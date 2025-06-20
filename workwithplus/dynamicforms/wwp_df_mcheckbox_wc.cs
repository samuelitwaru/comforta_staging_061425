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
   public class wwp_df_mcheckbox_wc : GXWebComponent
   {
      public wwp_df_mcheckbox_wc( )
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

      public wwp_df_mcheckbox_wc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPDynamicFormMode ,
                           short aP1_WWPFormElementId ,
                           short aP2_WWPFormInstanceElementId ,
                           short aP3_SessionId ,
                           ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance )
      {
         this.AV26WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV27WWPFormElementId = aP1_WWPFormElementId;
         this.AV32WWPFormInstanceElementId = aP2_WWPFormInstanceElementId;
         this.AV20SessionId = aP3_SessionId;
         this.AV30WWPFormInstance = aP4_WWPFormInstance;
         ExecuteImpl();
         aP4_WWPFormInstance=this.AV30WWPFormInstance;
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
                  AV26WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV26WWPDynamicFormMode", AV26WWPDynamicFormMode);
                  AV27WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV27WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV27WWPFormElementId), 4, 0));
                  AV32WWPFormInstanceElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV32WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV32WWPFormInstanceElementId), 4, 0));
                  AV20SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV20SessionId", StringUtil.LTrimStr( (decimal)(AV20SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV30WWPFormInstance);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV26WWPDynamicFormMode,(short)AV27WWPFormElementId,(short)AV32WWPFormInstanceElementId,(short)AV20SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV30WWPFormInstance});
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
         edtavDataname_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavDataname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDataname_Visible), 5, 0), !bGXsfl_12_Refreshing);
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
         edtavDataname_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavDataname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDataname_Visible), 5, 0), !bGXsfl_12_Refreshing);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV25WWP_DF_CharMetadata);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV34DataCollection);
         AV5WWPFormElementCaption = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementCaption"), "."), 18, MidpointRounding.ToEven));
         AV29WWPFormElementTitle = GetPar( "WWPFormElementTitle");
         AV10DataEnabled = StringUtil.StrToBool( GetPar( "DataEnabled"));
         AV11ElementInternalName = GetPar( "ElementInternalName");
         AV13HasReferenceId = StringUtil.StrToBool( GetPar( "HasReferenceId"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFs_refresh( AV25WWP_DF_CharMetadata, AV34DataCollection, AV5WWPFormElementCaption, AV29WWPFormElementTitle, AV10DataEnabled, AV11ElementInternalName, AV13HasReferenceId, sPrefix) ;
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
            PA2K2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS2K2( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form_Multiple Check Box_WC", "")) ;
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
            if ( nGXWrapped != 1 )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_mcheckbox_wc.aspx"+UrlEncode(StringUtil.RTrim(AV26WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV27WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV32WWPFormInstanceElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV20SessionId,4,0));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_mcheckbox_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV25WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV25WWP_DF_CharMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_CHARMETADATA", GetSecureSignedToken( sPrefix, AV25WWP_DF_CharMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTCAPTION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPFormElementCaption), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTCAPTION", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5WWPFormElementCaption), "9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV29WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV29WWPFormElementTitle, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDATAENABLED", AV10DataEnabled);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDATAENABLED", GetSecureSignedToken( sPrefix, AV10DataEnabled, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vELEMENTINTERNALNAME", AV11ElementInternalName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vELEMENTINTERNALNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV11ElementInternalName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV13HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV26WWPDynamicFormMode", StringUtil.RTrim( wcpOAV26WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV27WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV27WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV32WWPFormInstanceElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV32WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV20SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV20SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV25WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV25WWP_DF_CharMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_CHARMETADATA", GetSecureSignedToken( sPrefix, AV25WWP_DF_CharMetadata, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDATACOLLECTION", AV34DataCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDATACOLLECTION", AV34DataCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTCAPTION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPFormElementCaption), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTCAPTION", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5WWPFormElementCaption), "9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV29WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV29WWPFormElementTitle, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDATAENABLED", AV10DataEnabled);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDATAENABLED", GetSecureSignedToken( sPrefix, AV10DataEnabled, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vERRORIDS", AV38ErrorIds);
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6AuxSessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vEXISTELEMENT", AV12ExistElement);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV30WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV30WWPFormInstance);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vELEMENTINTERNALNAME", AV11ElementInternalName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vELEMENTINTERNALNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV11ElementInternalName, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCEELEMENT", AV31WWPFormInstanceElement);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCEELEMENT", AV31WWPFormInstanceElement);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVISIBLECONDITION", AV23VisibleCondition);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVISIBLECONDITION", AV23VisibleCondition);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV13HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV26WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"subFs_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFs_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDATANAME_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDataname_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
      }

      protected void RenderHtmlCloseForm2K2( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "WorkWithPlus.DynamicForms.WWP_DF_MCheckBox_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form_Multiple Check Box_WC", "") ;
      }

      protected void WB2K0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_mcheckbox_wc.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatatitlecell_Internalname, divDatatitlecell_Visible, 0, "px", 0, "px", divDatatitlecell_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDatatitle_Internalname, lblDatatitle_Caption, "", "", lblDatatitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_MCheckBox_WC.htm");
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

      protected void START2K2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form_Multiple Check Box_WC", ""), 0) ;
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
               STRUP2K0( ) ;
            }
         }
      }

      protected void WS2K2( )
      {
         START2K2( ) ;
         EVT2K2( ) ;
      }

      protected void EVT2K2( )
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
                                 STRUP2K0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_VALIDATE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E112K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E122K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavData_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "FS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "VDATA.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "VDATA.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2K0( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              AV8Data = StringUtil.StrToBool( cgiGet( chkavData_Internalname));
                              AssignAttri(sPrefix, false, chkavData_Internalname, AV8Data);
                              AV33DataName = cgiGet( edtavDataname_Internalname);
                              AssignAttri(sPrefix, false, edtavDataname_Internalname, AV33DataName);
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
                                          GX_FocusControl = chkavData_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E132K2 ();
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
                                          GX_FocusControl = chkavData_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Fs.Load */
                                          E142K2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDATA.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavData_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E152K2 ();
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
                                       STRUP2K0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavData_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2K2( ) ;
            }
         }
      }

      protected void PA2K2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_mcheckbox_wc.aspx")), "workwithplus.dynamicforms.wwp_df_mcheckbox_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_mcheckbox_wc.aspx")))) ;
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

      protected void gxgrFs_refresh( WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV25WWP_DF_CharMetadata ,
                                     GxSimpleCollection<string> AV34DataCollection ,
                                     short AV5WWPFormElementCaption ,
                                     string AV29WWPFormElementTitle ,
                                     bool AV10DataEnabled ,
                                     string AV11ElementInternalName ,
                                     bool AV13HasReferenceId ,
                                     string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FS_nCurrentRecord = 0;
         RF2K2( ) ;
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
         RF2K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FsContainer.ClearRows();
         }
         wbStart = 12;
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
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            /* Execute user event: Fs.Load */
            E142K2 ();
            wbEnd = 12;
            WB2K0( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2K2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV25WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV25WWP_DF_CharMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_CHARMETADATA", GetSecureSignedToken( sPrefix, AV25WWP_DF_CharMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTCAPTION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPFormElementCaption), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTCAPTION", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5WWPFormElementCaption), "9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV29WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV29WWPFormElementTitle, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDATAENABLED", AV10DataEnabled);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDATAENABLED", GetSecureSignedToken( sPrefix, AV10DataEnabled, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vELEMENTINTERNALNAME", AV11ElementInternalName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vELEMENTINTERNALNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV11ElementInternalName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV13HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
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

      protected void STRUP2K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E132K2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV26WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV26WWPDynamicFormMode");
            wcpOAV27WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV27WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV32WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV32WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV20SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV20SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subFs_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subFs_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            divLayoutmaintable_Class = cgiGet( sPrefix+"LAYOUTMAINTABLE_Class");
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
         E132K2 ();
         if (returnInSub) return;
      }

      protected void E132K2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV39SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformid = AV30WWPFormInstance.gxTpr_Wwpformid;
         AV39SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformversionnumber = AV30WWPFormInstance.gxTpr_Wwpformversionnumber;
         AV39SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationwwpformelementid = AV27WWPFormElementId;
         new prc_getdynamicformtranslation(context ).execute( ref  AV39SDT_DynamicFormTranslation) ;
         AV15IsElementFocusable = true;
         AV13HasReferenceId = false;
         AssignAttri(sPrefix, false, "AV13HasReferenceId", AV13HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV30WWPFormInstance.gxTpr_Element.Count )
         {
            AV31WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV30WWPFormInstance.gxTpr_Element.Item(AV40GXV1));
            if ( ( AV31WWPFormInstanceElement.gxTpr_Wwpformelementid == AV27WWPFormElementId ) && ( AV31WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV32WWPFormInstanceElementId ) )
            {
               AV7CurrentWWPFormInstanceElement = AV31WWPFormInstanceElement;
               AV13HasReferenceId = (bool)((!String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV31WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid)))));
               AssignAttri(sPrefix, false, "AV13HasReferenceId", AV13HasReferenceId);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV13HasReferenceId, context));
               AV29WWPFormElementTitle = AV31WWPFormInstanceElement.gxTpr_Wwpformelementtitle;
               AssignAttri(sPrefix, false, "AV29WWPFormElementTitle", AV29WWPFormElementTitle);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV29WWPFormElementTitle, context));
               AV28WWPFormElementMetadata = AV31WWPFormInstanceElement.gxTpr_Wwpformelementmetadata;
               AssignAttri(sPrefix, false, "AV28WWPFormElementMetadata", AV28WWPFormElementMetadata);
               AV5WWPFormElementCaption = AV31WWPFormInstanceElement.gxTpr_Wwpformelementcaption;
               AssignAttri(sPrefix, false, "AV5WWPFormElementCaption", StringUtil.Str( (decimal)(AV5WWPFormElementCaption), 1, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTCAPTION", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5WWPFormElementCaption), "9"), context));
               if (true) break;
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
         /* Execute user subroutine: 'LOAD TITLE AND METADATA' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GET DATA FROM CURRENT ELEMENT' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATE VISIBILITY' */
         S122 ();
         if (returnInSub) return;
         if ( AV15IsElementFocusable && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Table") == 0 ) && ( StringUtil.StrCmp(AV24WebSession.Get("WWPDynFormSetFocus"), "") != 0 ) )
         {
            /* Execute user subroutine: 'SET FOCUS TO ELEMENT' */
            S132 ();
            if (returnInSub) return;
            AV24WebSession.Remove("WWPDynFormSetFocus");
         }
         if ( ( StringUtil.StrCmp(AV26WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV26WWPDynamicFormMode, "DLT") != 0 ) )
         {
            AV10DataEnabled = true;
            AssignAttri(sPrefix, false, "AV10DataEnabled", AV10DataEnabled);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDATAENABLED", GetSecureSignedToken( sPrefix, AV10DataEnabled, context));
         }
         edtavDataname_Visible = 0;
         AssignProp(sPrefix, false, edtavDataname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDataname_Visible), 5, 0), !bGXsfl_12_Refreshing);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue)) )
         {
            lblDatatitle_Caption = AV29WWPFormElementTitle;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
         }
         else
         {
            lblDatatitle_Caption = AV39SDT_DynamicFormTranslation.gxTpr_Dynamicformtranslationvalue;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
         }
         divDatatitlecell_Visible = 1;
         AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
      }

      private void E142K2( )
      {
         /* Fs_Load Routine */
         returnInSub = false;
         AV14i = 1;
         while ( AV14i <= AV25WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Options.Count )
         {
            AV33DataName = ((string)AV25WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Options.Item(AV14i));
            AssignAttri(sPrefix, false, edtavDataname_Internalname, AV33DataName);
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "CheckBox_SetTitle", new Object[] {(string)chkavData_Internalname,(string)AV33DataName}, false);
            AV8Data = false;
            AssignAttri(sPrefix, false, chkavData_Internalname, AV8Data);
            if ( AV34DataCollection.IndexOf(AV33DataName) > 0 )
            {
               AV8Data = true;
               AssignAttri(sPrefix, false, chkavData_Internalname, AV8Data);
            }
            lblTextblockdata_Caption = "";
            if ( AV5WWPFormElementCaption != 1 )
            {
               AV9DataCellNameClass = "DataContentCell DataContentCellNoLabel";
            }
            else
            {
               AV9DataCellNameClass = "DataContentCell DscTop";
               if ( AV14i == 1 )
               {
                  if ( AV25WWP_DF_CharMetadata.gxTpr_Isrequired )
                  {
                     AV9DataCellNameClass = "Required" + AV9DataCellNameClass;
                  }
                  lblTextblockdata_Caption = AV29WWPFormElementTitle;
               }
               else
               {
                  lblTextblockdata_Visible = 0;
               }
            }
            divDatacellname_Class = AV9DataCellNameClass;
            AssignProp(sPrefix, false, divDatacellname_Internalname, "Class", divDatacellname_Class, !bGXsfl_12_Refreshing);
            divDatatitlecell_Class = AV9DataCellNameClass;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Class", divDatatitlecell_Class, true);
            chkavData.Enabled = (AV10DataEnabled ? 1 : 0);
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
            AV14i = (short)(AV14i+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E112K2( )
      {
         /* General\GlobalEvents_Dynamicform_validate Routine */
         returnInSub = false;
         if ( ( AV6AuxSessionId == AV20SessionId ) && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Invisible") != 0 ) && StringUtil.Contains( AV38ErrorIds, "|"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27WWPFormElementId), 4, 0))+"."+StringUtil.Trim( StringUtil.Str( (decimal)(AV32WWPFormInstanceElementId), 4, 0))+"|") )
         {
            /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
            S142 ();
            if (returnInSub) return;
            if ( AV12ExistElement )
            {
               /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
               S152 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31WWPFormInstanceElement", AV31WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30WWPFormInstance", AV30WWPFormInstance);
      }

      protected void E122K2( )
      {
         /* General\GlobalEvents_Dynamicform_updatevisibilities Routine */
         returnInSub = false;
         if ( ( AV6AuxSessionId == AV20SessionId ) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV23VisibleCondition.gxTpr_Expression))) )
         {
            /* Execute user subroutine: 'GET FORM INSTANCE' */
            S162 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'UPDATE VISIBILITY' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30WWPFormInstance", AV30WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23VisibleCondition", AV23VisibleCondition);
      }

      protected void S162( )
      {
         /* 'GET FORM INSTANCE' Routine */
         returnInSub = false;
         GXt_SdtWWP_FormInstance1 = AV30WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV20SessionId, out  GXt_SdtWWP_FormInstance1) ;
         AV30WWPFormInstance = GXt_SdtWWP_FormInstance1;
      }

      protected void S112( )
      {
         /* 'GET DATA FROM CURRENT ELEMENT' Routine */
         returnInSub = false;
         AV34DataCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar)) )
         {
            AV34DataCollection.FromJSonString(AV7CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar, null);
         }
      }

      protected void S142( )
      {
         /* 'SAVE ELEMENT DATA TO SESSION' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GET FORM INSTANCE' */
         S162 ();
         if (returnInSub) return;
         AV12ExistElement = false;
         AssignAttri(sPrefix, false, "AV12ExistElement", AV12ExistElement);
         AV41GXV2 = 1;
         while ( AV41GXV2 <= AV30WWPFormInstance.gxTpr_Element.Count )
         {
            AV31WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV30WWPFormInstance.gxTpr_Element.Item(AV41GXV2));
            if ( ( AV31WWPFormInstanceElement.gxTpr_Wwpformelementid == AV27WWPFormElementId ) && ( AV31WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV32WWPFormInstanceElementId ) )
            {
               AV12ExistElement = true;
               AssignAttri(sPrefix, false, "AV12ExistElement", AV12ExistElement);
               if (true) break;
            }
            AV41GXV2 = (int)(AV41GXV2+1);
         }
         if ( AV12ExistElement )
         {
            /* Execute user subroutine: 'SET DATA TO ELEMENT' */
            S172 ();
            if (returnInSub) return;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV20SessionId,  AV30WWPFormInstance) ;
         }
      }

      protected void S172( )
      {
         /* 'SET DATA TO ELEMENT' Routine */
         returnInSub = false;
         AV31WWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar = ((AV34DataCollection.Count>0) ? AV34DataCollection.ToJSonString(false) : "");
      }

      protected void S122( )
      {
         /* 'UPDATE VISIBILITY' Routine */
         returnInSub = false;
         AV23VisibleCondition = AV25WWP_DF_CharMetadata.gxTpr_Visiblecondition;
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV30WWPFormInstance,  AV32WWPFormInstanceElementId,  AV23VisibleCondition) )
         {
            divLayoutmaintable_Class = "Table";
            AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         }
         else
         {
            divLayoutmaintable_Class = "Invisible";
            AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         }
      }

      protected void S152( )
      {
         /* 'EXECUTE VALIDATIONS' Routine */
         returnInSub = false;
         AV16IsRequired = AV25WWP_DF_CharMetadata.gxTpr_Isrequired;
         AV22Validations = AV25WWP_DF_CharMetadata.gxTpr_Validations;
         AV21ThisValueStr = "''";
         if ( AV34DataCollection.Count > 0 )
         {
            AV21ThisValueStr = StringUtil.Format( "'%1'", StringUtil.StringReplace( AV34DataCollection.ToJSonString(false), "'", ""), "", "", "", "", "", "", "", "");
         }
         AV17IsValid = true;
         if ( AV16IsRequired && ( StringUtil.StrCmp(StringUtil.Trim( AV21ThisValueStr), "''") == 0 ) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), AV29WWPFormElementTitle, "", "", "", "", "", "", "", ""),  "error",  AV11ElementInternalName,  "true",  ""));
            AV17IsValid = false;
         }
         else
         {
            if ( AV22Validations.Count > 0 )
            {
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_executeelementvalidations(context ).execute(  AV30WWPFormInstance,  AV32WWPFormInstanceElementId,  AV21ThisValueStr,  AV22Validations, out  AV19Messages) ;
               AV42GXV3 = 1;
               while ( AV42GXV3 <= AV19Messages.Count )
               {
                  AV18Message = ((GeneXus.Utils.SdtMessages_Message)AV19Messages.Item(AV42GXV3));
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV18Message.gxTpr_Description,  ((AV18Message.gxTpr_Type==1) ? "error" : "info"),  AV11ElementInternalName,  "true",  ""));
                  if ( AV18Message.gxTpr_Type == 1 )
                  {
                     AV17IsValid = false;
                     if (true) break;
                  }
                  AV42GXV3 = (int)(AV42GXV3+1);
               }
            }
         }
      }

      protected void S182( )
      {
         /* 'LOAD TITLE AND METADATA' Routine */
         returnInSub = false;
         AV5WWPFormElementCaption = 0;
         AssignAttri(sPrefix, false, "AV5WWPFormElementCaption", StringUtil.Str( (decimal)(AV5WWPFormElementCaption), 1, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTCAPTION", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5WWPFormElementCaption), "9"), context));
         if ( AV5WWPFormElementCaption == 2 )
         {
            lblDatatitle_Caption = AV29WWPFormElementTitle;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
            divDatatitlecell_Visible = 1;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         else
         {
            divDatatitlecell_Visible = 0;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         AV9DataCellNameClass = "DataContentCell DscTop";
         if ( AV5WWPFormElementCaption != 1 )
         {
            AV9DataCellNameClass += " DataContentCellNoLabel";
         }
         AV25WWP_DF_CharMetadata.FromJSonString(AV28WWPFormElementMetadata, null);
         divDatatitlecell_Visible = 0;
         AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
      }

      protected void S132( )
      {
         /* 'SET FOCUS TO ELEMENT' Routine */
         returnInSub = false;
         GX_FocusControl = chkavData_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
      }

      protected void E152K2( )
      {
         /* Data_Click Routine */
         returnInSub = false;
         if ( AV8Data )
         {
            AV34DataCollection.Add(AV33DataName, 0);
         }
         else
         {
            AV35DataIndex = (short)(AV34DataCollection.IndexOf(AV33DataName));
            AV34DataCollection.RemoveItem(AV35DataIndex);
         }
         /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
         S142 ();
         if (returnInSub) return;
         if ( AV13HasReferenceId )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "DynamicForm_UpdateVisibilities", new Object[] {(short)AV20SessionId}, true);
         }
         /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34DataCollection", AV34DataCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31WWPFormInstanceElement", AV31WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30WWPFormInstance", AV30WWPFormInstance);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV26WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV26WWPDynamicFormMode", AV26WWPDynamicFormMode);
         AV27WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV27WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV27WWPFormElementId), 4, 0));
         AV32WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV32WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV32WWPFormInstanceElementId), 4, 0));
         AV20SessionId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV20SessionId", StringUtil.LTrimStr( (decimal)(AV20SessionId), 4, 0));
         AV30WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,4);
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
         PA2K2( ) ;
         WS2K2( ) ;
         WE2K2( ) ;
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
         sCtrlAV26WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV27WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV32WWPFormInstanceElementId = (string)((string)getParm(obj,2));
         sCtrlAV20SessionId = (string)((string)getParm(obj,3));
         sCtrlAV30WWPFormInstance = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2K2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_mcheckbox_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2K2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV26WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV26WWPDynamicFormMode", AV26WWPDynamicFormMode);
            AV27WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV27WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV27WWPFormElementId), 4, 0));
            AV32WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV32WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV32WWPFormInstanceElementId), 4, 0));
            AV20SessionId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV20SessionId", StringUtil.LTrimStr( (decimal)(AV20SessionId), 4, 0));
            AV30WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,6);
         }
         wcpOAV26WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV26WWPDynamicFormMode");
         wcpOAV27WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV27WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV32WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV32WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV20SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV20SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV26WWPDynamicFormMode, wcpOAV26WWPDynamicFormMode) != 0 ) || ( AV27WWPFormElementId != wcpOAV27WWPFormElementId ) || ( AV32WWPFormInstanceElementId != wcpOAV32WWPFormInstanceElementId ) || ( AV20SessionId != wcpOAV20SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV26WWPDynamicFormMode = AV26WWPDynamicFormMode;
         wcpOAV27WWPFormElementId = AV27WWPFormElementId;
         wcpOAV32WWPFormInstanceElementId = AV32WWPFormInstanceElementId;
         wcpOAV20SessionId = AV20SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV26WWPDynamicFormMode = cgiGet( sPrefix+"AV26WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV26WWPDynamicFormMode) > 0 )
         {
            AV26WWPDynamicFormMode = cgiGet( sCtrlAV26WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV26WWPDynamicFormMode", AV26WWPDynamicFormMode);
         }
         else
         {
            AV26WWPDynamicFormMode = cgiGet( sPrefix+"AV26WWPDynamicFormMode_PARM");
         }
         sCtrlAV27WWPFormElementId = cgiGet( sPrefix+"AV27WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV27WWPFormElementId) > 0 )
         {
            AV27WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV27WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV27WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV27WWPFormElementId), 4, 0));
         }
         else
         {
            AV27WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV27WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV32WWPFormInstanceElementId = cgiGet( sPrefix+"AV32WWPFormInstanceElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV32WWPFormInstanceElementId) > 0 )
         {
            AV32WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV32WWPFormInstanceElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV32WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV32WWPFormInstanceElementId), 4, 0));
         }
         else
         {
            AV32WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV32WWPFormInstanceElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV20SessionId = cgiGet( sPrefix+"AV20SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV20SessionId) > 0 )
         {
            AV20SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV20SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV20SessionId", StringUtil.LTrimStr( (decimal)(AV20SessionId), 4, 0));
         }
         else
         {
            AV20SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV20SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV30WWPFormInstance = cgiGet( sPrefix+"AV30WWPFormInstance_CTRL");
         if ( StringUtil.Len( sCtrlAV30WWPFormInstance) > 0 )
         {
            AV30WWPFormInstance.FromXml(cgiGet( sCtrlAV30WWPFormInstance), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV30WWPFormInstance_PARM"), AV30WWPFormInstance);
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
         PA2K2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2K2( ) ;
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
         WS2K2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV26WWPDynamicFormMode_PARM", StringUtil.RTrim( AV26WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV26WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV26WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV26WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV27WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV27WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV27WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV27WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV32WWPFormInstanceElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV32WWPFormInstanceElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV32WWPFormInstanceElementId_CTRL", StringUtil.RTrim( sCtrlAV32WWPFormInstanceElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20SessionId_CTRL", StringUtil.RTrim( sCtrlAV20SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV30WWPFormInstance_PARM", AV30WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV30WWPFormInstance_PARM", AV30WWPFormInstance);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV30WWPFormInstance)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV30WWPFormInstance_CTRL", StringUtil.RTrim( sCtrlAV30WWPFormInstance));
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
         WE2K2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562016572547", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_mcheckbox_wc.js", "?202562016572547", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         lblTextblockdata_Internalname = sPrefix+"TEXTBLOCKDATA_"+sGXsfl_12_idx;
         chkavData_Internalname = sPrefix+"vDATA_"+sGXsfl_12_idx;
         edtavDataname_Internalname = sPrefix+"vDATANAME_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         lblTextblockdata_Internalname = sPrefix+"TEXTBLOCKDATA_"+sGXsfl_12_fel_idx;
         chkavData_Internalname = sPrefix+"vDATA_"+sGXsfl_12_fel_idx;
         edtavDataname_Internalname = sPrefix+"vDATANAME_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         WB2K0( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',12)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GXCCtl = "vDATA_" + sGXsfl_12_idx;
         chkavData.Name = GXCCtl;
         chkavData.WebTags = "";
         chkavData.Caption = context.GetMessage( "Data", "");
         AssignProp(sPrefix, false, chkavData_Internalname, "TitleCaption", chkavData.Caption, !bGXsfl_12_Refreshing);
         chkavData.CheckedValue = "false";
         FsRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavData_Internalname,StringUtil.BoolToStr( AV8Data),(string)"",context.GetMessage( "Data", ""),(short)1,chkavData.Enabled,(string)"true",context.GetMessage( "Data", ""),(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onblur=\""+""+";gx.evt.onblur(this,22);\""});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         FsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         FsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfs_Internalname+"_"+sGXsfl_12_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         FsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         FsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavDataname_Internalname,context.GetMessage( "Data Name", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',12)\"";
         ROClassString = "Attribute";
         FsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDataname_Internalname,(string)AV33DataName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDataname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavDataname_Visible,(short)1,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)150,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( FsContainer.GetWrapped() == 1 )
         {
            FsContainer.CloseTag("cell");
         }
         if ( FsContainer.GetWrapped() == 1 )
         {
            FsContainer.CloseTag("row");
         }
         if ( FsContainer.GetWrapped() == 1 )
         {
            FsContainer.CloseTag("table");
         }
         /* End of table */
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2K2( ) ;
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
            FsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV8Data)));
            FsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavData.Enabled), 5, 0, ".", "")));
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
            FsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV33DataName));
            FsColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDataname_Visible), 5, 0, ".", "")));
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
         edtavDataname_Internalname = sPrefix+"vDATANAME";
         tblUnnamedtablecontentfsfs_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSFS";
         divFslayouttable_Internalname = sPrefix+"FSLAYOUTTABLE";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         edtavDataname_Jsonclick = "";
         chkavData.Caption = context.GetMessage( "Data", "");
         chkavData.Enabled = 1;
         lblTextblockdata_Caption = "";
         lblTextblockdata_Visible = 1;
         subFs_Class = "FreeStyleGrid";
         divDatacellname_Class = "col-xs-12 DataContentCell DscTop";
         subFs_Backcolorstyle = 0;
         lblDatatitle_Caption = context.GetMessage( "Title", "");
         divDatatitlecell_Class = "col-xs-12";
         divDatatitlecell_Visible = 1;
         divLayoutmaintable_Class = "Table";
         edtavDataname_Visible = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FS_nFirstRecordOnPage"},{"av":"FS_nEOF"},{"av":"edtavDataname_Visible","ctrl":"vDATANAME","prop":"Visible"},{"av":"AV34DataCollection","fld":"vDATACOLLECTION"},{"av":"sPrefix"},{"av":"AV25WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV5WWPFormElementCaption","fld":"vWWPFORMELEMENTCAPTION","pic":"9","hsh":true},{"av":"AV29WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV10DataEnabled","fld":"vDATAENABLED","hsh":true},{"av":"AV11ElementInternalName","fld":"vELEMENTINTERNALNAME","hsh":true},{"av":"AV13HasReferenceId","fld":"vHASREFERENCEID","hsh":true}]}""");
         setEventMetadata("FS.LOAD","""{"handler":"E142K2","iparms":[{"av":"AV25WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV34DataCollection","fld":"vDATACOLLECTION"},{"av":"AV5WWPFormElementCaption","fld":"vWWPFORMELEMENTCAPTION","pic":"9","hsh":true},{"av":"AV29WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV10DataEnabled","fld":"vDATAENABLED","hsh":true}]""");
         setEventMetadata("FS.LOAD",""","oparms":[{"av":"AV33DataName","fld":"vDATANAME"},{"av":"AV8Data","fld":"vDATA"},{"av":"lblTextblockdata_Caption","ctrl":"TEXTBLOCKDATA","prop":"Caption"},{"av":"lblTextblockdata_Visible","ctrl":"TEXTBLOCKDATA","prop":"Visible"},{"av":"divDatacellname_Class","ctrl":"DATACELLNAME","prop":"Class"},{"av":"divDatatitlecell_Class","ctrl":"DATATITLECELL","prop":"Class"},{"av":"chkavData.Enabled","ctrl":"vDATA","prop":"Enabled"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE","""{"handler":"E112K2","iparms":[{"av":"AV38ErrorIds","fld":"vERRORIDS"},{"av":"AV6AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV20SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"},{"av":"AV27WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV32WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV12ExistElement","fld":"vEXISTELEMENT"},{"av":"AV30WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV25WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV34DataCollection","fld":"vDATACOLLECTION"},{"av":"AV29WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV11ElementInternalName","fld":"vELEMENTINTERNALNAME","hsh":true},{"av":"AV31WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE",""","oparms":[{"av":"AV12ExistElement","fld":"vEXISTELEMENT"},{"av":"AV31WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV30WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES","""{"handler":"E122K2","iparms":[{"av":"AV6AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV20SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV23VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"AV25WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV32WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV30WWPFormInstance","fld":"vWWPFORMINSTANCE"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",""","oparms":[{"av":"AV30WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV23VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"}]}""");
         setEventMetadata("VDATA.CLICK","""{"handler":"E152K2","iparms":[{"av":"AV8Data","fld":"vDATA"},{"av":"AV33DataName","fld":"vDATANAME"},{"av":"AV34DataCollection","fld":"vDATACOLLECTION"},{"av":"AV13HasReferenceId","fld":"vHASREFERENCEID","hsh":true},{"av":"AV20SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV30WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV27WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV32WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV25WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV29WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV11ElementInternalName","fld":"vELEMENTINTERNALNAME","hsh":true},{"av":"AV31WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("VDATA.CLICK",""","oparms":[{"av":"AV34DataCollection","fld":"vDATACOLLECTION"},{"av":"AV12ExistElement","fld":"vEXISTELEMENT"},{"av":"AV31WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV30WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Dataname","iparms":[]}""");
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
         AV30WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         wcpOAV26WWPDynamicFormMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV25WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV34DataCollection = new GxSimpleCollection<string>();
         AV29WWPFormElementTitle = "";
         AV11ElementInternalName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV38ErrorIds = "";
         AV31WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV23VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         GX_FocusControl = "";
         lblDatatitle_Jsonclick = "";
         FsContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV33DataName = "";
         GXDecQS = "";
         AV39SDT_DynamicFormTranslation = new SdtSDT_DynamicFormTranslation(context);
         AV7CurrentWWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV28WWPFormElementMetadata = "";
         AV24WebSession = context.GetSession();
         AV9DataCellNameClass = "";
         FsRow = new GXWebRow();
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV22Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version2");
         AV21ThisValueStr = "";
         AV19Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV18Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV26WWPDynamicFormMode = "";
         sCtrlAV27WWPFormElementId = "";
         sCtrlAV32WWPFormInstanceElementId = "";
         sCtrlAV20SessionId = "";
         sCtrlAV30WWPFormInstance = "";
         subFs_Linesclass = "";
         lblTextblockdata_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         GXCCtl = "";
         ROClassString = "";
         subFs_Header = "";
         FsColumn = new GXWebColumn();
         /* GeneXus formulas. */
      }

      private short AV27WWPFormElementId ;
      private short AV32WWPFormInstanceElementId ;
      private short AV20SessionId ;
      private short wcpOAV27WWPFormElementId ;
      private short wcpOAV32WWPFormInstanceElementId ;
      private short wcpOAV20SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV5WWPFormElementCaption ;
      private short nGXWrapped ;
      private short AV6AuxSessionId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subFs_Backcolorstyle ;
      private short AV14i ;
      private short AV35DataIndex ;
      private short subFs_Backstyle ;
      private short subFs_Allowselection ;
      private short subFs_Allowhovering ;
      private short subFs_Allowcollapsing ;
      private short subFs_Collapsed ;
      private short FS_nEOF ;
      private int edtavDataname_Visible ;
      private int nRC_GXsfl_12 ;
      private int subFs_Recordcount ;
      private int nGXsfl_12_idx=1 ;
      private int divDatatitlecell_Visible ;
      private int subFs_Islastpage ;
      private int AV40GXV1 ;
      private int lblTextblockdata_Visible ;
      private int AV41GXV2 ;
      private int AV42GXV3 ;
      private int idxLst ;
      private int subFs_Backcolor ;
      private int subFs_Allbackcolor ;
      private int subFs_Selectedindex ;
      private int subFs_Selectioncolor ;
      private int subFs_Hoveringcolor ;
      private long FS_nCurrentRecord ;
      private long FS_nFirstRecordOnPage ;
      private string AV26WWPDynamicFormMode ;
      private string wcpOAV26WWPDynamicFormMode ;
      private string divLayoutmaintable_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string edtavDataname_Internalname ;
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
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavData_Internalname ;
      private string GXDecQS ;
      private string lblTextblockdata_Caption ;
      private string divDatacellname_Class ;
      private string divDatacellname_Internalname ;
      private string sCtrlAV26WWPDynamicFormMode ;
      private string sCtrlAV27WWPFormElementId ;
      private string sCtrlAV32WWPFormInstanceElementId ;
      private string sCtrlAV20SessionId ;
      private string sCtrlAV30WWPFormInstance ;
      private string lblTextblockdata_Internalname ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subFs_Class ;
      private string subFs_Linesclass ;
      private string divFslayouttable_Internalname ;
      private string divUnnamedtabledata_Internalname ;
      private string lblTextblockdata_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string GXCCtl ;
      private string tblUnnamedtablecontentfsfs_Internalname ;
      private string ROClassString ;
      private string edtavDataname_Jsonclick ;
      private string subFs_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool AV10DataEnabled ;
      private bool AV13HasReferenceId ;
      private bool AV12ExistElement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV8Data ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV15IsElementFocusable ;
      private bool AV16IsRequired ;
      private bool AV17IsValid ;
      private string AV29WWPFormElementTitle ;
      private string AV28WWPFormElementMetadata ;
      private string AV11ElementInternalName ;
      private string AV38ErrorIds ;
      private string AV33DataName ;
      private string AV9DataCellNameClass ;
      private string AV21ThisValueStr ;
      private IGxSession AV24WebSession ;
      private GXWebGrid FsContainer ;
      private GXWebRow FsRow ;
      private GXWebColumn FsColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV30WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance ;
      private GXCheckbox chkavData ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV25WWP_DF_CharMetadata ;
      private GxSimpleCollection<string> AV34DataCollection ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV31WWPFormInstanceElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV23VisibleCondition ;
      private SdtSDT_DynamicFormTranslation AV39SDT_DynamicFormTranslation ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV7CurrentWWPFormInstanceElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV22Validations ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV19Messages ;
      private GeneXus.Utils.SdtMessages_Message AV18Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
