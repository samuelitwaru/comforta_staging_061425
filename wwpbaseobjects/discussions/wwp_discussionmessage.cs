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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_discussionmessage : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel2"+"_"+"WWPUSEREXTENDEDID") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX2ASAWWPUSEREXTENDEDID0R38( Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vSDT_DISCUSSIONTRANSLATIONVAR") == 0 )
         {
            A200WWPDiscussionMessageId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPDiscussionMessageId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A200WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A200WWPDiscussionMessageId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASASDT_DISCUSSIONTRANSLATIONVAR0R38( A200WWPDiscussionMessageId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A199WWPDiscussionMessageThreadId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPDiscussionMessageThreadId"), "."), 18, MidpointRounding.ToEven));
            n199WWPDiscussionMessageThreadId = false;
            AssignAttri("", false, "A199WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A199WWPDiscussionMessageThreadId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A199WWPDiscussionMessageThreadId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A112WWPUserExtendedId = GetPar( "WWPUserExtendedId");
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A112WWPUserExtendedId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A125WWPEntityId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPEntityId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrimStr( (decimal)(A125WWPEntityId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A125WWPEntityId) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Discussion Message", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_discussionmessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_discussionmessage( IGxContext context )
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
            return "wwpdiscussionmessage_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Discussion Message", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A200WWPDiscussionMessageId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPDiscussionMessageId_Enabled!=0) ? context.localUtil.Format( (decimal)(A200WWPDiscussionMessageId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A200WWPDiscussionMessageId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageDate_Internalname, context.GetMessage( "Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPDiscussionMessageDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageDate_Internalname, context.localUtil.TToC( A203WWPDiscussionMessageDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A203WWPDiscussionMessageDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_bitmap( context, edtWWPDiscussionMessageDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPDiscussionMessageDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageThreadId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageThreadId_Internalname, context.GetMessage( "Thread Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageThreadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A199WWPDiscussionMessageThreadId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPDiscussionMessageThreadId_Enabled!=0) ? context.localUtil.Format( (decimal)(A199WWPDiscussionMessageThreadId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A199WWPDiscussionMessageThreadId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageThreadId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageThreadId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageMessage_Internalname, context.GetMessage( "Message", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPDiscussionMessageMessage_Internalname, A204WWPDiscussionMessageMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtWWPDiscussionMessageMessage_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A112WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A112WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_label_element( context, "", context.GetMessage( "User Photo", ""), "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A115WWPUserExtendedPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000WWPUserExtendedPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A115WWPUserExtendedPhoto));
         GxWebStd.gx_bitmap( context, imgWWPUserExtendedPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgWWPUserExtendedPhoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", "", "", 0, A115WWPUserExtendedPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedFullName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedFullName_Internalname, context.GetMessage( "User Full Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A113WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A113WWPUserExtendedFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPEntityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A125WWPEntityId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A125WWPEntityId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityName_Internalname, A126WWPEntityName, StringUtil.RTrim( context.localUtil.Format( A126WWPEntityName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageEntityReco_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageEntityReco_Internalname, context.GetMessage( "Record Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageEntityReco_Internalname, A205WWPDiscussionMessageEntityReco, StringUtil.RTrim( context.localUtil.Format( A205WWPDiscussionMessageEntityReco, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageEntityReco_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageEntityReco_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Discussions/WWP_DiscussionMessage.htm");
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
            Z200WWPDiscussionMessageId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z200WWPDiscussionMessageId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z203WWPDiscussionMessageDate = context.localUtil.CToT( cgiGet( "Z203WWPDiscussionMessageDate"), 0);
            Z204WWPDiscussionMessageMessage = cgiGet( "Z204WWPDiscussionMessageMessage");
            Z205WWPDiscussionMessageEntityReco = cgiGet( "Z205WWPDiscussionMessageEntityReco");
            Z112WWPUserExtendedId = cgiGet( "Z112WWPUserExtendedId");
            Z125WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z125WWPEntityId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z199WWPDiscussionMessageThreadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z199WWPDiscussionMessageThreadId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n199WWPDiscussionMessageThreadId = ((0==A199WWPDiscussionMessageThreadId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_DISCUSSIONTRANSLATIONVAR"), AV8SDT_DiscussionTranslationVar);
            A40000WWPUserExtendedPhoto_GXI = cgiGet( "WWPUSEREXTENDEDPHOTO_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPDISCUSSIONMESSAGEID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A200WWPDiscussionMessageId = 0;
               AssignAttri("", false, "A200WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A200WWPDiscussionMessageId), 10, 0));
            }
            else
            {
               A200WWPDiscussionMessageId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A200WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A200WWPDiscussionMessageId), 10, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPDiscussionMessageDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Message Date", "")}), 1, "WWPDISCUSSIONMESSAGEDATE");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A203WWPDiscussionMessageDate", context.localUtil.TToC( A203WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A203WWPDiscussionMessageDate = context.localUtil.CToT( cgiGet( edtWWPDiscussionMessageDate_Internalname));
               AssignAttri("", false, "A203WWPDiscussionMessageDate", context.localUtil.TToC( A203WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageThreadId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageThreadId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A199WWPDiscussionMessageThreadId = 0;
               n199WWPDiscussionMessageThreadId = false;
               AssignAttri("", false, "A199WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A199WWPDiscussionMessageThreadId), 10, 0));
            }
            else
            {
               A199WWPDiscussionMessageThreadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageThreadId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n199WWPDiscussionMessageThreadId = false;
               AssignAttri("", false, "A199WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A199WWPDiscussionMessageThreadId), 10, 0));
            }
            n199WWPDiscussionMessageThreadId = ((0==A199WWPDiscussionMessageThreadId) ? true : false);
            A204WWPDiscussionMessageMessage = cgiGet( edtWWPDiscussionMessageMessage_Internalname);
            AssignAttri("", false, "A204WWPDiscussionMessageMessage", A204WWPDiscussionMessageMessage);
            A112WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            A115WWPUserExtendedPhoto = cgiGet( imgWWPUserExtendedPhoto_Internalname);
            AssignAttri("", false, "A115WWPUserExtendedPhoto", A115WWPUserExtendedPhoto);
            A113WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
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
            A205WWPDiscussionMessageEntityReco = cgiGet( edtWWPDiscussionMessageEntityReco_Internalname);
            AssignAttri("", false, "A205WWPDiscussionMessageEntityReco", A205WWPDiscussionMessageEntityReco);
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
               A200WWPDiscussionMessageId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPDiscussionMessageId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A200WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A200WWPDiscussionMessageId), 10, 0));
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
               InitAll0R38( ) ;
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
         DisableAttributes0R38( ) ;
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

      protected void ResetCaption0R0( )
      {
      }

      protected void ZM0R38( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z203WWPDiscussionMessageDate = T000R3_A203WWPDiscussionMessageDate[0];
               Z204WWPDiscussionMessageMessage = T000R3_A204WWPDiscussionMessageMessage[0];
               Z205WWPDiscussionMessageEntityReco = T000R3_A205WWPDiscussionMessageEntityReco[0];
               Z112WWPUserExtendedId = T000R3_A112WWPUserExtendedId[0];
               Z125WWPEntityId = T000R3_A125WWPEntityId[0];
               Z199WWPDiscussionMessageThreadId = T000R3_A199WWPDiscussionMessageThreadId[0];
            }
            else
            {
               Z203WWPDiscussionMessageDate = A203WWPDiscussionMessageDate;
               Z204WWPDiscussionMessageMessage = A204WWPDiscussionMessageMessage;
               Z205WWPDiscussionMessageEntityReco = A205WWPDiscussionMessageEntityReco;
               Z112WWPUserExtendedId = A112WWPUserExtendedId;
               Z125WWPEntityId = A125WWPEntityId;
               Z199WWPDiscussionMessageThreadId = A199WWPDiscussionMessageThreadId;
            }
         }
         if ( GX_JID == -6 )
         {
            Z200WWPDiscussionMessageId = A200WWPDiscussionMessageId;
            Z203WWPDiscussionMessageDate = A203WWPDiscussionMessageDate;
            Z204WWPDiscussionMessageMessage = A204WWPDiscussionMessageMessage;
            Z205WWPDiscussionMessageEntityReco = A205WWPDiscussionMessageEntityReco;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
            Z125WWPEntityId = A125WWPEntityId;
            Z199WWPDiscussionMessageThreadId = A199WWPDiscussionMessageThreadId;
            Z115WWPUserExtendedPhoto = A115WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
            Z126WWPEntityName = A126WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         A203WWPDiscussionMessageDate = DateTimeUtil.Now( context);
         AssignAttri("", false, "A203WWPDiscussionMessageDate", context.localUtil.TToC( A203WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GXt_char1 = A112WWPUserExtendedId;
         new uwwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         A112WWPUserExtendedId = GXt_char1;
         AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
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
            /* Using cursor T000R4 */
            pr_default.execute(2, new Object[] {A112WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = T000R4_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
            A113WWPUserExtendedFullName = T000R4_A113WWPUserExtendedFullName[0];
            AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
            A115WWPUserExtendedPhoto = T000R4_A115WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A115WWPUserExtendedPhoto", A115WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
            pr_default.close(2);
         }
      }

      protected void Load0R38( )
      {
         /* Using cursor T000R7 */
         pr_default.execute(5, new Object[] {A200WWPDiscussionMessageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound38 = 1;
            A203WWPDiscussionMessageDate = T000R7_A203WWPDiscussionMessageDate[0];
            AssignAttri("", false, "A203WWPDiscussionMessageDate", context.localUtil.TToC( A203WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A204WWPDiscussionMessageMessage = T000R7_A204WWPDiscussionMessageMessage[0];
            AssignAttri("", false, "A204WWPDiscussionMessageMessage", A204WWPDiscussionMessageMessage);
            A40000WWPUserExtendedPhoto_GXI = T000R7_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
            A113WWPUserExtendedFullName = T000R7_A113WWPUserExtendedFullName[0];
            AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
            A126WWPEntityName = T000R7_A126WWPEntityName[0];
            AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
            A205WWPDiscussionMessageEntityReco = T000R7_A205WWPDiscussionMessageEntityReco[0];
            AssignAttri("", false, "A205WWPDiscussionMessageEntityReco", A205WWPDiscussionMessageEntityReco);
            A112WWPUserExtendedId = T000R7_A112WWPUserExtendedId[0];
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            A125WWPEntityId = T000R7_A125WWPEntityId[0];
            AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrimStr( (decimal)(A125WWPEntityId), 10, 0));
            A199WWPDiscussionMessageThreadId = T000R7_A199WWPDiscussionMessageThreadId[0];
            n199WWPDiscussionMessageThreadId = T000R7_n199WWPDiscussionMessageThreadId[0];
            AssignAttri("", false, "A199WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A199WWPDiscussionMessageThreadId), 10, 0));
            A115WWPUserExtendedPhoto = T000R7_A115WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A115WWPUserExtendedPhoto", A115WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
            ZM0R38( -6) ;
         }
         pr_default.close(5);
         OnLoadActions0R38( ) ;
      }

      protected void OnLoadActions0R38( )
      {
      }

      protected void CheckExtendedTable0R38( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000R6 */
         pr_default.execute(4, new Object[] {n199WWPDiscussionMessageThreadId, A199WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A199WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Thread", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T000R4 */
         pr_default.execute(2, new Object[] {A112WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40000WWPUserExtendedPhoto_GXI = T000R4_A40000WWPUserExtendedPhoto_GXI[0];
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
         A113WWPUserExtendedFullName = T000R4_A113WWPUserExtendedFullName[0];
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         A115WWPUserExtendedPhoto = T000R4_A115WWPUserExtendedPhoto[0];
         AssignAttri("", false, "A115WWPUserExtendedPhoto", A115WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
         pr_default.close(2);
         /* Using cursor T000R5 */
         pr_default.execute(3, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A126WWPEntityName = T000R5_A126WWPEntityName[0];
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0R38( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( long A199WWPDiscussionMessageThreadId )
      {
         /* Using cursor T000R8 */
         pr_default.execute(6, new Object[] {n199WWPDiscussionMessageThreadId, A199WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A199WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Thread", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_7( string A112WWPUserExtendedId )
      {
         /* Using cursor T000R9 */
         pr_default.execute(7, new Object[] {A112WWPUserExtendedId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40000WWPUserExtendedPhoto_GXI = T000R9_A40000WWPUserExtendedPhoto_GXI[0];
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
         A113WWPUserExtendedFullName = T000R9_A113WWPUserExtendedFullName[0];
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         A115WWPUserExtendedPhoto = T000R9_A115WWPUserExtendedPhoto[0];
         AssignAttri("", false, "A115WWPUserExtendedPhoto", A115WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A115WWPUserExtendedPhoto)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000WWPUserExtendedPhoto_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( A113WWPUserExtendedFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_8( long A125WWPEntityId )
      {
         /* Using cursor T000R10 */
         pr_default.execute(8, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A126WWPEntityName = T000R10_A126WWPEntityName[0];
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A126WWPEntityName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0R38( )
      {
         /* Using cursor T000R11 */
         pr_default.execute(9, new Object[] {A200WWPDiscussionMessageId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound38 = 1;
         }
         else
         {
            RcdFound38 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000R3 */
         pr_default.execute(1, new Object[] {A200WWPDiscussionMessageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0R38( 6) ;
            RcdFound38 = 1;
            A200WWPDiscussionMessageId = T000R3_A200WWPDiscussionMessageId[0];
            AssignAttri("", false, "A200WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A200WWPDiscussionMessageId), 10, 0));
            A203WWPDiscussionMessageDate = T000R3_A203WWPDiscussionMessageDate[0];
            AssignAttri("", false, "A203WWPDiscussionMessageDate", context.localUtil.TToC( A203WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A204WWPDiscussionMessageMessage = T000R3_A204WWPDiscussionMessageMessage[0];
            AssignAttri("", false, "A204WWPDiscussionMessageMessage", A204WWPDiscussionMessageMessage);
            A205WWPDiscussionMessageEntityReco = T000R3_A205WWPDiscussionMessageEntityReco[0];
            AssignAttri("", false, "A205WWPDiscussionMessageEntityReco", A205WWPDiscussionMessageEntityReco);
            A112WWPUserExtendedId = T000R3_A112WWPUserExtendedId[0];
            AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
            A125WWPEntityId = T000R3_A125WWPEntityId[0];
            AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrimStr( (decimal)(A125WWPEntityId), 10, 0));
            A199WWPDiscussionMessageThreadId = T000R3_A199WWPDiscussionMessageThreadId[0];
            n199WWPDiscussionMessageThreadId = T000R3_n199WWPDiscussionMessageThreadId[0];
            AssignAttri("", false, "A199WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A199WWPDiscussionMessageThreadId), 10, 0));
            Z200WWPDiscussionMessageId = A200WWPDiscussionMessageId;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0R38( ) ;
            if ( AnyError == 1 )
            {
               RcdFound38 = 0;
               InitializeNonKey0R38( ) ;
            }
            Gx_mode = sMode38;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound38 = 0;
            InitializeNonKey0R38( ) ;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode38;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0R38( ) ;
         if ( RcdFound38 == 0 )
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
         RcdFound38 = 0;
         /* Using cursor T000R12 */
         pr_default.execute(10, new Object[] {A200WWPDiscussionMessageId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000R12_A200WWPDiscussionMessageId[0] < A200WWPDiscussionMessageId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000R12_A200WWPDiscussionMessageId[0] > A200WWPDiscussionMessageId ) ) )
            {
               A200WWPDiscussionMessageId = T000R12_A200WWPDiscussionMessageId[0];
               AssignAttri("", false, "A200WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A200WWPDiscussionMessageId), 10, 0));
               RcdFound38 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound38 = 0;
         /* Using cursor T000R13 */
         pr_default.execute(11, new Object[] {A200WWPDiscussionMessageId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000R13_A200WWPDiscussionMessageId[0] > A200WWPDiscussionMessageId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000R13_A200WWPDiscussionMessageId[0] < A200WWPDiscussionMessageId ) ) )
            {
               A200WWPDiscussionMessageId = T000R13_A200WWPDiscussionMessageId[0];
               AssignAttri("", false, "A200WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A200WWPDiscussionMessageId), 10, 0));
               RcdFound38 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0R38( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0R38( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound38 == 1 )
            {
               if ( A200WWPDiscussionMessageId != Z200WWPDiscussionMessageId )
               {
                  A200WWPDiscussionMessageId = Z200WWPDiscussionMessageId;
                  AssignAttri("", false, "A200WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A200WWPDiscussionMessageId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0R38( ) ;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A200WWPDiscussionMessageId != Z200WWPDiscussionMessageId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0R38( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPDISCUSSIONMESSAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0R38( ) ;
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
         if ( A200WWPDiscussionMessageId != Z200WWPDiscussionMessageId )
         {
            A200WWPDiscussionMessageId = Z200WWPDiscussionMessageId;
            AssignAttri("", false, "A200WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A200WWPDiscussionMessageId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
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
         if ( RcdFound38 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0R38( ) ;
         if ( RcdFound38 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0R38( ) ;
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
         if ( RcdFound38 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
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
         if ( RcdFound38 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
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
         ScanStart0R38( ) ;
         if ( RcdFound38 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound38 != 0 )
            {
               ScanNext0R38( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0R38( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0R38( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000R2 */
            pr_default.execute(0, new Object[] {A200WWPDiscussionMessageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z203WWPDiscussionMessageDate != T000R2_A203WWPDiscussionMessageDate[0] ) || ( StringUtil.StrCmp(Z204WWPDiscussionMessageMessage, T000R2_A204WWPDiscussionMessageMessage[0]) != 0 ) || ( StringUtil.StrCmp(Z205WWPDiscussionMessageEntityReco, T000R2_A205WWPDiscussionMessageEntityReco[0]) != 0 ) || ( StringUtil.StrCmp(Z112WWPUserExtendedId, T000R2_A112WWPUserExtendedId[0]) != 0 ) || ( Z125WWPEntityId != T000R2_A125WWPEntityId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z199WWPDiscussionMessageThreadId != T000R2_A199WWPDiscussionMessageThreadId[0] ) )
            {
               if ( Z203WWPDiscussionMessageDate != T000R2_A203WWPDiscussionMessageDate[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageDate");
                  GXUtil.WriteLogRaw("Old: ",Z203WWPDiscussionMessageDate);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A203WWPDiscussionMessageDate[0]);
               }
               if ( StringUtil.StrCmp(Z204WWPDiscussionMessageMessage, T000R2_A204WWPDiscussionMessageMessage[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageMessage");
                  GXUtil.WriteLogRaw("Old: ",Z204WWPDiscussionMessageMessage);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A204WWPDiscussionMessageMessage[0]);
               }
               if ( StringUtil.StrCmp(Z205WWPDiscussionMessageEntityReco, T000R2_A205WWPDiscussionMessageEntityReco[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageEntityReco");
                  GXUtil.WriteLogRaw("Old: ",Z205WWPDiscussionMessageEntityReco);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A205WWPDiscussionMessageEntityReco[0]);
               }
               if ( StringUtil.StrCmp(Z112WWPUserExtendedId, T000R2_A112WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z112WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A112WWPUserExtendedId[0]);
               }
               if ( Z125WWPEntityId != T000R2_A125WWPEntityId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPEntityId");
                  GXUtil.WriteLogRaw("Old: ",Z125WWPEntityId);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A125WWPEntityId[0]);
               }
               if ( Z199WWPDiscussionMessageThreadId != T000R2_A199WWPDiscussionMessageThreadId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageThreadId");
                  GXUtil.WriteLogRaw("Old: ",Z199WWPDiscussionMessageThreadId);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A199WWPDiscussionMessageThreadId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0R38( )
      {
         if ( ! IsAuthorized("wwpdiscussionmessage_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0R38( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R38( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0R38( 0) ;
            CheckOptimisticConcurrency0R38( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R38( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0R38( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000R14 */
                     pr_default.execute(12, new Object[] {A203WWPDiscussionMessageDate, A204WWPDiscussionMessageMessage, A205WWPDiscussionMessageEntityReco, A112WWPUserExtendedId, A125WWPEntityId, n199WWPDiscussionMessageThreadId, A199WWPDiscussionMessageThreadId});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000R15 */
                     pr_default.execute(13);
                     A200WWPDiscussionMessageId = T000R15_A200WWPDiscussionMessageId[0];
                     AssignAttri("", false, "A200WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A200WWPDiscussionMessageId), 10, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0R0( ) ;
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
               Load0R38( ) ;
            }
            EndLevel0R38( ) ;
         }
         CloseExtendedTableCursors0R38( ) ;
      }

      protected void Update0R38( )
      {
         if ( ! IsAuthorized("wwpdiscussionmessage_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0R38( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R38( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R38( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R38( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0R38( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000R16 */
                     pr_default.execute(14, new Object[] {A203WWPDiscussionMessageDate, A204WWPDiscussionMessageMessage, A205WWPDiscussionMessageEntityReco, A112WWPUserExtendedId, A125WWPEntityId, n199WWPDiscussionMessageThreadId, A199WWPDiscussionMessageThreadId, A200WWPDiscussionMessageId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0R38( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0R0( ) ;
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
            EndLevel0R38( ) ;
         }
         CloseExtendedTableCursors0R38( ) ;
      }

      protected void DeferredUpdate0R38( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpdiscussionmessage_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0R38( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R38( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0R38( ) ;
            AfterConfirm0R38( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0R38( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000R17 */
                  pr_default.execute(15, new Object[] {A200WWPDiscussionMessageId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound38 == 0 )
                        {
                           InitAll0R38( ) ;
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
                        ResetCaption0R0( ) ;
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
         sMode38 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0R38( ) ;
         Gx_mode = sMode38;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0R38( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000R18 */
            pr_default.execute(16, new Object[] {A112WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = T000R18_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
            A113WWPUserExtendedFullName = T000R18_A113WWPUserExtendedFullName[0];
            AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
            A115WWPUserExtendedPhoto = T000R18_A115WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A115WWPUserExtendedPhoto", A115WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
            pr_default.close(16);
            /* Using cursor T000R19 */
            pr_default.execute(17, new Object[] {A125WWPEntityId});
            A126WWPEntityName = T000R19_A126WWPEntityName[0];
            AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
            pr_default.close(17);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000R20 */
            pr_default.execute(18, new Object[] {A200WWPDiscussionMessageId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessage", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000R21 */
            pr_default.execute(19, new Object[] {A200WWPDiscussionMessageId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessageMention", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel0R38( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0R38( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.discussions.wwp_discussionmessage",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0R0( ) ;
            }
            /* After transaction rules */
            new prc_addtodiscussiontransalation(context ).execute(  AV8SDT_DiscussionTranslationVar) ;
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessage",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0R38( )
      {
         /* Using cursor T000R22 */
         pr_default.execute(20);
         RcdFound38 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound38 = 1;
            A200WWPDiscussionMessageId = T000R22_A200WWPDiscussionMessageId[0];
            AssignAttri("", false, "A200WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A200WWPDiscussionMessageId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0R38( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound38 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound38 = 1;
            A200WWPDiscussionMessageId = T000R22_A200WWPDiscussionMessageId[0];
            AssignAttri("", false, "A200WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A200WWPDiscussionMessageId), 10, 0));
         }
      }

      protected void ScanEnd0R38( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0R38( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0R38( )
      {
         /* Before Insert Rules */
         if ( (0==A199WWPDiscussionMessageThreadId) )
         {
            A199WWPDiscussionMessageThreadId = 0;
            n199WWPDiscussionMessageThreadId = false;
            AssignAttri("", false, "A199WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A199WWPDiscussionMessageThreadId), 10, 0));
            n199WWPDiscussionMessageThreadId = true;
            AssignAttri("", false, "A199WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A199WWPDiscussionMessageThreadId), 10, 0));
         }
      }

      protected void BeforeUpdate0R38( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0R38( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0R38( )
      {
         /* Before Complete Rules */
         GXt_SdtSDT_DiscussionTranslation2 = AV8SDT_DiscussionTranslationVar;
         new prc_adddiscussiontranslationtosdt(context ).execute(  A200WWPDiscussionMessageId, out  GXt_SdtSDT_DiscussionTranslation2) ;
         AV8SDT_DiscussionTranslationVar = GXt_SdtSDT_DiscussionTranslation2;
      }

      protected void BeforeValidate0R38( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0R38( )
      {
         edtWWPDiscussionMessageId_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageId_Enabled), 5, 0), true);
         edtWWPDiscussionMessageDate_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageDate_Enabled), 5, 0), true);
         edtWWPDiscussionMessageThreadId_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageThreadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageThreadId_Enabled), 5, 0), true);
         edtWWPDiscussionMessageMessage_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageMessage_Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         imgWWPUserExtendedPhoto_Enabled = 0;
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgWWPUserExtendedPhoto_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPEntityId_Enabled = 0;
         AssignProp("", false, edtWWPEntityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityId_Enabled), 5, 0), true);
         edtWWPEntityName_Enabled = 0;
         AssignProp("", false, edtWWPEntityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityName_Enabled), 5, 0), true);
         edtWWPDiscussionMessageEntityReco_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageEntityReco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageEntityReco_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0R38( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0R0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.discussions.wwp_discussionmessage.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z200WWPDiscussionMessageId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z200WWPDiscussionMessageId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z203WWPDiscussionMessageDate", context.localUtil.TToC( Z203WWPDiscussionMessageDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z204WWPDiscussionMessageMessage", Z204WWPDiscussionMessageMessage);
         GxWebStd.gx_hidden_field( context, "Z205WWPDiscussionMessageEntityReco", Z205WWPDiscussionMessageEntityReco);
         GxWebStd.gx_hidden_field( context, "Z112WWPUserExtendedId", StringUtil.RTrim( Z112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z125WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z199WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z199WWPDiscussionMessageThreadId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_DISCUSSIONTRANSLATIONVAR", AV8SDT_DiscussionTranslationVar);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_DISCUSSIONTRANSLATIONVAR", AV8SDT_DiscussionTranslationVar);
         }
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
         return formatLink("wwpbaseobjects.discussions.wwp_discussionmessage.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Discussions.WWP_DiscussionMessage" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Discussion Message", "") ;
      }

      protected void InitializeNonKey0R38( )
      {
         A203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A203WWPDiscussionMessageDate", context.localUtil.TToC( A203WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A112WWPUserExtendedId = "";
         AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
         AV8SDT_DiscussionTranslationVar = new SdtSDT_DiscussionTranslation(context);
         A199WWPDiscussionMessageThreadId = 0;
         n199WWPDiscussionMessageThreadId = false;
         AssignAttri("", false, "A199WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A199WWPDiscussionMessageThreadId), 10, 0));
         n199WWPDiscussionMessageThreadId = ((0==A199WWPDiscussionMessageThreadId) ? true : false);
         A204WWPDiscussionMessageMessage = "";
         AssignAttri("", false, "A204WWPDiscussionMessageMessage", A204WWPDiscussionMessageMessage);
         A115WWPUserExtendedPhoto = "";
         AssignAttri("", false, "A115WWPUserExtendedPhoto", A115WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
         A40000WWPUserExtendedPhoto_GXI = "";
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A115WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A115WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A115WWPUserExtendedPhoto), true);
         A113WWPUserExtendedFullName = "";
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         A125WWPEntityId = 0;
         AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrimStr( (decimal)(A125WWPEntityId), 10, 0));
         A126WWPEntityName = "";
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
         A205WWPDiscussionMessageEntityReco = "";
         AssignAttri("", false, "A205WWPDiscussionMessageEntityReco", A205WWPDiscussionMessageEntityReco);
         Z203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z204WWPDiscussionMessageMessage = "";
         Z205WWPDiscussionMessageEntityReco = "";
         Z112WWPUserExtendedId = "";
         Z125WWPEntityId = 0;
         Z199WWPDiscussionMessageThreadId = 0;
      }

      protected void InitAll0R38( )
      {
         A200WWPDiscussionMessageId = 0;
         AssignAttri("", false, "A200WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A200WWPDiscussionMessageId), 10, 0));
         InitializeNonKey0R38( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A203WWPDiscussionMessageDate = i203WWPDiscussionMessageDate;
         AssignAttri("", false, "A203WWPDiscussionMessageDate", context.localUtil.TToC( A203WWPDiscussionMessageDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A112WWPUserExtendedId = i112WWPUserExtendedId;
         AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201734093", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/discussions/wwp_discussionmessage.js", "?20256201734093", false, true);
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
         edtWWPDiscussionMessageId_Internalname = "WWPDISCUSSIONMESSAGEID";
         edtWWPDiscussionMessageDate_Internalname = "WWPDISCUSSIONMESSAGEDATE";
         edtWWPDiscussionMessageThreadId_Internalname = "WWPDISCUSSIONMESSAGETHREADID";
         edtWWPDiscussionMessageMessage_Internalname = "WWPDISCUSSIONMESSAGEMESSAGE";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         imgWWPUserExtendedPhoto_Internalname = "WWPUSEREXTENDEDPHOTO";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPEntityId_Internalname = "WWPENTITYID";
         edtWWPEntityName_Internalname = "WWPENTITYNAME";
         edtWWPDiscussionMessageEntityReco_Internalname = "WWPDISCUSSIONMESSAGEENTITYRECO";
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
         Form.Caption = context.GetMessage( "Discussion Message", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPDiscussionMessageEntityReco_Jsonclick = "";
         edtWWPDiscussionMessageEntityReco_Enabled = 1;
         edtWWPEntityName_Jsonclick = "";
         edtWWPEntityName_Enabled = 0;
         edtWWPEntityId_Jsonclick = "";
         edtWWPEntityId_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         imgWWPUserExtendedPhoto_Enabled = 0;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         edtWWPDiscussionMessageMessage_Enabled = 1;
         edtWWPDiscussionMessageThreadId_Jsonclick = "";
         edtWWPDiscussionMessageThreadId_Enabled = 1;
         edtWWPDiscussionMessageDate_Jsonclick = "";
         edtWWPDiscussionMessageDate_Enabled = 1;
         edtWWPDiscussionMessageId_Jsonclick = "";
         edtWWPDiscussionMessageId_Enabled = 1;
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

      protected void GX2ASAWWPUSEREXTENDEDID0R38( string Gx_mode )
      {
         GXt_char1 = A112WWPUserExtendedId;
         new uwwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         A112WWPUserExtendedId = GXt_char1;
         AssignAttri("", false, "A112WWPUserExtendedId", A112WWPUserExtendedId);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A112WWPUserExtendedId))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX4ASASDT_DISCUSSIONTRANSLATIONVAR0R38( long A200WWPDiscussionMessageId )
      {
         GXt_SdtSDT_DiscussionTranslation2 = AV8SDT_DiscussionTranslationVar;
         new prc_adddiscussiontranslationtosdt(context ).execute(  A200WWPDiscussionMessageId, out  GXt_SdtSDT_DiscussionTranslation2) ;
         AV8SDT_DiscussionTranslationVar = GXt_SdtSDT_DiscussionTranslation2;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV8SDT_DiscussionTranslationVar.ToXml(false, true, "", "")))+"\"") ;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
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

      public void Valid_Wwpdiscussionmessageid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A203WWPDiscussionMessageDate", context.localUtil.TToC( A203WWPDiscussionMessageDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A112WWPUserExtendedId", StringUtil.RTrim( A112WWPUserExtendedId));
         AssignAttri("", false, "A199WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A199WWPDiscussionMessageThreadId), 10, 0, ".", "")));
         AssignAttri("", false, "A204WWPDiscussionMessageMessage", A204WWPDiscussionMessageMessage);
         AssignAttri("", false, "A125WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A205WWPDiscussionMessageEntityReco", A205WWPDiscussionMessageEntityReco);
         AssignAttri("", false, "A115WWPUserExtendedPhoto", context.PathToRelativeUrl( A115WWPUserExtendedPhoto));
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A115WWPUserExtendedPhoto));
         AssignAttri("", false, "A40000WWPUserExtendedPhoto_GXI", A40000WWPUserExtendedPhoto_GXI);
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z200WWPDiscussionMessageId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z200WWPDiscussionMessageId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z203WWPDiscussionMessageDate", context.localUtil.TToC( Z203WWPDiscussionMessageDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z112WWPUserExtendedId", StringUtil.RTrim( Z112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z199WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z199WWPDiscussionMessageThreadId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z204WWPDiscussionMessageMessage", Z204WWPDiscussionMessageMessage);
         GxWebStd.gx_hidden_field( context, "Z125WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z205WWPDiscussionMessageEntityReco", Z205WWPDiscussionMessageEntityReco);
         GxWebStd.gx_hidden_field( context, "Z115WWPUserExtendedPhoto", context.PathToRelativeUrl( Z115WWPUserExtendedPhoto));
         GxWebStd.gx_hidden_field( context, "Z40000WWPUserExtendedPhoto_GXI", Z40000WWPUserExtendedPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z113WWPUserExtendedFullName", Z113WWPUserExtendedFullName);
         GxWebStd.gx_hidden_field( context, "Z126WWPEntityName", Z126WWPEntityName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpdiscussionmessagethreadid( )
      {
         n199WWPDiscussionMessageThreadId = false;
         /* Using cursor T000R23 */
         pr_default.execute(21, new Object[] {n199WWPDiscussionMessageThreadId, A199WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A199WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Thread", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
            }
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Wwpuserextendedid( )
      {
         /* Using cursor T000R18 */
         pr_default.execute(16, new Object[] {A112WWPUserExtendedId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
         }
         A40000WWPUserExtendedPhoto_GXI = T000R18_A40000WWPUserExtendedPhoto_GXI[0];
         A113WWPUserExtendedFullName = T000R18_A113WWPUserExtendedFullName[0];
         A115WWPUserExtendedPhoto = T000R18_A115WWPUserExtendedPhoto[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A115WWPUserExtendedPhoto", context.PathToRelativeUrl( A115WWPUserExtendedPhoto));
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A115WWPUserExtendedPhoto));
         AssignAttri("", false, "A40000WWPUserExtendedPhoto_GXI", A40000WWPUserExtendedPhoto_GXI);
         AssignAttri("", false, "A113WWPUserExtendedFullName", A113WWPUserExtendedFullName);
      }

      public void Valid_Wwpentityid( )
      {
         /* Using cursor T000R19 */
         pr_default.execute(17, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
         }
         A126WWPEntityName = T000R19_A126WWPEntityName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A126WWPEntityName", A126WWPEntityName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEID","""{"handler":"Valid_Wwpdiscussionmessageid","iparms":[{"av":"A200WWPDiscussionMessageId","fld":"WWPDISCUSSIONMESSAGEID","pic":"ZZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A203WWPDiscussionMessageDate","fld":"WWPDISCUSSIONMESSAGEDATE","pic":"99/99/99 99:99"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"}]""");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEID",""","oparms":[{"av":"A203WWPDiscussionMessageDate","fld":"WWPDISCUSSIONMESSAGEDATE","pic":"99/99/99 99:99"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"A199WWPDiscussionMessageThreadId","fld":"WWPDISCUSSIONMESSAGETHREADID","pic":"ZZZZZZZZZ9"},{"av":"A204WWPDiscussionMessageMessage","fld":"WWPDISCUSSIONMESSAGEMESSAGE"},{"av":"A125WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A205WWPDiscussionMessageEntityReco","fld":"WWPDISCUSSIONMESSAGEENTITYRECO"},{"av":"A115WWPUserExtendedPhoto","fld":"WWPUSEREXTENDEDPHOTO"},{"av":"A40000WWPUserExtendedPhoto_GXI","fld":"WWPUSEREXTENDEDPHOTO_GXI"},{"av":"A113WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"A126WWPEntityName","fld":"WWPENTITYNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z200WWPDiscussionMessageId"},{"av":"Z203WWPDiscussionMessageDate"},{"av":"Z112WWPUserExtendedId"},{"av":"Z199WWPDiscussionMessageThreadId"},{"av":"Z204WWPDiscussionMessageMessage"},{"av":"Z125WWPEntityId"},{"av":"Z205WWPDiscussionMessageEntityReco"},{"av":"Z115WWPUserExtendedPhoto"},{"av":"Z40000WWPUserExtendedPhoto_GXI"},{"av":"Z113WWPUserExtendedFullName"},{"av":"Z126WWPEntityName"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGETHREADID","""{"handler":"Valid_Wwpdiscussionmessagethreadid","iparms":[{"av":"A199WWPDiscussionMessageThreadId","fld":"WWPDISCUSSIONMESSAGETHREADID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","""{"handler":"Valid_Wwpuserextendedid","iparms":[{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"A115WWPUserExtendedPhoto","fld":"WWPUSEREXTENDEDPHOTO"},{"av":"A40000WWPUserExtendedPhoto_GXI","fld":"WWPUSEREXTENDEDPHOTO_GXI"},{"av":"A113WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"}]""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",""","oparms":[{"av":"A115WWPUserExtendedPhoto","fld":"WWPUSEREXTENDEDPHOTO"},{"av":"A40000WWPUserExtendedPhoto_GXI","fld":"WWPUSEREXTENDEDPHOTO_GXI"},{"av":"A113WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"}]}""");
         setEventMetadata("VALID_WWPENTITYID","""{"handler":"Valid_Wwpentityid","iparms":[{"av":"A125WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A126WWPEntityName","fld":"WWPENTITYNAME"}]""");
         setEventMetadata("VALID_WWPENTITYID",""","oparms":[{"av":"A126WWPEntityName","fld":"WWPENTITYNAME"}]}""");
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
         pr_default.close(17);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z204WWPDiscussionMessageMessage = "";
         Z205WWPDiscussionMessageEntityReco = "";
         Z112WWPUserExtendedId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         Gx_mode = "";
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
         A203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A204WWPDiscussionMessageMessage = "";
         A115WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         sImgUrl = "";
         A113WWPUserExtendedFullName = "";
         A126WWPEntityName = "";
         A205WWPDiscussionMessageEntityReco = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV8SDT_DiscussionTranslationVar = new SdtSDT_DiscussionTranslation(context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z115WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         Z113WWPUserExtendedFullName = "";
         Z126WWPEntityName = "";
         T000R4_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000R4_A113WWPUserExtendedFullName = new string[] {""} ;
         T000R4_A115WWPUserExtendedPhoto = new string[] {""} ;
         T000R7_A200WWPDiscussionMessageId = new long[1] ;
         T000R7_A203WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000R7_A204WWPDiscussionMessageMessage = new string[] {""} ;
         T000R7_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000R7_A113WWPUserExtendedFullName = new string[] {""} ;
         T000R7_A126WWPEntityName = new string[] {""} ;
         T000R7_A205WWPDiscussionMessageEntityReco = new string[] {""} ;
         T000R7_A112WWPUserExtendedId = new string[] {""} ;
         T000R7_A125WWPEntityId = new long[1] ;
         T000R7_A199WWPDiscussionMessageThreadId = new long[1] ;
         T000R7_n199WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000R7_A115WWPUserExtendedPhoto = new string[] {""} ;
         T000R6_A199WWPDiscussionMessageThreadId = new long[1] ;
         T000R6_n199WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000R5_A126WWPEntityName = new string[] {""} ;
         T000R8_A199WWPDiscussionMessageThreadId = new long[1] ;
         T000R8_n199WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000R9_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000R9_A113WWPUserExtendedFullName = new string[] {""} ;
         T000R9_A115WWPUserExtendedPhoto = new string[] {""} ;
         T000R10_A126WWPEntityName = new string[] {""} ;
         T000R11_A200WWPDiscussionMessageId = new long[1] ;
         T000R3_A200WWPDiscussionMessageId = new long[1] ;
         T000R3_A203WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000R3_A204WWPDiscussionMessageMessage = new string[] {""} ;
         T000R3_A205WWPDiscussionMessageEntityReco = new string[] {""} ;
         T000R3_A112WWPUserExtendedId = new string[] {""} ;
         T000R3_A125WWPEntityId = new long[1] ;
         T000R3_A199WWPDiscussionMessageThreadId = new long[1] ;
         T000R3_n199WWPDiscussionMessageThreadId = new bool[] {false} ;
         sMode38 = "";
         T000R12_A200WWPDiscussionMessageId = new long[1] ;
         T000R13_A200WWPDiscussionMessageId = new long[1] ;
         T000R2_A200WWPDiscussionMessageId = new long[1] ;
         T000R2_A203WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000R2_A204WWPDiscussionMessageMessage = new string[] {""} ;
         T000R2_A205WWPDiscussionMessageEntityReco = new string[] {""} ;
         T000R2_A112WWPUserExtendedId = new string[] {""} ;
         T000R2_A125WWPEntityId = new long[1] ;
         T000R2_A199WWPDiscussionMessageThreadId = new long[1] ;
         T000R2_n199WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000R15_A200WWPDiscussionMessageId = new long[1] ;
         T000R18_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000R18_A113WWPUserExtendedFullName = new string[] {""} ;
         T000R18_A115WWPUserExtendedPhoto = new string[] {""} ;
         T000R19_A126WWPEntityName = new string[] {""} ;
         T000R20_A199WWPDiscussionMessageThreadId = new long[1] ;
         T000R20_n199WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000R21_A200WWPDiscussionMessageId = new long[1] ;
         T000R21_A201WWPDiscussionMentionUserId = new string[] {""} ;
         T000R22_A200WWPDiscussionMessageId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         i112WWPUserExtendedId = "";
         GXt_char1 = "";
         GXt_SdtSDT_DiscussionTranslation2 = new SdtSDT_DiscussionTranslation(context);
         ZZ203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         ZZ112WWPUserExtendedId = "";
         ZZ204WWPDiscussionMessageMessage = "";
         ZZ205WWPDiscussionMessageEntityReco = "";
         ZZ115WWPUserExtendedPhoto = "";
         ZZ40000WWPUserExtendedPhoto_GXI = "";
         ZZ113WWPUserExtendedFullName = "";
         ZZ126WWPEntityName = "";
         T000R23_A199WWPDiscussionMessageThreadId = new long[1] ;
         T000R23_n199WWPDiscussionMessageThreadId = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage__default(),
            new Object[][] {
                new Object[] {
               T000R2_A200WWPDiscussionMessageId, T000R2_A203WWPDiscussionMessageDate, T000R2_A204WWPDiscussionMessageMessage, T000R2_A205WWPDiscussionMessageEntityReco, T000R2_A112WWPUserExtendedId, T000R2_A125WWPEntityId, T000R2_A199WWPDiscussionMessageThreadId, T000R2_n199WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000R3_A200WWPDiscussionMessageId, T000R3_A203WWPDiscussionMessageDate, T000R3_A204WWPDiscussionMessageMessage, T000R3_A205WWPDiscussionMessageEntityReco, T000R3_A112WWPUserExtendedId, T000R3_A125WWPEntityId, T000R3_A199WWPDiscussionMessageThreadId, T000R3_n199WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000R4_A40000WWPUserExtendedPhoto_GXI, T000R4_A113WWPUserExtendedFullName, T000R4_A115WWPUserExtendedPhoto
               }
               , new Object[] {
               T000R5_A126WWPEntityName
               }
               , new Object[] {
               T000R6_A199WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000R7_A200WWPDiscussionMessageId, T000R7_A203WWPDiscussionMessageDate, T000R7_A204WWPDiscussionMessageMessage, T000R7_A40000WWPUserExtendedPhoto_GXI, T000R7_A113WWPUserExtendedFullName, T000R7_A126WWPEntityName, T000R7_A205WWPDiscussionMessageEntityReco, T000R7_A112WWPUserExtendedId, T000R7_A125WWPEntityId, T000R7_A199WWPDiscussionMessageThreadId,
               T000R7_n199WWPDiscussionMessageThreadId, T000R7_A115WWPUserExtendedPhoto
               }
               , new Object[] {
               T000R8_A199WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000R9_A40000WWPUserExtendedPhoto_GXI, T000R9_A113WWPUserExtendedFullName, T000R9_A115WWPUserExtendedPhoto
               }
               , new Object[] {
               T000R10_A126WWPEntityName
               }
               , new Object[] {
               T000R11_A200WWPDiscussionMessageId
               }
               , new Object[] {
               T000R12_A200WWPDiscussionMessageId
               }
               , new Object[] {
               T000R13_A200WWPDiscussionMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               T000R15_A200WWPDiscussionMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000R18_A40000WWPUserExtendedPhoto_GXI, T000R18_A113WWPUserExtendedFullName, T000R18_A115WWPUserExtendedPhoto
               }
               , new Object[] {
               T000R19_A126WWPEntityName
               }
               , new Object[] {
               T000R20_A199WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000R21_A200WWPDiscussionMessageId, T000R21_A201WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000R22_A200WWPDiscussionMessageId
               }
               , new Object[] {
               T000R23_A199WWPDiscussionMessageThreadId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound38 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPDiscussionMessageId_Enabled ;
      private int edtWWPDiscussionMessageDate_Enabled ;
      private int edtWWPDiscussionMessageThreadId_Enabled ;
      private int edtWWPDiscussionMessageMessage_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int imgWWPUserExtendedPhoto_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPEntityId_Enabled ;
      private int edtWWPEntityName_Enabled ;
      private int edtWWPDiscussionMessageEntityReco_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z200WWPDiscussionMessageId ;
      private long Z125WWPEntityId ;
      private long Z199WWPDiscussionMessageThreadId ;
      private long A200WWPDiscussionMessageId ;
      private long A199WWPDiscussionMessageThreadId ;
      private long A125WWPEntityId ;
      private long ZZ200WWPDiscussionMessageId ;
      private long ZZ199WWPDiscussionMessageThreadId ;
      private long ZZ125WWPEntityId ;
      private string sPrefix ;
      private string Z112WWPUserExtendedId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string A112WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPDiscussionMessageId_Internalname ;
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
      private string edtWWPDiscussionMessageId_Jsonclick ;
      private string edtWWPDiscussionMessageDate_Internalname ;
      private string edtWWPDiscussionMessageDate_Jsonclick ;
      private string edtWWPDiscussionMessageThreadId_Internalname ;
      private string edtWWPDiscussionMessageThreadId_Jsonclick ;
      private string edtWWPDiscussionMessageMessage_Internalname ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string imgWWPUserExtendedPhoto_Internalname ;
      private string sImgUrl ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPEntityId_Internalname ;
      private string edtWWPEntityId_Jsonclick ;
      private string edtWWPEntityName_Internalname ;
      private string edtWWPEntityName_Jsonclick ;
      private string edtWWPDiscussionMessageEntityReco_Internalname ;
      private string edtWWPDiscussionMessageEntityReco_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode38 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string i112WWPUserExtendedId ;
      private string GXt_char1 ;
      private string ZZ112WWPUserExtendedId ;
      private DateTime Z203WWPDiscussionMessageDate ;
      private DateTime A203WWPDiscussionMessageDate ;
      private DateTime i203WWPDiscussionMessageDate ;
      private DateTime ZZ203WWPDiscussionMessageDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n199WWPDiscussionMessageThreadId ;
      private bool wbErr ;
      private bool A115WWPUserExtendedPhoto_IsBlob ;
      private bool Gx_longc ;
      private string Z204WWPDiscussionMessageMessage ;
      private string Z205WWPDiscussionMessageEntityReco ;
      private string A204WWPDiscussionMessageMessage ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string A113WWPUserExtendedFullName ;
      private string A126WWPEntityName ;
      private string A205WWPDiscussionMessageEntityReco ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string Z113WWPUserExtendedFullName ;
      private string Z126WWPEntityName ;
      private string ZZ204WWPDiscussionMessageMessage ;
      private string ZZ205WWPDiscussionMessageEntityReco ;
      private string ZZ40000WWPUserExtendedPhoto_GXI ;
      private string ZZ113WWPUserExtendedFullName ;
      private string ZZ126WWPEntityName ;
      private string A115WWPUserExtendedPhoto ;
      private string Z115WWPUserExtendedPhoto ;
      private string ZZ115WWPUserExtendedPhoto ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_DiscussionTranslation AV8SDT_DiscussionTranslationVar ;
      private IDataStoreProvider pr_default ;
      private string[] T000R4_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000R4_A113WWPUserExtendedFullName ;
      private string[] T000R4_A115WWPUserExtendedPhoto ;
      private long[] T000R7_A200WWPDiscussionMessageId ;
      private DateTime[] T000R7_A203WWPDiscussionMessageDate ;
      private string[] T000R7_A204WWPDiscussionMessageMessage ;
      private string[] T000R7_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000R7_A113WWPUserExtendedFullName ;
      private string[] T000R7_A126WWPEntityName ;
      private string[] T000R7_A205WWPDiscussionMessageEntityReco ;
      private string[] T000R7_A112WWPUserExtendedId ;
      private long[] T000R7_A125WWPEntityId ;
      private long[] T000R7_A199WWPDiscussionMessageThreadId ;
      private bool[] T000R7_n199WWPDiscussionMessageThreadId ;
      private string[] T000R7_A115WWPUserExtendedPhoto ;
      private long[] T000R6_A199WWPDiscussionMessageThreadId ;
      private bool[] T000R6_n199WWPDiscussionMessageThreadId ;
      private string[] T000R5_A126WWPEntityName ;
      private long[] T000R8_A199WWPDiscussionMessageThreadId ;
      private bool[] T000R8_n199WWPDiscussionMessageThreadId ;
      private string[] T000R9_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000R9_A113WWPUserExtendedFullName ;
      private string[] T000R9_A115WWPUserExtendedPhoto ;
      private string[] T000R10_A126WWPEntityName ;
      private long[] T000R11_A200WWPDiscussionMessageId ;
      private long[] T000R3_A200WWPDiscussionMessageId ;
      private DateTime[] T000R3_A203WWPDiscussionMessageDate ;
      private string[] T000R3_A204WWPDiscussionMessageMessage ;
      private string[] T000R3_A205WWPDiscussionMessageEntityReco ;
      private string[] T000R3_A112WWPUserExtendedId ;
      private long[] T000R3_A125WWPEntityId ;
      private long[] T000R3_A199WWPDiscussionMessageThreadId ;
      private bool[] T000R3_n199WWPDiscussionMessageThreadId ;
      private long[] T000R12_A200WWPDiscussionMessageId ;
      private long[] T000R13_A200WWPDiscussionMessageId ;
      private long[] T000R2_A200WWPDiscussionMessageId ;
      private DateTime[] T000R2_A203WWPDiscussionMessageDate ;
      private string[] T000R2_A204WWPDiscussionMessageMessage ;
      private string[] T000R2_A205WWPDiscussionMessageEntityReco ;
      private string[] T000R2_A112WWPUserExtendedId ;
      private long[] T000R2_A125WWPEntityId ;
      private long[] T000R2_A199WWPDiscussionMessageThreadId ;
      private bool[] T000R2_n199WWPDiscussionMessageThreadId ;
      private long[] T000R15_A200WWPDiscussionMessageId ;
      private string[] T000R18_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000R18_A113WWPUserExtendedFullName ;
      private string[] T000R18_A115WWPUserExtendedPhoto ;
      private string[] T000R19_A126WWPEntityName ;
      private long[] T000R20_A199WWPDiscussionMessageThreadId ;
      private bool[] T000R20_n199WWPDiscussionMessageThreadId ;
      private long[] T000R21_A200WWPDiscussionMessageId ;
      private string[] T000R21_A201WWPDiscussionMentionUserId ;
      private long[] T000R22_A200WWPDiscussionMessageId ;
      private SdtSDT_DiscussionTranslation GXt_SdtSDT_DiscussionTranslation2 ;
      private long[] T000R23_A199WWPDiscussionMessageThreadId ;
      private bool[] T000R23_n199WWPDiscussionMessageThreadId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_discussionmessage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_discussionmessage__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[20])
      ,new ForEachCursor(def[21])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000R2;
       prmT000R2 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmT000R3;
       prmT000R3 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmT000R4;
       prmT000R4 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0)
       };
       Object[] prmT000R5;
       prmT000R5 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmT000R6;
       prmT000R6 = new Object[] {
       new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000R7;
       prmT000R7 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmT000R8;
       prmT000R8 = new Object[] {
       new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000R9;
       prmT000R9 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0)
       };
       Object[] prmT000R10;
       prmT000R10 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmT000R11;
       prmT000R11 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmT000R12;
       prmT000R12 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmT000R13;
       prmT000R13 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmT000R14;
       prmT000R14 = new Object[] {
       new ParDef("WWPDiscussionMessageDate",GXType.DateTime,8,5) ,
       new ParDef("WWPDiscussionMessageMessage",GXType.VarChar,400,0) ,
       new ParDef("WWPDiscussionMessageEntityReco",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0) ,
       new ParDef("WWPEntityId",GXType.Int64,10,0) ,
       new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmT000R15;
       prmT000R15 = new Object[] {
       };
       Object[] prmT000R16;
       prmT000R16 = new Object[] {
       new ParDef("WWPDiscussionMessageDate",GXType.DateTime,8,5) ,
       new ParDef("WWPDiscussionMessageMessage",GXType.VarChar,400,0) ,
       new ParDef("WWPDiscussionMessageEntityReco",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0) ,
       new ParDef("WWPEntityId",GXType.Int64,10,0) ,
       new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true} ,
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmT000R17;
       prmT000R17 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmT000R18;
       prmT000R18 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0)
       };
       Object[] prmT000R19;
       prmT000R19 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmT000R20;
       prmT000R20 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmT000R21;
       prmT000R21 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmT000R22;
       prmT000R22 = new Object[] {
       };
       Object[] prmT000R23;
       prmT000R23 = new Object[] {
       new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("T000R2", "SELECT WWPDiscussionMessageId, WWPDiscussionMessageDate, WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco, WWPUserExtendedId, WWPEntityId, WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId  FOR UPDATE OF WWP_DiscussionMessage NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000R2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R3", "SELECT WWPDiscussionMessageId, WWPDiscussionMessageDate, WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco, WWPUserExtendedId, WWPEntityId, WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R4", "SELECT WWPUserExtendedPhoto_GXI, WWPUserExtendedFullName, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R5", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R6", "SELECT WWPDiscussionMessageId AS WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R7", "SELECT TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMessageDate, TM1.WWPDiscussionMessageMessage, T2.WWPUserExtendedPhoto_GXI, T2.WWPUserExtendedFullName, T3.WWPEntityName, TM1.WWPDiscussionMessageEntityReco, TM1.WWPUserExtendedId, TM1.WWPEntityId, TM1.WWPDiscussionMessageThreadId AS WWPDiscussionMessageThreadId, T2.WWPUserExtendedPhoto FROM ((WWP_DiscussionMessage TM1 INNER JOIN WWP_UserExtended T2 ON T2.WWPUserExtendedId = TM1.WWPUserExtendedId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPDiscussionMessageId = :WWPDiscussionMessageId ORDER BY TM1.WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R7,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R8", "SELECT WWPDiscussionMessageId AS WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R9", "SELECT WWPUserExtendedPhoto_GXI, WWPUserExtendedFullName, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R10", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R11", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R12", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE ( WWPDiscussionMessageId > :WWPDiscussionMessageId) ORDER BY WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R12,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000R13", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE ( WWPDiscussionMessageId < :WWPDiscussionMessageId) ORDER BY WWPDiscussionMessageId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R13,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000R14", "SAVEPOINT gxupdate;INSERT INTO WWP_DiscussionMessage(WWPDiscussionMessageDate, WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco, WWPUserExtendedId, WWPEntityId, WWPDiscussionMessageThreadId) VALUES(:WWPDiscussionMessageDate, :WWPDiscussionMessageMessage, :WWPDiscussionMessageEntityReco, :WWPUserExtendedId, :WWPEntityId, :WWPDiscussionMessageThreadId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000R14)
          ,new CursorDef("T000R15", "SELECT currval('WWPDiscussionMessageId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R15,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R16", "SAVEPOINT gxupdate;UPDATE WWP_DiscussionMessage SET WWPDiscussionMessageDate=:WWPDiscussionMessageDate, WWPDiscussionMessageMessage=:WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco=:WWPDiscussionMessageEntityReco, WWPUserExtendedId=:WWPUserExtendedId, WWPEntityId=:WWPEntityId, WWPDiscussionMessageThreadId=:WWPDiscussionMessageThreadId  WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000R16)
          ,new CursorDef("T000R17", "SAVEPOINT gxupdate;DELETE FROM WWP_DiscussionMessage  WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000R17)
          ,new CursorDef("T000R18", "SELECT WWPUserExtendedPhoto_GXI, WWPUserExtendedFullName, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R18,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R19", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R19,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R20", "SELECT WWPDiscussionMessageId AS WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageThreadId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R20,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000R21", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R21,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000R22", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage ORDER BY WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R22,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000R23", "SELECT WWPDiscussionMessageId AS WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R23,1, GxCacheFrequency.OFF ,true,false )
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
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 40);
             ((long[]) buf[5])[0] = rslt.getLong(6);
             ((long[]) buf[6])[0] = rslt.getLong(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 40);
             ((long[]) buf[5])[0] = rslt.getLong(6);
             ((long[]) buf[6])[0] = rslt.getLong(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 5 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 40);
             ((long[]) buf[8])[0] = rslt.getLong(9);
             ((long[]) buf[9])[0] = rslt.getLong(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
             return;
          case 6 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
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
             ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
             return;
          case 17 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 18 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 19 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 40);
             return;
          case 20 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 21 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
    }
 }

}

}
