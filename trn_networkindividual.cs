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
   public class trn_networkindividual : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Network Individual", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNetworkIndividualId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_networkindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_networkindividual( IGxContext context )
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
         cmbNetworkIndividualRelationship = new GXCombobox();
         cmbNetworkIndividualGender = new GXCombobox();
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
            return "trn_networkindividual_Execute" ;
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
         if ( cmbNetworkIndividualRelationship.ItemCount > 0 )
         {
            A495NetworkIndividualRelationship = cmbNetworkIndividualRelationship.getValidValue(A495NetworkIndividualRelationship);
            AssignAttri("", false, "A495NetworkIndividualRelationship", A495NetworkIndividualRelationship);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNetworkIndividualRelationship.CurrentValue = StringUtil.RTrim( A495NetworkIndividualRelationship);
            AssignProp("", false, cmbNetworkIndividualRelationship_Internalname, "Values", cmbNetworkIndividualRelationship.ToJavascriptSource(), true);
         }
         if ( cmbNetworkIndividualGender.ItemCount > 0 )
         {
            A81NetworkIndividualGender = cmbNetworkIndividualGender.getValidValue(A81NetworkIndividualGender);
            AssignAttri("", false, "A81NetworkIndividualGender", A81NetworkIndividualGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNetworkIndividualGender.CurrentValue = StringUtil.RTrim( A81NetworkIndividualGender);
            AssignProp("", false, cmbNetworkIndividualGender_Internalname, "Values", cmbNetworkIndividualGender.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Network Individual", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_NetworkIndividual.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_NetworkIndividual.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualId_Internalname, context.GetMessage( "Individual Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualId_Internalname, A74NetworkIndividualId.ToString(), A74NetworkIndividualId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkIndividualId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualBsnNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualBsnNumber_Internalname, context.GetMessage( "Bsn Number", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualBsnNumber_Internalname, A75NetworkIndividualBsnNumber, StringUtil.RTrim( context.localUtil.Format( A75NetworkIndividualBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkIndividualBsnNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualBsnNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "BsnNumber", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualGivenName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualGivenName_Internalname, context.GetMessage( "Given Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualGivenName_Internalname, A76NetworkIndividualGivenName, StringUtil.RTrim( context.localUtil.Format( A76NetworkIndividualGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkIndividualGivenName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualGivenName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualLastName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualLastName_Internalname, context.GetMessage( "Last Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualLastName_Internalname, A77NetworkIndividualLastName, StringUtil.RTrim( context.localUtil.Format( A77NetworkIndividualLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkIndividualLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualEmail_Internalname, context.GetMessage( "Individual Email", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualEmail_Internalname, A78NetworkIndividualEmail, StringUtil.RTrim( context.localUtil.Format( A78NetworkIndividualEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A78NetworkIndividualEmail, "", "", "", edtNetworkIndividualEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualPhone_Internalname, context.GetMessage( "Individual Phone", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A79NetworkIndividualPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualPhone_Internalname, StringUtil.RTrim( A79NetworkIndividualPhone), StringUtil.RTrim( context.localUtil.Format( A79NetworkIndividualPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtNetworkIndividualPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualHomePhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualHomePhone_Internalname, context.GetMessage( "Home Phone", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A433NetworkIndividualHomePhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualHomePhone_Internalname, StringUtil.RTrim( A433NetworkIndividualHomePhone), StringUtil.RTrim( context.localUtil.Format( A433NetworkIndividualHomePhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtNetworkIndividualHomePhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualHomePhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualPhoneCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualPhoneCode_Internalname, context.GetMessage( "Phone Code", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualPhoneCode_Internalname, A359NetworkIndividualPhoneCode, StringUtil.RTrim( context.localUtil.Format( A359NetworkIndividualPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkIndividualPhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualPhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualHomePhoneCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualHomePhoneCode_Internalname, context.GetMessage( "Phone Code", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualHomePhoneCode_Internalname, A434NetworkIndividualHomePhoneCode, StringUtil.RTrim( context.localUtil.Format( A434NetworkIndividualHomePhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkIndividualHomePhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualHomePhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualPhoneNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualPhoneNumber_Internalname, context.GetMessage( "Phone Number", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualPhoneNumber_Internalname, A360NetworkIndividualPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A360NetworkIndividualPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkIndividualPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualHomePhoneNumb_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualHomePhoneNumb_Internalname, context.GetMessage( "Phone Number", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualHomePhoneNumb_Internalname, A435NetworkIndividualHomePhoneNumb, StringUtil.RTrim( context.localUtil.Format( A435NetworkIndividualHomePhoneNumb, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkIndividualHomePhoneNumb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualHomePhoneNumb_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNetworkIndividualRelationship_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNetworkIndividualRelationship_Internalname, context.GetMessage( "Relationship", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNetworkIndividualRelationship, cmbNetworkIndividualRelationship_Internalname, StringUtil.RTrim( A495NetworkIndividualRelationship), 1, cmbNetworkIndividualRelationship_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNetworkIndividualRelationship.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_Trn_NetworkIndividual.htm");
         cmbNetworkIndividualRelationship.CurrentValue = StringUtil.RTrim( A495NetworkIndividualRelationship);
         AssignProp("", false, cmbNetworkIndividualRelationship_Internalname, "Values", (string)(cmbNetworkIndividualRelationship.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNetworkIndividualGender_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNetworkIndividualGender_Internalname, context.GetMessage( "Individual Gender", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNetworkIndividualGender, cmbNetworkIndividualGender_Internalname, StringUtil.RTrim( A81NetworkIndividualGender), 1, cmbNetworkIndividualGender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNetworkIndividualGender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "", true, 0, "HLP_Trn_NetworkIndividual.htm");
         cmbNetworkIndividualGender.CurrentValue = StringUtil.RTrim( A81NetworkIndividualGender);
         AssignProp("", false, cmbNetworkIndividualGender_Internalname, "Values", (string)(cmbNetworkIndividualGender.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualCountry_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualCountry_Internalname, context.GetMessage( "Individual Country", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualCountry_Internalname, A322NetworkIndividualCountry, StringUtil.RTrim( context.localUtil.Format( A322NetworkIndividualCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkIndividualCountry_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualCountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualCity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualCity_Internalname, context.GetMessage( "Individual City", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualCity_Internalname, A323NetworkIndividualCity, StringUtil.RTrim( context.localUtil.Format( A323NetworkIndividualCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkIndividualCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualZipCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualZipCode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualZipCode_Internalname, A324NetworkIndividualZipCode, StringUtil.RTrim( context.localUtil.Format( A324NetworkIndividualZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkIndividualZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualAddressLine1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualAddressLine1_Internalname, context.GetMessage( "Address Line1", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualAddressLine1_Internalname, A325NetworkIndividualAddressLine1, StringUtil.RTrim( context.localUtil.Format( A325NetworkIndividualAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkIndividualAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNetworkIndividualAddressLine2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNetworkIndividualAddressLine2_Internalname, context.GetMessage( "Address Line2", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNetworkIndividualAddressLine2_Internalname, A326NetworkIndividualAddressLine2, StringUtil.RTrim( context.localUtil.Format( A326NetworkIndividualAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNetworkIndividualAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNetworkIndividualAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_NetworkIndividual.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkIndividual.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_NetworkIndividual.htm");
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
            Z74NetworkIndividualId = StringUtil.StrToGuid( cgiGet( "Z74NetworkIndividualId"));
            Z75NetworkIndividualBsnNumber = cgiGet( "Z75NetworkIndividualBsnNumber");
            Z76NetworkIndividualGivenName = cgiGet( "Z76NetworkIndividualGivenName");
            Z77NetworkIndividualLastName = cgiGet( "Z77NetworkIndividualLastName");
            Z78NetworkIndividualEmail = cgiGet( "Z78NetworkIndividualEmail");
            Z79NetworkIndividualPhone = cgiGet( "Z79NetworkIndividualPhone");
            Z433NetworkIndividualHomePhone = cgiGet( "Z433NetworkIndividualHomePhone");
            Z359NetworkIndividualPhoneCode = cgiGet( "Z359NetworkIndividualPhoneCode");
            Z434NetworkIndividualHomePhoneCode = cgiGet( "Z434NetworkIndividualHomePhoneCode");
            Z360NetworkIndividualPhoneNumber = cgiGet( "Z360NetworkIndividualPhoneNumber");
            Z435NetworkIndividualHomePhoneNumb = cgiGet( "Z435NetworkIndividualHomePhoneNumb");
            Z495NetworkIndividualRelationship = cgiGet( "Z495NetworkIndividualRelationship");
            Z81NetworkIndividualGender = cgiGet( "Z81NetworkIndividualGender");
            Z322NetworkIndividualCountry = cgiGet( "Z322NetworkIndividualCountry");
            Z323NetworkIndividualCity = cgiGet( "Z323NetworkIndividualCity");
            Z324NetworkIndividualZipCode = cgiGet( "Z324NetworkIndividualZipCode");
            Z325NetworkIndividualAddressLine1 = cgiGet( "Z325NetworkIndividualAddressLine1");
            Z326NetworkIndividualAddressLine2 = cgiGet( "Z326NetworkIndividualAddressLine2");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtNetworkIndividualId_Internalname), "") == 0 )
            {
               A74NetworkIndividualId = Guid.Empty;
               AssignAttri("", false, "A74NetworkIndividualId", A74NetworkIndividualId.ToString());
            }
            else
            {
               try
               {
                  A74NetworkIndividualId = StringUtil.StrToGuid( cgiGet( edtNetworkIndividualId_Internalname));
                  AssignAttri("", false, "A74NetworkIndividualId", A74NetworkIndividualId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "NETWORKINDIVIDUALID");
                  AnyError = 1;
                  GX_FocusControl = edtNetworkIndividualId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A75NetworkIndividualBsnNumber = cgiGet( edtNetworkIndividualBsnNumber_Internalname);
            AssignAttri("", false, "A75NetworkIndividualBsnNumber", A75NetworkIndividualBsnNumber);
            A76NetworkIndividualGivenName = cgiGet( edtNetworkIndividualGivenName_Internalname);
            AssignAttri("", false, "A76NetworkIndividualGivenName", A76NetworkIndividualGivenName);
            A77NetworkIndividualLastName = cgiGet( edtNetworkIndividualLastName_Internalname);
            AssignAttri("", false, "A77NetworkIndividualLastName", A77NetworkIndividualLastName);
            A78NetworkIndividualEmail = cgiGet( edtNetworkIndividualEmail_Internalname);
            AssignAttri("", false, "A78NetworkIndividualEmail", A78NetworkIndividualEmail);
            A79NetworkIndividualPhone = cgiGet( edtNetworkIndividualPhone_Internalname);
            AssignAttri("", false, "A79NetworkIndividualPhone", A79NetworkIndividualPhone);
            A433NetworkIndividualHomePhone = cgiGet( edtNetworkIndividualHomePhone_Internalname);
            AssignAttri("", false, "A433NetworkIndividualHomePhone", A433NetworkIndividualHomePhone);
            A359NetworkIndividualPhoneCode = cgiGet( edtNetworkIndividualPhoneCode_Internalname);
            AssignAttri("", false, "A359NetworkIndividualPhoneCode", A359NetworkIndividualPhoneCode);
            A434NetworkIndividualHomePhoneCode = cgiGet( edtNetworkIndividualHomePhoneCode_Internalname);
            AssignAttri("", false, "A434NetworkIndividualHomePhoneCode", A434NetworkIndividualHomePhoneCode);
            A360NetworkIndividualPhoneNumber = cgiGet( edtNetworkIndividualPhoneNumber_Internalname);
            AssignAttri("", false, "A360NetworkIndividualPhoneNumber", A360NetworkIndividualPhoneNumber);
            A435NetworkIndividualHomePhoneNumb = cgiGet( edtNetworkIndividualHomePhoneNumb_Internalname);
            AssignAttri("", false, "A435NetworkIndividualHomePhoneNumb", A435NetworkIndividualHomePhoneNumb);
            cmbNetworkIndividualRelationship.CurrentValue = cgiGet( cmbNetworkIndividualRelationship_Internalname);
            A495NetworkIndividualRelationship = cgiGet( cmbNetworkIndividualRelationship_Internalname);
            AssignAttri("", false, "A495NetworkIndividualRelationship", A495NetworkIndividualRelationship);
            cmbNetworkIndividualGender.CurrentValue = cgiGet( cmbNetworkIndividualGender_Internalname);
            A81NetworkIndividualGender = cgiGet( cmbNetworkIndividualGender_Internalname);
            AssignAttri("", false, "A81NetworkIndividualGender", A81NetworkIndividualGender);
            A322NetworkIndividualCountry = cgiGet( edtNetworkIndividualCountry_Internalname);
            AssignAttri("", false, "A322NetworkIndividualCountry", A322NetworkIndividualCountry);
            A323NetworkIndividualCity = cgiGet( edtNetworkIndividualCity_Internalname);
            AssignAttri("", false, "A323NetworkIndividualCity", A323NetworkIndividualCity);
            A324NetworkIndividualZipCode = cgiGet( edtNetworkIndividualZipCode_Internalname);
            AssignAttri("", false, "A324NetworkIndividualZipCode", A324NetworkIndividualZipCode);
            A325NetworkIndividualAddressLine1 = cgiGet( edtNetworkIndividualAddressLine1_Internalname);
            AssignAttri("", false, "A325NetworkIndividualAddressLine1", A325NetworkIndividualAddressLine1);
            A326NetworkIndividualAddressLine2 = cgiGet( edtNetworkIndividualAddressLine2_Internalname);
            AssignAttri("", false, "A326NetworkIndividualAddressLine2", A326NetworkIndividualAddressLine2);
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
               A74NetworkIndividualId = StringUtil.StrToGuid( GetPar( "NetworkIndividualId"));
               AssignAttri("", false, "A74NetworkIndividualId", A74NetworkIndividualId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A74NetworkIndividualId) && ( Gx_BScreen == 0 ) )
               {
                  A74NetworkIndividualId = Guid.NewGuid( );
                  AssignAttri("", false, "A74NetworkIndividualId", A74NetworkIndividualId.ToString());
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
               InitAll0A17( ) ;
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
         DisableAttributes0A17( ) ;
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

      protected void ResetCaption0A0( )
      {
      }

      protected void ZM0A17( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z75NetworkIndividualBsnNumber = T000A3_A75NetworkIndividualBsnNumber[0];
               Z76NetworkIndividualGivenName = T000A3_A76NetworkIndividualGivenName[0];
               Z77NetworkIndividualLastName = T000A3_A77NetworkIndividualLastName[0];
               Z78NetworkIndividualEmail = T000A3_A78NetworkIndividualEmail[0];
               Z79NetworkIndividualPhone = T000A3_A79NetworkIndividualPhone[0];
               Z433NetworkIndividualHomePhone = T000A3_A433NetworkIndividualHomePhone[0];
               Z359NetworkIndividualPhoneCode = T000A3_A359NetworkIndividualPhoneCode[0];
               Z434NetworkIndividualHomePhoneCode = T000A3_A434NetworkIndividualHomePhoneCode[0];
               Z360NetworkIndividualPhoneNumber = T000A3_A360NetworkIndividualPhoneNumber[0];
               Z435NetworkIndividualHomePhoneNumb = T000A3_A435NetworkIndividualHomePhoneNumb[0];
               Z495NetworkIndividualRelationship = T000A3_A495NetworkIndividualRelationship[0];
               Z81NetworkIndividualGender = T000A3_A81NetworkIndividualGender[0];
               Z322NetworkIndividualCountry = T000A3_A322NetworkIndividualCountry[0];
               Z323NetworkIndividualCity = T000A3_A323NetworkIndividualCity[0];
               Z324NetworkIndividualZipCode = T000A3_A324NetworkIndividualZipCode[0];
               Z325NetworkIndividualAddressLine1 = T000A3_A325NetworkIndividualAddressLine1[0];
               Z326NetworkIndividualAddressLine2 = T000A3_A326NetworkIndividualAddressLine2[0];
            }
            else
            {
               Z75NetworkIndividualBsnNumber = A75NetworkIndividualBsnNumber;
               Z76NetworkIndividualGivenName = A76NetworkIndividualGivenName;
               Z77NetworkIndividualLastName = A77NetworkIndividualLastName;
               Z78NetworkIndividualEmail = A78NetworkIndividualEmail;
               Z79NetworkIndividualPhone = A79NetworkIndividualPhone;
               Z433NetworkIndividualHomePhone = A433NetworkIndividualHomePhone;
               Z359NetworkIndividualPhoneCode = A359NetworkIndividualPhoneCode;
               Z434NetworkIndividualHomePhoneCode = A434NetworkIndividualHomePhoneCode;
               Z360NetworkIndividualPhoneNumber = A360NetworkIndividualPhoneNumber;
               Z435NetworkIndividualHomePhoneNumb = A435NetworkIndividualHomePhoneNumb;
               Z495NetworkIndividualRelationship = A495NetworkIndividualRelationship;
               Z81NetworkIndividualGender = A81NetworkIndividualGender;
               Z322NetworkIndividualCountry = A322NetworkIndividualCountry;
               Z323NetworkIndividualCity = A323NetworkIndividualCity;
               Z324NetworkIndividualZipCode = A324NetworkIndividualZipCode;
               Z325NetworkIndividualAddressLine1 = A325NetworkIndividualAddressLine1;
               Z326NetworkIndividualAddressLine2 = A326NetworkIndividualAddressLine2;
            }
         }
         if ( GX_JID == -9 )
         {
            Z74NetworkIndividualId = A74NetworkIndividualId;
            Z75NetworkIndividualBsnNumber = A75NetworkIndividualBsnNumber;
            Z76NetworkIndividualGivenName = A76NetworkIndividualGivenName;
            Z77NetworkIndividualLastName = A77NetworkIndividualLastName;
            Z78NetworkIndividualEmail = A78NetworkIndividualEmail;
            Z79NetworkIndividualPhone = A79NetworkIndividualPhone;
            Z433NetworkIndividualHomePhone = A433NetworkIndividualHomePhone;
            Z359NetworkIndividualPhoneCode = A359NetworkIndividualPhoneCode;
            Z434NetworkIndividualHomePhoneCode = A434NetworkIndividualHomePhoneCode;
            Z360NetworkIndividualPhoneNumber = A360NetworkIndividualPhoneNumber;
            Z435NetworkIndividualHomePhoneNumb = A435NetworkIndividualHomePhoneNumb;
            Z495NetworkIndividualRelationship = A495NetworkIndividualRelationship;
            Z81NetworkIndividualGender = A81NetworkIndividualGender;
            Z322NetworkIndividualCountry = A322NetworkIndividualCountry;
            Z323NetworkIndividualCity = A323NetworkIndividualCity;
            Z324NetworkIndividualZipCode = A324NetworkIndividualZipCode;
            Z325NetworkIndividualAddressLine1 = A325NetworkIndividualAddressLine1;
            Z326NetworkIndividualAddressLine2 = A326NetworkIndividualAddressLine2;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A74NetworkIndividualId) && ( Gx_BScreen == 0 ) )
         {
            A74NetworkIndividualId = Guid.NewGuid( );
            AssignAttri("", false, "A74NetworkIndividualId", A74NetworkIndividualId.ToString());
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

      protected void Load0A17( )
      {
         /* Using cursor T000A4 */
         pr_default.execute(2, new Object[] {A74NetworkIndividualId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound17 = 1;
            A75NetworkIndividualBsnNumber = T000A4_A75NetworkIndividualBsnNumber[0];
            AssignAttri("", false, "A75NetworkIndividualBsnNumber", A75NetworkIndividualBsnNumber);
            A76NetworkIndividualGivenName = T000A4_A76NetworkIndividualGivenName[0];
            AssignAttri("", false, "A76NetworkIndividualGivenName", A76NetworkIndividualGivenName);
            A77NetworkIndividualLastName = T000A4_A77NetworkIndividualLastName[0];
            AssignAttri("", false, "A77NetworkIndividualLastName", A77NetworkIndividualLastName);
            A78NetworkIndividualEmail = T000A4_A78NetworkIndividualEmail[0];
            AssignAttri("", false, "A78NetworkIndividualEmail", A78NetworkIndividualEmail);
            A79NetworkIndividualPhone = T000A4_A79NetworkIndividualPhone[0];
            AssignAttri("", false, "A79NetworkIndividualPhone", A79NetworkIndividualPhone);
            A433NetworkIndividualHomePhone = T000A4_A433NetworkIndividualHomePhone[0];
            AssignAttri("", false, "A433NetworkIndividualHomePhone", A433NetworkIndividualHomePhone);
            A359NetworkIndividualPhoneCode = T000A4_A359NetworkIndividualPhoneCode[0];
            AssignAttri("", false, "A359NetworkIndividualPhoneCode", A359NetworkIndividualPhoneCode);
            A434NetworkIndividualHomePhoneCode = T000A4_A434NetworkIndividualHomePhoneCode[0];
            AssignAttri("", false, "A434NetworkIndividualHomePhoneCode", A434NetworkIndividualHomePhoneCode);
            A360NetworkIndividualPhoneNumber = T000A4_A360NetworkIndividualPhoneNumber[0];
            AssignAttri("", false, "A360NetworkIndividualPhoneNumber", A360NetworkIndividualPhoneNumber);
            A435NetworkIndividualHomePhoneNumb = T000A4_A435NetworkIndividualHomePhoneNumb[0];
            AssignAttri("", false, "A435NetworkIndividualHomePhoneNumb", A435NetworkIndividualHomePhoneNumb);
            A495NetworkIndividualRelationship = T000A4_A495NetworkIndividualRelationship[0];
            AssignAttri("", false, "A495NetworkIndividualRelationship", A495NetworkIndividualRelationship);
            A81NetworkIndividualGender = T000A4_A81NetworkIndividualGender[0];
            AssignAttri("", false, "A81NetworkIndividualGender", A81NetworkIndividualGender);
            A322NetworkIndividualCountry = T000A4_A322NetworkIndividualCountry[0];
            AssignAttri("", false, "A322NetworkIndividualCountry", A322NetworkIndividualCountry);
            A323NetworkIndividualCity = T000A4_A323NetworkIndividualCity[0];
            AssignAttri("", false, "A323NetworkIndividualCity", A323NetworkIndividualCity);
            A324NetworkIndividualZipCode = T000A4_A324NetworkIndividualZipCode[0];
            AssignAttri("", false, "A324NetworkIndividualZipCode", A324NetworkIndividualZipCode);
            A325NetworkIndividualAddressLine1 = T000A4_A325NetworkIndividualAddressLine1[0];
            AssignAttri("", false, "A325NetworkIndividualAddressLine1", A325NetworkIndividualAddressLine1);
            A326NetworkIndividualAddressLine2 = T000A4_A326NetworkIndividualAddressLine2[0];
            AssignAttri("", false, "A326NetworkIndividualAddressLine2", A326NetworkIndividualAddressLine2);
            ZM0A17( -9) ;
         }
         pr_default.close(2);
         OnLoadActions0A17( ) ;
      }

      protected void OnLoadActions0A17( )
      {
      }

      protected void CheckExtendedTable0A17( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A75NetworkIndividualBsnNumber)) && ( StringUtil.Len( A75NetworkIndividualBsnNumber) != 9 ) )
         {
            GX_msglist.addItem(context.GetMessage( "BSN number contains 9 digits", ""), 1, "NETWORKINDIVIDUALBSNNUMBER");
            AnyError = 1;
            GX_FocusControl = edtNetworkIndividualBsnNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A78NetworkIndividualEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Network Individual Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "NETWORKINDIVIDUALEMAIL");
            AnyError = 1;
            GX_FocusControl = edtNetworkIndividualEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A360NetworkIndividualPhoneNumber)) && ! GxRegex.IsMatch(A360NetworkIndividualPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "NETWORKINDIVIDUALPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtNetworkIndividualPhoneNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A435NetworkIndividualHomePhoneNumb)) && ! GxRegex.IsMatch(A435NetworkIndividualHomePhoneNumb,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "NETWORKINDIVIDUALHOMEPHONENUMB");
            AnyError = 1;
            GX_FocusControl = edtNetworkIndividualHomePhoneNumb_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A81NetworkIndividualGender, "Male") == 0 ) || ( StringUtil.StrCmp(A81NetworkIndividualGender, "Female") == 0 ) || ( StringUtil.StrCmp(A81NetworkIndividualGender, "Other") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Network Individual Gender", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "NETWORKINDIVIDUALGENDER");
            AnyError = 1;
            GX_FocusControl = cmbNetworkIndividualGender_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! GxRegex.IsMatch(A324NetworkIndividualZipCode,context.GetMessage( "^\\d{4}\\s?[A-Z]{2}$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A324NetworkIndividualZipCode)) )
         {
            GX_msglist.addItem(context.GetMessage( "Zip Code is incorrect", ""), 1, "NETWORKINDIVIDUALZIPCODE");
            AnyError = 1;
            GX_FocusControl = edtNetworkIndividualZipCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0A17( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0A17( )
      {
         /* Using cursor T000A5 */
         pr_default.execute(3, new Object[] {A74NetworkIndividualId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A74NetworkIndividualId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A17( 9) ;
            RcdFound17 = 1;
            A74NetworkIndividualId = T000A3_A74NetworkIndividualId[0];
            AssignAttri("", false, "A74NetworkIndividualId", A74NetworkIndividualId.ToString());
            A75NetworkIndividualBsnNumber = T000A3_A75NetworkIndividualBsnNumber[0];
            AssignAttri("", false, "A75NetworkIndividualBsnNumber", A75NetworkIndividualBsnNumber);
            A76NetworkIndividualGivenName = T000A3_A76NetworkIndividualGivenName[0];
            AssignAttri("", false, "A76NetworkIndividualGivenName", A76NetworkIndividualGivenName);
            A77NetworkIndividualLastName = T000A3_A77NetworkIndividualLastName[0];
            AssignAttri("", false, "A77NetworkIndividualLastName", A77NetworkIndividualLastName);
            A78NetworkIndividualEmail = T000A3_A78NetworkIndividualEmail[0];
            AssignAttri("", false, "A78NetworkIndividualEmail", A78NetworkIndividualEmail);
            A79NetworkIndividualPhone = T000A3_A79NetworkIndividualPhone[0];
            AssignAttri("", false, "A79NetworkIndividualPhone", A79NetworkIndividualPhone);
            A433NetworkIndividualHomePhone = T000A3_A433NetworkIndividualHomePhone[0];
            AssignAttri("", false, "A433NetworkIndividualHomePhone", A433NetworkIndividualHomePhone);
            A359NetworkIndividualPhoneCode = T000A3_A359NetworkIndividualPhoneCode[0];
            AssignAttri("", false, "A359NetworkIndividualPhoneCode", A359NetworkIndividualPhoneCode);
            A434NetworkIndividualHomePhoneCode = T000A3_A434NetworkIndividualHomePhoneCode[0];
            AssignAttri("", false, "A434NetworkIndividualHomePhoneCode", A434NetworkIndividualHomePhoneCode);
            A360NetworkIndividualPhoneNumber = T000A3_A360NetworkIndividualPhoneNumber[0];
            AssignAttri("", false, "A360NetworkIndividualPhoneNumber", A360NetworkIndividualPhoneNumber);
            A435NetworkIndividualHomePhoneNumb = T000A3_A435NetworkIndividualHomePhoneNumb[0];
            AssignAttri("", false, "A435NetworkIndividualHomePhoneNumb", A435NetworkIndividualHomePhoneNumb);
            A495NetworkIndividualRelationship = T000A3_A495NetworkIndividualRelationship[0];
            AssignAttri("", false, "A495NetworkIndividualRelationship", A495NetworkIndividualRelationship);
            A81NetworkIndividualGender = T000A3_A81NetworkIndividualGender[0];
            AssignAttri("", false, "A81NetworkIndividualGender", A81NetworkIndividualGender);
            A322NetworkIndividualCountry = T000A3_A322NetworkIndividualCountry[0];
            AssignAttri("", false, "A322NetworkIndividualCountry", A322NetworkIndividualCountry);
            A323NetworkIndividualCity = T000A3_A323NetworkIndividualCity[0];
            AssignAttri("", false, "A323NetworkIndividualCity", A323NetworkIndividualCity);
            A324NetworkIndividualZipCode = T000A3_A324NetworkIndividualZipCode[0];
            AssignAttri("", false, "A324NetworkIndividualZipCode", A324NetworkIndividualZipCode);
            A325NetworkIndividualAddressLine1 = T000A3_A325NetworkIndividualAddressLine1[0];
            AssignAttri("", false, "A325NetworkIndividualAddressLine1", A325NetworkIndividualAddressLine1);
            A326NetworkIndividualAddressLine2 = T000A3_A326NetworkIndividualAddressLine2[0];
            AssignAttri("", false, "A326NetworkIndividualAddressLine2", A326NetworkIndividualAddressLine2);
            Z74NetworkIndividualId = A74NetworkIndividualId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0A17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0A17( ) ;
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0A17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A17( ) ;
         if ( RcdFound17 == 0 )
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
         RcdFound17 = 0;
         /* Using cursor T000A6 */
         pr_default.execute(4, new Object[] {A74NetworkIndividualId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T000A6_A74NetworkIndividualId[0], A74NetworkIndividualId, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T000A6_A74NetworkIndividualId[0], A74NetworkIndividualId, 0) > 0 ) ) )
            {
               A74NetworkIndividualId = T000A6_A74NetworkIndividualId[0];
               AssignAttri("", false, "A74NetworkIndividualId", A74NetworkIndividualId.ToString());
               RcdFound17 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound17 = 0;
         /* Using cursor T000A7 */
         pr_default.execute(5, new Object[] {A74NetworkIndividualId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T000A7_A74NetworkIndividualId[0], A74NetworkIndividualId, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T000A7_A74NetworkIndividualId[0], A74NetworkIndividualId, 0) < 0 ) ) )
            {
               A74NetworkIndividualId = T000A7_A74NetworkIndividualId[0];
               AssignAttri("", false, "A74NetworkIndividualId", A74NetworkIndividualId.ToString());
               RcdFound17 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNetworkIndividualId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A17( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A74NetworkIndividualId != Z74NetworkIndividualId )
               {
                  A74NetworkIndividualId = Z74NetworkIndividualId;
                  AssignAttri("", false, "A74NetworkIndividualId", A74NetworkIndividualId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "NETWORKINDIVIDUALID");
                  AnyError = 1;
                  GX_FocusControl = edtNetworkIndividualId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNetworkIndividualId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0A17( ) ;
                  GX_FocusControl = edtNetworkIndividualId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A74NetworkIndividualId != Z74NetworkIndividualId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtNetworkIndividualId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A17( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "NETWORKINDIVIDUALID");
                     AnyError = 1;
                     GX_FocusControl = edtNetworkIndividualId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtNetworkIndividualId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A17( ) ;
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
         if ( A74NetworkIndividualId != Z74NetworkIndividualId )
         {
            A74NetworkIndividualId = Z74NetworkIndividualId;
            AssignAttri("", false, "A74NetworkIndividualId", A74NetworkIndividualId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "NETWORKINDIVIDUALID");
            AnyError = 1;
            GX_FocusControl = edtNetworkIndividualId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNetworkIndividualId_Internalname;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "NETWORKINDIVIDUALID");
            AnyError = 1;
            GX_FocusControl = edtNetworkIndividualId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtNetworkIndividualBsnNumber_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNetworkIndividualBsnNumber_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A17( ) ;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNetworkIndividualBsnNumber_Internalname;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNetworkIndividualBsnNumber_Internalname;
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
         ScanStart0A17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound17 != 0 )
            {
               ScanNext0A17( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNetworkIndividualBsnNumber_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A17( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0A17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A74NetworkIndividualId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_NetworkIndividual"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z75NetworkIndividualBsnNumber, T000A2_A75NetworkIndividualBsnNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z76NetworkIndividualGivenName, T000A2_A76NetworkIndividualGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z77NetworkIndividualLastName, T000A2_A77NetworkIndividualLastName[0]) != 0 ) || ( StringUtil.StrCmp(Z78NetworkIndividualEmail, T000A2_A78NetworkIndividualEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z79NetworkIndividualPhone, T000A2_A79NetworkIndividualPhone[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z433NetworkIndividualHomePhone, T000A2_A433NetworkIndividualHomePhone[0]) != 0 ) || ( StringUtil.StrCmp(Z359NetworkIndividualPhoneCode, T000A2_A359NetworkIndividualPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z434NetworkIndividualHomePhoneCode, T000A2_A434NetworkIndividualHomePhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z360NetworkIndividualPhoneNumber, T000A2_A360NetworkIndividualPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z435NetworkIndividualHomePhoneNumb, T000A2_A435NetworkIndividualHomePhoneNumb[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z495NetworkIndividualRelationship, T000A2_A495NetworkIndividualRelationship[0]) != 0 ) || ( StringUtil.StrCmp(Z81NetworkIndividualGender, T000A2_A81NetworkIndividualGender[0]) != 0 ) || ( StringUtil.StrCmp(Z322NetworkIndividualCountry, T000A2_A322NetworkIndividualCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z323NetworkIndividualCity, T000A2_A323NetworkIndividualCity[0]) != 0 ) || ( StringUtil.StrCmp(Z324NetworkIndividualZipCode, T000A2_A324NetworkIndividualZipCode[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z325NetworkIndividualAddressLine1, T000A2_A325NetworkIndividualAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z326NetworkIndividualAddressLine2, T000A2_A326NetworkIndividualAddressLine2[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z75NetworkIndividualBsnNumber, T000A2_A75NetworkIndividualBsnNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualBsnNumber");
                  GXUtil.WriteLogRaw("Old: ",Z75NetworkIndividualBsnNumber);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A75NetworkIndividualBsnNumber[0]);
               }
               if ( StringUtil.StrCmp(Z76NetworkIndividualGivenName, T000A2_A76NetworkIndividualGivenName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualGivenName");
                  GXUtil.WriteLogRaw("Old: ",Z76NetworkIndividualGivenName);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A76NetworkIndividualGivenName[0]);
               }
               if ( StringUtil.StrCmp(Z77NetworkIndividualLastName, T000A2_A77NetworkIndividualLastName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualLastName");
                  GXUtil.WriteLogRaw("Old: ",Z77NetworkIndividualLastName);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A77NetworkIndividualLastName[0]);
               }
               if ( StringUtil.StrCmp(Z78NetworkIndividualEmail, T000A2_A78NetworkIndividualEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualEmail");
                  GXUtil.WriteLogRaw("Old: ",Z78NetworkIndividualEmail);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A78NetworkIndividualEmail[0]);
               }
               if ( StringUtil.StrCmp(Z79NetworkIndividualPhone, T000A2_A79NetworkIndividualPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualPhone");
                  GXUtil.WriteLogRaw("Old: ",Z79NetworkIndividualPhone);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A79NetworkIndividualPhone[0]);
               }
               if ( StringUtil.StrCmp(Z433NetworkIndividualHomePhone, T000A2_A433NetworkIndividualHomePhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualHomePhone");
                  GXUtil.WriteLogRaw("Old: ",Z433NetworkIndividualHomePhone);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A433NetworkIndividualHomePhone[0]);
               }
               if ( StringUtil.StrCmp(Z359NetworkIndividualPhoneCode, T000A2_A359NetworkIndividualPhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualPhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z359NetworkIndividualPhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A359NetworkIndividualPhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z434NetworkIndividualHomePhoneCode, T000A2_A434NetworkIndividualHomePhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualHomePhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z434NetworkIndividualHomePhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A434NetworkIndividualHomePhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z360NetworkIndividualPhoneNumber, T000A2_A360NetworkIndividualPhoneNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualPhoneNumber");
                  GXUtil.WriteLogRaw("Old: ",Z360NetworkIndividualPhoneNumber);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A360NetworkIndividualPhoneNumber[0]);
               }
               if ( StringUtil.StrCmp(Z435NetworkIndividualHomePhoneNumb, T000A2_A435NetworkIndividualHomePhoneNumb[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualHomePhoneNumb");
                  GXUtil.WriteLogRaw("Old: ",Z435NetworkIndividualHomePhoneNumb);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A435NetworkIndividualHomePhoneNumb[0]);
               }
               if ( StringUtil.StrCmp(Z495NetworkIndividualRelationship, T000A2_A495NetworkIndividualRelationship[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualRelationship");
                  GXUtil.WriteLogRaw("Old: ",Z495NetworkIndividualRelationship);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A495NetworkIndividualRelationship[0]);
               }
               if ( StringUtil.StrCmp(Z81NetworkIndividualGender, T000A2_A81NetworkIndividualGender[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualGender");
                  GXUtil.WriteLogRaw("Old: ",Z81NetworkIndividualGender);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A81NetworkIndividualGender[0]);
               }
               if ( StringUtil.StrCmp(Z322NetworkIndividualCountry, T000A2_A322NetworkIndividualCountry[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualCountry");
                  GXUtil.WriteLogRaw("Old: ",Z322NetworkIndividualCountry);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A322NetworkIndividualCountry[0]);
               }
               if ( StringUtil.StrCmp(Z323NetworkIndividualCity, T000A2_A323NetworkIndividualCity[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualCity");
                  GXUtil.WriteLogRaw("Old: ",Z323NetworkIndividualCity);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A323NetworkIndividualCity[0]);
               }
               if ( StringUtil.StrCmp(Z324NetworkIndividualZipCode, T000A2_A324NetworkIndividualZipCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualZipCode");
                  GXUtil.WriteLogRaw("Old: ",Z324NetworkIndividualZipCode);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A324NetworkIndividualZipCode[0]);
               }
               if ( StringUtil.StrCmp(Z325NetworkIndividualAddressLine1, T000A2_A325NetworkIndividualAddressLine1[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualAddressLine1");
                  GXUtil.WriteLogRaw("Old: ",Z325NetworkIndividualAddressLine1);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A325NetworkIndividualAddressLine1[0]);
               }
               if ( StringUtil.StrCmp(Z326NetworkIndividualAddressLine2, T000A2_A326NetworkIndividualAddressLine2[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_networkindividual:[seudo value changed for attri]"+"NetworkIndividualAddressLine2");
                  GXUtil.WriteLogRaw("Old: ",Z326NetworkIndividualAddressLine2);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A326NetworkIndividualAddressLine2[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_NetworkIndividual"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A17( )
      {
         if ( ! IsAuthorized("trn_networkindividual_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A17( 0) ;
            CheckOptimisticConcurrency0A17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A8 */
                     pr_default.execute(6, new Object[] {A74NetworkIndividualId, A75NetworkIndividualBsnNumber, A76NetworkIndividualGivenName, A77NetworkIndividualLastName, A78NetworkIndividualEmail, A79NetworkIndividualPhone, A433NetworkIndividualHomePhone, A359NetworkIndividualPhoneCode, A434NetworkIndividualHomePhoneCode, A360NetworkIndividualPhoneNumber, A435NetworkIndividualHomePhoneNumb, A495NetworkIndividualRelationship, A81NetworkIndividualGender, A322NetworkIndividualCountry, A323NetworkIndividualCity, A324NetworkIndividualZipCode, A325NetworkIndividualAddressLine1, A326NetworkIndividualAddressLine2});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_NetworkIndividual");
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
                           ResetCaption0A0( ) ;
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
               Load0A17( ) ;
            }
            EndLevel0A17( ) ;
         }
         CloseExtendedTableCursors0A17( ) ;
      }

      protected void Update0A17( )
      {
         if ( ! IsAuthorized("trn_networkindividual_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A9 */
                     pr_default.execute(7, new Object[] {A75NetworkIndividualBsnNumber, A76NetworkIndividualGivenName, A77NetworkIndividualLastName, A78NetworkIndividualEmail, A79NetworkIndividualPhone, A433NetworkIndividualHomePhone, A359NetworkIndividualPhoneCode, A434NetworkIndividualHomePhoneCode, A360NetworkIndividualPhoneNumber, A435NetworkIndividualHomePhoneNumb, A495NetworkIndividualRelationship, A81NetworkIndividualGender, A322NetworkIndividualCountry, A323NetworkIndividualCity, A324NetworkIndividualZipCode, A325NetworkIndividualAddressLine1, A326NetworkIndividualAddressLine2, A74NetworkIndividualId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_NetworkIndividual");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_NetworkIndividual"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A17( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0A0( ) ;
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
            EndLevel0A17( ) ;
         }
         CloseExtendedTableCursors0A17( ) ;
      }

      protected void DeferredUpdate0A17( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_networkindividual_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0A17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A17( ) ;
            AfterConfirm0A17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A10 */
                  pr_default.execute(8, new Object[] {A74NetworkIndividualId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_NetworkIndividual");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound17 == 0 )
                        {
                           InitAll0A17( ) ;
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
                        ResetCaption0A0( ) ;
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A17( ) ;
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A17( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0A17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A17( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_networkindividual",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_networkindividual",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A17( )
      {
         /* Using cursor T000A11 */
         pr_default.execute(9);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound17 = 1;
            A74NetworkIndividualId = T000A11_A74NetworkIndividualId[0];
            AssignAttri("", false, "A74NetworkIndividualId", A74NetworkIndividualId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A17( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound17 = 1;
            A74NetworkIndividualId = T000A11_A74NetworkIndividualId[0];
            AssignAttri("", false, "A74NetworkIndividualId", A74NetworkIndividualId.ToString());
         }
      }

      protected void ScanEnd0A17( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0A17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A17( )
      {
         edtNetworkIndividualId_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualId_Enabled), 5, 0), true);
         edtNetworkIndividualBsnNumber_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualBsnNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualBsnNumber_Enabled), 5, 0), true);
         edtNetworkIndividualGivenName_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualGivenName_Enabled), 5, 0), true);
         edtNetworkIndividualLastName_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualLastName_Enabled), 5, 0), true);
         edtNetworkIndividualEmail_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualEmail_Enabled), 5, 0), true);
         edtNetworkIndividualPhone_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualPhone_Enabled), 5, 0), true);
         edtNetworkIndividualHomePhone_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualHomePhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualHomePhone_Enabled), 5, 0), true);
         edtNetworkIndividualPhoneCode_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualPhoneCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualPhoneCode_Enabled), 5, 0), true);
         edtNetworkIndividualHomePhoneCode_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualHomePhoneCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualHomePhoneCode_Enabled), 5, 0), true);
         edtNetworkIndividualPhoneNumber_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualPhoneNumber_Enabled), 5, 0), true);
         edtNetworkIndividualHomePhoneNumb_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualHomePhoneNumb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualHomePhoneNumb_Enabled), 5, 0), true);
         cmbNetworkIndividualRelationship.Enabled = 0;
         AssignProp("", false, cmbNetworkIndividualRelationship_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNetworkIndividualRelationship.Enabled), 5, 0), true);
         cmbNetworkIndividualGender.Enabled = 0;
         AssignProp("", false, cmbNetworkIndividualGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNetworkIndividualGender.Enabled), 5, 0), true);
         edtNetworkIndividualCountry_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualCountry_Enabled), 5, 0), true);
         edtNetworkIndividualCity_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualCity_Enabled), 5, 0), true);
         edtNetworkIndividualZipCode_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualZipCode_Enabled), 5, 0), true);
         edtNetworkIndividualAddressLine1_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualAddressLine1_Enabled), 5, 0), true);
         edtNetworkIndividualAddressLine2_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualAddressLine2_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0A17( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0A0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_networkindividual.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z74NetworkIndividualId", Z74NetworkIndividualId.ToString());
         GxWebStd.gx_hidden_field( context, "Z75NetworkIndividualBsnNumber", Z75NetworkIndividualBsnNumber);
         GxWebStd.gx_hidden_field( context, "Z76NetworkIndividualGivenName", Z76NetworkIndividualGivenName);
         GxWebStd.gx_hidden_field( context, "Z77NetworkIndividualLastName", Z77NetworkIndividualLastName);
         GxWebStd.gx_hidden_field( context, "Z78NetworkIndividualEmail", Z78NetworkIndividualEmail);
         GxWebStd.gx_hidden_field( context, "Z79NetworkIndividualPhone", StringUtil.RTrim( Z79NetworkIndividualPhone));
         GxWebStd.gx_hidden_field( context, "Z433NetworkIndividualHomePhone", StringUtil.RTrim( Z433NetworkIndividualHomePhone));
         GxWebStd.gx_hidden_field( context, "Z359NetworkIndividualPhoneCode", Z359NetworkIndividualPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z434NetworkIndividualHomePhoneCode", Z434NetworkIndividualHomePhoneCode);
         GxWebStd.gx_hidden_field( context, "Z360NetworkIndividualPhoneNumber", Z360NetworkIndividualPhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z435NetworkIndividualHomePhoneNumb", Z435NetworkIndividualHomePhoneNumb);
         GxWebStd.gx_hidden_field( context, "Z495NetworkIndividualRelationship", Z495NetworkIndividualRelationship);
         GxWebStd.gx_hidden_field( context, "Z81NetworkIndividualGender", Z81NetworkIndividualGender);
         GxWebStd.gx_hidden_field( context, "Z322NetworkIndividualCountry", Z322NetworkIndividualCountry);
         GxWebStd.gx_hidden_field( context, "Z323NetworkIndividualCity", Z323NetworkIndividualCity);
         GxWebStd.gx_hidden_field( context, "Z324NetworkIndividualZipCode", Z324NetworkIndividualZipCode);
         GxWebStd.gx_hidden_field( context, "Z325NetworkIndividualAddressLine1", Z325NetworkIndividualAddressLine1);
         GxWebStd.gx_hidden_field( context, "Z326NetworkIndividualAddressLine2", Z326NetworkIndividualAddressLine2);
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
         return formatLink("trn_networkindividual.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_NetworkIndividual" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Network Individual", "") ;
      }

      protected void InitializeNonKey0A17( )
      {
         A75NetworkIndividualBsnNumber = "";
         AssignAttri("", false, "A75NetworkIndividualBsnNumber", A75NetworkIndividualBsnNumber);
         A76NetworkIndividualGivenName = "";
         AssignAttri("", false, "A76NetworkIndividualGivenName", A76NetworkIndividualGivenName);
         A77NetworkIndividualLastName = "";
         AssignAttri("", false, "A77NetworkIndividualLastName", A77NetworkIndividualLastName);
         A78NetworkIndividualEmail = "";
         AssignAttri("", false, "A78NetworkIndividualEmail", A78NetworkIndividualEmail);
         A79NetworkIndividualPhone = "";
         AssignAttri("", false, "A79NetworkIndividualPhone", A79NetworkIndividualPhone);
         A433NetworkIndividualHomePhone = "";
         AssignAttri("", false, "A433NetworkIndividualHomePhone", A433NetworkIndividualHomePhone);
         A359NetworkIndividualPhoneCode = "";
         AssignAttri("", false, "A359NetworkIndividualPhoneCode", A359NetworkIndividualPhoneCode);
         A434NetworkIndividualHomePhoneCode = "";
         AssignAttri("", false, "A434NetworkIndividualHomePhoneCode", A434NetworkIndividualHomePhoneCode);
         A360NetworkIndividualPhoneNumber = "";
         AssignAttri("", false, "A360NetworkIndividualPhoneNumber", A360NetworkIndividualPhoneNumber);
         A435NetworkIndividualHomePhoneNumb = "";
         AssignAttri("", false, "A435NetworkIndividualHomePhoneNumb", A435NetworkIndividualHomePhoneNumb);
         A495NetworkIndividualRelationship = "";
         AssignAttri("", false, "A495NetworkIndividualRelationship", A495NetworkIndividualRelationship);
         A81NetworkIndividualGender = "";
         AssignAttri("", false, "A81NetworkIndividualGender", A81NetworkIndividualGender);
         A322NetworkIndividualCountry = "";
         AssignAttri("", false, "A322NetworkIndividualCountry", A322NetworkIndividualCountry);
         A323NetworkIndividualCity = "";
         AssignAttri("", false, "A323NetworkIndividualCity", A323NetworkIndividualCity);
         A324NetworkIndividualZipCode = "";
         AssignAttri("", false, "A324NetworkIndividualZipCode", A324NetworkIndividualZipCode);
         A325NetworkIndividualAddressLine1 = "";
         AssignAttri("", false, "A325NetworkIndividualAddressLine1", A325NetworkIndividualAddressLine1);
         A326NetworkIndividualAddressLine2 = "";
         AssignAttri("", false, "A326NetworkIndividualAddressLine2", A326NetworkIndividualAddressLine2);
         Z75NetworkIndividualBsnNumber = "";
         Z76NetworkIndividualGivenName = "";
         Z77NetworkIndividualLastName = "";
         Z78NetworkIndividualEmail = "";
         Z79NetworkIndividualPhone = "";
         Z433NetworkIndividualHomePhone = "";
         Z359NetworkIndividualPhoneCode = "";
         Z434NetworkIndividualHomePhoneCode = "";
         Z360NetworkIndividualPhoneNumber = "";
         Z435NetworkIndividualHomePhoneNumb = "";
         Z495NetworkIndividualRelationship = "";
         Z81NetworkIndividualGender = "";
         Z322NetworkIndividualCountry = "";
         Z323NetworkIndividualCity = "";
         Z324NetworkIndividualZipCode = "";
         Z325NetworkIndividualAddressLine1 = "";
         Z326NetworkIndividualAddressLine2 = "";
      }

      protected void InitAll0A17( )
      {
         A74NetworkIndividualId = Guid.NewGuid( );
         AssignAttri("", false, "A74NetworkIndividualId", A74NetworkIndividualId.ToString());
         InitializeNonKey0A17( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309382975", true, true);
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
         context.AddJavascriptSource("trn_networkindividual.js", "?20256309382975", false, true);
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
         edtNetworkIndividualId_Internalname = "NETWORKINDIVIDUALID";
         edtNetworkIndividualBsnNumber_Internalname = "NETWORKINDIVIDUALBSNNUMBER";
         edtNetworkIndividualGivenName_Internalname = "NETWORKINDIVIDUALGIVENNAME";
         edtNetworkIndividualLastName_Internalname = "NETWORKINDIVIDUALLASTNAME";
         edtNetworkIndividualEmail_Internalname = "NETWORKINDIVIDUALEMAIL";
         edtNetworkIndividualPhone_Internalname = "NETWORKINDIVIDUALPHONE";
         edtNetworkIndividualHomePhone_Internalname = "NETWORKINDIVIDUALHOMEPHONE";
         edtNetworkIndividualPhoneCode_Internalname = "NETWORKINDIVIDUALPHONECODE";
         edtNetworkIndividualHomePhoneCode_Internalname = "NETWORKINDIVIDUALHOMEPHONECODE";
         edtNetworkIndividualPhoneNumber_Internalname = "NETWORKINDIVIDUALPHONENUMBER";
         edtNetworkIndividualHomePhoneNumb_Internalname = "NETWORKINDIVIDUALHOMEPHONENUMB";
         cmbNetworkIndividualRelationship_Internalname = "NETWORKINDIVIDUALRELATIONSHIP";
         cmbNetworkIndividualGender_Internalname = "NETWORKINDIVIDUALGENDER";
         edtNetworkIndividualCountry_Internalname = "NETWORKINDIVIDUALCOUNTRY";
         edtNetworkIndividualCity_Internalname = "NETWORKINDIVIDUALCITY";
         edtNetworkIndividualZipCode_Internalname = "NETWORKINDIVIDUALZIPCODE";
         edtNetworkIndividualAddressLine1_Internalname = "NETWORKINDIVIDUALADDRESSLINE1";
         edtNetworkIndividualAddressLine2_Internalname = "NETWORKINDIVIDUALADDRESSLINE2";
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
         Form.Caption = context.GetMessage( "Trn_Network Individual", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtNetworkIndividualAddressLine2_Jsonclick = "";
         edtNetworkIndividualAddressLine2_Enabled = 1;
         edtNetworkIndividualAddressLine1_Jsonclick = "";
         edtNetworkIndividualAddressLine1_Enabled = 1;
         edtNetworkIndividualZipCode_Jsonclick = "";
         edtNetworkIndividualZipCode_Enabled = 1;
         edtNetworkIndividualCity_Jsonclick = "";
         edtNetworkIndividualCity_Enabled = 1;
         edtNetworkIndividualCountry_Jsonclick = "";
         edtNetworkIndividualCountry_Enabled = 1;
         cmbNetworkIndividualGender_Jsonclick = "";
         cmbNetworkIndividualGender.Enabled = 1;
         cmbNetworkIndividualRelationship_Jsonclick = "";
         cmbNetworkIndividualRelationship.Enabled = 1;
         edtNetworkIndividualHomePhoneNumb_Jsonclick = "";
         edtNetworkIndividualHomePhoneNumb_Enabled = 1;
         edtNetworkIndividualPhoneNumber_Jsonclick = "";
         edtNetworkIndividualPhoneNumber_Enabled = 1;
         edtNetworkIndividualHomePhoneCode_Jsonclick = "";
         edtNetworkIndividualHomePhoneCode_Enabled = 1;
         edtNetworkIndividualPhoneCode_Jsonclick = "";
         edtNetworkIndividualPhoneCode_Enabled = 1;
         edtNetworkIndividualHomePhone_Jsonclick = "";
         edtNetworkIndividualHomePhone_Enabled = 1;
         edtNetworkIndividualPhone_Jsonclick = "";
         edtNetworkIndividualPhone_Enabled = 1;
         edtNetworkIndividualEmail_Jsonclick = "";
         edtNetworkIndividualEmail_Enabled = 1;
         edtNetworkIndividualLastName_Jsonclick = "";
         edtNetworkIndividualLastName_Enabled = 1;
         edtNetworkIndividualGivenName_Jsonclick = "";
         edtNetworkIndividualGivenName_Enabled = 1;
         edtNetworkIndividualBsnNumber_Jsonclick = "";
         edtNetworkIndividualBsnNumber_Enabled = 1;
         edtNetworkIndividualId_Jsonclick = "";
         edtNetworkIndividualId_Enabled = 1;
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
         cmbNetworkIndividualRelationship.Name = "NETWORKINDIVIDUALRELATIONSHIP";
         cmbNetworkIndividualRelationship.WebTags = "";
         cmbNetworkIndividualRelationship.addItem("", context.GetMessage( "Other", ""), 0);
         cmbNetworkIndividualRelationship.addItem("Father", context.GetMessage( "Father", ""), 0);
         cmbNetworkIndividualRelationship.addItem("Mother", context.GetMessage( "Mother", ""), 0);
         cmbNetworkIndividualRelationship.addItem("Daughter", context.GetMessage( "Daughter", ""), 0);
         cmbNetworkIndividualRelationship.addItem("Son", context.GetMessage( "Son", ""), 0);
         cmbNetworkIndividualRelationship.addItem("Aunt", context.GetMessage( "Aunt", ""), 0);
         cmbNetworkIndividualRelationship.addItem("Uncle", context.GetMessage( "Uncle", ""), 0);
         cmbNetworkIndividualRelationship.addItem("GrandMother", context.GetMessage( "GrandMother", ""), 0);
         cmbNetworkIndividualRelationship.addItem("GrandFather", context.GetMessage( "GrandFather", ""), 0);
         cmbNetworkIndividualRelationship.addItem("Cousin", context.GetMessage( "Cousin", ""), 0);
         cmbNetworkIndividualRelationship.addItem("Friend", context.GetMessage( "Friend", ""), 0);
         if ( cmbNetworkIndividualRelationship.ItemCount > 0 )
         {
            A495NetworkIndividualRelationship = cmbNetworkIndividualRelationship.getValidValue(A495NetworkIndividualRelationship);
            AssignAttri("", false, "A495NetworkIndividualRelationship", A495NetworkIndividualRelationship);
         }
         cmbNetworkIndividualGender.Name = "NETWORKINDIVIDUALGENDER";
         cmbNetworkIndividualGender.WebTags = "";
         cmbNetworkIndividualGender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbNetworkIndividualGender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbNetworkIndividualGender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbNetworkIndividualGender.ItemCount > 0 )
         {
            A81NetworkIndividualGender = cmbNetworkIndividualGender.getValidValue(A81NetworkIndividualGender);
            AssignAttri("", false, "A81NetworkIndividualGender", A81NetworkIndividualGender);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtNetworkIndividualBsnNumber_Internalname;
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

      public void Valid_Networkindividualid( )
      {
         A81NetworkIndividualGender = cmbNetworkIndividualGender.CurrentValue;
         cmbNetworkIndividualGender.CurrentValue = A81NetworkIndividualGender;
         A495NetworkIndividualRelationship = cmbNetworkIndividualRelationship.CurrentValue;
         cmbNetworkIndividualRelationship.CurrentValue = A495NetworkIndividualRelationship;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbNetworkIndividualRelationship.ItemCount > 0 )
         {
            A495NetworkIndividualRelationship = cmbNetworkIndividualRelationship.getValidValue(A495NetworkIndividualRelationship);
            cmbNetworkIndividualRelationship.CurrentValue = A495NetworkIndividualRelationship;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNetworkIndividualRelationship.CurrentValue = StringUtil.RTrim( A495NetworkIndividualRelationship);
         }
         if ( cmbNetworkIndividualGender.ItemCount > 0 )
         {
            A81NetworkIndividualGender = cmbNetworkIndividualGender.getValidValue(A81NetworkIndividualGender);
            cmbNetworkIndividualGender.CurrentValue = A81NetworkIndividualGender;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNetworkIndividualGender.CurrentValue = StringUtil.RTrim( A81NetworkIndividualGender);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A75NetworkIndividualBsnNumber", A75NetworkIndividualBsnNumber);
         AssignAttri("", false, "A76NetworkIndividualGivenName", A76NetworkIndividualGivenName);
         AssignAttri("", false, "A77NetworkIndividualLastName", A77NetworkIndividualLastName);
         AssignAttri("", false, "A78NetworkIndividualEmail", A78NetworkIndividualEmail);
         AssignAttri("", false, "A79NetworkIndividualPhone", StringUtil.RTrim( A79NetworkIndividualPhone));
         AssignAttri("", false, "A433NetworkIndividualHomePhone", StringUtil.RTrim( A433NetworkIndividualHomePhone));
         AssignAttri("", false, "A359NetworkIndividualPhoneCode", A359NetworkIndividualPhoneCode);
         AssignAttri("", false, "A434NetworkIndividualHomePhoneCode", A434NetworkIndividualHomePhoneCode);
         AssignAttri("", false, "A360NetworkIndividualPhoneNumber", A360NetworkIndividualPhoneNumber);
         AssignAttri("", false, "A435NetworkIndividualHomePhoneNumb", A435NetworkIndividualHomePhoneNumb);
         AssignAttri("", false, "A495NetworkIndividualRelationship", A495NetworkIndividualRelationship);
         cmbNetworkIndividualRelationship.CurrentValue = StringUtil.RTrim( A495NetworkIndividualRelationship);
         AssignProp("", false, cmbNetworkIndividualRelationship_Internalname, "Values", cmbNetworkIndividualRelationship.ToJavascriptSource(), true);
         AssignAttri("", false, "A81NetworkIndividualGender", A81NetworkIndividualGender);
         cmbNetworkIndividualGender.CurrentValue = StringUtil.RTrim( A81NetworkIndividualGender);
         AssignProp("", false, cmbNetworkIndividualGender_Internalname, "Values", cmbNetworkIndividualGender.ToJavascriptSource(), true);
         AssignAttri("", false, "A322NetworkIndividualCountry", A322NetworkIndividualCountry);
         AssignAttri("", false, "A323NetworkIndividualCity", A323NetworkIndividualCity);
         AssignAttri("", false, "A324NetworkIndividualZipCode", A324NetworkIndividualZipCode);
         AssignAttri("", false, "A325NetworkIndividualAddressLine1", A325NetworkIndividualAddressLine1);
         AssignAttri("", false, "A326NetworkIndividualAddressLine2", A326NetworkIndividualAddressLine2);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z74NetworkIndividualId", Z74NetworkIndividualId.ToString());
         GxWebStd.gx_hidden_field( context, "Z75NetworkIndividualBsnNumber", Z75NetworkIndividualBsnNumber);
         GxWebStd.gx_hidden_field( context, "Z76NetworkIndividualGivenName", Z76NetworkIndividualGivenName);
         GxWebStd.gx_hidden_field( context, "Z77NetworkIndividualLastName", Z77NetworkIndividualLastName);
         GxWebStd.gx_hidden_field( context, "Z78NetworkIndividualEmail", Z78NetworkIndividualEmail);
         GxWebStd.gx_hidden_field( context, "Z79NetworkIndividualPhone", StringUtil.RTrim( Z79NetworkIndividualPhone));
         GxWebStd.gx_hidden_field( context, "Z433NetworkIndividualHomePhone", StringUtil.RTrim( Z433NetworkIndividualHomePhone));
         GxWebStd.gx_hidden_field( context, "Z359NetworkIndividualPhoneCode", Z359NetworkIndividualPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z434NetworkIndividualHomePhoneCode", Z434NetworkIndividualHomePhoneCode);
         GxWebStd.gx_hidden_field( context, "Z360NetworkIndividualPhoneNumber", Z360NetworkIndividualPhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z435NetworkIndividualHomePhoneNumb", Z435NetworkIndividualHomePhoneNumb);
         GxWebStd.gx_hidden_field( context, "Z495NetworkIndividualRelationship", Z495NetworkIndividualRelationship);
         GxWebStd.gx_hidden_field( context, "Z81NetworkIndividualGender", Z81NetworkIndividualGender);
         GxWebStd.gx_hidden_field( context, "Z322NetworkIndividualCountry", Z322NetworkIndividualCountry);
         GxWebStd.gx_hidden_field( context, "Z323NetworkIndividualCity", Z323NetworkIndividualCity);
         GxWebStd.gx_hidden_field( context, "Z324NetworkIndividualZipCode", Z324NetworkIndividualZipCode);
         GxWebStd.gx_hidden_field( context, "Z325NetworkIndividualAddressLine1", Z325NetworkIndividualAddressLine1);
         GxWebStd.gx_hidden_field( context, "Z326NetworkIndividualAddressLine2", Z326NetworkIndividualAddressLine2);
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
         setEventMetadata("VALID_NETWORKINDIVIDUALID","""{"handler":"Valid_Networkindividualid","iparms":[{"av":"cmbNetworkIndividualGender"},{"av":"A81NetworkIndividualGender","fld":"NETWORKINDIVIDUALGENDER"},{"av":"cmbNetworkIndividualRelationship"},{"av":"A495NetworkIndividualRelationship","fld":"NETWORKINDIVIDUALRELATIONSHIP"},{"av":"A74NetworkIndividualId","fld":"NETWORKINDIVIDUALID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_NETWORKINDIVIDUALID",""","oparms":[{"av":"A75NetworkIndividualBsnNumber","fld":"NETWORKINDIVIDUALBSNNUMBER"},{"av":"A76NetworkIndividualGivenName","fld":"NETWORKINDIVIDUALGIVENNAME"},{"av":"A77NetworkIndividualLastName","fld":"NETWORKINDIVIDUALLASTNAME"},{"av":"A78NetworkIndividualEmail","fld":"NETWORKINDIVIDUALEMAIL"},{"av":"A79NetworkIndividualPhone","fld":"NETWORKINDIVIDUALPHONE"},{"av":"A433NetworkIndividualHomePhone","fld":"NETWORKINDIVIDUALHOMEPHONE"},{"av":"A359NetworkIndividualPhoneCode","fld":"NETWORKINDIVIDUALPHONECODE"},{"av":"A434NetworkIndividualHomePhoneCode","fld":"NETWORKINDIVIDUALHOMEPHONECODE"},{"av":"A360NetworkIndividualPhoneNumber","fld":"NETWORKINDIVIDUALPHONENUMBER"},{"av":"A435NetworkIndividualHomePhoneNumb","fld":"NETWORKINDIVIDUALHOMEPHONENUMB"},{"av":"cmbNetworkIndividualRelationship"},{"av":"A495NetworkIndividualRelationship","fld":"NETWORKINDIVIDUALRELATIONSHIP"},{"av":"cmbNetworkIndividualGender"},{"av":"A81NetworkIndividualGender","fld":"NETWORKINDIVIDUALGENDER"},{"av":"A322NetworkIndividualCountry","fld":"NETWORKINDIVIDUALCOUNTRY"},{"av":"A323NetworkIndividualCity","fld":"NETWORKINDIVIDUALCITY"},{"av":"A324NetworkIndividualZipCode","fld":"NETWORKINDIVIDUALZIPCODE"},{"av":"A325NetworkIndividualAddressLine1","fld":"NETWORKINDIVIDUALADDRESSLINE1"},{"av":"A326NetworkIndividualAddressLine2","fld":"NETWORKINDIVIDUALADDRESSLINE2"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z74NetworkIndividualId"},{"av":"Z75NetworkIndividualBsnNumber"},{"av":"Z76NetworkIndividualGivenName"},{"av":"Z77NetworkIndividualLastName"},{"av":"Z78NetworkIndividualEmail"},{"av":"Z79NetworkIndividualPhone"},{"av":"Z433NetworkIndividualHomePhone"},{"av":"Z359NetworkIndividualPhoneCode"},{"av":"Z434NetworkIndividualHomePhoneCode"},{"av":"Z360NetworkIndividualPhoneNumber"},{"av":"Z435NetworkIndividualHomePhoneNumb"},{"av":"Z495NetworkIndividualRelationship"},{"av":"Z81NetworkIndividualGender"},{"av":"Z322NetworkIndividualCountry"},{"av":"Z323NetworkIndividualCity"},{"av":"Z324NetworkIndividualZipCode"},{"av":"Z325NetworkIndividualAddressLine1"},{"av":"Z326NetworkIndividualAddressLine2"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_NETWORKINDIVIDUALBSNNUMBER","""{"handler":"Valid_Networkindividualbsnnumber","iparms":[]}""");
         setEventMetadata("VALID_NETWORKINDIVIDUALEMAIL","""{"handler":"Valid_Networkindividualemail","iparms":[]}""");
         setEventMetadata("VALID_NETWORKINDIVIDUALPHONENUMBER","""{"handler":"Valid_Networkindividualphonenumber","iparms":[]}""");
         setEventMetadata("VALID_NETWORKINDIVIDUALHOMEPHONENUMB","""{"handler":"Valid_Networkindividualhomephonenumb","iparms":[]}""");
         setEventMetadata("VALID_NETWORKINDIVIDUALGENDER","""{"handler":"Valid_Networkindividualgender","iparms":[]}""");
         setEventMetadata("VALID_NETWORKINDIVIDUALZIPCODE","""{"handler":"Valid_Networkindividualzipcode","iparms":[]}""");
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
         Z74NetworkIndividualId = Guid.Empty;
         Z75NetworkIndividualBsnNumber = "";
         Z76NetworkIndividualGivenName = "";
         Z77NetworkIndividualLastName = "";
         Z78NetworkIndividualEmail = "";
         Z79NetworkIndividualPhone = "";
         Z433NetworkIndividualHomePhone = "";
         Z359NetworkIndividualPhoneCode = "";
         Z434NetworkIndividualHomePhoneCode = "";
         Z360NetworkIndividualPhoneNumber = "";
         Z435NetworkIndividualHomePhoneNumb = "";
         Z495NetworkIndividualRelationship = "";
         Z81NetworkIndividualGender = "";
         Z322NetworkIndividualCountry = "";
         Z323NetworkIndividualCity = "";
         Z324NetworkIndividualZipCode = "";
         Z325NetworkIndividualAddressLine1 = "";
         Z326NetworkIndividualAddressLine2 = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A495NetworkIndividualRelationship = "";
         A81NetworkIndividualGender = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A74NetworkIndividualId = Guid.Empty;
         A75NetworkIndividualBsnNumber = "";
         A76NetworkIndividualGivenName = "";
         A77NetworkIndividualLastName = "";
         A78NetworkIndividualEmail = "";
         gxphoneLink = "";
         A79NetworkIndividualPhone = "";
         A433NetworkIndividualHomePhone = "";
         A359NetworkIndividualPhoneCode = "";
         A434NetworkIndividualHomePhoneCode = "";
         A360NetworkIndividualPhoneNumber = "";
         A435NetworkIndividualHomePhoneNumb = "";
         A322NetworkIndividualCountry = "";
         A323NetworkIndividualCity = "";
         A324NetworkIndividualZipCode = "";
         A325NetworkIndividualAddressLine1 = "";
         A326NetworkIndividualAddressLine2 = "";
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
         T000A4_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         T000A4_A75NetworkIndividualBsnNumber = new string[] {""} ;
         T000A4_A76NetworkIndividualGivenName = new string[] {""} ;
         T000A4_A77NetworkIndividualLastName = new string[] {""} ;
         T000A4_A78NetworkIndividualEmail = new string[] {""} ;
         T000A4_A79NetworkIndividualPhone = new string[] {""} ;
         T000A4_A433NetworkIndividualHomePhone = new string[] {""} ;
         T000A4_A359NetworkIndividualPhoneCode = new string[] {""} ;
         T000A4_A434NetworkIndividualHomePhoneCode = new string[] {""} ;
         T000A4_A360NetworkIndividualPhoneNumber = new string[] {""} ;
         T000A4_A435NetworkIndividualHomePhoneNumb = new string[] {""} ;
         T000A4_A495NetworkIndividualRelationship = new string[] {""} ;
         T000A4_A81NetworkIndividualGender = new string[] {""} ;
         T000A4_A322NetworkIndividualCountry = new string[] {""} ;
         T000A4_A323NetworkIndividualCity = new string[] {""} ;
         T000A4_A324NetworkIndividualZipCode = new string[] {""} ;
         T000A4_A325NetworkIndividualAddressLine1 = new string[] {""} ;
         T000A4_A326NetworkIndividualAddressLine2 = new string[] {""} ;
         T000A5_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         T000A3_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         T000A3_A75NetworkIndividualBsnNumber = new string[] {""} ;
         T000A3_A76NetworkIndividualGivenName = new string[] {""} ;
         T000A3_A77NetworkIndividualLastName = new string[] {""} ;
         T000A3_A78NetworkIndividualEmail = new string[] {""} ;
         T000A3_A79NetworkIndividualPhone = new string[] {""} ;
         T000A3_A433NetworkIndividualHomePhone = new string[] {""} ;
         T000A3_A359NetworkIndividualPhoneCode = new string[] {""} ;
         T000A3_A434NetworkIndividualHomePhoneCode = new string[] {""} ;
         T000A3_A360NetworkIndividualPhoneNumber = new string[] {""} ;
         T000A3_A435NetworkIndividualHomePhoneNumb = new string[] {""} ;
         T000A3_A495NetworkIndividualRelationship = new string[] {""} ;
         T000A3_A81NetworkIndividualGender = new string[] {""} ;
         T000A3_A322NetworkIndividualCountry = new string[] {""} ;
         T000A3_A323NetworkIndividualCity = new string[] {""} ;
         T000A3_A324NetworkIndividualZipCode = new string[] {""} ;
         T000A3_A325NetworkIndividualAddressLine1 = new string[] {""} ;
         T000A3_A326NetworkIndividualAddressLine2 = new string[] {""} ;
         sMode17 = "";
         T000A6_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         T000A7_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         T000A2_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         T000A2_A75NetworkIndividualBsnNumber = new string[] {""} ;
         T000A2_A76NetworkIndividualGivenName = new string[] {""} ;
         T000A2_A77NetworkIndividualLastName = new string[] {""} ;
         T000A2_A78NetworkIndividualEmail = new string[] {""} ;
         T000A2_A79NetworkIndividualPhone = new string[] {""} ;
         T000A2_A433NetworkIndividualHomePhone = new string[] {""} ;
         T000A2_A359NetworkIndividualPhoneCode = new string[] {""} ;
         T000A2_A434NetworkIndividualHomePhoneCode = new string[] {""} ;
         T000A2_A360NetworkIndividualPhoneNumber = new string[] {""} ;
         T000A2_A435NetworkIndividualHomePhoneNumb = new string[] {""} ;
         T000A2_A495NetworkIndividualRelationship = new string[] {""} ;
         T000A2_A81NetworkIndividualGender = new string[] {""} ;
         T000A2_A322NetworkIndividualCountry = new string[] {""} ;
         T000A2_A323NetworkIndividualCity = new string[] {""} ;
         T000A2_A324NetworkIndividualZipCode = new string[] {""} ;
         T000A2_A325NetworkIndividualAddressLine1 = new string[] {""} ;
         T000A2_A326NetworkIndividualAddressLine2 = new string[] {""} ;
         T000A11_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ74NetworkIndividualId = Guid.Empty;
         ZZ75NetworkIndividualBsnNumber = "";
         ZZ76NetworkIndividualGivenName = "";
         ZZ77NetworkIndividualLastName = "";
         ZZ78NetworkIndividualEmail = "";
         ZZ79NetworkIndividualPhone = "";
         ZZ433NetworkIndividualHomePhone = "";
         ZZ359NetworkIndividualPhoneCode = "";
         ZZ434NetworkIndividualHomePhoneCode = "";
         ZZ360NetworkIndividualPhoneNumber = "";
         ZZ435NetworkIndividualHomePhoneNumb = "";
         ZZ495NetworkIndividualRelationship = "";
         ZZ81NetworkIndividualGender = "";
         ZZ322NetworkIndividualCountry = "";
         ZZ323NetworkIndividualCity = "";
         ZZ324NetworkIndividualZipCode = "";
         ZZ325NetworkIndividualAddressLine1 = "";
         ZZ326NetworkIndividualAddressLine2 = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_networkindividual__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_networkindividual__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_networkindividual__default(),
            new Object[][] {
                new Object[] {
               T000A2_A74NetworkIndividualId, T000A2_A75NetworkIndividualBsnNumber, T000A2_A76NetworkIndividualGivenName, T000A2_A77NetworkIndividualLastName, T000A2_A78NetworkIndividualEmail, T000A2_A79NetworkIndividualPhone, T000A2_A433NetworkIndividualHomePhone, T000A2_A359NetworkIndividualPhoneCode, T000A2_A434NetworkIndividualHomePhoneCode, T000A2_A360NetworkIndividualPhoneNumber,
               T000A2_A435NetworkIndividualHomePhoneNumb, T000A2_A495NetworkIndividualRelationship, T000A2_A81NetworkIndividualGender, T000A2_A322NetworkIndividualCountry, T000A2_A323NetworkIndividualCity, T000A2_A324NetworkIndividualZipCode, T000A2_A325NetworkIndividualAddressLine1, T000A2_A326NetworkIndividualAddressLine2
               }
               , new Object[] {
               T000A3_A74NetworkIndividualId, T000A3_A75NetworkIndividualBsnNumber, T000A3_A76NetworkIndividualGivenName, T000A3_A77NetworkIndividualLastName, T000A3_A78NetworkIndividualEmail, T000A3_A79NetworkIndividualPhone, T000A3_A433NetworkIndividualHomePhone, T000A3_A359NetworkIndividualPhoneCode, T000A3_A434NetworkIndividualHomePhoneCode, T000A3_A360NetworkIndividualPhoneNumber,
               T000A3_A435NetworkIndividualHomePhoneNumb, T000A3_A495NetworkIndividualRelationship, T000A3_A81NetworkIndividualGender, T000A3_A322NetworkIndividualCountry, T000A3_A323NetworkIndividualCity, T000A3_A324NetworkIndividualZipCode, T000A3_A325NetworkIndividualAddressLine1, T000A3_A326NetworkIndividualAddressLine2
               }
               , new Object[] {
               T000A4_A74NetworkIndividualId, T000A4_A75NetworkIndividualBsnNumber, T000A4_A76NetworkIndividualGivenName, T000A4_A77NetworkIndividualLastName, T000A4_A78NetworkIndividualEmail, T000A4_A79NetworkIndividualPhone, T000A4_A433NetworkIndividualHomePhone, T000A4_A359NetworkIndividualPhoneCode, T000A4_A434NetworkIndividualHomePhoneCode, T000A4_A360NetworkIndividualPhoneNumber,
               T000A4_A435NetworkIndividualHomePhoneNumb, T000A4_A495NetworkIndividualRelationship, T000A4_A81NetworkIndividualGender, T000A4_A322NetworkIndividualCountry, T000A4_A323NetworkIndividualCity, T000A4_A324NetworkIndividualZipCode, T000A4_A325NetworkIndividualAddressLine1, T000A4_A326NetworkIndividualAddressLine2
               }
               , new Object[] {
               T000A5_A74NetworkIndividualId
               }
               , new Object[] {
               T000A6_A74NetworkIndividualId
               }
               , new Object[] {
               T000A7_A74NetworkIndividualId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A11_A74NetworkIndividualId
               }
            }
         );
         Z74NetworkIndividualId = Guid.NewGuid( );
         A74NetworkIndividualId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound17 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtNetworkIndividualId_Enabled ;
      private int edtNetworkIndividualBsnNumber_Enabled ;
      private int edtNetworkIndividualGivenName_Enabled ;
      private int edtNetworkIndividualLastName_Enabled ;
      private int edtNetworkIndividualEmail_Enabled ;
      private int edtNetworkIndividualPhone_Enabled ;
      private int edtNetworkIndividualHomePhone_Enabled ;
      private int edtNetworkIndividualPhoneCode_Enabled ;
      private int edtNetworkIndividualHomePhoneCode_Enabled ;
      private int edtNetworkIndividualPhoneNumber_Enabled ;
      private int edtNetworkIndividualHomePhoneNumb_Enabled ;
      private int edtNetworkIndividualCountry_Enabled ;
      private int edtNetworkIndividualCity_Enabled ;
      private int edtNetworkIndividualZipCode_Enabled ;
      private int edtNetworkIndividualAddressLine1_Enabled ;
      private int edtNetworkIndividualAddressLine2_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z79NetworkIndividualPhone ;
      private string Z433NetworkIndividualHomePhone ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNetworkIndividualId_Internalname ;
      private string cmbNetworkIndividualRelationship_Internalname ;
      private string cmbNetworkIndividualGender_Internalname ;
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
      private string edtNetworkIndividualId_Jsonclick ;
      private string edtNetworkIndividualBsnNumber_Internalname ;
      private string edtNetworkIndividualBsnNumber_Jsonclick ;
      private string edtNetworkIndividualGivenName_Internalname ;
      private string edtNetworkIndividualGivenName_Jsonclick ;
      private string edtNetworkIndividualLastName_Internalname ;
      private string edtNetworkIndividualLastName_Jsonclick ;
      private string edtNetworkIndividualEmail_Internalname ;
      private string edtNetworkIndividualEmail_Jsonclick ;
      private string edtNetworkIndividualPhone_Internalname ;
      private string gxphoneLink ;
      private string A79NetworkIndividualPhone ;
      private string edtNetworkIndividualPhone_Jsonclick ;
      private string edtNetworkIndividualHomePhone_Internalname ;
      private string A433NetworkIndividualHomePhone ;
      private string edtNetworkIndividualHomePhone_Jsonclick ;
      private string edtNetworkIndividualPhoneCode_Internalname ;
      private string edtNetworkIndividualPhoneCode_Jsonclick ;
      private string edtNetworkIndividualHomePhoneCode_Internalname ;
      private string edtNetworkIndividualHomePhoneCode_Jsonclick ;
      private string edtNetworkIndividualPhoneNumber_Internalname ;
      private string edtNetworkIndividualPhoneNumber_Jsonclick ;
      private string edtNetworkIndividualHomePhoneNumb_Internalname ;
      private string edtNetworkIndividualHomePhoneNumb_Jsonclick ;
      private string cmbNetworkIndividualRelationship_Jsonclick ;
      private string cmbNetworkIndividualGender_Jsonclick ;
      private string edtNetworkIndividualCountry_Internalname ;
      private string edtNetworkIndividualCountry_Jsonclick ;
      private string edtNetworkIndividualCity_Internalname ;
      private string edtNetworkIndividualCity_Jsonclick ;
      private string edtNetworkIndividualZipCode_Internalname ;
      private string edtNetworkIndividualZipCode_Jsonclick ;
      private string edtNetworkIndividualAddressLine1_Internalname ;
      private string edtNetworkIndividualAddressLine1_Jsonclick ;
      private string edtNetworkIndividualAddressLine2_Internalname ;
      private string edtNetworkIndividualAddressLine2_Jsonclick ;
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
      private string sMode17 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ79NetworkIndividualPhone ;
      private string ZZ433NetworkIndividualHomePhone ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z75NetworkIndividualBsnNumber ;
      private string Z76NetworkIndividualGivenName ;
      private string Z77NetworkIndividualLastName ;
      private string Z78NetworkIndividualEmail ;
      private string Z359NetworkIndividualPhoneCode ;
      private string Z434NetworkIndividualHomePhoneCode ;
      private string Z360NetworkIndividualPhoneNumber ;
      private string Z435NetworkIndividualHomePhoneNumb ;
      private string Z495NetworkIndividualRelationship ;
      private string Z81NetworkIndividualGender ;
      private string Z322NetworkIndividualCountry ;
      private string Z323NetworkIndividualCity ;
      private string Z324NetworkIndividualZipCode ;
      private string Z325NetworkIndividualAddressLine1 ;
      private string Z326NetworkIndividualAddressLine2 ;
      private string A495NetworkIndividualRelationship ;
      private string A81NetworkIndividualGender ;
      private string A75NetworkIndividualBsnNumber ;
      private string A76NetworkIndividualGivenName ;
      private string A77NetworkIndividualLastName ;
      private string A78NetworkIndividualEmail ;
      private string A359NetworkIndividualPhoneCode ;
      private string A434NetworkIndividualHomePhoneCode ;
      private string A360NetworkIndividualPhoneNumber ;
      private string A435NetworkIndividualHomePhoneNumb ;
      private string A322NetworkIndividualCountry ;
      private string A323NetworkIndividualCity ;
      private string A324NetworkIndividualZipCode ;
      private string A325NetworkIndividualAddressLine1 ;
      private string A326NetworkIndividualAddressLine2 ;
      private string ZZ75NetworkIndividualBsnNumber ;
      private string ZZ76NetworkIndividualGivenName ;
      private string ZZ77NetworkIndividualLastName ;
      private string ZZ78NetworkIndividualEmail ;
      private string ZZ359NetworkIndividualPhoneCode ;
      private string ZZ434NetworkIndividualHomePhoneCode ;
      private string ZZ360NetworkIndividualPhoneNumber ;
      private string ZZ435NetworkIndividualHomePhoneNumb ;
      private string ZZ495NetworkIndividualRelationship ;
      private string ZZ81NetworkIndividualGender ;
      private string ZZ322NetworkIndividualCountry ;
      private string ZZ323NetworkIndividualCity ;
      private string ZZ324NetworkIndividualZipCode ;
      private string ZZ325NetworkIndividualAddressLine1 ;
      private string ZZ326NetworkIndividualAddressLine2 ;
      private Guid Z74NetworkIndividualId ;
      private Guid A74NetworkIndividualId ;
      private Guid ZZ74NetworkIndividualId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbNetworkIndividualRelationship ;
      private GXCombobox cmbNetworkIndividualGender ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000A4_A74NetworkIndividualId ;
      private string[] T000A4_A75NetworkIndividualBsnNumber ;
      private string[] T000A4_A76NetworkIndividualGivenName ;
      private string[] T000A4_A77NetworkIndividualLastName ;
      private string[] T000A4_A78NetworkIndividualEmail ;
      private string[] T000A4_A79NetworkIndividualPhone ;
      private string[] T000A4_A433NetworkIndividualHomePhone ;
      private string[] T000A4_A359NetworkIndividualPhoneCode ;
      private string[] T000A4_A434NetworkIndividualHomePhoneCode ;
      private string[] T000A4_A360NetworkIndividualPhoneNumber ;
      private string[] T000A4_A435NetworkIndividualHomePhoneNumb ;
      private string[] T000A4_A495NetworkIndividualRelationship ;
      private string[] T000A4_A81NetworkIndividualGender ;
      private string[] T000A4_A322NetworkIndividualCountry ;
      private string[] T000A4_A323NetworkIndividualCity ;
      private string[] T000A4_A324NetworkIndividualZipCode ;
      private string[] T000A4_A325NetworkIndividualAddressLine1 ;
      private string[] T000A4_A326NetworkIndividualAddressLine2 ;
      private Guid[] T000A5_A74NetworkIndividualId ;
      private Guid[] T000A3_A74NetworkIndividualId ;
      private string[] T000A3_A75NetworkIndividualBsnNumber ;
      private string[] T000A3_A76NetworkIndividualGivenName ;
      private string[] T000A3_A77NetworkIndividualLastName ;
      private string[] T000A3_A78NetworkIndividualEmail ;
      private string[] T000A3_A79NetworkIndividualPhone ;
      private string[] T000A3_A433NetworkIndividualHomePhone ;
      private string[] T000A3_A359NetworkIndividualPhoneCode ;
      private string[] T000A3_A434NetworkIndividualHomePhoneCode ;
      private string[] T000A3_A360NetworkIndividualPhoneNumber ;
      private string[] T000A3_A435NetworkIndividualHomePhoneNumb ;
      private string[] T000A3_A495NetworkIndividualRelationship ;
      private string[] T000A3_A81NetworkIndividualGender ;
      private string[] T000A3_A322NetworkIndividualCountry ;
      private string[] T000A3_A323NetworkIndividualCity ;
      private string[] T000A3_A324NetworkIndividualZipCode ;
      private string[] T000A3_A325NetworkIndividualAddressLine1 ;
      private string[] T000A3_A326NetworkIndividualAddressLine2 ;
      private Guid[] T000A6_A74NetworkIndividualId ;
      private Guid[] T000A7_A74NetworkIndividualId ;
      private Guid[] T000A2_A74NetworkIndividualId ;
      private string[] T000A2_A75NetworkIndividualBsnNumber ;
      private string[] T000A2_A76NetworkIndividualGivenName ;
      private string[] T000A2_A77NetworkIndividualLastName ;
      private string[] T000A2_A78NetworkIndividualEmail ;
      private string[] T000A2_A79NetworkIndividualPhone ;
      private string[] T000A2_A433NetworkIndividualHomePhone ;
      private string[] T000A2_A359NetworkIndividualPhoneCode ;
      private string[] T000A2_A434NetworkIndividualHomePhoneCode ;
      private string[] T000A2_A360NetworkIndividualPhoneNumber ;
      private string[] T000A2_A435NetworkIndividualHomePhoneNumb ;
      private string[] T000A2_A495NetworkIndividualRelationship ;
      private string[] T000A2_A81NetworkIndividualGender ;
      private string[] T000A2_A322NetworkIndividualCountry ;
      private string[] T000A2_A323NetworkIndividualCity ;
      private string[] T000A2_A324NetworkIndividualZipCode ;
      private string[] T000A2_A325NetworkIndividualAddressLine1 ;
      private string[] T000A2_A326NetworkIndividualAddressLine2 ;
      private Guid[] T000A11_A74NetworkIndividualId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_networkindividual__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_networkindividual__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_networkindividual__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT000A2;
       prmT000A2 = new Object[] {
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000A3;
       prmT000A3 = new Object[] {
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000A4;
       prmT000A4 = new Object[] {
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000A5;
       prmT000A5 = new Object[] {
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000A6;
       prmT000A6 = new Object[] {
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000A7;
       prmT000A7 = new Object[] {
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000A8;
       prmT000A8 = new Object[] {
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkIndividualBsnNumber",GXType.VarChar,9,0) ,
       new ParDef("NetworkIndividualGivenName",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualLastName",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualEmail",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualPhone",GXType.Char,20,0) ,
       new ParDef("NetworkIndividualHomePhone",GXType.Char,20,0) ,
       new ParDef("NetworkIndividualPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("NetworkIndividualHomePhoneCode",GXType.VarChar,40,0) ,
       new ParDef("NetworkIndividualPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("NetworkIndividualHomePhoneNumb",GXType.VarChar,9,0) ,
       new ParDef("NetworkIndividualRelationship",GXType.VarChar,400,0) ,
       new ParDef("NetworkIndividualGender",GXType.VarChar,40,0) ,
       new ParDef("NetworkIndividualCountry",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualCity",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualZipCode",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualAddressLine2",GXType.VarChar,100,0)
       };
       Object[] prmT000A9;
       prmT000A9 = new Object[] {
       new ParDef("NetworkIndividualBsnNumber",GXType.VarChar,9,0) ,
       new ParDef("NetworkIndividualGivenName",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualLastName",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualEmail",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualPhone",GXType.Char,20,0) ,
       new ParDef("NetworkIndividualHomePhone",GXType.Char,20,0) ,
       new ParDef("NetworkIndividualPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("NetworkIndividualHomePhoneCode",GXType.VarChar,40,0) ,
       new ParDef("NetworkIndividualPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("NetworkIndividualHomePhoneNumb",GXType.VarChar,9,0) ,
       new ParDef("NetworkIndividualRelationship",GXType.VarChar,400,0) ,
       new ParDef("NetworkIndividualGender",GXType.VarChar,40,0) ,
       new ParDef("NetworkIndividualCountry",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualCity",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualZipCode",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000A10;
       prmT000A10 = new Object[] {
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000A11;
       prmT000A11 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000A2", "SELECT NetworkIndividualId, NetworkIndividualBsnNumber, NetworkIndividualGivenName, NetworkIndividualLastName, NetworkIndividualEmail, NetworkIndividualPhone, NetworkIndividualHomePhone, NetworkIndividualPhoneCode, NetworkIndividualHomePhoneCode, NetworkIndividualPhoneNumber, NetworkIndividualHomePhoneNumb, NetworkIndividualRelationship, NetworkIndividualGender, NetworkIndividualCountry, NetworkIndividualCity, NetworkIndividualZipCode, NetworkIndividualAddressLine1, NetworkIndividualAddressLine2 FROM Trn_NetworkIndividual WHERE NetworkIndividualId = :NetworkIndividualId  FOR UPDATE OF Trn_NetworkIndividual NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000A3", "SELECT NetworkIndividualId, NetworkIndividualBsnNumber, NetworkIndividualGivenName, NetworkIndividualLastName, NetworkIndividualEmail, NetworkIndividualPhone, NetworkIndividualHomePhone, NetworkIndividualPhoneCode, NetworkIndividualHomePhoneCode, NetworkIndividualPhoneNumber, NetworkIndividualHomePhoneNumb, NetworkIndividualRelationship, NetworkIndividualGender, NetworkIndividualCountry, NetworkIndividualCity, NetworkIndividualZipCode, NetworkIndividualAddressLine1, NetworkIndividualAddressLine2 FROM Trn_NetworkIndividual WHERE NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000A4", "SELECT TM1.NetworkIndividualId, TM1.NetworkIndividualBsnNumber, TM1.NetworkIndividualGivenName, TM1.NetworkIndividualLastName, TM1.NetworkIndividualEmail, TM1.NetworkIndividualPhone, TM1.NetworkIndividualHomePhone, TM1.NetworkIndividualPhoneCode, TM1.NetworkIndividualHomePhoneCode, TM1.NetworkIndividualPhoneNumber, TM1.NetworkIndividualHomePhoneNumb, TM1.NetworkIndividualRelationship, TM1.NetworkIndividualGender, TM1.NetworkIndividualCountry, TM1.NetworkIndividualCity, TM1.NetworkIndividualZipCode, TM1.NetworkIndividualAddressLine1, TM1.NetworkIndividualAddressLine2 FROM Trn_NetworkIndividual TM1 WHERE TM1.NetworkIndividualId = :NetworkIndividualId ORDER BY TM1.NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000A5", "SELECT NetworkIndividualId FROM Trn_NetworkIndividual WHERE NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000A6", "SELECT NetworkIndividualId FROM Trn_NetworkIndividual WHERE ( NetworkIndividualId > :NetworkIndividualId) ORDER BY NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000A7", "SELECT NetworkIndividualId FROM Trn_NetworkIndividual WHERE ( NetworkIndividualId < :NetworkIndividualId) ORDER BY NetworkIndividualId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000A8", "SAVEPOINT gxupdate;INSERT INTO Trn_NetworkIndividual(NetworkIndividualId, NetworkIndividualBsnNumber, NetworkIndividualGivenName, NetworkIndividualLastName, NetworkIndividualEmail, NetworkIndividualPhone, NetworkIndividualHomePhone, NetworkIndividualPhoneCode, NetworkIndividualHomePhoneCode, NetworkIndividualPhoneNumber, NetworkIndividualHomePhoneNumb, NetworkIndividualRelationship, NetworkIndividualGender, NetworkIndividualCountry, NetworkIndividualCity, NetworkIndividualZipCode, NetworkIndividualAddressLine1, NetworkIndividualAddressLine2) VALUES(:NetworkIndividualId, :NetworkIndividualBsnNumber, :NetworkIndividualGivenName, :NetworkIndividualLastName, :NetworkIndividualEmail, :NetworkIndividualPhone, :NetworkIndividualHomePhone, :NetworkIndividualPhoneCode, :NetworkIndividualHomePhoneCode, :NetworkIndividualPhoneNumber, :NetworkIndividualHomePhoneNumb, :NetworkIndividualRelationship, :NetworkIndividualGender, :NetworkIndividualCountry, :NetworkIndividualCity, :NetworkIndividualZipCode, :NetworkIndividualAddressLine1, :NetworkIndividualAddressLine2);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000A8)
          ,new CursorDef("T000A9", "SAVEPOINT gxupdate;UPDATE Trn_NetworkIndividual SET NetworkIndividualBsnNumber=:NetworkIndividualBsnNumber, NetworkIndividualGivenName=:NetworkIndividualGivenName, NetworkIndividualLastName=:NetworkIndividualLastName, NetworkIndividualEmail=:NetworkIndividualEmail, NetworkIndividualPhone=:NetworkIndividualPhone, NetworkIndividualHomePhone=:NetworkIndividualHomePhone, NetworkIndividualPhoneCode=:NetworkIndividualPhoneCode, NetworkIndividualHomePhoneCode=:NetworkIndividualHomePhoneCode, NetworkIndividualPhoneNumber=:NetworkIndividualPhoneNumber, NetworkIndividualHomePhoneNumb=:NetworkIndividualHomePhoneNumb, NetworkIndividualRelationship=:NetworkIndividualRelationship, NetworkIndividualGender=:NetworkIndividualGender, NetworkIndividualCountry=:NetworkIndividualCountry, NetworkIndividualCity=:NetworkIndividualCity, NetworkIndividualZipCode=:NetworkIndividualZipCode, NetworkIndividualAddressLine1=:NetworkIndividualAddressLine1, NetworkIndividualAddressLine2=:NetworkIndividualAddressLine2  WHERE NetworkIndividualId = :NetworkIndividualId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000A9)
          ,new CursorDef("T000A10", "SAVEPOINT gxupdate;DELETE FROM Trn_NetworkIndividual  WHERE NetworkIndividualId = :NetworkIndividualId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000A10)
          ,new CursorDef("T000A11", "SELECT NetworkIndividualId FROM Trn_NetworkIndividual ORDER BY NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A11,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[6])[0] = rslt.getString(7, 20);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getString(7, 20);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getString(7, 20);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
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
