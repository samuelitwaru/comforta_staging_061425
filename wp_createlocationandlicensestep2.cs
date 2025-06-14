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
   public class wp_createlocationandlicensestep2 : GXWebComponent
   {
      public wp_createlocationandlicensestep2( )
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

      public wp_createlocationandlicensestep2( IGxContext context )
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
         this.AV20WebSessionKey = aP0_WebSessionKey;
         this.AV17PreviousStep = aP1_PreviousStep;
         this.AV9GoingBack = aP2_GoingBack;
         this.AV16OrganisationId = aP3_OrganisationId;
         ExecuteImpl();
         aP3_OrganisationId=this.AV16OrganisationId;
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
         chkavLocationhasmycare = new GXCheckbox();
         chkavLocationhasmyliving = new GXCheckbox();
         chkavLocationhasmyservices = new GXCheckbox();
         chkavLocationhasownbrand = new GXCheckbox();
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
                  AV20WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV20WebSessionKey", AV20WebSessionKey);
                  AV17PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV17PreviousStep", AV17PreviousStep);
                  AV9GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV9GoingBack", AV9GoingBack);
                  AV16OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "AV16OrganisationId", AV16OrganisationId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV20WebSessionKey,(string)AV17PreviousStep,(bool)AV9GoingBack,(Guid)AV16OrganisationId});
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
            PAAZ2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WSAZ2( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Create Location And License Step2", "")) ;
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
         context.AddJavascriptSource("UserControls/UC_ThemeSelectorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_CtaThemeSelectorRender.js", "", false, true);
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
            GXEncryptionTmp = "wp_createlocationandlicensestep2.aspx"+UrlEncode(StringUtil.RTrim(AV20WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV17PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV9GoingBack)) + "," + UrlEncode(AV16OrganisationId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createlocationandlicensestep2.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_FILEUPLOADDATA", AV25SDT_FileUploadData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_FILEUPLOADDATA", AV25SDT_FileUploadData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_FILEUPLOADDATA", GetSecureSignedToken( sPrefix, AV25SDT_FileUploadData, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSELECTEDBRANDTHEME", AV22SelectedBrandTheme);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSELECTEDBRANDTHEME", AV22SelectedBrandTheme);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSELECTEDCTATHEME", AV23SelectedCtaTheme);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSELECTEDCTATHEME", AV23SelectedCtaTheme);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV20WebSessionKey", wcpOAV20WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV17PreviousStep", wcpOAV17PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV9GoingBack", wcpOAV9GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV16OrganisationId", wcpOAV16OrganisationId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV20WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV21WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV21WizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vIMAGEFILE2", AV11ImageFile2);
         GxWebStd.gx_hidden_field( context, sPrefix+"vORGANISATIONID", AV16OrganisationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_FILEUPLOADDATA", AV25SDT_FileUploadData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_FILEUPLOADDATA", AV25SDT_FileUploadData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_FILEUPLOADDATA", GetSecureSignedToken( sPrefix, AV25SDT_FileUploadData, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vERRORMESSAGES", AV8ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vERRORMESSAGES", AV8ErrorMessages);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV17PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV9GoingBack);
      }

      protected void RenderHtmlCloseFormAZ2( )
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
         return "WP_CreateLocationAndLicenseStep2" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Create Location And License Step2", "") ;
      }

      protected void WBAZ0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createlocationandlicensestep2.aspx");
               context.AddJavascriptSource("UserControls/UC_ThemeSelectorRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/UC_CtaThemeSelectorRender.js", "", false, true);
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "License", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateLocationAndLicenseStep2.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGroupattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAgreementfields_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavLocationhasmycare_Internalname, context.GetMessage( "Location Has My Care", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavLocationhasmycare_Internalname, StringUtil.BoolToStr( AV12LocationHasMyCare), "", context.GetMessage( "Location Has My Care", ""), 1, chkavLocationhasmycare.Enabled, "true", context.GetMessage( "My Care", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(23, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,23);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavLocationhasmyliving_Internalname, context.GetMessage( "Location Has My Living", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavLocationhasmyliving_Internalname, StringUtil.BoolToStr( AV13LocationHasMyLiving), "", context.GetMessage( "Location Has My Living", ""), 1, chkavLocationhasmyliving.Enabled, "true", context.GetMessage( "My Living", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(27, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,27);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavLocationhasmyservices_Internalname, context.GetMessage( "Location Has My Services", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavLocationhasmyservices_Internalname, StringUtil.BoolToStr( AV14LocationHasMyServices), "", context.GetMessage( "Location Has My Services", ""), 1, chkavLocationhasmyservices.Enabled, "true", context.GetMessage( "My Services", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(31, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,31);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavLocationhasownbrand_Internalname, context.GetMessage( "Location Has Own Brand", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavLocationhasownbrand_Internalname, StringUtil.BoolToStr( AV15LocationHasOwnBrand), "", context.GetMessage( "Location Has Own Brand", ""), 1, chkavLocationhasownbrand.Enabled, "true", context.GetMessage( "My Location Brand Theme", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(35, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,35);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-7", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBrandthemetable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBrandtable_Internalname, divBrandtable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblThemelabel_Internalname, context.GetMessage( "Location Brand Theme", ""), "", "", lblThemelabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateLocationAndLicenseStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucThemeselector.SetProperty("SelectedTheme", AV22SelectedBrandTheme);
            ucThemeselector.Render(context, "uc_themeselector", Themeselector_Internalname, sPrefix+"THEMESELECTORContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCtatable_Internalname, divCtatable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCtatheme_Internalname, context.GetMessage( "Call To Action Theme", ""), "", "", lblCtatheme_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateLocationAndLicenseStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCalltoactionthemeselector.SetProperty("ResultTheme", AV23SelectedCtaTheme);
            ucCalltoactionthemeselector.Render(context, "uc_ctathemeselector", Calltoactionthemeselector_Internalname, sPrefix+"CALLTOACTIONTHEMESELECTORContainer");
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
            ucBtnwizardfinish.SetProperty("TooltipText", Btnwizardfinish_Tooltiptext);
            ucBtnwizardfinish.SetProperty("Caption", Btnwizardfinish_Caption);
            ucBtnwizardfinish.SetProperty("Class", Btnwizardfinish_Class);
            ucBtnwizardfinish.Render(context, "wwp_iconbutton", Btnwizardfinish_Internalname, sPrefix+"BTNWIZARDFINISHContainer");
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
         wbLoad = true;
      }

      protected void STARTAZ2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Create Location And License Step2", ""), 0) ;
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
               STRUPAZ0( ) ;
            }
         }
      }

      protected void WSAZ2( )
      {
         STARTAZ2( ) ;
         EVTAZ2( ) ;
      }

      protected void EVTAZ2( )
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
                                 STRUPAZ0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPAZ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11AZ2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPAZ0( ) ;
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
                                          E12AZ2 ();
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
                                 STRUPAZ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E13AZ2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOWIZARDFINISH'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPAZ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoWizardFinish' */
                                    E14AZ2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPAZ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E15AZ2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPAZ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavLocationhasmycare_Internalname;
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

      protected void WEAZ2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormAZ2( ) ;
            }
         }
      }

      protected void PAAZ2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createlocationandlicensestep2.aspx")), "wp_createlocationandlicensestep2.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createlocationandlicensestep2.aspx")))) ;
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
               GX_FocusControl = chkavLocationhasmycare_Internalname;
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
         AV12LocationHasMyCare = StringUtil.StrToBool( StringUtil.BoolToStr( AV12LocationHasMyCare));
         AssignAttri(sPrefix, false, "AV12LocationHasMyCare", AV12LocationHasMyCare);
         AV13LocationHasMyLiving = StringUtil.StrToBool( StringUtil.BoolToStr( AV13LocationHasMyLiving));
         AssignAttri(sPrefix, false, "AV13LocationHasMyLiving", AV13LocationHasMyLiving);
         AV14LocationHasMyServices = StringUtil.StrToBool( StringUtil.BoolToStr( AV14LocationHasMyServices));
         AssignAttri(sPrefix, false, "AV14LocationHasMyServices", AV14LocationHasMyServices);
         AV15LocationHasOwnBrand = StringUtil.StrToBool( StringUtil.BoolToStr( AV15LocationHasOwnBrand));
         AssignAttri(sPrefix, false, "AV15LocationHasOwnBrand", AV15LocationHasOwnBrand);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFAZ2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFAZ2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15AZ2 ();
            WBAZ0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesAZ2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_FILEUPLOADDATA", AV25SDT_FileUploadData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_FILEUPLOADDATA", AV25SDT_FileUploadData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_FILEUPLOADDATA", GetSecureSignedToken( sPrefix, AV25SDT_FileUploadData, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPAZ0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11AZ2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSELECTEDBRANDTHEME"), AV22SelectedBrandTheme);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSELECTEDCTATHEME"), AV23SelectedCtaTheme);
            /* Read saved values. */
            wcpOAV20WebSessionKey = cgiGet( sPrefix+"wcpOAV20WebSessionKey");
            wcpOAV17PreviousStep = cgiGet( sPrefix+"wcpOAV17PreviousStep");
            wcpOAV9GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV9GoingBack"));
            wcpOAV16OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV16OrganisationId"));
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
         E11AZ2 ();
         if (returnInSub) return;
      }

      protected void E11AZ2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12AZ2 ();
         if (returnInSub) return;
      }

      protected void E12AZ2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
            AV19WebSession.Remove(AV20WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21WizardData", AV21WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8ErrorMessages", AV8ErrorMessages);
      }

      protected void E13AZ2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S132 ();
         if (returnInSub) return;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_createlocationandlicense.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.BoolToStr(true)) + "," + UrlEncode(AV16OrganisationId.ToString());
         CallWebObject(formatLink("wp_createlocationandlicense.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21WizardData", AV21WizardData);
      }

      protected void E14AZ2( )
      {
         /* 'DoWizardFinish' Routine */
         returnInSub = false;
         if ( ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21WizardData", AV21WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8ErrorMessages", AV8ErrorMessages);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV21WizardData.FromJSonString(AV19WebSession.Get(AV20WebSessionKey), null);
         AV12LocationHasMyCare = AV21WizardData.gxTpr_Step2.gxTpr_Locationhasmycare;
         AssignAttri(sPrefix, false, "AV12LocationHasMyCare", AV12LocationHasMyCare);
         AV13LocationHasMyLiving = AV21WizardData.gxTpr_Step2.gxTpr_Locationhasmyliving;
         AssignAttri(sPrefix, false, "AV13LocationHasMyLiving", AV13LocationHasMyLiving);
         AV14LocationHasMyServices = AV21WizardData.gxTpr_Step2.gxTpr_Locationhasmyservices;
         AssignAttri(sPrefix, false, "AV14LocationHasMyServices", AV14LocationHasMyServices);
         AV15LocationHasOwnBrand = AV21WizardData.gxTpr_Step2.gxTpr_Locationhasownbrand;
         AssignAttri(sPrefix, false, "AV15LocationHasOwnBrand", AV15LocationHasOwnBrand);
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV21WizardData.FromJSonString(AV19WebSession.Get(AV20WebSessionKey), null);
         AV21WizardData.gxTpr_Step2.gxTpr_Locationhasmycare = AV12LocationHasMyCare;
         AV21WizardData.gxTpr_Step2.gxTpr_Locationhasmyliving = AV13LocationHasMyLiving;
         AV21WizardData.gxTpr_Step2.gxTpr_Locationhasmyservices = AV14LocationHasMyServices;
         AV21WizardData.gxTpr_Step2.gxTpr_Locationhasownbrand = AV15LocationHasOwnBrand;
         AV19WebSession.Set(AV20WebSessionKey, AV21WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21WizardData.gxTpr_Step1.gxTpr_Locationimagevar)) )
         {
            AV11ImageFile2=context.FileFromBase64( AV21WizardData.gxTpr_Step1.gxTpr_Locationimagevar) ;
         }
         AV8ErrorMessages.Clear();
         AV18Trn_Location = new SdtTrn_Location(context);
         AV18Trn_Location.gxTpr_Locationid = AV21WizardData.gxTpr_Step1.gxTpr_Locationid;
         AV18Trn_Location.gxTpr_Locationname = AV21WizardData.gxTpr_Step1.gxTpr_Locationname;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11ImageFile2)) )
         {
            AV18Trn_Location.gxTpr_Locationimage = AV11ImageFile2;
            AV18Trn_Location.gxTpr_Locationimage_gxi = GXDbFile.GetUriFromFile( "", "", AV11ImageFile2);
         }
         AV18Trn_Location.gxTpr_Organisationid = AV16OrganisationId;
         AV18Trn_Location.gxTpr_Locationemail = AV21WizardData.gxTpr_Step1.gxTpr_Locationemail;
         AV18Trn_Location.gxTpr_Locationphone = AV21WizardData.gxTpr_Step1.gxTpr_Locationphone;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21WizardData.gxTpr_Step1.gxTpr_Locationphonenumber)) )
         {
            AV18Trn_Location.gxTpr_Locationphonecode = AV21WizardData.gxTpr_Step1.gxTpr_Locationphonecode;
            AV18Trn_Location.gxTpr_Locationphonenumber = AV21WizardData.gxTpr_Step1.gxTpr_Locationphonenumber;
         }
         AV18Trn_Location.gxTpr_Locationcity = AV21WizardData.gxTpr_Step1.gxTpr_Locationcity;
         AV18Trn_Location.gxTpr_Locationcountry = AV21WizardData.gxTpr_Step1.gxTpr_Locationcountry;
         AV18Trn_Location.gxTpr_Locationzipcode = AV21WizardData.gxTpr_Step1.gxTpr_Locationzipcode;
         AV18Trn_Location.gxTpr_Locationaddressline1 = AV21WizardData.gxTpr_Step1.gxTpr_Locationaddressline1;
         AV18Trn_Location.gxTpr_Locationaddressline2 = AV21WizardData.gxTpr_Step1.gxTpr_Locationaddressline2;
         AV18Trn_Location.gxTpr_Locationdescription = AV21WizardData.gxTpr_Step1.gxTpr_Locationdescription;
         AV18Trn_Location.gxTpr_Locationhasmycare = AV12LocationHasMyCare;
         AV18Trn_Location.gxTpr_Locationhasmyliving = AV13LocationHasMyLiving;
         AV18Trn_Location.gxTpr_Locationhasmyservices = AV14LocationHasMyServices;
         AV18Trn_Location.gxTpr_Locationhasownbrand = AV15LocationHasOwnBrand;
         if ( AV15LocationHasOwnBrand )
         {
            AV18Trn_Location.gxTpr_Locationbrandtheme = AV22SelectedBrandTheme.ToJSonString(false, true);
            AV18Trn_Location.gxTpr_Locationctatheme = AV23SelectedCtaTheme.ToJSonString(false, true);
         }
         AV5isLocationInserted = AV18Trn_Location.Insert();
         if ( AV5isLocationInserted )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21WizardData.gxTpr_Step1.gxTpr_Locationimagevar)) )
            {
               if ( AV25SDT_FileUploadData.FromJSonString(AV21WizardData.gxTpr_Step1.gxTpr_Locationimagevar, null) )
               {
                  AV29GXV1 = 1;
                  while ( AV29GXV1 <= AV25SDT_FileUploadData.Count )
                  {
                     AV26File = ((SdtSDT_FileUploadData)AV25SDT_FileUploadData.Item(AV29GXV1));
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26File.gxTpr_File)) )
                     {
                        AV27ImageFile = "";
                        AV24base64String = GxRegex.Split(AV26File.gxTpr_File,",").GetString(2);
                        AV27ImageFile=context.FileFromBase64( AV24base64String) ;
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ImageFile)) )
                        {
                           AV28Trn_LocationImage = new SdtTrn_LocationImage(context);
                           AV28Trn_LocationImage.gxTpr_Organisationlocationid = AV18Trn_Location.gxTpr_Locationid;
                           AV28Trn_LocationImage.gxTpr_Organisationlocationimage = AV27ImageFile;
                           AV28Trn_LocationImage.gxTpr_Organisationlocationimage_gxi = GXDbFile.GetUriFromFile( "", "", AV27ImageFile);
                           AV28Trn_LocationImage.Insert();
                        }
                     }
                     AV29GXV1 = (int)(AV29GXV1+1);
                  }
               }
            }
            context.CommitDataStores("wp_createlocationandlicensestep2",pr_default);
            AV19WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Inserted successfully", ""));
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_organisationview.aspx"+UrlEncode(AV16OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(context.GetMessage( "Trn_Location", "")));
            CallWebObject(formatLink("trn_organisationview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            context.RollbackDataStores("wp_createlocationandlicensestep2",pr_default);
            AV8ErrorMessages = AV18Trn_Location.GetMessages();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S152 ();
            if (returnInSub) return;
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divBrandtable_Visible = (((AV15LocationHasOwnBrand)) ? 1 : 0);
         AssignProp(sPrefix, false, divBrandtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divBrandtable_Visible), 5, 0), true);
         divCtatable_Visible = (((AV15LocationHasOwnBrand)) ? 1 : 0);
         AssignProp(sPrefix, false, divCtatable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCtatable_Visible), 5, 0), true);
      }

      protected void S152( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV30GXV2 = 1;
         while ( AV30GXV2 <= AV8ErrorMessages.Count )
         {
            AV7Error = ((GeneXus.Utils.SdtMessages_Message)AV8ErrorMessages.Item(AV30GXV2));
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV7Error.gxTpr_Description,  "error",  "",  "true",  ""));
            AV30GXV2 = (int)(AV30GXV2+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E15AZ2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV20WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV20WebSessionKey", AV20WebSessionKey);
         AV17PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV17PreviousStep", AV17PreviousStep);
         AV9GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV9GoingBack", AV9GoingBack);
         AV16OrganisationId = (Guid)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV16OrganisationId", AV16OrganisationId.ToString());
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
         PAAZ2( ) ;
         WSAZ2( ) ;
         WEAZ2( ) ;
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
         sCtrlAV20WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV17PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV9GoingBack = (string)((string)getParm(obj,2));
         sCtrlAV16OrganisationId = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAAZ2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createlocationandlicensestep2", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAAZ2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV20WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV20WebSessionKey", AV20WebSessionKey);
            AV17PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV17PreviousStep", AV17PreviousStep);
            AV9GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV9GoingBack", AV9GoingBack);
            AV16OrganisationId = (Guid)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV16OrganisationId", AV16OrganisationId.ToString());
         }
         wcpOAV20WebSessionKey = cgiGet( sPrefix+"wcpOAV20WebSessionKey");
         wcpOAV17PreviousStep = cgiGet( sPrefix+"wcpOAV17PreviousStep");
         wcpOAV9GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV9GoingBack"));
         wcpOAV16OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV16OrganisationId"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV20WebSessionKey, wcpOAV20WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV17PreviousStep, wcpOAV17PreviousStep) != 0 ) || ( AV9GoingBack != wcpOAV9GoingBack ) || ( AV16OrganisationId != wcpOAV16OrganisationId ) ) )
         {
            setjustcreated();
         }
         wcpOAV20WebSessionKey = AV20WebSessionKey;
         wcpOAV17PreviousStep = AV17PreviousStep;
         wcpOAV9GoingBack = AV9GoingBack;
         wcpOAV16OrganisationId = AV16OrganisationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV20WebSessionKey = cgiGet( sPrefix+"AV20WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV20WebSessionKey) > 0 )
         {
            AV20WebSessionKey = cgiGet( sCtrlAV20WebSessionKey);
            AssignAttri(sPrefix, false, "AV20WebSessionKey", AV20WebSessionKey);
         }
         else
         {
            AV20WebSessionKey = cgiGet( sPrefix+"AV20WebSessionKey_PARM");
         }
         sCtrlAV17PreviousStep = cgiGet( sPrefix+"AV17PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV17PreviousStep) > 0 )
         {
            AV17PreviousStep = cgiGet( sCtrlAV17PreviousStep);
            AssignAttri(sPrefix, false, "AV17PreviousStep", AV17PreviousStep);
         }
         else
         {
            AV17PreviousStep = cgiGet( sPrefix+"AV17PreviousStep_PARM");
         }
         sCtrlAV9GoingBack = cgiGet( sPrefix+"AV9GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV9GoingBack) > 0 )
         {
            AV9GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV9GoingBack));
            AssignAttri(sPrefix, false, "AV9GoingBack", AV9GoingBack);
         }
         else
         {
            AV9GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV9GoingBack_PARM"));
         }
         sCtrlAV16OrganisationId = cgiGet( sPrefix+"AV16OrganisationId_CTRL");
         if ( StringUtil.Len( sCtrlAV16OrganisationId) > 0 )
         {
            AV16OrganisationId = StringUtil.StrToGuid( cgiGet( sCtrlAV16OrganisationId));
            AssignAttri(sPrefix, false, "AV16OrganisationId", AV16OrganisationId.ToString());
         }
         else
         {
            AV16OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV16OrganisationId_PARM"));
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
         PAAZ2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSAZ2( ) ;
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
         WSAZ2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20WebSessionKey_PARM", AV20WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV20WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV17PreviousStep_PARM", AV17PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV17PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV17PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV17PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9GoingBack_PARM", StringUtil.BoolToStr( AV9GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9GoingBack_CTRL", StringUtil.RTrim( sCtrlAV9GoingBack));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV16OrganisationId_PARM", AV16OrganisationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16OrganisationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16OrganisationId_CTRL", StringUtil.RTrim( sCtrlAV16OrganisationId));
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
         WEAZ2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025614538090", true, true);
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
         context.AddJavascriptSource("wp_createlocationandlicensestep2.js", "?2025614538091", false, true);
         context.AddJavascriptSource("UserControls/UC_ThemeSelectorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_CtaThemeSelectorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavLocationhasmycare.Name = "vLOCATIONHASMYCARE";
         chkavLocationhasmycare.WebTags = "";
         chkavLocationhasmycare.Caption = context.GetMessage( "Location Has My Care", "");
         AssignProp(sPrefix, false, chkavLocationhasmycare_Internalname, "TitleCaption", chkavLocationhasmycare.Caption, true);
         chkavLocationhasmycare.CheckedValue = "false";
         chkavLocationhasmyliving.Name = "vLOCATIONHASMYLIVING";
         chkavLocationhasmyliving.WebTags = "";
         chkavLocationhasmyliving.Caption = context.GetMessage( "Location Has My Living", "");
         AssignProp(sPrefix, false, chkavLocationhasmyliving_Internalname, "TitleCaption", chkavLocationhasmyliving.Caption, true);
         chkavLocationhasmyliving.CheckedValue = "false";
         chkavLocationhasmyservices.Name = "vLOCATIONHASMYSERVICES";
         chkavLocationhasmyservices.WebTags = "";
         chkavLocationhasmyservices.Caption = context.GetMessage( "Location Has My Services", "");
         AssignProp(sPrefix, false, chkavLocationhasmyservices_Internalname, "TitleCaption", chkavLocationhasmyservices.Caption, true);
         chkavLocationhasmyservices.CheckedValue = "false";
         chkavLocationhasownbrand.Name = "vLOCATIONHASOWNBRAND";
         chkavLocationhasownbrand.WebTags = "";
         chkavLocationhasownbrand.Caption = context.GetMessage( "Location Has Own Brand", "");
         AssignProp(sPrefix, false, chkavLocationhasownbrand_Internalname, "TitleCaption", chkavLocationhasownbrand.Caption, true);
         chkavLocationhasownbrand.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         chkavLocationhasmycare_Internalname = sPrefix+"vLOCATIONHASMYCARE";
         chkavLocationhasmyliving_Internalname = sPrefix+"vLOCATIONHASMYLIVING";
         chkavLocationhasmyservices_Internalname = sPrefix+"vLOCATIONHASMYSERVICES";
         chkavLocationhasownbrand_Internalname = sPrefix+"vLOCATIONHASOWNBRAND";
         divAgreementfields_Internalname = sPrefix+"AGREEMENTFIELDS";
         lblThemelabel_Internalname = sPrefix+"THEMELABEL";
         Themeselector_Internalname = sPrefix+"THEMESELECTOR";
         divBrandtable_Internalname = sPrefix+"BRANDTABLE";
         lblCtatheme_Internalname = sPrefix+"CTATHEME";
         Calltoactionthemeselector_Internalname = sPrefix+"CALLTOACTIONTHEMESELECTOR";
         divCtatable_Internalname = sPrefix+"CTATABLE";
         divBrandthemetable_Internalname = sPrefix+"BRANDTHEMETABLE";
         divGroupattributes_Internalname = sPrefix+"GROUPATTRIBUTES";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardfinish_Internalname = sPrefix+"BTNWIZARDFINISH";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         chkavLocationhasownbrand.Caption = context.GetMessage( "Location Has Own Brand", "");
         chkavLocationhasmyservices.Caption = context.GetMessage( "Location Has My Services", "");
         chkavLocationhasmyliving.Caption = context.GetMessage( "Location Has My Living", "");
         chkavLocationhasmycare.Caption = context.GetMessage( "Location Has My Care", "");
         Btnwizardfinish_Class = "ButtonMaterial";
         Btnwizardfinish_Caption = context.GetMessage( "Finish", "");
         Btnwizardfinish_Tooltiptext = "";
         Btnwizardprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardprevious_Caption = context.GetMessage( "GXM_previous", "");
         Btnwizardprevious_Tooltiptext = "";
         divCtatable_Visible = 1;
         divBrandtable_Visible = 1;
         chkavLocationhasownbrand.Enabled = 1;
         chkavLocationhasmyservices.Enabled = 1;
         chkavLocationhasmyliving.Enabled = 1;
         chkavLocationhasmycare.Enabled = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV12LocationHasMyCare","fld":"vLOCATIONHASMYCARE"},{"av":"AV13LocationHasMyLiving","fld":"vLOCATIONHASMYLIVING"},{"av":"AV14LocationHasMyServices","fld":"vLOCATIONHASMYSERVICES"},{"av":"AV15LocationHasOwnBrand","fld":"vLOCATIONHASOWNBRAND"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV25SDT_FileUploadData","fld":"vSDT_FILEUPLOADDATA","hsh":true}]}""");
         setEventMetadata("ENTER","""{"handler":"E12AZ2","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV20WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV12LocationHasMyCare","fld":"vLOCATIONHASMYCARE"},{"av":"AV13LocationHasMyLiving","fld":"vLOCATIONHASMYLIVING"},{"av":"AV14LocationHasMyServices","fld":"vLOCATIONHASMYSERVICES"},{"av":"AV15LocationHasOwnBrand","fld":"vLOCATIONHASOWNBRAND"},{"av":"AV21WizardData","fld":"vWIZARDDATA"},{"av":"AV11ImageFile2","fld":"vIMAGEFILE2"},{"av":"AV16OrganisationId","fld":"vORGANISATIONID"},{"av":"AV22SelectedBrandTheme","fld":"vSELECTEDBRANDTHEME"},{"av":"AV23SelectedCtaTheme","fld":"vSELECTEDCTATHEME"},{"av":"AV25SDT_FileUploadData","fld":"vSDT_FILEUPLOADDATA","hsh":true},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV21WizardData","fld":"vWIZARDDATA"},{"av":"AV11ImageFile2","fld":"vIMAGEFILE2"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E13AZ2","iparms":[{"av":"AV16OrganisationId","fld":"vORGANISATIONID"},{"av":"AV20WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV12LocationHasMyCare","fld":"vLOCATIONHASMYCARE"},{"av":"AV13LocationHasMyLiving","fld":"vLOCATIONHASMYLIVING"},{"av":"AV14LocationHasMyServices","fld":"vLOCATIONHASMYSERVICES"},{"av":"AV15LocationHasOwnBrand","fld":"vLOCATIONHASOWNBRAND"}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV16OrganisationId","fld":"vORGANISATIONID"},{"av":"AV21WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOWIZARDFINISH'","""{"handler":"E14AZ2","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV20WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV12LocationHasMyCare","fld":"vLOCATIONHASMYCARE"},{"av":"AV13LocationHasMyLiving","fld":"vLOCATIONHASMYLIVING"},{"av":"AV14LocationHasMyServices","fld":"vLOCATIONHASMYSERVICES"},{"av":"AV15LocationHasOwnBrand","fld":"vLOCATIONHASOWNBRAND"},{"av":"AV21WizardData","fld":"vWIZARDDATA"},{"av":"AV11ImageFile2","fld":"vIMAGEFILE2"},{"av":"AV16OrganisationId","fld":"vORGANISATIONID"},{"av":"AV22SelectedBrandTheme","fld":"vSELECTEDBRANDTHEME"},{"av":"AV23SelectedCtaTheme","fld":"vSELECTEDCTATHEME"},{"av":"AV25SDT_FileUploadData","fld":"vSDT_FILEUPLOADDATA","hsh":true},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"}]""");
         setEventMetadata("'DOWIZARDFINISH'",""","oparms":[{"av":"AV21WizardData","fld":"vWIZARDDATA"},{"av":"AV11ImageFile2","fld":"vIMAGEFILE2"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"}]}""");
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
         wcpOAV20WebSessionKey = "";
         wcpOAV17PreviousStep = "";
         wcpOAV16OrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV25SDT_FileUploadData = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version21");
         AV22SelectedBrandTheme = new SdtSDT_BrandThemeColors(context);
         AV23SelectedCtaTheme = new SdtSDT_CtaThemeColors(context);
         AV21WizardData = new SdtWP_CreateLocationAndLicenseData(context);
         AV11ImageFile2 = "";
         AV8ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV12LocationHasMyCare = false;
         AV13LocationHasMyLiving = false;
         AV14LocationHasMyServices = false;
         AV15LocationHasOwnBrand = false;
         lblThemelabel_Jsonclick = "";
         ucThemeselector = new GXUserControl();
         lblCtatheme_Jsonclick = "";
         ucCalltoactionthemeselector = new GXUserControl();
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardfinish = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV19WebSession = context.GetSession();
         AV18Trn_Location = new SdtTrn_Location(context);
         AV26File = new SdtSDT_FileUploadData(context);
         AV27ImageFile = "";
         AV24base64String = "";
         AV28Trn_LocationImage = new SdtTrn_LocationImage(context);
         AV7Error = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV20WebSessionKey = "";
         sCtrlAV17PreviousStep = "";
         sCtrlAV9GoingBack = "";
         sCtrlAV16OrganisationId = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_createlocationandlicensestep2__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_createlocationandlicensestep2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createlocationandlicensestep2__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
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
      private int divBrandtable_Visible ;
      private int divCtatable_Visible ;
      private int AV29GXV1 ;
      private int AV30GXV2 ;
      private int idxLst ;
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
      private string divGroupattributes_Internalname ;
      private string divAgreementfields_Internalname ;
      private string chkavLocationhasmycare_Internalname ;
      private string TempTags ;
      private string chkavLocationhasmyliving_Internalname ;
      private string chkavLocationhasmyservices_Internalname ;
      private string chkavLocationhasownbrand_Internalname ;
      private string divBrandthemetable_Internalname ;
      private string divBrandtable_Internalname ;
      private string lblThemelabel_Internalname ;
      private string lblThemelabel_Jsonclick ;
      private string Themeselector_Internalname ;
      private string divCtatable_Internalname ;
      private string lblCtatheme_Internalname ;
      private string lblCtatheme_Jsonclick ;
      private string Calltoactionthemeselector_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string Btnwizardfinish_Tooltiptext ;
      private string Btnwizardfinish_Caption ;
      private string Btnwizardfinish_Class ;
      private string Btnwizardfinish_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV20WebSessionKey ;
      private string sCtrlAV17PreviousStep ;
      private string sCtrlAV9GoingBack ;
      private string sCtrlAV16OrganisationId ;
      private bool AV9GoingBack ;
      private bool wcpOAV9GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool wbLoad ;
      private bool AV12LocationHasMyCare ;
      private bool AV13LocationHasMyLiving ;
      private bool AV14LocationHasMyServices ;
      private bool AV15LocationHasOwnBrand ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5isLocationInserted ;
      private string AV24base64String ;
      private string AV20WebSessionKey ;
      private string AV17PreviousStep ;
      private string wcpOAV20WebSessionKey ;
      private string wcpOAV17PreviousStep ;
      private Guid AV16OrganisationId ;
      private Guid wcpOAV16OrganisationId ;
      private string AV11ImageFile2 ;
      private string AV27ImageFile ;
      private GXUserControl ucThemeselector ;
      private GXUserControl ucCalltoactionthemeselector ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardfinish ;
      private GXWebForm Form ;
      private IGxSession AV19WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP3_OrganisationId ;
      private GXCheckbox chkavLocationhasmycare ;
      private GXCheckbox chkavLocationhasmyliving ;
      private GXCheckbox chkavLocationhasmyservices ;
      private GXCheckbox chkavLocationhasownbrand ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV25SDT_FileUploadData ;
      private SdtSDT_BrandThemeColors AV22SelectedBrandTheme ;
      private SdtSDT_CtaThemeColors AV23SelectedCtaTheme ;
      private SdtWP_CreateLocationAndLicenseData AV21WizardData ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8ErrorMessages ;
      private SdtTrn_Location AV18Trn_Location ;
      private SdtSDT_FileUploadData AV26File ;
      private SdtTrn_LocationImage AV28Trn_LocationImage ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Utils.SdtMessages_Message AV7Error ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_createlocationandlicensestep2__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_createlocationandlicensestep2__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_createlocationandlicensestep2__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
