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
   public class trn_audit : GXDataArea
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
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_audit.aspx")), "trn_audit.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_audit.aspx")))) ;
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
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7AuditId = StringUtil.StrToGuid( GetPar( "AuditId"));
                  AssignAttri("", false, "AV7AuditId", AV7AuditId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vAUDITID", GetSecureSignedToken( "", AV7AuditId, context));
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  n11OrganisationId = false;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Audit", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAuditDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_audit( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_audit( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_AuditId ,
                           Guid aP2_OrganisationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AuditId = aP1_AuditId;
         this.A11OrganisationId = aP2_OrganisationId;
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
            return "trn_audit_Execute" ;
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
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Audit.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditDate_Internalname, context.GetMessage( "Date", ""), "col-sm-4 AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAuditDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAuditDate_Internalname, context.localUtil.TToC( A372AuditDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A372AuditDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditDate_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtAuditDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Audit.htm");
         GxWebStd.gx_bitmap( context, edtAuditDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAuditDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_Audit.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditDescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAuditDescription_Internalname, A374AuditDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", 0, 1, edtAuditDescription_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditShortDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditShortDescription_Internalname, context.GetMessage( "Short Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAuditShortDescription_Internalname, A375AuditShortDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", 0, 1, edtAuditShortDescription_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditUserName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditUserName_Internalname, context.GetMessage( "User Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditUserName_Internalname, A377AuditUserName, StringUtil.RTrim( context.localUtil.Format( A377AuditUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditUserName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAuditUserName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditAction_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditAction_Internalname, context.GetMessage( "Action", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditAction_Internalname, A378AuditAction, StringUtil.RTrim( context.localUtil.Format( A378AuditAction, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditAction_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAuditAction_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedorganisationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockorganisationid_Internalname, context.GetMessage( "Organisations", ""), "", "", lblTextblockorganisationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_organisationid.SetProperty("Caption", Combo_organisationid_Caption);
         ucCombo_organisationid.SetProperty("Cls", Combo_organisationid_Cls);
         ucCombo_organisationid.SetProperty("DataListProc", Combo_organisationid_Datalistproc);
         ucCombo_organisationid.SetProperty("DataListProcParametersPrefix", Combo_organisationid_Datalistprocparametersprefix);
         ucCombo_organisationid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_organisationid.SetProperty("DropDownOptionsData", AV15OrganisationId_Data);
         ucCombo_organisationid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_organisationid_Internalname, "COMBO_ORGANISATIONIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationId_Internalname, context.GetMessage( "Organisation Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditTableDiaplayName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditTableDiaplayName_Internalname, context.GetMessage( "Table Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditTableDiaplayName_Internalname, A491AuditTableDiaplayName, StringUtil.RTrim( context.localUtil.Format( A491AuditTableDiaplayName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditTableDiaplayName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAuditTableDiaplayName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Audit.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "ButtonMaterial hidden-xs hidden-sm hidden-md hidden-lg";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault hidden-xs hidden-sm hidden-md hidden-lg";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault hidden-xs hidden-sm hidden-md hidden-lg";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Audit.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_organisationid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboorganisationid_Internalname, AV20ComboOrganisationId.ToString(), AV20ComboOrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboorganisationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboorganisationid_Visible, edtavComboorganisationid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditId_Internalname, A371AuditId.ToString(), A371AuditId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditId_Jsonclick, 0, "Attribute", "", "", "", "", edtAuditId_Visible, edtAuditId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Audit.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditTableName_Internalname, A373AuditTableName, StringUtil.RTrim( context.localUtil.Format( A373AuditTableName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditTableName_Jsonclick, 0, "Attribute", "", "", "", "", edtAuditTableName_Visible, edtAuditTableName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Audit.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGAMUserId_Internalname, StringUtil.RTrim( A376GAMUserId), StringUtil.RTrim( context.localUtil.Format( A376GAMUserId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGAMUserId_Jsonclick, 0, "Attribute", "", "", "", "", edtGAMUserId_Visible, edtGAMUserId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_Trn_Audit.htm");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAuditDisplayDescription_Internalname, A419AuditDisplayDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", 0, edtAuditDisplayDescription_Visible, edtAuditDisplayDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         E11162 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vORGANISATIONID_DATA"), AV15OrganisationId_Data);
               /* Read saved values. */
               Z371AuditId = StringUtil.StrToGuid( cgiGet( "Z371AuditId"));
               Z372AuditDate = context.localUtil.CToT( cgiGet( "Z372AuditDate"), 0);
               Z373AuditTableName = cgiGet( "Z373AuditTableName");
               Z375AuditShortDescription = cgiGet( "Z375AuditShortDescription");
               Z376GAMUserId = cgiGet( "Z376GAMUserId");
               Z377AuditUserName = cgiGet( "Z377AuditUserName");
               Z378AuditAction = cgiGet( "Z378AuditAction");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N11OrganisationId = StringUtil.StrToGuid( cgiGet( "N11OrganisationId"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               AV7AuditId = StringUtil.StrToGuid( cgiGet( "vAUDITID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_OrganisationId = StringUtil.StrToGuid( cgiGet( "vINSERT_ORGANISATIONID"));
               AV23Pgmname = cgiGet( "vPGMNAME");
               Combo_organisationid_Objectcall = cgiGet( "COMBO_ORGANISATIONID_Objectcall");
               Combo_organisationid_Class = cgiGet( "COMBO_ORGANISATIONID_Class");
               Combo_organisationid_Icontype = cgiGet( "COMBO_ORGANISATIONID_Icontype");
               Combo_organisationid_Icon = cgiGet( "COMBO_ORGANISATIONID_Icon");
               Combo_organisationid_Caption = cgiGet( "COMBO_ORGANISATIONID_Caption");
               Combo_organisationid_Tooltip = cgiGet( "COMBO_ORGANISATIONID_Tooltip");
               Combo_organisationid_Cls = cgiGet( "COMBO_ORGANISATIONID_Cls");
               Combo_organisationid_Selectedvalue_set = cgiGet( "COMBO_ORGANISATIONID_Selectedvalue_set");
               Combo_organisationid_Selectedvalue_get = cgiGet( "COMBO_ORGANISATIONID_Selectedvalue_get");
               Combo_organisationid_Selectedtext_set = cgiGet( "COMBO_ORGANISATIONID_Selectedtext_set");
               Combo_organisationid_Selectedtext_get = cgiGet( "COMBO_ORGANISATIONID_Selectedtext_get");
               Combo_organisationid_Gamoauthtoken = cgiGet( "COMBO_ORGANISATIONID_Gamoauthtoken");
               Combo_organisationid_Ddointernalname = cgiGet( "COMBO_ORGANISATIONID_Ddointernalname");
               Combo_organisationid_Titlecontrolalign = cgiGet( "COMBO_ORGANISATIONID_Titlecontrolalign");
               Combo_organisationid_Dropdownoptionstype = cgiGet( "COMBO_ORGANISATIONID_Dropdownoptionstype");
               Combo_organisationid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Enabled"));
               Combo_organisationid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Visible"));
               Combo_organisationid_Titlecontrolidtoreplace = cgiGet( "COMBO_ORGANISATIONID_Titlecontrolidtoreplace");
               Combo_organisationid_Datalisttype = cgiGet( "COMBO_ORGANISATIONID_Datalisttype");
               Combo_organisationid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Allowmultipleselection"));
               Combo_organisationid_Datalistfixedvalues = cgiGet( "COMBO_ORGANISATIONID_Datalistfixedvalues");
               Combo_organisationid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Isgriditem"));
               Combo_organisationid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Hasdescription"));
               Combo_organisationid_Datalistproc = cgiGet( "COMBO_ORGANISATIONID_Datalistproc");
               Combo_organisationid_Datalistprocparametersprefix = cgiGet( "COMBO_ORGANISATIONID_Datalistprocparametersprefix");
               Combo_organisationid_Remoteservicesparameters = cgiGet( "COMBO_ORGANISATIONID_Remoteservicesparameters");
               Combo_organisationid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ORGANISATIONID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_organisationid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Includeonlyselectedoption"));
               Combo_organisationid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Includeselectalloption"));
               Combo_organisationid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Emptyitem"));
               Combo_organisationid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Includeaddnewoption"));
               Combo_organisationid_Htmltemplate = cgiGet( "COMBO_ORGANISATIONID_Htmltemplate");
               Combo_organisationid_Multiplevaluestype = cgiGet( "COMBO_ORGANISATIONID_Multiplevaluestype");
               Combo_organisationid_Loadingdata = cgiGet( "COMBO_ORGANISATIONID_Loadingdata");
               Combo_organisationid_Noresultsfound = cgiGet( "COMBO_ORGANISATIONID_Noresultsfound");
               Combo_organisationid_Emptyitemtext = cgiGet( "COMBO_ORGANISATIONID_Emptyitemtext");
               Combo_organisationid_Onlyselectedvalues = cgiGet( "COMBO_ORGANISATIONID_Onlyselectedvalues");
               Combo_organisationid_Selectalltext = cgiGet( "COMBO_ORGANISATIONID_Selectalltext");
               Combo_organisationid_Multiplevaluesseparator = cgiGet( "COMBO_ORGANISATIONID_Multiplevaluesseparator");
               Combo_organisationid_Addnewoptiontext = cgiGet( "COMBO_ORGANISATIONID_Addnewoptiontext");
               /* Read variables values. */
               if ( context.localUtil.VCDateTime( cgiGet( edtAuditDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Audit Date", "")}), 1, "AUDITDATE");
                  AnyError = 1;
                  GX_FocusControl = edtAuditDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A372AuditDate = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A372AuditDate", context.localUtil.TToC( A372AuditDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A372AuditDate = context.localUtil.CToT( cgiGet( edtAuditDate_Internalname));
                  AssignAttri("", false, "A372AuditDate", context.localUtil.TToC( A372AuditDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               A374AuditDescription = cgiGet( edtAuditDescription_Internalname);
               AssignAttri("", false, "A374AuditDescription", A374AuditDescription);
               A375AuditShortDescription = cgiGet( edtAuditShortDescription_Internalname);
               AssignAttri("", false, "A375AuditShortDescription", A375AuditShortDescription);
               A377AuditUserName = cgiGet( edtAuditUserName_Internalname);
               AssignAttri("", false, "A377AuditUserName", A377AuditUserName);
               A378AuditAction = cgiGet( edtAuditAction_Internalname);
               AssignAttri("", false, "A378AuditAction", A378AuditAction);
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
               n11OrganisationId = false;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               A491AuditTableDiaplayName = cgiGet( edtAuditTableDiaplayName_Internalname);
               AssignAttri("", false, "A491AuditTableDiaplayName", A491AuditTableDiaplayName);
               AV20ComboOrganisationId = StringUtil.StrToGuid( cgiGet( edtavComboorganisationid_Internalname));
               AssignAttri("", false, "AV20ComboOrganisationId", AV20ComboOrganisationId.ToString());
               if ( StringUtil.StrCmp(cgiGet( edtAuditId_Internalname), "") == 0 )
               {
                  A371AuditId = Guid.Empty;
                  AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
               }
               else
               {
                  try
                  {
                     A371AuditId = StringUtil.StrToGuid( cgiGet( edtAuditId_Internalname));
                     AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "AUDITID");
                     AnyError = 1;
                     GX_FocusControl = edtAuditId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A373AuditTableName = cgiGet( edtAuditTableName_Internalname);
               AssignAttri("", false, "A373AuditTableName", A373AuditTableName);
               A376GAMUserId = cgiGet( edtGAMUserId_Internalname);
               AssignAttri("", false, "A376GAMUserId", A376GAMUserId);
               A419AuditDisplayDescription = cgiGet( edtAuditDisplayDescription_Internalname);
               AssignAttri("", false, "A419AuditDisplayDescription", A419AuditDisplayDescription);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Audit");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A371AuditId != Z371AuditId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_audit:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A371AuditId = StringUtil.StrToGuid( GetPar( "AuditId"));
                  AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7AuditId) )
                  {
                     A371AuditId = AV7AuditId;
                     AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A371AuditId) && ( Gx_BScreen == 0 ) )
                     {
                        A371AuditId = Guid.NewGuid( );
                        AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode73 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7AuditId) )
                     {
                        A371AuditId = AV7AuditId;
                        AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A371AuditId) && ( Gx_BScreen == 0 ) )
                        {
                           A371AuditId = Guid.NewGuid( );
                           AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
                        }
                     }
                     Gx_mode = sMode73;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound73 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_160( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "AUDITID");
                        AnyError = 1;
                        GX_FocusControl = edtAuditId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_ORGANISATIONID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_organisationid.Onoptionclicked */
                           E12162 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11162 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E13162 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            E13162 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1673( ) ;
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
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes1673( ) ;
         }
         AssignProp("", false, edtavComboorganisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationid_Enabled), 5, 0), true);
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

      protected void CONFIRM_160( )
      {
         BeforeValidate1673( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1673( ) ;
            }
            else
            {
               CheckExtendedTable1673( ) ;
               CloseExtendedTableCursors1673( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption160( )
      {
      }

      protected void E11162( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV22GAMErrors);
         Combo_organisationid_Gamoauthtoken = AV21GAMSession.gxTpr_Token;
         ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "GAMOAuthToken", Combo_organisationid_Gamoauthtoken);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         AV20ComboOrganisationId = Guid.Empty;
         AssignAttri("", false, "AV20ComboOrganisationId", AV20ComboOrganisationId.ToString());
         edtavComboorganisationid_Visible = 0;
         AssignProp("", false, edtavComboorganisationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboorganisationid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOORGANISATIONID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            while ( AV24GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV13Insert_OrganisationId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV13Insert_OrganisationId", AV13Insert_OrganisationId.ToString());
                  if ( ! (Guid.Empty==AV13Insert_OrganisationId) )
                  {
                     AV20ComboOrganisationId = AV13Insert_OrganisationId;
                     AssignAttri("", false, "AV20ComboOrganisationId", AV20ComboOrganisationId.ToString());
                     Combo_organisationid_Selectedvalue_set = StringUtil.Trim( AV20ComboOrganisationId.ToString());
                     ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedValue_set", Combo_organisationid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new trn_auditloaddvcombo(context ).execute(  "OrganisationId",  "GET",  false,  AV7AuditId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_organisationid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedText_set", Combo_organisationid_Selectedtext_set);
                     Combo_organisationid_Enabled = false;
                     ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_organisationid_Enabled));
                  }
               }
               AV24GXV1 = (int)(AV24GXV1+1);
               AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            }
         }
         edtAuditId_Visible = 0;
         AssignProp("", false, edtAuditId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditId_Visible), 5, 0), true);
         edtAuditTableName_Visible = 0;
         AssignProp("", false, edtAuditTableName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditTableName_Visible), 5, 0), true);
         edtGAMUserId_Visible = 0;
         AssignProp("", false, edtGAMUserId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtGAMUserId_Visible), 5, 0), true);
         edtAuditDisplayDescription_Visible = 0;
         AssignProp("", false, edtAuditDisplayDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditDisplayDescription_Visible), 5, 0), true);
      }

      protected void E13162( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_auditww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E12162( )
      {
         /* Combo_organisationid_Onoptionclicked Routine */
         returnInSub = false;
         AV20ComboOrganisationId = StringUtil.StrToGuid( Combo_organisationid_Selectedvalue_get);
         AssignAttri("", false, "AV20ComboOrganisationId", AV20ComboOrganisationId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADCOMBOORGANISATIONID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new trn_auditloaddvcombo(context ).execute(  "OrganisationId",  Gx_mode,  false,  AV7AuditId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_organisationid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedValue_set", Combo_organisationid_Selectedvalue_set);
         Combo_organisationid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedText_set", Combo_organisationid_Selectedtext_set);
         AV20ComboOrganisationId = StringUtil.StrToGuid( AV17ComboSelectedValue);
         AssignAttri("", false, "AV20ComboOrganisationId", AV20ComboOrganisationId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_organisationid_Enabled = false;
            ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_organisationid_Enabled));
         }
      }

      protected void ZM1673( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z372AuditDate = T00163_A372AuditDate[0];
               Z373AuditTableName = T00163_A373AuditTableName[0];
               Z375AuditShortDescription = T00163_A375AuditShortDescription[0];
               Z376GAMUserId = T00163_A376GAMUserId[0];
               Z377AuditUserName = T00163_A377AuditUserName[0];
               Z378AuditAction = T00163_A378AuditAction[0];
            }
            else
            {
               Z372AuditDate = A372AuditDate;
               Z373AuditTableName = A373AuditTableName;
               Z375AuditShortDescription = A375AuditShortDescription;
               Z376GAMUserId = A376GAMUserId;
               Z377AuditUserName = A377AuditUserName;
               Z378AuditAction = A378AuditAction;
            }
         }
         if ( GX_JID == -12 )
         {
            Z11OrganisationId = A11OrganisationId;
            Z371AuditId = A371AuditId;
            Z372AuditDate = A372AuditDate;
            Z373AuditTableName = A373AuditTableName;
            Z374AuditDescription = A374AuditDescription;
            Z375AuditShortDescription = A375AuditShortDescription;
            Z376GAMUserId = A376GAMUserId;
            Z377AuditUserName = A377AuditUserName;
            Z378AuditAction = A378AuditAction;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV23Pgmname = "Trn_Audit";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7AuditId) )
         {
            edtAuditId_Enabled = 0;
            AssignProp("", false, edtAuditId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditId_Enabled), 5, 0), true);
         }
         else
         {
            edtAuditId_Enabled = 1;
            AssignProp("", false, edtAuditId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7AuditId) )
         {
            edtAuditId_Enabled = 0;
            AssignProp("", false, edtAuditId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditId_Enabled), 5, 0), true);
         }
         /* Using cursor T00164 */
         pr_default.execute(2, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationId_Enabled = 1;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
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
         if ( ! (Guid.Empty==AV7AuditId) )
         {
            A371AuditId = AV7AuditId;
            AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A371AuditId) && ( Gx_BScreen == 0 ) )
            {
               A371AuditId = Guid.NewGuid( );
               AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_OrganisationId) )
            {
               A11OrganisationId = AV13Insert_OrganisationId;
               n11OrganisationId = false;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            }
            else
            {
               if ( (Guid.Empty==AV20ComboOrganisationId) )
               {
                  A11OrganisationId = Guid.Empty;
                  n11OrganisationId = false;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  n11OrganisationId = true;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
               else
               {
                  if ( ! (Guid.Empty==AV20ComboOrganisationId) )
                  {
                     A11OrganisationId = AV20ComboOrganisationId;
                     n11OrganisationId = false;
                     AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  }
               }
            }
         }
      }

      protected void Load1673( )
      {
         /* Using cursor T00165 */
         pr_default.execute(3, new Object[] {A371AuditId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound73 = 1;
            A372AuditDate = T00165_A372AuditDate[0];
            AssignAttri("", false, "A372AuditDate", context.localUtil.TToC( A372AuditDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A373AuditTableName = T00165_A373AuditTableName[0];
            AssignAttri("", false, "A373AuditTableName", A373AuditTableName);
            A374AuditDescription = T00165_A374AuditDescription[0];
            AssignAttri("", false, "A374AuditDescription", A374AuditDescription);
            A375AuditShortDescription = T00165_A375AuditShortDescription[0];
            AssignAttri("", false, "A375AuditShortDescription", A375AuditShortDescription);
            A376GAMUserId = T00165_A376GAMUserId[0];
            AssignAttri("", false, "A376GAMUserId", A376GAMUserId);
            A377AuditUserName = T00165_A377AuditUserName[0];
            AssignAttri("", false, "A377AuditUserName", A377AuditUserName);
            A378AuditAction = T00165_A378AuditAction[0];
            AssignAttri("", false, "A378AuditAction", A378AuditAction);
            ZM1673( -12) ;
         }
         pr_default.close(3);
         OnLoadActions1673( ) ;
      }

      protected void OnLoadActions1673( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_OrganisationId) )
         {
            A11OrganisationId = AV13Insert_OrganisationId;
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV20ComboOrganisationId) )
            {
               A11OrganisationId = Guid.Empty;
               n11OrganisationId = false;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               n11OrganisationId = true;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            }
            else
            {
               if ( ! (Guid.Empty==AV20ComboOrganisationId) )
               {
                  A11OrganisationId = AV20ComboOrganisationId;
                  n11OrganisationId = false;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
            }
         }
         A491AuditTableDiaplayName = StringUtil.Substring( A373AuditTableName, 5, -1);
         AssignAttri("", false, "A491AuditTableDiaplayName", A491AuditTableDiaplayName);
         A419AuditDisplayDescription = StringUtil.Substring( A375AuditShortDescription, 161, 240);
         AssignAttri("", false, "A419AuditDisplayDescription", A419AuditDisplayDescription);
      }

      protected void CheckExtendedTable1673( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_OrganisationId) )
         {
            A11OrganisationId = AV13Insert_OrganisationId;
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV20ComboOrganisationId) )
            {
               A11OrganisationId = Guid.Empty;
               n11OrganisationId = false;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               n11OrganisationId = true;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            }
            else
            {
               if ( ! (Guid.Empty==AV20ComboOrganisationId) )
               {
                  A11OrganisationId = AV20ComboOrganisationId;
                  n11OrganisationId = false;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
            }
         }
         A491AuditTableDiaplayName = StringUtil.Substring( A373AuditTableName, 5, -1);
         AssignAttri("", false, "A491AuditTableDiaplayName", A491AuditTableDiaplayName);
         A419AuditDisplayDescription = StringUtil.Substring( A375AuditShortDescription, 161, 240);
         AssignAttri("", false, "A419AuditDisplayDescription", A419AuditDisplayDescription);
      }

      protected void CloseExtendedTableCursors1673( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1673( )
      {
         /* Using cursor T00166 */
         pr_default.execute(4, new Object[] {A371AuditId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound73 = 1;
         }
         else
         {
            RcdFound73 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00163 */
         pr_default.execute(1, new Object[] {A371AuditId});
         if ( (pr_default.getStatus(1) != 101) && ( T00163_A11OrganisationId[0] == A11OrganisationId ) )
         {
            ZM1673( 12) ;
            RcdFound73 = 1;
            A371AuditId = T00163_A371AuditId[0];
            AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
            A372AuditDate = T00163_A372AuditDate[0];
            AssignAttri("", false, "A372AuditDate", context.localUtil.TToC( A372AuditDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A373AuditTableName = T00163_A373AuditTableName[0];
            AssignAttri("", false, "A373AuditTableName", A373AuditTableName);
            A374AuditDescription = T00163_A374AuditDescription[0];
            AssignAttri("", false, "A374AuditDescription", A374AuditDescription);
            A375AuditShortDescription = T00163_A375AuditShortDescription[0];
            AssignAttri("", false, "A375AuditShortDescription", A375AuditShortDescription);
            A376GAMUserId = T00163_A376GAMUserId[0];
            AssignAttri("", false, "A376GAMUserId", A376GAMUserId);
            A377AuditUserName = T00163_A377AuditUserName[0];
            AssignAttri("", false, "A377AuditUserName", A377AuditUserName);
            A378AuditAction = T00163_A378AuditAction[0];
            AssignAttri("", false, "A378AuditAction", A378AuditAction);
            Z371AuditId = A371AuditId;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1673( ) ;
            if ( AnyError == 1 )
            {
               RcdFound73 = 0;
               InitializeNonKey1673( ) ;
            }
            Gx_mode = sMode73;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound73 = 0;
            InitializeNonKey1673( ) ;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode73;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1673( ) ;
         if ( RcdFound73 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound73 = 0;
         /* Using cursor T00167 */
         pr_default.execute(5, new Object[] {A371AuditId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T00167_A371AuditId[0], A371AuditId, 0) < 0 ) ) && ( T00167_A11OrganisationId[0] == A11OrganisationId ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T00167_A371AuditId[0], A371AuditId, 0) > 0 ) ) && ( T00167_A11OrganisationId[0] == A11OrganisationId ) )
            {
               A371AuditId = T00167_A371AuditId[0];
               AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
               RcdFound73 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound73 = 0;
         /* Using cursor T00168 */
         pr_default.execute(6, new Object[] {A371AuditId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00168_A371AuditId[0], A371AuditId, 0) > 0 ) ) && ( T00168_A11OrganisationId[0] == A11OrganisationId ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00168_A371AuditId[0], A371AuditId, 0) < 0 ) ) && ( T00168_A11OrganisationId[0] == A11OrganisationId ) )
            {
               A371AuditId = T00168_A371AuditId[0];
               AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
               RcdFound73 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1673( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAuditDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1673( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound73 == 1 )
            {
               if ( A371AuditId != Z371AuditId )
               {
                  A371AuditId = Z371AuditId;
                  AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AUDITID");
                  AnyError = 1;
                  GX_FocusControl = edtAuditId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAuditDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1673( ) ;
                  GX_FocusControl = edtAuditDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A371AuditId != Z371AuditId )
               {
                  /* Insert record */
                  GX_FocusControl = edtAuditDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1673( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AUDITID");
                     AnyError = 1;
                     GX_FocusControl = edtAuditId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtAuditDate_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1673( ) ;
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
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A371AuditId != Z371AuditId )
         {
            A371AuditId = Z371AuditId;
            AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AUDITID");
            AnyError = 1;
            GX_FocusControl = edtAuditId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAuditDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1673( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00162 */
            pr_default.execute(0, new Object[] {A371AuditId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Audit"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z372AuditDate != T00162_A372AuditDate[0] ) || ( StringUtil.StrCmp(Z373AuditTableName, T00162_A373AuditTableName[0]) != 0 ) || ( StringUtil.StrCmp(Z375AuditShortDescription, T00162_A375AuditShortDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z376GAMUserId, T00162_A376GAMUserId[0]) != 0 ) || ( StringUtil.StrCmp(Z377AuditUserName, T00162_A377AuditUserName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z378AuditAction, T00162_A378AuditAction[0]) != 0 ) )
            {
               if ( Z372AuditDate != T00162_A372AuditDate[0] )
               {
                  GXUtil.WriteLog("trn_audit:[seudo value changed for attri]"+"AuditDate");
                  GXUtil.WriteLogRaw("Old: ",Z372AuditDate);
                  GXUtil.WriteLogRaw("Current: ",T00162_A372AuditDate[0]);
               }
               if ( StringUtil.StrCmp(Z373AuditTableName, T00162_A373AuditTableName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_audit:[seudo value changed for attri]"+"AuditTableName");
                  GXUtil.WriteLogRaw("Old: ",Z373AuditTableName);
                  GXUtil.WriteLogRaw("Current: ",T00162_A373AuditTableName[0]);
               }
               if ( StringUtil.StrCmp(Z375AuditShortDescription, T00162_A375AuditShortDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_audit:[seudo value changed for attri]"+"AuditShortDescription");
                  GXUtil.WriteLogRaw("Old: ",Z375AuditShortDescription);
                  GXUtil.WriteLogRaw("Current: ",T00162_A375AuditShortDescription[0]);
               }
               if ( StringUtil.StrCmp(Z376GAMUserId, T00162_A376GAMUserId[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_audit:[seudo value changed for attri]"+"GAMUserId");
                  GXUtil.WriteLogRaw("Old: ",Z376GAMUserId);
                  GXUtil.WriteLogRaw("Current: ",T00162_A376GAMUserId[0]);
               }
               if ( StringUtil.StrCmp(Z377AuditUserName, T00162_A377AuditUserName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_audit:[seudo value changed for attri]"+"AuditUserName");
                  GXUtil.WriteLogRaw("Old: ",Z377AuditUserName);
                  GXUtil.WriteLogRaw("Current: ",T00162_A377AuditUserName[0]);
               }
               if ( StringUtil.StrCmp(Z378AuditAction, T00162_A378AuditAction[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_audit:[seudo value changed for attri]"+"AuditAction");
                  GXUtil.WriteLogRaw("Old: ",Z378AuditAction);
                  GXUtil.WriteLogRaw("Current: ",T00162_A378AuditAction[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Audit"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1673( )
      {
         if ( ! IsAuthorized("trn_audit_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1673( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1673( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1673( 0) ;
            CheckOptimisticConcurrency1673( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1673( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1673( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00169 */
                     pr_default.execute(7, new Object[] {n11OrganisationId, A11OrganisationId, A371AuditId, A372AuditDate, A373AuditTableName, A374AuditDescription, A375AuditShortDescription, A376GAMUserId, A377AuditUserName, A378AuditAction});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Audit");
                     if ( (pr_default.getStatus(7) == 1) )
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
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
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
            else
            {
               Load1673( ) ;
            }
            EndLevel1673( ) ;
         }
         CloseExtendedTableCursors1673( ) ;
      }

      protected void Update1673( )
      {
         if ( ! IsAuthorized("trn_audit_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1673( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1673( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1673( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1673( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1673( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001610 */
                     pr_default.execute(8, new Object[] {n11OrganisationId, A11OrganisationId, A372AuditDate, A373AuditTableName, A374AuditDescription, A375AuditShortDescription, A376GAMUserId, A377AuditUserName, A378AuditAction, A371AuditId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Audit");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Audit"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1673( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
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
            EndLevel1673( ) ;
         }
         CloseExtendedTableCursors1673( ) ;
      }

      protected void DeferredUpdate1673( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_audit_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1673( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1673( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1673( ) ;
            AfterConfirm1673( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1673( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001611 */
                  pr_default.execute(9, new Object[] {A371AuditId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Audit");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
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
         sMode73 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1673( ) ;
         Gx_mode = sMode73;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1673( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A491AuditTableDiaplayName = StringUtil.Substring( A373AuditTableName, 5, -1);
            AssignAttri("", false, "A491AuditTableDiaplayName", A491AuditTableDiaplayName);
            A419AuditDisplayDescription = StringUtil.Substring( A375AuditShortDescription, 161, 240);
            AssignAttri("", false, "A419AuditDisplayDescription", A419AuditDisplayDescription);
         }
      }

      protected void EndLevel1673( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1673( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_audit",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues160( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_audit",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1673( )
      {
         /* Scan By routine */
         /* Using cursor T001612 */
         pr_default.execute(10, new Object[] {n11OrganisationId, A11OrganisationId});
         RcdFound73 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound73 = 1;
            A371AuditId = T001612_A371AuditId[0];
            AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1673( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound73 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound73 = 1;
            A371AuditId = T001612_A371AuditId[0];
            AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
         }
      }

      protected void ScanEnd1673( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1673( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1673( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1673( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1673( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1673( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1673( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1673( )
      {
         edtAuditDate_Enabled = 0;
         AssignProp("", false, edtAuditDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditDate_Enabled), 5, 0), true);
         edtAuditDescription_Enabled = 0;
         AssignProp("", false, edtAuditDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditDescription_Enabled), 5, 0), true);
         edtAuditShortDescription_Enabled = 0;
         AssignProp("", false, edtAuditShortDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditShortDescription_Enabled), 5, 0), true);
         edtAuditUserName_Enabled = 0;
         AssignProp("", false, edtAuditUserName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditUserName_Enabled), 5, 0), true);
         edtAuditAction_Enabled = 0;
         AssignProp("", false, edtAuditAction_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditAction_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtAuditTableDiaplayName_Enabled = 0;
         AssignProp("", false, edtAuditTableDiaplayName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditTableDiaplayName_Enabled), 5, 0), true);
         edtavComboorganisationid_Enabled = 0;
         AssignProp("", false, edtavComboorganisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationid_Enabled), 5, 0), true);
         edtAuditId_Enabled = 0;
         AssignProp("", false, edtAuditId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditId_Enabled), 5, 0), true);
         edtAuditTableName_Enabled = 0;
         AssignProp("", false, edtAuditTableName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditTableName_Enabled), 5, 0), true);
         edtGAMUserId_Enabled = 0;
         AssignProp("", false, edtGAMUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGAMUserId_Enabled), 5, 0), true);
         edtAuditDisplayDescription_Enabled = 0;
         AssignProp("", false, edtAuditDisplayDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditDisplayDescription_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1673( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues160( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_audit.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7AuditId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_audit.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Audit");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_audit:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z371AuditId", Z371AuditId.ToString());
         GxWebStd.gx_hidden_field( context, "Z372AuditDate", context.localUtil.TToC( Z372AuditDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z373AuditTableName", Z373AuditTableName);
         GxWebStd.gx_hidden_field( context, "Z375AuditShortDescription", Z375AuditShortDescription);
         GxWebStd.gx_hidden_field( context, "Z376GAMUserId", StringUtil.RTrim( Z376GAMUserId));
         GxWebStd.gx_hidden_field( context, "Z377AuditUserName", Z377AuditUserName);
         GxWebStd.gx_hidden_field( context, "Z378AuditAction", Z378AuditAction);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N11OrganisationId", A11OrganisationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vORGANISATIONID_DATA", AV15OrganisationId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vORGANISATIONID_DATA", AV15OrganisationId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vAUDITID", AV7AuditId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vAUDITID", GetSecureSignedToken( "", AV7AuditId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ORGANISATIONID", AV13Insert_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV23Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Objectcall", StringUtil.RTrim( Combo_organisationid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Cls", StringUtil.RTrim( Combo_organisationid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Selectedvalue_set", StringUtil.RTrim( Combo_organisationid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Selectedtext_set", StringUtil.RTrim( Combo_organisationid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Gamoauthtoken", StringUtil.RTrim( Combo_organisationid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Enabled", StringUtil.BoolToStr( Combo_organisationid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Datalistproc", StringUtil.RTrim( Combo_organisationid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_organisationid_Datalistprocparametersprefix));
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_audit.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7AuditId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
         return formatLink("trn_audit.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Audit" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Audit", "") ;
      }

      protected void InitializeNonKey1673( )
      {
         A419AuditDisplayDescription = "";
         AssignAttri("", false, "A419AuditDisplayDescription", A419AuditDisplayDescription);
         A491AuditTableDiaplayName = "";
         AssignAttri("", false, "A491AuditTableDiaplayName", A491AuditTableDiaplayName);
         A372AuditDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A372AuditDate", context.localUtil.TToC( A372AuditDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A373AuditTableName = "";
         AssignAttri("", false, "A373AuditTableName", A373AuditTableName);
         A374AuditDescription = "";
         AssignAttri("", false, "A374AuditDescription", A374AuditDescription);
         A375AuditShortDescription = "";
         AssignAttri("", false, "A375AuditShortDescription", A375AuditShortDescription);
         A376GAMUserId = "";
         AssignAttri("", false, "A376GAMUserId", A376GAMUserId);
         A377AuditUserName = "";
         AssignAttri("", false, "A377AuditUserName", A377AuditUserName);
         A378AuditAction = "";
         AssignAttri("", false, "A378AuditAction", A378AuditAction);
         Z372AuditDate = (DateTime)(DateTime.MinValue);
         Z373AuditTableName = "";
         Z375AuditShortDescription = "";
         Z376GAMUserId = "";
         Z377AuditUserName = "";
         Z378AuditAction = "";
      }

      protected void InitAll1673( )
      {
         A371AuditId = Guid.NewGuid( );
         AssignAttri("", false, "A371AuditId", A371AuditId.ToString());
         InitializeNonKey1673( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145354279", true, true);
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
         context.AddJavascriptSource("trn_audit.js", "?20256145354283", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtAuditDate_Internalname = "AUDITDATE";
         edtAuditDescription_Internalname = "AUDITDESCRIPTION";
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION";
         edtAuditUserName_Internalname = "AUDITUSERNAME";
         edtAuditAction_Internalname = "AUDITACTION";
         lblTextblockorganisationid_Internalname = "TEXTBLOCKORGANISATIONID";
         Combo_organisationid_Internalname = "COMBO_ORGANISATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         divTablesplittedorganisationid_Internalname = "TABLESPLITTEDORGANISATIONID";
         edtAuditTableDiaplayName_Internalname = "AUDITTABLEDIAPLAYNAME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboorganisationid_Internalname = "vCOMBOORGANISATIONID";
         divSectionattribute_organisationid_Internalname = "SECTIONATTRIBUTE_ORGANISATIONID";
         edtAuditId_Internalname = "AUDITID";
         edtAuditTableName_Internalname = "AUDITTABLENAME";
         edtGAMUserId_Internalname = "GAMUSERID";
         edtAuditDisplayDescription_Internalname = "AUDITDISPLAYDESCRIPTION";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
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
         Form.Caption = context.GetMessage( "Trn_Audit", "");
         edtAuditDisplayDescription_Enabled = 0;
         edtAuditDisplayDescription_Visible = 1;
         edtGAMUserId_Jsonclick = "";
         edtGAMUserId_Enabled = 1;
         edtGAMUserId_Visible = 1;
         edtAuditTableName_Jsonclick = "";
         edtAuditTableName_Enabled = 1;
         edtAuditTableName_Visible = 1;
         edtAuditId_Jsonclick = "";
         edtAuditId_Enabled = 1;
         edtAuditId_Visible = 1;
         edtavComboorganisationid_Jsonclick = "";
         edtavComboorganisationid_Enabled = 0;
         edtavComboorganisationid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtAuditTableDiaplayName_Jsonclick = "";
         edtAuditTableDiaplayName_Enabled = 0;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 0;
         edtOrganisationId_Visible = 1;
         Combo_organisationid_Datalistprocparametersprefix = " \"ComboName\": \"OrganisationId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"AuditId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_organisationid_Datalistproc = "Trn_AuditLoadDVCombo";
         Combo_organisationid_Cls = "ExtendedCombo Attribute";
         Combo_organisationid_Caption = "";
         Combo_organisationid_Enabled = Convert.ToBoolean( -1);
         edtAuditAction_Jsonclick = "";
         edtAuditAction_Enabled = 1;
         edtAuditUserName_Jsonclick = "";
         edtAuditUserName_Enabled = 1;
         edtAuditShortDescription_Enabled = 1;
         edtAuditDescription_Enabled = 1;
         edtAuditDate_Jsonclick = "";
         edtAuditDate_Enabled = 1;
         divLayoutmaintable_Class = "Table";
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7AuditId","fld":"vAUDITID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7AuditId","fld":"vAUDITID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E13162","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_ORGANISATIONID.ONOPTIONCLICKED","""{"handler":"E12162","iparms":[{"av":"Combo_organisationid_Selectedvalue_get","ctrl":"COMBO_ORGANISATIONID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_ORGANISATIONID.ONOPTIONCLICKED",""","oparms":[{"av":"AV20ComboOrganisationId","fld":"vCOMBOORGANISATIONID"}]}""");
         setEventMetadata("VALID_AUDITSHORTDESCRIPTION","""{"handler":"Valid_Auditshortdescription","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOORGANISATIONID","""{"handler":"Validv_Comboorganisationid","iparms":[]}""");
         setEventMetadata("VALID_AUDITID","""{"handler":"Valid_Auditid","iparms":[]}""");
         setEventMetadata("VALID_AUDITTABLENAME","""{"handler":"Valid_Audittablename","iparms":[]}""");
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
         wcpOGx_mode = "";
         wcpOAV7AuditId = Guid.Empty;
         wcpOA11OrganisationId = Guid.Empty;
         Z371AuditId = Guid.Empty;
         Z372AuditDate = (DateTime)(DateTime.MinValue);
         Z373AuditTableName = "";
         Z375AuditShortDescription = "";
         Z376GAMUserId = "";
         Z377AuditUserName = "";
         Z378AuditAction = "";
         Combo_organisationid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A372AuditDate = (DateTime)(DateTime.MinValue);
         A374AuditDescription = "";
         A375AuditShortDescription = "";
         A377AuditUserName = "";
         A378AuditAction = "";
         lblTextblockorganisationid_Jsonclick = "";
         ucCombo_organisationid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15OrganisationId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A491AuditTableDiaplayName = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV20ComboOrganisationId = Guid.Empty;
         A371AuditId = Guid.Empty;
         A373AuditTableName = "";
         A376GAMUserId = "";
         A419AuditDisplayDescription = "";
         AV13Insert_OrganisationId = Guid.Empty;
         AV23Pgmname = "";
         Combo_organisationid_Objectcall = "";
         Combo_organisationid_Class = "";
         Combo_organisationid_Icontype = "";
         Combo_organisationid_Icon = "";
         Combo_organisationid_Tooltip = "";
         Combo_organisationid_Selectedvalue_set = "";
         Combo_organisationid_Selectedtext_set = "";
         Combo_organisationid_Selectedtext_get = "";
         Combo_organisationid_Gamoauthtoken = "";
         Combo_organisationid_Ddointernalname = "";
         Combo_organisationid_Titlecontrolalign = "";
         Combo_organisationid_Dropdownoptionstype = "";
         Combo_organisationid_Titlecontrolidtoreplace = "";
         Combo_organisationid_Datalisttype = "";
         Combo_organisationid_Datalistfixedvalues = "";
         Combo_organisationid_Remoteservicesparameters = "";
         Combo_organisationid_Htmltemplate = "";
         Combo_organisationid_Multiplevaluestype = "";
         Combo_organisationid_Loadingdata = "";
         Combo_organisationid_Noresultsfound = "";
         Combo_organisationid_Emptyitemtext = "";
         Combo_organisationid_Onlyselectedvalues = "";
         Combo_organisationid_Selectalltext = "";
         Combo_organisationid_Multiplevaluesseparator = "";
         Combo_organisationid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode73 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV22GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_char2 = "";
         Z11OrganisationId = Guid.Empty;
         Z374AuditDescription = "";
         T00164_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00164_n11OrganisationId = new bool[] {false} ;
         T00165_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00165_n11OrganisationId = new bool[] {false} ;
         T00165_A371AuditId = new Guid[] {Guid.Empty} ;
         T00165_A372AuditDate = new DateTime[] {DateTime.MinValue} ;
         T00165_A373AuditTableName = new string[] {""} ;
         T00165_A374AuditDescription = new string[] {""} ;
         T00165_A375AuditShortDescription = new string[] {""} ;
         T00165_A376GAMUserId = new string[] {""} ;
         T00165_A377AuditUserName = new string[] {""} ;
         T00165_A378AuditAction = new string[] {""} ;
         T00166_A371AuditId = new Guid[] {Guid.Empty} ;
         T00163_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00163_n11OrganisationId = new bool[] {false} ;
         T00163_A371AuditId = new Guid[] {Guid.Empty} ;
         T00163_A372AuditDate = new DateTime[] {DateTime.MinValue} ;
         T00163_A373AuditTableName = new string[] {""} ;
         T00163_A374AuditDescription = new string[] {""} ;
         T00163_A375AuditShortDescription = new string[] {""} ;
         T00163_A376GAMUserId = new string[] {""} ;
         T00163_A377AuditUserName = new string[] {""} ;
         T00163_A378AuditAction = new string[] {""} ;
         T00167_A371AuditId = new Guid[] {Guid.Empty} ;
         T00167_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00167_n11OrganisationId = new bool[] {false} ;
         T00168_A371AuditId = new Guid[] {Guid.Empty} ;
         T00168_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00168_n11OrganisationId = new bool[] {false} ;
         T00162_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00162_n11OrganisationId = new bool[] {false} ;
         T00162_A371AuditId = new Guid[] {Guid.Empty} ;
         T00162_A372AuditDate = new DateTime[] {DateTime.MinValue} ;
         T00162_A373AuditTableName = new string[] {""} ;
         T00162_A374AuditDescription = new string[] {""} ;
         T00162_A375AuditShortDescription = new string[] {""} ;
         T00162_A376GAMUserId = new string[] {""} ;
         T00162_A377AuditUserName = new string[] {""} ;
         T00162_A378AuditAction = new string[] {""} ;
         T001612_A371AuditId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_audit__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_audit__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_audit__default(),
            new Object[][] {
                new Object[] {
               T00162_A11OrganisationId, T00162_n11OrganisationId, T00162_A371AuditId, T00162_A372AuditDate, T00162_A373AuditTableName, T00162_A374AuditDescription, T00162_A375AuditShortDescription, T00162_A376GAMUserId, T00162_A377AuditUserName, T00162_A378AuditAction
               }
               , new Object[] {
               T00163_A11OrganisationId, T00163_n11OrganisationId, T00163_A371AuditId, T00163_A372AuditDate, T00163_A373AuditTableName, T00163_A374AuditDescription, T00163_A375AuditShortDescription, T00163_A376GAMUserId, T00163_A377AuditUserName, T00163_A378AuditAction
               }
               , new Object[] {
               T00164_A11OrganisationId
               }
               , new Object[] {
               T00165_A11OrganisationId, T00165_n11OrganisationId, T00165_A371AuditId, T00165_A372AuditDate, T00165_A373AuditTableName, T00165_A374AuditDescription, T00165_A375AuditShortDescription, T00165_A376GAMUserId, T00165_A377AuditUserName, T00165_A378AuditAction
               }
               , new Object[] {
               T00166_A371AuditId
               }
               , new Object[] {
               T00167_A371AuditId, T00167_A11OrganisationId, T00167_n11OrganisationId
               }
               , new Object[] {
               T00168_A371AuditId, T00168_A11OrganisationId, T00168_n11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001612_A371AuditId
               }
            }
         );
         N11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         Z11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         Z371AuditId = Guid.NewGuid( );
         A371AuditId = Guid.NewGuid( );
         AV23Pgmname = "Trn_Audit";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound73 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtAuditDate_Enabled ;
      private int edtAuditDescription_Enabled ;
      private int edtAuditShortDescription_Enabled ;
      private int edtAuditUserName_Enabled ;
      private int edtAuditAction_Enabled ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int edtAuditTableDiaplayName_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboorganisationid_Visible ;
      private int edtavComboorganisationid_Enabled ;
      private int edtAuditId_Visible ;
      private int edtAuditId_Enabled ;
      private int edtAuditTableName_Visible ;
      private int edtAuditTableName_Enabled ;
      private int edtGAMUserId_Visible ;
      private int edtGAMUserId_Enabled ;
      private int edtAuditDisplayDescription_Visible ;
      private int edtAuditDisplayDescription_Enabled ;
      private int Combo_organisationid_Datalistupdateminimumcharacters ;
      private int AV24GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z376GAMUserId ;
      private string Combo_organisationid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAuditDate_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtAuditDate_Jsonclick ;
      private string edtAuditDescription_Internalname ;
      private string edtAuditShortDescription_Internalname ;
      private string edtAuditUserName_Internalname ;
      private string edtAuditUserName_Jsonclick ;
      private string edtAuditAction_Internalname ;
      private string edtAuditAction_Jsonclick ;
      private string divTablesplittedorganisationid_Internalname ;
      private string lblTextblockorganisationid_Internalname ;
      private string lblTextblockorganisationid_Jsonclick ;
      private string Combo_organisationid_Caption ;
      private string Combo_organisationid_Cls ;
      private string Combo_organisationid_Datalistproc ;
      private string Combo_organisationid_Datalistprocparametersprefix ;
      private string Combo_organisationid_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtAuditTableDiaplayName_Internalname ;
      private string edtAuditTableDiaplayName_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_organisationid_Internalname ;
      private string edtavComboorganisationid_Internalname ;
      private string edtavComboorganisationid_Jsonclick ;
      private string edtAuditId_Internalname ;
      private string edtAuditId_Jsonclick ;
      private string edtAuditTableName_Internalname ;
      private string edtAuditTableName_Jsonclick ;
      private string edtGAMUserId_Internalname ;
      private string A376GAMUserId ;
      private string edtGAMUserId_Jsonclick ;
      private string edtAuditDisplayDescription_Internalname ;
      private string AV23Pgmname ;
      private string Combo_organisationid_Objectcall ;
      private string Combo_organisationid_Class ;
      private string Combo_organisationid_Icontype ;
      private string Combo_organisationid_Icon ;
      private string Combo_organisationid_Tooltip ;
      private string Combo_organisationid_Selectedvalue_set ;
      private string Combo_organisationid_Selectedtext_set ;
      private string Combo_organisationid_Selectedtext_get ;
      private string Combo_organisationid_Gamoauthtoken ;
      private string Combo_organisationid_Ddointernalname ;
      private string Combo_organisationid_Titlecontrolalign ;
      private string Combo_organisationid_Dropdownoptionstype ;
      private string Combo_organisationid_Titlecontrolidtoreplace ;
      private string Combo_organisationid_Datalisttype ;
      private string Combo_organisationid_Datalistfixedvalues ;
      private string Combo_organisationid_Remoteservicesparameters ;
      private string Combo_organisationid_Htmltemplate ;
      private string Combo_organisationid_Multiplevaluestype ;
      private string Combo_organisationid_Loadingdata ;
      private string Combo_organisationid_Noresultsfound ;
      private string Combo_organisationid_Emptyitemtext ;
      private string Combo_organisationid_Onlyselectedvalues ;
      private string Combo_organisationid_Selectalltext ;
      private string Combo_organisationid_Multiplevaluesseparator ;
      private string Combo_organisationid_Addnewoptiontext ;
      private string hsh ;
      private string sMode73 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z372AuditDate ;
      private DateTime A372AuditDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n11OrganisationId ;
      private bool wbErr ;
      private bool Combo_organisationid_Enabled ;
      private bool Combo_organisationid_Visible ;
      private bool Combo_organisationid_Allowmultipleselection ;
      private bool Combo_organisationid_Isgriditem ;
      private bool Combo_organisationid_Hasdescription ;
      private bool Combo_organisationid_Includeonlyselectedoption ;
      private bool Combo_organisationid_Includeselectalloption ;
      private bool Combo_organisationid_Emptyitem ;
      private bool Combo_organisationid_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string A374AuditDescription ;
      private string AV19Combo_DataJson ;
      private string Z374AuditDescription ;
      private string Z373AuditTableName ;
      private string Z375AuditShortDescription ;
      private string Z377AuditUserName ;
      private string Z378AuditAction ;
      private string A375AuditShortDescription ;
      private string A377AuditUserName ;
      private string A378AuditAction ;
      private string A491AuditTableDiaplayName ;
      private string A373AuditTableName ;
      private string A419AuditDisplayDescription ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private Guid wcpOAV7AuditId ;
      private Guid wcpOA11OrganisationId ;
      private Guid Z371AuditId ;
      private Guid N11OrganisationId ;
      private Guid AV7AuditId ;
      private Guid A11OrganisationId ;
      private Guid AV20ComboOrganisationId ;
      private Guid A371AuditId ;
      private Guid AV13Insert_OrganisationId ;
      private Guid Z11OrganisationId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_organisationid ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15OrganisationId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV21GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV22GAMErrors ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] T00164_A11OrganisationId ;
      private bool[] T00164_n11OrganisationId ;
      private Guid[] T00165_A11OrganisationId ;
      private bool[] T00165_n11OrganisationId ;
      private Guid[] T00165_A371AuditId ;
      private DateTime[] T00165_A372AuditDate ;
      private string[] T00165_A373AuditTableName ;
      private string[] T00165_A374AuditDescription ;
      private string[] T00165_A375AuditShortDescription ;
      private string[] T00165_A376GAMUserId ;
      private string[] T00165_A377AuditUserName ;
      private string[] T00165_A378AuditAction ;
      private Guid[] T00166_A371AuditId ;
      private Guid[] T00163_A11OrganisationId ;
      private bool[] T00163_n11OrganisationId ;
      private Guid[] T00163_A371AuditId ;
      private DateTime[] T00163_A372AuditDate ;
      private string[] T00163_A373AuditTableName ;
      private string[] T00163_A374AuditDescription ;
      private string[] T00163_A375AuditShortDescription ;
      private string[] T00163_A376GAMUserId ;
      private string[] T00163_A377AuditUserName ;
      private string[] T00163_A378AuditAction ;
      private Guid[] T00167_A371AuditId ;
      private Guid[] T00167_A11OrganisationId ;
      private bool[] T00167_n11OrganisationId ;
      private Guid[] T00168_A371AuditId ;
      private Guid[] T00168_A11OrganisationId ;
      private bool[] T00168_n11OrganisationId ;
      private Guid[] T00162_A11OrganisationId ;
      private bool[] T00162_n11OrganisationId ;
      private Guid[] T00162_A371AuditId ;
      private DateTime[] T00162_A372AuditDate ;
      private string[] T00162_A373AuditTableName ;
      private string[] T00162_A374AuditDescription ;
      private string[] T00162_A375AuditShortDescription ;
      private string[] T00162_A376GAMUserId ;
      private string[] T00162_A377AuditUserName ;
      private string[] T00162_A378AuditAction ;
      private Guid[] T001612_A371AuditId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_audit__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_audit__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_audit__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT00162;
       prmT00162 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00163;
       prmT00163 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00164;
       prmT00164 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00165;
       prmT00165 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00166;
       prmT00166 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00167;
       prmT00167 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00168;
       prmT00168 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT00169;
       prmT00169 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AuditDate",GXType.DateTime,8,5) ,
       new ParDef("AuditTableName",GXType.VarChar,100,0) ,
       new ParDef("AuditDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("AuditShortDescription",GXType.VarChar,400,0) ,
       new ParDef("GAMUserId",GXType.Char,40,0) ,
       new ParDef("AuditUserName",GXType.VarChar,100,0) ,
       new ParDef("AuditAction",GXType.VarChar,40,0)
       };
       Object[] prmT001610;
       prmT001610 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("AuditDate",GXType.DateTime,8,5) ,
       new ParDef("AuditTableName",GXType.VarChar,100,0) ,
       new ParDef("AuditDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("AuditShortDescription",GXType.VarChar,400,0) ,
       new ParDef("GAMUserId",GXType.Char,40,0) ,
       new ParDef("AuditUserName",GXType.VarChar,100,0) ,
       new ParDef("AuditAction",GXType.VarChar,40,0) ,
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001611;
       prmT001611 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001612;
       prmT001612 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("T00162", "SELECT OrganisationId, AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, GAMUserId, AuditUserName, AuditAction FROM Trn_Audit WHERE AuditId = :AuditId  FOR UPDATE OF Trn_Audit NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00162,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00163", "SELECT OrganisationId, AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, GAMUserId, AuditUserName, AuditAction FROM Trn_Audit WHERE AuditId = :AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00163,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00164", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00164,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00165", "SELECT TM1.OrganisationId, TM1.AuditId, TM1.AuditDate, TM1.AuditTableName, TM1.AuditDescription, TM1.AuditShortDescription, TM1.GAMUserId, TM1.AuditUserName, TM1.AuditAction FROM Trn_Audit TM1 WHERE TM1.AuditId = :AuditId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00165,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00166", "SELECT AuditId FROM Trn_Audit WHERE AuditId = :AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00166,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00167", "SELECT AuditId, OrganisationId FROM Trn_Audit WHERE ( AuditId > :AuditId) and OrganisationId = :OrganisationId ORDER BY AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00167,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T00168", "SELECT AuditId, OrganisationId FROM Trn_Audit WHERE ( AuditId < :AuditId) and OrganisationId = :OrganisationId ORDER BY AuditId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00168,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T00169", "SAVEPOINT gxupdate;INSERT INTO Trn_Audit(OrganisationId, AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, GAMUserId, AuditUserName, AuditAction) VALUES(:OrganisationId, :AuditId, :AuditDate, :AuditTableName, :AuditDescription, :AuditShortDescription, :GAMUserId, :AuditUserName, :AuditAction);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT00169)
          ,new CursorDef("T001610", "SAVEPOINT gxupdate;UPDATE Trn_Audit SET OrganisationId=:OrganisationId, AuditDate=:AuditDate, AuditTableName=:AuditTableName, AuditDescription=:AuditDescription, AuditShortDescription=:AuditShortDescription, GAMUserId=:GAMUserId, AuditUserName=:AuditUserName, AuditAction=:AuditAction  WHERE AuditId = :AuditId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001610)
          ,new CursorDef("T001611", "SAVEPOINT gxupdate;DELETE FROM Trn_Audit  WHERE AuditId = :AuditId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001611)
          ,new CursorDef("T001612", "SELECT AuditId FROM Trn_Audit WHERE OrganisationId = :OrganisationId ORDER BY AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001612,100, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[1])[0] = rslt.wasNull(1);
             ((Guid[]) buf[2])[0] = rslt.getGuid(2);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[4])[0] = rslt.getVarchar(4);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getString(7, 40);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((string[]) buf[9])[0] = rslt.getVarchar(9);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((bool[]) buf[1])[0] = rslt.wasNull(1);
             ((Guid[]) buf[2])[0] = rslt.getGuid(2);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[4])[0] = rslt.getVarchar(4);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getString(7, 40);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((string[]) buf[9])[0] = rslt.getVarchar(9);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((bool[]) buf[1])[0] = rslt.wasNull(1);
             ((Guid[]) buf[2])[0] = rslt.getGuid(2);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[4])[0] = rslt.getVarchar(4);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getString(7, 40);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((string[]) buf[9])[0] = rslt.getVarchar(9);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
