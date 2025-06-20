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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_createdynamicvalidations : GXDataArea
   {
      public wwp_createdynamicvalidations( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_createdynamicvalidations( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormId ,
                           string aP1_WWPDynamicFormMode )
      {
         this.AV7WWPFormId = aP0_WWPFormId;
         this.AV37WWPDynamicFormMode = aP1_WWPDynamicFormMode;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavActiongroup = new GXCombobox();
         cmbavGridactiongroup1 = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "WWPFormId");
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
               gxfirstwebparm = GetFirstPar( "WWPFormId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "WWPFormId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_34 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_34"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_34_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_34_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_34_idx = GetPar( "sGXsfl_34_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV24ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV44WWPFormElementType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementType"), "."), 18, MidpointRounding.ToEven));
         AV53Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV32Validations);
         AV37WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
         AV40WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementDataType"), "."), 18, MidpointRounding.ToEven));
         AV28SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
         AV42WWPFormElementParentId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementParentId"), "."), 18, MidpointRounding.ToEven));
         AV41WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
         AV43WWPFormElementReferenceId = GetPar( "WWPFormElementReferenceId");
         AV7WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV24ManageFiltersExecutionStep, AV44WWPFormElementType, AV53Pgmname, AV15FilterFullText, AV32Validations, AV37WWPDynamicFormMode, AV40WWPFormElementDataType, AV28SessionId, AV42WWPFormElementParentId, AV41WWPFormElementId, AV43WWPFormElementReferenceId, AV7WWPFormId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            return "wwp_createdynamicvalidations_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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

      public override short ExecuteStartEvent( )
      {
         PA232( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START232( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicvalidations.aspx"+UrlEncode(StringUtil.LTrimStr(AV7WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV37WWPDynamicFormMode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_createdynamicvalidations.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV44WWPFormElementType), "9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTDATATYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormElementDataType), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSESSIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28SessionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTPARENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTPARENTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV42WWPFormElementParentId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV41WWPFormElementId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTREFERENCEID", AV43WWPFormElementReferenceId);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTREFERENCEID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43WWPFormElementReferenceId, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV37WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV37WWPDynamicFormMode, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Validations", AV32Validations);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Validations", AV32Validations);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_34", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_34), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV23ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV23ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV44WWPFormElementType), "9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vVALIDATIONS", AV32Validations);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vVALIDATIONS", AV32Validations);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV18GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV18GridState);
         }
         GxWebStd.gx_hidden_field( context, "vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV37WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV37WWPDynamicFormMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTDATATYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormElementDataType), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSESSIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28SessionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vVALIDATIONJSON", AV31ValidationJson);
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTPARENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTPARENTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV42WWPFormElementParentId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV41WWPFormElementId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTREFERENCEID", AV43WWPFormElementReferenceId);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTREFERENCEID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43WWPFormElementReferenceId, "")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTVALIDATIONINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13CurrentValidationIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV10CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vWWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "WWPFORMINSTANTIATED", A234WWPFormInstantiated);
         GxWebStd.gx_hidden_field( context, "WWPFORMDATE", context.localUtil.TToC( A231WWPFormDate, 10, 8, 0, 0, "/", ":", " "));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPFORM", AV38WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPFORM", AV38WWPForm);
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "UPDATEVALIDATION_MODAL_Width", StringUtil.RTrim( Updatevalidation_modal_Width));
         GxWebStd.gx_hidden_field( context, "UPDATEVALIDATION_MODAL_Title", StringUtil.RTrim( Updatevalidation_modal_Title));
         GxWebStd.gx_hidden_field( context, "UPDATEVALIDATION_MODAL_Confirmtype", StringUtil.RTrim( Updatevalidation_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "UPDATEVALIDATION_MODAL_Bodytype", StringUtil.RTrim( Updatevalidation_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "ADDVALIDATION_MODAL_Width", StringUtil.RTrim( Addvalidation_modal_Width));
         GxWebStd.gx_hidden_field( context, "ADDVALIDATION_MODAL_Title", StringUtil.RTrim( Addvalidation_modal_Title));
         GxWebStd.gx_hidden_field( context, "ADDVALIDATION_MODAL_Confirmtype", StringUtil.RTrim( Addvalidation_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "ADDVALIDATION_MODAL_Bodytype", StringUtil.RTrim( Addvalidation_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "UPDATEVALIDATION_MODAL_Result", StringUtil.RTrim( Updatevalidation_modal_Result));
         GxWebStd.gx_hidden_field( context, "ADDVALIDATION_MODAL_Result", StringUtil.RTrim( Addvalidation_modal_Result));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UPDATEVALIDATION_MODAL_Result", StringUtil.RTrim( Updatevalidation_modal_Result));
         GxWebStd.gx_hidden_field( context, "ADDVALIDATION_MODAL_Result", StringUtil.RTrim( Addvalidation_modal_Result));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE232( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT232( ) ;
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
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicvalidations.aspx"+UrlEncode(StringUtil.LTrimStr(AV7WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV37WWPDynamicFormMode));
         return formatLink("workwithplus.dynamicforms.wwp_createdynamicvalidations.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WorkWithPlus.DynamicForms.WWP_CreateDynamicValidations" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Element settings", "") ;
      }

      protected void WB230( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableWithSelectableGrid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainWithShadow", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "ButtonGray";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaddvalidation_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", context.GetMessage( "WWP_DF_AddValidation", ""), bttBtnaddvalidation_Jsonclick, 7, context.GetMessage( "WWP_DF_AddValidation", ""), "", StyleString, ClassString, bttBtnaddvalidation_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11231_client"+"'", TempTags, "", 2, "HLP_WorkWithPlus/DynamicForms/WWP_CreateDynamicValidations.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_19_232( true) ;
         }
         else
         {
            wb_table1_19_232( false) ;
         }
         return  ;
      }

      protected void wb_table1_19_232e( bool wbgen )
      {
         if ( wbgen )
         {
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid CellMarginTop GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl34( ) ;
         }
         if ( wbEnd == 34 )
         {
            wbEnd = 0;
            nRC_GXsfl_34 = (int)(nGXsfl_34_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               AV50GXV1 = nGXsfl_34_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_CreateDynamicValidations.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_CreateDynamicValidations.htm");
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
            wb_table2_49_232( true) ;
         }
         else
         {
            wb_table2_49_232( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_232e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_54_232( true) ;
         }
         else
         {
            wb_table3_54_232( false) ;
         }
         return  ;
      }

      protected void wb_table3_54_232e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0061"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0061"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_34_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0061"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 34 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  AV50GXV1 = nGXsfl_34_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START232( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Element settings", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP230( ) ;
      }

      protected void WS232( )
      {
         START232( ) ;
         EVT232( ) ;
      }

      protected void EVT232( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E12232 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "UPDATEVALIDATION_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Updatevalidation_modal.Close */
                              E13232 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "UPDATEVALIDATION_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Updatevalidation_modal.Onloadcomponent */
                              E14232 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ADDVALIDATION_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Addvalidation_modal.Close */
                              E15232 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ADDVALIDATION_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Addvalidation_modal.Onloadcomponent */
                              E16232 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E17232 ();
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) )
                           {
                              nGXsfl_34_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
                              SubsflControlProps_342( ) ;
                              AV50GXV1 = (int)(nGXsfl_34_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV32Validations.Count >= AV50GXV1 ) && ( AV50GXV1 > 0 ) )
                              {
                                 AV32Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV32Validations.Item(AV50GXV1));
                                 cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                                 cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                                 AV49ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV49ActionGroup), 4, 0));
                                 cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                                 cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                                 AV17GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV17GridActionGroup1), 4, 0));
                                 AV33Validations__MessageWithTags = cgiGet( edtavValidations__messagewithtags_Internalname);
                                 AssignAttri("", false, edtavValidations__messagewithtags_Internalname, AV33Validations__MessageWithTags);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18232 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E19232 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E20232 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E21232 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 61 )
                        {
                           OldWwpaux_wc = cgiGet( "W0061");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0061", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE232( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA232( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_createdynamicvalidations.aspx")), "workwithplus.dynamicforms.wwp_createdynamicvalidations.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_createdynamicvalidations.aspx")))) ;
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
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "WWPFormId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV7WWPFormId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV7WWPFormId", StringUtil.LTrimStr( (decimal)(AV7WWPFormId), 4, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7WWPFormId), "ZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV37WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                        AssignAttri("", false, "AV37WWPDynamicFormMode", AV37WWPDynamicFormMode);
                        GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV37WWPDynamicFormMode, "")), context));
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_342( ) ;
         while ( nGXsfl_34_idx <= nRC_GXsfl_34 )
         {
            sendrow_342( ) ;
            nGXsfl_34_idx = ((subGrid_Islastpage==1)&&(nGXsfl_34_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV24ManageFiltersExecutionStep ,
                                       short AV44WWPFormElementType ,
                                       string AV53Pgmname ,
                                       string AV15FilterFullText ,
                                       GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV32Validations ,
                                       string AV37WWPDynamicFormMode ,
                                       short AV40WWPFormElementDataType ,
                                       short AV28SessionId ,
                                       short AV42WWPFormElementParentId ,
                                       short AV41WWPFormElementId ,
                                       string AV43WWPFormElementReferenceId ,
                                       short AV7WWPFormId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF232( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF232( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV53Pgmname = "WorkWithPlus.DynamicForms.WWP_CreateDynamicValidations";
         edtavValidations__messagewithtags_Enabled = 0;
         edtavValidations__message_Enabled = 0;
      }

      protected void RF232( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 34;
         /* Execute user event: Refresh */
         E19232 ();
         nGXsfl_34_idx = 1;
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_342( ) ;
         bGXsfl_34_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWithSelection WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_342( ) ;
            /* Execute user event: Grid.Load */
            E20232 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_34_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E20232 ();
            }
            wbEnd = 34;
            WB230( ) ;
         }
         bGXsfl_34_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes232( )
      {
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV44WWPFormElementType), "9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTDATATYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormElementDataType), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSESSIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28SessionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTPARENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTPARENTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV42WWPFormElementParentId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV41WWPFormElementId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMELEMENTREFERENCEID", AV43WWPFormElementReferenceId);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTREFERENCEID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43WWPFormElementReferenceId, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return AV32Validations.Count ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV24ManageFiltersExecutionStep, AV44WWPFormElementType, AV53Pgmname, AV15FilterFullText, AV32Validations, AV37WWPDynamicFormMode, AV40WWPFormElementDataType, AV28SessionId, AV42WWPFormElementParentId, AV41WWPFormElementId, AV43WWPFormElementReferenceId, AV7WWPFormId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV24ManageFiltersExecutionStep, AV44WWPFormElementType, AV53Pgmname, AV15FilterFullText, AV32Validations, AV37WWPDynamicFormMode, AV40WWPFormElementDataType, AV28SessionId, AV42WWPFormElementParentId, AV41WWPFormElementId, AV43WWPFormElementReferenceId, AV7WWPFormId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV24ManageFiltersExecutionStep, AV44WWPFormElementType, AV53Pgmname, AV15FilterFullText, AV32Validations, AV37WWPDynamicFormMode, AV40WWPFormElementDataType, AV28SessionId, AV42WWPFormElementParentId, AV41WWPFormElementId, AV43WWPFormElementReferenceId, AV7WWPFormId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV24ManageFiltersExecutionStep, AV44WWPFormElementType, AV53Pgmname, AV15FilterFullText, AV32Validations, AV37WWPDynamicFormMode, AV40WWPFormElementDataType, AV28SessionId, AV42WWPFormElementParentId, AV41WWPFormElementId, AV43WWPFormElementReferenceId, AV7WWPFormId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV24ManageFiltersExecutionStep, AV44WWPFormElementType, AV53Pgmname, AV15FilterFullText, AV32Validations, AV37WWPDynamicFormMode, AV40WWPFormElementDataType, AV28SessionId, AV42WWPFormElementParentId, AV41WWPFormElementId, AV43WWPFormElementReferenceId, AV7WWPFormId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV53Pgmname = "WorkWithPlus.DynamicForms.WWP_CreateDynamicValidations";
         edtavValidations__messagewithtags_Enabled = 0;
         edtavValidations__message_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP230( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18232 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Validations"), AV32Validations);
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV23ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vVALIDATIONS"), AV32Validations);
            /* Read saved values. */
            nRC_GXsfl_34 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_34"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Updatevalidation_modal_Width = cgiGet( "UPDATEVALIDATION_MODAL_Width");
            Updatevalidation_modal_Title = cgiGet( "UPDATEVALIDATION_MODAL_Title");
            Updatevalidation_modal_Confirmtype = cgiGet( "UPDATEVALIDATION_MODAL_Confirmtype");
            Updatevalidation_modal_Bodytype = cgiGet( "UPDATEVALIDATION_MODAL_Bodytype");
            Addvalidation_modal_Width = cgiGet( "ADDVALIDATION_MODAL_Width");
            Addvalidation_modal_Title = cgiGet( "ADDVALIDATION_MODAL_Title");
            Addvalidation_modal_Confirmtype = cgiGet( "ADDVALIDATION_MODAL_Confirmtype");
            Addvalidation_modal_Bodytype = cgiGet( "ADDVALIDATION_MODAL_Bodytype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Updatevalidation_modal_Result = cgiGet( "UPDATEVALIDATION_MODAL_Result");
            Addvalidation_modal_Result = cgiGet( "ADDVALIDATION_MODAL_Result");
            nRC_GXsfl_34 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_34"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_34_fel_idx = 0;
            while ( nGXsfl_34_fel_idx < nRC_GXsfl_34 )
            {
               nGXsfl_34_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_34_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_fel_idx+1);
               sGXsfl_34_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_342( ) ;
               AV50GXV1 = (int)(nGXsfl_34_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV32Validations.Count >= AV50GXV1 ) && ( AV50GXV1 > 0 ) )
               {
                  AV32Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV32Validations.Item(AV50GXV1));
                  cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                  cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                  AV49ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                  cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                  cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                  AV17GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                  AV33Validations__MessageWithTags = cgiGet( edtavValidations__messagewithtags_Internalname);
               }
            }
            if ( nGXsfl_34_fel_idx == 0 )
            {
               nGXsfl_34_idx = 1;
               sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
               SubsflControlProps_342( ) ;
            }
            nGXsfl_34_fel_idx = 1;
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            /* Read subfile selected row values. */
            nGXsfl_34_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
            AV50GXV1 = (int)(nGXsfl_34_idx+GRID_nFirstRecordOnPage);
            if ( nGXsfl_34_idx > 0 )
            {
               AV50GXV1 = (int)(nGXsfl_34_idx+GRID_nFirstRecordOnPage);
               if ( ( AV32Validations.Count >= AV50GXV1 ) && ( AV50GXV1 > 0 ) )
               {
                  AV32Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV32Validations.Item(AV50GXV1));
                  cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                  cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                  AV49ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV49ActionGroup), 4, 0));
                  cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                  cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                  AV17GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV17GridActionGroup1), 4, 0));
                  AV33Validations__MessageWithTags = cgiGet( edtavValidations__messagewithtags_Internalname);
                  AssignAttri("", false, edtavValidations__messagewithtags_Internalname, AV33Validations__MessageWithTags);
               }
               if ( ( AV50GXV1 > 0 ) && ( AV32Validations.Count >= AV50GXV1 ) )
               {
                  AV32Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV32Validations.Item(AV50GXV1));
               }
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E18232 ();
         if (returnInSub) return;
      }

      protected void E18232( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV5HTTPRequest.Method, "GET") == 0 )
         {
            AV28SessionId = (short)(NumberUtil.Random( )*10000);
            AssignAttri("", false, "AV28SessionId", StringUtil.LTrimStr( (decimal)(AV28SessionId), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vSESSIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28SessionId), "ZZZ9"), context));
            /* Using cursor H00232 */
            pr_default.execute(0, new Object[] {AV7WWPFormId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A206WWPFormId = H00232_A206WWPFormId[0];
               A207WWPFormVersionNumber = H00232_A207WWPFormVersionNumber[0];
               AV8WWPFormVersionNumber = A207WWPFormVersionNumber;
               AssignAttri("", false, "AV8WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV8WWPFormVersionNumber), 4, 0));
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( (0==AV8WWPFormVersionNumber) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_RecordNotFound", ""));
               bttBtnenter_Visible = 0;
               AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
            }
            else
            {
               AV38WWPForm.Load(AV7WWPFormId, AV8WWPFormVersionNumber);
               AV38WWPForm.gxTpr_Element.Sort("WWPFormElementOrderIndex");
               if ( ( StringUtil.StrCmp(AV37WWPDynamicFormMode, "UPD") == 0 ) || ( StringUtil.StrCmp(AV37WWPDynamicFormMode, "DLT") == 0 ) )
               {
                  bttBtnenter_Caption = ((StringUtil.StrCmp(AV37WWPDynamicFormMode, "UPD")==0) ? context.GetMessage( "GX_BtnEnter", "") : context.GetMessage( "GX_BtnDelete", ""));
                  AssignProp("", false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
               }
               else
               {
                  bttBtnenter_Visible = 0;
                  AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
               }
            }
            Form.Caption = StringUtil.Format( context.GetMessage( "Dynamic Validations for %1", ""), AV38WWPForm.gxTpr_Wwpformreferencename, "", "", "", "", "", "", "", "");
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveformdefinition(context ).execute(  AV28SessionId,  AV38WWPForm) ;
            AV32Validations.FromJSonString(AV38WWPForm.gxTpr_Wwpformvalidations, null);
            gx_BV34 = true;
            AV44WWPFormElementType = 2;
            AssignAttri("", false, "AV44WWPFormElementType", StringUtil.Str( (decimal)(AV44WWPFormElementType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMELEMENTTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV44WWPFormElementType), "9"), context));
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV5HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         Form.Caption = context.GetMessage( "Element settings", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E19232( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV36WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         if ( AV24ManageFiltersExecutionStep == 1 )
         {
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV24ManageFiltersExecutionStep == 2 )
         {
            AV24ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23ManageFiltersData", AV23ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18GridState", AV18GridState);
      }

      private void E20232( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV32Validations.Count )
         {
            AV32Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV32Validations.Item(AV50GXV1));
            AV21IsFirstValidation = (bool)(((AV32Validations.IndexOf(((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV32Validations.CurrentItem)))==1)));
            AV22IsLastValidation = (bool)(((AV32Validations.IndexOf(((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV32Validations.CurrentItem)))==AV32Validations.Count)));
            cmbavActiongroup.removeAllItems();
            cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
            cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            cmbavGridactiongroup1.removeAllItems();
            cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
            cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fas fa-pencil", "", "", "", "", "", "", ""), 0);
            cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "far fa-trash-can", "", "", "", "", "", "", ""), 0);
            if ( ! AV21IsFirstValidation )
            {
               cmbavGridactiongroup1.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "WWP_DF_MoveUp", ""), "fas fa-arrow-up", "", "", "", "", "", "", ""), 0);
            }
            if ( ! AV22IsLastValidation )
            {
               cmbavGridactiongroup1.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "WWP_DF_MoveDown", ""), "fas fa-arrow-down", "", "", "", "", "", "", ""), 0);
            }
            GXt_char1 = AV33Validations__MessageWithTags;
            new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV32Validations.CurrentItem)).gxTpr_Message, out  GXt_char1) ;
            AV33Validations__MessageWithTags = GXt_char1;
            AssignAttri("", false, edtavValidations__messagewithtags_Internalname, AV33Validations__MessageWithTags);
            if ( 1 == 1 )
            {
               AV33Validations__MessageWithTags = StringUtil.Format( "<i class='fa fa-check-circle FontColorIconSuccess	 TagBeforeText BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "ValidationTooltip", ""), "", "", "", "", "", "", "", "") + AV33Validations__MessageWithTags;
               AssignAttri("", false, edtavValidations__messagewithtags_Internalname, AV33Validations__MessageWithTags);
            }
            AV29Text = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV32Validations.CurrentItem)).gxTpr_Condition.gxTpr_Expression;
            AV33Validations__MessageWithTags = StringUtil.StringReplace( AV33Validations__MessageWithTags, "ValidationTooltip", StringUtil.StringReplace( AV29Text, "'", "\""));
            AssignAttri("", false, edtavValidations__messagewithtags_Internalname, AV33Validations__MessageWithTags);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 34;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_342( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_34_Refreshing )
            {
               DoAjaxLoad(34, GridRow);
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49ActionGroup), 4, 0));
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17GridActionGroup1), 4, 0));
      }

      protected void E12232( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S162 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S142 ();
            if (returnInSub) return;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WorkWithPlus.DynamicForms.WWP_CreateDynamicValidationsFilters")) + "," + UrlEncode(StringUtil.RTrim(AV53Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WorkWithPlus.DynamicForms.WWP_CreateDynamicValidationsFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char1 = AV25ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WorkWithPlus.DynamicForms.WWP_CreateDynamicValidationsFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char1) ;
            AV25ManageFiltersXml = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if (returnInSub) return;
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV53Pgmname+"GridState",  AV25ManageFiltersXml) ;
               AV18GridState.FromXml(AV25ManageFiltersXml, null, "", "");
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18GridState", AV18GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23ManageFiltersData", AV23ManageFiltersData);
      }

      protected void E21232( )
      {
         AV50GXV1 = (int)(nGXsfl_34_idx+GRID_nFirstRecordOnPage);
         if ( ( AV50GXV1 > 0 ) && ( AV32Validations.Count >= AV50GXV1 ) )
         {
            AV32Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV32Validations.Item(AV50GXV1));
         }
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV17GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO UPDATEVALIDATION' */
            S212 ();
            if (returnInSub) return;
         }
         else if ( AV17GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO DELETEVALIDATION' */
            S222 ();
            if (returnInSub) return;
         }
         else if ( AV17GridActionGroup1 == 3 )
         {
            /* Execute user subroutine: 'DO MOVEUP' */
            S232 ();
            if (returnInSub) return;
         }
         else if ( AV17GridActionGroup1 == 4 )
         {
            /* Execute user subroutine: 'DO MOVEDOWN' */
            S242 ();
            if (returnInSub) return;
         }
         AV17GridActionGroup1 = 0;
         AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV17GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32Validations", AV32Validations);
         nGXsfl_34_bak_idx = nGXsfl_34_idx;
         gxgrGrid_refresh( subGrid_Rows, AV24ManageFiltersExecutionStep, AV44WWPFormElementType, AV53Pgmname, AV15FilterFullText, AV32Validations, AV37WWPDynamicFormMode, AV40WWPFormElementDataType, AV28SessionId, AV42WWPFormElementParentId, AV41WWPFormElementId, AV43WWPFormElementReferenceId, AV7WWPFormId) ;
         nGXsfl_34_idx = nGXsfl_34_bak_idx;
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_342( ) ;
      }

      protected void E14232( )
      {
         /* Updatevalidation_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_EditValidation")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_editvalidation", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_EditValidation";
            WebComp_Wwpaux_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_EditValidation";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0061",(string)"",(string)AV37WWPDynamicFormMode,(short)0,(short)0,(string)"",(short)AV40WWPFormElementDataType,(short)AV28SessionId,(string)AV31ValidationJson});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0061"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E16232( )
      {
         /* Addvalidation_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_EditValidation")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_editvalidation", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_EditValidation";
            WebComp_Wwpaux_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_EditValidation";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0061",(string)"",(string)AV37WWPDynamicFormMode,(short)AV42WWPFormElementParentId,(short)AV41WWPFormElementId,(string)AV43WWPFormElementReferenceId,(short)AV40WWPFormElementDataType,(short)AV28SessionId,(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0061"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( AV44WWPFormElementType != 3 ) ) )
         {
            bttBtnaddvalidation_Visible = 0;
            AssignProp("", false, bttBtnaddvalidation_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnaddvalidation_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item2 = AV23ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WorkWithPlus.DynamicForms.WWP_CreateDynamicValidationsFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item2) ;
         AV23ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item2;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
      }

      protected void S182( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
      }

      protected void S192( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
      }

      protected void S202( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
      }

      protected void S212( )
      {
         /* 'DO UPDATEVALIDATION' Routine */
         returnInSub = false;
         AV13CurrentValidationIndex = (short)(AV32Validations.IndexOf(((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV32Validations.CurrentItem))));
         AssignAttri("", false, "AV13CurrentValidationIndex", StringUtil.LTrimStr( (decimal)(AV13CurrentValidationIndex), 4, 0));
         AV31ValidationJson = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV32Validations.CurrentItem)).ToJSonString(false, true);
         AssignAttri("", false, "AV31ValidationJson", AV31ValidationJson);
         this.executeUsercontrolMethod("", false, "UPDATEVALIDATION_MODALContainer", "Confirm", "", new Object[] {});
      }

      protected void S222( )
      {
         /* 'DO DELETEVALIDATION' Routine */
         returnInSub = false;
         AV32Validations.RemoveItem(AV32Validations.IndexOf(((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV32Validations.CurrentItem))));
         gx_BV34 = true;
      }

      protected void S232( )
      {
         /* 'DO MOVEUP' Routine */
         returnInSub = false;
         AV12CurrentValidation = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV32Validations.CurrentItem));
         AV20Index = (short)(AV32Validations.IndexOf(((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV32Validations.CurrentItem))));
         AV32Validations.RemoveItem(AV20Index);
         gx_BV34 = true;
         AV32Validations.Add(AV12CurrentValidation, AV20Index-1);
         gx_BV34 = true;
      }

      protected void S242( )
      {
         /* 'DO MOVEDOWN' Routine */
         returnInSub = false;
         AV12CurrentValidation = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV32Validations.CurrentItem));
         AV20Index = (short)(AV32Validations.IndexOf(((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV32Validations.CurrentItem))));
         AV32Validations.RemoveItem(AV20Index);
         gx_BV34 = true;
         AV32Validations.Add(AV12CurrentValidation, AV20Index+1);
         gx_BV34 = true;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get(AV53Pgmname+"GridState"), "") == 0 )
         {
            AV18GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV53Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV18GridState.FromXml(AV27Session.Get(AV53Pgmname+"GridState"), null, "", "");
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV18GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV18GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV18GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV54GXV3 = 1;
         while ( AV54GXV3 <= AV18GridState.gxTpr_Filtervalues.Count )
         {
            AV19GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV18GridState.gxTpr_Filtervalues.Item(AV54GXV3));
            if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            AV54GXV3 = (int)(AV54GXV3+1);
         }
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV18GridState.FromXml(AV27Session.Get(AV53Pgmname+"GridState"), null, "", "");
         AV18GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV18GridState,  "FILTERFULLTEXT",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         AV18GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV18GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV53Pgmname+"GridState",  AV18GridState.ToXml(false, true, "", "")) ;
      }

      protected void E13232( )
      {
         AV50GXV1 = (int)(nGXsfl_34_idx+GRID_nFirstRecordOnPage);
         if ( ( AV50GXV1 > 0 ) && ( AV32Validations.Count >= AV50GXV1 ) )
         {
            AV32Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV32Validations.Item(AV50GXV1));
         }
         /* Updatevalidation_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Updatevalidation_modal_Result, "CANCEL") != 0 )
         {
            AV30Validation = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation(context);
            AV30Validation.FromJSonString(Updatevalidation_modal_Result, null);
            AV32Validations.RemoveItem(AV13CurrentValidationIndex);
            gx_BV34 = true;
            AV32Validations.Add(AV30Validation, AV13CurrentValidationIndex);
            gx_BV34 = true;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32Validations", AV32Validations);
         nGXsfl_34_bak_idx = nGXsfl_34_idx;
         gxgrGrid_refresh( subGrid_Rows, AV24ManageFiltersExecutionStep, AV44WWPFormElementType, AV53Pgmname, AV15FilterFullText, AV32Validations, AV37WWPDynamicFormMode, AV40WWPFormElementDataType, AV28SessionId, AV42WWPFormElementParentId, AV41WWPFormElementId, AV43WWPFormElementReferenceId, AV7WWPFormId) ;
         nGXsfl_34_idx = nGXsfl_34_bak_idx;
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_342( ) ;
      }

      protected void E15232( )
      {
         AV50GXV1 = (int)(nGXsfl_34_idx+GRID_nFirstRecordOnPage);
         if ( ( AV50GXV1 > 0 ) && ( AV32Validations.Count >= AV50GXV1 ) )
         {
            AV32Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV32Validations.Item(AV50GXV1));
         }
         /* Addvalidation_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Addvalidation_modal_Result, "CANCEL") != 0 )
         {
            AV30Validation = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation(context);
            AV30Validation.FromJSonString(Addvalidation_modal_Result, null);
            AV32Validations.Add(AV30Validation, 0);
            gx_BV34 = true;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32Validations", AV32Validations);
         nGXsfl_34_bak_idx = nGXsfl_34_idx;
         gxgrGrid_refresh( subGrid_Rows, AV24ManageFiltersExecutionStep, AV44WWPFormElementType, AV53Pgmname, AV15FilterFullText, AV32Validations, AV37WWPDynamicFormMode, AV40WWPFormElementDataType, AV28SessionId, AV42WWPFormElementParentId, AV41WWPFormElementId, AV43WWPFormElementReferenceId, AV7WWPFormId) ;
         nGXsfl_34_idx = nGXsfl_34_bak_idx;
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_342( ) ;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E17232 ();
         if (returnInSub) return;
      }

      protected void E17232( )
      {
         AV50GXV1 = (int)(nGXsfl_34_idx+GRID_nFirstRecordOnPage);
         if ( ( AV50GXV1 > 0 ) && ( AV32Validations.Count >= AV50GXV1 ) )
         {
            AV32Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV32Validations.Item(AV50GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDATE' */
         S252 ();
         if (returnInSub) return;
         if ( AV10CheckRequiredFieldsResult && ( ( StringUtil.StrCmp(AV37WWPDynamicFormMode, "INS") == 0 ) || ( StringUtil.StrCmp(AV37WWPDynamicFormMode, "UPD") == 0 ) ) )
         {
            if ( ( StringUtil.StrCmp(AV37WWPDynamicFormMode, "DSP") != 0 ) && ! (0==AV8WWPFormVersionNumber) )
            {
               /* Using cursor H00233 */
               pr_default.execute(1, new Object[] {AV7WWPFormId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A206WWPFormId = H00233_A206WWPFormId[0];
                  A234WWPFormInstantiated = H00233_A234WWPFormInstantiated[0];
                  A231WWPFormDate = H00233_A231WWPFormDate[0];
                  A207WWPFormVersionNumber = H00233_A207WWPFormVersionNumber[0];
                  AV8WWPFormVersionNumber = A207WWPFormVersionNumber;
                  AssignAttri("", false, "AV8WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV8WWPFormVersionNumber), 4, 0));
                  AV16FormWasInstantiated = A234WWPFormInstantiated;
                  AV39WWPFormDate = A231WWPFormDate;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               if ( ( AV8WWPFormVersionNumber > AV38WWPForm.gxTpr_Wwpformversionnumber ) || ( AV39WWPFormDate != AV38WWPForm.gxTpr_Wwpformdate ) )
               {
                  GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_waschg", ""), context.GetMessage( "Dynamic form", ""), "", "", "", "", "", "", "", ""));
               }
               else
               {
                  if ( AV16FormWasInstantiated )
                  {
                     AV26NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
                     AV26NewWWPForm.gxTpr_Wwpformid = AV38WWPForm.gxTpr_Wwpformid;
                     AV26NewWWPForm.gxTpr_Wwpformversionnumber = (short)(AV38WWPForm.gxTpr_Wwpformversionnumber+1);
                     AV26NewWWPForm.gxTpr_Wwpformreferencename = AV38WWPForm.gxTpr_Wwpformreferencename;
                     AV26NewWWPForm.gxTpr_Wwpformtitle = AV38WWPForm.gxTpr_Wwpformtitle;
                     AV26NewWWPForm.gxTpr_Wwpformiswizard = AV38WWPForm.gxTpr_Wwpformiswizard;
                     AV26NewWWPForm.gxTpr_Wwpformresume = AV38WWPForm.gxTpr_Wwpformresume;
                     AV26NewWWPForm.gxTpr_Wwpformresumemessage = AV38WWPForm.gxTpr_Wwpformresumemessage;
                     AV26NewWWPForm.gxTpr_Wwpformtype = AV38WWPForm.gxTpr_Wwpformtype;
                     AV26NewWWPForm.gxTpr_Wwpformsectionrefelements = AV38WWPForm.gxTpr_Wwpformsectionrefelements;
                     AV56GXV4 = 1;
                     while ( AV56GXV4 <= AV38WWPForm.gxTpr_Element.Count )
                     {
                        AV14Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV38WWPForm.gxTpr_Element.Item(AV56GXV4));
                        if ( AV14Element.gxTpr_Wwpformelementparentid >= 0 )
                        {
                           AV26NewWWPForm.gxTpr_Element.Add(AV14Element, 0);
                        }
                        AV56GXV4 = (int)(AV56GXV4+1);
                     }
                     AV26NewWWPForm.gxTpr_Element.Sort("WWPFormElementId");
                     AV38WWPForm = AV26NewWWPForm;
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(AV37WWPDynamicFormMode, "UPD") == 0 )
                     {
                        AV38WWPForm.gxTpr_Element.Sort("WWPFormElementParentId");
                     }
                  }
                  AV38WWPForm.gxTpr_Wwpformdate = DateTimeUtil.Now( context);
                  AV38WWPForm.gxTpr_Wwpformvalidations = AV32Validations.ToJSonString(false);
                  AV38WWPForm.Save();
                  if ( AV38WWPForm.Success() )
                  {
                     context.CommitDataStores("workwithplus.dynamicforms.wwp_createdynamicvalidations",pr_default);
                     context.setWebReturnParms(new Object[] {});
                     context.setWebReturnParmsMetadata(new Object[] {});
                     context.wjLocDisableFrm = 1;
                     context.nUserReturn = 1;
                     returnInSub = true;
                     if (true) return;
                  }
                  else
                  {
                     AV6Messages = AV38WWPForm.GetMessages();
                  }
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38WWPForm", AV38WWPForm);
      }

      protected void S252( )
      {
         /* 'VALIDATE' Routine */
         returnInSub = false;
         AV10CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         GXt_char1 = AV34VarCharAux;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getavailablevariables(context ).execute(  AV28SessionId,  false,  AV41WWPFormElementId,  9999,  "", out  GXt_char1) ;
         AV34VarCharAux = GXt_char1;
         AV9AllReferenceIds.FromJSonString(StringUtil.Lower( AV34VarCharAux), null);
         if ( AV32Validations.Count > 0 )
         {
            AV57GXV5 = 1;
            while ( AV57GXV5 <= AV32Validations.Count )
            {
               AV30Validation = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV32Validations.Item(AV57GXV5));
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getconditionmentionsandvalidate(context ).execute(  AV38WWPForm,  AV30Validation.gxTpr_Condition.gxTpr_Expression,  true,  false,  AV43WWPFormElementReferenceId,  AV40WWPFormElementDataType, ref  AV9AllReferenceIds, out  AV35VarCharList, out  AV11ConditionError) ;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11ConditionError)) )
               {
                  GX_msglist.addItem(AV11ConditionError);
                  AV10CheckRequiredFieldsResult = false;
                  AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
                  if (true) break;
               }
               AV57GXV5 = (int)(AV57GXV5+1);
            }
         }
      }

      protected void wb_table3_54_232( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableaddvalidation_modal_Internalname, tblTableaddvalidation_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucAddvalidation_modal.SetProperty("Width", Addvalidation_modal_Width);
            ucAddvalidation_modal.SetProperty("Title", Addvalidation_modal_Title);
            ucAddvalidation_modal.SetProperty("ConfirmType", Addvalidation_modal_Confirmtype);
            ucAddvalidation_modal.SetProperty("BodyType", Addvalidation_modal_Bodytype);
            ucAddvalidation_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Addvalidation_modal_Internalname, "ADDVALIDATION_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"ADDVALIDATION_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_54_232e( true) ;
         }
         else
         {
            wb_table3_54_232e( false) ;
         }
      }

      protected void wb_table2_49_232( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableupdatevalidation_modal_Internalname, tblTableupdatevalidation_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucUpdatevalidation_modal.SetProperty("Width", Updatevalidation_modal_Width);
            ucUpdatevalidation_modal.SetProperty("Title", Updatevalidation_modal_Title);
            ucUpdatevalidation_modal.SetProperty("ConfirmType", Updatevalidation_modal_Confirmtype);
            ucUpdatevalidation_modal.SetProperty("BodyType", Updatevalidation_modal_Bodytype);
            ucUpdatevalidation_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Updatevalidation_modal_Internalname, "UPDATEVALIDATION_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"UPDATEVALIDATION_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_232e( true) ;
         }
         else
         {
            wb_table2_49_232e( false) ;
         }
      }

      protected void wb_table1_19_232( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV23ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table4_24_232( true) ;
         }
         else
         {
            wb_table4_24_232( false) ;
         }
         return  ;
      }

      protected void wb_table4_24_232e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_19_232e( true) ;
         }
         else
         {
            wb_table1_19_232e( false) ;
         }
      }

      protected void wb_table4_24_232( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_34_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_CreateDynamicValidations.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_24_232e( true) ;
         }
         else
         {
            wb_table4_24_232e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7WWPFormId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV7WWPFormId", StringUtil.LTrimStr( (decimal)(AV7WWPFormId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7WWPFormId), "ZZZ9"), context));
         AV37WWPDynamicFormMode = (string)getParm(obj,1);
         AssignAttri("", false, "AV37WWPDynamicFormMode", AV37WWPDynamicFormMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV37WWPDynamicFormMode, "")), context));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA232( ) ;
         WS232( ) ;
         WE232( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201771981", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_createdynamicvalidations.js", "?20256201771981", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_342( )
      {
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_34_idx;
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_34_idx;
         edtavValidations__messagewithtags_Internalname = "vVALIDATIONS__MESSAGEWITHTAGS_"+sGXsfl_34_idx;
         edtavValidations__message_Internalname = "VALIDATIONS__MESSAGE_"+sGXsfl_34_idx;
      }

      protected void SubsflControlProps_fel_342( )
      {
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_34_fel_idx;
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_34_fel_idx;
         edtavValidations__messagewithtags_Internalname = "vVALIDATIONS__MESSAGEWITHTAGS_"+sGXsfl_34_fel_idx;
         edtavValidations__message_Internalname = "VALIDATIONS__MESSAGE_"+sGXsfl_34_fel_idx;
      }

      protected void sendrow_342( )
      {
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_342( ) ;
         WB230( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_34_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_34_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWithSelection WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_34_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_34_idx + "',34)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_34_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  if ( ( AV50GXV1 > 0 ) && ( AV32Validations.Count >= AV50GXV1 ) && (0==AV49ActionGroup) )
                  {
                     AV49ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV49ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV49ActionGroup), 4, 0));
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV49ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)7,(string)"'"+""+"'"+",false,"+"'"+"e22232_client"+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_34_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_34_idx + "',34)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_34_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  if ( ( AV50GXV1 > 0 ) && ( AV32Validations.Count >= AV50GXV1 ) && (0==AV17GridActionGroup1) )
                  {
                     AV17GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV17GridActionGroup1), 4, 0));
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV17GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_34_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17GridActionGroup1), 4, 0));
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_34_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_34_idx + "',34)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavValidations__messagewithtags_Internalname,(string)AV33Validations__MessageWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavValidations__messagewithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavValidations__messagewithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavValidations__message_Internalname,((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV32Validations.Item(AV50GXV1)).gxTpr_Message,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavValidations__message_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavValidations__message_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes232( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_34_idx = ((subGrid_Islastpage==1)&&(nGXsfl_34_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
         }
         /* End function sendrow_342 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vACTIONGROUP_" + sGXsfl_34_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            if ( ( AV50GXV1 > 0 ) && ( AV32Validations.Count >= AV50GXV1 ) && (0==AV49ActionGroup) )
            {
               AV49ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV49ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV49ActionGroup), 4, 0));
            }
         }
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_34_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            if ( ( AV50GXV1 > 0 ) && ( AV32Validations.Count >= AV50GXV1 ) && (0==AV17GridActionGroup1) )
            {
               AV17GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV17GridActionGroup1), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl34( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"34\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWithSelection WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_Validations", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_Validations", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "WorkWithSelection WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49ActionGroup), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17GridActionGroup1), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV33Validations__MessageWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavValidations__messagewithtags_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavValidations__message_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnaddvalidation_Internalname = "BTNADDVALIDATION";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavActiongroup_Internalname = "vACTIONGROUP";
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1";
         edtavValidations__messagewithtags_Internalname = "vVALIDATIONS__MESSAGEWITHTAGS";
         edtavValidations__message_Internalname = "VALIDATIONS__MESSAGE";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         Updatevalidation_modal_Internalname = "UPDATEVALIDATION_MODAL";
         tblTableupdatevalidation_modal_Internalname = "TABLEUPDATEVALIDATION_MODAL";
         Addvalidation_modal_Internalname = "ADDVALIDATION_MODAL";
         tblTableaddvalidation_modal_Internalname = "TABLEADDVALIDATION_MODAL";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowhovering = -1;
         subGrid_Allowselection = 1;
         subGrid_Header = "";
         edtavValidations__message_Jsonclick = "";
         edtavValidations__message_Enabled = 0;
         edtavValidations__messagewithtags_Jsonclick = "";
         edtavValidations__messagewithtags_Enabled = 1;
         cmbavGridactiongroup1_Jsonclick = "";
         cmbavActiongroup_Jsonclick = "";
         subGrid_Class = "WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavValidations__message_Enabled = -1;
         bttBtnenter_Caption = context.GetMessage( "GX_BtnEnter", "");
         bttBtnenter_Visible = 1;
         bttBtnaddvalidation_Visible = 1;
         Addvalidation_modal_Bodytype = "WebComponent";
         Addvalidation_modal_Confirmtype = "";
         Addvalidation_modal_Title = context.GetMessage( "Validation", "");
         Addvalidation_modal_Width = "800";
         Updatevalidation_modal_Bodytype = "WebComponent";
         Updatevalidation_modal_Confirmtype = "";
         Updatevalidation_modal_Title = context.GetMessage( "Validation", "");
         Updatevalidation_modal_Width = "800";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Element settings", "");
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV44WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9","hsh":true},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV37WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV40WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV28SessionId","fld":"vSESSIONID","pic":"ZZZ9","hsh":true},{"av":"AV42WWPFormElementParentId","fld":"vWWPFORMELEMENTPARENTID","pic":"ZZZ9","hsh":true},{"av":"AV41WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9","hsh":true},{"av":"AV43WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID","hsh":true},{"av":"AV7WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"ctrl":"BTNADDVALIDATION","prop":"Visible"},{"av":"AV23ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E20232","iparms":[{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV49ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"cmbavGridactiongroup1"},{"av":"AV17GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"AV33Validations__MessageWithTags","fld":"vVALIDATIONS__MESSAGEWITHTAGS"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E12232","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV44WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9","hsh":true},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34},{"av":"AV37WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV40WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV28SessionId","fld":"vSESSIONID","pic":"ZZZ9","hsh":true},{"av":"AV42WWPFormElementParentId","fld":"vWWPFORMELEMENTPARENTID","pic":"ZZZ9","hsh":true},{"av":"AV41WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9","hsh":true},{"av":"AV43WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID","hsh":true},{"av":"AV7WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18GridState","fld":"vGRIDSTATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"ctrl":"BTNADDVALIDATION","prop":"Visible"},{"av":"AV23ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E22232","iparms":[{"av":"cmbavActiongroup"},{"av":"AV49ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV49ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E21232","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV17GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34},{"av":"GRID_nEOF"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV44WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9","hsh":true},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV37WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV40WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV28SessionId","fld":"vSESSIONID","pic":"ZZZ9","hsh":true},{"av":"AV42WWPFormElementParentId","fld":"vWWPFORMELEMENTPARENTID","pic":"ZZZ9","hsh":true},{"av":"AV41WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9","hsh":true},{"av":"AV43WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID","hsh":true},{"av":"AV7WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV17GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"AV13CurrentValidationIndex","fld":"vCURRENTVALIDATIONINDEX","pic":"ZZZ9"},{"av":"AV31ValidationJson","fld":"vVALIDATIONJSON"},{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34}]}""");
         setEventMetadata("UPDATEVALIDATION_MODAL.ONLOADCOMPONENT","""{"handler":"E14232","iparms":[{"av":"AV37WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV40WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV28SessionId","fld":"vSESSIONID","pic":"ZZZ9","hsh":true},{"av":"AV31ValidationJson","fld":"vVALIDATIONJSON"}]""");
         setEventMetadata("UPDATEVALIDATION_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("'DOADDVALIDATION'","""{"handler":"E11231","iparms":[]}""");
         setEventMetadata("ADDVALIDATION_MODAL.ONLOADCOMPONENT","""{"handler":"E16232","iparms":[{"av":"AV37WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV42WWPFormElementParentId","fld":"vWWPFORMELEMENTPARENTID","pic":"ZZZ9","hsh":true},{"av":"AV41WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9","hsh":true},{"av":"AV43WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID","hsh":true},{"av":"AV40WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV28SessionId","fld":"vSESSIONID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("ADDVALIDATION_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("UPDATEVALIDATION_MODAL.CLOSE","""{"handler":"E13232","iparms":[{"av":"Updatevalidation_modal_Result","ctrl":"UPDATEVALIDATION_MODAL","prop":"Result"},{"av":"AV13CurrentValidationIndex","fld":"vCURRENTVALIDATIONINDEX","pic":"ZZZ9"},{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34},{"av":"GRID_nEOF"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV44WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9","hsh":true},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV37WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV40WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV28SessionId","fld":"vSESSIONID","pic":"ZZZ9","hsh":true},{"av":"AV42WWPFormElementParentId","fld":"vWWPFORMELEMENTPARENTID","pic":"ZZZ9","hsh":true},{"av":"AV41WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9","hsh":true},{"av":"AV43WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID","hsh":true},{"av":"AV7WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("UPDATEVALIDATION_MODAL.CLOSE",""","oparms":[{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34}]}""");
         setEventMetadata("ADDVALIDATION_MODAL.CLOSE","""{"handler":"E15232","iparms":[{"av":"Addvalidation_modal_Result","ctrl":"ADDVALIDATION_MODAL","prop":"Result"},{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34},{"av":"GRID_nEOF"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV44WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9","hsh":true},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV37WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV40WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV28SessionId","fld":"vSESSIONID","pic":"ZZZ9","hsh":true},{"av":"AV42WWPFormElementParentId","fld":"vWWPFORMELEMENTPARENTID","pic":"ZZZ9","hsh":true},{"av":"AV41WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9","hsh":true},{"av":"AV43WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID","hsh":true},{"av":"AV7WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("ADDVALIDATION_MODAL.CLOSE",""","oparms":[{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34}]}""");
         setEventMetadata("ENTER","""{"handler":"E17232","iparms":[{"av":"AV10CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV37WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV8WWPFormVersionNumber","fld":"vWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV7WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A231WWPFormDate","fld":"WWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV38WWPForm","fld":"vWWPFORM"},{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34},{"av":"AV28SessionId","fld":"vSESSIONID","pic":"ZZZ9","hsh":true},{"av":"AV41WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9","hsh":true},{"av":"AV43WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID","hsh":true},{"av":"AV40WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV8WWPFormVersionNumber","fld":"vWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV38WWPForm","fld":"vWWPFORM"},{"av":"AV10CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34},{"av":"AV37WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV40WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV28SessionId","fld":"vSESSIONID","pic":"ZZZ9","hsh":true},{"av":"AV42WWPFormElementParentId","fld":"vWWPFORMELEMENTPARENTID","pic":"ZZZ9","hsh":true},{"av":"AV41WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9","hsh":true},{"av":"AV43WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID","hsh":true},{"av":"AV7WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV44WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9","hsh":true},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"ctrl":"BTNADDVALIDATION","prop":"Visible"},{"av":"AV23ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34},{"av":"AV37WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV40WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV28SessionId","fld":"vSESSIONID","pic":"ZZZ9","hsh":true},{"av":"AV42WWPFormElementParentId","fld":"vWWPFORMELEMENTPARENTID","pic":"ZZZ9","hsh":true},{"av":"AV41WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9","hsh":true},{"av":"AV43WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID","hsh":true},{"av":"AV7WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV44WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9","hsh":true},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"ctrl":"BTNADDVALIDATION","prop":"Visible"},{"av":"AV23ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34},{"av":"AV37WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV40WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV28SessionId","fld":"vSESSIONID","pic":"ZZZ9","hsh":true},{"av":"AV42WWPFormElementParentId","fld":"vWWPFORMELEMENTPARENTID","pic":"ZZZ9","hsh":true},{"av":"AV41WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9","hsh":true},{"av":"AV43WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID","hsh":true},{"av":"AV7WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV44WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9","hsh":true},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"ctrl":"BTNADDVALIDATION","prop":"Visible"},{"av":"AV23ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV32Validations","fld":"vVALIDATIONS","grid":34},{"av":"nGXsfl_34_idx","ctrl":"GRID","prop":"GridCurrRow","grid":34},{"av":"nRC_GXsfl_34","ctrl":"GRID","prop":"GridRC","grid":34},{"av":"AV37WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true},{"av":"AV40WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV28SessionId","fld":"vSESSIONID","pic":"ZZZ9","hsh":true},{"av":"AV42WWPFormElementParentId","fld":"vWWPFORMELEMENTPARENTID","pic":"ZZZ9","hsh":true},{"av":"AV41WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9","hsh":true},{"av":"AV43WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID","hsh":true},{"av":"AV7WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV44WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9","hsh":true},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"ctrl":"BTNADDVALIDATION","prop":"Visible"},{"av":"AV23ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv2","iparms":[]}""");
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

      public override void initialize( )
      {
         wcpOAV37WWPDynamicFormMode = "";
         Ddo_managefilters_Activeeventkey = "";
         Updatevalidation_modal_Result = "";
         Addvalidation_modal_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV53Pgmname = "";
         AV15FilterFullText = "";
         AV32Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version2");
         AV43WWPFormElementReferenceId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV23ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV18GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV31ValidationJson = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         AV38WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnaddvalidation_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV33Validations__MessageWithTags = "";
         GXDecQS = "";
         AV5HTTPRequest = new GxHttpRequest( context);
         H00232_A206WWPFormId = new short[1] ;
         H00232_A207WWPFormVersionNumber = new short[1] ;
         AV36WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29Text = "";
         GridRow = new GXWebRow();
         AV25ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item2 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12CurrentValidation = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation(context);
         AV27Session = context.GetSession();
         AV19GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV30Validation = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation(context);
         H00233_A206WWPFormId = new short[1] ;
         H00233_A234WWPFormInstantiated = new bool[] {false} ;
         H00233_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         H00233_A207WWPFormVersionNumber = new short[1] ;
         AV39WWPFormDate = (DateTime)(DateTime.MinValue);
         AV26NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV14Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV6Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV34VarCharAux = "";
         GXt_char1 = "";
         AV9AllReferenceIds = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "Comforta_version2");
         AV35VarCharList = new GxSimpleCollection<string>();
         AV11ConditionError = "";
         ucAddvalidation_modal = new GXUserControl();
         ucUpdatevalidation_modal = new GXUserControl();
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_createdynamicvalidations__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_createdynamicvalidations__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_createdynamicvalidations__default(),
            new Object[][] {
                new Object[] {
               H00232_A206WWPFormId, H00232_A207WWPFormVersionNumber
               }
               , new Object[] {
               H00233_A206WWPFormId, H00233_A234WWPFormInstantiated, H00233_A231WWPFormDate, H00233_A207WWPFormVersionNumber
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV53Pgmname = "WorkWithPlus.DynamicForms.WWP_CreateDynamicValidations";
         /* GeneXus formulas. */
         AV53Pgmname = "WorkWithPlus.DynamicForms.WWP_CreateDynamicValidations";
         edtavValidations__messagewithtags_Enabled = 0;
         edtavValidations__message_Enabled = 0;
      }

      private short AV7WWPFormId ;
      private short wcpOAV7WWPFormId ;
      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV24ManageFiltersExecutionStep ;
      private short AV44WWPFormElementType ;
      private short AV40WWPFormElementDataType ;
      private short AV28SessionId ;
      private short AV42WWPFormElementParentId ;
      private short AV41WWPFormElementId ;
      private short gxajaxcallmode ;
      private short AV13CurrentValidationIndex ;
      private short AV8WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short wbEnd ;
      private short wbStart ;
      private short AV49ActionGroup ;
      private short AV17GridActionGroup1 ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short AV20Index ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_34 ;
      private int nGXsfl_34_idx=1 ;
      private int bttBtnaddvalidation_Visible ;
      private int AV50GXV1 ;
      private int bttBtnenter_Visible ;
      private int subGrid_Islastpage ;
      private int edtavValidations__messagewithtags_Enabled ;
      private int edtavValidations__message_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_34_fel_idx=1 ;
      private int nGXsfl_34_bak_idx=1 ;
      private int AV54GXV3 ;
      private int AV56GXV4 ;
      private int AV57GXV5 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string AV37WWPDynamicFormMode ;
      private string wcpOAV37WWPDynamicFormMode ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Updatevalidation_modal_Result ;
      private string Addvalidation_modal_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_34_idx="0001" ;
      private string AV53Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Updatevalidation_modal_Width ;
      private string Updatevalidation_modal_Title ;
      private string Updatevalidation_modal_Confirmtype ;
      private string Updatevalidation_modal_Bodytype ;
      private string Addvalidation_modal_Width ;
      private string Addvalidation_modal_Title ;
      private string Addvalidation_modal_Confirmtype ;
      private string Addvalidation_modal_Bodytype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnaddvalidation_Internalname ;
      private string bttBtnaddvalidation_Jsonclick ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavActiongroup_Internalname ;
      private string cmbavGridactiongroup1_Internalname ;
      private string edtavValidations__messagewithtags_Internalname ;
      private string GXDecQS ;
      private string edtavFilterfulltext_Internalname ;
      private string sGXsfl_34_fel_idx="0001" ;
      private string GXt_char1 ;
      private string tblTableaddvalidation_modal_Internalname ;
      private string Addvalidation_modal_Internalname ;
      private string tblTableupdatevalidation_modal_Internalname ;
      private string Updatevalidation_modal_Internalname ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string edtavValidations__message_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavActiongroup_Jsonclick ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string ROClassString ;
      private string edtavValidations__messagewithtags_Jsonclick ;
      private string edtavValidations__message_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A231WWPFormDate ;
      private DateTime AV39WWPFormDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10CheckRequiredFieldsResult ;
      private bool A234WWPFormInstantiated ;
      private bool wbLoad ;
      private bool bGXsfl_34_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV34 ;
      private bool gx_refresh_fired ;
      private bool AV21IsFirstValidation ;
      private bool AV22IsLastValidation ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV16FormWasInstantiated ;
      private string AV25ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV43WWPFormElementReferenceId ;
      private string AV31ValidationJson ;
      private string AV33Validations__MessageWithTags ;
      private string AV29Text ;
      private string AV34VarCharAux ;
      private string AV11ConditionError ;
      private IGxSession AV27Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucAddvalidation_modal ;
      private GXUserControl ucUpdatevalidation_modal ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV5HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavActiongroup ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV32Validations ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV23ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV18GridState ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV38WWPForm ;
      private IDataStoreProvider pr_default ;
      private short[] H00232_A206WWPFormId ;
      private short[] H00232_A207WWPFormVersionNumber ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV36WWPContext ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item2 ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation AV12CurrentValidation ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV19GridStateFilterValue ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation AV30Validation ;
      private short[] H00233_A206WWPFormId ;
      private bool[] H00233_A234WWPFormInstantiated ;
      private DateTime[] H00233_A231WWPFormDate ;
      private short[] H00233_A207WWPFormVersionNumber ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV26NewWWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV14Element ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV6Messages ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem> AV9AllReferenceIds ;
      private GxSimpleCollection<string> AV35VarCharList ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_createdynamicvalidations__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_createdynamicvalidations__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_createdynamicvalidations__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH00232;
       prmH00232 = new Object[] {
       new ParDef("AV7WWPFormId",GXType.Int16,4,0)
       };
       Object[] prmH00233;
       prmH00233 = new Object[] {
       new ParDef("AV7WWPFormId",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("H00232", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = :AV7WWPFormId ORDER BY WWPFormId, WWPFormVersionNumber DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00232,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("H00233", "SELECT WWPFormId, WWPFormInstantiated, WWPFormDate, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = :AV7WWPFormId ORDER BY WWPFormId, WWPFormVersionNumber DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00233,1, GxCacheFrequency.OFF ,true,true )
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
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((bool[]) buf[1])[0] = rslt.getBool(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             return;
    }
 }

}

}
