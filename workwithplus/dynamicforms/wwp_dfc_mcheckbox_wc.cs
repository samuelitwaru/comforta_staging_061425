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
   public class wwp_dfc_mcheckbox_wc : GXWebComponent
   {
      public wwp_dfc_mcheckbox_wc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wwp_dfc_mcheckbox_wc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPDynamicFormMode ,
                           short aP1_WWPFormElementId ,
                           short aP2_SessionId ,
                           ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP3_WWPForm )
      {
         this.AV16WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV19WWPFormElementId = aP1_WWPFormElementId;
         this.AV12SessionId = aP2_SessionId;
         this.AV17WWPForm = aP3_WWPForm;
         ExecuteImpl();
         aP3_WWPForm=this.AV17WWPForm;
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
         chkavData = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
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
                  AV16WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV16WWPDynamicFormMode", AV16WWPDynamicFormMode);
                  AV19WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV19WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV19WWPFormElementId), 4, 0));
                  AV12SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV12SessionId", StringUtil.LTrimStr( (decimal)(AV12SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV17WWPForm);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV16WWPDynamicFormMode,(short)AV19WWPFormElementId,(short)AV12SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV17WWPForm});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fs") == 0 )
               {
                  gxnrFs_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fs") == 0 )
               {
                  gxgrFs_refresh_invoke( ) ;
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrFs_newrow_invoke( )
      {
         nRC_GXsfl_12 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFs_newrow( ) ;
         /* End function gxnrFs_newrow_invoke */
      }

      protected void gxgrFs_refresh_invoke( )
      {
         AV9IsFirstElement = StringUtil.StrToBool( GetPar( "IsFirstElement"));
         AV10IsLastElement = StringUtil.StrToBool( GetPar( "IsLastElement"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV13WWP_DF_CharMetadata);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV18WWPFormElement);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV14WWP_DF_DateMetadata);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV24SDT_DynamicFormTranslation);
         AV20ParentIsGridMultipleData = StringUtil.StrToBool( GetPar( "ParentIsGridMultipleData"));
         AV15WWP_DynamicFormDataType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWP_DynamicFormDataType"), "."), 18, MidpointRounding.ToEven));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFs_refresh( AV9IsFirstElement, AV10IsLastElement, AV13WWP_DF_CharMetadata, AV18WWPFormElement, AV14WWP_DF_DateMetadata, AV24SDT_DynamicFormTranslation, AV20ParentIsGridMultipleData, AV15WWP_DynamicFormDataType, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFs_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA322( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS322( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form Creation_Multiple Checkbox_WC", "")) ;
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
            {
               context.WriteHtmlText( " dir=\"rtl\" ") ;
            }
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_dfc_mcheckbox_wc.aspx"+UrlEncode(StringUtil.RTrim(AV16WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV19WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV12SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_dfc_mcheckbox_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV9IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV9IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV10IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV10IsLastElement, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_DATEMETADATA", AV14WWP_DF_DateMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_DATEMETADATA", AV14WWP_DF_DateMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_DATEMETADATA", GetSecureSignedToken( sPrefix, AV14WWP_DF_DateMetadata, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV24SDT_DynamicFormTranslation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV24SDT_DynamicFormTranslation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_DYNAMICFORMTRANSLATION", GetSecureSignedToken( sPrefix, AV24SDT_DynamicFormTranslation, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV20ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV20ParentIsGridMultipleData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DYNAMICFORMDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15WWP_DynamicFormDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15WWP_DynamicFormDataType), "Z9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV16WWPDynamicFormMode", StringUtil.RTrim( wcpOAV16WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV19WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV19WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV12SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV12SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV9IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV9IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV10IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV10IsLastElement, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV13WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV13WWP_DF_CharMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMELEMENT", AV18WWPFormElement);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMELEMENT", AV18WWPFormElement);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_DATEMETADATA", AV14WWP_DF_DateMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_DATEMETADATA", AV14WWP_DF_DateMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_DATEMETADATA", GetSecureSignedToken( sPrefix, AV14WWP_DF_DateMetadata, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV24SDT_DynamicFormTranslation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV24SDT_DynamicFormTranslation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_DYNAMICFORMTRANSLATION", GetSecureSignedToken( sPrefix, AV24SDT_DynamicFormTranslation, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vNEEDTORELOADWC", AV11NeedToReloadWC);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV20ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV20ParentIsGridMultipleData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DYNAMICFORMDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15WWP_DynamicFormDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15WWP_DynamicFormDataType), "Z9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV16WWPDynamicFormMode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORM", AV17WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORM", AV17WWPForm);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"subFs_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFs_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndeleteelement_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENT_Wwpformelementmetadata", AV18WWPFormElement.gxTpr_Wwpformelementmetadata);
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndeleteelement_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
      }

      protected void RenderHtmlCloseForm322( )
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
            if ( ! ( WebComp_Wwpaux_wc == null ) )
            {
               WebComp_Wwpaux_wc.componentjscripts();
            }
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
         return "WorkWithPlus.DynamicForms.WWP_DFC_MCheckBox_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form Creation_Multiple Checkbox_WC", "") ;
      }

      protected void WB320( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_dfc_mcheckbox_wc.aspx");
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableDynFormAddedElement", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatatitlecell_Internalname, divDatatitlecell_Visible, 0, "px", 0, "px", divDatatitlecell_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDatatitle_Internalname, lblDatatitle_Caption, "", "", lblDatatitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DynFormDataDescription", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DFC_MCheckBox_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DynamicFormMultipleCheckBoxCell", "start", "top", "", "", "div");
            /*  Grid Control  */
            FsContainer.SetIsFreestyle(true);
            FsContainer.SetWrapped(nGXWrapped);
            StartGridControl12( ) ;
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
            if ( FsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"FsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fs", FsContainer, subFs_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FsContainerData", FsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FsContainerData"+"V", FsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FsContainerData"+"V"+"\" value='"+FsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 TableDynAddElementActionsCell", "end", "top", "", "", "div");
            wb_table1_25_322( true) ;
         }
         else
         {
            wb_table1_25_322( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_322e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "end", "top", "div");
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
            wb_table2_38_322( true) ;
         }
         else
         {
            wb_table2_38_322( false) ;
         }
         return  ;
      }

      protected void wb_table2_38_322e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_43_322( true) ;
         }
         else
         {
            wb_table3_43_322( false) ;
         }
         return  ;
      }

      protected void wb_table3_43_322e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0049"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0049"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_12_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0049"+"");
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
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"FsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fs", FsContainer, subFs_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FsContainerData", FsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FsContainerData"+"V", FsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FsContainerData"+"V"+"\" value='"+FsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START322( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form Creation_Multiple Checkbox_WC", ""), 0) ;
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
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP320( ) ;
            }
         }
      }

      protected void WS322( )
      {
         START322( ) ;
         EVT322( ) ;
      }

      protected void EVT322( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP320( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP320( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_btndeleteelement.Close */
                                    E11322 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP320( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Close */
                                    E12322 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP320( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Onloadcomponent */
                                    E13322 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMOVEUP'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP320( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMoveUp' */
                                    E14322 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMOVEDOWN'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP320( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMoveDown' */
                                    E15322 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP320( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "FS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP320( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              AV5Data = StringUtil.StrToBool( cgiGet( chkavData_Internalname));
                              AssignAttri(sPrefix, false, chkavData_Internalname, AV5Data);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E16322 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Refresh */
                                          E17322 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Fs.Load */
                                          E18322 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP320( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                       }
                                    }
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
                        if ( nCmpId == 49 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0049");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0049", "", sEvt);
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

      protected void WE322( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm322( ) ;
            }
         }
      }

      protected void PA322( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_mcheckbox_wc.aspx")), "workwithplus.dynamicforms.wwp_dfc_mcheckbox_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_mcheckbox_wc.aspx")))) ;
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
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
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
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrFs_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subFs_Islastpage==1)&&(nGXsfl_12_idx+1>subFs_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FsContainer)) ;
         /* End function gxnrFs_newrow */
      }

      protected void gxgrFs_refresh( bool AV9IsFirstElement ,
                                     bool AV10IsLastElement ,
                                     WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV13WWP_DF_CharMetadata ,
                                     GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV18WWPFormElement ,
                                     WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata AV14WWP_DF_DateMetadata ,
                                     SdtSDT_DynamicFormTranslation AV24SDT_DynamicFormTranslation ,
                                     bool AV20ParentIsGridMultipleData ,
                                     short AV15WWP_DynamicFormDataType ,
                                     string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FS_nCurrentRecord = 0;
         RF322( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrFs_refresh */
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
         RF322( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF322( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FsContainer.ClearRows();
         }
         wbStart = 12;
         /* Execute user event: Refresh */
         E17322 ();
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         FsContainer.AddObjectProperty("GridName", "Fs");
         FsContainer.AddObjectProperty("CmpContext", sPrefix);
         FsContainer.AddObjectProperty("InMasterPage", "false");
         FsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FsContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFs_Backcolorstyle), 1, 0, ".", "")));
         FsContainer.PageSize = subFs_fnc_Recordsperpage( );
         if ( subFs_Islastpage != 0 )
         {
            FS_nFirstRecordOnPage = (long)(subFs_fnc_Recordcount( )-subFs_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"FS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FS_nFirstRecordOnPage), 15, 0, ".", "")));
            FsContainer.AddObjectProperty("FS_nFirstRecordOnPage", FS_nFirstRecordOnPage);
         }
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
            SubsflControlProps_122( ) ;
            /* Execute user event: Fs.Load */
            E18322 ();
            wbEnd = 12;
            WB320( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes322( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV9IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV9IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV10IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV10IsLastElement, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_DATEMETADATA", AV14WWP_DF_DateMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_DATEMETADATA", AV14WWP_DF_DateMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_DATEMETADATA", GetSecureSignedToken( sPrefix, AV14WWP_DF_DateMetadata, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV24SDT_DynamicFormTranslation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_DYNAMICFORMTRANSLATION", AV24SDT_DynamicFormTranslation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_DYNAMICFORMTRANSLATION", GetSecureSignedToken( sPrefix, AV24SDT_DynamicFormTranslation, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV20ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV20ParentIsGridMultipleData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DYNAMICFORMDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15WWP_DynamicFormDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15WWP_DynamicFormDataType), "Z9"), context));
      }

      protected int subFs_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFs_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFs_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFs_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP320( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16322 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV16WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV16WWPDynamicFormMode");
            wcpOAV19WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV19WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV12SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV12SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subFs_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subFs_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvelop_confirmpanel_btndeleteelement_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result");
            Settings_modal_Result = cgiGet( sPrefix+"SETTINGS_MODAL_Result");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E16322 ();
         if (returnInSub) return;
      }

      protected void E16322( )
      {
         /* Start Routine */
         returnInSub = false;
         AV24SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid = AV17WWPForm.gxTpr_Wwpformid;
         AV24SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber = AV17WWPForm.gxTpr_Wwpformversionnumber;
         AV24SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid = AV19WWPFormElementId;
         new prc_getdynamicformtranslation(context ).execute( ref  AV24SDT_DynamicFormTranslation) ;
         GXt_SdtWWP_Form_Element1 = AV18WWPFormElement;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV17WWPForm,  AV19WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
         AV18WWPFormElement = GXt_SdtWWP_Form_Element1;
         AV15WWP_DynamicFormDataType = AV18WWPFormElement.gxTpr_Wwpformelementdatatype;
         AssignAttri(sPrefix, false, "AV15WWP_DynamicFormDataType", StringUtil.LTrimStr( (decimal)(AV15WWP_DynamicFormDataType), 2, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15WWP_DynamicFormDataType), "Z9"), context));
         /* Execute user subroutine: 'LOAD TITLE AND METADATA' */
         S112 ();
         if (returnInSub) return;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_canmoveelement(context ).execute(  AV17WWPForm,  AV18WWPFormElement, out  AV9IsFirstElement, out  AV10IsLastElement) ;
         AssignAttri(sPrefix, false, "AV9IsFirstElement", AV9IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV9IsFirstElement, context));
         AssignAttri(sPrefix, false, "AV10IsLastElement", AV10IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV10IsLastElement, context));
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_showsmallbuttons(context).executeUdp( ref  AV17WWPForm,  AV18WWPFormElement.gxTpr_Wwpformelementparentid,  false, out  AV20ParentIsGridMultipleData) )
         {
            Btnmoveup_Caption = "";
            ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Caption", Btnmoveup_Caption);
            Btnmovedown_Caption = "";
            ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Caption", Btnmovedown_Caption);
            Btnsettings_Caption = "";
            ucBtnsettings.SendProperty(context, sPrefix, false, Btnsettings_Internalname, "Caption", Btnsettings_Caption);
            Btndeleteelement_Caption = "";
            ucBtndeleteelement.SendProperty(context, sPrefix, false, Btndeleteelement_Internalname, "Caption", Btndeleteelement_Caption);
            if ( AV20ParentIsGridMultipleData )
            {
               Btnmoveup_Tooltiptext = context.GetMessage( "Move left", "");
               ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "TooltipText", Btnmoveup_Tooltiptext);
               Btnmoveup_Beforeiconclass = "fas fa-arrow-left";
               ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "BeforeIconClass", Btnmoveup_Beforeiconclass);
               Btnmovedown_Tooltiptext = context.GetMessage( "Move right", "");
               ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "TooltipText", Btnmovedown_Tooltiptext);
               Btnmovedown_Beforeiconclass = "fas fa-arrow-right";
               ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "BeforeIconClass", Btnmovedown_Beforeiconclass);
            }
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E17322( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      private void E18322( )
      {
         /* Fs_Load Routine */
         returnInSub = false;
         AV8i = 1;
         while ( AV8i <= AV13WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Options.Count )
         {
            AV7DataName = ((string)AV13WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Options.Item(AV8i));
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "CheckBox_SetTitle", new Object[] {(string)chkavData_Internalname,(string)AV7DataName}, false);
            lblTextblockdata_Caption = "";
            if ( AV18WWPFormElement.gxTpr_Wwpformelementcaption != 1 )
            {
               AV6DataCellNameClass = "DataContentCell DataContentCellNoLabel";
            }
            else
            {
               AV6DataCellNameClass = "DataContentCell DscTop";
               if ( AV8i == 1 )
               {
                  if ( AV14WWP_DF_DateMetadata.gxTpr_Isrequired )
                  {
                     AV6DataCellNameClass = "Required" + AV6DataCellNameClass;
                  }
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue)) )
                  {
                     lblTextblockdata_Caption = AV18WWPFormElement.gxTpr_Wwpformelementtitle;
                  }
                  else
                  {
                     lblTextblockdata_Caption = AV24SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue;
                  }
               }
               else
               {
                  lblTextblockdata_Visible = 0;
               }
            }
            divDatacellname_Class = AV6DataCellNameClass;
            AssignProp(sPrefix, false, divDatacellname_Internalname, "Class", divDatacellname_Class, !bGXsfl_12_Refreshing);
            divDatatitlecell_Class = AV6DataCellNameClass;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Class", divDatatitlecell_Class, true);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 12;
            }
            sendrow_122( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
            {
               DoAjaxLoad(12, FsRow);
            }
            AV8i = (short)(AV8i+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E14322( )
      {
         /* 'DoMoveUp' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_moveelement(context ).execute(  AV12SessionId,  AV19WWPFormElementId,  true) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
      }

      protected void E15322( )
      {
         /* 'DoMoveDown' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_moveelement(context ).execute(  AV12SessionId,  AV19WWPFormElementId,  false) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
      }

      protected void E11322( )
      {
         /* Dvelop_confirmpanel_btndeleteelement_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btndeleteelement_Result, "Yes") == 0 )
         {
            GXt_SdtWWP_Form2 = AV17WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV12SessionId, out  GXt_SdtWWP_Form2) ;
            AV17WWPForm = GXt_SdtWWP_Form2;
            GXt_SdtWWP_Form_Element1 = AV18WWPFormElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV17WWPForm,  AV19WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
            AV18WWPFormElement = GXt_SdtWWP_Form_Element1;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_deleteelement(context ).execute( ref  AV17WWPForm, ref  AV18WWPFormElement) ;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveformdefinition(context ).execute(  AV12SessionId,  AV17WWPForm) ;
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17WWPForm", AV17WWPForm);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18WWPFormElement", AV18WWPFormElement);
      }

      protected void E13322( )
      {
         /* Settings_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "UAddElement")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "uaddelement", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "UAddElement";
            WebComp_Wwpaux_wc_Component = "UAddElement";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0049",(string)"",(string)"UPD",(short)0,(short)AV19WWPFormElementId,(short)AV12SessionId});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0049"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV9IsFirstElement ) )
         {
            Btnmoveup_Visible = false;
            ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Visible", StringUtil.BoolToStr( Btnmoveup_Visible));
         }
         if ( ! ( ! AV10IsLastElement ) )
         {
            Btnmovedown_Visible = false;
            ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Visible", StringUtil.BoolToStr( Btnmovedown_Visible));
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         tblTableactions_Visible = (((StringUtil.StrCmp(AV16WWPDynamicFormMode, "DSP")!=0)) ? 1 : 0);
         AssignProp(sPrefix, false, tblTableactions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableactions_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'LOAD TITLE AND METADATA' Routine */
         returnInSub = false;
         if ( AV18WWPFormElement.gxTpr_Wwpformelementcaption == 2 )
         {
            lblDatatitle_Caption = AV18WWPFormElement.gxTpr_Wwpformelementtitle;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
            divDatatitlecell_Visible = 1;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         else
         {
            divDatatitlecell_Visible = 0;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         AV6DataCellNameClass = "DataContentCell DscTop";
         if ( AV18WWPFormElement.gxTpr_Wwpformelementcaption != 1 )
         {
            AV6DataCellNameClass += " DataContentCellNoLabel";
         }
         AV13WWP_DF_CharMetadata.FromJSonString(AV18WWPFormElement.gxTpr_Wwpformelementmetadata, null);
         divDatatitlecell_Class = AV6DataCellNameClass;
         AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Class", divDatatitlecell_Class, true);
      }

      protected void E12322( )
      {
         /* Settings_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Settings_modal_Result, "OK") == 0 )
         {
            GXt_SdtWWP_Form2 = AV17WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV12SessionId, out  GXt_SdtWWP_Form2) ;
            AV17WWPForm = GXt_SdtWWP_Form2;
            GXt_SdtWWP_Form_Element1 = AV18WWPFormElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV17WWPForm,  AV19WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
            AV18WWPFormElement = GXt_SdtWWP_Form_Element1;
            /* Execute user subroutine: 'NEED TO RELOAD WC' */
            S142 ();
            if (returnInSub) return;
            if ( AV11NeedToReloadWC )
            {
               this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
            }
            else
            {
               /* Execute user subroutine: 'LOAD TITLE AND METADATA' */
               S112 ();
               if (returnInSub) return;
            }
         }
         if ( ( StringUtil.StrCmp(Settings_modal_Result, "OK") == 0 ) && ! AV11NeedToReloadWC )
         {
            gxgrFs_refresh( AV9IsFirstElement, AV10IsLastElement, AV13WWP_DF_CharMetadata, AV18WWPFormElement, AV14WWP_DF_DateMetadata, AV24SDT_DynamicFormTranslation, AV20ParentIsGridMultipleData, AV15WWP_DynamicFormDataType, sPrefix) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17WWPForm", AV17WWPForm);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18WWPFormElement", AV18WWPFormElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13WWP_DF_CharMetadata", AV13WWP_DF_CharMetadata);
      }

      protected void S142( )
      {
         /* 'NEED TO RELOAD WC' Routine */
         returnInSub = false;
         AV11NeedToReloadWC = (bool)((AV20ParentIsGridMultipleData||(AV18WWPFormElement.gxTpr_Wwpformelementdatatype!=AV15WWP_DynamicFormDataType)));
         AssignAttri(sPrefix, false, "AV11NeedToReloadWC", AV11NeedToReloadWC);
         if ( ! AV11NeedToReloadWC )
         {
            AV13WWP_DF_CharMetadata.FromJSonString(AV18WWPFormElement.gxTpr_Wwpformelementmetadata, null);
            AV11NeedToReloadWC = (bool)(((AV13WWP_DF_CharMetadata.gxTpr_Controltype!=4)||(AV13WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype!=4)));
            AssignAttri(sPrefix, false, "AV11NeedToReloadWC", AV11NeedToReloadWC);
         }
      }

      protected void wb_table3_43_322( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablesettings_modal_Internalname, tblTablesettings_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucSettings_modal.SetProperty("Width", Settings_modal_Width);
            ucSettings_modal.SetProperty("Title", Settings_modal_Title);
            ucSettings_modal.SetProperty("ConfirmType", Settings_modal_Confirmtype);
            ucSettings_modal.SetProperty("BodyType", Settings_modal_Bodytype);
            ucSettings_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Settings_modal_Internalname, sPrefix+"SETTINGS_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"SETTINGS_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_43_322e( true) ;
         }
         else
         {
            wb_table3_43_322e( false) ;
         }
      }

      protected void wb_table2_38_322( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btndeleteelement_Internalname, tblTabledvelop_confirmpanel_btndeleteelement_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("Title", Dvelop_confirmpanel_btndeleteelement_Title);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("ConfirmationText", Dvelop_confirmpanel_btndeleteelement_Confirmationtext);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btndeleteelement_Yesbuttoncaption);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btndeleteelement_Nobuttoncaption);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btndeleteelement_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btndeleteelement_Yesbuttonposition);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("ConfirmType", Dvelop_confirmpanel_btndeleteelement_Confirmtype);
            ucDvelop_confirmpanel_btndeleteelement.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btndeleteelement_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENTContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_38_322e( true) ;
         }
         else
         {
            wb_table2_38_322e( false) ;
         }
      }

      protected void wb_table1_25_322( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTableactions_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTableactions_Internalname, tblTableactions_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtnmoveup.SetProperty("TooltipText", Btnmoveup_Tooltiptext);
            ucBtnmoveup.SetProperty("BeforeIconClass", Btnmoveup_Beforeiconclass);
            ucBtnmoveup.SetProperty("Caption", Btnmoveup_Caption);
            ucBtnmoveup.SetProperty("Class", Btnmoveup_Class);
            ucBtnmoveup.Render(context, "wwp_iconbutton", Btnmoveup_Internalname, sPrefix+"BTNMOVEUPContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtnmovedown.SetProperty("TooltipText", Btnmovedown_Tooltiptext);
            ucBtnmovedown.SetProperty("BeforeIconClass", Btnmovedown_Beforeiconclass);
            ucBtnmovedown.SetProperty("Caption", Btnmovedown_Caption);
            ucBtnmovedown.SetProperty("Class", Btnmovedown_Class);
            ucBtnmovedown.Render(context, "wwp_iconbutton", Btnmovedown_Internalname, sPrefix+"BTNMOVEDOWNContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtndeleteelement.SetProperty("TooltipText", Btndeleteelement_Tooltiptext);
            ucBtndeleteelement.SetProperty("BeforeIconClass", Btndeleteelement_Beforeiconclass);
            ucBtndeleteelement.SetProperty("Caption", Btndeleteelement_Caption);
            ucBtndeleteelement.SetProperty("Class", Btndeleteelement_Class);
            ucBtndeleteelement.Render(context, "wwp_iconbutton", Btndeleteelement_Internalname, sPrefix+"BTNDELETEELEMENTContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtnsettings.SetProperty("TooltipText", Btnsettings_Tooltiptext);
            ucBtnsettings.SetProperty("BeforeIconClass", Btnsettings_Beforeiconclass);
            ucBtnsettings.SetProperty("Caption", Btnsettings_Caption);
            ucBtnsettings.SetProperty("Class", Btnsettings_Class);
            ucBtnsettings.Render(context, "wwp_iconbutton", Btnsettings_Internalname, sPrefix+"BTNSETTINGSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_322e( true) ;
         }
         else
         {
            wb_table1_25_322e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV16WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV16WWPDynamicFormMode", AV16WWPDynamicFormMode);
         AV19WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV19WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV19WWPFormElementId), 4, 0));
         AV12SessionId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV12SessionId", StringUtil.LTrimStr( (decimal)(AV12SessionId), 4, 0));
         AV17WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,3);
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
         PA322( ) ;
         WS322( ) ;
         WE322( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
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
         sCtrlAV16WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV19WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV12SessionId = (string)((string)getParm(obj,2));
         sCtrlAV17WWPForm = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA322( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_dfc_mcheckbox_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA322( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV16WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV16WWPDynamicFormMode", AV16WWPDynamicFormMode);
            AV19WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV19WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV19WWPFormElementId), 4, 0));
            AV12SessionId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV12SessionId", StringUtil.LTrimStr( (decimal)(AV12SessionId), 4, 0));
            AV17WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,5);
         }
         wcpOAV16WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV16WWPDynamicFormMode");
         wcpOAV19WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV19WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV12SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV12SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV16WWPDynamicFormMode, wcpOAV16WWPDynamicFormMode) != 0 ) || ( AV19WWPFormElementId != wcpOAV19WWPFormElementId ) || ( AV12SessionId != wcpOAV12SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV16WWPDynamicFormMode = AV16WWPDynamicFormMode;
         wcpOAV19WWPFormElementId = AV19WWPFormElementId;
         wcpOAV12SessionId = AV12SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV16WWPDynamicFormMode = cgiGet( sPrefix+"AV16WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV16WWPDynamicFormMode) > 0 )
         {
            AV16WWPDynamicFormMode = cgiGet( sCtrlAV16WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV16WWPDynamicFormMode", AV16WWPDynamicFormMode);
         }
         else
         {
            AV16WWPDynamicFormMode = cgiGet( sPrefix+"AV16WWPDynamicFormMode_PARM");
         }
         sCtrlAV19WWPFormElementId = cgiGet( sPrefix+"AV19WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV19WWPFormElementId) > 0 )
         {
            AV19WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV19WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV19WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV19WWPFormElementId), 4, 0));
         }
         else
         {
            AV19WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV19WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV12SessionId = cgiGet( sPrefix+"AV12SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV12SessionId) > 0 )
         {
            AV12SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV12SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV12SessionId", StringUtil.LTrimStr( (decimal)(AV12SessionId), 4, 0));
         }
         else
         {
            AV12SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV12SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV17WWPForm = cgiGet( sPrefix+"AV17WWPForm_CTRL");
         if ( StringUtil.Len( sCtrlAV17WWPForm) > 0 )
         {
            AV17WWPForm.FromXml(cgiGet( sCtrlAV17WWPForm), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV17WWPForm_PARM"), AV17WWPForm);
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
         INITWEB( ) ;
         nDraw = 0;
         PA322( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS322( ) ;
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
         WS322( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV16WWPDynamicFormMode_PARM", StringUtil.RTrim( AV16WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV16WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV19WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV19WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV19WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV19WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV12SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV12SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV12SessionId_CTRL", StringUtil.RTrim( sCtrlAV12SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV17WWPForm_PARM", AV17WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV17WWPForm_PARM", AV17WWPForm);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV17WWPForm)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV17WWPForm_CTRL", StringUtil.RTrim( sCtrlAV17WWPForm));
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
         WE322( ) ;
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145243345", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_dfc_mcheckbox_wc.js", "?20256145243346", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         lblTextblockdata_Internalname = sPrefix+"TEXTBLOCKDATA_"+sGXsfl_12_idx;
         chkavData_Internalname = sPrefix+"vDATA_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         lblTextblockdata_Internalname = sPrefix+"TEXTBLOCKDATA_"+sGXsfl_12_fel_idx;
         chkavData_Internalname = sPrefix+"vDATA_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         WB320( ) ;
         FsRow = GXWebRow.GetNew(context,FsContainer);
         if ( subFs_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFs_Backstyle = 0;
            if ( StringUtil.StrCmp(subFs_Class, "") != 0 )
            {
               subFs_Linesclass = subFs_Class+"Odd";
            }
         }
         else if ( subFs_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFs_Backstyle = 0;
            subFs_Backcolor = subFs_Allbackcolor;
            if ( StringUtil.StrCmp(subFs_Class, "") != 0 )
            {
               subFs_Linesclass = subFs_Class+"Uniform";
            }
         }
         else if ( subFs_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFs_Backstyle = 1;
            if ( StringUtil.StrCmp(subFs_Class, "") != 0 )
            {
               subFs_Linesclass = subFs_Class+"Odd";
            }
            subFs_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFs_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFs_Backstyle = 1;
            if ( ((int)((nGXsfl_12_idx) % (2))) == 0 )
            {
               subFs_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFs_Class, "") != 0 )
               {
                  subFs_Linesclass = subFs_Class+"Even";
               }
            }
            else
            {
               subFs_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFs_Class, "") != 0 )
               {
                  subFs_Linesclass = subFs_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFs_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_12_idx+"\">") ;
         }
         /* Div Control */
         FsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFslayouttable_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divDatacellname_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)divDatacellname_Class,(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtabledata_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 MergeLabelCell",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         FsRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTextblockdata_Internalname,(string)lblTextblockdata_Caption,(string)"",(string)"",(string)lblTextblockdata_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"Label",(short)0,(string)"",(int)lblTextblockdata_Visible,(short)1,(short)0,(short)0});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         FsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavData_Internalname,context.GetMessage( "Data", ""),(string)"col-sm-3 AttributeCheckBoxLabel",(short)0,(bool)true,(string)""});
         /* Check box */
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GXCCtl = "vDATA_" + sGXsfl_12_idx;
         chkavData.Name = GXCCtl;
         chkavData.WebTags = "";
         chkavData.Caption = context.GetMessage( "Data", "");
         AssignProp(sPrefix, false, chkavData_Internalname, "TitleCaption", chkavData.Caption, !bGXsfl_12_Refreshing);
         chkavData.CheckedValue = "false";
         FsRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavData_Internalname,StringUtil.BoolToStr( AV5Data),(string)"",context.GetMessage( "Data", ""),(short)1,(short)0,(string)"true",context.GetMessage( "Data", ""),(string)StyleString,(string)ClassString,(string)"",(string)"",(string)""});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes322( ) ;
         /* End of Columns property logic. */
         FsContainer.AddRow(FsRow);
         nGXsfl_12_idx = ((subFs_Islastpage==1)&&(nGXsfl_12_idx+1>subFs_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vDATA_" + sGXsfl_12_idx;
         chkavData.Name = GXCCtl;
         chkavData.WebTags = "";
         chkavData.Caption = context.GetMessage( "Data", "");
         AssignProp(sPrefix, false, chkavData_Internalname, "TitleCaption", chkavData.Caption, !bGXsfl_12_Refreshing);
         chkavData.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl12( )
      {
         if ( FsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"FsContainer"+"DivS\" data-gxgridid=\"12\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFs_Internalname, subFs_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FsContainer.AddObjectProperty("GridName", "Fs");
         }
         else
         {
            FsContainer.AddObjectProperty("GridName", "Fs");
            FsContainer.AddObjectProperty("Header", subFs_Header);
            FsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FsContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            FsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFs_Backcolorstyle), 1, 0, ".", "")));
            FsContainer.AddObjectProperty("CmpContext", sPrefix);
            FsContainer.AddObjectProperty("InMasterPage", "false");
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsColumn.AddObjectProperty("Value", lblTextblockdata_Caption);
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV5Data)));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsContainer.AddColumnProperties(FsColumn);
            FsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFs_Selectedindex), 4, 0, ".", "")));
            FsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFs_Allowselection), 1, 0, ".", "")));
            FsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFs_Selectioncolor), 9, 0, ".", "")));
            FsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFs_Allowhovering), 1, 0, ".", "")));
            FsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFs_Hoveringcolor), 9, 0, ".", "")));
            FsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFs_Allowcollapsing), 1, 0, ".", "")));
            FsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFs_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblDatatitle_Internalname = sPrefix+"DATATITLE";
         divDatatitlecell_Internalname = sPrefix+"DATATITLECELL";
         lblTextblockdata_Internalname = sPrefix+"TEXTBLOCKDATA";
         chkavData_Internalname = sPrefix+"vDATA";
         divUnnamedtabledata_Internalname = sPrefix+"UNNAMEDTABLEDATA";
         divDatacellname_Internalname = sPrefix+"DATACELLNAME";
         divFslayouttable_Internalname = sPrefix+"FSLAYOUTTABLE";
         Btnmoveup_Internalname = sPrefix+"BTNMOVEUP";
         Btnmovedown_Internalname = sPrefix+"BTNMOVEDOWN";
         Btndeleteelement_Internalname = sPrefix+"BTNDELETEELEMENT";
         Btnsettings_Internalname = sPrefix+"BTNSETTINGS";
         tblTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Dvelop_confirmpanel_btndeleteelement_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT";
         tblTabledvelop_confirmpanel_btndeleteelement_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_BTNDELETEELEMENT";
         Settings_modal_Internalname = sPrefix+"SETTINGS_MODAL";
         tblTablesettings_modal_Internalname = sPrefix+"TABLESETTINGS_MODAL";
         divDiv_wwpauxwc_Internalname = sPrefix+"DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subFs_Internalname = sPrefix+"FS";
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
         subFs_Allowcollapsing = 0;
         lblTextblockdata_Caption = "";
         chkavData.Caption = context.GetMessage( "Data", "");
         lblTextblockdata_Caption = "";
         lblTextblockdata_Visible = 1;
         subFs_Class = "FreeStyleGrid";
         Btnsettings_Class = "ButtonGray";
         Btnsettings_Beforeiconclass = "fas fa-gear";
         Btnsettings_Tooltiptext = "Settings";
         Btndeleteelement_Class = "ButtonGray";
         Btndeleteelement_Beforeiconclass = "fa-trash-can far";
         Btndeleteelement_Tooltiptext = "Delete";
         Btnmovedown_Class = "ButtonGray";
         Btnmoveup_Class = "ButtonGray";
         Dvelop_confirmpanel_btndeleteelement_Confirmtype = "1";
         Dvelop_confirmpanel_btndeleteelement_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btndeleteelement_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btndeleteelement_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btndeleteelement_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btndeleteelement_Confirmationtext = "DF_ConfirmCurrentElementDeletion";
         Dvelop_confirmpanel_btndeleteelement_Title = context.GetMessage( "GX_BtnDelete", "");
         Settings_modal_Bodytype = "WebComponent";
         Settings_modal_Confirmtype = "";
         Settings_modal_Title = context.GetMessage( "Add Element", "");
         Settings_modal_Width = "800";
         tblTableactions_Visible = 1;
         Btnmovedown_Visible = Convert.ToBoolean( -1);
         Btnmoveup_Visible = Convert.ToBoolean( -1);
         divDatacellname_Class = "col-xs-12 DataContentCell DscTop";
         Btnmovedown_Beforeiconclass = "fas fa-arrow-down";
         Btnmovedown_Tooltiptext = "Move down";
         Btnmoveup_Beforeiconclass = "fas fa-arrow-up";
         Btnmoveup_Tooltiptext = "Move up";
         Btndeleteelement_Caption = context.GetMessage( "GX_BtnDelete", "");
         Btnsettings_Caption = context.GetMessage( "WWP_DF_Settings", "");
         Btnmovedown_Caption = context.GetMessage( "WWP_DF_MoveDown", "");
         Btnmoveup_Caption = context.GetMessage( "WWP_DF_MoveUp", "");
         subFs_Backcolorstyle = 0;
         lblDatatitle_Caption = context.GetMessage( "Title", "");
         divDatatitlecell_Class = "col-xs-12";
         divDatatitlecell_Visible = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FS_nFirstRecordOnPage"},{"av":"FS_nEOF"},{"av":"AV13WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"AV18WWPFormElement","fld":"vWWPFORMELEMENT"},{"av":"sPrefix"},{"av":"AV9IsFirstElement","fld":"vISFIRSTELEMENT","hsh":true},{"av":"AV10IsLastElement","fld":"vISLASTELEMENT","hsh":true},{"av":"AV14WWP_DF_DateMetadata","fld":"vWWP_DF_DATEMETADATA","hsh":true},{"av":"AV24SDT_DynamicFormTranslation","fld":"vSDT_DYNAMICFORMTRANSLATION","hsh":true},{"av":"AV20ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV15WWP_DynamicFormDataType","fld":"vWWP_DYNAMICFORMDATATYPE","pic":"Z9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnmoveup_Visible","ctrl":"BTNMOVEUP","prop":"Visible"},{"av":"Btnmovedown_Visible","ctrl":"BTNMOVEDOWN","prop":"Visible"}]}""");
         setEventMetadata("FS.LOAD","""{"handler":"E18322","iparms":[{"av":"AV13WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"AV18WWPFormElement","fld":"vWWPFORMELEMENT"},{"av":"AV14WWP_DF_DateMetadata","fld":"vWWP_DF_DATEMETADATA","hsh":true},{"av":"AV24SDT_DynamicFormTranslation","fld":"vSDT_DYNAMICFORMTRANSLATION","hsh":true}]""");
         setEventMetadata("FS.LOAD",""","oparms":[{"av":"lblTextblockdata_Caption","ctrl":"TEXTBLOCKDATA","prop":"Caption"},{"av":"lblTextblockdata_Visible","ctrl":"TEXTBLOCKDATA","prop":"Visible"},{"av":"divDatacellname_Class","ctrl":"DATACELLNAME","prop":"Class"},{"av":"divDatatitlecell_Class","ctrl":"DATATITLECELL","prop":"Class"}]}""");
         setEventMetadata("'DOMOVEUP'","""{"handler":"E14322","iparms":[{"av":"AV12SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV19WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("'DOMOVEDOWN'","""{"handler":"E15322","iparms":[{"av":"AV12SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV19WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE","""{"handler":"E11322","iparms":[{"av":"Dvelop_confirmpanel_btndeleteelement_Result","ctrl":"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT","prop":"Result"},{"av":"AV12SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV19WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE",""","oparms":[{"av":"AV17WWPForm","fld":"vWWPFORM"},{"av":"AV18WWPFormElement","fld":"vWWPFORMELEMENT"}]}""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT","""{"handler":"E13322","iparms":[{"av":"AV19WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV12SessionId","fld":"vSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("SETTINGS_MODAL.CLOSE","""{"handler":"E12322","iparms":[{"av":"FS_nFirstRecordOnPage"},{"av":"FS_nEOF"},{"av":"AV9IsFirstElement","fld":"vISFIRSTELEMENT","hsh":true},{"av":"AV10IsLastElement","fld":"vISLASTELEMENT","hsh":true},{"av":"AV13WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"AV18WWPFormElement","fld":"vWWPFORMELEMENT"},{"av":"AV14WWP_DF_DateMetadata","fld":"vWWP_DF_DATEMETADATA","hsh":true},{"av":"AV24SDT_DynamicFormTranslation","fld":"vSDT_DYNAMICFORMTRANSLATION","hsh":true},{"av":"AV20ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV15WWP_DynamicFormDataType","fld":"vWWP_DYNAMICFORMDATATYPE","pic":"Z9","hsh":true},{"av":"sPrefix"},{"av":"Settings_modal_Result","ctrl":"SETTINGS_MODAL","prop":"Result"},{"av":"AV12SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV19WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV11NeedToReloadWC","fld":"vNEEDTORELOADWC"}]""");
         setEventMetadata("SETTINGS_MODAL.CLOSE",""","oparms":[{"av":"AV17WWPForm","fld":"vWWPFORM"},{"av":"AV18WWPFormElement","fld":"vWWPFORMELEMENT"},{"av":"AV11NeedToReloadWC","fld":"vNEEDTORELOADWC"},{"av":"AV13WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"lblDatatitle_Caption","ctrl":"DATATITLE","prop":"Caption"},{"av":"divDatatitlecell_Visible","ctrl":"DATATITLECELL","prop":"Visible"},{"av":"divDatatitlecell_Class","ctrl":"DATATITLECELL","prop":"Class"},{"av":"Btnmoveup_Visible","ctrl":"BTNMOVEUP","prop":"Visible"},{"av":"Btnmovedown_Visible","ctrl":"BTNMOVEDOWN","prop":"Visible"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Data","iparms":[]}""");
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
         AV17WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         wcpOAV16WWPDynamicFormMode = "";
         Dvelop_confirmpanel_btndeleteelement_Result = "";
         Settings_modal_Result = "";
         AV18WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV13WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV14WWP_DF_DateMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata(context);
         AV24SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         lblDatatitle_Jsonclick = "";
         FsContainer = new GXWebGrid( context);
         sStyleString = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         ucBtnmoveup = new GXUserControl();
         ucBtnmovedown = new GXUserControl();
         ucBtnsettings = new GXUserControl();
         ucBtndeleteelement = new GXUserControl();
         AV7DataName = "";
         AV6DataCellNameClass = "";
         FsRow = new GXWebRow();
         GXt_SdtWWP_Form2 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         GXt_SdtWWP_Form_Element1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         ucSettings_modal = new GXUserControl();
         ucDvelop_confirmpanel_btndeleteelement = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV16WWPDynamicFormMode = "";
         sCtrlAV19WWPFormElementId = "";
         sCtrlAV12SessionId = "";
         sCtrlAV17WWPForm = "";
         subFs_Linesclass = "";
         lblTextblockdata_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         GXCCtl = "";
         subFs_Header = "";
         FsColumn = new GXWebColumn();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV19WWPFormElementId ;
      private short AV12SessionId ;
      private short wcpOAV19WWPFormElementId ;
      private short wcpOAV12SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV15WWP_DynamicFormDataType ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short subFs_Backcolorstyle ;
      private short FS_nEOF ;
      private short AV8i ;
      private short nGXWrapped ;
      private short subFs_Backstyle ;
      private short subFs_Allowselection ;
      private short subFs_Allowhovering ;
      private short subFs_Allowcollapsing ;
      private short subFs_Collapsed ;
      private int nRC_GXsfl_12 ;
      private int subFs_Recordcount ;
      private int nGXsfl_12_idx=1 ;
      private int divDatatitlecell_Visible ;
      private int subFs_Islastpage ;
      private int lblTextblockdata_Visible ;
      private int tblTableactions_Visible ;
      private int idxLst ;
      private int subFs_Backcolor ;
      private int subFs_Allbackcolor ;
      private int subFs_Selectedindex ;
      private int subFs_Selectioncolor ;
      private int subFs_Hoveringcolor ;
      private long FS_nCurrentRecord ;
      private long FS_nFirstRecordOnPage ;
      private string AV16WWPDynamicFormMode ;
      private string wcpOAV16WWPDynamicFormMode ;
      private string Dvelop_confirmpanel_btndeleteelement_Result ;
      private string Settings_modal_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divDatatitlecell_Internalname ;
      private string divDatatitlecell_Class ;
      private string lblDatatitle_Internalname ;
      private string lblDatatitle_Caption ;
      private string lblDatatitle_Jsonclick ;
      private string sStyleString ;
      private string subFs_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavData_Internalname ;
      private string GXDecQS ;
      private string Btnmoveup_Caption ;
      private string Btnmoveup_Internalname ;
      private string Btnmovedown_Caption ;
      private string Btnmovedown_Internalname ;
      private string Btnsettings_Caption ;
      private string Btnsettings_Internalname ;
      private string Btndeleteelement_Caption ;
      private string Btndeleteelement_Internalname ;
      private string Btnmoveup_Tooltiptext ;
      private string Btnmoveup_Beforeiconclass ;
      private string Btnmovedown_Tooltiptext ;
      private string Btnmovedown_Beforeiconclass ;
      private string lblTextblockdata_Caption ;
      private string divDatacellname_Class ;
      private string divDatacellname_Internalname ;
      private string tblTableactions_Internalname ;
      private string tblTablesettings_modal_Internalname ;
      private string Settings_modal_Width ;
      private string Settings_modal_Title ;
      private string Settings_modal_Confirmtype ;
      private string Settings_modal_Bodytype ;
      private string Settings_modal_Internalname ;
      private string tblTabledvelop_confirmpanel_btndeleteelement_Internalname ;
      private string Dvelop_confirmpanel_btndeleteelement_Title ;
      private string Dvelop_confirmpanel_btndeleteelement_Confirmationtext ;
      private string Dvelop_confirmpanel_btndeleteelement_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btndeleteelement_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btndeleteelement_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btndeleteelement_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btndeleteelement_Confirmtype ;
      private string Dvelop_confirmpanel_btndeleteelement_Internalname ;
      private string Btnmoveup_Class ;
      private string Btnmovedown_Class ;
      private string Btndeleteelement_Tooltiptext ;
      private string Btndeleteelement_Beforeiconclass ;
      private string Btndeleteelement_Class ;
      private string Btnsettings_Tooltiptext ;
      private string Btnsettings_Beforeiconclass ;
      private string Btnsettings_Class ;
      private string sCtrlAV16WWPDynamicFormMode ;
      private string sCtrlAV19WWPFormElementId ;
      private string sCtrlAV12SessionId ;
      private string sCtrlAV17WWPForm ;
      private string lblTextblockdata_Internalname ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subFs_Class ;
      private string subFs_Linesclass ;
      private string divFslayouttable_Internalname ;
      private string divUnnamedtabledata_Internalname ;
      private string lblTextblockdata_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string GXCCtl ;
      private string subFs_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV9IsFirstElement ;
      private bool AV10IsLastElement ;
      private bool AV20ParentIsGridMultipleData ;
      private bool AV11NeedToReloadWC ;
      private bool wbLoad ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV5Data ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool Btnmoveup_Visible ;
      private bool Btnmovedown_Visible ;
      private string AV7DataName ;
      private string AV6DataCellNameClass ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid FsContainer ;
      private GXWebRow FsRow ;
      private GXWebColumn FsColumn ;
      private GXUserControl ucBtnmoveup ;
      private GXUserControl ucBtnmovedown ;
      private GXUserControl ucBtnsettings ;
      private GXUserControl ucBtndeleteelement ;
      private GXUserControl ucSettings_modal ;
      private GXUserControl ucDvelop_confirmpanel_btndeleteelement ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV17WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP3_WWPForm ;
      private GXCheckbox chkavData ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV18WWPFormElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV13WWP_DF_CharMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata AV14WWP_DF_DateMetadata ;
      private SdtSDT_DynamicFormTranslation AV24SDT_DynamicFormTranslation ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form2 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element GXt_SdtWWP_Form_Element1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
