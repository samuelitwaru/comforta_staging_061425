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
   public class wp_productservicestep1 : GXWebComponent
   {
      public wp_productservicestep1( )
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

      public wp_productservicestep1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WebSessionKey ,
                           string aP1_PreviousStep ,
                           bool aP2_GoingBack ,
                           ref bool aP3_IsPopup ,
                           ref Guid aP4_FromToolBox_ProductServiceId ,
                           ref string aP5_PageType )
      {
         this.AV25WebSessionKey = aP0_WebSessionKey;
         this.AV12PreviousStep = aP1_PreviousStep;
         this.AV10GoingBack = aP2_GoingBack;
         this.AV52IsPopup = aP3_IsPopup;
         this.AV53FromToolBox_ProductServiceId = aP4_FromToolBox_ProductServiceId;
         this.AV54PageType = aP5_PageType;
         ExecuteImpl();
         aP3_IsPopup=this.AV52IsPopup;
         aP4_FromToolBox_ProductServiceId=this.AV53FromToolBox_ProductServiceId;
         aP5_PageType=this.AV54PageType;
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
         dynavLocationid = new GXCombobox();
         cmbavProductserviceclass = new GXCombobox();
         dynavProductservicegroup = new GXCombobox();
         chkavNofilteragb = new GXCheckbox();
         chkavNofiltergen = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
                  AV25WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV25WebSessionKey", AV25WebSessionKey);
                  AV12PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV12PreviousStep", AV12PreviousStep);
                  AV10GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV10GoingBack", AV10GoingBack);
                  AV52IsPopup = StringUtil.StrToBool( GetPar( "IsPopup"));
                  AssignAttri(sPrefix, false, "AV52IsPopup", AV52IsPopup);
                  AV53FromToolBox_ProductServiceId = StringUtil.StrToGuid( GetPar( "FromToolBox_ProductServiceId"));
                  AssignAttri(sPrefix, false, "AV53FromToolBox_ProductServiceId", AV53FromToolBox_ProductServiceId.ToString());
                  AV54PageType = GetPar( "PageType");
                  AssignAttri(sPrefix, false, "AV54PageType", AV54PageType);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV25WebSessionKey,(string)AV12PreviousStep,(bool)AV10GoingBack,(bool)AV52IsPopup,(Guid)AV53FromToolBox_ProductServiceId,(string)AV54PageType});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vLOCATIONID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLVvLOCATIONID6C2( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vPRODUCTSERVICEGROUP") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDSVvPRODUCTSERVICEGROUP6C2( ) ;
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
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
            PA6C2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               GXVvLOCATIONID_html6C2( ) ;
               GXVvPRODUCTSERVICEGROUP_html6C2( ) ;
               WS6C2( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Product Service Step1", "")) ;
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
         context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_productservicestep1.aspx"+UrlEncode(StringUtil.RTrim(AV25WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV12PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV10GoingBack)) + "," + UrlEncode(StringUtil.BoolToStr(AV52IsPopup)) + "," + UrlEncode(AV53FromToolBox_ProductServiceId.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV54PageType));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_productservicestep1.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV11HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV11HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORGANISATIONID", AV36OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vORGANISATIONID", GetSecureSignedToken( sPrefix, AV36OrganisationId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPREFERREDAGBSUPPLIERS", AV44PreferredAgbSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPREFERREDAGBSUPPLIERS", AV44PreferredAgbSuppliers);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPREFERREDAGBSUPPLIERS", GetSecureSignedToken( sPrefix, AV44PreferredAgbSuppliers, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV23UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV23UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILESTOUPDATE", AV55FilesToUpdate);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILESTOUPDATE", AV55FilesToUpdate);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSUPPLIERAGBID_DATA", AV20SupplierAgbId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSUPPLIERAGBID_DATA", AV20SupplierAgbId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSUPPLIERGENID_DATA", AV22SupplierGenId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSUPPLIERGENID_DATA", AV22SupplierGenId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPRODUCTSERVICEDESCRIPTION", AV13ProductServiceDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV25WebSessionKey", wcpOAV25WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV12PreviousStep", wcpOAV12PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV10GoingBack", wcpOAV10GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV52IsPopup", wcpOAV52IsPopup);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV53FromToolBox_ProductServiceId", wcpOAV53FromToolBox_ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV54PageType", wcpOAV54PageType);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV10GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"vFROMTOOLBOX_PRODUCTSERVICEID", AV53FromToolBox_ProductServiceId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV31CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV11HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV11HasValidationErrors, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISPOPUP", AV52IsPopup);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPAGETYPE", AV54PageType);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV25WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICENAME", A59ProductServiceName);
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONID", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vORGANISATIONID", AV36OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vORGANISATIONID", GetSecureSignedToken( sPrefix, AV36OrganisationId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENCOMPANYNAME", A44SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENID", A42SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERAGBNAME", A51SupplierAgbName);
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERAGBID", A49SupplierAgbId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPREFERREDAGBSUPPLIERS", AV44PreferredAgbSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPREFERREDAGBSUPPLIERS", AV44PreferredAgbSuppliers);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPREFERREDAGBSUPPLIERS", GetSecureSignedToken( sPrefix, AV44PreferredAgbSuppliers, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISSTART", AV50isStart);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPREFERREDGENSUPPLIERS", AV45PreferredGenSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPREFERREDGENSUPPLIERS", AV45PreferredGenSuppliers);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV12PreviousStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERGENID_Selectedvalue_get", StringUtil.RTrim( Combo_suppliergenid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERAGBID_Selectedvalue_get", StringUtil.RTrim( Combo_supplieragbid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"IMAGEUPLOADUC_Faileduploadmessage", StringUtil.RTrim( Imageuploaduc_Faileduploadmessage));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERGENID_Selectedvalue_get", StringUtil.RTrim( Combo_suppliergenid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERAGBID_Selectedvalue_get", StringUtil.RTrim( Combo_supplieragbid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"IMAGEUPLOADUC_Faileduploadmessage", StringUtil.RTrim( Imageuploaduc_Faileduploadmessage));
      }

      protected void RenderHtmlCloseForm6C2( )
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
         return "WP_ProductServiceStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Product Service Step1", "") ;
      }

      protected void WB6C0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_productservicestep1.aspx");
               context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
               context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
            }
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "Service", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_ProductServiceStep1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", divTableattributes_Height, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLocationid_cell_Internalname, 1, 0, "px", 0, "px", divLocationid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", dynavLocationid.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavLocationid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLocationid_Internalname, context.GetMessage( "Location", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLocationid, dynavLocationid_Internalname, AV34LocationId.ToString(), 1, dynavLocationid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "guid", "", dynavLocationid.Visible, dynavLocationid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, 0, "HLP_WP_ProductServiceStep1.htm");
            dynavLocationid.CurrentValue = AV34LocationId.ToString();
            AssignProp(sPrefix, false, dynavLocationid_Internalname, "Values", (string)(dynavLocationid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProductservicename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductservicename_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductservicename_Internalname, AV17ProductServiceName, StringUtil.RTrim( context.localUtil.Format( AV17ProductServiceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductservicename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProductservicename_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblProductserviceimagetext_Internalname, context.GetMessage( "Images", ""), "", "", lblProductserviceimagetext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUcfilecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucImageuploaduc.SetProperty("UploadedFiles", AV23UploadedFiles);
            ucImageuploaduc.SetProperty("FilesToEdit", AV55FilesToUpdate);
            ucImageuploaduc.Render(context, "uc_customimageupload", Imageuploaduc_Internalname, sPrefix+"IMAGEUPLOADUCContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavProductserviceclass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavProductserviceclass_Internalname, context.GetMessage( "Category", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavProductserviceclass, cmbavProductserviceclass_Internalname, StringUtil.RTrim( AV40ProductServiceClass), 1, cmbavProductserviceclass_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavProductserviceclass.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_WP_ProductServiceStep1.htm");
            cmbavProductserviceclass.CurrentValue = StringUtil.RTrim( AV40ProductServiceClass);
            AssignProp(sPrefix, false, cmbavProductserviceclass_Internalname, "Values", (string)(cmbavProductserviceclass.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavProductservicegroup_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavProductservicegroup_Internalname, context.GetMessage( "Delivered By", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavProductservicegroup, dynavProductservicegroup_Internalname, StringUtil.RTrim( AV14ProductServiceGroup), 1, dynavProductservicegroup_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, dynavProductservicegroup.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_WP_ProductServiceStep1.htm");
            dynavProductservicegroup.CurrentValue = StringUtil.RTrim( AV14ProductServiceGroup);
            AssignProp(sPrefix, false, dynavProductservicegroup_Internalname, "Values", (string)(dynavProductservicegroup.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesupplieragb_Internalname, divTablesupplieragb_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsupplieragbid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_supplieragbid_Internalname, context.GetMessage( "AGB Supplier", ""), "", "", lblTextblockcombo_supplieragbid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table1_63_6C2( true) ;
         }
         else
         {
            wb_table1_63_6C2( false) ;
         }
         return  ;
      }

      protected void wb_table1_63_6C2e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesuppliergen_Internalname, divTablesuppliergen_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsuppliergenid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_suppliergenid_Internalname, context.GetMessage( "Supplier", ""), "", "", lblTextblockcombo_suppliergenid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table2_80_6C2( true) ;
         }
         else
         {
            wb_table2_80_6C2( false) ;
         }
         return  ;
      }

      protected void wb_table2_80_6C2e( bool wbgen )
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell CKEditor", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Productservicedescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Productservicedescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucProductservicedescription.SetProperty("Width", Productservicedescription_Width);
            ucProductservicedescription.SetProperty("Height", Productservicedescription_Height);
            ucProductservicedescription.SetProperty("Attribute", AV13ProductServiceDescription);
            ucProductservicedescription.SetProperty("Skin", Productservicedescription_Skin);
            ucProductservicedescription.SetProperty("Toolbar", Productservicedescription_Toolbar);
            ucProductservicedescription.SetProperty("CustomToolbar", Productservicedescription_Customtoolbar);
            ucProductservicedescription.SetProperty("CustomConfiguration", Productservicedescription_Customconfiguration);
            ucProductservicedescription.SetProperty("ToolbarCanCollapse", Productservicedescription_Toolbarcancollapse);
            ucProductservicedescription.SetProperty("ToolbarExpanded", Productservicedescription_Toolbarexpanded);
            ucProductservicedescription.SetProperty("CaptionClass", Productservicedescription_Captionclass);
            ucProductservicedescription.SetProperty("CaptionStyle", Productservicedescription_Captionstyle);
            ucProductservicedescription.SetProperty("CaptionPosition", Productservicedescription_Captionposition);
            ucProductservicedescription.Render(context, "fckeditor", Productservicedescription_Internalname, sPrefix+"PRODUCTSERVICEDESCRIPTIONContainer");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWizardActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardfirstprevious.SetProperty("TooltipText", Btnwizardfirstprevious_Tooltiptext);
            ucBtnwizardfirstprevious.SetProperty("BeforeIconClass", Btnwizardfirstprevious_Beforeiconclass);
            ucBtnwizardfirstprevious.SetProperty("Caption", Btnwizardfirstprevious_Caption);
            ucBtnwizardfirstprevious.SetProperty("Class", Btnwizardfirstprevious_Class);
            ucBtnwizardfirstprevious.Render(context, "wwp_iconbutton", Btnwizardfirstprevious_Internalname, sPrefix+"BTNWIZARDFIRSTPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardnext.SetProperty("TooltipText", Btnwizardnext_Tooltiptext);
            ucBtnwizardnext.SetProperty("AfterIconClass", Btnwizardnext_Aftericonclass);
            ucBtnwizardnext.SetProperty("Caption", Btnwizardnext_Caption);
            ucBtnwizardnext.SetProperty("Class", Btnwizardnext_Class);
            ucBtnwizardnext.Render(context, "wwp_iconbutton", Btnwizardnext_Internalname, sPrefix+"BTNWIZARDNEXTContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSupplieragbid_Internalname, AV19SupplierAgbId.ToString(), AV19SupplierAgbId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSupplieragbid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSupplieragbid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_ProductServiceStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSuppliergenid_Internalname, AV21SupplierGenId.ToString(), AV21SupplierGenId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSuppliergenid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSuppliergenid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_ProductServiceStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductserviceid_Internalname, AV15ProductServiceId.ToString(), AV15ProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductserviceid_Jsonclick, 0, "Attribute", "", "", "", "", edtavProductserviceid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_ProductServiceStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductservicetilename_Internalname, StringUtil.RTrim( AV18ProductServiceTileName), StringUtil.RTrim( context.localUtil.Format( AV18ProductServiceTileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductservicetilename_Jsonclick, 0, "Attribute", "", "", "", "", edtavProductservicetilename_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProductServiceStep1.htm");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavProductserviceimagevar_Internalname, AV37ProductServiceImageVar, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", 0, edtavProductserviceimagevar_Visible, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WP_ProductServiceStep1.htm");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavUploadedimagevalues_Internalname, AV56UploadedImageValues, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", 0, edtavUploadedimagevalues_Visible, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WP_ProductServiceStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilename_Internalname, AV32FileName, StringUtil.RTrim( context.localUtil.Format( AV32FileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilename_Jsonclick, 0, "Attribute", "", "", "", "", edtavFilename_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6C2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Product Service Step1", ""), 0) ;
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
               STRUP6C0( ) ;
            }
         }
      }

      protected void WS6C2( )
      {
         START6C2( ) ;
         EVT6C2( ) ;
      }

      protected void EVT6C2( )
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
                                 STRUP6C0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "IMAGEUPLOADUC.ONFAILEDUPLOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Imageuploaduc.Onfailedupload */
                                    E116C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERAGBID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_supplieragbid.Onoptionclicked */
                                    E126C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERGENID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_suppliergenid.Onoptionclicked */
                                    E136C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E146C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E156C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
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
                                          /* Execute user event: Enter */
                                          E166C2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E176C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUserAction1' */
                                    E186C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VPRODUCTSERVICEGROUP.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E196C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNOFILTERGEN.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E206C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNOFILTERAGB.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E216C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.REFRESHPREFERREDSUPPLIER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E226C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E236C2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = dynavLocationid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE6C2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6C2( ) ;
            }
         }
      }

      protected void PA6C2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_productservicestep1.aspx")), "wp_productservicestep1.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_productservicestep1.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
               GX_FocusControl = dynavLocationid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvLOCATIONID6C2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLOCATIONID_data6C2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvLOCATIONID_html6C2( )
      {
         Guid gxdynajaxvalue;
         GXDLVvLOCATIONID_data6C2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLocationid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavLocationid.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvLOCATIONID_data6C2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(Guid.Empty.ToString());
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Location", ""));
         /* Using cursor H006C2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( H006C2_A11OrganisationId[0] == new prc_getuserorganisationid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(H006C2_A29LocationId[0].ToString());
               gxdynajaxctrldescr.Add(H006C2_A31LocationName[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDSVvPRODUCTSERVICEGROUP6C2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDSVvPRODUCTSERVICEGROUP_data6C2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrldescr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrldescr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvPRODUCTSERVICEGROUP_html6C2( )
      {
         string gxdynajaxvalue;
         GXDSVvPRODUCTSERVICEGROUP_data6C2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavProductservicegroup.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex));
            dynavProductservicegroup.addItem(gxdynajaxvalue, ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDSVvPRODUCTSERVICEGROUP_data6C2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add("");
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Service Delivery", ""));
         GXBaseCollection<SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem> gxcolvPRODUCTSERVICEGROUP;
         SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem gxcolitemvPRODUCTSERVICEGROUP;
         new dp_productservicesuppliergroup(context ).execute( out  gxcolvPRODUCTSERVICEGROUP) ;
         gxcolvPRODUCTSERVICEGROUP.Sort("Sdt_productservicesuppliergroupname");
         int gxindex = 1;
         while ( gxindex <= gxcolvPRODUCTSERVICEGROUP.Count )
         {
            gxcolitemvPRODUCTSERVICEGROUP = ((SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem)gxcolvPRODUCTSERVICEGROUP.Item(gxindex));
            gxdynajaxctrlcodr.Add(gxcolitemvPRODUCTSERVICEGROUP.gxTpr_Sdt_productservicesuppliergroupid);
            gxdynajaxctrldescr.Add(gxcolitemvPRODUCTSERVICEGROUP.gxTpr_Sdt_productservicesuppliergroupname);
            gxindex = (int)(gxindex+1);
         }
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvLOCATIONID_html6C2( ) ;
            GXVvPRODUCTSERVICEGROUP_html6C2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavLocationid.ItemCount > 0 )
         {
            AV34LocationId = StringUtil.StrToGuid( dynavLocationid.getValidValue(AV34LocationId.ToString()));
            AssignAttri(sPrefix, false, "AV34LocationId", AV34LocationId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLocationid.CurrentValue = AV34LocationId.ToString();
            AssignProp(sPrefix, false, dynavLocationid_Internalname, "Values", dynavLocationid.ToJavascriptSource(), true);
         }
         if ( cmbavProductserviceclass.ItemCount > 0 )
         {
            AV40ProductServiceClass = cmbavProductserviceclass.getValidValue(AV40ProductServiceClass);
            AssignAttri(sPrefix, false, "AV40ProductServiceClass", AV40ProductServiceClass);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavProductserviceclass.CurrentValue = StringUtil.RTrim( AV40ProductServiceClass);
            AssignProp(sPrefix, false, cmbavProductserviceclass_Internalname, "Values", cmbavProductserviceclass.ToJavascriptSource(), true);
         }
         if ( dynavProductservicegroup.ItemCount > 0 )
         {
            AV14ProductServiceGroup = dynavProductservicegroup.getValidValue(AV14ProductServiceGroup);
            AssignAttri(sPrefix, false, "AV14ProductServiceGroup", AV14ProductServiceGroup);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavProductservicegroup.CurrentValue = StringUtil.RTrim( AV14ProductServiceGroup);
            AssignProp(sPrefix, false, dynavProductservicegroup_Internalname, "Values", dynavProductservicegroup.ToJavascriptSource(), true);
         }
         AV47noFilterAgb = StringUtil.StrToBool( StringUtil.BoolToStr( AV47noFilterAgb));
         AssignAttri(sPrefix, false, "AV47noFilterAgb", AV47noFilterAgb);
         AV48noFilterGen = StringUtil.StrToBool( StringUtil.BoolToStr( AV48noFilterGen));
         AssignAttri(sPrefix, false, "AV48noFilterGen", AV48noFilterGen);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF6C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E156C2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E236C2 ();
            WB6C0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6C2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV11HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV11HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORGANISATIONID", AV36OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vORGANISATIONID", GetSecureSignedToken( sPrefix, AV36OrganisationId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPREFERREDAGBSUPPLIERS", AV44PreferredAgbSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPREFERREDAGBSUPPLIERS", AV44PreferredAgbSuppliers);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPREFERREDAGBSUPPLIERS", GetSecureSignedToken( sPrefix, AV44PreferredAgbSuppliers, context));
      }

      protected void before_start_formulas( )
      {
         GXVvLOCATIONID_html6C2( ) ;
         GXVvPRODUCTSERVICEGROUP_html6C2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E146C2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV23UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILESTOUPDATE"), AV55FilesToUpdate);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSUPPLIERAGBID_DATA"), AV20SupplierAgbId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSUPPLIERGENID_DATA"), AV22SupplierGenId_Data);
            /* Read saved values. */
            AV13ProductServiceDescription = cgiGet( sPrefix+"vPRODUCTSERVICEDESCRIPTION");
            wcpOAV25WebSessionKey = cgiGet( sPrefix+"wcpOAV25WebSessionKey");
            wcpOAV12PreviousStep = cgiGet( sPrefix+"wcpOAV12PreviousStep");
            wcpOAV10GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV10GoingBack"));
            wcpOAV52IsPopup = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV52IsPopup"));
            wcpOAV53FromToolBox_ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV53FromToolBox_ProductServiceId"));
            wcpOAV54PageType = cgiGet( sPrefix+"wcpOAV54PageType");
            Combo_suppliergenid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_SUPPLIERGENID_Selectedvalue_get");
            Combo_supplieragbid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_SUPPLIERAGBID_Selectedvalue_get");
            Imageuploaduc_Faileduploadmessage = cgiGet( sPrefix+"IMAGEUPLOADUC_Faileduploadmessage");
            /* Read variables values. */
            dynavLocationid.CurrentValue = cgiGet( dynavLocationid_Internalname);
            AV34LocationId = StringUtil.StrToGuid( cgiGet( dynavLocationid_Internalname));
            AssignAttri(sPrefix, false, "AV34LocationId", AV34LocationId.ToString());
            AV17ProductServiceName = cgiGet( edtavProductservicename_Internalname);
            AssignAttri(sPrefix, false, "AV17ProductServiceName", AV17ProductServiceName);
            cmbavProductserviceclass.CurrentValue = cgiGet( cmbavProductserviceclass_Internalname);
            AV40ProductServiceClass = cgiGet( cmbavProductserviceclass_Internalname);
            AssignAttri(sPrefix, false, "AV40ProductServiceClass", AV40ProductServiceClass);
            dynavProductservicegroup.CurrentValue = cgiGet( dynavProductservicegroup_Internalname);
            AV14ProductServiceGroup = cgiGet( dynavProductservicegroup_Internalname);
            AssignAttri(sPrefix, false, "AV14ProductServiceGroup", AV14ProductServiceGroup);
            AV47noFilterAgb = StringUtil.StrToBool( cgiGet( chkavNofilteragb_Internalname));
            AssignAttri(sPrefix, false, "AV47noFilterAgb", AV47noFilterAgb);
            AV48noFilterGen = StringUtil.StrToBool( cgiGet( chkavNofiltergen_Internalname));
            AssignAttri(sPrefix, false, "AV48noFilterGen", AV48noFilterGen);
            if ( StringUtil.StrCmp(cgiGet( edtavSupplieragbid_Internalname), "") == 0 )
            {
               AV19SupplierAgbId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV19SupplierAgbId", AV19SupplierAgbId.ToString());
            }
            else
            {
               try
               {
                  AV19SupplierAgbId = StringUtil.StrToGuid( cgiGet( edtavSupplieragbid_Internalname));
                  AssignAttri(sPrefix, false, "AV19SupplierAgbId", AV19SupplierAgbId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vSUPPLIERAGBID");
                  GX_FocusControl = edtavSupplieragbid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavSuppliergenid_Internalname), "") == 0 )
            {
               AV21SupplierGenId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV21SupplierGenId", AV21SupplierGenId.ToString());
            }
            else
            {
               try
               {
                  AV21SupplierGenId = StringUtil.StrToGuid( cgiGet( edtavSuppliergenid_Internalname));
                  AssignAttri(sPrefix, false, "AV21SupplierGenId", AV21SupplierGenId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vSUPPLIERGENID");
                  GX_FocusControl = edtavSuppliergenid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavProductserviceid_Internalname), "") == 0 )
            {
               AV15ProductServiceId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV15ProductServiceId", AV15ProductServiceId.ToString());
            }
            else
            {
               try
               {
                  AV15ProductServiceId = StringUtil.StrToGuid( cgiGet( edtavProductserviceid_Internalname));
                  AssignAttri(sPrefix, false, "AV15ProductServiceId", AV15ProductServiceId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vPRODUCTSERVICEID");
                  GX_FocusControl = edtavProductserviceid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV18ProductServiceTileName = cgiGet( edtavProductservicetilename_Internalname);
            AssignAttri(sPrefix, false, "AV18ProductServiceTileName", AV18ProductServiceTileName);
            AV37ProductServiceImageVar = cgiGet( edtavProductserviceimagevar_Internalname);
            AssignAttri(sPrefix, false, "AV37ProductServiceImageVar", AV37ProductServiceImageVar);
            AV56UploadedImageValues = cgiGet( edtavUploadedimagevalues_Internalname);
            AssignAttri(sPrefix, false, "AV56UploadedImageValues", AV56UploadedImageValues);
            AV32FileName = cgiGet( edtavFilename_Internalname);
            AssignAttri(sPrefix, false, "AV32FileName", AV32FileName);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            GXVvLOCATIONID_html6C2( ) ;
            GXVvPRODUCTSERVICEGROUP_html6C2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E146C2 ();
         if (returnInSub) return;
      }

      protected void E146C2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV57WWPContext) ;
         AV36OrganisationId = AV57WWPContext.gxTpr_Organisationid;
         AssignAttri(sPrefix, false, "AV36OrganisationId", AV36OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vORGANISATIONID", GetSecureSignedToken( sPrefix, AV36OrganisationId, context));
         GXt_objcol_guid1 = AV45PreferredGenSuppliers;
         new prc_getpreferredgensuppliers(context ).execute( ref  GXt_objcol_guid1) ;
         AV45PreferredGenSuppliers = GXt_objcol_guid1;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         divTableattributes_Height = 350;
         AssignProp(sPrefix, false, divTableattributes_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTableattributes_Height), 9, 0), true);
         edtavSuppliergenid_Visible = 0;
         AssignProp(sPrefix, false, edtavSuppliergenid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSuppliergenid_Visible), 5, 0), true);
         edtavSupplieragbid_Visible = 0;
         AssignProp(sPrefix, false, edtavSupplieragbid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplieragbid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S142 ();
         if (returnInSub) return;
         edtavProductserviceid_Visible = 0;
         AssignProp(sPrefix, false, edtavProductserviceid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProductserviceid_Visible), 5, 0), true);
         edtavProductservicetilename_Visible = 0;
         AssignProp(sPrefix, false, edtavProductservicetilename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProductservicetilename_Visible), 5, 0), true);
         edtavProductserviceimagevar_Visible = 0;
         AssignProp(sPrefix, false, edtavProductserviceimagevar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProductserviceimagevar_Visible), 5, 0), true);
         edtavUploadedimagevalues_Visible = 0;
         AssignProp(sPrefix, false, edtavUploadedimagevalues_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUploadedimagevalues_Visible), 5, 0), true);
         edtavFilename_Visible = 0;
         AssignProp(sPrefix, false, edtavFilename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFilename_Visible), 5, 0), true);
         if ( (Guid.Empty==AV19SupplierAgbId) )
         {
            divTablesupplieragb_Visible = 0;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
         }
         else
         {
            divTablesupplieragb_Visible = 1;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
         }
         if ( (Guid.Empty==AV21SupplierGenId) )
         {
            divTablesuppliergen_Visible = 0;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
         }
         else
         {
            divTablesuppliergen_Visible = 1;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
         }
         AV14ProductServiceGroup = AV57WWPContext.gxTpr_Locationid.ToString();
         AssignAttri(sPrefix, false, "AV14ProductServiceGroup", AV14ProductServiceGroup);
         if ( StringUtil.StrCmp(AV14ProductServiceGroup, " AGB Supplier") == 0 )
         {
            divTablesupplieragb_Visible = 1;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
            divTablesuppliergen_Visible = 0;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
            AV21SupplierGenId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV21SupplierGenId", AV21SupplierGenId.ToString());
         }
         else if ( StringUtil.StrCmp(AV14ProductServiceGroup, "Supplier") == 0 )
         {
            divTablesuppliergen_Visible = 1;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
            divTablesupplieragb_Visible = 0;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
            AV19SupplierAgbId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV19SupplierAgbId", AV19SupplierAgbId.ToString());
         }
         else
         {
            divTablesuppliergen_Visible = 0;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
            divTablesupplieragb_Visible = 0;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
            AV19SupplierAgbId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV19SupplierAgbId", AV19SupplierAgbId.ToString());
            AV21SupplierGenId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV21SupplierGenId", AV21SupplierGenId.ToString());
         }
         AV50isStart = true;
         AssignAttri(sPrefix, false, "AV50isStart", AV50isStart);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID_GENID' */
         S152 ();
         if (returnInSub) return;
         if ( AV57WWPContext.gxTpr_Isorganisationmanager || AV57WWPContext.gxTpr_Isrootadmin )
         {
            dynavLocationid.Visible = 1;
            AssignProp(sPrefix, false, dynavLocationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationid.Visible), 5, 0), true);
         }
         else
         {
            dynavLocationid.Visible = 0;
            AssignProp(sPrefix, false, dynavLocationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationid.Visible), 5, 0), true);
            AV34LocationId = AV57WWPContext.gxTpr_Locationid;
            AssignAttri(sPrefix, false, "AV34LocationId", AV34LocationId.ToString());
         }
         if ( StringUtil.StrCmp(AV54PageType, "MyCare") == 0 )
         {
            cmbavProductserviceclass.removeItem(context.GetMessage( "My Services", ""));
            cmbavProductserviceclass.removeItem(context.GetMessage( "My Living", ""));
         }
         else if ( StringUtil.StrCmp(AV54PageType, "MyService") == 0 )
         {
            cmbavProductserviceclass.removeItem(context.GetMessage( "My Care", ""));
            cmbavProductserviceclass.removeItem(context.GetMessage( "My Living", ""));
         }
         else if ( StringUtil.StrCmp(AV54PageType, "MyLiving") == 0 )
         {
            cmbavProductserviceclass.removeItem(context.GetMessage( "My Care", ""));
            cmbavProductserviceclass.removeItem(context.GetMessage( "My Services", ""));
         }
         else
         {
         }
      }

      protected void E156C2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         AV10GoingBack = false;
         AssignAttri(sPrefix, false, "AV10GoingBack", AV10GoingBack);
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E166C2 ();
         if (returnInSub) return;
      }

      protected void E166C2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( (Guid.Empty==AV53FromToolBox_ProductServiceId) )
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
            S172 ();
            if (returnInSub) return;
            if ( AV31CheckRequiredFieldsResult && ! AV11HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S182 ();
               if (returnInSub) return;
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wp_productservice.aspx"+UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.BoolToStr(false)) + "," + UrlEncode(StringUtil.BoolToStr(AV52IsPopup)) + "," + UrlEncode(AV53FromToolBox_ProductServiceId.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV54PageType));
               CallWebObject(formatLink("wp_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
         }
         else
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS2' */
            S192 ();
            if (returnInSub) return;
            if ( AV31CheckRequiredFieldsResult && ! AV11HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S182 ();
               if (returnInSub) return;
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wp_productservice.aspx"+UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.BoolToStr(false)) + "," + UrlEncode(StringUtil.BoolToStr(AV52IsPopup)) + "," + UrlEncode(AV53FromToolBox_ProductServiceId.ToString());
               CallWebObject(formatLink("wp_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E176C2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         if ( (Guid.Empty==AV53FromToolBox_ProductServiceId) )
         {
            CallWebObject(formatLink("trn_productserviceww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            context.setWebReturnParms(new Object[] {(bool)AV52IsPopup,(Guid)AV53FromToolBox_ProductServiceId,(string)AV54PageType});
            context.setWebReturnParmsMetadata(new Object[] {"AV52IsPopup","AV53FromToolBox_ProductServiceId","AV54PageType"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         context.setWebReturnParms(new Object[] {(bool)AV52IsPopup,(Guid)AV53FromToolBox_ProductServiceId,(string)AV54PageType});
         context.setWebReturnParmsMetadata(new Object[] {"AV52IsPopup","AV53FromToolBox_ProductServiceId","AV54PageType"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E136C2( )
      {
         /* Combo_suppliergenid_Onoptionclicked Routine */
         returnInSub = false;
         AV19SupplierAgbId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV19SupplierAgbId", AV19SupplierAgbId.ToString());
         if ( StringUtil.StrCmp(Combo_suppliergenid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createnewgeneralsupplier.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(AV21SupplierGenId.ToString());
            context.PopUp(formatLink("wp_createnewgeneralsupplier.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_suppliergenid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENID' */
            S132 ();
            if (returnInSub) return;
            AV6ComboSelectedValue = AV49Session.Get("SUPPLIERGENID");
            AV49Session.Remove("SUPPLIERGENID");
            Combo_suppliergenid_Selectedvalue_set = AV6ComboSelectedValue;
            ucCombo_suppliergenid.SendProperty(context, sPrefix, false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
            AV21SupplierGenId = StringUtil.StrToGuid( AV6ComboSelectedValue);
            AssignAttri(sPrefix, false, "AV21SupplierGenId", AV21SupplierGenId.ToString());
         }
         else
         {
            AV21SupplierGenId = StringUtil.StrToGuid( Combo_suppliergenid_Selectedvalue_get);
            AssignAttri(sPrefix, false, "AV21SupplierGenId", AV21SupplierGenId.ToString());
            /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENID' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22SupplierGenId_Data", AV22SupplierGenId_Data);
      }

      protected void E126C2( )
      {
         /* Combo_supplieragbid_Onoptionclicked Routine */
         returnInSub = false;
         AV21SupplierGenId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV21SupplierGenId", AV21SupplierGenId.ToString());
         AV19SupplierAgbId = StringUtil.StrToGuid( Combo_supplieragbid_Selectedvalue_get);
         AssignAttri(sPrefix, false, "AV19SupplierAgbId", AV19SupplierAgbId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV10GoingBack ) )
         {
            Btnwizardfirstprevious_Visible = false;
            ucBtnwizardfirstprevious.SendProperty(context, sPrefix, false, Btnwizardfirstprevious_Internalname, "Visible", StringUtil.BoolToStr( Btnwizardfirstprevious_Visible));
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV26WizardData.FromJSonString(AV24WebSession.Get(AV25WebSessionKey), null);
         AV40ProductServiceClass = AV26WizardData.gxTpr_Step1.gxTpr_Productserviceclass;
         AssignAttri(sPrefix, false, "AV40ProductServiceClass", AV40ProductServiceClass);
         AV14ProductServiceGroup = AV26WizardData.gxTpr_Step1.gxTpr_Productservicegroup;
         AssignAttri(sPrefix, false, "AV14ProductServiceGroup", AV14ProductServiceGroup);
         AV13ProductServiceDescription = AV26WizardData.gxTpr_Step1.gxTpr_Productservicedescription;
         AssignAttri(sPrefix, false, "AV13ProductServiceDescription", AV13ProductServiceDescription);
         AV21SupplierGenId = AV26WizardData.gxTpr_Step1.gxTpr_Suppliergenid;
         AssignAttri(sPrefix, false, "AV21SupplierGenId", AV21SupplierGenId.ToString());
         AV48noFilterGen = AV26WizardData.gxTpr_Step1.gxTpr_Nofiltergen;
         AssignAttri(sPrefix, false, "AV48noFilterGen", AV48noFilterGen);
         AV19SupplierAgbId = AV26WizardData.gxTpr_Step1.gxTpr_Supplieragbid;
         AssignAttri(sPrefix, false, "AV19SupplierAgbId", AV19SupplierAgbId.ToString());
         AV47noFilterAgb = AV26WizardData.gxTpr_Step1.gxTpr_Nofilteragb;
         AssignAttri(sPrefix, false, "AV47noFilterAgb", AV47noFilterAgb);
         AV34LocationId = AV26WizardData.gxTpr_Step1.gxTpr_Locationid;
         AssignAttri(sPrefix, false, "AV34LocationId", AV34LocationId.ToString());
         AV15ProductServiceId = AV26WizardData.gxTpr_Step1.gxTpr_Productserviceid;
         AssignAttri(sPrefix, false, "AV15ProductServiceId", AV15ProductServiceId.ToString());
         AV17ProductServiceName = AV26WizardData.gxTpr_Step1.gxTpr_Productservicename;
         AssignAttri(sPrefix, false, "AV17ProductServiceName", AV17ProductServiceName);
         AV18ProductServiceTileName = AV26WizardData.gxTpr_Step1.gxTpr_Productservicetilename;
         AssignAttri(sPrefix, false, "AV18ProductServiceTileName", AV18ProductServiceTileName);
         AV37ProductServiceImageVar = AV26WizardData.gxTpr_Step1.gxTpr_Productserviceimagevar;
         AssignAttri(sPrefix, false, "AV37ProductServiceImageVar", AV37ProductServiceImageVar);
         AV56UploadedImageValues = AV26WizardData.gxTpr_Step1.gxTpr_Uploadedimagevalues;
         AssignAttri(sPrefix, false, "AV56UploadedImageValues", AV56UploadedImageValues);
         AV32FileName = AV26WizardData.gxTpr_Step1.gxTpr_Filename;
         AssignAttri(sPrefix, false, "AV32FileName", AV32FileName);
         if ( AV55FilesToUpdate.FromJSonString(AV26WizardData.gxTpr_Step1.gxTpr_Uploadedimagevalues, null) )
         {
         }
      }

      protected void S182( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         if ( AV23UploadedFiles.Count > 0 )
         {
            AV56UploadedImageValues = AV23UploadedFiles.ToJSonString(false);
            AssignAttri(sPrefix, false, "AV56UploadedImageValues", AV56UploadedImageValues);
         }
         if ( StringUtil.StrCmp(AV14ProductServiceGroup, "Location") == 0 )
         {
            AV19SupplierAgbId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV19SupplierAgbId", AV19SupplierAgbId.ToString());
            AV21SupplierGenId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV21SupplierGenId", AV21SupplierGenId.ToString());
         }
         AV15ProductServiceId = Guid.NewGuid( );
         AssignAttri(sPrefix, false, "AV15ProductServiceId", AV15ProductServiceId.ToString());
         AV26WizardData.FromJSonString(AV24WebSession.Get(AV25WebSessionKey), null);
         AV26WizardData.gxTpr_Step1.gxTpr_Productserviceclass = AV40ProductServiceClass;
         AV26WizardData.gxTpr_Step1.gxTpr_Productservicegroup = AV14ProductServiceGroup;
         AV26WizardData.gxTpr_Step1.gxTpr_Productservicedescription = AV13ProductServiceDescription;
         AV26WizardData.gxTpr_Step1.gxTpr_Suppliergenid = AV21SupplierGenId;
         AV26WizardData.gxTpr_Step1.gxTpr_Nofiltergen = AV48noFilterGen;
         AV26WizardData.gxTpr_Step1.gxTpr_Supplieragbid = AV19SupplierAgbId;
         AV26WizardData.gxTpr_Step1.gxTpr_Nofilteragb = AV47noFilterAgb;
         AV26WizardData.gxTpr_Step1.gxTpr_Locationid = AV34LocationId;
         AV26WizardData.gxTpr_Step1.gxTpr_Productserviceid = AV15ProductServiceId;
         AV26WizardData.gxTpr_Step1.gxTpr_Productservicename = AV17ProductServiceName;
         AV26WizardData.gxTpr_Step1.gxTpr_Productservicetilename = AV18ProductServiceTileName;
         AV26WizardData.gxTpr_Step1.gxTpr_Productserviceimagevar = AV37ProductServiceImageVar;
         AV26WizardData.gxTpr_Step1.gxTpr_Uploadedimagevalues = AV56UploadedImageValues;
         AV26WizardData.gxTpr_Step1.gxTpr_Filename = AV32FileName;
         AV24WebSession.Set(AV25WebSessionKey, AV26WizardData.ToJSonString(false, true));
      }

      protected void S172( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV31CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         if ( ( AV51GAMUser.checkrole("Organisation Manager") || AV51GAMUser.checkrole("Root Admin") ) && (Guid.Empty==AV34LocationId) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Location", ""), "", "", "", "", "", "", "", ""),  "error",  dynavLocationid_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17ProductServiceName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavProductservicename_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40ProductServiceClass)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Category", ""), "", "", "", "", "", "", "", ""),  "error",  cmbavProductserviceclass_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( new prc_uniquelocationservicename(context).executeUdp(  AV17ProductServiceName,  AV34LocationId,  AV15ProductServiceId) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Service name already exist", ""),  "error",  edtavProductservicename_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
      }

      protected void S142( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( AV51GAMUser.checkrole("Organisation Manager") || AV51GAMUser.checkrole("Root Admin") )
         {
            divLocationid_cell_Class = "col-xs-12 RequiredDataContentCell";
            AssignProp(sPrefix, false, divLocationid_cell_Internalname, "Class", divLocationid_cell_Class, true);
         }
         else
         {
            divLocationid_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divLocationid_cell_Internalname, "Class", divLocationid_cell_Class, true);
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOSUPPLIERGENID' Routine */
         returnInSub = false;
         AV22SupplierGenId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GXt_boolean2 = false;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "<Check_Is_Authenticated>", out  GXt_boolean2) ;
         Combo_suppliergenid_Includeaddnewoption = GXt_boolean2;
         ucCombo_suppliergenid.SendProperty(context, sPrefix, false, Combo_suppliergenid_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_suppliergenid_Includeaddnewoption));
         /* Using cursor H006C3 */
         pr_default.execute(1, new Object[] {AV36OrganisationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A602SG_LocationSupplierOrganisatio = H006C3_A602SG_LocationSupplierOrganisatio[0];
            n602SG_LocationSupplierOrganisatio = H006C3_n602SG_LocationSupplierOrganisatio[0];
            A603SG_LocationSupplierLocationId = H006C3_A603SG_LocationSupplierLocationId[0];
            n603SG_LocationSupplierLocationId = H006C3_n603SG_LocationSupplierLocationId[0];
            A630ToolBoxLastUpdateReceptionistI = H006C3_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = H006C3_n630ToolBoxLastUpdateReceptionistI[0];
            A89ReceptionistId = H006C3_A89ReceptionistId[0];
            A29LocationId = H006C3_A29LocationId[0];
            A42SupplierGenId = H006C3_A42SupplierGenId[0];
            A44SupplierGenCompanyName = H006C3_A44SupplierGenCompanyName[0];
            A630ToolBoxLastUpdateReceptionistI = H006C3_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = H006C3_n630ToolBoxLastUpdateReceptionistI[0];
            /* Using cursor H006C4 */
            pr_default.execute(2, new Object[] {n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio});
            pr_default.close(2);
            AV5Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV5Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
            AV5Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
            AV22SupplierGenId_Data.Add(AV5Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         pr_default.close(2);
         Combo_suppliergenid_Selectedvalue_set = ((Guid.Empty==AV21SupplierGenId) ? "" : StringUtil.Trim( AV21SupplierGenId.ToString()));
         ucCombo_suppliergenid.SendProperty(context, sPrefix, false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUPPLIERAGBID' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A49SupplierAgbId ,
                                              AV44PreferredAgbSuppliers } ,
                                              new int[]{
                                              }
         });
         /* Using cursor H006C5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A49SupplierAgbId = H006C5_A49SupplierAgbId[0];
            A51SupplierAgbName = H006C5_A51SupplierAgbName[0];
            AV5Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV5Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
            AV5Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
            AV20SupplierAgbId_Data.Add(AV5Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_supplieragbid_Selectedvalue_set = ((Guid.Empty==AV19SupplierAgbId) ? "" : StringUtil.Trim( AV19SupplierAgbId.ToString()));
         ucCombo_supplieragbid.SendProperty(context, sPrefix, false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
      }

      protected void E186C2( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {(bool)AV52IsPopup,(Guid)AV53FromToolBox_ProductServiceId,(string)AV54PageType});
         context.setWebReturnParmsMetadata(new Object[] {"AV52IsPopup","AV53FromToolBox_ProductServiceId","AV54PageType"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E196C2( )
      {
         /* Productservicegroup_Controlvaluechanged Routine */
         returnInSub = false;
         AV47noFilterAgb = true;
         AssignAttri(sPrefix, false, "AV47noFilterAgb", AV47noFilterAgb);
         AV48noFilterGen = true;
         AssignAttri(sPrefix, false, "AV48noFilterGen", AV48noFilterGen);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID_GENID' */
         S152 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV14ProductServiceGroup, " AGB Supplier") == 0 )
         {
            divTablesupplieragb_Visible = 1;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
            divTablesuppliergen_Visible = 0;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
            AV21SupplierGenId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV21SupplierGenId", AV21SupplierGenId.ToString());
         }
         else if ( StringUtil.StrCmp(AV14ProductServiceGroup, "Supplier") == 0 )
         {
            divTablesuppliergen_Visible = 1;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
            divTablesupplieragb_Visible = 0;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
            AV19SupplierAgbId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV19SupplierAgbId", AV19SupplierAgbId.ToString());
         }
         else
         {
            divTablesuppliergen_Visible = 0;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
            divTablesupplieragb_Visible = 0;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
            AV19SupplierAgbId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV19SupplierAgbId", AV19SupplierAgbId.ToString());
            AV21SupplierGenId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV21SupplierGenId", AV21SupplierGenId.ToString());
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20SupplierAgbId_Data", AV20SupplierAgbId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22SupplierGenId_Data", AV22SupplierGenId_Data);
      }

      protected void E206C2( )
      {
         /* Nofiltergen_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID_GENID' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20SupplierAgbId_Data", AV20SupplierAgbId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22SupplierGenId_Data", AV22SupplierGenId_Data);
      }

      protected void E116C2( )
      {
         /* Imageuploaduc_Onfailedupload Routine */
         returnInSub = false;
         GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  Imageuploaduc_Faileduploadmessage,  "error",  "",  "true",  ""));
      }

      protected void E216C2( )
      {
         /* Nofilteragb_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID_GENID' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20SupplierAgbId_Data", AV20SupplierAgbId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22SupplierGenId_Data", AV22SupplierGenId_Data);
      }

      protected void E226C2( )
      {
         /* General\GlobalEvents_Refreshpreferredsupplier Routine */
         returnInSub = false;
         GXt_objcol_guid1 = AV45PreferredGenSuppliers;
         new prc_getpreferredgensuppliers(context ).execute( ref  GXt_objcol_guid1) ;
         AV45PreferredGenSuppliers = GXt_objcol_guid1;
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID_GENID' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV45PreferredGenSuppliers", AV45PreferredGenSuppliers);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20SupplierAgbId_Data", AV20SupplierAgbId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22SupplierGenId_Data", AV22SupplierGenId_Data);
      }

      protected void S152( )
      {
         /* 'LOADCOMBOSUPPLIERAGBID_GENID' Routine */
         returnInSub = false;
         AV20SupplierAgbId_Data.Clear();
         AV22SupplierGenId_Data.Clear();
         if ( ! AV47noFilterAgb && ( StringUtil.StrCmp(AV14ProductServiceGroup, " AGB Supplier") == 0 ) )
         {
            /* Using cursor H006C6 */
            pr_default.execute(4);
            while ( (pr_default.getStatus(4) != 101) )
            {
               A49SupplierAgbId = H006C6_A49SupplierAgbId[0];
               A51SupplierAgbName = H006C6_A51SupplierAgbName[0];
               AV5Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV5Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
               AV5Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
               AV20SupplierAgbId_Data.Add(AV5Combo_DataItem, 0);
               pr_default.readNext(4);
            }
            pr_default.close(4);
            Combo_supplieragbid_Selectedvalue_set = ((Guid.Empty==AV19SupplierAgbId) ? "" : StringUtil.Trim( AV19SupplierAgbId.ToString()));
            ucCombo_supplieragbid.SendProperty(context, sPrefix, false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
         }
         else if ( ( AV47noFilterAgb ) && ( StringUtil.StrCmp(AV14ProductServiceGroup, " AGB Supplier") == 0 ) )
         {
            pr_default.dynParam(5, new Object[]{ new Object[]{
                                                 A49SupplierAgbId ,
                                                 AV44PreferredAgbSuppliers } ,
                                                 new int[]{
                                                 }
            });
            /* Using cursor H006C7 */
            pr_default.execute(5);
            while ( (pr_default.getStatus(5) != 101) )
            {
               A49SupplierAgbId = H006C7_A49SupplierAgbId[0];
               A51SupplierAgbName = H006C7_A51SupplierAgbName[0];
               AV5Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV5Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
               AV5Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
               AV20SupplierAgbId_Data.Add(AV5Combo_DataItem, 0);
               pr_default.readNext(5);
            }
            pr_default.close(5);
            if ( ! AV50isStart )
            {
               AV19SupplierAgbId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV19SupplierAgbId", AV19SupplierAgbId.ToString());
            }
            Combo_supplieragbid_Selectedvalue_set = ((Guid.Empty==AV19SupplierAgbId) ? "" : StringUtil.Trim( AV19SupplierAgbId.ToString()));
            ucCombo_supplieragbid.SendProperty(context, sPrefix, false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
         }
         else if ( ! AV48noFilterGen && ( StringUtil.StrCmp(AV14ProductServiceGroup, "Supplier") == 0 ) )
         {
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 A42SupplierGenId ,
                                                 AV45PreferredGenSuppliers ,
                                                 A11OrganisationId ,
                                                 AV36OrganisationId } ,
                                                 new int[]{
                                                 }
            });
            /* Using cursor H006C8 */
            pr_default.execute(6, new Object[] {AV36OrganisationId});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A602SG_LocationSupplierOrganisatio = H006C8_A602SG_LocationSupplierOrganisatio[0];
               n602SG_LocationSupplierOrganisatio = H006C8_n602SG_LocationSupplierOrganisatio[0];
               A603SG_LocationSupplierLocationId = H006C8_A603SG_LocationSupplierLocationId[0];
               n603SG_LocationSupplierLocationId = H006C8_n603SG_LocationSupplierLocationId[0];
               A630ToolBoxLastUpdateReceptionistI = H006C8_A630ToolBoxLastUpdateReceptionistI[0];
               n630ToolBoxLastUpdateReceptionistI = H006C8_n630ToolBoxLastUpdateReceptionistI[0];
               A89ReceptionistId = H006C8_A89ReceptionistId[0];
               A29LocationId = H006C8_A29LocationId[0];
               A42SupplierGenId = H006C8_A42SupplierGenId[0];
               A44SupplierGenCompanyName = H006C8_A44SupplierGenCompanyName[0];
               A630ToolBoxLastUpdateReceptionistI = H006C8_A630ToolBoxLastUpdateReceptionistI[0];
               n630ToolBoxLastUpdateReceptionistI = H006C8_n630ToolBoxLastUpdateReceptionistI[0];
               /* Using cursor H006C9 */
               pr_default.execute(7, new Object[] {n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio});
               pr_default.close(7);
               AV5Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV5Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
               AV5Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
               AV22SupplierGenId_Data.Add(AV5Combo_DataItem, 0);
               pr_default.readNext(6);
            }
            pr_default.close(6);
            pr_default.close(7);
            Combo_suppliergenid_Selectedvalue_set = ((Guid.Empty==AV21SupplierGenId) ? "" : StringUtil.Trim( AV21SupplierGenId.ToString()));
            ucCombo_suppliergenid.SendProperty(context, sPrefix, false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
         }
         else if ( ( AV48noFilterGen ) && ( StringUtil.StrCmp(AV14ProductServiceGroup, "Supplier") == 0 ) )
         {
            pr_default.dynParam(8, new Object[]{ new Object[]{
                                                 A42SupplierGenId ,
                                                 AV45PreferredGenSuppliers } ,
                                                 new int[]{
                                                 }
            });
            /* Using cursor H006C10 */
            pr_default.execute(8);
            while ( (pr_default.getStatus(8) != 101) )
            {
               A42SupplierGenId = H006C10_A42SupplierGenId[0];
               A44SupplierGenCompanyName = H006C10_A44SupplierGenCompanyName[0];
               AV5Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV5Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
               AV5Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
               AV22SupplierGenId_Data.Add(AV5Combo_DataItem, 0);
               pr_default.readNext(8);
            }
            pr_default.close(8);
            if ( ! AV50isStart )
            {
               AV21SupplierGenId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV21SupplierGenId", AV21SupplierGenId.ToString());
            }
            Combo_suppliergenid_Selectedvalue_set = ((Guid.Empty==AV21SupplierGenId) ? "" : StringUtil.Trim( AV21SupplierGenId.ToString()));
            ucCombo_suppliergenid.SendProperty(context, sPrefix, false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
         }
         AV50isStart = false;
         AssignAttri(sPrefix, false, "AV50isStart", AV50isStart);
      }

      protected void S192( )
      {
         /* 'CHECKREQUIREDFIELDS2' Routine */
         returnInSub = false;
         AV31CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         if ( ( AV51GAMUser.checkrole("Organisation Manager") || AV51GAMUser.checkrole("Root Admin") ) && (Guid.Empty==AV34LocationId) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Location", ""), "", "", "", "", "", "", "", ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17ProductServiceName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Name", ""), "", "", "", "", "", "", "", ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ProductServiceTileName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "App Tile Name", ""), "", "", "", "", "", "", "", ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40ProductServiceClass)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Category", ""), "", "", "", "", "", "", "", ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         /* Using cursor H006C11 */
         pr_default.execute(9, new Object[] {AV34LocationId, AV36OrganisationId, AV17ProductServiceName});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A11OrganisationId = H006C11_A11OrganisationId[0];
            A29LocationId = H006C11_A29LocationId[0];
            A59ProductServiceName = H006C11_A59ProductServiceName[0];
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Service name Already exists", ""), context.GetMessage( "Name", ""), "", "", "", "", "", "", "", ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
            pr_default.readNext(9);
         }
         pr_default.close(9);
      }

      protected void nextLoad( )
      {
      }

      protected void E236C2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_80_6C2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsuppliergenid_Internalname, tblTablemergedsuppliergenid_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucCombo_suppliergenid.SetProperty("Caption", Combo_suppliergenid_Caption);
            ucCombo_suppliergenid.SetProperty("Cls", Combo_suppliergenid_Cls);
            ucCombo_suppliergenid.SetProperty("EmptyItem", Combo_suppliergenid_Emptyitem);
            ucCombo_suppliergenid.SetProperty("IncludeAddNewOption", Combo_suppliergenid_Includeaddnewoption);
            ucCombo_suppliergenid.SetProperty("DropDownOptionsData", AV22SupplierGenId_Data);
            ucCombo_suppliergenid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenid_Internalname, sPrefix+"COMBO_SUPPLIERGENIDContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavNofiltergen_Internalname, context.GetMessage( "no Filter Gen", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavNofiltergen_Internalname, StringUtil.BoolToStr( AV48noFilterGen), "", context.GetMessage( "no Filter Gen", ""), 1, chkavNofiltergen.Enabled, "true", context.GetMessage( "Preferred", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(86, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,86);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_80_6C2e( true) ;
         }
         else
         {
            wb_table2_80_6C2e( false) ;
         }
      }

      protected void wb_table1_63_6C2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsupplieragbid_Internalname, tblTablemergedsupplieragbid_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucCombo_supplieragbid.SetProperty("Caption", Combo_supplieragbid_Caption);
            ucCombo_supplieragbid.SetProperty("Cls", Combo_supplieragbid_Cls);
            ucCombo_supplieragbid.SetProperty("EmptyItem", Combo_supplieragbid_Emptyitem);
            ucCombo_supplieragbid.SetProperty("DropDownOptionsData", AV20SupplierAgbId_Data);
            ucCombo_supplieragbid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_supplieragbid_Internalname, sPrefix+"COMBO_SUPPLIERAGBIDContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavNofilteragb_Internalname, context.GetMessage( "no Filter Agb", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavNofilteragb_Internalname, StringUtil.BoolToStr( AV47noFilterAgb), "", context.GetMessage( "no Filter Agb", ""), 1, chkavNofilteragb.Enabled, "true", context.GetMessage( "Preferred", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(69, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,69);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_63_6C2e( true) ;
         }
         else
         {
            wb_table1_63_6C2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV25WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV25WebSessionKey", AV25WebSessionKey);
         AV12PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV12PreviousStep", AV12PreviousStep);
         AV10GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV10GoingBack", AV10GoingBack);
         AV52IsPopup = (bool)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV52IsPopup", AV52IsPopup);
         AV53FromToolBox_ProductServiceId = (Guid)getParm(obj,4);
         AssignAttri(sPrefix, false, "AV53FromToolBox_ProductServiceId", AV53FromToolBox_ProductServiceId.ToString());
         AV54PageType = (string)getParm(obj,5);
         AssignAttri(sPrefix, false, "AV54PageType", AV54PageType);
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
         PA6C2( ) ;
         WS6C2( ) ;
         WE6C2( ) ;
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
         sCtrlAV25WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV12PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV10GoingBack = (string)((string)getParm(obj,2));
         sCtrlAV52IsPopup = (string)((string)getParm(obj,3));
         sCtrlAV53FromToolBox_ProductServiceId = (string)((string)getParm(obj,4));
         sCtrlAV54PageType = (string)((string)getParm(obj,5));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA6C2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_productservicestep1", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6C2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV25WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV25WebSessionKey", AV25WebSessionKey);
            AV12PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV12PreviousStep", AV12PreviousStep);
            AV10GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV10GoingBack", AV10GoingBack);
            AV52IsPopup = (bool)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV52IsPopup", AV52IsPopup);
            AV53FromToolBox_ProductServiceId = (Guid)getParm(obj,6);
            AssignAttri(sPrefix, false, "AV53FromToolBox_ProductServiceId", AV53FromToolBox_ProductServiceId.ToString());
            AV54PageType = (string)getParm(obj,7);
            AssignAttri(sPrefix, false, "AV54PageType", AV54PageType);
         }
         wcpOAV25WebSessionKey = cgiGet( sPrefix+"wcpOAV25WebSessionKey");
         wcpOAV12PreviousStep = cgiGet( sPrefix+"wcpOAV12PreviousStep");
         wcpOAV10GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV10GoingBack"));
         wcpOAV52IsPopup = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV52IsPopup"));
         wcpOAV53FromToolBox_ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV53FromToolBox_ProductServiceId"));
         wcpOAV54PageType = cgiGet( sPrefix+"wcpOAV54PageType");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV25WebSessionKey, wcpOAV25WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV12PreviousStep, wcpOAV12PreviousStep) != 0 ) || ( AV10GoingBack != wcpOAV10GoingBack ) || ( AV52IsPopup != wcpOAV52IsPopup ) || ( AV53FromToolBox_ProductServiceId != wcpOAV53FromToolBox_ProductServiceId ) || ( StringUtil.StrCmp(AV54PageType, wcpOAV54PageType) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV25WebSessionKey = AV25WebSessionKey;
         wcpOAV12PreviousStep = AV12PreviousStep;
         wcpOAV10GoingBack = AV10GoingBack;
         wcpOAV52IsPopup = AV52IsPopup;
         wcpOAV53FromToolBox_ProductServiceId = AV53FromToolBox_ProductServiceId;
         wcpOAV54PageType = AV54PageType;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV25WebSessionKey = cgiGet( sPrefix+"AV25WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV25WebSessionKey) > 0 )
         {
            AV25WebSessionKey = cgiGet( sCtrlAV25WebSessionKey);
            AssignAttri(sPrefix, false, "AV25WebSessionKey", AV25WebSessionKey);
         }
         else
         {
            AV25WebSessionKey = cgiGet( sPrefix+"AV25WebSessionKey_PARM");
         }
         sCtrlAV12PreviousStep = cgiGet( sPrefix+"AV12PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV12PreviousStep) > 0 )
         {
            AV12PreviousStep = cgiGet( sCtrlAV12PreviousStep);
            AssignAttri(sPrefix, false, "AV12PreviousStep", AV12PreviousStep);
         }
         else
         {
            AV12PreviousStep = cgiGet( sPrefix+"AV12PreviousStep_PARM");
         }
         sCtrlAV10GoingBack = cgiGet( sPrefix+"AV10GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV10GoingBack) > 0 )
         {
            AV10GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV10GoingBack));
            AssignAttri(sPrefix, false, "AV10GoingBack", AV10GoingBack);
         }
         else
         {
            AV10GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV10GoingBack_PARM"));
         }
         sCtrlAV52IsPopup = cgiGet( sPrefix+"AV52IsPopup_CTRL");
         if ( StringUtil.Len( sCtrlAV52IsPopup) > 0 )
         {
            AV52IsPopup = StringUtil.StrToBool( cgiGet( sCtrlAV52IsPopup));
            AssignAttri(sPrefix, false, "AV52IsPopup", AV52IsPopup);
         }
         else
         {
            AV52IsPopup = StringUtil.StrToBool( cgiGet( sPrefix+"AV52IsPopup_PARM"));
         }
         sCtrlAV53FromToolBox_ProductServiceId = cgiGet( sPrefix+"AV53FromToolBox_ProductServiceId_CTRL");
         if ( StringUtil.Len( sCtrlAV53FromToolBox_ProductServiceId) > 0 )
         {
            AV53FromToolBox_ProductServiceId = StringUtil.StrToGuid( cgiGet( sCtrlAV53FromToolBox_ProductServiceId));
            AssignAttri(sPrefix, false, "AV53FromToolBox_ProductServiceId", AV53FromToolBox_ProductServiceId.ToString());
         }
         else
         {
            AV53FromToolBox_ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV53FromToolBox_ProductServiceId_PARM"));
         }
         sCtrlAV54PageType = cgiGet( sPrefix+"AV54PageType_CTRL");
         if ( StringUtil.Len( sCtrlAV54PageType) > 0 )
         {
            AV54PageType = cgiGet( sCtrlAV54PageType);
            AssignAttri(sPrefix, false, "AV54PageType", AV54PageType);
         }
         else
         {
            AV54PageType = cgiGet( sPrefix+"AV54PageType_PARM");
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
         PA6C2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6C2( ) ;
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
         WS6C2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV25WebSessionKey_PARM", AV25WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV25WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV25WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV25WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV12PreviousStep_PARM", AV12PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV12PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV12PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV12PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV10GoingBack_PARM", StringUtil.BoolToStr( AV10GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV10GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV10GoingBack_CTRL", StringUtil.RTrim( sCtrlAV10GoingBack));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV52IsPopup_PARM", StringUtil.BoolToStr( AV52IsPopup));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV52IsPopup)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV52IsPopup_CTRL", StringUtil.RTrim( sCtrlAV52IsPopup));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV53FromToolBox_ProductServiceId_PARM", AV53FromToolBox_ProductServiceId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV53FromToolBox_ProductServiceId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV53FromToolBox_ProductServiceId_CTRL", StringUtil.RTrim( sCtrlAV53FromToolBox_ProductServiceId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV54PageType_PARM", AV54PageType);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV54PageType)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV54PageType_CTRL", StringUtil.RTrim( sCtrlAV54PageType));
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
         WE6C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257218173584", true, true);
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
         context.AddJavascriptSource("wp_productservicestep1.js", "?20257218173591", false, true);
         context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavLocationid.Name = "vLOCATIONID";
         dynavLocationid.WebTags = "";
         cmbavProductserviceclass.Name = "vPRODUCTSERVICECLASS";
         cmbavProductserviceclass.WebTags = "";
         cmbavProductserviceclass.addItem("", context.GetMessage( "Select Category", ""), 0);
         cmbavProductserviceclass.addItem("My Living", context.GetMessage( "My Living", ""), 0);
         cmbavProductserviceclass.addItem("My Care", context.GetMessage( "My Care", ""), 0);
         cmbavProductserviceclass.addItem("My Services", context.GetMessage( "My Services", ""), 0);
         if ( cmbavProductserviceclass.ItemCount > 0 )
         {
         }
         dynavProductservicegroup.Name = "vPRODUCTSERVICEGROUP";
         dynavProductservicegroup.WebTags = "";
         chkavNofilteragb.Name = "vNOFILTERAGB";
         chkavNofilteragb.WebTags = "";
         chkavNofilteragb.Caption = context.GetMessage( "no Filter Agb", "");
         AssignProp(sPrefix, false, chkavNofilteragb_Internalname, "TitleCaption", chkavNofilteragb.Caption, true);
         chkavNofilteragb.CheckedValue = "false";
         chkavNofiltergen.Name = "vNOFILTERGEN";
         chkavNofiltergen.WebTags = "";
         chkavNofiltergen.Caption = context.GetMessage( "no Filter Gen", "");
         AssignProp(sPrefix, false, chkavNofiltergen_Internalname, "TitleCaption", chkavNofiltergen.Caption, true);
         chkavNofiltergen.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynavLocationid_Internalname = sPrefix+"vLOCATIONID";
         divLocationid_cell_Internalname = sPrefix+"LOCATIONID_CELL";
         edtavProductservicename_Internalname = sPrefix+"vPRODUCTSERVICENAME";
         lblProductserviceimagetext_Internalname = sPrefix+"PRODUCTSERVICEIMAGETEXT";
         Imageuploaduc_Internalname = sPrefix+"IMAGEUPLOADUC";
         divUcfilecell_Internalname = sPrefix+"UCFILECELL";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         cmbavProductserviceclass_Internalname = sPrefix+"vPRODUCTSERVICECLASS";
         dynavProductservicegroup_Internalname = sPrefix+"vPRODUCTSERVICEGROUP";
         lblTextblockcombo_supplieragbid_Internalname = sPrefix+"TEXTBLOCKCOMBO_SUPPLIERAGBID";
         Combo_supplieragbid_Internalname = sPrefix+"COMBO_SUPPLIERAGBID";
         chkavNofilteragb_Internalname = sPrefix+"vNOFILTERAGB";
         tblTablemergedsupplieragbid_Internalname = sPrefix+"TABLEMERGEDSUPPLIERAGBID";
         divTablesplittedsupplieragbid_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERAGBID";
         divTablesupplieragb_Internalname = sPrefix+"TABLESUPPLIERAGB";
         lblTextblockcombo_suppliergenid_Internalname = sPrefix+"TEXTBLOCKCOMBO_SUPPLIERGENID";
         Combo_suppliergenid_Internalname = sPrefix+"COMBO_SUPPLIERGENID";
         chkavNofiltergen_Internalname = sPrefix+"vNOFILTERGEN";
         tblTablemergedsuppliergenid_Internalname = sPrefix+"TABLEMERGEDSUPPLIERGENID";
         divTablesplittedsuppliergenid_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERGENID";
         divTablesuppliergen_Internalname = sPrefix+"TABLESUPPLIERGEN";
         divUnnamedtable4_Internalname = sPrefix+"UNNAMEDTABLE4";
         Productservicedescription_Internalname = sPrefix+"PRODUCTSERVICEDESCRIPTION";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavSupplieragbid_Internalname = sPrefix+"vSUPPLIERAGBID";
         edtavSuppliergenid_Internalname = sPrefix+"vSUPPLIERGENID";
         edtavProductserviceid_Internalname = sPrefix+"vPRODUCTSERVICEID";
         edtavProductservicetilename_Internalname = sPrefix+"vPRODUCTSERVICETILENAME";
         edtavProductserviceimagevar_Internalname = sPrefix+"vPRODUCTSERVICEIMAGEVAR";
         edtavUploadedimagevalues_Internalname = sPrefix+"vUPLOADEDIMAGEVALUES";
         edtavFilename_Internalname = sPrefix+"vFILENAME";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         chkavNofiltergen.Caption = context.GetMessage( "no Filter Gen", "");
         chkavNofilteragb.Caption = context.GetMessage( "no Filter Agb", "");
         chkavNofilteragb.Enabled = 1;
         Combo_supplieragbid_Emptyitem = Convert.ToBoolean( 0);
         Combo_supplieragbid_Cls = "ExtendedCombo ExtendedCombo";
         chkavNofiltergen.Enabled = 1;
         Combo_suppliergenid_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergenid_Cls = "ExtendedCombo ExtendedCombo";
         Combo_suppliergenid_Includeaddnewoption = Convert.ToBoolean( -1);
         Btnwizardfirstprevious_Visible = Convert.ToBoolean( -1);
         edtavFilename_Jsonclick = "";
         edtavFilename_Visible = 1;
         edtavUploadedimagevalues_Visible = 1;
         edtavProductserviceimagevar_Visible = 1;
         edtavProductservicetilename_Jsonclick = "";
         edtavProductservicetilename_Visible = 1;
         edtavProductserviceid_Jsonclick = "";
         edtavProductserviceid_Visible = 1;
         edtavSuppliergenid_Jsonclick = "";
         edtavSuppliergenid_Visible = 1;
         edtavSupplieragbid_Jsonclick = "";
         edtavSupplieragbid_Visible = 1;
         Btnwizardnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardnext_Caption = context.GetMessage( "GXM_next", "");
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardfirstprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardfirstprevious_Caption = context.GetMessage( "GX_BtnCancel", "");
         Btnwizardfirstprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardfirstprevious_Tooltiptext = "";
         Productservicedescription_Captionposition = "Left";
         Productservicedescription_Captionstyle = "";
         Productservicedescription_Captionclass = "col-sm-4 AttributeLabel";
         Productservicedescription_Toolbarexpanded = Convert.ToBoolean( -1);
         Productservicedescription_Toolbarcancollapse = Convert.ToBoolean( 0);
         Productservicedescription_Customconfiguration = "myconfig.js";
         Productservicedescription_Customtoolbar = "myToolbar";
         Productservicedescription_Toolbar = "Custom";
         Productservicedescription_Skin = "default";
         Productservicedescription_Height = "250";
         Productservicedescription_Width = "100%";
         Productservicedescription_Enabled = Convert.ToBoolean( 1);
         divTablesuppliergen_Visible = 1;
         divTablesupplieragb_Visible = 1;
         dynavProductservicegroup_Jsonclick = "";
         dynavProductservicegroup.Enabled = 1;
         cmbavProductserviceclass_Jsonclick = "";
         cmbavProductserviceclass.Enabled = 1;
         edtavProductservicename_Jsonclick = "";
         edtavProductservicename_Enabled = 1;
         dynavLocationid_Jsonclick = "";
         dynavLocationid.Enabled = 1;
         dynavLocationid.Visible = 1;
         divLocationid_cell_Class = "col-xs-12";
         divTableattributes_Height = 0;
         Imageuploaduc_Faileduploadmessage = "Upload Failed";
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10GoingBack","fld":"vGOINGBACK"},{"av":"dynavLocationid"},{"av":"AV34LocationId","fld":"vLOCATIONID"},{"av":"dynavProductservicegroup"},{"av":"AV14ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"AV47noFilterAgb","fld":"vNOFILTERAGB"},{"av":"AV48noFilterGen","fld":"vNOFILTERGEN"},{"av":"AV11HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV36OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV44PreferredAgbSuppliers","fld":"vPREFERREDAGBSUPPLIERS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV10GoingBack","fld":"vGOINGBACK"},{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E166C2","iparms":[{"av":"AV53FromToolBox_ProductServiceId","fld":"vFROMTOOLBOX_PRODUCTSERVICEID"},{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV11HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV52IsPopup","fld":"vISPOPUP"},{"av":"AV54PageType","fld":"vPAGETYPE"},{"av":"dynavLocationid"},{"av":"AV34LocationId","fld":"vLOCATIONID"},{"av":"AV17ProductServiceName","fld":"vPRODUCTSERVICENAME"},{"av":"cmbavProductserviceclass"},{"av":"AV40ProductServiceClass","fld":"vPRODUCTSERVICECLASS"},{"av":"AV15ProductServiceId","fld":"vPRODUCTSERVICEID"},{"av":"AV23UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"dynavProductservicegroup"},{"av":"AV14ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"AV25WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV13ProductServiceDescription","fld":"vPRODUCTSERVICEDESCRIPTION"},{"av":"AV21SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV48noFilterGen","fld":"vNOFILTERGEN"},{"av":"AV19SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV47noFilterAgb","fld":"vNOFILTERAGB"},{"av":"AV18ProductServiceTileName","fld":"vPRODUCTSERVICETILENAME"},{"av":"AV37ProductServiceImageVar","fld":"vPRODUCTSERVICEIMAGEVAR"},{"av":"AV56UploadedImageValues","fld":"vUPLOADEDIMAGEVALUES"},{"av":"AV32FileName","fld":"vFILENAME"},{"av":"A59ProductServiceName","fld":"PRODUCTSERVICENAME"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV36OrganisationId","fld":"vORGANISATIONID","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV54PageType","fld":"vPAGETYPE"},{"av":"AV53FromToolBox_ProductServiceId","fld":"vFROMTOOLBOX_PRODUCTSERVICEID"},{"av":"AV52IsPopup","fld":"vISPOPUP"},{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV56UploadedImageValues","fld":"vUPLOADEDIMAGEVALUES"},{"av":"AV19SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV21SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV15ProductServiceId","fld":"vPRODUCTSERVICEID"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E176C2","iparms":[{"av":"AV53FromToolBox_ProductServiceId","fld":"vFROMTOOLBOX_PRODUCTSERVICEID"},{"av":"AV54PageType","fld":"vPAGETYPE"},{"av":"AV52IsPopup","fld":"vISPOPUP"}]}""");
         setEventMetadata("COMBO_SUPPLIERGENID.ONOPTIONCLICKED","""{"handler":"E136C2","iparms":[{"av":"Combo_suppliergenid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_get"},{"av":"AV21SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV36OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"}]""");
         setEventMetadata("COMBO_SUPPLIERGENID.ONOPTIONCLICKED",""","oparms":[{"av":"AV19SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"Combo_suppliergenid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_set"},{"av":"AV21SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV22SupplierGenId_Data","fld":"vSUPPLIERGENID_DATA"},{"av":"Combo_suppliergenid_Includeaddnewoption","ctrl":"COMBO_SUPPLIERGENID","prop":"IncludeAddNewOption"}]}""");
         setEventMetadata("COMBO_SUPPLIERAGBID.ONOPTIONCLICKED","""{"handler":"E126C2","iparms":[{"av":"Combo_supplieragbid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_SUPPLIERAGBID.ONOPTIONCLICKED",""","oparms":[{"av":"AV21SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV19SupplierAgbId","fld":"vSUPPLIERAGBID"}]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E186C2","iparms":[{"av":"AV54PageType","fld":"vPAGETYPE"},{"av":"AV53FromToolBox_ProductServiceId","fld":"vFROMTOOLBOX_PRODUCTSERVICEID"},{"av":"AV52IsPopup","fld":"vISPOPUP"}]}""");
         setEventMetadata("VPRODUCTSERVICEGROUP.CONTROLVALUECHANGED","""{"handler":"E196C2","iparms":[{"av":"dynavProductservicegroup"},{"av":"AV14ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"AV47noFilterAgb","fld":"vNOFILTERAGB"},{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID"},{"av":"AV19SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV44PreferredAgbSuppliers","fld":"vPREFERREDAGBSUPPLIERS","hsh":true},{"av":"AV50isStart","fld":"vISSTART"},{"av":"AV48noFilterGen","fld":"vNOFILTERGEN"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV36OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"},{"av":"AV45PreferredGenSuppliers","fld":"vPREFERREDGENSUPPLIERS"},{"av":"AV21SupplierGenId","fld":"vSUPPLIERGENID"}]""");
         setEventMetadata("VPRODUCTSERVICEGROUP.CONTROLVALUECHANGED",""","oparms":[{"av":"AV47noFilterAgb","fld":"vNOFILTERAGB"},{"av":"AV48noFilterGen","fld":"vNOFILTERGEN"},{"av":"AV21SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV19SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"divTablesupplieragb_Visible","ctrl":"TABLESUPPLIERAGB","prop":"Visible"},{"av":"divTablesuppliergen_Visible","ctrl":"TABLESUPPLIERGEN","prop":"Visible"},{"av":"AV20SupplierAgbId_Data","fld":"vSUPPLIERAGBID_DATA"},{"av":"AV22SupplierGenId_Data","fld":"vSUPPLIERGENID_DATA"},{"av":"Combo_supplieragbid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_set"},{"av":"Combo_suppliergenid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_set"},{"av":"AV50isStart","fld":"vISSTART"}]}""");
         setEventMetadata("VNOFILTERGEN.CONTROLVALUECHANGED","""{"handler":"E206C2","iparms":[{"av":"AV47noFilterAgb","fld":"vNOFILTERAGB"},{"av":"dynavProductservicegroup"},{"av":"AV14ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID"},{"av":"AV19SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV44PreferredAgbSuppliers","fld":"vPREFERREDAGBSUPPLIERS","hsh":true},{"av":"AV50isStart","fld":"vISSTART"},{"av":"AV48noFilterGen","fld":"vNOFILTERGEN"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV36OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"},{"av":"AV45PreferredGenSuppliers","fld":"vPREFERREDGENSUPPLIERS"},{"av":"AV21SupplierGenId","fld":"vSUPPLIERGENID"}]""");
         setEventMetadata("VNOFILTERGEN.CONTROLVALUECHANGED",""","oparms":[{"av":"AV20SupplierAgbId_Data","fld":"vSUPPLIERAGBID_DATA"},{"av":"AV22SupplierGenId_Data","fld":"vSUPPLIERGENID_DATA"},{"av":"Combo_supplieragbid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_set"},{"av":"AV19SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"Combo_suppliergenid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_set"},{"av":"AV21SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV50isStart","fld":"vISSTART"}]}""");
         setEventMetadata("IMAGEUPLOADUC.ONFAILEDUPLOAD","""{"handler":"E116C2","iparms":[{"av":"Imageuploaduc_Faileduploadmessage","ctrl":"IMAGEUPLOADUC","prop":"FailedUploadMessage"}]}""");
         setEventMetadata("VNOFILTERAGB.CONTROLVALUECHANGED","""{"handler":"E216C2","iparms":[{"av":"AV47noFilterAgb","fld":"vNOFILTERAGB"},{"av":"dynavProductservicegroup"},{"av":"AV14ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID"},{"av":"AV19SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV44PreferredAgbSuppliers","fld":"vPREFERREDAGBSUPPLIERS","hsh":true},{"av":"AV50isStart","fld":"vISSTART"},{"av":"AV48noFilterGen","fld":"vNOFILTERGEN"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV36OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"},{"av":"AV45PreferredGenSuppliers","fld":"vPREFERREDGENSUPPLIERS"},{"av":"AV21SupplierGenId","fld":"vSUPPLIERGENID"}]""");
         setEventMetadata("VNOFILTERAGB.CONTROLVALUECHANGED",""","oparms":[{"av":"AV20SupplierAgbId_Data","fld":"vSUPPLIERAGBID_DATA"},{"av":"AV22SupplierGenId_Data","fld":"vSUPPLIERGENID_DATA"},{"av":"Combo_supplieragbid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_set"},{"av":"AV19SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"Combo_suppliergenid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_set"},{"av":"AV21SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV50isStart","fld":"vISSTART"}]}""");
         setEventMetadata("GLOBALEVENTS.REFRESHPREFERREDSUPPLIER","""{"handler":"E226C2","iparms":[{"av":"AV47noFilterAgb","fld":"vNOFILTERAGB"},{"av":"dynavProductservicegroup"},{"av":"AV14ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"},{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID"},{"av":"AV19SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV44PreferredAgbSuppliers","fld":"vPREFERREDAGBSUPPLIERS","hsh":true},{"av":"AV50isStart","fld":"vISSTART"},{"av":"AV48noFilterGen","fld":"vNOFILTERGEN"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV36OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"},{"av":"AV45PreferredGenSuppliers","fld":"vPREFERREDGENSUPPLIERS"},{"av":"AV21SupplierGenId","fld":"vSUPPLIERGENID"}]""");
         setEventMetadata("GLOBALEVENTS.REFRESHPREFERREDSUPPLIER",""","oparms":[{"av":"AV45PreferredGenSuppliers","fld":"vPREFERREDGENSUPPLIERS"},{"av":"AV20SupplierAgbId_Data","fld":"vSUPPLIERAGBID_DATA"},{"av":"AV22SupplierGenId_Data","fld":"vSUPPLIERGENID_DATA"},{"av":"Combo_supplieragbid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_set"},{"av":"AV19SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"Combo_suppliergenid_Selectedvalue_set","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_set"},{"av":"AV21SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV50isStart","fld":"vISSTART"}]}""");
         setEventMetadata("VALIDV_LOCATIONID","""{"handler":"Validv_Locationid","iparms":[]}""");
         setEventMetadata("VALIDV_SUPPLIERAGBID","""{"handler":"Validv_Supplieragbid","iparms":[]}""");
         setEventMetadata("VALIDV_SUPPLIERGENID","""{"handler":"Validv_Suppliergenid","iparms":[]}""");
         setEventMetadata("VALIDV_PRODUCTSERVICEID","""{"handler":"Validv_Productserviceid","iparms":[]}""");
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
         wcpOAV25WebSessionKey = "";
         wcpOAV12PreviousStep = "";
         wcpOAV53FromToolBox_ProductServiceId = Guid.Empty;
         wcpOAV54PageType = "";
         Combo_suppliergenid_Selectedvalue_get = "";
         Combo_supplieragbid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV36OrganisationId = Guid.Empty;
         AV44PreferredAgbSuppliers = new GxSimpleCollection<Guid>();
         AV23UploadedFiles = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV55FilesToUpdate = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV20SupplierAgbId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV22SupplierGenId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV13ProductServiceDescription = "";
         A59ProductServiceName = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A44SupplierGenCompanyName = "";
         A42SupplierGenId = Guid.Empty;
         A51SupplierAgbName = "";
         A49SupplierAgbId = Guid.Empty;
         AV45PreferredGenSuppliers = new GxSimpleCollection<Guid>();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV34LocationId = Guid.Empty;
         AV17ProductServiceName = "";
         lblProductserviceimagetext_Jsonclick = "";
         ucImageuploaduc = new GXUserControl();
         AV40ProductServiceClass = "";
         AV14ProductServiceGroup = "";
         lblTextblockcombo_supplieragbid_Jsonclick = "";
         lblTextblockcombo_suppliergenid_Jsonclick = "";
         ucProductservicedescription = new GXUserControl();
         ucBtnwizardfirstprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         AV19SupplierAgbId = Guid.Empty;
         AV21SupplierGenId = Guid.Empty;
         AV15ProductServiceId = Guid.Empty;
         AV18ProductServiceTileName = "";
         AV37ProductServiceImageVar = "";
         AV56UploadedImageValues = "";
         AV32FileName = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H006C2_A29LocationId = new Guid[] {Guid.Empty} ;
         H006C2_A31LocationName = new string[] {""} ;
         H006C2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         AV57WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV6ComboSelectedValue = "";
         AV49Session = context.GetSession();
         Combo_suppliergenid_Selectedvalue_set = "";
         ucCombo_suppliergenid = new GXUserControl();
         AV26WizardData = new SdtWP_ProductServiceData(context);
         AV24WebSession = context.GetSession();
         AV51GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         H006C3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H006C3_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         H006C3_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         H006C3_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         H006C3_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         H006C3_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         H006C3_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         H006C3_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         H006C3_A29LocationId = new Guid[] {Guid.Empty} ;
         H006C3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H006C3_A44SupplierGenCompanyName = new string[] {""} ;
         A602SG_LocationSupplierOrganisatio = Guid.Empty;
         A603SG_LocationSupplierLocationId = Guid.Empty;
         A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         H006C4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         AV5Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         H006C5_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H006C5_A51SupplierAgbName = new string[] {""} ;
         Combo_supplieragbid_Selectedvalue_set = "";
         ucCombo_supplieragbid = new GXUserControl();
         GXt_objcol_guid1 = new GxSimpleCollection<Guid>();
         H006C6_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H006C6_A51SupplierAgbName = new string[] {""} ;
         H006C7_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H006C7_A51SupplierAgbName = new string[] {""} ;
         H006C8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H006C8_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         H006C8_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         H006C8_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         H006C8_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         H006C8_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         H006C8_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         H006C8_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         H006C8_A29LocationId = new Guid[] {Guid.Empty} ;
         H006C8_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H006C8_A44SupplierGenCompanyName = new string[] {""} ;
         H006C9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H006C10_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H006C10_A44SupplierGenCompanyName = new string[] {""} ;
         H006C11_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H006C11_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H006C11_A29LocationId = new Guid[] {Guid.Empty} ;
         H006C11_A59ProductServiceName = new string[] {""} ;
         sStyleString = "";
         Combo_suppliergenid_Caption = "";
         Combo_supplieragbid_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV25WebSessionKey = "";
         sCtrlAV12PreviousStep = "";
         sCtrlAV10GoingBack = "";
         sCtrlAV52IsPopup = "";
         sCtrlAV53FromToolBox_ProductServiceId = "";
         sCtrlAV54PageType = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_productservicestep1__default(),
            new Object[][] {
                new Object[] {
               H006C2_A29LocationId, H006C2_A31LocationName, H006C2_A11OrganisationId
               }
               , new Object[] {
               H006C3_A11OrganisationId, H006C3_A602SG_LocationSupplierOrganisatio, H006C3_n602SG_LocationSupplierOrganisatio, H006C3_A603SG_LocationSupplierLocationId, H006C3_n603SG_LocationSupplierLocationId, H006C3_A630ToolBoxLastUpdateReceptionistI, H006C3_n630ToolBoxLastUpdateReceptionistI, H006C3_A89ReceptionistId, H006C3_A29LocationId, H006C3_A42SupplierGenId,
               H006C3_A44SupplierGenCompanyName
               }
               , new Object[] {
               H006C4_A11OrganisationId
               }
               , new Object[] {
               H006C5_A49SupplierAgbId, H006C5_A51SupplierAgbName
               }
               , new Object[] {
               H006C6_A49SupplierAgbId, H006C6_A51SupplierAgbName
               }
               , new Object[] {
               H006C7_A49SupplierAgbId, H006C7_A51SupplierAgbName
               }
               , new Object[] {
               H006C8_A11OrganisationId, H006C8_A602SG_LocationSupplierOrganisatio, H006C8_n602SG_LocationSupplierOrganisatio, H006C8_A603SG_LocationSupplierLocationId, H006C8_n603SG_LocationSupplierLocationId, H006C8_A630ToolBoxLastUpdateReceptionistI, H006C8_n630ToolBoxLastUpdateReceptionistI, H006C8_A89ReceptionistId, H006C8_A29LocationId, H006C8_A42SupplierGenId,
               H006C8_A44SupplierGenCompanyName
               }
               , new Object[] {
               H006C9_A11OrganisationId
               }
               , new Object[] {
               H006C10_A42SupplierGenId, H006C10_A44SupplierGenCompanyName
               }
               , new Object[] {
               H006C11_A58ProductServiceId, H006C11_A11OrganisationId, H006C11_A29LocationId, H006C11_A59ProductServiceName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
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
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int divTableattributes_Height ;
      private int edtavProductservicename_Enabled ;
      private int divTablesupplieragb_Visible ;
      private int divTablesuppliergen_Visible ;
      private int edtavSupplieragbid_Visible ;
      private int edtavSuppliergenid_Visible ;
      private int edtavProductserviceid_Visible ;
      private int edtavProductservicetilename_Visible ;
      private int edtavProductserviceimagevar_Visible ;
      private int edtavUploadedimagevalues_Visible ;
      private int edtavFilename_Visible ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private string Combo_suppliergenid_Selectedvalue_get ;
      private string Combo_supplieragbid_Selectedvalue_get ;
      private string Imageuploaduc_Faileduploadmessage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTableattributes_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string divLocationid_cell_Internalname ;
      private string divLocationid_cell_Class ;
      private string dynavLocationid_Internalname ;
      private string TempTags ;
      private string dynavLocationid_Jsonclick ;
      private string edtavProductservicename_Internalname ;
      private string edtavProductservicename_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblProductserviceimagetext_Internalname ;
      private string lblProductserviceimagetext_Jsonclick ;
      private string divUcfilecell_Internalname ;
      private string Imageuploaduc_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string cmbavProductserviceclass_Internalname ;
      private string cmbavProductserviceclass_Jsonclick ;
      private string dynavProductservicegroup_Internalname ;
      private string dynavProductservicegroup_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string divTablesupplieragb_Internalname ;
      private string divTablesplittedsupplieragbid_Internalname ;
      private string lblTextblockcombo_supplieragbid_Internalname ;
      private string lblTextblockcombo_supplieragbid_Jsonclick ;
      private string divTablesuppliergen_Internalname ;
      private string divTablesplittedsuppliergenid_Internalname ;
      private string lblTextblockcombo_suppliergenid_Internalname ;
      private string lblTextblockcombo_suppliergenid_Jsonclick ;
      private string Productservicedescription_Internalname ;
      private string Productservicedescription_Width ;
      private string Productservicedescription_Height ;
      private string Productservicedescription_Skin ;
      private string Productservicedescription_Toolbar ;
      private string Productservicedescription_Customtoolbar ;
      private string Productservicedescription_Customconfiguration ;
      private string Productservicedescription_Captionclass ;
      private string Productservicedescription_Captionstyle ;
      private string Productservicedescription_Captionposition ;
      private string divTableactions_Internalname ;
      private string Btnwizardfirstprevious_Tooltiptext ;
      private string Btnwizardfirstprevious_Beforeiconclass ;
      private string Btnwizardfirstprevious_Caption ;
      private string Btnwizardfirstprevious_Class ;
      private string Btnwizardfirstprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Aftericonclass ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavSupplieragbid_Internalname ;
      private string edtavSupplieragbid_Jsonclick ;
      private string edtavSuppliergenid_Internalname ;
      private string edtavSuppliergenid_Jsonclick ;
      private string edtavProductserviceid_Internalname ;
      private string edtavProductserviceid_Jsonclick ;
      private string edtavProductservicetilename_Internalname ;
      private string AV18ProductServiceTileName ;
      private string edtavProductservicetilename_Jsonclick ;
      private string edtavProductserviceimagevar_Internalname ;
      private string edtavUploadedimagevalues_Internalname ;
      private string edtavFilename_Internalname ;
      private string edtavFilename_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string chkavNofilteragb_Internalname ;
      private string chkavNofiltergen_Internalname ;
      private string Combo_suppliergenid_Selectedvalue_set ;
      private string Combo_suppliergenid_Internalname ;
      private string Combo_supplieragbid_Selectedvalue_set ;
      private string Combo_supplieragbid_Internalname ;
      private string sStyleString ;
      private string tblTablemergedsuppliergenid_Internalname ;
      private string Combo_suppliergenid_Caption ;
      private string Combo_suppliergenid_Cls ;
      private string tblTablemergedsupplieragbid_Internalname ;
      private string Combo_supplieragbid_Caption ;
      private string Combo_supplieragbid_Cls ;
      private string sCtrlAV25WebSessionKey ;
      private string sCtrlAV12PreviousStep ;
      private string sCtrlAV10GoingBack ;
      private string sCtrlAV52IsPopup ;
      private string sCtrlAV53FromToolBox_ProductServiceId ;
      private string sCtrlAV54PageType ;
      private bool AV10GoingBack ;
      private bool AV52IsPopup ;
      private bool wcpOAV10GoingBack ;
      private bool wcpOAV52IsPopup ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11HasValidationErrors ;
      private bool AV31CheckRequiredFieldsResult ;
      private bool AV50isStart ;
      private bool wbLoad ;
      private bool Productservicedescription_Toolbarcancollapse ;
      private bool Productservicedescription_Toolbarexpanded ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV47noFilterAgb ;
      private bool AV48noFilterGen ;
      private bool returnInSub ;
      private bool Btnwizardfirstprevious_Visible ;
      private bool Combo_suppliergenid_Includeaddnewoption ;
      private bool GXt_boolean2 ;
      private bool n602SG_LocationSupplierOrganisatio ;
      private bool n603SG_LocationSupplierLocationId ;
      private bool n630ToolBoxLastUpdateReceptionistI ;
      private bool Combo_suppliergenid_Emptyitem ;
      private bool Combo_supplieragbid_Emptyitem ;
      private bool Productservicedescription_Enabled ;
      private string AV13ProductServiceDescription ;
      private string AV37ProductServiceImageVar ;
      private string AV56UploadedImageValues ;
      private string AV25WebSessionKey ;
      private string AV12PreviousStep ;
      private string AV54PageType ;
      private string wcpOAV25WebSessionKey ;
      private string wcpOAV12PreviousStep ;
      private string wcpOAV54PageType ;
      private string A59ProductServiceName ;
      private string A44SupplierGenCompanyName ;
      private string A51SupplierAgbName ;
      private string AV17ProductServiceName ;
      private string AV40ProductServiceClass ;
      private string AV14ProductServiceGroup ;
      private string AV32FileName ;
      private string AV6ComboSelectedValue ;
      private Guid AV53FromToolBox_ProductServiceId ;
      private Guid wcpOAV53FromToolBox_ProductServiceId ;
      private Guid AV36OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A42SupplierGenId ;
      private Guid A49SupplierAgbId ;
      private Guid AV34LocationId ;
      private Guid AV19SupplierAgbId ;
      private Guid AV21SupplierGenId ;
      private Guid AV15ProductServiceId ;
      private Guid A602SG_LocationSupplierOrganisatio ;
      private Guid A603SG_LocationSupplierLocationId ;
      private Guid A630ToolBoxLastUpdateReceptionistI ;
      private Guid A89ReceptionistId ;
      private IGxSession AV49Session ;
      private IGxSession AV24WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucImageuploaduc ;
      private GXUserControl ucProductservicedescription ;
      private GXUserControl ucBtnwizardfirstprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucCombo_suppliergenid ;
      private GXUserControl ucCombo_supplieragbid ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private bool aP3_IsPopup ;
      private Guid aP4_FromToolBox_ProductServiceId ;
      private string aP5_PageType ;
      private GXCombobox dynavLocationid ;
      private GXCombobox cmbavProductserviceclass ;
      private GXCombobox dynavProductservicegroup ;
      private GXCheckbox chkavNofilteragb ;
      private GXCheckbox chkavNofiltergen ;
      private GxSimpleCollection<Guid> AV44PreferredAgbSuppliers ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV23UploadedFiles ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV55FilesToUpdate ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV20SupplierAgbId_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV22SupplierGenId_Data ;
      private GxSimpleCollection<Guid> AV45PreferredGenSuppliers ;
      private IDataStoreProvider pr_default ;
      private Guid[] H006C2_A29LocationId ;
      private string[] H006C2_A31LocationName ;
      private Guid[] H006C2_A11OrganisationId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV57WWPContext ;
      private SdtWP_ProductServiceData AV26WizardData ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV51GAMUser ;
      private Guid[] H006C3_A11OrganisationId ;
      private Guid[] H006C3_A602SG_LocationSupplierOrganisatio ;
      private bool[] H006C3_n602SG_LocationSupplierOrganisatio ;
      private Guid[] H006C3_A603SG_LocationSupplierLocationId ;
      private bool[] H006C3_n603SG_LocationSupplierLocationId ;
      private Guid[] H006C3_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] H006C3_n630ToolBoxLastUpdateReceptionistI ;
      private Guid[] H006C3_A89ReceptionistId ;
      private Guid[] H006C3_A29LocationId ;
      private Guid[] H006C3_A42SupplierGenId ;
      private string[] H006C3_A44SupplierGenCompanyName ;
      private Guid[] H006C4_A11OrganisationId ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV5Combo_DataItem ;
      private Guid[] H006C5_A49SupplierAgbId ;
      private string[] H006C5_A51SupplierAgbName ;
      private GxSimpleCollection<Guid> GXt_objcol_guid1 ;
      private Guid[] H006C6_A49SupplierAgbId ;
      private string[] H006C6_A51SupplierAgbName ;
      private Guid[] H006C7_A49SupplierAgbId ;
      private string[] H006C7_A51SupplierAgbName ;
      private Guid[] H006C8_A11OrganisationId ;
      private Guid[] H006C8_A602SG_LocationSupplierOrganisatio ;
      private bool[] H006C8_n602SG_LocationSupplierOrganisatio ;
      private Guid[] H006C8_A603SG_LocationSupplierLocationId ;
      private bool[] H006C8_n603SG_LocationSupplierLocationId ;
      private Guid[] H006C8_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] H006C8_n630ToolBoxLastUpdateReceptionistI ;
      private Guid[] H006C8_A89ReceptionistId ;
      private Guid[] H006C8_A29LocationId ;
      private Guid[] H006C8_A42SupplierGenId ;
      private string[] H006C8_A44SupplierGenCompanyName ;
      private Guid[] H006C9_A11OrganisationId ;
      private Guid[] H006C10_A42SupplierGenId ;
      private string[] H006C10_A44SupplierGenCompanyName ;
      private Guid[] H006C11_A58ProductServiceId ;
      private Guid[] H006C11_A11OrganisationId ;
      private Guid[] H006C11_A29LocationId ;
      private string[] H006C11_A59ProductServiceName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_productservicestep1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H006C5( IGxContext context ,
                                             Guid A49SupplierAgbId ,
                                             GxSimpleCollection<Guid> AV44PreferredAgbSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV44PreferredAgbSuppliers, "SupplierAgbId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierAgbName";
         GXv_Object3[0] = scmdbuf;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H006C7( IGxContext context ,
                                             Guid A49SupplierAgbId ,
                                             GxSimpleCollection<Guid> AV44PreferredAgbSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV44PreferredAgbSuppliers, "SupplierAgbId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierAgbName";
         GXv_Object5[0] = scmdbuf;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H006C8( IGxContext context ,
                                             Guid A42SupplierGenId ,
                                             GxSimpleCollection<Guid> AV45PreferredGenSuppliers ,
                                             Guid A11OrganisationId ,
                                             Guid AV36OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[1];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T3.OrganisationId, T1.SG_LocationSupplierOrganisatio AS SG_LocationSupplierOrganisatio, T1.SG_LocationSupplierLocationId AS SG_LocationSupplierLocationId, T2.ToolBoxLastUpdateReceptionistI, T3.ReceptionistId, T3.LocationId, T1.SupplierGenId, T1.SupplierGenCompanyName FROM ((Trn_SupplierGen T1 LEFT JOIN Trn_Location T2 ON T2.LocationId = T1.SG_LocationSupplierLocationId AND T2.OrganisationId = T1.SG_LocationSupplierOrganisatio) LEFT JOIN Trn_Receptionist T3 ON T3.ReceptionistId = T2.ToolBoxLastUpdateReceptionistI AND T3.OrganisationId = T1.SG_LocationSupplierOrganisatio AND T3.LocationId = T1.SG_LocationSupplierLocationId)";
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV45PreferredGenSuppliers, "T1.SupplierGenId IN (", ")")+")");
         AddWhere(sWhereString, "(T3.OrganisationId = :AV36OrganisationId)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenCompanyName";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H006C10( IGxContext context ,
                                              Guid A42SupplierGenId ,
                                              GxSimpleCollection<Guid> AV45PreferredGenSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT SupplierGenId, SupplierGenCompanyName FROM Trn_SupplierGen";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV45PreferredGenSuppliers, "SupplierGenId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierGenCompanyName";
         GXv_Object9[0] = scmdbuf;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_H006C5(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
               case 5 :
                     return conditional_H006C7(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
               case 6 :
                     return conditional_H006C8(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
               case 8 :
                     return conditional_H006C10(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH006C2;
          prmH006C2 = new Object[] {
          };
          Object[] prmH006C3;
          prmH006C3 = new Object[] {
          new ParDef("AV36OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH006C4;
          prmH006C4 = new Object[] {
          new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmH006C6;
          prmH006C6 = new Object[] {
          };
          Object[] prmH006C9;
          prmH006C9 = new Object[] {
          new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmH006C11;
          prmH006C11 = new Object[] {
          new ParDef("AV34LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV36OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV17ProductServiceName",GXType.VarChar,100,0)
          };
          Object[] prmH006C5;
          prmH006C5 = new Object[] {
          };
          Object[] prmH006C7;
          prmH006C7 = new Object[] {
          };
          Object[] prmH006C8;
          prmH006C8 = new Object[] {
          new ParDef("AV36OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH006C10;
          prmH006C10 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H006C2", "SELECT LocationId, LocationName, OrganisationId FROM Trn_Location ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006C2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006C3", "SELECT T3.OrganisationId, T1.SG_LocationSupplierOrganisatio AS SG_LocationSupplierOrganisatio, T1.SG_LocationSupplierLocationId AS SG_LocationSupplierLocationId, T2.ToolBoxLastUpdateReceptionistI, T3.ReceptionistId, T3.LocationId, T1.SupplierGenId, T1.SupplierGenCompanyName FROM ((Trn_SupplierGen T1 LEFT JOIN Trn_Location T2 ON T2.LocationId = T1.SG_LocationSupplierLocationId AND T2.OrganisationId = T1.SG_LocationSupplierOrganisatio) LEFT JOIN Trn_Receptionist T3 ON T3.ReceptionistId = T2.ToolBoxLastUpdateReceptionistI AND T3.OrganisationId = T1.SG_LocationSupplierOrganisatio AND T3.LocationId = T1.SG_LocationSupplierLocationId) WHERE T3.OrganisationId = :AV36OrganisationId ORDER BY T1.SupplierGenCompanyName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006C3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006C4", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :SG_LocationSupplierOrganisatio ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006C4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006C5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006C5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006C6", "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB ORDER BY SupplierAgbName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006C6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006C7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006C7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006C8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006C8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006C9", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :SG_LocationSupplierOrganisatio ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006C9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006C10", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006C10,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006C11", "SELECT ProductServiceId, OrganisationId, LocationId, ProductServiceName FROM Trn_ProductService WHERE (LocationId = :AV34LocationId and OrganisationId = :AV36OrganisationId) AND (ProductServiceName = ( :AV17ProductServiceName)) ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006C11,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((Guid[]) buf[7])[0] = rslt.getGuid(5);
                ((Guid[]) buf[8])[0] = rslt.getGuid(6);
                ((Guid[]) buf[9])[0] = rslt.getGuid(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((Guid[]) buf[7])[0] = rslt.getGuid(5);
                ((Guid[]) buf[8])[0] = rslt.getGuid(6);
                ((Guid[]) buf[9])[0] = rslt.getGuid(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                return;
             case 7 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 8 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 9 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
