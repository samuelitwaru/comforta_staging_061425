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
   public class trn_theme : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_ctacolor") == 0 )
         {
            gxnrGridlevel_ctacolor_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_icon") == 0 )
         {
            gxnrGridlevel_icon_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_color") == 0 )
         {
            gxnrGridlevel_color_newrow_invoke( ) ;
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
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_theme.aspx")), "trn_theme.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_theme.aspx")))) ;
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
                  AV7Trn_ThemeId = StringUtil.StrToGuid( GetPar( "Trn_ThemeId"));
                  AssignAttri("", false, "AV7Trn_ThemeId", AV7Trn_ThemeId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRN_THEMEID", GetSecureSignedToken( "", AV7Trn_ThemeId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Theme", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_ctacolor_newrow_invoke( )
      {
         nRC_GXsfl_42 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_42"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_42_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_42_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_42_idx = GetPar( "sGXsfl_42_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_ctacolor_newrow( ) ;
         /* End function gxnrGridlevel_ctacolor_newrow_invoke */
      }

      protected void gxnrGridlevel_icon_newrow_invoke( )
      {
         nRC_GXsfl_51 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_51"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_51_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_51_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_51_idx = GetPar( "sGXsfl_51_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_icon_newrow( ) ;
         /* End function gxnrGridlevel_icon_newrow_invoke */
      }

      protected void gxnrGridlevel_color_newrow_invoke( )
      {
         nRC_GXsfl_64 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_color_newrow( ) ;
         /* End function gxnrGridlevel_color_newrow_invoke */
      }

      public trn_theme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_theme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_Trn_ThemeId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7Trn_ThemeId = aP1_Trn_ThemeId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbIconCategory = new GXCombobox();
         cmbColorName = new GXCombobox();
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
            return "trn_theme_Execute" ;
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Theme.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ThemeId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ThemeId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ThemeId_Internalname, A273Trn_ThemeId.ToString(), A273Trn_ThemeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ThemeId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ThemeId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ThemeName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ThemeName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ThemeName_Internalname, A274Trn_ThemeName, StringUtil.RTrim( context.localUtil.Format( A274Trn_ThemeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ThemeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ThemeName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ThemeFontFamily_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ThemeFontFamily_Internalname, context.GetMessage( "Font Family", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ThemeFontFamily_Internalname, A281Trn_ThemeFontFamily, StringUtil.RTrim( context.localUtil.Format( A281Trn_ThemeFontFamily, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ThemeFontFamily_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ThemeFontFamily_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ThemeFontSize_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ThemeFontSize_Internalname, context.GetMessage( "Font Size", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ThemeFontSize_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A405Trn_ThemeFontSize), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTrn_ThemeFontSize_Enabled!=0) ? context.localUtil.Format( (decimal)(A405Trn_ThemeFontSize), "ZZZ9") : context.localUtil.Format( (decimal)(A405Trn_ThemeFontSize), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ThemeFontSize_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ThemeFontSize_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Theme.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_ctacolor_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_ctacolor( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_icon_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_icon( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, context.GetMessage( "Colors", ""), "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_color_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_color( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Theme.htm");
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

      protected void gxdraw_Gridlevel_ctacolor( )
      {
         /*  Grid Control  */
         StartGridControl42( ) ;
         nGXsfl_42_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount97 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_97 = 1;
               ScanStart0Z97( ) ;
               while ( RcdFound97 != 0 )
               {
                  init_level_properties97( ) ;
                  getByPrimaryKey0Z97( ) ;
                  AddRow0Z97( ) ;
                  ScanNext0Z97( ) ;
               }
               ScanEnd0Z97( ) ;
               nBlankRcdCount97 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0Z97( ) ;
            standaloneModal0Z97( ) ;
            sMode97 = Gx_mode;
            while ( nGXsfl_42_idx < nRC_GXsfl_42 )
            {
               bGXsfl_42_Refreshing = true;
               ReadRow0Z97( ) ;
               edtCtaColorId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTACOLORID_"+sGXsfl_42_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCtaColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorId_Enabled), 5, 0), !bGXsfl_42_Refreshing);
               edtCtaColorName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTACOLORNAME_"+sGXsfl_42_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCtaColorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorName_Enabled), 5, 0), !bGXsfl_42_Refreshing);
               edtCtaColorCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTACOLORCODE_"+sGXsfl_42_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCtaColorCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorCode_Enabled), 5, 0), !bGXsfl_42_Refreshing);
               if ( ( nRcdExists_97 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0Z97( ) ;
               }
               SendRow0Z97( ) ;
               bGXsfl_42_Refreshing = false;
            }
            Gx_mode = sMode97;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount97 = 5;
            nRcdExists_97 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0Z97( ) ;
               while ( RcdFound97 != 0 )
               {
                  sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_4297( ) ;
                  init_level_properties97( ) ;
                  standaloneNotModal0Z97( ) ;
                  getByPrimaryKey0Z97( ) ;
                  standaloneModal0Z97( ) ;
                  AddRow0Z97( ) ;
                  ScanNext0Z97( ) ;
               }
               ScanEnd0Z97( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode97 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx+1), 4, 0), 4, "0");
            SubsflControlProps_4297( ) ;
            InitAll0Z97( ) ;
            init_level_properties97( ) ;
            nRcdExists_97 = 0;
            nIsMod_97 = 0;
            nRcdDeleted_97 = 0;
            nBlankRcdCount97 = (short)(nBlankRcdUsr97+nBlankRcdCount97);
            fRowAdded = 0;
            while ( nBlankRcdCount97 > 0 )
            {
               A538CtaColorId = Guid.Empty;
               standaloneNotModal0Z97( ) ;
               standaloneModal0Z97( ) ;
               AddRow0Z97( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCtaColorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount97 = (short)(nBlankRcdCount97-1);
            }
            Gx_mode = sMode97;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_ctacolorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_ctacolor", Gridlevel_ctacolorContainer, subGridlevel_ctacolor_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_ctacolorContainerData", Gridlevel_ctacolorContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_ctacolorContainerData"+"V", Gridlevel_ctacolorContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_ctacolorContainerData"+"V"+"\" value='"+Gridlevel_ctacolorContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridlevel_icon( )
      {
         /*  Grid Control  */
         StartGridControl51( ) ;
         nGXsfl_51_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount82 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_82 = 1;
               ScanStart0Z82( ) ;
               while ( RcdFound82 != 0 )
               {
                  init_level_properties82( ) ;
                  getByPrimaryKey0Z82( ) ;
                  AddRow0Z82( ) ;
                  ScanNext0Z82( ) ;
               }
               ScanEnd0Z82( ) ;
               nBlankRcdCount82 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0Z82( ) ;
            standaloneModal0Z82( ) ;
            sMode82 = Gx_mode;
            while ( nGXsfl_51_idx < nRC_GXsfl_51 )
            {
               bGXsfl_51_Refreshing = true;
               ReadRow0Z82( ) ;
               edtIconName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONNAME_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtIconName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconName_Enabled), 5, 0), !bGXsfl_51_Refreshing);
               cmbIconCategory.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONCATEGORY_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbIconCategory_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbIconCategory.Enabled), 5, 0), !bGXsfl_51_Refreshing);
               edtIconSVG_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONSVG_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtIconSVG_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconSVG_Enabled), 5, 0), !bGXsfl_51_Refreshing);
               edtIconTags_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONTAGS_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtIconTags_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconTags_Enabled), 5, 0), !bGXsfl_51_Refreshing);
               if ( ( nRcdExists_82 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0Z82( ) ;
               }
               SendRow0Z82( ) ;
               bGXsfl_51_Refreshing = false;
            }
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount82 = 5;
            nRcdExists_82 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0Z82( ) ;
               while ( RcdFound82 != 0 )
               {
                  sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5182( ) ;
                  init_level_properties82( ) ;
                  standaloneNotModal0Z82( ) ;
                  getByPrimaryKey0Z82( ) ;
                  standaloneModal0Z82( ) ;
                  AddRow0Z82( ) ;
                  ScanNext0Z82( ) ;
               }
               ScanEnd0Z82( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode82 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx+1), 4, 0), 4, "0");
            SubsflControlProps_5182( ) ;
            InitAll0Z82( ) ;
            init_level_properties82( ) ;
            nRcdExists_82 = 0;
            nIsMod_82 = 0;
            nRcdDeleted_82 = 0;
            nBlankRcdCount82 = (short)(nBlankRcdUsr82+nBlankRcdCount82);
            fRowAdded = 0;
            while ( nBlankRcdCount82 > 0 )
            {
               A282IconId = Guid.Empty;
               standaloneNotModal0Z82( ) ;
               standaloneModal0Z82( ) ;
               AddRow0Z82( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtIconName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount82 = (short)(nBlankRcdCount82-1);
            }
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_iconContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_icon", Gridlevel_iconContainer, subGridlevel_icon_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_iconContainerData", Gridlevel_iconContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_iconContainerData"+"V", Gridlevel_iconContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_iconContainerData"+"V"+"\" value='"+Gridlevel_iconContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridlevel_color( )
      {
         /*  Grid Control  */
         StartGridControl64( ) ;
         nGXsfl_64_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount53 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_53 = 1;
               ScanStart0Z53( ) ;
               while ( RcdFound53 != 0 )
               {
                  init_level_properties53( ) ;
                  getByPrimaryKey0Z53( ) ;
                  AddRow0Z53( ) ;
                  ScanNext0Z53( ) ;
               }
               ScanEnd0Z53( ) ;
               nBlankRcdCount53 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0Z53( ) ;
            standaloneModal0Z53( ) ;
            sMode53 = Gx_mode;
            while ( nGXsfl_64_idx < nRC_GXsfl_64 )
            {
               bGXsfl_64_Refreshing = true;
               ReadRow0Z53( ) ;
               edtColorId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORID_"+sGXsfl_64_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorId_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               cmbColorName.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORNAME_"+sGXsfl_64_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbColorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbColorName.Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtColorCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORCODE_"+sGXsfl_64_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtColorCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorCode_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               if ( ( nRcdExists_53 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0Z53( ) ;
               }
               SendRow0Z53( ) ;
               bGXsfl_64_Refreshing = false;
            }
            Gx_mode = sMode53;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount53 = 5;
            nRcdExists_53 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0Z53( ) ;
               while ( RcdFound53 != 0 )
               {
                  sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_6453( ) ;
                  init_level_properties53( ) ;
                  standaloneNotModal0Z53( ) ;
                  getByPrimaryKey0Z53( ) ;
                  standaloneModal0Z53( ) ;
                  AddRow0Z53( ) ;
                  ScanNext0Z53( ) ;
               }
               ScanEnd0Z53( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode53 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx+1), 4, 0), 4, "0");
            SubsflControlProps_6453( ) ;
            InitAll0Z53( ) ;
            init_level_properties53( ) ;
            nRcdExists_53 = 0;
            nIsMod_53 = 0;
            nRcdDeleted_53 = 0;
            nBlankRcdCount53 = (short)(nBlankRcdUsr53+nBlankRcdCount53);
            fRowAdded = 0;
            while ( nBlankRcdCount53 > 0 )
            {
               A275ColorId = Guid.Empty;
               standaloneNotModal0Z53( ) ;
               standaloneModal0Z53( ) ;
               AddRow0Z53( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = cmbColorName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount53 = (short)(nBlankRcdCount53-1);
            }
            Gx_mode = sMode53;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_colorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_color", Gridlevel_colorContainer, subGridlevel_color_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_colorContainerData", Gridlevel_colorContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_colorContainerData"+"V", Gridlevel_colorContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_colorContainerData"+"V"+"\" value='"+Gridlevel_colorContainer.GridValuesHidden()+"'/>") ;
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
         E110Z2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z273Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "Z273Trn_ThemeId"));
               Z274Trn_ThemeName = cgiGet( "Z274Trn_ThemeName");
               Z281Trn_ThemeFontFamily = cgiGet( "Z281Trn_ThemeFontFamily");
               Z405Trn_ThemeFontSize = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z405Trn_ThemeFontSize"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z576ThemeIsPredefined = StringUtil.StrToBool( cgiGet( "Z576ThemeIsPredefined"));
               A576ThemeIsPredefined = StringUtil.StrToBool( cgiGet( "Z576ThemeIsPredefined"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_42 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_42"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_51 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_51"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "vTRN_THEMEID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A576ThemeIsPredefined = StringUtil.StrToBool( cgiGet( "THEMEISPREDEFINED"));
               A282IconId = StringUtil.StrToGuid( cgiGet( "ICONID"));
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtTrn_ThemeId_Internalname), "") == 0 )
               {
                  A273Trn_ThemeId = Guid.Empty;
                  n273Trn_ThemeId = false;
                  AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
               }
               else
               {
                  try
                  {
                     A273Trn_ThemeId = StringUtil.StrToGuid( cgiGet( edtTrn_ThemeId_Internalname));
                     n273Trn_ThemeId = false;
                     AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRN_THEMEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_ThemeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A274Trn_ThemeName = cgiGet( edtTrn_ThemeName_Internalname);
               AssignAttri("", false, "A274Trn_ThemeName", A274Trn_ThemeName);
               A281Trn_ThemeFontFamily = cgiGet( edtTrn_ThemeFontFamily_Internalname);
               AssignAttri("", false, "A281Trn_ThemeFontFamily", A281Trn_ThemeFontFamily);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTrn_ThemeFontSize_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrn_ThemeFontSize_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRN_THEMEFONTSIZE");
                  AnyError = 1;
                  GX_FocusControl = edtTrn_ThemeFontSize_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A405Trn_ThemeFontSize = 0;
                  AssignAttri("", false, "A405Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A405Trn_ThemeFontSize), 4, 0));
               }
               else
               {
                  A405Trn_ThemeFontSize = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTrn_ThemeFontSize_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A405Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A405Trn_ThemeFontSize), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Theme");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ThemeIsPredefined", StringUtil.BoolToStr( A576ThemeIsPredefined));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A273Trn_ThemeId != Z273Trn_ThemeId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_theme:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               /* Check if conditions changed and reset current page numbers */
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
                  A273Trn_ThemeId = StringUtil.StrToGuid( GetPar( "Trn_ThemeId"));
                  n273Trn_ThemeId = false;
                  AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7Trn_ThemeId) )
                  {
                     A273Trn_ThemeId = AV7Trn_ThemeId;
                     n273Trn_ThemeId = false;
                     AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A273Trn_ThemeId) && ( Gx_BScreen == 0 ) )
                     {
                        A273Trn_ThemeId = Guid.NewGuid( );
                        n273Trn_ThemeId = false;
                        AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
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
                     sMode51 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7Trn_ThemeId) )
                     {
                        A273Trn_ThemeId = AV7Trn_ThemeId;
                        n273Trn_ThemeId = false;
                        AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A273Trn_ThemeId) && ( Gx_BScreen == 0 ) )
                        {
                           A273Trn_ThemeId = Guid.NewGuid( );
                           n273Trn_ThemeId = false;
                           AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
                        }
                     }
                     Gx_mode = sMode51;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound51 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0Z0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TRN_THEMEID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_ThemeId_Internalname;
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
                           E110Z2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120Z2 ();
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
            E120Z2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0Z51( ) ;
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
            DisableAttributes0Z51( ) ;
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

      protected void CONFIRM_0Z0( )
      {
         BeforeValidate0Z51( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Z51( ) ;
            }
            else
            {
               CheckExtendedTable0Z51( ) ;
               CloseExtendedTableCursors0Z51( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode51 = Gx_mode;
            CONFIRM_0Z97( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0Z82( ) ;
               if ( AnyError == 0 )
               {
                  CONFIRM_0Z53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Restore parent mode. */
                     Gx_mode = sMode51;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     IsConfirmed = 1;
                     AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                  }
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode51;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0Z53( )
      {
         nGXsfl_64_idx = 0;
         while ( nGXsfl_64_idx < nRC_GXsfl_64 )
         {
            ReadRow0Z53( ) ;
            if ( ( nRcdExists_53 != 0 ) || ( nIsMod_53 != 0 ) )
            {
               GetKey0Z53( ) ;
               if ( ( nRcdExists_53 == 0 ) && ( nRcdDeleted_53 == 0 ) )
               {
                  if ( RcdFound53 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0Z53( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Z53( ) ;
                        CloseExtendedTableCursors0Z53( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TRN_THEMEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_ThemeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound53 != 0 )
                  {
                     if ( nRcdDeleted_53 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0Z53( ) ;
                        Load0Z53( ) ;
                        BeforeValidate0Z53( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Z53( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_53 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0Z53( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Z53( ) ;
                              CloseExtendedTableCursors0Z53( ) ;
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
                     if ( nRcdDeleted_53 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_THEMEID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_ThemeId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtColorId_Internalname, A275ColorId.ToString()) ;
            ChangePostValue( cmbColorName_Internalname, A276ColorName) ;
            ChangePostValue( edtColorCode_Internalname, A277ColorCode) ;
            ChangePostValue( "ZT_"+"Z275ColorId_"+sGXsfl_64_idx, Z275ColorId.ToString()) ;
            ChangePostValue( "ZT_"+"Z276ColorName_"+sGXsfl_64_idx, Z276ColorName) ;
            ChangePostValue( "ZT_"+"Z277ColorCode_"+sGXsfl_64_idx, Z277ColorCode) ;
            ChangePostValue( "nRcdDeleted_53_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_53), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_53_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_53), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_53_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_53), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_53 != 0 )
            {
               ChangePostValue( "COLORID_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COLORNAME_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbColorName.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COLORCODE_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorCode_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0Z82( )
      {
         nGXsfl_51_idx = 0;
         while ( nGXsfl_51_idx < nRC_GXsfl_51 )
         {
            ReadRow0Z82( ) ;
            if ( ( nRcdExists_82 != 0 ) || ( nIsMod_82 != 0 ) )
            {
               GetKey0Z82( ) ;
               if ( ( nRcdExists_82 == 0 ) && ( nRcdDeleted_82 == 0 ) )
               {
                  if ( RcdFound82 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0Z82( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Z82( ) ;
                        CloseExtendedTableCursors0Z82( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TRN_THEMEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_ThemeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound82 != 0 )
                  {
                     if ( nRcdDeleted_82 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0Z82( ) ;
                        Load0Z82( ) ;
                        BeforeValidate0Z82( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Z82( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_82 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0Z82( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Z82( ) ;
                              CloseExtendedTableCursors0Z82( ) ;
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
                     if ( nRcdDeleted_82 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_THEMEID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_ThemeId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtIconName_Internalname, A283IconName) ;
            ChangePostValue( cmbIconCategory_Internalname, A443IconCategory) ;
            ChangePostValue( edtIconSVG_Internalname, A284IconSVG) ;
            ChangePostValue( edtIconTags_Internalname, A643IconTags) ;
            ChangePostValue( "ZT_"+"Z282IconId_"+sGXsfl_51_idx, Z282IconId.ToString()) ;
            ChangePostValue( "ZT_"+"Z443IconCategory_"+sGXsfl_51_idx, Z443IconCategory) ;
            ChangePostValue( "ZT_"+"Z283IconName_"+sGXsfl_51_idx, Z283IconName) ;
            ChangePostValue( "nRcdDeleted_82_"+sGXsfl_51_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_82), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_82_"+sGXsfl_51_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_82), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_82_"+sGXsfl_51_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_82), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_82 != 0 )
            {
               ChangePostValue( "ICONNAME_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ICONCATEGORY_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbIconCategory.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ICONSVG_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconSVG_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ICONTAGS_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconTags_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0Z97( )
      {
         nGXsfl_42_idx = 0;
         while ( nGXsfl_42_idx < nRC_GXsfl_42 )
         {
            ReadRow0Z97( ) ;
            if ( ( nRcdExists_97 != 0 ) || ( nIsMod_97 != 0 ) )
            {
               GetKey0Z97( ) ;
               if ( ( nRcdExists_97 == 0 ) && ( nRcdDeleted_97 == 0 ) )
               {
                  if ( RcdFound97 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0Z97( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Z97( ) ;
                        CloseExtendedTableCursors0Z97( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CTACOLORID_" + sGXsfl_42_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCtaColorId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound97 != 0 )
                  {
                     if ( nRcdDeleted_97 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0Z97( ) ;
                        Load0Z97( ) ;
                        BeforeValidate0Z97( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Z97( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_97 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0Z97( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Z97( ) ;
                              CloseExtendedTableCursors0Z97( ) ;
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
                     if ( nRcdDeleted_97 == 0 )
                     {
                        GXCCtl = "CTACOLORID_" + sGXsfl_42_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCtaColorId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCtaColorId_Internalname, A538CtaColorId.ToString()) ;
            ChangePostValue( edtCtaColorName_Internalname, A539CtaColorName) ;
            ChangePostValue( edtCtaColorCode_Internalname, A540CtaColorCode) ;
            ChangePostValue( "ZT_"+"Z538CtaColorId_"+sGXsfl_42_idx, Z538CtaColorId.ToString()) ;
            ChangePostValue( "ZT_"+"Z539CtaColorName_"+sGXsfl_42_idx, Z539CtaColorName) ;
            ChangePostValue( "ZT_"+"Z540CtaColorCode_"+sGXsfl_42_idx, Z540CtaColorCode) ;
            ChangePostValue( "nRcdDeleted_97_"+sGXsfl_42_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_97), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_97_"+sGXsfl_42_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_97), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_97_"+sGXsfl_42_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_97), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_97 != 0 )
            {
               ChangePostValue( "CTACOLORID_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTACOLORNAME_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTACOLORCODE_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorCode_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0Z0( )
      {
      }

      protected void E110Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120Z2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_themeww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0Z51( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z274Trn_ThemeName = T000Z9_A274Trn_ThemeName[0];
               Z281Trn_ThemeFontFamily = T000Z9_A281Trn_ThemeFontFamily[0];
               Z405Trn_ThemeFontSize = T000Z9_A405Trn_ThemeFontSize[0];
               Z576ThemeIsPredefined = T000Z9_A576ThemeIsPredefined[0];
            }
            else
            {
               Z274Trn_ThemeName = A274Trn_ThemeName;
               Z281Trn_ThemeFontFamily = A281Trn_ThemeFontFamily;
               Z405Trn_ThemeFontSize = A405Trn_ThemeFontSize;
               Z576ThemeIsPredefined = A576ThemeIsPredefined;
            }
         }
         if ( GX_JID == -13 )
         {
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z274Trn_ThemeName = A274Trn_ThemeName;
            Z281Trn_ThemeFontFamily = A281Trn_ThemeFontFamily;
            Z405Trn_ThemeFontSize = A405Trn_ThemeFontSize;
            Z576ThemeIsPredefined = A576ThemeIsPredefined;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7Trn_ThemeId) )
         {
            edtTrn_ThemeId_Enabled = 0;
            AssignProp("", false, edtTrn_ThemeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeId_Enabled), 5, 0), true);
         }
         else
         {
            edtTrn_ThemeId_Enabled = 1;
            AssignProp("", false, edtTrn_ThemeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7Trn_ThemeId) )
         {
            edtTrn_ThemeId_Enabled = 0;
            AssignProp("", false, edtTrn_ThemeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeId_Enabled), 5, 0), true);
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
         if ( ! (Guid.Empty==AV7Trn_ThemeId) )
         {
            A273Trn_ThemeId = AV7Trn_ThemeId;
            n273Trn_ThemeId = false;
            AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A273Trn_ThemeId) && ( Gx_BScreen == 0 ) )
            {
               A273Trn_ThemeId = Guid.NewGuid( );
               n273Trn_ThemeId = false;
               AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
            }
         }
         if ( IsIns( )  && (false==A576ThemeIsPredefined) && ( Gx_BScreen == 0 ) )
         {
            A576ThemeIsPredefined = false;
            AssignAttri("", false, "A576ThemeIsPredefined", A576ThemeIsPredefined);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Z51( )
      {
         /* Using cursor T000Z10 */
         pr_default.execute(8, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound51 = 1;
            A274Trn_ThemeName = T000Z10_A274Trn_ThemeName[0];
            AssignAttri("", false, "A274Trn_ThemeName", A274Trn_ThemeName);
            A281Trn_ThemeFontFamily = T000Z10_A281Trn_ThemeFontFamily[0];
            AssignAttri("", false, "A281Trn_ThemeFontFamily", A281Trn_ThemeFontFamily);
            A405Trn_ThemeFontSize = T000Z10_A405Trn_ThemeFontSize[0];
            AssignAttri("", false, "A405Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A405Trn_ThemeFontSize), 4, 0));
            A576ThemeIsPredefined = T000Z10_A576ThemeIsPredefined[0];
            ZM0Z51( -13) ;
         }
         pr_default.close(8);
         OnLoadActions0Z51( ) ;
      }

      protected void OnLoadActions0Z51( )
      {
      }

      protected void CheckExtendedTable0Z51( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0Z51( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Z51( )
      {
         /* Using cursor T000Z11 */
         pr_default.execute(9, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound51 = 1;
         }
         else
         {
            RcdFound51 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Z9 */
         pr_default.execute(7, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM0Z51( 13) ;
            RcdFound51 = 1;
            A273Trn_ThemeId = T000Z9_A273Trn_ThemeId[0];
            n273Trn_ThemeId = T000Z9_n273Trn_ThemeId[0];
            AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
            A274Trn_ThemeName = T000Z9_A274Trn_ThemeName[0];
            AssignAttri("", false, "A274Trn_ThemeName", A274Trn_ThemeName);
            A281Trn_ThemeFontFamily = T000Z9_A281Trn_ThemeFontFamily[0];
            AssignAttri("", false, "A281Trn_ThemeFontFamily", A281Trn_ThemeFontFamily);
            A405Trn_ThemeFontSize = T000Z9_A405Trn_ThemeFontSize[0];
            AssignAttri("", false, "A405Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A405Trn_ThemeFontSize), 4, 0));
            A576ThemeIsPredefined = T000Z9_A576ThemeIsPredefined[0];
            Z273Trn_ThemeId = A273Trn_ThemeId;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Z51( ) ;
            if ( AnyError == 1 )
            {
               RcdFound51 = 0;
               InitializeNonKey0Z51( ) ;
            }
            Gx_mode = sMode51;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound51 = 0;
            InitializeNonKey0Z51( ) ;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode51;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(7);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Z51( ) ;
         if ( RcdFound51 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound51 = 0;
         /* Using cursor T000Z12 */
         pr_default.execute(10, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000Z12_A273Trn_ThemeId[0], A273Trn_ThemeId, 0) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000Z12_A273Trn_ThemeId[0], A273Trn_ThemeId, 0) > 0 ) ) )
            {
               A273Trn_ThemeId = T000Z12_A273Trn_ThemeId[0];
               n273Trn_ThemeId = T000Z12_n273Trn_ThemeId[0];
               AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
               RcdFound51 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound51 = 0;
         /* Using cursor T000Z13 */
         pr_default.execute(11, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000Z13_A273Trn_ThemeId[0], A273Trn_ThemeId, 0) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000Z13_A273Trn_ThemeId[0], A273Trn_ThemeId, 0) < 0 ) ) )
            {
               A273Trn_ThemeId = T000Z13_A273Trn_ThemeId[0];
               n273Trn_ThemeId = T000Z13_n273Trn_ThemeId[0];
               AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
               RcdFound51 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Z51( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Z51( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound51 == 1 )
            {
               if ( A273Trn_ThemeId != Z273Trn_ThemeId )
               {
                  A273Trn_ThemeId = Z273Trn_ThemeId;
                  n273Trn_ThemeId = false;
                  AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRN_THEMEID");
                  AnyError = 1;
                  GX_FocusControl = edtTrn_ThemeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrn_ThemeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0Z51( ) ;
                  GX_FocusControl = edtTrn_ThemeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A273Trn_ThemeId != Z273Trn_ThemeId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTrn_ThemeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Z51( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_THEMEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_ThemeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTrn_ThemeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Z51( ) ;
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
         if ( A273Trn_ThemeId != Z273Trn_ThemeId )
         {
            A273Trn_ThemeId = Z273Trn_ThemeId;
            n273Trn_ThemeId = false;
            AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0Z51( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Z8 */
            pr_default.execute(6, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Theme"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(6) == 101) || ( StringUtil.StrCmp(Z274Trn_ThemeName, T000Z8_A274Trn_ThemeName[0]) != 0 ) || ( StringUtil.StrCmp(Z281Trn_ThemeFontFamily, T000Z8_A281Trn_ThemeFontFamily[0]) != 0 ) || ( Z405Trn_ThemeFontSize != T000Z8_A405Trn_ThemeFontSize[0] ) || ( Z576ThemeIsPredefined != T000Z8_A576ThemeIsPredefined[0] ) )
            {
               if ( StringUtil.StrCmp(Z274Trn_ThemeName, T000Z8_A274Trn_ThemeName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"Trn_ThemeName");
                  GXUtil.WriteLogRaw("Old: ",Z274Trn_ThemeName);
                  GXUtil.WriteLogRaw("Current: ",T000Z8_A274Trn_ThemeName[0]);
               }
               if ( StringUtil.StrCmp(Z281Trn_ThemeFontFamily, T000Z8_A281Trn_ThemeFontFamily[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"Trn_ThemeFontFamily");
                  GXUtil.WriteLogRaw("Old: ",Z281Trn_ThemeFontFamily);
                  GXUtil.WriteLogRaw("Current: ",T000Z8_A281Trn_ThemeFontFamily[0]);
               }
               if ( Z405Trn_ThemeFontSize != T000Z8_A405Trn_ThemeFontSize[0] )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"Trn_ThemeFontSize");
                  GXUtil.WriteLogRaw("Old: ",Z405Trn_ThemeFontSize);
                  GXUtil.WriteLogRaw("Current: ",T000Z8_A405Trn_ThemeFontSize[0]);
               }
               if ( Z576ThemeIsPredefined != T000Z8_A576ThemeIsPredefined[0] )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"ThemeIsPredefined");
                  GXUtil.WriteLogRaw("Old: ",Z576ThemeIsPredefined);
                  GXUtil.WriteLogRaw("Current: ",T000Z8_A576ThemeIsPredefined[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Theme"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z51( )
      {
         if ( ! IsAuthorized("trn_theme_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z51( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z51( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z51( 0) ;
            CheckOptimisticConcurrency0Z51( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z51( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z51( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z14 */
                     pr_default.execute(12, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A274Trn_ThemeName, A281Trn_ThemeFontFamily, A405Trn_ThemeFontSize, A576ThemeIsPredefined});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ProcessLevel0Z51( ) ;
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
               Load0Z51( ) ;
            }
            EndLevel0Z51( ) ;
         }
         CloseExtendedTableCursors0Z51( ) ;
      }

      protected void Update0Z51( )
      {
         if ( ! IsAuthorized("trn_theme_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z51( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z51( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z51( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z51( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z51( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z15 */
                     pr_default.execute(13, new Object[] {A274Trn_ThemeName, A281Trn_ThemeFontFamily, A405Trn_ThemeFontSize, A576ThemeIsPredefined, n273Trn_ThemeId, A273Trn_ThemeId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Theme"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z51( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0Z51( ) ;
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
            }
            EndLevel0Z51( ) ;
         }
         CloseExtendedTableCursors0Z51( ) ;
      }

      protected void DeferredUpdate0Z51( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_theme_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z51( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z51( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z51( ) ;
            AfterConfirm0Z51( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z51( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0Z97( ) ;
                  while ( RcdFound97 != 0 )
                  {
                     getByPrimaryKey0Z97( ) ;
                     Delete0Z97( ) ;
                     ScanNext0Z97( ) ;
                  }
                  ScanEnd0Z97( ) ;
                  ScanStart0Z82( ) ;
                  while ( RcdFound82 != 0 )
                  {
                     getByPrimaryKey0Z82( ) ;
                     Delete0Z82( ) ;
                     ScanNext0Z82( ) ;
                  }
                  ScanEnd0Z82( ) ;
                  ScanStart0Z53( ) ;
                  while ( RcdFound53 != 0 )
                  {
                     getByPrimaryKey0Z53( ) ;
                     Delete0Z53( ) ;
                     ScanNext0Z53( ) ;
                  }
                  ScanEnd0Z53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z16 */
                     pr_default.execute(14, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
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
         }
         sMode51 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Z51( ) ;
         Gx_mode = sMode51;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Z51( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000Z17 */
            pr_default.execute(15, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Locations", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000Z18 */
            pr_default.execute(16, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000Z19 */
            pr_default.execute(17, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_OrganisationSetting", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel0Z97( )
      {
         nGXsfl_42_idx = 0;
         while ( nGXsfl_42_idx < nRC_GXsfl_42 )
         {
            ReadRow0Z97( ) ;
            if ( ( nRcdExists_97 != 0 ) || ( nIsMod_97 != 0 ) )
            {
               standaloneNotModal0Z97( ) ;
               GetKey0Z97( ) ;
               if ( ( nRcdExists_97 == 0 ) && ( nRcdDeleted_97 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0Z97( ) ;
               }
               else
               {
                  if ( RcdFound97 != 0 )
                  {
                     if ( ( nRcdDeleted_97 != 0 ) && ( nRcdExists_97 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0Z97( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_97 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0Z97( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_97 == 0 )
                     {
                        GXCCtl = "CTACOLORID_" + sGXsfl_42_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCtaColorId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCtaColorId_Internalname, A538CtaColorId.ToString()) ;
            ChangePostValue( edtCtaColorName_Internalname, A539CtaColorName) ;
            ChangePostValue( edtCtaColorCode_Internalname, A540CtaColorCode) ;
            ChangePostValue( "ZT_"+"Z538CtaColorId_"+sGXsfl_42_idx, Z538CtaColorId.ToString()) ;
            ChangePostValue( "ZT_"+"Z539CtaColorName_"+sGXsfl_42_idx, Z539CtaColorName) ;
            ChangePostValue( "ZT_"+"Z540CtaColorCode_"+sGXsfl_42_idx, Z540CtaColorCode) ;
            ChangePostValue( "nRcdDeleted_97_"+sGXsfl_42_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_97), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_97_"+sGXsfl_42_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_97), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_97_"+sGXsfl_42_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_97), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_97 != 0 )
            {
               ChangePostValue( "CTACOLORID_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTACOLORNAME_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CTACOLORCODE_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorCode_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Z97( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_97 = 0;
         nIsMod_97 = 0;
         nRcdDeleted_97 = 0;
      }

      protected void ProcessNestedLevel0Z82( )
      {
         nGXsfl_51_idx = 0;
         while ( nGXsfl_51_idx < nRC_GXsfl_51 )
         {
            ReadRow0Z82( ) ;
            if ( ( nRcdExists_82 != 0 ) || ( nIsMod_82 != 0 ) )
            {
               standaloneNotModal0Z82( ) ;
               GetKey0Z82( ) ;
               if ( ( nRcdExists_82 == 0 ) && ( nRcdDeleted_82 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0Z82( ) ;
               }
               else
               {
                  if ( RcdFound82 != 0 )
                  {
                     if ( ( nRcdDeleted_82 != 0 ) && ( nRcdExists_82 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0Z82( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_82 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0Z82( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_82 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_THEMEID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_ThemeId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtIconName_Internalname, A283IconName) ;
            ChangePostValue( cmbIconCategory_Internalname, A443IconCategory) ;
            ChangePostValue( edtIconSVG_Internalname, A284IconSVG) ;
            ChangePostValue( edtIconTags_Internalname, A643IconTags) ;
            ChangePostValue( "ZT_"+"Z282IconId_"+sGXsfl_51_idx, Z282IconId.ToString()) ;
            ChangePostValue( "ZT_"+"Z443IconCategory_"+sGXsfl_51_idx, Z443IconCategory) ;
            ChangePostValue( "ZT_"+"Z283IconName_"+sGXsfl_51_idx, Z283IconName) ;
            ChangePostValue( "nRcdDeleted_82_"+sGXsfl_51_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_82), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_82_"+sGXsfl_51_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_82), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_82_"+sGXsfl_51_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_82), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_82 != 0 )
            {
               ChangePostValue( "ICONNAME_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ICONCATEGORY_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbIconCategory.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ICONSVG_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconSVG_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ICONTAGS_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconTags_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Z82( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_82 = 0;
         nIsMod_82 = 0;
         nRcdDeleted_82 = 0;
      }

      protected void ProcessNestedLevel0Z53( )
      {
         nGXsfl_64_idx = 0;
         while ( nGXsfl_64_idx < nRC_GXsfl_64 )
         {
            ReadRow0Z53( ) ;
            if ( ( nRcdExists_53 != 0 ) || ( nIsMod_53 != 0 ) )
            {
               standaloneNotModal0Z53( ) ;
               GetKey0Z53( ) ;
               if ( ( nRcdExists_53 == 0 ) && ( nRcdDeleted_53 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0Z53( ) ;
               }
               else
               {
                  if ( RcdFound53 != 0 )
                  {
                     if ( ( nRcdDeleted_53 != 0 ) && ( nRcdExists_53 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0Z53( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_53 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0Z53( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_53 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_THEMEID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_ThemeId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtColorId_Internalname, A275ColorId.ToString()) ;
            ChangePostValue( cmbColorName_Internalname, A276ColorName) ;
            ChangePostValue( edtColorCode_Internalname, A277ColorCode) ;
            ChangePostValue( "ZT_"+"Z275ColorId_"+sGXsfl_64_idx, Z275ColorId.ToString()) ;
            ChangePostValue( "ZT_"+"Z276ColorName_"+sGXsfl_64_idx, Z276ColorName) ;
            ChangePostValue( "ZT_"+"Z277ColorCode_"+sGXsfl_64_idx, Z277ColorCode) ;
            ChangePostValue( "nRcdDeleted_53_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_53), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_53_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_53), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_53_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_53), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_53 != 0 )
            {
               ChangePostValue( "COLORID_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COLORNAME_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbColorName.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COLORCODE_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorCode_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Z53( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_53 = 0;
         nIsMod_53 = 0;
         nRcdDeleted_53 = 0;
      }

      protected void ProcessLevel0Z51( )
      {
         /* Save parent mode. */
         sMode51 = Gx_mode;
         ProcessNestedLevel0Z97( ) ;
         ProcessNestedLevel0Z82( ) ;
         ProcessNestedLevel0Z53( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode51;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0Z51( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(6);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Z51( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_theme",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Z0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_theme",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Z51( )
      {
         /* Scan By routine */
         /* Using cursor T000Z20 */
         pr_default.execute(18);
         RcdFound51 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound51 = 1;
            A273Trn_ThemeId = T000Z20_A273Trn_ThemeId[0];
            n273Trn_ThemeId = T000Z20_n273Trn_ThemeId[0];
            AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z51( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound51 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound51 = 1;
            A273Trn_ThemeId = T000Z20_A273Trn_ThemeId[0];
            n273Trn_ThemeId = T000Z20_n273Trn_ThemeId[0];
            AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
         }
      }

      protected void ScanEnd0Z51( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0Z51( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z51( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z51( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z51( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z51( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z51( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z51( )
      {
         edtTrn_ThemeId_Enabled = 0;
         AssignProp("", false, edtTrn_ThemeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeId_Enabled), 5, 0), true);
         edtTrn_ThemeName_Enabled = 0;
         AssignProp("", false, edtTrn_ThemeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeName_Enabled), 5, 0), true);
         edtTrn_ThemeFontFamily_Enabled = 0;
         AssignProp("", false, edtTrn_ThemeFontFamily_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeFontFamily_Enabled), 5, 0), true);
         edtTrn_ThemeFontSize_Enabled = 0;
         AssignProp("", false, edtTrn_ThemeFontSize_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeFontSize_Enabled), 5, 0), true);
      }

      protected void ZM0Z97( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z539CtaColorName = T000Z7_A539CtaColorName[0];
               Z540CtaColorCode = T000Z7_A540CtaColorCode[0];
            }
            else
            {
               Z539CtaColorName = A539CtaColorName;
               Z540CtaColorCode = A540CtaColorCode;
            }
         }
         if ( GX_JID == -14 )
         {
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z538CtaColorId = A538CtaColorId;
            Z539CtaColorName = A539CtaColorName;
            Z540CtaColorCode = A540CtaColorCode;
         }
      }

      protected void standaloneNotModal0Z97( )
      {
      }

      protected void standaloneModal0Z97( )
      {
         if ( IsIns( )  && (Guid.Empty==A538CtaColorId) && ( Gx_BScreen == 0 ) )
         {
            A538CtaColorId = Guid.NewGuid( );
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCtaColorId_Enabled = 0;
            AssignProp("", false, edtCtaColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorId_Enabled), 5, 0), !bGXsfl_42_Refreshing);
         }
         else
         {
            edtCtaColorId_Enabled = 1;
            AssignProp("", false, edtCtaColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorId_Enabled), 5, 0), !bGXsfl_42_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Z97( )
      {
         /* Using cursor T000Z21 */
         pr_default.execute(19, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound97 = 1;
            A539CtaColorName = T000Z21_A539CtaColorName[0];
            A540CtaColorCode = T000Z21_A540CtaColorCode[0];
            ZM0Z97( -14) ;
         }
         pr_default.close(19);
         OnLoadActions0Z97( ) ;
      }

      protected void OnLoadActions0Z97( )
      {
      }

      protected void CheckExtendedTable0Z97( )
      {
         nIsDirty_97 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0Z97( ) ;
         /* Using cursor T000Z22 */
         pr_default.execute(20, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A539CtaColorName, A538CtaColorId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Cta Color Name", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(20);
      }

      protected void CloseExtendedTableCursors0Z97( )
      {
      }

      protected void enableDisable0Z97( )
      {
      }

      protected void GetKey0Z97( )
      {
         /* Using cursor T000Z23 */
         pr_default.execute(21, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound97 = 1;
         }
         else
         {
            RcdFound97 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey0Z97( )
      {
         /* Using cursor T000Z7 */
         pr_default.execute(5, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0Z97( 14) ;
            RcdFound97 = 1;
            InitializeNonKey0Z97( ) ;
            A538CtaColorId = T000Z7_A538CtaColorId[0];
            A539CtaColorName = T000Z7_A539CtaColorName[0];
            A540CtaColorCode = T000Z7_A540CtaColorCode[0];
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z538CtaColorId = A538CtaColorId;
            sMode97 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Z97( ) ;
            Gx_mode = sMode97;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound97 = 0;
            InitializeNonKey0Z97( ) ;
            sMode97 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0Z97( ) ;
            Gx_mode = sMode97;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Z97( ) ;
         }
         pr_default.close(5);
      }

      protected void CheckOptimisticConcurrency0Z97( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Z6 */
            pr_default.execute(4, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeCtaColor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z539CtaColorName, T000Z6_A539CtaColorName[0]) != 0 ) || ( StringUtil.StrCmp(Z540CtaColorCode, T000Z6_A540CtaColorCode[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z539CtaColorName, T000Z6_A539CtaColorName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"CtaColorName");
                  GXUtil.WriteLogRaw("Old: ",Z539CtaColorName);
                  GXUtil.WriteLogRaw("Current: ",T000Z6_A539CtaColorName[0]);
               }
               if ( StringUtil.StrCmp(Z540CtaColorCode, T000Z6_A540CtaColorCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"CtaColorCode");
                  GXUtil.WriteLogRaw("Old: ",Z540CtaColorCode);
                  GXUtil.WriteLogRaw("Current: ",T000Z6_A540CtaColorCode[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeCtaColor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z97( )
      {
         if ( ! IsAuthorized("trn_theme_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z97( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z97( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z97( 0) ;
            CheckOptimisticConcurrency0Z97( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z97( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z97( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z24 */
                     pr_default.execute(22, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId, A539CtaColorName, A540CtaColorCode});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                     if ( (pr_default.getStatus(22) == 1) )
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
               Load0Z97( ) ;
            }
            EndLevel0Z97( ) ;
         }
         CloseExtendedTableCursors0Z97( ) ;
      }

      protected void Update0Z97( )
      {
         if ( ! IsAuthorized("trn_theme_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z97( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z97( ) ;
         }
         if ( ( nIsMod_97 != 0 ) || ( nIsDirty_97 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0Z97( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0Z97( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0Z97( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000Z25 */
                        pr_default.execute(23, new Object[] {A539CtaColorName, A540CtaColorCode, n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId});
                        pr_default.close(23);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                        if ( (pr_default.getStatus(23) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeCtaColor"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0Z97( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0Z97( ) ;
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
               EndLevel0Z97( ) ;
            }
         }
         CloseExtendedTableCursors0Z97( ) ;
      }

      protected void DeferredUpdate0Z97( )
      {
      }

      protected void Delete0Z97( )
      {
         if ( ! IsAuthorized("trn_theme_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Z97( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z97( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z97( ) ;
            AfterConfirm0Z97( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z97( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Z26 */
                  pr_default.execute(24, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId});
                  pr_default.close(24);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
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
         sMode97 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Z97( ) ;
         Gx_mode = sMode97;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Z97( )
      {
         standaloneModal0Z97( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Z97( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Z97( )
      {
         /* Scan By routine */
         /* Using cursor T000Z27 */
         pr_default.execute(25, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         RcdFound97 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound97 = 1;
            A538CtaColorId = T000Z27_A538CtaColorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z97( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound97 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound97 = 1;
            A538CtaColorId = T000Z27_A538CtaColorId[0];
         }
      }

      protected void ScanEnd0Z97( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm0Z97( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z97( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z97( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z97( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z97( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z97( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z97( )
      {
         edtCtaColorId_Enabled = 0;
         AssignProp("", false, edtCtaColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorId_Enabled), 5, 0), !bGXsfl_42_Refreshing);
         edtCtaColorName_Enabled = 0;
         AssignProp("", false, edtCtaColorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorName_Enabled), 5, 0), !bGXsfl_42_Refreshing);
         edtCtaColorCode_Enabled = 0;
         AssignProp("", false, edtCtaColorCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorCode_Enabled), 5, 0), !bGXsfl_42_Refreshing);
      }

      protected void send_integrity_lvl_hashes0Z97( )
      {
      }

      protected void ZM0Z82( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z443IconCategory = T000Z5_A443IconCategory[0];
               Z283IconName = T000Z5_A283IconName[0];
            }
            else
            {
               Z443IconCategory = A443IconCategory;
               Z283IconName = A283IconName;
            }
         }
         if ( GX_JID == -16 )
         {
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z282IconId = A282IconId;
            Z443IconCategory = A443IconCategory;
            Z283IconName = A283IconName;
            Z643IconTags = A643IconTags;
            Z284IconSVG = A284IconSVG;
         }
      }

      protected void standaloneNotModal0Z82( )
      {
      }

      protected void standaloneModal0Z82( )
      {
         if ( IsIns( )  && (Guid.Empty==A282IconId) && ( Gx_BScreen == 0 ) )
         {
            A282IconId = Guid.NewGuid( );
            AssignAttri("", false, "A282IconId", A282IconId.ToString());
         }
      }

      protected void Load0Z82( )
      {
         /* Using cursor T000Z28 */
         pr_default.execute(26, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A282IconId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound82 = 1;
            A443IconCategory = T000Z28_A443IconCategory[0];
            A283IconName = T000Z28_A283IconName[0];
            A643IconTags = T000Z28_A643IconTags[0];
            A284IconSVG = T000Z28_A284IconSVG[0];
            ZM0Z82( -16) ;
         }
         pr_default.close(26);
         OnLoadActions0Z82( ) ;
      }

      protected void OnLoadActions0Z82( )
      {
      }

      protected void CheckExtendedTable0Z82( )
      {
         nIsDirty_82 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0Z82( ) ;
         if ( ! ( ( StringUtil.StrCmp(A443IconCategory, "General") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Services") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Living") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Health") == 0 ) ) )
         {
            GXCCtl = "ICONCATEGORY_" + sGXsfl_51_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Icon Category", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbIconCategory_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000Z29 */
         pr_default.execute(27, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A283IconName, A443IconCategory, A282IconId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Icon Name", "")+","+context.GetMessage( "Icon Category", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(27);
      }

      protected void CloseExtendedTableCursors0Z82( )
      {
      }

      protected void enableDisable0Z82( )
      {
      }

      protected void GetKey0Z82( )
      {
         /* Using cursor T000Z30 */
         pr_default.execute(28, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A282IconId});
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound82 = 1;
         }
         else
         {
            RcdFound82 = 0;
         }
         pr_default.close(28);
      }

      protected void getByPrimaryKey0Z82( )
      {
         /* Using cursor T000Z5 */
         pr_default.execute(3, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A282IconId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0Z82( 16) ;
            RcdFound82 = 1;
            InitializeNonKey0Z82( ) ;
            A282IconId = T000Z5_A282IconId[0];
            A443IconCategory = T000Z5_A443IconCategory[0];
            A283IconName = T000Z5_A283IconName[0];
            A643IconTags = T000Z5_A643IconTags[0];
            A284IconSVG = T000Z5_A284IconSVG[0];
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z282IconId = A282IconId;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Z82( ) ;
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound82 = 0;
            InitializeNonKey0Z82( ) ;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0Z82( ) ;
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Z82( ) ;
         }
         pr_default.close(3);
      }

      protected void CheckOptimisticConcurrency0Z82( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Z4 */
            pr_default.execute(2, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A282IconId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeIcon"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z443IconCategory, T000Z4_A443IconCategory[0]) != 0 ) || ( StringUtil.StrCmp(Z283IconName, T000Z4_A283IconName[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z443IconCategory, T000Z4_A443IconCategory[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"IconCategory");
                  GXUtil.WriteLogRaw("Old: ",Z443IconCategory);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A443IconCategory[0]);
               }
               if ( StringUtil.StrCmp(Z283IconName, T000Z4_A283IconName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"IconName");
                  GXUtil.WriteLogRaw("Old: ",Z283IconName);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A283IconName[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeIcon"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z82( )
      {
         if ( ! IsAuthorized("trn_theme_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z82( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z82( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z82( 0) ;
            CheckOptimisticConcurrency0Z82( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z82( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z82( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z31 */
                     pr_default.execute(29, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A282IconId, A443IconCategory, A283IconName, A643IconTags, A284IconSVG});
                     pr_default.close(29);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                     if ( (pr_default.getStatus(29) == 1) )
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
               Load0Z82( ) ;
            }
            EndLevel0Z82( ) ;
         }
         CloseExtendedTableCursors0Z82( ) ;
      }

      protected void Update0Z82( )
      {
         if ( ! IsAuthorized("trn_theme_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z82( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z82( ) ;
         }
         if ( ( nIsMod_82 != 0 ) || ( nIsDirty_82 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0Z82( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0Z82( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0Z82( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000Z32 */
                        pr_default.execute(30, new Object[] {A443IconCategory, A283IconName, A643IconTags, A284IconSVG, n273Trn_ThemeId, A273Trn_ThemeId, A282IconId});
                        pr_default.close(30);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                        if ( (pr_default.getStatus(30) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeIcon"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0Z82( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0Z82( ) ;
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
               EndLevel0Z82( ) ;
            }
         }
         CloseExtendedTableCursors0Z82( ) ;
      }

      protected void DeferredUpdate0Z82( )
      {
      }

      protected void Delete0Z82( )
      {
         if ( ! IsAuthorized("trn_theme_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Z82( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z82( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z82( ) ;
            AfterConfirm0Z82( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z82( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Z33 */
                  pr_default.execute(31, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A282IconId});
                  pr_default.close(31);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
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
         sMode82 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Z82( ) ;
         Gx_mode = sMode82;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Z82( )
      {
         standaloneModal0Z82( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Z82( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Z82( )
      {
         /* Scan By routine */
         /* Using cursor T000Z34 */
         pr_default.execute(32, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         RcdFound82 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound82 = 1;
            A282IconId = T000Z34_A282IconId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z82( )
      {
         /* Scan next routine */
         pr_default.readNext(32);
         RcdFound82 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound82 = 1;
            A282IconId = T000Z34_A282IconId[0];
         }
      }

      protected void ScanEnd0Z82( )
      {
         pr_default.close(32);
      }

      protected void AfterConfirm0Z82( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z82( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z82( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z82( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z82( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z82( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z82( )
      {
         edtIconName_Enabled = 0;
         AssignProp("", false, edtIconName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconName_Enabled), 5, 0), !bGXsfl_51_Refreshing);
         cmbIconCategory.Enabled = 0;
         AssignProp("", false, cmbIconCategory_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbIconCategory.Enabled), 5, 0), !bGXsfl_51_Refreshing);
         edtIconSVG_Enabled = 0;
         AssignProp("", false, edtIconSVG_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconSVG_Enabled), 5, 0), !bGXsfl_51_Refreshing);
         edtIconTags_Enabled = 0;
         AssignProp("", false, edtIconTags_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIconTags_Enabled), 5, 0), !bGXsfl_51_Refreshing);
      }

      protected void send_integrity_lvl_hashes0Z82( )
      {
      }

      protected void ZM0Z53( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z276ColorName = T000Z3_A276ColorName[0];
               Z277ColorCode = T000Z3_A277ColorCode[0];
            }
            else
            {
               Z276ColorName = A276ColorName;
               Z277ColorCode = A277ColorCode;
            }
         }
         if ( GX_JID == -18 )
         {
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z275ColorId = A275ColorId;
            Z276ColorName = A276ColorName;
            Z277ColorCode = A277ColorCode;
         }
      }

      protected void standaloneNotModal0Z53( )
      {
         edtColorId_Enabled = 0;
         AssignProp("", false, edtColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorId_Enabled), 5, 0), !bGXsfl_64_Refreshing);
      }

      protected void standaloneModal0Z53( )
      {
         if ( IsIns( )  && (Guid.Empty==A275ColorId) && ( Gx_BScreen == 0 ) )
         {
            A275ColorId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Z53( )
      {
         /* Using cursor T000Z35 */
         pr_default.execute(33, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound53 = 1;
            A276ColorName = T000Z35_A276ColorName[0];
            A277ColorCode = T000Z35_A277ColorCode[0];
            ZM0Z53( -18) ;
         }
         pr_default.close(33);
         OnLoadActions0Z53( ) ;
      }

      protected void OnLoadActions0Z53( )
      {
      }

      protected void CheckExtendedTable0Z53( )
      {
         nIsDirty_53 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0Z53( ) ;
         /* Using cursor T000Z36 */
         pr_default.execute(34, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A276ColorName, A275ColorId});
         if ( (pr_default.getStatus(34) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Color Name", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(34);
         /* Using cursor T000Z37 */
         pr_default.execute(35, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A276ColorName, A277ColorCode, A275ColorId});
         if ( (pr_default.getStatus(35) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Color Name", "")+","+context.GetMessage( "Color Code", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(35);
      }

      protected void CloseExtendedTableCursors0Z53( )
      {
      }

      protected void enableDisable0Z53( )
      {
      }

      protected void GetKey0Z53( )
      {
         /* Using cursor T000Z38 */
         pr_default.execute(36, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId});
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound53 = 1;
         }
         else
         {
            RcdFound53 = 0;
         }
         pr_default.close(36);
      }

      protected void getByPrimaryKey0Z53( )
      {
         /* Using cursor T000Z3 */
         pr_default.execute(1, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Z53( 18) ;
            RcdFound53 = 1;
            InitializeNonKey0Z53( ) ;
            A275ColorId = T000Z3_A275ColorId[0];
            A276ColorName = T000Z3_A276ColorName[0];
            A277ColorCode = T000Z3_A277ColorCode[0];
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z275ColorId = A275ColorId;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Z53( ) ;
            Gx_mode = sMode53;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound53 = 0;
            InitializeNonKey0Z53( ) ;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0Z53( ) ;
            Gx_mode = sMode53;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Z53( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0Z53( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Z2 */
            pr_default.execute(0, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeColor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z276ColorName, T000Z2_A276ColorName[0]) != 0 ) || ( StringUtil.StrCmp(Z277ColorCode, T000Z2_A277ColorCode[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z276ColorName, T000Z2_A276ColorName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"ColorName");
                  GXUtil.WriteLogRaw("Old: ",Z276ColorName);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A276ColorName[0]);
               }
               if ( StringUtil.StrCmp(Z277ColorCode, T000Z2_A277ColorCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"ColorCode");
                  GXUtil.WriteLogRaw("Old: ",Z277ColorCode);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A277ColorCode[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeColor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z53( )
      {
         if ( ! IsAuthorized("trn_theme_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z53( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z53( 0) ;
            CheckOptimisticConcurrency0Z53( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z53( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z39 */
                     pr_default.execute(37, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId, A276ColorName, A277ColorCode});
                     pr_default.close(37);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                     if ( (pr_default.getStatus(37) == 1) )
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
               Load0Z53( ) ;
            }
            EndLevel0Z53( ) ;
         }
         CloseExtendedTableCursors0Z53( ) ;
      }

      protected void Update0Z53( )
      {
         if ( ! IsAuthorized("trn_theme_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z53( ) ;
         }
         if ( ( nIsMod_53 != 0 ) || ( nIsDirty_53 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0Z53( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0Z53( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0Z53( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000Z40 */
                        pr_default.execute(38, new Object[] {A276ColorName, A277ColorCode, n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId});
                        pr_default.close(38);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                        if ( (pr_default.getStatus(38) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeColor"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0Z53( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0Z53( ) ;
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
               EndLevel0Z53( ) ;
            }
         }
         CloseExtendedTableCursors0Z53( ) ;
      }

      protected void DeferredUpdate0Z53( )
      {
      }

      protected void Delete0Z53( )
      {
         if ( ! IsAuthorized("trn_theme_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Z53( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z53( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z53( ) ;
            AfterConfirm0Z53( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z53( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Z41 */
                  pr_default.execute(39, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId});
                  pr_default.close(39);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
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
         sMode53 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Z53( ) ;
         Gx_mode = sMode53;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Z53( )
      {
         standaloneModal0Z53( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Z53( )
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

      public void ScanStart0Z53( )
      {
         /* Scan By routine */
         /* Using cursor T000Z42 */
         pr_default.execute(40, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         RcdFound53 = 0;
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound53 = 1;
            A275ColorId = T000Z42_A275ColorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z53( )
      {
         /* Scan next routine */
         pr_default.readNext(40);
         RcdFound53 = 0;
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound53 = 1;
            A275ColorId = T000Z42_A275ColorId[0];
         }
      }

      protected void ScanEnd0Z53( )
      {
         pr_default.close(40);
      }

      protected void AfterConfirm0Z53( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z53( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z53( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z53( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z53( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z53( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z53( )
      {
         edtColorId_Enabled = 0;
         AssignProp("", false, edtColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorId_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         cmbColorName.Enabled = 0;
         AssignProp("", false, cmbColorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbColorName.Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtColorCode_Enabled = 0;
         AssignProp("", false, edtColorCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorCode_Enabled), 5, 0), !bGXsfl_64_Refreshing);
      }

      protected void send_integrity_lvl_hashes0Z53( )
      {
      }

      protected void send_integrity_lvl_hashes0Z51( )
      {
      }

      protected void SubsflControlProps_4297( )
      {
         edtCtaColorId_Internalname = "CTACOLORID_"+sGXsfl_42_idx;
         edtCtaColorName_Internalname = "CTACOLORNAME_"+sGXsfl_42_idx;
         edtCtaColorCode_Internalname = "CTACOLORCODE_"+sGXsfl_42_idx;
      }

      protected void SubsflControlProps_fel_4297( )
      {
         edtCtaColorId_Internalname = "CTACOLORID_"+sGXsfl_42_fel_idx;
         edtCtaColorName_Internalname = "CTACOLORNAME_"+sGXsfl_42_fel_idx;
         edtCtaColorCode_Internalname = "CTACOLORCODE_"+sGXsfl_42_fel_idx;
      }

      protected void AddRow0Z97( )
      {
         nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
         sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx), 4, 0), 4, "0");
         SubsflControlProps_4297( ) ;
         SendRow0Z97( ) ;
      }

      protected void SendRow0Z97( )
      {
         Gridlevel_ctacolorRow = GXWebRow.GetNew(context);
         if ( subGridlevel_ctacolor_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_ctacolor_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_ctacolor_Class, "") != 0 )
            {
               subGridlevel_ctacolor_Linesclass = subGridlevel_ctacolor_Class+"Odd";
            }
         }
         else if ( subGridlevel_ctacolor_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_ctacolor_Backstyle = 0;
            subGridlevel_ctacolor_Backcolor = subGridlevel_ctacolor_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_ctacolor_Class, "") != 0 )
            {
               subGridlevel_ctacolor_Linesclass = subGridlevel_ctacolor_Class+"Uniform";
            }
         }
         else if ( subGridlevel_ctacolor_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_ctacolor_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_ctacolor_Class, "") != 0 )
            {
               subGridlevel_ctacolor_Linesclass = subGridlevel_ctacolor_Class+"Odd";
            }
            subGridlevel_ctacolor_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_ctacolor_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_ctacolor_Backstyle = 1;
            if ( ((int)((nGXsfl_42_idx) % (2))) == 0 )
            {
               subGridlevel_ctacolor_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_ctacolor_Class, "") != 0 )
               {
                  subGridlevel_ctacolor_Linesclass = subGridlevel_ctacolor_Class+"Even";
               }
            }
            else
            {
               subGridlevel_ctacolor_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_ctacolor_Class, "") != 0 )
               {
                  subGridlevel_ctacolor_Linesclass = subGridlevel_ctacolor_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_97_" + sGXsfl_42_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_42_idx + "',42)\"";
         ROClassString = "Attribute";
         Gridlevel_ctacolorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCtaColorId_Internalname,A538CtaColorId.ToString(),A538CtaColorId.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCtaColorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCtaColorId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)42,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_97_" + sGXsfl_42_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_42_idx + "',42)\"";
         ROClassString = "Attribute";
         Gridlevel_ctacolorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCtaColorName_Internalname,(string)A539CtaColorName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCtaColorName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCtaColorName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)42,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_97_" + sGXsfl_42_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_42_idx + "',42)\"";
         ROClassString = "Attribute";
         Gridlevel_ctacolorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCtaColorCode_Internalname,(string)A540CtaColorCode,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCtaColorCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCtaColorCode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)42,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Code",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_ctacolorRow);
         send_integrity_lvl_hashes0Z97( ) ;
         GXCCtl = "Z538CtaColorId_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z538CtaColorId.ToString());
         GXCCtl = "Z539CtaColorName_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z539CtaColorName);
         GXCCtl = "Z540CtaColorCode_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z540CtaColorCode);
         GXCCtl = "nRcdDeleted_97_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_97), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_97_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_97), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_97_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_97), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_42_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vTRN_THEMEID_" + sGXsfl_42_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV7Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "CTACOLORID_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CTACOLORNAME_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CTACOLORCODE_"+sGXsfl_42_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorCode_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_ctacolorContainer.AddRow(Gridlevel_ctacolorRow);
      }

      protected void ReadRow0Z97( )
      {
         nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
         sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx), 4, 0), 4, "0");
         SubsflControlProps_4297( ) ;
         edtCtaColorId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTACOLORID_"+sGXsfl_42_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCtaColorName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTACOLORNAME_"+sGXsfl_42_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCtaColorCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CTACOLORCODE_"+sGXsfl_42_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( StringUtil.StrCmp(cgiGet( edtCtaColorId_Internalname), "") == 0 )
         {
            A538CtaColorId = Guid.Empty;
         }
         else
         {
            try
            {
               A538CtaColorId = StringUtil.StrToGuid( cgiGet( edtCtaColorId_Internalname));
            }
            catch ( Exception  )
            {
               GXCCtl = "CTACOLORID_" + sGXsfl_42_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtCtaColorId_Internalname;
               wbErr = true;
            }
         }
         A539CtaColorName = cgiGet( edtCtaColorName_Internalname);
         A540CtaColorCode = cgiGet( edtCtaColorCode_Internalname);
         GXCCtl = "Z538CtaColorId_" + sGXsfl_42_idx;
         Z538CtaColorId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z539CtaColorName_" + sGXsfl_42_idx;
         Z539CtaColorName = cgiGet( GXCCtl);
         GXCCtl = "Z540CtaColorCode_" + sGXsfl_42_idx;
         Z540CtaColorCode = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_97_" + sGXsfl_42_idx;
         nRcdDeleted_97 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_97_" + sGXsfl_42_idx;
         nRcdExists_97 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_97_" + sGXsfl_42_idx;
         nIsMod_97 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_5182( )
      {
         edtIconName_Internalname = "ICONNAME_"+sGXsfl_51_idx;
         cmbIconCategory_Internalname = "ICONCATEGORY_"+sGXsfl_51_idx;
         edtIconSVG_Internalname = "ICONSVG_"+sGXsfl_51_idx;
         edtIconTags_Internalname = "ICONTAGS_"+sGXsfl_51_idx;
      }

      protected void SubsflControlProps_fel_5182( )
      {
         edtIconName_Internalname = "ICONNAME_"+sGXsfl_51_fel_idx;
         cmbIconCategory_Internalname = "ICONCATEGORY_"+sGXsfl_51_fel_idx;
         edtIconSVG_Internalname = "ICONSVG_"+sGXsfl_51_fel_idx;
         edtIconTags_Internalname = "ICONTAGS_"+sGXsfl_51_fel_idx;
      }

      protected void AddRow0Z82( )
      {
         nGXsfl_51_idx = (int)(nGXsfl_51_idx+1);
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_5182( ) ;
         SendRow0Z82( ) ;
      }

      protected void SendRow0Z82( )
      {
         Gridlevel_iconRow = GXWebRow.GetNew(context);
         if ( subGridlevel_icon_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_icon_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_icon_Class, "") != 0 )
            {
               subGridlevel_icon_Linesclass = subGridlevel_icon_Class+"Odd";
            }
         }
         else if ( subGridlevel_icon_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_icon_Backstyle = 0;
            subGridlevel_icon_Backcolor = subGridlevel_icon_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_icon_Class, "") != 0 )
            {
               subGridlevel_icon_Linesclass = subGridlevel_icon_Class+"Uniform";
            }
         }
         else if ( subGridlevel_icon_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_icon_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_icon_Class, "") != 0 )
            {
               subGridlevel_icon_Linesclass = subGridlevel_icon_Class+"Odd";
            }
            subGridlevel_icon_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_icon_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_icon_Backstyle = 1;
            if ( ((int)((nGXsfl_51_idx) % (2))) == 0 )
            {
               subGridlevel_icon_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_icon_Class, "") != 0 )
               {
                  subGridlevel_icon_Linesclass = subGridlevel_icon_Class+"Even";
               }
            }
            else
            {
               subGridlevel_icon_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_icon_Class, "") != 0 )
               {
                  subGridlevel_icon_Linesclass = subGridlevel_icon_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_82_" + sGXsfl_51_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_51_idx + "',51)\"";
         ROClassString = "Attribute";
         Gridlevel_iconRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIconName_Internalname,(string)A283IconName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIconName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtIconName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)51,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_82_" + sGXsfl_51_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_51_idx + "',51)\"";
         if ( ( cmbIconCategory.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "ICONCATEGORY_" + sGXsfl_51_idx;
            cmbIconCategory.Name = GXCCtl;
            cmbIconCategory.WebTags = "";
            cmbIconCategory.addItem("General", context.GetMessage( "General", ""), 0);
            cmbIconCategory.addItem("Services", context.GetMessage( "Services", ""), 0);
            cmbIconCategory.addItem("Living", context.GetMessage( "Living", ""), 0);
            cmbIconCategory.addItem("Health", context.GetMessage( "Health", ""), 0);
            if ( cmbIconCategory.ItemCount > 0 )
            {
               A443IconCategory = cmbIconCategory.getValidValue(A443IconCategory);
            }
         }
         /* ComboBox */
         Gridlevel_iconRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbIconCategory,(string)cmbIconCategory_Internalname,StringUtil.RTrim( A443IconCategory),(short)1,(string)cmbIconCategory_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbIconCategory.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"",(bool)true,(short)0});
         cmbIconCategory.CurrentValue = StringUtil.RTrim( A443IconCategory);
         AssignProp("", false, cmbIconCategory_Internalname, "Values", (string)(cmbIconCategory.ToJavascriptSource()), !bGXsfl_51_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_82_" + sGXsfl_51_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_51_idx + "',51)\"";
         ROClassString = "Attribute";
         Gridlevel_iconRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIconSVG_Internalname,(string)A284IconSVG,(string)A284IconSVG,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIconSVG_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtIconSVG_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)51,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_82_" + sGXsfl_51_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_51_idx + "',51)\"";
         ROClassString = "Attribute";
         Gridlevel_iconRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIconTags_Internalname,(string)A643IconTags,(string)A643IconTags,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIconTags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtIconTags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)51,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         ajax_sending_grid_row(Gridlevel_iconRow);
         send_integrity_lvl_hashes0Z82( ) ;
         GXCCtl = "ICONID_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, A282IconId.ToString());
         GXCCtl = "Z282IconId_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z282IconId.ToString());
         GXCCtl = "Z443IconCategory_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z443IconCategory);
         GXCCtl = "Z283IconName_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z283IconName);
         GXCCtl = "nRcdDeleted_82_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_82), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_82_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_82), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_82_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_82), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_51_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vTRN_THEMEID_" + sGXsfl_51_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV7Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "ICONNAME_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ICONCATEGORY_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbIconCategory.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ICONSVG_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconSVG_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ICONTAGS_"+sGXsfl_51_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconTags_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_iconContainer.AddRow(Gridlevel_iconRow);
      }

      protected void ReadRow0Z82( )
      {
         nGXsfl_51_idx = (int)(nGXsfl_51_idx+1);
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_5182( ) ;
         edtIconName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONNAME_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbIconCategory.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONCATEGORY_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtIconSVG_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONSVG_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtIconTags_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ICONTAGS_"+sGXsfl_51_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A283IconName = cgiGet( edtIconName_Internalname);
         cmbIconCategory.Name = cmbIconCategory_Internalname;
         cmbIconCategory.CurrentValue = cgiGet( cmbIconCategory_Internalname);
         A443IconCategory = cgiGet( cmbIconCategory_Internalname);
         A284IconSVG = cgiGet( edtIconSVG_Internalname);
         A643IconTags = cgiGet( edtIconTags_Internalname);
         GXCCtl = "ICONID_" + sGXsfl_51_idx;
         A282IconId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z282IconId_" + sGXsfl_51_idx;
         Z282IconId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z443IconCategory_" + sGXsfl_51_idx;
         Z443IconCategory = cgiGet( GXCCtl);
         GXCCtl = "Z283IconName_" + sGXsfl_51_idx;
         Z283IconName = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_82_" + sGXsfl_51_idx;
         nRcdDeleted_82 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_82_" + sGXsfl_51_idx;
         nRcdExists_82 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_82_" + sGXsfl_51_idx;
         nIsMod_82 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_6453( )
      {
         edtColorId_Internalname = "COLORID_"+sGXsfl_64_idx;
         cmbColorName_Internalname = "COLORNAME_"+sGXsfl_64_idx;
         edtColorCode_Internalname = "COLORCODE_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_6453( )
      {
         edtColorId_Internalname = "COLORID_"+sGXsfl_64_fel_idx;
         cmbColorName_Internalname = "COLORNAME_"+sGXsfl_64_fel_idx;
         edtColorCode_Internalname = "COLORCODE_"+sGXsfl_64_fel_idx;
      }

      protected void AddRow0Z53( )
      {
         nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_6453( ) ;
         SendRow0Z53( ) ;
      }

      protected void SendRow0Z53( )
      {
         Gridlevel_colorRow = GXWebRow.GetNew(context);
         if ( subGridlevel_color_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_color_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
            {
               subGridlevel_color_Linesclass = subGridlevel_color_Class+"Odd";
            }
         }
         else if ( subGridlevel_color_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_color_Backstyle = 0;
            subGridlevel_color_Backcolor = subGridlevel_color_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
            {
               subGridlevel_color_Linesclass = subGridlevel_color_Class+"Uniform";
            }
         }
         else if ( subGridlevel_color_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_color_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
            {
               subGridlevel_color_Linesclass = subGridlevel_color_Class+"Odd";
            }
            subGridlevel_color_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_color_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_color_Backstyle = 1;
            if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
            {
               subGridlevel_color_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
               {
                  subGridlevel_color_Linesclass = subGridlevel_color_Class+"Even";
               }
            }
            else
            {
               subGridlevel_color_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
               {
                  subGridlevel_color_Linesclass = subGridlevel_color_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_colorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtColorId_Internalname,A275ColorId.ToString(),A275ColorId.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtColorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtColorId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)64,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_53_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_64_idx + "',64)\"";
         if ( ( cmbColorName.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "COLORNAME_" + sGXsfl_64_idx;
            cmbColorName.Name = GXCCtl;
            cmbColorName.WebTags = "";
            cmbColorName.addItem("cardBgColor", context.GetMessage( "Card BG Color", ""), 0);
            cmbColorName.addItem("ButtonBgColor", context.GetMessage( "Button Bg Color", ""), 0);
            cmbColorName.addItem("secondaryColor", context.GetMessage( "Secondary Color", ""), 0);
            cmbColorName.addItem("borderColor", context.GetMessage( "Border Color", ""), 0);
            cmbColorName.addItem("backgroundColor", context.GetMessage( "Background Color", ""), 0);
            cmbColorName.addItem("textColor", context.GetMessage( "Text Color", ""), 0);
            cmbColorName.addItem("cardTextColor", context.GetMessage( "Card Text Color", ""), 0);
            cmbColorName.addItem("accentColor", context.GetMessage( "Accent Color", ""), 0);
            cmbColorName.addItem("buttonTextColor", context.GetMessage( "Button Text Color", ""), 0);
            cmbColorName.addItem("primaryColor", context.GetMessage( "Primary Color", ""), 0);
            if ( cmbColorName.ItemCount > 0 )
            {
               A276ColorName = cmbColorName.getValidValue(A276ColorName);
            }
         }
         /* ComboBox */
         Gridlevel_colorRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbColorName,(string)cmbColorName_Internalname,StringUtil.RTrim( A276ColorName),(short)1,(string)cmbColorName_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbColorName.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"",(string)"",(bool)true,(short)0});
         cmbColorName.CurrentValue = StringUtil.RTrim( A276ColorName);
         AssignProp("", false, cmbColorName_Internalname, "Values", (string)(cmbColorName.ToJavascriptSource()), !bGXsfl_64_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_53_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridlevel_colorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtColorCode_Internalname,(string)A277ColorCode,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtColorCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtColorCode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Code",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_colorRow);
         send_integrity_lvl_hashes0Z53( ) ;
         GXCCtl = "Z275ColorId_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z275ColorId.ToString());
         GXCCtl = "Z276ColorName_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z276ColorName);
         GXCCtl = "Z277ColorCode_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z277ColorCode);
         GXCCtl = "nRcdDeleted_53_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_53), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_53_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_53), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_53_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_53), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_64_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vTRN_THEMEID_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV7Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "COLORID_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COLORNAME_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbColorName.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COLORCODE_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorCode_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_colorContainer.AddRow(Gridlevel_colorRow);
      }

      protected void ReadRow0Z53( )
      {
         nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_6453( ) ;
         edtColorId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORID_"+sGXsfl_64_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbColorName.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORNAME_"+sGXsfl_64_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtColorCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORCODE_"+sGXsfl_64_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A275ColorId = StringUtil.StrToGuid( cgiGet( edtColorId_Internalname));
         cmbColorName.Name = cmbColorName_Internalname;
         cmbColorName.CurrentValue = cgiGet( cmbColorName_Internalname);
         A276ColorName = cgiGet( cmbColorName_Internalname);
         A277ColorCode = cgiGet( edtColorCode_Internalname);
         GXCCtl = "Z275ColorId_" + sGXsfl_64_idx;
         Z275ColorId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z276ColorName_" + sGXsfl_64_idx;
         Z276ColorName = cgiGet( GXCCtl);
         GXCCtl = "Z277ColorCode_" + sGXsfl_64_idx;
         Z277ColorCode = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_53_" + sGXsfl_64_idx;
         nRcdDeleted_53 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_53_" + sGXsfl_64_idx;
         nRcdExists_53 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_53_" + sGXsfl_64_idx;
         nIsMod_53 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtColorId_Enabled = edtColorId_Enabled;
         defedtCtaColorId_Enabled = edtCtaColorId_Enabled;
      }

      protected void ConfirmValues0Z0( )
      {
         nGXsfl_42_idx = 0;
         sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx), 4, 0), 4, "0");
         SubsflControlProps_4297( ) ;
         while ( nGXsfl_42_idx < nRC_GXsfl_42 )
         {
            nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
            sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx), 4, 0), 4, "0");
            SubsflControlProps_4297( ) ;
            ChangePostValue( "Z538CtaColorId_"+sGXsfl_42_idx, cgiGet( "ZT_"+"Z538CtaColorId_"+sGXsfl_42_idx)) ;
            DeletePostValue( "ZT_"+"Z538CtaColorId_"+sGXsfl_42_idx) ;
            ChangePostValue( "Z539CtaColorName_"+sGXsfl_42_idx, cgiGet( "ZT_"+"Z539CtaColorName_"+sGXsfl_42_idx)) ;
            DeletePostValue( "ZT_"+"Z539CtaColorName_"+sGXsfl_42_idx) ;
            ChangePostValue( "Z540CtaColorCode_"+sGXsfl_42_idx, cgiGet( "ZT_"+"Z540CtaColorCode_"+sGXsfl_42_idx)) ;
            DeletePostValue( "ZT_"+"Z540CtaColorCode_"+sGXsfl_42_idx) ;
         }
         nGXsfl_51_idx = 0;
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_5182( ) ;
         while ( nGXsfl_51_idx < nRC_GXsfl_51 )
         {
            nGXsfl_51_idx = (int)(nGXsfl_51_idx+1);
            sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
            SubsflControlProps_5182( ) ;
            ChangePostValue( "Z282IconId_"+sGXsfl_51_idx, cgiGet( "ZT_"+"Z282IconId_"+sGXsfl_51_idx)) ;
            DeletePostValue( "ZT_"+"Z282IconId_"+sGXsfl_51_idx) ;
            ChangePostValue( "Z443IconCategory_"+sGXsfl_51_idx, cgiGet( "ZT_"+"Z443IconCategory_"+sGXsfl_51_idx)) ;
            DeletePostValue( "ZT_"+"Z443IconCategory_"+sGXsfl_51_idx) ;
            ChangePostValue( "Z283IconName_"+sGXsfl_51_idx, cgiGet( "ZT_"+"Z283IconName_"+sGXsfl_51_idx)) ;
            DeletePostValue( "ZT_"+"Z283IconName_"+sGXsfl_51_idx) ;
         }
         nGXsfl_64_idx = 0;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_6453( ) ;
         while ( nGXsfl_64_idx < nRC_GXsfl_64 )
         {
            nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_6453( ) ;
            ChangePostValue( "Z275ColorId_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z275ColorId_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z275ColorId_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z276ColorName_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z276ColorName_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z276ColorName_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z277ColorCode_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z277ColorCode_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z277ColorCode_"+sGXsfl_64_idx) ;
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
         GXEncryptionTmp = "trn_theme.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7Trn_ThemeId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_theme.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Theme");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ThemeIsPredefined", StringUtil.BoolToStr( A576ThemeIsPredefined));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_theme:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z273Trn_ThemeId", Z273Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "Z274Trn_ThemeName", Z274Trn_ThemeName);
         GxWebStd.gx_hidden_field( context, "Z281Trn_ThemeFontFamily", Z281Trn_ThemeFontFamily);
         GxWebStd.gx_hidden_field( context, "Z405Trn_ThemeFontSize", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z405Trn_ThemeFontSize), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z576ThemeIsPredefined", Z576ThemeIsPredefined);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_42", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_42_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_51", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_51_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_64_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vTRN_THEMEID", AV7Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRN_THEMEID", GetSecureSignedToken( "", AV7Trn_ThemeId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "THEMEISPREDEFINED", A576ThemeIsPredefined);
         GxWebStd.gx_hidden_field( context, "ICONID", A282IconId.ToString());
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
         GXEncryptionTmp = "trn_theme.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7Trn_ThemeId.ToString());
         return formatLink("trn_theme.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Theme" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Theme", "") ;
      }

      protected void InitializeNonKey0Z51( )
      {
         A274Trn_ThemeName = "";
         AssignAttri("", false, "A274Trn_ThemeName", A274Trn_ThemeName);
         A281Trn_ThemeFontFamily = "";
         AssignAttri("", false, "A281Trn_ThemeFontFamily", A281Trn_ThemeFontFamily);
         A405Trn_ThemeFontSize = 0;
         AssignAttri("", false, "A405Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A405Trn_ThemeFontSize), 4, 0));
         A576ThemeIsPredefined = false;
         AssignAttri("", false, "A576ThemeIsPredefined", A576ThemeIsPredefined);
         Z274Trn_ThemeName = "";
         Z281Trn_ThemeFontFamily = "";
         Z405Trn_ThemeFontSize = 0;
         Z576ThemeIsPredefined = false;
      }

      protected void InitAll0Z51( )
      {
         A273Trn_ThemeId = Guid.NewGuid( );
         n273Trn_ThemeId = false;
         AssignAttri("", false, "A273Trn_ThemeId", A273Trn_ThemeId.ToString());
         InitializeNonKey0Z51( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A576ThemeIsPredefined = i576ThemeIsPredefined;
         AssignAttri("", false, "A576ThemeIsPredefined", A576ThemeIsPredefined);
      }

      protected void InitializeNonKey0Z97( )
      {
         A539CtaColorName = "";
         A540CtaColorCode = "";
         Z539CtaColorName = "";
         Z540CtaColorCode = "";
      }

      protected void InitAll0Z97( )
      {
         A538CtaColorId = Guid.NewGuid( );
         InitializeNonKey0Z97( ) ;
      }

      protected void StandaloneModalInsert0Z97( )
      {
      }

      protected void InitializeNonKey0Z82( )
      {
         A443IconCategory = "";
         A283IconName = "";
         A643IconTags = "";
         A284IconSVG = "";
         Z443IconCategory = "";
         Z283IconName = "";
      }

      protected void InitAll0Z82( )
      {
         A282IconId = Guid.NewGuid( );
         AssignAttri("", false, "A282IconId", A282IconId.ToString());
         InitializeNonKey0Z82( ) ;
      }

      protected void StandaloneModalInsert0Z82( )
      {
      }

      protected void InitializeNonKey0Z53( )
      {
         A276ColorName = "";
         A277ColorCode = "";
         Z276ColorName = "";
         Z277ColorCode = "";
      }

      protected void InitAll0Z53( )
      {
         A275ColorId = Guid.NewGuid( );
         InitializeNonKey0Z53( ) ;
      }

      protected void StandaloneModalInsert0Z53( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309414732", true, true);
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
         context.AddJavascriptSource("trn_theme.js", "?20256309414732", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties97( )
      {
         edtCtaColorId_Enabled = defedtCtaColorId_Enabled;
         AssignProp("", false, edtCtaColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCtaColorId_Enabled), 5, 0), !bGXsfl_42_Refreshing);
      }

      protected void init_level_properties82( )
      {
      }

      protected void init_level_properties53( )
      {
         edtColorId_Enabled = defedtColorId_Enabled;
         AssignProp("", false, edtColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorId_Enabled), 5, 0), !bGXsfl_64_Refreshing);
      }

      protected void StartGridControl42( )
      {
         Gridlevel_ctacolorContainer.AddObjectProperty("GridName", "Gridlevel_ctacolor");
         Gridlevel_ctacolorContainer.AddObjectProperty("Header", subGridlevel_ctacolor_Header);
         Gridlevel_ctacolorContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_ctacolorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_ctacolorContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_ctacolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_ctacolorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A538CtaColorId.ToString()));
         Gridlevel_ctacolorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorId_Enabled), 5, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddColumnProperties(Gridlevel_ctacolorColumn);
         Gridlevel_ctacolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_ctacolorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A539CtaColorName));
         Gridlevel_ctacolorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorName_Enabled), 5, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddColumnProperties(Gridlevel_ctacolorColumn);
         Gridlevel_ctacolorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_ctacolorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A540CtaColorCode));
         Gridlevel_ctacolorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCtaColorCode_Enabled), 5, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddColumnProperties(Gridlevel_ctacolorColumn);
         Gridlevel_ctacolorContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Selectedindex), 4, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Allowselection), 1, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Allowhovering), 1, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_ctacolorContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_ctacolor_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl51( )
      {
         Gridlevel_iconContainer.AddObjectProperty("GridName", "Gridlevel_icon");
         Gridlevel_iconContainer.AddObjectProperty("Header", subGridlevel_icon_Header);
         Gridlevel_iconContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_iconContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_iconContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_iconColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_iconColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A283IconName));
         Gridlevel_iconColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconName_Enabled), 5, 0, ".", "")));
         Gridlevel_iconContainer.AddColumnProperties(Gridlevel_iconColumn);
         Gridlevel_iconColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_iconColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A443IconCategory));
         Gridlevel_iconColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbIconCategory.Enabled), 5, 0, ".", "")));
         Gridlevel_iconContainer.AddColumnProperties(Gridlevel_iconColumn);
         Gridlevel_iconColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_iconColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A284IconSVG));
         Gridlevel_iconColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconSVG_Enabled), 5, 0, ".", "")));
         Gridlevel_iconContainer.AddColumnProperties(Gridlevel_iconColumn);
         Gridlevel_iconColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_iconColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A643IconTags));
         Gridlevel_iconColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIconTags_Enabled), 5, 0, ".", "")));
         Gridlevel_iconContainer.AddColumnProperties(Gridlevel_iconColumn);
         Gridlevel_iconContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Selectedindex), 4, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Allowselection), 1, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Allowhovering), 1, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_iconContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_icon_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl64( )
      {
         Gridlevel_colorContainer.AddObjectProperty("GridName", "Gridlevel_color");
         Gridlevel_colorContainer.AddObjectProperty("Header", subGridlevel_color_Header);
         Gridlevel_colorContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_colorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_colorContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_colorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_colorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A275ColorId.ToString()));
         Gridlevel_colorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorId_Enabled), 5, 0, ".", "")));
         Gridlevel_colorContainer.AddColumnProperties(Gridlevel_colorColumn);
         Gridlevel_colorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_colorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A276ColorName));
         Gridlevel_colorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbColorName.Enabled), 5, 0, ".", "")));
         Gridlevel_colorContainer.AddColumnProperties(Gridlevel_colorColumn);
         Gridlevel_colorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_colorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A277ColorCode));
         Gridlevel_colorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorCode_Enabled), 5, 0, ".", "")));
         Gridlevel_colorContainer.AddColumnProperties(Gridlevel_colorColumn);
         Gridlevel_colorContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Selectedindex), 4, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Allowselection), 1, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Allowhovering), 1, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtTrn_ThemeId_Internalname = "TRN_THEMEID";
         edtTrn_ThemeName_Internalname = "TRN_THEMENAME";
         edtTrn_ThemeFontFamily_Internalname = "TRN_THEMEFONTFAMILY";
         edtTrn_ThemeFontSize_Internalname = "TRN_THEMEFONTSIZE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         edtCtaColorId_Internalname = "CTACOLORID";
         edtCtaColorName_Internalname = "CTACOLORNAME";
         edtCtaColorCode_Internalname = "CTACOLORCODE";
         divTableleaflevel_ctacolor_Internalname = "TABLELEAFLEVEL_CTACOLOR";
         edtIconName_Internalname = "ICONNAME";
         cmbIconCategory_Internalname = "ICONCATEGORY";
         edtIconSVG_Internalname = "ICONSVG";
         edtIconTags_Internalname = "ICONTAGS";
         divTableleaflevel_icon_Internalname = "TABLELEAFLEVEL_ICON";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtColorId_Internalname = "COLORID";
         cmbColorName_Internalname = "COLORNAME";
         edtColorCode_Internalname = "COLORCODE";
         divTableleaflevel_color_Internalname = "TABLELEAFLEVEL_COLOR";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_ctacolor_Internalname = "GRIDLEVEL_CTACOLOR";
         subGridlevel_icon_Internalname = "GRIDLEVEL_ICON";
         subGridlevel_color_Internalname = "GRIDLEVEL_COLOR";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_color_Allowcollapsing = 0;
         subGridlevel_color_Allowselection = 0;
         subGridlevel_color_Header = "";
         subGridlevel_icon_Allowcollapsing = 0;
         subGridlevel_icon_Allowselection = 0;
         subGridlevel_icon_Header = "";
         subGridlevel_ctacolor_Allowcollapsing = 0;
         subGridlevel_ctacolor_Allowselection = 0;
         subGridlevel_ctacolor_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Trn_Theme", "");
         edtColorCode_Jsonclick = "";
         cmbColorName_Jsonclick = "";
         edtColorId_Jsonclick = "";
         subGridlevel_color_Class = "WorkWith";
         subGridlevel_color_Backcolorstyle = 0;
         edtIconTags_Jsonclick = "";
         edtIconSVG_Jsonclick = "";
         cmbIconCategory_Jsonclick = "";
         edtIconName_Jsonclick = "";
         subGridlevel_icon_Class = "WorkWith";
         subGridlevel_icon_Backcolorstyle = 0;
         edtCtaColorCode_Jsonclick = "";
         edtCtaColorName_Jsonclick = "";
         edtCtaColorId_Jsonclick = "";
         subGridlevel_ctacolor_Class = "WorkWith";
         subGridlevel_ctacolor_Backcolorstyle = 0;
         edtColorCode_Enabled = 1;
         cmbColorName.Enabled = 1;
         edtColorId_Enabled = 0;
         edtIconTags_Enabled = 1;
         edtIconSVG_Enabled = 1;
         cmbIconCategory.Enabled = 1;
         edtIconName_Enabled = 1;
         edtCtaColorCode_Enabled = 1;
         edtCtaColorName_Enabled = 1;
         edtCtaColorId_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTrn_ThemeFontSize_Jsonclick = "";
         edtTrn_ThemeFontSize_Enabled = 1;
         edtTrn_ThemeFontFamily_Jsonclick = "";
         edtTrn_ThemeFontFamily_Enabled = 1;
         edtTrn_ThemeName_Jsonclick = "";
         edtTrn_ThemeName_Enabled = 1;
         edtTrn_ThemeId_Jsonclick = "";
         edtTrn_ThemeId_Enabled = 1;
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

      protected void gxnrGridlevel_ctacolor_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_4297( ) ;
         while ( nGXsfl_42_idx <= nRC_GXsfl_42 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0Z97( ) ;
            standaloneModal0Z97( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0Z97( ) ;
            nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
            sGXsfl_42_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_42_idx), 4, 0), 4, "0");
            SubsflControlProps_4297( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_ctacolorContainer)) ;
         /* End function gxnrGridlevel_ctacolor_newrow */
      }

      protected void gxnrGridlevel_icon_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_5182( ) ;
         while ( nGXsfl_51_idx <= nRC_GXsfl_51 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0Z82( ) ;
            standaloneModal0Z82( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0Z82( ) ;
            nGXsfl_51_idx = (int)(nGXsfl_51_idx+1);
            sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
            SubsflControlProps_5182( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_iconContainer)) ;
         /* End function gxnrGridlevel_icon_newrow */
      }

      protected void gxnrGridlevel_color_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_6453( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0Z53( ) ;
            standaloneModal0Z53( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0Z53( ) ;
            nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_6453( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_colorContainer)) ;
         /* End function gxnrGridlevel_color_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "ICONCATEGORY_" + sGXsfl_51_idx;
         cmbIconCategory.Name = GXCCtl;
         cmbIconCategory.WebTags = "";
         cmbIconCategory.addItem("General", context.GetMessage( "General", ""), 0);
         cmbIconCategory.addItem("Services", context.GetMessage( "Services", ""), 0);
         cmbIconCategory.addItem("Living", context.GetMessage( "Living", ""), 0);
         cmbIconCategory.addItem("Health", context.GetMessage( "Health", ""), 0);
         if ( cmbIconCategory.ItemCount > 0 )
         {
            A443IconCategory = cmbIconCategory.getValidValue(A443IconCategory);
         }
         GXCCtl = "COLORNAME_" + sGXsfl_64_idx;
         cmbColorName.Name = GXCCtl;
         cmbColorName.WebTags = "";
         cmbColorName.addItem("cardBgColor", context.GetMessage( "Card BG Color", ""), 0);
         cmbColorName.addItem("ButtonBgColor", context.GetMessage( "Button Bg Color", ""), 0);
         cmbColorName.addItem("secondaryColor", context.GetMessage( "Secondary Color", ""), 0);
         cmbColorName.addItem("borderColor", context.GetMessage( "Border Color", ""), 0);
         cmbColorName.addItem("backgroundColor", context.GetMessage( "Background Color", ""), 0);
         cmbColorName.addItem("textColor", context.GetMessage( "Text Color", ""), 0);
         cmbColorName.addItem("cardTextColor", context.GetMessage( "Card Text Color", ""), 0);
         cmbColorName.addItem("accentColor", context.GetMessage( "Accent Color", ""), 0);
         cmbColorName.addItem("buttonTextColor", context.GetMessage( "Button Text Color", ""), 0);
         cmbColorName.addItem("primaryColor", context.GetMessage( "Primary Color", ""), 0);
         if ( cmbColorName.ItemCount > 0 )
         {
            A276ColorName = cmbColorName.getValidValue(A276ColorName);
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

      public void Valid_Ctacolorname( )
      {
         n273Trn_ThemeId = false;
         /* Using cursor T000Z43 */
         pr_default.execute(41, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A539CtaColorName, A538CtaColorId});
         if ( (pr_default.getStatus(41) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Cta Color Name", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
         }
         pr_default.close(41);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Iconcategory( )
      {
         n273Trn_ThemeId = false;
         A443IconCategory = cmbIconCategory.CurrentValue;
         /* Using cursor T000Z44 */
         pr_default.execute(42, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A283IconName, A443IconCategory, A282IconId});
         if ( (pr_default.getStatus(42) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Icon Name", "")+","+context.GetMessage( "Icon Category", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
         }
         pr_default.close(42);
         if ( ! ( ( StringUtil.StrCmp(A443IconCategory, "General") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Services") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Living") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Health") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Icon Category", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "ICONCATEGORY");
            AnyError = 1;
            GX_FocusControl = cmbIconCategory_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Colorname( )
      {
         n273Trn_ThemeId = false;
         A276ColorName = cmbColorName.CurrentValue;
         /* Using cursor T000Z45 */
         pr_default.execute(43, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A276ColorName, A275ColorId});
         if ( (pr_default.getStatus(43) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Color Name", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
         }
         pr_default.close(43);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Colorcode( )
      {
         n273Trn_ThemeId = false;
         A276ColorName = cmbColorName.CurrentValue;
         /* Using cursor T000Z46 */
         pr_default.execute(44, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A276ColorName, A277ColorCode, A275ColorId});
         if ( (pr_default.getStatus(44) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Color Name", "")+","+context.GetMessage( "Color Code", "")}), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
         }
         pr_default.close(44);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7Trn_ThemeId","fld":"vTRN_THEMEID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7Trn_ThemeId","fld":"vTRN_THEMEID","hsh":true},{"av":"A576ThemeIsPredefined","fld":"THEMEISPREDEFINED"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120Z2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_TRN_THEMEID","""{"handler":"Valid_Trn_themeid","iparms":[]}""");
         setEventMetadata("VALID_CTACOLORID","""{"handler":"Valid_Ctacolorid","iparms":[]}""");
         setEventMetadata("VALID_CTACOLORNAME","""{"handler":"Valid_Ctacolorname","iparms":[{"av":"A273Trn_ThemeId","fld":"TRN_THEMEID"},{"av":"A539CtaColorName","fld":"CTACOLORNAME"},{"av":"A538CtaColorId","fld":"CTACOLORID"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Ctacolorcode","iparms":[]}""");
         setEventMetadata("VALID_ICONNAME","""{"handler":"Valid_Iconname","iparms":[]}""");
         setEventMetadata("VALID_ICONCATEGORY","""{"handler":"Valid_Iconcategory","iparms":[{"av":"A273Trn_ThemeId","fld":"TRN_THEMEID"},{"av":"A283IconName","fld":"ICONNAME"},{"av":"cmbIconCategory"},{"av":"A443IconCategory","fld":"ICONCATEGORY"},{"av":"A282IconId","fld":"ICONID"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Icontags","iparms":[]}""");
         setEventMetadata("VALID_COLORID","""{"handler":"Valid_Colorid","iparms":[]}""");
         setEventMetadata("VALID_COLORNAME","""{"handler":"Valid_Colorname","iparms":[{"av":"A273Trn_ThemeId","fld":"TRN_THEMEID"},{"av":"cmbColorName"},{"av":"A276ColorName","fld":"COLORNAME"},{"av":"A275ColorId","fld":"COLORID"}]}""");
         setEventMetadata("VALID_COLORCODE","""{"handler":"Valid_Colorcode","iparms":[{"av":"A273Trn_ThemeId","fld":"TRN_THEMEID"},{"av":"cmbColorName"},{"av":"A276ColorName","fld":"COLORNAME"},{"av":"A277ColorCode","fld":"COLORCODE"},{"av":"A275ColorId","fld":"COLORID"}]}""");
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
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(7);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7Trn_ThemeId = Guid.Empty;
         Z273Trn_ThemeId = Guid.Empty;
         Z274Trn_ThemeName = "";
         Z281Trn_ThemeFontFamily = "";
         Z538CtaColorId = Guid.Empty;
         Z539CtaColorName = "";
         Z540CtaColorCode = "";
         Z282IconId = Guid.Empty;
         Z443IconCategory = "";
         Z283IconName = "";
         Z275ColorId = Guid.Empty;
         Z276ColorName = "";
         Z277ColorCode = "";
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
         A273Trn_ThemeId = Guid.Empty;
         A274Trn_ThemeName = "";
         A281Trn_ThemeFontFamily = "";
         lblTextblock1_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_ctacolorContainer = new GXWebGrid( context);
         sMode97 = "";
         A538CtaColorId = Guid.Empty;
         sStyleString = "";
         Gridlevel_iconContainer = new GXWebGrid( context);
         sMode82 = "";
         A282IconId = Guid.Empty;
         Gridlevel_colorContainer = new GXWebGrid( context);
         sMode53 = "";
         A275ColorId = Guid.Empty;
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode51 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A276ColorName = "";
         A277ColorCode = "";
         A283IconName = "";
         A443IconCategory = "";
         A284IconSVG = "";
         A643IconTags = "";
         GXCCtl = "";
         A539CtaColorName = "";
         A540CtaColorCode = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000Z10_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z10_n273Trn_ThemeId = new bool[] {false} ;
         T000Z10_A274Trn_ThemeName = new string[] {""} ;
         T000Z10_A281Trn_ThemeFontFamily = new string[] {""} ;
         T000Z10_A405Trn_ThemeFontSize = new short[1] ;
         T000Z10_A576ThemeIsPredefined = new bool[] {false} ;
         T000Z11_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z11_n273Trn_ThemeId = new bool[] {false} ;
         T000Z9_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z9_n273Trn_ThemeId = new bool[] {false} ;
         T000Z9_A274Trn_ThemeName = new string[] {""} ;
         T000Z9_A281Trn_ThemeFontFamily = new string[] {""} ;
         T000Z9_A405Trn_ThemeFontSize = new short[1] ;
         T000Z9_A576ThemeIsPredefined = new bool[] {false} ;
         T000Z12_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z12_n273Trn_ThemeId = new bool[] {false} ;
         T000Z13_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z13_n273Trn_ThemeId = new bool[] {false} ;
         T000Z8_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z8_n273Trn_ThemeId = new bool[] {false} ;
         T000Z8_A274Trn_ThemeName = new string[] {""} ;
         T000Z8_A281Trn_ThemeFontFamily = new string[] {""} ;
         T000Z8_A405Trn_ThemeFontSize = new short[1] ;
         T000Z8_A576ThemeIsPredefined = new bool[] {false} ;
         T000Z17_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Z17_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z18_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T000Z19_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         T000Z19_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z20_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z20_n273Trn_ThemeId = new bool[] {false} ;
         T000Z21_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z21_n273Trn_ThemeId = new bool[] {false} ;
         T000Z21_A538CtaColorId = new Guid[] {Guid.Empty} ;
         T000Z21_A539CtaColorName = new string[] {""} ;
         T000Z21_A540CtaColorCode = new string[] {""} ;
         T000Z22_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z22_n273Trn_ThemeId = new bool[] {false} ;
         T000Z23_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z23_n273Trn_ThemeId = new bool[] {false} ;
         T000Z23_A538CtaColorId = new Guid[] {Guid.Empty} ;
         T000Z7_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z7_n273Trn_ThemeId = new bool[] {false} ;
         T000Z7_A538CtaColorId = new Guid[] {Guid.Empty} ;
         T000Z7_A539CtaColorName = new string[] {""} ;
         T000Z7_A540CtaColorCode = new string[] {""} ;
         T000Z6_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z6_n273Trn_ThemeId = new bool[] {false} ;
         T000Z6_A538CtaColorId = new Guid[] {Guid.Empty} ;
         T000Z6_A539CtaColorName = new string[] {""} ;
         T000Z6_A540CtaColorCode = new string[] {""} ;
         T000Z27_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z27_n273Trn_ThemeId = new bool[] {false} ;
         T000Z27_A538CtaColorId = new Guid[] {Guid.Empty} ;
         Z643IconTags = "";
         Z284IconSVG = "";
         T000Z28_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z28_n273Trn_ThemeId = new bool[] {false} ;
         T000Z28_A282IconId = new Guid[] {Guid.Empty} ;
         T000Z28_A443IconCategory = new string[] {""} ;
         T000Z28_A283IconName = new string[] {""} ;
         T000Z28_A643IconTags = new string[] {""} ;
         T000Z28_A284IconSVG = new string[] {""} ;
         T000Z29_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z29_n273Trn_ThemeId = new bool[] {false} ;
         T000Z30_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z30_n273Trn_ThemeId = new bool[] {false} ;
         T000Z30_A282IconId = new Guid[] {Guid.Empty} ;
         T000Z5_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z5_n273Trn_ThemeId = new bool[] {false} ;
         T000Z5_A282IconId = new Guid[] {Guid.Empty} ;
         T000Z5_A443IconCategory = new string[] {""} ;
         T000Z5_A283IconName = new string[] {""} ;
         T000Z5_A643IconTags = new string[] {""} ;
         T000Z5_A284IconSVG = new string[] {""} ;
         T000Z4_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z4_n273Trn_ThemeId = new bool[] {false} ;
         T000Z4_A282IconId = new Guid[] {Guid.Empty} ;
         T000Z4_A443IconCategory = new string[] {""} ;
         T000Z4_A283IconName = new string[] {""} ;
         T000Z4_A643IconTags = new string[] {""} ;
         T000Z4_A284IconSVG = new string[] {""} ;
         T000Z34_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z34_n273Trn_ThemeId = new bool[] {false} ;
         T000Z34_A282IconId = new Guid[] {Guid.Empty} ;
         T000Z35_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z35_n273Trn_ThemeId = new bool[] {false} ;
         T000Z35_A275ColorId = new Guid[] {Guid.Empty} ;
         T000Z35_A276ColorName = new string[] {""} ;
         T000Z35_A277ColorCode = new string[] {""} ;
         T000Z36_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z36_n273Trn_ThemeId = new bool[] {false} ;
         T000Z37_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z37_n273Trn_ThemeId = new bool[] {false} ;
         T000Z38_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z38_n273Trn_ThemeId = new bool[] {false} ;
         T000Z38_A275ColorId = new Guid[] {Guid.Empty} ;
         T000Z3_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z3_n273Trn_ThemeId = new bool[] {false} ;
         T000Z3_A275ColorId = new Guid[] {Guid.Empty} ;
         T000Z3_A276ColorName = new string[] {""} ;
         T000Z3_A277ColorCode = new string[] {""} ;
         T000Z2_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z2_n273Trn_ThemeId = new bool[] {false} ;
         T000Z2_A275ColorId = new Guid[] {Guid.Empty} ;
         T000Z2_A276ColorName = new string[] {""} ;
         T000Z2_A277ColorCode = new string[] {""} ;
         T000Z42_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z42_n273Trn_ThemeId = new bool[] {false} ;
         T000Z42_A275ColorId = new Guid[] {Guid.Empty} ;
         Gridlevel_ctacolorRow = new GXWebRow();
         subGridlevel_ctacolor_Linesclass = "";
         ROClassString = "";
         Gridlevel_iconRow = new GXWebRow();
         subGridlevel_icon_Linesclass = "";
         Gridlevel_colorRow = new GXWebRow();
         subGridlevel_color_Linesclass = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         Gridlevel_ctacolorColumn = new GXWebColumn();
         Gridlevel_iconColumn = new GXWebColumn();
         Gridlevel_colorColumn = new GXWebColumn();
         T000Z43_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z43_n273Trn_ThemeId = new bool[] {false} ;
         T000Z44_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z44_n273Trn_ThemeId = new bool[] {false} ;
         T000Z45_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z45_n273Trn_ThemeId = new bool[] {false} ;
         T000Z46_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000Z46_n273Trn_ThemeId = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_theme__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_theme__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_theme__default(),
            new Object[][] {
                new Object[] {
               T000Z2_A273Trn_ThemeId, T000Z2_A275ColorId, T000Z2_A276ColorName, T000Z2_A277ColorCode
               }
               , new Object[] {
               T000Z3_A273Trn_ThemeId, T000Z3_A275ColorId, T000Z3_A276ColorName, T000Z3_A277ColorCode
               }
               , new Object[] {
               T000Z4_A273Trn_ThemeId, T000Z4_A282IconId, T000Z4_A443IconCategory, T000Z4_A283IconName, T000Z4_A643IconTags, T000Z4_A284IconSVG
               }
               , new Object[] {
               T000Z5_A273Trn_ThemeId, T000Z5_A282IconId, T000Z5_A443IconCategory, T000Z5_A283IconName, T000Z5_A643IconTags, T000Z5_A284IconSVG
               }
               , new Object[] {
               T000Z6_A273Trn_ThemeId, T000Z6_A538CtaColorId, T000Z6_A539CtaColorName, T000Z6_A540CtaColorCode
               }
               , new Object[] {
               T000Z7_A273Trn_ThemeId, T000Z7_A538CtaColorId, T000Z7_A539CtaColorName, T000Z7_A540CtaColorCode
               }
               , new Object[] {
               T000Z8_A273Trn_ThemeId, T000Z8_A274Trn_ThemeName, T000Z8_A281Trn_ThemeFontFamily, T000Z8_A405Trn_ThemeFontSize, T000Z8_A576ThemeIsPredefined
               }
               , new Object[] {
               T000Z9_A273Trn_ThemeId, T000Z9_A274Trn_ThemeName, T000Z9_A281Trn_ThemeFontFamily, T000Z9_A405Trn_ThemeFontSize, T000Z9_A576ThemeIsPredefined
               }
               , new Object[] {
               T000Z10_A273Trn_ThemeId, T000Z10_A274Trn_ThemeName, T000Z10_A281Trn_ThemeFontFamily, T000Z10_A405Trn_ThemeFontSize, T000Z10_A576ThemeIsPredefined
               }
               , new Object[] {
               T000Z11_A273Trn_ThemeId
               }
               , new Object[] {
               T000Z12_A273Trn_ThemeId
               }
               , new Object[] {
               T000Z13_A273Trn_ThemeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z17_A29LocationId, T000Z17_A11OrganisationId
               }
               , new Object[] {
               T000Z18_A523AppVersionId
               }
               , new Object[] {
               T000Z19_A100OrganisationSettingid, T000Z19_A11OrganisationId
               }
               , new Object[] {
               T000Z20_A273Trn_ThemeId
               }
               , new Object[] {
               T000Z21_A273Trn_ThemeId, T000Z21_A538CtaColorId, T000Z21_A539CtaColorName, T000Z21_A540CtaColorCode
               }
               , new Object[] {
               T000Z22_A273Trn_ThemeId
               }
               , new Object[] {
               T000Z23_A273Trn_ThemeId, T000Z23_A538CtaColorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z27_A273Trn_ThemeId, T000Z27_A538CtaColorId
               }
               , new Object[] {
               T000Z28_A273Trn_ThemeId, T000Z28_A282IconId, T000Z28_A443IconCategory, T000Z28_A283IconName, T000Z28_A643IconTags, T000Z28_A284IconSVG
               }
               , new Object[] {
               T000Z29_A273Trn_ThemeId
               }
               , new Object[] {
               T000Z30_A273Trn_ThemeId, T000Z30_A282IconId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z34_A273Trn_ThemeId, T000Z34_A282IconId
               }
               , new Object[] {
               T000Z35_A273Trn_ThemeId, T000Z35_A275ColorId, T000Z35_A276ColorName, T000Z35_A277ColorCode
               }
               , new Object[] {
               T000Z36_A273Trn_ThemeId
               }
               , new Object[] {
               T000Z37_A273Trn_ThemeId
               }
               , new Object[] {
               T000Z38_A273Trn_ThemeId, T000Z38_A275ColorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z42_A273Trn_ThemeId, T000Z42_A275ColorId
               }
               , new Object[] {
               T000Z43_A273Trn_ThemeId
               }
               , new Object[] {
               T000Z44_A273Trn_ThemeId
               }
               , new Object[] {
               T000Z45_A273Trn_ThemeId
               }
               , new Object[] {
               T000Z46_A273Trn_ThemeId
               }
            }
         );
         Z275ColorId = Guid.NewGuid( );
         A275ColorId = Guid.NewGuid( );
         Z282IconId = Guid.NewGuid( );
         A282IconId = Guid.NewGuid( );
         Z538CtaColorId = Guid.NewGuid( );
         A538CtaColorId = Guid.NewGuid( );
         Z273Trn_ThemeId = Guid.NewGuid( );
         n273Trn_ThemeId = false;
         A273Trn_ThemeId = Guid.NewGuid( );
         n273Trn_ThemeId = false;
         Z576ThemeIsPredefined = false;
         A576ThemeIsPredefined = false;
         i576ThemeIsPredefined = false;
      }

      private short Z405Trn_ThemeFontSize ;
      private short nRcdDeleted_97 ;
      private short nRcdExists_97 ;
      private short nIsMod_97 ;
      private short nRcdDeleted_82 ;
      private short nRcdExists_82 ;
      private short nIsMod_82 ;
      private short nRcdDeleted_53 ;
      private short nRcdExists_53 ;
      private short nIsMod_53 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short A405Trn_ThemeFontSize ;
      private short nBlankRcdCount97 ;
      private short RcdFound97 ;
      private short nBlankRcdUsr97 ;
      private short nBlankRcdCount82 ;
      private short RcdFound82 ;
      private short nBlankRcdUsr82 ;
      private short nBlankRcdCount53 ;
      private short RcdFound53 ;
      private short nBlankRcdUsr53 ;
      private short RcdFound51 ;
      private short nIsDirty_97 ;
      private short nIsDirty_82 ;
      private short nIsDirty_53 ;
      private short subGridlevel_ctacolor_Backcolorstyle ;
      private short subGridlevel_ctacolor_Backstyle ;
      private short subGridlevel_icon_Backcolorstyle ;
      private short subGridlevel_icon_Backstyle ;
      private short subGridlevel_color_Backcolorstyle ;
      private short subGridlevel_color_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_ctacolor_Allowselection ;
      private short subGridlevel_ctacolor_Allowhovering ;
      private short subGridlevel_ctacolor_Allowcollapsing ;
      private short subGridlevel_ctacolor_Collapsed ;
      private short subGridlevel_icon_Allowselection ;
      private short subGridlevel_icon_Allowhovering ;
      private short subGridlevel_icon_Allowcollapsing ;
      private short subGridlevel_icon_Collapsed ;
      private short subGridlevel_color_Allowselection ;
      private short subGridlevel_color_Allowhovering ;
      private short subGridlevel_color_Allowcollapsing ;
      private short subGridlevel_color_Collapsed ;
      private int nRC_GXsfl_42 ;
      private int nGXsfl_42_idx=1 ;
      private int nRC_GXsfl_51 ;
      private int nGXsfl_51_idx=1 ;
      private int nRC_GXsfl_64 ;
      private int nGXsfl_64_idx=1 ;
      private int trnEnded ;
      private int edtTrn_ThemeId_Enabled ;
      private int edtTrn_ThemeName_Enabled ;
      private int edtTrn_ThemeFontFamily_Enabled ;
      private int edtTrn_ThemeFontSize_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtCtaColorId_Enabled ;
      private int edtCtaColorName_Enabled ;
      private int edtCtaColorCode_Enabled ;
      private int fRowAdded ;
      private int edtIconName_Enabled ;
      private int edtIconSVG_Enabled ;
      private int edtIconTags_Enabled ;
      private int edtColorId_Enabled ;
      private int edtColorCode_Enabled ;
      private int subGridlevel_ctacolor_Backcolor ;
      private int subGridlevel_ctacolor_Allbackcolor ;
      private int subGridlevel_icon_Backcolor ;
      private int subGridlevel_icon_Allbackcolor ;
      private int subGridlevel_color_Backcolor ;
      private int subGridlevel_color_Allbackcolor ;
      private int defedtColorId_Enabled ;
      private int defedtCtaColorId_Enabled ;
      private int idxLst ;
      private int subGridlevel_ctacolor_Selectedindex ;
      private int subGridlevel_ctacolor_Selectioncolor ;
      private int subGridlevel_ctacolor_Hoveringcolor ;
      private int subGridlevel_icon_Selectedindex ;
      private int subGridlevel_icon_Selectioncolor ;
      private int subGridlevel_icon_Hoveringcolor ;
      private int subGridlevel_color_Selectedindex ;
      private int subGridlevel_color_Selectioncolor ;
      private int subGridlevel_color_Hoveringcolor ;
      private long GRIDLEVEL_CTACOLOR_nFirstRecordOnPage ;
      private long GRIDLEVEL_ICON_nFirstRecordOnPage ;
      private long GRIDLEVEL_COLOR_nFirstRecordOnPage ;
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
      private string edtTrn_ThemeId_Internalname ;
      private string sGXsfl_42_idx="0001" ;
      private string sGXsfl_51_idx="0001" ;
      private string sGXsfl_64_idx="0001" ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtTrn_ThemeId_Jsonclick ;
      private string edtTrn_ThemeName_Internalname ;
      private string edtTrn_ThemeName_Jsonclick ;
      private string edtTrn_ThemeFontFamily_Internalname ;
      private string edtTrn_ThemeFontFamily_Jsonclick ;
      private string edtTrn_ThemeFontSize_Internalname ;
      private string edtTrn_ThemeFontSize_Jsonclick ;
      private string divTableleaflevel_ctacolor_Internalname ;
      private string divTableleaflevel_icon_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTableleaflevel_color_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode97 ;
      private string edtCtaColorId_Internalname ;
      private string edtCtaColorName_Internalname ;
      private string edtCtaColorCode_Internalname ;
      private string sStyleString ;
      private string subGridlevel_ctacolor_Internalname ;
      private string sMode82 ;
      private string edtIconName_Internalname ;
      private string cmbIconCategory_Internalname ;
      private string edtIconSVG_Internalname ;
      private string edtIconTags_Internalname ;
      private string subGridlevel_icon_Internalname ;
      private string sMode53 ;
      private string edtColorId_Internalname ;
      private string cmbColorName_Internalname ;
      private string edtColorCode_Internalname ;
      private string subGridlevel_color_Internalname ;
      private string hsh ;
      private string sMode51 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sGXsfl_42_fel_idx="0001" ;
      private string subGridlevel_ctacolor_Class ;
      private string subGridlevel_ctacolor_Linesclass ;
      private string ROClassString ;
      private string edtCtaColorId_Jsonclick ;
      private string edtCtaColorName_Jsonclick ;
      private string edtCtaColorCode_Jsonclick ;
      private string sGXsfl_51_fel_idx="0001" ;
      private string subGridlevel_icon_Class ;
      private string subGridlevel_icon_Linesclass ;
      private string edtIconName_Jsonclick ;
      private string cmbIconCategory_Jsonclick ;
      private string edtIconSVG_Jsonclick ;
      private string edtIconTags_Jsonclick ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGridlevel_color_Class ;
      private string subGridlevel_color_Linesclass ;
      private string edtColorId_Jsonclick ;
      private string cmbColorName_Jsonclick ;
      private string edtColorCode_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string subGridlevel_ctacolor_Header ;
      private string subGridlevel_icon_Header ;
      private string subGridlevel_color_Header ;
      private bool Z576ThemeIsPredefined ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_42_Refreshing=false ;
      private bool bGXsfl_51_Refreshing=false ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool A576ThemeIsPredefined ;
      private bool n273Trn_ThemeId ;
      private bool returnInSub ;
      private bool i576ThemeIsPredefined ;
      private string A284IconSVG ;
      private string A643IconTags ;
      private string Z643IconTags ;
      private string Z284IconSVG ;
      private string Z274Trn_ThemeName ;
      private string Z281Trn_ThemeFontFamily ;
      private string Z539CtaColorName ;
      private string Z540CtaColorCode ;
      private string Z443IconCategory ;
      private string Z283IconName ;
      private string Z276ColorName ;
      private string Z277ColorCode ;
      private string A274Trn_ThemeName ;
      private string A281Trn_ThemeFontFamily ;
      private string A276ColorName ;
      private string A277ColorCode ;
      private string A283IconName ;
      private string A443IconCategory ;
      private string A539CtaColorName ;
      private string A540CtaColorCode ;
      private Guid wcpOAV7Trn_ThemeId ;
      private Guid Z273Trn_ThemeId ;
      private Guid Z538CtaColorId ;
      private Guid Z282IconId ;
      private Guid Z275ColorId ;
      private Guid AV7Trn_ThemeId ;
      private Guid A273Trn_ThemeId ;
      private Guid A538CtaColorId ;
      private Guid A282IconId ;
      private Guid A275ColorId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_ctacolorContainer ;
      private GXWebGrid Gridlevel_iconContainer ;
      private GXWebGrid Gridlevel_colorContainer ;
      private GXWebRow Gridlevel_ctacolorRow ;
      private GXWebRow Gridlevel_iconRow ;
      private GXWebRow Gridlevel_colorRow ;
      private GXWebColumn Gridlevel_ctacolorColumn ;
      private GXWebColumn Gridlevel_iconColumn ;
      private GXWebColumn Gridlevel_colorColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbIconCategory ;
      private GXCombobox cmbColorName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000Z10_A273Trn_ThemeId ;
      private bool[] T000Z10_n273Trn_ThemeId ;
      private string[] T000Z10_A274Trn_ThemeName ;
      private string[] T000Z10_A281Trn_ThemeFontFamily ;
      private short[] T000Z10_A405Trn_ThemeFontSize ;
      private bool[] T000Z10_A576ThemeIsPredefined ;
      private Guid[] T000Z11_A273Trn_ThemeId ;
      private bool[] T000Z11_n273Trn_ThemeId ;
      private Guid[] T000Z9_A273Trn_ThemeId ;
      private bool[] T000Z9_n273Trn_ThemeId ;
      private string[] T000Z9_A274Trn_ThemeName ;
      private string[] T000Z9_A281Trn_ThemeFontFamily ;
      private short[] T000Z9_A405Trn_ThemeFontSize ;
      private bool[] T000Z9_A576ThemeIsPredefined ;
      private Guid[] T000Z12_A273Trn_ThemeId ;
      private bool[] T000Z12_n273Trn_ThemeId ;
      private Guid[] T000Z13_A273Trn_ThemeId ;
      private bool[] T000Z13_n273Trn_ThemeId ;
      private Guid[] T000Z8_A273Trn_ThemeId ;
      private bool[] T000Z8_n273Trn_ThemeId ;
      private string[] T000Z8_A274Trn_ThemeName ;
      private string[] T000Z8_A281Trn_ThemeFontFamily ;
      private short[] T000Z8_A405Trn_ThemeFontSize ;
      private bool[] T000Z8_A576ThemeIsPredefined ;
      private Guid[] T000Z17_A29LocationId ;
      private Guid[] T000Z17_A11OrganisationId ;
      private Guid[] T000Z18_A523AppVersionId ;
      private Guid[] T000Z19_A100OrganisationSettingid ;
      private Guid[] T000Z19_A11OrganisationId ;
      private Guid[] T000Z20_A273Trn_ThemeId ;
      private bool[] T000Z20_n273Trn_ThemeId ;
      private Guid[] T000Z21_A273Trn_ThemeId ;
      private bool[] T000Z21_n273Trn_ThemeId ;
      private Guid[] T000Z21_A538CtaColorId ;
      private string[] T000Z21_A539CtaColorName ;
      private string[] T000Z21_A540CtaColorCode ;
      private Guid[] T000Z22_A273Trn_ThemeId ;
      private bool[] T000Z22_n273Trn_ThemeId ;
      private Guid[] T000Z23_A273Trn_ThemeId ;
      private bool[] T000Z23_n273Trn_ThemeId ;
      private Guid[] T000Z23_A538CtaColorId ;
      private Guid[] T000Z7_A273Trn_ThemeId ;
      private bool[] T000Z7_n273Trn_ThemeId ;
      private Guid[] T000Z7_A538CtaColorId ;
      private string[] T000Z7_A539CtaColorName ;
      private string[] T000Z7_A540CtaColorCode ;
      private Guid[] T000Z6_A273Trn_ThemeId ;
      private bool[] T000Z6_n273Trn_ThemeId ;
      private Guid[] T000Z6_A538CtaColorId ;
      private string[] T000Z6_A539CtaColorName ;
      private string[] T000Z6_A540CtaColorCode ;
      private Guid[] T000Z27_A273Trn_ThemeId ;
      private bool[] T000Z27_n273Trn_ThemeId ;
      private Guid[] T000Z27_A538CtaColorId ;
      private Guid[] T000Z28_A273Trn_ThemeId ;
      private bool[] T000Z28_n273Trn_ThemeId ;
      private Guid[] T000Z28_A282IconId ;
      private string[] T000Z28_A443IconCategory ;
      private string[] T000Z28_A283IconName ;
      private string[] T000Z28_A643IconTags ;
      private string[] T000Z28_A284IconSVG ;
      private Guid[] T000Z29_A273Trn_ThemeId ;
      private bool[] T000Z29_n273Trn_ThemeId ;
      private Guid[] T000Z30_A273Trn_ThemeId ;
      private bool[] T000Z30_n273Trn_ThemeId ;
      private Guid[] T000Z30_A282IconId ;
      private Guid[] T000Z5_A273Trn_ThemeId ;
      private bool[] T000Z5_n273Trn_ThemeId ;
      private Guid[] T000Z5_A282IconId ;
      private string[] T000Z5_A443IconCategory ;
      private string[] T000Z5_A283IconName ;
      private string[] T000Z5_A643IconTags ;
      private string[] T000Z5_A284IconSVG ;
      private Guid[] T000Z4_A273Trn_ThemeId ;
      private bool[] T000Z4_n273Trn_ThemeId ;
      private Guid[] T000Z4_A282IconId ;
      private string[] T000Z4_A443IconCategory ;
      private string[] T000Z4_A283IconName ;
      private string[] T000Z4_A643IconTags ;
      private string[] T000Z4_A284IconSVG ;
      private Guid[] T000Z34_A273Trn_ThemeId ;
      private bool[] T000Z34_n273Trn_ThemeId ;
      private Guid[] T000Z34_A282IconId ;
      private Guid[] T000Z35_A273Trn_ThemeId ;
      private bool[] T000Z35_n273Trn_ThemeId ;
      private Guid[] T000Z35_A275ColorId ;
      private string[] T000Z35_A276ColorName ;
      private string[] T000Z35_A277ColorCode ;
      private Guid[] T000Z36_A273Trn_ThemeId ;
      private bool[] T000Z36_n273Trn_ThemeId ;
      private Guid[] T000Z37_A273Trn_ThemeId ;
      private bool[] T000Z37_n273Trn_ThemeId ;
      private Guid[] T000Z38_A273Trn_ThemeId ;
      private bool[] T000Z38_n273Trn_ThemeId ;
      private Guid[] T000Z38_A275ColorId ;
      private Guid[] T000Z3_A273Trn_ThemeId ;
      private bool[] T000Z3_n273Trn_ThemeId ;
      private Guid[] T000Z3_A275ColorId ;
      private string[] T000Z3_A276ColorName ;
      private string[] T000Z3_A277ColorCode ;
      private Guid[] T000Z2_A273Trn_ThemeId ;
      private bool[] T000Z2_n273Trn_ThemeId ;
      private Guid[] T000Z2_A275ColorId ;
      private string[] T000Z2_A276ColorName ;
      private string[] T000Z2_A277ColorCode ;
      private Guid[] T000Z42_A273Trn_ThemeId ;
      private bool[] T000Z42_n273Trn_ThemeId ;
      private Guid[] T000Z42_A275ColorId ;
      private Guid[] T000Z43_A273Trn_ThemeId ;
      private bool[] T000Z43_n273Trn_ThemeId ;
      private Guid[] T000Z44_A273Trn_ThemeId ;
      private bool[] T000Z44_n273Trn_ThemeId ;
      private Guid[] T000Z45_A273Trn_ThemeId ;
      private bool[] T000Z45_n273Trn_ThemeId ;
      private Guid[] T000Z46_A273Trn_ThemeId ;
      private bool[] T000Z46_n273Trn_ThemeId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_theme__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_theme__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_theme__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[13])
      ,new UpdateCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
      ,new ForEachCursor(def[21])
      ,new UpdateCursor(def[22])
      ,new UpdateCursor(def[23])
      ,new UpdateCursor(def[24])
      ,new ForEachCursor(def[25])
      ,new ForEachCursor(def[26])
      ,new ForEachCursor(def[27])
      ,new ForEachCursor(def[28])
      ,new UpdateCursor(def[29])
      ,new UpdateCursor(def[30])
      ,new UpdateCursor(def[31])
      ,new ForEachCursor(def[32])
      ,new ForEachCursor(def[33])
      ,new ForEachCursor(def[34])
      ,new ForEachCursor(def[35])
      ,new ForEachCursor(def[36])
      ,new UpdateCursor(def[37])
      ,new UpdateCursor(def[38])
      ,new UpdateCursor(def[39])
      ,new ForEachCursor(def[40])
      ,new ForEachCursor(def[41])
      ,new ForEachCursor(def[42])
      ,new ForEachCursor(def[43])
      ,new ForEachCursor(def[44])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000Z2;
       prmT000Z2 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z3;
       prmT000Z3 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z4;
       prmT000Z4 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z5;
       prmT000Z5 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z6;
       prmT000Z6 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z7;
       prmT000Z7 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z8;
       prmT000Z8 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z9;
       prmT000Z9 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z10;
       prmT000Z10 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z11;
       prmT000Z11 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z12;
       prmT000Z12 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z13;
       prmT000Z13 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z14;
       prmT000Z14 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
       new ParDef("Trn_ThemeFontSize",GXType.Int16,4,0) ,
       new ParDef("ThemeIsPredefined",GXType.Boolean,4,0)
       };
       Object[] prmT000Z15;
       prmT000Z15 = new Object[] {
       new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
       new ParDef("Trn_ThemeFontSize",GXType.Int16,4,0) ,
       new ParDef("ThemeIsPredefined",GXType.Boolean,4,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z16;
       prmT000Z16 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z17;
       prmT000Z17 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z18;
       prmT000Z18 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z19;
       prmT000Z19 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z20;
       prmT000Z20 = new Object[] {
       };
       Object[] prmT000Z21;
       prmT000Z21 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z22;
       prmT000Z22 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z23;
       prmT000Z23 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z24;
       prmT000Z24 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorCode",GXType.VarChar,100,0)
       };
       Object[] prmT000Z25;
       prmT000Z25 = new Object[] {
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorCode",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z26;
       prmT000Z26 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z27;
       prmT000Z27 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z28;
       prmT000Z28 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z29;
       prmT000Z29 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z30;
       prmT000Z30 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z31;
       prmT000Z31 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconTags",GXType.LongVarChar,2097152,0) ,
       new ParDef("IconSVG",GXType.LongVarChar,2097152,0)
       };
       Object[] prmT000Z32;
       prmT000Z32 = new Object[] {
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconTags",GXType.LongVarChar,2097152,0) ,
       new ParDef("IconSVG",GXType.LongVarChar,2097152,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z33;
       prmT000Z33 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z34;
       prmT000Z34 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z35;
       prmT000Z35 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z36;
       prmT000Z36 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z37;
       prmT000Z37 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z38;
       prmT000Z38 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z39;
       prmT000Z39 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0)
       };
       Object[] prmT000Z40;
       prmT000Z40 = new Object[] {
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z41;
       prmT000Z41 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z42;
       prmT000Z42 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000Z43;
       prmT000Z43 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z44;
       prmT000Z44 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z45;
       prmT000Z45 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000Z46;
       prmT000Z46 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000Z2", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId  FOR UPDATE OF Trn_ThemeColor NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z3", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z4", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconTags, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId  FOR UPDATE OF Trn_ThemeIcon NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z5", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconTags, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z6", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId  FOR UPDATE OF Trn_ThemeCtaColor NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z7", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z8", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize, ThemeIsPredefined FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId  FOR UPDATE OF Trn_Theme NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z9", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize, ThemeIsPredefined FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z10", "SELECT TM1.Trn_ThemeId, TM1.Trn_ThemeName, TM1.Trn_ThemeFontFamily, TM1.Trn_ThemeFontSize, TM1.ThemeIsPredefined FROM Trn_Theme TM1 WHERE TM1.Trn_ThemeId = :Trn_ThemeId ORDER BY TM1.Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z10,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z11", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z12", "SELECT Trn_ThemeId FROM Trn_Theme WHERE ( Trn_ThemeId > :Trn_ThemeId) ORDER BY Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z12,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000Z13", "SELECT Trn_ThemeId FROM Trn_Theme WHERE ( Trn_ThemeId < :Trn_ThemeId) ORDER BY Trn_ThemeId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z13,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000Z14", "SAVEPOINT gxupdate;INSERT INTO Trn_Theme(Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize, ThemeIsPredefined) VALUES(:Trn_ThemeId, :Trn_ThemeName, :Trn_ThemeFontFamily, :Trn_ThemeFontSize, :ThemeIsPredefined);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Z14)
          ,new CursorDef("T000Z15", "SAVEPOINT gxupdate;UPDATE Trn_Theme SET Trn_ThemeName=:Trn_ThemeName, Trn_ThemeFontFamily=:Trn_ThemeFontFamily, Trn_ThemeFontSize=:Trn_ThemeFontSize, ThemeIsPredefined=:ThemeIsPredefined  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z15)
          ,new CursorDef("T000Z16", "SAVEPOINT gxupdate;DELETE FROM Trn_Theme  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z16)
          ,new CursorDef("T000Z17", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE LocationThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z17,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000Z18", "SELECT AppVersionId FROM Trn_AppVersion WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z18,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000Z19", "SELECT OrganisationSettingid, OrganisationId FROM Trn_OrganisationSetting WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z19,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000Z20", "SELECT Trn_ThemeId FROM Trn_Theme ORDER BY Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z20,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z21", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId and CtaColorId = :CtaColorId ORDER BY Trn_ThemeId, CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z21,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z22", "SELECT Trn_ThemeId FROM Trn_ThemeCtaColor WHERE (Trn_ThemeId = :Trn_ThemeId AND CtaColorName = :CtaColorName) AND (Not ( Trn_ThemeId = :Trn_ThemeId and CtaColorId = :CtaColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z22,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z23", "SELECT Trn_ThemeId, CtaColorId FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z23,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z24", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeCtaColor(Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode) VALUES(:Trn_ThemeId, :CtaColorId, :CtaColorName, :CtaColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Z24)
          ,new CursorDef("T000Z25", "SAVEPOINT gxupdate;UPDATE Trn_ThemeCtaColor SET CtaColorName=:CtaColorName, CtaColorCode=:CtaColorCode  WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z25)
          ,new CursorDef("T000Z26", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeCtaColor  WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z26)
          ,new CursorDef("T000Z27", "SELECT Trn_ThemeId, CtaColorId FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z27,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z28", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconTags, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId and IconId = :IconId ORDER BY Trn_ThemeId, IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z28,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z29", "SELECT Trn_ThemeId FROM Trn_ThemeIcon WHERE (Trn_ThemeId = :Trn_ThemeId AND IconName = :IconName AND IconCategory = :IconCategory) AND (Not ( Trn_ThemeId = :Trn_ThemeId and IconId = :IconId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z29,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z30", "SELECT Trn_ThemeId, IconId FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z30,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z31", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeIcon(Trn_ThemeId, IconId, IconCategory, IconName, IconTags, IconSVG) VALUES(:Trn_ThemeId, :IconId, :IconCategory, :IconName, :IconTags, :IconSVG);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Z31)
          ,new CursorDef("T000Z32", "SAVEPOINT gxupdate;UPDATE Trn_ThemeIcon SET IconCategory=:IconCategory, IconName=:IconName, IconTags=:IconTags, IconSVG=:IconSVG  WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z32)
          ,new CursorDef("T000Z33", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeIcon  WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z33)
          ,new CursorDef("T000Z34", "SELECT Trn_ThemeId, IconId FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z34,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z35", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId ORDER BY Trn_ThemeId, ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z35,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z36", "SELECT Trn_ThemeId FROM Trn_ThemeColor WHERE (Trn_ThemeId = :Trn_ThemeId AND ColorName = :ColorName) AND (Not ( Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z36,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z37", "SELECT Trn_ThemeId FROM Trn_ThemeColor WHERE (Trn_ThemeId = :Trn_ThemeId AND ColorName = :ColorName AND ColorCode = :ColorCode) AND (Not ( Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z37,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z38", "SELECT Trn_ThemeId, ColorId FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z38,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z39", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeColor(Trn_ThemeId, ColorId, ColorName, ColorCode) VALUES(:Trn_ThemeId, :ColorId, :ColorName, :ColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Z39)
          ,new CursorDef("T000Z40", "SAVEPOINT gxupdate;UPDATE Trn_ThemeColor SET ColorName=:ColorName, ColorCode=:ColorCode  WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z40)
          ,new CursorDef("T000Z41", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeColor  WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z41)
          ,new CursorDef("T000Z42", "SELECT Trn_ThemeId, ColorId FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z42,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z43", "SELECT Trn_ThemeId FROM Trn_ThemeCtaColor WHERE (Trn_ThemeId = :Trn_ThemeId AND CtaColorName = :CtaColorName) AND (Not ( Trn_ThemeId = :Trn_ThemeId and CtaColorId = :CtaColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z43,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z44", "SELECT Trn_ThemeId FROM Trn_ThemeIcon WHERE (Trn_ThemeId = :Trn_ThemeId AND IconName = :IconName AND IconCategory = :IconCategory) AND (Not ( Trn_ThemeId = :Trn_ThemeId and IconId = :IconId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z44,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z45", "SELECT Trn_ThemeId FROM Trn_ThemeColor WHERE (Trn_ThemeId = :Trn_ThemeId AND ColorName = :ColorName) AND (Not ( Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z45,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Z46", "SELECT Trn_ThemeId FROM Trn_ThemeColor WHERE (Trn_ThemeId = :Trn_ThemeId AND ColorName = :ColorName AND ColorCode = :ColorCode) AND (Not ( Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z46,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 19 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 20 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 21 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 25 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 26 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
          case 27 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 28 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 32 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 33 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 34 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 35 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 36 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 40 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 41 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 42 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 43 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 44 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
