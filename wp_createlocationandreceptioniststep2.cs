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
   public class wp_createlocationandreceptioniststep2 : GXWebComponent
   {
      public wp_createlocationandreceptioniststep2( )
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

      public wp_createlocationandreceptioniststep2( IGxContext context )
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
         this.AV63OrganisationId = aP3_OrganisationId;
         ExecuteImpl();
         aP3_OrganisationId=this.AV63OrganisationId;
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
         chkavSdt_receptionists__receptionistisactive = new GXCheckbox();
         cmbavGridactiongroup1 = new GXCombobox();
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
                  AV63OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "AV63OrganisationId", AV63OrganisationId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6WebSessionKey,(string)AV8PreviousStep,(bool)AV7GoingBack,(Guid)AV63OrganisationId});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdt_receptionistss") == 0 )
               {
                  gxnrGridsdt_receptionistss_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdt_receptionistss") == 0 )
               {
                  gxgrGridsdt_receptionistss_refresh_invoke( ) ;
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

      protected void gxnrGridsdt_receptionistss_newrow_invoke( )
      {
         nRC_GXsfl_83 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_83"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_83_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_83_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_83_idx = GetPar( "sGXsfl_83_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsdt_receptionistss_newrow( ) ;
         /* End function gxnrGridsdt_receptionistss_newrow_invoke */
      }

      protected void gxgrGridsdt_receptionistss_refresh_invoke( )
      {
         subGridsdt_receptionistss_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsdt_receptionistss_Rows"), "."), 18, MidpointRounding.ToEven));
         AV68ReceptionistTitle = GetPar( "ReceptionistTitle");
         AV10HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV54Trn_Manager);
         AV47FileName = GetPar( "FileName");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV68ReceptionistTitle, AV10HasValidationErrors, AV54Trn_Manager, AV47FileName, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridsdt_receptionistss_refresh_invoke */
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
            PA662( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavFilename_Enabled = 0;
               AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
               edtavSdt_receptionists__receptionistid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistid_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtavSdt_receptionists__organisationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__organisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__organisationid_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtavSdt_receptionists__locationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__locationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__locationid_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistgivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistgivenname_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtavSdt_receptionists__receptionistlastname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistlastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistlastname_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtavSdt_receptionists__receptionistemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistemail_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtavSdt_receptionists__receptionistphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistphone_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtavSdt_receptionists__receptionistphonecode_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistphonecode_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtavSdt_receptionists__receptionistphonenumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistphonenumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistphonenumber_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtavSdt_receptionists__receptioniststatus_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptioniststatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptioniststatus_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               chkavSdt_receptionists__receptionistisactive.Enabled = 0;
               AssignProp(sPrefix, false, chkavSdt_receptionists__receptionistisactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavSdt_receptionists__receptionistisactive.Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistgamguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistgamguid_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               WS662( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Create Location And Receptionist Step2", "")) ;
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
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GXEncryptionTmp = "wp_createlocationandreceptioniststep2.aspx"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack)) + "," + UrlEncode(AV63OrganisationId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createlocationandreceptioniststep2.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vRECEPTIONISTTITLE", AV68ReceptionistTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRECEPTIONISTTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV68ReceptionistTitle, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_MANAGER", AV54Trn_Manager);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_MANAGER", AV54Trn_Manager);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTRN_MANAGER", GetSecureSignedToken( sPrefix, AV54Trn_Manager, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILENAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47FileName, "")), context));
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WP_CreateLocationAndReceptionistStep2");
         forbiddenHiddens.Add("FileName", StringUtil.RTrim( context.localUtil.Format( AV47FileName, "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wp_createlocationandreceptioniststep2:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdt_receptionists", AV19SDT_Receptionists);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdt_receptionists", AV19SDT_Receptionists);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_83", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_83), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV43UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV43UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFAILEDFILES", AV44FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFAILEDFILES", AV44FailedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV32DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV32DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRECEPTIONISTPHONECODE_DATA", AV36ReceptionistPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRECEPTIONISTPHONECODE_DATA", AV36ReceptionistPhoneCode_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV63OrganisationId", wcpOAV63OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vRECEPTIONISTTITLE", AV68ReceptionistTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRECEPTIONISTTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV68ReceptionistTitle, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_RECEPTIONISTS", AV19SDT_Receptionists);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_RECEPTIONISTS", AV19SDT_Receptionists);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV18CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vIMAGEFILE2", AV61ImageFile2);
         GxWebStd.gx_hidden_field( context, sPrefix+"vORGANISATIONID", AV63OrganisationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_FILEUPLOADDATA", AV66SDT_FileUploadData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_FILEUPLOADDATA", AV66SDT_FileUploadData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_RECEPTIONIST", AV26Trn_Receptionist);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_RECEPTIONIST", AV26Trn_Receptionist);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_MANAGER", AV54Trn_Manager);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_MANAGER", AV54Trn_Manager);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTRN_MANAGER", GetSecureSignedToken( sPrefix, AV54Trn_Manager, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISSUCCESSFUL", AV53isSuccessful);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vERRORMESSAGES", AV23ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vERRORMESSAGES", AV23ErrorMessages);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"RECEPTIONISTEMAIL", A93ReceptionistEmail);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_LOCATION", AV24Trn_Location);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_LOCATION", AV24Trn_Location);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNUSERACTION1_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnuseraction1_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECEPTIONISTPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_receptionistphonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNUSERACTION1_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnuseraction1_Result));
      }

      protected void RenderHtmlCloseForm662( )
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
         return "WP_CreateLocationAndReceptionistStep2" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Create Location And Receptionist Step2", "") ;
      }

      protected void WB660( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createlocationandreceptioniststep2.aspx");
               context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpReceptionistgroup_Internalname, grpReceptionistgroup_Caption, 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFormtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReceptionistgivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReceptionistgivenname_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistgivenname_Internalname, AV14ReceptionistGivenName, StringUtil.RTrim( context.localUtil.Format( AV14ReceptionistGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistgivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavReceptionistgivenname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReceptionistlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReceptionistlastname_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistlastname_Internalname, AV15ReceptionistLastName, StringUtil.RTrim( context.localUtil.Format( AV15ReceptionistLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistlastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavReceptionistlastname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, divUnnamedtable7_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblProductserviceimagetext_Internalname, context.GetMessage( "Image", ""), "", "", lblProductserviceimagetext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUcfilecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-5", "start", "top", "", "", "div");
            wb_table1_34_662( true) ;
         }
         else
         {
            wb_table1_34_662( false) ;
         }
         return  ;
      }

      protected void wb_table1_34_662e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReceptionistimagevar_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavReceptionistimagevar_Internalname, AV48ReceptionistImageVar, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, 1, edtavReceptionistimagevar_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReceptionistemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReceptionistemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistemail_Internalname, AV16ReceptionistEmail, StringUtil.RTrim( context.localUtil.Format( AV16ReceptionistEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "johndoe@gmail.com", ""), edtavReceptionistemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavReceptionistemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPhonelabel_Internalname, context.GetMessage( "Phone", ""), "", "", lblPhonelabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_receptionistphonecode.SetProperty("Caption", Combo_receptionistphonecode_Caption);
            ucCombo_receptionistphonecode.SetProperty("Cls", Combo_receptionistphonecode_Cls);
            ucCombo_receptionistphonecode.SetProperty("EmptyItem", Combo_receptionistphonecode_Emptyitem);
            ucCombo_receptionistphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV32DDO_TitleSettingsIcons);
            ucCombo_receptionistphonecode.SetProperty("DropDownOptionsData", AV36ReceptionistPhoneCode_Data);
            ucCombo_receptionistphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_receptionistphonecode_Internalname, sPrefix+"COMBO_RECEPTIONISTPHONECODEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReceptionistphonenumber_Internalname, context.GetMessage( "Receptionist Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistphonenumber_Internalname, AV38ReceptionistPhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV38ReceptionistPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistphonenumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavReceptionistphonenumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuinsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(83), 2, 0)+","+"null"+");", context.GetMessage( "Save", ""), bttBtnuinsert_Jsonclick, 5, context.GetMessage( "Add new item", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegrid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Gridsdt_receptionistssContainer.SetWrapped(nGXWrapped);
            StartGridControl83( ) ;
         }
         if ( wbEnd == 83 )
         {
            wbEnd = 0;
            nRC_GXsfl_83 = (int)(nGXsfl_83_idx-1);
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Gridsdt_receptionistssContainer.AddObjectProperty("GRIDSDT_RECEPTIONISTSS_nEOF", GRIDSDT_RECEPTIONISTSS_nEOF);
               Gridsdt_receptionistssContainer.AddObjectProperty("GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
               AV70GXV1 = nGXsfl_83_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_receptionistssContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_receptionistss", Gridsdt_receptionistssContainer, subGridsdt_receptionistss_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_receptionistssContainerData", Gridsdt_receptionistssContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_receptionistssContainerData"+"V", Gridsdt_receptionistssContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_receptionistssContainerData"+"V"+"\" value='"+Gridsdt_receptionistssContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            ucBtnwizardprevious.SetProperty("TooltipText", Btnwizardprevious_Tooltiptext);
            ucBtnwizardprevious.SetProperty("Caption", Btnwizardprevious_Caption);
            ucBtnwizardprevious.SetProperty("Class", Btnwizardprevious_Class);
            ucBtnwizardprevious.Render(context, "wwp_iconbutton", Btnwizardprevious_Internalname, sPrefix+"BTNWIZARDPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardlastnext.SetProperty("TooltipText", Btnwizardlastnext_Tooltiptext);
            ucBtnwizardlastnext.SetProperty("Caption", Btnwizardlastnext_Caption);
            ucBtnwizardlastnext.SetProperty("Class", Btnwizardlastnext_Class);
            ucBtnwizardlastnext.Render(context, "wwp_iconbutton", Btnwizardlastnext_Internalname, sPrefix+"BTNWIZARDLASTNEXTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(83), 2, 0)+","+"null"+");", context.GetMessage( "Proceed ", ""), bttBtnuseraction1_Jsonclick, 7, context.GetMessage( "Proceed ", ""), "", StyleString, ClassString, bttBtnuseraction1_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11661_client"+"'", TempTags, "", 2, "HLP_WP_CreateLocationAndReceptionistStep2.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistphonecode_Internalname, AV35ReceptionistPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV35ReceptionistPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavReceptionistphonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistphone_Internalname, StringUtil.RTrim( AV17ReceptionistPhone), StringUtil.RTrim( context.localUtil.Format( AV17ReceptionistPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavReceptionistphone_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistid_Internalname, AV13ReceptionistId.ToString(), AV13ReceptionistId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistid_Jsonclick, 0, "Attribute", "", "", "", "", edtavReceptionistid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            wb_table2_113_662( true) ;
         }
         else
         {
            wb_table2_113_662( false) ;
         }
         return  ;
      }

      protected void wb_table2_113_662e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGridsdt_receptionistss_empowerer.Render(context, "wwp.gridempowerer", Gridsdt_receptionistss_empowerer_Internalname, sPrefix+"GRIDSDT_RECEPTIONISTSS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 83 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Gridsdt_receptionistssContainer.AddObjectProperty("GRIDSDT_RECEPTIONISTSS_nEOF", GRIDSDT_RECEPTIONISTSS_nEOF);
                  Gridsdt_receptionistssContainer.AddObjectProperty("GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
                  AV70GXV1 = nGXsfl_83_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_receptionistssContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_receptionistss", Gridsdt_receptionistssContainer, subGridsdt_receptionistss_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_receptionistssContainerData", Gridsdt_receptionistssContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_receptionistssContainerData"+"V", Gridsdt_receptionistssContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_receptionistssContainerData"+"V"+"\" value='"+Gridsdt_receptionistssContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START662( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Create Location And Receptionist Step2", ""), 0) ;
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
               STRUP660( ) ;
            }
         }
      }

      protected void WS662( )
      {
         START662( ) ;
         EVT662( ) ;
      }

      protected void EVT662( )
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
                                 STRUP660( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNUSERACTION1.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_btnuseraction1.Close */
                                    E12662 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
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
                                          E13662 ();
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
                                 STRUP660( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E14662 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUInsert' */
                                    E15662 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRECEPTIONISTEMAIL.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E16662 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRECEPTIONISTPHONENUMBER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E17662 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSdt_receptionists__receptionistid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_RECEPTIONISTSSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDSDT_RECEPTIONISTSSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridsdt_receptionistss_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridsdt_receptionistss_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridsdt_receptionistss_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridsdt_receptionistss_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 27), "GRIDSDT_RECEPTIONISTSS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              nGXsfl_83_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
                              SubsflControlProps_832( ) ;
                              AV70GXV1 = (int)(nGXsfl_83_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
                              if ( ( AV19SDT_Receptionists.Count >= AV70GXV1 ) && ( AV70GXV1 > 0 ) )
                              {
                                 AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1));
                                 cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                                 cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                                 AV60GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV60GridActionGroup1), 4, 0));
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
                                          GX_FocusControl = edtavSdt_receptionists__receptionistid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E18662 ();
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
                                          GX_FocusControl = edtavSdt_receptionists__receptionistid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E19662 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_RECEPTIONISTSS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_receptionists__receptionistid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Gridsdt_receptionistss.Load */
                                          E20662 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_receptionists__receptionistid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E21662 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP660( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_receptionists__receptionistid_Internalname;
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

      protected void WE662( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm662( ) ;
            }
         }
      }

      protected void PA662( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createlocationandreceptioniststep2.aspx")), "wp_createlocationandreceptioniststep2.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createlocationandreceptioniststep2.aspx")))) ;
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
               GX_FocusControl = edtavReceptionistgivenname_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridsdt_receptionistss_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_832( ) ;
         while ( nGXsfl_83_idx <= nRC_GXsfl_83 )
         {
            sendrow_832( ) ;
            nGXsfl_83_idx = ((subGridsdt_receptionistss_Islastpage==1)&&(nGXsfl_83_idx+1>subGridsdt_receptionistss_fnc_Recordsperpage( )) ? 1 : nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_832( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsdt_receptionistssContainer)) ;
         /* End function gxnrGridsdt_receptionistss_newrow */
      }

      protected void gxgrGridsdt_receptionistss_refresh( int subGridsdt_receptionistss_Rows ,
                                                         string AV68ReceptionistTitle ,
                                                         bool AV10HasValidationErrors ,
                                                         SdtTrn_Manager AV54Trn_Manager ,
                                                         string AV47FileName ,
                                                         string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDSDT_RECEPTIONISTSS_nCurrentRecord = 0;
         RF662( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WP_CreateLocationAndReceptionistStep2");
         forbiddenHiddens.Add("FileName", StringUtil.RTrim( context.localUtil.Format( AV47FileName, "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wp_createlocationandreceptioniststep2:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         /* End function gxgrGridsdt_receptionistss_refresh */
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
         RF662( ) ;
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
         edtavSdt_receptionists__receptionistid_Enabled = 0;
         edtavSdt_receptionists__organisationid_Enabled = 0;
         edtavSdt_receptionists__locationid_Enabled = 0;
         edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
         edtavSdt_receptionists__receptionistlastname_Enabled = 0;
         edtavSdt_receptionists__receptionistemail_Enabled = 0;
         edtavSdt_receptionists__receptionistphone_Enabled = 0;
         edtavSdt_receptionists__receptionistphonecode_Enabled = 0;
         edtavSdt_receptionists__receptionistphonenumber_Enabled = 0;
         edtavSdt_receptionists__receptioniststatus_Enabled = 0;
         chkavSdt_receptionists__receptionistisactive.Enabled = 0;
         edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
      }

      protected void RF662( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridsdt_receptionistssContainer.ClearRows();
         }
         wbStart = 83;
         /* Execute user event: Refresh */
         E19662 ();
         nGXsfl_83_idx = 1;
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_832( ) ;
         bGXsfl_83_Refreshing = true;
         Gridsdt_receptionistssContainer.AddObjectProperty("GridName", "Gridsdt_receptionistss");
         Gridsdt_receptionistssContainer.AddObjectProperty("CmpContext", sPrefix);
         Gridsdt_receptionistssContainer.AddObjectProperty("InMasterPage", "false");
         Gridsdt_receptionistssContainer.AddObjectProperty("Class", "WorkWith");
         Gridsdt_receptionistssContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsdt_receptionistssContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsdt_receptionistssContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Backcolorstyle), 1, 0, ".", "")));
         Gridsdt_receptionistssContainer.PageSize = subGridsdt_receptionistss_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_832( ) ;
            /* Execute user event: Gridsdt_receptionistss.Load */
            E20662 ();
            if ( ( subGridsdt_receptionistss_Islastpage == 0 ) && ( GRIDSDT_RECEPTIONISTSS_nCurrentRecord > 0 ) && ( GRIDSDT_RECEPTIONISTSS_nGridOutOfScope == 0 ) && ( nGXsfl_83_idx == 1 ) )
            {
               GRIDSDT_RECEPTIONISTSS_nCurrentRecord = 0;
               GRIDSDT_RECEPTIONISTSS_nGridOutOfScope = 1;
               subgridsdt_receptionistss_firstpage( ) ;
               /* Execute user event: Gridsdt_receptionistss.Load */
               E20662 ();
            }
            wbEnd = 83;
            WB660( ) ;
         }
         bGXsfl_83_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes662( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vRECEPTIONISTTITLE", AV68ReceptionistTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRECEPTIONISTTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV68ReceptionistTitle, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_MANAGER", AV54Trn_Manager);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_MANAGER", AV54Trn_Manager);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTRN_MANAGER", GetSecureSignedToken( sPrefix, AV54Trn_Manager, context));
      }

      protected int subGridsdt_receptionistss_fnc_Pagecount( )
      {
         GRIDSDT_RECEPTIONISTSS_nRecordCount = subGridsdt_receptionistss_fnc_Recordcount( );
         if ( ((int)((GRIDSDT_RECEPTIONISTSS_nRecordCount) % (subGridsdt_receptionistss_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_RECEPTIONISTSS_nRecordCount/ (decimal)(subGridsdt_receptionistss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_RECEPTIONISTSS_nRecordCount/ (decimal)(subGridsdt_receptionistss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridsdt_receptionistss_fnc_Recordcount( )
      {
         return AV19SDT_Receptionists.Count ;
      }

      protected int subGridsdt_receptionistss_fnc_Recordsperpage( )
      {
         if ( subGridsdt_receptionistss_Rows > 0 )
         {
            return subGridsdt_receptionistss_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsdt_receptionistss_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage/ (decimal)(subGridsdt_receptionistss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridsdt_receptionistss_firstpage( )
      {
         GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV68ReceptionistTitle, AV10HasValidationErrors, AV54Trn_Manager, AV47FileName, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_receptionistss_nextpage( )
      {
         GRIDSDT_RECEPTIONISTSS_nRecordCount = subGridsdt_receptionistss_fnc_Recordcount( );
         if ( ( GRIDSDT_RECEPTIONISTSS_nRecordCount >= subGridsdt_receptionistss_fnc_Recordsperpage( ) ) && ( GRIDSDT_RECEPTIONISTSS_nEOF == 0 ) )
         {
            GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = (long)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage+subGridsdt_receptionistss_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridsdt_receptionistssContainer.AddObjectProperty("GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV68ReceptionistTitle, AV10HasValidationErrors, AV54Trn_Manager, AV47FileName, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSDT_RECEPTIONISTSS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsdt_receptionistss_previouspage( )
      {
         if ( GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage >= subGridsdt_receptionistss_fnc_Recordsperpage( ) )
         {
            GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = (long)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage-subGridsdt_receptionistss_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV68ReceptionistTitle, AV10HasValidationErrors, AV54Trn_Manager, AV47FileName, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_receptionistss_lastpage( )
      {
         GRIDSDT_RECEPTIONISTSS_nRecordCount = subGridsdt_receptionistss_fnc_Recordcount( );
         if ( GRIDSDT_RECEPTIONISTSS_nRecordCount > subGridsdt_receptionistss_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDSDT_RECEPTIONISTSS_nRecordCount) % (subGridsdt_receptionistss_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = (long)(GRIDSDT_RECEPTIONISTSS_nRecordCount-subGridsdt_receptionistss_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = (long)(GRIDSDT_RECEPTIONISTSS_nRecordCount-((int)((GRIDSDT_RECEPTIONISTSS_nRecordCount) % (subGridsdt_receptionistss_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV68ReceptionistTitle, AV10HasValidationErrors, AV54Trn_Manager, AV47FileName, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsdt_receptionistss_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = (long)(subGridsdt_receptionistss_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV68ReceptionistTitle, AV10HasValidationErrors, AV54Trn_Manager, AV47FileName, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavFilename_Enabled = 0;
         AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
         edtavSdt_receptionists__receptionistid_Enabled = 0;
         edtavSdt_receptionists__organisationid_Enabled = 0;
         edtavSdt_receptionists__locationid_Enabled = 0;
         edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
         edtavSdt_receptionists__receptionistlastname_Enabled = 0;
         edtavSdt_receptionists__receptionistemail_Enabled = 0;
         edtavSdt_receptionists__receptionistphone_Enabled = 0;
         edtavSdt_receptionists__receptionistphonecode_Enabled = 0;
         edtavSdt_receptionists__receptionistphonenumber_Enabled = 0;
         edtavSdt_receptionists__receptioniststatus_Enabled = 0;
         chkavSdt_receptionists__receptionistisactive.Enabled = 0;
         edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP660( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18662 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdt_receptionists"), AV19SDT_Receptionists);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV43UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFAILEDFILES"), AV44FailedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV32DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRECEPTIONISTPHONECODE_DATA"), AV36ReceptionistPhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDT_RECEPTIONISTS"), AV19SDT_Receptionists);
            /* Read saved values. */
            nRC_GXsfl_83 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_83"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            wcpOAV63OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV63OrganisationId"));
            GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDSDT_RECEPTIONISTSS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_RECEPTIONISTSS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridsdt_receptionistss_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_RECEPTIONISTSS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_btnuseraction1_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_BTNUSERACTION1_Result");
            nRC_GXsfl_83 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_83"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_83_fel_idx = 0;
            while ( nGXsfl_83_fel_idx < nRC_GXsfl_83 )
            {
               nGXsfl_83_fel_idx = ((subGridsdt_receptionistss_Islastpage==1)&&(nGXsfl_83_fel_idx+1>subGridsdt_receptionistss_fnc_Recordsperpage( )) ? 1 : nGXsfl_83_fel_idx+1);
               sGXsfl_83_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_832( ) ;
               AV70GXV1 = (int)(nGXsfl_83_fel_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
               if ( ( AV19SDT_Receptionists.Count >= AV70GXV1 ) && ( AV70GXV1 > 0 ) )
               {
                  AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1));
                  cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                  cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                  AV60GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
               }
            }
            if ( nGXsfl_83_fel_idx == 0 )
            {
               nGXsfl_83_idx = 1;
               sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
               SubsflControlProps_832( ) ;
            }
            nGXsfl_83_fel_idx = 1;
            /* Read variables values. */
            AV14ReceptionistGivenName = cgiGet( edtavReceptionistgivenname_Internalname);
            AssignAttri(sPrefix, false, "AV14ReceptionistGivenName", AV14ReceptionistGivenName);
            AV15ReceptionistLastName = cgiGet( edtavReceptionistlastname_Internalname);
            AssignAttri(sPrefix, false, "AV15ReceptionistLastName", AV15ReceptionistLastName);
            AV47FileName = cgiGet( edtavFilename_Internalname);
            AssignAttri(sPrefix, false, "AV47FileName", AV47FileName);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILENAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47FileName, "")), context));
            AV48ReceptionistImageVar = cgiGet( edtavReceptionistimagevar_Internalname);
            AssignAttri(sPrefix, false, "AV48ReceptionistImageVar", AV48ReceptionistImageVar);
            AV16ReceptionistEmail = cgiGet( edtavReceptionistemail_Internalname);
            AssignAttri(sPrefix, false, "AV16ReceptionistEmail", AV16ReceptionistEmail);
            AV38ReceptionistPhoneNumber = cgiGet( edtavReceptionistphonenumber_Internalname);
            AssignAttri(sPrefix, false, "AV38ReceptionistPhoneNumber", AV38ReceptionistPhoneNumber);
            AV35ReceptionistPhoneCode = cgiGet( edtavReceptionistphonecode_Internalname);
            AssignAttri(sPrefix, false, "AV35ReceptionistPhoneCode", AV35ReceptionistPhoneCode);
            AV17ReceptionistPhone = cgiGet( edtavReceptionistphone_Internalname);
            AssignAttri(sPrefix, false, "AV17ReceptionistPhone", AV17ReceptionistPhone);
            if ( StringUtil.StrCmp(cgiGet( edtavReceptionistid_Internalname), "") == 0 )
            {
               AV13ReceptionistId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV13ReceptionistId", AV13ReceptionistId.ToString());
            }
            else
            {
               try
               {
                  AV13ReceptionistId = StringUtil.StrToGuid( cgiGet( edtavReceptionistid_Internalname));
                  AssignAttri(sPrefix, false, "AV13ReceptionistId", AV13ReceptionistId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vRECEPTIONISTID");
                  GX_FocusControl = edtavReceptionistid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WP_CreateLocationAndReceptionistStep2");
            AV47FileName = cgiGet( edtavFilename_Internalname);
            AssignAttri(sPrefix, false, "AV47FileName", AV47FileName);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILENAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47FileName, "")), context));
            forbiddenHiddens.Add("FileName", StringUtil.RTrim( context.localUtil.Format( AV47FileName, "")));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("wp_createlocationandreceptioniststep2:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
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
         E18662 ();
         if (returnInSub) return;
      }

      protected void E18662( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( (false==AV11WizardData.gxTpr_Step1.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null)) )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createlocationandreceptionist.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.BoolToStr(true));
            CallWebObject(formatLink("wp_createlocationandreceptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV32DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV32DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavReceptionistphonecode_Visible = 0;
         AssignProp(sPrefix, false, edtavReceptionistphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReceptionistphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_receptionistphonecode_Htmltemplate = GXt_char2;
         ucCombo_receptionistphonecode.SendProperty(context, sPrefix, false, Combo_receptionistphonecode_Internalname, "HTMLTemplate", Combo_receptionistphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBORECEPTIONISTPHONECODE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if (returnInSub) return;
         edtavReceptionistphone_Visible = 0;
         AssignProp(sPrefix, false, edtavReceptionistphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReceptionistphone_Visible), 5, 0), true);
         edtavReceptionistid_Visible = 0;
         AssignProp(sPrefix, false, edtavReceptionistid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReceptionistid_Visible), 5, 0), true);
         Gridsdt_receptionistss_empowerer_Gridinternalname = subGridsdt_receptionistss_Internalname;
         ucGridsdt_receptionistss_empowerer.SendProperty(context, sPrefix, false, Gridsdt_receptionistss_empowerer_Internalname, "GridInternalName", Gridsdt_receptionistss_empowerer_Gridinternalname);
         subGridsdt_receptionistss_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Rows), 6, 0, ".", "")));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35ReceptionistPhoneCode)) )
         {
            AV33defaultCountryPhoneCode = "+31";
            AV35ReceptionistPhoneCode = "+31";
            AssignAttri(sPrefix, false, "AV35ReceptionistPhoneCode", AV35ReceptionistPhoneCode);
            Combo_receptionistphonecode_Selectedtext_set = AV33defaultCountryPhoneCode;
            ucCombo_receptionistphonecode.SendProperty(context, sPrefix, false, Combo_receptionistphonecode_Internalname, "SelectedText_set", Combo_receptionistphonecode_Selectedtext_set);
            Combo_receptionistphonecode_Selectedvalue_set = AV33defaultCountryPhoneCode;
            ucCombo_receptionistphonecode.SendProperty(context, sPrefix, false, Combo_receptionistphonecode_Internalname, "SelectedValue_set", Combo_receptionistphonecode_Selectedvalue_set);
         }
         GXt_char2 = AV68ReceptionistTitle;
         new prc_getorganisationdefinition(context ).execute(  "Receptionist", out  GXt_char2) ;
         AV68ReceptionistTitle = GXt_char2;
         AssignAttri(sPrefix, false, "AV68ReceptionistTitle", AV68ReceptionistTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRECEPTIONISTTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV68ReceptionistTitle, "")), context));
      }

      protected void E19662( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S142 ();
         if (returnInSub) return;
         grpReceptionistgroup_Caption = AV68ReceptionistTitle+" "+context.GetMessage( "Information", "");
         AssignProp(sPrefix, false, grpReceptionistgroup_Internalname, "Caption", grpReceptionistgroup_Caption, true);
         /*  Sending Event outputs  */
      }

      private void E20662( )
      {
         /* Gridsdt_receptionistss_Load Routine */
         returnInSub = false;
         AV70GXV1 = 1;
         while ( AV70GXV1 <= AV19SDT_Receptionists.Count )
         {
            AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1));
            cmbavGridactiongroup1.removeAllItems();
            cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
            cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fas fa-pencil", "", "", "", "", "", "", ""), 0);
            cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Delete", ""), "fas fa-xmark", "", "", "", "", "", "", ""), 0);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 83;
            }
            if ( ( subGridsdt_receptionistss_Islastpage == 1 ) || ( subGridsdt_receptionistss_Rows == 0 ) || ( ( GRIDSDT_RECEPTIONISTSS_nCurrentRecord >= GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage ) && ( GRIDSDT_RECEPTIONISTSS_nCurrentRecord < GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage + subGridsdt_receptionistss_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_832( ) ;
            }
            GRIDSDT_RECEPTIONISTSS_nEOF = (short)(((GRIDSDT_RECEPTIONISTSS_nCurrentRecord<GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage+subGridsdt_receptionistss_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nEOF), 1, 0, ".", "")));
            GRIDSDT_RECEPTIONISTSS_nCurrentRecord = (long)(GRIDSDT_RECEPTIONISTSS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_83_Refreshing )
            {
               DoAjaxLoad(83, Gridsdt_receptionistssRow);
            }
            AV70GXV1 = (int)(AV70GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridActionGroup1), 4, 0));
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E13662 ();
         if (returnInSub) return;
      }

      protected void E13662( )
      {
         AV70GXV1 = (int)(nGXsfl_83_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
         if ( ( AV70GXV1 > 0 ) && ( AV19SDT_Receptionists.Count >= AV70GXV1 ) )
         {
            AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         if ( true )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S152 ();
            if (returnInSub) return;
            if ( AV19SDT_Receptionists.Count == 0 )
            {
               this.executeUsercontrolMethod(sPrefix, false, "DVELOP_CONFIRMPANEL_BTNUSERACTION1Container", "Confirm", "", new Object[] {});
               Dvelop_confirmpanel_btnuseraction1_Confirmationtext = context.GetMessage( "You are creating a location without any ", "")+AV68ReceptionistTitle+context.GetMessage( ", Are you sure you want to proceed?", "");
               ucDvelop_confirmpanel_btnuseraction1.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_btnuseraction1_Internalname, "ConfirmationText", Dvelop_confirmpanel_btnuseraction1_Confirmationtext);
            }
            else
            {
               /* Execute user subroutine: 'FINISHWIZARD' */
               S162 ();
               if (returnInSub) return;
               AV5WebSession.Remove(AV6WebSessionKey);
            }
         }
         else
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
            S172 ();
            if (returnInSub) return;
            if ( AV18CheckRequiredFieldsResult && ! AV10HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S152 ();
               if (returnInSub) return;
               /* Execute user subroutine: 'FINISHWIZARD' */
               S162 ();
               if (returnInSub) return;
               AV5WebSession.Remove(AV6WebSessionKey);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23ErrorMessages", AV23ErrorMessages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24Trn_Location", AV24Trn_Location);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV66SDT_FileUploadData", AV66SDT_FileUploadData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26Trn_Receptionist", AV26Trn_Receptionist);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19SDT_Receptionists", AV19SDT_Receptionists);
         nGXsfl_83_bak_idx = nGXsfl_83_idx;
         gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV68ReceptionistTitle, AV10HasValidationErrors, AV54Trn_Manager, AV47FileName, sPrefix) ;
         nGXsfl_83_idx = nGXsfl_83_bak_idx;
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_832( ) ;
      }

      protected void E14662( )
      {
         AV70GXV1 = (int)(nGXsfl_83_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
         if ( ( AV70GXV1 > 0 ) && ( AV19SDT_Receptionists.Count >= AV70GXV1 ) )
         {
            AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1));
         }
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S152 ();
         if (returnInSub) return;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_createlocationandreceptionist.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.BoolToStr(true)) + "," + UrlEncode(AV63OrganisationId.ToString());
         CallWebObject(formatLink("wp_createlocationandreceptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E15662( )
      {
         AV70GXV1 = (int)(nGXsfl_83_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
         if ( ( AV70GXV1 > 0 ) && ( AV19SDT_Receptionists.Count >= AV70GXV1 ) )
         {
            AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1));
         }
         /* 'DoUInsert' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S172 ();
         if (returnInSub) return;
         if ( AV18CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            AV20isAlreadyAdded = false;
            AV58isAlreadyExistingInGAM = false;
            AV57GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getbylogin("local", AV16ReceptionistEmail, out  AV55GAMErrorCollection);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57GAMUser.gxTpr_Email)) && ( StringUtil.StrCmp(AV57GAMUser.gxTpr_Email, AV16ReceptionistEmail) == 0 ) )
            {
               AV58isAlreadyExistingInGAM = true;
            }
            AV83GXV14 = 1;
            while ( AV83GXV14 <= AV19SDT_Receptionists.Count )
            {
               AV21SDT_Receptionist = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV83GXV14));
               if ( StringUtil.StrCmp(AV21SDT_Receptionist.gxTpr_Receptionistemail, AV16ReceptionistEmail) == 0 )
               {
                  AV20isAlreadyAdded = true;
                  if (true) break;
               }
               AV83GXV14 = (int)(AV83GXV14+1);
            }
            /* Using cursor H00662 */
            pr_default.execute(0, new Object[] {AV16ReceptionistEmail});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A93ReceptionistEmail = H00662_A93ReceptionistEmail[0];
               AV22isAlreadyRegistered = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV20isAlreadyAdded || AV22isAlreadyRegistered )
            {
               GX_msglist.addItem(context.GetMessage( "This email has already been added.", ""));
               AV19SDT_Receptionists = AV11WizardData.gxTpr_Step2.gxTpr_Sdt_receptionists;
               gx_BV83 = true;
            }
            else
            {
               if ( AV58isAlreadyExistingInGAM )
               {
                  GX_msglist.addItem(context.GetMessage( "This email is already used in the system.", ""));
                  AV19SDT_Receptionists = AV11WizardData.gxTpr_Step2.gxTpr_Sdt_receptionists;
                  gx_BV83 = true;
               }
               else
               {
                  AV50Image=context.FileFromBase64( AV48ReceptionistImageVar) ;
                  AV21SDT_Receptionist = new SdtSDT_Receptionists_SDT_ReceptionistsItem(context);
                  AV21SDT_Receptionist.gxTpr_Receptionistid = Guid.NewGuid( );
                  AV21SDT_Receptionist.gxTpr_Locationid = AV24Trn_Location.gxTpr_Locationid;
                  AV21SDT_Receptionist.gxTpr_Receptionistemail = AV16ReceptionistEmail;
                  AV21SDT_Receptionist.gxTpr_Receptionistgivenname = AV14ReceptionistGivenName;
                  AV21SDT_Receptionist.gxTpr_Receptionistlastname = AV15ReceptionistLastName;
                  AV21SDT_Receptionist.gxTpr_Receptionistphonecode = AV35ReceptionistPhoneCode;
                  AV21SDT_Receptionist.gxTpr_Receptionistphonenumber = AV38ReceptionistPhoneNumber;
                  GXt_char2 = "";
                  new prc_concatenateintlphone(context ).execute(  AV35ReceptionistPhoneCode,  AV38ReceptionistPhoneNumber, out  GXt_char2) ;
                  AV21SDT_Receptionist.gxTpr_Receptionistphone = GXt_char2;
                  AV11WizardData.gxTpr_Step2.gxTpr_Sdt_receptionists.Add(AV21SDT_Receptionist, 0);
                  AV19SDT_Receptionists = AV11WizardData.gxTpr_Step2.gxTpr_Sdt_receptionists;
                  gx_BV83 = true;
                  /* Execute user subroutine: 'CLEARFORMVALUES' */
                  S182 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19SDT_Receptionists", AV19SDT_Receptionists);
         nGXsfl_83_bak_idx = nGXsfl_83_idx;
         gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV68ReceptionistTitle, AV10HasValidationErrors, AV54Trn_Manager, AV47FileName, sPrefix) ;
         nGXsfl_83_idx = nGXsfl_83_bak_idx;
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_832( ) ;
      }

      protected void E12662( )
      {
         AV70GXV1 = (int)(nGXsfl_83_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
         if ( ( AV70GXV1 > 0 ) && ( AV19SDT_Receptionists.Count >= AV70GXV1 ) )
         {
            AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1));
         }
         /* Dvelop_confirmpanel_btnuseraction1_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btnuseraction1_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'FINISHWIZARD' */
            S162 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23ErrorMessages", AV23ErrorMessages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24Trn_Location", AV24Trn_Location);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV66SDT_FileUploadData", AV66SDT_FileUploadData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26Trn_Receptionist", AV26Trn_Receptionist);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19SDT_Receptionists", AV19SDT_Receptionists);
         nGXsfl_83_bak_idx = nGXsfl_83_idx;
         gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV68ReceptionistTitle, AV10HasValidationErrors, AV54Trn_Manager, AV47FileName, sPrefix) ;
         nGXsfl_83_idx = nGXsfl_83_bak_idx;
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_832( ) ;
      }

      protected void E21662( )
      {
         AV70GXV1 = (int)(nGXsfl_83_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
         if ( ( AV70GXV1 > 0 ) && ( AV19SDT_Receptionists.Count >= AV70GXV1 ) )
         {
            AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1));
         }
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV60GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO UUPDATE' */
            S192 ();
            if (returnInSub) return;
         }
         else if ( AV60GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO UDELETE' */
            S202 ();
            if (returnInSub) return;
         }
         AV60GridActionGroup1 = 0;
         AssignAttri(sPrefix, false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV60GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridActionGroup1), 4, 0));
         AssignProp(sPrefix, false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19SDT_Receptionists", AV19SDT_Receptionists);
         nGXsfl_83_bak_idx = nGXsfl_83_idx;
         gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV68ReceptionistTitle, AV10HasValidationErrors, AV54Trn_Manager, AV47FileName, sPrefix) ;
         nGXsfl_83_idx = nGXsfl_83_bak_idx;
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_832( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( 1 == 0 ) ) )
         {
            bttBtnuseraction1_Visible = 0;
            AssignProp(sPrefix, false, bttBtnuseraction1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuseraction1_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV16ReceptionistEmail = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistemail;
         AssignAttri(sPrefix, false, "AV16ReceptionistEmail", AV16ReceptionistEmail);
         AV17ReceptionistPhone = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistphone;
         AssignAttri(sPrefix, false, "AV17ReceptionistPhone", AV17ReceptionistPhone);
         AV38ReceptionistPhoneNumber = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistphonenumber;
         AssignAttri(sPrefix, false, "AV38ReceptionistPhoneNumber", AV38ReceptionistPhoneNumber);
         AV35ReceptionistPhoneCode = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistphonecode;
         AssignAttri(sPrefix, false, "AV35ReceptionistPhoneCode", AV35ReceptionistPhoneCode);
         AV13ReceptionistId = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistid;
         AssignAttri(sPrefix, false, "AV13ReceptionistId", AV13ReceptionistId.ToString());
         AV14ReceptionistGivenName = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistgivenname;
         AssignAttri(sPrefix, false, "AV14ReceptionistGivenName", AV14ReceptionistGivenName);
         AV15ReceptionistLastName = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistlastname;
         AssignAttri(sPrefix, false, "AV15ReceptionistLastName", AV15ReceptionistLastName);
         AV47FileName = AV11WizardData.gxTpr_Step2.gxTpr_Filename;
         AssignAttri(sPrefix, false, "AV47FileName", AV47FileName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILENAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47FileName, "")), context));
         AV48ReceptionistImageVar = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistimagevar;
         AssignAttri(sPrefix, false, "AV48ReceptionistImageVar", AV48ReceptionistImageVar);
         AV19SDT_Receptionists = AV11WizardData.gxTpr_Step2.gxTpr_Sdt_receptionists;
         gx_BV83 = true;
      }

      protected void S152( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistemail = AV16ReceptionistEmail;
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistphone = AV17ReceptionistPhone;
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistphonenumber = AV38ReceptionistPhoneNumber;
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistphonecode = AV35ReceptionistPhoneCode;
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistid = AV13ReceptionistId;
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistgivenname = AV14ReceptionistGivenName;
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistlastname = AV15ReceptionistLastName;
         AV11WizardData.gxTpr_Step2.gxTpr_Filename = AV47FileName;
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistimagevar = AV48ReceptionistImageVar;
         AV11WizardData.gxTpr_Step2.gxTpr_Sdt_receptionists = AV19SDT_Receptionists;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S162( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         AV23ErrorMessages.Clear();
         AV24Trn_Location = new SdtTrn_Location(context);
         AV24Trn_Location.gxTpr_Locationid = AV11WizardData.gxTpr_Step1.gxTpr_Locationid;
         AV24Trn_Location.gxTpr_Locationname = AV11WizardData.gxTpr_Step1.gxTpr_Locationname;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ImageFile2)) )
         {
            AV24Trn_Location.gxTpr_Locationimage = AV61ImageFile2;
            AV24Trn_Location.gxTpr_Locationimage_gxi = GXDbFile.GetUriFromFile( "", "", AV61ImageFile2);
         }
         AV24Trn_Location.gxTpr_Organisationid = AV63OrganisationId;
         AV24Trn_Location.gxTpr_Locationemail = AV11WizardData.gxTpr_Step1.gxTpr_Locationemail;
         AV24Trn_Location.gxTpr_Locationphone = AV11WizardData.gxTpr_Step1.gxTpr_Locationphone;
         AV24Trn_Location.gxTpr_Locationphonecode = AV11WizardData.gxTpr_Step1.gxTpr_Locationphonecode;
         AV24Trn_Location.gxTpr_Locationphonenumber = AV11WizardData.gxTpr_Step1.gxTpr_Locationphonenumber;
         AV24Trn_Location.gxTpr_Locationcity = AV11WizardData.gxTpr_Step1.gxTpr_Locationcity;
         AV24Trn_Location.gxTpr_Locationcountry = AV11WizardData.gxTpr_Step1.gxTpr_Locationcountry;
         AV24Trn_Location.gxTpr_Locationzipcode = AV11WizardData.gxTpr_Step1.gxTpr_Locationzipcode;
         AV24Trn_Location.gxTpr_Locationaddressline1 = AV11WizardData.gxTpr_Step1.gxTpr_Locationaddressline1;
         AV24Trn_Location.gxTpr_Locationaddressline2 = AV11WizardData.gxTpr_Step1.gxTpr_Locationaddressline2;
         AV24Trn_Location.gxTpr_Locationdescription = AV11WizardData.gxTpr_Step1.gxTpr_Locationdescription;
         if ( AV66SDT_FileUploadData.FromJSonString(AV11WizardData.gxTpr_Step1.gxTpr_Locationimagevar, null) )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_FileUploadData)AV66SDT_FileUploadData.Item(1)).gxTpr_File)) )
            {
               AV46ImageFile = "";
               AV64base64String = GxRegex.Split(((SdtSDT_FileUploadData)AV66SDT_FileUploadData.Item(1)).gxTpr_File,",").GetString(2);
               AV46ImageFile=context.FileFromBase64( AV64base64String) ;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46ImageFile)) )
               {
                  AV24Trn_Location.gxTpr_Locationimage = AV46ImageFile;
                  AV24Trn_Location.gxTpr_Locationimage_gxi = GXDbFile.GetUriFromFile( "", "", AV46ImageFile);
               }
            }
         }
         AV25isLocationInserted = AV24Trn_Location.Insert();
         if ( AV25isLocationInserted )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11WizardData.gxTpr_Step1.gxTpr_Locationimagevar)) )
            {
               if ( AV66SDT_FileUploadData.FromJSonString(AV11WizardData.gxTpr_Step1.gxTpr_Locationimagevar, null) )
               {
                  AV85GXV15 = 1;
                  while ( AV85GXV15 <= AV66SDT_FileUploadData.Count )
                  {
                     AV65File = ((SdtSDT_FileUploadData)AV66SDT_FileUploadData.Item(AV85GXV15));
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65File.gxTpr_File)) )
                     {
                        AV46ImageFile = "";
                        AV64base64String = GxRegex.Split(AV65File.gxTpr_File,",").GetString(2);
                        AV46ImageFile=context.FileFromBase64( AV64base64String) ;
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46ImageFile)) )
                        {
                           AV67Trn_LocationImage = new SdtTrn_LocationImage(context);
                           AV67Trn_LocationImage.gxTpr_Organisationlocationid = AV24Trn_Location.gxTpr_Locationid;
                           AV67Trn_LocationImage.gxTpr_Organisationlocationimage = AV46ImageFile;
                           AV67Trn_LocationImage.gxTpr_Organisationlocationimage_gxi = GXDbFile.GetUriFromFile( "", "", AV46ImageFile);
                           AV67Trn_LocationImage.Insert();
                        }
                     }
                     AV85GXV15 = (int)(AV85GXV15+1);
                  }
               }
            }
            AV69ReceptionistBlob = "";
            AV86GXV16 = 1;
            while ( AV86GXV16 <= AV19SDT_Receptionists.Count )
            {
               AV21SDT_Receptionist = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV86GXV16));
               AV26Trn_Receptionist.gxTpr_Receptionistid = AV21SDT_Receptionist.gxTpr_Receptionistid;
               AV26Trn_Receptionist.gxTpr_Receptionistgivenname = AV21SDT_Receptionist.gxTpr_Receptionistgivenname;
               AV26Trn_Receptionist.gxTpr_Receptionistlastname = AV21SDT_Receptionist.gxTpr_Receptionistlastname;
               AV26Trn_Receptionist.gxTpr_Receptionistemail = AV21SDT_Receptionist.gxTpr_Receptionistemail;
               AV26Trn_Receptionist.gxTpr_Receptionistphone = AV21SDT_Receptionist.gxTpr_Receptionistphone;
               AV26Trn_Receptionist.gxTpr_Receptionistphonecode = AV21SDT_Receptionist.gxTpr_Receptionistphonecode;
               AV26Trn_Receptionist.gxTpr_Receptionistphonenumber = AV21SDT_Receptionist.gxTpr_Receptionistphonenumber;
               AV26Trn_Receptionist.gxTpr_Receptionistimage = AV69ReceptionistBlob;
               AV26Trn_Receptionist.gxTpr_Receptionistimage_gxi = GXDbFile.GetUriFromFile( "", "", AV69ReceptionistBlob);
               AV26Trn_Receptionist.gxTpr_Receptionistgamguid = Guid.NewGuid( ).ToString();
               AV26Trn_Receptionist.gxTpr_Locationid = AV24Trn_Location.gxTpr_Locationid;
               AV27isReceptionistInserted = AV26Trn_Receptionist.Insert();
               if ( ! AV27isReceptionistInserted )
               {
                  AV88GXV18 = 1;
                  AV87GXV17 = AV54Trn_Manager.GetMessages();
                  while ( AV88GXV18 <= AV87GXV17.Count )
                  {
                     AV28Error = ((GeneXus.Utils.SdtMessages_Message)AV87GXV17.Item(AV88GXV18));
                     AV23ErrorMessages.Add(AV28Error, 0);
                     AV88GXV18 = (int)(AV88GXV18+1);
                  }
               }
               else
               {
                  GXt_char2 = AV26Trn_Receptionist.gxTpr_Receptionistgamguid;
                  new prc_creategamuseraccountnocommit(context ).execute(  AV26Trn_Receptionist.gxTpr_Receptionistemail,  AV26Trn_Receptionist.gxTpr_Receptionistgivenname,  AV26Trn_Receptionist.gxTpr_Receptionistlastname,  "Receptionist", ref  GXt_char2, ref  AV55GAMErrorCollection, ref  AV53isSuccessful) ;
                  AV26Trn_Receptionist.gxTpr_Receptionistgamguid = GXt_char2;
                  AssignAttri(sPrefix, false, "AV53isSuccessful", AV53isSuccessful);
                  if ( AV55GAMErrorCollection.Count == 0 )
                  {
                     GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  context.GetMessage( "Invitation sent successfully", ""),  "success",  "",  "true",  ""));
                  }
                  AV89GXV19 = 1;
                  while ( AV89GXV19 <= AV55GAMErrorCollection.Count )
                  {
                     AV56GAMErrorItem = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV55GAMErrorCollection.Item(AV89GXV19));
                     AV28Error = new GeneXus.Utils.SdtMessages_Message(context);
                     AV28Error.gxTpr_Id = Guid.NewGuid( ).ToString();
                     AV28Error.gxTpr_Type = 1;
                     AV28Error.gxTpr_Description = AV56GAMErrorItem.gxTpr_Message;
                     AV23ErrorMessages.Add(AV28Error, 0);
                     AV89GXV19 = (int)(AV89GXV19+1);
                  }
               }
               AV86GXV16 = (int)(AV86GXV16+1);
            }
            if ( AV23ErrorMessages.Count > 0 )
            {
               context.RollbackDataStores("wp_createlocationandreceptioniststep2",pr_default);
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S212 ();
               if (returnInSub) return;
            }
            else
            {
               context.CommitDataStores("wp_createlocationandreceptioniststep2",pr_default);
               AV19SDT_Receptionists.Clear();
               gx_BV83 = true;
               /* Execute user subroutine: 'CLEARFORMVALUES' */
               S182 ();
               if (returnInSub) return;
               AV5WebSession.Remove(AV6WebSessionKey);
               AV5WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Inserted successfully", ""));
               CallWebObject(formatLink("trn_locationww.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else
         {
            AV23ErrorMessages = AV24Trn_Location.GetMessages();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S212 ();
            if (returnInSub) return;
         }
      }

      protected void S192( )
      {
         /* 'DO UUPDATE' Routine */
         returnInSub = false;
         AV16ReceptionistEmail = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem)).gxTpr_Receptionistemail;
         AssignAttri(sPrefix, false, "AV16ReceptionistEmail", AV16ReceptionistEmail);
         AV14ReceptionistGivenName = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem)).gxTpr_Receptionistgivenname;
         AssignAttri(sPrefix, false, "AV14ReceptionistGivenName", AV14ReceptionistGivenName);
         AV15ReceptionistLastName = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem)).gxTpr_Receptionistlastname;
         AssignAttri(sPrefix, false, "AV15ReceptionistLastName", AV15ReceptionistLastName);
         AV17ReceptionistPhone = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem)).gxTpr_Receptionistphone;
         AssignAttri(sPrefix, false, "AV17ReceptionistPhone", AV17ReceptionistPhone);
         AV38ReceptionistPhoneNumber = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem)).gxTpr_Receptionistphonenumber;
         AssignAttri(sPrefix, false, "AV38ReceptionistPhoneNumber", AV38ReceptionistPhoneNumber);
         AV13ReceptionistId = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem)).gxTpr_Receptionistid;
         AssignAttri(sPrefix, false, "AV13ReceptionistId", AV13ReceptionistId.ToString());
         AV52IndexToEdit = (short)(AV19SDT_Receptionists.IndexOf(((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem))));
         if ( AV52IndexToEdit == AV19SDT_Receptionists.Count )
         {
            AV19SDT_Receptionists.RemoveItem(AV52IndexToEdit);
            gx_BV83 = true;
            AV11WizardData.gxTpr_Step2.gxTpr_Sdt_receptionists = AV19SDT_Receptionists;
         }
         else
         {
            AV19SDT_Receptionists.RemoveItem(AV52IndexToEdit);
            gx_BV83 = true;
            AV11WizardData.gxTpr_Step2.gxTpr_Sdt_receptionists = AV19SDT_Receptionists;
         }
      }

      protected void S202( )
      {
         /* 'DO UDELETE' Routine */
         returnInSub = false;
         AV19SDT_Receptionists.RemoveItem(AV19SDT_Receptionists.IndexOf(((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem))));
         gx_BV83 = true;
         AV11WizardData.gxTpr_Step2.gxTpr_Sdt_receptionists = AV19SDT_Receptionists;
      }

      protected void S172( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV18CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14ReceptionistGivenName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "First Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavReceptionistgivenname_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15ReceptionistLastName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Last Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavReceptionistlastname_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16ReceptionistEmail)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavReceptionistemail_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38ReceptionistPhoneNumber)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Receptionist Phone Number", ""), "", "", "", "", "", "", "", ""),  "error",  edtavReceptionistphonenumber_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ReceptionistEmail)) && ! GxRegex.IsMatch(AV16ReceptionistEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ReceptionistPhoneNumber)) && ! GxRegex.IsMatch(AV38ReceptionistPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) )
         {
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
      }

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divUnnamedtable7_Visible = (((1==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divUnnamedtable7_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable7_Visible), 5, 0), true);
      }

      protected void S122( )
      {
         /* 'LOADCOMBORECEPTIONISTPHONECODE' Routine */
         returnInSub = false;
         AV91GXV21 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV90GXV20;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV90GXV20 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV91GXV21 <= AV90GXV20.Count )
         {
            AV37ReceptionistPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV90GXV20.Item(AV91GXV21));
            AV29Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV29Combo_DataItem.gxTpr_Id = AV37ReceptionistPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV31ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV31ComboTitles.Add(AV37ReceptionistPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV31ComboTitles.Add(AV37ReceptionistPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV29Combo_DataItem.gxTpr_Title = AV31ComboTitles.ToJSonString(false);
            AV36ReceptionistPhoneCode_Data.Add(AV29Combo_DataItem, 0);
            AV91GXV21 = (int)(AV91GXV21+1);
         }
         AV36ReceptionistPhoneCode_Data.Sort("Title");
         Combo_receptionistphonecode_Selectedvalue_set = AV35ReceptionistPhoneCode;
         ucCombo_receptionistphonecode.SendProperty(context, sPrefix, false, Combo_receptionistphonecode_Internalname, "SelectedValue_set", Combo_receptionistphonecode_Selectedvalue_set);
      }

      protected void E16662( )
      {
         /* Receptionistemail_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV16ReceptionistEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Email is incorrect", ""),  "error",  edtavReceptionistemail_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E17662( )
      {
         /* Receptionistphonenumber_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV38ReceptionistPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ReceptionistPhoneNumber)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Phone contains 9 digits", ""),  "error",  edtavReceptionistphonenumber_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void S182( )
      {
         /* 'CLEARFORMVALUES' Routine */
         returnInSub = false;
         AV16ReceptionistEmail = "";
         AssignAttri(sPrefix, false, "AV16ReceptionistEmail", AV16ReceptionistEmail);
         AV14ReceptionistGivenName = "";
         AssignAttri(sPrefix, false, "AV14ReceptionistGivenName", AV14ReceptionistGivenName);
         AV15ReceptionistLastName = "";
         AssignAttri(sPrefix, false, "AV15ReceptionistLastName", AV15ReceptionistLastName);
         AV17ReceptionistPhone = "";
         AssignAttri(sPrefix, false, "AV17ReceptionistPhone", AV17ReceptionistPhone);
         AV38ReceptionistPhoneNumber = "";
         AssignAttri(sPrefix, false, "AV38ReceptionistPhoneNumber", AV38ReceptionistPhoneNumber);
         AV13ReceptionistId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV13ReceptionistId", AV13ReceptionistId.ToString());
      }

      protected void S212( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV92GXV22 = 1;
         while ( AV92GXV22 <= AV23ErrorMessages.Count )
         {
            AV28Error = ((GeneXus.Utils.SdtMessages_Message)AV23ErrorMessages.Item(AV92GXV22));
            GX_msglist.addItem(context.GetMessage( "Error: ", "")+AV28Error.gxTpr_Description);
            AV92GXV22 = (int)(AV92GXV22+1);
         }
      }

      protected void wb_table2_113_662( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btnuseraction1_Internalname, tblTabledvelop_confirmpanel_btnuseraction1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btnuseraction1.SetProperty("Title", Dvelop_confirmpanel_btnuseraction1_Title);
            ucDvelop_confirmpanel_btnuseraction1.SetProperty("ConfirmationText", Dvelop_confirmpanel_btnuseraction1_Confirmationtext);
            ucDvelop_confirmpanel_btnuseraction1.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btnuseraction1_Yesbuttoncaption);
            ucDvelop_confirmpanel_btnuseraction1.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btnuseraction1_Nobuttoncaption);
            ucDvelop_confirmpanel_btnuseraction1.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btnuseraction1_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btnuseraction1.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btnuseraction1_Yesbuttonposition);
            ucDvelop_confirmpanel_btnuseraction1.SetProperty("ConfirmType", Dvelop_confirmpanel_btnuseraction1_Confirmtype);
            ucDvelop_confirmpanel_btnuseraction1.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btnuseraction1_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_BTNUSERACTION1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_BTNUSERACTION1Container"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_113_662e( true) ;
         }
         else
         {
            wb_table2_113_662e( false) ;
         }
      }

      protected void wb_table1_34_662( bool wbgen )
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
            ucUsercontrol1.SetProperty("UploadedFiles", AV43UploadedFiles);
            ucUsercontrol1.SetProperty("FailedFiles", AV44FailedFiles);
            ucUsercontrol1.Render(context, "fileupload", Usercontrol1_Internalname, sPrefix+"USERCONTROL1Container");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilename_Internalname, context.GetMessage( "File Name", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilename_Internalname, AV47FileName, StringUtil.RTrim( context.localUtil.Format( AV47FileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilename_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUseractiondelete_Internalname, context.GetMessage( "<i class=\"fas fa-trash-can\"></i>", ""), "", "", lblUseractiondelete_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e22661_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 1, "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_34_662e( true) ;
         }
         else
         {
            wb_table1_34_662e( false) ;
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
         AV63OrganisationId = (Guid)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV63OrganisationId", AV63OrganisationId.ToString());
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
         PA662( ) ;
         WS662( ) ;
         WE662( ) ;
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
         sCtrlAV63OrganisationId = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA662( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createlocationandreceptioniststep2", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA662( ) ;
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
            AV63OrganisationId = (Guid)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV63OrganisationId", AV63OrganisationId.ToString());
         }
         wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
         wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
         wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
         wcpOAV63OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV63OrganisationId"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6WebSessionKey, wcpOAV6WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV8PreviousStep, wcpOAV8PreviousStep) != 0 ) || ( AV7GoingBack != wcpOAV7GoingBack ) || ( AV63OrganisationId != wcpOAV63OrganisationId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6WebSessionKey = AV6WebSessionKey;
         wcpOAV8PreviousStep = AV8PreviousStep;
         wcpOAV7GoingBack = AV7GoingBack;
         wcpOAV63OrganisationId = AV63OrganisationId;
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
         sCtrlAV63OrganisationId = cgiGet( sPrefix+"AV63OrganisationId_CTRL");
         if ( StringUtil.Len( sCtrlAV63OrganisationId) > 0 )
         {
            AV63OrganisationId = StringUtil.StrToGuid( cgiGet( sCtrlAV63OrganisationId));
            AssignAttri(sPrefix, false, "AV63OrganisationId", AV63OrganisationId.ToString());
         }
         else
         {
            AV63OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV63OrganisationId_PARM"));
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
         PA662( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS662( ) ;
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
         WS662( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV63OrganisationId_PARM", AV63OrganisationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV63OrganisationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV63OrganisationId_CTRL", StringUtil.RTrim( sCtrlAV63OrganisationId));
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
         WE662( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309445922", true, true);
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
         context.AddJavascriptSource("wp_createlocationandreceptioniststep2.js", "?20256309445926", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_832( )
      {
         edtavSdt_receptionists__receptionistid_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTID_"+sGXsfl_83_idx;
         edtavSdt_receptionists__organisationid_Internalname = sPrefix+"SDT_RECEPTIONISTS__ORGANISATIONID_"+sGXsfl_83_idx;
         edtavSdt_receptionists__locationid_Internalname = sPrefix+"SDT_RECEPTIONISTS__LOCATIONID_"+sGXsfl_83_idx;
         edtavSdt_receptionists__receptionistgivenname_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME_"+sGXsfl_83_idx;
         edtavSdt_receptionists__receptionistlastname_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME_"+sGXsfl_83_idx;
         edtavSdt_receptionists__receptionistemail_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTEMAIL_"+sGXsfl_83_idx;
         edtavSdt_receptionists__receptionistphone_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONE_"+sGXsfl_83_idx;
         edtavSdt_receptionists__receptionistphonecode_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONECODE_"+sGXsfl_83_idx;
         edtavSdt_receptionists__receptionistphonenumber_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONENUMBER_"+sGXsfl_83_idx;
         edtavSdt_receptionists__receptioniststatus_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTSTATUS_"+sGXsfl_83_idx;
         chkavSdt_receptionists__receptionistisactive_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTISACTIVE_"+sGXsfl_83_idx;
         edtavSdt_receptionists__receptionistgamguid_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTGAMGUID_"+sGXsfl_83_idx;
         cmbavGridactiongroup1_Internalname = sPrefix+"vGRIDACTIONGROUP1_"+sGXsfl_83_idx;
      }

      protected void SubsflControlProps_fel_832( )
      {
         edtavSdt_receptionists__receptionistid_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTID_"+sGXsfl_83_fel_idx;
         edtavSdt_receptionists__organisationid_Internalname = sPrefix+"SDT_RECEPTIONISTS__ORGANISATIONID_"+sGXsfl_83_fel_idx;
         edtavSdt_receptionists__locationid_Internalname = sPrefix+"SDT_RECEPTIONISTS__LOCATIONID_"+sGXsfl_83_fel_idx;
         edtavSdt_receptionists__receptionistgivenname_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME_"+sGXsfl_83_fel_idx;
         edtavSdt_receptionists__receptionistlastname_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME_"+sGXsfl_83_fel_idx;
         edtavSdt_receptionists__receptionistemail_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTEMAIL_"+sGXsfl_83_fel_idx;
         edtavSdt_receptionists__receptionistphone_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONE_"+sGXsfl_83_fel_idx;
         edtavSdt_receptionists__receptionistphonecode_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONECODE_"+sGXsfl_83_fel_idx;
         edtavSdt_receptionists__receptionistphonenumber_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONENUMBER_"+sGXsfl_83_fel_idx;
         edtavSdt_receptionists__receptioniststatus_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTSTATUS_"+sGXsfl_83_fel_idx;
         chkavSdt_receptionists__receptionistisactive_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTISACTIVE_"+sGXsfl_83_fel_idx;
         edtavSdt_receptionists__receptionistgamguid_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTGAMGUID_"+sGXsfl_83_fel_idx;
         cmbavGridactiongroup1_Internalname = sPrefix+"vGRIDACTIONGROUP1_"+sGXsfl_83_fel_idx;
      }

      protected void sendrow_832( )
      {
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_832( ) ;
         WB660( ) ;
         if ( ( subGridsdt_receptionistss_Rows * 1 == 0 ) || ( nGXsfl_83_idx <= subGridsdt_receptionistss_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridsdt_receptionistssRow = GXWebRow.GetNew(context,Gridsdt_receptionistssContainer);
            if ( subGridsdt_receptionistss_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsdt_receptionistss_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsdt_receptionistss_Class, "") != 0 )
               {
                  subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Odd";
               }
            }
            else if ( subGridsdt_receptionistss_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsdt_receptionistss_Backstyle = 0;
               subGridsdt_receptionistss_Backcolor = subGridsdt_receptionistss_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsdt_receptionistss_Class, "") != 0 )
               {
                  subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Uniform";
               }
            }
            else if ( subGridsdt_receptionistss_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsdt_receptionistss_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsdt_receptionistss_Class, "") != 0 )
               {
                  subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Odd";
               }
               subGridsdt_receptionistss_Backcolor = (int)(0x0);
            }
            else if ( subGridsdt_receptionistss_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsdt_receptionistss_Backstyle = 1;
               if ( ((int)((nGXsfl_83_idx) % (2))) == 0 )
               {
                  subGridsdt_receptionistss_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_receptionistss_Class, "") != 0 )
                  {
                     subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Even";
                  }
               }
               else
               {
                  subGridsdt_receptionistss_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_receptionistss_Class, "") != 0 )
                  {
                     subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Odd";
                  }
               }
            }
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_83_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistid_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Receptionistid.ToString(),((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Receptionistid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__receptionistid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)83,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__organisationid_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Organisationid.ToString(),((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Organisationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__organisationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__organisationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)83,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__locationid_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Locationid.ToString(),((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Locationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__locationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__locationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)83,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',83)\"";
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistgivenname_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Receptionistgivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistgivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_receptionists__receptionistgivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',83)\"";
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistlastname_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Receptionistlastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistlastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_receptionists__receptionistlastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',83)\"";
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistemail_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Receptionistemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_receptionists__receptionistemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',83)\"";
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistphone_Internalname,StringUtil.RTrim( ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Receptionistphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_receptionists__receptionistphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistphonecode_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Receptionistphonecode,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistphonecode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__receptionistphonecode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistphonenumber_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Receptionistphonenumber,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistphonenumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__receptionistphonenumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptioniststatus_Internalname,StringUtil.RTrim( ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Receptioniststatus),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptioniststatus_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__receptioniststatus_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "SDT_RECEPTIONISTS__RECEPTIONISTISACTIVE_" + sGXsfl_83_idx;
            chkavSdt_receptionists__receptionistisactive.Name = GXCCtl;
            chkavSdt_receptionists__receptionistisactive.WebTags = "";
            chkavSdt_receptionists__receptionistisactive.Caption = "";
            AssignProp(sPrefix, false, chkavSdt_receptionists__receptionistisactive_Internalname, "TitleCaption", chkavSdt_receptionists__receptionistisactive.Caption, !bGXsfl_83_Refreshing);
            chkavSdt_receptionists__receptionistisactive.CheckedValue = "false";
            Gridsdt_receptionistssRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavSdt_receptionists__receptionistisactive_Internalname,StringUtil.BoolToStr( ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Receptionistisactive),(string)"",(string)"",(short)0,chkavSdt_receptionists__receptionistisactive.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistgamguid_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV70GXV1)).gxTpr_Receptionistgamguid,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistgamguid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__receptionistgamguid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)83,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'" + sGXsfl_83_idx + "',83)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_83_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  if ( ( AV70GXV1 > 0 ) && ( AV19SDT_Receptionists.Count >= AV70GXV1 ) && (0==AV60GridActionGroup1) )
                  {
                     AV60GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                     AssignAttri(sPrefix, false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV60GridActionGroup1), 4, 0));
                  }
               }
            }
            /* ComboBox */
            Gridsdt_receptionistssRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_83_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridActionGroup1), 4, 0));
            AssignProp(sPrefix, false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_83_Refreshing);
            send_integrity_lvl_hashes662( ) ;
            Gridsdt_receptionistssContainer.AddRow(Gridsdt_receptionistssRow);
            nGXsfl_83_idx = ((subGridsdt_receptionistss_Islastpage==1)&&(nGXsfl_83_idx+1>subGridsdt_receptionistss_fnc_Recordsperpage( )) ? 1 : nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_832( ) ;
         }
         /* End function sendrow_832 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "SDT_RECEPTIONISTS__RECEPTIONISTISACTIVE_" + sGXsfl_83_idx;
         chkavSdt_receptionists__receptionistisactive.Name = GXCCtl;
         chkavSdt_receptionists__receptionistisactive.WebTags = "";
         chkavSdt_receptionists__receptionistisactive.Caption = "";
         AssignProp(sPrefix, false, chkavSdt_receptionists__receptionistisactive_Internalname, "TitleCaption", chkavSdt_receptionists__receptionistisactive.Caption, !bGXsfl_83_Refreshing);
         chkavSdt_receptionists__receptionistisactive.CheckedValue = "false";
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_83_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            if ( ( AV70GXV1 > 0 ) && ( AV19SDT_Receptionists.Count >= AV70GXV1 ) && (0==AV60GridActionGroup1) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl83( )
      {
         if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_receptionistssContainer"+"DivS\" data-gxgridid=\"83\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridsdt_receptionistss_Internalname, subGridsdt_receptionistss_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridsdt_receptionistss_Backcolorstyle == 0 )
            {
               subGridsdt_receptionistss_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridsdt_receptionistss_Class) > 0 )
               {
                  subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Title";
               }
            }
            else
            {
               subGridsdt_receptionistss_Titlebackstyle = 1;
               if ( subGridsdt_receptionistss_Backcolorstyle == 1 )
               {
                  subGridsdt_receptionistss_Titlebackcolor = subGridsdt_receptionistss_Allbackcolor;
                  if ( StringUtil.Len( subGridsdt_receptionistss_Class) > 0 )
                  {
                     subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridsdt_receptionistss_Class) > 0 )
                  {
                     subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Receptionist Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Organisation Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "First Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone Code", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Status", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Receptionist Is Active", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Receptionist GAMGUID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridsdt_receptionistssContainer.AddObjectProperty("GridName", "Gridsdt_receptionistss");
         }
         else
         {
            Gridsdt_receptionistssContainer.AddObjectProperty("GridName", "Gridsdt_receptionistss");
            Gridsdt_receptionistssContainer.AddObjectProperty("Header", subGridsdt_receptionistss_Header);
            Gridsdt_receptionistssContainer.AddObjectProperty("Class", "WorkWith");
            Gridsdt_receptionistssContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Backcolorstyle), 1, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("CmpContext", sPrefix);
            Gridsdt_receptionistssContainer.AddObjectProperty("InMasterPage", "false");
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistid_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__organisationid_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__locationid_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistgivenname_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistlastname_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistemail_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistphone_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistphonecode_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistphonenumber_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptioniststatus_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavSdt_receptionists__receptionistisactive.Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistgamguid_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60GridActionGroup1), 4, 0, ".", ""))));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Selectedindex), 4, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Allowselection), 1, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Selectioncolor), 9, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Allowhovering), 1, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Hoveringcolor), 9, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Allowcollapsing), 1, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavReceptionistgivenname_Internalname = sPrefix+"vRECEPTIONISTGIVENNAME";
         edtavReceptionistlastname_Internalname = sPrefix+"vRECEPTIONISTLASTNAME";
         lblProductserviceimagetext_Internalname = sPrefix+"PRODUCTSERVICEIMAGETEXT";
         Usercontrol1_Internalname = sPrefix+"USERCONTROL1";
         edtavFilename_Internalname = sPrefix+"vFILENAME";
         lblUseractiondelete_Internalname = sPrefix+"USERACTIONDELETE";
         tblTablemergedusercontrol1_Internalname = sPrefix+"TABLEMERGEDUSERCONTROL1";
         divUcfilecell_Internalname = sPrefix+"UCFILECELL";
         edtavReceptionistimagevar_Internalname = sPrefix+"vRECEPTIONISTIMAGEVAR";
         divUnnamedtable7_Internalname = sPrefix+"UNNAMEDTABLE7";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         edtavReceptionistemail_Internalname = sPrefix+"vRECEPTIONISTEMAIL";
         lblPhonelabel_Internalname = sPrefix+"PHONELABEL";
         Combo_receptionistphonecode_Internalname = sPrefix+"COMBO_RECEPTIONISTPHONECODE";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         edtavReceptionistphonenumber_Internalname = sPrefix+"vRECEPTIONISTPHONENUMBER";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         divUnnamedtable4_Internalname = sPrefix+"UNNAMEDTABLE4";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divFormtable_Internalname = sPrefix+"FORMTABLE";
         grpReceptionistgroup_Internalname = sPrefix+"RECEPTIONISTGROUP";
         bttBtnuinsert_Internalname = sPrefix+"BTNUINSERT";
         edtavSdt_receptionists__receptionistid_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTID";
         edtavSdt_receptionists__organisationid_Internalname = sPrefix+"SDT_RECEPTIONISTS__ORGANISATIONID";
         edtavSdt_receptionists__locationid_Internalname = sPrefix+"SDT_RECEPTIONISTS__LOCATIONID";
         edtavSdt_receptionists__receptionistgivenname_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME";
         edtavSdt_receptionists__receptionistlastname_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME";
         edtavSdt_receptionists__receptionistemail_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTEMAIL";
         edtavSdt_receptionists__receptionistphone_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONE";
         edtavSdt_receptionists__receptionistphonecode_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONECODE";
         edtavSdt_receptionists__receptionistphonenumber_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONENUMBER";
         edtavSdt_receptionists__receptioniststatus_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTSTATUS";
         chkavSdt_receptionists__receptionistisactive_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTISACTIVE";
         edtavSdt_receptionists__receptionistgamguid_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTGAMGUID";
         cmbavGridactiongroup1_Internalname = sPrefix+"vGRIDACTIONGROUP1";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardlastnext_Internalname = sPrefix+"BTNWIZARDLASTNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         bttBtnuseraction1_Internalname = sPrefix+"BTNUSERACTION1";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavReceptionistphonecode_Internalname = sPrefix+"vRECEPTIONISTPHONECODE";
         edtavReceptionistphone_Internalname = sPrefix+"vRECEPTIONISTPHONE";
         edtavReceptionistid_Internalname = sPrefix+"vRECEPTIONISTID";
         Dvelop_confirmpanel_btnuseraction1_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_BTNUSERACTION1";
         tblTabledvelop_confirmpanel_btnuseraction1_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_BTNUSERACTION1";
         Gridsdt_receptionistss_empowerer_Internalname = sPrefix+"GRIDSDT_RECEPTIONISTSS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridsdt_receptionistss_Internalname = sPrefix+"GRIDSDT_RECEPTIONISTSS";
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
         subGridsdt_receptionistss_Allowcollapsing = 0;
         subGridsdt_receptionistss_Allowselection = 0;
         subGridsdt_receptionistss_Header = "";
         cmbavGridactiongroup1_Jsonclick = "";
         edtavSdt_receptionists__receptionistgamguid_Jsonclick = "";
         edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
         chkavSdt_receptionists__receptionistisactive.Caption = "";
         chkavSdt_receptionists__receptionistisactive.Enabled = 0;
         edtavSdt_receptionists__receptioniststatus_Jsonclick = "";
         edtavSdt_receptionists__receptioniststatus_Enabled = 0;
         edtavSdt_receptionists__receptionistphonenumber_Jsonclick = "";
         edtavSdt_receptionists__receptionistphonenumber_Enabled = 0;
         edtavSdt_receptionists__receptionistphonecode_Jsonclick = "";
         edtavSdt_receptionists__receptionistphonecode_Enabled = 0;
         edtavSdt_receptionists__receptionistphone_Jsonclick = "";
         edtavSdt_receptionists__receptionistphone_Enabled = 0;
         edtavSdt_receptionists__receptionistemail_Jsonclick = "";
         edtavSdt_receptionists__receptionistemail_Enabled = 0;
         edtavSdt_receptionists__receptionistlastname_Jsonclick = "";
         edtavSdt_receptionists__receptionistlastname_Enabled = 0;
         edtavSdt_receptionists__receptionistgivenname_Jsonclick = "";
         edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
         edtavSdt_receptionists__locationid_Jsonclick = "";
         edtavSdt_receptionists__locationid_Enabled = 0;
         edtavSdt_receptionists__organisationid_Jsonclick = "";
         edtavSdt_receptionists__organisationid_Enabled = 0;
         edtavSdt_receptionists__receptionistid_Jsonclick = "";
         edtavSdt_receptionists__receptionistid_Enabled = 0;
         subGridsdt_receptionistss_Class = "WorkWith";
         subGridsdt_receptionistss_Backcolorstyle = 0;
         edtavFilename_Jsonclick = "";
         edtavFilename_Enabled = 1;
         Usercontrol1_Acceptedfiletypes = "image";
         Usercontrol1_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Usercontrol1_Maxnumberoffiles = 1;
         Usercontrol1_Maxfilesize = 134217728;
         Usercontrol1_Disableimageresize = Convert.ToBoolean( 0);
         Usercontrol1_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Usercontrol1_Tooltiptext = "";
         Usercontrol1_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Usercontrol1_Autoupload = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_btnuseraction1_Confirmtype = "1";
         Dvelop_confirmpanel_btnuseraction1_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btnuseraction1_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btnuseraction1_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btnuseraction1_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btnuseraction1_Title = context.GetMessage( "Confirm Location", "");
         Dvelop_confirmpanel_btnuseraction1_Confirmationtext = "You are creating a location without any receptionists, Are you sure you want to proceed?";
         Combo_receptionistphonecode_Htmltemplate = "";
         edtavReceptionistid_Jsonclick = "";
         edtavReceptionistid_Visible = 1;
         edtavReceptionistphone_Jsonclick = "";
         edtavReceptionistphone_Visible = 1;
         edtavReceptionistphonecode_Jsonclick = "";
         edtavReceptionistphonecode_Visible = 1;
         bttBtnuseraction1_Visible = 1;
         Btnwizardlastnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardlastnext_Caption = context.GetMessage( "WWP_WizardFinishCaption", "");
         Btnwizardlastnext_Tooltiptext = "";
         Btnwizardprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardprevious_Caption = context.GetMessage( "GXM_previous", "");
         Btnwizardprevious_Tooltiptext = "";
         edtavReceptionistphonenumber_Jsonclick = "";
         edtavReceptionistphonenumber_Enabled = 1;
         Combo_receptionistphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_receptionistphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_receptionistphonecode_Caption = "";
         edtavReceptionistemail_Jsonclick = "";
         edtavReceptionistemail_Enabled = 1;
         edtavReceptionistimagevar_Enabled = 1;
         divUnnamedtable7_Visible = 1;
         edtavReceptionistlastname_Jsonclick = "";
         edtavReceptionistlastname_Enabled = 1;
         edtavReceptionistgivenname_Jsonclick = "";
         edtavReceptionistgivenname_Enabled = 1;
         grpReceptionistgroup_Caption = context.GetMessage( "Receptionist Information", "");
         edtavSdt_receptionists__receptionistgamguid_Enabled = -1;
         chkavSdt_receptionists__receptionistisactive.Enabled = -1;
         edtavSdt_receptionists__receptioniststatus_Enabled = -1;
         edtavSdt_receptionists__receptionistphonenumber_Enabled = -1;
         edtavSdt_receptionists__receptionistphonecode_Enabled = -1;
         edtavSdt_receptionists__receptionistphone_Enabled = -1;
         edtavSdt_receptionists__receptionistemail_Enabled = -1;
         edtavSdt_receptionists__receptionistlastname_Enabled = -1;
         edtavSdt_receptionists__receptionistgivenname_Enabled = -1;
         edtavSdt_receptionists__locationid_Enabled = -1;
         edtavSdt_receptionists__organisationid_Enabled = -1;
         edtavSdt_receptionists__receptionistid_Enabled = -1;
         subGridsdt_receptionistss_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV68ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV54Trn_Manager","fld":"vTRN_MANAGER","hsh":true},{"av":"AV47FileName","fld":"vFILENAME","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"grpReceptionistgroup_Caption","ctrl":"RECEPTIONISTGROUP","prop":"Caption"},{"ctrl":"BTNUSERACTION1","prop":"Visible"}]}""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS.LOAD","""{"handler":"E20662","iparms":[]""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS.LOAD",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV60GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"}]}""");
         setEventMetadata("ENTER","""{"handler":"E13662","iparms":[{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83},{"av":"AV68ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV18CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"},{"av":"AV17ReceptionistPhone","fld":"vRECEPTIONISTPHONE"},{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"},{"av":"AV35ReceptionistPhoneCode","fld":"vRECEPTIONISTPHONECODE"},{"av":"AV13ReceptionistId","fld":"vRECEPTIONISTID"},{"av":"AV14ReceptionistGivenName","fld":"vRECEPTIONISTGIVENNAME"},{"av":"AV15ReceptionistLastName","fld":"vRECEPTIONISTLASTNAME"},{"av":"AV47FileName","fld":"vFILENAME","hsh":true},{"av":"AV48ReceptionistImageVar","fld":"vRECEPTIONISTIMAGEVAR"},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"AV61ImageFile2","fld":"vIMAGEFILE2"},{"av":"AV63OrganisationId","fld":"vORGANISATIONID"},{"av":"AV66SDT_FileUploadData","fld":"vSDT_FILEUPLOADDATA"},{"av":"AV26Trn_Receptionist","fld":"vTRN_RECEPTIONIST"},{"av":"AV54Trn_Manager","fld":"vTRN_MANAGER","hsh":true},{"av":"AV53isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV23ErrorMessages","fld":"vERRORMESSAGES"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"Dvelop_confirmpanel_btnuseraction1_Confirmationtext","ctrl":"DVELOP_CONFIRMPANEL_BTNUSERACTION1","prop":"ConfirmationText"},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"AV23ErrorMessages","fld":"vERRORMESSAGES"},{"av":"AV24Trn_Location","fld":"vTRN_LOCATION"},{"av":"AV66SDT_FileUploadData","fld":"vSDT_FILEUPLOADDATA"},{"av":"AV26Trn_Receptionist","fld":"vTRN_RECEPTIONIST"},{"av":"AV53isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83},{"av":"AV18CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"},{"av":"AV14ReceptionistGivenName","fld":"vRECEPTIONISTGIVENNAME"},{"av":"AV15ReceptionistLastName","fld":"vRECEPTIONISTLASTNAME"},{"av":"AV17ReceptionistPhone","fld":"vRECEPTIONISTPHONE"},{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"},{"av":"AV13ReceptionistId","fld":"vRECEPTIONISTID"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E14662","iparms":[{"av":"AV63OrganisationId","fld":"vORGANISATIONID"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"},{"av":"AV17ReceptionistPhone","fld":"vRECEPTIONISTPHONE"},{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"},{"av":"AV35ReceptionistPhoneCode","fld":"vRECEPTIONISTPHONECODE"},{"av":"AV13ReceptionistId","fld":"vRECEPTIONISTID"},{"av":"AV14ReceptionistGivenName","fld":"vRECEPTIONISTGIVENNAME"},{"av":"AV15ReceptionistLastName","fld":"vRECEPTIONISTLASTNAME"},{"av":"AV47FileName","fld":"vFILENAME","hsh":true},{"av":"AV48ReceptionistImageVar","fld":"vRECEPTIONISTIMAGEVAR"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV63OrganisationId","fld":"vORGANISATIONID"},{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOUINSERT'","""{"handler":"E15662","iparms":[{"av":"AV18CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83},{"av":"A93ReceptionistEmail","fld":"RECEPTIONISTEMAIL"},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"AV48ReceptionistImageVar","fld":"vRECEPTIONISTIMAGEVAR"},{"av":"AV24Trn_Location","fld":"vTRN_LOCATION"},{"av":"AV14ReceptionistGivenName","fld":"vRECEPTIONISTGIVENNAME"},{"av":"AV15ReceptionistLastName","fld":"vRECEPTIONISTLASTNAME"},{"av":"AV35ReceptionistPhoneCode","fld":"vRECEPTIONISTPHONECODE"},{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV68ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"av":"AV54Trn_Manager","fld":"vTRN_MANAGER","hsh":true},{"av":"AV47FileName","fld":"vFILENAME","hsh":true}]""");
         setEventMetadata("'DOUINSERT'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83},{"av":"AV18CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"},{"av":"AV14ReceptionistGivenName","fld":"vRECEPTIONISTGIVENNAME"},{"av":"AV15ReceptionistLastName","fld":"vRECEPTIONISTLASTNAME"},{"av":"AV17ReceptionistPhone","fld":"vRECEPTIONISTPHONE"},{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"},{"av":"AV13ReceptionistId","fld":"vRECEPTIONISTID"}]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E11661","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNUSERACTION1.CLOSE","""{"handler":"E12662","iparms":[{"av":"Dvelop_confirmpanel_btnuseraction1_Result","ctrl":"DVELOP_CONFIRMPANEL_BTNUSERACTION1","prop":"Result"},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"AV61ImageFile2","fld":"vIMAGEFILE2"},{"av":"AV63OrganisationId","fld":"vORGANISATIONID"},{"av":"AV66SDT_FileUploadData","fld":"vSDT_FILEUPLOADDATA"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83},{"av":"AV26Trn_Receptionist","fld":"vTRN_RECEPTIONIST"},{"av":"AV54Trn_Manager","fld":"vTRN_MANAGER","hsh":true},{"av":"AV53isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV23ErrorMessages","fld":"vERRORMESSAGES"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV68ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV47FileName","fld":"vFILENAME","hsh":true}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNUSERACTION1.CLOSE",""","oparms":[{"av":"AV23ErrorMessages","fld":"vERRORMESSAGES"},{"av":"AV24Trn_Location","fld":"vTRN_LOCATION"},{"av":"AV66SDT_FileUploadData","fld":"vSDT_FILEUPLOADDATA"},{"av":"AV26Trn_Receptionist","fld":"vTRN_RECEPTIONIST"},{"av":"AV53isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83},{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"},{"av":"AV14ReceptionistGivenName","fld":"vRECEPTIONISTGIVENNAME"},{"av":"AV15ReceptionistLastName","fld":"vRECEPTIONISTLASTNAME"},{"av":"AV17ReceptionistPhone","fld":"vRECEPTIONISTPHONE"},{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"},{"av":"AV13ReceptionistId","fld":"vRECEPTIONISTID"}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E21662","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV60GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV68ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV54Trn_Manager","fld":"vTRN_MANAGER","hsh":true},{"av":"AV47FileName","fld":"vFILENAME","hsh":true}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV60GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"},{"av":"AV14ReceptionistGivenName","fld":"vRECEPTIONISTGIVENNAME"},{"av":"AV15ReceptionistLastName","fld":"vRECEPTIONISTLASTNAME"},{"av":"AV17ReceptionistPhone","fld":"vRECEPTIONISTPHONE"},{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"},{"av":"AV13ReceptionistId","fld":"vRECEPTIONISTID"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83},{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOUSERACTIONDELETE'","""{"handler":"E22661","iparms":[]}""");
         setEventMetadata("VRECEPTIONISTEMAIL.CONTROLVALUECHANGED","""{"handler":"E16662","iparms":[{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"}]""");
         setEventMetadata("VRECEPTIONISTEMAIL.CONTROLVALUECHANGED",""","oparms":[{"av":"AV18CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VRECEPTIONISTPHONENUMBER.CONTROLVALUECHANGED","""{"handler":"E17662","iparms":[{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"}]""");
         setEventMetadata("VRECEPTIONISTPHONENUMBER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV18CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS_FIRSTPAGE","""{"handler":"subgridsdt_receptionistss_firstpage","iparms":[{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV54Trn_Manager","fld":"vTRN_MANAGER","hsh":true},{"av":"AV47FileName","fld":"vFILENAME","hsh":true},{"av":"sPrefix"},{"av":"AV68ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true}]""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS_FIRSTPAGE",""","oparms":[{"av":"grpReceptionistgroup_Caption","ctrl":"RECEPTIONISTGROUP","prop":"Caption"},{"ctrl":"BTNUSERACTION1","prop":"Visible"}]}""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS_PREVPAGE","""{"handler":"subgridsdt_receptionistss_previouspage","iparms":[{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV54Trn_Manager","fld":"vTRN_MANAGER","hsh":true},{"av":"AV47FileName","fld":"vFILENAME","hsh":true},{"av":"sPrefix"},{"av":"AV68ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true}]""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS_PREVPAGE",""","oparms":[{"av":"grpReceptionistgroup_Caption","ctrl":"RECEPTIONISTGROUP","prop":"Caption"},{"ctrl":"BTNUSERACTION1","prop":"Visible"}]}""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS_NEXTPAGE","""{"handler":"subgridsdt_receptionistss_nextpage","iparms":[{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV54Trn_Manager","fld":"vTRN_MANAGER","hsh":true},{"av":"AV47FileName","fld":"vFILENAME","hsh":true},{"av":"sPrefix"},{"av":"AV68ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true}]""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS_NEXTPAGE",""","oparms":[{"av":"grpReceptionistgroup_Caption","ctrl":"RECEPTIONISTGROUP","prop":"Caption"},{"ctrl":"BTNUSERACTION1","prop":"Visible"}]}""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS_LASTPAGE","""{"handler":"subgridsdt_receptionistss_lastpage","iparms":[{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":83},{"av":"nGXsfl_83_idx","ctrl":"GRID","prop":"GridCurrRow","grid":83},{"av":"nRC_GXsfl_83","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":83},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV54Trn_Manager","fld":"vTRN_MANAGER","hsh":true},{"av":"AV47FileName","fld":"vFILENAME","hsh":true},{"av":"sPrefix"},{"av":"AV68ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true}]""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS_LASTPAGE",""","oparms":[{"av":"grpReceptionistgroup_Caption","ctrl":"RECEPTIONISTGROUP","prop":"Caption"},{"ctrl":"BTNUSERACTION1","prop":"Visible"}]}""");
         setEventMetadata("VALIDV_RECEPTIONISTEMAIL","""{"handler":"Validv_Receptionistemail","iparms":[]}""");
         setEventMetadata("VALIDV_RECEPTIONISTID","""{"handler":"Validv_Receptionistid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gridactiongroup1","iparms":[]}""");
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
         wcpOAV63OrganisationId = Guid.Empty;
         Dvelop_confirmpanel_btnuseraction1_Result = "";
         Combo_receptionistphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV68ReceptionistTitle = "";
         AV54Trn_Manager = new SdtTrn_Manager(context);
         AV47FileName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         AV19SDT_Receptionists = new GXBaseCollection<SdtSDT_Receptionists_SDT_ReceptionistsItem>( context, "SDT_ReceptionistsItem", "Comforta_version2");
         AV43UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV44FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV32DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV36ReceptionistPhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV11WizardData = new SdtWP_CreateLocationAndReceptionistData(context);
         AV61ImageFile2 = "";
         AV66SDT_FileUploadData = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV26Trn_Receptionist = new SdtTrn_Receptionist(context);
         AV23ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         A93ReceptionistEmail = "";
         AV24Trn_Location = new SdtTrn_Location(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV14ReceptionistGivenName = "";
         AV15ReceptionistLastName = "";
         lblProductserviceimagetext_Jsonclick = "";
         AV48ReceptionistImageVar = "";
         AV16ReceptionistEmail = "";
         lblPhonelabel_Jsonclick = "";
         ucCombo_receptionistphonecode = new GXUserControl();
         AV38ReceptionistPhoneNumber = "";
         bttBtnuinsert_Jsonclick = "";
         Gridsdt_receptionistssContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardlastnext = new GXUserControl();
         bttBtnuseraction1_Jsonclick = "";
         AV35ReceptionistPhoneCode = "";
         AV17ReceptionistPhone = "";
         AV13ReceptionistId = Guid.Empty;
         ucGridsdt_receptionistss_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         hsh = "";
         AV5WebSession = context.GetSession();
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Gridsdt_receptionistss_empowerer_Gridinternalname = "";
         AV33defaultCountryPhoneCode = "";
         Combo_receptionistphonecode_Selectedtext_set = "";
         Combo_receptionistphonecode_Selectedvalue_set = "";
         Gridsdt_receptionistssRow = new GXWebRow();
         ucDvelop_confirmpanel_btnuseraction1 = new GXUserControl();
         AV57GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV55GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV21SDT_Receptionist = new SdtSDT_Receptionists_SDT_ReceptionistsItem(context);
         H00662_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         H00662_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00662_A29LocationId = new Guid[] {Guid.Empty} ;
         H00662_A93ReceptionistEmail = new string[] {""} ;
         AV50Image = "";
         AV46ImageFile = "";
         AV64base64String = "";
         AV65File = new SdtSDT_FileUploadData(context);
         AV67Trn_LocationImage = new SdtTrn_LocationImage(context);
         AV69ReceptionistBlob = "";
         AV87GXV17 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV28Error = new GeneXus.Utils.SdtMessages_Message(context);
         GXt_char2 = "";
         AV56GAMErrorItem = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV90GXV20 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV37ReceptionistPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV29Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV31ComboTitles = new GxSimpleCollection<string>();
         ucUsercontrol1 = new GXUserControl();
         lblUseractiondelete_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         sCtrlAV63OrganisationId = "";
         subGridsdt_receptionistss_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         Gridsdt_receptionistssColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_createlocationandreceptioniststep2__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_createlocationandreceptioniststep2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createlocationandreceptioniststep2__default(),
            new Object[][] {
                new Object[] {
               H00662_A89ReceptionistId, H00662_A11OrganisationId, H00662_A29LocationId, H00662_A93ReceptionistEmail
               }
            }
         );
         /* GeneXus formulas. */
         edtavFilename_Enabled = 0;
         edtavSdt_receptionists__receptionistid_Enabled = 0;
         edtavSdt_receptionists__organisationid_Enabled = 0;
         edtavSdt_receptionists__locationid_Enabled = 0;
         edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
         edtavSdt_receptionists__receptionistlastname_Enabled = 0;
         edtavSdt_receptionists__receptionistemail_Enabled = 0;
         edtavSdt_receptionists__receptionistphone_Enabled = 0;
         edtavSdt_receptionists__receptionistphonecode_Enabled = 0;
         edtavSdt_receptionists__receptionistphonenumber_Enabled = 0;
         edtavSdt_receptionists__receptioniststatus_Enabled = 0;
         chkavSdt_receptionists__receptionistisactive.Enabled = 0;
         edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
      }

      private short GRIDSDT_RECEPTIONISTSS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV60GridActionGroup1 ;
      private short nDonePA ;
      private short subGridsdt_receptionistss_Backcolorstyle ;
      private short AV52IndexToEdit ;
      private short nGXWrapped ;
      private short subGridsdt_receptionistss_Backstyle ;
      private short subGridsdt_receptionistss_Titlebackstyle ;
      private short subGridsdt_receptionistss_Allowselection ;
      private short subGridsdt_receptionistss_Allowhovering ;
      private short subGridsdt_receptionistss_Allowcollapsing ;
      private short subGridsdt_receptionistss_Collapsed ;
      private int nRC_GXsfl_83 ;
      private int subGridsdt_receptionistss_Rows ;
      private int nGXsfl_83_idx=1 ;
      private int edtavFilename_Enabled ;
      private int edtavSdt_receptionists__receptionistid_Enabled ;
      private int edtavSdt_receptionists__organisationid_Enabled ;
      private int edtavSdt_receptionists__locationid_Enabled ;
      private int edtavSdt_receptionists__receptionistgivenname_Enabled ;
      private int edtavSdt_receptionists__receptionistlastname_Enabled ;
      private int edtavSdt_receptionists__receptionistemail_Enabled ;
      private int edtavSdt_receptionists__receptionistphone_Enabled ;
      private int edtavSdt_receptionists__receptionistphonecode_Enabled ;
      private int edtavSdt_receptionists__receptionistphonenumber_Enabled ;
      private int edtavSdt_receptionists__receptioniststatus_Enabled ;
      private int edtavSdt_receptionists__receptionistgamguid_Enabled ;
      private int edtavReceptionistgivenname_Enabled ;
      private int edtavReceptionistlastname_Enabled ;
      private int divUnnamedtable7_Visible ;
      private int edtavReceptionistimagevar_Enabled ;
      private int edtavReceptionistemail_Enabled ;
      private int edtavReceptionistphonenumber_Enabled ;
      private int AV70GXV1 ;
      private int bttBtnuseraction1_Visible ;
      private int edtavReceptionistphonecode_Visible ;
      private int edtavReceptionistphone_Visible ;
      private int edtavReceptionistid_Visible ;
      private int subGridsdt_receptionistss_Islastpage ;
      private int GRIDSDT_RECEPTIONISTSS_nGridOutOfScope ;
      private int nGXsfl_83_fel_idx=1 ;
      private int nGXsfl_83_bak_idx=1 ;
      private int AV83GXV14 ;
      private int AV85GXV15 ;
      private int AV86GXV16 ;
      private int AV88GXV18 ;
      private int AV89GXV19 ;
      private int AV91GXV21 ;
      private int AV92GXV22 ;
      private int Usercontrol1_Maxfilesize ;
      private int Usercontrol1_Maxnumberoffiles ;
      private int idxLst ;
      private int subGridsdt_receptionistss_Backcolor ;
      private int subGridsdt_receptionistss_Allbackcolor ;
      private int subGridsdt_receptionistss_Titlebackcolor ;
      private int subGridsdt_receptionistss_Selectedindex ;
      private int subGridsdt_receptionistss_Selectioncolor ;
      private int subGridsdt_receptionistss_Hoveringcolor ;
      private long GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage ;
      private long GRIDSDT_RECEPTIONISTSS_nCurrentRecord ;
      private long GRIDSDT_RECEPTIONISTSS_nRecordCount ;
      private string Dvelop_confirmpanel_btnuseraction1_Result ;
      private string Combo_receptionistphonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_83_idx="0001" ;
      private string edtavFilename_Internalname ;
      private string edtavSdt_receptionists__receptionistid_Internalname ;
      private string edtavSdt_receptionists__organisationid_Internalname ;
      private string edtavSdt_receptionists__locationid_Internalname ;
      private string edtavSdt_receptionists__receptionistgivenname_Internalname ;
      private string edtavSdt_receptionists__receptionistlastname_Internalname ;
      private string edtavSdt_receptionists__receptionistemail_Internalname ;
      private string edtavSdt_receptionists__receptionistphone_Internalname ;
      private string edtavSdt_receptionists__receptionistphonecode_Internalname ;
      private string edtavSdt_receptionists__receptionistphonenumber_Internalname ;
      private string edtavSdt_receptionists__receptioniststatus_Internalname ;
      private string chkavSdt_receptionists__receptionistisactive_Internalname ;
      private string edtavSdt_receptionists__receptionistgamguid_Internalname ;
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
      private string grpReceptionistgroup_Internalname ;
      private string grpReceptionistgroup_Caption ;
      private string divFormtable_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtavReceptionistgivenname_Internalname ;
      private string TempTags ;
      private string edtavReceptionistgivenname_Jsonclick ;
      private string edtavReceptionistlastname_Internalname ;
      private string edtavReceptionistlastname_Jsonclick ;
      private string divUnnamedtable7_Internalname ;
      private string lblProductserviceimagetext_Internalname ;
      private string lblProductserviceimagetext_Jsonclick ;
      private string divUcfilecell_Internalname ;
      private string edtavReceptionistimagevar_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string edtavReceptionistemail_Internalname ;
      private string edtavReceptionistemail_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string lblPhonelabel_Internalname ;
      private string lblPhonelabel_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string divUnnamedtable5_Internalname ;
      private string Combo_receptionistphonecode_Caption ;
      private string Combo_receptionistphonecode_Cls ;
      private string Combo_receptionistphonecode_Internalname ;
      private string divUnnamedtable6_Internalname ;
      private string edtavReceptionistphonenumber_Internalname ;
      private string edtavReceptionistphonenumber_Jsonclick ;
      private string bttBtnuinsert_Internalname ;
      private string bttBtnuinsert_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGridsdt_receptionistss_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string Btnwizardlastnext_Tooltiptext ;
      private string Btnwizardlastnext_Caption ;
      private string Btnwizardlastnext_Class ;
      private string Btnwizardlastnext_Internalname ;
      private string bttBtnuseraction1_Internalname ;
      private string bttBtnuseraction1_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavReceptionistphonecode_Internalname ;
      private string edtavReceptionistphonecode_Jsonclick ;
      private string edtavReceptionistphone_Internalname ;
      private string AV17ReceptionistPhone ;
      private string edtavReceptionistphone_Jsonclick ;
      private string edtavReceptionistid_Internalname ;
      private string edtavReceptionistid_Jsonclick ;
      private string Gridsdt_receptionistss_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactiongroup1_Internalname ;
      private string GXDecQS ;
      private string sGXsfl_83_fel_idx="0001" ;
      private string hsh ;
      private string Combo_receptionistphonecode_Htmltemplate ;
      private string Gridsdt_receptionistss_empowerer_Gridinternalname ;
      private string Combo_receptionistphonecode_Selectedtext_set ;
      private string Combo_receptionistphonecode_Selectedvalue_set ;
      private string Dvelop_confirmpanel_btnuseraction1_Confirmationtext ;
      private string Dvelop_confirmpanel_btnuseraction1_Internalname ;
      private string GXt_char2 ;
      private string tblTabledvelop_confirmpanel_btnuseraction1_Internalname ;
      private string Dvelop_confirmpanel_btnuseraction1_Title ;
      private string Dvelop_confirmpanel_btnuseraction1_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btnuseraction1_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btnuseraction1_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btnuseraction1_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btnuseraction1_Confirmtype ;
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
      private string sCtrlAV63OrganisationId ;
      private string subGridsdt_receptionistss_Class ;
      private string subGridsdt_receptionistss_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_receptionists__receptionistid_Jsonclick ;
      private string edtavSdt_receptionists__organisationid_Jsonclick ;
      private string edtavSdt_receptionists__locationid_Jsonclick ;
      private string edtavSdt_receptionists__receptionistgivenname_Jsonclick ;
      private string edtavSdt_receptionists__receptionistlastname_Jsonclick ;
      private string edtavSdt_receptionists__receptionistemail_Jsonclick ;
      private string edtavSdt_receptionists__receptionistphone_Jsonclick ;
      private string edtavSdt_receptionists__receptionistphonecode_Jsonclick ;
      private string edtavSdt_receptionists__receptionistphonenumber_Jsonclick ;
      private string edtavSdt_receptionists__receptioniststatus_Jsonclick ;
      private string GXCCtl ;
      private string edtavSdt_receptionists__receptionistgamguid_Jsonclick ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string subGridsdt_receptionistss_Header ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool bGXsfl_83_Refreshing=false ;
      private bool AV18CheckRequiredFieldsResult ;
      private bool AV53isSuccessful ;
      private bool wbLoad ;
      private bool Combo_receptionistphonecode_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV20isAlreadyAdded ;
      private bool AV58isAlreadyExistingInGAM ;
      private bool AV22isAlreadyRegistered ;
      private bool gx_BV83 ;
      private bool AV25isLocationInserted ;
      private bool AV27isReceptionistInserted ;
      private bool Usercontrol1_Autoupload ;
      private bool Usercontrol1_Hideadditionalbuttons ;
      private bool Usercontrol1_Enableuploadedfilecanceling ;
      private bool Usercontrol1_Disableimageresize ;
      private bool Usercontrol1_Autodisableaddingfiles ;
      private string AV48ReceptionistImageVar ;
      private string AV64base64String ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV68ReceptionistTitle ;
      private string AV47FileName ;
      private string A93ReceptionistEmail ;
      private string AV14ReceptionistGivenName ;
      private string AV15ReceptionistLastName ;
      private string AV16ReceptionistEmail ;
      private string AV38ReceptionistPhoneNumber ;
      private string AV35ReceptionistPhoneCode ;
      private string AV33defaultCountryPhoneCode ;
      private Guid AV63OrganisationId ;
      private Guid wcpOAV63OrganisationId ;
      private Guid AV13ReceptionistId ;
      private string AV61ImageFile2 ;
      private string AV50Image ;
      private string AV46ImageFile ;
      private string AV69ReceptionistBlob ;
      private IGxSession AV5WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridsdt_receptionistssContainer ;
      private GXWebRow Gridsdt_receptionistssRow ;
      private GXWebColumn Gridsdt_receptionistssColumn ;
      private GXUserControl ucCombo_receptionistphonecode ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardlastnext ;
      private GXUserControl ucGridsdt_receptionistss_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_btnuseraction1 ;
      private GXUserControl ucUsercontrol1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP3_OrganisationId ;
      private GXCheckbox chkavSdt_receptionists__receptionistisactive ;
      private GXCombobox cmbavGridactiongroup1 ;
      private SdtTrn_Manager AV54Trn_Manager ;
      private GXBaseCollection<SdtSDT_Receptionists_SDT_ReceptionistsItem> AV19SDT_Receptionists ;
      private GXBaseCollection<SdtFileUploadData> AV43UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV44FailedFiles ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV32DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV36ReceptionistPhoneCode_Data ;
      private SdtWP_CreateLocationAndReceptionistData AV11WizardData ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV66SDT_FileUploadData ;
      private SdtTrn_Receptionist AV26Trn_Receptionist ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV23ErrorMessages ;
      private SdtTrn_Location AV24Trn_Location ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV57GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV55GAMErrorCollection ;
      private SdtSDT_Receptionists_SDT_ReceptionistsItem AV21SDT_Receptionist ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00662_A89ReceptionistId ;
      private Guid[] H00662_A11OrganisationId ;
      private Guid[] H00662_A29LocationId ;
      private string[] H00662_A93ReceptionistEmail ;
      private SdtSDT_FileUploadData AV65File ;
      private SdtTrn_LocationImage AV67Trn_LocationImage ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV87GXV17 ;
      private GeneXus.Utils.SdtMessages_Message AV28Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV56GAMErrorItem ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV90GXV20 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem3 ;
      private SdtSDT_Country_SDT_CountryItem AV37ReceptionistPhoneCode_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV29Combo_DataItem ;
      private GxSimpleCollection<string> AV31ComboTitles ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_createlocationandreceptioniststep2__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_createlocationandreceptioniststep2__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_createlocationandreceptioniststep2__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH00662;
       prmH00662 = new Object[] {
       new ParDef("AV16ReceptionistEmail",GXType.VarChar,100,0)
       };
       def= new CursorDef[] {
           new CursorDef("H00662", "SELECT ReceptionistId, OrganisationId, LocationId, ReceptionistEmail FROM Trn_Receptionist WHERE ReceptionistEmail = ( :AV16ReceptionistEmail) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00662,1, GxCacheFrequency.OFF ,false,true )
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
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
    }
 }

}

}
