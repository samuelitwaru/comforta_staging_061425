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
   public class wwp_df_fs_wc : GXWebComponent
   {
      public wwp_df_fs_wc( )
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

      public wwp_df_fs_wc( IGxContext context )
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
         this.AV14WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV15WWPFormElementId = aP1_WWPFormElementId;
         this.AV5WWPFormInstanceElementId = aP2_WWPFormInstanceElementId;
         this.AV8SessionId = aP3_SessionId;
         this.AV16WWPFormInstance = aP4_WWPFormInstance;
         ExecuteImpl();
         aP4_WWPFormInstance=this.AV16WWPFormInstance;
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
                  AV14WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV14WWPDynamicFormMode", AV14WWPDynamicFormMode);
                  AV15WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV15WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV15WWPFormElementId), 4, 0));
                  AV5WWPFormInstanceElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV5WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV5WWPFormInstanceElementId), 4, 0));
                  AV8SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8SessionId", StringUtil.LTrimStr( (decimal)(AV8SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV16WWPFormInstance);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV14WWPDynamicFormMode,(short)AV15WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
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
         A212WWPFormElementOrderIndex = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementOrderIndex"), "."), 18, MidpointRounding.ToEven));
         A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV16WWPFormInstance);
         A207WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
         A211WWPFormElementParentId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementParentId"), "."), 18, MidpointRounding.ToEven));
         n211WWPFormElementParentId = false;
         AV15WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
         A217WWPFormElementType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementType"), "."), 18, MidpointRounding.ToEven));
         A236WWPFormElementMetadata = GetPar( "WWPFormElementMetadata");
         AV14WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
         A210WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
         AV5WWPFormInstanceElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceElementId"), "."), 18, MidpointRounding.ToEven));
         AV8SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
         A218WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementDataType"), "."), 18, MidpointRounding.ToEven));
         AV6Columns = (short)(Math.Round(NumberUtil.Val( GetPar( "Columns"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11WWP_DF_GroupMetadata);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFsgrid_refresh( A212WWPFormElementOrderIndex, A206WWPFormId, AV16WWPFormInstance, A207WWPFormVersionNumber, A211WWPFormElementParentId, AV15WWPFormElementId, A217WWPFormElementType, A236WWPFormElementMetadata, AV14WWPDynamicFormMode, A210WWPFormElementId, AV5WWPFormInstanceElementId, AV8SessionId, A218WWPFormElementDataType, AV6Columns, AV11WWP_DF_GroupMetadata, sPrefix) ;
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
            PA262( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS262( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form_FS_WC", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_fs_wc.aspx"+UrlEncode(StringUtil.RTrim(AV14WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV15WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV5WWPFormInstanceElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV8SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_fs_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLUMNS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6Columns), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_GROUPMETADATA", AV11WWP_DF_GroupMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_GROUPMETADATA", AV11WWP_DF_GroupMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_GROUPMETADATA", GetSecureSignedToken( sPrefix, AV11WWP_DF_GroupMetadata, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV14WWPDynamicFormMode", StringUtil.RTrim( wcpOAV14WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV15WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV15WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV5WWPFormInstanceElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV5WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTORDERINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(A212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV16WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV16WWPFormInstance);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTPARENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A217WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTMETADATA", A236WWPFormElementMetadata);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV14WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A218WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLUMNS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6Columns), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18AuxSessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_GROUPMETADATA", AV11WWP_DF_GroupMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_GROUPMETADATA", AV11WWP_DF_GroupMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_GROUPMETADATA", GetSecureSignedToken( sPrefix, AV11WWP_DF_GroupMetadata, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVISIBLECONDITION", AV17VisibleCondition);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVISIBLECONDITION", AV17VisibleCondition);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"subFsgrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseForm262( )
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
         return "WorkWithPlus.DynamicForms.WWP_DF_FS_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form_FS_WC", "") ;
      }

      protected void WB260( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_fs_wc.aspx");
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
            GxWebStd.gx_div_start( context, divFsgridcell_Internalname, 1, 0, "px", 0, "px", divFsgridcell_Class, "start", "top", "", "", "div");
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

      protected void START262( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form_FS_WC", ""), 0) ;
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
               STRUP260( ) ;
            }
         }
      }

      protected void WS262( )
      {
         START262( ) ;
         EVT262( ) ;
      }

      protected void EVT262( )
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
                                 STRUP260( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP260( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E11262 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP260( ) ;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "FSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "FSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP260( ) ;
                              }
                              nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
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
                                          E12262 ();
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
                                          /* Execute user event: Fsgrid.Load */
                                          E13262 ();
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
                                       STRUP260( ) ;
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
                                 sEvtType = StringUtil.Right( sEvt, 4);
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                                 if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "FSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP260( ) ;
                                    }
                                    nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                                    sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                                    SubsflControlProps_92( ) ;
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
                                                E12262 ();
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
                                                /* Execute user event: Fsgrid.Load */
                                                E13262 ();
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
                                             STRUP260( ) ;
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "FSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP260( ) ;
                              }
                              nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
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
                                          E12262 ();
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
                                          /* Execute user event: Fsgrid.Load */
                                          E13262 ();
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
                                       STRUP260( ) ;
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
                        if ( nCmpId == 13 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0013" + sEvtType;
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
                              WebComp_GX_Process.componentprocess(sPrefix+"W0013", sEvtType, sEvt);
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

      protected void WE262( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm262( ) ;
            }
         }
      }

      protected void PA262( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_fs_wc.aspx")), "workwithplus.dynamicforms.wwp_df_fs_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_fs_wc.aspx")))) ;
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

      protected void gxgrFsgrid_refresh( short A212WWPFormElementOrderIndex ,
                                         short A206WWPFormId ,
                                         GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV16WWPFormInstance ,
                                         short A207WWPFormVersionNumber ,
                                         short A211WWPFormElementParentId ,
                                         short AV15WWPFormElementId ,
                                         short A217WWPFormElementType ,
                                         string A236WWPFormElementMetadata ,
                                         string AV14WWPDynamicFormMode ,
                                         short A210WWPFormElementId ,
                                         short AV5WWPFormInstanceElementId ,
                                         short AV8SessionId ,
                                         short A218WWPFormElementDataType ,
                                         short AV6Columns ,
                                         WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata AV11WWP_DF_GroupMetadata ,
                                         string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FSGRID_nCurrentRecord = 0;
         RF262( ) ;
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
         RF262( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF262( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FsgridContainer.ClearRows();
         }
         wbStart = 9;
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
            E13262 ();
            wbEnd = 9;
            WB260( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes262( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLUMNS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6Columns), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_GROUPMETADATA", AV11WWP_DF_GroupMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_GROUPMETADATA", AV11WWP_DF_GroupMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_GROUPMETADATA", GetSecureSignedToken( sPrefix, AV11WWP_DF_GroupMetadata, context));
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

      protected void STRUP260( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12262 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV14WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV14WWPDynamicFormMode");
            wcpOAV15WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV15WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV5WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV5WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV8SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subFsgrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subFsgrid_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         E12262 ();
         if (returnInSub) return;
      }

      protected void E12262( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H00262 */
         pr_default.execute(0, new Object[] {AV16WWPFormInstance.gxTpr_Wwpformid, AV16WWPFormInstance.gxTpr_Wwpformversionnumber, AV15WWPFormElementId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A210WWPFormElementId = H00262_A210WWPFormElementId[0];
            A207WWPFormVersionNumber = H00262_A207WWPFormVersionNumber[0];
            A206WWPFormId = H00262_A206WWPFormId[0];
            A217WWPFormElementType = H00262_A217WWPFormElementType[0];
            A236WWPFormElementMetadata = H00262_A236WWPFormElementMetadata[0];
            if ( A217WWPFormElementType == 2 )
            {
               AV11WWP_DF_GroupMetadata.FromJSonString(A236WWPFormElementMetadata, null);
               AV6Columns = AV11WWP_DF_GroupMetadata.gxTpr_Columns;
               AssignAttri(sPrefix, false, "AV6Columns", StringUtil.LTrimStr( (decimal)(AV6Columns), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
               if ( AV11WWP_DF_GroupMetadata.gxTpr_Style == 0 )
               {
                  AV17VisibleCondition = AV11WWP_DF_GroupMetadata.gxTpr_Visiblecondition;
               }
            }
            else if ( A217WWPFormElementType == 5 )
            {
               AV13WWP_DF_StepMetadata.FromJSonString(A236WWPFormElementMetadata, null);
               AV6Columns = AV13WWP_DF_StepMetadata.gxTpr_Columns;
               AssignAttri(sPrefix, false, "AV6Columns", StringUtil.LTrimStr( (decimal)(AV6Columns), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
            }
            else if ( A217WWPFormElementType == 3 )
            {
               AV12WWP_DF_MultipleMetadata.FromJSonString(A236WWPFormElementMetadata, null);
               AV6Columns = AV12WWP_DF_MultipleMetadata.gxTpr_Columns;
               AssignAttri(sPrefix, false, "AV6Columns", StringUtil.LTrimStr( (decimal)(AV6Columns), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Execute user subroutine: 'UPDATE VISIBILITY' */
         S112 ();
         if (returnInSub) return;
         AV6Columns = (short)(((0==AV6Columns) ? 1 : AV6Columns));
         AssignAttri(sPrefix, false, "AV6Columns", StringUtil.LTrimStr( (decimal)(AV6Columns), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6Columns), "ZZZ9"), context));
         divFsgridcell_Class = StringUtil.Format( "col-xs-12 DynamicFormGridCell%1Columns", StringUtil.Trim( StringUtil.Str( (decimal)(AV6Columns), 4, 0)), "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, divFsgridcell_Internalname, "Class", divFsgridcell_Class, true);
      }

      private void E13262( )
      {
         /* Fsgrid_Load Routine */
         returnInSub = false;
         AV7LoadedElements = 0;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV15WWPFormElementId ,
                                              A211WWPFormElementParentId ,
                                              A206WWPFormId ,
                                              AV16WWPFormInstance.gxTpr_Wwpformid ,
                                              A207WWPFormVersionNumber ,
                                              AV16WWPFormInstance.gxTpr_Wwpformversionnumber } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor H00263 */
         pr_default.execute(1, new Object[] {AV16WWPFormInstance.gxTpr_Wwpformid, AV16WWPFormInstance.gxTpr_Wwpformversionnumber, AV15WWPFormElementId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A211WWPFormElementParentId = H00263_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = H00263_n211WWPFormElementParentId[0];
            A207WWPFormVersionNumber = H00263_A207WWPFormVersionNumber[0];
            A206WWPFormId = H00263_A206WWPFormId[0];
            A217WWPFormElementType = H00263_A217WWPFormElementType[0];
            A236WWPFormElementMetadata = H00263_A236WWPFormElementMetadata[0];
            A210WWPFormElementId = H00263_A210WWPFormElementId[0];
            A218WWPFormElementDataType = H00263_A218WWPFormElementDataType[0];
            A212WWPFormElementOrderIndex = H00263_A212WWPFormElementOrderIndex[0];
            if ( A217WWPFormElementType == 2 )
            {
               AV11WWP_DF_GroupMetadata.FromJSonString(A236WWPFormElementMetadata, null);
               if ( AV11WWP_DF_GroupMetadata.gxTpr_Style == 0 )
               {
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
                     WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                     WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                  }
               }
               else
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Wcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Group_WC")) != 0 )
                  {
                     WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_group_wc", new Object[] {context} );
                     WebComp_Wcchildren.ComponentInit();
                     WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Group_WC";
                     WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Group_WC";
                  }
                  if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                  {
                     WebComp_Wcchildren.setjustcreated();
                     WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                     WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                  }
               }
            }
            else if ( A217WWPFormElementType == 4 )
            {
               /* Object Property */
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  bDynCreated_Wcchildren = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Label_WC")) != 0 )
               {
                  WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_label_wc", new Object[] {context} );
                  WebComp_Wcchildren.ComponentInit();
                  WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Label_WC";
                  WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Label_WC";
               }
               if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
               {
                  WebComp_Wcchildren.setjustcreated();
                  WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                  WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
               }
            }
            else if ( A217WWPFormElementType == 3 )
            {
               AV12WWP_DF_MultipleMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
               AV12WWP_DF_MultipleMetadata.FromJSonString(A236WWPFormElementMetadata, null);
               if ( AV12WWP_DF_MultipleMetadata.gxTpr_Repetitionsdatatype == 1 )
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Wcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_MDataPlain_WC")) != 0 )
                  {
                     WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_mdataplain_wc", new Object[] {context} );
                     WebComp_Wcchildren.ComponentInit();
                     WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_MDataPlain_WC";
                     WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_MDataPlain_WC";
                  }
                  if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                  {
                     WebComp_Wcchildren.setjustcreated();
                     WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                     WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                  }
               }
               else
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Wcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_MDataGrid_WC")) != 0 )
                  {
                     WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_mdatagrid_wc", new Object[] {context} );
                     WebComp_Wcchildren.ComponentInit();
                     WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_MDataGrid_WC";
                     WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_MDataGrid_WC";
                  }
                  if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                  {
                     WebComp_Wcchildren.setjustcreated();
                     WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                     WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                  }
               }
            }
            else if ( A217WWPFormElementType == 1 )
            {
               if ( A218WWPFormElementDataType == 2 )
               {
                  AV10WWP_DF_CharMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                  if ( AV10WWP_DF_CharMetadata.gxTpr_Controltype == 1 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Text_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_text_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Text_WC";
                        WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Text_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else if ( AV10WWP_DF_CharMetadata.gxTpr_Controltype == 2 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_TextArea_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_textarea_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_TextArea_WC";
                        WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_TextArea_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else if ( AV10WWP_DF_CharMetadata.gxTpr_Controltype == 3 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_HTMLEditor_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_htmleditor_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_HTMLEditor_WC";
                        WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_HTMLEditor_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else if ( AV10WWP_DF_CharMetadata.gxTpr_Controltype == 4 )
                  {
                     if ( AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 1 )
                     {
                        if ( AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Hasdynamicoptions )
                        {
                           /* Object Property */
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              bDynCreated_Wcchildren = true;
                           }
                           if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_DynamicComboBox_WC")) != 0 )
                           {
                              WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_dynamiccombobox_wc", new Object[] {context} );
                              WebComp_Wcchildren.ComponentInit();
                              WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_DynamicComboBox_WC";
                              WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_DynamicComboBox_WC";
                           }
                           if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                           {
                              WebComp_Wcchildren.setjustcreated();
                              WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                              WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                           }
                        }
                        else
                        {
                           /* Object Property */
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              bDynCreated_Wcchildren = true;
                           }
                           if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_ComboBox_WC")) != 0 )
                           {
                              WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_combobox_wc", new Object[] {context} );
                              WebComp_Wcchildren.ComponentInit();
                              WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_ComboBox_WC";
                              WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_ComboBox_WC";
                           }
                           if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                           {
                              WebComp_Wcchildren.setjustcreated();
                              WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                              WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                           }
                        }
                     }
                     else if ( AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 2 )
                     {
                        if ( AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Hasdynamicoptions )
                        {
                           /* Object Property */
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              bDynCreated_Wcchildren = true;
                           }
                           if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_DynamicSuggest_WC")) != 0 )
                           {
                              WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_dynamicsuggest_wc", new Object[] {context} );
                              WebComp_Wcchildren.ComponentInit();
                              WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_DynamicSuggest_WC";
                              WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_DynamicSuggest_WC";
                           }
                           if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                           {
                              WebComp_Wcchildren.setjustcreated();
                              WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                              WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                           }
                        }
                        else
                        {
                           /* Object Property */
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              bDynCreated_Wcchildren = true;
                           }
                           if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Suggest_WC")) != 0 )
                           {
                              WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_suggest_wc", new Object[] {context} );
                              WebComp_Wcchildren.ComponentInit();
                              WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Suggest_WC";
                              WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Suggest_WC";
                           }
                           if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                           {
                              WebComp_Wcchildren.setjustcreated();
                              WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                              WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                           }
                        }
                     }
                     else if ( AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 3 )
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Wcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Radiobutton_WC")) != 0 )
                        {
                           WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_radiobutton_wc", new Object[] {context} );
                           WebComp_Wcchildren.ComponentInit();
                           WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Radiobutton_WC";
                           WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Radiobutton_WC";
                        }
                        if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                        {
                           WebComp_Wcchildren.setjustcreated();
                           WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                           WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                     else if ( AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 4 )
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Wcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_MCheckBox_WC")) != 0 )
                        {
                           WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_mcheckbox_wc", new Object[] {context} );
                           WebComp_Wcchildren.ComponentInit();
                           WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_MCheckBox_WC";
                           WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_MCheckBox_WC";
                        }
                        if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                        {
                           WebComp_Wcchildren.setjustcreated();
                           WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                           WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                  }
               }
               else if ( ( A218WWPFormElementDataType == 6 ) || ( A218WWPFormElementDataType == 7 ) || ( A218WWPFormElementDataType == 8 ) )
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Wcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Text_WC")) != 0 )
                  {
                     WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_text_wc", new Object[] {context} );
                     WebComp_Wcchildren.ComponentInit();
                     WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Text_WC";
                     WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Text_WC";
                  }
                  if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                  {
                     WebComp_Wcchildren.setjustcreated();
                     WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                     WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                  }
               }
               else if ( A218WWPFormElementDataType == 1 )
               {
                  AV9WWP_DF_BooleanMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                  if ( AV9WWP_DF_BooleanMetadata.gxTpr_Controltype == 1 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Checkbox_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_checkbox_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Checkbox_WC";
                        WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Checkbox_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else if ( AV9WWP_DF_BooleanMetadata.gxTpr_Controltype == 2 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Wcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Switch_WC")) != 0 )
                     {
                        WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_switch_wc", new Object[] {context} );
                        WebComp_Wcchildren.ComponentInit();
                        WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Switch_WC";
                        WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Switch_WC";
                     }
                     if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                     {
                        WebComp_Wcchildren.setjustcreated();
                        WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                        WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                     }
                  }
               }
               else if ( A218WWPFormElementDataType == 4 )
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Wcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Date_WC")) != 0 )
                  {
                     WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_date_wc", new Object[] {context} );
                     WebComp_Wcchildren.ComponentInit();
                     WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Date_WC";
                     WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Date_WC";
                  }
                  if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                  {
                     WebComp_Wcchildren.setjustcreated();
                     WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                     WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                  }
               }
               else if ( A218WWPFormElementDataType == 5 )
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Wcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Datetime_WC")) != 0 )
                  {
                     WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_datetime_wc", new Object[] {context} );
                     WebComp_Wcchildren.ComponentInit();
                     WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Datetime_WC";
                     WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Datetime_WC";
                  }
                  if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                  {
                     WebComp_Wcchildren.setjustcreated();
                     WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                     WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                  }
               }
               else if ( A218WWPFormElementDataType == 3 )
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Wcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Numeric_WC")) != 0 )
                  {
                     WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_numeric_wc", new Object[] {context} );
                     WebComp_Wcchildren.ComponentInit();
                     WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Numeric_WC";
                     WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Numeric_WC";
                  }
                  if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                  {
                     WebComp_Wcchildren.setjustcreated();
                     WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                     WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                  }
               }
               else if ( A218WWPFormElementDataType == 10 )
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Wcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Image_WC")) != 0 )
                  {
                     WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_image_wc", new Object[] {context} );
                     WebComp_Wcchildren.ComponentInit();
                     WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Image_WC";
                     WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Image_WC";
                  }
                  if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                  {
                     WebComp_Wcchildren.setjustcreated();
                     WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                     WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                  }
               }
               else if ( A218WWPFormElementDataType == 9 )
               {
                  /* Object Property */
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     bDynCreated_Wcchildren = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_File_WC")) != 0 )
                  {
                     WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_file_wc", new Object[] {context} );
                     WebComp_Wcchildren.ComponentInit();
                     WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_File_WC";
                     WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_File_WC";
                  }
                  if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
                  {
                     WebComp_Wcchildren.setjustcreated();
                     WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx,(string)AV14WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV5WWPFormInstanceElementId,(short)AV8SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV16WWPFormInstance});
                     WebComp_Wcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                  }
               }
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
            AV7LoadedElements = (short)(AV7LoadedElements+1);
            if ( ( AV6Columns > 1 ) && ( AV7LoadedElements == AV6Columns ) )
            {
               /* Object Property */
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  bDynCreated_Wcchildren = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_EmptyWC")) != 0 )
               {
                  WebComp_Wcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_emptywc", new Object[] {context} );
                  WebComp_Wcchildren.ComponentInit();
                  WebComp_Wcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_EmptyWC";
                  WebComp_Wcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_EmptyWC";
               }
               if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
               {
                  WebComp_Wcchildren.setjustcreated();
                  WebComp_Wcchildren.componentprepare(new Object[] {(string)sPrefix+"W0013",(string)sGXsfl_9_idx});
                  WebComp_Wcchildren.componentbind(new Object[] {});
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
               AV7LoadedElements = 0;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WWP_DF_GroupMetadata", AV11WWP_DF_GroupMetadata);
      }

      protected void E11262( )
      {
         /* General\GlobalEvents_Dynamicform_updatevisibilities Routine */
         returnInSub = false;
         if ( AV11WWP_DF_GroupMetadata.gxTpr_Style == 0 )
         {
            AV17VisibleCondition = AV11WWP_DF_GroupMetadata.gxTpr_Visiblecondition;
         }
         else
         {
            AV17VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         }
         if ( ( AV18AuxSessionId == AV8SessionId ) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV17VisibleCondition.gxTpr_Expression))) )
         {
            GXt_SdtWWP_FormInstance1 = AV16WWPFormInstance;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV8SessionId, out  GXt_SdtWWP_FormInstance1) ;
            AV16WWPFormInstance = GXt_SdtWWP_FormInstance1;
            /* Execute user subroutine: 'UPDATE VISIBILITY' */
            S112 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17VisibleCondition", AV17VisibleCondition);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV16WWPFormInstance", AV16WWPFormInstance);
      }

      protected void S112( )
      {
         /* 'UPDATE VISIBILITY' Routine */
         returnInSub = false;
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV16WWPFormInstance,  AV5WWPFormInstanceElementId,  AV17VisibleCondition) )
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

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV14WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV14WWPDynamicFormMode", AV14WWPDynamicFormMode);
         AV15WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV15WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV15WWPFormElementId), 4, 0));
         AV5WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV5WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV5WWPFormInstanceElementId), 4, 0));
         AV8SessionId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV8SessionId", StringUtil.LTrimStr( (decimal)(AV8SessionId), 4, 0));
         AV16WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,4);
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
         PA262( ) ;
         WS262( ) ;
         WE262( ) ;
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
         sCtrlAV14WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV15WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV5WWPFormInstanceElementId = (string)((string)getParm(obj,2));
         sCtrlAV8SessionId = (string)((string)getParm(obj,3));
         sCtrlAV16WWPFormInstance = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA262( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_fs_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA262( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV14WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV14WWPDynamicFormMode", AV14WWPDynamicFormMode);
            AV15WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV15WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV15WWPFormElementId), 4, 0));
            AV5WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV5WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV5WWPFormInstanceElementId), 4, 0));
            AV8SessionId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV8SessionId", StringUtil.LTrimStr( (decimal)(AV8SessionId), 4, 0));
            AV16WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,6);
         }
         wcpOAV14WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV14WWPDynamicFormMode");
         wcpOAV15WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV15WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV5WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV5WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV8SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV14WWPDynamicFormMode, wcpOAV14WWPDynamicFormMode) != 0 ) || ( AV15WWPFormElementId != wcpOAV15WWPFormElementId ) || ( AV5WWPFormInstanceElementId != wcpOAV5WWPFormInstanceElementId ) || ( AV8SessionId != wcpOAV8SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV14WWPDynamicFormMode = AV14WWPDynamicFormMode;
         wcpOAV15WWPFormElementId = AV15WWPFormElementId;
         wcpOAV5WWPFormInstanceElementId = AV5WWPFormInstanceElementId;
         wcpOAV8SessionId = AV8SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV14WWPDynamicFormMode = cgiGet( sPrefix+"AV14WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV14WWPDynamicFormMode) > 0 )
         {
            AV14WWPDynamicFormMode = cgiGet( sCtrlAV14WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV14WWPDynamicFormMode", AV14WWPDynamicFormMode);
         }
         else
         {
            AV14WWPDynamicFormMode = cgiGet( sPrefix+"AV14WWPDynamicFormMode_PARM");
         }
         sCtrlAV15WWPFormElementId = cgiGet( sPrefix+"AV15WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV15WWPFormElementId) > 0 )
         {
            AV15WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV15WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV15WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV15WWPFormElementId), 4, 0));
         }
         else
         {
            AV15WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV15WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV5WWPFormInstanceElementId = cgiGet( sPrefix+"AV5WWPFormInstanceElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV5WWPFormInstanceElementId) > 0 )
         {
            AV5WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV5WWPFormInstanceElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV5WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV5WWPFormInstanceElementId), 4, 0));
         }
         else
         {
            AV5WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV5WWPFormInstanceElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV8SessionId = cgiGet( sPrefix+"AV8SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV8SessionId) > 0 )
         {
            AV8SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8SessionId", StringUtil.LTrimStr( (decimal)(AV8SessionId), 4, 0));
         }
         else
         {
            AV8SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV16WWPFormInstance = cgiGet( sPrefix+"AV16WWPFormInstance_CTRL");
         if ( StringUtil.Len( sCtrlAV16WWPFormInstance) > 0 )
         {
            AV16WWPFormInstance.FromXml(cgiGet( sCtrlAV16WWPFormInstance), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV16WWPFormInstance_PARM"), AV16WWPFormInstance);
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
         PA262( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS262( ) ;
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
         WS262( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV14WWPDynamicFormMode_PARM", StringUtil.RTrim( AV14WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV14WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV14WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV14WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV15WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV15WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV15WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV15WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV5WWPFormInstanceElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV5WWPFormInstanceElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV5WWPFormInstanceElementId_CTRL", StringUtil.RTrim( sCtrlAV5WWPFormInstanceElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8SessionId_CTRL", StringUtil.RTrim( sCtrlAV8SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV16WWPFormInstance_PARM", AV16WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV16WWPFormInstance_PARM", AV16WWPFormInstance);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16WWPFormInstance)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16WWPFormInstance_CTRL", StringUtil.RTrim( sCtrlAV16WWPFormInstance));
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
         WE262( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145241363", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_fs_wc.js", "?20256145241364", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_92( )
      {
         subFsgrid_Internalname = sPrefix+"FSGRID";
      }

      protected void SubsflControlProps_fel_92( )
      {
         subFsgrid_Internalname = sPrefix+"FSGRID";
      }

      protected void sendrow_92( )
      {
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         WB260( ) ;
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
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFsgridlayouttable_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0013"+sGXsfl_9_idx, StringUtil.RTrim( WebComp_Wcchildren_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0013"+sGXsfl_9_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_9_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Wcchildren_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0013"+sGXsfl_9_idx, cgiGet( "_EventName"), 1) != 0 ) )
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
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0013"+sGXsfl_9_idx);
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
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes262( ) ;
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
         divFsgridlayouttable_Internalname = sPrefix+"FSGRIDLAYOUTTABLE";
         divFsgridcell_Internalname = sPrefix+"FSGRIDCELL";
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
         subFsgrid_Class = "FreeStyleGrid";
         subFsgrid_Backcolorstyle = 0;
         divFsgridcell_Class = "col-xs-12";
         divLayoutmaintable_Class = "Table";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"A212WWPFormElementOrderIndex","fld":"WWPFORMELEMENTORDERINDEX","pic":"ZZZ9"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"AV16WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"AV15WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"A236WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA"},{"av":"AV14WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"A210WWPFormElementId","fld":"WWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV5WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV8SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"A218WWPFormElementDataType","fld":"WWPFORMELEMENTDATATYPE","pic":"Z9"},{"av":"sPrefix"},{"av":"AV6Columns","fld":"vCOLUMNS","pic":"ZZZ9","hsh":true},{"av":"AV11WWP_DF_GroupMetadata","fld":"vWWP_DF_GROUPMETADATA","hsh":true}]}""");
         setEventMetadata("FSGRID.LOAD","""{"handler":"E13262","iparms":[{"av":"A212WWPFormElementOrderIndex","fld":"WWPFORMELEMENTORDERINDEX","pic":"ZZZ9"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"AV16WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"AV15WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"A236WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA"},{"av":"AV14WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"A210WWPFormElementId","fld":"WWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV5WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV8SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"A218WWPFormElementDataType","fld":"WWPFORMELEMENTDATATYPE","pic":"Z9"},{"av":"AV6Columns","fld":"vCOLUMNS","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("FSGRID.LOAD",""","oparms":[{"av":"AV11WWP_DF_GroupMetadata","fld":"vWWP_DF_GROUPMETADATA","hsh":true},{"ctrl":"WCCHILDREN"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES","""{"handler":"E11262","iparms":[{"av":"AV18AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV11WWP_DF_GroupMetadata","fld":"vWWP_DF_GROUPMETADATA","hsh":true},{"av":"AV8SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV17VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"AV5WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV16WWPFormInstance","fld":"vWWPFORMINSTANCE"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",""","oparms":[{"av":"AV17VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"AV16WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"}]}""");
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
         AV16WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         wcpOAV14WWPDynamicFormMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         A236WWPFormElementMetadata = "";
         AV11WWP_DF_GroupMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV17VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         GX_FocusControl = "";
         FsgridContainer = new GXWebGrid( context);
         sStyleString = "";
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
         H00262_A210WWPFormElementId = new short[1] ;
         H00262_A207WWPFormVersionNumber = new short[1] ;
         H00262_A206WWPFormId = new short[1] ;
         H00262_A217WWPFormElementType = new short[1] ;
         H00262_A236WWPFormElementMetadata = new string[] {""} ;
         AV13WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
         AV12WWP_DF_MultipleMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
         H00263_A211WWPFormElementParentId = new short[1] ;
         H00263_n211WWPFormElementParentId = new bool[] {false} ;
         H00263_A207WWPFormVersionNumber = new short[1] ;
         H00263_A206WWPFormId = new short[1] ;
         H00263_A217WWPFormElementType = new short[1] ;
         H00263_A236WWPFormElementMetadata = new string[] {""} ;
         H00263_A210WWPFormElementId = new short[1] ;
         H00263_A218WWPFormElementDataType = new short[1] ;
         H00263_A212WWPFormElementOrderIndex = new short[1] ;
         AV10WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV9WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
         FsgridRow = new GXWebRow();
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV14WWPDynamicFormMode = "";
         sCtrlAV15WWPFormElementId = "";
         sCtrlAV5WWPFormInstanceElementId = "";
         sCtrlAV8SessionId = "";
         sCtrlAV16WWPFormInstance = "";
         subFsgrid_Linesclass = "";
         subFsgrid_Header = "";
         FsgridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_fs_wc__default(),
            new Object[][] {
                new Object[] {
               H00262_A210WWPFormElementId, H00262_A207WWPFormVersionNumber, H00262_A206WWPFormId, H00262_A217WWPFormElementType, H00262_A236WWPFormElementMetadata
               }
               , new Object[] {
               H00263_A211WWPFormElementParentId, H00263_n211WWPFormElementParentId, H00263_A207WWPFormVersionNumber, H00263_A206WWPFormId, H00263_A217WWPFormElementType, H00263_A236WWPFormElementMetadata, H00263_A210WWPFormElementId, H00263_A218WWPFormElementDataType, H00263_A212WWPFormElementOrderIndex
               }
            }
         );
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcchildren = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV15WWPFormElementId ;
      private short AV5WWPFormInstanceElementId ;
      private short AV8SessionId ;
      private short wcpOAV15WWPFormElementId ;
      private short wcpOAV5WWPFormInstanceElementId ;
      private short wcpOAV8SessionId ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A212WWPFormElementOrderIndex ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A211WWPFormElementParentId ;
      private short A217WWPFormElementType ;
      private short A210WWPFormElementId ;
      private short A218WWPFormElementDataType ;
      private short AV6Columns ;
      private short AV18AuxSessionId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short subFsgrid_Backcolorstyle ;
      private short AV7LoadedElements ;
      private short AV16WWPFormInstance_gxTpr_Wwpformid ;
      private short AV16WWPFormInstance_gxTpr_Wwpformversionnumber ;
      private short nGXWrapped ;
      private short subFsgrid_Backstyle ;
      private short subFsgrid_Allowselection ;
      private short subFsgrid_Allowhovering ;
      private short subFsgrid_Allowcollapsing ;
      private short subFsgrid_Collapsed ;
      private short FSGRID_nEOF ;
      private int nRC_GXsfl_9 ;
      private int nGXsfl_9_idx=1 ;
      private int subFsgrid_Recordcount ;
      private int nGXsfl_9_webc_idx=0 ;
      private int subFsgrid_Islastpage ;
      private int idxLst ;
      private int subFsgrid_Backcolor ;
      private int subFsgrid_Allbackcolor ;
      private int subFsgrid_Selectedindex ;
      private int subFsgrid_Selectioncolor ;
      private int subFsgrid_Hoveringcolor ;
      private long FSGRID_nCurrentRecord ;
      private long FSGRID_nFirstRecordOnPage ;
      private string AV14WWPDynamicFormMode ;
      private string wcpOAV14WWPDynamicFormMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_9_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divFsgridcell_Internalname ;
      private string divFsgridcell_Class ;
      private string sStyleString ;
      private string subFsgrid_Internalname ;
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
      private string WebComp_Wcchildren_Component ;
      private string sCtrlAV14WWPDynamicFormMode ;
      private string sCtrlAV15WWPFormElementId ;
      private string sCtrlAV5WWPFormInstanceElementId ;
      private string sCtrlAV8SessionId ;
      private string sCtrlAV16WWPFormInstance ;
      private string subFsgrid_Class ;
      private string subFsgrid_Linesclass ;
      private string divFsgridlayouttable_Internalname ;
      private string subFsgrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n211WWPFormElementParentId ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcchildren ;
      private string A236WWPFormElementMetadata ;
      private GXWebComponent WebComp_Wcchildren ;
      private GXWebGrid FsgridContainer ;
      private GXWebRow FsgridRow ;
      private GXWebColumn FsgridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV16WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata AV11WWP_DF_GroupMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV17VisibleCondition ;
      private GXWebComponent WebComp_GX_Process ;
      private IDataStoreProvider pr_default ;
      private short[] H00262_A210WWPFormElementId ;
      private short[] H00262_A207WWPFormVersionNumber ;
      private short[] H00262_A206WWPFormId ;
      private short[] H00262_A217WWPFormElementType ;
      private string[] H00262_A236WWPFormElementMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata AV13WWP_DF_StepMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV12WWP_DF_MultipleMetadata ;
      private short[] H00263_A211WWPFormElementParentId ;
      private bool[] H00263_n211WWPFormElementParentId ;
      private short[] H00263_A207WWPFormVersionNumber ;
      private short[] H00263_A206WWPFormId ;
      private short[] H00263_A217WWPFormElementType ;
      private string[] H00263_A236WWPFormElementMetadata ;
      private short[] H00263_A210WWPFormElementId ;
      private short[] H00263_A218WWPFormElementDataType ;
      private short[] H00263_A212WWPFormElementOrderIndex ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV10WWP_DF_CharMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata AV9WWP_DF_BooleanMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_df_fs_wc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00263( IGxContext context ,
                                             short AV15WWPFormElementId ,
                                             short A211WWPFormElementParentId ,
                                             short A206WWPFormId ,
                                             short AV16WWPFormInstance_gxTpr_Wwpformid ,
                                             short A207WWPFormVersionNumber ,
                                             short AV16WWPFormInstance_gxTpr_Wwpformversionnumber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[3];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT WWPFormElementParentId, WWPFormVersionNumber, WWPFormId, WWPFormElementType, WWPFormElementMetadata, WWPFormElementId, WWPFormElementDataType, WWPFormElementOrderIndex FROM WWP_FormElement";
         AddWhere(sWhereString, "(WWPFormId = :AV16WWPF_2Wwpformid)");
         AddWhere(sWhereString, "(WWPFormVersionNumber = :AV16WWPF_1Wwpformversionnumbe)");
         if ( AV15WWPFormElementId > 0 )
         {
            AddWhere(sWhereString, "(WWPFormElementParentId = :AV15WWPFormElementId)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV15WWPFormElementId == 0 )
         {
            AddWhere(sWhereString, "(WWPFormElementParentId IS NULL)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPFormElementOrderIndex";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H00263(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH00262;
          prmH00262 = new Object[] {
          new ParDef("AV16WWPF_2Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV16WWPF_1Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV15WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmH00263;
          prmH00263 = new Object[] {
          new ParDef("AV16WWPF_2Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV16WWPF_1Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV15WWPFormElementId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00262", "SELECT WWPFormElementId, WWPFormVersionNumber, WWPFormId, WWPFormElementType, WWPFormElementMetadata FROM WWP_FormElement WHERE WWPFormId = :AV16WWPF_2Wwpformid and WWPFormVersionNumber = :AV16WWPF_1Wwpformversionnumbe and WWPFormElementId = :AV15WWPFormElementId ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00262,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00263", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00263,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
