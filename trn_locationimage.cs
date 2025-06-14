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
   public class trn_locationimage : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Location Image", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLocationImageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_locationimage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_locationimage( IGxContext context )
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
            return "trn_location_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Location Image", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_LocationImage.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationImage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationImage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationImage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationImage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_LocationImage.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationImageId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationImageId_Internalname, context.GetMessage( "Image Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationImageId_Internalname, A613LocationImageId.ToString(), A613LocationImageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationImageId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationImageId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_LocationImage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationLocationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationLocationId_Internalname, context.GetMessage( "Location Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationLocationId_Internalname, A614OrganisationLocationId.ToString(), A614OrganisationLocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationLocationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationLocationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_LocationImage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgOrganisationLocationImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Location Image", ""), "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A615OrganisationLocationImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A615OrganisationLocationImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000OrganisationLocationImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A615OrganisationLocationImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A615OrganisationLocationImage)) ? A40000OrganisationLocationImage_GXI : context.PathToRelativeUrl( A615OrganisationLocationImage));
         GxWebStd.gx_bitmap( context, imgOrganisationLocationImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgOrganisationLocationImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", "", "", 0, A615OrganisationLocationImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_LocationImage.htm");
         AssignProp("", false, imgOrganisationLocationImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A615OrganisationLocationImage)) ? A40000OrganisationLocationImage_GXI : context.PathToRelativeUrl( A615OrganisationLocationImage)), true);
         AssignProp("", false, imgOrganisationLocationImage_Internalname, "IsBlob", StringUtil.BoolToStr( A615OrganisationLocationImage_IsBlob), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationImage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationImage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationImage.htm");
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
            Z613LocationImageId = StringUtil.StrToGuid( cgiGet( "Z613LocationImageId"));
            Z614OrganisationLocationId = StringUtil.StrToGuid( cgiGet( "Z614OrganisationLocationId"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A40000OrganisationLocationImage_GXI = cgiGet( "ORGANISATIONLOCATIONIMAGE_GXI");
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtLocationImageId_Internalname), "") == 0 )
            {
               A613LocationImageId = Guid.Empty;
               AssignAttri("", false, "A613LocationImageId", A613LocationImageId.ToString());
            }
            else
            {
               try
               {
                  A613LocationImageId = StringUtil.StrToGuid( cgiGet( edtLocationImageId_Internalname));
                  AssignAttri("", false, "A613LocationImageId", A613LocationImageId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "LOCATIONIMAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtLocationImageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtOrganisationLocationId_Internalname), "") == 0 )
            {
               A614OrganisationLocationId = Guid.Empty;
               AssignAttri("", false, "A614OrganisationLocationId", A614OrganisationLocationId.ToString());
            }
            else
            {
               try
               {
                  A614OrganisationLocationId = StringUtil.StrToGuid( cgiGet( edtOrganisationLocationId_Internalname));
                  AssignAttri("", false, "A614OrganisationLocationId", A614OrganisationLocationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ORGANISATIONLOCATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtOrganisationLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A615OrganisationLocationImage = cgiGet( imgOrganisationLocationImage_Internalname);
            AssignAttri("", false, "A615OrganisationLocationImage", A615OrganisationLocationImage);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgOrganisationLocationImage_Internalname, ref  A615OrganisationLocationImage, ref  A40000OrganisationLocationImage_GXI);
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
               A613LocationImageId = StringUtil.StrToGuid( GetPar( "LocationImageId"));
               AssignAttri("", false, "A613LocationImageId", A613LocationImageId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A613LocationImageId) && ( Gx_BScreen == 0 ) )
               {
                  A613LocationImageId = Guid.NewGuid( );
                  AssignAttri("", false, "A613LocationImageId", A613LocationImageId.ToString());
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
               InitAll1U105( ) ;
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
         DisableAttributes1U105( ) ;
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

      protected void ResetCaption1U0( )
      {
      }

      protected void ZM1U105( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z614OrganisationLocationId = T001U3_A614OrganisationLocationId[0];
            }
            else
            {
               Z614OrganisationLocationId = A614OrganisationLocationId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z613LocationImageId = A613LocationImageId;
            Z614OrganisationLocationId = A614OrganisationLocationId;
            Z615OrganisationLocationImage = A615OrganisationLocationImage;
            Z40000OrganisationLocationImage_GXI = A40000OrganisationLocationImage_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A613LocationImageId) && ( Gx_BScreen == 0 ) )
         {
            A613LocationImageId = Guid.NewGuid( );
            AssignAttri("", false, "A613LocationImageId", A613LocationImageId.ToString());
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

      protected void Load1U105( )
      {
         /* Using cursor T001U4 */
         pr_default.execute(2, new Object[] {A613LocationImageId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound105 = 1;
            A614OrganisationLocationId = T001U4_A614OrganisationLocationId[0];
            AssignAttri("", false, "A614OrganisationLocationId", A614OrganisationLocationId.ToString());
            A40000OrganisationLocationImage_GXI = T001U4_A40000OrganisationLocationImage_GXI[0];
            AssignProp("", false, imgOrganisationLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A615OrganisationLocationImage)) ? A40000OrganisationLocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A615OrganisationLocationImage))), true);
            AssignProp("", false, imgOrganisationLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A615OrganisationLocationImage), true);
            A615OrganisationLocationImage = T001U4_A615OrganisationLocationImage[0];
            AssignAttri("", false, "A615OrganisationLocationImage", A615OrganisationLocationImage);
            AssignProp("", false, imgOrganisationLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A615OrganisationLocationImage)) ? A40000OrganisationLocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A615OrganisationLocationImage))), true);
            AssignProp("", false, imgOrganisationLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A615OrganisationLocationImage), true);
            ZM1U105( -4) ;
         }
         pr_default.close(2);
         OnLoadActions1U105( ) ;
      }

      protected void OnLoadActions1U105( )
      {
      }

      protected void CheckExtendedTable1U105( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1U105( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1U105( )
      {
         /* Using cursor T001U5 */
         pr_default.execute(3, new Object[] {A613LocationImageId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound105 = 1;
         }
         else
         {
            RcdFound105 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001U3 */
         pr_default.execute(1, new Object[] {A613LocationImageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1U105( 4) ;
            RcdFound105 = 1;
            A613LocationImageId = T001U3_A613LocationImageId[0];
            AssignAttri("", false, "A613LocationImageId", A613LocationImageId.ToString());
            A614OrganisationLocationId = T001U3_A614OrganisationLocationId[0];
            AssignAttri("", false, "A614OrganisationLocationId", A614OrganisationLocationId.ToString());
            A40000OrganisationLocationImage_GXI = T001U3_A40000OrganisationLocationImage_GXI[0];
            AssignProp("", false, imgOrganisationLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A615OrganisationLocationImage)) ? A40000OrganisationLocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A615OrganisationLocationImage))), true);
            AssignProp("", false, imgOrganisationLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A615OrganisationLocationImage), true);
            A615OrganisationLocationImage = T001U3_A615OrganisationLocationImage[0];
            AssignAttri("", false, "A615OrganisationLocationImage", A615OrganisationLocationImage);
            AssignProp("", false, imgOrganisationLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A615OrganisationLocationImage)) ? A40000OrganisationLocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A615OrganisationLocationImage))), true);
            AssignProp("", false, imgOrganisationLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A615OrganisationLocationImage), true);
            Z613LocationImageId = A613LocationImageId;
            sMode105 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1U105( ) ;
            if ( AnyError == 1 )
            {
               RcdFound105 = 0;
               InitializeNonKey1U105( ) ;
            }
            Gx_mode = sMode105;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound105 = 0;
            InitializeNonKey1U105( ) ;
            sMode105 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode105;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1U105( ) ;
         if ( RcdFound105 == 0 )
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
         RcdFound105 = 0;
         /* Using cursor T001U6 */
         pr_default.execute(4, new Object[] {A613LocationImageId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001U6_A613LocationImageId[0], A613LocationImageId, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001U6_A613LocationImageId[0], A613LocationImageId, 0) > 0 ) ) )
            {
               A613LocationImageId = T001U6_A613LocationImageId[0];
               AssignAttri("", false, "A613LocationImageId", A613LocationImageId.ToString());
               RcdFound105 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound105 = 0;
         /* Using cursor T001U7 */
         pr_default.execute(5, new Object[] {A613LocationImageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001U7_A613LocationImageId[0], A613LocationImageId, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001U7_A613LocationImageId[0], A613LocationImageId, 0) < 0 ) ) )
            {
               A613LocationImageId = T001U7_A613LocationImageId[0];
               AssignAttri("", false, "A613LocationImageId", A613LocationImageId.ToString());
               RcdFound105 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1U105( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLocationImageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1U105( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound105 == 1 )
            {
               if ( A613LocationImageId != Z613LocationImageId )
               {
                  A613LocationImageId = Z613LocationImageId;
                  AssignAttri("", false, "A613LocationImageId", A613LocationImageId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LOCATIONIMAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtLocationImageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLocationImageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1U105( ) ;
                  GX_FocusControl = edtLocationImageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A613LocationImageId != Z613LocationImageId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLocationImageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1U105( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LOCATIONIMAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtLocationImageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtLocationImageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1U105( ) ;
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
         if ( A613LocationImageId != Z613LocationImageId )
         {
            A613LocationImageId = Z613LocationImageId;
            AssignAttri("", false, "A613LocationImageId", A613LocationImageId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LOCATIONIMAGEID");
            AnyError = 1;
            GX_FocusControl = edtLocationImageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLocationImageId_Internalname;
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
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LOCATIONIMAGEID");
            AnyError = 1;
            GX_FocusControl = edtLocationImageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtOrganisationLocationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1U105( ) ;
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtOrganisationLocationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1U105( ) ;
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
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtOrganisationLocationId_Internalname;
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
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtOrganisationLocationId_Internalname;
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
         ScanStart1U105( ) ;
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound105 != 0 )
            {
               ScanNext1U105( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtOrganisationLocationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1U105( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1U105( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001U2 */
            pr_default.execute(0, new Object[] {A613LocationImageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_LocationImage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z614OrganisationLocationId != T001U2_A614OrganisationLocationId[0] ) )
            {
               if ( Z614OrganisationLocationId != T001U2_A614OrganisationLocationId[0] )
               {
                  GXUtil.WriteLog("trn_locationimage:[seudo value changed for attri]"+"OrganisationLocationId");
                  GXUtil.WriteLogRaw("Old: ",Z614OrganisationLocationId);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A614OrganisationLocationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_LocationImage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1U105( )
      {
         if ( ! IsAuthorized("trn_location_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1U105( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U105( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1U105( 0) ;
            CheckOptimisticConcurrency1U105( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U105( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1U105( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001U8 */
                     pr_default.execute(6, new Object[] {A613LocationImageId, A614OrganisationLocationId, A615OrganisationLocationImage, A40000OrganisationLocationImage_GXI});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_LocationImage");
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
                           ResetCaption1U0( ) ;
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
               Load1U105( ) ;
            }
            EndLevel1U105( ) ;
         }
         CloseExtendedTableCursors1U105( ) ;
      }

      protected void Update1U105( )
      {
         if ( ! IsAuthorized("trn_location_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1U105( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U105( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U105( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U105( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1U105( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001U9 */
                     pr_default.execute(7, new Object[] {A614OrganisationLocationId, A613LocationImageId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_LocationImage");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_LocationImage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1U105( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1U0( ) ;
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
            EndLevel1U105( ) ;
         }
         CloseExtendedTableCursors1U105( ) ;
      }

      protected void DeferredUpdate1U105( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001U10 */
            pr_default.execute(8, new Object[] {A615OrganisationLocationImage, A40000OrganisationLocationImage_GXI, A613LocationImageId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Trn_LocationImage");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_location_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1U105( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U105( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1U105( ) ;
            AfterConfirm1U105( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1U105( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001U11 */
                  pr_default.execute(9, new Object[] {A613LocationImageId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_LocationImage");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound105 == 0 )
                        {
                           InitAll1U105( ) ;
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
                        ResetCaption1U0( ) ;
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
         sMode105 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1U105( ) ;
         Gx_mode = sMode105;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1U105( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1U105( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1U105( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_locationimage",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_locationimage",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1U105( )
      {
         /* Using cursor T001U12 */
         pr_default.execute(10);
         RcdFound105 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound105 = 1;
            A613LocationImageId = T001U12_A613LocationImageId[0];
            AssignAttri("", false, "A613LocationImageId", A613LocationImageId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1U105( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound105 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound105 = 1;
            A613LocationImageId = T001U12_A613LocationImageId[0];
            AssignAttri("", false, "A613LocationImageId", A613LocationImageId.ToString());
         }
      }

      protected void ScanEnd1U105( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1U105( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1U105( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1U105( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1U105( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1U105( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1U105( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1U105( )
      {
         edtLocationImageId_Enabled = 0;
         AssignProp("", false, edtLocationImageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationImageId_Enabled), 5, 0), true);
         edtOrganisationLocationId_Enabled = 0;
         AssignProp("", false, edtOrganisationLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationLocationId_Enabled), 5, 0), true);
         imgOrganisationLocationImage_Enabled = 0;
         AssignProp("", false, imgOrganisationLocationImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgOrganisationLocationImage_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1U105( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1U0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_locationimage.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z613LocationImageId", Z613LocationImageId.ToString());
         GxWebStd.gx_hidden_field( context, "Z614OrganisationLocationId", Z614OrganisationLocationId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONLOCATIONIMAGE_GXI", A40000OrganisationLocationImage_GXI);
         GXCCtlgxBlob = "ORGANISATIONLOCATIONIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A615OrganisationLocationImage);
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
         return formatLink("trn_locationimage.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_LocationImage" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Location Image", "") ;
      }

      protected void InitializeNonKey1U105( )
      {
         A614OrganisationLocationId = Guid.Empty;
         AssignAttri("", false, "A614OrganisationLocationId", A614OrganisationLocationId.ToString());
         A615OrganisationLocationImage = "";
         AssignAttri("", false, "A615OrganisationLocationImage", A615OrganisationLocationImage);
         AssignProp("", false, imgOrganisationLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A615OrganisationLocationImage)) ? A40000OrganisationLocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A615OrganisationLocationImage))), true);
         AssignProp("", false, imgOrganisationLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A615OrganisationLocationImage), true);
         A40000OrganisationLocationImage_GXI = "";
         AssignProp("", false, imgOrganisationLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A615OrganisationLocationImage)) ? A40000OrganisationLocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A615OrganisationLocationImage))), true);
         AssignProp("", false, imgOrganisationLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A615OrganisationLocationImage), true);
         Z614OrganisationLocationId = Guid.Empty;
      }

      protected void InitAll1U105( )
      {
         A613LocationImageId = Guid.NewGuid( );
         AssignAttri("", false, "A613LocationImageId", A613LocationImageId.ToString());
         InitializeNonKey1U105( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025614537578", true, true);
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
         context.AddJavascriptSource("trn_locationimage.js", "?2025614537578", false, true);
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
         edtLocationImageId_Internalname = "LOCATIONIMAGEID";
         edtOrganisationLocationId_Internalname = "ORGANISATIONLOCATIONID";
         imgOrganisationLocationImage_Internalname = "ORGANISATIONLOCATIONIMAGE";
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
         Form.Caption = context.GetMessage( "Trn_Location Image", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgOrganisationLocationImage_Enabled = 1;
         edtOrganisationLocationId_Jsonclick = "";
         edtOrganisationLocationId_Enabled = 1;
         edtLocationImageId_Jsonclick = "";
         edtLocationImageId_Enabled = 1;
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
         GX_FocusControl = edtOrganisationLocationId_Internalname;
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

      public void Valid_Locationimageid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A614OrganisationLocationId", A614OrganisationLocationId.ToString());
         AssignAttri("", false, "A615OrganisationLocationImage", context.PathToRelativeUrl( A615OrganisationLocationImage));
         GXCCtlgxBlob = "ORGANISATIONLOCATIONIMAGE" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A615OrganisationLocationImage));
         AssignAttri("", false, "A40000OrganisationLocationImage_GXI", A40000OrganisationLocationImage_GXI);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z613LocationImageId", Z613LocationImageId.ToString());
         GxWebStd.gx_hidden_field( context, "Z614OrganisationLocationId", Z614OrganisationLocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z615OrganisationLocationImage", context.PathToRelativeUrl( Z615OrganisationLocationImage));
         GxWebStd.gx_hidden_field( context, "Z40000OrganisationLocationImage_GXI", Z40000OrganisationLocationImage_GXI);
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
         setEventMetadata("VALID_LOCATIONIMAGEID","""{"handler":"Valid_Locationimageid","iparms":[{"av":"A613LocationImageId","fld":"LOCATIONIMAGEID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_LOCATIONIMAGEID",""","oparms":[{"av":"A614OrganisationLocationId","fld":"ORGANISATIONLOCATIONID"},{"av":"A615OrganisationLocationImage","fld":"ORGANISATIONLOCATIONIMAGE"},{"av":"A40000OrganisationLocationImage_GXI","fld":"ORGANISATIONLOCATIONIMAGE_GXI"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z613LocationImageId"},{"av":"Z614OrganisationLocationId"},{"av":"Z615OrganisationLocationImage"},{"av":"Z40000OrganisationLocationImage_GXI"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_ORGANISATIONLOCATIONID","""{"handler":"Valid_Organisationlocationid","iparms":[]}""");
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
         Z613LocationImageId = Guid.Empty;
         Z614OrganisationLocationId = Guid.Empty;
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
         A613LocationImageId = Guid.Empty;
         A614OrganisationLocationId = Guid.Empty;
         A615OrganisationLocationImage = "";
         A40000OrganisationLocationImage_GXI = "";
         sImgUrl = "";
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
         Z615OrganisationLocationImage = "";
         Z40000OrganisationLocationImage_GXI = "";
         T001U4_A613LocationImageId = new Guid[] {Guid.Empty} ;
         T001U4_A614OrganisationLocationId = new Guid[] {Guid.Empty} ;
         T001U4_A40000OrganisationLocationImage_GXI = new string[] {""} ;
         T001U4_A615OrganisationLocationImage = new string[] {""} ;
         T001U5_A613LocationImageId = new Guid[] {Guid.Empty} ;
         T001U3_A613LocationImageId = new Guid[] {Guid.Empty} ;
         T001U3_A614OrganisationLocationId = new Guid[] {Guid.Empty} ;
         T001U3_A40000OrganisationLocationImage_GXI = new string[] {""} ;
         T001U3_A615OrganisationLocationImage = new string[] {""} ;
         sMode105 = "";
         T001U6_A613LocationImageId = new Guid[] {Guid.Empty} ;
         T001U7_A613LocationImageId = new Guid[] {Guid.Empty} ;
         T001U2_A613LocationImageId = new Guid[] {Guid.Empty} ;
         T001U2_A614OrganisationLocationId = new Guid[] {Guid.Empty} ;
         T001U2_A40000OrganisationLocationImage_GXI = new string[] {""} ;
         T001U2_A615OrganisationLocationImage = new string[] {""} ;
         T001U12_A613LocationImageId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ613LocationImageId = Guid.Empty;
         ZZ614OrganisationLocationId = Guid.Empty;
         ZZ615OrganisationLocationImage = "";
         ZZ40000OrganisationLocationImage_GXI = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_locationimage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_locationimage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_locationimage__default(),
            new Object[][] {
                new Object[] {
               T001U2_A613LocationImageId, T001U2_A614OrganisationLocationId, T001U2_A40000OrganisationLocationImage_GXI, T001U2_A615OrganisationLocationImage
               }
               , new Object[] {
               T001U3_A613LocationImageId, T001U3_A614OrganisationLocationId, T001U3_A40000OrganisationLocationImage_GXI, T001U3_A615OrganisationLocationImage
               }
               , new Object[] {
               T001U4_A613LocationImageId, T001U4_A614OrganisationLocationId, T001U4_A40000OrganisationLocationImage_GXI, T001U4_A615OrganisationLocationImage
               }
               , new Object[] {
               T001U5_A613LocationImageId
               }
               , new Object[] {
               T001U6_A613LocationImageId
               }
               , new Object[] {
               T001U7_A613LocationImageId
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
               T001U12_A613LocationImageId
               }
            }
         );
         Z613LocationImageId = Guid.NewGuid( );
         A613LocationImageId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound105 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLocationImageId_Enabled ;
      private int edtOrganisationLocationId_Enabled ;
      private int imgOrganisationLocationImage_Enabled ;
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
      private string edtLocationImageId_Internalname ;
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
      private string edtLocationImageId_Jsonclick ;
      private string edtOrganisationLocationId_Internalname ;
      private string edtOrganisationLocationId_Jsonclick ;
      private string imgOrganisationLocationImage_Internalname ;
      private string sImgUrl ;
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
      private string sMode105 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A615OrganisationLocationImage_IsBlob ;
      private string A40000OrganisationLocationImage_GXI ;
      private string Z40000OrganisationLocationImage_GXI ;
      private string ZZ40000OrganisationLocationImage_GXI ;
      private string A615OrganisationLocationImage ;
      private string Z615OrganisationLocationImage ;
      private string ZZ615OrganisationLocationImage ;
      private Guid Z613LocationImageId ;
      private Guid Z614OrganisationLocationId ;
      private Guid A613LocationImageId ;
      private Guid A614OrganisationLocationId ;
      private Guid ZZ613LocationImageId ;
      private Guid ZZ614OrganisationLocationId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001U4_A613LocationImageId ;
      private Guid[] T001U4_A614OrganisationLocationId ;
      private string[] T001U4_A40000OrganisationLocationImage_GXI ;
      private string[] T001U4_A615OrganisationLocationImage ;
      private Guid[] T001U5_A613LocationImageId ;
      private Guid[] T001U3_A613LocationImageId ;
      private Guid[] T001U3_A614OrganisationLocationId ;
      private string[] T001U3_A40000OrganisationLocationImage_GXI ;
      private string[] T001U3_A615OrganisationLocationImage ;
      private Guid[] T001U6_A613LocationImageId ;
      private Guid[] T001U7_A613LocationImageId ;
      private Guid[] T001U2_A613LocationImageId ;
      private Guid[] T001U2_A614OrganisationLocationId ;
      private string[] T001U2_A40000OrganisationLocationImage_GXI ;
      private string[] T001U2_A615OrganisationLocationImage ;
      private Guid[] T001U12_A613LocationImageId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_locationimage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_locationimage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_locationimage__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001U2;
       prmT001U2 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U3;
       prmT001U3 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U4;
       prmT001U4 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U5;
       prmT001U5 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U6;
       prmT001U6 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U7;
       prmT001U7 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U8;
       prmT001U8 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationLocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationLocationImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationLocationImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Trn_LocationImage", Fld="OrganisationLocationImage"}
       };
       Object[] prmT001U9;
       prmT001U9 = new Object[] {
       new ParDef("OrganisationLocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U10;
       prmT001U10 = new Object[] {
       new ParDef("OrganisationLocationImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationLocationImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_LocationImage", Fld="OrganisationLocationImage"} ,
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U11;
       prmT001U11 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001U12;
       prmT001U12 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T001U2", "SELECT LocationImageId, OrganisationLocationId, OrganisationLocationImage_GXI, OrganisationLocationImage FROM Trn_LocationImage WHERE LocationImageId = :LocationImageId  FOR UPDATE OF Trn_LocationImage NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001U2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U3", "SELECT LocationImageId, OrganisationLocationId, OrganisationLocationImage_GXI, OrganisationLocationImage FROM Trn_LocationImage WHERE LocationImageId = :LocationImageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U4", "SELECT TM1.LocationImageId, TM1.OrganisationLocationId, TM1.OrganisationLocationImage_GXI, TM1.OrganisationLocationImage FROM Trn_LocationImage TM1 WHERE TM1.LocationImageId = :LocationImageId ORDER BY TM1.LocationImageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U5", "SELECT LocationImageId FROM Trn_LocationImage WHERE LocationImageId = :LocationImageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001U6", "SELECT LocationImageId FROM Trn_LocationImage WHERE ( LocationImageId > :LocationImageId) ORDER BY LocationImageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001U7", "SELECT LocationImageId FROM Trn_LocationImage WHERE ( LocationImageId < :LocationImageId) ORDER BY LocationImageId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001U8", "SAVEPOINT gxupdate;INSERT INTO Trn_LocationImage(LocationImageId, OrganisationLocationId, OrganisationLocationImage, OrganisationLocationImage_GXI) VALUES(:LocationImageId, :OrganisationLocationId, :OrganisationLocationImage, :OrganisationLocationImage_GXI);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001U8)
          ,new CursorDef("T001U9", "SAVEPOINT gxupdate;UPDATE Trn_LocationImage SET OrganisationLocationId=:OrganisationLocationId  WHERE LocationImageId = :LocationImageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001U9)
          ,new CursorDef("T001U10", "SAVEPOINT gxupdate;UPDATE Trn_LocationImage SET OrganisationLocationImage=:OrganisationLocationImage, OrganisationLocationImage_GXI=:OrganisationLocationImage_GXI  WHERE LocationImageId = :LocationImageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001U10)
          ,new CursorDef("T001U11", "SAVEPOINT gxupdate;DELETE FROM Trn_LocationImage  WHERE LocationImageId = :LocationImageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001U11)
          ,new CursorDef("T001U12", "SELECT LocationImageId FROM Trn_LocationImage ORDER BY LocationImageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U12,100, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
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
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
