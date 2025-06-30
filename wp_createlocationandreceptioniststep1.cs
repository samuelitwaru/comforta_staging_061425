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
   public class wp_createlocationandreceptioniststep1 : GXWebComponent
   {
      public wp_createlocationandreceptioniststep1( )
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

      public wp_createlocationandreceptioniststep1( IGxContext context )
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
                           ref Guid aP3_OrganisationId )
      {
         this.AV6WebSessionKey = aP0_WebSessionKey;
         this.AV8PreviousStep = aP1_PreviousStep;
         this.AV7GoingBack = aP2_GoingBack;
         this.AV41OrganisationId = aP3_OrganisationId;
         ExecuteImpl();
         aP3_OrganisationId=this.AV41OrganisationId;
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
                  AV6WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
                  AV8PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
                  AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
                  AV41OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "AV41OrganisationId", AV41OrganisationId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6WebSessionKey,(string)AV8PreviousStep,(bool)AV7GoingBack,(Guid)AV41OrganisationId});
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
            PA652( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavFilename_Enabled = 0;
               AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
               WS652( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Create Location And Receptionist Step1", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            GXEncryptionTmp = "wp_createlocationandreceptioniststep1.aspx"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack)) + "," + UrlEncode(AV41OrganisationId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createlocationandreceptioniststep1.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV26DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV26DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLOCATIONPHONECODE_DATA", AV32LocationPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLOCATIONPHONECODE_DATA", AV32LocationPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV37UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV37UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILESTOUPDATE", AV42FilesToUpdate);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILESTOUPDATE", AV42FilesToUpdate);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILE", AV43UploadedFile);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILE", AV43UploadedFile);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFAILEDFILE", AV44FailedFile);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFAILEDFILE", AV44FailedFile);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vLOCATIONDESCRIPTION", AV21LocationDescription);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLOCATIONCOUNTRY_DATA", AV25LocationCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLOCATIONCOUNTRY_DATA", AV25LocationCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV41OrganisationId", wcpOAV41OrganisationId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV22CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORGANISATIONID", AV41OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONCOUNTRY_Selectedvalue_get", StringUtil.RTrim( Combo_locationcountry_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_locationphonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"IMAGEUPLOADUC_Faileduploadmessage", StringUtil.RTrim( Imageuploaduc_Faileduploadmessage));
         GxWebStd.gx_hidden_field( context, sPrefix+"IMAGEUPLOADUC_Faileduploadmessage", StringUtil.RTrim( Imageuploaduc_Faileduploadmessage));
      }

      protected void RenderHtmlCloseForm652( )
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
         return "WP_CreateLocationAndReceptionistStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Create Location And Receptionist Step1", "") ;
      }

      protected void WB650( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createlocationandreceptioniststep1.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
               context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
               context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
               context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Location Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLocationname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocationname_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationname_Internalname, AV13LocationName, StringUtil.RTrim( context.localUtil.Format( AV13LocationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLocationname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLocationemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocationemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationemail_Internalname, AV14LocationEmail, StringUtil.RTrim( context.localUtil.Format( AV14LocationEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "johndoe@gmail.com", ""), edtavLocationemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLocationemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPhonelabel_Internalname, context.GetMessage( "Phone", ""), "", "", lblPhonelabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_locationphonecode.SetProperty("Caption", Combo_locationphonecode_Caption);
            ucCombo_locationphonecode.SetProperty("Cls", Combo_locationphonecode_Cls);
            ucCombo_locationphonecode.SetProperty("EmptyItem", Combo_locationphonecode_Emptyitem);
            ucCombo_locationphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV26DDO_TitleSettingsIcons);
            ucCombo_locationphonecode.SetProperty("DropDownOptionsData", AV32LocationPhoneCode_Data);
            ucCombo_locationphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_locationphonecode_Internalname, sPrefix+"COMBO_LOCATIONPHONECODEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocationphonenumber_Internalname, context.GetMessage( "Location Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationphonenumber_Internalname, AV34LocationPhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV34LocationPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationphonenumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLocationphonenumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImageuploaductable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLocationimagetext_Internalname, context.GetMessage( "Images", ""), "", "", lblLocationimagetext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUcfilecell2_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucImageuploaduc.SetProperty("MaxNumberOfFiles", Imageuploaduc_Maxnumberoffiles);
            ucImageuploaduc.SetProperty("MaxFileSize", Imageuploaduc_Maxfilesize);
            ucImageuploaduc.SetProperty("UploadedFiles", AV37UploadedFiles);
            ucImageuploaduc.SetProperty("FilesToEdit", AV42FilesToUpdate);
            ucImageuploaduc.Render(context, "uc_customimageupload", Imageuploaduc_Internalname, sPrefix+"IMAGEUPLOADUCContainer");
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
            GxWebStd.gx_div_start( context, divTableimage1_Internalname, divTableimage1_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblProductserviceimagetext_Internalname, context.GetMessage( "Image", ""), "", "", lblProductserviceimagetext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUcfilecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-5", "start", "top", "", "", "div");
            wb_table1_65_652( true) ;
         }
         else
         {
            wb_table1_65_652( false) ;
         }
         return  ;
      }

      protected void wb_table1_65_652e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Locationdescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Locationdescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucLocationdescription.SetProperty("Width", Locationdescription_Width);
            ucLocationdescription.SetProperty("Height", Locationdescription_Height);
            ucLocationdescription.SetProperty("Attribute", AV21LocationDescription);
            ucLocationdescription.SetProperty("Skin", Locationdescription_Skin);
            ucLocationdescription.SetProperty("Toolbar", Locationdescription_Toolbar);
            ucLocationdescription.SetProperty("CustomToolbar", Locationdescription_Customtoolbar);
            ucLocationdescription.SetProperty("CustomConfiguration", Locationdescription_Customconfiguration);
            ucLocationdescription.SetProperty("ToolbarCanCollapse", Locationdescription_Toolbarcancollapse);
            ucLocationdescription.SetProperty("Color", Locationdescription_Color);
            ucLocationdescription.SetProperty("CaptionClass", Locationdescription_Captionclass);
            ucLocationdescription.SetProperty("CaptionStyle", Locationdescription_Captionstyle);
            ucLocationdescription.SetProperty("CaptionPosition", Locationdescription_Captionposition);
            ucLocationdescription.Render(context, "fckeditor", Locationdescription_Internalname, sPrefix+"LOCATIONDESCRIPTIONContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLocationaddressline1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocationaddressline1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationaddressline1_Internalname, AV19LocationAddressLine1, StringUtil.RTrim( context.localUtil.Format( AV19LocationAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationaddressline1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLocationaddressline1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLocationaddressline2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocationaddressline2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationaddressline2_Internalname, AV20LocationAddressLine2, StringUtil.RTrim( context.localUtil.Format( AV20LocationAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationaddressline2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLocationaddressline2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLocationzipcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocationzipcode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationzipcode_Internalname, AV18LocationZipCode, StringUtil.RTrim( context.localUtil.Format( AV18LocationZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "1234 AB", ""), edtavLocationzipcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLocationzipcode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLocationcity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocationcity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationcity_Internalname, AV17LocationCity, StringUtil.RTrim( context.localUtil.Format( AV17LocationCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationcity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLocationcity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlocationcountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_locationcountry_Internalname, context.GetMessage( "Country", ""), "", "", lblTextblockcombo_locationcountry_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_locationcountry.SetProperty("Caption", Combo_locationcountry_Caption);
            ucCombo_locationcountry.SetProperty("Cls", Combo_locationcountry_Cls);
            ucCombo_locationcountry.SetProperty("EmptyItem", Combo_locationcountry_Emptyitem);
            ucCombo_locationcountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV26DDO_TitleSettingsIcons);
            ucCombo_locationcountry.SetProperty("DropDownOptionsData", AV25LocationCountry_Data);
            ucCombo_locationcountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_locationcountry_Internalname, sPrefix+"COMBO_LOCATIONCOUNTRYContainer");
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
            ucBtnwizardfirstprevious.SetProperty("Caption", Btnwizardfirstprevious_Caption);
            ucBtnwizardfirstprevious.SetProperty("Class", Btnwizardfirstprevious_Class);
            ucBtnwizardfirstprevious.Render(context, "wwp_iconbutton", Btnwizardfirstprevious_Internalname, sPrefix+"BTNWIZARDFIRSTPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardnext.SetProperty("TooltipText", Btnwizardnext_Tooltiptext);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationphonecode_Internalname, AV31LocationPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV31LocationPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavLocationphonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationcountry_Internalname, AV16LocationCountry, StringUtil.RTrim( context.localUtil.Format( AV16LocationCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationcountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavLocationcountry_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationid_Internalname, AV12LocationId.ToString(), AV12LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLocationid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavLocationimagevar_Internalname, AV35LocationImageVar, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", 0, edtavLocationimagevar_Visible, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationphone_Internalname, StringUtil.RTrim( AV15LocationPhone), StringUtil.RTrim( context.localUtil.Format( AV15LocationPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavLocationphone_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START652( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Create Location And Receptionist Step1", ""), 0) ;
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
               STRUP650( ) ;
            }
         }
      }

      protected void WS652( )
      {
         START652( ) ;
         EVT652( ) ;
      }

      protected void EVT652( )
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
                                 STRUP650( ) ;
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
                                 STRUP650( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Imageuploaduc.Onfailedupload */
                                    E11652 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP650( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E12652 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP650( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E13652 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP650( ) ;
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
                                          E14652 ();
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
                                 STRUP650( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E15652 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VLOCATIONZIPCODE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP650( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E16652 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VLOCATIONPHONENUMBER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP650( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E17652 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILENAME.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP650( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E18652 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP650( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E19652 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP650( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavLocationname_Internalname;
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

      protected void WE652( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm652( ) ;
            }
         }
      }

      protected void PA652( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createlocationandreceptioniststep1.aspx")), "wp_createlocationandreceptioniststep1.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createlocationandreceptioniststep1.aspx")))) ;
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
               GX_FocusControl = edtavLocationname_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         RF652( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavFilename_Enabled = 0;
         AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
      }

      protected void RF652( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E13652 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E19652 ();
            WB650( ) ;
         }
      }

      protected void send_integrity_lvl_hashes652( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         edtavFilename_Enabled = 0;
         AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP650( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12652 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV26DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vLOCATIONPHONECODE_DATA"), AV32LocationPhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV37UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILESTOUPDATE"), AV42FilesToUpdate);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILE"), AV43UploadedFile);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFAILEDFILE"), AV44FailedFile);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vLOCATIONCOUNTRY_DATA"), AV25LocationCountry_Data);
            /* Read saved values. */
            AV21LocationDescription = cgiGet( sPrefix+"vLOCATIONDESCRIPTION");
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            wcpOAV41OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV41OrganisationId"));
            Imageuploaduc_Faileduploadmessage = cgiGet( sPrefix+"IMAGEUPLOADUC_Faileduploadmessage");
            /* Read variables values. */
            AV13LocationName = cgiGet( edtavLocationname_Internalname);
            AssignAttri(sPrefix, false, "AV13LocationName", AV13LocationName);
            AV14LocationEmail = cgiGet( edtavLocationemail_Internalname);
            AssignAttri(sPrefix, false, "AV14LocationEmail", AV14LocationEmail);
            AV34LocationPhoneNumber = cgiGet( edtavLocationphonenumber_Internalname);
            AssignAttri(sPrefix, false, "AV34LocationPhoneNumber", AV34LocationPhoneNumber);
            AV36FileName = cgiGet( edtavFilename_Internalname);
            AssignAttri(sPrefix, false, "AV36FileName", AV36FileName);
            AV19LocationAddressLine1 = cgiGet( edtavLocationaddressline1_Internalname);
            AssignAttri(sPrefix, false, "AV19LocationAddressLine1", AV19LocationAddressLine1);
            AV20LocationAddressLine2 = cgiGet( edtavLocationaddressline2_Internalname);
            AssignAttri(sPrefix, false, "AV20LocationAddressLine2", AV20LocationAddressLine2);
            AV18LocationZipCode = cgiGet( edtavLocationzipcode_Internalname);
            AssignAttri(sPrefix, false, "AV18LocationZipCode", AV18LocationZipCode);
            AV17LocationCity = cgiGet( edtavLocationcity_Internalname);
            AssignAttri(sPrefix, false, "AV17LocationCity", AV17LocationCity);
            AV31LocationPhoneCode = cgiGet( edtavLocationphonecode_Internalname);
            AssignAttri(sPrefix, false, "AV31LocationPhoneCode", AV31LocationPhoneCode);
            AV16LocationCountry = cgiGet( edtavLocationcountry_Internalname);
            AssignAttri(sPrefix, false, "AV16LocationCountry", AV16LocationCountry);
            if ( StringUtil.StrCmp(cgiGet( edtavLocationid_Internalname), "") == 0 )
            {
               AV12LocationId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV12LocationId", AV12LocationId.ToString());
            }
            else
            {
               try
               {
                  AV12LocationId = StringUtil.StrToGuid( cgiGet( edtavLocationid_Internalname));
                  AssignAttri(sPrefix, false, "AV12LocationId", AV12LocationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vLOCATIONID");
                  GX_FocusControl = edtavLocationid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV35LocationImageVar = cgiGet( edtavLocationimagevar_Internalname);
            AssignAttri(sPrefix, false, "AV35LocationImageVar", AV35LocationImageVar);
            AV15LocationPhone = cgiGet( edtavLocationphone_Internalname);
            AssignAttri(sPrefix, false, "AV15LocationPhone", AV15LocationPhone);
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
         E12652 ();
         if (returnInSub) return;
      }

      protected void E12652( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV26DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV26DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavLocationcountry_Visible = 0;
         AssignProp(sPrefix, false, edtavLocationcountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationcountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_locationcountry_Htmltemplate = GXt_char2;
         ucCombo_locationcountry.SendProperty(context, sPrefix, false, Combo_locationcountry_Internalname, "HTMLTemplate", Combo_locationcountry_Htmltemplate);
         edtavLocationphonecode_Visible = 0;
         AssignProp(sPrefix, false, edtavLocationphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_locationphonecode_Htmltemplate = GXt_char2;
         ucCombo_locationphonecode.SendProperty(context, sPrefix, false, Combo_locationphonecode_Internalname, "HTMLTemplate", Combo_locationphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOLOCATIONPHONECODE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOLOCATIONCOUNTRY' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S142 ();
         if (returnInSub) return;
         edtavLocationid_Visible = 0;
         AssignProp(sPrefix, false, edtavLocationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationid_Visible), 5, 0), true);
         edtavLocationimagevar_Visible = 0;
         AssignProp(sPrefix, false, edtavLocationimagevar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationimagevar_Visible), 5, 0), true);
         edtavLocationphone_Visible = 0;
         AssignProp(sPrefix, false, edtavLocationphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationphone_Visible), 5, 0), true);
         AV23Trn_Organisation.Load(new prc_getuserorganisationid(context).executeUdp( ));
         AV16LocationCountry = AV23Trn_Organisation.gxTpr_Organisationaddresscountry;
         AssignAttri(sPrefix, false, "AV16LocationCountry", AV16LocationCountry);
         Combo_locationcountry_Selectedtext_set = AV16LocationCountry;
         ucCombo_locationcountry.SendProperty(context, sPrefix, false, Combo_locationcountry_Internalname, "SelectedText_set", Combo_locationcountry_Selectedtext_set);
         Combo_locationcountry_Selectedvalue_set = AV16LocationCountry;
         ucCombo_locationcountry.SendProperty(context, sPrefix, false, Combo_locationcountry_Internalname, "SelectedValue_set", Combo_locationcountry_Selectedvalue_set);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31LocationPhoneCode)) )
         {
            AV30defaultCountryPhoneCode = "+31";
            AV31LocationPhoneCode = "+31";
            AssignAttri(sPrefix, false, "AV31LocationPhoneCode", AV31LocationPhoneCode);
            Combo_locationphonecode_Selectedtext_set = AV30defaultCountryPhoneCode;
            ucCombo_locationphonecode.SendProperty(context, sPrefix, false, Combo_locationphonecode_Internalname, "SelectedText_set", Combo_locationphonecode_Selectedtext_set);
            Combo_locationphonecode_Selectedvalue_set = AV30defaultCountryPhoneCode;
            ucCombo_locationphonecode.SendProperty(context, sPrefix, false, Combo_locationphonecode_Internalname, "SelectedValue_set", Combo_locationphonecode_Selectedvalue_set);
         }
      }

      protected void E13652( )
      {
         /* Refresh Routine */
         returnInSub = false;
         AV7GoingBack = false;
         AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E14652 ();
         if (returnInSub) return;
      }

      protected void E14652( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S162 ();
         if (returnInSub) return;
         if ( AV22CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S172 ();
            if (returnInSub) return;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createlocationandreceptionist.aspx"+UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.BoolToStr(false)) + "," + UrlEncode(AV41OrganisationId.ToString());
            CallWebObject(formatLink("wp_createlocationandreceptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E15652( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         CallWebObject(formatLink("trn_locationww.aspx") );
         context.wjLocDisableFrm = 1;
         context.setWebReturnParms(new Object[] {(Guid)AV41OrganisationId});
         context.setWebReturnParmsMetadata(new Object[] {"AV41OrganisationId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV7GoingBack ) )
         {
            Btnwizardfirstprevious_Visible = false;
            ucBtnwizardfirstprevious.SendProperty(context, sPrefix, false, Btnwizardfirstprevious_Internalname, "Visible", StringUtil.BoolToStr( Btnwizardfirstprevious_Visible));
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV19LocationAddressLine1 = AV11WizardData.gxTpr_Step1.gxTpr_Locationaddressline1;
         AssignAttri(sPrefix, false, "AV19LocationAddressLine1", AV19LocationAddressLine1);
         AV20LocationAddressLine2 = AV11WizardData.gxTpr_Step1.gxTpr_Locationaddressline2;
         AssignAttri(sPrefix, false, "AV20LocationAddressLine2", AV20LocationAddressLine2);
         AV18LocationZipCode = AV11WizardData.gxTpr_Step1.gxTpr_Locationzipcode;
         AssignAttri(sPrefix, false, "AV18LocationZipCode", AV18LocationZipCode);
         AV17LocationCity = AV11WizardData.gxTpr_Step1.gxTpr_Locationcity;
         AssignAttri(sPrefix, false, "AV17LocationCity", AV17LocationCity);
         AV16LocationCountry = AV11WizardData.gxTpr_Step1.gxTpr_Locationcountry;
         AssignAttri(sPrefix, false, "AV16LocationCountry", AV16LocationCountry);
         AV12LocationId = AV11WizardData.gxTpr_Step1.gxTpr_Locationid;
         AssignAttri(sPrefix, false, "AV12LocationId", AV12LocationId.ToString());
         AV13LocationName = AV11WizardData.gxTpr_Step1.gxTpr_Locationname;
         AssignAttri(sPrefix, false, "AV13LocationName", AV13LocationName);
         AV35LocationImageVar = AV11WizardData.gxTpr_Step1.gxTpr_Locationimagevar;
         AssignAttri(sPrefix, false, "AV35LocationImageVar", AV35LocationImageVar);
         AV14LocationEmail = AV11WizardData.gxTpr_Step1.gxTpr_Locationemail;
         AssignAttri(sPrefix, false, "AV14LocationEmail", AV14LocationEmail);
         AV15LocationPhone = AV11WizardData.gxTpr_Step1.gxTpr_Locationphone;
         AssignAttri(sPrefix, false, "AV15LocationPhone", AV15LocationPhone);
         AV21LocationDescription = AV11WizardData.gxTpr_Step1.gxTpr_Locationdescription;
         AssignAttri(sPrefix, false, "AV21LocationDescription", AV21LocationDescription);
         AV36FileName = AV11WizardData.gxTpr_Step1.gxTpr_Filename;
         AssignAttri(sPrefix, false, "AV36FileName", AV36FileName);
         AV34LocationPhoneNumber = AV11WizardData.gxTpr_Step1.gxTpr_Locationphonenumber;
         AssignAttri(sPrefix, false, "AV34LocationPhoneNumber", AV34LocationPhoneNumber);
         AV31LocationPhoneCode = AV11WizardData.gxTpr_Step1.gxTpr_Locationphonecode;
         AssignAttri(sPrefix, false, "AV31LocationPhoneCode", AV31LocationPhoneCode);
         if ( AV42FilesToUpdate.FromJSonString(AV11WizardData.gxTpr_Step1.gxTpr_Locationimagevar, null) )
         {
         }
      }

      protected void S172( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         if ( AV37UploadedFiles.Count > 0 )
         {
            AV35LocationImageVar = AV37UploadedFiles.ToJSonString(false);
            AssignAttri(sPrefix, false, "AV35LocationImageVar", AV35LocationImageVar);
         }
         AV12LocationId = Guid.NewGuid( );
         AssignAttri(sPrefix, false, "AV12LocationId", AV12LocationId.ToString());
         GXt_char2 = AV15LocationPhone;
         new prc_concatenateintlphone(context ).execute(  AV31LocationPhoneCode,  AV34LocationPhoneNumber, out  GXt_char2) ;
         AV15LocationPhone = GXt_char2;
         AssignAttri(sPrefix, false, "AV15LocationPhone", AV15LocationPhone);
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Step1.gxTpr_Locationaddressline1 = AV19LocationAddressLine1;
         AV11WizardData.gxTpr_Step1.gxTpr_Locationaddressline2 = AV20LocationAddressLine2;
         AV11WizardData.gxTpr_Step1.gxTpr_Locationzipcode = AV18LocationZipCode;
         AV11WizardData.gxTpr_Step1.gxTpr_Locationcity = AV17LocationCity;
         AV11WizardData.gxTpr_Step1.gxTpr_Locationcountry = AV16LocationCountry;
         AV11WizardData.gxTpr_Step1.gxTpr_Locationid = AV12LocationId;
         AV11WizardData.gxTpr_Step1.gxTpr_Locationname = AV13LocationName;
         AV11WizardData.gxTpr_Step1.gxTpr_Locationimagevar = AV35LocationImageVar;
         AV11WizardData.gxTpr_Step1.gxTpr_Locationemail = AV14LocationEmail;
         AV11WizardData.gxTpr_Step1.gxTpr_Locationphone = AV15LocationPhone;
         AV11WizardData.gxTpr_Step1.gxTpr_Locationdescription = AV21LocationDescription;
         AV11WizardData.gxTpr_Step1.gxTpr_Filename = AV36FileName;
         AV11WizardData.gxTpr_Step1.gxTpr_Locationphonenumber = AV34LocationPhoneNumber;
         AV11WizardData.gxTpr_Step1.gxTpr_Locationphonecode = AV31LocationPhoneCode;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S162( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV22CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13LocationName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavLocationname_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19LocationAddressLine1)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Address Line 1", ""), "", "", "", "", "", "", "", ""),  "error",  edtavLocationaddressline1_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18LocationZipCode)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Zip Code", ""), "", "", "", "", "", "", "", ""),  "error",  edtavLocationzipcode_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17LocationCity)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "City", ""), "", "", "", "", "", "", "", ""),  "error",  edtavLocationcity_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14LocationEmail)) && ! GxRegex.IsMatch(AV14LocationEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
      }

      protected void S142( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divTableimage1_Visible = (((1==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divTableimage1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableimage1_Visible), 5, 0), true);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOLOCATIONCOUNTRY' Routine */
         returnInSub = false;
         AV46GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV45GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV45GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV46GXV2 <= AV45GXV1.Count )
         {
            AV29LocationCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV45GXV1.Item(AV46GXV2));
            AV28Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV28Combo_DataItem.gxTpr_Id = AV29LocationCountry_DPItem.gxTpr_Countryname;
            AV24ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV24ComboTitles.Add(AV29LocationCountry_DPItem.gxTpr_Countryname, 0);
            AV24ComboTitles.Add(AV29LocationCountry_DPItem.gxTpr_Countryflag, 0);
            AV28Combo_DataItem.gxTpr_Title = AV24ComboTitles.ToJSonString(false);
            AV25LocationCountry_Data.Add(AV28Combo_DataItem, 0);
            AV46GXV2 = (int)(AV46GXV2+1);
         }
         AV25LocationCountry_Data.Sort("Title");
         Combo_locationcountry_Selectedvalue_set = AV16LocationCountry;
         ucCombo_locationcountry.SendProperty(context, sPrefix, false, Combo_locationcountry_Internalname, "SelectedValue_set", Combo_locationcountry_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOLOCATIONPHONECODE' Routine */
         returnInSub = false;
         AV48GXV4 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV47GXV3;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV47GXV3 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV48GXV4 <= AV47GXV3.Count )
         {
            AV33LocationPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV47GXV3.Item(AV48GXV4));
            AV28Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV28Combo_DataItem.gxTpr_Id = AV33LocationPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV24ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV24ComboTitles.Add(AV33LocationPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV24ComboTitles.Add(AV33LocationPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV28Combo_DataItem.gxTpr_Title = AV24ComboTitles.ToJSonString(false);
            AV32LocationPhoneCode_Data.Add(AV28Combo_DataItem, 0);
            AV48GXV4 = (int)(AV48GXV4+1);
         }
         AV32LocationPhoneCode_Data.Sort("Title");
         Combo_locationphonecode_Selectedvalue_set = AV31LocationPhoneCode;
         ucCombo_locationphonecode.SendProperty(context, sPrefix, false, Combo_locationphonecode_Internalname, "SelectedValue_set", Combo_locationphonecode_Selectedvalue_set);
      }

      protected void E16652( )
      {
         /* Locationzipcode_Controlvaluechanged Routine */
         returnInSub = false;
         AV18LocationZipCode = StringUtil.Upper( AV18LocationZipCode);
         AssignAttri(sPrefix, false, "AV18LocationZipCode", AV18LocationZipCode);
         if ( ! GxRegex.IsMatch(AV18LocationZipCode,context.GetMessage( "^\\d{4}\\s?[A-Z]{2}$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18LocationZipCode)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Zip Code is incorrect", ""),  "error",  edtavLocationzipcode_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E17652( )
      {
         /* Locationphonenumber_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV34LocationPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV34LocationPhoneNumber)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Phone contains 9 digits", ""),  "error",  edtavLocationphonenumber_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E18652( )
      {
         /* Filename_Controlvaluechanged Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36FileName)) )
         {
            this.executeUsercontrolMethod(sPrefix, false, "USERCONTROL1Container", "Clear", "", new Object[] {});
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void E11652( )
      {
         /* Imageuploaduc_Onfailedupload Routine */
         returnInSub = false;
         GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  Imageuploaduc_Faileduploadmessage,  "error",  "",  "true",  ""));
      }

      protected void nextLoad( )
      {
      }

      protected void E19652( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_65_652( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedusercontrol1_Internalname, tblTablemergedusercontrol1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucUsercontrol1.SetProperty("AutoUpload", Usercontrol1_Autoupload);
            ucUsercontrol1.SetProperty("HideAdditionalButtons", Usercontrol1_Hideadditionalbuttons);
            ucUsercontrol1.SetProperty("TooltipText", Usercontrol1_Tooltiptext);
            ucUsercontrol1.SetProperty("EnableUploadedFileCanceling", Usercontrol1_Enableuploadedfilecanceling);
            ucUsercontrol1.SetProperty("DisableImageResize", Usercontrol1_Disableimageresize);
            ucUsercontrol1.SetProperty("MaxFileSize", Usercontrol1_Maxfilesize);
            ucUsercontrol1.SetProperty("MaxNumberOfFiles", Usercontrol1_Maxnumberoffiles);
            ucUsercontrol1.SetProperty("AutoDisableAddingFiles", Usercontrol1_Autodisableaddingfiles);
            ucUsercontrol1.SetProperty("AcceptedFileTypes", Usercontrol1_Acceptedfiletypes);
            ucUsercontrol1.SetProperty("UploadedFiles", AV43UploadedFile);
            ucUsercontrol1.SetProperty("FailedFiles", AV44FailedFile);
            ucUsercontrol1.Render(context, "fileupload", Usercontrol1_Internalname, sPrefix+"USERCONTROL1Container");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilename_Internalname, context.GetMessage( "File Name", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilename_Internalname, AV36FileName, StringUtil.RTrim( context.localUtil.Format( AV36FileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilename_Jsonclick, 0, "Attribute", "", "", "", "", edtavFilename_Visible, edtavFilename_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUseractiondelete_Internalname, context.GetMessage( "<i class=\"fas fa-trash-can\"></i>", ""), "", "", lblUseractiondelete_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e20651_client"+"'", "", "TextBlock", 7, "", lblUseractiondelete_Visible, 1, 0, 1, "HLP_WP_CreateLocationAndReceptionistStep1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_65_652e( true) ;
         }
         else
         {
            wb_table1_65_652e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         AV8PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         AV7GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         AV41OrganisationId = (Guid)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV41OrganisationId", AV41OrganisationId.ToString());
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
         PA652( ) ;
         WS652( ) ;
         WE652( ) ;
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
         sCtrlAV6WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV8PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV7GoingBack = (string)((string)getParm(obj,2));
         sCtrlAV41OrganisationId = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA652( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createlocationandreceptioniststep1", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA652( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
            AV8PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
            AV7GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
            AV41OrganisationId = (Guid)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV41OrganisationId", AV41OrganisationId.ToString());
         }
         wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
         wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
         wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
         wcpOAV41OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV41OrganisationId"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6WebSessionKey, wcpOAV6WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV8PreviousStep, wcpOAV8PreviousStep) != 0 ) || ( AV7GoingBack != wcpOAV7GoingBack ) || ( AV41OrganisationId != wcpOAV41OrganisationId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6WebSessionKey = AV6WebSessionKey;
         wcpOAV8PreviousStep = AV8PreviousStep;
         wcpOAV7GoingBack = AV7GoingBack;
         wcpOAV41OrganisationId = AV41OrganisationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV6WebSessionKey) > 0 )
         {
            AV6WebSessionKey = cgiGet( sCtrlAV6WebSessionKey);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         }
         else
         {
            AV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_PARM");
         }
         sCtrlAV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV8PreviousStep) > 0 )
         {
            AV8PreviousStep = cgiGet( sCtrlAV8PreviousStep);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         }
         else
         {
            AV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_PARM");
         }
         sCtrlAV7GoingBack = cgiGet( sPrefix+"AV7GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV7GoingBack) > 0 )
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV7GoingBack));
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         else
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV7GoingBack_PARM"));
         }
         sCtrlAV41OrganisationId = cgiGet( sPrefix+"AV41OrganisationId_CTRL");
         if ( StringUtil.Len( sCtrlAV41OrganisationId) > 0 )
         {
            AV41OrganisationId = StringUtil.StrToGuid( cgiGet( sCtrlAV41OrganisationId));
            AssignAttri(sPrefix, false, "AV41OrganisationId", AV41OrganisationId.ToString());
         }
         else
         {
            AV41OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV41OrganisationId_PARM"));
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
         PA652( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS652( ) ;
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
         WS652( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_PARM", AV6WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV6WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_PARM", AV8PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV8PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_PARM", StringUtil.BoolToStr( AV7GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_CTRL", StringUtil.RTrim( sCtrlAV7GoingBack));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV41OrganisationId_PARM", AV41OrganisationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV41OrganisationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV41OrganisationId_CTRL", StringUtil.RTrim( sCtrlAV41OrganisationId));
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
         WE652( ) ;
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
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309364191", true, true);
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
         context.AddJavascriptSource("wp_createlocationandreceptioniststep1.js", "?20256309364192", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavLocationname_Internalname = sPrefix+"vLOCATIONNAME";
         edtavLocationemail_Internalname = sPrefix+"vLOCATIONEMAIL";
         lblPhonelabel_Internalname = sPrefix+"PHONELABEL";
         Combo_locationphonecode_Internalname = sPrefix+"COMBO_LOCATIONPHONECODE";
         divUnnamedtable7_Internalname = sPrefix+"UNNAMEDTABLE7";
         edtavLocationphonenumber_Internalname = sPrefix+"vLOCATIONPHONENUMBER";
         divUnnamedtable8_Internalname = sPrefix+"UNNAMEDTABLE8";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         lblLocationimagetext_Internalname = sPrefix+"LOCATIONIMAGETEXT";
         Imageuploaduc_Internalname = sPrefix+"IMAGEUPLOADUC";
         divUcfilecell2_Internalname = sPrefix+"UCFILECELL2";
         divImageuploaductable_Internalname = sPrefix+"IMAGEUPLOADUCTABLE";
         lblProductserviceimagetext_Internalname = sPrefix+"PRODUCTSERVICEIMAGETEXT";
         Usercontrol1_Internalname = sPrefix+"USERCONTROL1";
         edtavFilename_Internalname = sPrefix+"vFILENAME";
         lblUseractiondelete_Internalname = sPrefix+"USERACTIONDELETE";
         tblTablemergedusercontrol1_Internalname = sPrefix+"TABLEMERGEDUSERCONTROL1";
         divUcfilecell_Internalname = sPrefix+"UCFILECELL";
         divTableimage1_Internalname = sPrefix+"TABLEIMAGE1";
         Locationdescription_Internalname = sPrefix+"LOCATIONDESCRIPTION";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         edtavLocationaddressline1_Internalname = sPrefix+"vLOCATIONADDRESSLINE1";
         edtavLocationaddressline2_Internalname = sPrefix+"vLOCATIONADDRESSLINE2";
         edtavLocationzipcode_Internalname = sPrefix+"vLOCATIONZIPCODE";
         edtavLocationcity_Internalname = sPrefix+"vLOCATIONCITY";
         lblTextblockcombo_locationcountry_Internalname = sPrefix+"TEXTBLOCKCOMBO_LOCATIONCOUNTRY";
         Combo_locationcountry_Internalname = sPrefix+"COMBO_LOCATIONCOUNTRY";
         divTablesplittedlocationcountry_Internalname = sPrefix+"TABLESPLITTEDLOCATIONCOUNTRY";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = sPrefix+"UNNAMEDGROUP4";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavLocationphonecode_Internalname = sPrefix+"vLOCATIONPHONECODE";
         edtavLocationcountry_Internalname = sPrefix+"vLOCATIONCOUNTRY";
         edtavLocationid_Internalname = sPrefix+"vLOCATIONID";
         edtavLocationimagevar_Internalname = sPrefix+"vLOCATIONIMAGEVAR";
         edtavLocationphone_Internalname = sPrefix+"vLOCATIONPHONE";
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
         lblUseractiondelete_Visible = 1;
         edtavFilename_Jsonclick = "";
         edtavFilename_Enabled = 1;
         edtavFilename_Visible = 1;
         Usercontrol1_Acceptedfiletypes = "image";
         Usercontrol1_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Usercontrol1_Maxnumberoffiles = 1;
         Usercontrol1_Maxfilesize = 134217728;
         Usercontrol1_Disableimageresize = Convert.ToBoolean( 0);
         Usercontrol1_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Usercontrol1_Tooltiptext = "";
         Usercontrol1_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Usercontrol1_Autoupload = Convert.ToBoolean( -1);
         Btnwizardfirstprevious_Visible = Convert.ToBoolean( -1);
         Combo_locationphonecode_Htmltemplate = "";
         Combo_locationcountry_Htmltemplate = "";
         edtavLocationphone_Jsonclick = "";
         edtavLocationphone_Visible = 1;
         edtavLocationimagevar_Visible = 1;
         edtavLocationid_Jsonclick = "";
         edtavLocationid_Visible = 1;
         edtavLocationcountry_Jsonclick = "";
         edtavLocationcountry_Visible = 1;
         edtavLocationphonecode_Jsonclick = "";
         edtavLocationphonecode_Visible = 1;
         Btnwizardnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardnext_Caption = context.GetMessage( "GXM_next", "");
         Btnwizardnext_Tooltiptext = "";
         Btnwizardfirstprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardfirstprevious_Caption = context.GetMessage( "GX_BtnCancel", "");
         Btnwizardfirstprevious_Tooltiptext = "";
         Combo_locationcountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_locationcountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_locationcountry_Caption = "";
         edtavLocationcity_Jsonclick = "";
         edtavLocationcity_Enabled = 1;
         edtavLocationzipcode_Jsonclick = "";
         edtavLocationzipcode_Enabled = 1;
         edtavLocationaddressline2_Jsonclick = "";
         edtavLocationaddressline2_Enabled = 1;
         edtavLocationaddressline1_Jsonclick = "";
         edtavLocationaddressline1_Enabled = 1;
         Locationdescription_Captionposition = "Left";
         Locationdescription_Captionstyle = "";
         Locationdescription_Captionclass = "col-sm-4 AttributeLabel";
         Locationdescription_Color = (int)(0xC0C0C0);
         Locationdescription_Toolbarcancollapse = Convert.ToBoolean( 0);
         Locationdescription_Customconfiguration = "myconfig.js";
         Locationdescription_Customtoolbar = "myToolbar";
         Locationdescription_Toolbar = "Custom";
         Locationdescription_Skin = "default";
         Locationdescription_Height = "250";
         Locationdescription_Width = "100%";
         Locationdescription_Enabled = Convert.ToBoolean( 1);
         divTableimage1_Visible = 1;
         Imageuploaduc_Maxfilesize = "10";
         Imageuploaduc_Maxnumberoffiles = "6";
         edtavLocationphonenumber_Jsonclick = "";
         edtavLocationphonenumber_Enabled = 1;
         Combo_locationphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_locationphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_locationphonecode_Caption = "";
         edtavLocationemail_Jsonclick = "";
         edtavLocationemail_Enabled = 1;
         edtavLocationname_Jsonclick = "";
         edtavLocationname_Enabled = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7GoingBack","fld":"vGOINGBACK"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV7GoingBack","fld":"vGOINGBACK"},{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E14652","iparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV41OrganisationId","fld":"vORGANISATIONID"},{"av":"AV13LocationName","fld":"vLOCATIONNAME"},{"av":"AV19LocationAddressLine1","fld":"vLOCATIONADDRESSLINE1"},{"av":"AV18LocationZipCode","fld":"vLOCATIONZIPCODE"},{"av":"AV17LocationCity","fld":"vLOCATIONCITY"},{"av":"AV14LocationEmail","fld":"vLOCATIONEMAIL"},{"av":"AV37UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV31LocationPhoneCode","fld":"vLOCATIONPHONECODE"},{"av":"AV34LocationPhoneNumber","fld":"vLOCATIONPHONENUMBER"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV20LocationAddressLine2","fld":"vLOCATIONADDRESSLINE2"},{"av":"AV16LocationCountry","fld":"vLOCATIONCOUNTRY"},{"av":"AV35LocationImageVar","fld":"vLOCATIONIMAGEVAR"},{"av":"AV21LocationDescription","fld":"vLOCATIONDESCRIPTION"},{"av":"AV36FileName","fld":"vFILENAME"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV41OrganisationId","fld":"vORGANISATIONID"},{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV35LocationImageVar","fld":"vLOCATIONIMAGEVAR"},{"av":"AV12LocationId","fld":"vLOCATIONID"},{"av":"AV15LocationPhone","fld":"vLOCATIONPHONE"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E15652","iparms":[{"av":"AV41OrganisationId","fld":"vORGANISATIONID"}]}""");
         setEventMetadata("'DOUSERACTIONDELETE'","""{"handler":"E20651","iparms":[]}""");
         setEventMetadata("VLOCATIONZIPCODE.CONTROLVALUECHANGED","""{"handler":"E16652","iparms":[{"av":"AV18LocationZipCode","fld":"vLOCATIONZIPCODE"}]""");
         setEventMetadata("VLOCATIONZIPCODE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV18LocationZipCode","fld":"vLOCATIONZIPCODE"},{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VLOCATIONPHONENUMBER.CONTROLVALUECHANGED","""{"handler":"E17652","iparms":[{"av":"AV34LocationPhoneNumber","fld":"vLOCATIONPHONENUMBER"}]""");
         setEventMetadata("VLOCATIONPHONENUMBER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VFILENAME.CONTROLVALUECHANGED","""{"handler":"E18652","iparms":[{"av":"AV36FileName","fld":"vFILENAME"}]}""");
         setEventMetadata("IMAGEUPLOADUC.ONFAILEDUPLOAD","""{"handler":"E11652","iparms":[{"av":"Imageuploaduc_Faileduploadmessage","ctrl":"IMAGEUPLOADUC","prop":"FailedUploadMessage"}]}""");
         setEventMetadata("VALIDV_LOCATIONEMAIL","""{"handler":"Validv_Locationemail","iparms":[]}""");
         setEventMetadata("VALIDV_LOCATIONID","""{"handler":"Validv_Locationid","iparms":[]}""");
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         wcpOAV6WebSessionKey = "";
         wcpOAV8PreviousStep = "";
         wcpOAV41OrganisationId = Guid.Empty;
         Combo_locationcountry_Selectedvalue_get = "";
         Combo_locationphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV26DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV32LocationPhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV37UploadedFiles = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV42FilesToUpdate = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV43UploadedFile = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV44FailedFile = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV21LocationDescription = "";
         AV25LocationCountry_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV13LocationName = "";
         AV14LocationEmail = "";
         lblPhonelabel_Jsonclick = "";
         ucCombo_locationphonecode = new GXUserControl();
         AV34LocationPhoneNumber = "";
         lblLocationimagetext_Jsonclick = "";
         ucImageuploaduc = new GXUserControl();
         lblProductserviceimagetext_Jsonclick = "";
         ucLocationdescription = new GXUserControl();
         AV19LocationAddressLine1 = "";
         AV20LocationAddressLine2 = "";
         AV18LocationZipCode = "";
         AV17LocationCity = "";
         lblTextblockcombo_locationcountry_Jsonclick = "";
         ucCombo_locationcountry = new GXUserControl();
         ucBtnwizardfirstprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         AV31LocationPhoneCode = "";
         AV16LocationCountry = "";
         AV12LocationId = Guid.Empty;
         AV35LocationImageVar = "";
         AV15LocationPhone = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV36FileName = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV23Trn_Organisation = new SdtTrn_Organisation(context);
         Combo_locationcountry_Selectedtext_set = "";
         Combo_locationcountry_Selectedvalue_set = "";
         AV30defaultCountryPhoneCode = "";
         Combo_locationphonecode_Selectedtext_set = "";
         Combo_locationphonecode_Selectedvalue_set = "";
         AV11WizardData = new SdtWP_CreateLocationAndReceptionistData(context);
         AV5WebSession = context.GetSession();
         GXt_char2 = "";
         AV45GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV29LocationCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV28Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV24ComboTitles = new GxSimpleCollection<string>();
         AV47GXV3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV33LocationPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         sStyleString = "";
         ucUsercontrol1 = new GXUserControl();
         lblUseractiondelete_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         sCtrlAV41OrganisationId = "";
         /* GeneXus formulas. */
         edtavFilename_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavFilename_Enabled ;
      private int edtavLocationname_Enabled ;
      private int edtavLocationemail_Enabled ;
      private int edtavLocationphonenumber_Enabled ;
      private int divTableimage1_Visible ;
      private int Locationdescription_Color ;
      private int edtavLocationaddressline1_Enabled ;
      private int edtavLocationaddressline2_Enabled ;
      private int edtavLocationzipcode_Enabled ;
      private int edtavLocationcity_Enabled ;
      private int edtavLocationphonecode_Visible ;
      private int edtavLocationcountry_Visible ;
      private int edtavLocationid_Visible ;
      private int edtavLocationimagevar_Visible ;
      private int edtavLocationphone_Visible ;
      private int AV46GXV2 ;
      private int AV48GXV4 ;
      private int Usercontrol1_Maxfilesize ;
      private int Usercontrol1_Maxnumberoffiles ;
      private int edtavFilename_Visible ;
      private int lblUseractiondelete_Visible ;
      private int idxLst ;
      private string Combo_locationcountry_Selectedvalue_get ;
      private string Combo_locationphonecode_Selectedvalue_get ;
      private string Imageuploaduc_Faileduploadmessage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavFilename_Internalname ;
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
      private string divTableattributes_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtavLocationname_Internalname ;
      private string TempTags ;
      private string edtavLocationname_Jsonclick ;
      private string edtavLocationemail_Internalname ;
      private string edtavLocationemail_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblPhonelabel_Internalname ;
      private string lblPhonelabel_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string divUnnamedtable7_Internalname ;
      private string Combo_locationphonecode_Caption ;
      private string Combo_locationphonecode_Cls ;
      private string Combo_locationphonecode_Internalname ;
      private string divUnnamedtable8_Internalname ;
      private string edtavLocationphonenumber_Internalname ;
      private string edtavLocationphonenumber_Jsonclick ;
      private string divImageuploaductable_Internalname ;
      private string lblLocationimagetext_Internalname ;
      private string lblLocationimagetext_Jsonclick ;
      private string divUcfilecell2_Internalname ;
      private string Imageuploaduc_Maxnumberoffiles ;
      private string Imageuploaduc_Maxfilesize ;
      private string Imageuploaduc_Internalname ;
      private string divTableimage1_Internalname ;
      private string lblProductserviceimagetext_Internalname ;
      private string lblProductserviceimagetext_Jsonclick ;
      private string divUcfilecell_Internalname ;
      private string Locationdescription_Internalname ;
      private string Locationdescription_Width ;
      private string Locationdescription_Height ;
      private string Locationdescription_Skin ;
      private string Locationdescription_Toolbar ;
      private string Locationdescription_Customtoolbar ;
      private string Locationdescription_Customconfiguration ;
      private string Locationdescription_Captionclass ;
      private string Locationdescription_Captionstyle ;
      private string Locationdescription_Captionposition ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtavLocationaddressline1_Internalname ;
      private string edtavLocationaddressline1_Jsonclick ;
      private string edtavLocationaddressline2_Internalname ;
      private string edtavLocationaddressline2_Jsonclick ;
      private string edtavLocationzipcode_Internalname ;
      private string edtavLocationzipcode_Jsonclick ;
      private string edtavLocationcity_Internalname ;
      private string edtavLocationcity_Jsonclick ;
      private string divTablesplittedlocationcountry_Internalname ;
      private string lblTextblockcombo_locationcountry_Internalname ;
      private string lblTextblockcombo_locationcountry_Jsonclick ;
      private string Combo_locationcountry_Caption ;
      private string Combo_locationcountry_Cls ;
      private string Combo_locationcountry_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardfirstprevious_Tooltiptext ;
      private string Btnwizardfirstprevious_Caption ;
      private string Btnwizardfirstprevious_Class ;
      private string Btnwizardfirstprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavLocationphonecode_Internalname ;
      private string edtavLocationphonecode_Jsonclick ;
      private string edtavLocationcountry_Internalname ;
      private string edtavLocationcountry_Jsonclick ;
      private string edtavLocationid_Internalname ;
      private string edtavLocationid_Jsonclick ;
      private string edtavLocationimagevar_Internalname ;
      private string edtavLocationphone_Internalname ;
      private string AV15LocationPhone ;
      private string edtavLocationphone_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Combo_locationcountry_Htmltemplate ;
      private string Combo_locationphonecode_Htmltemplate ;
      private string Combo_locationcountry_Selectedtext_set ;
      private string Combo_locationcountry_Selectedvalue_set ;
      private string Combo_locationphonecode_Selectedtext_set ;
      private string Combo_locationphonecode_Selectedvalue_set ;
      private string GXt_char2 ;
      private string sStyleString ;
      private string tblTablemergedusercontrol1_Internalname ;
      private string Usercontrol1_Tooltiptext ;
      private string Usercontrol1_Acceptedfiletypes ;
      private string Usercontrol1_Internalname ;
      private string edtavFilename_Jsonclick ;
      private string lblUseractiondelete_Internalname ;
      private string lblUseractiondelete_Jsonclick ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private string sCtrlAV41OrganisationId ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool AV22CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Combo_locationphonecode_Emptyitem ;
      private bool Locationdescription_Toolbarcancollapse ;
      private bool Combo_locationcountry_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool Btnwizardfirstprevious_Visible ;
      private bool Usercontrol1_Autoupload ;
      private bool Usercontrol1_Hideadditionalbuttons ;
      private bool Usercontrol1_Enableuploadedfilecanceling ;
      private bool Usercontrol1_Disableimageresize ;
      private bool Usercontrol1_Autodisableaddingfiles ;
      private bool Locationdescription_Enabled ;
      private string AV21LocationDescription ;
      private string AV35LocationImageVar ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV13LocationName ;
      private string AV14LocationEmail ;
      private string AV34LocationPhoneNumber ;
      private string AV19LocationAddressLine1 ;
      private string AV20LocationAddressLine2 ;
      private string AV18LocationZipCode ;
      private string AV17LocationCity ;
      private string AV31LocationPhoneCode ;
      private string AV16LocationCountry ;
      private string AV36FileName ;
      private string AV30defaultCountryPhoneCode ;
      private Guid AV41OrganisationId ;
      private Guid wcpOAV41OrganisationId ;
      private Guid AV12LocationId ;
      private IGxSession AV5WebSession ;
      private GXUserControl ucCombo_locationphonecode ;
      private GXUserControl ucImageuploaduc ;
      private GXUserControl ucLocationdescription ;
      private GXUserControl ucCombo_locationcountry ;
      private GXUserControl ucBtnwizardfirstprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucUsercontrol1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP3_OrganisationId ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV26DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV32LocationPhoneCode_Data ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV37UploadedFiles ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV42FilesToUpdate ;
      private GXBaseCollection<SdtFileUploadData> AV43UploadedFile ;
      private GXBaseCollection<SdtFileUploadData> AV44FailedFile ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV25LocationCountry_Data ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private SdtTrn_Organisation AV23Trn_Organisation ;
      private SdtWP_CreateLocationAndReceptionistData AV11WizardData ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV45GXV1 ;
      private SdtSDT_Country_SDT_CountryItem AV29LocationCountry_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV28Combo_DataItem ;
      private GxSimpleCollection<string> AV24ComboTitles ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV47GXV3 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem3 ;
      private SdtSDT_Country_SDT_CountryItem AV33LocationPhoneCode_DPItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
