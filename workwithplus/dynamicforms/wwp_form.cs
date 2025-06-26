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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_form : GXWebComponent
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               nDynComponent = 1;
               sCompPrefix = GetPar( "sCompPrefix");
               sSFPrefix = GetPar( "sSFPrefix");
               Gx_mode = GetPar( "Mode");
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               AV7WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV7WWPFormId", StringUtil.LTrimStr( (decimal)(AV7WWPFormId), 4, 0));
               AV8WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV8WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV8WWPFormVersionNumber), 4, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(short)AV7WWPFormId,(short)AV8WWPFormVersionNumber});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel1"+"_"+"WWPFORMLATESTVERSIONNUMBER") == 0 )
            {
               A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GX1ASAWWPFORMLATESTVERSIONNUMBER0T40( A206WWPFormId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
            {
               A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               A207WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               A211WWPFormElementParentId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementParentId"), "."), 18, MidpointRounding.ToEven));
               n211WWPFormElementParentId = false;
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_16( A206WWPFormId, A207WWPFormVersionNumber, A211WWPFormElementParentId) ;
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
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
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
         }
         GXKey = Crypto.GetSiteKey( );
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_form.aspx")), "workwithplus.dynamicforms.wwp_form.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_form.aspx")))) ;
               }
               else
               {
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               }
            }
         }
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "Mode");
               toggleJsOutput = isJsOutputEnabled( );
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_web_controls( ) ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "WWPForm", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
            if ( nDynComponent == 0 )
            {
               context.HttpContext.Response.StatusCode = 404;
               GXUtil.WriteLog("send_http_error_code " + 404.ToString());
               GxWebError = 1;
            }
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGridlevel_element_newrow_invoke( )
      {
         nRC_GXsfl_52 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_52"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_52_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_52_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_52_idx = GetPar( "sGXsfl_52_idx");
         sPrefix = GetPar( "sPrefix");
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

      public wwp_form( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wwp_form( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_WWPFormId ,
                           short aP2_WWPFormVersionNumber )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7WWPFormId = aP1_WWPFormId;
         this.AV8WWPFormVersionNumber = aP2_WWPFormVersionNumber;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         chkWWPFormIsWizard = new GXCheckbox();
         cmbWWPFormElementType = new GXCombobox();
         cmbWWPFormElementDataType = new GXCombobox();
         cmbWWPFormElementParentType = new GXCombobox();
         cmbWWPFormElementCaption = new GXCombobox();
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
            }
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
         AssignAttri(sPrefix, false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
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
            RenderHtmlCloseForm0T40( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            RenderHtmlHeaders( ) ;
         }
         RenderHtmlOpenForm( ) ;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_form.aspx");
         }
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
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
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
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
         AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,21);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
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
         AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormVersionNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormVersionNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormVersionNumber_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
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
         AssignAttri(sPrefix, false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPFormDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPFormDate_Internalname, context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A231WWPFormDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormDate_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtWWPFormDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
         GxWebStd.gx_bitmap( context, edtWWPFormDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPFormDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
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
         AssignAttri(sPrefix, false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPFormIsWizard_Internalname, StringUtil.BoolToStr( A232WWPFormIsWizard), "", context.GetMessage( "Is Wizard", ""), 1, chkWWPFormIsWizard.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,36);\"");
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
         AssignAttri(sPrefix, false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormReferenceName_Internalname, A208WWPFormReferenceName, StringUtil.RTrim( context.localUtil.Format( A208WWPFormReferenceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormReferenceName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormReferenceName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
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
         AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormTitle_Internalname, A209WWPFormTitle, StringUtil.RTrim( context.localUtil.Format( A209WWPFormTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
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
               ScanStart0T41( ) ;
               while ( RcdFound41 != 0 )
               {
                  init_level_properties41( ) ;
                  getByPrimaryKey0T41( ) ;
                  AddRow0T41( ) ;
                  ScanNext0T41( ) ;
               }
               ScanEnd0T41( ) ;
               nBlankRcdCount41 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0T41( ) ;
            standaloneModal0T41( ) ;
            sMode41 = Gx_mode;
            while ( nGXsfl_52_idx < nRC_GXsfl_52 )
            {
               bGXsfl_52_Refreshing = true;
               ReadRow0T41( ) ;
               edtWWPFormElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtWWPFormElementTitle_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtWWPFormElementReferenceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementReferenceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               cmbWWPFormElementType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, cmbWWPFormElementType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementType.Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtWWPFormElementOrderIndex_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementOrderIndex_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               cmbWWPFormElementDataType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtWWPFormElementParentId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementParentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtWWPFormElementParentName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementParentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               cmbWWPFormElementParentType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, cmbWWPFormElementParentType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtWWPFormElementMetadata_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               cmbWWPFormElementCaption.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, cmbWWPFormElementCaption_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0), !bGXsfl_52_Refreshing);
               if ( ( nRcdExists_41 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  standaloneModal0T41( ) ;
               }
               SendRow0T41( ) ;
               bGXsfl_52_Refreshing = false;
            }
            Gx_mode = sMode41;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount41 = 5;
            nRcdExists_41 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0T41( ) ;
               while ( RcdFound41 != 0 )
               {
                  sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5241( ) ;
                  init_level_properties41( ) ;
                  standaloneNotModal0T41( ) ;
                  getByPrimaryKey0T41( ) ;
                  standaloneModal0T41( ) ;
                  AddRow0T41( ) ;
                  ScanNext0T41( ) ;
               }
               ScanEnd0T41( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode41 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx+1), 4, 0), 4, "0");
            SubsflControlProps_5241( ) ;
            InitAll0T41( ) ;
            init_level_properties41( ) ;
            nRcdExists_41 = 0;
            nIsMod_41 = 0;
            nRcdDeleted_41 = 0;
            nBlankRcdCount41 = (short)(nBlankRcdUsr41+nBlankRcdCount41);
            fRowAdded = 0;
            while ( nBlankRcdCount41 > 0 )
            {
               standaloneNotModal0T41( ) ;
               standaloneModal0T41( ) ;
               AddRow0T41( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtWWPFormElementId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount41 = (short)(nBlankRcdCount41-1);
            }
            Gx_mode = sMode41;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+sPrefix+"Gridlevel_elementContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridlevel_element", Gridlevel_elementContainer, subGridlevel_element_Internalname);
         if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gridlevel_elementContainerData", Gridlevel_elementContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gridlevel_elementContainerData"+"V", Gridlevel_elementContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridlevel_elementContainerData"+"V"+"\" value='"+Gridlevel_elementContainer.GridValuesHidden()+"'/>") ;
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
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               standaloneStartupServer( ) ;
            }
         }
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110T2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         nDoneStart = 1;
         if ( AnyError == 0 )
         {
            sXEvt = cgiGet( "_EventName");
            if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z206WWPFormId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z207WWPFormVersionNumber"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z208WWPFormReferenceName = cgiGet( sPrefix+"Z208WWPFormReferenceName");
               Z209WWPFormTitle = cgiGet( sPrefix+"Z209WWPFormTitle");
               Z231WWPFormDate = context.localUtil.CToT( cgiGet( sPrefix+"Z231WWPFormDate"), 0);
               Z232WWPFormIsWizard = StringUtil.StrToBool( cgiGet( sPrefix+"Z232WWPFormIsWizard"));
               Z216WWPFormResume = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z216WWPFormResume"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z234WWPFormInstantiated = StringUtil.StrToBool( cgiGet( sPrefix+"Z234WWPFormInstantiated"));
               Z240WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z240WWPFormType"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z241WWPFormSectionRefElements = cgiGet( sPrefix+"Z241WWPFormSectionRefElements");
               Z242WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sPrefix+"Z242WWPFormIsForDynamicValidations"));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPFormId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               wcpOAV8WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8WWPFormVersionNumber"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A216WWPFormResume = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z216WWPFormResume"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A234WWPFormInstantiated = StringUtil.StrToBool( cgiGet( sPrefix+"Z234WWPFormInstantiated"));
               A240WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z240WWPFormType"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A241WWPFormSectionRefElements = cgiGet( sPrefix+"Z241WWPFormSectionRefElements");
               A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sPrefix+"Z242WWPFormIsForDynamicValidations"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( sPrefix+"Mode");
               nRC_GXsfl_52 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_52"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A219WWPFormLatestVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMLATESTVERSIONNUMBER"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vWWPFORMID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV8WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vWWPFORMVERSIONNUMBER"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A216WWPFormResume = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMRESUME"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A235WWPFormResumeMessage = cgiGet( sPrefix+"WWPFORMRESUMEMESSAGE");
               A233WWPFormValidations = cgiGet( sPrefix+"WWPFORMVALIDATIONS");
               A234WWPFormInstantiated = StringUtil.StrToBool( cgiGet( sPrefix+"WWPFORMINSTANTIATED"));
               A240WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMTYPE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A241WWPFormSectionRefElements = cgiGet( sPrefix+"WWPFORMSECTIONREFELEMENTS");
               A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sPrefix+"WWPFORMISFORDYNAMICVALIDATIONS"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A238WWPFormElementExcludeFromExpor = StringUtil.StrToBool( cgiGet( sPrefix+"WWPFORMELEMENTEXCLUDEFROMEXPOR"));
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPFORMID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A206WWPFormId = 0;
                  AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               }
               else
               {
                  A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPFORMVERSIONNUMBER");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormVersionNumber_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A207WWPFormVersionNumber = 0;
                  AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               }
               else
               {
                  A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtWWPFormDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "WWPForm Date", "")}), 1, "WWPFORMDATE");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormDate_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A231WWPFormDate = (DateTime)(DateTime.MinValue);
                  AssignAttri(sPrefix, false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname));
                  AssignAttri(sPrefix, false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               A232WWPFormIsWizard = StringUtil.StrToBool( cgiGet( chkWWPFormIsWizard_Internalname));
               AssignAttri(sPrefix, false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
               A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
               AssignAttri(sPrefix, false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
               A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
               AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WWP_Form");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("WWPFormResume", context.localUtil.Format( (decimal)(A216WWPFormResume), "9"));
               forbiddenHiddens.Add("WWPFormInstantiated", StringUtil.BoolToStr( A234WWPFormInstantiated));
               forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A240WWPFormType), "9"));
               forbiddenHiddens.Add("WWPFormSectionRefElements", StringUtil.RTrim( context.localUtil.Format( A241WWPFormSectionRefElements, "")));
               forbiddenHiddens.Add("WWPFormIsForDynamicValidations", StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A206WWPFormId != Z206WWPFormId ) || ( A207WWPFormVersionNumber != Z207WWPFormVersionNumber ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("workwithplus\\dynamicforms\\wwp_form:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
                  A207WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode40 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode40;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound40 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0T0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "WWPFORMID");
                        AnyError = 1;
                        GX_FocusControl = edtWWPFormId_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read Transaction buttons. */
            if ( context.wbHandled == 0 )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  sEvt = cgiGet( "_EventName");
                  EvtGridId = cgiGet( "_EventGridId");
                  EvtRowId = cgiGet( "_EventRowId");
               }
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E110T2 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: After Trn */
                                 E120T2 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 if ( ! IsDsp( ) )
                                 {
                                    btn_enter( ) ;
                                 }
                              }
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            E120T2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0T40( ) ;
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
         bttBtntrn_delete_Visible = 0;
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0T40( ) ;
         }
         AssignProp(sPrefix, false, edtWWPFormDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormDate_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkWWPFormIsWizard_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormIsWizard.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtWWPFormReferenceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormReferenceName_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtWWPFormTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
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

      protected void CONFIRM_0T0( )
      {
         BeforeValidate0T40( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0T40( ) ;
            }
            else
            {
               CheckExtendedTable0T40( ) ;
               CloseExtendedTableCursors0T40( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode40 = Gx_mode;
            CONFIRM_0T41( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode40;
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode40;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0T41( )
      {
         nGXsfl_52_idx = 0;
         while ( nGXsfl_52_idx < nRC_GXsfl_52 )
         {
            ReadRow0T41( ) ;
            if ( ( nRcdExists_41 != 0 ) || ( nIsMod_41 != 0 ) )
            {
               GetKey0T41( ) ;
               if ( ( nRcdExists_41 == 0 ) && ( nRcdDeleted_41 == 0 ) )
               {
                  if ( RcdFound41 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     BeforeValidate0T41( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0T41( ) ;
                        CloseExtendedTableCursors0T41( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_52_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtWWPFormElementId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound41 != 0 )
                  {
                     if ( nRcdDeleted_41 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0T41( ) ;
                        Load0T41( ) ;
                        BeforeValidate0T41( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0T41( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_41 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                           BeforeValidate0T41( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0T41( ) ;
                              CloseExtendedTableCursors0T41( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
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
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( sPrefix+edtWWPFormElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementTitle_Internalname, A229WWPFormElementTitle) ;
            ChangePostValue( sPrefix+edtWWPFormElementReferenceId_Internalname, A213WWPFormElementReferenceId) ;
            ChangePostValue( sPrefix+cmbWWPFormElementType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A217WWPFormElementType), 1, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementOrderIndex_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+cmbWWPFormElementDataType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A218WWPFormElementDataType), 2, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementParentId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementParentName_Internalname, A228WWPFormElementParentName) ;
            ChangePostValue( sPrefix+cmbWWPFormElementParentType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A230WWPFormElementParentType), 1, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementMetadata_Internalname, A236WWPFormElementMetadata) ;
            ChangePostValue( sPrefix+cmbWWPFormElementCaption_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A237WWPFormElementCaption), 1, 0, ".", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z210WWPFormElementId_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z237WWPFormElementCaption_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z237WWPFormElementCaption), 1, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z217WWPFormElementType_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z217WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z212WWPFormElementOrderIndex_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z218WWPFormElementDataType_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z218WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z213WWPFormElementReferenceId_"+sGXsfl_52_idx, Z213WWPFormElementReferenceId) ;
            ChangePostValue( sPrefix+"ZT_"+"Z238WWPFormElementExcludeFromExpor_"+sGXsfl_52_idx, StringUtil.BoolToStr( Z238WWPFormElementExcludeFromExpor)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z211WWPFormElementParentId_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"nRcdDeleted_41_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_41), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"nRcdExists_41_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_41), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"nIsMod_41_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_41), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_41 != 0 )
            {
               ChangePostValue( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0T0( )
      {
      }

      protected void E110T2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120T2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0T40( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z208WWPFormReferenceName = T000T6_A208WWPFormReferenceName[0];
               Z209WWPFormTitle = T000T6_A209WWPFormTitle[0];
               Z231WWPFormDate = T000T6_A231WWPFormDate[0];
               Z232WWPFormIsWizard = T000T6_A232WWPFormIsWizard[0];
               Z216WWPFormResume = T000T6_A216WWPFormResume[0];
               Z234WWPFormInstantiated = T000T6_A234WWPFormInstantiated[0];
               Z240WWPFormType = T000T6_A240WWPFormType[0];
               Z241WWPFormSectionRefElements = T000T6_A241WWPFormSectionRefElements[0];
               Z242WWPFormIsForDynamicValidations = T000T6_A242WWPFormIsForDynamicValidations[0];
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
         if ( GX_JID == -14 )
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
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7WWPFormId) )
         {
            A206WWPFormId = AV7WWPFormId;
            AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
         }
         if ( ! (0==AV7WWPFormId) )
         {
            edtWWPFormId_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         }
         else
         {
            edtWWPFormId_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7WWPFormId) )
         {
            edtWWPFormId_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8WWPFormVersionNumber) )
         {
            A207WWPFormVersionNumber = AV8WWPFormVersionNumber;
            AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         }
         if ( ! (0==AV8WWPFormVersionNumber) )
         {
            edtWWPFormVersionNumber_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         }
         else
         {
            edtWWPFormVersionNumber_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8WWPFormVersionNumber) )
         {
            edtWWPFormVersionNumber_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            AssignAttri(sPrefix, false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         }
      }

      protected void Load0T40( )
      {
         /* Using cursor T000T7 */
         pr_default.execute(5, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound40 = 1;
            A208WWPFormReferenceName = T000T7_A208WWPFormReferenceName[0];
            AssignAttri(sPrefix, false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A209WWPFormTitle = T000T7_A209WWPFormTitle[0];
            AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
            A231WWPFormDate = T000T7_A231WWPFormDate[0];
            AssignAttri(sPrefix, false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A232WWPFormIsWizard = T000T7_A232WWPFormIsWizard[0];
            AssignAttri(sPrefix, false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
            A216WWPFormResume = T000T7_A216WWPFormResume[0];
            A235WWPFormResumeMessage = T000T7_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = T000T7_A233WWPFormValidations[0];
            A234WWPFormInstantiated = T000T7_A234WWPFormInstantiated[0];
            A240WWPFormType = T000T7_A240WWPFormType[0];
            A241WWPFormSectionRefElements = T000T7_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = T000T7_A242WWPFormIsForDynamicValidations[0];
            ZM0T40( -14) ;
         }
         pr_default.close(5);
         OnLoadActions0T40( ) ;
      }

      protected void OnLoadActions0T40( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri(sPrefix, false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
      }

      protected void CheckExtendedTable0T40( )
      {
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri(sPrefix, false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         if ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  A206WWPFormId,  A208WWPFormReferenceName) )
         {
            GX_msglist.addItem(context.GetMessage( "WWP_DF_ReferenceMustBeUnique", ""), 1, "WWPFORMID");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0T40( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0T40( )
      {
         /* Using cursor T000T8 */
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
         /* Using cursor T000T6 */
         pr_default.execute(4, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0T40( 14) ;
            RcdFound40 = 1;
            A206WWPFormId = T000T6_A206WWPFormId[0];
            AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T000T6_A207WWPFormVersionNumber[0];
            AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            A208WWPFormReferenceName = T000T6_A208WWPFormReferenceName[0];
            AssignAttri(sPrefix, false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A209WWPFormTitle = T000T6_A209WWPFormTitle[0];
            AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
            A231WWPFormDate = T000T6_A231WWPFormDate[0];
            AssignAttri(sPrefix, false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A232WWPFormIsWizard = T000T6_A232WWPFormIsWizard[0];
            AssignAttri(sPrefix, false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
            A216WWPFormResume = T000T6_A216WWPFormResume[0];
            A235WWPFormResumeMessage = T000T6_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = T000T6_A233WWPFormValidations[0];
            A234WWPFormInstantiated = T000T6_A234WWPFormInstantiated[0];
            A240WWPFormType = T000T6_A240WWPFormType[0];
            A241WWPFormSectionRefElements = T000T6_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = T000T6_A242WWPFormIsForDynamicValidations[0];
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0T40( ) ;
            if ( AnyError == 1 )
            {
               RcdFound40 = 0;
               InitializeNonKey0T40( ) ;
            }
            Gx_mode = sMode40;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound40 = 0;
            InitializeNonKey0T40( ) ;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode40;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0T40( ) ;
         if ( RcdFound40 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound40 = 0;
         /* Using cursor T000T9 */
         pr_default.execute(7, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000T9_A206WWPFormId[0] < A206WWPFormId ) || ( T000T9_A206WWPFormId[0] == A206WWPFormId ) && ( T000T9_A207WWPFormVersionNumber[0] < A207WWPFormVersionNumber ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000T9_A206WWPFormId[0] > A206WWPFormId ) || ( T000T9_A206WWPFormId[0] == A206WWPFormId ) && ( T000T9_A207WWPFormVersionNumber[0] > A207WWPFormVersionNumber ) ) )
            {
               A206WWPFormId = T000T9_A206WWPFormId[0];
               AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               A207WWPFormVersionNumber = T000T9_A207WWPFormVersionNumber[0];
               AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               RcdFound40 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound40 = 0;
         /* Using cursor T000T10 */
         pr_default.execute(8, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000T10_A206WWPFormId[0] > A206WWPFormId ) || ( T000T10_A206WWPFormId[0] == A206WWPFormId ) && ( T000T10_A207WWPFormVersionNumber[0] > A207WWPFormVersionNumber ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000T10_A206WWPFormId[0] < A206WWPFormId ) || ( T000T10_A206WWPFormId[0] == A206WWPFormId ) && ( T000T10_A207WWPFormVersionNumber[0] < A207WWPFormVersionNumber ) ) )
            {
               A206WWPFormId = T000T10_A206WWPFormId[0];
               AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
               A207WWPFormVersionNumber = T000T10_A207WWPFormVersionNumber[0];
               AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
               RcdFound40 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0T40( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0T40( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound40 == 1 )
            {
               if ( ( A206WWPFormId != Z206WWPFormId ) || ( A207WWPFormVersionNumber != Z207WWPFormVersionNumber ) )
               {
                  A206WWPFormId = Z206WWPFormId;
                  AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
                  A207WWPFormVersionNumber = Z207WWPFormVersionNumber;
                  AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPFORMID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0T40( ) ;
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A206WWPFormId != Z206WWPFormId ) || ( A207WWPFormVersionNumber != Z207WWPFormVersionNumber ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0T40( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPFORMID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPFormId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtWWPFormId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0T40( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( ( A206WWPFormId != Z206WWPFormId ) || ( A207WWPFormVersionNumber != Z207WWPFormVersionNumber ) )
         {
            A206WWPFormId = Z206WWPFormId;
            AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = Z207WWPFormVersionNumber;
            AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPFORMID");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0T40( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000T5 */
            pr_default.execute(3, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Form"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z208WWPFormReferenceName, T000T5_A208WWPFormReferenceName[0]) != 0 ) || ( StringUtil.StrCmp(Z209WWPFormTitle, T000T5_A209WWPFormTitle[0]) != 0 ) || ( Z231WWPFormDate != T000T5_A231WWPFormDate[0] ) || ( Z232WWPFormIsWizard != T000T5_A232WWPFormIsWizard[0] ) || ( Z216WWPFormResume != T000T5_A216WWPFormResume[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z234WWPFormInstantiated != T000T5_A234WWPFormInstantiated[0] ) || ( Z240WWPFormType != T000T5_A240WWPFormType[0] ) || ( StringUtil.StrCmp(Z241WWPFormSectionRefElements, T000T5_A241WWPFormSectionRefElements[0]) != 0 ) || ( Z242WWPFormIsForDynamicValidations != T000T5_A242WWPFormIsForDynamicValidations[0] ) )
            {
               if ( StringUtil.StrCmp(Z208WWPFormReferenceName, T000T5_A208WWPFormReferenceName[0]) != 0 )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormReferenceName");
                  GXUtil.WriteLogRaw("Old: ",Z208WWPFormReferenceName);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A208WWPFormReferenceName[0]);
               }
               if ( StringUtil.StrCmp(Z209WWPFormTitle, T000T5_A209WWPFormTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormTitle");
                  GXUtil.WriteLogRaw("Old: ",Z209WWPFormTitle);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A209WWPFormTitle[0]);
               }
               if ( Z231WWPFormDate != T000T5_A231WWPFormDate[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormDate");
                  GXUtil.WriteLogRaw("Old: ",Z231WWPFormDate);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A231WWPFormDate[0]);
               }
               if ( Z232WWPFormIsWizard != T000T5_A232WWPFormIsWizard[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormIsWizard");
                  GXUtil.WriteLogRaw("Old: ",Z232WWPFormIsWizard);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A232WWPFormIsWizard[0]);
               }
               if ( Z216WWPFormResume != T000T5_A216WWPFormResume[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormResume");
                  GXUtil.WriteLogRaw("Old: ",Z216WWPFormResume);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A216WWPFormResume[0]);
               }
               if ( Z234WWPFormInstantiated != T000T5_A234WWPFormInstantiated[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormInstantiated");
                  GXUtil.WriteLogRaw("Old: ",Z234WWPFormInstantiated);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A234WWPFormInstantiated[0]);
               }
               if ( Z240WWPFormType != T000T5_A240WWPFormType[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormType");
                  GXUtil.WriteLogRaw("Old: ",Z240WWPFormType);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A240WWPFormType[0]);
               }
               if ( StringUtil.StrCmp(Z241WWPFormSectionRefElements, T000T5_A241WWPFormSectionRefElements[0]) != 0 )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormSectionRefElements");
                  GXUtil.WriteLogRaw("Old: ",Z241WWPFormSectionRefElements);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A241WWPFormSectionRefElements[0]);
               }
               if ( Z242WWPFormIsForDynamicValidations != T000T5_A242WWPFormIsForDynamicValidations[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormIsForDynamicValidations");
                  GXUtil.WriteLogRaw("Old: ",Z242WWPFormIsForDynamicValidations);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A242WWPFormIsForDynamicValidations[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Form"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0T40( )
      {
         BeforeValidate0T40( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T40( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0T40( 0) ;
            CheckOptimisticConcurrency0T40( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T40( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0T40( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T11 */
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
                           ProcessLevel0T40( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0T0( ) ;
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
               Load0T40( ) ;
            }
            EndLevel0T40( ) ;
         }
         CloseExtendedTableCursors0T40( ) ;
      }

      protected void Update0T40( )
      {
         BeforeValidate0T40( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T40( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T40( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T40( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0T40( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T12 */
                     pr_default.execute(10, new Object[] {A208WWPFormReferenceName, A209WWPFormTitle, A231WWPFormDate, A232WWPFormIsWizard, A216WWPFormResume, A235WWPFormResumeMessage, A233WWPFormValidations, A234WWPFormInstantiated, A240WWPFormType, A241WWPFormSectionRefElements, A242WWPFormIsForDynamicValidations, A206WWPFormId, A207WWPFormVersionNumber});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Form"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0T40( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0T40( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
                                 {
                                    context.nUserReturn = 1;
                                 }
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
            }
            EndLevel0T40( ) ;
         }
         CloseExtendedTableCursors0T40( ) ;
      }

      protected void DeferredUpdate0T40( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0T40( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T40( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0T40( ) ;
            AfterConfirm0T40( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0T40( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0T41( ) ;
                  while ( RcdFound41 != 0 )
                  {
                     getByPrimaryKey0T41( ) ;
                     Delete0T41( ) ;
                     ScanNext0T41( ) ;
                  }
                  ScanEnd0T41( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T13 */
                     pr_default.execute(11, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
                              {
                                 context.nUserReturn = 1;
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
            }
         }
         sMode40 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0T40( ) ;
         Gx_mode = sMode40;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0T40( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            AssignAttri(sPrefix, false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000T14 */
            pr_default.execute(12, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_SupplierDynamicForm", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000T15 */
            pr_default.execute(13, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_OrganisationDynamicForm", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000T16 */
            pr_default.execute(14, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Location Dynamic Forms", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000T17 */
            pr_default.execute(15, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWPForm Instance", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000T18 */
            pr_default.execute(16, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Element", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void ProcessNestedLevel0T41( )
      {
         nGXsfl_52_idx = 0;
         while ( nGXsfl_52_idx < nRC_GXsfl_52 )
         {
            ReadRow0T41( ) ;
            if ( ( nRcdExists_41 != 0 ) || ( nIsMod_41 != 0 ) )
            {
               standaloneNotModal0T41( ) ;
               GetKey0T41( ) ;
               if ( ( nRcdExists_41 == 0 ) && ( nRcdDeleted_41 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  Insert0T41( ) ;
               }
               else
               {
                  if ( RcdFound41 != 0 )
                  {
                     if ( ( nRcdDeleted_41 != 0 ) && ( nRcdExists_41 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        Delete0T41( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_41 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                           Update0T41( ) ;
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
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( sPrefix+edtWWPFormElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementTitle_Internalname, A229WWPFormElementTitle) ;
            ChangePostValue( sPrefix+edtWWPFormElementReferenceId_Internalname, A213WWPFormElementReferenceId) ;
            ChangePostValue( sPrefix+cmbWWPFormElementType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A217WWPFormElementType), 1, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementOrderIndex_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+cmbWWPFormElementDataType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A218WWPFormElementDataType), 2, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementParentId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementParentName_Internalname, A228WWPFormElementParentName) ;
            ChangePostValue( sPrefix+cmbWWPFormElementParentType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A230WWPFormElementParentType), 1, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementMetadata_Internalname, A236WWPFormElementMetadata) ;
            ChangePostValue( sPrefix+cmbWWPFormElementCaption_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A237WWPFormElementCaption), 1, 0, ".", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z210WWPFormElementId_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z237WWPFormElementCaption_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z237WWPFormElementCaption), 1, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z217WWPFormElementType_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z217WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z212WWPFormElementOrderIndex_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z218WWPFormElementDataType_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z218WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z213WWPFormElementReferenceId_"+sGXsfl_52_idx, Z213WWPFormElementReferenceId) ;
            ChangePostValue( sPrefix+"ZT_"+"Z238WWPFormElementExcludeFromExpor_"+sGXsfl_52_idx, StringUtil.BoolToStr( Z238WWPFormElementExcludeFromExpor)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z211WWPFormElementParentId_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"nRcdDeleted_41_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_41), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"nRcdExists_41_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_41), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( sPrefix+"nIsMod_41_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_41), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_41 != 0 )
            {
               ChangePostValue( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0T41( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_41 = 0;
         nIsMod_41 = 0;
         nRcdDeleted_41 = 0;
      }

      protected void ProcessLevel0T40( )
      {
         /* Save parent mode. */
         sMode40 = Gx_mode;
         ProcessNestedLevel0T41( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode40;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0T40( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0T40( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("workwithplus.dynamicforms.wwp_form",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("workwithplus.dynamicforms.wwp_form",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0T40( )
      {
         /* Scan By routine */
         /* Using cursor T000T19 */
         pr_default.execute(17);
         RcdFound40 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound40 = 1;
            A206WWPFormId = T000T19_A206WWPFormId[0];
            AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T000T19_A207WWPFormVersionNumber[0];
            AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0T40( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound40 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound40 = 1;
            A206WWPFormId = T000T19_A206WWPFormId[0];
            AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T000T19_A207WWPFormVersionNumber[0];
            AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         }
      }

      protected void ScanEnd0T40( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0T40( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0T40( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0T40( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0T40( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0T40( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0T40( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0T40( )
      {
         edtWWPFormId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         edtWWPFormVersionNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         edtWWPFormDate_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormDate_Enabled), 5, 0), true);
         chkWWPFormIsWizard.Enabled = 0;
         AssignProp(sPrefix, false, chkWWPFormIsWizard_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormIsWizard.Enabled), 5, 0), true);
         edtWWPFormReferenceName_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormReferenceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormReferenceName_Enabled), 5, 0), true);
         edtWWPFormTitle_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Enabled), 5, 0), true);
      }

      protected void ZM0T41( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z237WWPFormElementCaption = T000T3_A237WWPFormElementCaption[0];
               Z217WWPFormElementType = T000T3_A217WWPFormElementType[0];
               Z212WWPFormElementOrderIndex = T000T3_A212WWPFormElementOrderIndex[0];
               Z218WWPFormElementDataType = T000T3_A218WWPFormElementDataType[0];
               Z213WWPFormElementReferenceId = T000T3_A213WWPFormElementReferenceId[0];
               Z238WWPFormElementExcludeFromExpor = T000T3_A238WWPFormElementExcludeFromExpor[0];
               Z211WWPFormElementParentId = T000T3_A211WWPFormElementParentId[0];
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
         if ( GX_JID == -15 )
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

      protected void standaloneNotModal0T41( )
      {
      }

      protected void standaloneModal0T41( )
      {
         if ( IsIns( )  && (0==A237WWPFormElementCaption) && ( Gx_BScreen == 0 ) )
         {
            A237WWPFormElementCaption = 1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtWWPFormElementId_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         }
         else
         {
            edtWWPFormElementId_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0T41( )
      {
         /* Using cursor T000T20 */
         pr_default.execute(18, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound41 = 1;
            A237WWPFormElementCaption = T000T20_A237WWPFormElementCaption[0];
            A229WWPFormElementTitle = T000T20_A229WWPFormElementTitle[0];
            A217WWPFormElementType = T000T20_A217WWPFormElementType[0];
            A212WWPFormElementOrderIndex = T000T20_A212WWPFormElementOrderIndex[0];
            A218WWPFormElementDataType = T000T20_A218WWPFormElementDataType[0];
            A228WWPFormElementParentName = T000T20_A228WWPFormElementParentName[0];
            A230WWPFormElementParentType = T000T20_A230WWPFormElementParentType[0];
            A236WWPFormElementMetadata = T000T20_A236WWPFormElementMetadata[0];
            A213WWPFormElementReferenceId = T000T20_A213WWPFormElementReferenceId[0];
            A238WWPFormElementExcludeFromExpor = T000T20_A238WWPFormElementExcludeFromExpor[0];
            A211WWPFormElementParentId = T000T20_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = T000T20_n211WWPFormElementParentId[0];
            ZM0T41( -15) ;
         }
         pr_default.close(18);
         OnLoadActions0T41( ) ;
      }

      protected void OnLoadActions0T41( )
      {
      }

      protected void CheckExtendedTable0T41( )
      {
         nIsDirty_41 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0T41( ) ;
         /* Using cursor T000T4 */
         pr_default.execute(2, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) || (0==A211WWPFormElementParentId) ) )
            {
               GXCCtl = "WWPFORMELEMENTPARENTID_" + sGXsfl_52_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWPForm Element Parent", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtWWPFormElementParentId_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A228WWPFormElementParentName = T000T4_A228WWPFormElementParentName[0];
         A230WWPFormElementParentType = T000T4_A230WWPFormElementParentType[0];
         pr_default.close(2);
         if ( ! ( ( A217WWPFormElementType == 1 ) || ( A217WWPFormElementType == 2 ) || ( A217WWPFormElementType == 3 ) || ( A217WWPFormElementType == 4 ) || ( A217WWPFormElementType == 5 ) ) )
         {
            GXCCtl = "WWPFORMELEMENTTYPE_" + sGXsfl_52_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "WWPForm Element Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbWWPFormElementType_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( A218WWPFormElementDataType == 1 ) || ( A218WWPFormElementDataType == 2 ) || ( A218WWPFormElementDataType == 3 ) || ( A218WWPFormElementDataType == 4 ) || ( A218WWPFormElementDataType == 5 ) || ( A218WWPFormElementDataType == 6 ) || ( A218WWPFormElementDataType == 7 ) || ( A218WWPFormElementDataType == 8 ) || ( A218WWPFormElementDataType == 9 ) || ( A218WWPFormElementDataType == 10 ) ) )
         {
            GXCCtl = "WWPFORMELEMENTDATATYPE_" + sGXsfl_52_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "WWPForm Element Data Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbWWPFormElementDataType_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( A237WWPFormElementCaption == 1 ) || ( A237WWPFormElementCaption == 2 ) || ( A237WWPFormElementCaption == 3 ) ) )
         {
            GXCCtl = "WWPFORMELEMENTCAPTION_" + sGXsfl_52_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "WWPForm Element Caption", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbWWPFormElementCaption_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0T41( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0T41( )
      {
      }

      protected void gxLoad_16( short A206WWPFormId ,
                                short A207WWPFormVersionNumber ,
                                short A211WWPFormElementParentId )
      {
         /* Using cursor T000T21 */
         pr_default.execute(19, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) || (0==A211WWPFormElementParentId) ) )
            {
               GXCCtl = "WWPFORMELEMENTPARENTID_" + sGXsfl_52_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWPForm Element Parent", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtWWPFormElementParentId_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A228WWPFormElementParentName = T000T21_A228WWPFormElementParentName[0];
         A230WWPFormElementParentType = T000T21_A230WWPFormElementParentType[0];
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

      protected void GetKey0T41( )
      {
         /* Using cursor T000T22 */
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

      protected void getByPrimaryKey0T41( )
      {
         /* Using cursor T000T3 */
         pr_default.execute(1, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0T41( 15) ;
            RcdFound41 = 1;
            InitializeNonKey0T41( ) ;
            A210WWPFormElementId = T000T3_A210WWPFormElementId[0];
            A237WWPFormElementCaption = T000T3_A237WWPFormElementCaption[0];
            A229WWPFormElementTitle = T000T3_A229WWPFormElementTitle[0];
            A217WWPFormElementType = T000T3_A217WWPFormElementType[0];
            A212WWPFormElementOrderIndex = T000T3_A212WWPFormElementOrderIndex[0];
            A218WWPFormElementDataType = T000T3_A218WWPFormElementDataType[0];
            A236WWPFormElementMetadata = T000T3_A236WWPFormElementMetadata[0];
            A213WWPFormElementReferenceId = T000T3_A213WWPFormElementReferenceId[0];
            A238WWPFormElementExcludeFromExpor = T000T3_A238WWPFormElementExcludeFromExpor[0];
            A211WWPFormElementParentId = T000T3_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = T000T3_n211WWPFormElementParentId[0];
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z210WWPFormElementId = A210WWPFormElementId;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0T41( ) ;
            Gx_mode = sMode41;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound41 = 0;
            InitializeNonKey0T41( ) ;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal0T41( ) ;
            Gx_mode = sMode41;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0T41( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0T41( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000T2 */
            pr_default.execute(0, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormElement"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z237WWPFormElementCaption != T000T2_A237WWPFormElementCaption[0] ) || ( Z217WWPFormElementType != T000T2_A217WWPFormElementType[0] ) || ( Z212WWPFormElementOrderIndex != T000T2_A212WWPFormElementOrderIndex[0] ) || ( Z218WWPFormElementDataType != T000T2_A218WWPFormElementDataType[0] ) || ( StringUtil.StrCmp(Z213WWPFormElementReferenceId, T000T2_A213WWPFormElementReferenceId[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z238WWPFormElementExcludeFromExpor != T000T2_A238WWPFormElementExcludeFromExpor[0] ) || ( Z211WWPFormElementParentId != T000T2_A211WWPFormElementParentId[0] ) )
            {
               if ( Z237WWPFormElementCaption != T000T2_A237WWPFormElementCaption[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementCaption");
                  GXUtil.WriteLogRaw("Old: ",Z237WWPFormElementCaption);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A237WWPFormElementCaption[0]);
               }
               if ( Z217WWPFormElementType != T000T2_A217WWPFormElementType[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementType");
                  GXUtil.WriteLogRaw("Old: ",Z217WWPFormElementType);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A217WWPFormElementType[0]);
               }
               if ( Z212WWPFormElementOrderIndex != T000T2_A212WWPFormElementOrderIndex[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementOrderIndex");
                  GXUtil.WriteLogRaw("Old: ",Z212WWPFormElementOrderIndex);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A212WWPFormElementOrderIndex[0]);
               }
               if ( Z218WWPFormElementDataType != T000T2_A218WWPFormElementDataType[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementDataType");
                  GXUtil.WriteLogRaw("Old: ",Z218WWPFormElementDataType);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A218WWPFormElementDataType[0]);
               }
               if ( StringUtil.StrCmp(Z213WWPFormElementReferenceId, T000T2_A213WWPFormElementReferenceId[0]) != 0 )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementReferenceId");
                  GXUtil.WriteLogRaw("Old: ",Z213WWPFormElementReferenceId);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A213WWPFormElementReferenceId[0]);
               }
               if ( Z238WWPFormElementExcludeFromExpor != T000T2_A238WWPFormElementExcludeFromExpor[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementExcludeFromExpor");
                  GXUtil.WriteLogRaw("Old: ",Z238WWPFormElementExcludeFromExpor);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A238WWPFormElementExcludeFromExpor[0]);
               }
               if ( Z211WWPFormElementParentId != T000T2_A211WWPFormElementParentId[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementParentId");
                  GXUtil.WriteLogRaw("Old: ",Z211WWPFormElementParentId);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A211WWPFormElementParentId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_FormElement"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0T41( )
      {
         BeforeValidate0T41( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T41( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0T41( 0) ;
            CheckOptimisticConcurrency0T41( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T41( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0T41( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T23 */
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
               Load0T41( ) ;
            }
            EndLevel0T41( ) ;
         }
         CloseExtendedTableCursors0T41( ) ;
      }

      protected void Update0T41( )
      {
         BeforeValidate0T41( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T41( ) ;
         }
         if ( ( nIsMod_41 != 0 ) || ( nIsDirty_41 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0T41( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0T41( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0T41( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000T24 */
                        pr_default.execute(22, new Object[] {A237WWPFormElementCaption, A229WWPFormElementTitle, A217WWPFormElementType, A212WWPFormElementOrderIndex, A218WWPFormElementDataType, A236WWPFormElementMetadata, A213WWPFormElementReferenceId, A238WWPFormElementExcludeFromExpor, n211WWPFormElementParentId, A211WWPFormElementParentId, A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
                        pr_default.close(22);
                        pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
                        if ( (pr_default.getStatus(22) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormElement"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0T41( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0T41( ) ;
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
               EndLevel0T41( ) ;
            }
         }
         CloseExtendedTableCursors0T41( ) ;
      }

      protected void DeferredUpdate0T41( )
      {
      }

      protected void Delete0T41( )
      {
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         BeforeValidate0T41( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T41( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0T41( ) ;
            AfterConfirm0T41( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0T41( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000T25 */
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
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0T41( ) ;
         Gx_mode = sMode41;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0T41( )
      {
         standaloneModal0T41( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000T26 */
            pr_default.execute(24, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
            A228WWPFormElementParentName = T000T26_A228WWPFormElementParentName[0];
            A230WWPFormElementParentType = T000T26_A230WWPFormElementParentType[0];
            pr_default.close(24);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000T27 */
            pr_default.execute(25, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Element", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
         }
      }

      protected void EndLevel0T41( )
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

      public void ScanStart0T41( )
      {
         /* Scan By routine */
         /* Using cursor T000T28 */
         pr_default.execute(26, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         RcdFound41 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound41 = 1;
            A210WWPFormElementId = T000T28_A210WWPFormElementId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0T41( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound41 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound41 = 1;
            A210WWPFormElementId = T000T28_A210WWPFormElementId[0];
         }
      }

      protected void ScanEnd0T41( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm0T41( )
      {
         /* After Confirm Rules */
         if ( (0==A211WWPFormElementParentId) )
         {
            A211WWPFormElementParentId = 0;
            n211WWPFormElementParentId = false;
            n211WWPFormElementParentId = true;
         }
      }

      protected void BeforeInsert0T41( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0T41( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0T41( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0T41( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0T41( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0T41( )
      {
         edtWWPFormElementId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtWWPFormElementTitle_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtWWPFormElementReferenceId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementReferenceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         cmbWWPFormElementType.Enabled = 0;
         AssignProp(sPrefix, false, cmbWWPFormElementType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementType.Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtWWPFormElementOrderIndex_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementOrderIndex_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         cmbWWPFormElementDataType.Enabled = 0;
         AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtWWPFormElementParentId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementParentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtWWPFormElementParentName_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementParentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         cmbWWPFormElementParentType.Enabled = 0;
         AssignProp(sPrefix, false, cmbWWPFormElementParentType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtWWPFormElementMetadata_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         cmbWWPFormElementCaption.Enabled = 0;
         AssignProp(sPrefix, false, cmbWWPFormElementCaption_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0), !bGXsfl_52_Refreshing);
      }

      protected void send_integrity_lvl_hashes0T41( )
      {
      }

      protected void send_integrity_lvl_hashes0T40( )
      {
      }

      protected void SubsflControlProps_5241( )
      {
         edtWWPFormElementId_Internalname = sPrefix+"WWPFORMELEMENTID_"+sGXsfl_52_idx;
         edtWWPFormElementTitle_Internalname = sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_52_idx;
         edtWWPFormElementReferenceId_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_idx;
         cmbWWPFormElementType_Internalname = sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_52_idx;
         edtWWPFormElementOrderIndex_Internalname = sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_idx;
         cmbWWPFormElementDataType_Internalname = sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_52_idx;
         edtWWPFormElementParentId_Internalname = sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_52_idx;
         edtWWPFormElementParentName_Internalname = sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_idx;
         cmbWWPFormElementParentType_Internalname = sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_idx;
         edtWWPFormElementMetadata_Internalname = sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_52_idx;
         cmbWWPFormElementCaption_Internalname = sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_52_idx;
      }

      protected void SubsflControlProps_fel_5241( )
      {
         edtWWPFormElementId_Internalname = sPrefix+"WWPFORMELEMENTID_"+sGXsfl_52_fel_idx;
         edtWWPFormElementTitle_Internalname = sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_52_fel_idx;
         edtWWPFormElementReferenceId_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_fel_idx;
         cmbWWPFormElementType_Internalname = sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_52_fel_idx;
         edtWWPFormElementOrderIndex_Internalname = sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_fel_idx;
         cmbWWPFormElementDataType_Internalname = sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_52_fel_idx;
         edtWWPFormElementParentId_Internalname = sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_52_fel_idx;
         edtWWPFormElementParentName_Internalname = sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_fel_idx;
         cmbWWPFormElementParentType_Internalname = sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_fel_idx;
         edtWWPFormElementMetadata_Internalname = sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_52_fel_idx;
         cmbWWPFormElementCaption_Internalname = sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_52_fel_idx;
      }

      protected void AddRow0T41( )
      {
         nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
         SubsflControlProps_5241( ) ;
         SendRow0T41( ) ;
      }

      protected void SendRow0T41( )
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
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A210WWPFormElementId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,53);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementTitle_Internalname,(string)A229WWPFormElementTitle,(string)A229WWPFormElementTitle,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementTitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementTitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)52,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementReferenceId_Internalname,(string)A213WWPFormElementReferenceId,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementReferenceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementReferenceId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'" + sGXsfl_52_idx + "',52)\"";
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
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementType,(string)cmbWWPFormElementType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A217WWPFormElementType), 1, 0)),(short)1,(string)cmbWWPFormElementType_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementType.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A217WWPFormElementType), 1, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementType_Internalname, "Values", (string)(cmbWWPFormElementType.ToJavascriptSource()), !bGXsfl_52_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementOrderIndex_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtWWPFormElementOrderIndex_Enabled!=0) ? context.localUtil.Format( (decimal)(A212WWPFormElementOrderIndex), "ZZZ9") : context.localUtil.Format( (decimal)(A212WWPFormElementOrderIndex), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,57);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementOrderIndex_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementOrderIndex_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'" + sGXsfl_52_idx + "',52)\"";
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
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementDataType,(string)cmbWWPFormElementDataType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A218WWPFormElementDataType), 2, 0)),(short)1,(string)cmbWWPFormElementDataType_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementDataType.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementDataType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A218WWPFormElementDataType), 2, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Values", (string)(cmbWWPFormElementDataType.ToJavascriptSource()), !bGXsfl_52_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementParentId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtWWPFormElementParentId_Enabled!=0) ? context.localUtil.Format( (decimal)(A211WWPFormElementParentId), "ZZZ9") : context.localUtil.Format( (decimal)(A211WWPFormElementParentId), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementParentId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementParentId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementParentName_Internalname,(string)A228WWPFormElementParentName,(string)A228WWPFormElementParentName,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementParentName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementParentName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)52,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'" + sGXsfl_52_idx + "',52)\"";
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
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementParentType,(string)cmbWWPFormElementParentType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0)),(short)1,(string)cmbWWPFormElementParentType_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementParentType.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementParentType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementParentType_Internalname, "Values", (string)(cmbWWPFormElementParentType.ToJavascriptSource()), !bGXsfl_52_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 62,'" + sPrefix + "',false,'" + sGXsfl_52_idx + "',52)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementMetadata_Internalname,(string)A236WWPFormElementMetadata,(string)A236WWPFormElementMetadata,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementMetadata_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementMetadata_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)52,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_41_" + sGXsfl_52_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'" + sGXsfl_52_idx + "',52)\"";
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
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementCaption,(string)cmbWWPFormElementCaption_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A237WWPFormElementCaption), 1, 0)),(short)1,(string)cmbWWPFormElementCaption_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementCaption.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementCaption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A237WWPFormElementCaption), 1, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementCaption_Internalname, "Values", (string)(cmbWWPFormElementCaption.ToJavascriptSource()), !bGXsfl_52_Refreshing);
         ajax_sending_grid_row(Gridlevel_elementRow);
         send_integrity_lvl_hashes0T41( ) ;
         GXCCtl = "Z210WWPFormElementId_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z237WWPFormElementCaption_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z237WWPFormElementCaption), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z217WWPFormElementType_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z217WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z212WWPFormElementOrderIndex_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z218WWPFormElementDataType_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z218WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z213WWPFormElementReferenceId_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z213WWPFormElementReferenceId);
         GXCCtl = "Z238WWPFormElementExcludeFromExpor_" + sGXsfl_52_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z238WWPFormElementExcludeFromExpor);
         GXCCtl = "Z211WWPFormElementParentId_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_41_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_41), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_41_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_41), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_41_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_41), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vWWPFORMID_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vWWPFORMVERSIONNUMBER_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementType.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_elementContainer.AddRow(Gridlevel_elementRow);
      }

      protected void ReadRow0T41( )
      {
         nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
         SubsflControlProps_5241( ) ;
         edtWWPFormElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementTitle_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementReferenceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbWWPFormElementType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementOrderIndex_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbWWPFormElementDataType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementParentId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementParentName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbWWPFormElementParentType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWWPFormElementMetadata_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbWWPFormElementCaption.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_52_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         Z210WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z237WWPFormElementCaption_" + sGXsfl_52_idx;
         Z237WWPFormElementCaption = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z217WWPFormElementType_" + sGXsfl_52_idx;
         Z217WWPFormElementType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z212WWPFormElementOrderIndex_" + sGXsfl_52_idx;
         Z212WWPFormElementOrderIndex = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z218WWPFormElementDataType_" + sGXsfl_52_idx;
         Z218WWPFormElementDataType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z213WWPFormElementReferenceId_" + sGXsfl_52_idx;
         Z213WWPFormElementReferenceId = cgiGet( sPrefix+GXCCtl);
         GXCCtl = "Z238WWPFormElementExcludeFromExpor_" + sGXsfl_52_idx;
         Z238WWPFormElementExcludeFromExpor = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         GXCCtl = "Z211WWPFormElementParentId_" + sGXsfl_52_idx;
         Z211WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n211WWPFormElementParentId = ((0==A211WWPFormElementParentId) ? true : false);
         GXCCtl = "Z238WWPFormElementExcludeFromExpor_" + sGXsfl_52_idx;
         A238WWPFormElementExcludeFromExpor = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         GXCCtl = "nRcdDeleted_41_" + sGXsfl_52_idx;
         nRcdDeleted_41 = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_41_" + sGXsfl_52_idx;
         nRcdExists_41 = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_41_" + sGXsfl_52_idx;
         nIsMod_41 = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtWWPFormElementId_Enabled = edtWWPFormElementId_Enabled;
      }

      protected void ConfirmValues0T0( )
      {
         nGXsfl_52_idx = 0;
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
         SubsflControlProps_5241( ) ;
         while ( nGXsfl_52_idx < nRC_GXsfl_52 )
         {
            nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
            sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
            SubsflControlProps_5241( ) ;
            ChangePostValue( sPrefix+"Z210WWPFormElementId_"+sGXsfl_52_idx, cgiGet( sPrefix+"ZT_"+"Z210WWPFormElementId_"+sGXsfl_52_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z210WWPFormElementId_"+sGXsfl_52_idx) ;
            ChangePostValue( sPrefix+"Z237WWPFormElementCaption_"+sGXsfl_52_idx, cgiGet( sPrefix+"ZT_"+"Z237WWPFormElementCaption_"+sGXsfl_52_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z237WWPFormElementCaption_"+sGXsfl_52_idx) ;
            ChangePostValue( sPrefix+"Z217WWPFormElementType_"+sGXsfl_52_idx, cgiGet( sPrefix+"ZT_"+"Z217WWPFormElementType_"+sGXsfl_52_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z217WWPFormElementType_"+sGXsfl_52_idx) ;
            ChangePostValue( sPrefix+"Z212WWPFormElementOrderIndex_"+sGXsfl_52_idx, cgiGet( sPrefix+"ZT_"+"Z212WWPFormElementOrderIndex_"+sGXsfl_52_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z212WWPFormElementOrderIndex_"+sGXsfl_52_idx) ;
            ChangePostValue( sPrefix+"Z218WWPFormElementDataType_"+sGXsfl_52_idx, cgiGet( sPrefix+"ZT_"+"Z218WWPFormElementDataType_"+sGXsfl_52_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z218WWPFormElementDataType_"+sGXsfl_52_idx) ;
            ChangePostValue( sPrefix+"Z213WWPFormElementReferenceId_"+sGXsfl_52_idx, cgiGet( sPrefix+"ZT_"+"Z213WWPFormElementReferenceId_"+sGXsfl_52_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z213WWPFormElementReferenceId_"+sGXsfl_52_idx) ;
            ChangePostValue( sPrefix+"Z238WWPFormElementExcludeFromExpor_"+sGXsfl_52_idx, cgiGet( sPrefix+"ZT_"+"Z238WWPFormElementExcludeFromExpor_"+sGXsfl_52_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z238WWPFormElementExcludeFromExpor_"+sGXsfl_52_idx) ;
            ChangePostValue( sPrefix+"Z211WWPFormElementParentId_"+sGXsfl_52_idx, cgiGet( sPrefix+"ZT_"+"Z211WWPFormElementParentId_"+sGXsfl_52_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z211WWPFormElementParentId_"+sGXsfl_52_idx) ;
         }
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "WWPForm", "")) ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            bodyStyle += "-moz-opacity:0;opacity:0;";
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_form.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7WWPFormId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV8WWPFormVersionNumber,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_form.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WWP_Form");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("WWPFormResume", context.localUtil.Format( (decimal)(A216WWPFormResume), "9"));
         forbiddenHiddens.Add("WWPFormInstantiated", StringUtil.BoolToStr( A234WWPFormInstantiated));
         forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A240WWPFormType), "9"));
         forbiddenHiddens.Add("WWPFormSectionRefElements", StringUtil.RTrim( context.localUtil.Format( A241WWPFormSectionRefElements, "")));
         forbiddenHiddens.Add("WWPFormIsForDynamicValidations", StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("workwithplus\\dynamicforms\\wwp_form:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z206WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z207WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z208WWPFormReferenceName", Z208WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z209WWPFormTitle", Z209WWPFormTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z231WWPFormDate", context.localUtil.TToC( Z231WWPFormDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z232WWPFormIsWizard", Z232WWPFormIsWizard);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z216WWPFormResume", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z216WWPFormResume), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z234WWPFormInstantiated", Z234WWPFormInstantiated);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z240WWPFormType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z240WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z241WWPFormSectionRefElements", Z241WWPFormSectionRefElements);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z242WWPFormIsForDynamicValidations", Z242WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_52", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_52_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMLATESTVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMRESUME", StringUtil.LTrim( StringUtil.NToC( (decimal)(A216WWPFormResume), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMRESUMEMESSAGE", A235WWPFormResumeMessage);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMVALIDATIONS", A233WWPFormValidations);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"WWPFORMINSTANTIATED", A234WWPFormInstantiated);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A240WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMSECTIONREFELEMENTS", A241WWPFormSectionRefElements);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"WWPFORMISFORDYNAMICVALIDATIONS", A242WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"WWPFORMELEMENTEXCLUDEFROMEXPOR", A238WWPFormElementExcludeFromExpor);
      }

      protected void RenderHtmlCloseForm0T40( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WorkWithPlus.DynamicForms.WWP_Form" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWPForm", "") ;
      }

      protected void InitializeNonKey0T40( )
      {
         A219WWPFormLatestVersionNumber = 0;
         AssignAttri(sPrefix, false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         A208WWPFormReferenceName = "";
         AssignAttri(sPrefix, false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         A209WWPFormTitle = "";
         AssignAttri(sPrefix, false, "A209WWPFormTitle", A209WWPFormTitle);
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A232WWPFormIsWizard = false;
         AssignAttri(sPrefix, false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         A216WWPFormResume = 0;
         AssignAttri(sPrefix, false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         A235WWPFormResumeMessage = "";
         AssignAttri(sPrefix, false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         A233WWPFormValidations = "";
         AssignAttri(sPrefix, false, "A233WWPFormValidations", A233WWPFormValidations);
         A234WWPFormInstantiated = false;
         AssignAttri(sPrefix, false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         A240WWPFormType = 0;
         AssignAttri(sPrefix, false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         A241WWPFormSectionRefElements = "";
         AssignAttri(sPrefix, false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         A242WWPFormIsForDynamicValidations = false;
         AssignAttri(sPrefix, false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
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

      protected void InitAll0T40( )
      {
         A206WWPFormId = 0;
         AssignAttri(sPrefix, false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
         A207WWPFormVersionNumber = 0;
         AssignAttri(sPrefix, false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         InitializeNonKey0T40( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0T41( )
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
         AssignAttri(sPrefix, false, "A238WWPFormElementExcludeFromExpor", A238WWPFormElementExcludeFromExpor);
         A237WWPFormElementCaption = 1;
         Z237WWPFormElementCaption = 0;
         Z217WWPFormElementType = 0;
         Z212WWPFormElementOrderIndex = 0;
         Z218WWPFormElementDataType = 0;
         Z213WWPFormElementReferenceId = "";
         Z238WWPFormElementExcludeFromExpor = false;
         Z211WWPFormElementParentId = 0;
      }

      protected void InitAll0T41( )
      {
         A210WWPFormElementId = 0;
         InitializeNonKey0T41( ) ;
      }

      protected void StandaloneModalInsert0T41( )
      {
         A237WWPFormElementCaption = i237WWPFormElementCaption;
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SITE ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV7WWPFormId = (string)((string)getParm(obj,1));
         sCtrlAV8WWPFormVersionNumber = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            initialize_properties( ) ;
         }
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         if ( nDoneStart == 0 )
         {
            createObjects();
            initialize();
         }
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_form", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITENV( ) ;
            INITTRN( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV7WWPFormId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7WWPFormId", StringUtil.LTrimStr( (decimal)(AV7WWPFormId), 4, 0));
            AV8WWPFormVersionNumber = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV8WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV8WWPFormVersionNumber), 4, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPFormId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV8WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8WWPFormVersionNumber"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7WWPFormId != wcpOAV7WWPFormId ) || ( AV8WWPFormVersionNumber != wcpOAV8WWPFormVersionNumber ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7WWPFormId = AV7WWPFormId;
         wcpOAV8WWPFormVersionNumber = AV8WWPFormVersionNumber;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
         }
         sCtrlAV7WWPFormId = cgiGet( sPrefix+"AV7WWPFormId_CTRL");
         if ( StringUtil.Len( sCtrlAV7WWPFormId) > 0 )
         {
            AV7WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV7WWPFormId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV7WWPFormId", StringUtil.LTrimStr( (decimal)(AV7WWPFormId), 4, 0));
         }
         else
         {
            AV7WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV7WWPFormId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV8WWPFormVersionNumber = cgiGet( sPrefix+"AV8WWPFormVersionNumber_CTRL");
         if ( StringUtil.Len( sCtrlAV8WWPFormVersionNumber) > 0 )
         {
            AV8WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8WWPFormVersionNumber), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV8WWPFormVersionNumber), 4, 0));
         }
         else
         {
            AV8WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8WWPFormVersionNumber_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITENV( ) ;
         INITTRN( ) ;
         nDraw = 0;
         sEvt = sCompEvt;
         if ( isFullAjaxMode( ) )
         {
            UserMain( ) ;
         }
         else
         {
            WCParametersGet( ) ;
         }
         Process( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         UserMain( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPFormId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7WWPFormId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPFormId_CTRL", StringUtil.RTrim( sCtrlAV7WWPFormId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPFormVersionNumber_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8WWPFormVersionNumber)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPFormVersionNumber_CTRL", StringUtil.RTrim( sCtrlAV8WWPFormVersionNumber));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         Draw( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256231344218", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_form.js", "?20256231344219", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties41( )
      {
         edtWWPFormElementId_Enabled = defedtWWPFormElementId_Enabled;
         AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
      }

      protected void StartGridControl52( )
      {
         Gridlevel_elementContainer.AddObjectProperty("GridName", "Gridlevel_element");
         Gridlevel_elementContainer.AddObjectProperty("Header", subGridlevel_element_Header);
         Gridlevel_elementContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_elementContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("CmpContext", sPrefix);
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
         edtWWPFormId_Internalname = sPrefix+"WWPFORMID";
         edtWWPFormVersionNumber_Internalname = sPrefix+"WWPFORMVERSIONNUMBER";
         edtWWPFormDate_Internalname = sPrefix+"WWPFORMDATE";
         chkWWPFormIsWizard_Internalname = sPrefix+"WWPFORMISWIZARD";
         edtWWPFormReferenceName_Internalname = sPrefix+"WWPFORMREFERENCENAME";
         edtWWPFormTitle_Internalname = sPrefix+"WWPFORMTITLE";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         edtWWPFormElementId_Internalname = sPrefix+"WWPFORMELEMENTID";
         edtWWPFormElementTitle_Internalname = sPrefix+"WWPFORMELEMENTTITLE";
         edtWWPFormElementReferenceId_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEID";
         cmbWWPFormElementType_Internalname = sPrefix+"WWPFORMELEMENTTYPE";
         edtWWPFormElementOrderIndex_Internalname = sPrefix+"WWPFORMELEMENTORDERINDEX";
         cmbWWPFormElementDataType_Internalname = sPrefix+"WWPFORMELEMENTDATATYPE";
         edtWWPFormElementParentId_Internalname = sPrefix+"WWPFORMELEMENTPARENTID";
         edtWWPFormElementParentName_Internalname = sPrefix+"WWPFORMELEMENTPARENTNAME";
         cmbWWPFormElementParentType_Internalname = sPrefix+"WWPFORMELEMENTPARENTTYPE";
         edtWWPFormElementMetadata_Internalname = sPrefix+"WWPFORMELEMENTMETADATA";
         cmbWWPFormElementCaption_Internalname = sPrefix+"WWPFORMELEMENTCAPTION";
         divTableleaflevel_element_Internalname = sPrefix+"TABLELEAFLEVEL_ELEMENT";
         bttBtntrn_enter_Internalname = sPrefix+"BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = sPrefix+"BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = sPrefix+"BTNTRN_DELETE";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridlevel_element_Internalname = sPrefix+"GRIDLEVEL_ELEMENT";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGridlevel_element_Allowcollapsing = 0;
         subGridlevel_element_Allowselection = 0;
         subGridlevel_element_Header = "";
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
         bttBtntrn_delete_Enabled = 0;
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
         divLayoutmaintable_Class = "Table";
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GX1ASAWWPFORMLATESTVERSIONNUMBER0T40( short A206WWPFormId )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri(sPrefix, false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
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
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         SubsflControlProps_5241( ) ;
         while ( nGXsfl_52_idx <= nRC_GXsfl_52 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0T41( ) ;
            standaloneModal0T41( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0T41( ) ;
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
         AssignProp(sPrefix, false, chkWWPFormIsWizard_Internalname, "TitleCaption", chkWWPFormIsWizard.Caption, true);
         chkWWPFormIsWizard.CheckedValue = "false";
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
         AssignAttri(sPrefix, false, "A219WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", "")));
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
         /* Using cursor T000T26 */
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
         A228WWPFormElementParentName = T000T26_A228WWPFormElementParentName[0];
         A230WWPFormElementParentType = T000T26_A230WWPFormElementParentType[0];
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
         AssignAttri(sPrefix, false, "A228WWPFormElementParentName", A228WWPFormElementParentName);
         AssignAttri(sPrefix, false, "A230WWPFormElementParentType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A230WWPFormElementParentType), 1, 0, ".", "")));
         cmbWWPFormElementParentType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A230WWPFormElementParentType), 1, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementParentType_Internalname, "Values", cmbWWPFormElementParentType.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"componentprocess","iparms":[{"postForm":true},{"sPrefix":true},{"sSFPrefix":true},{"sCompEvt":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV7WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9"},{"av":"AV8WWPFormVersionNumber","fld":"vWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A241WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120T2","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("VALID_WWPFORMID",""","oparms":[{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"}]}""");
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
         wcpOGx_mode = "";
         Z208WWPFormReferenceName = "";
         Z209WWPFormTitle = "";
         Z231WWPFormDate = (DateTime)(DateTime.MinValue);
         Z241WWPFormSectionRefElements = "";
         Z213WWPFormElementReferenceId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         sXEvt = "";
         GX_FocusControl = "";
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
         sMode40 = "";
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
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         Z235WWPFormResumeMessage = "";
         Z233WWPFormValidations = "";
         T000T7_A206WWPFormId = new short[1] ;
         T000T7_A207WWPFormVersionNumber = new short[1] ;
         T000T7_A208WWPFormReferenceName = new string[] {""} ;
         T000T7_A209WWPFormTitle = new string[] {""} ;
         T000T7_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T000T7_A232WWPFormIsWizard = new bool[] {false} ;
         T000T7_A216WWPFormResume = new short[1] ;
         T000T7_A235WWPFormResumeMessage = new string[] {""} ;
         T000T7_A233WWPFormValidations = new string[] {""} ;
         T000T7_A234WWPFormInstantiated = new bool[] {false} ;
         T000T7_A240WWPFormType = new short[1] ;
         T000T7_A241WWPFormSectionRefElements = new string[] {""} ;
         T000T7_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T000T8_A206WWPFormId = new short[1] ;
         T000T8_A207WWPFormVersionNumber = new short[1] ;
         T000T6_A206WWPFormId = new short[1] ;
         T000T6_A207WWPFormVersionNumber = new short[1] ;
         T000T6_A208WWPFormReferenceName = new string[] {""} ;
         T000T6_A209WWPFormTitle = new string[] {""} ;
         T000T6_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T000T6_A232WWPFormIsWizard = new bool[] {false} ;
         T000T6_A216WWPFormResume = new short[1] ;
         T000T6_A235WWPFormResumeMessage = new string[] {""} ;
         T000T6_A233WWPFormValidations = new string[] {""} ;
         T000T6_A234WWPFormInstantiated = new bool[] {false} ;
         T000T6_A240WWPFormType = new short[1] ;
         T000T6_A241WWPFormSectionRefElements = new string[] {""} ;
         T000T6_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T000T9_A206WWPFormId = new short[1] ;
         T000T9_A207WWPFormVersionNumber = new short[1] ;
         T000T10_A206WWPFormId = new short[1] ;
         T000T10_A207WWPFormVersionNumber = new short[1] ;
         T000T5_A206WWPFormId = new short[1] ;
         T000T5_A207WWPFormVersionNumber = new short[1] ;
         T000T5_A208WWPFormReferenceName = new string[] {""} ;
         T000T5_A209WWPFormTitle = new string[] {""} ;
         T000T5_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T000T5_A232WWPFormIsWizard = new bool[] {false} ;
         T000T5_A216WWPFormResume = new short[1] ;
         T000T5_A235WWPFormResumeMessage = new string[] {""} ;
         T000T5_A233WWPFormValidations = new string[] {""} ;
         T000T5_A234WWPFormInstantiated = new bool[] {false} ;
         T000T5_A240WWPFormType = new short[1] ;
         T000T5_A241WWPFormSectionRefElements = new string[] {""} ;
         T000T5_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T000T14_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         T000T14_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T000T15_A509OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         T000T15_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000T16_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T000T16_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000T16_A29LocationId = new Guid[] {Guid.Empty} ;
         T000T17_A214WWPFormInstanceId = new int[1] ;
         T000T18_A206WWPFormId = new short[1] ;
         T000T18_A207WWPFormVersionNumber = new short[1] ;
         T000T18_A211WWPFormElementParentId = new short[1] ;
         T000T18_n211WWPFormElementParentId = new bool[] {false} ;
         T000T19_A206WWPFormId = new short[1] ;
         T000T19_A207WWPFormVersionNumber = new short[1] ;
         Z229WWPFormElementTitle = "";
         Z236WWPFormElementMetadata = "";
         Z228WWPFormElementParentName = "";
         T000T20_A210WWPFormElementId = new short[1] ;
         T000T20_A237WWPFormElementCaption = new short[1] ;
         T000T20_A229WWPFormElementTitle = new string[] {""} ;
         T000T20_A217WWPFormElementType = new short[1] ;
         T000T20_A212WWPFormElementOrderIndex = new short[1] ;
         T000T20_A218WWPFormElementDataType = new short[1] ;
         T000T20_A228WWPFormElementParentName = new string[] {""} ;
         T000T20_A230WWPFormElementParentType = new short[1] ;
         T000T20_A236WWPFormElementMetadata = new string[] {""} ;
         T000T20_A213WWPFormElementReferenceId = new string[] {""} ;
         T000T20_A238WWPFormElementExcludeFromExpor = new bool[] {false} ;
         T000T20_A206WWPFormId = new short[1] ;
         T000T20_A207WWPFormVersionNumber = new short[1] ;
         T000T20_A211WWPFormElementParentId = new short[1] ;
         T000T20_n211WWPFormElementParentId = new bool[] {false} ;
         T000T4_A228WWPFormElementParentName = new string[] {""} ;
         T000T4_A230WWPFormElementParentType = new short[1] ;
         T000T21_A228WWPFormElementParentName = new string[] {""} ;
         T000T21_A230WWPFormElementParentType = new short[1] ;
         T000T22_A206WWPFormId = new short[1] ;
         T000T22_A207WWPFormVersionNumber = new short[1] ;
         T000T22_A210WWPFormElementId = new short[1] ;
         T000T3_A210WWPFormElementId = new short[1] ;
         T000T3_A237WWPFormElementCaption = new short[1] ;
         T000T3_A229WWPFormElementTitle = new string[] {""} ;
         T000T3_A217WWPFormElementType = new short[1] ;
         T000T3_A212WWPFormElementOrderIndex = new short[1] ;
         T000T3_A218WWPFormElementDataType = new short[1] ;
         T000T3_A236WWPFormElementMetadata = new string[] {""} ;
         T000T3_A213WWPFormElementReferenceId = new string[] {""} ;
         T000T3_A238WWPFormElementExcludeFromExpor = new bool[] {false} ;
         T000T3_A206WWPFormId = new short[1] ;
         T000T3_A207WWPFormVersionNumber = new short[1] ;
         T000T3_A211WWPFormElementParentId = new short[1] ;
         T000T3_n211WWPFormElementParentId = new bool[] {false} ;
         T000T2_A210WWPFormElementId = new short[1] ;
         T000T2_A237WWPFormElementCaption = new short[1] ;
         T000T2_A229WWPFormElementTitle = new string[] {""} ;
         T000T2_A217WWPFormElementType = new short[1] ;
         T000T2_A212WWPFormElementOrderIndex = new short[1] ;
         T000T2_A218WWPFormElementDataType = new short[1] ;
         T000T2_A236WWPFormElementMetadata = new string[] {""} ;
         T000T2_A213WWPFormElementReferenceId = new string[] {""} ;
         T000T2_A238WWPFormElementExcludeFromExpor = new bool[] {false} ;
         T000T2_A206WWPFormId = new short[1] ;
         T000T2_A207WWPFormVersionNumber = new short[1] ;
         T000T2_A211WWPFormElementParentId = new short[1] ;
         T000T2_n211WWPFormElementParentId = new bool[] {false} ;
         T000T26_A228WWPFormElementParentName = new string[] {""} ;
         T000T26_A230WWPFormElementParentType = new short[1] ;
         T000T27_A206WWPFormId = new short[1] ;
         T000T27_A207WWPFormVersionNumber = new short[1] ;
         T000T27_A211WWPFormElementParentId = new short[1] ;
         T000T27_n211WWPFormElementParentId = new bool[] {false} ;
         T000T28_A206WWPFormId = new short[1] ;
         T000T28_A207WWPFormVersionNumber = new short[1] ;
         T000T28_A210WWPFormElementId = new short[1] ;
         Gridlevel_elementRow = new GXWebRow();
         subGridlevel_element_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         sCtrlGx_mode = "";
         sCtrlAV7WWPFormId = "";
         sCtrlAV8WWPFormVersionNumber = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         Gridlevel_elementColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_form__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_form__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_form__default(),
            new Object[][] {
                new Object[] {
               T000T2_A210WWPFormElementId, T000T2_A237WWPFormElementCaption, T000T2_A229WWPFormElementTitle, T000T2_A217WWPFormElementType, T000T2_A212WWPFormElementOrderIndex, T000T2_A218WWPFormElementDataType, T000T2_A236WWPFormElementMetadata, T000T2_A213WWPFormElementReferenceId, T000T2_A238WWPFormElementExcludeFromExpor, T000T2_A206WWPFormId,
               T000T2_A207WWPFormVersionNumber, T000T2_A211WWPFormElementParentId, T000T2_n211WWPFormElementParentId
               }
               , new Object[] {
               T000T3_A210WWPFormElementId, T000T3_A237WWPFormElementCaption, T000T3_A229WWPFormElementTitle, T000T3_A217WWPFormElementType, T000T3_A212WWPFormElementOrderIndex, T000T3_A218WWPFormElementDataType, T000T3_A236WWPFormElementMetadata, T000T3_A213WWPFormElementReferenceId, T000T3_A238WWPFormElementExcludeFromExpor, T000T3_A206WWPFormId,
               T000T3_A207WWPFormVersionNumber, T000T3_A211WWPFormElementParentId, T000T3_n211WWPFormElementParentId
               }
               , new Object[] {
               T000T4_A228WWPFormElementParentName, T000T4_A230WWPFormElementParentType
               }
               , new Object[] {
               T000T5_A206WWPFormId, T000T5_A207WWPFormVersionNumber, T000T5_A208WWPFormReferenceName, T000T5_A209WWPFormTitle, T000T5_A231WWPFormDate, T000T5_A232WWPFormIsWizard, T000T5_A216WWPFormResume, T000T5_A235WWPFormResumeMessage, T000T5_A233WWPFormValidations, T000T5_A234WWPFormInstantiated,
               T000T5_A240WWPFormType, T000T5_A241WWPFormSectionRefElements, T000T5_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T000T6_A206WWPFormId, T000T6_A207WWPFormVersionNumber, T000T6_A208WWPFormReferenceName, T000T6_A209WWPFormTitle, T000T6_A231WWPFormDate, T000T6_A232WWPFormIsWizard, T000T6_A216WWPFormResume, T000T6_A235WWPFormResumeMessage, T000T6_A233WWPFormValidations, T000T6_A234WWPFormInstantiated,
               T000T6_A240WWPFormType, T000T6_A241WWPFormSectionRefElements, T000T6_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T000T7_A206WWPFormId, T000T7_A207WWPFormVersionNumber, T000T7_A208WWPFormReferenceName, T000T7_A209WWPFormTitle, T000T7_A231WWPFormDate, T000T7_A232WWPFormIsWizard, T000T7_A216WWPFormResume, T000T7_A235WWPFormResumeMessage, T000T7_A233WWPFormValidations, T000T7_A234WWPFormInstantiated,
               T000T7_A240WWPFormType, T000T7_A241WWPFormSectionRefElements, T000T7_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T000T8_A206WWPFormId, T000T8_A207WWPFormVersionNumber
               }
               , new Object[] {
               T000T9_A206WWPFormId, T000T9_A207WWPFormVersionNumber
               }
               , new Object[] {
               T000T10_A206WWPFormId, T000T10_A207WWPFormVersionNumber
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000T14_A616SupplierDynamicFormId, T000T14_A42SupplierGenId
               }
               , new Object[] {
               T000T15_A509OrganisationDynamicFormId, T000T15_A11OrganisationId
               }
               , new Object[] {
               T000T16_A366LocationDynamicFormId, T000T16_A11OrganisationId, T000T16_A29LocationId
               }
               , new Object[] {
               T000T17_A214WWPFormInstanceId
               }
               , new Object[] {
               T000T18_A206WWPFormId, T000T18_A207WWPFormVersionNumber, T000T18_A211WWPFormElementParentId
               }
               , new Object[] {
               T000T19_A206WWPFormId, T000T19_A207WWPFormVersionNumber
               }
               , new Object[] {
               T000T20_A210WWPFormElementId, T000T20_A237WWPFormElementCaption, T000T20_A229WWPFormElementTitle, T000T20_A217WWPFormElementType, T000T20_A212WWPFormElementOrderIndex, T000T20_A218WWPFormElementDataType, T000T20_A228WWPFormElementParentName, T000T20_A230WWPFormElementParentType, T000T20_A236WWPFormElementMetadata, T000T20_A213WWPFormElementReferenceId,
               T000T20_A238WWPFormElementExcludeFromExpor, T000T20_A206WWPFormId, T000T20_A207WWPFormVersionNumber, T000T20_A211WWPFormElementParentId, T000T20_n211WWPFormElementParentId
               }
               , new Object[] {
               T000T21_A228WWPFormElementParentName, T000T21_A230WWPFormElementParentType
               }
               , new Object[] {
               T000T22_A206WWPFormId, T000T22_A207WWPFormVersionNumber, T000T22_A210WWPFormElementId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000T26_A228WWPFormElementParentName, T000T26_A230WWPFormElementParentType
               }
               , new Object[] {
               T000T27_A206WWPFormId, T000T27_A207WWPFormVersionNumber, T000T27_A211WWPFormElementParentId
               }
               , new Object[] {
               T000T28_A206WWPFormId, T000T28_A207WWPFormVersionNumber, T000T28_A210WWPFormElementId
               }
            }
         );
         Z237WWPFormElementCaption = 1;
         A237WWPFormElementCaption = 1;
         i237WWPFormElementCaption = 1;
      }

      private short wcpOAV7WWPFormId ;
      private short wcpOAV8WWPFormVersionNumber ;
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
      private short nDynComponent ;
      private short AV7WWPFormId ;
      private short AV8WWPFormVersionNumber ;
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
      private short nDraw ;
      private short nDoneStart ;
      private short A216WWPFormResume ;
      private short A240WWPFormType ;
      private short A219WWPFormLatestVersionNumber ;
      private short RcdFound40 ;
      private short A210WWPFormElementId ;
      private short A217WWPFormElementType ;
      private short A212WWPFormElementOrderIndex ;
      private short A218WWPFormElementDataType ;
      private short A230WWPFormElementParentType ;
      private short A237WWPFormElementCaption ;
      private short Z230WWPFormElementParentType ;
      private short nIsDirty_41 ;
      private short subGridlevel_element_Backcolorstyle ;
      private short subGridlevel_element_Backstyle ;
      private short i237WWPFormElementCaption ;
      private short subGridlevel_element_Allowselection ;
      private short subGridlevel_element_Allowhovering ;
      private short subGridlevel_element_Allowcollapsing ;
      private short subGridlevel_element_Collapsed ;
      private short GXt_int1 ;
      private short Z219WWPFormLatestVersionNumber ;
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
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string sXEvt ;
      private string GX_FocusControl ;
      private string edtWWPFormId_Internalname ;
      private string sGXsfl_52_idx="0001" ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
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
      private string sMode40 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
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
      private string GXEncryptionTmp ;
      private string sCtrlGx_mode ;
      private string sCtrlAV7WWPFormId ;
      private string sCtrlAV8WWPFormVersionNumber ;
      private string subGridlevel_element_Header ;
      private DateTime Z231WWPFormDate ;
      private DateTime A231WWPFormDate ;
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
      private string Z208WWPFormReferenceName ;
      private string Z209WWPFormTitle ;
      private string Z241WWPFormSectionRefElements ;
      private string Z213WWPFormElementReferenceId ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string A241WWPFormSectionRefElements ;
      private string A213WWPFormElementReferenceId ;
      private IGxSession AV11WebSession ;
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
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T000T7_A206WWPFormId ;
      private short[] T000T7_A207WWPFormVersionNumber ;
      private string[] T000T7_A208WWPFormReferenceName ;
      private string[] T000T7_A209WWPFormTitle ;
      private DateTime[] T000T7_A231WWPFormDate ;
      private bool[] T000T7_A232WWPFormIsWizard ;
      private short[] T000T7_A216WWPFormResume ;
      private string[] T000T7_A235WWPFormResumeMessage ;
      private string[] T000T7_A233WWPFormValidations ;
      private bool[] T000T7_A234WWPFormInstantiated ;
      private short[] T000T7_A240WWPFormType ;
      private string[] T000T7_A241WWPFormSectionRefElements ;
      private bool[] T000T7_A242WWPFormIsForDynamicValidations ;
      private short[] T000T8_A206WWPFormId ;
      private short[] T000T8_A207WWPFormVersionNumber ;
      private short[] T000T6_A206WWPFormId ;
      private short[] T000T6_A207WWPFormVersionNumber ;
      private string[] T000T6_A208WWPFormReferenceName ;
      private string[] T000T6_A209WWPFormTitle ;
      private DateTime[] T000T6_A231WWPFormDate ;
      private bool[] T000T6_A232WWPFormIsWizard ;
      private short[] T000T6_A216WWPFormResume ;
      private string[] T000T6_A235WWPFormResumeMessage ;
      private string[] T000T6_A233WWPFormValidations ;
      private bool[] T000T6_A234WWPFormInstantiated ;
      private short[] T000T6_A240WWPFormType ;
      private string[] T000T6_A241WWPFormSectionRefElements ;
      private bool[] T000T6_A242WWPFormIsForDynamicValidations ;
      private short[] T000T9_A206WWPFormId ;
      private short[] T000T9_A207WWPFormVersionNumber ;
      private short[] T000T10_A206WWPFormId ;
      private short[] T000T10_A207WWPFormVersionNumber ;
      private short[] T000T5_A206WWPFormId ;
      private short[] T000T5_A207WWPFormVersionNumber ;
      private string[] T000T5_A208WWPFormReferenceName ;
      private string[] T000T5_A209WWPFormTitle ;
      private DateTime[] T000T5_A231WWPFormDate ;
      private bool[] T000T5_A232WWPFormIsWizard ;
      private short[] T000T5_A216WWPFormResume ;
      private string[] T000T5_A235WWPFormResumeMessage ;
      private string[] T000T5_A233WWPFormValidations ;
      private bool[] T000T5_A234WWPFormInstantiated ;
      private short[] T000T5_A240WWPFormType ;
      private string[] T000T5_A241WWPFormSectionRefElements ;
      private bool[] T000T5_A242WWPFormIsForDynamicValidations ;
      private Guid[] T000T14_A616SupplierDynamicFormId ;
      private Guid[] T000T14_A42SupplierGenId ;
      private Guid[] T000T15_A509OrganisationDynamicFormId ;
      private Guid[] T000T15_A11OrganisationId ;
      private Guid[] T000T16_A366LocationDynamicFormId ;
      private Guid[] T000T16_A11OrganisationId ;
      private Guid[] T000T16_A29LocationId ;
      private int[] T000T17_A214WWPFormInstanceId ;
      private short[] T000T18_A206WWPFormId ;
      private short[] T000T18_A207WWPFormVersionNumber ;
      private short[] T000T18_A211WWPFormElementParentId ;
      private bool[] T000T18_n211WWPFormElementParentId ;
      private short[] T000T19_A206WWPFormId ;
      private short[] T000T19_A207WWPFormVersionNumber ;
      private short[] T000T20_A210WWPFormElementId ;
      private short[] T000T20_A237WWPFormElementCaption ;
      private string[] T000T20_A229WWPFormElementTitle ;
      private short[] T000T20_A217WWPFormElementType ;
      private short[] T000T20_A212WWPFormElementOrderIndex ;
      private short[] T000T20_A218WWPFormElementDataType ;
      private string[] T000T20_A228WWPFormElementParentName ;
      private short[] T000T20_A230WWPFormElementParentType ;
      private string[] T000T20_A236WWPFormElementMetadata ;
      private string[] T000T20_A213WWPFormElementReferenceId ;
      private bool[] T000T20_A238WWPFormElementExcludeFromExpor ;
      private short[] T000T20_A206WWPFormId ;
      private short[] T000T20_A207WWPFormVersionNumber ;
      private short[] T000T20_A211WWPFormElementParentId ;
      private bool[] T000T20_n211WWPFormElementParentId ;
      private string[] T000T4_A228WWPFormElementParentName ;
      private short[] T000T4_A230WWPFormElementParentType ;
      private string[] T000T21_A228WWPFormElementParentName ;
      private short[] T000T21_A230WWPFormElementParentType ;
      private short[] T000T22_A206WWPFormId ;
      private short[] T000T22_A207WWPFormVersionNumber ;
      private short[] T000T22_A210WWPFormElementId ;
      private short[] T000T3_A210WWPFormElementId ;
      private short[] T000T3_A237WWPFormElementCaption ;
      private string[] T000T3_A229WWPFormElementTitle ;
      private short[] T000T3_A217WWPFormElementType ;
      private short[] T000T3_A212WWPFormElementOrderIndex ;
      private short[] T000T3_A218WWPFormElementDataType ;
      private string[] T000T3_A236WWPFormElementMetadata ;
      private string[] T000T3_A213WWPFormElementReferenceId ;
      private bool[] T000T3_A238WWPFormElementExcludeFromExpor ;
      private short[] T000T3_A206WWPFormId ;
      private short[] T000T3_A207WWPFormVersionNumber ;
      private short[] T000T3_A211WWPFormElementParentId ;
      private bool[] T000T3_n211WWPFormElementParentId ;
      private short[] T000T2_A210WWPFormElementId ;
      private short[] T000T2_A237WWPFormElementCaption ;
      private string[] T000T2_A229WWPFormElementTitle ;
      private short[] T000T2_A217WWPFormElementType ;
      private short[] T000T2_A212WWPFormElementOrderIndex ;
      private short[] T000T2_A218WWPFormElementDataType ;
      private string[] T000T2_A236WWPFormElementMetadata ;
      private string[] T000T2_A213WWPFormElementReferenceId ;
      private bool[] T000T2_A238WWPFormElementExcludeFromExpor ;
      private short[] T000T2_A206WWPFormId ;
      private short[] T000T2_A207WWPFormVersionNumber ;
      private short[] T000T2_A211WWPFormElementParentId ;
      private bool[] T000T2_n211WWPFormElementParentId ;
      private string[] T000T26_A228WWPFormElementParentName ;
      private short[] T000T26_A230WWPFormElementParentType ;
      private short[] T000T27_A206WWPFormId ;
      private short[] T000T27_A207WWPFormVersionNumber ;
      private short[] T000T27_A211WWPFormElementParentId ;
      private bool[] T000T27_n211WWPFormElementParentId ;
      private short[] T000T28_A206WWPFormId ;
      private short[] T000T28_A207WWPFormVersionNumber ;
      private short[] T000T28_A210WWPFormElementId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_form__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_form__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_form__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT000T2;
       prmT000T2 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT000T3;
       prmT000T3 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT000T4;
       prmT000T4 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000T5;
       prmT000T5 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000T6;
       prmT000T6 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000T7;
       prmT000T7 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000T8;
       prmT000T8 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000T9;
       prmT000T9 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000T10;
       prmT000T10 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000T11;
       prmT000T11 = new Object[] {
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
       Object[] prmT000T12;
       prmT000T12 = new Object[] {
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
       Object[] prmT000T13;
       prmT000T13 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000T14;
       prmT000T14 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000T15;
       prmT000T15 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000T16;
       prmT000T16 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000T17;
       prmT000T17 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000T18;
       prmT000T18 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmT000T19;
       prmT000T19 = new Object[] {
       };
       Object[] prmT000T20;
       prmT000T20 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT000T21;
       prmT000T21 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000T22;
       prmT000T22 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT000T23;
       prmT000T23 = new Object[] {
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
       Object[] prmT000T24;
       prmT000T24 = new Object[] {
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
       Object[] prmT000T25;
       prmT000T25 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT000T26;
       prmT000T26 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000T27;
       prmT000T27 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmT000T28;
       prmT000T28 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000T2", "SELECT WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExpor, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId  FOR UPDATE OF WWP_FormElement NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000T2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000T3", "SELECT WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExpor, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000T4", "SELECT WWPFormElementTitle AS WWPFormElementParentName, WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000T5", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber  FOR UPDATE OF WWP_Form NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000T5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000T6", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000T7", "SELECT TM1.WWPFormId, TM1.WWPFormVersionNumber, TM1.WWPFormReferenceName, TM1.WWPFormTitle, TM1.WWPFormDate, TM1.WWPFormIsWizard, TM1.WWPFormResume, TM1.WWPFormResumeMessage, TM1.WWPFormValidations, TM1.WWPFormInstantiated, TM1.WWPFormType, TM1.WWPFormSectionRefElements, TM1.WWPFormIsForDynamicValidations FROM WWP_Form TM1 WHERE TM1.WWPFormId = :WWPFormId and TM1.WWPFormVersionNumber = :WWPFormVersionNumber ORDER BY TM1.WWPFormId, TM1.WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T7,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000T8", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000T9", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE ( WWPFormId > :WWPFormId or WWPFormId = :WWPFormId and WWPFormVersionNumber > :WWPFormVersionNumber) ORDER BY WWPFormId, WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000T10", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE ( WWPFormId < :WWPFormId or WWPFormId = :WWPFormId and WWPFormVersionNumber < :WWPFormVersionNumber) ORDER BY WWPFormId DESC, WWPFormVersionNumber DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000T11", "SAVEPOINT gxupdate;INSERT INTO WWP_Form(WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations) VALUES(:WWPFormId, :WWPFormVersionNumber, :WWPFormReferenceName, :WWPFormTitle, :WWPFormDate, :WWPFormIsWizard, :WWPFormResume, :WWPFormResumeMessage, :WWPFormValidations, :WWPFormInstantiated, :WWPFormType, :WWPFormSectionRefElements, :WWPFormIsForDynamicValidations);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000T11)
          ,new CursorDef("T000T12", "SAVEPOINT gxupdate;UPDATE WWP_Form SET WWPFormReferenceName=:WWPFormReferenceName, WWPFormTitle=:WWPFormTitle, WWPFormDate=:WWPFormDate, WWPFormIsWizard=:WWPFormIsWizard, WWPFormResume=:WWPFormResume, WWPFormResumeMessage=:WWPFormResumeMessage, WWPFormValidations=:WWPFormValidations, WWPFormInstantiated=:WWPFormInstantiated, WWPFormType=:WWPFormType, WWPFormSectionRefElements=:WWPFormSectionRefElements, WWPFormIsForDynamicValidations=:WWPFormIsForDynamicValidations  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000T12)
          ,new CursorDef("T000T13", "SAVEPOINT gxupdate;DELETE FROM WWP_Form  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000T13)
          ,new CursorDef("T000T14", "SELECT SupplierDynamicFormId, SupplierGenId FROM Trn_SupplierDynamicForm WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000T15", "SELECT OrganisationDynamicFormId, OrganisationId FROM Trn_OrganisationDynamicForm WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T15,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000T16", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T16,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000T17", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T17,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000T18", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId AS WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T18,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000T19", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form ORDER BY WWPFormId, WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T19,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000T20", "SELECT T1.WWPFormElementId, T1.WWPFormElementCaption, T1.WWPFormElementTitle, T1.WWPFormElementType, T1.WWPFormElementOrderIndex, T1.WWPFormElementDataType, T2.WWPFormElementTitle AS WWPFormElementParentName, T2.WWPFormElementType AS WWPFormElementParentType, T1.WWPFormElementMetadata, T1.WWPFormElementReferenceId, T1.WWPFormElementExcludeFromExpor, T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementParentId AS WWPFormElementParentId FROM (WWP_FormElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementParentId) WHERE T1.WWPFormId = :WWPFormId and T1.WWPFormVersionNumber = :WWPFormVersionNumber and T1.WWPFormElementId = :WWPFormElementId ORDER BY T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T20,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000T21", "SELECT WWPFormElementTitle AS WWPFormElementParentName, WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T21,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000T22", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T22,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000T23", "SAVEPOINT gxupdate;INSERT INTO WWP_FormElement(WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExpor, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId) VALUES(:WWPFormElementId, :WWPFormElementCaption, :WWPFormElementTitle, :WWPFormElementType, :WWPFormElementOrderIndex, :WWPFormElementDataType, :WWPFormElementMetadata, :WWPFormElementReferenceId, :WWPFormElementExcludeFromExpor, :WWPFormId, :WWPFormVersionNumber, :WWPFormElementParentId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000T23)
          ,new CursorDef("T000T24", "SAVEPOINT gxupdate;UPDATE WWP_FormElement SET WWPFormElementCaption=:WWPFormElementCaption, WWPFormElementTitle=:WWPFormElementTitle, WWPFormElementType=:WWPFormElementType, WWPFormElementOrderIndex=:WWPFormElementOrderIndex, WWPFormElementDataType=:WWPFormElementDataType, WWPFormElementMetadata=:WWPFormElementMetadata, WWPFormElementReferenceId=:WWPFormElementReferenceId, WWPFormElementExcludeFromExpor=:WWPFormElementExcludeFromExpor, WWPFormElementParentId=:WWPFormElementParentId  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000T24)
          ,new CursorDef("T000T25", "SAVEPOINT gxupdate;DELETE FROM WWP_FormElement  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000T25)
          ,new CursorDef("T000T26", "SELECT WWPFormElementTitle AS WWPFormElementParentName, WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T26,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000T27", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId AS WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementParentId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T27,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000T28", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId and WWPFormVersionNumber = :WWPFormVersionNumber ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T28,11, GxCacheFrequency.OFF ,true,false )
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
