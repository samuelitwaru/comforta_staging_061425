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
   public class uform : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel1"+"_"+"WWPFORMLATESTVERSIONNUMBER") == 0 )
         {
            A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX1ASAWWPFORMLATESTVERSIONNUMBER1G40( A206WWPFormId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            A211WWPFormElementParentId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementParentId"), "."), 18, MidpointRounding.ToEven));
            n211WWPFormElementParentId = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A206WWPFormId, A207WWPFormVersionNumber, A211WWPFormElementParentId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_element") == 0 )
         {
            gxnrGridlevel_element_newrow_invoke( ) ;
            return  ;
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
         Form.Meta.addItem("description", context.GetMessage( "General Dynamic Form", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_element_newrow_invoke( )
      {
         nRC_GXsfl_52 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_52"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_52_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_52_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_52_idx = GetPar( "sGXsfl_52_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_element_newrow( ) ;
         /* End function gxnrGridlevel_element_newrow_invoke */
      }

      public uform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public uform( IGxContext context )
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
         chkWWPFormIsWizard = new GXCheckbox();
         cmbWWPFormElementType = new GXCombobox();
         cmbWWPFormElementDataType = new GXCombobox();
         cmbWWPFormElementParentType = new GXCombobox();
         cmbWWPFormElementCaption = new GXCombobox();
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
            return "uform_Execute" ;
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
         A232WWPFormIsWizard = StringUtil.StrToBool( StringUtil.BoolToStr( A232WWPFormIsWizard));
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_UForm.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPFormId_Enabled!=0) ? context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9") : context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_UForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormVersionNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormVersionNumber_Internalname, context.GetMessage( "Form Version #", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormVersionNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPFormVersionNumber_Enabled!=0) ? context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9") : context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormVersionNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormVersionNumber_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_UForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormDate_Internalname, context.GetMessage( "Date", ""), "col-sm-4 AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPFormDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPFormDate_Internalname, context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A231WWPFormDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormDate_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtWWPFormDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_UForm.htm");
         GxWebStd.gx_bitmap( context, edtWWPFormDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPFormDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_UForm.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPFormIsWizard_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPFormIsWizard_Internalname, context.GetMessage( "Is Wizard", ""), "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPFormIsWizard_Internalname, StringUtil.BoolToStr( A232WWPFormIsWizard), "", context.GetMessage( "Is Wizard", ""), 1, chkWWPFormIsWizard.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,36);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormReferenceName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormReferenceName_Internalname, context.GetMessage( "Reference Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormReferenceName_Internalname, A208WWPFormReferenceName, StringUtil.RTrim( context.localUtil.Format( A208WWPFormReferenceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormReferenceName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormReferenceName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_UForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormTitle_Internalname, context.GetMessage( "Title", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormTitle_Internalname, A209WWPFormTitle, StringUtil.RTrim( context.localUtil.Format( A209WWPFormTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_UForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_element_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "start", "top", "", "", "div");
         gxdraw_Gridlevel_element( ) ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_UForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_UForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_UForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_element( )
      {
         /*  Grid Control  */
         StartGridControl52( ) ;
         nGXsfl_52_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount41 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_41 = 1;
               ScanStart1G41( ) ;
               while ( RcdFound41 != 0 )
               {
                  init_level_properties41( ) ;
                  getByPrimaryKey1G41( ) ;
                  AddRow1G41( ) ;
                  ScanNext1G41( ) ;
               }
               ScanEnd1G41( ) ;
               nBlankRcdCount41 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1G41( ) ;
            standaloneModal1G41( ) ;
            sMode41 = Gx_mode;
            while ( nGXsfl_52_idx < nRC_GXsfl_52 )
            {
               bGXsfl_52_Refreshing = true;
               ReadRow1G41( ) ;
               edtWWPFormElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTID_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtWWPFormElementTitle_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTTITLE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWWPFormElementTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtWWPFormElementReferenceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWWPFormElementReferenceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               cmbWWPFormElementType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTTYPE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbWWPFormElementType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementType.Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtWWPFormElementOrderIndex_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWWPFormElementOrderIndex_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               cmbWWPFormElementDataType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTDATATYPE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbWWPFormElementDataType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtWWPFormElementParentId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTPARENTID_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWWPFormElementParentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtWWPFormElementParentName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWWPFormElementParentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               cmbWWPFormElementParentType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbWWPFormElementParentType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtWWPFormElementMetadata_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTMETADATA_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWWPFormElementMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               cmbWWPFormElementCaption.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTCAPTION_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbWWPFormElementCaption_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0), !bGXsfl_52_Refreshing);
               if ( ( nRcdExists_41 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1G41( ) ;
               }
               SendRow1G41( ) ;
               bGXsfl_52_Refreshing = false;
            }
            Gx_mode = sMode41;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount41 = 5;
            nRcdExists_41 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1G41( ) ;
               while ( RcdFound41 != 0 )
               {
                  sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5241( ) ;
                  init_level_properties41( ) ;
                  standaloneNotModal1G41( ) ;
                  getByPrimaryKey1G41( ) ;
                  standaloneModal1G41( ) ;
                  AddRow1G41( ) ;
                  ScanNext1G41( ) ;
               }
               ScanEnd1G41( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode41 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx+1), 4, 0), 4, "0");
         SubsflControlProps_5241( ) ;
         InitAll1G41( ) ;
         init_level_properties41( ) ;
         nRcdExists_41 = 0;
         nIsMod_41 = 0;
         nRcdDeleted_41 = 0;
         nBlankRcdCount41 = (short)(nBlankRcdUsr41+nBlankRcdCount41);
         fRowAdded = 0;
         while ( nBlankRcdCount41 > 0 )
         {
            standaloneNotModal1G41( ) ;
            standaloneModal1G41( ) ;
            AddRow1G41( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtWWPFormElementId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount41 = (short)(nBlankRcdCount41-1);
         }
         Gx_mode = sMode41;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_elementContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_element", Gridlevel_elementContainer, subGridlevel_element_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_elementContainerData", Gridlevel_elementContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_elementContainerData"+"V", Gridlevel_elementContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_elementContainerData"+"V"+"\" value='"+Gridlevel_elementContainer.GridValuesHidden()+"'/>") ;
         }
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
         E111G2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z206WWPFormId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z207WWPFormVersionNumber"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z208WWPFormReferenceName = cgiGet( "Z208WWPFormReferenceName");
               Z209WWPFormTitle = cgiGet( "Z209WWPFormTitle");
               Z231WWPFormDate = context.localUtil.CToT( cgiGet( "Z231WWPFormDate"), 0);
               Z232WWPFormIsWizard = StringUtil.StrToBool( cgiGet( "Z232WWPFormIsWizard"));
               Z216WWPFormResume = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z216WWPFormResume"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z234WWPFormInstantiated = StringUtil.StrToBool( cgiGet( "Z234WWPFormInstantiated"));
               Z240WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z240WWPFormType"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z241WWPFormSectionRefElements = cgiGet( "Z241WWPFormSectionRefElements");
               Z242WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( "Z242WWPFormIsForDynamicValidations"));
               A216WWPFormResume = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z216WWPFormResume"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A234WWPFormInstantiated = StringUtil.StrToBool( cgiGet( "Z234WWPFormInstantiated"));
               A240WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z240WWPFormType"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A241WWPFormSectionRefElements = cgiGet( "Z241WWPFormSectionRefElements");
               A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( "Z242WWPFormIsForDynamicValidations"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_52 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_52"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A219WWPFormLatestVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMLATESTVERSIONNUMBER"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A216WWPFormResume = (short)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMRESUME"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A235WWPFormResumeMessage = cgiGet( "WWPFORMRESUMEMESSAGE");
               A233WWPFormValidations = cgiGet( "WWPFORMVALIDATIONS");
               A234WWPFormInstantiated = StringUtil.StrToBool( cgiGet( "WWPFORMINSTANTIATED"));
               A240WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMTYPE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A241WWPFormSectionRefElements = cgiGet( "WWPFORMSECTIONREFELEMENTS");
               A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( "WWPFORMISFORDYNAMICVALIDATIONS"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A238WWPFormElementExcludeFromExpor = StringUtil.StrToBool( cgiGet( "WWPFORMELEMENTEXCLUDEFROMEXPOR"));
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPFORMID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A206WWPFormId = 0;
                  AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               }
               else
               {
                  A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPFORMVERSIONNUMBER");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormVersionNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A207WWPFormVersionNumber = 0;
                  AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               }
               else
               {
                  A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtWWPFormDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "WWPForm Date", "")}), 1, "WWPFORMDATE");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A231WWPFormDate = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname));
                  AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               A232WWPFormIsWizard = StringUtil.StrToBool( cgiGet( chkWWPFormIsWizard_Internalname));
               AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
               A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
               AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
               A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
               AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"UForm");
               forbiddenHiddens.Add("WWPFormResume", context.localUtil.Format( (decimal)(A216WWPFormResume), "9"));
               forbiddenHiddens.Add("WWPFormInstantiated", StringUtil.BoolToStr( A234WWPFormInstantiated));
               forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A240WWPFormType), "9"));
               forbiddenHiddens.Add("WWPFormSectionRefElements", StringUtil.RTrim( context.localUtil.Format( A241WWPFormSectionRefElements, "")));
               forbiddenHiddens.Add("WWPFormIsForDynamicValidations", StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A206WWPFormId != Z206WWPFormId ) || ( A207WWPFormVersionNumber != Z207WWPFormVersionNumber ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("uform:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
                  A207WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
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
                           E111G2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121G2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E121G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1G40( ) ;
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
            bttBtntrn_delete_Enabled = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtntrn_enter_Visible = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
         }
         DisableAttributes1G40( ) ;
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

      protected void CONFIRM_1G41( )
      {
         nGXsfl_52_idx = 0;
         while ( nGXsfl_52_idx < nRC_GXsfl_52 )
         {
            ReadRow1G41( ) ;
            if ( ( nRcdExists_41 != 0 ) || ( nIsMod_41 != 0 ) )
            {
               GetKey1G41( ) ;
               if ( ( nRcdExists_41 == 0 ) && ( nRcdDeleted_41 == 0 ) )
               {
                  if ( RcdFound41 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1G41( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1G41( ) ;
                        CloseExtendedTableCursors1G41( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_52_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtWWPFormElementId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound41 != 0 )
                  {
                     if ( nRcdDeleted_41 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1G41( ) ;
                        Load1G41( ) ;
                        BeforeValidate1G41( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1G41( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_41 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1G41( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1G41( ) ;
                              CloseExtendedTableCursors1G41( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_41 == 0 )
                     {
                        GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_52_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPFormElementId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtWWPFormElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtWWPFormElementTitle_Internalname, A229WWPFormElementTitle) ;
            ChangePostValue( edtWWPFormElementReferenceId_Internalname, A213WWPFormElementReferenceId) ;
            ChangePostValue( cmbWWPFormElementType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A217WWPFormElementType), 1, 0, ".", ""))) ;
            ChangePostValue( edtWWPFormElementOrderIndex_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbWWPFormElementDataType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A218WWPFormElementDataType), 2, 0, ".", ""))) ;
            ChangePostValue( edtWWPFormElementParentId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtWWPFormElementParentName_Internalname, A228WWPFormElementParentName) ;
            ChangePostValue( cmbWWPFormElementParentType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A230WWPFormElementParentType), 1, 0, ".", ""))) ;
            ChangePostValue( edtWWPFormElementMetadata_Internalname, A236WWPFormElementMetadata) ;
            ChangePostValue( cmbWWPFormElementCaption_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A237WWPFormElementCaption), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z210WWPFormElementId_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z237WWPFormElementCaption_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z237WWPFormElementCaption), 1, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z217WWPFormElementType_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z217WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z212WWPFormElementOrderIndex_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z218WWPFormElementDataType_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z218WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z213WWPFormElementReferenceId_"+sGXsfl_52_idx, Z213WWPFormElementReferenceId) ;
            ChangePostValue( "ZT_"+"Z238WWPFormElementExcludeFromExpor_"+sGXsfl_52_idx, StringUtil.BoolToStr( Z238WWPFormElementExcludeFromExpor)) ;
            ChangePostValue( "ZT_"+"Z211WWPFormElementParentId_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_41_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_41), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_41_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_41), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_41_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_41), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_41 != 0 )
            {
               ChangePostValue( "WWPFORMELEMENTID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTTITLE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTTYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTDATATYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTPARENTID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTMETADATA_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTCAPTION_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1G0( )
      {
      }

      protected void E111G2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E121G2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1G40( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z208WWPFormReferenceName = T001G6_A208WWPFormReferenceName[0];
               Z209WWPFormTitle = T001G6_A209WWPFormTitle[0];
               Z231WWPFormDate = T001G6_A231WWPFormDate[0];
               Z232WWPFormIsWizard = T001G6_A232WWPFormIsWizard[0];
               Z216WWPFormResume = T001G6_A216WWPFormResume[0];
               Z234WWPFormInstantiated = T001G6_A234WWPFormInstantiated[0];
               Z240WWPFormType = T001G6_A240WWPFormType[0];
               Z241WWPFormSectionRefElements = T001G6_A241WWPFormSectionRefElements[0];
               Z242WWPFormIsForDynamicValidations = T001G6_A242WWPFormIsForDynamicValidations[0];
            }
            else
            {
               Z208WWPFormReferenceName = A208WWPFormReferenceName;
               Z209WWPFormTitle = A209WWPFormTitle;
               Z231WWPFormDate = A231WWPFormDate;
               Z232WWPFormIsWizard = A232WWPFormIsWizard;
               Z216WWPFormResume = A216WWPFormResume;
               Z234WWPFormInstantiated = A234WWPFormInstantiated;
               Z240WWPFormType = A240WWPFormType;
               Z241WWPFormSectionRefElements = A241WWPFormSectionRefElements;
               Z242WWPFormIsForDynamicValidations = A242WWPFormIsForDynamicValidations;
            }
         }
         if ( GX_JID == -8 )
         {
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z208WWPFormReferenceName = A208WWPFormReferenceName;
            Z209WWPFormTitle = A209WWPFormTitle;
            Z231WWPFormDate = A231WWPFormDate;
            Z232WWPFormIsWizard = A232WWPFormIsWizard;
            Z216WWPFormResume = A216WWPFormResume;
            Z235WWPFormResumeMessage = A235WWPFormResumeMessage;
            Z233WWPFormValidations = A233WWPFormValidations;
            Z234WWPFormInstantiated = A234WWPFormInstantiated;
            Z240WWPFormType = A240WWPFormType;
            Z241WWPFormSectionRefElements = A241WWPFormSectionRefElements;
            Z242WWPFormIsForDynamicValidations = A242WWPFormIsForDynamicValidations;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtntrn_delete_Enabled = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_delete_Enabled = 1;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load1G40( )
      {
         /* Using cursor T001G7 */
         pr_default.execute(5, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound40 = 1;
            A208WWPFormReferenceName = T001G7_A208WWPFormReferenceName[0];
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A209WWPFormTitle = T001G7_A209WWPFormTitle[0];
            AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
            A231WWPFormDate = T001G7_A231WWPFormDate[0];
            AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A232WWPFormIsWizard = T001G7_A232WWPFormIsWizard[0];
            AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
            A216WWPFormResume = T001G7_A216WWPFormResume[0];
            A235WWPFormResumeMessage = T001G7_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = T001G7_A233WWPFormValidations[0];
            A234WWPFormInstantiated = T001G7_A234WWPFormInstantiated[0];
            A240WWPFormType = T001G7_A240WWPFormType[0];
            A241WWPFormSectionRefElements = T001G7_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = T001G7_A242WWPFormIsForDynamicValidations[0];
            ZM1G40( -8) ;
         }
         pr_default.close(5);
         OnLoadActions1G40( ) ;
      }

      protected void OnLoadActions1G40( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
      }

      protected void CheckExtendedTable1G40( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         if ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  A206WWPFormId,  A208WWPFormReferenceName) )
         {
            GX_msglist.addItem(context.GetMessage( "WWP_DF_ReferenceMustBeUnique", ""), 1, "WWPFORMID");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1G40( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1G40( )
      {
         /* Using cursor T001G8 */
         pr_default.execute(6, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound40 = 1;
         }
         else
         {
            RcdFound40 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001G6 */
         pr_default.execute(4, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM1G40( 8) ;
            RcdFound40 = 1;
            A206WWPFormId = T001G6_A206WWPFormId[0];
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T001G6_A207WWPFormVersionNumber[0];
            AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            A208WWPFormReferenceName = T001G6_A208WWPFormReferenceName[0];
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A209WWPFormTitle = T001G6_A209WWPFormTitle[0];
            AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
            A231WWPFormDate = T001G6_A231WWPFormDate[0];
            AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A232WWPFormIsWizard = T001G6_A232WWPFormIsWizard[0];
            AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
            A216WWPFormResume = T001G6_A216WWPFormResume[0];
            A235WWPFormResumeMessage = T001G6_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = T001G6_A233WWPFormValidations[0];
            A234WWPFormInstantiated = T001G6_A234WWPFormInstantiated[0];
            A240WWPFormType = T001G6_A240WWPFormType[0];
            A241WWPFormSectionRefElements = T001G6_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = T001G6_A242WWPFormIsForDynamicValidations[0];
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1G40( ) ;
            if ( AnyError == 1 )
            {
               RcdFound40 = 0;
               InitializeNonKey1G40( ) ;
            }
            Gx_mode = sMode40;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound40 = 0;
            InitializeNonKey1G40( ) ;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode40;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey1G40( ) ;
         if ( RcdFound40 == 0 )
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
         RcdFound40 = 0;
         /* Using cursor T001G9 */
         pr_default.execute(7, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001G9_A206WWPFormId[0] < A206WWPFormId ) || ( T001G9_A206WWPFormId[0] == A206WWPFormId ) && ( T001G9_A207WWPFormVersionNumber[0] < A207WWPFormVersionNumber ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001G9_A206WWPFormId[0] > A206WWPFormId ) || ( T001G9_A206WWPFormId[0] == A206WWPFormId ) && ( T001G9_A207WWPFormVersionNumber[0] > A207WWPFormVersionNumber ) ) )
            {
               A206WWPFormId = T001G9_A206WWPFormId[0];
               AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               A207WWPFormVersionNumber = T001G9_A207WWPFormVersionNumber[0];
               AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               RcdFound40 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound40 = 0;
         /* Using cursor T001G10 */
         pr_default.execute(8, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001G10_A206WWPFormId[0] > A206WWPFormId ) || ( T001G10_A206WWPFormId[0] == A206WWPFormId ) && ( T001G10_A207WWPFormVersionNumber[0] > A207WWPFormVersionNumber ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001G10_A206WWPFormId[0] < A206WWPFormId ) || ( T001G10_A206WWPFormId[0] == A206WWPFormId ) && ( T001G10_A207WWPFormVersionNumber[0] < A207WWPFormVersionNumber ) ) )
            {
               A206WWPFormId = T001G10_A206WWPFormId[0];
               AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               A207WWPFormVersionNumber = T001G10_A207WWPFormVersionNumber[0];
               AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               RcdFound40 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1G40( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1G40( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound40 == 1 )
            {
               if ( ( A206WWPFormId != Z206WWPFormId ) || ( A207WWPFormVersionNumber != Z207WWPFormVersionNumber ) )
               {
                  A206WWPFormId = Z206WWPFormId;
                  AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
                  A207WWPFormVersionNumber = Z207WWPFormVersionNumber;
                  AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPFORMID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1G40( ) ;
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A206WWPFormId != Z206WWPFormId ) || ( A207WWPFormVersionNumber != Z207WWPFormVersionNumber ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1G40( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPFORMID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPFormId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPFormId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1G40( ) ;
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
         if ( ( A206WWPFormId != Z206WWPFormId ) || ( A207WWPFormVersionNumber != Z207WWPFormVersionNumber ) )
         {
            A206WWPFormId = Z206WWPFormId;
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = Z207WWPFormVersionNumber;
            AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPFORMID");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPFormId_Internalname;
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
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPFORMID");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPFormDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1G40( ) ;
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPFormDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1G40( ) ;
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
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPFormDate_Internalname;
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
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPFormDate_Internalname;
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
         ScanStart1G40( ) ;
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound40 != 0 )
            {
               ScanNext1G40( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPFormDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1G40( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1G40( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001G5 */
            pr_default.execute(3, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Form"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z208WWPFormReferenceName, T001G5_A208WWPFormReferenceName[0]) != 0 ) || ( StringUtil.StrCmp(Z209WWPFormTitle, T001G5_A209WWPFormTitle[0]) != 0 ) || ( Z231WWPFormDate != T001G5_A231WWPFormDate[0] ) || ( Z232WWPFormIsWizard != T001G5_A232WWPFormIsWizard[0] ) || ( Z216WWPFormResume != T001G5_A216WWPFormResume[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z234WWPFormInstantiated != T001G5_A234WWPFormInstantiated[0] ) || ( Z240WWPFormType != T001G5_A240WWPFormType[0] ) || ( StringUtil.StrCmp(Z241WWPFormSectionRefElements, T001G5_A241WWPFormSectionRefElements[0]) != 0 ) || ( Z242WWPFormIsForDynamicValidations != T001G5_A242WWPFormIsForDynamicValidations[0] ) )
            {
               if ( StringUtil.StrCmp(Z208WWPFormReferenceName, T001G5_A208WWPFormReferenceName[0]) != 0 )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormReferenceName");
                  GXUtil.WriteLogRaw("Old: ",Z208WWPFormReferenceName);
                  GXUtil.WriteLogRaw("Current: ",T001G5_A208WWPFormReferenceName[0]);
               }
               if ( StringUtil.StrCmp(Z209WWPFormTitle, T001G5_A209WWPFormTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormTitle");
                  GXUtil.WriteLogRaw("Old: ",Z209WWPFormTitle);
                  GXUtil.WriteLogRaw("Current: ",T001G5_A209WWPFormTitle[0]);
               }
               if ( Z231WWPFormDate != T001G5_A231WWPFormDate[0] )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormDate");
                  GXUtil.WriteLogRaw("Old: ",Z231WWPFormDate);
                  GXUtil.WriteLogRaw("Current: ",T001G5_A231WWPFormDate[0]);
               }
               if ( Z232WWPFormIsWizard != T001G5_A232WWPFormIsWizard[0] )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormIsWizard");
                  GXUtil.WriteLogRaw("Old: ",Z232WWPFormIsWizard);
                  GXUtil.WriteLogRaw("Current: ",T001G5_A232WWPFormIsWizard[0]);
               }
               if ( Z216WWPFormResume != T001G5_A216WWPFormResume[0] )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormResume");
                  GXUtil.WriteLogRaw("Old: ",Z216WWPFormResume);
                  GXUtil.WriteLogRaw("Current: ",T001G5_A216WWPFormResume[0]);
               }
               if ( Z234WWPFormInstantiated != T001G5_A234WWPFormInstantiated[0] )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormInstantiated");
                  GXUtil.WriteLogRaw("Old: ",Z234WWPFormInstantiated);
                  GXUtil.WriteLogRaw("Current: ",T001G5_A234WWPFormInstantiated[0]);
               }
               if ( Z240WWPFormType != T001G5_A240WWPFormType[0] )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormType");
                  GXUtil.WriteLogRaw("Old: ",Z240WWPFormType);
                  GXUtil.WriteLogRaw("Current: ",T001G5_A240WWPFormType[0]);
               }
               if ( StringUtil.StrCmp(Z241WWPFormSectionRefElements, T001G5_A241WWPFormSectionRefElements[0]) != 0 )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormSectionRefElements");
                  GXUtil.WriteLogRaw("Old: ",Z241WWPFormSectionRefElements);
                  GXUtil.WriteLogRaw("Current: ",T001G5_A241WWPFormSectionRefElements[0]);
               }
               if ( Z242WWPFormIsForDynamicValidations != T001G5_A242WWPFormIsForDynamicValidations[0] )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormIsForDynamicValidations");
                  GXUtil.WriteLogRaw("Old: ",Z242WWPFormIsForDynamicValidations);
                  GXUtil.WriteLogRaw("Current: ",T001G5_A242WWPFormIsForDynamicValidations[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Form"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G40( )
      {
         if ( ! IsAuthorized("uform_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1G40( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G40( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G40( 0) ;
            CheckOptimisticConcurrency1G40( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G40( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G40( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001G11 */
                     pr_default.execute(9, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A208WWPFormReferenceName, A209WWPFormTitle, A231WWPFormDate, A232WWPFormIsWizard, A216WWPFormResume, A235WWPFormResumeMessage, A233WWPFormValidations, A234WWPFormInstantiated, A240WWPFormType, A241WWPFormSectionRefElements, A242WWPFormIsForDynamicValidations});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
                     if ( (pr_default.getStatus(9) == 1) )
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
                           ProcessLevel1G40( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1G0( ) ;
                           }
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
               Load1G40( ) ;
            }
            EndLevel1G40( ) ;
         }
         CloseExtendedTableCursors1G40( ) ;
      }

      protected void Update1G40( )
      {
         if ( ! IsAuthorized("uform_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1G40( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G40( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G40( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G40( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1G40( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001G12 */
                     pr_default.execute(10, new Object[] {A208WWPFormReferenceName, A209WWPFormTitle, A231WWPFormDate, A232WWPFormIsWizard, A216WWPFormResume, A235WWPFormResumeMessage, A233WWPFormValidations, A234WWPFormInstantiated, A240WWPFormType, A241WWPFormSectionRefElements, A242WWPFormIsForDynamicValidations, A206WWPFormId, A207WWPFormVersionNumber});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Form"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1G40( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1G40( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption1G0( ) ;
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
            }
            EndLevel1G40( ) ;
         }
         CloseExtendedTableCursors1G40( ) ;
      }

      protected void DeferredUpdate1G40( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("uform_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1G40( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G40( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G40( ) ;
            AfterConfirm1G40( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G40( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1G41( ) ;
                  while ( RcdFound41 != 0 )
                  {
                     getByPrimaryKey1G41( ) ;
                     Delete1G41( ) ;
                     ScanNext1G41( ) ;
                  }
                  ScanEnd1G41( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001G13 */
                     pr_default.execute(11, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound40 == 0 )
                           {
                              InitAll1G40( ) ;
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
                           ResetCaption1G0( ) ;
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
         }
         sMode40 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1G40( ) ;
         Gx_mode = sMode40;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1G40( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001G14 */
            pr_default.execute(12, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_SupplierDynamicForm", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T001G15 */
            pr_default.execute(13, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_OrganisationDynamicForm", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T001G16 */
            pr_default.execute(14, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Location Dynamic Forms", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T001G17 */
            pr_default.execute(15, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWPForm Instance", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T001G18 */
            pr_default.execute(16, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Element", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void ProcessNestedLevel1G41( )
      {
         nGXsfl_52_idx = 0;
         while ( nGXsfl_52_idx < nRC_GXsfl_52 )
         {
            ReadRow1G41( ) ;
            if ( ( nRcdExists_41 != 0 ) || ( nIsMod_41 != 0 ) )
            {
               standaloneNotModal1G41( ) ;
               GetKey1G41( ) ;
               if ( ( nRcdExists_41 == 0 ) && ( nRcdDeleted_41 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1G41( ) ;
               }
               else
               {
                  if ( RcdFound41 != 0 )
                  {
                     if ( ( nRcdDeleted_41 != 0 ) && ( nRcdExists_41 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1G41( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_41 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1G41( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_41 == 0 )
                     {
                        GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_52_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPFormElementId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtWWPFormElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtWWPFormElementTitle_Internalname, A229WWPFormElementTitle) ;
            ChangePostValue( edtWWPFormElementReferenceId_Internalname, A213WWPFormElementReferenceId) ;
            ChangePostValue( cmbWWPFormElementType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A217WWPFormElementType), 1, 0, ".", ""))) ;
            ChangePostValue( edtWWPFormElementOrderIndex_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbWWPFormElementDataType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A218WWPFormElementDataType), 2, 0, ".", ""))) ;
            ChangePostValue( edtWWPFormElementParentId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtWWPFormElementParentName_Internalname, A228WWPFormElementParentName) ;
            ChangePostValue( cmbWWPFormElementParentType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A230WWPFormElementParentType), 1, 0, ".", ""))) ;
            ChangePostValue( edtWWPFormElementMetadata_Internalname, A236WWPFormElementMetadata) ;
            ChangePostValue( cmbWWPFormElementCaption_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A237WWPFormElementCaption), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z210WWPFormElementId_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z237WWPFormElementCaption_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z237WWPFormElementCaption), 1, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z217WWPFormElementType_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z217WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z212WWPFormElementOrderIndex_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z218WWPFormElementDataType_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z218WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z213WWPFormElementReferenceId_"+sGXsfl_52_idx, Z213WWPFormElementReferenceId) ;
            ChangePostValue( "ZT_"+"Z238WWPFormElementExcludeFromExpor_"+sGXsfl_52_idx, StringUtil.BoolToStr( Z238WWPFormElementExcludeFromExpor)) ;
            ChangePostValue( "ZT_"+"Z211WWPFormElementParentId_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_41_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_41), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_41_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_41), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_41_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_41), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_41 != 0 )
            {
               ChangePostValue( "WWPFORMELEMENTID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTTITLE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTTYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTDATATYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTPARENTID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTMETADATA_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPFORMELEMENTCAPTION_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1G41( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_41 = 0;
         nIsMod_41 = 0;
         nRcdDeleted_41 = 0;
      }

      protected void ProcessLevel1G40( )
      {
         /* Save parent mode. */
         sMode40 = Gx_mode;
         ProcessNestedLevel1G41( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode40;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1G40( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1G40( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("uform",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("uform",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1G40( )
      {
         /* Scan By routine */
         /* Using cursor T001G19 */
         pr_default.execute(17);
         RcdFound40 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound40 = 1;
            A206WWPFormId = T001G19_A206WWPFormId[0];
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T001G19_A207WWPFormVersionNumber[0];
            AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1G40( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound40 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound40 = 1;
            A206WWPFormId = T001G19_A206WWPFormId[0];
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T001G19_A207WWPFormVersionNumber[0];
            AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         }
      }

      protected void ScanEnd1G40( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm1G40( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1G40( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G40( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G40( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G40( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G40( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G40( )
      {
         edtWWPFormId_Enabled = 0;
         AssignProp("", false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         edtWWPFormVersionNumber_Enabled = 0;
         AssignProp("", false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         edtWWPFormDate_Enabled = 0;
         AssignProp("", false, edtWWPFormDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormDate_Enabled), 5, 0), true);
         chkWWPFormIsWizard.Enabled = 0;
         AssignProp("", false, chkWWPFormIsWizard_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormIsWizard.Enabled), 5, 0), true);
         edtWWPFormReferenceName_Enabled = 0;
         AssignProp("", false, edtWWPFormReferenceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormReferenceName_Enabled), 5, 0), true);
         edtWWPFormTitle_Enabled = 0;
         AssignProp("", false, edtWWPFormTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Enabled), 5, 0), true);
      }

      protected void ZM1G41( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z237WWPFormElementCaption = T001G3_A237WWPFormElementCaption[0];
               Z217WWPFormElementType = T001G3_A217WWPFormElementType[0];
               Z212WWPFormElementOrderIndex = T001G3_A212WWPFormElementOrderIndex[0];
               Z218WWPFormElementDataType = T001G3_A218WWPFormElementDataType[0];
               Z213WWPFormElementReferenceId = T001G3_A213WWPFormElementReferenceId[0];
               Z238WWPFormElementExcludeFromExpor = T001G3_A238WWPFormElementExcludeFromExpor[0];
               Z211WWPFormElementParentId = T001G3_A211WWPFormElementParentId[0];
            }
            else
            {
               Z237WWPFormElementCaption = A237WWPFormElementCaption;
               Z217WWPFormElementType = A217WWPFormElementType;
               Z212WWPFormElementOrderIndex = A212WWPFormElementOrderIndex;
               Z218WWPFormElementDataType = A218WWPFormElementDataType;
               Z213WWPFormElementReferenceId = A213WWPFormElementReferenceId;
               Z238WWPFormElementExcludeFromExpor = A238WWPFormElementExcludeFromExpor;
               Z211WWPFormElementParentId = A211WWPFormElementParentId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z210WWPFormElementId = A210WWPFormElementId;
            Z237WWPFormElementCaption = A237WWPFormElementCaption;
            Z229WWPFormElementTitle = A229WWPFormElementTitle;
            Z217WWPFormElementType = A217WWPFormElementType;
            Z212WWPFormElementOrderIndex = A212WWPFormElementOrderIndex;
            Z218WWPFormElementDataType = A218WWPFormElementDataType;
            Z236WWPFormElementMetadata = A236WWPFormElementMetadata;
            Z213WWPFormElementReferenceId = A213WWPFormElementReferenceId;
            Z238WWPFormElementExcludeFromExpor = A238WWPFormElementExcludeFromExpor;
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z211WWPFormElementParentId = A211WWPFormElementParentId;
            Z228WWPFormElementParentName = A228WWPFormElementParentName;
            Z230WWPFormElementParentType = A230WWPFormElementParentType;
         }
      }

      protected void standaloneNotModal1G41( )
      {
      }

      protected void standaloneModal1G41( )
      {
         if ( IsIns( )  && (0==A237WWPFormElementCaption) && ( Gx_BScreen == 0 ) )
         {
            A237WWPFormElementCaption = 1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtWWPFormElementId_Enabled = 0;
            AssignProp("", false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         }
         else
         {
            edtWWPFormElementId_Enabled = 1;
            AssignProp("", false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1G41( )
      {
         /* Using cursor T001G20 */
         pr_default.execute(18, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound41 = 1;
            A237WWPFormElementCaption = T001G20_A237WWPFormElementCaption[0];
            A229WWPFormElementTitle = T001G20_A229WWPFormElementTitle[0];
            A217WWPFormElementType = T001G20_A217WWPFormElementType[0];
            A212WWPFormElementOrderIndex = T001G20_A212WWPFormElementOrderIndex[0];
            A218WWPFormElementDataType = T001G20_A218WWPFormElementDataType[0];
            A228WWPFormElementParentName = T001G20_A228WWPFormElementParentName[0];
            A230WWPFormElementParentType = T001G20_A230WWPFormElementParentType[0];
            A236WWPFormElementMetadata = T001G20_A236WWPFormElementMetadata[0];
            A213WWPFormElementReferenceId = T001G20_A213WWPFormElementReferenceId[0];
            A238WWPFormElementExcludeFromExpor = T001G20_A238WWPFormElementExcludeFromExpor[0];
            A211WWPFormElementParentId = T001G20_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = T001G20_n211WWPFormElementParentId[0];
            ZM1G41( -9) ;
         }
         pr_default.close(18);
         OnLoadActions1G41( ) ;
      }

      protected void OnLoadActions1G41( )
      {
      }

      protected void CheckExtendedTable1G41( )
      {
         nIsDirty_41 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1G41( ) ;
         /* Using cursor T001G4 */
         pr_default.execute(2, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) || (0==A211WWPFormElementParentId) ) )
            {
               GXCCtl = "WWPFORMELEMENTPARENTID_" + sGXsfl_52_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWPForm Element Parent", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtWWPFormElementParentId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A228WWPFormElementParentName = T001G4_A228WWPFormElementParentName[0];
         A230WWPFormElementParentType = T001G4_A230WWPFormElementParentType[0];
         pr_default.close(2);
         if ( ! ( ( A217WWPFormElementType == 1 ) || ( A217WWPFormElementType == 2 ) || ( A217WWPFormElementType == 3 ) || ( A217WWPFormElementType == 4 ) || ( A217WWPFormElementType == 5 ) ) )
         {
            GXCCtl = "WWPFORMELEMENTTYPE_" + sGXsfl_52_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "WWPForm Element Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbWWPFormElementType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( A218WWPFormElementDataType == 1 ) || ( A218WWPFormElementDataType == 2 ) || ( A218WWPFormElementDataType == 3 ) || ( A218WWPFormElementDataType == 4 ) || ( A218WWPFormElementDataType == 5 ) || ( A218WWPFormElementDataType == 6 ) || ( A218WWPFormElementDataType == 7 ) || ( A218WWPFormElementDataType == 8 ) || ( A218WWPFormElementDataType == 9 ) || ( A218WWPFormElementDataType == 10 ) ) )
         {
            GXCCtl = "WWPFORMELEMENTDATATYPE_" + sGXsfl_52_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "WWPForm Element Data Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbWWPFormElementDataType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( A237WWPFormElementCaption == 1 ) || ( A237WWPFormElementCaption == 2 ) || ( A237WWPFormElementCaption == 3 ) ) )
         {
            GXCCtl = "WWPFORMELEMENTCAPTION_" + sGXsfl_52_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "WWPForm Element Caption", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbWWPFormElementCaption_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1G41( )
      {
         pr_default.close(2);
      }

      protected void enableDisable1G41( )
      {
      }

      protected void gxLoad_10( short A206WWPFormId ,
                                short A207WWPFormVersionNumber ,
                                short A211WWPFormElementParentId )
      {
         /* Using cursor T001G21 */
         pr_default.execute(19, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) || (0==A211WWPFormElementParentId) ) )
            {
               GXCCtl = "WWPFORMELEMENTPARENTID_" + sGXsfl_52_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWPForm Element Parent", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtWWPFormElementParentId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A228WWPFormElementParentName = T001G21_A228WWPFormElementParentName[0];
         A230WWPFormElementParentType = T001G21_A230WWPFormElementParentType[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A228WWPFormElementParentName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A230WWPFormElementParentType), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void GetKey1G41( )
      {
         /* Using cursor T001G22 */
         pr_default.execute(20, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound41 = 1;
         }
         else
         {
            RcdFound41 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey1G41( )
      {
         /* Using cursor T001G3 */
         pr_default.execute(1, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1G41( 9) ;
            RcdFound41 = 1;
            InitializeNonKey1G41( ) ;
            A210WWPFormElementId = T001G3_A210WWPFormElementId[0];
            A237WWPFormElementCaption = T001G3_A237WWPFormElementCaption[0];
            A229WWPFormElementTitle = T001G3_A229WWPFormElementTitle[0];
            A217WWPFormElementType = T001G3_A217WWPFormElementType[0];
            A212WWPFormElementOrderIndex = T001G3_A212WWPFormElementOrderIndex[0];
            A218WWPFormElementDataType = T001G3_A218WWPFormElementDataType[0];
            A236WWPFormElementMetadata = T001G3_A236WWPFormElementMetadata[0];
            A213WWPFormElementReferenceId = T001G3_A213WWPFormElementReferenceId[0];
            A238WWPFormElementExcludeFromExpor = T001G3_A238WWPFormElementExcludeFromExpor[0];
            A211WWPFormElementParentId = T001G3_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = T001G3_n211WWPFormElementParentId[0];
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z210WWPFormElementId = A210WWPFormElementId;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1G41( ) ;
            Load1G41( ) ;
            Gx_mode = sMode41;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound41 = 0;
            InitializeNonKey1G41( ) ;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1G41( ) ;
            Gx_mode = sMode41;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1G41( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1G41( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001G2 */
            pr_default.execute(0, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormElement"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z237WWPFormElementCaption != T001G2_A237WWPFormElementCaption[0] ) || ( Z217WWPFormElementType != T001G2_A217WWPFormElementType[0] ) || ( Z212WWPFormElementOrderIndex != T001G2_A212WWPFormElementOrderIndex[0] ) || ( Z218WWPFormElementDataType != T001G2_A218WWPFormElementDataType[0] ) || ( StringUtil.StrCmp(Z213WWPFormElementReferenceId, T001G2_A213WWPFormElementReferenceId[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z238WWPFormElementExcludeFromExpor != T001G2_A238WWPFormElementExcludeFromExpor[0] ) || ( Z211WWPFormElementParentId != T001G2_A211WWPFormElementParentId[0] ) )
            {
               if ( Z237WWPFormElementCaption != T001G2_A237WWPFormElementCaption[0] )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormElementCaption");
                  GXUtil.WriteLogRaw("Old: ",Z237WWPFormElementCaption);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A237WWPFormElementCaption[0]);
               }
               if ( Z217WWPFormElementType != T001G2_A217WWPFormElementType[0] )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormElementType");
                  GXUtil.WriteLogRaw("Old: ",Z217WWPFormElementType);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A217WWPFormElementType[0]);
               }
               if ( Z212WWPFormElementOrderIndex != T001G2_A212WWPFormElementOrderIndex[0] )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormElementOrderIndex");
                  GXUtil.WriteLogRaw("Old: ",Z212WWPFormElementOrderIndex);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A212WWPFormElementOrderIndex[0]);
               }
               if ( Z218WWPFormElementDataType != T001G2_A218WWPFormElementDataType[0] )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormElementDataType");
                  GXUtil.WriteLogRaw("Old: ",Z218WWPFormElementDataType);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A218WWPFormElementDataType[0]);
               }
               if ( StringUtil.StrCmp(Z213WWPFormElementReferenceId, T001G2_A213WWPFormElementReferenceId[0]) != 0 )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormElementReferenceId");
                  GXUtil.WriteLogRaw("Old: ",Z213WWPFormElementReferenceId);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A213WWPFormElementReferenceId[0]);
               }
               if ( Z238WWPFormElementExcludeFromExpor != T001G2_A238WWPFormElementExcludeFromExpor[0] )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormElementExcludeFromExpor");
                  GXUtil.WriteLogRaw("Old: ",Z238WWPFormElementExcludeFromExpor);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A238WWPFormElementExcludeFromExpor[0]);
               }
               if ( Z211WWPFormElementParentId != T001G2_A211WWPFormElementParentId[0] )
               {
                  GXUtil.WriteLog("uform:[seudo value changed for attri]"+"WWPFormElementParentId");
                  GXUtil.WriteLogRaw("Old: ",Z211WWPFormElementParentId);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A211WWPFormElementParentId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_FormElement"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G41( )
      {
         if ( ! IsAuthorized("uform_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1G41( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G41( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G41( 0) ;
            CheckOptimisticConcurrency1G41( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G41( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G41( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001G23 */
                     pr_default.execute(21, new Object[] {A210WWPFormElementId, A237WWPFormElementCaption, A229WWPFormElementTitle, A217WWPFormElementType, A212WWPFormElementOrderIndex, A218WWPFormElementDataType, A236WWPFormElementMetadata, A213WWPFormElementReferenceId, A238WWPFormElementExcludeFromExpor, A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
                     if ( (pr_default.getStatus(21) == 1) )
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
               Load1G41( ) ;
            }
            EndLevel1G41( ) ;
         }
         CloseExtendedTableCursors1G41( ) ;
      }

      protected void Update1G41( )
      {
         if ( ! IsAuthorized("uform_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1G41( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G41( ) ;
         }
         if ( ( nIsMod_41 != 0 ) || ( nIsDirty_41 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1G41( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1G41( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1G41( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001G24 */
                        pr_default.execute(22, new Object[] {A237WWPFormElementCaption, A229WWPFormElementTitle, A217WWPFormElementType, A212WWPFormElementOrderIndex, A218WWPFormElementDataType, A236WWPFormElementMetadata, A213WWPFormElementReferenceId, A238WWPFormElementExcludeFromExpor, n211WWPFormElementParentId, A211WWPFormElementParentId, A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
                        pr_default.close(22);
                        pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
                        if ( (pr_default.getStatus(22) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormElement"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1G41( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1G41( ) ;
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
               EndLevel1G41( ) ;
            }
         }
         CloseExtendedTableCursors1G41( ) ;
      }

      protected void DeferredUpdate1G41( )
      {
      }

      protected void Delete1G41( )
      {
         if ( ! IsAuthorized("uform_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1G41( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G41( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G41( ) ;
            AfterConfirm1G41( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G41( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001G25 */
                  pr_default.execute(23, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
                  pr_default.close(23);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode41 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1G41( ) ;
         Gx_mode = sMode41;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1G41( )
      {
         standaloneModal1G41( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001G26 */
            pr_default.execute(24, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
            A228WWPFormElementParentName = T001G26_A228WWPFormElementParentName[0];
            A230WWPFormElementParentType = T001G26_A230WWPFormElementParentType[0];
            pr_default.close(24);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001G27 */
            pr_default.execute(25, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Element", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
         }
      }

      protected void EndLevel1G41( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1G41( )
      {
         /* Scan By routine */
         /* Using cursor T001G28 */
         pr_default.execute(26, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         RcdFound41 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound41 = 1;
            A210WWPFormElementId = T001G28_A210WWPFormElementId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1G41( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound41 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound41 = 1;
            A210WWPFormElementId = T001G28_A210WWPFormElementId[0];
         }
      }

      protected void ScanEnd1G41( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm1G41( )
      {
         /* After Confirm Rules */
         if ( (0==A211WWPFormElementParentId) )
         {
            A211WWPFormElementParentId = 0;
            n211WWPFormElementParentId = false;
            n211WWPFormElementParentId = true;
         }
      }

      protected void BeforeInsert1G41( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G41( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G41( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G41( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G41( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G41( )
      {
         edtWWPFormElementId_Enabled = 0;
         AssignProp("", false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtWWPFormElementTitle_Enabled = 0;
         AssignProp("", false, edtWWPFormElementTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtWWPFormElementReferenceId_Enabled = 0;
         AssignProp("", false, edtWWPFormElementReferenceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         cmbWWPFormElementType.Enabled = 0;
         AssignProp("", false, cmbWWPFormElementType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementType.Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtWWPFormElementOrderIndex_Enabled = 0;
         AssignProp("", false, edtWWPFormElementOrderIndex_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         cmbWWPFormElementDataType.Enabled = 0;
         AssignProp("", false, cmbWWPFormElementDataType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtWWPFormElementParentId_Enabled = 0;
         AssignProp("", false, edtWWPFormElementParentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtWWPFormElementParentName_Enabled = 0;
         AssignProp("", false, edtWWPFormElementParentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         cmbWWPFormElementParentType.Enabled = 0;
         AssignProp("", false, cmbWWPFormElementParentType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtWWPFormElementMetadata_Enabled = 0;
         AssignProp("", false, edtWWPFormElementMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         cmbWWPFormElementCaption.Enabled = 0;
         AssignProp("", false, cmbWWPFormElementCaption_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0), !bGXsfl_52_Refreshing);
      }

      protected void send_integrity_lvl_hashes1G41( )
      {
      }

      protected void send_integrity_lvl_hashes1G40( )
      {
      }

      protected void SubsflControlProps_5241( )
      {
         edtWWPFormElementId_Internalname = "WWPFORMELEMENTID_"+sGXsfl_52_idx;
         edtWWPFormElementTitle_Internalname = "WWPFORMELEMENTTITLE_"+sGXsfl_52_idx;
         edtWWPFormElementReferenceId_Internalname = "WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_idx;
         cmbWWPFormElementType_Internalname = "WWPFORMELEMENTTYPE_"+sGXsfl_52_idx;
         edtWWPFormElementOrderIndex_Internalname = "WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_idx;
         cmbWWPFormElementDataType_Internalname = "WWPFORMELEMENTDATATYPE_"+sGXsfl_52_idx;
         edtWWPFormElementParentId_Internalname = "WWPFORMELEMENTPARENTID_"+sGXsfl_52_idx;
         edtWWPFormElementParentName_Internalname = "WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_idx;
         cmbWWPFormElementParentType_Internalname = "WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_idx;
         edtWWPFormElementMetadata_Internalname = "WWPFORMELEMENTMETADATA_"+sGXsfl_52_idx;
         cmbWWPFormElementCaption_Internalname = "WWPFORMELEMENTCAPTION_"+sGXsfl_52_idx;
      }

      protected void SubsflControlProps_fel_5241( )
      {
         edtWWPFormElementId_Internalname = "WWPFORMELEMENTID_"+sGXsfl_52_fel_idx;
         edtWWPFormElementTitle_Internalname = "WWPFORMELEMENTTITLE_"+sGXsfl_52_fel_idx;
         edtWWPFormElementReferenceId_Internalname = "WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_fel_idx;
         cmbWWPFormElementType_Internalname = "WWPFORMELEMENTTYPE_"+sGXsfl_52_fel_idx;
         edtWWPFormElementOrderIndex_Internalname = "WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_fel_idx;
         cmbWWPFormElementDataType_Internalname = "WWPFORMELEMENTDATATYPE_"+sGXsfl_52_fel_idx;
         edtWWPFormElementParentId_Internalname = "WWPFORMELEMENTPARENTID_"+sGXsfl_52_fel_idx;
         edtWWPFormElementParentName_Internalname = "WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_fel_idx;
         cmbWWPFormElementParentType_Internalname = "WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_fel_idx;
         edtWWPFormElementMetadata_Internalname = "WWPFORMELEMENTMETADATA_"+sGXsfl_52_fel_idx;
         cmbWWPFormElementCaption_Internalname = "WWPFORMELEMENTCAPTION_"+sGXsfl_52_fel_idx;
      }

      protected void AddRow1G41( )
      {
         nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
         SubsflControlProps_5241( ) ;
         SendRow1G41( ) ;
      }

      protected void SendRow1G41( )
      {
         Gridlevel_elementRow = GXWebRow.GetNew(context);
         if ( subGridlevel_element_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_element_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
            {
               subGridlevel_element_Linesclass = subGridlevel_element_Class+"Odd";
            }
         }
         else if ( subGridlevel_element_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_element_Backstyle = 0;
            subGridlevel_element_Backcolor = subGridlevel_element_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
            {
               subGridlevel_element_Linesclass = subGridlevel_element_Class+"Uniform";
            }
         }
         else if ( subGridlevel_element_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_element_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
            {
               subGridlevel_element_Linesclass = subGridlevel_element_Class+"Odd";
            }
            subGridlevel_element_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_element_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_element_Backstyle = 1;
            if ( ((int)((nGXsfl_52_idx) % (2))) == 0 )
            {
               subGridlevel_element_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
               {
                  subGridlevel_element_Linesclass = subGridlevel_element_Class+"Even";
               }
            }
            else
            {
               subGridlevel_element_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
               {
                  subGridlevel_element_Linesclass = subGridlevel_element_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A210WWPFormElementId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,53);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementTitle_Internalname,(string)A229WWPFormElementTitle,(string)A229WWPFormElementTitle,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementTitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementTitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)52,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementReferenceId_Internalname,(string)A213WWPFormElementReferenceId,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementReferenceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementReferenceId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_52_idx + "',52)\"";
         if ( ( cmbWWPFormElementType.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "WWPFORMELEMENTTYPE_" + sGXsfl_52_idx;
            cmbWWPFormElementType.Name = GXCCtl;
            cmbWWPFormElementType.WebTags = "";
            cmbWWPFormElementType.addItem("1", context.GetMessage( "WWP_DF_ElementType_Simple", ""), 0);
            cmbWWPFormElementType.addItem("2", context.GetMessage( "WWP_DF_ElementType_Container", ""), 0);
            cmbWWPFormElementType.addItem("3", context.GetMessage( "WWP_DF_ElementType_ElementsRepeater", ""), 0);
            cmbWWPFormElementType.addItem("4", context.GetMessage( "WWP_DF_ElementType_Label", ""), 0);
            cmbWWPFormElementType.addItem("5", context.GetMessage( "WWP_DF_ElementType_Step", ""), 0);
            if ( cmbWWPFormElementType.ItemCount > 0 )
            {
               A217WWPFormElementType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A217WWPFormElementType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            }
         }
         /* ComboBox */
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementType,(string)cmbWWPFormElementType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A217WWPFormElementType), 1, 0)),(short)1,(string)cmbWWPFormElementType_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementType.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A217WWPFormElementType), 1, 0));
         AssignProp("", false, cmbWWPFormElementType_Internalname, "Values", (string)(cmbWWPFormElementType.ToJavascriptSource()), !bGXsfl_52_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementOrderIndex_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtWWPFormElementOrderIndex_Enabled!=0) ? context.localUtil.Format( (decimal)(A212WWPFormElementOrderIndex), "ZZZ9") : context.localUtil.Format( (decimal)(A212WWPFormElementOrderIndex), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,57);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementOrderIndex_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementOrderIndex_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_52_idx + "',52)\"";
         if ( ( cmbWWPFormElementDataType.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "WWPFORMELEMENTDATATYPE_" + sGXsfl_52_idx;
            cmbWWPFormElementDataType.Name = GXCCtl;
            cmbWWPFormElementDataType.WebTags = "";
            cmbWWPFormElementDataType.addItem("1", context.GetMessage( "WWP_DF_DataType_Boolean", ""), 0);
            cmbWWPFormElementDataType.addItem("2", context.GetMessage( "WWP_DF_DataType_Character", ""), 0);
            cmbWWPFormElementDataType.addItem("3", context.GetMessage( "WWP_DF_DataType_Numeric", ""), 0);
            cmbWWPFormElementDataType.addItem("4", context.GetMessage( "WWP_DF_DataType_Date", ""), 0);
            cmbWWPFormElementDataType.addItem("5", context.GetMessage( "WWP_DF_DataType_Datetime", ""), 0);
            cmbWWPFormElementDataType.addItem("6", context.GetMessage( "WWP_DF_DataType_Password", ""), 0);
            cmbWWPFormElementDataType.addItem("7", context.GetMessage( "WWP_DF_DataType_Email", ""), 0);
            cmbWWPFormElementDataType.addItem("8", context.GetMessage( "WWP_DF_DataType_Url", ""), 0);
            cmbWWPFormElementDataType.addItem("9", context.GetMessage( "WWP_DF_DataType_File", ""), 0);
            cmbWWPFormElementDataType.addItem("10", context.GetMessage( "WWP_DF_DataType_Image", ""), 0);
            if ( cmbWWPFormElementDataType.ItemCount > 0 )
            {
               A218WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementDataType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A218WWPFormElementDataType), 2, 0))), "."), 18, MidpointRounding.ToEven));
            }
         }
         /* ComboBox */
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementDataType,(string)cmbWWPFormElementDataType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A218WWPFormElementDataType), 2, 0)),(short)1,(string)cmbWWPFormElementDataType_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementDataType.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementDataType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A218WWPFormElementDataType), 2, 0));
         AssignProp("", false, cmbWWPFormElementDataType_Internalname, "Values", (string)(cmbWWPFormElementDataType.ToJavascriptSource()), !bGXsfl_52_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementParentId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtWWPFormElementParentId_Enabled!=0) ? context.localUtil.Format( (decimal)(A211WWPFormElementParentId), "ZZZ9") : context.localUtil.Format( (decimal)(A211WWPFormElementParentId), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementParentId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementParentId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementParentName_Internalname,(string)A228WWPFormElementParentName,(string)A228WWPFormElementParentName,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementParentName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementParentName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)52,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_52_idx + "',52)\"";
         GXCCtl = "WWPFORMELEMENTPARENTTYPE_" + sGXsfl_52_idx;
         cmbWWPFormElementParentType.Name = GXCCtl;
         cmbWWPFormElementParentType.WebTags = "";
         cmbWWPFormElementParentType.addItem("1", context.GetMessage( "WWP_DF_ElementType_Simple", ""), 0);
         cmbWWPFormElementParentType.addItem("2", context.GetMessage( "WWP_DF_ElementType_Container", ""), 0);
         cmbWWPFormElementParentType.addItem("3", context.GetMessage( "WWP_DF_ElementType_ElementsRepeater", ""), 0);
         cmbWWPFormElementParentType.addItem("4", context.GetMessage( "WWP_DF_ElementType_Label", ""), 0);
         cmbWWPFormElementParentType.addItem("5", context.GetMessage( "WWP_DF_ElementType_Step", ""), 0);
         if ( cmbWWPFormElementParentType.ItemCount > 0 )
         {
            A230WWPFormElementParentType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementParentType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* ComboBox */
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementParentType,(string)cmbWWPFormElementParentType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0)),(short)1,(string)cmbWWPFormElementParentType_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementParentType.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementParentType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0));
         AssignProp("", false, cmbWWPFormElementParentType_Internalname, "Values", (string)(cmbWWPFormElementParentType.ToJavascriptSource()), !bGXsfl_52_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementMetadata_Internalname,(string)A236WWPFormElementMetadata,(string)A236WWPFormElementMetadata,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementMetadata_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementMetadata_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)52,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_52_idx + "',52)\"";
         GXCCtl = "WWPFORMELEMENTCAPTION_" + sGXsfl_52_idx;
         cmbWWPFormElementCaption.Name = GXCCtl;
         cmbWWPFormElementCaption.WebTags = "";
         cmbWWPFormElementCaption.addItem("1", context.GetMessage( "WWP_DF_ElementCaptionType_Label", ""), 0);
         cmbWWPFormElementCaption.addItem("2", context.GetMessage( "WWP_DF_ElementCaptionType_Title", ""), 0);
         cmbWWPFormElementCaption.addItem("3", context.GetMessage( "WWP_DF_ElementCaptionType_None", ""), 0);
         if ( cmbWWPFormElementCaption.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A237WWPFormElementCaption) )
            {
               A237WWPFormElementCaption = 1;
            }
         }
         /* ComboBox */
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementCaption,(string)cmbWWPFormElementCaption_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A237WWPFormElementCaption), 1, 0)),(short)1,(string)cmbWWPFormElementCaption_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementCaption.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementCaption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A237WWPFormElementCaption), 1, 0));
         AssignProp("", false, cmbWWPFormElementCaption_Internalname, "Values", (string)(cmbWWPFormElementCaption.ToJavascriptSource()), !bGXsfl_52_Refreshing);
         ajax_sending_grid_row(Gridlevel_elementRow);
         send_integrity_lvl_hashes1G41( ) ;
         GXCCtl = "Z210WWPFormElementId_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z237WWPFormElementCaption_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z237WWPFormElementCaption), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z217WWPFormElementType_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z217WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z212WWPFormElementOrderIndex_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z218WWPFormElementDataType_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z218WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z213WWPFormElementReferenceId_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z213WWPFormElementReferenceId);
         GXCCtl = "Z238WWPFormElementExcludeFromExpor_" + sGXsfl_52_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z238WWPFormElementExcludeFromExpor);
         GXCCtl = "Z211WWPFormElementParentId_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_41_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_41), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_41_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_41), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_41_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_41), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMELEMENTID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMELEMENTTITLE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMELEMENTTYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementType.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMELEMENTDATATYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMELEMENTPARENTID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMELEMENTMETADATA_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMELEMENTCAPTION_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_elementContainer.AddRow(Gridlevel_elementRow);
      }

      protected void ReadRow1G41( )
      {
         nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
         SubsflControlProps_5241( ) ;
         edtWWPFormElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTID_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementTitle_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTTITLE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementReferenceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbWWPFormElementType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTTYPE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementOrderIndex_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbWWPFormElementDataType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTDATATYPE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementParentId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTPARENTID_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementParentName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbWWPFormElementParentType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementMetadata_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTMETADATA_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbWWPFormElementCaption.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPFORMELEMENTCAPTION_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_52_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormElementId_Internalname;
            wbErr = true;
            A210WWPFormElementId = 0;
         }
         else
         {
            A210WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormElementId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A229WWPFormElementTitle = cgiGet( edtWWPFormElementTitle_Internalname);
         A213WWPFormElementReferenceId = cgiGet( edtWWPFormElementReferenceId_Internalname);
         cmbWWPFormElementType.Name = cmbWWPFormElementType_Internalname;
         cmbWWPFormElementType.CurrentValue = cgiGet( cmbWWPFormElementType_Internalname);
         A217WWPFormElementType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormElementType_Internalname), "."), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementOrderIndex_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementOrderIndex_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "WWPFORMELEMENTORDERINDEX_" + sGXsfl_52_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormElementOrderIndex_Internalname;
            wbErr = true;
            A212WWPFormElementOrderIndex = 0;
         }
         else
         {
            A212WWPFormElementOrderIndex = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormElementOrderIndex_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         cmbWWPFormElementDataType.Name = cmbWWPFormElementDataType_Internalname;
         cmbWWPFormElementDataType.CurrentValue = cgiGet( cmbWWPFormElementDataType_Internalname);
         A218WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormElementDataType_Internalname), "."), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementParentId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementParentId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "WWPFORMELEMENTPARENTID_" + sGXsfl_52_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormElementParentId_Internalname;
            wbErr = true;
            A211WWPFormElementParentId = 0;
            n211WWPFormElementParentId = false;
         }
         else
         {
            A211WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormElementParentId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n211WWPFormElementParentId = false;
         }
         n211WWPFormElementParentId = ((0==A211WWPFormElementParentId) ? true : false);
         A228WWPFormElementParentName = cgiGet( edtWWPFormElementParentName_Internalname);
         cmbWWPFormElementParentType.Name = cmbWWPFormElementParentType_Internalname;
         cmbWWPFormElementParentType.CurrentValue = cgiGet( cmbWWPFormElementParentType_Internalname);
         A230WWPFormElementParentType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormElementParentType_Internalname), "."), 18, MidpointRounding.ToEven));
         A236WWPFormElementMetadata = cgiGet( edtWWPFormElementMetadata_Internalname);
         cmbWWPFormElementCaption.Name = cmbWWPFormElementCaption_Internalname;
         cmbWWPFormElementCaption.CurrentValue = cgiGet( cmbWWPFormElementCaption_Internalname);
         A237WWPFormElementCaption = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormElementCaption_Internalname), "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z210WWPFormElementId_" + sGXsfl_52_idx;
         Z210WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z237WWPFormElementCaption_" + sGXsfl_52_idx;
         Z237WWPFormElementCaption = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z217WWPFormElementType_" + sGXsfl_52_idx;
         Z217WWPFormElementType = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z212WWPFormElementOrderIndex_" + sGXsfl_52_idx;
         Z212WWPFormElementOrderIndex = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z218WWPFormElementDataType_" + sGXsfl_52_idx;
         Z218WWPFormElementDataType = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z213WWPFormElementReferenceId_" + sGXsfl_52_idx;
         Z213WWPFormElementReferenceId = cgiGet( GXCCtl);
         GXCCtl = "Z238WWPFormElementExcludeFromExpor_" + sGXsfl_52_idx;
         Z238WWPFormElementExcludeFromExpor = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "Z211WWPFormElementParentId_" + sGXsfl_52_idx;
         Z211WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n211WWPFormElementParentId = ((0==A211WWPFormElementParentId) ? true : false);
         GXCCtl = "Z238WWPFormElementExcludeFromExpor_" + sGXsfl_52_idx;
         A238WWPFormElementExcludeFromExpor = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "nRcdDeleted_41_" + sGXsfl_52_idx;
         nRcdDeleted_41 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_41_" + sGXsfl_52_idx;
         nRcdExists_41 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_41_" + sGXsfl_52_idx;
         nIsMod_41 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtWWPFormElementId_Enabled = edtWWPFormElementId_Enabled;
      }

      protected void ConfirmValues1G0( )
      {
         nGXsfl_52_idx = 0;
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
         SubsflControlProps_5241( ) ;
         while ( nGXsfl_52_idx < nRC_GXsfl_52 )
         {
            nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
            sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
            SubsflControlProps_5241( ) ;
            ChangePostValue( "Z210WWPFormElementId_"+sGXsfl_52_idx, cgiGet( "ZT_"+"Z210WWPFormElementId_"+sGXsfl_52_idx)) ;
            DeletePostValue( "ZT_"+"Z210WWPFormElementId_"+sGXsfl_52_idx) ;
            ChangePostValue( "Z237WWPFormElementCaption_"+sGXsfl_52_idx, cgiGet( "ZT_"+"Z237WWPFormElementCaption_"+sGXsfl_52_idx)) ;
            DeletePostValue( "ZT_"+"Z237WWPFormElementCaption_"+sGXsfl_52_idx) ;
            ChangePostValue( "Z217WWPFormElementType_"+sGXsfl_52_idx, cgiGet( "ZT_"+"Z217WWPFormElementType_"+sGXsfl_52_idx)) ;
            DeletePostValue( "ZT_"+"Z217WWPFormElementType_"+sGXsfl_52_idx) ;
            ChangePostValue( "Z212WWPFormElementOrderIndex_"+sGXsfl_52_idx, cgiGet( "ZT_"+"Z212WWPFormElementOrderIndex_"+sGXsfl_52_idx)) ;
            DeletePostValue( "ZT_"+"Z212WWPFormElementOrderIndex_"+sGXsfl_52_idx) ;
            ChangePostValue( "Z218WWPFormElementDataType_"+sGXsfl_52_idx, cgiGet( "ZT_"+"Z218WWPFormElementDataType_"+sGXsfl_52_idx)) ;
            DeletePostValue( "ZT_"+"Z218WWPFormElementDataType_"+sGXsfl_52_idx) ;
            ChangePostValue( "Z213WWPFormElementReferenceId_"+sGXsfl_52_idx, cgiGet( "ZT_"+"Z213WWPFormElementReferenceId_"+sGXsfl_52_idx)) ;
            DeletePostValue( "ZT_"+"Z213WWPFormElementReferenceId_"+sGXsfl_52_idx) ;
            ChangePostValue( "Z238WWPFormElementExcludeFromExpor_"+sGXsfl_52_idx, cgiGet( "ZT_"+"Z238WWPFormElementExcludeFromExpor_"+sGXsfl_52_idx)) ;
            DeletePostValue( "ZT_"+"Z238WWPFormElementExcludeFromExpor_"+sGXsfl_52_idx) ;
            ChangePostValue( "Z211WWPFormElementParentId_"+sGXsfl_52_idx, cgiGet( "ZT_"+"Z211WWPFormElementParentId_"+sGXsfl_52_idx)) ;
            DeletePostValue( "ZT_"+"Z211WWPFormElementParentId_"+sGXsfl_52_idx) ;
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("uform.aspx") +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"UForm");
         forbiddenHiddens.Add("WWPFormResume", context.localUtil.Format( (decimal)(A216WWPFormResume), "9"));
         forbiddenHiddens.Add("WWPFormInstantiated", StringUtil.BoolToStr( A234WWPFormInstantiated));
         forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A240WWPFormType), "9"));
         forbiddenHiddens.Add("WWPFormSectionRefElements", StringUtil.RTrim( context.localUtil.Format( A241WWPFormSectionRefElements, "")));
         forbiddenHiddens.Add("WWPFormIsForDynamicValidations", StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("uform:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z206WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z207WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z208WWPFormReferenceName", Z208WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "Z209WWPFormTitle", Z209WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "Z231WWPFormDate", context.localUtil.TToC( Z231WWPFormDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z232WWPFormIsWizard", Z232WWPFormIsWizard);
         GxWebStd.gx_hidden_field( context, "Z216WWPFormResume", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z216WWPFormResume), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z234WWPFormInstantiated", Z234WWPFormInstantiated);
         GxWebStd.gx_hidden_field( context, "Z240WWPFormType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z240WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z241WWPFormSectionRefElements", Z241WWPFormSectionRefElements);
         GxWebStd.gx_boolean_hidden_field( context, "Z242WWPFormIsForDynamicValidations", Z242WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_52", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_52_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMLATESTVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMRESUME", StringUtil.LTrim( StringUtil.NToC( (decimal)(A216WWPFormResume), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMRESUMEMESSAGE", A235WWPFormResumeMessage);
         GxWebStd.gx_hidden_field( context, "WWPFORMVALIDATIONS", A233WWPFormValidations);
         GxWebStd.gx_boolean_hidden_field( context, "WWPFORMINSTANTIATED", A234WWPFormInstantiated);
         GxWebStd.gx_hidden_field( context, "WWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A240WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMSECTIONREFELEMENTS", A241WWPFormSectionRefElements);
         GxWebStd.gx_boolean_hidden_field( context, "WWPFORMISFORDYNAMICVALIDATIONS", A242WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "WWPFORMELEMENTEXCLUDEFROMEXPOR", A238WWPFormElementExcludeFromExpor);
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
         return formatLink("uform.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "UForm" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "General Dynamic Form", "") ;
      }

      protected void InitializeNonKey1G40( )
      {
         A219WWPFormLatestVersionNumber = 0;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         A208WWPFormReferenceName = "";
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         A209WWPFormTitle = "";
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A232WWPFormIsWizard = false;
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         A216WWPFormResume = 0;
         AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         A235WWPFormResumeMessage = "";
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         A233WWPFormValidations = "";
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         A234WWPFormInstantiated = false;
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         A240WWPFormType = 0;
         AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         A241WWPFormSectionRefElements = "";
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         A242WWPFormIsForDynamicValidations = false;
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         Z208WWPFormReferenceName = "";
         Z209WWPFormTitle = "";
         Z231WWPFormDate = (DateTime)(DateTime.MinValue);
         Z232WWPFormIsWizard = false;
         Z216WWPFormResume = 0;
         Z234WWPFormInstantiated = false;
         Z240WWPFormType = 0;
         Z241WWPFormSectionRefElements = "";
         Z242WWPFormIsForDynamicValidations = false;
      }

      protected void InitAll1G40( )
      {
         A206WWPFormId = 0;
         AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
         A207WWPFormVersionNumber = 0;
         AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         InitializeNonKey1G40( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1G41( )
      {
         A229WWPFormElementTitle = "";
         A217WWPFormElementType = 0;
         A212WWPFormElementOrderIndex = 0;
         A218WWPFormElementDataType = 0;
         A211WWPFormElementParentId = 0;
         n211WWPFormElementParentId = false;
         A228WWPFormElementParentName = "";
         A230WWPFormElementParentType = 0;
         A236WWPFormElementMetadata = "";
         A213WWPFormElementReferenceId = "";
         A238WWPFormElementExcludeFromExpor = false;
         AssignAttri("", false, "A238WWPFormElementExcludeFromExpor", A238WWPFormElementExcludeFromExpor);
         A237WWPFormElementCaption = 1;
         Z237WWPFormElementCaption = 0;
         Z217WWPFormElementType = 0;
         Z212WWPFormElementOrderIndex = 0;
         Z218WWPFormElementDataType = 0;
         Z213WWPFormElementReferenceId = "";
         Z238WWPFormElementExcludeFromExpor = false;
         Z211WWPFormElementParentId = 0;
      }

      protected void InitAll1G41( )
      {
         A210WWPFormElementId = 0;
         InitializeNonKey1G41( ) ;
      }

      protected void StandaloneModalInsert1G41( )
      {
         A237WWPFormElementCaption = i237WWPFormElementCaption;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212513324", true, true);
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
         context.AddJavascriptSource("uform.js", "?20257212513325", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties41( )
      {
         edtWWPFormElementId_Enabled = defedtWWPFormElementId_Enabled;
         AssignProp("", false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
      }

      protected void StartGridControl52( )
      {
         Gridlevel_elementContainer.AddObjectProperty("GridName", "Gridlevel_element");
         Gridlevel_elementContainer.AddObjectProperty("Header", subGridlevel_element_Header);
         Gridlevel_elementContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_elementContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_elementContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A229WWPFormElementTitle));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A213WWPFormElementReferenceId));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A217WWPFormElementType), 1, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementType.Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A212WWPFormElementOrderIndex), 4, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A218WWPFormElementDataType), 2, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A228WWPFormElementParentName));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A230WWPFormElementParentType), 1, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A236WWPFormElementMetadata));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A237WWPFormElementCaption), 1, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Selectedindex), 4, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Allowselection), 1, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Allowhovering), 1, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtWWPFormId_Internalname = "WWPFORMID";
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER";
         edtWWPFormDate_Internalname = "WWPFORMDATE";
         chkWWPFormIsWizard_Internalname = "WWPFORMISWIZARD";
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME";
         edtWWPFormTitle_Internalname = "WWPFORMTITLE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         edtWWPFormElementId_Internalname = "WWPFORMELEMENTID";
         edtWWPFormElementTitle_Internalname = "WWPFORMELEMENTTITLE";
         edtWWPFormElementReferenceId_Internalname = "WWPFORMELEMENTREFERENCEID";
         cmbWWPFormElementType_Internalname = "WWPFORMELEMENTTYPE";
         edtWWPFormElementOrderIndex_Internalname = "WWPFORMELEMENTORDERINDEX";
         cmbWWPFormElementDataType_Internalname = "WWPFORMELEMENTDATATYPE";
         edtWWPFormElementParentId_Internalname = "WWPFORMELEMENTPARENTID";
         edtWWPFormElementParentName_Internalname = "WWPFORMELEMENTPARENTNAME";
         cmbWWPFormElementParentType_Internalname = "WWPFORMELEMENTPARENTTYPE";
         edtWWPFormElementMetadata_Internalname = "WWPFORMELEMENTMETADATA";
         cmbWWPFormElementCaption_Internalname = "WWPFORMELEMENTCAPTION";
         divTableleaflevel_element_Internalname = "TABLELEAFLEVEL_ELEMENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_element_Internalname = "GRIDLEVEL_ELEMENT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_element_Allowcollapsing = 0;
         subGridlevel_element_Allowselection = 0;
         subGridlevel_element_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "General Dynamic Form", "");
         cmbWWPFormElementCaption_Jsonclick = "";
         edtWWPFormElementMetadata_Jsonclick = "";
         cmbWWPFormElementParentType_Jsonclick = "";
         edtWWPFormElementParentName_Jsonclick = "";
         edtWWPFormElementParentId_Jsonclick = "";
         cmbWWPFormElementDataType_Jsonclick = "";
         edtWWPFormElementOrderIndex_Jsonclick = "";
         cmbWWPFormElementType_Jsonclick = "";
         edtWWPFormElementReferenceId_Jsonclick = "";
         edtWWPFormElementTitle_Jsonclick = "";
         edtWWPFormElementId_Jsonclick = "";
         subGridlevel_element_Class = "WorkWith";
         subGridlevel_element_Backcolorstyle = 0;
         cmbWWPFormElementCaption.Enabled = 1;
         edtWWPFormElementMetadata_Enabled = 1;
         cmbWWPFormElementParentType.Enabled = 0;
         edtWWPFormElementParentName_Enabled = 0;
         edtWWPFormElementParentId_Enabled = 1;
         cmbWWPFormElementDataType.Enabled = 1;
         edtWWPFormElementOrderIndex_Enabled = 1;
         cmbWWPFormElementType.Enabled = 1;
         edtWWPFormElementReferenceId_Enabled = 1;
         edtWWPFormElementTitle_Enabled = 1;
         edtWWPFormElementId_Enabled = 1;
         bttBtntrn_delete_Enabled = 1;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtWWPFormTitle_Jsonclick = "";
         edtWWPFormTitle_Enabled = 1;
         edtWWPFormReferenceName_Jsonclick = "";
         edtWWPFormReferenceName_Enabled = 1;
         chkWWPFormIsWizard.Enabled = 1;
         edtWWPFormDate_Jsonclick = "";
         edtWWPFormDate_Enabled = 1;
         edtWWPFormVersionNumber_Jsonclick = "";
         edtWWPFormVersionNumber_Enabled = 1;
         edtWWPFormId_Jsonclick = "";
         edtWWPFormId_Enabled = 1;
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

      protected void GX1ASAWWPFORMLATESTVERSIONNUMBER1G40( short A206WWPFormId )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_element_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_5241( ) ;
         while ( nGXsfl_52_idx <= nRC_GXsfl_52 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1G41( ) ;
            standaloneModal1G41( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1G41( ) ;
            nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
            sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
            SubsflControlProps_5241( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_elementContainer)) ;
         /* End function gxnrGridlevel_element_newrow */
      }

      protected void init_web_controls( )
      {
         chkWWPFormIsWizard.Name = "WWPFORMISWIZARD";
         chkWWPFormIsWizard.WebTags = "";
         chkWWPFormIsWizard.Caption = context.GetMessage( "Is Wizard", "");
         AssignProp("", false, chkWWPFormIsWizard_Internalname, "TitleCaption", chkWWPFormIsWizard.Caption, true);
         chkWWPFormIsWizard.CheckedValue = "false";
         A232WWPFormIsWizard = StringUtil.StrToBool( StringUtil.BoolToStr( A232WWPFormIsWizard));
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         GXCCtl = "WWPFORMELEMENTTYPE_" + sGXsfl_52_idx;
         cmbWWPFormElementType.Name = GXCCtl;
         cmbWWPFormElementType.WebTags = "";
         cmbWWPFormElementType.addItem("1", context.GetMessage( "WWP_DF_ElementType_Simple", ""), 0);
         cmbWWPFormElementType.addItem("2", context.GetMessage( "WWP_DF_ElementType_Container", ""), 0);
         cmbWWPFormElementType.addItem("3", context.GetMessage( "WWP_DF_ElementType_ElementsRepeater", ""), 0);
         cmbWWPFormElementType.addItem("4", context.GetMessage( "WWP_DF_ElementType_Label", ""), 0);
         cmbWWPFormElementType.addItem("5", context.GetMessage( "WWP_DF_ElementType_Step", ""), 0);
         if ( cmbWWPFormElementType.ItemCount > 0 )
         {
            A217WWPFormElementType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A217WWPFormElementType), 1, 0))), "."), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "WWPFORMELEMENTDATATYPE_" + sGXsfl_52_idx;
         cmbWWPFormElementDataType.Name = GXCCtl;
         cmbWWPFormElementDataType.WebTags = "";
         cmbWWPFormElementDataType.addItem("1", context.GetMessage( "WWP_DF_DataType_Boolean", ""), 0);
         cmbWWPFormElementDataType.addItem("2", context.GetMessage( "WWP_DF_DataType_Character", ""), 0);
         cmbWWPFormElementDataType.addItem("3", context.GetMessage( "WWP_DF_DataType_Numeric", ""), 0);
         cmbWWPFormElementDataType.addItem("4", context.GetMessage( "WWP_DF_DataType_Date", ""), 0);
         cmbWWPFormElementDataType.addItem("5", context.GetMessage( "WWP_DF_DataType_Datetime", ""), 0);
         cmbWWPFormElementDataType.addItem("6", context.GetMessage( "WWP_DF_DataType_Password", ""), 0);
         cmbWWPFormElementDataType.addItem("7", context.GetMessage( "WWP_DF_DataType_Email", ""), 0);
         cmbWWPFormElementDataType.addItem("8", context.GetMessage( "WWP_DF_DataType_Url", ""), 0);
         cmbWWPFormElementDataType.addItem("9", context.GetMessage( "WWP_DF_DataType_File", ""), 0);
         cmbWWPFormElementDataType.addItem("10", context.GetMessage( "WWP_DF_DataType_Image", ""), 0);
         if ( cmbWWPFormElementDataType.ItemCount > 0 )
         {
            A218WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementDataType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A218WWPFormElementDataType), 2, 0))), "."), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "WWPFORMELEMENTPARENTTYPE_" + sGXsfl_52_idx;
         cmbWWPFormElementParentType.Name = GXCCtl;
         cmbWWPFormElementParentType.WebTags = "";
         cmbWWPFormElementParentType.addItem("1", context.GetMessage( "WWP_DF_ElementType_Simple", ""), 0);
         cmbWWPFormElementParentType.addItem("2", context.GetMessage( "WWP_DF_ElementType_Container", ""), 0);
         cmbWWPFormElementParentType.addItem("3", context.GetMessage( "WWP_DF_ElementType_ElementsRepeater", ""), 0);
         cmbWWPFormElementParentType.addItem("4", context.GetMessage( "WWP_DF_ElementType_Label", ""), 0);
         cmbWWPFormElementParentType.addItem("5", context.GetMessage( "WWP_DF_ElementType_Step", ""), 0);
         if ( cmbWWPFormElementParentType.ItemCount > 0 )
         {
            A230WWPFormElementParentType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementParentType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0))), "."), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "WWPFORMELEMENTCAPTION_" + sGXsfl_52_idx;
         cmbWWPFormElementCaption.Name = GXCCtl;
         cmbWWPFormElementCaption.WebTags = "";
         cmbWWPFormElementCaption.addItem("1", context.GetMessage( "WWP_DF_ElementCaptionType_Label", ""), 0);
         cmbWWPFormElementCaption.addItem("2", context.GetMessage( "WWP_DF_ElementCaptionType_Title", ""), 0);
         cmbWWPFormElementCaption.addItem("3", context.GetMessage( "WWP_DF_ElementCaptionType_None", ""), 0);
         if ( cmbWWPFormElementCaption.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A237WWPFormElementCaption) )
            {
               A237WWPFormElementCaption = 1;
            }
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPFormDate_Internalname;
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

      public void Valid_Wwpformid( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", "")));
      }

      public void Valid_Wwpformversionnumber( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A232WWPFormIsWizard = StringUtil.StrToBool( StringUtil.BoolToStr( A232WWPFormIsWizard));
         /*  Sending validation outputs */
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         AssignAttri("", false, "A216WWPFormResume", StringUtil.LTrim( StringUtil.NToC( (decimal)(A216WWPFormResume), 1, 0, ".", "")));
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         AssignAttri("", false, "A240WWPFormType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A240WWPFormType), 1, 0, ".", "")));
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z206WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z206WWPFormId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z207WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z207WWPFormVersionNumber), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z208WWPFormReferenceName", Z208WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "Z209WWPFormTitle", Z209WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "Z231WWPFormDate", context.localUtil.TToC( Z231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z232WWPFormIsWizard", StringUtil.BoolToStr( Z232WWPFormIsWizard));
         GxWebStd.gx_hidden_field( context, "Z216WWPFormResume", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z216WWPFormResume), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z235WWPFormResumeMessage", Z235WWPFormResumeMessage);
         GxWebStd.gx_hidden_field( context, "Z233WWPFormValidations", Z233WWPFormValidations);
         GxWebStd.gx_hidden_field( context, "Z234WWPFormInstantiated", StringUtil.BoolToStr( Z234WWPFormInstantiated));
         GxWebStd.gx_hidden_field( context, "Z240WWPFormType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z240WWPFormType), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z241WWPFormSectionRefElements", Z241WWPFormSectionRefElements);
         GxWebStd.gx_hidden_field( context, "Z242WWPFormIsForDynamicValidations", StringUtil.BoolToStr( Z242WWPFormIsForDynamicValidations));
         GxWebStd.gx_hidden_field( context, "Z219WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z219WWPFormLatestVersionNumber), 4, 0, ".", "")));
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpformreferencename( )
      {
         if ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  A206WWPFormId,  A208WWPFormReferenceName) )
         {
            GX_msglist.addItem(context.GetMessage( "WWP_DF_ReferenceMustBeUnique", ""), 1, "WWPFORMREFERENCENAME");
            AnyError = 1;
            GX_FocusControl = edtWWPFormReferenceName_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Wwpformelementparentid( )
      {
         n211WWPFormElementParentId = false;
         A230WWPFormElementParentType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementParentType.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormElementParentType.CurrentValue = StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0);
         /* Using cursor T001G26 */
         pr_default.execute(24, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) || (0==A211WWPFormElementParentId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWPForm Element Parent", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMELEMENTPARENTID");
               AnyError = 1;
               GX_FocusControl = edtWWPFormElementParentId_Internalname;
            }
         }
         A228WWPFormElementParentName = T001G26_A228WWPFormElementParentName[0];
         A230WWPFormElementParentType = T001G26_A230WWPFormElementParentType[0];
         cmbWWPFormElementParentType.CurrentValue = StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0);
         pr_default.close(24);
         dynload_actions( ) ;
         if ( cmbWWPFormElementParentType.ItemCount > 0 )
         {
            A230WWPFormElementParentType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementParentType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPFormElementParentType.CurrentValue = StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormElementParentType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A228WWPFormElementParentName", A228WWPFormElementParentName);
         AssignAttri("", false, "A230WWPFormElementParentType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A230WWPFormElementParentType), 1, 0, ".", "")));
         cmbWWPFormElementParentType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0));
         AssignProp("", false, cmbWWPFormElementParentType_Internalname, "Values", cmbWWPFormElementParentType.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A241WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121G2","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("VALID_WWPFORMID",""","oparms":[{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"},{"av":"A241WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER",""","oparms":[{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A231WWPFormDate","fld":"WWPFORMDATE","pic":"99/99/99 99:99"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A235WWPFormResumeMessage","fld":"WWPFORMRESUMEMESSAGE"},{"av":"A233WWPFormValidations","fld":"WWPFORMVALIDATIONS"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A241WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"},{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z206WWPFormId"},{"av":"Z207WWPFormVersionNumber"},{"av":"Z208WWPFormReferenceName"},{"av":"Z209WWPFormTitle"},{"av":"Z231WWPFormDate"},{"av":"Z232WWPFormIsWizard"},{"av":"Z216WWPFormResume"},{"av":"Z235WWPFormResumeMessage"},{"av":"Z233WWPFormValidations"},{"av":"Z234WWPFormInstantiated"},{"av":"Z240WWPFormType"},{"av":"Z241WWPFormSectionRefElements"},{"av":"Z242WWPFormIsForDynamicValidations"},{"av":"Z219WWPFormLatestVersionNumber"},{"ctrl":"BTNTRN_DELETE","prop":"Enabled"},{"ctrl":"BTNTRN_ENTER","prop":"Enabled"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("VALID_WWPFORMREFERENCENAME","""{"handler":"Valid_Wwpformreferencename","iparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("VALID_WWPFORMREFERENCENAME",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("VALID_WWPFORMELEMENTID","""{"handler":"Valid_Wwpformelementid","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("VALID_WWPFORMELEMENTID",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("VALID_WWPFORMELEMENTTYPE","""{"handler":"Valid_Wwpformelementtype","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("VALID_WWPFORMELEMENTTYPE",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("VALID_WWPFORMELEMENTDATATYPE","""{"handler":"Valid_Wwpformelementdatatype","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("VALID_WWPFORMELEMENTDATATYPE",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("VALID_WWPFORMELEMENTPARENTID","""{"handler":"Valid_Wwpformelementparentid","iparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"A228WWPFormElementParentName","fld":"WWPFORMELEMENTPARENTNAME"},{"av":"cmbWWPFormElementParentType"},{"av":"A230WWPFormElementParentType","fld":"WWPFORMELEMENTPARENTTYPE","pic":"9"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("VALID_WWPFORMELEMENTPARENTID",""","oparms":[{"av":"A228WWPFormElementParentName","fld":"WWPFORMELEMENTPARENTNAME"},{"av":"cmbWWPFormElementParentType"},{"av":"A230WWPFormElementParentType","fld":"WWPFORMELEMENTPARENTTYPE","pic":"9"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("VALID_WWPFORMELEMENTCAPTION","""{"handler":"Valid_Wwpformelementcaption","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("VALID_WWPFORMELEMENTCAPTION",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
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
         pr_default.close(24);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z208WWPFormReferenceName = "";
         Z209WWPFormTitle = "";
         Z231WWPFormDate = (DateTime)(DateTime.MinValue);
         Z241WWPFormSectionRefElements = "";
         Z213WWPFormElementReferenceId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         Gx_mode = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_elementContainer = new GXWebGrid( context);
         sMode41 = "";
         sStyleString = "";
         A241WWPFormSectionRefElements = "";
         A235WWPFormResumeMessage = "";
         A233WWPFormValidations = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A229WWPFormElementTitle = "";
         A213WWPFormElementReferenceId = "";
         A228WWPFormElementParentName = "";
         A236WWPFormElementMetadata = "";
         Z235WWPFormResumeMessage = "";
         Z233WWPFormValidations = "";
         T001G7_A206WWPFormId = new short[1] ;
         T001G7_A207WWPFormVersionNumber = new short[1] ;
         T001G7_A208WWPFormReferenceName = new string[] {""} ;
         T001G7_A209WWPFormTitle = new string[] {""} ;
         T001G7_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T001G7_A232WWPFormIsWizard = new bool[] {false} ;
         T001G7_A216WWPFormResume = new short[1] ;
         T001G7_A235WWPFormResumeMessage = new string[] {""} ;
         T001G7_A233WWPFormValidations = new string[] {""} ;
         T001G7_A234WWPFormInstantiated = new bool[] {false} ;
         T001G7_A240WWPFormType = new short[1] ;
         T001G7_A241WWPFormSectionRefElements = new string[] {""} ;
         T001G7_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T001G8_A206WWPFormId = new short[1] ;
         T001G8_A207WWPFormVersionNumber = new short[1] ;
         T001G6_A206WWPFormId = new short[1] ;
         T001G6_A207WWPFormVersionNumber = new short[1] ;
         T001G6_A208WWPFormReferenceName = new string[] {""} ;
         T001G6_A209WWPFormTitle = new string[] {""} ;
         T001G6_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T001G6_A232WWPFormIsWizard = new bool[] {false} ;
         T001G6_A216WWPFormResume = new short[1] ;
         T001G6_A235WWPFormResumeMessage = new string[] {""} ;
         T001G6_A233WWPFormValidations = new string[] {""} ;
         T001G6_A234WWPFormInstantiated = new bool[] {false} ;
         T001G6_A240WWPFormType = new short[1] ;
         T001G6_A241WWPFormSectionRefElements = new string[] {""} ;
         T001G6_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         sMode40 = "";
         T001G9_A206WWPFormId = new short[1] ;
         T001G9_A207WWPFormVersionNumber = new short[1] ;
         T001G10_A206WWPFormId = new short[1] ;
         T001G10_A207WWPFormVersionNumber = new short[1] ;
         T001G5_A206WWPFormId = new short[1] ;
         T001G5_A207WWPFormVersionNumber = new short[1] ;
         T001G5_A208WWPFormReferenceName = new string[] {""} ;
         T001G5_A209WWPFormTitle = new string[] {""} ;
         T001G5_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T001G5_A232WWPFormIsWizard = new bool[] {false} ;
         T001G5_A216WWPFormResume = new short[1] ;
         T001G5_A235WWPFormResumeMessage = new string[] {""} ;
         T001G5_A233WWPFormValidations = new string[] {""} ;
         T001G5_A234WWPFormInstantiated = new bool[] {false} ;
         T001G5_A240WWPFormType = new short[1] ;
         T001G5_A241WWPFormSectionRefElements = new string[] {""} ;
         T001G5_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T001G14_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         T001G14_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T001G15_A509OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         T001G15_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001G16_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T001G16_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001G16_A29LocationId = new Guid[] {Guid.Empty} ;
         T001G17_A214WWPFormInstanceId = new int[1] ;
         T001G18_A206WWPFormId = new short[1] ;
         T001G18_A207WWPFormVersionNumber = new short[1] ;
         T001G18_A211WWPFormElementParentId = new short[1] ;
         T001G18_n211WWPFormElementParentId = new bool[] {false} ;
         T001G19_A206WWPFormId = new short[1] ;
         T001G19_A207WWPFormVersionNumber = new short[1] ;
         Z229WWPFormElementTitle = "";
         Z236WWPFormElementMetadata = "";
         Z228WWPFormElementParentName = "";
         T001G20_A210WWPFormElementId = new short[1] ;
         T001G20_A237WWPFormElementCaption = new short[1] ;
         T001G20_A229WWPFormElementTitle = new string[] {""} ;
         T001G20_A217WWPFormElementType = new short[1] ;
         T001G20_A212WWPFormElementOrderIndex = new short[1] ;
         T001G20_A218WWPFormElementDataType = new short[1] ;
         T001G20_A228WWPFormElementParentName = new string[] {""} ;
         T001G20_A230WWPFormElementParentType = new short[1] ;
         T001G20_A236WWPFormElementMetadata = new string[] {""} ;
         T001G20_A213WWPFormElementReferenceId = new string[] {""} ;
         T001G20_A238WWPFormElementExcludeFromExpor = new bool[] {false} ;
         T001G20_A206WWPFormId = new short[1] ;
         T001G20_A207WWPFormVersionNumber = new short[1] ;
         T001G20_A211WWPFormElementParentId = new short[1] ;
         T001G20_n211WWPFormElementParentId = new bool[] {false} ;
         T001G4_A228WWPFormElementParentName = new string[] {""} ;
         T001G4_A230WWPFormElementParentType = new short[1] ;
         T001G21_A228WWPFormElementParentName = new string[] {""} ;
         T001G21_A230WWPFormElementParentType = new short[1] ;
         T001G22_A206WWPFormId = new short[1] ;
         T001G22_A207WWPFormVersionNumber = new short[1] ;
         T001G22_A210WWPFormElementId = new short[1] ;
         T001G3_A210WWPFormElementId = new short[1] ;
         T001G3_A237WWPFormElementCaption = new short[1] ;
         T001G3_A229WWPFormElementTitle = new string[] {""} ;
         T001G3_A217WWPFormElementType = new short[1] ;
         T001G3_A212WWPFormElementOrderIndex = new short[1] ;
         T001G3_A218WWPFormElementDataType = new short[1] ;
         T001G3_A236WWPFormElementMetadata = new string[] {""} ;
         T001G3_A213WWPFormElementReferenceId = new string[] {""} ;
         T001G3_A238WWPFormElementExcludeFromExpor = new bool[] {false} ;
         T001G3_A206WWPFormId = new short[1] ;
         T001G3_A207WWPFormVersionNumber = new short[1] ;
         T001G3_A211WWPFormElementParentId = new short[1] ;
         T001G3_n211WWPFormElementParentId = new bool[] {false} ;
         T001G2_A210WWPFormElementId = new short[1] ;
         T001G2_A237WWPFormElementCaption = new short[1] ;
         T001G2_A229WWPFormElementTitle = new string[] {""} ;
         T001G2_A217WWPFormElementType = new short[1] ;
         T001G2_A212WWPFormElementOrderIndex = new short[1] ;
         T001G2_A218WWPFormElementDataType = new short[1] ;
         T001G2_A236WWPFormElementMetadata = new string[] {""} ;
         T001G2_A213WWPFormElementReferenceId = new string[] {""} ;
         T001G2_A238WWPFormElementExcludeFromExpor = new bool[] {false} ;
         T001G2_A206WWPFormId = new short[1] ;
         T001G2_A207WWPFormVersionNumber = new short[1] ;
         T001G2_A211WWPFormElementParentId = new short[1] ;
         T001G2_n211WWPFormElementParentId = new bool[] {false} ;
         T001G26_A228WWPFormElementParentName = new string[] {""} ;
         T001G26_A230WWPFormElementParentType = new short[1] ;
         T001G27_A206WWPFormId = new short[1] ;
         T001G27_A207WWPFormVersionNumber = new short[1] ;
         T001G27_A211WWPFormElementParentId = new short[1] ;
         T001G27_n211WWPFormElementParentId = new bool[] {false} ;
         T001G28_A206WWPFormId = new short[1] ;
         T001G28_A207WWPFormVersionNumber = new short[1] ;
         T001G28_A210WWPFormElementId = new short[1] ;
         Gridlevel_elementRow = new GXWebRow();
         subGridlevel_element_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_elementColumn = new GXWebColumn();
         ZZ208WWPFormReferenceName = "";
         ZZ209WWPFormTitle = "";
         ZZ231WWPFormDate = (DateTime)(DateTime.MinValue);
         ZZ235WWPFormResumeMessage = "";
         ZZ233WWPFormValidations = "";
         ZZ241WWPFormSectionRefElements = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.uform__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.uform__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.uform__default(),
            new Object[][] {
                new Object[] {
               T001G2_A210WWPFormElementId, T001G2_A237WWPFormElementCaption, T001G2_A229WWPFormElementTitle, T001G2_A217WWPFormElementType, T001G2_A212WWPFormElementOrderIndex, T001G2_A218WWPFormElementDataType, T001G2_A236WWPFormElementMetadata, T001G2_A213WWPFormElementReferenceId, T001G2_A238WWPFormElementExcludeFromExpor, T001G2_A206WWPFormId,
               T001G2_A207WWPFormVersionNumber, T001G2_A211WWPFormElementParentId, T001G2_n211WWPFormElementParentId
               }
               , new Object[] {
               T001G3_A210WWPFormElementId, T001G3_A237WWPFormElementCaption, T001G3_A229WWPFormElementTitle, T001G3_A217WWPFormElementType, T001G3_A212WWPFormElementOrderIndex, T001G3_A218WWPFormElementDataType, T001G3_A236WWPFormElementMetadata, T001G3_A213WWPFormElementReferenceId, T001G3_A238WWPFormElementExcludeFromExpor, T001G3_A206WWPFormId,
               T001G3_A207WWPFormVersionNumber, T001G3_A211WWPFormElementParentId, T001G3_n211WWPFormElementParentId
               }
               , new Object[] {
               T001G4_A228WWPFormElementParentName, T001G4_A230WWPFormElementParentType
               }
               , new Object[] {
               T001G5_A206WWPFormId, T001G5_A207WWPFormVersionNumber, T001G5_A208WWPFormReferenceName, T001G5_A209WWPFormTitle, T001G5_A231WWPFormDate, T001G5_A232WWPFormIsWizard, T001G5_A216WWPFormResume, T001G5_A235WWPFormResumeMessage, T001G5_A233WWPFormValidations, T001G5_A234WWPFormInstantiated,
               T001G5_A240WWPFormType, T001G5_A241WWPFormSectionRefElements, T001G5_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T001G6_A206WWPFormId, T001G6_A207WWPFormVersionNumber, T001G6_A208WWPFormReferenceName, T001G6_A209WWPFormTitle, T001G6_A231WWPFormDate, T001G6_A232WWPFormIsWizard, T001G6_A216WWPFormResume, T001G6_A235WWPFormResumeMessage, T001G6_A233WWPFormValidations, T001G6_A234WWPFormInstantiated,
               T001G6_A240WWPFormType, T001G6_A241WWPFormSectionRefElements, T001G6_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T001G7_A206WWPFormId, T001G7_A207WWPFormVersionNumber, T001G7_A208WWPFormReferenceName, T001G7_A209WWPFormTitle, T001G7_A231WWPFormDate, T001G7_A232WWPFormIsWizard, T001G7_A216WWPFormResume, T001G7_A235WWPFormResumeMessage, T001G7_A233WWPFormValidations, T001G7_A234WWPFormInstantiated,
               T001G7_A240WWPFormType, T001G7_A241WWPFormSectionRefElements, T001G7_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T001G8_A206WWPFormId, T001G8_A207WWPFormVersionNumber
               }
               , new Object[] {
               T001G9_A206WWPFormId, T001G9_A207WWPFormVersionNumber
               }
               , new Object[] {
               T001G10_A206WWPFormId, T001G10_A207WWPFormVersionNumber
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001G14_A616SupplierDynamicFormId, T001G14_A42SupplierGenId
               }
               , new Object[] {
               T001G15_A509OrganisationDynamicFormId, T001G15_A11OrganisationId
               }
               , new Object[] {
               T001G16_A366LocationDynamicFormId, T001G16_A11OrganisationId, T001G16_A29LocationId
               }
               , new Object[] {
               T001G17_A214WWPFormInstanceId
               }
               , new Object[] {
               T001G18_A206WWPFormId, T001G18_A207WWPFormVersionNumber, T001G18_A211WWPFormElementParentId
               }
               , new Object[] {
               T001G19_A206WWPFormId, T001G19_A207WWPFormVersionNumber
               }
               , new Object[] {
               T001G20_A210WWPFormElementId, T001G20_A237WWPFormElementCaption, T001G20_A229WWPFormElementTitle, T001G20_A217WWPFormElementType, T001G20_A212WWPFormElementOrderIndex, T001G20_A218WWPFormElementDataType, T001G20_A228WWPFormElementParentName, T001G20_A230WWPFormElementParentType, T001G20_A236WWPFormElementMetadata, T001G20_A213WWPFormElementReferenceId,
               T001G20_A238WWPFormElementExcludeFromExpor, T001G20_A206WWPFormId, T001G20_A207WWPFormVersionNumber, T001G20_A211WWPFormElementParentId, T001G20_n211WWPFormElementParentId
               }
               , new Object[] {
               T001G21_A228WWPFormElementParentName, T001G21_A230WWPFormElementParentType
               }
               , new Object[] {
               T001G22_A206WWPFormId, T001G22_A207WWPFormVersionNumber, T001G22_A210WWPFormElementId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001G26_A228WWPFormElementParentName, T001G26_A230WWPFormElementParentType
               }
               , new Object[] {
               T001G27_A206WWPFormId, T001G27_A207WWPFormVersionNumber, T001G27_A211WWPFormElementParentId
               }
               , new Object[] {
               T001G28_A206WWPFormId, T001G28_A207WWPFormVersionNumber, T001G28_A210WWPFormElementId
               }
            }
         );
         Z237WWPFormElementCaption = 1;
         A237WWPFormElementCaption = 1;
         i237WWPFormElementCaption = 1;
      }

      private short Z206WWPFormId ;
      private short Z207WWPFormVersionNumber ;
      private short Z216WWPFormResume ;
      private short Z240WWPFormType ;
      private short Z210WWPFormElementId ;
      private short Z237WWPFormElementCaption ;
      private short Z217WWPFormElementType ;
      private short Z212WWPFormElementOrderIndex ;
      private short Z218WWPFormElementDataType ;
      private short Z211WWPFormElementParentId ;
      private short nRcdDeleted_41 ;
      private short nRcdExists_41 ;
      private short nIsMod_41 ;
      private short GxWebError ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A211WWPFormElementParentId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short nBlankRcdCount41 ;
      private short RcdFound41 ;
      private short nBlankRcdUsr41 ;
      private short A216WWPFormResume ;
      private short A240WWPFormType ;
      private short A219WWPFormLatestVersionNumber ;
      private short A210WWPFormElementId ;
      private short A217WWPFormElementType ;
      private short A212WWPFormElementOrderIndex ;
      private short A218WWPFormElementDataType ;
      private short A230WWPFormElementParentType ;
      private short A237WWPFormElementCaption ;
      private short RcdFound40 ;
      private short Z230WWPFormElementParentType ;
      private short nIsDirty_41 ;
      private short subGridlevel_element_Backcolorstyle ;
      private short subGridlevel_element_Backstyle ;
      private short gxajaxcallmode ;
      private short i237WWPFormElementCaption ;
      private short subGridlevel_element_Allowselection ;
      private short subGridlevel_element_Allowhovering ;
      private short subGridlevel_element_Allowcollapsing ;
      private short subGridlevel_element_Collapsed ;
      private short Z219WWPFormLatestVersionNumber ;
      private short GXt_int1 ;
      private short ZZ206WWPFormId ;
      private short ZZ207WWPFormVersionNumber ;
      private short ZZ216WWPFormResume ;
      private short ZZ240WWPFormType ;
      private short ZZ219WWPFormLatestVersionNumber ;
      private int nRC_GXsfl_52 ;
      private int nGXsfl_52_idx=1 ;
      private int trnEnded ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormDate_Enabled ;
      private int edtWWPFormReferenceName_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtWWPFormElementId_Enabled ;
      private int edtWWPFormElementTitle_Enabled ;
      private int edtWWPFormElementReferenceId_Enabled ;
      private int edtWWPFormElementOrderIndex_Enabled ;
      private int edtWWPFormElementParentId_Enabled ;
      private int edtWWPFormElementParentName_Enabled ;
      private int edtWWPFormElementMetadata_Enabled ;
      private int fRowAdded ;
      private int subGridlevel_element_Backcolor ;
      private int subGridlevel_element_Allbackcolor ;
      private int defedtWWPFormElementId_Enabled ;
      private int idxLst ;
      private int subGridlevel_element_Selectedindex ;
      private int subGridlevel_element_Selectioncolor ;
      private int subGridlevel_element_Hoveringcolor ;
      private long GRIDLEVEL_ELEMENT_nFirstRecordOnPage ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPFormId_Internalname ;
      private string sGXsfl_52_idx="0001" ;
      private string Gx_mode ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtWWPFormId_Jsonclick ;
      private string edtWWPFormVersionNumber_Internalname ;
      private string edtWWPFormVersionNumber_Jsonclick ;
      private string edtWWPFormDate_Internalname ;
      private string edtWWPFormDate_Jsonclick ;
      private string chkWWPFormIsWizard_Internalname ;
      private string edtWWPFormReferenceName_Internalname ;
      private string edtWWPFormReferenceName_Jsonclick ;
      private string edtWWPFormTitle_Internalname ;
      private string edtWWPFormTitle_Jsonclick ;
      private string divTableleaflevel_element_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode41 ;
      private string edtWWPFormElementId_Internalname ;
      private string edtWWPFormElementTitle_Internalname ;
      private string edtWWPFormElementReferenceId_Internalname ;
      private string cmbWWPFormElementType_Internalname ;
      private string edtWWPFormElementOrderIndex_Internalname ;
      private string cmbWWPFormElementDataType_Internalname ;
      private string edtWWPFormElementParentId_Internalname ;
      private string edtWWPFormElementParentName_Internalname ;
      private string cmbWWPFormElementParentType_Internalname ;
      private string edtWWPFormElementMetadata_Internalname ;
      private string cmbWWPFormElementCaption_Internalname ;
      private string sStyleString ;
      private string subGridlevel_element_Internalname ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode40 ;
      private string sGXsfl_52_fel_idx="0001" ;
      private string subGridlevel_element_Class ;
      private string subGridlevel_element_Linesclass ;
      private string ROClassString ;
      private string edtWWPFormElementId_Jsonclick ;
      private string edtWWPFormElementTitle_Jsonclick ;
      private string edtWWPFormElementReferenceId_Jsonclick ;
      private string cmbWWPFormElementType_Jsonclick ;
      private string edtWWPFormElementOrderIndex_Jsonclick ;
      private string cmbWWPFormElementDataType_Jsonclick ;
      private string edtWWPFormElementParentId_Jsonclick ;
      private string edtWWPFormElementParentName_Jsonclick ;
      private string cmbWWPFormElementParentType_Jsonclick ;
      private string edtWWPFormElementMetadata_Jsonclick ;
      private string cmbWWPFormElementCaption_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_element_Header ;
      private DateTime Z231WWPFormDate ;
      private DateTime A231WWPFormDate ;
      private DateTime ZZ231WWPFormDate ;
      private bool Z232WWPFormIsWizard ;
      private bool Z234WWPFormInstantiated ;
      private bool Z242WWPFormIsForDynamicValidations ;
      private bool Z238WWPFormElementExcludeFromExpor ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n211WWPFormElementParentId ;
      private bool wbErr ;
      private bool A232WWPFormIsWizard ;
      private bool bGXsfl_52_Refreshing=false ;
      private bool A234WWPFormInstantiated ;
      private bool A242WWPFormIsForDynamicValidations ;
      private bool A238WWPFormElementExcludeFromExpor ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool ZZ232WWPFormIsWizard ;
      private bool ZZ234WWPFormInstantiated ;
      private bool ZZ242WWPFormIsForDynamicValidations ;
      private string A235WWPFormResumeMessage ;
      private string A233WWPFormValidations ;
      private string A229WWPFormElementTitle ;
      private string A228WWPFormElementParentName ;
      private string A236WWPFormElementMetadata ;
      private string Z235WWPFormResumeMessage ;
      private string Z233WWPFormValidations ;
      private string Z229WWPFormElementTitle ;
      private string Z236WWPFormElementMetadata ;
      private string Z228WWPFormElementParentName ;
      private string ZZ235WWPFormResumeMessage ;
      private string ZZ233WWPFormValidations ;
      private string Z208WWPFormReferenceName ;
      private string Z209WWPFormTitle ;
      private string Z241WWPFormSectionRefElements ;
      private string Z213WWPFormElementReferenceId ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string A241WWPFormSectionRefElements ;
      private string A213WWPFormElementReferenceId ;
      private string ZZ208WWPFormReferenceName ;
      private string ZZ209WWPFormTitle ;
      private string ZZ241WWPFormSectionRefElements ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_elementContainer ;
      private GXWebRow Gridlevel_elementRow ;
      private GXWebColumn Gridlevel_elementColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPFormIsWizard ;
      private GXCombobox cmbWWPFormElementType ;
      private GXCombobox cmbWWPFormElementDataType ;
      private GXCombobox cmbWWPFormElementParentType ;
      private GXCombobox cmbWWPFormElementCaption ;
      private IDataStoreProvider pr_default ;
      private short[] T001G7_A206WWPFormId ;
      private short[] T001G7_A207WWPFormVersionNumber ;
      private string[] T001G7_A208WWPFormReferenceName ;
      private string[] T001G7_A209WWPFormTitle ;
      private DateTime[] T001G7_A231WWPFormDate ;
      private bool[] T001G7_A232WWPFormIsWizard ;
      private short[] T001G7_A216WWPFormResume ;
      private string[] T001G7_A235WWPFormResumeMessage ;
      private string[] T001G7_A233WWPFormValidations ;
      private bool[] T001G7_A234WWPFormInstantiated ;
      private short[] T001G7_A240WWPFormType ;
      private string[] T001G7_A241WWPFormSectionRefElements ;
      private bool[] T001G7_A242WWPFormIsForDynamicValidations ;
      private short[] T001G8_A206WWPFormId ;
      private short[] T001G8_A207WWPFormVersionNumber ;
      private short[] T001G6_A206WWPFormId ;
      private short[] T001G6_A207WWPFormVersionNumber ;
      private string[] T001G6_A208WWPFormReferenceName ;
      private string[] T001G6_A209WWPFormTitle ;
      private DateTime[] T001G6_A231WWPFormDate ;
      private bool[] T001G6_A232WWPFormIsWizard ;
      private short[] T001G6_A216WWPFormResume ;
      private string[] T001G6_A235WWPFormResumeMessage ;
      private string[] T001G6_A233WWPFormValidations ;
      private bool[] T001G6_A234WWPFormInstantiated ;
      private short[] T001G6_A240WWPFormType ;
      private string[] T001G6_A241WWPFormSectionRefElements ;
      private bool[] T001G6_A242WWPFormIsForDynamicValidations ;
      private short[] T001G9_A206WWPFormId ;
      private short[] T001G9_A207WWPFormVersionNumber ;
      private short[] T001G10_A206WWPFormId ;
      private short[] T001G10_A207WWPFormVersionNumber ;
      private short[] T001G5_A206WWPFormId ;
      private short[] T001G5_A207WWPFormVersionNumber ;
      private string[] T001G5_A208WWPFormReferenceName ;
      private string[] T001G5_A209WWPFormTitle ;
      private DateTime[] T001G5_A231WWPFormDate ;
      private bool[] T001G5_A232WWPFormIsWizard ;
      private short[] T001G5_A216WWPFormResume ;
      private string[] T001G5_A235WWPFormResumeMessage ;
      private string[] T001G5_A233WWPFormValidations ;
      private bool[] T001G5_A234WWPFormInstantiated ;
      private short[] T001G5_A240WWPFormType ;
      private string[] T001G5_A241WWPFormSectionRefElements ;
      private bool[] T001G5_A242WWPFormIsForDynamicValidations ;
      private Guid[] T001G14_A616SupplierDynamicFormId ;
      private Guid[] T001G14_A42SupplierGenId ;
      private Guid[] T001G15_A509OrganisationDynamicFormId ;
      private Guid[] T001G15_A11OrganisationId ;
      private Guid[] T001G16_A366LocationDynamicFormId ;
      private Guid[] T001G16_A11OrganisationId ;
      private Guid[] T001G16_A29LocationId ;
      private int[] T001G17_A214WWPFormInstanceId ;
      private short[] T001G18_A206WWPFormId ;
      private short[] T001G18_A207WWPFormVersionNumber ;
      private short[] T001G18_A211WWPFormElementParentId ;
      private bool[] T001G18_n211WWPFormElementParentId ;
      private short[] T001G19_A206WWPFormId ;
      private short[] T001G19_A207WWPFormVersionNumber ;
      private short[] T001G20_A210WWPFormElementId ;
      private short[] T001G20_A237WWPFormElementCaption ;
      private string[] T001G20_A229WWPFormElementTitle ;
      private short[] T001G20_A217WWPFormElementType ;
      private short[] T001G20_A212WWPFormElementOrderIndex ;
      private short[] T001G20_A218WWPFormElementDataType ;
      private string[] T001G20_A228WWPFormElementParentName ;
      private short[] T001G20_A230WWPFormElementParentType ;
      private string[] T001G20_A236WWPFormElementMetadata ;
      private string[] T001G20_A213WWPFormElementReferenceId ;
      private bool[] T001G20_A238WWPFormElementExcludeFromExpor ;
      private short[] T001G20_A206WWPFormId ;
      private short[] T001G20_A207WWPFormVersionNumber ;
      private short[] T001G20_A211WWPFormElementParentId ;
      private bool[] T001G20_n211WWPFormElementParentId ;
      private string[] T001G4_A228WWPFormElementParentName ;
      private short[] T001G4_A230WWPFormElementParentType ;
      private string[] T001G21_A228WWPFormElementParentName ;
      private short[] T001G21_A230WWPFormElementParentType ;
      private short[] T001G22_A206WWPFormId ;
      private short[] T001G22_A207WWPFormVersionNumber ;
      private short[] T001G22_A210WWPFormElementId ;
      private short[] T001G3_A210WWPFormElementId ;
      private short[] T001G3_A237WWPFormElementCaption ;
      private string[] T001G3_A229WWPFormElementTitle ;
      private short[] T001G3_A217WWPFormElementType ;
      private short[] T001G3_A212WWPFormElementOrderIndex ;
      private short[] T001G3_A218WWPFormElementDataType ;
      private string[] T001G3_A236WWPFormElementMetadata ;
      private string[] T001G3_A213WWPFormElementReferenceId ;
      private bool[] T001G3_A238WWPFormElementExcludeFromExpor ;
      private short[] T001G3_A206WWPFormId ;
      private short[] T001G3_A207WWPFormVersionNumber ;
      private short[] T001G3_A211WWPFormElementParentId ;
      private bool[] T001G3_n211WWPFormElementParentId ;
      private short[] T001G2_A210WWPFormElementId ;
      private short[] T001G2_A237WWPFormElementCaption ;
      private string[] T001G2_A229WWPFormElementTitle ;
      private short[] T001G2_A217WWPFormElementType ;
      private short[] T001G2_A212WWPFormElementOrderIndex ;
      private short[] T001G2_A218WWPFormElementDataType ;
      private string[] T001G2_A236WWPFormElementMetadata ;
      private string[] T001G2_A213WWPFormElementReferenceId ;
      private bool[] T001G2_A238WWPFormElementExcludeFromExpor ;
      private short[] T001G2_A206WWPFormId ;
      private short[] T001G2_A207WWPFormVersionNumber ;
      private short[] T001G2_A211WWPFormElementParentId ;
      private bool[] T001G2_n211WWPFormElementParentId ;
      private string[] T001G26_A228WWPFormElementParentName ;
      private short[] T001G26_A230WWPFormElementParentType ;
      private short[] T001G27_A206WWPFormId ;
      private short[] T001G27_A207WWPFormVersionNumber ;
      private short[] T001G27_A211WWPFormElementParentId ;
      private bool[] T001G27_n211WWPFormElementParentId ;
      private short[] T001G28_A206WWPFormId ;
      private short[] T001G28_A207WWPFormVersionNumber ;
      private short[] T001G28_A210WWPFormElementId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class uform__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class uform__gam : DataStoreHelperBase, IDataStoreHelper
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

public class uform__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
      ,new UpdateCursor(def[21])
      ,new UpdateCursor(def[22])
      ,new UpdateCursor(def[23])
      ,new ForEachCursor(def[24])
      ,new ForEachCursor(def[25])
      ,new ForEachCursor(def[26])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001G2;
       prmT001G2 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT001G3;
       prmT001G3 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT001G4;
       prmT001G4 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT001G5;
       prmT001G5 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001G6;
       prmT001G6 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001G7;
       prmT001G7 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001G8;
       prmT001G8 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001G9;
       prmT001G9 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001G10;
       prmT001G10 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001G11;
       prmT001G11 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormReferenceName",GXType.VarChar,100,0) ,
       new ParDef("WWPFormTitle",GXType.VarChar,100,0) ,
       new ParDef("WWPFormDate",GXType.DateTime,8,5) ,
       new ParDef("WWPFormIsWizard",GXType.Boolean,4,0) ,
       new ParDef("WWPFormResume",GXType.Int16,1,0) ,
       new ParDef("WWPFormResumeMessage",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormValidations",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormInstantiated",GXType.Boolean,4,0) ,
       new ParDef("WWPFormType",GXType.Int16,1,0) ,
       new ParDef("WWPFormSectionRefElements",GXType.VarChar,400,0) ,
       new ParDef("WWPFormIsForDynamicValidations",GXType.Boolean,4,0)
       };
       Object[] prmT001G12;
       prmT001G12 = new Object[] {
       new ParDef("WWPFormReferenceName",GXType.VarChar,100,0) ,
       new ParDef("WWPFormTitle",GXType.VarChar,100,0) ,
       new ParDef("WWPFormDate",GXType.DateTime,8,5) ,
       new ParDef("WWPFormIsWizard",GXType.Boolean,4,0) ,
       new ParDef("WWPFormResume",GXType.Int16,1,0) ,
       new ParDef("WWPFormResumeMessage",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormValidations",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormInstantiated",GXType.Boolean,4,0) ,
       new ParDef("WWPFormType",GXType.Int16,1,0) ,
       new ParDef("WWPFormSectionRefElements",GXType.VarChar,400,0) ,
       new ParDef("WWPFormIsForDynamicValidations",GXType.Boolean,4,0) ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001G13;
       prmT001G13 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001G14;
       prmT001G14 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001G15;
       prmT001G15 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001G16;
       prmT001G16 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001G17;
       prmT001G17 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001G18;
       prmT001G18 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT001G19;
       prmT001G19 = new Object[] {
       };
       Object[] prmT001G20;
       prmT001G20 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT001G21;
       prmT001G21 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT001G22;
       prmT001G22 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT001G23;
       prmT001G23 = new Object[] {
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementCaption",GXType.Int16,1,0) ,
       new ParDef("WWPFormElementTitle",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormElementType",GXType.Int16,1,0) ,
       new ParDef("WWPFormElementOrderIndex",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementDataType",GXType.Int16,2,0) ,
       new ParDef("WWPFormElementMetadata",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormElementReferenceId",GXType.VarChar,100,0) ,
       new ParDef("WWPFormElementExcludeFromExpor",GXType.Boolean,4,0) ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT001G24;
       prmT001G24 = new Object[] {
       new ParDef("WWPFormElementCaption",GXType.Int16,1,0) ,
       new ParDef("WWPFormElementTitle",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormElementType",GXType.Int16,1,0) ,
       new ParDef("WWPFormElementOrderIndex",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementDataType",GXType.Int16,2,0) ,
       new ParDef("WWPFormElementMetadata",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormElementReferenceId",GXType.VarChar,100,0) ,
       new ParDef("WWPFormElementExcludeFromExpor",GXType.Boolean,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true} ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT001G25;
       prmT001G25 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT001G26;
       prmT001G26 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT001G27;
       prmT001G27 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT001G28;
       prmT001G28 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("T001G2", "SELECT WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExpor, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId  FOR UPDATE OF WWP_FormElement NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001G2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001G3", "SELECT WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExpor, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001G4", "SELECT WWPFormElementTitle AS WWPFormElementParentName, WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001G5", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber  FOR UPDATE OF WWP_Form NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001G5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001G6", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001G7", "SELECT TM1.WWPFormId, TM1.WWPFormVersionNumber, TM1.WWPFormReferenceName, TM1.WWPFormTitle, TM1.WWPFormDate, TM1.WWPFormIsWizard, TM1.WWPFormResume, TM1.WWPFormResumeMessage, TM1.WWPFormValidations, TM1.WWPFormInstantiated, TM1.WWPFormType, TM1.WWPFormSectionRefElements, TM1.WWPFormIsForDynamicValidations FROM WWP_Form TM1 WHERE TM1.WWPFormId = :WWPFormId and TM1.WWPFormVersionNumber = :WWPFormVersionNumber ORDER BY TM1.WWPFormId, TM1.WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G7,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001G8", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001G9", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE ( WWPFormId > :WWPFormId or WWPFormId = :WWPFormId and WWPFormVersionNumber > :WWPFormVersionNumber) ORDER BY WWPFormId, WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001G10", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE ( WWPFormId < :WWPFormId or WWPFormId = :WWPFormId and WWPFormVersionNumber < :WWPFormVersionNumber) ORDER BY WWPFormId DESC, WWPFormVersionNumber DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001G11", "SAVEPOINT gxupdate;INSERT INTO WWP_Form(WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations) VALUES(:WWPFormId, :WWPFormVersionNumber, :WWPFormReferenceName, :WWPFormTitle, :WWPFormDate, :WWPFormIsWizard, :WWPFormResume, :WWPFormResumeMessage, :WWPFormValidations, :WWPFormInstantiated, :WWPFormType, :WWPFormSectionRefElements, :WWPFormIsForDynamicValidations);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001G11)
          ,new CursorDef("T001G12", "SAVEPOINT gxupdate;UPDATE WWP_Form SET WWPFormReferenceName=:WWPFormReferenceName, WWPFormTitle=:WWPFormTitle, WWPFormDate=:WWPFormDate, WWPFormIsWizard=:WWPFormIsWizard, WWPFormResume=:WWPFormResume, WWPFormResumeMessage=:WWPFormResumeMessage, WWPFormValidations=:WWPFormValidations, WWPFormInstantiated=:WWPFormInstantiated, WWPFormType=:WWPFormType, WWPFormSectionRefElements=:WWPFormSectionRefElements, WWPFormIsForDynamicValidations=:WWPFormIsForDynamicValidations  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001G12)
          ,new CursorDef("T001G13", "SAVEPOINT gxupdate;DELETE FROM WWP_Form  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001G13)
          ,new CursorDef("T001G14", "SELECT SupplierDynamicFormId, SupplierGenId FROM Trn_SupplierDynamicForm WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001G15", "SELECT OrganisationDynamicFormId, OrganisationId FROM Trn_OrganisationDynamicForm WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G15,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001G16", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G16,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001G17", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G17,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001G18", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId AS WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G18,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001G19", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form ORDER BY WWPFormId, WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G19,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001G20", "SELECT T1.WWPFormElementId, T1.WWPFormElementCaption, T1.WWPFormElementTitle, T1.WWPFormElementType, T1.WWPFormElementOrderIndex, T1.WWPFormElementDataType, T2.WWPFormElementTitle AS WWPFormElementParentName, T2.WWPFormElementType AS WWPFormElementParentType, T1.WWPFormElementMetadata, T1.WWPFormElementReferenceId, T1.WWPFormElementExcludeFromExpor, T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementParentId AS WWPFormElementParentId FROM (WWP_FormElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementParentId) WHERE T1.WWPFormId = :WWPFormId and T1.WWPFormVersionNumber = :WWPFormVersionNumber and T1.WWPFormElementId = :WWPFormElementId ORDER BY T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G20,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001G21", "SELECT WWPFormElementTitle AS WWPFormElementParentName, WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G21,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001G22", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G22,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001G23", "SAVEPOINT gxupdate;INSERT INTO WWP_FormElement(WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExpor, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId) VALUES(:WWPFormElementId, :WWPFormElementCaption, :WWPFormElementTitle, :WWPFormElementType, :WWPFormElementOrderIndex, :WWPFormElementDataType, :WWPFormElementMetadata, :WWPFormElementReferenceId, :WWPFormElementExcludeFromExpor, :WWPFormId, :WWPFormVersionNumber, :WWPFormElementParentId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001G23)
          ,new CursorDef("T001G24", "SAVEPOINT gxupdate;UPDATE WWP_FormElement SET WWPFormElementCaption=:WWPFormElementCaption, WWPFormElementTitle=:WWPFormElementTitle, WWPFormElementType=:WWPFormElementType, WWPFormElementOrderIndex=:WWPFormElementOrderIndex, WWPFormElementDataType=:WWPFormElementDataType, WWPFormElementMetadata=:WWPFormElementMetadata, WWPFormElementReferenceId=:WWPFormElementReferenceId, WWPFormElementExcludeFromExpor=:WWPFormElementExcludeFromExpor, WWPFormElementParentId=:WWPFormElementParentId  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001G24)
          ,new CursorDef("T001G25", "SAVEPOINT gxupdate;DELETE FROM WWP_FormElement  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001G25)
          ,new CursorDef("T001G26", "SELECT WWPFormElementTitle AS WWPFormElementParentName, WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G26,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001G27", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId AS WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementParentId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G27,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001G28", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId and WWPFormVersionNumber = :WWPFormVersionNumber ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G28,11, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((short[]) buf[9])[0] = rslt.getShort(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((short[]) buf[11])[0] = rslt.getShort(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((short[]) buf[9])[0] = rslt.getShort(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((short[]) buf[11])[0] = rslt.getShort(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             return;
          case 4 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             return;
          case 5 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             return;
          case 6 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 7 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 8 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 15 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             return;
          case 16 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
          case 17 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 18 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((short[]) buf[7])[0] = rslt.getShort(8);
             ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((short[]) buf[11])[0] = rslt.getShort(12);
             ((short[]) buf[12])[0] = rslt.getShort(13);
             ((short[]) buf[13])[0] = rslt.getShort(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             return;
          case 19 :
             ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 20 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
          case 24 :
             ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 25 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
          case 26 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
    }
 }

}

}
