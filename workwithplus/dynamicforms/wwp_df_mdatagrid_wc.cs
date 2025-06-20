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
   public class wwp_df_mdatagrid_wc : GXWebComponent
   {
      public wwp_df_mdatagrid_wc( )
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

      public wwp_df_mdatagrid_wc( IGxContext context )
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
         this.AV16WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV17WWPFormElementId = aP1_WWPFormElementId;
         this.AV28WWPFormInstanceElementId = aP2_WWPFormInstanceElementId;
         this.AV11SessionId = aP3_SessionId;
         this.AV22WWPFormInstance = aP4_WWPFormInstance;
         ExecuteImpl();
         aP4_WWPFormInstance=this.AV22WWPFormInstance;
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
                  AV16WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV16WWPDynamicFormMode", AV16WWPDynamicFormMode);
                  AV17WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV17WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV17WWPFormElementId), 4, 0));
                  AV28WWPFormInstanceElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV28WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV28WWPFormInstanceElementId), 4, 0));
                  AV11SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV11SessionId", StringUtil.LTrimStr( (decimal)(AV11SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV22WWPFormInstance);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV16WWPDynamicFormMode,(short)AV17WWPFormElementId,(short)AV28WWPFormInstanceElementId,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
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
         AV17WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV22WWPFormInstance);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV15WWP_DF_ElementsRepeaterMetadata);
         AV16WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10MultipleDataWWPFormInstanceElementId);
         A212WWPFormElementOrderIndex = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementOrderIndex"), "."), 18, MidpointRounding.ToEven));
         A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
         A207WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
         A211WWPFormElementParentId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementParentId"), "."), 18, MidpointRounding.ToEven));
         n211WWPFormElementParentId = false;
         A229WWPFormElementTitle = GetPar( "WWPFormElementTitle");
         A217WWPFormElementType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementType"), "."), 18, MidpointRounding.ToEven));
         A236WWPFormElementMetadata = GetPar( "WWPFormElementMetadata");
         AV11SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
         A210WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
         A218WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementDataType"), "."), 18, MidpointRounding.ToEven));
         AV18WWPFormElementIdSimpleChildren = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementIdSimpleChildren"), "."), 18, MidpointRounding.ToEven));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFsgrid_refresh( AV17WWPFormElementId, AV22WWPFormInstance, AV15WWP_DF_ElementsRepeaterMetadata, AV16WWPDynamicFormMode, AV10MultipleDataWWPFormInstanceElementId, A212WWPFormElementOrderIndex, A206WWPFormId, A207WWPFormVersionNumber, A211WWPFormElementParentId, A229WWPFormElementTitle, A217WWPFormElementType, A236WWPFormElementMetadata, AV11SessionId, A210WWPFormElementId, A218WWPFormElementDataType, AV18WWPFormElementIdSimpleChildren, sPrefix) ;
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
            PA2D2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               /* Using cursor H002D3 */
               pr_default.execute(0, new Object[] {AV22WWPFormInstance.gxTpr_Wwpformid, AV22WWPFormInstance.gxTpr_Wwpformversionnumber, AV17WWPFormElementId});
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A40000GXC1 = H002D3_A40000GXC1[0];
                  n40000GXC1 = H002D3_n40000GXC1[0];
               }
               else
               {
                  A40000GXC1 = 0;
                  n40000GXC1 = false;
                  AssignAttri(sPrefix, false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
               }
               pr_default.close(0);
               WS2D2( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form_Multiple Data Grid_WC", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_mdatagrid_wc.aspx"+UrlEncode(StringUtil.RTrim(AV16WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV17WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV28WWPFormInstanceElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV11SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_mdatagrid_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV15WWP_DF_ElementsRepeaterMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV15WWP_DF_ElementsRepeaterMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_ELEMENTSREPEATERMETADATA", GetSecureSignedToken( sPrefix, AV15WWP_DF_ElementsRepeaterMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTIDSIMPLECHILDREN", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18WWPFormElementIdSimpleChildren), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTIDSIMPLECHILDREN", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV18WWPFormElementIdSimpleChildren), "ZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV16WWPDynamicFormMode", StringUtil.RTrim( wcpOAV16WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV17WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV17WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV28WWPFormInstanceElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV28WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV11SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV11SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV22WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV22WWPFormInstance);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV15WWP_DF_ElementsRepeaterMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV15WWP_DF_ElementsRepeaterMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_ELEMENTSREPEATERMETADATA", GetSecureSignedToken( sPrefix, AV15WWP_DF_ElementsRepeaterMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV16WWPDynamicFormMode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID", AV10MultipleDataWWPFormInstanceElementId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID", AV10MultipleDataWWPFormInstanceElementId);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTORDERINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(A212WWPFormElementOrderIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTPARENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A211WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTITLE", A229WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A217WWPFormElementType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTMETADATA", A236WWPFormElementMetadata);
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A210WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A218WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTIDNEW", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26WWPFormInstanceElementIdNew), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTIDSIMPLECHILDREN", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18WWPFormElementIdSimpleChildren), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTIDSIMPLECHILDREN", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV18WWPFormElementIdSimpleChildren), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTIDAUX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24WWPFormInstanceElementIdAux), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AuxSessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMULTIPLEDATAREPETITIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9MultipleDataRepetitions), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subFsgrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsgrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXC1", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40000GXC1), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseForm2D2( )
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
            if ( ! ( WebComp_Datawcchildren == null ) )
            {
               WebComp_Datawcchildren.componentjscripts();
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
         return "WorkWithPlus.DynamicForms.WWP_DF_MDataGrid_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form_Multiple Data Grid_WC", "") ;
      }

      protected void WB2D0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_mdatagrid_wc.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MultipleDataGridCell GridNoBorder", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "end", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonGray";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaddchild_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(9), 1, 0)+","+"null"+");", bttBtnaddchild_Caption, bttBtnaddchild_Jsonclick, 5, context.GetMessage( "Add child", ""), "", StyleString, ClassString, bttBtnaddchild_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOADDCHILD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_DF_MDataGrid_WC.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
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

      protected void START2D2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form_Multiple Data Grid_WC", ""), 0) ;
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
               STRUP2D0( ) ;
            }
         }
      }

      protected void WS2D2( )
      {
         START2D2( ) ;
         EVT2D2( ) ;
      }

      protected void EVT2D2( )
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
                                 STRUP2D0( ) ;
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
                                 STRUP2D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAddChild' */
                                    E112D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_DELETEGRIDRECORD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E122D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E132D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2D0( ) ;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "FSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "FSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "FSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2D0( ) ;
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
                                          E142D2 ();
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
                                          E152D2 ();
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
                                          E162D2 ();
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
                                       STRUP2D0( ) ;
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
                                 if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "FSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP2D0( ) ;
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
                                                E142D2 ();
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
                                                E152D2 ();
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
                                                E162D2 ();
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
                                             STRUP2D0( ) ;
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
                                 else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "FSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP2D0( ) ;
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
                                                E142D2 ();
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
                                                E152D2 ();
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
                                                E162D2 ();
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
                                             STRUP2D0( ) ;
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "FSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2D0( ) ;
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
                                          E142D2 ();
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
                                          E152D2 ();
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
                                          E162D2 ();
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
                                       STRUP2D0( ) ;
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "FSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2D0( ) ;
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
                                          E142D2 ();
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
                                          E152D2 ();
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
                                          E162D2 ();
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
                                       STRUP2D0( ) ;
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
                        if ( nCmpId == 20 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0020" + sEvtType;
                           OldDatawcchildren = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldDatawcchildren) == 0 ) || ( StringUtil.StrCmp(OldDatawcchildren, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldDatawcchildren, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldDatawcchildren";
                              WebComp_GX_Process_Component = OldDatawcchildren;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0020", sEvtType, sEvt);
                           }
                           nGXsfl_9_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Datawcchildren";
                           WebComp_GX_Process_Component = OldDatawcchildren;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2D2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2D2( ) ;
            }
         }
      }

      protected void PA2D2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_mdatagrid_wc.aspx")), "workwithplus.dynamicforms.wwp_df_mdatagrid_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_mdatagrid_wc.aspx")))) ;
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

      protected void gxgrFsgrid_refresh( short AV17WWPFormElementId ,
                                         GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV22WWPFormInstance ,
                                         WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV15WWP_DF_ElementsRepeaterMetadata ,
                                         string AV16WWPDynamicFormMode ,
                                         GxSimpleCollection<short> AV10MultipleDataWWPFormInstanceElementId ,
                                         short A212WWPFormElementOrderIndex ,
                                         short A206WWPFormId ,
                                         short A207WWPFormVersionNumber ,
                                         short A211WWPFormElementParentId ,
                                         string A229WWPFormElementTitle ,
                                         short A217WWPFormElementType ,
                                         string A236WWPFormElementMetadata ,
                                         short AV11SessionId ,
                                         short A210WWPFormElementId ,
                                         short A218WWPFormElementDataType ,
                                         short AV18WWPFormElementIdSimpleChildren ,
                                         string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FSGRID_nCurrentRecord = 0;
         RF2D2( ) ;
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
         RF2D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FsgridContainer.ClearRows();
         }
         wbStart = 9;
         /* Execute user event: Refresh */
         E152D2 ();
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
         FsgridContainer.AddObjectProperty("GridName", "Fsgrid");
         FsgridContainer.AddObjectProperty("SflColumns", subFsgrid_Columns);
         FsgridContainer.AddObjectProperty("CmpContext", sPrefix);
         FsgridContainer.AddObjectProperty("InMasterPage", "false");
         FsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
         FsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
         FsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
         FsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
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
               if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
               {
                  WebComp_Datawcchildren.componentstart();
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
            E162D2 ();
            wbEnd = 9;
            WB2D0( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2D2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV15WWP_DF_ElementsRepeaterMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV15WWP_DF_ElementsRepeaterMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_ELEMENTSREPEATERMETADATA", GetSecureSignedToken( sPrefix, AV15WWP_DF_ElementsRepeaterMetadata, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTIDSIMPLECHILDREN", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18WWPFormElementIdSimpleChildren), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTIDSIMPLECHILDREN", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV18WWPFormElementIdSimpleChildren), "ZZZ9"), context));
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
         /* Using cursor H002D5 */
         pr_default.execute(1, new Object[] {AV22WWPFormInstance.gxTpr_Wwpformid, AV22WWPFormInstance.gxTpr_Wwpformversionnumber, AV17WWPFormElementId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40000GXC1 = H002D5_A40000GXC1[0];
            n40000GXC1 = H002D5_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri(sPrefix, false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         pr_default.close(1);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E142D2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV16WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV16WWPDynamicFormMode");
            wcpOAV17WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV17WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV28WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV28WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV11SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV11SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         E142D2 ();
         if (returnInSub) return;
      }

      protected void E142D2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H002D6 */
         pr_default.execute(2, new Object[] {AV22WWPFormInstance.gxTpr_Wwpformid, AV22WWPFormInstance.gxTpr_Wwpformversionnumber, AV17WWPFormElementId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A210WWPFormElementId = H002D6_A210WWPFormElementId[0];
            A207WWPFormVersionNumber = H002D6_A207WWPFormVersionNumber[0];
            A206WWPFormId = H002D6_A206WWPFormId[0];
            A229WWPFormElementTitle = H002D6_A229WWPFormElementTitle[0];
            A236WWPFormElementMetadata = H002D6_A236WWPFormElementMetadata[0];
            AV21WWPFormElementTitle = A229WWPFormElementTitle;
            AV20WWPFormElementMetadata = A236WWPFormElementMetadata;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         AV15WWP_DF_ElementsRepeaterMetadata.FromJSonString(AV20WWPFormElementMetadata, null);
         AV18WWPFormElementIdSimpleChildren = AV17WWPFormElementId;
         AssignAttri(sPrefix, false, "AV18WWPFormElementIdSimpleChildren", StringUtil.LTrimStr( (decimal)(AV18WWPFormElementIdSimpleChildren), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTIDSIMPLECHILDREN", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV18WWPFormElementIdSimpleChildren), "ZZZ9"), context));
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getsimpleelementofmultipledata(context ).execute(  AV22WWPFormInstance.gxTpr_Wwpformid,  AV22WWPFormInstance.gxTpr_Wwpformversionnumber, ref  AV18WWPFormElementIdSimpleChildren) ;
         AssignAttri(sPrefix, false, "AV18WWPFormElementIdSimpleChildren", StringUtil.LTrimStr( (decimal)(AV18WWPFormElementIdSimpleChildren), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTIDSIMPLECHILDREN", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV18WWPFormElementIdSimpleChildren), "ZZZ9"), context));
         AV10MultipleDataWWPFormInstanceElementId = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         AV32GXV1 = 1;
         while ( AV32GXV1 <= AV22WWPFormInstance.gxTpr_Element.Count )
         {
            AV23WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV22WWPFormInstance.gxTpr_Element.Item(AV32GXV1));
            if ( ( AV23WWPFormInstanceElement.gxTpr_Wwpformelementid == AV18WWPFormElementIdSimpleChildren ) && ( ! StringUtil.Contains( AV23WWPFormInstanceElement.ToJSonString(true, true), "\"Mode\":\"DLT\"") ) )
            {
               AV10MultipleDataWWPFormInstanceElementId.Add(AV23WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid, 0);
            }
            AV32GXV1 = (int)(AV32GXV1+1);
         }
         if ( AV15WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 )
         {
            bttBtnaddchild_Caption = AV15WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildcaption;
            AssignProp(sPrefix, false, bttBtnaddchild_Internalname, "Caption", bttBtnaddchild_Caption, true);
         }
         if ( AV10MultipleDataWWPFormInstanceElementId.Count == 0 )
         {
            if ( StringUtil.StrCmp(AV16WWPDynamicFormMode, "INS") != 0 )
            {
               /* Using cursor H002D7 */
               pr_default.execute(3, new Object[] {AV27WWPFormInstanceId, AV18WWPFormElementIdSimpleChildren});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A210WWPFormElementId = H002D7_A210WWPFormElementId[0];
                  A214WWPFormInstanceId = H002D7_A214WWPFormInstanceId[0];
                  A215WWPFormInstanceElementId = H002D7_A215WWPFormInstanceElementId[0];
                  AV10MultipleDataWWPFormInstanceElementId.Add(A215WWPFormInstanceElementId, 0);
                  pr_default.readNext(3);
               }
               pr_default.close(3);
            }
            else
            {
               if ( AV15WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 2 )
               {
                  AV9MultipleDataRepetitions = AV15WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_fixedvalue.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV9MultipleDataRepetitions", StringUtil.LTrimStr( (decimal)(AV9MultipleDataRepetitions), 4, 0));
               }
               else
               {
                  if ( AV15WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 3 )
                  {
                     GXt_SdtWWP_FormInstance1 = AV22WWPFormInstance;
                     new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV11SessionId, out  GXt_SdtWWP_FormInstance1) ;
                     AV22WWPFormInstance = GXt_SdtWWP_FormInstance1;
                     AV34GXV2 = 1;
                     while ( AV34GXV2 <= AV22WWPFormInstance.gxTpr_Element.Count )
                     {
                        AV23WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV22WWPFormInstance.gxTpr_Element.Item(AV34GXV2));
                        if ( AV23WWPFormInstanceElement.gxTpr_Wwpformelementid == AV15WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_variable.gxTpr_Elementid )
                        {
                           AV9MultipleDataRepetitions = (short)(Math.Round(AV23WWPFormInstanceElement.gxTpr_Wwpforminstanceelemnumeric, 18, MidpointRounding.ToEven));
                           AssignAttri(sPrefix, false, "AV9MultipleDataRepetitions", StringUtil.LTrimStr( (decimal)(AV9MultipleDataRepetitions), 4, 0));
                           if (true) break;
                        }
                        AV34GXV2 = (int)(AV34GXV2+1);
                     }
                  }
               }
               AV6i = 1;
               while ( AV6i <= AV9MultipleDataRepetitions )
               {
                  AV10MultipleDataWWPFormInstanceElementId.Add(AV6i, 0);
                  AV6i = (short)(AV6i+1);
               }
            }
            GXt_SdtWWP_FormInstance1 = AV22WWPFormInstance;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV11SessionId, out  GXt_SdtWWP_FormInstance1) ;
            AV22WWPFormInstance = GXt_SdtWWP_FormInstance1;
            AV35GXV3 = 1;
            while ( AV35GXV3 <= AV10MultipleDataWWPFormInstanceElementId.Count )
            {
               AV6i = (short)(AV10MultipleDataWWPFormInstanceElementId.GetNumeric(AV35GXV3));
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_createchildren(context ).execute(  AV6i,  AV17WWPFormElementId, ref  AV22WWPFormInstance) ;
               AV35GXV3 = (int)(AV35GXV3+1);
            }
            AV22WWPFormInstance.Check();
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_clearunusedreferences(context ).execute( ref  AV22WWPFormInstance) ;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV11SessionId,  AV22WWPFormInstance) ;
         }
         AV9MultipleDataRepetitions = (short)(AV10MultipleDataWWPFormInstanceElementId.Count);
         AssignAttri(sPrefix, false, "AV9MultipleDataRepetitions", StringUtil.LTrimStr( (decimal)(AV9MultipleDataRepetitions), 4, 0));
      }

      protected void E152D2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Using cursor H002D9 */
         pr_default.execute(4, new Object[] {AV22WWPFormInstance.gxTpr_Wwpformid, AV22WWPFormInstance.gxTpr_Wwpformversionnumber, AV17WWPFormElementId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A40000GXC1 = H002D9_A40000GXC1[0];
            n40000GXC1 = H002D9_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri(sPrefix, false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         pr_default.close(4);
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S112 ();
         if (returnInSub) return;
         AV8MultipleDataElements = (short)(A40000GXC1);
         if ( ( AV15WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) && ( StringUtil.StrCmp(AV16WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV16WWPDynamicFormMode, "DLT") != 0 ) )
         {
            AV8MultipleDataElements = (short)(AV8MultipleDataElements+1);
         }
         subFsgrid_Columns = AV8MultipleDataElements;
         /*  Sending Event outputs  */
      }

      private void E162D2( )
      {
         /* Fsgrid_Load Routine */
         returnInSub = false;
         AV12TitlesAreLoaded = false;
         divDatatablecell_Visible = 0;
         AssignProp(sPrefix, false, divDatatablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatablecell_Visible), 5, 0), !bGXsfl_9_Refreshing);
         /* Using cursor H002D10 */
         pr_default.execute(5, new Object[] {AV22WWPFormInstance.gxTpr_Wwpformid, AV22WWPFormInstance.gxTpr_Wwpformversionnumber, AV17WWPFormElementId});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A211WWPFormElementParentId = H002D10_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = H002D10_n211WWPFormElementParentId[0];
            A207WWPFormVersionNumber = H002D10_A207WWPFormVersionNumber[0];
            A206WWPFormId = H002D10_A206WWPFormId[0];
            A229WWPFormElementTitle = H002D10_A229WWPFormElementTitle[0];
            A212WWPFormElementOrderIndex = H002D10_A212WWPFormElementOrderIndex[0];
            lblTitletextblocktitle_Caption = A229WWPFormElementTitle;
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
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( ( AV15WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) && ( StringUtil.StrCmp(AV16WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV16WWPDynamicFormMode, "DLT") != 0 ) )
         {
            lblTitletextblocktitle_Caption = "";
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
         }
         AV12TitlesAreLoaded = true;
         AV37GXV4 = 1;
         while ( AV37GXV4 <= AV10MultipleDataWWPFormInstanceElementId.Count )
         {
            AV25WWPFormInstanceElementIdChild = (short)(AV10MultipleDataWWPFormInstanceElementId.GetNumeric(AV37GXV4));
            /* Using cursor H002D11 */
            pr_default.execute(6, new Object[] {AV22WWPFormInstance.gxTpr_Wwpformid, AV22WWPFormInstance.gxTpr_Wwpformversionnumber, AV17WWPFormElementId});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A211WWPFormElementParentId = H002D11_A211WWPFormElementParentId[0];
               n211WWPFormElementParentId = H002D11_n211WWPFormElementParentId[0];
               A207WWPFormVersionNumber = H002D11_A207WWPFormVersionNumber[0];
               A206WWPFormId = H002D11_A206WWPFormId[0];
               A217WWPFormElementType = H002D11_A217WWPFormElementType[0];
               A218WWPFormElementDataType = H002D11_A218WWPFormElementDataType[0];
               A236WWPFormElementMetadata = H002D11_A236WWPFormElementMetadata[0];
               A210WWPFormElementId = H002D11_A210WWPFormElementId[0];
               A212WWPFormElementOrderIndex = H002D11_A212WWPFormElementOrderIndex[0];
               if ( A217WWPFormElementType == 1 )
               {
                  divTitletablecell_Visible = 0;
                  AssignProp(sPrefix, false, divTitletablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTitletablecell_Visible), 5, 0), !bGXsfl_9_Refreshing);
                  divDatatablecell_Visible = 0;
                  AssignProp(sPrefix, false, divDatatablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatablecell_Visible), 5, 0), !bGXsfl_9_Refreshing);
                  if ( AV12TitlesAreLoaded )
                  {
                     divDatatablecell_Visible = 1;
                     AssignProp(sPrefix, false, divDatatablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatablecell_Visible), 5, 0), !bGXsfl_9_Refreshing);
                  }
                  else
                  {
                     divTitletablecell_Visible = 1;
                     AssignProp(sPrefix, false, divTitletablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTitletablecell_Visible), 5, 0), !bGXsfl_9_Refreshing);
                  }
                  if ( A218WWPFormElementDataType == 2 )
                  {
                     AV14WWP_DF_CharMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                     if ( AV14WWP_DF_CharMetadata.gxTpr_Controltype == 1 )
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Datawcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Text_WC")) != 0 )
                        {
                           WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_text_wc", new Object[] {context} );
                           WebComp_Datawcchildren.ComponentInit();
                           WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Text_WC";
                           WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Text_WC";
                        }
                        if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                        {
                           WebComp_Datawcchildren.setjustcreated();
                           WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                           WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                     else if ( AV14WWP_DF_CharMetadata.gxTpr_Controltype == 2 )
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Datawcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_TextArea_WC")) != 0 )
                        {
                           WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_textarea_wc", new Object[] {context} );
                           WebComp_Datawcchildren.ComponentInit();
                           WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_TextArea_WC";
                           WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_TextArea_WC";
                        }
                        if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                        {
                           WebComp_Datawcchildren.setjustcreated();
                           WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                           WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                     else if ( AV14WWP_DF_CharMetadata.gxTpr_Controltype == 3 )
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Datawcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_HTMLEditor_WC")) != 0 )
                        {
                           WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_htmleditor_wc", new Object[] {context} );
                           WebComp_Datawcchildren.ComponentInit();
                           WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_HTMLEditor_WC";
                           WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_HTMLEditor_WC";
                        }
                        if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                        {
                           WebComp_Datawcchildren.setjustcreated();
                           WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                           WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                     else if ( AV14WWP_DF_CharMetadata.gxTpr_Controltype == 4 )
                     {
                        if ( AV14WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 1 )
                        {
                           if ( AV14WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Hasdynamicoptions )
                           {
                              /* Object Property */
                              if ( StringUtil.Len( sPrefix) == 0 )
                              {
                                 bDynCreated_Datawcchildren = true;
                              }
                              if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_DynamicComboBox_WC")) != 0 )
                              {
                                 WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_dynamiccombobox_wc", new Object[] {context} );
                                 WebComp_Datawcchildren.ComponentInit();
                                 WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_DynamicComboBox_WC";
                                 WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_DynamicComboBox_WC";
                              }
                              if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                              {
                                 WebComp_Datawcchildren.setjustcreated();
                                 WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                                 WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                              }
                           }
                           else
                           {
                              /* Object Property */
                              if ( StringUtil.Len( sPrefix) == 0 )
                              {
                                 bDynCreated_Datawcchildren = true;
                              }
                              if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_ComboBox_WC")) != 0 )
                              {
                                 WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_combobox_wc", new Object[] {context} );
                                 WebComp_Datawcchildren.ComponentInit();
                                 WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_ComboBox_WC";
                                 WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_ComboBox_WC";
                              }
                              if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                              {
                                 WebComp_Datawcchildren.setjustcreated();
                                 WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                                 WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                              }
                           }
                        }
                        else if ( AV14WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 2 )
                        {
                           if ( AV14WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Hasdynamicoptions )
                           {
                              /* Object Property */
                              if ( StringUtil.Len( sPrefix) == 0 )
                              {
                                 bDynCreated_Datawcchildren = true;
                              }
                              if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_DynamicSuggest_WC")) != 0 )
                              {
                                 WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_dynamicsuggest_wc", new Object[] {context} );
                                 WebComp_Datawcchildren.ComponentInit();
                                 WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_DynamicSuggest_WC";
                                 WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_DynamicSuggest_WC";
                              }
                              if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                              {
                                 WebComp_Datawcchildren.setjustcreated();
                                 WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                                 WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                              }
                           }
                           else
                           {
                              /* Object Property */
                              if ( StringUtil.Len( sPrefix) == 0 )
                              {
                                 bDynCreated_Datawcchildren = true;
                              }
                              if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Suggest_WC")) != 0 )
                              {
                                 WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_suggest_wc", new Object[] {context} );
                                 WebComp_Datawcchildren.ComponentInit();
                                 WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Suggest_WC";
                                 WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Suggest_WC";
                              }
                              if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                              {
                                 WebComp_Datawcchildren.setjustcreated();
                                 WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                                 WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                              }
                           }
                        }
                        else if ( AV14WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 3 )
                        {
                           /* Object Property */
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              bDynCreated_Datawcchildren = true;
                           }
                           if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Radiobutton_WC")) != 0 )
                           {
                              WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_radiobutton_wc", new Object[] {context} );
                              WebComp_Datawcchildren.ComponentInit();
                              WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Radiobutton_WC";
                              WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Radiobutton_WC";
                           }
                           if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                           {
                              WebComp_Datawcchildren.setjustcreated();
                              WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                              WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                           }
                        }
                        else if ( AV14WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 4 )
                        {
                           /* Object Property */
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              bDynCreated_Datawcchildren = true;
                           }
                           if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_MCheckBox_WC")) != 0 )
                           {
                              WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_mcheckbox_wc", new Object[] {context} );
                              WebComp_Datawcchildren.ComponentInit();
                              WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_MCheckBox_WC";
                              WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_MCheckBox_WC";
                           }
                           if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                           {
                              WebComp_Datawcchildren.setjustcreated();
                              WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                              WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                           }
                        }
                     }
                  }
                  else if ( ( A218WWPFormElementDataType == 6 ) || ( A218WWPFormElementDataType == 7 ) || ( A218WWPFormElementDataType == 8 ) )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Datawcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Text_WC")) != 0 )
                     {
                        WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_text_wc", new Object[] {context} );
                        WebComp_Datawcchildren.ComponentInit();
                        WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Text_WC";
                        WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Text_WC";
                     }
                     if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                     {
                        WebComp_Datawcchildren.setjustcreated();
                        WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                        WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else if ( A218WWPFormElementDataType == 1 )
                  {
                     AV13WWP_DF_BooleanMetadata.FromJSonString(A236WWPFormElementMetadata, null);
                     if ( AV13WWP_DF_BooleanMetadata.gxTpr_Controltype == 1 )
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Datawcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Checkbox_WC")) != 0 )
                        {
                           WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_checkbox_wc", new Object[] {context} );
                           WebComp_Datawcchildren.ComponentInit();
                           WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Checkbox_WC";
                           WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Checkbox_WC";
                        }
                        if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                        {
                           WebComp_Datawcchildren.setjustcreated();
                           WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                           WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                     else if ( AV13WWP_DF_BooleanMetadata.gxTpr_Controltype == 2 )
                     {
                        /* Object Property */
                        if ( StringUtil.Len( sPrefix) == 0 )
                        {
                           bDynCreated_Datawcchildren = true;
                        }
                        if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Switch_WC")) != 0 )
                        {
                           WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_switch_wc", new Object[] {context} );
                           WebComp_Datawcchildren.ComponentInit();
                           WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Switch_WC";
                           WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Switch_WC";
                        }
                        if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                        {
                           WebComp_Datawcchildren.setjustcreated();
                           WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                           WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                        }
                     }
                  }
                  else if ( A218WWPFormElementDataType == 4 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Datawcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Date_WC")) != 0 )
                     {
                        WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_date_wc", new Object[] {context} );
                        WebComp_Datawcchildren.ComponentInit();
                        WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Date_WC";
                        WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Date_WC";
                     }
                     if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                     {
                        WebComp_Datawcchildren.setjustcreated();
                        WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                        WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else if ( A218WWPFormElementDataType == 5 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Datawcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Datetime_WC")) != 0 )
                     {
                        WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_datetime_wc", new Object[] {context} );
                        WebComp_Datawcchildren.ComponentInit();
                        WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Datetime_WC";
                        WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Datetime_WC";
                     }
                     if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                     {
                        WebComp_Datawcchildren.setjustcreated();
                        WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                        WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else if ( A218WWPFormElementDataType == 3 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Datawcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Numeric_WC")) != 0 )
                     {
                        WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_numeric_wc", new Object[] {context} );
                        WebComp_Datawcchildren.ComponentInit();
                        WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Numeric_WC";
                        WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Numeric_WC";
                     }
                     if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                     {
                        WebComp_Datawcchildren.setjustcreated();
                        WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                        WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else if ( A218WWPFormElementDataType == 10 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Datawcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_Image_WC")) != 0 )
                     {
                        WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_image_wc", new Object[] {context} );
                        WebComp_Datawcchildren.ComponentInit();
                        WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_Image_WC";
                        WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_Image_WC";
                     }
                     if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                     {
                        WebComp_Datawcchildren.setjustcreated();
                        WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                        WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
                     }
                  }
                  else if ( A218WWPFormElementDataType == 9 )
                  {
                     /* Object Property */
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        bDynCreated_Datawcchildren = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_File_WC")) != 0 )
                     {
                        WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_file_wc", new Object[] {context} );
                        WebComp_Datawcchildren.ComponentInit();
                        WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_File_WC";
                        WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_File_WC";
                     }
                     if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                     {
                        WebComp_Datawcchildren.setjustcreated();
                        WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(string)AV16WWPDynamicFormMode,(short)A210WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                        WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
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
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
            if ( ( AV15WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) && ( StringUtil.StrCmp(AV16WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV16WWPDynamicFormMode, "DLT") != 0 ) )
            {
               /* Object Property */
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  bDynCreated_Datawcchildren = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawcchildren_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_MDataGrid_Remove_WC")) != 0 )
               {
                  WebComp_Datawcchildren = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_mdatagrid_remove_wc", new Object[] {context} );
                  WebComp_Datawcchildren.ComponentInit();
                  WebComp_Datawcchildren.Name = "WorkWithPlus.DynamicForms.WWP_DF_MDataGrid_Remove_WC";
                  WebComp_Datawcchildren_Component = "WorkWithPlus.DynamicForms.WWP_DF_MDataGrid_Remove_WC";
               }
               if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
               {
                  WebComp_Datawcchildren.setjustcreated();
                  WebComp_Datawcchildren.componentprepare(new Object[] {(string)sPrefix+"W0020",(string)sGXsfl_9_idx,(short)AV17WWPFormElementId,(short)AV25WWPFormInstanceElementIdChild,(short)AV11SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV22WWPFormInstance});
                  WebComp_Datawcchildren.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
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
            }
            AV37GXV4 = (int)(AV37GXV4+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E112D2( )
      {
         /* 'DoAddChild' Routine */
         returnInSub = false;
         GXt_SdtWWP_FormInstance1 = AV22WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV11SessionId, out  GXt_SdtWWP_FormInstance1) ;
         AV22WWPFormInstance = GXt_SdtWWP_FormInstance1;
         /* Execute user subroutine: 'GET NEW INSTANCEELEMENTID' */
         S122 ();
         if (returnInSub) return;
         AV10MultipleDataWWPFormInstanceElementId.Add(AV26WWPFormInstanceElementIdNew, 0);
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_createchildren(context ).execute(  AV26WWPFormInstanceElementIdNew,  AV17WWPFormElementId, ref  AV22WWPFormInstance) ;
         AV22WWPFormInstance.Check();
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_clearunusedreferences(context ).execute( ref  AV22WWPFormInstance) ;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV11SessionId,  AV22WWPFormInstance) ;
         gxgrFsgrid_refresh( AV17WWPFormElementId, AV22WWPFormInstance, AV15WWP_DF_ElementsRepeaterMetadata, AV16WWPDynamicFormMode, AV10MultipleDataWWPFormInstanceElementId, A212WWPFormElementOrderIndex, A206WWPFormId, A207WWPFormVersionNumber, A211WWPFormElementParentId, A229WWPFormElementTitle, A217WWPFormElementType, A236WWPFormElementMetadata, AV11SessionId, A210WWPFormElementId, A218WWPFormElementDataType, AV18WWPFormElementIdSimpleChildren, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22WWPFormInstance", AV22WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10MultipleDataWWPFormInstanceElementId", AV10MultipleDataWWPFormInstanceElementId);
      }

      protected void S112( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         bttBtnaddchild_Visible = 1;
         AssignProp(sPrefix, false, bttBtnaddchild_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnaddchild_Visible), 5, 0), true);
         if ( ! ( ( AV15WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) && ( AV10MultipleDataWWPFormInstanceElementId.Count < AV15WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Maxrepetitions ) && ( StringUtil.StrCmp(AV16WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV16WWPDynamicFormMode, "DLT") != 0 ) ) )
         {
            bttBtnaddchild_Visible = 0;
            AssignProp(sPrefix, false, bttBtnaddchild_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnaddchild_Visible), 5, 0), true);
         }
      }

      protected void E122D2( )
      {
         /* General\GlobalEvents_Dynamicform_deletegridrecord Routine */
         returnInSub = false;
         if ( AV5AuxSessionId == AV11SessionId )
         {
            GXt_SdtWWP_FormInstance1 = AV22WWPFormInstance;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV11SessionId, out  GXt_SdtWWP_FormInstance1) ;
            AV22WWPFormInstance = GXt_SdtWWP_FormInstance1;
            AV6i = 1;
            while ( AV6i <= AV10MultipleDataWWPFormInstanceElementId.Count )
            {
               if ( AV10MultipleDataWWPFormInstanceElementId.GetNumeric(AV6i) == AV24WWPFormInstanceElementIdAux )
               {
                  if (true) break;
               }
               AV6i = (short)(AV6i+1);
            }
            if ( AV6i <= AV10MultipleDataWWPFormInstanceElementId.Count )
            {
               AV10MultipleDataWWPFormInstanceElementId.RemoveItem(AV6i);
               /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
               S112 ();
               if (returnInSub) return;
               gxgrFsgrid_refresh( AV17WWPFormElementId, AV22WWPFormInstance, AV15WWP_DF_ElementsRepeaterMetadata, AV16WWPDynamicFormMode, AV10MultipleDataWWPFormInstanceElementId, A212WWPFormElementOrderIndex, A206WWPFormId, A207WWPFormVersionNumber, A211WWPFormElementParentId, A229WWPFormElementTitle, A217WWPFormElementType, A236WWPFormElementMetadata, AV11SessionId, A210WWPFormElementId, A218WWPFormElementDataType, AV18WWPFormElementIdSimpleChildren, sPrefix) ;
               GX_FocusControl = bttBtnaddchild_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               context.DoAjaxSetFocus(GX_FocusControl);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22WWPFormInstance", AV22WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10MultipleDataWWPFormInstanceElementId", AV10MultipleDataWWPFormInstanceElementId);
      }

      protected void E132D2( )
      {
         /* General\GlobalEvents_Dynamicform_updatevisibilities Routine */
         returnInSub = false;
         if ( ( AV5AuxSessionId == AV11SessionId ) && ( AV15WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 3 ) )
         {
            GXt_SdtWWP_FormInstance1 = AV22WWPFormInstance;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV11SessionId, out  GXt_SdtWWP_FormInstance1) ;
            AV22WWPFormInstance = GXt_SdtWWP_FormInstance1;
            AV39GXV5 = 1;
            while ( AV39GXV5 <= AV22WWPFormInstance.gxTpr_Element.Count )
            {
               AV23WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV22WWPFormInstance.gxTpr_Element.Item(AV39GXV5));
               if ( AV23WWPFormInstanceElement.gxTpr_Wwpformelementid == AV15WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_variable.gxTpr_Elementid )
               {
                  AV9MultipleDataRepetitions = (short)(Math.Round(AV23WWPFormInstanceElement.gxTpr_Wwpforminstanceelemnumeric, 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV9MultipleDataRepetitions", StringUtil.LTrimStr( (decimal)(AV9MultipleDataRepetitions), 4, 0));
                  if (true) break;
               }
               AV39GXV5 = (int)(AV39GXV5+1);
            }
            if ( AV9MultipleDataRepetitions != AV10MultipleDataWWPFormInstanceElementId.Count )
            {
               if ( AV9MultipleDataRepetitions < AV10MultipleDataWWPFormInstanceElementId.Count )
               {
                  AV19WWPFormElementIdToDelete = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deletechildren(context ).execute(  AV22WWPFormInstance.gxTpr_Wwpformid,  AV22WWPFormInstance.gxTpr_Wwpformversionnumber,  AV17WWPFormElementId, ref  AV19WWPFormElementIdToDelete) ;
                  while ( AV9MultipleDataRepetitions < AV10MultipleDataWWPFormInstanceElementId.Count )
                  {
                     AV25WWPFormInstanceElementIdChild = (short)(AV10MultipleDataWWPFormInstanceElementId.GetNumeric(AV10MultipleDataWWPFormInstanceElementId.Count));
                     AV6i = 1;
                     while ( AV6i <= AV19WWPFormElementIdToDelete.Count )
                     {
                        AV7j = 1;
                        AV40GXV6 = 1;
                        while ( AV40GXV6 <= AV22WWPFormInstance.gxTpr_Element.Count )
                        {
                           AV23WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV22WWPFormInstance.gxTpr_Element.Item(AV40GXV6));
                           if ( ( AV23WWPFormInstanceElement.gxTpr_Wwpformelementid == AV19WWPFormElementIdToDelete.GetNumeric(AV6i) ) && ( AV23WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV25WWPFormInstanceElementIdChild ) )
                           {
                              if (true) break;
                           }
                           else
                           {
                              AV7j = (short)(AV7j+1);
                           }
                           AV40GXV6 = (int)(AV40GXV6+1);
                        }
                        if ( AV7j <= AV22WWPFormInstance.gxTpr_Element.Count )
                        {
                           AV22WWPFormInstance.gxTpr_Element.RemoveItem(AV7j);
                        }
                        AV6i = (short)(AV6i+1);
                     }
                     AV10MultipleDataWWPFormInstanceElementId.RemoveItem(AV10MultipleDataWWPFormInstanceElementId.Count);
                  }
               }
               AV6i = 0;
               while ( AV9MultipleDataRepetitions > AV10MultipleDataWWPFormInstanceElementId.Count )
               {
                  if ( (0==AV6i) )
                  {
                     /* Execute user subroutine: 'GET NEW INSTANCEELEMENTID' */
                     S122 ();
                     if (returnInSub) return;
                     AV6i = AV26WWPFormInstanceElementIdNew;
                  }
                  else
                  {
                     AV6i = (short)(AV6i+1);
                  }
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_createchildren(context ).execute(  AV6i,  AV17WWPFormElementId, ref  AV22WWPFormInstance) ;
                  AV10MultipleDataWWPFormInstanceElementId.Add(AV6i, 0);
               }
               AV22WWPFormInstance.Check();
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_clearunusedreferences(context ).execute( ref  AV22WWPFormInstance) ;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV11SessionId,  AV22WWPFormInstance) ;
               gxgrFsgrid_refresh( AV17WWPFormElementId, AV22WWPFormInstance, AV15WWP_DF_ElementsRepeaterMetadata, AV16WWPDynamicFormMode, AV10MultipleDataWWPFormInstanceElementId, A212WWPFormElementOrderIndex, A206WWPFormId, A207WWPFormVersionNumber, A211WWPFormElementParentId, A229WWPFormElementTitle, A217WWPFormElementType, A236WWPFormElementMetadata, AV11SessionId, A210WWPFormElementId, A218WWPFormElementDataType, AV18WWPFormElementIdSimpleChildren, sPrefix) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22WWPFormInstance", AV22WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10MultipleDataWWPFormInstanceElementId", AV10MultipleDataWWPFormInstanceElementId);
      }

      protected void S122( )
      {
         /* 'GET NEW INSTANCEELEMENTID' Routine */
         returnInSub = false;
         AV26WWPFormInstanceElementIdNew = 0;
         AssignAttri(sPrefix, false, "AV26WWPFormInstanceElementIdNew", StringUtil.LTrimStr( (decimal)(AV26WWPFormInstanceElementIdNew), 4, 0));
         AV41GXV7 = 1;
         while ( AV41GXV7 <= AV22WWPFormInstance.gxTpr_Element.Count )
         {
            AV23WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV22WWPFormInstance.gxTpr_Element.Item(AV41GXV7));
            if ( ( AV23WWPFormInstanceElement.gxTpr_Wwpformelementid == AV18WWPFormElementIdSimpleChildren ) && ( AV23WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid > AV26WWPFormInstanceElementIdNew ) )
            {
               AV26WWPFormInstanceElementIdNew = AV23WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid;
               AssignAttri(sPrefix, false, "AV26WWPFormInstanceElementIdNew", StringUtil.LTrimStr( (decimal)(AV26WWPFormInstanceElementIdNew), 4, 0));
            }
            AV41GXV7 = (int)(AV41GXV7+1);
         }
         AV26WWPFormInstanceElementIdNew = (short)(AV26WWPFormInstanceElementIdNew+1);
         AssignAttri(sPrefix, false, "AV26WWPFormInstanceElementIdNew", StringUtil.LTrimStr( (decimal)(AV26WWPFormInstanceElementIdNew), 4, 0));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV16WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV16WWPDynamicFormMode", AV16WWPDynamicFormMode);
         AV17WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV17WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV17WWPFormElementId), 4, 0));
         AV28WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV28WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV28WWPFormInstanceElementId), 4, 0));
         AV11SessionId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV11SessionId", StringUtil.LTrimStr( (decimal)(AV11SessionId), 4, 0));
         AV22WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,4);
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
         PA2D2( ) ;
         WS2D2( ) ;
         WE2D2( ) ;
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
         sCtrlAV17WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV28WWPFormInstanceElementId = (string)((string)getParm(obj,2));
         sCtrlAV11SessionId = (string)((string)getParm(obj,3));
         sCtrlAV22WWPFormInstance = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2D2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_mdatagrid_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2D2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV16WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV16WWPDynamicFormMode", AV16WWPDynamicFormMode);
            AV17WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV17WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV17WWPFormElementId), 4, 0));
            AV28WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV28WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV28WWPFormInstanceElementId), 4, 0));
            AV11SessionId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV11SessionId", StringUtil.LTrimStr( (decimal)(AV11SessionId), 4, 0));
            AV22WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,6);
         }
         wcpOAV16WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV16WWPDynamicFormMode");
         wcpOAV17WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV17WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV28WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV28WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV11SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV11SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV16WWPDynamicFormMode, wcpOAV16WWPDynamicFormMode) != 0 ) || ( AV17WWPFormElementId != wcpOAV17WWPFormElementId ) || ( AV28WWPFormInstanceElementId != wcpOAV28WWPFormInstanceElementId ) || ( AV11SessionId != wcpOAV11SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV16WWPDynamicFormMode = AV16WWPDynamicFormMode;
         wcpOAV17WWPFormElementId = AV17WWPFormElementId;
         wcpOAV28WWPFormInstanceElementId = AV28WWPFormInstanceElementId;
         wcpOAV11SessionId = AV11SessionId;
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
         sCtrlAV17WWPFormElementId = cgiGet( sPrefix+"AV17WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV17WWPFormElementId) > 0 )
         {
            AV17WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV17WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV17WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV17WWPFormElementId), 4, 0));
         }
         else
         {
            AV17WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV17WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV28WWPFormInstanceElementId = cgiGet( sPrefix+"AV28WWPFormInstanceElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV28WWPFormInstanceElementId) > 0 )
         {
            AV28WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV28WWPFormInstanceElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV28WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV28WWPFormInstanceElementId), 4, 0));
         }
         else
         {
            AV28WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV28WWPFormInstanceElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         sCtrlAV22WWPFormInstance = cgiGet( sPrefix+"AV22WWPFormInstance_CTRL");
         if ( StringUtil.Len( sCtrlAV22WWPFormInstance) > 0 )
         {
            AV22WWPFormInstance.FromXml(cgiGet( sCtrlAV22WWPFormInstance), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV22WWPFormInstance_PARM"), AV22WWPFormInstance);
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
         PA2D2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2D2( ) ;
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
         WS2D2( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV17WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV17WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV17WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV17WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV28WWPFormInstanceElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV28WWPFormInstanceElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV28WWPFormInstanceElementId_CTRL", StringUtil.RTrim( sCtrlAV28WWPFormInstanceElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11SessionId_CTRL", StringUtil.RTrim( sCtrlAV11SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV22WWPFormInstance_PARM", AV22WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV22WWPFormInstance_PARM", AV22WWPFormInstance);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV22WWPFormInstance)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV22WWPFormInstance_CTRL", StringUtil.RTrim( sCtrlAV22WWPFormInstance));
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
         WE2D2( ) ;
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
         if ( ! ( WebComp_Datawcchildren == null ) )
         {
            WebComp_Datawcchildren.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Datawcchildren == null ) )
         {
            if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
            {
               WebComp_Datawcchildren.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562016573264", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_mdatagrid_wc.js", "?202562016573265", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_92( )
      {
         lblTitletextblocktitle_Internalname = sPrefix+"TITLETEXTBLOCKTITLE_"+sGXsfl_9_idx;
         subFsgrid_Internalname = sPrefix+"FSGRID";
         subFsgrid_Internalname = sPrefix+"FSGRID";
      }

      protected void SubsflControlProps_fel_92( )
      {
         lblTitletextblocktitle_Internalname = sPrefix+"TITLETEXTBLOCKTITLE_"+sGXsfl_9_fel_idx;
         subFsgrid_Internalname = sPrefix+"FSGRID";
         subFsgrid_Internalname = sPrefix+"FSGRID";
      }

      protected void sendrow_92( )
      {
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         WB2D0( ) ;
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
            if ( subFsgrid_Columns <= 0 )
            {
               subFsgrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
               {
                  subFsgrid_Linesclass = subFsgrid_Class+"Odd";
               }
            }
            else if ( subFsgrid_Columns == 1 )
            {
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
            else
            {
               if ( ((int)(((nGXsfl_9_idx-1)/ (decimal)(subFsgrid_Columns)) % (2))) == 0 )
               {
                  subFsgrid_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
                  {
                     subFsgrid_Linesclass = subFsgrid_Class+"Odd";
                  }
               }
               else
               {
                  subFsgrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subFsgrid_Class, "") != 0 )
                  {
                     subFsgrid_Linesclass = subFsgrid_Class+"Even";
                  }
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            if ( ( subFsgrid_Columns == 0 ) && ( nGXsfl_9_idx == 1 ) )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subFsgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_9_idx+"\">") ;
            }
            if ( subFsgrid_Columns > 0 )
            {
               if ( ( subFsgrid_Columns == 1 ) || ( ((int)((nGXsfl_9_idx) % (subFsgrid_Columns))) - 1 == 0 ) )
               {
                  context.WriteHtmlText( "<tr"+" class=\""+subFsgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_9_idx+"\">") ;
               }
            }
         }
         FsgridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)subFsgrid_Linesclass,(string)""});
         FsgridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFsgridlayouttable_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTitletablecell_Internalname+"_"+sGXsfl_9_idx,(int)divTitletablecell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTitletable_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Text block */
         FsgridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTitletextblocktitle_Internalname,(string)lblTitletextblocktitle_Caption,(string)"",(string)"",(string)lblTitletextblocktitle_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"DynFormDataDescription",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divDatatablecell_Internalname+"_"+sGXsfl_9_idx,(int)divDatatablecell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divDatatable_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         FsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0020"+sGXsfl_9_idx, StringUtil.RTrim( WebComp_Datawcchildren_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0020"+sGXsfl_9_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_9_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0020"+sGXsfl_9_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Datawcchildren_Component) != 0 )
                     {
                        WebComp_Datawcchildren.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldDatawcchildren), StringUtil.Lower( WebComp_Datawcchildren_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0020"+sGXsfl_9_idx);
               }
               WebComp_Datawcchildren.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldDatawcchildren), StringUtil.Lower( WebComp_Datawcchildren_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Datawcchildren_Component = "";
         WebComp_Datawcchildren.componentjscripts();
         FsgridRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Datawcchildren"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            FsgridContainer.CloseTag("cell");
         }
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            FsgridContainer.CloseTag("row");
         }
         send_integrity_lvl_hashes2D2( ) ;
         /* End of Columns property logic. */
         if ( FsgridContainer.GetWrapped() == 1 )
         {
            if ( subFsgrid_Columns > 0 )
            {
               if ( ((int)((nGXsfl_9_idx) % (subFsgrid_Columns))) == 0 )
               {
                  context.WriteHtmlTextNl( "</tr>") ;
               }
            }
         }
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
            GxWebStd.gx_table_start( context, subFsgrid_Internalname, subFsgrid_Internalname, "", "FreeStyleGrid", 0, "", "", 0, 0, sStyleString, "", "", 0);
            FsgridContainer.AddObjectProperty("GridName", "Fsgrid");
         }
         else
         {
            FsgridContainer.AddObjectProperty("GridName", "Fsgrid");
            FsgridContainer.AddObjectProperty("Header", subFsgrid_Header);
            FsgridContainer.AddObjectProperty("SflColumns", subFsgrid_Columns);
            FsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
            FsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(0), 4, 0, ".", "")));
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
            FsgridColumn.AddObjectProperty("Value", lblTitletextblocktitle_Caption);
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
         lblTitletextblocktitle_Internalname = sPrefix+"TITLETEXTBLOCKTITLE";
         divTitletable_Internalname = sPrefix+"TITLETABLE";
         divTitletablecell_Internalname = sPrefix+"TITLETABLECELL";
         divDatatable_Internalname = sPrefix+"DATATABLE";
         divDatatablecell_Internalname = sPrefix+"DATATABLECELL";
         divFsgridlayouttable_Internalname = sPrefix+"FSGRIDLAYOUTTABLE";
         bttBtnaddchild_Internalname = sPrefix+"BTNADDCHILD";
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
         lblTitletextblocktitle_Caption = context.GetMessage( "Title", "");
         divDatatablecell_Visible = 1;
         lblTitletextblocktitle_Caption = context.GetMessage( "Title", "");
         divTitletablecell_Visible = 1;
         subFsgrid_Class = "FreeStyleGrid";
         subFsgrid_Backcolorstyle = 0;
         subFsgrid_Columns = 1;
         bttBtnaddchild_Caption = context.GetMessage( "Add child", "");
         bttBtnaddchild_Visible = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"A212WWPFormElementOrderIndex","fld":"WWPFORMELEMENTORDERINDEX","pic":"ZZZ9"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"A229WWPFormElementTitle","fld":"WWPFORMELEMENTTITLE"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"A236WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA"},{"av":"AV11SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"A210WWPFormElementId","fld":"WWPFORMELEMENTID","pic":"ZZZ9"},{"av":"A218WWPFormElementDataType","fld":"WWPFORMELEMENTDATATYPE","pic":"Z9"},{"av":"sPrefix"},{"av":"AV17WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV22WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV16WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"AV15WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV18WWPFormElementIdSimpleChildren","fld":"vWWPFORMELEMENTIDSIMPLECHILDREN","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A40000GXC1","fld":"GXC1","pic":"999999999"},{"av":"subFsgrid_Columns","ctrl":"FSGRID","prop":"Columns"},{"ctrl":"BTNADDCHILD","prop":"Visible"}]}""");
         setEventMetadata("FSGRID.LOAD","""{"handler":"E162D2","iparms":[{"av":"A212WWPFormElementOrderIndex","fld":"WWPFORMELEMENTORDERINDEX","pic":"ZZZ9"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"AV22WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"AV17WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"A229WWPFormElementTitle","fld":"WWPFORMELEMENTTITLE"},{"av":"AV15WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV16WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"A236WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA"},{"av":"AV11SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"A210WWPFormElementId","fld":"WWPFORMELEMENTID","pic":"ZZZ9"},{"av":"A218WWPFormElementDataType","fld":"WWPFORMELEMENTDATATYPE","pic":"Z9"}]""");
         setEventMetadata("FSGRID.LOAD",""","oparms":[{"av":"divDatatablecell_Visible","ctrl":"DATATABLECELL","prop":"Visible"},{"av":"lblTitletextblocktitle_Caption","ctrl":"TITLETEXTBLOCKTITLE","prop":"Caption"},{"av":"divTitletablecell_Visible","ctrl":"TITLETABLECELL","prop":"Visible"},{"ctrl":"DATAWCCHILDREN"}]}""");
         setEventMetadata("'DOADDCHILD'","""{"handler":"E112D2","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"AV17WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV22WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV15WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV16WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"A212WWPFormElementOrderIndex","fld":"WWPFORMELEMENTORDERINDEX","pic":"ZZZ9"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"A229WWPFormElementTitle","fld":"WWPFORMELEMENTTITLE"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"A236WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA"},{"av":"AV11SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"A210WWPFormElementId","fld":"WWPFORMELEMENTID","pic":"ZZZ9"},{"av":"A218WWPFormElementDataType","fld":"WWPFORMELEMENTDATATYPE","pic":"Z9"},{"av":"AV18WWPFormElementIdSimpleChildren","fld":"vWWPFORMELEMENTIDSIMPLECHILDREN","pic":"ZZZ9","hsh":true},{"av":"sPrefix"},{"av":"AV26WWPFormInstanceElementIdNew","fld":"vWWPFORMINSTANCEELEMENTIDNEW","pic":"ZZZ9"}]""");
         setEventMetadata("'DOADDCHILD'",""","oparms":[{"av":"AV22WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"AV26WWPFormInstanceElementIdNew","fld":"vWWPFORMINSTANCEELEMENTIDNEW","pic":"ZZZ9"},{"av":"A40000GXC1","fld":"GXC1","pic":"999999999"},{"av":"subFsgrid_Columns","ctrl":"FSGRID","prop":"Columns"},{"ctrl":"BTNADDCHILD","prop":"Visible"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_DELETEGRIDRECORD","""{"handler":"E122D2","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"AV17WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV22WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV15WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV16WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"A212WWPFormElementOrderIndex","fld":"WWPFORMELEMENTORDERINDEX","pic":"ZZZ9"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"A229WWPFormElementTitle","fld":"WWPFORMELEMENTTITLE"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"A236WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA"},{"av":"AV11SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"A210WWPFormElementId","fld":"WWPFORMELEMENTID","pic":"ZZZ9"},{"av":"A218WWPFormElementDataType","fld":"WWPFORMELEMENTDATATYPE","pic":"Z9"},{"av":"AV18WWPFormElementIdSimpleChildren","fld":"vWWPFORMELEMENTIDSIMPLECHILDREN","pic":"ZZZ9","hsh":true},{"av":"sPrefix"},{"av":"AV24WWPFormInstanceElementIdAux","fld":"vWWPFORMINSTANCEELEMENTIDAUX","pic":"ZZZ9"},{"av":"AV5AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_DELETEGRIDRECORD",""","oparms":[{"av":"AV22WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"ctrl":"BTNADDCHILD","prop":"Visible"},{"av":"A40000GXC1","fld":"GXC1","pic":"999999999"},{"av":"subFsgrid_Columns","ctrl":"FSGRID","prop":"Columns"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES","""{"handler":"E132D2","iparms":[{"av":"FSGRID_nFirstRecordOnPage"},{"av":"FSGRID_nEOF"},{"av":"AV17WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV22WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV15WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA","hsh":true},{"av":"AV16WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"A212WWPFormElementOrderIndex","fld":"WWPFORMELEMENTORDERINDEX","pic":"ZZZ9"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A211WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"A229WWPFormElementTitle","fld":"WWPFORMELEMENTTITLE"},{"av":"A217WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9"},{"av":"A236WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA"},{"av":"AV11SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"A210WWPFormElementId","fld":"WWPFORMELEMENTID","pic":"ZZZ9"},{"av":"A218WWPFormElementDataType","fld":"WWPFORMELEMENTDATATYPE","pic":"Z9"},{"av":"AV18WWPFormElementIdSimpleChildren","fld":"vWWPFORMELEMENTIDSIMPLECHILDREN","pic":"ZZZ9","hsh":true},{"av":"sPrefix"},{"av":"AV5AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV9MultipleDataRepetitions","fld":"vMULTIPLEDATAREPETITIONS","pic":"ZZZ9"},{"av":"AV26WWPFormInstanceElementIdNew","fld":"vWWPFORMINSTANCEELEMENTIDNEW","pic":"ZZZ9"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",""","oparms":[{"av":"AV22WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV9MultipleDataRepetitions","fld":"vMULTIPLEDATAREPETITIONS","pic":"ZZZ9"},{"av":"AV10MultipleDataWWPFormInstanceElementId","fld":"vMULTIPLEDATAWWPFORMINSTANCEELEMENTID"},{"av":"AV26WWPFormInstanceElementIdNew","fld":"vWWPFORMINSTANCEELEMENTIDNEW","pic":"ZZZ9"},{"av":"A40000GXC1","fld":"GXC1","pic":"999999999"},{"av":"subFsgrid_Columns","ctrl":"FSGRID","prop":"Columns"},{"ctrl":"BTNADDCHILD","prop":"Visible"}]}""");
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
      }

      public override void initialize( )
      {
         AV22WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         wcpOAV16WWPDynamicFormMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15WWP_DF_ElementsRepeaterMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
         AV10MultipleDataWWPFormInstanceElementId = new GxSimpleCollection<short>();
         A229WWPFormElementTitle = "";
         A236WWPFormElementMetadata = "";
         H002D3_A40000GXC1 = new int[1] ;
         H002D3_n40000GXC1 = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         FsgridContainer = new GXWebGrid( context);
         sStyleString = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnaddchild_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         OldDatawcchildren = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         GXDecQS = "";
         WebComp_Datawcchildren_Component = "";
         H002D5_A40000GXC1 = new int[1] ;
         H002D5_n40000GXC1 = new bool[] {false} ;
         H002D6_A210WWPFormElementId = new short[1] ;
         H002D6_A207WWPFormVersionNumber = new short[1] ;
         H002D6_A206WWPFormId = new short[1] ;
         H002D6_A229WWPFormElementTitle = new string[] {""} ;
         H002D6_A236WWPFormElementMetadata = new string[] {""} ;
         AV21WWPFormElementTitle = "";
         AV20WWPFormElementMetadata = "";
         AV23WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         H002D7_A210WWPFormElementId = new short[1] ;
         H002D7_A214WWPFormInstanceId = new int[1] ;
         H002D7_A215WWPFormInstanceElementId = new short[1] ;
         H002D9_A40000GXC1 = new int[1] ;
         H002D9_n40000GXC1 = new bool[] {false} ;
         H002D10_A210WWPFormElementId = new short[1] ;
         H002D10_A211WWPFormElementParentId = new short[1] ;
         H002D10_n211WWPFormElementParentId = new bool[] {false} ;
         H002D10_A207WWPFormVersionNumber = new short[1] ;
         H002D10_A206WWPFormId = new short[1] ;
         H002D10_A229WWPFormElementTitle = new string[] {""} ;
         H002D10_A212WWPFormElementOrderIndex = new short[1] ;
         FsgridRow = new GXWebRow();
         H002D11_A211WWPFormElementParentId = new short[1] ;
         H002D11_n211WWPFormElementParentId = new bool[] {false} ;
         H002D11_A207WWPFormVersionNumber = new short[1] ;
         H002D11_A206WWPFormId = new short[1] ;
         H002D11_A217WWPFormElementType = new short[1] ;
         H002D11_A218WWPFormElementDataType = new short[1] ;
         H002D11_A236WWPFormElementMetadata = new string[] {""} ;
         H002D11_A210WWPFormElementId = new short[1] ;
         H002D11_A212WWPFormElementOrderIndex = new short[1] ;
         AV14WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV13WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV19WWPFormElementIdToDelete = new GxSimpleCollection<short>();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV16WWPDynamicFormMode = "";
         sCtrlAV17WWPFormElementId = "";
         sCtrlAV28WWPFormInstanceElementId = "";
         sCtrlAV11SessionId = "";
         sCtrlAV22WWPFormInstance = "";
         subFsgrid_Linesclass = "";
         lblTitletextblocktitle_Jsonclick = "";
         subFsgrid_Header = "";
         FsgridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_mdatagrid_wc__default(),
            new Object[][] {
                new Object[] {
               H002D3_A40000GXC1, H002D3_n40000GXC1
               }
               , new Object[] {
               H002D5_A40000GXC1, H002D5_n40000GXC1
               }
               , new Object[] {
               H002D6_A210WWPFormElementId, H002D6_A207WWPFormVersionNumber, H002D6_A206WWPFormId, H002D6_A229WWPFormElementTitle, H002D6_A236WWPFormElementMetadata
               }
               , new Object[] {
               H002D7_A210WWPFormElementId, H002D7_A214WWPFormInstanceId, H002D7_A215WWPFormInstanceElementId
               }
               , new Object[] {
               H002D9_A40000GXC1, H002D9_n40000GXC1
               }
               , new Object[] {
               H002D10_A210WWPFormElementId, H002D10_A211WWPFormElementParentId, H002D10_n211WWPFormElementParentId, H002D10_A207WWPFormVersionNumber, H002D10_A206WWPFormId, H002D10_A229WWPFormElementTitle, H002D10_A212WWPFormElementOrderIndex
               }
               , new Object[] {
               H002D11_A211WWPFormElementParentId, H002D11_n211WWPFormElementParentId, H002D11_A207WWPFormVersionNumber, H002D11_A206WWPFormId, H002D11_A217WWPFormElementType, H002D11_A218WWPFormElementDataType, H002D11_A236WWPFormElementMetadata, H002D11_A210WWPFormElementId, H002D11_A212WWPFormElementOrderIndex
               }
            }
         );
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Datawcchildren = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV17WWPFormElementId ;
      private short AV28WWPFormInstanceElementId ;
      private short AV11SessionId ;
      private short wcpOAV17WWPFormElementId ;
      private short wcpOAV28WWPFormInstanceElementId ;
      private short wcpOAV11SessionId ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
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
      private short AV18WWPFormElementIdSimpleChildren ;
      private short AV26WWPFormInstanceElementIdNew ;
      private short AV24WWPFormInstanceElementIdAux ;
      private short AV5AuxSessionId ;
      private short AV9MultipleDataRepetitions ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short subFsgrid_Columns ;
      private short subFsgrid_Backcolorstyle ;
      private short A215WWPFormInstanceElementId ;
      private short AV6i ;
      private short AV8MultipleDataElements ;
      private short FSGRID_nEOF ;
      private short AV25WWPFormInstanceElementIdChild ;
      private short AV7j ;
      private short nGXWrapped ;
      private short subFsgrid_Backstyle ;
      private short subFsgrid_Allowselection ;
      private short subFsgrid_Allowhovering ;
      private short subFsgrid_Allowcollapsing ;
      private short subFsgrid_Collapsed ;
      private int nRC_GXsfl_9 ;
      private int nGXsfl_9_idx=1 ;
      private int subFsgrid_Recordcount ;
      private int A40000GXC1 ;
      private int bttBtnaddchild_Visible ;
      private int nGXsfl_9_webc_idx=0 ;
      private int subFsgrid_Islastpage ;
      private int AV32GXV1 ;
      private int AV27WWPFormInstanceId ;
      private int A214WWPFormInstanceId ;
      private int AV34GXV2 ;
      private int AV35GXV3 ;
      private int divDatatablecell_Visible ;
      private int AV37GXV4 ;
      private int divTitletablecell_Visible ;
      private int AV39GXV5 ;
      private int AV40GXV6 ;
      private int AV41GXV7 ;
      private int idxLst ;
      private int subFsgrid_Backcolor ;
      private int subFsgrid_Allbackcolor ;
      private int subFsgrid_Selectedindex ;
      private int subFsgrid_Selectioncolor ;
      private int subFsgrid_Hoveringcolor ;
      private long FSGRID_nCurrentRecord ;
      private long FSGRID_nFirstRecordOnPage ;
      private string AV16WWPDynamicFormMode ;
      private string wcpOAV16WWPDynamicFormMode ;
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
      private string divTablemain_Internalname ;
      private string sStyleString ;
      private string subFsgrid_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnaddchild_Internalname ;
      private string bttBtnaddchild_Caption ;
      private string bttBtnaddchild_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string OldDatawcchildren ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string GXDecQS ;
      private string WebComp_Datawcchildren_Component ;
      private string divDatatablecell_Internalname ;
      private string lblTitletextblocktitle_Caption ;
      private string divTitletablecell_Internalname ;
      private string sCtrlAV16WWPDynamicFormMode ;
      private string sCtrlAV17WWPFormElementId ;
      private string sCtrlAV28WWPFormInstanceElementId ;
      private string sCtrlAV11SessionId ;
      private string sCtrlAV22WWPFormInstance ;
      private string lblTitletextblocktitle_Internalname ;
      private string sGXsfl_9_fel_idx="0001" ;
      private string subFsgrid_Class ;
      private string subFsgrid_Linesclass ;
      private string divFsgridlayouttable_Internalname ;
      private string divTitletable_Internalname ;
      private string lblTitletextblocktitle_Jsonclick ;
      private string divDatatable_Internalname ;
      private string subFsgrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n211WWPFormElementParentId ;
      private bool n40000GXC1 ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV12TitlesAreLoaded ;
      private bool bDynCreated_Datawcchildren ;
      private string A229WWPFormElementTitle ;
      private string A236WWPFormElementMetadata ;
      private string AV21WWPFormElementTitle ;
      private string AV20WWPFormElementMetadata ;
      private GXWebComponent WebComp_Datawcchildren ;
      private GXWebGrid FsgridContainer ;
      private GXWebRow FsgridRow ;
      private GXWebColumn FsgridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV22WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV15WWP_DF_ElementsRepeaterMetadata ;
      private GxSimpleCollection<short> AV10MultipleDataWWPFormInstanceElementId ;
      private IDataStoreProvider pr_default ;
      private int[] H002D3_A40000GXC1 ;
      private bool[] H002D3_n40000GXC1 ;
      private GXWebComponent WebComp_GX_Process ;
      private int[] H002D5_A40000GXC1 ;
      private bool[] H002D5_n40000GXC1 ;
      private short[] H002D6_A210WWPFormElementId ;
      private short[] H002D6_A207WWPFormVersionNumber ;
      private short[] H002D6_A206WWPFormId ;
      private string[] H002D6_A229WWPFormElementTitle ;
      private string[] H002D6_A236WWPFormElementMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV23WWPFormInstanceElement ;
      private short[] H002D7_A210WWPFormElementId ;
      private int[] H002D7_A214WWPFormInstanceId ;
      private short[] H002D7_A215WWPFormInstanceElementId ;
      private int[] H002D9_A40000GXC1 ;
      private bool[] H002D9_n40000GXC1 ;
      private short[] H002D10_A210WWPFormElementId ;
      private short[] H002D10_A211WWPFormElementParentId ;
      private bool[] H002D10_n211WWPFormElementParentId ;
      private short[] H002D10_A207WWPFormVersionNumber ;
      private short[] H002D10_A206WWPFormId ;
      private string[] H002D10_A229WWPFormElementTitle ;
      private short[] H002D10_A212WWPFormElementOrderIndex ;
      private short[] H002D11_A211WWPFormElementParentId ;
      private bool[] H002D11_n211WWPFormElementParentId ;
      private short[] H002D11_A207WWPFormVersionNumber ;
      private short[] H002D11_A206WWPFormId ;
      private short[] H002D11_A217WWPFormElementType ;
      private short[] H002D11_A218WWPFormElementDataType ;
      private string[] H002D11_A236WWPFormElementMetadata ;
      private short[] H002D11_A210WWPFormElementId ;
      private short[] H002D11_A212WWPFormElementOrderIndex ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV14WWP_DF_CharMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata AV13WWP_DF_BooleanMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private GxSimpleCollection<short> AV19WWPFormElementIdToDelete ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_df_mdatagrid_wc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002D3;
          prmH002D3 = new Object[] {
          new ParDef("AV22WWPF_1Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV22WWPF_2Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV17WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmH002D5;
          prmH002D5 = new Object[] {
          new ParDef("AV22WWPF_1Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV22WWPF_2Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV17WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmH002D6;
          prmH002D6 = new Object[] {
          new ParDef("AV22WWPF_1Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV22WWPF_2Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV17WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmH002D7;
          prmH002D7 = new Object[] {
          new ParDef("AV27WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("AV18WWPFormElementIdSimpleChildren",GXType.Int16,4,0)
          };
          Object[] prmH002D9;
          prmH002D9 = new Object[] {
          new ParDef("AV22WWPF_1Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV22WWPF_2Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV17WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmH002D10;
          prmH002D10 = new Object[] {
          new ParDef("AV22WWPF_1Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV22WWPF_2Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV17WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmH002D11;
          prmH002D11 = new Object[] {
          new ParDef("AV22WWPF_1Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV22WWPF_2Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV17WWPFormElementId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002D3", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM WWP_FormElement WHERE (WWPFormId = :AV22WWPF_1Wwpformid) AND (WWPFormVersionNumber = :AV22WWPF_2Wwpformversionnumbe) AND (WWPFormElementParentId = :AV17WWPFormElementId) AND (WWPFormElementType = 1) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002D5", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM WWP_FormElement WHERE (WWPFormId = :AV22WWPF_1Wwpformid) AND (WWPFormVersionNumber = :AV22WWPF_2Wwpformversionnumbe) AND (WWPFormElementParentId = :AV17WWPFormElementId) AND (WWPFormElementType = 1) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002D6", "SELECT WWPFormElementId, WWPFormVersionNumber, WWPFormId, WWPFormElementTitle, WWPFormElementMetadata FROM WWP_FormElement WHERE WWPFormId = :AV22WWPF_1Wwpformid and WWPFormVersionNumber = :AV22WWPF_2Wwpformversionnumbe and WWPFormElementId = :AV17WWPFormElementId ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002D7", "SELECT WWPFormElementId, WWPFormInstanceId, WWPFormInstanceElementId FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :AV27WWPFormInstanceId and WWPFormElementId = :AV18WWPFormElementIdSimpleChildren ORDER BY WWPFormInstanceId, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002D9", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM WWP_FormElement WHERE (WWPFormId = :AV22WWPF_1Wwpformid) AND (WWPFormVersionNumber = :AV22WWPF_2Wwpformversionnumbe) AND (WWPFormElementParentId = :AV17WWPFormElementId) AND (WWPFormElementType = 1) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002D10", "SELECT WWPFormElementId, WWPFormElementParentId, WWPFormVersionNumber, WWPFormId, WWPFormElementTitle, WWPFormElementOrderIndex FROM WWP_FormElement WHERE (WWPFormId = :AV22WWPF_1Wwpformid) AND (WWPFormVersionNumber = :AV22WWPF_2Wwpformversionnumbe) AND (WWPFormElementParentId = :AV17WWPFormElementId) ORDER BY WWPFormElementOrderIndex ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002D11", "SELECT WWPFormElementParentId, WWPFormVersionNumber, WWPFormId, WWPFormElementType, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementId, WWPFormElementOrderIndex FROM WWP_FormElement WHERE (WWPFormId = :AV22WWPF_1Wwpformid) AND (WWPFormVersionNumber = :AV22WWPF_2Wwpformversionnumbe) AND (WWPFormElementParentId = :AV17WWPFormElementId) ORDER BY WWPFormElementOrderIndex ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D11,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
