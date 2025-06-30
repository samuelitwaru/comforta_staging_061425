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
   public class wwp_df_mdataplain_wc : GXWebComponent
   {
      public wwp_df_mdataplain_wc( )
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

      public wwp_df_mdataplain_wc( IGxContext context )
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
         this.AV13WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV14WWPFormElementId = aP1_WWPFormElementId;
         this.AV20WWPFormInstanceElementId = aP2_WWPFormInstanceElementId;
         this.AV11SessionId = aP3_SessionId;
         this.AV5WWPFormInstance = aP4_WWPFormInstance;
         ExecuteImpl();
         aP4_WWPFormInstance=this.AV5WWPFormInstance;
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
                  AV13WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV13WWPDynamicFormMode", AV13WWPDynamicFormMode);
                  AV14WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV14WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV14WWPFormElementId), 4, 0));
                  AV20WWPFormInstanceElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV20WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV20WWPFormInstanceElementId), 4, 0));
                  AV11SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV11SessionId", StringUtil.LTrimStr( (decimal)(AV11SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV5WWPFormInstance);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV13WWPDynamicFormMode,(short)AV14WWPFormElementId,(short)AV20WWPFormInstanceElementId,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV5WWPFormInstance});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fsgrid") == 0 )
               {
                  gxnrFsgrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fsgrid") == 0 )
               {
                  gxgrFsgrid_refresh_invoke( ) ;
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

      protected void gxnrFsgrid_newrow_invoke( )
      {
         nRC_GXsfl_9 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_9"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_9_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_9_idx = GetPar( "sGXsfl_9_idx");
         sPrefix = GetPar( "sPrefix");
         edtavWwpforminstanceelementidchild_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpforminstanceelementidchild_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpforminstanceelementidchild_Visible), 5, 0), !bGXsfl_9_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFsgrid_newrow( ) ;
         /* End function gxnrFsgrid_newrow_invoke */
      }

      protected void gxgrFsgrid_refresh_invoke( )
      {
         AV9MultipleDataRepetitions = (short)(Math.Round(NumberUtil.Val( GetPar( "MultipleDataRepetitions"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV12WWP_DF_ElementsRepeaterMetadata);
         AV13WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
         edtavWwpforminstanceelementidchild_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpforminstanceelementidchild_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpforminstanceelementidchild_Visible), 5, 0), !bGXsfl_9_Refreshing);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10MultipleDataWWPFormInstanceElementId);
         AV24IsGroupAsMainChild = StringUtil.StrToBool( GetPar( "IsGroupAsMainChild"));
         AV14WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
         AV11SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5WWPFormInstance);
         A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
         A207WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
         A211WWPFormElementParentId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementParentId"), "."), 18, MidpointRounding.ToEven));
         n211WWPFormElementParentId = false;
         A217WWPFormElementType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementType"), "."), 18, MidpointRounding.ToEven));
         AV15WWPFormElementIdSimpleChildren = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementIdSimpleChildren"), "."), 18, MidpointRounding.ToEven));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFsgrid_refresh( AV9MultipleDataRepetitions, AV12WWP_DF_ElementsRepeaterMetadata, AV13WWPDynamicFormMode, AV10MultipleDataWWPFormInstanceElementId, AV24IsGroupAsMainChild, AV14WWPFormElementId, AV11SessionId, AV5WWPFormInstance, A206WWPFormId, A207WWPFormVersionNumber, A211WWPFormElementParentId, A217WWPFormElementType, AV15WWPFormElementIdSimpleChildren, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFsgrid_refresh_invoke */
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
            PA2C2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS2C2( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form_Multiple Data Plain_WC", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_mdataplain_wc.aspx"+UrlEncode(StringUtil.RTrim(AV13WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV14WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV20WWPFormInstanceElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV11SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_mdataplain_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV12WWP_DF_ElementsRepeaterMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV12WWP_DF_ElementsRepeaterMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_ELEMENTSREPEATERMETADATA", GetSecureSignedToken( sPrefix, AV12WWP_DF_ElementsRepeaterMetadata, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISGROUPASMAINCHILD", AV24IsGroupAsMainChild);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISGROUPASMAINCHILD", GetSecureSignedToken( sPrefix, AV24IsGroupAsMainChild, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTIDSIMPLECHILDREN", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15WWPFormElementIdSimpleChildren), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTIDSIMPLECHILDREN", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15WWPFormElementIdSimpleChildren), "ZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV13WWPDynamicFormMode", StringUtil.RTrim( wcpOAV13WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV14WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV14WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV20WWPFormInstanceElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV20WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV11SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV11SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV12WWP_DF_ElementsRepeaterMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV12WWP_DF_ElementsRepeaterMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_ELEMENTSREPEATERMETADATA", GetSecureSignedToken( sPrefix, AV12WWP_DF_ElementsRepeaterMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV13WWPDynamicFormMode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID", AV10MultipleDataWWPFormInstanceElementId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID", AV10MultipleDataWWPFormInstanceElementId);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISGROUPASMAINCHILD", AV24IsGroupAsMainChild);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISGROUPASMAINCHILD", GetSecureSignedToken( sPrefix, AV24IsGroupAsMainChild, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV5WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV5WWPFormInstance);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTPARENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A217WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTIDNEW", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22WWPFormInstanceElementIdNew), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTIDSIMPLECHILDREN", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15WWPFormElementIdSimpleChildren), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTIDSIMPLECHILDREN", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15WWPFormElementIdSimpleChildren), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6AuxSessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subFsgrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTIDCHILD_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpforminstanceelementidchild_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm2C2( )
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
            if ( ! ( WebComp_Wcchildren == null ) )
            {
               WebComp_Wcchildren.componentjscripts();
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
         return "WorkWithPlus.DynamicForms.WWP_DF_MDataPlain_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form_Multiple Data Plain_WC", "") ;
      }

      protected void WB2C0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_mdataplain_wc.aspx");
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            FsgridContainer.SetIsFreestyle(true);
            FsgridContainer.SetWrapped(nGXWrapped);
            StartGridControl9( ) ;
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            nRC_GXsfl_9 = (int)(nGXsfl_9_idx-1);
            if ( FsgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"FsgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fsgrid", FsgridContainer, subFsgrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FsgridContainerData", FsgridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FsgridContainerData"+"V", FsgridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FsgridContainerData"+"V"+"\" value='"+FsgridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatacellname_Internalname, divDatacellname_Visible, 0, "px", 0, "px", divDatacellname_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedmultipledatarepetitions_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockmultipledatarepetitions_Internalname, "", "", "", lblTextblockmultipledatarepetitions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_MDataPlain_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_28_2C2( true) ;
         }
         else
         {
            wb_table1_28_2C2( false) ;
         }
         return  ;
      }

      protected void wb_table1_28_2C2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FsgridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"FsgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fsgrid", FsgridContainer, subFsgrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FsgridContainerData", FsgridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FsgridContainerData"+"V", FsgridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FsgridContainerData"+"V"+"\" value='"+FsgridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2C2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form_Multiple Data Plain_WC", ""), 0) ;
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
               STRUP2C0( ) ;
            }
         }
      }

      protected void WS2C2( )
      {
         START2C2( ) ;
         EVT2C2( ) ;
      }

      protected void EVT2C2( )
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
                                 STRUP2C0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOADDCHILD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAddChild' */
                                    E112C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E122C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavWwpforminstanceelementidchild_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "FSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "'DOREMOVECHILD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "'DOREMOVECHILD'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2C0( ) ;
                              }
                              nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpforminstanceelementidchild_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpforminstanceelementidchild_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPFORMINSTANCEELEMENTIDCHILD");
                                 GX_FocusControl = edtavWwpforminstanceelementidchild_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV21WWPFormInstanceElementIdChild = 0;
                                 AssignAttri(sPrefix, false, edtavWwpforminstanceelementidchild_Internalname, StringUtil.LTrimStr( (decimal)(AV21WWPFormInstanceElementIdChild), 4, 0));
                              }
                              else
                              {
                                 AV21WWPFormInstanceElementIdChild = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwpforminstanceelementidchild_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavWwpforminstanceelementidchild_Internalname, StringUtil.LTrimStr( (decimal)(AV21WWPFormInstanceElementIdChild), 4, 0));
                              }
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
                                          GX_FocusControl = edtavWwpforminstanceelementidchild_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E132C2 ();
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
                                          GX_FocusControl = edtavWwpforminstanceelementidchild_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E142C2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FSGRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavWwpforminstanceelementidchild_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Fsgrid.Load */
                                          E152C2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOREMOVECHILD'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavWwpforminstanceelementidchild_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'DoRemoveChild' */
                                          E162C2 ();
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
                                       STRUP2C0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavWwpforminstanceelementidchild_Internalname;
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 18 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0018" + sEvtType;
                           OldWcchildren = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldWcchildren) == 0 ) || ( StringUtil.StrCmp(OldWcchildren, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldWcchildren, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldWcchildren";
                              WebComp_GX_Process_Component = OldWcchildren;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0018", sEvtType, sEvt);
                           }
                           nGXsfl_9_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Wcchildren";
                           WebComp_GX_Process_Component = OldWcchildren;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2C2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2C2( ) ;
            }
         }
      }

      protected void PA2C2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_mdataplain_wc.aspx")), "workwithplus.dynamicforms.wwp_df_mdataplain_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_mdataplain_wc.aspx")))) ;
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
               GX_FocusControl = edtavMultipledatarepetitions_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrFsgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_92( ) ;
         while ( nGXsfl_9_idx <= nRC_GXsfl_9 )
         {
            sendrow_92( ) ;
            nGXsfl_9_idx = ((subFsgrid_Islastpage==1)&&(nGXsfl_9_idx+1>subFsgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FsgridContainer)) ;
         /* End function gxnrFsgrid_newrow */
      }

      protected void gxgrFsgrid_refresh( short AV9MultipleDataRepetitions ,
                                         WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV12WWP_DF_ElementsRepeaterMetadata ,
                                         string AV13WWPDynamicFormMode ,
                                         GxSimpleCollection<short> AV10MultipleDataWWPFormInstanceElementId ,
                                         bool AV24IsGroupAsMainChild ,
                                         short AV14WWPFormElementId ,
                                         short AV11SessionId ,
                                         GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV5WWPFormInstance ,
                                         short A206WWPFormId ,
                                         short A207WWPFormVersionNumber ,
                                         short A211WWPFormElementParentId ,
                                         short A217WWPFormElementType ,
                                         short AV15WWPFormElementIdSimpleChildren ,
                                         string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FSGRID_nCurrentRecord = 0;
         RF2C2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrFsgrid_refresh */
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
         RF2C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FsgridContainer.ClearRows();
         }
         wbStart = 9;
         /* Execute user event: Refresh */
         E142C2 ();
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
         FsgridContainer.AddObjectProperty("GridName", "Fsgrid");
         FsgridContainer.AddObjectProperty("CmpContext", sPrefix);
         FsgridContainer.AddObjectProperty("InMasterPage", "false");
         FsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FsgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Backcolorstyle), 1, 0, ".", "")));
         FsgridContainer.PageSize = subFsgrid_fnc_Recordsperpage( );
         if ( subFsgrid_Islastpage != 0 )
         {
            FSGRID_nFirstRecordOnPage = (long)(subFsgrid_fnc_Recordcount( )-subFsgrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"FSGRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FSGRID_nFirstRecordOnPage), 15, 0, ".", "")));
            FsgridContainer.AddObjectProperty("FSGRID_nFirstRecordOnPage", FSGRID_nFirstRecordOnPage);
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
               {
                  WebComp_Wcchildren.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_92( ) ;
            /* Execute user event: Fsgrid.Load */
            E152C2 ();
            wbEnd = 9;
            WB2C0( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2C2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV12WWP_DF_ElementsRepeaterMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV12WWP_DF_ElementsRepeaterMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_ELEMENTSREPEATERMETADATA", GetSecureSignedToken( sPrefix, AV12WWP_DF_ElementsRepeaterMetadata, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISGROUPASMAINCHILD", AV24IsGroupAsMainChild);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISGROUPASMAINCHILD", GetSecureSignedToken( sPrefix, AV24IsGroupAsMainChild, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTIDSIMPLECHILDREN", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15WWPFormElementIdSimpleChildren), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTIDSIMPLECHILDREN", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15WWPFormElementIdSimpleChildren), "ZZZ9"), context));
      }

      protected int subFsgrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFsgrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFsgrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFsgrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E132C2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV13WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV13WWPDynamicFormMode");
            wcpOAV14WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV14WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV20WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV20WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV11SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV11SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subFsgrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subFsgrid_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMultipledatarepetitions_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMultipledatarepetitions_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMULTIPLEDATAREPETITIONS");
               GX_FocusControl = edtavMultipledatarepetitions_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9MultipleDataRepetitions = 0;
               AssignAttri(sPrefix, false, "AV9MultipleDataRepetitions", StringUtil.LTrimStr( (decimal)(AV9MultipleDataRepetitions), 4, 0));
            }
            else
            {
               AV9MultipleDataRepetitions = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavMultipledatarepetitions_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV9MultipleDataRepetitions", StringUtil.LTrimStr( (decimal)(AV9MultipleDataRepetitions), 4, 0));
            }
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
         E132C2 ();
         if (returnInSub) return;
      }

      protected void E132C2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H002C2 */
         pr_default.execute(0, new Object[] {AV5WWPFormInstance.gxTpr_Wwpformid, AV5WWPFormInstance.gxTpr_Wwpformversionnumber, AV14WWPFormElementId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A210WWPFormElementId = H002C2_A210WWPFormElementId[0];
            A207WWPFormVersionNumber = H002C2_A207WWPFormVersionNumber[0];
            A206WWPFormId = H002C2_A206WWPFormId[0];
            A229WWPFormElementTitle = H002C2_A229WWPFormElementTitle[0];
            A236WWPFormElementMetadata = H002C2_A236WWPFormElementMetadata[0];
            AV18WWPFormElementTitle = A229WWPFormElementTitle;
            AV17WWPFormElementMetadata = A236WWPFormElementMetadata;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV12WWP_DF_ElementsRepeaterMetadata.FromJSonString(AV17WWPFormElementMetadata, null);
         AV15WWPFormElementIdSimpleChildren = AV14WWPFormElementId;
         AssignAttri(sPrefix, false, "AV15WWPFormElementIdSimpleChildren", StringUtil.LTrimStr( (decimal)(AV15WWPFormElementIdSimpleChildren), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTIDSIMPLECHILDREN", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15WWPFormElementIdSimpleChildren), "ZZZ9"), context));
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getsimpleelementofmultipledata(context ).execute(  AV5WWPFormInstance.gxTpr_Wwpformid,  AV5WWPFormInstance.gxTpr_Wwpformversionnumber, ref  AV15WWPFormElementIdSimpleChildren) ;
         AssignAttri(sPrefix, false, "AV15WWPFormElementIdSimpleChildren", StringUtil.LTrimStr( (decimal)(AV15WWPFormElementIdSimpleChildren), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTIDSIMPLECHILDREN", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15WWPFormElementIdSimpleChildren), "ZZZ9"), context));
         AV10MultipleDataWWPFormInstanceElementId = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         AV30GXV1 = 1;
         while ( AV30GXV1 <= AV5WWPFormInstance.gxTpr_Element.Count )
         {
            AV19WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV5WWPFormInstance.gxTpr_Element.Item(AV30GXV1));
            if ( ( AV19WWPFormInstanceElement.gxTpr_Wwpformelementid == AV15WWPFormElementIdSimpleChildren ) && ( ! StringUtil.Contains( AV19WWPFormInstanceElement.ToJSonString(true, true), "\"Mode\":\"DLT\"") ) )
            {
               AV10MultipleDataWWPFormInstanceElementId.Add(AV19WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid, 0);
            }
            AV30GXV1 = (int)(AV30GXV1+1);
         }
         if ( AV10MultipleDataWWPFormInstanceElementId.Count == 0 )
         {
            if ( StringUtil.StrCmp(AV13WWPDynamicFormMode, "INS") != 0 )
            {
               /* Using cursor H002C3 */
               pr_default.execute(1, new Object[] {AV23WWPFormInstanceId, AV15WWPFormElementIdSimpleChildren});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A210WWPFormElementId = H002C3_A210WWPFormElementId[0];
                  A214WWPFormInstanceId = H002C3_A214WWPFormInstanceId[0];
                  A215WWPFormInstanceElementId = H002C3_A215WWPFormInstanceElementId[0];
                  AV10MultipleDataWWPFormInstanceElementId.Add(A215WWPFormInstanceElementId, 0);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
            }
            else
            {
               if ( AV12WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 )
               {
                  Btnaddchild_Caption = AV12WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildcaption;
                  ucBtnaddchild.SendProperty(context, sPrefix, false, Btnaddchild_Internalname, "Caption", Btnaddchild_Caption);
               }
               else
               {
                  if ( AV12WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 2 )
                  {
                     AV9MultipleDataRepetitions = AV12WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_fixedvalue.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV9MultipleDataRepetitions", StringUtil.LTrimStr( (decimal)(AV9MultipleDataRepetitions), 4, 0));
                  }
                  else
                  {
                     GXt_SdtWWP_FormInstance1 = AV5WWPFormInstance;
                     new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV11SessionId, out  GXt_SdtWWP_FormInstance1) ;
                     AV5WWPFormInstance = GXt_SdtWWP_FormInstance1;
                     AV32GXV2 = 1;
                     while ( AV32GXV2 <= AV5WWPFormInstance.gxTpr_Element.Count )
                     {
                        AV19WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV5WWPFormInstance.gxTpr_Element.Item(AV32GXV2));
                        if ( AV19WWPFormInstanceElement.gxTpr_Wwpformelementid == AV12WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_variable.gxTpr_Elementid )
                        {
                           AV9MultipleDataRepetitions = (short)(Math.Round(AV19WWPFormInstanceElement.gxTpr_Wwpforminstanceelemnumeric, 18, MidpointRounding.ToEven));
                           AssignAttri(sPrefix, false, "AV9MultipleDataRepetitions", StringUtil.LTrimStr( (decimal)(AV9MultipleDataRepetitions), 4, 0));
                           if (true) break;
                        }
                        AV32GXV2 = (int)(AV32GXV2+1);
                     }
                  }
                  AV7i = 1;
                  while ( AV7i <= AV9MultipleDataRepetitions )
                  {
                     AV10MultipleDataWWPFormInstanceElementId.Add(AV7i, 0);
                     AV7i = (short)(AV7i+1);
                  }
               }
            }
            GXt_SdtWWP_FormInstance1 = AV5WWPFormInstance;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV11SessionId, out  GXt_SdtWWP_FormInstance1) ;
            AV5WWPFormInstance = GXt_SdtWWP_FormInstance1;
            AV33GXV3 = 1;
            while ( AV33GXV3 <= AV10MultipleDataWWPFormInstanceElementId.Count )
            {
               AV7i = (short)(AV10MultipleDataWWPFormInstanceElementId.GetNumeric(AV33GXV3));
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_createchildren(context ).execute(  AV7i,  AV14WWPFormElementId, ref  AV5WWPFormInstance) ;
               AV33GXV3 = (int)(AV33GXV3+1);
            }
            AV5WWPFormInstance.Check();
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_clearunusedreferences(context ).execute( ref  AV5WWPFormInstance) ;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV11SessionId,  AV5WWPFormInstance) ;
         }
         AV9MultipleDataRepetitions = (short)(AV10MultipleDataWWPFormInstanceElementId.Count);
         AssignAttri(sPrefix, false, "AV9MultipleDataRepetitions", StringUtil.LTrimStr( (decimal)(AV9MultipleDataRepetitions), 4, 0));
         edtavMultipledatarepetitions_Visible = 0;
         AssignProp(sPrefix, false, edtavMultipledatarepetitions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMultipledatarepetitions_Visible), 5, 0), true);
         if ( AV12WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel )
         {
            divDatacellname_Class = "DataContentCell DscTop";
            AssignProp(sPrefix, false, divDatacellname_Internalname, "Class", divDatacellname_Class, true);
         }
         else
         {
            divDatacellname_Class = "DataContentCell DataContentCellNoLabel DscTop DynamicFormAddChildren";
            AssignProp(sPrefix, false, divDatacellname_Internalname, "Class", divDatacellname_Class, true);
         }
         edtavWwpforminstanceelementidchild_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpforminstanceelementidchild_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpforminstanceelementidchild_Visible), 5, 0), !bGXsfl_9_Refreshing);
      }

      protected void E142C2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      private void E152C2( )
      {
         /* Fsgrid_Load Routine */
         returnInSub = false;
         /* Execute user subroutine: 'HASGROUPASMAINCHILD' */
         S122 ();
         if (returnInSub) return;
         AV34GXV4 = 1;
         while ( AV34GXV4 <= AV10MultipleDataWWPFormInstanceElementId.Count )
         {
            AV21WWPFormInstanceElementIdChild = (short)(AV10MultipleDataWWPFormInstanceElementId.GetNumeric(AV34GXV4));
            AssignAttri(sPrefix, false, edtavWwpforminstanceelementidchild_Internalname, StringUtil.LTrimStr( (decimal)(AV21WWPFormInstanceElementIdChild), 4, 0));
            if ( ( AV12WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) && ( StringUtil.StrCmp(AV13WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV13WWPDynamicFormMode, "DLT") != 0 ) )
            {
               lblRemovechild_Visible = 1;
            }
            else
            {
               lblRemovechild_Visible = 0;
            }
            if ( AV24IsGroupAsMainChild )
            {
               lblRemovechild_Class = "DynamicFormMultipleDataActionGroup";
            }
            else
            {
               lblRemovechild_Class = "DynamicFormMultipleDataActionTextblock";
            }
            /* Object Property */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               bDynCreated_Wcchildren = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_FS_WC")) != 0 )
            {
               WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_fs_wc", new Object[] {context} );
               WebComp_Wcchildren.ComponentInit();
               WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_FS_WC";
               WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_FS_WC";
            }
            if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
            {
               WebComp_Wcchildren.setjustcreated();
               WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0018",(string)sGXsfl_9_idx,(string)AV13WWPDynamicFormMode,(short)AV14WWPFormElementId,(short)AV21WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV5WWPFormInstance});
               WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)sPrefix+"vWWPFORMINSTANCEELEMENTIDCHILD_"+sGXsfl_9_idx,(string)"",(string)""});
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 9;
            }
            sendrow_92( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
            {
               DoAjaxLoad(9, FsgridRow);
            }
            AV34GXV4 = (int)(AV34GXV4+1);
         }
         AV9MultipleDataRepetitions = (short)(AV10MultipleDataWWPFormInstanceElementId.Count);
         AssignAttri(sPrefix, false, "AV9MultipleDataRepetitions", StringUtil.LTrimStr( (decimal)(AV9MultipleDataRepetitions), 4, 0));
         /*  Sending Event outputs  */
      }

      protected void E112C2( )
      {
         /* 'DoAddChild' Routine */
         returnInSub = false;
         GXt_SdtWWP_FormInstance1 = AV5WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV11SessionId, out  GXt_SdtWWP_FormInstance1) ;
         AV5WWPFormInstance = GXt_SdtWWP_FormInstance1;
         /* Execute user subroutine: 'GET NEW INSTANCEELEMENTID' */
         S132 ();
         if (returnInSub) return;
         AV10MultipleDataWWPFormInstanceElementId.Add(AV22WWPFormInstanceElementIdNew, 0);
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_createchildren(context ).execute(  AV22WWPFormInstanceElementIdNew,  AV14WWPFormElementId, ref  AV5WWPFormInstance) ;
         AV5WWPFormInstance.Check();
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_clearunusedreferences(context ).execute( ref  AV5WWPFormInstance) ;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV11SessionId,  AV5WWPFormInstance) ;
         AV9MultipleDataRepetitions = (short)(AV9MultipleDataRepetitions+1);
         AssignAttri(sPrefix, false, "AV9MultipleDataRepetitions", StringUtil.LTrimStr( (decimal)(AV9MultipleDataRepetitions), 4, 0));
         gxgrFsgrid_refresh( AV9MultipleDataRepetitions, AV12WWP_DF_ElementsRepeaterMetadata, AV13WWPDynamicFormMode, AV10MultipleDataWWPFormInstanceElementId, AV24IsGroupAsMainChild, AV14WWPFormElementId, AV11SessionId, AV5WWPFormInstance, A206WWPFormId, A207WWPFormVersionNumber, A211WWPFormElementParentId, A217WWPFormElementType, AV15WWPFormElementIdSimpleChildren, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5WWPFormInstance", AV5WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10MultipleDataWWPFormInstanceElementId", AV10MultipleDataWWPFormInstanceElementId);
      }

      protected void E162C2( )
      {
         /* 'DoRemoveChild' Routine */
         returnInSub = false;
         GXt_SdtWWP_FormInstance1 = AV5WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV11SessionId, out  GXt_SdtWWP_FormInstance1) ;
         AV5WWPFormInstance = GXt_SdtWWP_FormInstance1;
         /* Execute user subroutine: 'REMOVE SELECTED CHILD' */
         S142 ();
         if (returnInSub) return;
         AV9MultipleDataRepetitions = (short)(AV10MultipleDataWWPFormInstanceElementId.Count);
         AssignAttri(sPrefix, false, "AV9MultipleDataRepetitions", StringUtil.LTrimStr( (decimal)(AV9MultipleDataRepetitions), 4, 0));
         AV5WWPFormInstance.Check();
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_clearunusedreferences(context ).execute( ref  AV5WWPFormInstance) ;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV11SessionId,  AV5WWPFormInstance) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S112 ();
         if (returnInSub) return;
         gxgrFsgrid_refresh( AV9MultipleDataRepetitions, AV12WWP_DF_ElementsRepeaterMetadata, AV13WWPDynamicFormMode, AV10MultipleDataWWPFormInstanceElementId, AV24IsGroupAsMainChild, AV14WWPFormElementId, AV11SessionId, AV5WWPFormInstance, A206WWPFormId, A207WWPFormVersionNumber, A211WWPFormElementParentId, A217WWPFormElementType, AV15WWPFormElementIdSimpleChildren, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5WWPFormInstance", AV5WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10MultipleDataWWPFormInstanceElementId", AV10MultipleDataWWPFormInstanceElementId);
      }

      protected void S112( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ( AV12WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) && ( AV9MultipleDataRepetitions < AV12WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Maxrepetitions ) && ( StringUtil.StrCmp(AV13WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV13WWPDynamicFormMode, "DLT") != 0 ) )
         {
            divDatacellname_Visible = 1;
            AssignProp(sPrefix, false, divDatacellname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatacellname_Visible), 5, 0), true);
            Btnaddchild_Visible = true;
            ucBtnaddchild.SendProperty(context, sPrefix, false, Btnaddchild_Internalname, "Visible", StringUtil.BoolToStr( Btnaddchild_Visible));
         }
         else
         {
            divDatacellname_Visible = 0;
            AssignProp(sPrefix, false, divDatacellname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatacellname_Visible), 5, 0), true);
         }
         if ( ! ( ( AV12WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) && ( AV9MultipleDataRepetitions < AV12WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Maxrepetitions ) && ( StringUtil.StrCmp(AV13WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV13WWPDynamicFormMode, "DLT") != 0 ) ) )
         {
            Btnaddchild_Visible = false;
            ucBtnaddchild.SendProperty(context, sPrefix, false, Btnaddchild_Internalname, "Visible", StringUtil.BoolToStr( Btnaddchild_Visible));
         }
      }

      protected void E122C2( )
      {
         /* General\GlobalEvents_Dynamicform_updatevisibilities Routine */
         returnInSub = false;
         if ( ( AV6AuxSessionId == AV11SessionId ) && ( AV12WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 3 ) )
         {
            GXt_SdtWWP_FormInstance1 = AV5WWPFormInstance;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV11SessionId, out  GXt_SdtWWP_FormInstance1) ;
            AV5WWPFormInstance = GXt_SdtWWP_FormInstance1;
            AV35GXV5 = 1;
            while ( AV35GXV5 <= AV5WWPFormInstance.gxTpr_Element.Count )
            {
               AV19WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV5WWPFormInstance.gxTpr_Element.Item(AV35GXV5));
               if ( AV19WWPFormInstanceElement.gxTpr_Wwpformelementid == AV12WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_variable.gxTpr_Elementid )
               {
                  AV9MultipleDataRepetitions = (short)(Math.Round(AV19WWPFormInstanceElement.gxTpr_Wwpforminstanceelemnumeric, 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV9MultipleDataRepetitions", StringUtil.LTrimStr( (decimal)(AV9MultipleDataRepetitions), 4, 0));
                  if (true) break;
               }
               AV35GXV5 = (int)(AV35GXV5+1);
            }
            if ( AV9MultipleDataRepetitions != AV10MultipleDataWWPFormInstanceElementId.Count )
            {
               AV25ChildrenRemoved = false;
               while ( AV9MultipleDataRepetitions < AV10MultipleDataWWPFormInstanceElementId.Count )
               {
                  AV21WWPFormInstanceElementIdChild = (short)(AV10MultipleDataWWPFormInstanceElementId.Count);
                  AssignAttri(sPrefix, false, edtavWwpforminstanceelementidchild_Internalname, StringUtil.LTrimStr( (decimal)(AV21WWPFormInstanceElementIdChild), 4, 0));
                  /* Execute user subroutine: 'REMOVE SELECTED CHILD' */
                  S142 ();
                  if (returnInSub) return;
                  AV25ChildrenRemoved = true;
               }
               AV26IdsToAdd = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
               AV7i = 0;
               while ( AV9MultipleDataRepetitions > AV10MultipleDataWWPFormInstanceElementId.Count )
               {
                  if ( (0==AV7i) )
                  {
                     /* Execute user subroutine: 'GET NEW INSTANCEELEMENTID' */
                     S132 ();
                     if (returnInSub) return;
                     AV7i = AV22WWPFormInstanceElementIdNew;
                  }
                  else
                  {
                     AV7i = (short)(AV7i+1);
                  }
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_createchildren(context ).execute(  AV7i,  AV14WWPFormElementId, ref  AV5WWPFormInstance) ;
                  AV10MultipleDataWWPFormInstanceElementId.Add(AV7i, 0);
                  if ( ! AV25ChildrenRemoved )
                  {
                     AV26IdsToAdd.Add(AV7i, 0);
                  }
               }
               AV5WWPFormInstance.Check();
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_clearunusedreferences(context ).execute( ref  AV5WWPFormInstance) ;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV11SessionId,  AV5WWPFormInstance) ;
               gxgrFsgrid_refresh( AV9MultipleDataRepetitions, AV12WWP_DF_ElementsRepeaterMetadata, AV13WWPDynamicFormMode, AV10MultipleDataWWPFormInstanceElementId, AV24IsGroupAsMainChild, AV14WWPFormElementId, AV11SessionId, AV5WWPFormInstance, A206WWPFormId, A207WWPFormVersionNumber, A211WWPFormElementParentId, A217WWPFormElementType, AV15WWPFormElementIdSimpleChildren, sPrefix) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5WWPFormInstance", AV5WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10MultipleDataWWPFormInstanceElementId", AV10MultipleDataWWPFormInstanceElementId);
      }

      protected void S122( )
      {
         /* 'HASGROUPASMAINCHILD' Routine */
         returnInSub = false;
         AV24IsGroupAsMainChild = false;
         AssignAttri(sPrefix, false, "AV24IsGroupAsMainChild", AV24IsGroupAsMainChild);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISGROUPASMAINCHILD", GetSecureSignedToken( sPrefix, AV24IsGroupAsMainChild, context));
         /* Using cursor H002C4 */
         pr_default.execute(2, new Object[] {AV5WWPFormInstance.gxTpr_Wwpformid, AV5WWPFormInstance.gxTpr_Wwpformversionnumber, AV14WWPFormElementId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A211WWPFormElementParentId = H002C4_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = H002C4_n211WWPFormElementParentId[0];
            A207WWPFormVersionNumber = H002C4_A207WWPFormVersionNumber[0];
            A206WWPFormId = H002C4_A206WWPFormId[0];
            A217WWPFormElementType = H002C4_A217WWPFormElementType[0];
            if ( A217WWPFormElementType == 2 )
            {
               AV24IsGroupAsMainChild = true;
               AssignAttri(sPrefix, false, "AV24IsGroupAsMainChild", AV24IsGroupAsMainChild);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISGROUPASMAINCHILD", GetSecureSignedToken( sPrefix, AV24IsGroupAsMainChild, context));
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S142( )
      {
         /* 'REMOVE SELECTED CHILD' Routine */
         returnInSub = false;
         AV16WWPFormElementIdToDelete = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deletechildren(context ).execute(  AV5WWPFormInstance.gxTpr_Wwpformid,  AV5WWPFormInstance.gxTpr_Wwpformversionnumber,  AV14WWPFormElementId, ref  AV16WWPFormElementIdToDelete) ;
         AV7i = 1;
         while ( AV7i <= AV16WWPFormElementIdToDelete.Count )
         {
            AV8j = 1;
            AV37GXV6 = 1;
            while ( AV37GXV6 <= AV5WWPFormInstance.gxTpr_Element.Count )
            {
               AV19WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV5WWPFormInstance.gxTpr_Element.Item(AV37GXV6));
               if ( ( AV19WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV21WWPFormInstanceElementIdChild ) && ( AV19WWPFormInstanceElement.gxTpr_Wwpformelementid == AV16WWPFormElementIdToDelete.GetNumeric(AV7i) ) )
               {
                  if (true) break;
               }
               else
               {
                  AV8j = (short)(AV8j+1);
               }
               AV37GXV6 = (int)(AV37GXV6+1);
            }
            if ( AV8j <= AV5WWPFormInstance.gxTpr_Element.Count )
            {
               AV5WWPFormInstance.gxTpr_Element.RemoveItem(AV8j);
            }
            AV7i = (short)(AV7i+1);
         }
         AV10MultipleDataWWPFormInstanceElementId.RemoveItem(AV10MultipleDataWWPFormInstanceElementId.IndexOf(AV21WWPFormInstanceElementIdChild));
      }

      protected void S132( )
      {
         /* 'GET NEW INSTANCEELEMENTID' Routine */
         returnInSub = false;
         AV22WWPFormInstanceElementIdNew = 0;
         AssignAttri(sPrefix, false, "AV22WWPFormInstanceElementIdNew", StringUtil.LTrimStr( (decimal)(AV22WWPFormInstanceElementIdNew), 4, 0));
         AV38GXV7 = 1;
         while ( AV38GXV7 <= AV5WWPFormInstance.gxTpr_Element.Count )
         {
            AV19WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV5WWPFormInstance.gxTpr_Element.Item(AV38GXV7));
            if ( ( AV19WWPFormInstanceElement.gxTpr_Wwpformelementid == AV15WWPFormElementIdSimpleChildren ) && ( AV19WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid > AV22WWPFormInstanceElementIdNew ) )
            {
               AV22WWPFormInstanceElementIdNew = AV19WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid;
               AssignAttri(sPrefix, false, "AV22WWPFormInstanceElementIdNew", StringUtil.LTrimStr( (decimal)(AV22WWPFormInstanceElementIdNew), 4, 0));
            }
            AV38GXV7 = (int)(AV38GXV7+1);
         }
         AV22WWPFormInstanceElementIdNew = (short)(AV22WWPFormInstanceElementIdNew+1);
         AssignAttri(sPrefix, false, "AV22WWPFormInstanceElementIdNew", StringUtil.LTrimStr( (decimal)(AV22WWPFormInstanceElementIdNew), 4, 0));
      }

      protected void wb_table1_28_2C2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedmultipledatarepetitions_Internalname, tblTablemergedmultipledatarepetitions_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMultipledatarepetitions_Internalname, context.GetMessage( "Multiple Data Repetitions", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMultipledatarepetitions_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9MultipleDataRepetitions), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavMultipledatarepetitions_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9MultipleDataRepetitions), "ZZZ9") : context.localUtil.Format( (decimal)(AV9MultipleDataRepetitions), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMultipledatarepetitions_Jsonclick, 0, "Attribute", "", "", "", "", edtavMultipledatarepetitions_Visible, edtavMultipledatarepetitions_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_MDataPlain_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtnaddchild.SetProperty("TooltipText", Btnaddchild_Tooltiptext);
            ucBtnaddchild.SetProperty("BeforeIconClass", Btnaddchild_Beforeiconclass);
            ucBtnaddchild.SetProperty("Caption", Btnaddchild_Caption);
            ucBtnaddchild.SetProperty("Class", Btnaddchild_Class);
            ucBtnaddchild.Render(context, "wwp_iconbutton", Btnaddchild_Internalname, sPrefix+"BTNADDCHILDContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_28_2C2e( true) ;
         }
         else
         {
            wb_table1_28_2C2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV13WWPDynamicFormMode", AV13WWPDynamicFormMode);
         AV14WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV14WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV14WWPFormElementId), 4, 0));
         AV20WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV20WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV20WWPFormInstanceElementId), 4, 0));
         AV11SessionId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV11SessionId", StringUtil.LTrimStr( (decimal)(AV11SessionId), 4, 0));
         AV5WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,4);
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
         PA2C2( ) ;
         WS2C2( ) ;
         WE2C2( ) ;
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
         sCtrlAV13WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV14WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV20WWPFormInstanceElementId = (string)((string)getParm(obj,2));
         sCtrlAV11SessionId = (string)((string)getParm(obj,3));
         sCtrlAV5WWPFormInstance = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2C2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_mdataplain_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2C2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV13WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV13WWPDynamicFormMode", AV13WWPDynamicFormMode);
            AV14WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV14WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV14WWPFormElementId), 4, 0));
            AV20WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV20WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV20WWPFormInstanceElementId), 4, 0));
            AV11SessionId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV11SessionId", StringUtil.LTrimStr( (decimal)(AV11SessionId), 4, 0));
            AV5WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,6);
         }
         wcpOAV13WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV13WWPDynamicFormMode");
         wcpOAV14WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV14WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV20WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV20WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV11SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV11SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV13WWPDynamicFormMode, wcpOAV13WWPDynamicFormMode) != 0 ) || ( AV14WWPFormElementId != wcpOAV14WWPFormElementId ) || ( AV20WWPFormInstanceElementId != wcpOAV20WWPFormInstanceElementId ) || ( AV11SessionId != wcpOAV11SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV13WWPDynamicFormMode = AV13WWPDynamicFormMode;
         wcpOAV14WWPFormElementId = AV14WWPFormElementId;
         wcpOAV20WWPFormInstanceElementId = AV20WWPFormInstanceElementId;
         wcpOAV11SessionId = AV11SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV13WWPDynamicFormMode = cgiGet( sPrefix+"AV13WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV13WWPDynamicFormMode) > 0 )
         {
            AV13WWPDynamicFormMode = cgiGet( sCtrlAV13WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV13WWPDynamicFormMode", AV13WWPDynamicFormMode);
         }
         else
         {
            AV13WWPDynamicFormMode = cgiGet( sPrefix+"AV13WWPDynamicFormMode_PARM");
         }
         sCtrlAV14WWPFormElementId = cgiGet( sPrefix+"AV14WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV14WWPFormElementId) > 0 )
         {
            AV14WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV14WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV14WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV14WWPFormElementId), 4, 0));
         }
         else
         {
            AV14WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV14WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV20WWPFormInstanceElementId = cgiGet( sPrefix+"AV20WWPFormInstanceElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV20WWPFormInstanceElementId) > 0 )
         {
            AV20WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV20WWPFormInstanceElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV20WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV20WWPFormInstanceElementId), 4, 0));
         }
         else
         {
            AV20WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV20WWPFormInstanceElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV11SessionId = cgiGet( sPrefix+"AV11SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV11SessionId) > 0 )
         {
            AV11SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV11SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV11SessionId", StringUtil.LTrimStr( (decimal)(AV11SessionId), 4, 0));
         }
         else
         {
            AV11SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV11SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV5WWPFormInstance = cgiGet( sPrefix+"AV5WWPFormInstance_CTRL");
         if ( StringUtil.Len( sCtrlAV5WWPFormInstance) > 0 )
         {
            AV5WWPFormInstance.FromXml(cgiGet( sCtrlAV5WWPFormInstance), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV5WWPFormInstance_PARM"), AV5WWPFormInstance);
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
         PA2C2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2C2( ) ;
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
         WS2C2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV13WWPDynamicFormMode_PARM", StringUtil.RTrim( AV13WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV13WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV13WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV13WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV14WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV14WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV14WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV14WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20WWPFormInstanceElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20WWPFormInstanceElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20WWPFormInstanceElementId_CTRL", StringUtil.RTrim( sCtrlAV20WWPFormInstanceElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11SessionId_CTRL", StringUtil.RTrim( sCtrlAV11SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV5WWPFormInstance_PARM", AV5WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV5WWPFormInstance_PARM", AV5WWPFormInstance);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV5WWPFormInstance)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV5WWPFormInstance_CTRL", StringUtil.RTrim( sCtrlAV5WWPFormInstance));
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
         WE2C2( ) ;
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
         if ( ! ( WebComp_GX_Process == null ) )
         {
            WebComp_GX_Process.componentjscripts();
         }
         if ( ! ( WebComp_Wcchildren == null ) )
         {
            WebComp_Wcchildren.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcchildren == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
            {
               WebComp_Wcchildren.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309335699", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_mdataplain_wc.js", "?20256309335699", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_92( )
      {
         edtavWwpforminstanceelementidchild_Internalname = sPrefix+"vWWPFORMINSTANCEELEMENTIDCHILD_"+sGXsfl_9_idx;
         lblRemovechild_Internalname = sPrefix+"REMOVECHILD_"+sGXsfl_9_idx;
      }

      protected void SubsflControlProps_fel_92( )
      {
         edtavWwpforminstanceelementidchild_Internalname = sPrefix+"vWWPFORMINSTANCEELEMENTIDCHILD_"+sGXsfl_9_fel_idx;
         lblRemovechild_Internalname = sPrefix+"REMOVECHILD_"+sGXsfl_9_fel_idx;
      }

      protected void sendrow_92( )
      {
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         WB2C0( ) ;
         FsgridRow = GXWebRow.GetNew(context,FsgridContainer);
         if ( subFsgrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFsgrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
            {
               subFsgrid_Linesclass = subFsgrid_Class+"Odd";
            }
         }
         else if ( subFsgrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFsgrid_Backstyle = 0;
            subFsgrid_Backcolor = subFsgrid_Allbackcolor;
            if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
            {
               subFsgrid_Linesclass = subFsgrid_Class+"Uniform";
            }
         }
         else if ( subFsgrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFsgrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
            {
               subFsgrid_Linesclass = subFsgrid_Class+"Odd";
            }
            subFsgrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFsgrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFsgrid_Backstyle = 1;
            if ( ((int)((nGXsfl_9_idx) % (2))) == 0 )
            {
               subFsgrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
               {
                  subFsgrid_Linesclass = subFsgrid_Class+"Even";
               }
            }
            else
            {
               subFsgrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
               {
                  subFsgrid_Linesclass = subFsgrid_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFsgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_9_idx+"\">") ;
         }
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFsgridlayouttable_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Invisible",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Table start */
         FsgridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfsgrid_Internalname+"_"+sGXsfl_9_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         FsgridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FsgridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavWwpforminstanceelementidchild_Internalname,context.GetMessage( "WWPForm Instance Element Id Child", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',9)\"";
         ROClassString = "Attribute";
         FsgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpforminstanceelementidchild_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21WWPFormInstanceElementIdChild), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV21WWPFormInstanceElementIdChild), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwpforminstanceelementidchild_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavWwpforminstanceelementidchild_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            FsgridContainer.CloseTag("cell");
         }
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            FsgridContainer.CloseTag("row");
         }
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            FsgridContainer.CloseTag("table");
         }
         /* End of table */
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0018"+sGXsfl_9_idx, StringUtil.RTrim( WebComp_Wcchildren_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0018"+sGXsfl_9_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_9_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0018"+sGXsfl_9_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcchildren), StringUtil.Lower( WebComp_Wcchildren_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0018"+sGXsfl_9_idx);
               }
               WebComp_Wcchildren.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcchildren), StringUtil.Lower( WebComp_Wcchildren_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Wcchildren_Component = "";
         WebComp_Wcchildren.componentjscripts();
         FsgridRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Wcchildren"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         FsgridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblRemovechild_Internalname,context.GetMessage( "<i class=\"DynamicFormMultipleDataAction fas fa-trash\"></i>", ""),(string)"",(string)"",(string)lblRemovechild_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOREMOVECHILD\\'."+sGXsfl_9_idx+"'",(string)"",(string)lblRemovechild_Class,(short)5,(string)"",(int)lblRemovechild_Visible,(short)1,(short)0,(short)1});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2C2( ) ;
         /* End of Columns property logic. */
         FsgridContainer.AddRow(FsgridRow);
         nGXsfl_9_idx = ((subFsgrid_Islastpage==1)&&(nGXsfl_9_idx+1>subFsgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         /* End function sendrow_92 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl9( )
      {
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"FsgridContainer"+"DivS\" data-gxgridid=\"9\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFsgrid_Internalname, subFsgrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FsgridContainer.AddObjectProperty("GridName", "Fsgrid");
         }
         else
         {
            FsgridContainer.AddObjectProperty("GridName", "Fsgrid");
            FsgridContainer.AddObjectProperty("Header", subFsgrid_Header);
            FsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Backcolorstyle), 1, 0, ".", "")));
            FsgridContainer.AddObjectProperty("CmpContext", sPrefix);
            FsgridContainer.AddObjectProperty("InMasterPage", "false");
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21WWPFormInstanceElementIdChild), 4, 0, ".", ""))));
            FsgridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpforminstanceelementidchild_Visible), 5, 0, ".", "")));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridColumn.AddObjectProperty("Value", lblRemovechild_Caption);
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FsgridContainer.AddColumnProperties(FsgridColumn);
            FsgridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Selectedindex), 4, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Allowselection), 1, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Selectioncolor), 9, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Allowhovering), 1, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Hoveringcolor), 9, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Allowcollapsing), 1, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavWwpforminstanceelementidchild_Internalname = sPrefix+"vWWPFORMINSTANCEELEMENTIDCHILD";
         tblUnnamedtablecontentfsfsgrid_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSFSGRID";
         lblRemovechild_Internalname = sPrefix+"REMOVECHILD";
         divFsgridlayouttable_Internalname = sPrefix+"FSGRIDLAYOUTTABLE";
         lblTextblockmultipledatarepetitions_Internalname = sPrefix+"TEXTBLOCKMULTIPLEDATAREPETITIONS";
         edtavMultipledatarepetitions_Internalname = sPrefix+"vMULTIPLEDATAREPETITIONS";
         Btnaddchild_Internalname = sPrefix+"BTNADDCHILD";
         tblTablemergedmultipledatarepetitions_Internalname = sPrefix+"TABLEMERGEDMULTIPLEDATAREPETITIONS";
         divTablesplittedmultipledatarepetitions_Internalname = sPrefix+"TABLESPLITTEDMULTIPLEDATAREPETITIONS";
         divDatacellname_Internalname = sPrefix+"DATACELLNAME";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subFsgrid_Internalname = sPrefix+"FSGRID";
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
         subFsgrid_Allowcollapsing = 0;
         lblRemovechild_Caption = context.GetMessage( "<i class=\"DynamicFormMultipleDataAction fas fa-trash\"></i>", "");
         lblRemovechild_Class = "TextBlock";
         lblRemovechild_Visible = 1;
         edtavWwpforminstanceelementidchild_Jsonclick = "";
         subFsgrid_Class = "FreeStyleGrid";
         Btnaddchild_Class = "ButtonGray";
         Btnaddchild_Beforeiconclass = "fas fa-circle-plus";
         Btnaddchild_Tooltiptext = "";
         edtavMultipledatarepetitions_Jsonclick = "";
         edtavMultipledatarepetitions_Enabled = 1;
         Btnaddchild_Visible = Convert.ToBoolean( -1);
         edtavMultipledatarepetitions_Visible = 1;
         Btnaddchild_Caption = context.GetMessage( "Add child", "");
         subFsgrid_Backcolorstyle = 0;
         divDatacellname_Class = "col-xs-12 DataContentCell DscTop";
         divDatacellname_Visible = 1;
         edtavWwpforminstanceelementidchild_Visible = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"edtavWwpforminstanceelementidchild_Visible","ctrl":"vWWPFORMINSTANCEELEMENTIDCHILD","prop":"Visible"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"AV14WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV11SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"sPrefix"},{"av":"AV9MultipleDataRepetitions","fld":"vMULTIPLEDATAREPETITIONS","pic":"ZZZ9"},{"av":"AV13WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV12WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV24IsGroupAsMainChild","fld":"vISGROUPASMAINCHILD","hsh":true},{"av":"AV15WWPFormElementIdSimpleChildren","fld":"vWWPFORMELEMENTIDSIMPLECHILDREN","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnaddchild_Visible","ctrl":"BTNADDCHILD","prop":"Visible"},{"av":"divDatacellname_Visible","ctrl":"DATACELLNAME","prop":"Visible"}]}""");
         setEventMetadata("FSGRID.LOAD","""{"handler":"E152C2","iparms":[{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"AV12WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV13WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV24IsGroupAsMainChild","fld":"vISGROUPASMAINCHILD","hsh":true},{"av":"AV14WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV11SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"}]""");
         setEventMetadata("FSGRID.LOAD",""","oparms":[{"av":"AV21WWPFormInstanceElementIdChild","fld":"vWWPFORMINSTANCEELEMENTIDCHILD","pic":"ZZZ9"},{"av":"lblRemovechild_Visible","ctrl":"REMOVECHILD","prop":"Visible"},{"av":"lblRemovechild_Class","ctrl":"REMOVECHILD","prop":"Class"},{"ctrl":"WCCHILDREN"},{"av":"AV9MultipleDataRepetitions","fld":"vMULTIPLEDATAREPETITIONS","pic":"ZZZ9"},{"av":"AV24IsGroupAsMainChild","fld":"vISGROUPASMAINCHILD","hsh":true}]}""");
         setEventMetadata("'DOADDCHILD'","""{"handler":"E112C2","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"AV9MultipleDataRepetitions","fld":"vMULTIPLEDATAREPETITIONS","pic":"ZZZ9"},{"av":"AV12WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV13WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"edtavWwpforminstanceelementidchild_Visible","ctrl":"vWWPFORMINSTANCEELEMENTIDCHILD","prop":"Visible"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"AV24IsGroupAsMainChild","fld":"vISGROUPASMAINCHILD","hsh":true},{"av":"AV14WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV11SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"AV15WWPFormElementIdSimpleChildren","fld":"vWWPFORMELEMENTIDSIMPLECHILDREN","pic":"ZZZ9","hsh":true},{"av":"sPrefix"},{"av":"AV22WWPFormInstanceElementIdNew","fld":"vWWPFORMINSTANCEELEMENTIDNEW","pic":"ZZZ9"}]""");
         setEventMetadata("'DOADDCHILD'",""","oparms":[{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"AV9MultipleDataRepetitions","fld":"vMULTIPLEDATAREPETITIONS","pic":"ZZZ9"},{"av":"AV22WWPFormInstanceElementIdNew","fld":"vWWPFORMINSTANCEELEMENTIDNEW","pic":"ZZZ9"},{"av":"Btnaddchild_Visible","ctrl":"BTNADDCHILD","prop":"Visible"},{"av":"divDatacellname_Visible","ctrl":"DATACELLNAME","prop":"Visible"}]}""");
         setEventMetadata("'DOREMOVECHILD'","""{"handler":"E162C2","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"AV9MultipleDataRepetitions","fld":"vMULTIPLEDATAREPETITIONS","pic":"ZZZ9"},{"av":"AV12WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV13WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"edtavWwpforminstanceelementidchild_Visible","ctrl":"vWWPFORMINSTANCEELEMENTIDCHILD","prop":"Visible"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"AV24IsGroupAsMainChild","fld":"vISGROUPASMAINCHILD","hsh":true},{"av":"AV14WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV11SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"AV15WWPFormElementIdSimpleChildren","fld":"vWWPFORMELEMENTIDSIMPLECHILDREN","pic":"ZZZ9","hsh":true},{"av":"sPrefix"},{"av":"AV21WWPFormInstanceElementIdChild","fld":"vWWPFORMINSTANCEELEMENTIDCHILD","pic":"ZZZ9"}]""");
         setEventMetadata("'DOREMOVECHILD'",""","oparms":[{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV9MultipleDataRepetitions","fld":"vMULTIPLEDATAREPETITIONS","pic":"ZZZ9"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"Btnaddchild_Visible","ctrl":"BTNADDCHILD","prop":"Visible"},{"av":"divDatacellname_Visible","ctrl":"DATACELLNAME","prop":"Visible"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES","""{"handler":"E122C2","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"AV9MultipleDataRepetitions","fld":"vMULTIPLEDATAREPETITIONS","pic":"ZZZ9"},{"av":"AV12WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV13WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"edtavWwpforminstanceelementidchild_Visible","ctrl":"vWWPFORMINSTANCEELEMENTIDCHILD","prop":"Visible"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"AV24IsGroupAsMainChild","fld":"vISGROUPASMAINCHILD","hsh":true},{"av":"AV14WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV11SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"AV15WWPFormElementIdSimpleChildren","fld":"vWWPFORMELEMENTIDSIMPLECHILDREN","pic":"ZZZ9","hsh":true},{"av":"sPrefix"},{"av":"AV6AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV22WWPFormInstanceElementIdNew","fld":"vWWPFORMINSTANCEELEMENTIDNEW","pic":"ZZZ9"},{"av":"AV21WWPFormInstanceElementIdChild","fld":"vWWPFORMINSTANCEELEMENTIDCHILD","pic":"ZZZ9"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",""","oparms":[{"av":"AV5WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV9MultipleDataRepetitions","fld":"vMULTIPLEDATAREPETITIONS","pic":"ZZZ9"},{"av":"AV21WWPFormInstanceElementIdChild","fld":"vWWPFORMINSTANCEELEMENTIDCHILD","pic":"ZZZ9"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"AV22WWPFormInstanceElementIdNew","fld":"vWWPFORMINSTANCEELEMENTIDNEW","pic":"ZZZ9"},{"av":"Btnaddchild_Visible","ctrl":"BTNADDCHILD","prop":"Visible"},{"av":"divDatacellname_Visible","ctrl":"DATACELLNAME","prop":"Visible"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Wwpforminstanceelementidchild","iparms":[]}""");
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
         AV5WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         wcpOAV13WWPDynamicFormMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV12WWP_DF_ElementsRepeaterMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
         AV10MultipleDataWWPFormInstanceElementId = new GxSimpleCollection<short>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         FsgridContainer = new GXWebGrid( context);
         sStyleString = "";
         lblTextblockmultipledatarepetitions_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         OldWcchildren = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         GXDecQS = "";
         WebComp_Wcchildren_Component = "";
         H002C2_A210WWPFormElementId = new short[1] ;
         H002C2_A207WWPFormVersionNumber = new short[1] ;
         H002C2_A206WWPFormId = new short[1] ;
         H002C2_A229WWPFormElementTitle = new string[] {""} ;
         H002C2_A236WWPFormElementMetadata = new string[] {""} ;
         A229WWPFormElementTitle = "";
         A236WWPFormElementMetadata = "";
         AV18WWPFormElementTitle = "";
         AV17WWPFormElementMetadata = "";
         AV19WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         H002C3_A210WWPFormElementId = new short[1] ;
         H002C3_A214WWPFormInstanceId = new int[1] ;
         H002C3_A215WWPFormInstanceElementId = new short[1] ;
         ucBtnaddchild = new GXUserControl();
         FsgridRow = new GXWebRow();
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV26IdsToAdd = new GxSimpleCollection<short>();
         H002C4_A210WWPFormElementId = new short[1] ;
         H002C4_A211WWPFormElementParentId = new short[1] ;
         H002C4_n211WWPFormElementParentId = new bool[] {false} ;
         H002C4_A207WWPFormVersionNumber = new short[1] ;
         H002C4_A206WWPFormId = new short[1] ;
         H002C4_A217WWPFormElementType = new short[1] ;
         AV16WWPFormElementIdToDelete = new GxSimpleCollection<short>();
         TempTags = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV13WWPDynamicFormMode = "";
         sCtrlAV14WWPFormElementId = "";
         sCtrlAV20WWPFormInstanceElementId = "";
         sCtrlAV11SessionId = "";
         sCtrlAV5WWPFormInstance = "";
         subFsgrid_Linesclass = "";
         ROClassString = "";
         lblRemovechild_Jsonclick = "";
         subFsgrid_Header = "";
         FsgridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_mdataplain_wc__default(),
            new Object[][] {
                new Object[] {
               H002C2_A210WWPFormElementId, H002C2_A207WWPFormVersionNumber, H002C2_A206WWPFormId, H002C2_A229WWPFormElementTitle, H002C2_A236WWPFormElementMetadata
               }
               , new Object[] {
               H002C3_A210WWPFormElementId, H002C3_A214WWPFormInstanceId, H002C3_A215WWPFormInstanceElementId
               }
               , new Object[] {
               H002C4_A210WWPFormElementId, H002C4_A211WWPFormElementParentId, H002C4_n211WWPFormElementParentId, H002C4_A207WWPFormVersionNumber, H002C4_A206WWPFormId, H002C4_A217WWPFormElementType
               }
            }
         );
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcchildren = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV14WWPFormElementId ;
      private short AV20WWPFormInstanceElementId ;
      private short AV11SessionId ;
      private short wcpOAV14WWPFormElementId ;
      private short wcpOAV20WWPFormInstanceElementId ;
      private short wcpOAV11SessionId ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV9MultipleDataRepetitions ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A211WWPFormElementParentId ;
      private short A217WWPFormElementType ;
      private short AV15WWPFormElementIdSimpleChildren ;
      private short AV22WWPFormInstanceElementIdNew ;
      private short AV6AuxSessionId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV21WWPFormInstanceElementIdChild ;
      private short nCmpId ;
      private short nDonePA ;
      private short subFsgrid_Backcolorstyle ;
      private short A210WWPFormElementId ;
      private short A215WWPFormInstanceElementId ;
      private short AV7i ;
      private short FSGRID_nEOF ;
      private short AV8j ;
      private short nGXWrapped ;
      private short subFsgrid_Backstyle ;
      private short subFsgrid_Allowselection ;
      private short subFsgrid_Allowhovering ;
      private short subFsgrid_Allowcollapsing ;
      private short subFsgrid_Collapsed ;
      private int edtavWwpforminstanceelementidchild_Visible ;
      private int nRC_GXsfl_9 ;
      private int subFsgrid_Recordcount ;
      private int nGXsfl_9_idx=1 ;
      private int divDatacellname_Visible ;
      private int nGXsfl_9_webc_idx=0 ;
      private int subFsgrid_Islastpage ;
      private int AV30GXV1 ;
      private int AV23WWPFormInstanceId ;
      private int A214WWPFormInstanceId ;
      private int AV32GXV2 ;
      private int AV33GXV3 ;
      private int edtavMultipledatarepetitions_Visible ;
      private int AV34GXV4 ;
      private int lblRemovechild_Visible ;
      private int AV35GXV5 ;
      private int AV37GXV6 ;
      private int AV38GXV7 ;
      private int edtavMultipledatarepetitions_Enabled ;
      private int idxLst ;
      private int subFsgrid_Backcolor ;
      private int subFsgrid_Allbackcolor ;
      private int subFsgrid_Selectedindex ;
      private int subFsgrid_Selectioncolor ;
      private int subFsgrid_Hoveringcolor ;
      private long FSGRID_nCurrentRecord ;
      private long FSGRID_nFirstRecordOnPage ;
      private string AV13WWPDynamicFormMode ;
      private string wcpOAV13WWPDynamicFormMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_9_idx="0001" ;
      private string edtavWwpforminstanceelementidchild_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string sStyleString ;
      private string subFsgrid_Internalname ;
      private string divDatacellname_Internalname ;
      private string divDatacellname_Class ;
      private string divTablesplittedmultipledatarepetitions_Internalname ;
      private string lblTextblockmultipledatarepetitions_Internalname ;
      private string lblTextblockmultipledatarepetitions_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string OldWcchildren ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string GXDecQS ;
      private string edtavMultipledatarepetitions_Internalname ;
      private string WebComp_Wcchildren_Component ;
      private string Btnaddchild_Caption ;
      private string Btnaddchild_Internalname ;
      private string lblRemovechild_Class ;
      private string tblTablemergedmultipledatarepetitions_Internalname ;
      private string TempTags ;
      private string edtavMultipledatarepetitions_Jsonclick ;
      private string Btnaddchild_Tooltiptext ;
      private string Btnaddchild_Beforeiconclass ;
      private string Btnaddchild_Class ;
      private string sCtrlAV13WWPDynamicFormMode ;
      private string sCtrlAV14WWPFormElementId ;
      private string sCtrlAV20WWPFormInstanceElementId ;
      private string sCtrlAV11SessionId ;
      private string sCtrlAV5WWPFormInstance ;
      private string lblRemovechild_Internalname ;
      private string sGXsfl_9_fel_idx="0001" ;
      private string subFsgrid_Class ;
      private string subFsgrid_Linesclass ;
      private string divFsgridlayouttable_Internalname ;
      private string tblUnnamedtablecontentfsfsgrid_Internalname ;
      private string ROClassString ;
      private string edtavWwpforminstanceelementidchild_Jsonclick ;
      private string lblRemovechild_Jsonclick ;
      private string subFsgrid_Header ;
      private string lblRemovechild_Caption ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool AV24IsGroupAsMainChild ;
      private bool n211WWPFormElementParentId ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wcchildren ;
      private bool Btnaddchild_Visible ;
      private bool AV25ChildrenRemoved ;
      private string A229WWPFormElementTitle ;
      private string A236WWPFormElementMetadata ;
      private string AV18WWPFormElementTitle ;
      private string AV17WWPFormElementMetadata ;
      private GXWebComponent WebComp_Wcchildren ;
      private GXWebGrid FsgridContainer ;
      private GXWebRow FsgridRow ;
      private GXWebColumn FsgridColumn ;
      private GXUserControl ucBtnaddchild ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV5WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV12WWP_DF_ElementsRepeaterMetadata ;
      private GxSimpleCollection<short> AV10MultipleDataWWPFormInstanceElementId ;
      private GXWebComponent WebComp_GX_Process ;
      private IDataStoreProvider pr_default ;
      private short[] H002C2_A210WWPFormElementId ;
      private short[] H002C2_A207WWPFormVersionNumber ;
      private short[] H002C2_A206WWPFormId ;
      private string[] H002C2_A229WWPFormElementTitle ;
      private string[] H002C2_A236WWPFormElementMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV19WWPFormInstanceElement ;
      private short[] H002C3_A210WWPFormElementId ;
      private int[] H002C3_A214WWPFormInstanceId ;
      private short[] H002C3_A215WWPFormInstanceElementId ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private GxSimpleCollection<short> AV26IdsToAdd ;
      private short[] H002C4_A210WWPFormElementId ;
      private short[] H002C4_A211WWPFormElementParentId ;
      private bool[] H002C4_n211WWPFormElementParentId ;
      private short[] H002C4_A207WWPFormVersionNumber ;
      private short[] H002C4_A206WWPFormId ;
      private short[] H002C4_A217WWPFormElementType ;
      private GxSimpleCollection<short> AV16WWPFormElementIdToDelete ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_df_mdataplain_wc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002C2;
          prmH002C2 = new Object[] {
          new ParDef("AV5WWPFormInstance__Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV5WWPFo_1Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV14WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmH002C3;
          prmH002C3 = new Object[] {
          new ParDef("AV23WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("AV15WWPFormElementIdSimpleChildren",GXType.Int16,4,0)
          };
          Object[] prmH002C4;
          prmH002C4 = new Object[] {
          new ParDef("AV5WWPFormInstance__Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV5WWPFo_1Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV14WWPFormElementId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002C2", "SELECT WWPFormElementId, WWPFormVersionNumber, WWPFormId, WWPFormElementTitle, WWPFormElementMetadata FROM WWP_FormElement WHERE WWPFormId = :AV5WWPFormInstance__Wwpformid and WWPFormVersionNumber = :AV5WWPFo_1Wwpformversionnumbe and WWPFormElementId = :AV14WWPFormElementId ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002C2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002C3", "SELECT WWPFormElementId, WWPFormInstanceId, WWPFormInstanceElementId FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :AV23WWPFormInstanceId and WWPFormElementId = :AV15WWPFormElementIdSimpleChildren ORDER BY WWPFormInstanceId, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002C3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002C4", "SELECT WWPFormElementId, WWPFormElementParentId, WWPFormVersionNumber, WWPFormId, WWPFormElementType FROM WWP_FormElement WHERE WWPFormId = :AV5WWPFormInstance__Wwpformid and WWPFormVersionNumber = :AV5WWPFo_1Wwpformversionnumbe and WWPFormElementParentId = :AV14WWPFormElementId ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementParentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002C4,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
