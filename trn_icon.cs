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
   public class trn_icon : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_icon.aspx")), "trn_icon.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_icon.aspx")))) ;
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
                  AV7Trn_IconId = StringUtil.StrToGuid( GetPar( "Trn_IconId"));
                  AssignAttri("", false, "AV7Trn_IconId", AV7Trn_IconId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRN_ICONID", GetSecureSignedToken( "", AV7Trn_IconId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Icon", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTrn_IconId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_icon( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_icon( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_Trn_IconId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7Trn_IconId = aP1_Trn_IconId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTrn_IconCategory = new GXCombobox();
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
            return "trn_icon_Execute" ;
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
         if ( cmbTrn_IconCategory.ItemCount > 0 )
         {
            A654Trn_IconCategory = cmbTrn_IconCategory.getValidValue(A654Trn_IconCategory);
            AssignAttri("", false, "A654Trn_IconCategory", A654Trn_IconCategory);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTrn_IconCategory.CurrentValue = StringUtil.RTrim( A654Trn_IconCategory);
            AssignProp("", false, cmbTrn_IconCategory_Internalname, "Values", cmbTrn_IconCategory.ToJavascriptSource(), true);
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Icon.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_IconId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_IconId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_IconId_Internalname, A649Trn_IconId.ToString(), A649Trn_IconId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_IconId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_IconId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Icon.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIconEnglishName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIconEnglishName_Internalname, context.GetMessage( "English Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIconEnglishName_Internalname, A651IconEnglishName, StringUtil.RTrim( context.localUtil.Format( A651IconEnglishName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIconEnglishName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIconEnglishName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Icon.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIconDutchName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIconDutchName_Internalname, context.GetMessage( "Dutch Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIconDutchName_Internalname, A652IconDutchName, StringUtil.RTrim( context.localUtil.Format( A652IconDutchName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIconDutchName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIconDutchName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Icon.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_IconSVG_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_IconSVG_Internalname, context.GetMessage( "SVG", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTrn_IconSVG_Internalname, A653Trn_IconSVG, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", 0, 1, edtTrn_IconSVG_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Icon.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTrn_IconCategory_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTrn_IconCategory_Internalname, context.GetMessage( "Category", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTrn_IconCategory, cmbTrn_IconCategory_Internalname, StringUtil.RTrim( A654Trn_IconCategory), 1, cmbTrn_IconCategory_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbTrn_IconCategory.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_Trn_Icon.htm");
         cmbTrn_IconCategory.CurrentValue = StringUtil.RTrim( A654Trn_IconCategory);
         AssignProp("", false, cmbTrn_IconCategory_Internalname, "Values", (string)(cmbTrn_IconCategory.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIconEnglishTags_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIconEnglishTags_Internalname, context.GetMessage( "English Tags", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtIconEnglishTags_Internalname, A655IconEnglishTags, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", 0, 1, edtIconEnglishTags_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Icon.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIconDutchTags_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIconDutchTags_Internalname, context.GetMessage( "Dutch Tags", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtIconDutchTags_Internalname, A656IconDutchTags, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", 0, 1, edtIconDutchTags_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Icon.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Icon.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Icon.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Icon.htm");
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
         E111Y2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z649Trn_IconId = StringUtil.StrToGuid( cgiGet( "Z649Trn_IconId"));
               Z657IconDisplayName = cgiGet( "Z657IconDisplayName");
               Z651IconEnglishName = cgiGet( "Z651IconEnglishName");
               Z652IconDutchName = cgiGet( "Z652IconDutchName");
               Z654Trn_IconCategory = cgiGet( "Z654Trn_IconCategory");
               A657IconDisplayName = cgiGet( "Z657IconDisplayName");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7Trn_IconId = StringUtil.StrToGuid( cgiGet( "vTRN_ICONID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A657IconDisplayName = cgiGet( "ICONDISPLAYNAME");
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtTrn_IconId_Internalname), "") == 0 )
               {
                  A649Trn_IconId = Guid.Empty;
                  AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
               }
               else
               {
                  try
                  {
                     A649Trn_IconId = StringUtil.StrToGuid( cgiGet( edtTrn_IconId_Internalname));
                     AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRN_ICONID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_IconId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A651IconEnglishName = cgiGet( edtIconEnglishName_Internalname);
               AssignAttri("", false, "A651IconEnglishName", A651IconEnglishName);
               A652IconDutchName = cgiGet( edtIconDutchName_Internalname);
               AssignAttri("", false, "A652IconDutchName", A652IconDutchName);
               A653Trn_IconSVG = cgiGet( edtTrn_IconSVG_Internalname);
               AssignAttri("", false, "A653Trn_IconSVG", A653Trn_IconSVG);
               cmbTrn_IconCategory.CurrentValue = cgiGet( cmbTrn_IconCategory_Internalname);
               A654Trn_IconCategory = cgiGet( cmbTrn_IconCategory_Internalname);
               AssignAttri("", false, "A654Trn_IconCategory", A654Trn_IconCategory);
               A655IconEnglishTags = cgiGet( edtIconEnglishTags_Internalname);
               AssignAttri("", false, "A655IconEnglishTags", A655IconEnglishTags);
               A656IconDutchTags = cgiGet( edtIconDutchTags_Internalname);
               AssignAttri("", false, "A656IconDutchTags", A656IconDutchTags);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Icon");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("IconDisplayName", StringUtil.RTrim( context.localUtil.Format( A657IconDisplayName, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A649Trn_IconId != Z649Trn_IconId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_icon:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A649Trn_IconId = StringUtil.StrToGuid( GetPar( "Trn_IconId"));
                  AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7Trn_IconId) )
                  {
                     A649Trn_IconId = AV7Trn_IconId;
                     AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A649Trn_IconId) && ( Gx_BScreen == 0 ) )
                     {
                        A649Trn_IconId = Guid.NewGuid( );
                        AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
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
                     sMode109 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7Trn_IconId) )
                     {
                        A649Trn_IconId = AV7Trn_IconId;
                        AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A649Trn_IconId) && ( Gx_BScreen == 0 ) )
                        {
                           A649Trn_IconId = Guid.NewGuid( );
                           AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
                        }
                     }
                     Gx_mode = sMode109;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound109 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1Y0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TRN_ICONID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_IconId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E111Y2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121Y2 ();
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
            E121Y2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1Y109( ) ;
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
            DisableAttributes1Y109( ) ;
         }
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

      protected void CONFIRM_1Y0( )
      {
         BeforeValidate1Y109( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1Y109( ) ;
            }
            else
            {
               CheckExtendedTable1Y109( ) ;
               CloseExtendedTableCursors1Y109( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1Y0( )
      {
      }

      protected void E111Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E121Y2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_iconww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1Y109( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z657IconDisplayName = T001Y3_A657IconDisplayName[0];
               Z651IconEnglishName = T001Y3_A651IconEnglishName[0];
               Z652IconDutchName = T001Y3_A652IconDutchName[0];
               Z654Trn_IconCategory = T001Y3_A654Trn_IconCategory[0];
            }
            else
            {
               Z657IconDisplayName = A657IconDisplayName;
               Z651IconEnglishName = A651IconEnglishName;
               Z652IconDutchName = A652IconDutchName;
               Z654Trn_IconCategory = A654Trn_IconCategory;
            }
         }
         if ( GX_JID == -6 )
         {
            Z649Trn_IconId = A649Trn_IconId;
            Z657IconDisplayName = A657IconDisplayName;
            Z651IconEnglishName = A651IconEnglishName;
            Z652IconDutchName = A652IconDutchName;
            Z653Trn_IconSVG = A653Trn_IconSVG;
            Z654Trn_IconCategory = A654Trn_IconCategory;
            Z655IconEnglishTags = A655IconEnglishTags;
            Z656IconDutchTags = A656IconDutchTags;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7Trn_IconId) )
         {
            edtTrn_IconId_Enabled = 0;
            AssignProp("", false, edtTrn_IconId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_IconId_Enabled), 5, 0), true);
         }
         else
         {
            edtTrn_IconId_Enabled = 1;
            AssignProp("", false, edtTrn_IconId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_IconId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7Trn_IconId) )
         {
            edtTrn_IconId_Enabled = 0;
            AssignProp("", false, edtTrn_IconId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_IconId_Enabled), 5, 0), true);
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
         if ( ! (Guid.Empty==AV7Trn_IconId) )
         {
            A649Trn_IconId = AV7Trn_IconId;
            AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A649Trn_IconId) && ( Gx_BScreen == 0 ) )
            {
               A649Trn_IconId = Guid.NewGuid( );
               AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1Y109( )
      {
         /* Using cursor T001Y4 */
         pr_default.execute(2, new Object[] {A649Trn_IconId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound109 = 1;
            A657IconDisplayName = T001Y4_A657IconDisplayName[0];
            A651IconEnglishName = T001Y4_A651IconEnglishName[0];
            AssignAttri("", false, "A651IconEnglishName", A651IconEnglishName);
            A652IconDutchName = T001Y4_A652IconDutchName[0];
            AssignAttri("", false, "A652IconDutchName", A652IconDutchName);
            A653Trn_IconSVG = T001Y4_A653Trn_IconSVG[0];
            AssignAttri("", false, "A653Trn_IconSVG", A653Trn_IconSVG);
            A654Trn_IconCategory = T001Y4_A654Trn_IconCategory[0];
            AssignAttri("", false, "A654Trn_IconCategory", A654Trn_IconCategory);
            A655IconEnglishTags = T001Y4_A655IconEnglishTags[0];
            AssignAttri("", false, "A655IconEnglishTags", A655IconEnglishTags);
            A656IconDutchTags = T001Y4_A656IconDutchTags[0];
            AssignAttri("", false, "A656IconDutchTags", A656IconDutchTags);
            ZM1Y109( -6) ;
         }
         pr_default.close(2);
         OnLoadActions1Y109( ) ;
      }

      protected void OnLoadActions1Y109( )
      {
      }

      protected void CheckExtendedTable1Y109( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A654Trn_IconCategory, "General") == 0 ) || ( StringUtil.StrCmp(A654Trn_IconCategory, "Services") == 0 ) || ( StringUtil.StrCmp(A654Trn_IconCategory, "Living") == 0 ) || ( StringUtil.StrCmp(A654Trn_IconCategory, "Health") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Trn_Icon Category", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "TRN_ICONCATEGORY");
            AnyError = 1;
            GX_FocusControl = cmbTrn_IconCategory_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1Y109( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1Y109( )
      {
         /* Using cursor T001Y5 */
         pr_default.execute(3, new Object[] {A649Trn_IconId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound109 = 1;
         }
         else
         {
            RcdFound109 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001Y3 */
         pr_default.execute(1, new Object[] {A649Trn_IconId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Y109( 6) ;
            RcdFound109 = 1;
            A649Trn_IconId = T001Y3_A649Trn_IconId[0];
            AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
            A657IconDisplayName = T001Y3_A657IconDisplayName[0];
            A651IconEnglishName = T001Y3_A651IconEnglishName[0];
            AssignAttri("", false, "A651IconEnglishName", A651IconEnglishName);
            A652IconDutchName = T001Y3_A652IconDutchName[0];
            AssignAttri("", false, "A652IconDutchName", A652IconDutchName);
            A653Trn_IconSVG = T001Y3_A653Trn_IconSVG[0];
            AssignAttri("", false, "A653Trn_IconSVG", A653Trn_IconSVG);
            A654Trn_IconCategory = T001Y3_A654Trn_IconCategory[0];
            AssignAttri("", false, "A654Trn_IconCategory", A654Trn_IconCategory);
            A655IconEnglishTags = T001Y3_A655IconEnglishTags[0];
            AssignAttri("", false, "A655IconEnglishTags", A655IconEnglishTags);
            A656IconDutchTags = T001Y3_A656IconDutchTags[0];
            AssignAttri("", false, "A656IconDutchTags", A656IconDutchTags);
            Z649Trn_IconId = A649Trn_IconId;
            sMode109 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1Y109( ) ;
            if ( AnyError == 1 )
            {
               RcdFound109 = 0;
               InitializeNonKey1Y109( ) ;
            }
            Gx_mode = sMode109;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound109 = 0;
            InitializeNonKey1Y109( ) ;
            sMode109 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode109;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Y109( ) ;
         if ( RcdFound109 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound109 = 0;
         /* Using cursor T001Y6 */
         pr_default.execute(4, new Object[] {A649Trn_IconId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001Y6_A649Trn_IconId[0], A649Trn_IconId, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001Y6_A649Trn_IconId[0], A649Trn_IconId, 0) > 0 ) ) )
            {
               A649Trn_IconId = T001Y6_A649Trn_IconId[0];
               AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
               RcdFound109 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound109 = 0;
         /* Using cursor T001Y7 */
         pr_default.execute(5, new Object[] {A649Trn_IconId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001Y7_A649Trn_IconId[0], A649Trn_IconId, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001Y7_A649Trn_IconId[0], A649Trn_IconId, 0) < 0 ) ) )
            {
               A649Trn_IconId = T001Y7_A649Trn_IconId[0];
               AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
               RcdFound109 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1Y109( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrn_IconId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1Y109( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound109 == 1 )
            {
               if ( A649Trn_IconId != Z649Trn_IconId )
               {
                  A649Trn_IconId = Z649Trn_IconId;
                  AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRN_ICONID");
                  AnyError = 1;
                  GX_FocusControl = edtTrn_IconId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrn_IconId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1Y109( ) ;
                  GX_FocusControl = edtTrn_IconId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A649Trn_IconId != Z649Trn_IconId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTrn_IconId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1Y109( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_ICONID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_IconId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTrn_IconId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1Y109( ) ;
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
         if ( A649Trn_IconId != Z649Trn_IconId )
         {
            A649Trn_IconId = Z649Trn_IconId;
            AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRN_ICONID");
            AnyError = 1;
            GX_FocusControl = edtTrn_IconId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrn_IconId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1Y109( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001Y2 */
            pr_default.execute(0, new Object[] {A649Trn_IconId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Icon"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z657IconDisplayName, T001Y2_A657IconDisplayName[0]) != 0 ) || ( StringUtil.StrCmp(Z651IconEnglishName, T001Y2_A651IconEnglishName[0]) != 0 ) || ( StringUtil.StrCmp(Z652IconDutchName, T001Y2_A652IconDutchName[0]) != 0 ) || ( StringUtil.StrCmp(Z654Trn_IconCategory, T001Y2_A654Trn_IconCategory[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z657IconDisplayName, T001Y2_A657IconDisplayName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_icon:[seudo value changed for attri]"+"IconDisplayName");
                  GXUtil.WriteLogRaw("Old: ",Z657IconDisplayName);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A657IconDisplayName[0]);
               }
               if ( StringUtil.StrCmp(Z651IconEnglishName, T001Y2_A651IconEnglishName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_icon:[seudo value changed for attri]"+"IconEnglishName");
                  GXUtil.WriteLogRaw("Old: ",Z651IconEnglishName);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A651IconEnglishName[0]);
               }
               if ( StringUtil.StrCmp(Z652IconDutchName, T001Y2_A652IconDutchName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_icon:[seudo value changed for attri]"+"IconDutchName");
                  GXUtil.WriteLogRaw("Old: ",Z652IconDutchName);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A652IconDutchName[0]);
               }
               if ( StringUtil.StrCmp(Z654Trn_IconCategory, T001Y2_A654Trn_IconCategory[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_icon:[seudo value changed for attri]"+"Trn_IconCategory");
                  GXUtil.WriteLogRaw("Old: ",Z654Trn_IconCategory);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A654Trn_IconCategory[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Icon"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Y109( )
      {
         if ( ! IsAuthorized("trn_icon_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1Y109( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Y109( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Y109( 0) ;
            CheckOptimisticConcurrency1Y109( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Y109( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Y109( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Y8 */
                     pr_default.execute(6, new Object[] {A649Trn_IconId, A657IconDisplayName, A651IconEnglishName, A652IconDutchName, A653Trn_IconSVG, A654Trn_IconCategory, A655IconEnglishTags, A656IconDutchTags});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Icon");
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
               Load1Y109( ) ;
            }
            EndLevel1Y109( ) ;
         }
         CloseExtendedTableCursors1Y109( ) ;
      }

      protected void Update1Y109( )
      {
         if ( ! IsAuthorized("trn_icon_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1Y109( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Y109( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Y109( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Y109( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Y109( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Y9 */
                     pr_default.execute(7, new Object[] {A657IconDisplayName, A651IconEnglishName, A652IconDutchName, A653Trn_IconSVG, A654Trn_IconCategory, A655IconEnglishTags, A656IconDutchTags, A649Trn_IconId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Icon");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Icon"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Y109( ) ;
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
            EndLevel1Y109( ) ;
         }
         CloseExtendedTableCursors1Y109( ) ;
      }

      protected void DeferredUpdate1Y109( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_icon_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1Y109( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Y109( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Y109( ) ;
            AfterConfirm1Y109( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Y109( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001Y10 */
                  pr_default.execute(8, new Object[] {A649Trn_IconId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Icon");
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
         sMode109 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1Y109( ) ;
         Gx_mode = sMode109;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1Y109( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1Y109( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Y109( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_icon",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1Y0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_icon",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1Y109( )
      {
         /* Scan By routine */
         /* Using cursor T001Y11 */
         pr_default.execute(9);
         RcdFound109 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound109 = 1;
            A649Trn_IconId = T001Y11_A649Trn_IconId[0];
            AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1Y109( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound109 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound109 = 1;
            A649Trn_IconId = T001Y11_A649Trn_IconId[0];
            AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
         }
      }

      protected void ScanEnd1Y109( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1Y109( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Y109( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Y109( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Y109( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Y109( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Y109( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Y109( )
      {
         edtTrn_IconId_Enabled = 0;
         AssignProp("", false, edtTrn_IconId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_IconId_Enabled), 5, 0), true);
         edtIconEnglishName_Enabled = 0;
         AssignProp("", false, edtIconEnglishName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconEnglishName_Enabled), 5, 0), true);
         edtIconDutchName_Enabled = 0;
         AssignProp("", false, edtIconDutchName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconDutchName_Enabled), 5, 0), true);
         edtTrn_IconSVG_Enabled = 0;
         AssignProp("", false, edtTrn_IconSVG_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_IconSVG_Enabled), 5, 0), true);
         cmbTrn_IconCategory.Enabled = 0;
         AssignProp("", false, cmbTrn_IconCategory_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTrn_IconCategory.Enabled), 5, 0), true);
         edtIconEnglishTags_Enabled = 0;
         AssignProp("", false, edtIconEnglishTags_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconEnglishTags_Enabled), 5, 0), true);
         edtIconDutchTags_Enabled = 0;
         AssignProp("", false, edtIconDutchTags_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconDutchTags_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1Y109( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1Y0( )
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_icon.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7Trn_IconId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_icon.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Icon");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("IconDisplayName", StringUtil.RTrim( context.localUtil.Format( A657IconDisplayName, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_icon:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z649Trn_IconId", Z649Trn_IconId.ToString());
         GxWebStd.gx_hidden_field( context, "Z657IconDisplayName", Z657IconDisplayName);
         GxWebStd.gx_hidden_field( context, "Z651IconEnglishName", Z651IconEnglishName);
         GxWebStd.gx_hidden_field( context, "Z652IconDutchName", Z652IconDutchName);
         GxWebStd.gx_hidden_field( context, "Z654Trn_IconCategory", Z654Trn_IconCategory);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vTRN_ICONID", AV7Trn_IconId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRN_ICONID", GetSecureSignedToken( "", AV7Trn_IconId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ICONDISPLAYNAME", A657IconDisplayName);
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
         GXEncryptionTmp = "trn_icon.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7Trn_IconId.ToString());
         return formatLink("trn_icon.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Icon" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Icon", "") ;
      }

      protected void InitializeNonKey1Y109( )
      {
         A657IconDisplayName = "";
         AssignAttri("", false, "A657IconDisplayName", A657IconDisplayName);
         A651IconEnglishName = "";
         AssignAttri("", false, "A651IconEnglishName", A651IconEnglishName);
         A652IconDutchName = "";
         AssignAttri("", false, "A652IconDutchName", A652IconDutchName);
         A653Trn_IconSVG = "";
         AssignAttri("", false, "A653Trn_IconSVG", A653Trn_IconSVG);
         A654Trn_IconCategory = "";
         AssignAttri("", false, "A654Trn_IconCategory", A654Trn_IconCategory);
         A655IconEnglishTags = "";
         AssignAttri("", false, "A655IconEnglishTags", A655IconEnglishTags);
         A656IconDutchTags = "";
         AssignAttri("", false, "A656IconDutchTags", A656IconDutchTags);
         Z657IconDisplayName = "";
         Z651IconEnglishName = "";
         Z652IconDutchName = "";
         Z654Trn_IconCategory = "";
      }

      protected void InitAll1Y109( )
      {
         A649Trn_IconId = Guid.NewGuid( );
         AssignAttri("", false, "A649Trn_IconId", A649Trn_IconId.ToString());
         InitializeNonKey1Y109( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256261125399", true, true);
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
         context.AddJavascriptSource("trn_icon.js", "?20256261125399", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTrn_IconId_Internalname = "TRN_ICONID";
         edtIconEnglishName_Internalname = "ICONENGLISHNAME";
         edtIconDutchName_Internalname = "ICONDUTCHNAME";
         edtTrn_IconSVG_Internalname = "TRN_ICONSVG";
         cmbTrn_IconCategory_Internalname = "TRN_ICONCATEGORY";
         edtIconEnglishTags_Internalname = "ICONENGLISHTAGS";
         edtIconDutchTags_Internalname = "ICONDUTCHTAGS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Caption = context.GetMessage( "Trn_Icon", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtIconDutchTags_Enabled = 1;
         edtIconEnglishTags_Enabled = 1;
         cmbTrn_IconCategory_Jsonclick = "";
         cmbTrn_IconCategory.Enabled = 1;
         edtTrn_IconSVG_Enabled = 1;
         edtIconDutchName_Jsonclick = "";
         edtIconDutchName_Enabled = 1;
         edtIconEnglishName_Jsonclick = "";
         edtIconEnglishName_Enabled = 1;
         edtTrn_IconId_Jsonclick = "";
         edtTrn_IconId_Enabled = 1;
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
         cmbTrn_IconCategory.Name = "TRN_ICONCATEGORY";
         cmbTrn_IconCategory.WebTags = "";
         cmbTrn_IconCategory.addItem("General", context.GetMessage( "General", ""), 0);
         cmbTrn_IconCategory.addItem("Services", context.GetMessage( "Services", ""), 0);
         cmbTrn_IconCategory.addItem("Living", context.GetMessage( "Living", ""), 0);
         cmbTrn_IconCategory.addItem("Health", context.GetMessage( "Health", ""), 0);
         if ( cmbTrn_IconCategory.ItemCount > 0 )
         {
            A654Trn_IconCategory = cmbTrn_IconCategory.getValidValue(A654Trn_IconCategory);
            AssignAttri("", false, "A654Trn_IconCategory", A654Trn_IconCategory);
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7Trn_IconId","fld":"vTRN_ICONID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7Trn_IconId","fld":"vTRN_ICONID","hsh":true},{"av":"A657IconDisplayName","fld":"ICONDISPLAYNAME"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121Y2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_TRN_ICONID","""{"handler":"Valid_Trn_iconid","iparms":[]}""");
         setEventMetadata("VALID_TRN_ICONCATEGORY","""{"handler":"Valid_Trn_iconcategory","iparms":[]}""");
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
         wcpOAV7Trn_IconId = Guid.Empty;
         Z649Trn_IconId = Guid.Empty;
         Z657IconDisplayName = "";
         Z651IconEnglishName = "";
         Z652IconDutchName = "";
         Z654Trn_IconCategory = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A654Trn_IconCategory = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A649Trn_IconId = Guid.Empty;
         A651IconEnglishName = "";
         A652IconDutchName = "";
         A653Trn_IconSVG = "";
         A655IconEnglishTags = "";
         A656IconDutchTags = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A657IconDisplayName = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode109 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         Z653Trn_IconSVG = "";
         Z655IconEnglishTags = "";
         Z656IconDutchTags = "";
         T001Y4_A649Trn_IconId = new Guid[] {Guid.Empty} ;
         T001Y4_A657IconDisplayName = new string[] {""} ;
         T001Y4_A651IconEnglishName = new string[] {""} ;
         T001Y4_A652IconDutchName = new string[] {""} ;
         T001Y4_A653Trn_IconSVG = new string[] {""} ;
         T001Y4_A654Trn_IconCategory = new string[] {""} ;
         T001Y4_A655IconEnglishTags = new string[] {""} ;
         T001Y4_A656IconDutchTags = new string[] {""} ;
         T001Y5_A649Trn_IconId = new Guid[] {Guid.Empty} ;
         T001Y3_A649Trn_IconId = new Guid[] {Guid.Empty} ;
         T001Y3_A657IconDisplayName = new string[] {""} ;
         T001Y3_A651IconEnglishName = new string[] {""} ;
         T001Y3_A652IconDutchName = new string[] {""} ;
         T001Y3_A653Trn_IconSVG = new string[] {""} ;
         T001Y3_A654Trn_IconCategory = new string[] {""} ;
         T001Y3_A655IconEnglishTags = new string[] {""} ;
         T001Y3_A656IconDutchTags = new string[] {""} ;
         T001Y6_A649Trn_IconId = new Guid[] {Guid.Empty} ;
         T001Y7_A649Trn_IconId = new Guid[] {Guid.Empty} ;
         T001Y2_A649Trn_IconId = new Guid[] {Guid.Empty} ;
         T001Y2_A657IconDisplayName = new string[] {""} ;
         T001Y2_A651IconEnglishName = new string[] {""} ;
         T001Y2_A652IconDutchName = new string[] {""} ;
         T001Y2_A653Trn_IconSVG = new string[] {""} ;
         T001Y2_A654Trn_IconCategory = new string[] {""} ;
         T001Y2_A655IconEnglishTags = new string[] {""} ;
         T001Y2_A656IconDutchTags = new string[] {""} ;
         T001Y11_A649Trn_IconId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_icon__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_icon__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_icon__default(),
            new Object[][] {
                new Object[] {
               T001Y2_A649Trn_IconId, T001Y2_A657IconDisplayName, T001Y2_A651IconEnglishName, T001Y2_A652IconDutchName, T001Y2_A653Trn_IconSVG, T001Y2_A654Trn_IconCategory, T001Y2_A655IconEnglishTags, T001Y2_A656IconDutchTags
               }
               , new Object[] {
               T001Y3_A649Trn_IconId, T001Y3_A657IconDisplayName, T001Y3_A651IconEnglishName, T001Y3_A652IconDutchName, T001Y3_A653Trn_IconSVG, T001Y3_A654Trn_IconCategory, T001Y3_A655IconEnglishTags, T001Y3_A656IconDutchTags
               }
               , new Object[] {
               T001Y4_A649Trn_IconId, T001Y4_A657IconDisplayName, T001Y4_A651IconEnglishName, T001Y4_A652IconDutchName, T001Y4_A653Trn_IconSVG, T001Y4_A654Trn_IconCategory, T001Y4_A655IconEnglishTags, T001Y4_A656IconDutchTags
               }
               , new Object[] {
               T001Y5_A649Trn_IconId
               }
               , new Object[] {
               T001Y6_A649Trn_IconId
               }
               , new Object[] {
               T001Y7_A649Trn_IconId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001Y11_A649Trn_IconId
               }
            }
         );
         Z649Trn_IconId = Guid.NewGuid( );
         A649Trn_IconId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound109 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtTrn_IconId_Enabled ;
      private int edtIconEnglishName_Enabled ;
      private int edtIconDutchName_Enabled ;
      private int edtTrn_IconSVG_Enabled ;
      private int edtIconEnglishTags_Enabled ;
      private int edtIconDutchTags_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTrn_IconId_Internalname ;
      private string cmbTrn_IconCategory_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtTrn_IconId_Jsonclick ;
      private string edtIconEnglishName_Internalname ;
      private string edtIconEnglishName_Jsonclick ;
      private string edtIconDutchName_Internalname ;
      private string edtIconDutchName_Jsonclick ;
      private string edtTrn_IconSVG_Internalname ;
      private string cmbTrn_IconCategory_Jsonclick ;
      private string edtIconEnglishTags_Internalname ;
      private string edtIconDutchTags_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string hsh ;
      private string sMode109 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string A653Trn_IconSVG ;
      private string A655IconEnglishTags ;
      private string A656IconDutchTags ;
      private string Z653Trn_IconSVG ;
      private string Z655IconEnglishTags ;
      private string Z656IconDutchTags ;
      private string Z657IconDisplayName ;
      private string Z651IconEnglishName ;
      private string Z652IconDutchName ;
      private string Z654Trn_IconCategory ;
      private string A654Trn_IconCategory ;
      private string A651IconEnglishName ;
      private string A652IconDutchName ;
      private string A657IconDisplayName ;
      private Guid wcpOAV7Trn_IconId ;
      private Guid Z649Trn_IconId ;
      private Guid AV7Trn_IconId ;
      private Guid A649Trn_IconId ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTrn_IconCategory ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001Y4_A649Trn_IconId ;
      private string[] T001Y4_A657IconDisplayName ;
      private string[] T001Y4_A651IconEnglishName ;
      private string[] T001Y4_A652IconDutchName ;
      private string[] T001Y4_A653Trn_IconSVG ;
      private string[] T001Y4_A654Trn_IconCategory ;
      private string[] T001Y4_A655IconEnglishTags ;
      private string[] T001Y4_A656IconDutchTags ;
      private Guid[] T001Y5_A649Trn_IconId ;
      private Guid[] T001Y3_A649Trn_IconId ;
      private string[] T001Y3_A657IconDisplayName ;
      private string[] T001Y3_A651IconEnglishName ;
      private string[] T001Y3_A652IconDutchName ;
      private string[] T001Y3_A653Trn_IconSVG ;
      private string[] T001Y3_A654Trn_IconCategory ;
      private string[] T001Y3_A655IconEnglishTags ;
      private string[] T001Y3_A656IconDutchTags ;
      private Guid[] T001Y6_A649Trn_IconId ;
      private Guid[] T001Y7_A649Trn_IconId ;
      private Guid[] T001Y2_A649Trn_IconId ;
      private string[] T001Y2_A657IconDisplayName ;
      private string[] T001Y2_A651IconEnglishName ;
      private string[] T001Y2_A652IconDutchName ;
      private string[] T001Y2_A653Trn_IconSVG ;
      private string[] T001Y2_A654Trn_IconCategory ;
      private string[] T001Y2_A655IconEnglishTags ;
      private string[] T001Y2_A656IconDutchTags ;
      private Guid[] T001Y11_A649Trn_IconId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_icon__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_icon__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_icon__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT001Y2;
       prmT001Y2 = new Object[] {
       new ParDef("Trn_IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Y3;
       prmT001Y3 = new Object[] {
       new ParDef("Trn_IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Y4;
       prmT001Y4 = new Object[] {
       new ParDef("Trn_IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Y5;
       prmT001Y5 = new Object[] {
       new ParDef("Trn_IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Y6;
       prmT001Y6 = new Object[] {
       new ParDef("Trn_IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Y7;
       prmT001Y7 = new Object[] {
       new ParDef("Trn_IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Y8;
       prmT001Y8 = new Object[] {
       new ParDef("Trn_IconId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IconDisplayName",GXType.VarChar,100,0) ,
       new ParDef("IconEnglishName",GXType.VarChar,100,0) ,
       new ParDef("IconDutchName",GXType.VarChar,100,0) ,
       new ParDef("Trn_IconSVG",GXType.LongVarChar,2097152,0) ,
       new ParDef("Trn_IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconEnglishTags",GXType.LongVarChar,2097152,0) ,
       new ParDef("IconDutchTags",GXType.LongVarChar,2097152,0)
       };
       Object[] prmT001Y9;
       prmT001Y9 = new Object[] {
       new ParDef("IconDisplayName",GXType.VarChar,100,0) ,
       new ParDef("IconEnglishName",GXType.VarChar,100,0) ,
       new ParDef("IconDutchName",GXType.VarChar,100,0) ,
       new ParDef("Trn_IconSVG",GXType.LongVarChar,2097152,0) ,
       new ParDef("Trn_IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconEnglishTags",GXType.LongVarChar,2097152,0) ,
       new ParDef("IconDutchTags",GXType.LongVarChar,2097152,0) ,
       new ParDef("Trn_IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Y10;
       prmT001Y10 = new Object[] {
       new ParDef("Trn_IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001Y11;
       prmT001Y11 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T001Y2", "SELECT Trn_IconId, IconDisplayName, IconEnglishName, IconDutchName, Trn_IconSVG, Trn_IconCategory, IconEnglishTags, IconDutchTags FROM Trn_Icon WHERE Trn_IconId = :Trn_IconId  FOR UPDATE OF Trn_Icon NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Y3", "SELECT Trn_IconId, IconDisplayName, IconEnglishName, IconDutchName, Trn_IconSVG, Trn_IconCategory, IconEnglishTags, IconDutchTags FROM Trn_Icon WHERE Trn_IconId = :Trn_IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Y4", "SELECT TM1.Trn_IconId, TM1.IconDisplayName, TM1.IconEnglishName, TM1.IconDutchName, TM1.Trn_IconSVG, TM1.Trn_IconCategory, TM1.IconEnglishTags, TM1.IconDutchTags FROM Trn_Icon TM1 WHERE TM1.Trn_IconId = :Trn_IconId ORDER BY TM1.Trn_IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Y5", "SELECT Trn_IconId FROM Trn_Icon WHERE Trn_IconId = :Trn_IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001Y6", "SELECT Trn_IconId FROM Trn_Icon WHERE ( Trn_IconId > :Trn_IconId) ORDER BY Trn_IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001Y7", "SELECT Trn_IconId FROM Trn_Icon WHERE ( Trn_IconId < :Trn_IconId) ORDER BY Trn_IconId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001Y8", "SAVEPOINT gxupdate;INSERT INTO Trn_Icon(Trn_IconId, IconDisplayName, IconEnglishName, IconDutchName, Trn_IconSVG, Trn_IconCategory, IconEnglishTags, IconDutchTags) VALUES(:Trn_IconId, :IconDisplayName, :IconEnglishName, :IconDutchName, :Trn_IconSVG, :Trn_IconCategory, :IconEnglishTags, :IconDutchTags);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001Y8)
          ,new CursorDef("T001Y9", "SAVEPOINT gxupdate;UPDATE Trn_Icon SET IconDisplayName=:IconDisplayName, IconEnglishName=:IconEnglishName, IconDutchName=:IconDutchName, Trn_IconSVG=:Trn_IconSVG, Trn_IconCategory=:Trn_IconCategory, IconEnglishTags=:IconEnglishTags, IconDutchTags=:IconDutchTags  WHERE Trn_IconId = :Trn_IconId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Y9)
          ,new CursorDef("T001Y10", "SAVEPOINT gxupdate;DELETE FROM Trn_Icon  WHERE Trn_IconId = :Trn_IconId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Y10)
          ,new CursorDef("T001Y11", "SELECT Trn_IconId FROM Trn_Icon ORDER BY Trn_IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y11,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
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
