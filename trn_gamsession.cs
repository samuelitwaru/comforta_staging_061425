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
   public class trn_gamsession : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Gam Session", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtrepid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_gamsession( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_gamsession( IGxContext context )
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
         chksesreload = new GXCheckbox();
         chksesendedbyotherlogin = new GXCheckbox();
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
         A469sesreload = StringUtil.StrToBool( StringUtil.BoolToStr( A469sesreload));
         AssignAttri("", false, "A469sesreload", A469sesreload);
         A484sesendedbyotherlogin = StringUtil.StrToBool( StringUtil.BoolToStr( A484sesendedbyotherlogin));
         AssignAttri("", false, "A484sesendedbyotherlogin", A484sesendedbyotherlogin);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Gam Session", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_GamSession.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_GamSession.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtrepid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtrepid_Internalname, context.GetMessage( "repid", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtrepid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A449repid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtrepid_Enabled!=0) ? context.localUtil.Format( (decimal)(A449repid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A449repid), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtrepid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtrepid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsestoken_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsestoken_Internalname, context.GetMessage( "sestoken", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsestoken_Internalname, StringUtil.RTrim( A448sestoken), StringUtil.RTrim( context.localUtil.Format( A448sestoken, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsestoken_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsestoken_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesdate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesdate_Internalname, context.GetMessage( "sesdate", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtsesdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtsesdate_Internalname, context.localUtil.TToC( A457sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A457sesdate, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesdate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesdate_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtsesdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtsesdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsessts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsessts_Internalname, context.GetMessage( "sessts", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsessts_Internalname, StringUtil.RTrim( A450sessts), StringUtil.RTrim( context.localUtil.Format( A450sessts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsessts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsessts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsestype_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsestype_Internalname, context.GetMessage( "sestype", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsestype_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A451sestype), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtsestype_Enabled!=0) ? context.localUtil.Format( (decimal)(A451sestype), "ZZZ9") : context.localUtil.Format( (decimal)(A451sestype), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsestype_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsestype_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesurl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesurl_Internalname, context.GetMessage( "sesurl", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesurl_Internalname, A461sesurl, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtsesurl_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2048", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesipadd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesipadd_Internalname, context.GetMessage( "sesipadd", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesipadd_Internalname, StringUtil.RTrim( A462sesipadd), StringUtil.RTrim( context.localUtil.Format( A462sesipadd, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesipadd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesipadd_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtopesysid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtopesysid_Internalname, context.GetMessage( "opesysid", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtopesysid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A454opesysid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtopesysid_Enabled!=0) ? context.localUtil.Format( (decimal)(A454opesysid), "ZZZ9") : context.localUtil.Format( (decimal)(A454opesysid), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtopesysid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtopesysid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtseslastacc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtseslastacc_Internalname, context.GetMessage( "seslastacc", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtseslastacc_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtseslastacc_Internalname, context.localUtil.TToC( A463seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A463seslastacc, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtseslastacc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtseslastacc_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtseslastacc_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtseslastacc_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsestimeout_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsestimeout_Internalname, context.GetMessage( "sestimeout", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsestimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A464sestimeout), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtsestimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(A464sestimeout), "ZZZ9") : context.localUtil.Format( (decimal)(A464sestimeout), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsestimeout_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsestimeout_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtseslogatt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtseslogatt_Internalname, context.GetMessage( "seslogatt", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtseslogatt_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A465seslogatt), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtseslogatt_Enabled!=0) ? context.localUtil.Format( (decimal)(A465seslogatt), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A465seslogatt), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtseslogatt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtseslogatt_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtseslogdate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtseslogdate_Internalname, context.GetMessage( "seslogdate", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtseslogdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtseslogdate_Internalname, context.localUtil.TToC( A466seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A466seslogdate, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtseslogdate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtseslogdate_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtseslogdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtseslogdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesshareddata_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesshareddata_Internalname, context.GetMessage( "sesshareddata", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesshareddata_Internalname, A467sesshareddata, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", 0, 1, edtsesshareddata_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesenddate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesenddate_Internalname, context.GetMessage( "sesenddate", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtsesenddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtsesenddate_Internalname, context.localUtil.TToC( A468sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A468sesenddate, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesenddate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesenddate_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtsesenddate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtsesenddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chksesreload_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chksesreload_Internalname, context.GetMessage( "sesreload", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chksesreload_Internalname, StringUtil.BoolToStr( A469sesreload), "", context.GetMessage( "sesreload", ""), 1, chksesreload.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(104, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,104);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtbrwid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtbrwid_Internalname, context.GetMessage( "brwid", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtbrwid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A460brwid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtbrwid_Enabled!=0) ? context.localUtil.Format( (decimal)(A460brwid), "ZZZ9") : context.localUtil.Format( (decimal)(A460brwid), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtbrwid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtbrwid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtseslasturl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtseslasturl_Internalname, context.GetMessage( "seslasturl", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtseslasturl_Internalname, A470seslasturl, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", 0, 1, edtseslasturl_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2048", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtseslogin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtseslogin_Internalname, context.GetMessage( "seslogin", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtseslogin_Internalname, A471seslogin, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", 0, 1, edtseslogin_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesexttoken_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesexttoken_Internalname, context.GetMessage( "sesexttoken", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesexttoken_Internalname, StringUtil.RTrim( A455sesexttoken), StringUtil.RTrim( context.localUtil.Format( A455sesexttoken, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesexttoken_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesexttoken_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtuserguid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtuserguid_Internalname, context.GetMessage( "userguid", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtuserguid_Internalname, StringUtil.RTrim( A456userguid), StringUtil.RTrim( context.localUtil.Format( A456userguid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtuserguid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtuserguid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesapptokenexp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesapptokenexp_Internalname, context.GetMessage( "sesapptokenexp", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtsesapptokenexp_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtsesapptokenexp_Internalname, context.localUtil.TToC( A472sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A472sesapptokenexp, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesapptokenexp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesapptokenexp_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtsesapptokenexp_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtsesapptokenexp_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesrefreshtoken_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesrefreshtoken_Internalname, context.GetMessage( "sesrefreshtoken", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesrefreshtoken_Internalname, StringUtil.RTrim( A452sesrefreshtoken), StringUtil.RTrim( context.localUtil.Format( A452sesrefreshtoken, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesrefreshtoken_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesrefreshtoken_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesappid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesappid_Internalname, context.GetMessage( "sesappid", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesappid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A453sesappid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtsesappid_Enabled!=0) ? context.localUtil.Format( (decimal)(A453sesappid), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A453sesappid), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,144);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesappid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesappid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesdeviceid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesdeviceid_Internalname, context.GetMessage( "sesdeviceid", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesdeviceid_Internalname, StringUtil.RTrim( A473sesdeviceid), StringUtil.RTrim( context.localUtil.Format( A473sesdeviceid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesdeviceid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesdeviceid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesexttoken2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesexttoken2_Internalname, context.GetMessage( "sesexttoken2", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesexttoken2_Internalname, A474sesexttoken2, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"", 0, 1, edtsesexttoken2_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesauttypename_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesauttypename_Internalname, context.GetMessage( "sesauttypename", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesauttypename_Internalname, StringUtil.RTrim( A458sesauttypename), StringUtil.RTrim( context.localUtil.Format( A458sesauttypename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesauttypename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesauttypename_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesoauthtokenmaxrenew_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesoauthtokenmaxrenew_Internalname, context.GetMessage( "sesoauthtokenmaxrenew", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesoauthtokenmaxrenew_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A475sesoauthtokenmaxrenew), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtsesoauthtokenmaxrenew_Enabled!=0) ? context.localUtil.Format( (decimal)(A475sesoauthtokenmaxrenew), "ZZZ9") : context.localUtil.Format( (decimal)(A475sesoauthtokenmaxrenew), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesoauthtokenmaxrenew_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesoauthtokenmaxrenew_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesoauthtokenexpires_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesoauthtokenexpires_Internalname, context.GetMessage( "sesoauthtokenexpires", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtsesoauthtokenexpires_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A476sesoauthtokenexpires), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtsesoauthtokenexpires_Enabled!=0) ? context.localUtil.Format( (decimal)(A476sesoauthtokenexpires), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A476sesoauthtokenexpires), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesoauthtokenexpires_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesoauthtokenexpires_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesoauthscope_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesoauthscope_Internalname, context.GetMessage( "sesoauthscope", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesoauthscope_Internalname, A477sesoauthscope, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"", 0, 1, edtsesoauthscope_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2048", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesexttoken3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesexttoken3_Internalname, context.GetMessage( "sesexttoken3", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesexttoken3_Internalname, A478sesexttoken3, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,179);\"", 0, 1, edtsesexttoken3_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesexttokenexpires_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesexttokenexpires_Internalname, context.GetMessage( "sesexttokenexpires", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtsesexttokenexpires_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtsesexttokenexpires_Internalname, context.localUtil.TToC( A479sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A479sesexttokenexpires, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,184);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesexttokenexpires_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesexttokenexpires_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtsesexttokenexpires_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtsesexttokenexpires_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesexttokenrefresh_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesexttokenrefresh_Internalname, context.GetMessage( "sesexttokenrefresh", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesexttokenrefresh_Internalname, A480sesexttokenrefresh, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,189);\"", 0, 1, edtsesexttokenrefresh_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesjson_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesjson_Internalname, context.GetMessage( "sesjson", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesjson_Internalname, A481sesjson, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,194);\"", 0, 1, edtsesjson_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesidtoken_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesidtoken_Internalname, context.GetMessage( "sesidtoken", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 199,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesidtoken_Internalname, A482sesidtoken, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,199);\"", 0, 1, edtsesidtoken_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "4096", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesotp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesotp_Internalname, context.GetMessage( "sesotp", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtsesotp_Internalname, A459sesotp, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,204);\"", 0, 1, edtsesotp_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtsesotpexpire_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsesotpexpire_Internalname, context.GetMessage( "sesotpexpire", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 209,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtsesotpexpire_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtsesotpexpire_Internalname, context.localUtil.TToC( A483sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A483sesotpexpire, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,209);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsesotpexpire_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtsesotpexpire_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_GamSession.htm");
         GxWebStd.gx_bitmap( context, edtsesotpexpire_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtsesotpexpire_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_GamSession.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chksesendedbyotherlogin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chksesendedbyotherlogin_Internalname, context.GetMessage( "sesendedbyotherlogin", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 214,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chksesendedbyotherlogin_Internalname, StringUtil.BoolToStr( A484sesendedbyotherlogin), "", context.GetMessage( "sesendedbyotherlogin", ""), 1, chksesendedbyotherlogin.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(214, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,214);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 219,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 221,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 223,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_GamSession.htm");
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
            Z449repid = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z449repid"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z448sestoken = cgiGet( "Z448sestoken");
            Z457sesdate = context.localUtil.CToT( cgiGet( "Z457sesdate"), 0);
            Z450sessts = cgiGet( "Z450sessts");
            Z451sestype = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z451sestype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z461sesurl = cgiGet( "Z461sesurl");
            Z462sesipadd = cgiGet( "Z462sesipadd");
            Z454opesysid = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z454opesysid"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z463seslastacc = context.localUtil.CToT( cgiGet( "Z463seslastacc"), 0);
            Z464sestimeout = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z464sestimeout"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z465seslogatt = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z465seslogatt"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z466seslogdate = context.localUtil.CToT( cgiGet( "Z466seslogdate"), 0);
            Z468sesenddate = context.localUtil.CToT( cgiGet( "Z468sesenddate"), 0);
            Z469sesreload = StringUtil.StrToBool( cgiGet( "Z469sesreload"));
            Z460brwid = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z460brwid"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z470seslasturl = cgiGet( "Z470seslasturl");
            Z471seslogin = cgiGet( "Z471seslogin");
            Z455sesexttoken = cgiGet( "Z455sesexttoken");
            Z456userguid = cgiGet( "Z456userguid");
            Z472sesapptokenexp = context.localUtil.CToT( cgiGet( "Z472sesapptokenexp"), 0);
            Z452sesrefreshtoken = cgiGet( "Z452sesrefreshtoken");
            Z453sesappid = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z453sesappid"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z473sesdeviceid = cgiGet( "Z473sesdeviceid");
            Z474sesexttoken2 = cgiGet( "Z474sesexttoken2");
            Z458sesauttypename = cgiGet( "Z458sesauttypename");
            Z475sesoauthtokenmaxrenew = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z475sesoauthtokenmaxrenew"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z476sesoauthtokenexpires = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z476sesoauthtokenexpires"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z477sesoauthscope = cgiGet( "Z477sesoauthscope");
            Z479sesexttokenexpires = context.localUtil.CToT( cgiGet( "Z479sesexttokenexpires"), 0);
            Z480sesexttokenrefresh = cgiGet( "Z480sesexttokenrefresh");
            Z482sesidtoken = cgiGet( "Z482sesidtoken");
            Z459sesotp = cgiGet( "Z459sesotp");
            Z483sesotpexpire = context.localUtil.CToT( cgiGet( "Z483sesotpexpire"), 0);
            Z484sesendedbyotherlogin = StringUtil.StrToBool( cgiGet( "Z484sesendedbyotherlogin"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtrepid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtrepid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPID");
               AnyError = 1;
               GX_FocusControl = edtrepid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A449repid = 0;
               AssignAttri("", false, "A449repid", StringUtil.LTrimStr( (decimal)(A449repid), 9, 0));
            }
            else
            {
               A449repid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtrepid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A449repid", StringUtil.LTrimStr( (decimal)(A449repid), 9, 0));
            }
            A448sestoken = cgiGet( edtsestoken_Internalname);
            AssignAttri("", false, "A448sestoken", A448sestoken);
            if ( context.localUtil.VCDateTime( cgiGet( edtsesdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "sesdate", "")}), 1, "SESDATE");
               AnyError = 1;
               GX_FocusControl = edtsesdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A457sesdate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A457sesdate", context.localUtil.TToC( A457sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A457sesdate = context.localUtil.CToT( cgiGet( edtsesdate_Internalname));
               AssignAttri("", false, "A457sesdate", context.localUtil.TToC( A457sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A450sessts = cgiGet( edtsessts_Internalname);
            AssignAttri("", false, "A450sessts", A450sessts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtsestype_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtsestype_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SESTYPE");
               AnyError = 1;
               GX_FocusControl = edtsestype_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A451sestype = 0;
               AssignAttri("", false, "A451sestype", StringUtil.LTrimStr( (decimal)(A451sestype), 4, 0));
            }
            else
            {
               A451sestype = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtsestype_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A451sestype", StringUtil.LTrimStr( (decimal)(A451sestype), 4, 0));
            }
            A461sesurl = cgiGet( edtsesurl_Internalname);
            AssignAttri("", false, "A461sesurl", A461sesurl);
            A462sesipadd = cgiGet( edtsesipadd_Internalname);
            AssignAttri("", false, "A462sesipadd", A462sesipadd);
            if ( ( ( context.localUtil.CToN( cgiGet( edtopesysid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtopesysid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPESYSID");
               AnyError = 1;
               GX_FocusControl = edtopesysid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A454opesysid = 0;
               AssignAttri("", false, "A454opesysid", StringUtil.LTrimStr( (decimal)(A454opesysid), 4, 0));
            }
            else
            {
               A454opesysid = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtopesysid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A454opesysid", StringUtil.LTrimStr( (decimal)(A454opesysid), 4, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtseslastacc_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "seslastacc", "")}), 1, "SESLASTACC");
               AnyError = 1;
               GX_FocusControl = edtseslastacc_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A463seslastacc = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A463seslastacc", context.localUtil.TToC( A463seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A463seslastacc = context.localUtil.CToT( cgiGet( edtseslastacc_Internalname));
               AssignAttri("", false, "A463seslastacc", context.localUtil.TToC( A463seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtsestimeout_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtsestimeout_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SESTIMEOUT");
               AnyError = 1;
               GX_FocusControl = edtsestimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A464sestimeout = 0;
               AssignAttri("", false, "A464sestimeout", StringUtil.LTrimStr( (decimal)(A464sestimeout), 4, 0));
            }
            else
            {
               A464sestimeout = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtsestimeout_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A464sestimeout", StringUtil.LTrimStr( (decimal)(A464sestimeout), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtseslogatt_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtseslogatt_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SESLOGATT");
               AnyError = 1;
               GX_FocusControl = edtseslogatt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A465seslogatt = 0;
               AssignAttri("", false, "A465seslogatt", StringUtil.LTrimStr( (decimal)(A465seslogatt), 9, 0));
            }
            else
            {
               A465seslogatt = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtseslogatt_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A465seslogatt", StringUtil.LTrimStr( (decimal)(A465seslogatt), 9, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtseslogdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "seslogdate", "")}), 1, "SESLOGDATE");
               AnyError = 1;
               GX_FocusControl = edtseslogdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A466seslogdate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A466seslogdate", context.localUtil.TToC( A466seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A466seslogdate = context.localUtil.CToT( cgiGet( edtseslogdate_Internalname));
               AssignAttri("", false, "A466seslogdate", context.localUtil.TToC( A466seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A467sesshareddata = cgiGet( edtsesshareddata_Internalname);
            AssignAttri("", false, "A467sesshareddata", A467sesshareddata);
            if ( context.localUtil.VCDateTime( cgiGet( edtsesenddate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "sesenddate", "")}), 1, "SESENDDATE");
               AnyError = 1;
               GX_FocusControl = edtsesenddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A468sesenddate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A468sesenddate", context.localUtil.TToC( A468sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A468sesenddate = context.localUtil.CToT( cgiGet( edtsesenddate_Internalname));
               AssignAttri("", false, "A468sesenddate", context.localUtil.TToC( A468sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A469sesreload = StringUtil.StrToBool( cgiGet( chksesreload_Internalname));
            AssignAttri("", false, "A469sesreload", A469sesreload);
            if ( ( ( context.localUtil.CToN( cgiGet( edtbrwid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtbrwid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BRWID");
               AnyError = 1;
               GX_FocusControl = edtbrwid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A460brwid = 0;
               AssignAttri("", false, "A460brwid", StringUtil.LTrimStr( (decimal)(A460brwid), 4, 0));
            }
            else
            {
               A460brwid = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtbrwid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A460brwid", StringUtil.LTrimStr( (decimal)(A460brwid), 4, 0));
            }
            A470seslasturl = cgiGet( edtseslasturl_Internalname);
            AssignAttri("", false, "A470seslasturl", A470seslasturl);
            A471seslogin = cgiGet( edtseslogin_Internalname);
            AssignAttri("", false, "A471seslogin", A471seslogin);
            A455sesexttoken = cgiGet( edtsesexttoken_Internalname);
            AssignAttri("", false, "A455sesexttoken", A455sesexttoken);
            A456userguid = cgiGet( edtuserguid_Internalname);
            AssignAttri("", false, "A456userguid", A456userguid);
            if ( context.localUtil.VCDateTime( cgiGet( edtsesapptokenexp_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "sesapptokenexp", "")}), 1, "SESAPPTOKENEXP");
               AnyError = 1;
               GX_FocusControl = edtsesapptokenexp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A472sesapptokenexp = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A472sesapptokenexp", context.localUtil.TToC( A472sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A472sesapptokenexp = context.localUtil.CToT( cgiGet( edtsesapptokenexp_Internalname));
               AssignAttri("", false, "A472sesapptokenexp", context.localUtil.TToC( A472sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A452sesrefreshtoken = cgiGet( edtsesrefreshtoken_Internalname);
            AssignAttri("", false, "A452sesrefreshtoken", A452sesrefreshtoken);
            if ( ( ( context.localUtil.CToN( cgiGet( edtsesappid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtsesappid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SESAPPID");
               AnyError = 1;
               GX_FocusControl = edtsesappid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A453sesappid = 0;
               AssignAttri("", false, "A453sesappid", StringUtil.LTrimStr( (decimal)(A453sesappid), 18, 0));
            }
            else
            {
               A453sesappid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtsesappid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A453sesappid", StringUtil.LTrimStr( (decimal)(A453sesappid), 18, 0));
            }
            A473sesdeviceid = cgiGet( edtsesdeviceid_Internalname);
            AssignAttri("", false, "A473sesdeviceid", A473sesdeviceid);
            A474sesexttoken2 = cgiGet( edtsesexttoken2_Internalname);
            AssignAttri("", false, "A474sesexttoken2", A474sesexttoken2);
            A458sesauttypename = cgiGet( edtsesauttypename_Internalname);
            AssignAttri("", false, "A458sesauttypename", A458sesauttypename);
            if ( ( ( context.localUtil.CToN( cgiGet( edtsesoauthtokenmaxrenew_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtsesoauthtokenmaxrenew_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SESOAUTHTOKENMAXRENEW");
               AnyError = 1;
               GX_FocusControl = edtsesoauthtokenmaxrenew_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A475sesoauthtokenmaxrenew = 0;
               AssignAttri("", false, "A475sesoauthtokenmaxrenew", StringUtil.LTrimStr( (decimal)(A475sesoauthtokenmaxrenew), 4, 0));
            }
            else
            {
               A475sesoauthtokenmaxrenew = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtsesoauthtokenmaxrenew_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A475sesoauthtokenmaxrenew", StringUtil.LTrimStr( (decimal)(A475sesoauthtokenmaxrenew), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtsesoauthtokenexpires_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtsesoauthtokenexpires_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SESOAUTHTOKENEXPIRES");
               AnyError = 1;
               GX_FocusControl = edtsesoauthtokenexpires_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A476sesoauthtokenexpires = 0;
               AssignAttri("", false, "A476sesoauthtokenexpires", StringUtil.LTrimStr( (decimal)(A476sesoauthtokenexpires), 9, 0));
            }
            else
            {
               A476sesoauthtokenexpires = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtsesoauthtokenexpires_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A476sesoauthtokenexpires", StringUtil.LTrimStr( (decimal)(A476sesoauthtokenexpires), 9, 0));
            }
            A477sesoauthscope = cgiGet( edtsesoauthscope_Internalname);
            AssignAttri("", false, "A477sesoauthscope", A477sesoauthscope);
            A478sesexttoken3 = cgiGet( edtsesexttoken3_Internalname);
            AssignAttri("", false, "A478sesexttoken3", A478sesexttoken3);
            if ( context.localUtil.VCDateTime( cgiGet( edtsesexttokenexpires_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "sesexttokenexpires", "")}), 1, "SESEXTTOKENEXPIRES");
               AnyError = 1;
               GX_FocusControl = edtsesexttokenexpires_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A479sesexttokenexpires = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A479sesexttokenexpires", context.localUtil.TToC( A479sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A479sesexttokenexpires = context.localUtil.CToT( cgiGet( edtsesexttokenexpires_Internalname));
               AssignAttri("", false, "A479sesexttokenexpires", context.localUtil.TToC( A479sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A480sesexttokenrefresh = cgiGet( edtsesexttokenrefresh_Internalname);
            AssignAttri("", false, "A480sesexttokenrefresh", A480sesexttokenrefresh);
            A481sesjson = cgiGet( edtsesjson_Internalname);
            AssignAttri("", false, "A481sesjson", A481sesjson);
            A482sesidtoken = cgiGet( edtsesidtoken_Internalname);
            AssignAttri("", false, "A482sesidtoken", A482sesidtoken);
            A459sesotp = cgiGet( edtsesotp_Internalname);
            AssignAttri("", false, "A459sesotp", A459sesotp);
            if ( context.localUtil.VCDateTime( cgiGet( edtsesotpexpire_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "sesotpexpire", "")}), 1, "SESOTPEXPIRE");
               AnyError = 1;
               GX_FocusControl = edtsesotpexpire_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A483sesotpexpire = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A483sesotpexpire", context.localUtil.TToC( A483sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A483sesotpexpire = context.localUtil.CToT( cgiGet( edtsesotpexpire_Internalname));
               AssignAttri("", false, "A483sesotpexpire", context.localUtil.TToC( A483sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A484sesendedbyotherlogin = StringUtil.StrToBool( cgiGet( chksesendedbyotherlogin_Internalname));
            AssignAttri("", false, "A484sesendedbyotherlogin", A484sesendedbyotherlogin);
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
               A449repid = (int)(Math.Round(NumberUtil.Val( GetPar( "repid"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A449repid", StringUtil.LTrimStr( (decimal)(A449repid), 9, 0));
               A448sestoken = GetPar( "sestoken");
               AssignAttri("", false, "A448sestoken", A448sestoken);
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
               InitAll1D84( ) ;
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
         DisableAttributes1D84( ) ;
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

      protected void ResetCaption1D0( )
      {
      }

      protected void ZM1D84( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z457sesdate = T001D3_A457sesdate[0];
               Z450sessts = T001D3_A450sessts[0];
               Z451sestype = T001D3_A451sestype[0];
               Z461sesurl = T001D3_A461sesurl[0];
               Z462sesipadd = T001D3_A462sesipadd[0];
               Z454opesysid = T001D3_A454opesysid[0];
               Z463seslastacc = T001D3_A463seslastacc[0];
               Z464sestimeout = T001D3_A464sestimeout[0];
               Z465seslogatt = T001D3_A465seslogatt[0];
               Z466seslogdate = T001D3_A466seslogdate[0];
               Z468sesenddate = T001D3_A468sesenddate[0];
               Z469sesreload = T001D3_A469sesreload[0];
               Z460brwid = T001D3_A460brwid[0];
               Z470seslasturl = T001D3_A470seslasturl[0];
               Z471seslogin = T001D3_A471seslogin[0];
               Z455sesexttoken = T001D3_A455sesexttoken[0];
               Z456userguid = T001D3_A456userguid[0];
               Z472sesapptokenexp = T001D3_A472sesapptokenexp[0];
               Z452sesrefreshtoken = T001D3_A452sesrefreshtoken[0];
               Z453sesappid = T001D3_A453sesappid[0];
               Z473sesdeviceid = T001D3_A473sesdeviceid[0];
               Z474sesexttoken2 = T001D3_A474sesexttoken2[0];
               Z458sesauttypename = T001D3_A458sesauttypename[0];
               Z475sesoauthtokenmaxrenew = T001D3_A475sesoauthtokenmaxrenew[0];
               Z476sesoauthtokenexpires = T001D3_A476sesoauthtokenexpires[0];
               Z477sesoauthscope = T001D3_A477sesoauthscope[0];
               Z479sesexttokenexpires = T001D3_A479sesexttokenexpires[0];
               Z480sesexttokenrefresh = T001D3_A480sesexttokenrefresh[0];
               Z482sesidtoken = T001D3_A482sesidtoken[0];
               Z459sesotp = T001D3_A459sesotp[0];
               Z483sesotpexpire = T001D3_A483sesotpexpire[0];
               Z484sesendedbyotherlogin = T001D3_A484sesendedbyotherlogin[0];
            }
            else
            {
               Z457sesdate = A457sesdate;
               Z450sessts = A450sessts;
               Z451sestype = A451sestype;
               Z461sesurl = A461sesurl;
               Z462sesipadd = A462sesipadd;
               Z454opesysid = A454opesysid;
               Z463seslastacc = A463seslastacc;
               Z464sestimeout = A464sestimeout;
               Z465seslogatt = A465seslogatt;
               Z466seslogdate = A466seslogdate;
               Z468sesenddate = A468sesenddate;
               Z469sesreload = A469sesreload;
               Z460brwid = A460brwid;
               Z470seslasturl = A470seslasturl;
               Z471seslogin = A471seslogin;
               Z455sesexttoken = A455sesexttoken;
               Z456userguid = A456userguid;
               Z472sesapptokenexp = A472sesapptokenexp;
               Z452sesrefreshtoken = A452sesrefreshtoken;
               Z453sesappid = A453sesappid;
               Z473sesdeviceid = A473sesdeviceid;
               Z474sesexttoken2 = A474sesexttoken2;
               Z458sesauttypename = A458sesauttypename;
               Z475sesoauthtokenmaxrenew = A475sesoauthtokenmaxrenew;
               Z476sesoauthtokenexpires = A476sesoauthtokenexpires;
               Z477sesoauthscope = A477sesoauthscope;
               Z479sesexttokenexpires = A479sesexttokenexpires;
               Z480sesexttokenrefresh = A480sesexttokenrefresh;
               Z482sesidtoken = A482sesidtoken;
               Z459sesotp = A459sesotp;
               Z483sesotpexpire = A483sesotpexpire;
               Z484sesendedbyotherlogin = A484sesendedbyotherlogin;
            }
         }
         if ( GX_JID == -1 )
         {
            Z449repid = A449repid;
            Z448sestoken = A448sestoken;
            Z457sesdate = A457sesdate;
            Z450sessts = A450sessts;
            Z451sestype = A451sestype;
            Z461sesurl = A461sesurl;
            Z462sesipadd = A462sesipadd;
            Z454opesysid = A454opesysid;
            Z463seslastacc = A463seslastacc;
            Z464sestimeout = A464sestimeout;
            Z465seslogatt = A465seslogatt;
            Z466seslogdate = A466seslogdate;
            Z467sesshareddata = A467sesshareddata;
            Z468sesenddate = A468sesenddate;
            Z469sesreload = A469sesreload;
            Z460brwid = A460brwid;
            Z470seslasturl = A470seslasturl;
            Z471seslogin = A471seslogin;
            Z455sesexttoken = A455sesexttoken;
            Z456userguid = A456userguid;
            Z472sesapptokenexp = A472sesapptokenexp;
            Z452sesrefreshtoken = A452sesrefreshtoken;
            Z453sesappid = A453sesappid;
            Z473sesdeviceid = A473sesdeviceid;
            Z474sesexttoken2 = A474sesexttoken2;
            Z458sesauttypename = A458sesauttypename;
            Z475sesoauthtokenmaxrenew = A475sesoauthtokenmaxrenew;
            Z476sesoauthtokenexpires = A476sesoauthtokenexpires;
            Z477sesoauthscope = A477sesoauthscope;
            Z478sesexttoken3 = A478sesexttoken3;
            Z479sesexttokenexpires = A479sesexttokenexpires;
            Z480sesexttokenrefresh = A480sesexttokenrefresh;
            Z481sesjson = A481sesjson;
            Z482sesidtoken = A482sesidtoken;
            Z459sesotp = A459sesotp;
            Z483sesotpexpire = A483sesotpexpire;
            Z484sesendedbyotherlogin = A484sesendedbyotherlogin;
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

      protected void Load1D84( )
      {
         /* Using cursor T001D4 */
         pr_gam.execute(2, new Object[] {A449repid, A448sestoken});
         if ( (pr_gam.getStatus(2) != 101) )
         {
            RcdFound84 = 1;
            A457sesdate = T001D4_A457sesdate[0];
            AssignAttri("", false, "A457sesdate", context.localUtil.TToC( A457sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A450sessts = T001D4_A450sessts[0];
            AssignAttri("", false, "A450sessts", A450sessts);
            A451sestype = T001D4_A451sestype[0];
            AssignAttri("", false, "A451sestype", StringUtil.LTrimStr( (decimal)(A451sestype), 4, 0));
            A461sesurl = T001D4_A461sesurl[0];
            AssignAttri("", false, "A461sesurl", A461sesurl);
            A462sesipadd = T001D4_A462sesipadd[0];
            AssignAttri("", false, "A462sesipadd", A462sesipadd);
            A454opesysid = T001D4_A454opesysid[0];
            AssignAttri("", false, "A454opesysid", StringUtil.LTrimStr( (decimal)(A454opesysid), 4, 0));
            A463seslastacc = T001D4_A463seslastacc[0];
            AssignAttri("", false, "A463seslastacc", context.localUtil.TToC( A463seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A464sestimeout = T001D4_A464sestimeout[0];
            AssignAttri("", false, "A464sestimeout", StringUtil.LTrimStr( (decimal)(A464sestimeout), 4, 0));
            A465seslogatt = T001D4_A465seslogatt[0];
            AssignAttri("", false, "A465seslogatt", StringUtil.LTrimStr( (decimal)(A465seslogatt), 9, 0));
            A466seslogdate = T001D4_A466seslogdate[0];
            AssignAttri("", false, "A466seslogdate", context.localUtil.TToC( A466seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A467sesshareddata = T001D4_A467sesshareddata[0];
            AssignAttri("", false, "A467sesshareddata", A467sesshareddata);
            A468sesenddate = T001D4_A468sesenddate[0];
            AssignAttri("", false, "A468sesenddate", context.localUtil.TToC( A468sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A469sesreload = T001D4_A469sesreload[0];
            AssignAttri("", false, "A469sesreload", A469sesreload);
            A460brwid = T001D4_A460brwid[0];
            AssignAttri("", false, "A460brwid", StringUtil.LTrimStr( (decimal)(A460brwid), 4, 0));
            A470seslasturl = T001D4_A470seslasturl[0];
            AssignAttri("", false, "A470seslasturl", A470seslasturl);
            A471seslogin = T001D4_A471seslogin[0];
            AssignAttri("", false, "A471seslogin", A471seslogin);
            A455sesexttoken = T001D4_A455sesexttoken[0];
            AssignAttri("", false, "A455sesexttoken", A455sesexttoken);
            A456userguid = T001D4_A456userguid[0];
            AssignAttri("", false, "A456userguid", A456userguid);
            A472sesapptokenexp = T001D4_A472sesapptokenexp[0];
            AssignAttri("", false, "A472sesapptokenexp", context.localUtil.TToC( A472sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A452sesrefreshtoken = T001D4_A452sesrefreshtoken[0];
            AssignAttri("", false, "A452sesrefreshtoken", A452sesrefreshtoken);
            A453sesappid = T001D4_A453sesappid[0];
            AssignAttri("", false, "A453sesappid", StringUtil.LTrimStr( (decimal)(A453sesappid), 18, 0));
            A473sesdeviceid = T001D4_A473sesdeviceid[0];
            AssignAttri("", false, "A473sesdeviceid", A473sesdeviceid);
            A474sesexttoken2 = T001D4_A474sesexttoken2[0];
            AssignAttri("", false, "A474sesexttoken2", A474sesexttoken2);
            A458sesauttypename = T001D4_A458sesauttypename[0];
            AssignAttri("", false, "A458sesauttypename", A458sesauttypename);
            A475sesoauthtokenmaxrenew = T001D4_A475sesoauthtokenmaxrenew[0];
            AssignAttri("", false, "A475sesoauthtokenmaxrenew", StringUtil.LTrimStr( (decimal)(A475sesoauthtokenmaxrenew), 4, 0));
            A476sesoauthtokenexpires = T001D4_A476sesoauthtokenexpires[0];
            AssignAttri("", false, "A476sesoauthtokenexpires", StringUtil.LTrimStr( (decimal)(A476sesoauthtokenexpires), 9, 0));
            A477sesoauthscope = T001D4_A477sesoauthscope[0];
            AssignAttri("", false, "A477sesoauthscope", A477sesoauthscope);
            A478sesexttoken3 = T001D4_A478sesexttoken3[0];
            AssignAttri("", false, "A478sesexttoken3", A478sesexttoken3);
            A479sesexttokenexpires = T001D4_A479sesexttokenexpires[0];
            AssignAttri("", false, "A479sesexttokenexpires", context.localUtil.TToC( A479sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A480sesexttokenrefresh = T001D4_A480sesexttokenrefresh[0];
            AssignAttri("", false, "A480sesexttokenrefresh", A480sesexttokenrefresh);
            A481sesjson = T001D4_A481sesjson[0];
            AssignAttri("", false, "A481sesjson", A481sesjson);
            A482sesidtoken = T001D4_A482sesidtoken[0];
            AssignAttri("", false, "A482sesidtoken", A482sesidtoken);
            A459sesotp = T001D4_A459sesotp[0];
            AssignAttri("", false, "A459sesotp", A459sesotp);
            A483sesotpexpire = T001D4_A483sesotpexpire[0];
            AssignAttri("", false, "A483sesotpexpire", context.localUtil.TToC( A483sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A484sesendedbyotherlogin = T001D4_A484sesendedbyotherlogin[0];
            AssignAttri("", false, "A484sesendedbyotherlogin", A484sesendedbyotherlogin);
            ZM1D84( -1) ;
         }
         pr_gam.close(2);
         OnLoadActions1D84( ) ;
      }

      protected void OnLoadActions1D84( )
      {
      }

      protected void CheckExtendedTable1D84( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1D84( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1D84( )
      {
         /* Using cursor T001D5 */
         pr_gam.execute(3, new Object[] {A449repid, A448sestoken});
         if ( (pr_gam.getStatus(3) != 101) )
         {
            RcdFound84 = 1;
         }
         else
         {
            RcdFound84 = 0;
         }
         pr_gam.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001D3 */
         pr_gam.execute(1, new Object[] {A449repid, A448sestoken});
         if ( (pr_gam.getStatus(1) != 101) )
         {
            ZM1D84( 1) ;
            RcdFound84 = 1;
            A449repid = T001D3_A449repid[0];
            AssignAttri("", false, "A449repid", StringUtil.LTrimStr( (decimal)(A449repid), 9, 0));
            A448sestoken = T001D3_A448sestoken[0];
            AssignAttri("", false, "A448sestoken", A448sestoken);
            A457sesdate = T001D3_A457sesdate[0];
            AssignAttri("", false, "A457sesdate", context.localUtil.TToC( A457sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A450sessts = T001D3_A450sessts[0];
            AssignAttri("", false, "A450sessts", A450sessts);
            A451sestype = T001D3_A451sestype[0];
            AssignAttri("", false, "A451sestype", StringUtil.LTrimStr( (decimal)(A451sestype), 4, 0));
            A461sesurl = T001D3_A461sesurl[0];
            AssignAttri("", false, "A461sesurl", A461sesurl);
            A462sesipadd = T001D3_A462sesipadd[0];
            AssignAttri("", false, "A462sesipadd", A462sesipadd);
            A454opesysid = T001D3_A454opesysid[0];
            AssignAttri("", false, "A454opesysid", StringUtil.LTrimStr( (decimal)(A454opesysid), 4, 0));
            A463seslastacc = T001D3_A463seslastacc[0];
            AssignAttri("", false, "A463seslastacc", context.localUtil.TToC( A463seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A464sestimeout = T001D3_A464sestimeout[0];
            AssignAttri("", false, "A464sestimeout", StringUtil.LTrimStr( (decimal)(A464sestimeout), 4, 0));
            A465seslogatt = T001D3_A465seslogatt[0];
            AssignAttri("", false, "A465seslogatt", StringUtil.LTrimStr( (decimal)(A465seslogatt), 9, 0));
            A466seslogdate = T001D3_A466seslogdate[0];
            AssignAttri("", false, "A466seslogdate", context.localUtil.TToC( A466seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A467sesshareddata = T001D3_A467sesshareddata[0];
            AssignAttri("", false, "A467sesshareddata", A467sesshareddata);
            A468sesenddate = T001D3_A468sesenddate[0];
            AssignAttri("", false, "A468sesenddate", context.localUtil.TToC( A468sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A469sesreload = T001D3_A469sesreload[0];
            AssignAttri("", false, "A469sesreload", A469sesreload);
            A460brwid = T001D3_A460brwid[0];
            AssignAttri("", false, "A460brwid", StringUtil.LTrimStr( (decimal)(A460brwid), 4, 0));
            A470seslasturl = T001D3_A470seslasturl[0];
            AssignAttri("", false, "A470seslasturl", A470seslasturl);
            A471seslogin = T001D3_A471seslogin[0];
            AssignAttri("", false, "A471seslogin", A471seslogin);
            A455sesexttoken = T001D3_A455sesexttoken[0];
            AssignAttri("", false, "A455sesexttoken", A455sesexttoken);
            A456userguid = T001D3_A456userguid[0];
            AssignAttri("", false, "A456userguid", A456userguid);
            A472sesapptokenexp = T001D3_A472sesapptokenexp[0];
            AssignAttri("", false, "A472sesapptokenexp", context.localUtil.TToC( A472sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A452sesrefreshtoken = T001D3_A452sesrefreshtoken[0];
            AssignAttri("", false, "A452sesrefreshtoken", A452sesrefreshtoken);
            A453sesappid = T001D3_A453sesappid[0];
            AssignAttri("", false, "A453sesappid", StringUtil.LTrimStr( (decimal)(A453sesappid), 18, 0));
            A473sesdeviceid = T001D3_A473sesdeviceid[0];
            AssignAttri("", false, "A473sesdeviceid", A473sesdeviceid);
            A474sesexttoken2 = T001D3_A474sesexttoken2[0];
            AssignAttri("", false, "A474sesexttoken2", A474sesexttoken2);
            A458sesauttypename = T001D3_A458sesauttypename[0];
            AssignAttri("", false, "A458sesauttypename", A458sesauttypename);
            A475sesoauthtokenmaxrenew = T001D3_A475sesoauthtokenmaxrenew[0];
            AssignAttri("", false, "A475sesoauthtokenmaxrenew", StringUtil.LTrimStr( (decimal)(A475sesoauthtokenmaxrenew), 4, 0));
            A476sesoauthtokenexpires = T001D3_A476sesoauthtokenexpires[0];
            AssignAttri("", false, "A476sesoauthtokenexpires", StringUtil.LTrimStr( (decimal)(A476sesoauthtokenexpires), 9, 0));
            A477sesoauthscope = T001D3_A477sesoauthscope[0];
            AssignAttri("", false, "A477sesoauthscope", A477sesoauthscope);
            A478sesexttoken3 = T001D3_A478sesexttoken3[0];
            AssignAttri("", false, "A478sesexttoken3", A478sesexttoken3);
            A479sesexttokenexpires = T001D3_A479sesexttokenexpires[0];
            AssignAttri("", false, "A479sesexttokenexpires", context.localUtil.TToC( A479sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A480sesexttokenrefresh = T001D3_A480sesexttokenrefresh[0];
            AssignAttri("", false, "A480sesexttokenrefresh", A480sesexttokenrefresh);
            A481sesjson = T001D3_A481sesjson[0];
            AssignAttri("", false, "A481sesjson", A481sesjson);
            A482sesidtoken = T001D3_A482sesidtoken[0];
            AssignAttri("", false, "A482sesidtoken", A482sesidtoken);
            A459sesotp = T001D3_A459sesotp[0];
            AssignAttri("", false, "A459sesotp", A459sesotp);
            A483sesotpexpire = T001D3_A483sesotpexpire[0];
            AssignAttri("", false, "A483sesotpexpire", context.localUtil.TToC( A483sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A484sesendedbyotherlogin = T001D3_A484sesendedbyotherlogin[0];
            AssignAttri("", false, "A484sesendedbyotherlogin", A484sesendedbyotherlogin);
            Z449repid = A449repid;
            Z448sestoken = A448sestoken;
            sMode84 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1D84( ) ;
            if ( AnyError == 1 )
            {
               RcdFound84 = 0;
               InitializeNonKey1D84( ) ;
            }
            Gx_mode = sMode84;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound84 = 0;
            InitializeNonKey1D84( ) ;
            sMode84 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode84;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_gam.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1D84( ) ;
         if ( RcdFound84 == 0 )
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
         RcdFound84 = 0;
         /* Using cursor T001D6 */
         pr_gam.execute(4, new Object[] {A449repid, A448sestoken});
         if ( (pr_gam.getStatus(4) != 101) )
         {
            while ( (pr_gam.getStatus(4) != 101) && ( ( T001D6_A449repid[0] < A449repid ) || ( T001D6_A449repid[0] == A449repid ) && ( StringUtil.StrCmp(T001D6_A448sestoken[0], A448sestoken) < 0 ) ) )
            {
               pr_gam.readNext(4);
            }
            if ( (pr_gam.getStatus(4) != 101) && ( ( T001D6_A449repid[0] > A449repid ) || ( T001D6_A449repid[0] == A449repid ) && ( StringUtil.StrCmp(T001D6_A448sestoken[0], A448sestoken) > 0 ) ) )
            {
               A449repid = T001D6_A449repid[0];
               AssignAttri("", false, "A449repid", StringUtil.LTrimStr( (decimal)(A449repid), 9, 0));
               A448sestoken = T001D6_A448sestoken[0];
               AssignAttri("", false, "A448sestoken", A448sestoken);
               RcdFound84 = 1;
            }
         }
         pr_gam.close(4);
      }

      protected void move_previous( )
      {
         RcdFound84 = 0;
         /* Using cursor T001D7 */
         pr_gam.execute(5, new Object[] {A449repid, A448sestoken});
         if ( (pr_gam.getStatus(5) != 101) )
         {
            while ( (pr_gam.getStatus(5) != 101) && ( ( T001D7_A449repid[0] > A449repid ) || ( T001D7_A449repid[0] == A449repid ) && ( StringUtil.StrCmp(T001D7_A448sestoken[0], A448sestoken) > 0 ) ) )
            {
               pr_gam.readNext(5);
            }
            if ( (pr_gam.getStatus(5) != 101) && ( ( T001D7_A449repid[0] < A449repid ) || ( T001D7_A449repid[0] == A449repid ) && ( StringUtil.StrCmp(T001D7_A448sestoken[0], A448sestoken) < 0 ) ) )
            {
               A449repid = T001D7_A449repid[0];
               AssignAttri("", false, "A449repid", StringUtil.LTrimStr( (decimal)(A449repid), 9, 0));
               A448sestoken = T001D7_A448sestoken[0];
               AssignAttri("", false, "A448sestoken", A448sestoken);
               RcdFound84 = 1;
            }
         }
         pr_gam.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1D84( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtrepid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1D84( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound84 == 1 )
            {
               if ( ( A449repid != Z449repid ) || ( StringUtil.StrCmp(A448sestoken, Z448sestoken) != 0 ) )
               {
                  A449repid = Z449repid;
                  AssignAttri("", false, "A449repid", StringUtil.LTrimStr( (decimal)(A449repid), 9, 0));
                  A448sestoken = Z448sestoken;
                  AssignAttri("", false, "A448sestoken", A448sestoken);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "REPID");
                  AnyError = 1;
                  GX_FocusControl = edtrepid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtrepid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1D84( ) ;
                  GX_FocusControl = edtrepid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A449repid != Z449repid ) || ( StringUtil.StrCmp(A448sestoken, Z448sestoken) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtrepid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1D84( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "REPID");
                     AnyError = 1;
                     GX_FocusControl = edtrepid_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtrepid_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1D84( ) ;
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
         if ( ( A449repid != Z449repid ) || ( StringUtil.StrCmp(A448sestoken, Z448sestoken) != 0 ) )
         {
            A449repid = Z449repid;
            AssignAttri("", false, "A449repid", StringUtil.LTrimStr( (decimal)(A449repid), 9, 0));
            A448sestoken = Z448sestoken;
            AssignAttri("", false, "A448sestoken", A448sestoken);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "REPID");
            AnyError = 1;
            GX_FocusControl = edtrepid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtrepid_Internalname;
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
         if ( RcdFound84 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "REPID");
            AnyError = 1;
            GX_FocusControl = edtrepid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtsesdate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1D84( ) ;
         if ( RcdFound84 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtsesdate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1D84( ) ;
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
         if ( RcdFound84 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtsesdate_Internalname;
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
         if ( RcdFound84 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtsesdate_Internalname;
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
         ScanStart1D84( ) ;
         if ( RcdFound84 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound84 != 0 )
            {
               ScanNext1D84( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtsesdate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1D84( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1D84( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001D2 */
            pr_gam.execute(0, new Object[] {A449repid, A448sestoken});
            if ( (pr_gam.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"session"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_gam.getStatus(0) == 101) || ( Z457sesdate != T001D2_A457sesdate[0] ) || ( StringUtil.StrCmp(Z450sessts, T001D2_A450sessts[0]) != 0 ) || ( Z451sestype != T001D2_A451sestype[0] ) || ( StringUtil.StrCmp(Z461sesurl, T001D2_A461sesurl[0]) != 0 ) || ( StringUtil.StrCmp(Z462sesipadd, T001D2_A462sesipadd[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z454opesysid != T001D2_A454opesysid[0] ) || ( Z463seslastacc != T001D2_A463seslastacc[0] ) || ( Z464sestimeout != T001D2_A464sestimeout[0] ) || ( Z465seslogatt != T001D2_A465seslogatt[0] ) || ( Z466seslogdate != T001D2_A466seslogdate[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z468sesenddate != T001D2_A468sesenddate[0] ) || ( Z469sesreload != T001D2_A469sesreload[0] ) || ( Z460brwid != T001D2_A460brwid[0] ) || ( StringUtil.StrCmp(Z470seslasturl, T001D2_A470seslasturl[0]) != 0 ) || ( StringUtil.StrCmp(Z471seslogin, T001D2_A471seslogin[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z455sesexttoken, T001D2_A455sesexttoken[0]) != 0 ) || ( StringUtil.StrCmp(Z456userguid, T001D2_A456userguid[0]) != 0 ) || ( Z472sesapptokenexp != T001D2_A472sesapptokenexp[0] ) || ( StringUtil.StrCmp(Z452sesrefreshtoken, T001D2_A452sesrefreshtoken[0]) != 0 ) || ( Z453sesappid != T001D2_A453sesappid[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z473sesdeviceid, T001D2_A473sesdeviceid[0]) != 0 ) || ( StringUtil.StrCmp(Z474sesexttoken2, T001D2_A474sesexttoken2[0]) != 0 ) || ( StringUtil.StrCmp(Z458sesauttypename, T001D2_A458sesauttypename[0]) != 0 ) || ( Z475sesoauthtokenmaxrenew != T001D2_A475sesoauthtokenmaxrenew[0] ) || ( Z476sesoauthtokenexpires != T001D2_A476sesoauthtokenexpires[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z477sesoauthscope, T001D2_A477sesoauthscope[0]) != 0 ) || ( Z479sesexttokenexpires != T001D2_A479sesexttokenexpires[0] ) || ( StringUtil.StrCmp(Z480sesexttokenrefresh, T001D2_A480sesexttokenrefresh[0]) != 0 ) || ( StringUtil.StrCmp(Z482sesidtoken, T001D2_A482sesidtoken[0]) != 0 ) || ( StringUtil.StrCmp(Z459sesotp, T001D2_A459sesotp[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z483sesotpexpire != T001D2_A483sesotpexpire[0] ) || ( Z484sesendedbyotherlogin != T001D2_A484sesendedbyotherlogin[0] ) )
            {
               if ( Z457sesdate != T001D2_A457sesdate[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesdate");
                  GXUtil.WriteLogRaw("Old: ",Z457sesdate);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A457sesdate[0]);
               }
               if ( StringUtil.StrCmp(Z450sessts, T001D2_A450sessts[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sessts");
                  GXUtil.WriteLogRaw("Old: ",Z450sessts);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A450sessts[0]);
               }
               if ( Z451sestype != T001D2_A451sestype[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sestype");
                  GXUtil.WriteLogRaw("Old: ",Z451sestype);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A451sestype[0]);
               }
               if ( StringUtil.StrCmp(Z461sesurl, T001D2_A461sesurl[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesurl");
                  GXUtil.WriteLogRaw("Old: ",Z461sesurl);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A461sesurl[0]);
               }
               if ( StringUtil.StrCmp(Z462sesipadd, T001D2_A462sesipadd[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesipadd");
                  GXUtil.WriteLogRaw("Old: ",Z462sesipadd);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A462sesipadd[0]);
               }
               if ( Z454opesysid != T001D2_A454opesysid[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"opesysid");
                  GXUtil.WriteLogRaw("Old: ",Z454opesysid);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A454opesysid[0]);
               }
               if ( Z463seslastacc != T001D2_A463seslastacc[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"seslastacc");
                  GXUtil.WriteLogRaw("Old: ",Z463seslastacc);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A463seslastacc[0]);
               }
               if ( Z464sestimeout != T001D2_A464sestimeout[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sestimeout");
                  GXUtil.WriteLogRaw("Old: ",Z464sestimeout);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A464sestimeout[0]);
               }
               if ( Z465seslogatt != T001D2_A465seslogatt[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"seslogatt");
                  GXUtil.WriteLogRaw("Old: ",Z465seslogatt);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A465seslogatt[0]);
               }
               if ( Z466seslogdate != T001D2_A466seslogdate[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"seslogdate");
                  GXUtil.WriteLogRaw("Old: ",Z466seslogdate);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A466seslogdate[0]);
               }
               if ( Z468sesenddate != T001D2_A468sesenddate[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesenddate");
                  GXUtil.WriteLogRaw("Old: ",Z468sesenddate);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A468sesenddate[0]);
               }
               if ( Z469sesreload != T001D2_A469sesreload[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesreload");
                  GXUtil.WriteLogRaw("Old: ",Z469sesreload);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A469sesreload[0]);
               }
               if ( Z460brwid != T001D2_A460brwid[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"brwid");
                  GXUtil.WriteLogRaw("Old: ",Z460brwid);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A460brwid[0]);
               }
               if ( StringUtil.StrCmp(Z470seslasturl, T001D2_A470seslasturl[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"seslasturl");
                  GXUtil.WriteLogRaw("Old: ",Z470seslasturl);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A470seslasturl[0]);
               }
               if ( StringUtil.StrCmp(Z471seslogin, T001D2_A471seslogin[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"seslogin");
                  GXUtil.WriteLogRaw("Old: ",Z471seslogin);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A471seslogin[0]);
               }
               if ( StringUtil.StrCmp(Z455sesexttoken, T001D2_A455sesexttoken[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesexttoken");
                  GXUtil.WriteLogRaw("Old: ",Z455sesexttoken);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A455sesexttoken[0]);
               }
               if ( StringUtil.StrCmp(Z456userguid, T001D2_A456userguid[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"userguid");
                  GXUtil.WriteLogRaw("Old: ",Z456userguid);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A456userguid[0]);
               }
               if ( Z472sesapptokenexp != T001D2_A472sesapptokenexp[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesapptokenexp");
                  GXUtil.WriteLogRaw("Old: ",Z472sesapptokenexp);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A472sesapptokenexp[0]);
               }
               if ( StringUtil.StrCmp(Z452sesrefreshtoken, T001D2_A452sesrefreshtoken[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesrefreshtoken");
                  GXUtil.WriteLogRaw("Old: ",Z452sesrefreshtoken);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A452sesrefreshtoken[0]);
               }
               if ( Z453sesappid != T001D2_A453sesappid[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesappid");
                  GXUtil.WriteLogRaw("Old: ",Z453sesappid);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A453sesappid[0]);
               }
               if ( StringUtil.StrCmp(Z473sesdeviceid, T001D2_A473sesdeviceid[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesdeviceid");
                  GXUtil.WriteLogRaw("Old: ",Z473sesdeviceid);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A473sesdeviceid[0]);
               }
               if ( StringUtil.StrCmp(Z474sesexttoken2, T001D2_A474sesexttoken2[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesexttoken2");
                  GXUtil.WriteLogRaw("Old: ",Z474sesexttoken2);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A474sesexttoken2[0]);
               }
               if ( StringUtil.StrCmp(Z458sesauttypename, T001D2_A458sesauttypename[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesauttypename");
                  GXUtil.WriteLogRaw("Old: ",Z458sesauttypename);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A458sesauttypename[0]);
               }
               if ( Z475sesoauthtokenmaxrenew != T001D2_A475sesoauthtokenmaxrenew[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesoauthtokenmaxrenew");
                  GXUtil.WriteLogRaw("Old: ",Z475sesoauthtokenmaxrenew);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A475sesoauthtokenmaxrenew[0]);
               }
               if ( Z476sesoauthtokenexpires != T001D2_A476sesoauthtokenexpires[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesoauthtokenexpires");
                  GXUtil.WriteLogRaw("Old: ",Z476sesoauthtokenexpires);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A476sesoauthtokenexpires[0]);
               }
               if ( StringUtil.StrCmp(Z477sesoauthscope, T001D2_A477sesoauthscope[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesoauthscope");
                  GXUtil.WriteLogRaw("Old: ",Z477sesoauthscope);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A477sesoauthscope[0]);
               }
               if ( Z479sesexttokenexpires != T001D2_A479sesexttokenexpires[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesexttokenexpires");
                  GXUtil.WriteLogRaw("Old: ",Z479sesexttokenexpires);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A479sesexttokenexpires[0]);
               }
               if ( StringUtil.StrCmp(Z480sesexttokenrefresh, T001D2_A480sesexttokenrefresh[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesexttokenrefresh");
                  GXUtil.WriteLogRaw("Old: ",Z480sesexttokenrefresh);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A480sesexttokenrefresh[0]);
               }
               if ( StringUtil.StrCmp(Z482sesidtoken, T001D2_A482sesidtoken[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesidtoken");
                  GXUtil.WriteLogRaw("Old: ",Z482sesidtoken);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A482sesidtoken[0]);
               }
               if ( StringUtil.StrCmp(Z459sesotp, T001D2_A459sesotp[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesotp");
                  GXUtil.WriteLogRaw("Old: ",Z459sesotp);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A459sesotp[0]);
               }
               if ( Z483sesotpexpire != T001D2_A483sesotpexpire[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesotpexpire");
                  GXUtil.WriteLogRaw("Old: ",Z483sesotpexpire);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A483sesotpexpire[0]);
               }
               if ( Z484sesendedbyotherlogin != T001D2_A484sesendedbyotherlogin[0] )
               {
                  GXUtil.WriteLog("trn_gamsession:[seudo value changed for attri]"+"sesendedbyotherlogin");
                  GXUtil.WriteLogRaw("Old: ",Z484sesendedbyotherlogin);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A484sesendedbyotherlogin[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"session"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1D84( )
      {
         BeforeValidate1D84( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D84( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1D84( 0) ;
            CheckOptimisticConcurrency1D84( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D84( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1D84( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001D8 */
                     pr_gam.execute(6, new Object[] {A449repid, A448sestoken, A457sesdate, A450sessts, A451sestype, A461sesurl, A462sesipadd, A454opesysid, A463seslastacc, A464sestimeout, A465seslogatt, A466seslogdate, A467sesshareddata, A468sesenddate, A469sesreload, A460brwid, A470seslasturl, A471seslogin, A455sesexttoken, A456userguid, A472sesapptokenexp, A452sesrefreshtoken, A453sesappid, A473sesdeviceid, A474sesexttoken2, A458sesauttypename, A475sesoauthtokenmaxrenew, A476sesoauthtokenexpires, A477sesoauthscope, A478sesexttoken3, A479sesexttokenexpires, A480sesexttokenrefresh, A481sesjson, A482sesidtoken, A459sesotp, A483sesotpexpire, A484sesendedbyotherlogin});
                     pr_gam.close(6);
                     pr_gam.SmartCacheProvider.SetUpdated("session");
                     if ( (pr_gam.getStatus(6) == 1) )
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
                           ResetCaption1D0( ) ;
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
               Load1D84( ) ;
            }
            EndLevel1D84( ) ;
         }
         CloseExtendedTableCursors1D84( ) ;
      }

      protected void Update1D84( )
      {
         BeforeValidate1D84( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D84( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D84( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D84( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1D84( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001D9 */
                     pr_gam.execute(7, new Object[] {A457sesdate, A450sessts, A451sestype, A461sesurl, A462sesipadd, A454opesysid, A463seslastacc, A464sestimeout, A465seslogatt, A466seslogdate, A467sesshareddata, A468sesenddate, A469sesreload, A460brwid, A470seslasturl, A471seslogin, A455sesexttoken, A456userguid, A472sesapptokenexp, A452sesrefreshtoken, A453sesappid, A473sesdeviceid, A474sesexttoken2, A458sesauttypename, A475sesoauthtokenmaxrenew, A476sesoauthtokenexpires, A477sesoauthscope, A478sesexttoken3, A479sesexttokenexpires, A480sesexttokenrefresh, A481sesjson, A482sesidtoken, A459sesotp, A483sesotpexpire, A484sesendedbyotherlogin, A449repid, A448sestoken});
                     pr_gam.close(7);
                     pr_gam.SmartCacheProvider.SetUpdated("session");
                     if ( (pr_gam.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"session"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1D84( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1D0( ) ;
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
            EndLevel1D84( ) ;
         }
         CloseExtendedTableCursors1D84( ) ;
      }

      protected void DeferredUpdate1D84( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1D84( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D84( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1D84( ) ;
            AfterConfirm1D84( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1D84( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001D10 */
                  pr_gam.execute(8, new Object[] {A449repid, A448sestoken});
                  pr_gam.close(8);
                  pr_gam.SmartCacheProvider.SetUpdated("session");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound84 == 0 )
                        {
                           InitAll1D84( ) ;
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
                        ResetCaption1D0( ) ;
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
         sMode84 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1D84( ) ;
         Gx_mode = sMode84;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1D84( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1D84( )
      {
         if ( ! IsIns( ) )
         {
            pr_gam.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1D84( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_gamsession",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_gamsession",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1D84( )
      {
         /* Using cursor T001D11 */
         pr_gam.execute(9);
         RcdFound84 = 0;
         if ( (pr_gam.getStatus(9) != 101) )
         {
            RcdFound84 = 1;
            A449repid = T001D11_A449repid[0];
            AssignAttri("", false, "A449repid", StringUtil.LTrimStr( (decimal)(A449repid), 9, 0));
            A448sestoken = T001D11_A448sestoken[0];
            AssignAttri("", false, "A448sestoken", A448sestoken);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1D84( )
      {
         /* Scan next routine */
         pr_gam.readNext(9);
         RcdFound84 = 0;
         if ( (pr_gam.getStatus(9) != 101) )
         {
            RcdFound84 = 1;
            A449repid = T001D11_A449repid[0];
            AssignAttri("", false, "A449repid", StringUtil.LTrimStr( (decimal)(A449repid), 9, 0));
            A448sestoken = T001D11_A448sestoken[0];
            AssignAttri("", false, "A448sestoken", A448sestoken);
         }
      }

      protected void ScanEnd1D84( )
      {
         pr_gam.close(9);
      }

      protected void AfterConfirm1D84( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1D84( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1D84( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1D84( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1D84( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1D84( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1D84( )
      {
         edtrepid_Enabled = 0;
         AssignProp("", false, edtrepid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtrepid_Enabled), 5, 0), true);
         edtsestoken_Enabled = 0;
         AssignProp("", false, edtsestoken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsestoken_Enabled), 5, 0), true);
         edtsesdate_Enabled = 0;
         AssignProp("", false, edtsesdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesdate_Enabled), 5, 0), true);
         edtsessts_Enabled = 0;
         AssignProp("", false, edtsessts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsessts_Enabled), 5, 0), true);
         edtsestype_Enabled = 0;
         AssignProp("", false, edtsestype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsestype_Enabled), 5, 0), true);
         edtsesurl_Enabled = 0;
         AssignProp("", false, edtsesurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesurl_Enabled), 5, 0), true);
         edtsesipadd_Enabled = 0;
         AssignProp("", false, edtsesipadd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesipadd_Enabled), 5, 0), true);
         edtopesysid_Enabled = 0;
         AssignProp("", false, edtopesysid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtopesysid_Enabled), 5, 0), true);
         edtseslastacc_Enabled = 0;
         AssignProp("", false, edtseslastacc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtseslastacc_Enabled), 5, 0), true);
         edtsestimeout_Enabled = 0;
         AssignProp("", false, edtsestimeout_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsestimeout_Enabled), 5, 0), true);
         edtseslogatt_Enabled = 0;
         AssignProp("", false, edtseslogatt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtseslogatt_Enabled), 5, 0), true);
         edtseslogdate_Enabled = 0;
         AssignProp("", false, edtseslogdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtseslogdate_Enabled), 5, 0), true);
         edtsesshareddata_Enabled = 0;
         AssignProp("", false, edtsesshareddata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesshareddata_Enabled), 5, 0), true);
         edtsesenddate_Enabled = 0;
         AssignProp("", false, edtsesenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesenddate_Enabled), 5, 0), true);
         chksesreload.Enabled = 0;
         AssignProp("", false, chksesreload_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chksesreload.Enabled), 5, 0), true);
         edtbrwid_Enabled = 0;
         AssignProp("", false, edtbrwid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtbrwid_Enabled), 5, 0), true);
         edtseslasturl_Enabled = 0;
         AssignProp("", false, edtseslasturl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtseslasturl_Enabled), 5, 0), true);
         edtseslogin_Enabled = 0;
         AssignProp("", false, edtseslogin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtseslogin_Enabled), 5, 0), true);
         edtsesexttoken_Enabled = 0;
         AssignProp("", false, edtsesexttoken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesexttoken_Enabled), 5, 0), true);
         edtuserguid_Enabled = 0;
         AssignProp("", false, edtuserguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtuserguid_Enabled), 5, 0), true);
         edtsesapptokenexp_Enabled = 0;
         AssignProp("", false, edtsesapptokenexp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesapptokenexp_Enabled), 5, 0), true);
         edtsesrefreshtoken_Enabled = 0;
         AssignProp("", false, edtsesrefreshtoken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesrefreshtoken_Enabled), 5, 0), true);
         edtsesappid_Enabled = 0;
         AssignProp("", false, edtsesappid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesappid_Enabled), 5, 0), true);
         edtsesdeviceid_Enabled = 0;
         AssignProp("", false, edtsesdeviceid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesdeviceid_Enabled), 5, 0), true);
         edtsesexttoken2_Enabled = 0;
         AssignProp("", false, edtsesexttoken2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesexttoken2_Enabled), 5, 0), true);
         edtsesauttypename_Enabled = 0;
         AssignProp("", false, edtsesauttypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesauttypename_Enabled), 5, 0), true);
         edtsesoauthtokenmaxrenew_Enabled = 0;
         AssignProp("", false, edtsesoauthtokenmaxrenew_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesoauthtokenmaxrenew_Enabled), 5, 0), true);
         edtsesoauthtokenexpires_Enabled = 0;
         AssignProp("", false, edtsesoauthtokenexpires_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesoauthtokenexpires_Enabled), 5, 0), true);
         edtsesoauthscope_Enabled = 0;
         AssignProp("", false, edtsesoauthscope_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesoauthscope_Enabled), 5, 0), true);
         edtsesexttoken3_Enabled = 0;
         AssignProp("", false, edtsesexttoken3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesexttoken3_Enabled), 5, 0), true);
         edtsesexttokenexpires_Enabled = 0;
         AssignProp("", false, edtsesexttokenexpires_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesexttokenexpires_Enabled), 5, 0), true);
         edtsesexttokenrefresh_Enabled = 0;
         AssignProp("", false, edtsesexttokenrefresh_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesexttokenrefresh_Enabled), 5, 0), true);
         edtsesjson_Enabled = 0;
         AssignProp("", false, edtsesjson_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesjson_Enabled), 5, 0), true);
         edtsesidtoken_Enabled = 0;
         AssignProp("", false, edtsesidtoken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesidtoken_Enabled), 5, 0), true);
         edtsesotp_Enabled = 0;
         AssignProp("", false, edtsesotp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesotp_Enabled), 5, 0), true);
         edtsesotpexpire_Enabled = 0;
         AssignProp("", false, edtsesotpexpire_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsesotpexpire_Enabled), 5, 0), true);
         chksesendedbyotherlogin.Enabled = 0;
         AssignProp("", false, chksesendedbyotherlogin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chksesendedbyotherlogin.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1D84( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1D0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_gamsession.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z449repid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z449repid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z448sestoken", StringUtil.RTrim( Z448sestoken));
         GxWebStd.gx_hidden_field( context, "Z457sesdate", context.localUtil.TToC( Z457sesdate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z450sessts", StringUtil.RTrim( Z450sessts));
         GxWebStd.gx_hidden_field( context, "Z451sestype", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z451sestype), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z461sesurl", Z461sesurl);
         GxWebStd.gx_hidden_field( context, "Z462sesipadd", StringUtil.RTrim( Z462sesipadd));
         GxWebStd.gx_hidden_field( context, "Z454opesysid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z454opesysid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z463seslastacc", context.localUtil.TToC( Z463seslastacc, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z464sestimeout", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z464sestimeout), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z465seslogatt", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z465seslogatt), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z466seslogdate", context.localUtil.TToC( Z466seslogdate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z468sesenddate", context.localUtil.TToC( Z468sesenddate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z469sesreload", Z469sesreload);
         GxWebStd.gx_hidden_field( context, "Z460brwid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z460brwid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z470seslasturl", Z470seslasturl);
         GxWebStd.gx_hidden_field( context, "Z471seslogin", Z471seslogin);
         GxWebStd.gx_hidden_field( context, "Z455sesexttoken", StringUtil.RTrim( Z455sesexttoken));
         GxWebStd.gx_hidden_field( context, "Z456userguid", StringUtil.RTrim( Z456userguid));
         GxWebStd.gx_hidden_field( context, "Z472sesapptokenexp", context.localUtil.TToC( Z472sesapptokenexp, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z452sesrefreshtoken", StringUtil.RTrim( Z452sesrefreshtoken));
         GxWebStd.gx_hidden_field( context, "Z453sesappid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z453sesappid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z473sesdeviceid", StringUtil.RTrim( Z473sesdeviceid));
         GxWebStd.gx_hidden_field( context, "Z474sesexttoken2", Z474sesexttoken2);
         GxWebStd.gx_hidden_field( context, "Z458sesauttypename", StringUtil.RTrim( Z458sesauttypename));
         GxWebStd.gx_hidden_field( context, "Z475sesoauthtokenmaxrenew", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z475sesoauthtokenmaxrenew), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z476sesoauthtokenexpires", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z476sesoauthtokenexpires), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z477sesoauthscope", Z477sesoauthscope);
         GxWebStd.gx_hidden_field( context, "Z479sesexttokenexpires", context.localUtil.TToC( Z479sesexttokenexpires, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z480sesexttokenrefresh", Z480sesexttokenrefresh);
         GxWebStd.gx_hidden_field( context, "Z482sesidtoken", Z482sesidtoken);
         GxWebStd.gx_hidden_field( context, "Z459sesotp", Z459sesotp);
         GxWebStd.gx_hidden_field( context, "Z483sesotpexpire", context.localUtil.TToC( Z483sesotpexpire, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z484sesendedbyotherlogin", Z484sesendedbyotherlogin);
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
         return formatLink("trn_gamsession.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_GamSession" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Gam Session", "") ;
      }

      protected void InitializeNonKey1D84( )
      {
         A457sesdate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A457sesdate", context.localUtil.TToC( A457sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A450sessts = "";
         AssignAttri("", false, "A450sessts", A450sessts);
         A451sestype = 0;
         AssignAttri("", false, "A451sestype", StringUtil.LTrimStr( (decimal)(A451sestype), 4, 0));
         A461sesurl = "";
         AssignAttri("", false, "A461sesurl", A461sesurl);
         A462sesipadd = "";
         AssignAttri("", false, "A462sesipadd", A462sesipadd);
         A454opesysid = 0;
         AssignAttri("", false, "A454opesysid", StringUtil.LTrimStr( (decimal)(A454opesysid), 4, 0));
         A463seslastacc = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A463seslastacc", context.localUtil.TToC( A463seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A464sestimeout = 0;
         AssignAttri("", false, "A464sestimeout", StringUtil.LTrimStr( (decimal)(A464sestimeout), 4, 0));
         A465seslogatt = 0;
         AssignAttri("", false, "A465seslogatt", StringUtil.LTrimStr( (decimal)(A465seslogatt), 9, 0));
         A466seslogdate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A466seslogdate", context.localUtil.TToC( A466seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A467sesshareddata = "";
         AssignAttri("", false, "A467sesshareddata", A467sesshareddata);
         A468sesenddate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A468sesenddate", context.localUtil.TToC( A468sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A469sesreload = false;
         AssignAttri("", false, "A469sesreload", A469sesreload);
         A460brwid = 0;
         AssignAttri("", false, "A460brwid", StringUtil.LTrimStr( (decimal)(A460brwid), 4, 0));
         A470seslasturl = "";
         AssignAttri("", false, "A470seslasturl", A470seslasturl);
         A471seslogin = "";
         AssignAttri("", false, "A471seslogin", A471seslogin);
         A455sesexttoken = "";
         AssignAttri("", false, "A455sesexttoken", A455sesexttoken);
         A456userguid = "";
         AssignAttri("", false, "A456userguid", A456userguid);
         A472sesapptokenexp = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A472sesapptokenexp", context.localUtil.TToC( A472sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A452sesrefreshtoken = "";
         AssignAttri("", false, "A452sesrefreshtoken", A452sesrefreshtoken);
         A453sesappid = 0;
         AssignAttri("", false, "A453sesappid", StringUtil.LTrimStr( (decimal)(A453sesappid), 18, 0));
         A473sesdeviceid = "";
         AssignAttri("", false, "A473sesdeviceid", A473sesdeviceid);
         A474sesexttoken2 = "";
         AssignAttri("", false, "A474sesexttoken2", A474sesexttoken2);
         A458sesauttypename = "";
         AssignAttri("", false, "A458sesauttypename", A458sesauttypename);
         A475sesoauthtokenmaxrenew = 0;
         AssignAttri("", false, "A475sesoauthtokenmaxrenew", StringUtil.LTrimStr( (decimal)(A475sesoauthtokenmaxrenew), 4, 0));
         A476sesoauthtokenexpires = 0;
         AssignAttri("", false, "A476sesoauthtokenexpires", StringUtil.LTrimStr( (decimal)(A476sesoauthtokenexpires), 9, 0));
         A477sesoauthscope = "";
         AssignAttri("", false, "A477sesoauthscope", A477sesoauthscope);
         A478sesexttoken3 = "";
         AssignAttri("", false, "A478sesexttoken3", A478sesexttoken3);
         A479sesexttokenexpires = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A479sesexttokenexpires", context.localUtil.TToC( A479sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A480sesexttokenrefresh = "";
         AssignAttri("", false, "A480sesexttokenrefresh", A480sesexttokenrefresh);
         A481sesjson = "";
         AssignAttri("", false, "A481sesjson", A481sesjson);
         A482sesidtoken = "";
         AssignAttri("", false, "A482sesidtoken", A482sesidtoken);
         A459sesotp = "";
         AssignAttri("", false, "A459sesotp", A459sesotp);
         A483sesotpexpire = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A483sesotpexpire", context.localUtil.TToC( A483sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A484sesendedbyotherlogin = false;
         AssignAttri("", false, "A484sesendedbyotherlogin", A484sesendedbyotherlogin);
         Z457sesdate = (DateTime)(DateTime.MinValue);
         Z450sessts = "";
         Z451sestype = 0;
         Z461sesurl = "";
         Z462sesipadd = "";
         Z454opesysid = 0;
         Z463seslastacc = (DateTime)(DateTime.MinValue);
         Z464sestimeout = 0;
         Z465seslogatt = 0;
         Z466seslogdate = (DateTime)(DateTime.MinValue);
         Z468sesenddate = (DateTime)(DateTime.MinValue);
         Z469sesreload = false;
         Z460brwid = 0;
         Z470seslasturl = "";
         Z471seslogin = "";
         Z455sesexttoken = "";
         Z456userguid = "";
         Z472sesapptokenexp = (DateTime)(DateTime.MinValue);
         Z452sesrefreshtoken = "";
         Z453sesappid = 0;
         Z473sesdeviceid = "";
         Z474sesexttoken2 = "";
         Z458sesauttypename = "";
         Z475sesoauthtokenmaxrenew = 0;
         Z476sesoauthtokenexpires = 0;
         Z477sesoauthscope = "";
         Z479sesexttokenexpires = (DateTime)(DateTime.MinValue);
         Z480sesexttokenrefresh = "";
         Z482sesidtoken = "";
         Z459sesotp = "";
         Z483sesotpexpire = (DateTime)(DateTime.MinValue);
         Z484sesendedbyotherlogin = false;
      }

      protected void InitAll1D84( )
      {
         A449repid = 0;
         AssignAttri("", false, "A449repid", StringUtil.LTrimStr( (decimal)(A449repid), 9, 0));
         A448sestoken = "";
         AssignAttri("", false, "A448sestoken", A448sestoken);
         InitializeNonKey1D84( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201752323", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("trn_gamsession.js", "?20256201752323", false, true);
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
         edtrepid_Internalname = "REPID";
         edtsestoken_Internalname = "SESTOKEN";
         edtsesdate_Internalname = "SESDATE";
         edtsessts_Internalname = "SESSTS";
         edtsestype_Internalname = "SESTYPE";
         edtsesurl_Internalname = "SESURL";
         edtsesipadd_Internalname = "SESIPADD";
         edtopesysid_Internalname = "OPESYSID";
         edtseslastacc_Internalname = "SESLASTACC";
         edtsestimeout_Internalname = "SESTIMEOUT";
         edtseslogatt_Internalname = "SESLOGATT";
         edtseslogdate_Internalname = "SESLOGDATE";
         edtsesshareddata_Internalname = "SESSHAREDDATA";
         edtsesenddate_Internalname = "SESENDDATE";
         chksesreload_Internalname = "SESRELOAD";
         edtbrwid_Internalname = "BRWID";
         edtseslasturl_Internalname = "SESLASTURL";
         edtseslogin_Internalname = "SESLOGIN";
         edtsesexttoken_Internalname = "SESEXTTOKEN";
         edtuserguid_Internalname = "USERGUID";
         edtsesapptokenexp_Internalname = "SESAPPTOKENEXP";
         edtsesrefreshtoken_Internalname = "SESREFRESHTOKEN";
         edtsesappid_Internalname = "SESAPPID";
         edtsesdeviceid_Internalname = "SESDEVICEID";
         edtsesexttoken2_Internalname = "SESEXTTOKEN2";
         edtsesauttypename_Internalname = "SESAUTTYPENAME";
         edtsesoauthtokenmaxrenew_Internalname = "SESOAUTHTOKENMAXRENEW";
         edtsesoauthtokenexpires_Internalname = "SESOAUTHTOKENEXPIRES";
         edtsesoauthscope_Internalname = "SESOAUTHSCOPE";
         edtsesexttoken3_Internalname = "SESEXTTOKEN3";
         edtsesexttokenexpires_Internalname = "SESEXTTOKENEXPIRES";
         edtsesexttokenrefresh_Internalname = "SESEXTTOKENREFRESH";
         edtsesjson_Internalname = "SESJSON";
         edtsesidtoken_Internalname = "SESIDTOKEN";
         edtsesotp_Internalname = "SESOTP";
         edtsesotpexpire_Internalname = "SESOTPEXPIRE";
         chksesendedbyotherlogin_Internalname = "SESENDEDBYOTHERLOGIN";
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
         Form.Caption = context.GetMessage( "Trn_Gam Session", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chksesendedbyotherlogin.Enabled = 1;
         edtsesotpexpire_Jsonclick = "";
         edtsesotpexpire_Enabled = 1;
         edtsesotp_Enabled = 1;
         edtsesidtoken_Enabled = 1;
         edtsesjson_Enabled = 1;
         edtsesexttokenrefresh_Enabled = 1;
         edtsesexttokenexpires_Jsonclick = "";
         edtsesexttokenexpires_Enabled = 1;
         edtsesexttoken3_Enabled = 1;
         edtsesoauthscope_Enabled = 1;
         edtsesoauthtokenexpires_Jsonclick = "";
         edtsesoauthtokenexpires_Enabled = 1;
         edtsesoauthtokenmaxrenew_Jsonclick = "";
         edtsesoauthtokenmaxrenew_Enabled = 1;
         edtsesauttypename_Jsonclick = "";
         edtsesauttypename_Enabled = 1;
         edtsesexttoken2_Enabled = 1;
         edtsesdeviceid_Jsonclick = "";
         edtsesdeviceid_Enabled = 1;
         edtsesappid_Jsonclick = "";
         edtsesappid_Enabled = 1;
         edtsesrefreshtoken_Jsonclick = "";
         edtsesrefreshtoken_Enabled = 1;
         edtsesapptokenexp_Jsonclick = "";
         edtsesapptokenexp_Enabled = 1;
         edtuserguid_Jsonclick = "";
         edtuserguid_Enabled = 1;
         edtsesexttoken_Jsonclick = "";
         edtsesexttoken_Enabled = 1;
         edtseslogin_Enabled = 1;
         edtseslasturl_Enabled = 1;
         edtbrwid_Jsonclick = "";
         edtbrwid_Enabled = 1;
         chksesreload.Enabled = 1;
         edtsesenddate_Jsonclick = "";
         edtsesenddate_Enabled = 1;
         edtsesshareddata_Enabled = 1;
         edtseslogdate_Jsonclick = "";
         edtseslogdate_Enabled = 1;
         edtseslogatt_Jsonclick = "";
         edtseslogatt_Enabled = 1;
         edtsestimeout_Jsonclick = "";
         edtsestimeout_Enabled = 1;
         edtseslastacc_Jsonclick = "";
         edtseslastacc_Enabled = 1;
         edtopesysid_Jsonclick = "";
         edtopesysid_Enabled = 1;
         edtsesipadd_Jsonclick = "";
         edtsesipadd_Enabled = 1;
         edtsesurl_Enabled = 1;
         edtsestype_Jsonclick = "";
         edtsestype_Enabled = 1;
         edtsessts_Jsonclick = "";
         edtsessts_Enabled = 1;
         edtsesdate_Jsonclick = "";
         edtsesdate_Enabled = 1;
         edtsestoken_Jsonclick = "";
         edtsestoken_Enabled = 1;
         edtrepid_Jsonclick = "";
         edtrepid_Enabled = 1;
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
         chksesreload.Name = "SESRELOAD";
         chksesreload.WebTags = "";
         chksesreload.Caption = context.GetMessage( "sesreload", "");
         AssignProp("", false, chksesreload_Internalname, "TitleCaption", chksesreload.Caption, true);
         chksesreload.CheckedValue = "false";
         A469sesreload = StringUtil.StrToBool( StringUtil.BoolToStr( A469sesreload));
         AssignAttri("", false, "A469sesreload", A469sesreload);
         chksesendedbyotherlogin.Name = "SESENDEDBYOTHERLOGIN";
         chksesendedbyotherlogin.WebTags = "";
         chksesendedbyotherlogin.Caption = context.GetMessage( "sesendedbyotherlogin", "");
         AssignProp("", false, chksesendedbyotherlogin_Internalname, "TitleCaption", chksesendedbyotherlogin.Caption, true);
         chksesendedbyotherlogin.CheckedValue = "false";
         A484sesendedbyotherlogin = StringUtil.StrToBool( StringUtil.BoolToStr( A484sesendedbyotherlogin));
         AssignAttri("", false, "A484sesendedbyotherlogin", A484sesendedbyotherlogin);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtsesdate_Internalname;
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

      public void Valid_Sestoken( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A469sesreload = StringUtil.StrToBool( StringUtil.BoolToStr( A469sesreload));
         A484sesendedbyotherlogin = StringUtil.StrToBool( StringUtil.BoolToStr( A484sesendedbyotherlogin));
         /*  Sending validation outputs */
         AssignAttri("", false, "A457sesdate", context.localUtil.TToC( A457sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A450sessts", StringUtil.RTrim( A450sessts));
         AssignAttri("", false, "A451sestype", StringUtil.LTrim( StringUtil.NToC( (decimal)(A451sestype), 4, 0, ".", "")));
         AssignAttri("", false, "A461sesurl", A461sesurl);
         AssignAttri("", false, "A462sesipadd", StringUtil.RTrim( A462sesipadd));
         AssignAttri("", false, "A454opesysid", StringUtil.LTrim( StringUtil.NToC( (decimal)(A454opesysid), 4, 0, ".", "")));
         AssignAttri("", false, "A463seslastacc", context.localUtil.TToC( A463seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A464sestimeout", StringUtil.LTrim( StringUtil.NToC( (decimal)(A464sestimeout), 4, 0, ".", "")));
         AssignAttri("", false, "A465seslogatt", StringUtil.LTrim( StringUtil.NToC( (decimal)(A465seslogatt), 9, 0, ".", "")));
         AssignAttri("", false, "A466seslogdate", context.localUtil.TToC( A466seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A467sesshareddata", A467sesshareddata);
         AssignAttri("", false, "A468sesenddate", context.localUtil.TToC( A468sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A469sesreload", A469sesreload);
         AssignAttri("", false, "A460brwid", StringUtil.LTrim( StringUtil.NToC( (decimal)(A460brwid), 4, 0, ".", "")));
         AssignAttri("", false, "A470seslasturl", A470seslasturl);
         AssignAttri("", false, "A471seslogin", A471seslogin);
         AssignAttri("", false, "A455sesexttoken", StringUtil.RTrim( A455sesexttoken));
         AssignAttri("", false, "A456userguid", StringUtil.RTrim( A456userguid));
         AssignAttri("", false, "A472sesapptokenexp", context.localUtil.TToC( A472sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A452sesrefreshtoken", StringUtil.RTrim( A452sesrefreshtoken));
         AssignAttri("", false, "A453sesappid", StringUtil.LTrim( StringUtil.NToC( (decimal)(A453sesappid), 18, 0, ".", "")));
         AssignAttri("", false, "A473sesdeviceid", StringUtil.RTrim( A473sesdeviceid));
         AssignAttri("", false, "A474sesexttoken2", A474sesexttoken2);
         AssignAttri("", false, "A458sesauttypename", StringUtil.RTrim( A458sesauttypename));
         AssignAttri("", false, "A475sesoauthtokenmaxrenew", StringUtil.LTrim( StringUtil.NToC( (decimal)(A475sesoauthtokenmaxrenew), 4, 0, ".", "")));
         AssignAttri("", false, "A476sesoauthtokenexpires", StringUtil.LTrim( StringUtil.NToC( (decimal)(A476sesoauthtokenexpires), 9, 0, ".", "")));
         AssignAttri("", false, "A477sesoauthscope", A477sesoauthscope);
         AssignAttri("", false, "A478sesexttoken3", A478sesexttoken3);
         AssignAttri("", false, "A479sesexttokenexpires", context.localUtil.TToC( A479sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A480sesexttokenrefresh", A480sesexttokenrefresh);
         AssignAttri("", false, "A481sesjson", A481sesjson);
         AssignAttri("", false, "A482sesidtoken", A482sesidtoken);
         AssignAttri("", false, "A459sesotp", A459sesotp);
         AssignAttri("", false, "A483sesotpexpire", context.localUtil.TToC( A483sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A484sesendedbyotherlogin", A484sesendedbyotherlogin);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z449repid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z449repid), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z448sestoken", StringUtil.RTrim( Z448sestoken));
         GxWebStd.gx_hidden_field( context, "Z457sesdate", context.localUtil.TToC( Z457sesdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z450sessts", StringUtil.RTrim( Z450sessts));
         GxWebStd.gx_hidden_field( context, "Z451sestype", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z451sestype), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z461sesurl", Z461sesurl);
         GxWebStd.gx_hidden_field( context, "Z462sesipadd", StringUtil.RTrim( Z462sesipadd));
         GxWebStd.gx_hidden_field( context, "Z454opesysid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z454opesysid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z463seslastacc", context.localUtil.TToC( Z463seslastacc, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z464sestimeout", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z464sestimeout), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z465seslogatt", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z465seslogatt), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z466seslogdate", context.localUtil.TToC( Z466seslogdate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z467sesshareddata", Z467sesshareddata);
         GxWebStd.gx_hidden_field( context, "Z468sesenddate", context.localUtil.TToC( Z468sesenddate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z469sesreload", StringUtil.BoolToStr( Z469sesreload));
         GxWebStd.gx_hidden_field( context, "Z460brwid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z460brwid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z470seslasturl", Z470seslasturl);
         GxWebStd.gx_hidden_field( context, "Z471seslogin", Z471seslogin);
         GxWebStd.gx_hidden_field( context, "Z455sesexttoken", StringUtil.RTrim( Z455sesexttoken));
         GxWebStd.gx_hidden_field( context, "Z456userguid", StringUtil.RTrim( Z456userguid));
         GxWebStd.gx_hidden_field( context, "Z472sesapptokenexp", context.localUtil.TToC( Z472sesapptokenexp, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z452sesrefreshtoken", StringUtil.RTrim( Z452sesrefreshtoken));
         GxWebStd.gx_hidden_field( context, "Z453sesappid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z453sesappid), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z473sesdeviceid", StringUtil.RTrim( Z473sesdeviceid));
         GxWebStd.gx_hidden_field( context, "Z474sesexttoken2", Z474sesexttoken2);
         GxWebStd.gx_hidden_field( context, "Z458sesauttypename", StringUtil.RTrim( Z458sesauttypename));
         GxWebStd.gx_hidden_field( context, "Z475sesoauthtokenmaxrenew", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z475sesoauthtokenmaxrenew), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z476sesoauthtokenexpires", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z476sesoauthtokenexpires), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z477sesoauthscope", Z477sesoauthscope);
         GxWebStd.gx_hidden_field( context, "Z478sesexttoken3", Z478sesexttoken3);
         GxWebStd.gx_hidden_field( context, "Z479sesexttokenexpires", context.localUtil.TToC( Z479sesexttokenexpires, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z480sesexttokenrefresh", Z480sesexttokenrefresh);
         GxWebStd.gx_hidden_field( context, "Z481sesjson", Z481sesjson);
         GxWebStd.gx_hidden_field( context, "Z482sesidtoken", Z482sesidtoken);
         GxWebStd.gx_hidden_field( context, "Z459sesotp", Z459sesotp);
         GxWebStd.gx_hidden_field( context, "Z483sesotpexpire", context.localUtil.TToC( Z483sesotpexpire, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z484sesendedbyotherlogin", StringUtil.BoolToStr( Z484sesendedbyotherlogin));
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A469sesreload","fld":"SESRELOAD"},{"av":"A484sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A469sesreload","fld":"SESRELOAD"},{"av":"A484sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A469sesreload","fld":"SESRELOAD"},{"av":"A484sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A469sesreload","fld":"SESRELOAD"},{"av":"A484sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]}""");
         setEventMetadata("VALID_REPID","""{"handler":"Valid_Repid","iparms":[{"av":"A469sesreload","fld":"SESRELOAD"},{"av":"A484sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]""");
         setEventMetadata("VALID_REPID",""","oparms":[{"av":"A469sesreload","fld":"SESRELOAD"},{"av":"A484sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]}""");
         setEventMetadata("VALID_SESTOKEN","""{"handler":"Valid_Sestoken","iparms":[{"av":"A449repid","fld":"REPID","pic":"ZZZZZZZZ9"},{"av":"A448sestoken","fld":"SESTOKEN"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A469sesreload","fld":"SESRELOAD"},{"av":"A484sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]""");
         setEventMetadata("VALID_SESTOKEN",""","oparms":[{"av":"A457sesdate","fld":"SESDATE","pic":"99/99/9999 99:99:99"},{"av":"A450sessts","fld":"SESSTS"},{"av":"A451sestype","fld":"SESTYPE","pic":"ZZZ9"},{"av":"A461sesurl","fld":"SESURL"},{"av":"A462sesipadd","fld":"SESIPADD"},{"av":"A454opesysid","fld":"OPESYSID","pic":"ZZZ9"},{"av":"A463seslastacc","fld":"SESLASTACC","pic":"99/99/9999 99:99:99"},{"av":"A464sestimeout","fld":"SESTIMEOUT","pic":"ZZZ9"},{"av":"A465seslogatt","fld":"SESLOGATT","pic":"ZZZZZZZZ9"},{"av":"A466seslogdate","fld":"SESLOGDATE","pic":"99/99/9999 99:99:99"},{"av":"A467sesshareddata","fld":"SESSHAREDDATA"},{"av":"A468sesenddate","fld":"SESENDDATE","pic":"99/99/9999 99:99:99"},{"av":"A460brwid","fld":"BRWID","pic":"ZZZ9"},{"av":"A470seslasturl","fld":"SESLASTURL"},{"av":"A471seslogin","fld":"SESLOGIN"},{"av":"A455sesexttoken","fld":"SESEXTTOKEN"},{"av":"A456userguid","fld":"USERGUID"},{"av":"A472sesapptokenexp","fld":"SESAPPTOKENEXP","pic":"99/99/9999 99:99:99"},{"av":"A452sesrefreshtoken","fld":"SESREFRESHTOKEN"},{"av":"A453sesappid","fld":"SESAPPID","pic":"ZZZZZZZZZZZZZZZZZ9"},{"av":"A473sesdeviceid","fld":"SESDEVICEID"},{"av":"A474sesexttoken2","fld":"SESEXTTOKEN2"},{"av":"A458sesauttypename","fld":"SESAUTTYPENAME"},{"av":"A475sesoauthtokenmaxrenew","fld":"SESOAUTHTOKENMAXRENEW","pic":"ZZZ9"},{"av":"A476sesoauthtokenexpires","fld":"SESOAUTHTOKENEXPIRES","pic":"ZZZZZZZZ9"},{"av":"A477sesoauthscope","fld":"SESOAUTHSCOPE"},{"av":"A478sesexttoken3","fld":"SESEXTTOKEN3"},{"av":"A479sesexttokenexpires","fld":"SESEXTTOKENEXPIRES","pic":"99/99/9999 99:99:99"},{"av":"A480sesexttokenrefresh","fld":"SESEXTTOKENREFRESH"},{"av":"A481sesjson","fld":"SESJSON"},{"av":"A482sesidtoken","fld":"SESIDTOKEN"},{"av":"A459sesotp","fld":"SESOTP"},{"av":"A483sesotpexpire","fld":"SESOTPEXPIRE","pic":"99/99/9999 99:99:99"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z449repid"},{"av":"Z448sestoken"},{"av":"Z457sesdate"},{"av":"Z450sessts"},{"av":"Z451sestype"},{"av":"Z461sesurl"},{"av":"Z462sesipadd"},{"av":"Z454opesysid"},{"av":"Z463seslastacc"},{"av":"Z464sestimeout"},{"av":"Z465seslogatt"},{"av":"Z466seslogdate"},{"av":"Z467sesshareddata"},{"av":"Z468sesenddate"},{"av":"Z469sesreload"},{"av":"Z460brwid"},{"av":"Z470seslasturl"},{"av":"Z471seslogin"},{"av":"Z455sesexttoken"},{"av":"Z456userguid"},{"av":"Z472sesapptokenexp"},{"av":"Z452sesrefreshtoken"},{"av":"Z453sesappid"},{"av":"Z473sesdeviceid"},{"av":"Z474sesexttoken2"},{"av":"Z458sesauttypename"},{"av":"Z475sesoauthtokenmaxrenew"},{"av":"Z476sesoauthtokenexpires"},{"av":"Z477sesoauthscope"},{"av":"Z478sesexttoken3"},{"av":"Z479sesexttokenexpires"},{"av":"Z480sesexttokenrefresh"},{"av":"Z481sesjson"},{"av":"Z482sesidtoken"},{"av":"Z459sesotp"},{"av":"Z483sesotpexpire"},{"av":"Z484sesendedbyotherlogin"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A469sesreload","fld":"SESRELOAD"},{"av":"A484sesendedbyotherlogin","fld":"SESENDEDBYOTHERLOGIN"}]}""");
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
         pr_gam.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z448sestoken = "";
         Z457sesdate = (DateTime)(DateTime.MinValue);
         Z450sessts = "";
         Z461sesurl = "";
         Z462sesipadd = "";
         Z463seslastacc = (DateTime)(DateTime.MinValue);
         Z466seslogdate = (DateTime)(DateTime.MinValue);
         Z468sesenddate = (DateTime)(DateTime.MinValue);
         Z470seslasturl = "";
         Z471seslogin = "";
         Z455sesexttoken = "";
         Z456userguid = "";
         Z472sesapptokenexp = (DateTime)(DateTime.MinValue);
         Z452sesrefreshtoken = "";
         Z473sesdeviceid = "";
         Z474sesexttoken2 = "";
         Z458sesauttypename = "";
         Z477sesoauthscope = "";
         Z479sesexttokenexpires = (DateTime)(DateTime.MinValue);
         Z480sesexttokenrefresh = "";
         Z482sesidtoken = "";
         Z459sesotp = "";
         Z483sesotpexpire = (DateTime)(DateTime.MinValue);
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
         A448sestoken = "";
         A457sesdate = (DateTime)(DateTime.MinValue);
         A450sessts = "";
         A461sesurl = "";
         A462sesipadd = "";
         A463seslastacc = (DateTime)(DateTime.MinValue);
         A466seslogdate = (DateTime)(DateTime.MinValue);
         A467sesshareddata = "";
         A468sesenddate = (DateTime)(DateTime.MinValue);
         A470seslasturl = "";
         A471seslogin = "";
         A455sesexttoken = "";
         A456userguid = "";
         A472sesapptokenexp = (DateTime)(DateTime.MinValue);
         A452sesrefreshtoken = "";
         A473sesdeviceid = "";
         A474sesexttoken2 = "";
         A458sesauttypename = "";
         A477sesoauthscope = "";
         A478sesexttoken3 = "";
         A479sesexttokenexpires = (DateTime)(DateTime.MinValue);
         A480sesexttokenrefresh = "";
         A481sesjson = "";
         A482sesidtoken = "";
         A459sesotp = "";
         A483sesotpexpire = (DateTime)(DateTime.MinValue);
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
         Z467sesshareddata = "";
         Z478sesexttoken3 = "";
         Z481sesjson = "";
         T001D4_A449repid = new int[1] ;
         T001D4_A448sestoken = new string[] {""} ;
         T001D4_A457sesdate = new DateTime[] {DateTime.MinValue} ;
         T001D4_A450sessts = new string[] {""} ;
         T001D4_A451sestype = new short[1] ;
         T001D4_A461sesurl = new string[] {""} ;
         T001D4_A462sesipadd = new string[] {""} ;
         T001D4_A454opesysid = new short[1] ;
         T001D4_A463seslastacc = new DateTime[] {DateTime.MinValue} ;
         T001D4_A464sestimeout = new short[1] ;
         T001D4_A465seslogatt = new int[1] ;
         T001D4_A466seslogdate = new DateTime[] {DateTime.MinValue} ;
         T001D4_A467sesshareddata = new string[] {""} ;
         T001D4_A468sesenddate = new DateTime[] {DateTime.MinValue} ;
         T001D4_A469sesreload = new bool[] {false} ;
         T001D4_A460brwid = new short[1] ;
         T001D4_A470seslasturl = new string[] {""} ;
         T001D4_A471seslogin = new string[] {""} ;
         T001D4_A455sesexttoken = new string[] {""} ;
         T001D4_A456userguid = new string[] {""} ;
         T001D4_A472sesapptokenexp = new DateTime[] {DateTime.MinValue} ;
         T001D4_A452sesrefreshtoken = new string[] {""} ;
         T001D4_A453sesappid = new long[1] ;
         T001D4_A473sesdeviceid = new string[] {""} ;
         T001D4_A474sesexttoken2 = new string[] {""} ;
         T001D4_A458sesauttypename = new string[] {""} ;
         T001D4_A475sesoauthtokenmaxrenew = new short[1] ;
         T001D4_A476sesoauthtokenexpires = new int[1] ;
         T001D4_A477sesoauthscope = new string[] {""} ;
         T001D4_A478sesexttoken3 = new string[] {""} ;
         T001D4_A479sesexttokenexpires = new DateTime[] {DateTime.MinValue} ;
         T001D4_A480sesexttokenrefresh = new string[] {""} ;
         T001D4_A481sesjson = new string[] {""} ;
         T001D4_A482sesidtoken = new string[] {""} ;
         T001D4_A459sesotp = new string[] {""} ;
         T001D4_A483sesotpexpire = new DateTime[] {DateTime.MinValue} ;
         T001D4_A484sesendedbyotherlogin = new bool[] {false} ;
         T001D5_A449repid = new int[1] ;
         T001D5_A448sestoken = new string[] {""} ;
         T001D3_A449repid = new int[1] ;
         T001D3_A448sestoken = new string[] {""} ;
         T001D3_A457sesdate = new DateTime[] {DateTime.MinValue} ;
         T001D3_A450sessts = new string[] {""} ;
         T001D3_A451sestype = new short[1] ;
         T001D3_A461sesurl = new string[] {""} ;
         T001D3_A462sesipadd = new string[] {""} ;
         T001D3_A454opesysid = new short[1] ;
         T001D3_A463seslastacc = new DateTime[] {DateTime.MinValue} ;
         T001D3_A464sestimeout = new short[1] ;
         T001D3_A465seslogatt = new int[1] ;
         T001D3_A466seslogdate = new DateTime[] {DateTime.MinValue} ;
         T001D3_A467sesshareddata = new string[] {""} ;
         T001D3_A468sesenddate = new DateTime[] {DateTime.MinValue} ;
         T001D3_A469sesreload = new bool[] {false} ;
         T001D3_A460brwid = new short[1] ;
         T001D3_A470seslasturl = new string[] {""} ;
         T001D3_A471seslogin = new string[] {""} ;
         T001D3_A455sesexttoken = new string[] {""} ;
         T001D3_A456userguid = new string[] {""} ;
         T001D3_A472sesapptokenexp = new DateTime[] {DateTime.MinValue} ;
         T001D3_A452sesrefreshtoken = new string[] {""} ;
         T001D3_A453sesappid = new long[1] ;
         T001D3_A473sesdeviceid = new string[] {""} ;
         T001D3_A474sesexttoken2 = new string[] {""} ;
         T001D3_A458sesauttypename = new string[] {""} ;
         T001D3_A475sesoauthtokenmaxrenew = new short[1] ;
         T001D3_A476sesoauthtokenexpires = new int[1] ;
         T001D3_A477sesoauthscope = new string[] {""} ;
         T001D3_A478sesexttoken3 = new string[] {""} ;
         T001D3_A479sesexttokenexpires = new DateTime[] {DateTime.MinValue} ;
         T001D3_A480sesexttokenrefresh = new string[] {""} ;
         T001D3_A481sesjson = new string[] {""} ;
         T001D3_A482sesidtoken = new string[] {""} ;
         T001D3_A459sesotp = new string[] {""} ;
         T001D3_A483sesotpexpire = new DateTime[] {DateTime.MinValue} ;
         T001D3_A484sesendedbyotherlogin = new bool[] {false} ;
         sMode84 = "";
         T001D6_A449repid = new int[1] ;
         T001D6_A448sestoken = new string[] {""} ;
         T001D7_A449repid = new int[1] ;
         T001D7_A448sestoken = new string[] {""} ;
         T001D2_A449repid = new int[1] ;
         T001D2_A448sestoken = new string[] {""} ;
         T001D2_A457sesdate = new DateTime[] {DateTime.MinValue} ;
         T001D2_A450sessts = new string[] {""} ;
         T001D2_A451sestype = new short[1] ;
         T001D2_A461sesurl = new string[] {""} ;
         T001D2_A462sesipadd = new string[] {""} ;
         T001D2_A454opesysid = new short[1] ;
         T001D2_A463seslastacc = new DateTime[] {DateTime.MinValue} ;
         T001D2_A464sestimeout = new short[1] ;
         T001D2_A465seslogatt = new int[1] ;
         T001D2_A466seslogdate = new DateTime[] {DateTime.MinValue} ;
         T001D2_A467sesshareddata = new string[] {""} ;
         T001D2_A468sesenddate = new DateTime[] {DateTime.MinValue} ;
         T001D2_A469sesreload = new bool[] {false} ;
         T001D2_A460brwid = new short[1] ;
         T001D2_A470seslasturl = new string[] {""} ;
         T001D2_A471seslogin = new string[] {""} ;
         T001D2_A455sesexttoken = new string[] {""} ;
         T001D2_A456userguid = new string[] {""} ;
         T001D2_A472sesapptokenexp = new DateTime[] {DateTime.MinValue} ;
         T001D2_A452sesrefreshtoken = new string[] {""} ;
         T001D2_A453sesappid = new long[1] ;
         T001D2_A473sesdeviceid = new string[] {""} ;
         T001D2_A474sesexttoken2 = new string[] {""} ;
         T001D2_A458sesauttypename = new string[] {""} ;
         T001D2_A475sesoauthtokenmaxrenew = new short[1] ;
         T001D2_A476sesoauthtokenexpires = new int[1] ;
         T001D2_A477sesoauthscope = new string[] {""} ;
         T001D2_A478sesexttoken3 = new string[] {""} ;
         T001D2_A479sesexttokenexpires = new DateTime[] {DateTime.MinValue} ;
         T001D2_A480sesexttokenrefresh = new string[] {""} ;
         T001D2_A481sesjson = new string[] {""} ;
         T001D2_A482sesidtoken = new string[] {""} ;
         T001D2_A459sesotp = new string[] {""} ;
         T001D2_A483sesotpexpire = new DateTime[] {DateTime.MinValue} ;
         T001D2_A484sesendedbyotherlogin = new bool[] {false} ;
         T001D11_A449repid = new int[1] ;
         T001D11_A448sestoken = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ448sestoken = "";
         ZZ457sesdate = (DateTime)(DateTime.MinValue);
         ZZ450sessts = "";
         ZZ461sesurl = "";
         ZZ462sesipadd = "";
         ZZ463seslastacc = (DateTime)(DateTime.MinValue);
         ZZ466seslogdate = (DateTime)(DateTime.MinValue);
         ZZ467sesshareddata = "";
         ZZ468sesenddate = (DateTime)(DateTime.MinValue);
         ZZ470seslasturl = "";
         ZZ471seslogin = "";
         ZZ455sesexttoken = "";
         ZZ456userguid = "";
         ZZ472sesapptokenexp = (DateTime)(DateTime.MinValue);
         ZZ452sesrefreshtoken = "";
         ZZ473sesdeviceid = "";
         ZZ474sesexttoken2 = "";
         ZZ458sesauttypename = "";
         ZZ477sesoauthscope = "";
         ZZ478sesexttoken3 = "";
         ZZ479sesexttokenexpires = (DateTime)(DateTime.MinValue);
         ZZ480sesexttokenrefresh = "";
         ZZ481sesjson = "";
         ZZ482sesidtoken = "";
         ZZ459sesotp = "";
         ZZ483sesotpexpire = (DateTime)(DateTime.MinValue);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_gamsession__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_gamsession__gam(),
            new Object[][] {
                new Object[] {
               T001D2_A449repid, T001D2_A448sestoken, T001D2_A457sesdate, T001D2_A450sessts, T001D2_A451sestype, T001D2_A461sesurl, T001D2_A462sesipadd, T001D2_A454opesysid, T001D2_A463seslastacc, T001D2_A464sestimeout,
               T001D2_A465seslogatt, T001D2_A466seslogdate, T001D2_A467sesshareddata, T001D2_A468sesenddate, T001D2_A469sesreload, T001D2_A460brwid, T001D2_A470seslasturl, T001D2_A471seslogin, T001D2_A455sesexttoken, T001D2_A456userguid,
               T001D2_A472sesapptokenexp, T001D2_A452sesrefreshtoken, T001D2_A453sesappid, T001D2_A473sesdeviceid, T001D2_A474sesexttoken2, T001D2_A458sesauttypename, T001D2_A475sesoauthtokenmaxrenew, T001D2_A476sesoauthtokenexpires, T001D2_A477sesoauthscope, T001D2_A478sesexttoken3,
               T001D2_A479sesexttokenexpires, T001D2_A480sesexttokenrefresh, T001D2_A481sesjson, T001D2_A482sesidtoken, T001D2_A459sesotp, T001D2_A483sesotpexpire, T001D2_A484sesendedbyotherlogin
               }
               , new Object[] {
               T001D3_A449repid, T001D3_A448sestoken, T001D3_A457sesdate, T001D3_A450sessts, T001D3_A451sestype, T001D3_A461sesurl, T001D3_A462sesipadd, T001D3_A454opesysid, T001D3_A463seslastacc, T001D3_A464sestimeout,
               T001D3_A465seslogatt, T001D3_A466seslogdate, T001D3_A467sesshareddata, T001D3_A468sesenddate, T001D3_A469sesreload, T001D3_A460brwid, T001D3_A470seslasturl, T001D3_A471seslogin, T001D3_A455sesexttoken, T001D3_A456userguid,
               T001D3_A472sesapptokenexp, T001D3_A452sesrefreshtoken, T001D3_A453sesappid, T001D3_A473sesdeviceid, T001D3_A474sesexttoken2, T001D3_A458sesauttypename, T001D3_A475sesoauthtokenmaxrenew, T001D3_A476sesoauthtokenexpires, T001D3_A477sesoauthscope, T001D3_A478sesexttoken3,
               T001D3_A479sesexttokenexpires, T001D3_A480sesexttokenrefresh, T001D3_A481sesjson, T001D3_A482sesidtoken, T001D3_A459sesotp, T001D3_A483sesotpexpire, T001D3_A484sesendedbyotherlogin
               }
               , new Object[] {
               T001D4_A449repid, T001D4_A448sestoken, T001D4_A457sesdate, T001D4_A450sessts, T001D4_A451sestype, T001D4_A461sesurl, T001D4_A462sesipadd, T001D4_A454opesysid, T001D4_A463seslastacc, T001D4_A464sestimeout,
               T001D4_A465seslogatt, T001D4_A466seslogdate, T001D4_A467sesshareddata, T001D4_A468sesenddate, T001D4_A469sesreload, T001D4_A460brwid, T001D4_A470seslasturl, T001D4_A471seslogin, T001D4_A455sesexttoken, T001D4_A456userguid,
               T001D4_A472sesapptokenexp, T001D4_A452sesrefreshtoken, T001D4_A453sesappid, T001D4_A473sesdeviceid, T001D4_A474sesexttoken2, T001D4_A458sesauttypename, T001D4_A475sesoauthtokenmaxrenew, T001D4_A476sesoauthtokenexpires, T001D4_A477sesoauthscope, T001D4_A478sesexttoken3,
               T001D4_A479sesexttokenexpires, T001D4_A480sesexttokenrefresh, T001D4_A481sesjson, T001D4_A482sesidtoken, T001D4_A459sesotp, T001D4_A483sesotpexpire, T001D4_A484sesendedbyotherlogin
               }
               , new Object[] {
               T001D5_A449repid, T001D5_A448sestoken
               }
               , new Object[] {
               T001D6_A449repid, T001D6_A448sestoken
               }
               , new Object[] {
               T001D7_A449repid, T001D7_A448sestoken
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001D11_A449repid, T001D11_A448sestoken
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_gamsession__default(),
            new Object[][] {
            }
         );
      }

      private short Z451sestype ;
      private short Z454opesysid ;
      private short Z464sestimeout ;
      private short Z460brwid ;
      private short Z475sesoauthtokenmaxrenew ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A451sestype ;
      private short A454opesysid ;
      private short A464sestimeout ;
      private short A460brwid ;
      private short A475sesoauthtokenmaxrenew ;
      private short RcdFound84 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ451sestype ;
      private short ZZ454opesysid ;
      private short ZZ464sestimeout ;
      private short ZZ460brwid ;
      private short ZZ475sesoauthtokenmaxrenew ;
      private int Z449repid ;
      private int Z465seslogatt ;
      private int Z476sesoauthtokenexpires ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A449repid ;
      private int edtrepid_Enabled ;
      private int edtsestoken_Enabled ;
      private int edtsesdate_Enabled ;
      private int edtsessts_Enabled ;
      private int edtsestype_Enabled ;
      private int edtsesurl_Enabled ;
      private int edtsesipadd_Enabled ;
      private int edtopesysid_Enabled ;
      private int edtseslastacc_Enabled ;
      private int edtsestimeout_Enabled ;
      private int A465seslogatt ;
      private int edtseslogatt_Enabled ;
      private int edtseslogdate_Enabled ;
      private int edtsesshareddata_Enabled ;
      private int edtsesenddate_Enabled ;
      private int edtbrwid_Enabled ;
      private int edtseslasturl_Enabled ;
      private int edtseslogin_Enabled ;
      private int edtsesexttoken_Enabled ;
      private int edtuserguid_Enabled ;
      private int edtsesapptokenexp_Enabled ;
      private int edtsesrefreshtoken_Enabled ;
      private int edtsesappid_Enabled ;
      private int edtsesdeviceid_Enabled ;
      private int edtsesexttoken2_Enabled ;
      private int edtsesauttypename_Enabled ;
      private int edtsesoauthtokenmaxrenew_Enabled ;
      private int A476sesoauthtokenexpires ;
      private int edtsesoauthtokenexpires_Enabled ;
      private int edtsesoauthscope_Enabled ;
      private int edtsesexttoken3_Enabled ;
      private int edtsesexttokenexpires_Enabled ;
      private int edtsesexttokenrefresh_Enabled ;
      private int edtsesjson_Enabled ;
      private int edtsesidtoken_Enabled ;
      private int edtsesotp_Enabled ;
      private int edtsesotpexpire_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ449repid ;
      private int ZZ465seslogatt ;
      private int ZZ476sesoauthtokenexpires ;
      private long Z453sesappid ;
      private long A453sesappid ;
      private long ZZ453sesappid ;
      private string sPrefix ;
      private string Z448sestoken ;
      private string Z450sessts ;
      private string Z462sesipadd ;
      private string Z455sesexttoken ;
      private string Z456userguid ;
      private string Z452sesrefreshtoken ;
      private string Z473sesdeviceid ;
      private string Z458sesauttypename ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtrepid_Internalname ;
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
      private string edtrepid_Jsonclick ;
      private string edtsestoken_Internalname ;
      private string A448sestoken ;
      private string edtsestoken_Jsonclick ;
      private string edtsesdate_Internalname ;
      private string edtsesdate_Jsonclick ;
      private string edtsessts_Internalname ;
      private string A450sessts ;
      private string edtsessts_Jsonclick ;
      private string edtsestype_Internalname ;
      private string edtsestype_Jsonclick ;
      private string edtsesurl_Internalname ;
      private string edtsesipadd_Internalname ;
      private string A462sesipadd ;
      private string edtsesipadd_Jsonclick ;
      private string edtopesysid_Internalname ;
      private string edtopesysid_Jsonclick ;
      private string edtseslastacc_Internalname ;
      private string edtseslastacc_Jsonclick ;
      private string edtsestimeout_Internalname ;
      private string edtsestimeout_Jsonclick ;
      private string edtseslogatt_Internalname ;
      private string edtseslogatt_Jsonclick ;
      private string edtseslogdate_Internalname ;
      private string edtseslogdate_Jsonclick ;
      private string edtsesshareddata_Internalname ;
      private string edtsesenddate_Internalname ;
      private string edtsesenddate_Jsonclick ;
      private string chksesreload_Internalname ;
      private string edtbrwid_Internalname ;
      private string edtbrwid_Jsonclick ;
      private string edtseslasturl_Internalname ;
      private string edtseslogin_Internalname ;
      private string edtsesexttoken_Internalname ;
      private string A455sesexttoken ;
      private string edtsesexttoken_Jsonclick ;
      private string edtuserguid_Internalname ;
      private string A456userguid ;
      private string edtuserguid_Jsonclick ;
      private string edtsesapptokenexp_Internalname ;
      private string edtsesapptokenexp_Jsonclick ;
      private string edtsesrefreshtoken_Internalname ;
      private string A452sesrefreshtoken ;
      private string edtsesrefreshtoken_Jsonclick ;
      private string edtsesappid_Internalname ;
      private string edtsesappid_Jsonclick ;
      private string edtsesdeviceid_Internalname ;
      private string A473sesdeviceid ;
      private string edtsesdeviceid_Jsonclick ;
      private string edtsesexttoken2_Internalname ;
      private string edtsesauttypename_Internalname ;
      private string A458sesauttypename ;
      private string edtsesauttypename_Jsonclick ;
      private string edtsesoauthtokenmaxrenew_Internalname ;
      private string edtsesoauthtokenmaxrenew_Jsonclick ;
      private string edtsesoauthtokenexpires_Internalname ;
      private string edtsesoauthtokenexpires_Jsonclick ;
      private string edtsesoauthscope_Internalname ;
      private string edtsesexttoken3_Internalname ;
      private string edtsesexttokenexpires_Internalname ;
      private string edtsesexttokenexpires_Jsonclick ;
      private string edtsesexttokenrefresh_Internalname ;
      private string edtsesjson_Internalname ;
      private string edtsesidtoken_Internalname ;
      private string edtsesotp_Internalname ;
      private string edtsesotpexpire_Internalname ;
      private string edtsesotpexpire_Jsonclick ;
      private string chksesendedbyotherlogin_Internalname ;
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
      private string sMode84 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ448sestoken ;
      private string ZZ450sessts ;
      private string ZZ462sesipadd ;
      private string ZZ455sesexttoken ;
      private string ZZ456userguid ;
      private string ZZ452sesrefreshtoken ;
      private string ZZ473sesdeviceid ;
      private string ZZ458sesauttypename ;
      private DateTime Z457sesdate ;
      private DateTime Z463seslastacc ;
      private DateTime Z466seslogdate ;
      private DateTime Z468sesenddate ;
      private DateTime Z472sesapptokenexp ;
      private DateTime Z479sesexttokenexpires ;
      private DateTime Z483sesotpexpire ;
      private DateTime A457sesdate ;
      private DateTime A463seslastacc ;
      private DateTime A466seslogdate ;
      private DateTime A468sesenddate ;
      private DateTime A472sesapptokenexp ;
      private DateTime A479sesexttokenexpires ;
      private DateTime A483sesotpexpire ;
      private DateTime ZZ457sesdate ;
      private DateTime ZZ463seslastacc ;
      private DateTime ZZ466seslogdate ;
      private DateTime ZZ468sesenddate ;
      private DateTime ZZ472sesapptokenexp ;
      private DateTime ZZ479sesexttokenexpires ;
      private DateTime ZZ483sesotpexpire ;
      private bool Z469sesreload ;
      private bool Z484sesendedbyotherlogin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A469sesreload ;
      private bool A484sesendedbyotherlogin ;
      private bool Gx_longc ;
      private bool ZZ469sesreload ;
      private bool ZZ484sesendedbyotherlogin ;
      private string A467sesshareddata ;
      private string A478sesexttoken3 ;
      private string A481sesjson ;
      private string Z467sesshareddata ;
      private string Z478sesexttoken3 ;
      private string Z481sesjson ;
      private string ZZ467sesshareddata ;
      private string ZZ478sesexttoken3 ;
      private string ZZ481sesjson ;
      private string Z461sesurl ;
      private string Z470seslasturl ;
      private string Z471seslogin ;
      private string Z474sesexttoken2 ;
      private string Z477sesoauthscope ;
      private string Z480sesexttokenrefresh ;
      private string Z482sesidtoken ;
      private string Z459sesotp ;
      private string A461sesurl ;
      private string A470seslasturl ;
      private string A471seslogin ;
      private string A474sesexttoken2 ;
      private string A477sesoauthscope ;
      private string A480sesexttokenrefresh ;
      private string A482sesidtoken ;
      private string A459sesotp ;
      private string ZZ461sesurl ;
      private string ZZ470seslasturl ;
      private string ZZ471seslogin ;
      private string ZZ474sesexttoken2 ;
      private string ZZ477sesoauthscope ;
      private string ZZ480sesexttokenrefresh ;
      private string ZZ482sesidtoken ;
      private string ZZ459sesotp ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chksesreload ;
      private GXCheckbox chksesendedbyotherlogin ;
      private IDataStoreProvider pr_gam ;
      private int[] T001D4_A449repid ;
      private string[] T001D4_A448sestoken ;
      private DateTime[] T001D4_A457sesdate ;
      private string[] T001D4_A450sessts ;
      private short[] T001D4_A451sestype ;
      private string[] T001D4_A461sesurl ;
      private string[] T001D4_A462sesipadd ;
      private short[] T001D4_A454opesysid ;
      private DateTime[] T001D4_A463seslastacc ;
      private short[] T001D4_A464sestimeout ;
      private int[] T001D4_A465seslogatt ;
      private DateTime[] T001D4_A466seslogdate ;
      private string[] T001D4_A467sesshareddata ;
      private DateTime[] T001D4_A468sesenddate ;
      private bool[] T001D4_A469sesreload ;
      private short[] T001D4_A460brwid ;
      private string[] T001D4_A470seslasturl ;
      private string[] T001D4_A471seslogin ;
      private string[] T001D4_A455sesexttoken ;
      private string[] T001D4_A456userguid ;
      private DateTime[] T001D4_A472sesapptokenexp ;
      private string[] T001D4_A452sesrefreshtoken ;
      private long[] T001D4_A453sesappid ;
      private string[] T001D4_A473sesdeviceid ;
      private string[] T001D4_A474sesexttoken2 ;
      private string[] T001D4_A458sesauttypename ;
      private short[] T001D4_A475sesoauthtokenmaxrenew ;
      private int[] T001D4_A476sesoauthtokenexpires ;
      private string[] T001D4_A477sesoauthscope ;
      private string[] T001D4_A478sesexttoken3 ;
      private DateTime[] T001D4_A479sesexttokenexpires ;
      private string[] T001D4_A480sesexttokenrefresh ;
      private string[] T001D4_A481sesjson ;
      private string[] T001D4_A482sesidtoken ;
      private string[] T001D4_A459sesotp ;
      private DateTime[] T001D4_A483sesotpexpire ;
      private bool[] T001D4_A484sesendedbyotherlogin ;
      private int[] T001D5_A449repid ;
      private string[] T001D5_A448sestoken ;
      private int[] T001D3_A449repid ;
      private string[] T001D3_A448sestoken ;
      private DateTime[] T001D3_A457sesdate ;
      private string[] T001D3_A450sessts ;
      private short[] T001D3_A451sestype ;
      private string[] T001D3_A461sesurl ;
      private string[] T001D3_A462sesipadd ;
      private short[] T001D3_A454opesysid ;
      private DateTime[] T001D3_A463seslastacc ;
      private short[] T001D3_A464sestimeout ;
      private int[] T001D3_A465seslogatt ;
      private DateTime[] T001D3_A466seslogdate ;
      private string[] T001D3_A467sesshareddata ;
      private DateTime[] T001D3_A468sesenddate ;
      private bool[] T001D3_A469sesreload ;
      private short[] T001D3_A460brwid ;
      private string[] T001D3_A470seslasturl ;
      private string[] T001D3_A471seslogin ;
      private string[] T001D3_A455sesexttoken ;
      private string[] T001D3_A456userguid ;
      private DateTime[] T001D3_A472sesapptokenexp ;
      private string[] T001D3_A452sesrefreshtoken ;
      private long[] T001D3_A453sesappid ;
      private string[] T001D3_A473sesdeviceid ;
      private string[] T001D3_A474sesexttoken2 ;
      private string[] T001D3_A458sesauttypename ;
      private short[] T001D3_A475sesoauthtokenmaxrenew ;
      private int[] T001D3_A476sesoauthtokenexpires ;
      private string[] T001D3_A477sesoauthscope ;
      private string[] T001D3_A478sesexttoken3 ;
      private DateTime[] T001D3_A479sesexttokenexpires ;
      private string[] T001D3_A480sesexttokenrefresh ;
      private string[] T001D3_A481sesjson ;
      private string[] T001D3_A482sesidtoken ;
      private string[] T001D3_A459sesotp ;
      private DateTime[] T001D3_A483sesotpexpire ;
      private bool[] T001D3_A484sesendedbyotherlogin ;
      private int[] T001D6_A449repid ;
      private string[] T001D6_A448sestoken ;
      private int[] T001D7_A449repid ;
      private string[] T001D7_A448sestoken ;
      private int[] T001D2_A449repid ;
      private string[] T001D2_A448sestoken ;
      private DateTime[] T001D2_A457sesdate ;
      private string[] T001D2_A450sessts ;
      private short[] T001D2_A451sestype ;
      private string[] T001D2_A461sesurl ;
      private string[] T001D2_A462sesipadd ;
      private short[] T001D2_A454opesysid ;
      private DateTime[] T001D2_A463seslastacc ;
      private short[] T001D2_A464sestimeout ;
      private int[] T001D2_A465seslogatt ;
      private DateTime[] T001D2_A466seslogdate ;
      private string[] T001D2_A467sesshareddata ;
      private DateTime[] T001D2_A468sesenddate ;
      private bool[] T001D2_A469sesreload ;
      private short[] T001D2_A460brwid ;
      private string[] T001D2_A470seslasturl ;
      private string[] T001D2_A471seslogin ;
      private string[] T001D2_A455sesexttoken ;
      private string[] T001D2_A456userguid ;
      private DateTime[] T001D2_A472sesapptokenexp ;
      private string[] T001D2_A452sesrefreshtoken ;
      private long[] T001D2_A453sesappid ;
      private string[] T001D2_A473sesdeviceid ;
      private string[] T001D2_A474sesexttoken2 ;
      private string[] T001D2_A458sesauttypename ;
      private short[] T001D2_A475sesoauthtokenmaxrenew ;
      private int[] T001D2_A476sesoauthtokenexpires ;
      private string[] T001D2_A477sesoauthscope ;
      private string[] T001D2_A478sesexttoken3 ;
      private DateTime[] T001D2_A479sesexttokenexpires ;
      private string[] T001D2_A480sesexttokenrefresh ;
      private string[] T001D2_A481sesjson ;
      private string[] T001D2_A482sesidtoken ;
      private string[] T001D2_A459sesotp ;
      private DateTime[] T001D2_A483sesotpexpire ;
      private bool[] T001D2_A484sesendedbyotherlogin ;
      private IDataStoreProvider pr_default ;
      private int[] T001D11_A449repid ;
      private string[] T001D11_A448sestoken ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class trn_gamsession__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_gamsession__gam : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT001D2;
        prmT001D2 = new Object[] {
        new ParDef("repid",GXType.Int32,9,0) ,
        new ParDef("sestoken",GXType.Char,120,0)
        };
        Object[] prmT001D3;
        prmT001D3 = new Object[] {
        new ParDef("repid",GXType.Int32,9,0) ,
        new ParDef("sestoken",GXType.Char,120,0)
        };
        Object[] prmT001D4;
        prmT001D4 = new Object[] {
        new ParDef("repid",GXType.Int32,9,0) ,
        new ParDef("sestoken",GXType.Char,120,0)
        };
        Object[] prmT001D5;
        prmT001D5 = new Object[] {
        new ParDef("repid",GXType.Int32,9,0) ,
        new ParDef("sestoken",GXType.Char,120,0)
        };
        Object[] prmT001D6;
        prmT001D6 = new Object[] {
        new ParDef("repid",GXType.Int32,9,0) ,
        new ParDef("sestoken",GXType.Char,120,0)
        };
        Object[] prmT001D7;
        prmT001D7 = new Object[] {
        new ParDef("repid",GXType.Int32,9,0) ,
        new ParDef("sestoken",GXType.Char,120,0)
        };
        Object[] prmT001D8;
        prmT001D8 = new Object[] {
        new ParDef("repid",GXType.Int32,9,0) ,
        new ParDef("sestoken",GXType.Char,120,0) ,
        new ParDef("sesdate",GXType.DateTime,10,8) ,
        new ParDef("sessts",GXType.Char,1,0) ,
        new ParDef("sestype",GXType.Int16,4,0) ,
        new ParDef("sesurl",GXType.VarChar,2048,0) ,
        new ParDef("sesipadd",GXType.Char,60,0) ,
        new ParDef("opesysid",GXType.Int16,4,0) ,
        new ParDef("seslastacc",GXType.DateTime,10,8) ,
        new ParDef("sestimeout",GXType.Int16,4,0) ,
        new ParDef("seslogatt",GXType.Int32,9,0) ,
        new ParDef("seslogdate",GXType.DateTime,10,8) ,
        new ParDef("sesshareddata",GXType.LongVarChar,2097152,0) ,
        new ParDef("sesenddate",GXType.DateTime,10,8) ,
        new ParDef("sesreload",GXType.Boolean,1,0) ,
        new ParDef("brwid",GXType.Int16,4,0) ,
        new ParDef("seslasturl",GXType.VarChar,2048,0) ,
        new ParDef("seslogin",GXType.VarChar,250,0) ,
        new ParDef("sesexttoken",GXType.Char,120,0) ,
        new ParDef("userguid",GXType.Char,40,0) ,
        new ParDef("sesapptokenexp",GXType.DateTime,10,8) ,
        new ParDef("sesrefreshtoken",GXType.Char,40,0) ,
        new ParDef("sesappid",GXType.Int64,18,0) ,
        new ParDef("sesdeviceid",GXType.Char,40,0) ,
        new ParDef("sesexttoken2",GXType.VarChar,1024,0) ,
        new ParDef("sesauttypename",GXType.Char,60,0) ,
        new ParDef("sesoauthtokenmaxrenew",GXType.Int16,4,0) ,
        new ParDef("sesoauthtokenexpires",GXType.Int32,9,0) ,
        new ParDef("sesoauthscope",GXType.VarChar,2048,0) ,
        new ParDef("sesexttoken3",GXType.LongVarChar,2097152,0) ,
        new ParDef("sesexttokenexpires",GXType.DateTime,10,8) ,
        new ParDef("sesexttokenrefresh",GXType.VarChar,2000,0) ,
        new ParDef("sesjson",GXType.LongVarChar,2097152,0) ,
        new ParDef("sesidtoken",GXType.VarChar,4096,0) ,
        new ParDef("sesotp",GXType.VarChar,250,0) ,
        new ParDef("sesotpexpire",GXType.DateTime,10,8) ,
        new ParDef("sesendedbyotherlogin",GXType.Boolean,1,0)
        };
        Object[] prmT001D9;
        prmT001D9 = new Object[] {
        new ParDef("sesdate",GXType.DateTime,10,8) ,
        new ParDef("sessts",GXType.Char,1,0) ,
        new ParDef("sestype",GXType.Int16,4,0) ,
        new ParDef("sesurl",GXType.VarChar,2048,0) ,
        new ParDef("sesipadd",GXType.Char,60,0) ,
        new ParDef("opesysid",GXType.Int16,4,0) ,
        new ParDef("seslastacc",GXType.DateTime,10,8) ,
        new ParDef("sestimeout",GXType.Int16,4,0) ,
        new ParDef("seslogatt",GXType.Int32,9,0) ,
        new ParDef("seslogdate",GXType.DateTime,10,8) ,
        new ParDef("sesshareddata",GXType.LongVarChar,2097152,0) ,
        new ParDef("sesenddate",GXType.DateTime,10,8) ,
        new ParDef("sesreload",GXType.Boolean,1,0) ,
        new ParDef("brwid",GXType.Int16,4,0) ,
        new ParDef("seslasturl",GXType.VarChar,2048,0) ,
        new ParDef("seslogin",GXType.VarChar,250,0) ,
        new ParDef("sesexttoken",GXType.Char,120,0) ,
        new ParDef("userguid",GXType.Char,40,0) ,
        new ParDef("sesapptokenexp",GXType.DateTime,10,8) ,
        new ParDef("sesrefreshtoken",GXType.Char,40,0) ,
        new ParDef("sesappid",GXType.Int64,18,0) ,
        new ParDef("sesdeviceid",GXType.Char,40,0) ,
        new ParDef("sesexttoken2",GXType.VarChar,1024,0) ,
        new ParDef("sesauttypename",GXType.Char,60,0) ,
        new ParDef("sesoauthtokenmaxrenew",GXType.Int16,4,0) ,
        new ParDef("sesoauthtokenexpires",GXType.Int32,9,0) ,
        new ParDef("sesoauthscope",GXType.VarChar,2048,0) ,
        new ParDef("sesexttoken3",GXType.LongVarChar,2097152,0) ,
        new ParDef("sesexttokenexpires",GXType.DateTime,10,8) ,
        new ParDef("sesexttokenrefresh",GXType.VarChar,2000,0) ,
        new ParDef("sesjson",GXType.LongVarChar,2097152,0) ,
        new ParDef("sesidtoken",GXType.VarChar,4096,0) ,
        new ParDef("sesotp",GXType.VarChar,250,0) ,
        new ParDef("sesotpexpire",GXType.DateTime,10,8) ,
        new ParDef("sesendedbyotherlogin",GXType.Boolean,1,0) ,
        new ParDef("repid",GXType.Int32,9,0) ,
        new ParDef("sestoken",GXType.Char,120,0)
        };
        Object[] prmT001D10;
        prmT001D10 = new Object[] {
        new ParDef("repid",GXType.Int32,9,0) ,
        new ParDef("sestoken",GXType.Char,120,0)
        };
        Object[] prmT001D11;
        prmT001D11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001D2", "SELECT repid, sestoken, sesdate, sessts, sestype, sesurl, sesipadd, opesysid, seslastacc, sestimeout, seslogatt, seslogdate, sesshareddata, sesenddate, sesreload, brwid, seslasturl, seslogin, sesexttoken, userguid, sesapptokenexp, sesrefreshtoken, sesappid, sesdeviceid, sesexttoken2, sesauttypename, sesoauthtokenmaxrenew, sesoauthtokenexpires, sesoauthscope, sesexttoken3, sesexttokenexpires, sesexttokenrefresh, sesjson, sesidtoken, sesotp, sesotpexpire, sesendedbyotherlogin FROM gam.session WHERE repid = :repid AND sestoken = :sestoken  FOR UPDATE OF session NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D3", "SELECT repid, sestoken, sesdate, sessts, sestype, sesurl, sesipadd, opesysid, seslastacc, sestimeout, seslogatt, seslogdate, sesshareddata, sesenddate, sesreload, brwid, seslasturl, seslogin, sesexttoken, userguid, sesapptokenexp, sesrefreshtoken, sesappid, sesdeviceid, sesexttoken2, sesauttypename, sesoauthtokenmaxrenew, sesoauthtokenexpires, sesoauthscope, sesexttoken3, sesexttokenexpires, sesexttokenrefresh, sesjson, sesidtoken, sesotp, sesotpexpire, sesendedbyotherlogin FROM gam.session WHERE repid = :repid AND sestoken = :sestoken ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D4", "SELECT TM1.repid, TM1.sestoken, TM1.sesdate, TM1.sessts, TM1.sestype, TM1.sesurl, TM1.sesipadd, TM1.opesysid, TM1.seslastacc, TM1.sestimeout, TM1.seslogatt, TM1.seslogdate, TM1.sesshareddata, TM1.sesenddate, TM1.sesreload, TM1.brwid, TM1.seslasturl, TM1.seslogin, TM1.sesexttoken, TM1.userguid, TM1.sesapptokenexp, TM1.sesrefreshtoken, TM1.sesappid, TM1.sesdeviceid, TM1.sesexttoken2, TM1.sesauttypename, TM1.sesoauthtokenmaxrenew, TM1.sesoauthtokenexpires, TM1.sesoauthscope, TM1.sesexttoken3, TM1.sesexttokenexpires, TM1.sesexttokenrefresh, TM1.sesjson, TM1.sesidtoken, TM1.sesotp, TM1.sesotpexpire, TM1.sesendedbyotherlogin FROM gam.session TM1 WHERE TM1.repid = :repid and TM1.sestoken = ( :sestoken) ORDER BY TM1.repid, TM1.sestoken ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D5", "SELECT repid, sestoken FROM gam.session WHERE repid = :repid AND sestoken = :sestoken ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D6", "SELECT repid, sestoken FROM gam.session WHERE ( repid > :repid or repid = :repid and sestoken > ( :sestoken)) ORDER BY repid, sestoken ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D7", "SELECT repid, sestoken FROM gam.session WHERE ( repid < :repid or repid = :repid and sestoken < ( :sestoken)) ORDER BY repid DESC, sestoken DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D8", "SAVEPOINT gxupdate;INSERT INTO gam.session(repid, sestoken, sesdate, sessts, sestype, sesurl, sesipadd, opesysid, seslastacc, sestimeout, seslogatt, seslogdate, sesshareddata, sesenddate, sesreload, brwid, seslasturl, seslogin, sesexttoken, userguid, sesapptokenexp, sesrefreshtoken, sesappid, sesdeviceid, sesexttoken2, sesauttypename, sesoauthtokenmaxrenew, sesoauthtokenexpires, sesoauthscope, sesexttoken3, sesexttokenexpires, sesexttokenrefresh, sesjson, sesidtoken, sesotp, sesotpexpire, sesendedbyotherlogin) VALUES(:repid, :sestoken, :sesdate, :sessts, :sestype, :sesurl, :sesipadd, :opesysid, :seslastacc, :sestimeout, :seslogatt, :seslogdate, :sesshareddata, :sesenddate, :sesreload, :brwid, :seslasturl, :seslogin, :sesexttoken, :userguid, :sesapptokenexp, :sesrefreshtoken, :sesappid, :sesdeviceid, :sesexttoken2, :sesauttypename, :sesoauthtokenmaxrenew, :sesoauthtokenexpires, :sesoauthscope, :sesexttoken3, :sesexttokenexpires, :sesexttokenrefresh, :sesjson, :sesidtoken, :sesotp, :sesotpexpire, :sesendedbyotherlogin);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001D8)
           ,new CursorDef("T001D9", "SAVEPOINT gxupdate;UPDATE gam.session SET sesdate=:sesdate, sessts=:sessts, sestype=:sestype, sesurl=:sesurl, sesipadd=:sesipadd, opesysid=:opesysid, seslastacc=:seslastacc, sestimeout=:sestimeout, seslogatt=:seslogatt, seslogdate=:seslogdate, sesshareddata=:sesshareddata, sesenddate=:sesenddate, sesreload=:sesreload, brwid=:brwid, seslasturl=:seslasturl, seslogin=:seslogin, sesexttoken=:sesexttoken, userguid=:userguid, sesapptokenexp=:sesapptokenexp, sesrefreshtoken=:sesrefreshtoken, sesappid=:sesappid, sesdeviceid=:sesdeviceid, sesexttoken2=:sesexttoken2, sesauttypename=:sesauttypename, sesoauthtokenmaxrenew=:sesoauthtokenmaxrenew, sesoauthtokenexpires=:sesoauthtokenexpires, sesoauthscope=:sesoauthscope, sesexttoken3=:sesexttoken3, sesexttokenexpires=:sesexttokenexpires, sesexttokenrefresh=:sesexttokenrefresh, sesjson=:sesjson, sesidtoken=:sesidtoken, sesotp=:sesotp, sesotpexpire=:sesotpexpire, sesendedbyotherlogin=:sesendedbyotherlogin  WHERE repid = :repid AND sestoken = :sestoken;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001D9)
           ,new CursorDef("T001D10", "SAVEPOINT gxupdate;DELETE FROM gam.session  WHERE repid = :repid AND sestoken = :sestoken;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001D10)
           ,new CursorDef("T001D11", "SELECT repid, sestoken FROM gam.session ORDER BY repid, sestoken ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D11,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 60);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[14])[0] = rslt.getBool(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 120);
              ((string[]) buf[19])[0] = rslt.getString(20, 40);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(21);
              ((string[]) buf[21])[0] = rslt.getString(22, 40);
              ((long[]) buf[22])[0] = rslt.getLong(23);
              ((string[]) buf[23])[0] = rslt.getString(24, 40);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getString(26, 60);
              ((short[]) buf[26])[0] = rslt.getShort(27);
              ((int[]) buf[27])[0] = rslt.getInt(28);
              ((string[]) buf[28])[0] = rslt.getVarchar(29);
              ((string[]) buf[29])[0] = rslt.getLongVarchar(30);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
              ((string[]) buf[31])[0] = rslt.getVarchar(32);
              ((string[]) buf[32])[0] = rslt.getLongVarchar(33);
              ((string[]) buf[33])[0] = rslt.getVarchar(34);
              ((string[]) buf[34])[0] = rslt.getVarchar(35);
              ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(36);
              ((bool[]) buf[36])[0] = rslt.getBool(37);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 60);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[14])[0] = rslt.getBool(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 120);
              ((string[]) buf[19])[0] = rslt.getString(20, 40);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(21);
              ((string[]) buf[21])[0] = rslt.getString(22, 40);
              ((long[]) buf[22])[0] = rslt.getLong(23);
              ((string[]) buf[23])[0] = rslt.getString(24, 40);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getString(26, 60);
              ((short[]) buf[26])[0] = rslt.getShort(27);
              ((int[]) buf[27])[0] = rslt.getInt(28);
              ((string[]) buf[28])[0] = rslt.getVarchar(29);
              ((string[]) buf[29])[0] = rslt.getLongVarchar(30);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
              ((string[]) buf[31])[0] = rslt.getVarchar(32);
              ((string[]) buf[32])[0] = rslt.getLongVarchar(33);
              ((string[]) buf[33])[0] = rslt.getVarchar(34);
              ((string[]) buf[34])[0] = rslt.getVarchar(35);
              ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(36);
              ((bool[]) buf[36])[0] = rslt.getBool(37);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 60);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[14])[0] = rslt.getBool(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 120);
              ((string[]) buf[19])[0] = rslt.getString(20, 40);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(21);
              ((string[]) buf[21])[0] = rslt.getString(22, 40);
              ((long[]) buf[22])[0] = rslt.getLong(23);
              ((string[]) buf[23])[0] = rslt.getString(24, 40);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getString(26, 60);
              ((short[]) buf[26])[0] = rslt.getShort(27);
              ((int[]) buf[27])[0] = rslt.getInt(28);
              ((string[]) buf[28])[0] = rslt.getVarchar(29);
              ((string[]) buf[29])[0] = rslt.getLongVarchar(30);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
              ((string[]) buf[31])[0] = rslt.getVarchar(32);
              ((string[]) buf[32])[0] = rslt.getLongVarchar(33);
              ((string[]) buf[33])[0] = rslt.getVarchar(34);
              ((string[]) buf[34])[0] = rslt.getVarchar(35);
              ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(36);
              ((bool[]) buf[36])[0] = rslt.getBool(37);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              return;
     }
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class trn_gamsession__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
