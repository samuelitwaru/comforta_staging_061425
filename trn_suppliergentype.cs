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
   public class trn_suppliergentype : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_suppliergentype.aspx")), "trn_suppliergentype.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_suppliergentype.aspx")))) ;
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
                  AV7SupplierGenTypeId = StringUtil.StrToGuid( GetPar( "SupplierGenTypeId"));
                  AssignAttri("", false, "AV7SupplierGenTypeId", AV7SupplierGenTypeId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERGENTYPEID", GetSecureSignedToken( "", AV7SupplierGenTypeId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "General Supplier Type", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSupplierGenTypeName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_suppliergentype( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_suppliergentype( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_SupplierGenTypeId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SupplierGenTypeId = aP1_SupplierGenTypeId;
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
            return "trn_suppliergentype_Execute" ;
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_SupplierGenType.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenTypeName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenTypeName_Internalname, context.GetMessage( "Supplier Type Name", ""), "col-sm-6 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenTypeName_Internalname, A254SupplierGenTypeName, StringUtil.RTrim( context.localUtil.Format( A254SupplierGenTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenTypeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenTypeName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierGenType.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGenType.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGenType.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGenType.htm");
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
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenTypeId_Internalname, A253SupplierGenTypeId.ToString(), A253SupplierGenTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenTypeId_Visible, edtSupplierGenTypeId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_SupplierGenType.htm");
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
         E110X2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z253SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( "Z253SupplierGenTypeId"));
               Z254SupplierGenTypeName = cgiGet( "Z254SupplierGenTypeName");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( "vSUPPLIERGENTYPEID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A254SupplierGenTypeName = cgiGet( edtSupplierGenTypeName_Internalname);
               AssignAttri("", false, "A254SupplierGenTypeName", A254SupplierGenTypeName);
               if ( StringUtil.StrCmp(cgiGet( edtSupplierGenTypeId_Internalname), "") == 0 )
               {
                  A253SupplierGenTypeId = Guid.Empty;
                  AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
               }
               else
               {
                  try
                  {
                     A253SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( edtSupplierGenTypeId_Internalname));
                     AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SUPPLIERGENTYPEID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierGenTypeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_SupplierGenType");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A253SupplierGenTypeId != Z253SupplierGenTypeId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_suppliergentype:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A253SupplierGenTypeId = StringUtil.StrToGuid( GetPar( "SupplierGenTypeId"));
                  AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7SupplierGenTypeId) )
                  {
                     A253SupplierGenTypeId = AV7SupplierGenTypeId;
                     AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A253SupplierGenTypeId) && ( Gx_BScreen == 0 ) )
                     {
                        A253SupplierGenTypeId = Guid.NewGuid( );
                        AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
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
                     sMode48 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7SupplierGenTypeId) )
                     {
                        A253SupplierGenTypeId = AV7SupplierGenTypeId;
                        AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A253SupplierGenTypeId) && ( Gx_BScreen == 0 ) )
                        {
                           A253SupplierGenTypeId = Guid.NewGuid( );
                           AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
                        }
                     }
                     Gx_mode = sMode48;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound48 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0X0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SUPPLIERGENTYPEID");
                        AnyError = 1;
                        GX_FocusControl = edtSupplierGenTypeId_Internalname;
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
                           E110X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120X2 ();
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
            E120X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0X48( ) ;
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
            DisableAttributes0X48( ) ;
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

      protected void CONFIRM_0X0( )
      {
         BeforeValidate0X48( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0X48( ) ;
            }
            else
            {
               CheckExtendedTable0X48( ) ;
               CloseExtendedTableCursors0X48( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0X0( )
      {
      }

      protected void E110X2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtSupplierGenTypeId_Visible = 0;
         AssignProp("", false, edtSupplierGenTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Visible), 5, 0), true);
      }

      protected void E120X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_suppliergentypeww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0X48( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z254SupplierGenTypeName = T000X3_A254SupplierGenTypeName[0];
            }
            else
            {
               Z254SupplierGenTypeName = A254SupplierGenTypeName;
            }
         }
         if ( GX_JID == -6 )
         {
            Z253SupplierGenTypeId = A253SupplierGenTypeId;
            Z254SupplierGenTypeName = A254SupplierGenTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7SupplierGenTypeId) )
         {
            edtSupplierGenTypeId_Enabled = 0;
            AssignProp("", false, edtSupplierGenTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierGenTypeId_Enabled = 1;
            AssignProp("", false, edtSupplierGenTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7SupplierGenTypeId) )
         {
            edtSupplierGenTypeId_Enabled = 0;
            AssignProp("", false, edtSupplierGenTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Enabled), 5, 0), true);
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
         if ( ! (Guid.Empty==AV7SupplierGenTypeId) )
         {
            A253SupplierGenTypeId = AV7SupplierGenTypeId;
            AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A253SupplierGenTypeId) && ( Gx_BScreen == 0 ) )
            {
               A253SupplierGenTypeId = Guid.NewGuid( );
               AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0X48( )
      {
         /* Using cursor T000X4 */
         pr_default.execute(2, new Object[] {A253SupplierGenTypeId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound48 = 1;
            A254SupplierGenTypeName = T000X4_A254SupplierGenTypeName[0];
            AssignAttri("", false, "A254SupplierGenTypeName", A254SupplierGenTypeName);
            ZM0X48( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0X48( ) ;
      }

      protected void OnLoadActions0X48( )
      {
      }

      protected void CheckExtendedTable0X48( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A254SupplierGenTypeName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Type Name", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENTYPENAME");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0X48( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0X48( )
      {
         /* Using cursor T000X5 */
         pr_default.execute(3, new Object[] {A253SupplierGenTypeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound48 = 1;
         }
         else
         {
            RcdFound48 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000X3 */
         pr_default.execute(1, new Object[] {A253SupplierGenTypeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0X48( 6) ;
            RcdFound48 = 1;
            A253SupplierGenTypeId = T000X3_A253SupplierGenTypeId[0];
            AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
            A254SupplierGenTypeName = T000X3_A254SupplierGenTypeName[0];
            AssignAttri("", false, "A254SupplierGenTypeName", A254SupplierGenTypeName);
            Z253SupplierGenTypeId = A253SupplierGenTypeId;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0X48( ) ;
            if ( AnyError == 1 )
            {
               RcdFound48 = 0;
               InitializeNonKey0X48( ) ;
            }
            Gx_mode = sMode48;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound48 = 0;
            InitializeNonKey0X48( ) ;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode48;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0X48( ) ;
         if ( RcdFound48 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound48 = 0;
         /* Using cursor T000X6 */
         pr_default.execute(4, new Object[] {A253SupplierGenTypeId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T000X6_A253SupplierGenTypeId[0], A253SupplierGenTypeId, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T000X6_A253SupplierGenTypeId[0], A253SupplierGenTypeId, 0) > 0 ) ) )
            {
               A253SupplierGenTypeId = T000X6_A253SupplierGenTypeId[0];
               AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
               RcdFound48 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound48 = 0;
         /* Using cursor T000X7 */
         pr_default.execute(5, new Object[] {A253SupplierGenTypeId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T000X7_A253SupplierGenTypeId[0], A253SupplierGenTypeId, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T000X7_A253SupplierGenTypeId[0], A253SupplierGenTypeId, 0) < 0 ) ) )
            {
               A253SupplierGenTypeId = T000X7_A253SupplierGenTypeId[0];
               AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
               RcdFound48 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0X48( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSupplierGenTypeName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0X48( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound48 == 1 )
            {
               if ( A253SupplierGenTypeId != Z253SupplierGenTypeId )
               {
                  A253SupplierGenTypeId = Z253SupplierGenTypeId;
                  AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUPPLIERGENTYPEID");
                  AnyError = 1;
                  GX_FocusControl = edtSupplierGenTypeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSupplierGenTypeName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0X48( ) ;
                  GX_FocusControl = edtSupplierGenTypeName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A253SupplierGenTypeId != Z253SupplierGenTypeId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSupplierGenTypeName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0X48( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUPPLIERGENTYPEID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierGenTypeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSupplierGenTypeName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0X48( ) ;
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
         if ( A253SupplierGenTypeId != Z253SupplierGenTypeId )
         {
            A253SupplierGenTypeId = Z253SupplierGenTypeId;
            AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSupplierGenTypeName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0X48( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000X2 */
            pr_default.execute(0, new Object[] {A253SupplierGenTypeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGenType"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z254SupplierGenTypeName, T000X2_A254SupplierGenTypeName[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z254SupplierGenTypeName, T000X2_A254SupplierGenTypeName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergentype:[seudo value changed for attri]"+"SupplierGenTypeName");
                  GXUtil.WriteLogRaw("Old: ",Z254SupplierGenTypeName);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A254SupplierGenTypeName[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierGenType"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0X48( )
      {
         if ( ! IsAuthorized("trn_suppliergentype_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0X48( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X48( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0X48( 0) ;
            CheckOptimisticConcurrency0X48( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X48( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0X48( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X8 */
                     pr_default.execute(6, new Object[] {A253SupplierGenTypeId, A254SupplierGenTypeName});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGenType");
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
               Load0X48( ) ;
            }
            EndLevel0X48( ) ;
         }
         CloseExtendedTableCursors0X48( ) ;
      }

      protected void Update0X48( )
      {
         if ( ! IsAuthorized("trn_suppliergentype_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0X48( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X48( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X48( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X48( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0X48( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X9 */
                     pr_default.execute(7, new Object[] {A254SupplierGenTypeName, A253SupplierGenTypeId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGenType");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGenType"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0X48( ) ;
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
            EndLevel0X48( ) ;
         }
         CloseExtendedTableCursors0X48( ) ;
      }

      protected void DeferredUpdate0X48( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_suppliergentype_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0X48( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X48( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0X48( ) ;
            AfterConfirm0X48( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0X48( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000X10 */
                  pr_default.execute(8, new Object[] {A253SupplierGenTypeId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGenType");
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
         sMode48 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0X48( ) ;
         Gx_mode = sMode48;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0X48( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000X11 */
            pr_default.execute(9, new Object[] {A253SupplierGenTypeId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "General Suppliers", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0X48( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0X48( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_suppliergentype",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0X0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_suppliergentype",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0X48( )
      {
         /* Scan By routine */
         /* Using cursor T000X12 */
         pr_default.execute(10);
         RcdFound48 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound48 = 1;
            A253SupplierGenTypeId = T000X12_A253SupplierGenTypeId[0];
            AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0X48( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound48 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound48 = 1;
            A253SupplierGenTypeId = T000X12_A253SupplierGenTypeId[0];
            AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
         }
      }

      protected void ScanEnd0X48( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0X48( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0X48( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0X48( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0X48( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0X48( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0X48( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0X48( )
      {
         edtSupplierGenTypeName_Enabled = 0;
         AssignProp("", false, edtSupplierGenTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeName_Enabled), 5, 0), true);
         edtSupplierGenTypeId_Enabled = 0;
         AssignProp("", false, edtSupplierGenTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0X48( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0X0( )
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
         GXEncryptionTmp = "trn_suppliergentype.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7SupplierGenTypeId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_suppliergentype.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_SupplierGenType");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_suppliergentype:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z253SupplierGenTypeId", Z253SupplierGenTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "Z254SupplierGenTypeName", Z254SupplierGenTypeName);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vSUPPLIERGENTYPEID", AV7SupplierGenTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERGENTYPEID", GetSecureSignedToken( "", AV7SupplierGenTypeId, context));
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_suppliergentype.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7SupplierGenTypeId.ToString());
         return formatLink("trn_suppliergentype.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_SupplierGenType" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "General Supplier Type", "") ;
      }

      protected void InitializeNonKey0X48( )
      {
         A254SupplierGenTypeName = "";
         AssignAttri("", false, "A254SupplierGenTypeName", A254SupplierGenTypeName);
         Z254SupplierGenTypeName = "";
      }

      protected void InitAll0X48( )
      {
         A253SupplierGenTypeId = Guid.NewGuid( );
         AssignAttri("", false, "A253SupplierGenTypeId", A253SupplierGenTypeId.ToString());
         InitializeNonKey0X48( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145345224", true, true);
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
         context.AddJavascriptSource("trn_suppliergentype.js", "?20256145345225", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSupplierGenTypeName_Internalname = "SUPPLIERGENTYPENAME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtSupplierGenTypeId_Internalname = "SUPPLIERGENTYPEID";
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
         Form.Caption = context.GetMessage( "General Supplier Type", "");
         edtSupplierGenTypeId_Jsonclick = "";
         edtSupplierGenTypeId_Enabled = 1;
         edtSupplierGenTypeId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSupplierGenTypeName_Jsonclick = "";
         edtSupplierGenTypeName_Enabled = 1;
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7SupplierGenTypeId","fld":"vSUPPLIERGENTYPEID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7SupplierGenTypeId","fld":"vSUPPLIERGENTYPEID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120X2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_SUPPLIERGENTYPENAME","""{"handler":"Valid_Suppliergentypename","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENTYPEID","""{"handler":"Valid_Suppliergentypeid","iparms":[]}""");
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
         wcpOAV7SupplierGenTypeId = Guid.Empty;
         Z253SupplierGenTypeId = Guid.Empty;
         Z254SupplierGenTypeName = "";
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
         A254SupplierGenTypeName = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A253SupplierGenTypeId = Guid.Empty;
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode48 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000X4_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T000X4_A254SupplierGenTypeName = new string[] {""} ;
         T000X5_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T000X3_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T000X3_A254SupplierGenTypeName = new string[] {""} ;
         T000X6_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T000X7_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T000X2_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T000X2_A254SupplierGenTypeName = new string[] {""} ;
         T000X11_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T000X12_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergentype__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergentype__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergentype__default(),
            new Object[][] {
                new Object[] {
               T000X2_A253SupplierGenTypeId, T000X2_A254SupplierGenTypeName
               }
               , new Object[] {
               T000X3_A253SupplierGenTypeId, T000X3_A254SupplierGenTypeName
               }
               , new Object[] {
               T000X4_A253SupplierGenTypeId, T000X4_A254SupplierGenTypeName
               }
               , new Object[] {
               T000X5_A253SupplierGenTypeId
               }
               , new Object[] {
               T000X6_A253SupplierGenTypeId
               }
               , new Object[] {
               T000X7_A253SupplierGenTypeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000X11_A42SupplierGenId
               }
               , new Object[] {
               T000X12_A253SupplierGenTypeId
               }
            }
         );
         Z253SupplierGenTypeId = Guid.NewGuid( );
         A253SupplierGenTypeId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound48 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtSupplierGenTypeName_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtSupplierGenTypeId_Visible ;
      private int edtSupplierGenTypeId_Enabled ;
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
      private string edtSupplierGenTypeName_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtSupplierGenTypeName_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSupplierGenTypeId_Internalname ;
      private string edtSupplierGenTypeId_Jsonclick ;
      private string hsh ;
      private string sMode48 ;
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
      private string Z254SupplierGenTypeName ;
      private string A254SupplierGenTypeName ;
      private Guid wcpOAV7SupplierGenTypeId ;
      private Guid Z253SupplierGenTypeId ;
      private Guid AV7SupplierGenTypeId ;
      private Guid A253SupplierGenTypeId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000X4_A253SupplierGenTypeId ;
      private string[] T000X4_A254SupplierGenTypeName ;
      private Guid[] T000X5_A253SupplierGenTypeId ;
      private Guid[] T000X3_A253SupplierGenTypeId ;
      private string[] T000X3_A254SupplierGenTypeName ;
      private Guid[] T000X6_A253SupplierGenTypeId ;
      private Guid[] T000X7_A253SupplierGenTypeId ;
      private Guid[] T000X2_A253SupplierGenTypeId ;
      private string[] T000X2_A254SupplierGenTypeName ;
      private Guid[] T000X11_A42SupplierGenId ;
      private Guid[] T000X12_A253SupplierGenTypeId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_suppliergentype__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_suppliergentype__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_suppliergentype__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[10])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000X2;
       prmT000X2 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X3;
       prmT000X3 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X4;
       prmT000X4 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X5;
       prmT000X5 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X6;
       prmT000X6 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X7;
       prmT000X7 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X8;
       prmT000X8 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenTypeName",GXType.VarChar,100,0)
       };
       Object[] prmT000X9;
       prmT000X9 = new Object[] {
       new ParDef("SupplierGenTypeName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X10;
       prmT000X10 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X11;
       prmT000X11 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000X12;
       prmT000X12 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000X2", "SELECT SupplierGenTypeId, SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId  FOR UPDATE OF Trn_SupplierGenType NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000X2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000X3", "SELECT SupplierGenTypeId, SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000X4", "SELECT TM1.SupplierGenTypeId, TM1.SupplierGenTypeName FROM Trn_SupplierGenType TM1 WHERE TM1.SupplierGenTypeId = :SupplierGenTypeId ORDER BY TM1.SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000X5", "SELECT SupplierGenTypeId FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000X6", "SELECT SupplierGenTypeId FROM Trn_SupplierGenType WHERE ( SupplierGenTypeId > :SupplierGenTypeId) ORDER BY SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000X7", "SELECT SupplierGenTypeId FROM Trn_SupplierGenType WHERE ( SupplierGenTypeId < :SupplierGenTypeId) ORDER BY SupplierGenTypeId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000X8", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierGenType(SupplierGenTypeId, SupplierGenTypeName) VALUES(:SupplierGenTypeId, :SupplierGenTypeName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000X8)
          ,new CursorDef("T000X9", "SAVEPOINT gxupdate;UPDATE Trn_SupplierGenType SET SupplierGenTypeName=:SupplierGenTypeName  WHERE SupplierGenTypeId = :SupplierGenTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000X9)
          ,new CursorDef("T000X10", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierGenType  WHERE SupplierGenTypeId = :SupplierGenTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000X10)
          ,new CursorDef("T000X11", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000X12", "SELECT SupplierGenTypeId FROM Trn_SupplierGenType ORDER BY SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X12,100, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
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
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
