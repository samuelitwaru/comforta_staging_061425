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
namespace GeneXus.Programs {
   public class trn_productservicegeneral : GXWebComponent
   {
      public trn_productservicegeneral( )
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

      public trn_productservicegeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ProductServiceId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId )
      {
         this.A58ProductServiceId = aP0_ProductServiceId;
         this.A29LocationId = aP1_LocationId;
         this.A11OrganisationId = aP2_OrganisationId;
         ExecuteImpl();
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
         dynLocationId = new GXCombobox();
         cmbProductServiceClass = new GXCombobox();
         chkavListgen = new GXCheckbox();
         chkavListgenpre = new GXCheckbox();
         chkavListagb = new GXCheckbox();
         chkavListagbpre = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ProductServiceId");
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
                  A58ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
                  AssignAttri(sPrefix, false, "A58ProductServiceId", A58ProductServiceId.ToString());
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A58ProductServiceId,(Guid)A29LocationId,(Guid)A11OrganisationId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"LOCATIONID") == 0 )
               {
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLALOCATIONID4P2( A11OrganisationId) ;
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
                  gxfirstwebparm = GetFirstPar( "ProductServiceId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ProductServiceId");
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
            PA4P2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV34Pgmname = "Trn_ProductServiceGeneral";
               edtavSupplierlocation_Enabled = 0;
               AssignProp(sPrefix, false, edtavSupplierlocation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplierlocation_Enabled), 5, 0), true);
               chkavListgen.Enabled = 0;
               AssignProp(sPrefix, false, chkavListgen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgen.Enabled), 5, 0), true);
               edtavSuppliergen_id_Enabled = 0;
               AssignProp(sPrefix, false, edtavSuppliergen_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergen_id_Enabled), 5, 0), true);
               chkavListgenpre.Enabled = 0;
               AssignProp(sPrefix, false, chkavListgenpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgenpre.Enabled), 5, 0), true);
               chkavListagb.Enabled = 0;
               AssignProp(sPrefix, false, chkavListagb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagb.Enabled), 5, 0), true);
               edtavSupplieragb_id_Enabled = 0;
               AssignProp(sPrefix, false, edtavSupplieragb_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplieragb_id_Enabled), 5, 0), true);
               chkavListagbpre.Enabled = 0;
               AssignProp(sPrefix, false, chkavListagbpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Enabled), 5, 0), true);
               GXALOCATIONID_html4P2( A11OrganisationId) ;
               WS4P2( ) ;
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
            context.SendWebValue( context.GetMessage( "Trn_Product Service General", "")) ;
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
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
            GXEncryptionTmp = "trn_productservicegeneral.aspx"+UrlEncode(A58ProductServiceId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_productservicegeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTAGB", GetSecureSignedToken( sPrefix, AV22ListAgb, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTGEN", GetSecureSignedToken( sPrefix, AV23ListGen, context));
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Trn_ProductServiceGeneral");
         forbiddenHiddens.Add("ProductServiceGroup", StringUtil.RTrim( context.localUtil.Format( A338ProductServiceGroup, "")));
         AV23ListGen = StringUtil.StrToBool( StringUtil.BoolToStr( AV23ListGen));
         AssignAttri(sPrefix, false, "AV23ListGen", AV23ListGen);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTGEN", GetSecureSignedToken( sPrefix, AV23ListGen, context));
         forbiddenHiddens.Add("ListGen", StringUtil.BoolToStr( AV23ListGen));
         AV22ListAgb = StringUtil.StrToBool( StringUtil.BoolToStr( AV22ListAgb));
         AssignAttri(sPrefix, false, "AV22ListAgb", AV22ListAgb);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTAGB", GetSecureSignedToken( sPrefix, AV22ListAgb, context));
         forbiddenHiddens.Add("ListAgb", StringUtil.BoolToStr( AV22ListAgb));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_productservicegeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV32UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV32UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILESTOUPDATE", AV31FilesToUpdate);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILESTOUPDATE", AV31FilesToUpdate);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION", A60ProductServiceDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA58ProductServiceId", wcpOA58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA29LocationId", wcpOA29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA11OrganisationId", wcpOA11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"IMAGEUPLOADUC_Faileduploadmessage", StringUtil.RTrim( Imageuploaduc_Faileduploadmessage));
         GxWebStd.gx_hidden_field( context, sPrefix+"IMAGEUPLOADUC_Maxnumberoffiles", StringUtil.RTrim( Imageuploaduc_Maxnumberoffiles));
         GxWebStd.gx_hidden_field( context, sPrefix+"IMAGEUPLOADUC_Isreadonlymode", StringUtil.RTrim( Imageuploaduc_Isreadonlymode));
         GxWebStd.gx_hidden_field( context, sPrefix+"IMAGEUPLOADUC_Maxfilesize", StringUtil.RTrim( Imageuploaduc_Maxfilesize));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION_Enabled", StringUtil.BoolToStr( Productservicedescription_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION_Width", StringUtil.RTrim( Productservicedescription_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION_Height", StringUtil.RTrim( Productservicedescription_Height));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION_Skin", StringUtil.RTrim( Productservicedescription_Skin));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION_Toolbar", StringUtil.RTrim( Productservicedescription_Toolbar));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION_Customtoolbar", StringUtil.RTrim( Productservicedescription_Customtoolbar));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION_Customconfiguration", StringUtil.RTrim( Productservicedescription_Customconfiguration));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION_Toolbarcancollapse", StringUtil.BoolToStr( Productservicedescription_Toolbarcancollapse));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION_Captionclass", StringUtil.RTrim( Productservicedescription_Captionclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION_Captionstyle", StringUtil.RTrim( Productservicedescription_Captionstyle));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION_Captionposition", StringUtil.RTrim( Productservicedescription_Captionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION_Visible", StringUtil.BoolToStr( Productservicedescription_Visible));
      }

      protected void RenderHtmlCloseForm4P2( )
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
         return "Trn_ProductServiceGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Product Service General", "") ;
      }

      protected void WB4P0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_productservicegeneral.aspx");
               context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
               context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
               context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLocationid_cell_Internalname, 1, 0, "px", 0, "px", divLocationid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", dynLocationId.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynLocationId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynLocationId_Internalname, context.GetMessage( "Location", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynLocationId, dynLocationId_Internalname, A29LocationId.ToString(), 1, dynLocationId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "guid", "", dynLocationId.Visible, dynLocationId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "", true, 0, "HLP_Trn_ProductServiceGeneral.htm");
            dynLocationId.CurrentValue = A29LocationId.ToString();
            AssignProp(sPrefix, false, dynLocationId_Internalname, "Values", (string)(dynLocationId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductServiceName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProductServiceName_Internalname, A59ProductServiceName, StringUtil.RTrim( context.localUtil.Format( A59ProductServiceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductServiceName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ProductServiceGeneral.htm");
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
            GxWebStd.gx_label_ctrl( context, lblProductserviceimagetext_Internalname, context.GetMessage( "Images", ""), "", "", lblProductserviceimagetext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUcfilecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucImageuploaduc.SetProperty("FailedUploadMessage", Imageuploaduc_Faileduploadmessage);
            ucImageuploaduc.SetProperty("MaxNumberOfFiles", Imageuploaduc_Maxnumberoffiles);
            ucImageuploaduc.SetProperty("isReadOnlyMode", Imageuploaduc_Isreadonlymode);
            ucImageuploaduc.SetProperty("MaxFileSize", Imageuploaduc_Maxfilesize);
            ucImageuploaduc.SetProperty("UploadedFiles", AV32UploadedFiles);
            ucImageuploaduc.SetProperty("FilesToEdit", AV31FilesToUpdate);
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
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProductServiceClass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbProductServiceClass_Internalname, context.GetMessage( "Category", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbProductServiceClass, cmbProductServiceClass_Internalname, StringUtil.RTrim( A370ProductServiceClass), 1, cmbProductServiceClass_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbProductServiceClass.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_Trn_ProductServiceGeneral.htm");
            cmbProductServiceClass.CurrentValue = StringUtil.RTrim( A370ProductServiceClass);
            AssignProp(sPrefix, false, cmbProductServiceClass_Internalname, "Values", (string)(cmbProductServiceClass.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtProductServiceGroup_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceGroup_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductServiceGroup_Internalname, context.GetMessage( "Delivered By", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtProductServiceGroup_Internalname, A338ProductServiceGroup, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", 0, edtProductServiceGroup_Visible, edtProductServiceGroup_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSupplierlocation_cell_Internalname, 1, 0, "px", 0, "px", divSupplierlocation_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavSupplierlocation_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSupplierlocation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSupplierlocation_Internalname, context.GetMessage( "Delivered By", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavSupplierlocation_Internalname, AV29SupplierLocation, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, edtavSupplierlocation_Visible, edtavSupplierlocation_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_ProductServiceGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tablegen_Internalname, divTransactiondetail_tablegen_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_suppliergen_Internalname, divTransactiondetail_suppliergen_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsuppliergencompanyname_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksuppliergencompanyname_Internalname, context.GetMessage( "Supplier", ""), "", "", lblTextblocksuppliergencompanyname_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table1_64_4P2( true) ;
         }
         else
         {
            wb_table1_64_4P2( false) ;
         }
         return  ;
      }

      protected void wb_table1_64_4P2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTransactiondetail_suppliergenpre_Internalname, divTransactiondetail_suppliergenpre_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsuppliergen_id_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksuppliergen_id_Internalname, context.GetMessage( "Supplier", ""), "", "", lblTextblocksuppliergen_id_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table2_82_4P2( true) ;
         }
         else
         {
            wb_table2_82_4P2( false) ;
         }
         return  ;
      }

      protected void wb_table2_82_4P2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableagb_Internalname, divTransactiondetail_tableagb_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_supplieragb_Internalname, divTransactiondetail_supplieragb_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsupplieragbname_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksupplieragbname_Internalname, context.GetMessage( "Agb Suppliers", ""), "", "", lblTextblocksupplieragbname_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table3_103_4P2( true) ;
         }
         else
         {
            wb_table3_103_4P2( false) ;
         }
         return  ;
      }

      protected void wb_table3_103_4P2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTransactiondetail_supplieragbpre_Internalname, divTransactiondetail_supplieragbpre_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsupplieragb_id_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksupplieragb_id_Internalname, context.GetMessage( "Supplier Agb Id", ""), "", "", lblTextblocksupplieragb_id_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table4_121_4P2( true) ;
         }
         else
         {
            wb_table4_121_4P2( false) ;
         }
         return  ;
      }

      protected void wb_table4_121_4P2e( bool wbgen )
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divProductservicedescription_cell_Internalname, 1, 0, "px", 0, "px", divProductservicedescription_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Productservicedescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Productservicedescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucProductservicedescription.SetProperty("Width", Productservicedescription_Width);
            ucProductservicedescription.SetProperty("Height", Productservicedescription_Height);
            ucProductservicedescription.SetProperty("Attribute", ProductServiceDescription);
            ucProductservicedescription.SetProperty("Skin", Productservicedescription_Skin);
            ucProductservicedescription.SetProperty("Toolbar", Productservicedescription_Toolbar);
            ucProductservicedescription.SetProperty("CustomToolbar", Productservicedescription_Customtoolbar);
            ucProductservicedescription.SetProperty("CustomConfiguration", Productservicedescription_Customconfiguration);
            ucProductservicedescription.SetProperty("ToolbarCanCollapse", Productservicedescription_Toolbarcancollapse);
            ucProductservicedescription.SetProperty("CaptionClass", Productservicedescription_Captionclass);
            ucProductservicedescription.SetProperty("CaptionStyle", Productservicedescription_Captionstyle);
            ucProductservicedescription.SetProperty("CaptionPosition", Productservicedescription_Captionposition);
            ucProductservicedescription.Render(context, "fckeditor", Productservicedescription_Internalname, sPrefix+"PRODUCTSERVICEDESCRIPTIONContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_productsevicetable_Internalname, divTransactiondetail_productsevicetable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_textblockdescriptionlabel_Internalname, context.GetMessage( "Description", ""), "", "", lblTransactiondetail_textblockdescriptionlabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "HTMLTextOverfow", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_descriptiontext_Internalname, lblTransactiondetail_descriptiontext_Caption, "", "", lblTransactiondetail_descriptiontext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DynamicFormHTMLEditor", 0, "", 1, 1, 0, 1, "HLP_Trn_ProductServiceGeneral.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ProductServiceGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtProductServiceId_Internalname, A58ProductServiceId.ToString(), A58ProductServiceId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceId_Jsonclick, 0, "Attribute", "", "", "", "", edtProductServiceId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ProductServiceGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ProductServiceGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductServiceTileName_Internalname, StringUtil.RTrim( A266ProductServiceTileName), StringUtil.RTrim( context.localUtil.Format( A266ProductServiceTileName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceTileName_Jsonclick, 0, "Attribute", "", "", "", "", edtProductServiceTileName_Visible, 0, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ProductServiceGeneral.htm");
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A61ProductServiceImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductServiceImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage));
            GxWebStd.gx_bitmap( context, imgProductServiceImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgProductServiceImage_Visible, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A61ProductServiceImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4P2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Trn_Product Service General", ""), 0) ;
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
               STRUP4P0( ) ;
            }
         }
      }

      protected void WS4P2( )
      {
         START4P2( ) ;
         EVT4P2( ) ;
      }

      protected void EVT4P2( )
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
                                 STRUP4P0( ) ;
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
                                 STRUP4P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E114P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E124P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4P0( ) ;
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
                                 STRUP4P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSupplierlocation_Internalname;
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

      protected void WE4P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4P2( ) ;
            }
         }
      }

      protected void PA4P2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_productservicegeneral.aspx")), "trn_productservicegeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_productservicegeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ProductServiceId");
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
               GX_FocusControl = edtavSupplierlocation_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLALOCATIONID4P2( Guid A11OrganisationId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLALOCATIONID_data4P2( A11OrganisationId) ;
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

      protected void GXALOCATIONID_html4P2( Guid A11OrganisationId )
      {
         Guid gxdynajaxvalue;
         GXDLALOCATIONID_data4P2( A11OrganisationId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynLocationId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynLocationId.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         }
      }

      protected void GXDLALOCATIONID_data4P2( Guid A11OrganisationId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H004P2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( A11OrganisationId == new prc_getuserorganisationid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(H004P2_A29LocationId[0].ToString());
               gxdynajaxctrldescr.Add(H004P2_A31LocationName[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXALOCATIONID_html4P2( A11OrganisationId) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
            AssignProp(sPrefix, false, dynLocationId_Internalname, "Values", dynLocationId.ToJavascriptSource(), true);
         }
         if ( cmbProductServiceClass.ItemCount > 0 )
         {
            A370ProductServiceClass = cmbProductServiceClass.getValidValue(A370ProductServiceClass);
            AssignAttri(sPrefix, false, "A370ProductServiceClass", A370ProductServiceClass);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProductServiceClass.CurrentValue = StringUtil.RTrim( A370ProductServiceClass);
            AssignProp(sPrefix, false, cmbProductServiceClass_Internalname, "Values", cmbProductServiceClass.ToJavascriptSource(), true);
         }
         AV23ListGen = StringUtil.StrToBool( StringUtil.BoolToStr( AV23ListGen));
         AssignAttri(sPrefix, false, "AV23ListGen", AV23ListGen);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTGEN", GetSecureSignedToken( sPrefix, AV23ListGen, context));
         AV26ListGenPre = StringUtil.StrToBool( StringUtil.BoolToStr( AV26ListGenPre));
         AssignAttri(sPrefix, false, "AV26ListGenPre", AV26ListGenPre);
         AV22ListAgb = StringUtil.StrToBool( StringUtil.BoolToStr( AV22ListAgb));
         AssignAttri(sPrefix, false, "AV22ListAgb", AV22ListAgb);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTAGB", GetSecureSignedToken( sPrefix, AV22ListAgb, context));
         AV27ListAgbPre = StringUtil.StrToBool( StringUtil.BoolToStr( AV27ListAgbPre));
         AssignAttri(sPrefix, false, "AV27ListAgbPre", AV27ListAgbPre);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV34Pgmname = "Trn_ProductServiceGeneral";
         edtavSupplierlocation_Enabled = 0;
         AssignProp(sPrefix, false, edtavSupplierlocation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplierlocation_Enabled), 5, 0), true);
         chkavListgen.Enabled = 0;
         AssignProp(sPrefix, false, chkavListgen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgen.Enabled), 5, 0), true);
         edtavSuppliergen_id_Enabled = 0;
         AssignProp(sPrefix, false, edtavSuppliergen_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergen_id_Enabled), 5, 0), true);
         chkavListgenpre.Enabled = 0;
         AssignProp(sPrefix, false, chkavListgenpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgenpre.Enabled), 5, 0), true);
         chkavListagb.Enabled = 0;
         AssignProp(sPrefix, false, chkavListagb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagb.Enabled), 5, 0), true);
         edtavSupplieragb_id_Enabled = 0;
         AssignProp(sPrefix, false, edtavSupplieragb_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplieragb_id_Enabled), 5, 0), true);
         chkavListagbpre.Enabled = 0;
         AssignProp(sPrefix, false, chkavListagbpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Enabled), 5, 0), true);
      }

      protected void RF4P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H004P3 */
            pr_default.execute(1, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A49SupplierAgbId = H004P3_A49SupplierAgbId[0];
               n49SupplierAgbId = H004P3_n49SupplierAgbId[0];
               A42SupplierGenId = H004P3_A42SupplierGenId[0];
               n42SupplierGenId = H004P3_n42SupplierGenId[0];
               A40000ProductServiceImage_GXI = H004P3_A40000ProductServiceImage_GXI[0];
               AssignProp(sPrefix, false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
               AssignProp(sPrefix, false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
               A266ProductServiceTileName = H004P3_A266ProductServiceTileName[0];
               AssignAttri(sPrefix, false, "A266ProductServiceTileName", A266ProductServiceTileName);
               A60ProductServiceDescription = H004P3_A60ProductServiceDescription[0];
               A51SupplierAgbName = H004P3_A51SupplierAgbName[0];
               AssignAttri(sPrefix, false, "A51SupplierAgbName", A51SupplierAgbName);
               A44SupplierGenCompanyName = H004P3_A44SupplierGenCompanyName[0];
               AssignAttri(sPrefix, false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
               A338ProductServiceGroup = H004P3_A338ProductServiceGroup[0];
               AssignAttri(sPrefix, false, "A338ProductServiceGroup", A338ProductServiceGroup);
               A370ProductServiceClass = H004P3_A370ProductServiceClass[0];
               AssignAttri(sPrefix, false, "A370ProductServiceClass", A370ProductServiceClass);
               A59ProductServiceName = H004P3_A59ProductServiceName[0];
               AssignAttri(sPrefix, false, "A59ProductServiceName", A59ProductServiceName);
               A61ProductServiceImage = H004P3_A61ProductServiceImage[0];
               AssignAttri(sPrefix, false, "A61ProductServiceImage", A61ProductServiceImage);
               AssignProp(sPrefix, false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
               AssignProp(sPrefix, false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
               A51SupplierAgbName = H004P3_A51SupplierAgbName[0];
               AssignAttri(sPrefix, false, "A51SupplierAgbName", A51SupplierAgbName);
               A44SupplierGenCompanyName = H004P3_A44SupplierGenCompanyName[0];
               AssignAttri(sPrefix, false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
               GXALOCATIONID_html4P2( A11OrganisationId) ;
               /* Execute user event: Load */
               E124P2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB4P0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4P2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTAGB", GetSecureSignedToken( sPrefix, AV22ListAgb, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTGEN", GetSecureSignedToken( sPrefix, AV23ListGen, context));
      }

      protected void before_start_formulas( )
      {
         AV34Pgmname = "Trn_ProductServiceGeneral";
         edtavSupplierlocation_Enabled = 0;
         AssignProp(sPrefix, false, edtavSupplierlocation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplierlocation_Enabled), 5, 0), true);
         chkavListgen.Enabled = 0;
         AssignProp(sPrefix, false, chkavListgen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgen.Enabled), 5, 0), true);
         edtavSuppliergen_id_Enabled = 0;
         AssignProp(sPrefix, false, edtavSuppliergen_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSuppliergen_id_Enabled), 5, 0), true);
         chkavListgenpre.Enabled = 0;
         AssignProp(sPrefix, false, chkavListgenpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListgenpre.Enabled), 5, 0), true);
         chkavListagb.Enabled = 0;
         AssignProp(sPrefix, false, chkavListagb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagb.Enabled), 5, 0), true);
         edtavSupplieragb_id_Enabled = 0;
         AssignProp(sPrefix, false, edtavSupplieragb_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSupplieragb_id_Enabled), 5, 0), true);
         chkavListagbpre.Enabled = 0;
         AssignProp(sPrefix, false, chkavListagbpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Enabled), 5, 0), true);
         GXALOCATIONID_html4P2( A11OrganisationId) ;
         dynLocationId.Enabled = 0;
         AssignProp(sPrefix, false, dynLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLocationId.Enabled), 5, 0), true);
         edtProductServiceName_Enabled = 0;
         AssignProp(sPrefix, false, edtProductServiceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceName_Enabled), 5, 0), true);
         cmbProductServiceClass.Enabled = 0;
         AssignProp(sPrefix, false, cmbProductServiceClass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProductServiceClass.Enabled), 5, 0), true);
         edtProductServiceGroup_Enabled = 0;
         AssignProp(sPrefix, false, edtProductServiceGroup_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceGroup_Enabled), 5, 0), true);
         edtSupplierGenCompanyName_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierGenCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenCompanyName_Enabled), 5, 0), true);
         edtSupplierAgbName_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplierAgbName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbName_Enabled), 5, 0), true);
         edtProductServiceId_Enabled = 0;
         AssignProp(sPrefix, false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtProductServiceTileName_Enabled = 0;
         AssignProp(sPrefix, false, edtProductServiceTileName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTileName_Enabled), 5, 0), true);
         imgProductServiceImage_Enabled = 0;
         AssignProp(sPrefix, false, imgProductServiceImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductServiceImage_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114P2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV32UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILESTOUPDATE"), AV31FilesToUpdate);
            /* Read saved values. */
            A60ProductServiceDescription = cgiGet( sPrefix+"PRODUCTSERVICEDESCRIPTION");
            wcpOA58ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA58ProductServiceId"));
            wcpOA29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA29LocationId"));
            wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
            Imageuploaduc_Faileduploadmessage = cgiGet( sPrefix+"IMAGEUPLOADUC_Faileduploadmessage");
            Imageuploaduc_Maxnumberoffiles = cgiGet( sPrefix+"IMAGEUPLOADUC_Maxnumberoffiles");
            Imageuploaduc_Isreadonlymode = cgiGet( sPrefix+"IMAGEUPLOADUC_Isreadonlymode");
            Imageuploaduc_Maxfilesize = cgiGet( sPrefix+"IMAGEUPLOADUC_Maxfilesize");
            Productservicedescription_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"PRODUCTSERVICEDESCRIPTION_Enabled"));
            Productservicedescription_Width = cgiGet( sPrefix+"PRODUCTSERVICEDESCRIPTION_Width");
            Productservicedescription_Height = cgiGet( sPrefix+"PRODUCTSERVICEDESCRIPTION_Height");
            Productservicedescription_Skin = cgiGet( sPrefix+"PRODUCTSERVICEDESCRIPTION_Skin");
            Productservicedescription_Toolbar = cgiGet( sPrefix+"PRODUCTSERVICEDESCRIPTION_Toolbar");
            Productservicedescription_Customtoolbar = cgiGet( sPrefix+"PRODUCTSERVICEDESCRIPTION_Customtoolbar");
            Productservicedescription_Customconfiguration = cgiGet( sPrefix+"PRODUCTSERVICEDESCRIPTION_Customconfiguration");
            Productservicedescription_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( sPrefix+"PRODUCTSERVICEDESCRIPTION_Toolbarcancollapse"));
            Productservicedescription_Captionclass = cgiGet( sPrefix+"PRODUCTSERVICEDESCRIPTION_Captionclass");
            Productservicedescription_Captionstyle = cgiGet( sPrefix+"PRODUCTSERVICEDESCRIPTION_Captionstyle");
            Productservicedescription_Captionposition = cgiGet( sPrefix+"PRODUCTSERVICEDESCRIPTION_Captionposition");
            Productservicedescription_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"PRODUCTSERVICEDESCRIPTION_Visible"));
            /* Read variables values. */
            A59ProductServiceName = cgiGet( edtProductServiceName_Internalname);
            AssignAttri(sPrefix, false, "A59ProductServiceName", A59ProductServiceName);
            cmbProductServiceClass.CurrentValue = cgiGet( cmbProductServiceClass_Internalname);
            A370ProductServiceClass = cgiGet( cmbProductServiceClass_Internalname);
            AssignAttri(sPrefix, false, "A370ProductServiceClass", A370ProductServiceClass);
            A338ProductServiceGroup = cgiGet( edtProductServiceGroup_Internalname);
            AssignAttri(sPrefix, false, "A338ProductServiceGroup", A338ProductServiceGroup);
            AV29SupplierLocation = cgiGet( edtavSupplierlocation_Internalname);
            AssignAttri(sPrefix, false, "AV29SupplierLocation", AV29SupplierLocation);
            A44SupplierGenCompanyName = cgiGet( edtSupplierGenCompanyName_Internalname);
            AssignAttri(sPrefix, false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
            AV23ListGen = StringUtil.StrToBool( cgiGet( chkavListgen_Internalname));
            AssignAttri(sPrefix, false, "AV23ListGen", AV23ListGen);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTGEN", GetSecureSignedToken( sPrefix, AV23ListGen, context));
            AV25SupplierGen_Id = cgiGet( edtavSuppliergen_id_Internalname);
            AssignAttri(sPrefix, false, "AV25SupplierGen_Id", AV25SupplierGen_Id);
            AV26ListGenPre = StringUtil.StrToBool( cgiGet( chkavListgenpre_Internalname));
            AssignAttri(sPrefix, false, "AV26ListGenPre", AV26ListGenPre);
            A51SupplierAgbName = cgiGet( edtSupplierAgbName_Internalname);
            AssignAttri(sPrefix, false, "A51SupplierAgbName", A51SupplierAgbName);
            AV22ListAgb = StringUtil.StrToBool( cgiGet( chkavListagb_Internalname));
            AssignAttri(sPrefix, false, "AV22ListAgb", AV22ListAgb);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTAGB", GetSecureSignedToken( sPrefix, AV22ListAgb, context));
            AV24SupplierAgb_Id = cgiGet( edtavSupplieragb_id_Internalname);
            AssignAttri(sPrefix, false, "AV24SupplierAgb_Id", AV24SupplierAgb_Id);
            AV27ListAgbPre = StringUtil.StrToBool( cgiGet( chkavListagbpre_Internalname));
            AssignAttri(sPrefix, false, "AV27ListAgbPre", AV27ListAgbPre);
            A266ProductServiceTileName = cgiGet( edtProductServiceTileName_Internalname);
            AssignAttri(sPrefix, false, "A266ProductServiceTileName", A266ProductServiceTileName);
            A61ProductServiceImage = cgiGet( imgProductServiceImage_Internalname);
            AssignAttri(sPrefix, false, "A61ProductServiceImage", A61ProductServiceImage);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Trn_ProductServiceGeneral");
            A338ProductServiceGroup = cgiGet( edtProductServiceGroup_Internalname);
            AssignAttri(sPrefix, false, "A338ProductServiceGroup", A338ProductServiceGroup);
            forbiddenHiddens.Add("ProductServiceGroup", StringUtil.RTrim( context.localUtil.Format( A338ProductServiceGroup, "")));
            AV23ListGen = StringUtil.StrToBool( cgiGet( chkavListgen_Internalname));
            AssignAttri(sPrefix, false, "AV23ListGen", AV23ListGen);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTGEN", GetSecureSignedToken( sPrefix, AV23ListGen, context));
            forbiddenHiddens.Add("ListGen", StringUtil.BoolToStr( AV23ListGen));
            AV22ListAgb = StringUtil.StrToBool( cgiGet( chkavListagb_Internalname));
            AssignAttri(sPrefix, false, "AV22ListAgb", AV22ListAgb);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLISTAGB", GetSecureSignedToken( sPrefix, AV22ListAgb, context));
            forbiddenHiddens.Add("ListAgb", StringUtil.BoolToStr( AV22ListAgb));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("trn_productservicegeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
            GXALOCATIONID_html4P2( A11OrganisationId) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E114P2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E114P2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         chkavListgen.Visible = 0;
         AssignProp(sPrefix, false, chkavListgen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListgen.Visible), 5, 0), true);
         chkavListagb.Visible = 0;
         AssignProp(sPrefix, false, chkavListagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagb.Visible), 5, 0), true);
         chkavListagbpre.Visible = 0;
         AssignProp(sPrefix, false, chkavListagbpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Visible), 5, 0), true);
         chkavListgenpre.Visible = 0;
         AssignProp(sPrefix, false, chkavListgenpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListgenpre.Visible), 5, 0), true);
         cellListagb_cell_Class = "Invisible";
         AssignProp(sPrefix, false, cellListagb_cell_Internalname, "Class", cellListagb_cell_Class, true);
         cellListagb_cell_Class = "Invisible";
         AssignProp(sPrefix, false, cellListagb_cell_Internalname, "Class", cellListagb_cell_Class, true);
         cellListagbpre_cell_Class = "Invisible";
         AssignProp(sPrefix, false, cellListagbpre_cell_Internalname, "Class", cellListagbpre_cell_Class, true);
         cellListgen_cell_Class = "Invisible";
         AssignProp(sPrefix, false, cellListgen_cell_Internalname, "Class", cellListgen_cell_Class, true);
         cellListgenpre_cell_Class = "Invisible";
         AssignProp(sPrefix, false, cellListgenpre_cell_Internalname, "Class", cellListgenpre_cell_Class, true);
         edtSupplierAgbName_Class = "ForceReadOnlyAttribute";
         AssignProp(sPrefix, false, edtSupplierAgbName_Internalname, "Class", edtSupplierAgbName_Class, true);
         edtSupplierGenCompanyName_Class = "ForceReadOnlyAttribute";
         AssignProp(sPrefix, false, edtSupplierGenCompanyName_Internalname, "Class", edtSupplierGenCompanyName_Class, true);
         tblTablemergedsuppliergencompanyname_Class = "MergedCustomTableServiceSupplier";
         AssignProp(sPrefix, false, tblTablemergedsuppliergencompanyname_Internalname, "Class", tblTablemergedsuppliergencompanyname_Class, true);
         tblTablemergedsupplieragbname_Class = "MergedCustomTableServiceSupplier";
         AssignProp(sPrefix, false, tblTablemergedsupplieragbname_Internalname, "Class", tblTablemergedsupplieragbname_Class, true);
         GXt_objcol_SdtSDT_FileUploadData1 = AV31FilesToUpdate;
         new prc_getserviceimages(context ).execute(  A58ProductServiceId, out  GXt_objcol_SdtSDT_FileUploadData1) ;
         AV31FilesToUpdate = GXt_objcol_SdtSDT_FileUploadData1;
         Imageuploaduc_Isreadonlymode = context.GetMessage( "true", "");
         ucImageuploaduc.SendProperty(context, sPrefix, false, Imageuploaduc_Internalname, "isReadOnlyMode", Imageuploaduc_Isreadonlymode);
      }

      protected void nextLoad( )
      {
      }

      protected void E124P2( )
      {
         /* Load Routine */
         returnInSub = false;
         Gx_mode = "DSP";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         lblTransactiondetail_descriptiontext_Caption = A60ProductServiceDescription;
         AssignProp(sPrefix, false, lblTransactiondetail_descriptiontext_Internalname, "Caption", lblTransactiondetail_descriptiontext_Caption, true);
         GXt_char2 = AV29SupplierLocation;
         new prc_getsupplierlocationname(context ).execute(  A338ProductServiceGroup, out  GXt_char2) ;
         AV29SupplierLocation = GXt_char2;
         AssignAttri(sPrefix, false, "AV29SupplierLocation", AV29SupplierLocation);
         GXt_boolean3 = AV21TempBoolean;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_supplieragbview_Execute", out  GXt_boolean3) ;
         AV21TempBoolean = GXt_boolean3;
         if ( AV21TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_supplieragbview.aspx"+UrlEncode(A49SupplierAgbId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtSupplierAgbName_Link = formatLink("trn_supplieragbview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtSupplierAgbName_Internalname, "Link", edtSupplierAgbName_Link, true);
         }
         GXt_boolean3 = AV21TempBoolean;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_suppliergenview_Execute", out  GXt_boolean3) ;
         AV21TempBoolean = GXt_boolean3;
         if ( AV21TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_suppliergenview.aspx"+UrlEncode(A42SupplierGenId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtSupplierGenCompanyName_Link = formatLink("trn_suppliergenview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtSupplierGenCompanyName_Internalname, "Link", edtSupplierGenCompanyName_Link, true);
         }
         edtProductServiceId_Visible = 0;
         AssignProp(sPrefix, false, edtProductServiceId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         edtProductServiceTileName_Visible = 0;
         AssignProp(sPrefix, false, edtProductServiceTileName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceTileName_Visible), 5, 0), true);
         imgProductServiceImage_Visible = 0;
         AssignProp(sPrefix, false, imgProductServiceImage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgProductServiceImage_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) )
         {
            edtavSupplierlocation_Visible = 0;
            AssignProp(sPrefix, false, edtavSupplierlocation_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplierlocation_Visible), 5, 0), true);
            divSupplierlocation_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divSupplierlocation_cell_Internalname, "Class", divSupplierlocation_cell_Class, true);
         }
         else
         {
            edtavSupplierlocation_Visible = 1;
            AssignProp(sPrefix, false, edtavSupplierlocation_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplierlocation_Visible), 5, 0), true);
            divSupplierlocation_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divSupplierlocation_cell_Internalname, "Class", divSupplierlocation_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            Productservicedescription_Visible = false;
            AssignProp(sPrefix, false, Productservicedescription_Internalname, "Visible", StringUtil.BoolToStr( Productservicedescription_Visible), true);
            divProductservicedescription_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divProductservicedescription_cell_Internalname, "Class", divProductservicedescription_cell_Class, true);
         }
         else
         {
            Productservicedescription_Visible = true;
            AssignProp(sPrefix, false, Productservicedescription_Internalname, "Visible", StringUtil.BoolToStr( Productservicedescription_Visible), true);
            divProductservicedescription_cell_Class = "col-xs-12 DataContentCell CKEditor";
            AssignProp(sPrefix, false, divProductservicedescription_cell_Internalname, "Class", divProductservicedescription_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            chkavListagbpre.Visible = 0;
            AssignProp(sPrefix, false, chkavListagbpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Visible), 5, 0), true);
            cellListagbpre_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellListagbpre_cell_Internalname, "Class", cellListagbpre_cell_Class, true);
         }
         else
         {
            chkavListagbpre.Visible = 1;
            AssignProp(sPrefix, false, chkavListagbpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagbpre.Visible), 5, 0), true);
            cellListagbpre_cell_Class = "DataContentCell";
            AssignProp(sPrefix, false, cellListagbpre_cell_Internalname, "Class", cellListagbpre_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            chkavListagb.Visible = 0;
            AssignProp(sPrefix, false, chkavListagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagb.Visible), 5, 0), true);
            cellListagb_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellListagb_cell_Internalname, "Class", cellListagb_cell_Class, true);
         }
         else
         {
            chkavListagb.Visible = 1;
            AssignProp(sPrefix, false, chkavListagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListagb.Visible), 5, 0), true);
            cellListagb_cell_Class = "DataContentCell";
            AssignProp(sPrefix, false, cellListagb_cell_Internalname, "Class", cellListagb_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            chkavListgenpre.Visible = 0;
            AssignProp(sPrefix, false, chkavListgenpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListgenpre.Visible), 5, 0), true);
            cellListgenpre_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellListgenpre_cell_Internalname, "Class", cellListgenpre_cell_Class, true);
         }
         else
         {
            chkavListgenpre.Visible = 1;
            AssignProp(sPrefix, false, chkavListgenpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListgenpre.Visible), 5, 0), true);
            cellListgenpre_cell_Class = "DataContentCell";
            AssignProp(sPrefix, false, cellListgenpre_cell_Internalname, "Class", cellListgenpre_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            chkavListgen.Visible = 0;
            AssignProp(sPrefix, false, chkavListgen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListgen.Visible), 5, 0), true);
            cellListgen_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellListgen_cell_Internalname, "Class", cellListgen_cell_Class, true);
         }
         else
         {
            chkavListgen.Visible = 1;
            AssignProp(sPrefix, false, chkavListgen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavListgen.Visible), 5, 0), true);
            cellListgen_cell_Class = "DataContentCell";
            AssignProp(sPrefix, false, cellListgen_cell_Internalname, "Class", cellListgen_cell_Class, true);
         }
         if ( ! ( ( AV28isManager ) ) )
         {
            dynLocationId.Visible = 0;
            AssignProp(sPrefix, false, dynLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynLocationId.Visible), 5, 0), true);
            divLocationid_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divLocationid_cell_Internalname, "Class", divLocationid_cell_Class, true);
         }
         else
         {
            dynLocationId.Visible = 1;
            AssignProp(sPrefix, false, dynLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynLocationId.Visible), 5, 0), true);
            divLocationid_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divLocationid_cell_Internalname, "Class", divLocationid_cell_Class, true);
         }
         divTransactiondetail_productsevicetable_Visible = (((StringUtil.StrCmp(Gx_mode, "DSP")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_productsevicetable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_productsevicetable_Visible), 5, 0), true);
         divTransactiondetail_tablegen_Visible = (((StringUtil.StrCmp(A338ProductServiceGroup, "Supplier")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_tablegen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_tablegen_Visible), 5, 0), true);
         divTransactiondetail_tableagb_Visible = (((StringUtil.StrCmp(A338ProductServiceGroup, " AGB Supplier")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_tableagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_tableagb_Visible), 5, 0), true);
         divTransactiondetail_supplieragb_Visible = ((!AV22ListAgb) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_supplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_supplieragb_Visible), 5, 0), true);
         divTransactiondetail_supplieragbpre_Visible = (((AV22ListAgb)) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_supplieragbpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_supplieragbpre_Visible), 5, 0), true);
         divTransactiondetail_suppliergen_Visible = ((!AV23ListGen) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_suppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_suppliergen_Visible), 5, 0), true);
         divTransactiondetail_suppliergenpre_Visible = (((AV23ListGen)) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_suppliergenpre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_suppliergenpre_Visible), 5, 0), true);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29SupplierLocation)) )
         {
            edtavSupplierlocation_Visible = 0;
            AssignProp(sPrefix, false, edtavSupplierlocation_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplierlocation_Visible), 5, 0), true);
            edtProductServiceGroup_Visible = 1;
            AssignProp(sPrefix, false, edtProductServiceGroup_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceGroup_Visible), 5, 0), true);
         }
         else
         {
            edtavSupplierlocation_Visible = 1;
            AssignProp(sPrefix, false, edtavSupplierlocation_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplierlocation_Visible), 5, 0), true);
            edtProductServiceGroup_Visible = 0;
            AssignProp(sPrefix, false, edtProductServiceGroup_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceGroup_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV34Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Trn_ProductService";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table4_121_4P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsupplieragb_id_Internalname, tblTablemergedsupplieragb_id_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSupplieragb_id_Internalname, context.GetMessage( "Supplier Agb_Id", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSupplieragb_id_Internalname, AV24SupplierAgb_Id, StringUtil.RTrim( context.localUtil.Format( AV24SupplierAgb_Id, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSupplieragb_id_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSupplieragb_id_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellListagbpre_cell_Internalname+"\"  class='"+cellListagbpre_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavListagbpre_Internalname, context.GetMessage( "List Agb Pre", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavListagbpre_Internalname, StringUtil.BoolToStr( AV27ListAgbPre), "", context.GetMessage( "List Agb Pre", ""), chkavListagbpre.Visible, chkavListagbpre.Enabled, "true", context.GetMessage( "Preffered", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(128, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,128);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_121_4P2e( true) ;
         }
         else
         {
            wb_table4_121_4P2e( false) ;
         }
      }

      protected void wb_table3_103_4P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsupplieragbname_Internalname, tblTablemergedsupplieragbname_Internalname, "", tblTablemergedsupplieragbname_Class, 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierAgbName_Internalname, context.GetMessage( "Supplier Agb Name", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierAgbName_Internalname, A51SupplierAgbName, StringUtil.RTrim( context.localUtil.Format( A51SupplierAgbName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSupplierAgbName_Link, "", "", "", edtSupplierAgbName_Jsonclick, 0, edtSupplierAgbName_Class, "", "", "", "", 1, edtSupplierAgbName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellListagb_cell_Internalname+"\"  class='"+cellListagb_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavListagb_Internalname, context.GetMessage( "List Agb", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavListagb_Internalname, StringUtil.BoolToStr( AV22ListAgb), "", context.GetMessage( "List Agb", ""), chkavListagb.Visible, chkavListagb.Enabled, "true", context.GetMessage( "Preffered", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(110, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,110);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_103_4P2e( true) ;
         }
         else
         {
            wb_table3_103_4P2e( false) ;
         }
      }

      protected void wb_table2_82_4P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsuppliergen_id_Internalname, tblTablemergedsuppliergen_id_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSuppliergen_id_Internalname, context.GetMessage( "Supplier Gen_Id", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSuppliergen_id_Internalname, AV25SupplierGen_Id, StringUtil.RTrim( context.localUtil.Format( AV25SupplierGen_Id, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSuppliergen_id_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSuppliergen_id_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellListgenpre_cell_Internalname+"\"  class='"+cellListgenpre_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavListgenpre_Internalname, context.GetMessage( "List Gen Pre", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavListgenpre_Internalname, StringUtil.BoolToStr( AV26ListGenPre), "", context.GetMessage( "List Gen Pre", ""), chkavListgenpre.Visible, chkavListgenpre.Enabled, "true", context.GetMessage( "Preffered", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(89, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,89);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_82_4P2e( true) ;
         }
         else
         {
            wb_table2_82_4P2e( false) ;
         }
      }

      protected void wb_table1_64_4P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsuppliergencompanyname_Internalname, tblTablemergedsuppliergencompanyname_Internalname, "", tblTablemergedsuppliergencompanyname_Class, 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierGenCompanyName_Internalname, context.GetMessage( "Company Name", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplierGenCompanyName_Internalname, A44SupplierGenCompanyName, StringUtil.RTrim( context.localUtil.Format( A44SupplierGenCompanyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSupplierGenCompanyName_Link, "", "", "", edtSupplierGenCompanyName_Jsonclick, 0, edtSupplierGenCompanyName_Class, "", "", "", "", 1, edtSupplierGenCompanyName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ProductServiceGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellListgen_cell_Internalname+"\"  class='"+cellListgen_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavListgen_Internalname, context.GetMessage( "List Gen", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavListgen_Internalname, StringUtil.BoolToStr( AV23ListGen), "", context.GetMessage( "List Gen", ""), chkavListgen.Visible, chkavListgen.Enabled, "true", context.GetMessage( "Preffered", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(71, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,71);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_64_4P2e( true) ;
         }
         else
         {
            wb_table1_64_4P2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A58ProductServiceId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A58ProductServiceId", A58ProductServiceId.ToString());
         A29LocationId = (Guid)getParm(obj,1);
         AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = (Guid)getParm(obj,2);
         AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
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
         PA4P2( ) ;
         WS4P2( ) ;
         WE4P2( ) ;
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
         sCtrlA58ProductServiceId = (string)((string)getParm(obj,0));
         sCtrlA29LocationId = (string)((string)getParm(obj,1));
         sCtrlA11OrganisationId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4P2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_productservicegeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4P2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A58ProductServiceId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = (Guid)getParm(obj,4);
            AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         wcpOA58ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA58ProductServiceId"));
         wcpOA29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA29LocationId"));
         wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
         if ( ! GetJustCreated( ) && ( ( A58ProductServiceId != wcpOA58ProductServiceId ) || ( A29LocationId != wcpOA29LocationId ) || ( A11OrganisationId != wcpOA11OrganisationId ) ) )
         {
            setjustcreated();
         }
         wcpOA58ProductServiceId = A58ProductServiceId;
         wcpOA29LocationId = A29LocationId;
         wcpOA11OrganisationId = A11OrganisationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA58ProductServiceId = cgiGet( sPrefix+"A58ProductServiceId_CTRL");
         if ( StringUtil.Len( sCtrlA58ProductServiceId) > 0 )
         {
            A58ProductServiceId = StringUtil.StrToGuid( cgiGet( sCtrlA58ProductServiceId));
            AssignAttri(sPrefix, false, "A58ProductServiceId", A58ProductServiceId.ToString());
         }
         else
         {
            A58ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"A58ProductServiceId_PARM"));
         }
         sCtrlA29LocationId = cgiGet( sPrefix+"A29LocationId_CTRL");
         if ( StringUtil.Len( sCtrlA29LocationId) > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( cgiGet( sCtrlA29LocationId));
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         }
         else
         {
            A29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"A29LocationId_PARM"));
         }
         sCtrlA11OrganisationId = cgiGet( sPrefix+"A11OrganisationId_CTRL");
         if ( StringUtil.Len( sCtrlA11OrganisationId) > 0 )
         {
            A11OrganisationId = StringUtil.StrToGuid( cgiGet( sCtrlA11OrganisationId));
            AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            A11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"A11OrganisationId_PARM"));
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
         PA4P2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4P2( ) ;
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
         WS4P2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A58ProductServiceId_PARM", A58ProductServiceId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA58ProductServiceId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A58ProductServiceId_CTRL", StringUtil.RTrim( sCtrlA58ProductServiceId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A29LocationId_PARM", A29LocationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA29LocationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A29LocationId_CTRL", StringUtil.RTrim( sCtrlA29LocationId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A11OrganisationId_PARM", A11OrganisationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA11OrganisationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A11OrganisationId_CTRL", StringUtil.RTrim( sCtrlA11OrganisationId));
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
         WE4P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025630933363", true, true);
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
         context.AddJavascriptSource("trn_productservicegeneral.js", "?2025630933364", false, true);
         context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynLocationId.Name = "LOCATIONID";
         dynLocationId.WebTags = "";
         cmbProductServiceClass.Name = "PRODUCTSERVICECLASS";
         cmbProductServiceClass.WebTags = "";
         cmbProductServiceClass.addItem("", context.GetMessage( "Select Category", ""), 0);
         cmbProductServiceClass.addItem("My Living", context.GetMessage( "My Living", ""), 0);
         cmbProductServiceClass.addItem("My Care", context.GetMessage( "My Care", ""), 0);
         cmbProductServiceClass.addItem("My Services", context.GetMessage( "My Services", ""), 0);
         if ( cmbProductServiceClass.ItemCount > 0 )
         {
         }
         chkavListgen.Name = "vLISTGEN";
         chkavListgen.WebTags = "";
         chkavListgen.Caption = context.GetMessage( "List Gen", "");
         AssignProp(sPrefix, false, chkavListgen_Internalname, "TitleCaption", chkavListgen.Caption, true);
         chkavListgen.CheckedValue = "false";
         chkavListgenpre.Name = "vLISTGENPRE";
         chkavListgenpre.WebTags = "";
         chkavListgenpre.Caption = context.GetMessage( "List Gen Pre", "");
         AssignProp(sPrefix, false, chkavListgenpre_Internalname, "TitleCaption", chkavListgenpre.Caption, true);
         chkavListgenpre.CheckedValue = "false";
         chkavListagb.Name = "vLISTAGB";
         chkavListagb.WebTags = "";
         chkavListagb.Caption = context.GetMessage( "List Agb", "");
         AssignProp(sPrefix, false, chkavListagb_Internalname, "TitleCaption", chkavListagb.Caption, true);
         chkavListagb.CheckedValue = "false";
         chkavListagbpre.Name = "vLISTAGBPRE";
         chkavListagbpre.WebTags = "";
         chkavListagbpre.Caption = context.GetMessage( "List Agb Pre", "");
         AssignProp(sPrefix, false, chkavListagbpre_Internalname, "TitleCaption", chkavListagbpre.Caption, true);
         chkavListagbpre.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynLocationId_Internalname = sPrefix+"LOCATIONID";
         divLocationid_cell_Internalname = sPrefix+"LOCATIONID_CELL";
         edtProductServiceName_Internalname = sPrefix+"PRODUCTSERVICENAME";
         lblProductserviceimagetext_Internalname = sPrefix+"PRODUCTSERVICEIMAGETEXT";
         Imageuploaduc_Internalname = sPrefix+"IMAGEUPLOADUC";
         divUcfilecell_Internalname = sPrefix+"UCFILECELL";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         cmbProductServiceClass_Internalname = sPrefix+"PRODUCTSERVICECLASS";
         edtProductServiceGroup_Internalname = sPrefix+"PRODUCTSERVICEGROUP";
         edtavSupplierlocation_Internalname = sPrefix+"vSUPPLIERLOCATION";
         divSupplierlocation_cell_Internalname = sPrefix+"SUPPLIERLOCATION_CELL";
         lblTextblocksuppliergencompanyname_Internalname = sPrefix+"TEXTBLOCKSUPPLIERGENCOMPANYNAME";
         edtSupplierGenCompanyName_Internalname = sPrefix+"SUPPLIERGENCOMPANYNAME";
         chkavListgen_Internalname = sPrefix+"vLISTGEN";
         cellListgen_cell_Internalname = sPrefix+"LISTGEN_CELL";
         tblTablemergedsuppliergencompanyname_Internalname = sPrefix+"TABLEMERGEDSUPPLIERGENCOMPANYNAME";
         divTablesplittedsuppliergencompanyname_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERGENCOMPANYNAME";
         divTransactiondetail_suppliergen_Internalname = sPrefix+"TRANSACTIONDETAIL_SUPPLIERGEN";
         lblTextblocksuppliergen_id_Internalname = sPrefix+"TEXTBLOCKSUPPLIERGEN_ID";
         edtavSuppliergen_id_Internalname = sPrefix+"vSUPPLIERGEN_ID";
         chkavListgenpre_Internalname = sPrefix+"vLISTGENPRE";
         cellListgenpre_cell_Internalname = sPrefix+"LISTGENPRE_CELL";
         tblTablemergedsuppliergen_id_Internalname = sPrefix+"TABLEMERGEDSUPPLIERGEN_ID";
         divTablesplittedsuppliergen_id_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERGEN_ID";
         divTransactiondetail_suppliergenpre_Internalname = sPrefix+"TRANSACTIONDETAIL_SUPPLIERGENPRE";
         divTransactiondetail_tablegen_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEGEN";
         lblTextblocksupplieragbname_Internalname = sPrefix+"TEXTBLOCKSUPPLIERAGBNAME";
         edtSupplierAgbName_Internalname = sPrefix+"SUPPLIERAGBNAME";
         chkavListagb_Internalname = sPrefix+"vLISTAGB";
         cellListagb_cell_Internalname = sPrefix+"LISTAGB_CELL";
         tblTablemergedsupplieragbname_Internalname = sPrefix+"TABLEMERGEDSUPPLIERAGBNAME";
         divTablesplittedsupplieragbname_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERAGBNAME";
         divTransactiondetail_supplieragb_Internalname = sPrefix+"TRANSACTIONDETAIL_SUPPLIERAGB";
         lblTextblocksupplieragb_id_Internalname = sPrefix+"TEXTBLOCKSUPPLIERAGB_ID";
         edtavSupplieragb_id_Internalname = sPrefix+"vSUPPLIERAGB_ID";
         chkavListagbpre_Internalname = sPrefix+"vLISTAGBPRE";
         cellListagbpre_cell_Internalname = sPrefix+"LISTAGBPRE_CELL";
         tblTablemergedsupplieragb_id_Internalname = sPrefix+"TABLEMERGEDSUPPLIERAGB_ID";
         divTablesplittedsupplieragb_id_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERAGB_ID";
         divTransactiondetail_supplieragbpre_Internalname = sPrefix+"TRANSACTIONDETAIL_SUPPLIERAGBPRE";
         divTransactiondetail_tableagb_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEAGB";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         Productservicedescription_Internalname = sPrefix+"PRODUCTSERVICEDESCRIPTION";
         divProductservicedescription_cell_Internalname = sPrefix+"PRODUCTSERVICEDESCRIPTION_CELL";
         lblTransactiondetail_textblockdescriptionlabel_Internalname = sPrefix+"TRANSACTIONDETAIL_TEXTBLOCKDESCRIPTIONLABEL";
         lblTransactiondetail_descriptiontext_Internalname = sPrefix+"TRANSACTIONDETAIL_DESCRIPTIONTEXT";
         divUnnamedtable4_Internalname = sPrefix+"UNNAMEDTABLE4";
         divTransactiondetail_productsevicetable_Internalname = sPrefix+"TRANSACTIONDETAIL_PRODUCTSEVICETABLE";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTable_Internalname = sPrefix+"TABLE";
         edtProductServiceId_Internalname = sPrefix+"PRODUCTSERVICEID";
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID";
         edtProductServiceTileName_Internalname = sPrefix+"PRODUCTSERVICETILENAME";
         imgProductServiceImage_Internalname = sPrefix+"PRODUCTSERVICEIMAGE";
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
         chkavListagbpre.Caption = context.GetMessage( "List Agb Pre", "");
         chkavListagb.Caption = context.GetMessage( "List Agb", "");
         chkavListgenpre.Caption = context.GetMessage( "List Gen Pre", "");
         chkavListgen.Caption = context.GetMessage( "List Gen", "");
         chkavListgen.Enabled = 1;
         cellListgen_cell_Class = "";
         edtSupplierGenCompanyName_Jsonclick = "";
         chkavListgenpre.Enabled = 1;
         cellListgenpre_cell_Class = "";
         edtavSuppliergen_id_Jsonclick = "";
         edtavSuppliergen_id_Enabled = 1;
         chkavListagb.Enabled = 1;
         cellListagb_cell_Class = "";
         edtSupplierAgbName_Jsonclick = "";
         chkavListagbpre.Enabled = 1;
         cellListagbpre_cell_Class = "";
         edtavSupplieragb_id_Jsonclick = "";
         edtavSupplieragb_id_Enabled = 1;
         edtSupplierGenCompanyName_Link = "";
         edtSupplierAgbName_Link = "";
         tblTablemergedsupplieragbname_Class = "TableMerged";
         tblTablemergedsuppliergencompanyname_Class = "TableMerged";
         edtSupplierGenCompanyName_Class = "Attribute";
         edtSupplierAgbName_Class = "Attribute";
         chkavListgenpre.Visible = 1;
         chkavListagbpre.Visible = 1;
         chkavListagb.Visible = 1;
         chkavListgen.Visible = 1;
         imgProductServiceImage_Enabled = 0;
         edtProductServiceTileName_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtProductServiceId_Enabled = 0;
         edtSupplierAgbName_Enabled = 0;
         edtSupplierGenCompanyName_Enabled = 0;
         imgProductServiceImage_Visible = 1;
         edtProductServiceTileName_Jsonclick = "";
         edtProductServiceTileName_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Visible = 1;
         edtProductServiceId_Jsonclick = "";
         edtProductServiceId_Visible = 1;
         lblTransactiondetail_descriptiontext_Caption = "";
         divTransactiondetail_productsevicetable_Visible = 1;
         Productservicedescription_Enabled = Convert.ToBoolean( 0);
         divProductservicedescription_cell_Class = "col-xs-12";
         divTransactiondetail_supplieragbpre_Visible = 1;
         divTransactiondetail_supplieragb_Visible = 1;
         divTransactiondetail_tableagb_Visible = 1;
         divTransactiondetail_suppliergenpre_Visible = 1;
         divTransactiondetail_suppliergen_Visible = 1;
         divTransactiondetail_tablegen_Visible = 1;
         edtavSupplierlocation_Enabled = 1;
         edtavSupplierlocation_Visible = 1;
         divSupplierlocation_cell_Class = "col-xs-12";
         edtProductServiceGroup_Enabled = 0;
         edtProductServiceGroup_Visible = 1;
         cmbProductServiceClass_Jsonclick = "";
         cmbProductServiceClass.Enabled = 0;
         edtProductServiceName_Jsonclick = "";
         edtProductServiceName_Enabled = 0;
         dynLocationId_Jsonclick = "";
         dynLocationId.Enabled = 0;
         dynLocationId.Visible = 1;
         divLocationid_cell_Class = "col-xs-12";
         Productservicedescription_Visible = Convert.ToBoolean( -1);
         Productservicedescription_Captionposition = "Left";
         Productservicedescription_Captionstyle = "";
         Productservicedescription_Captionclass = "col-sm-4 AttributeLabel";
         Productservicedescription_Toolbarcancollapse = Convert.ToBoolean( 0);
         Productservicedescription_Customconfiguration = "myconfig.js";
         Productservicedescription_Customtoolbar = "myToolbar";
         Productservicedescription_Toolbar = "Custom";
         Productservicedescription_Skin = "default";
         Productservicedescription_Height = "250";
         Productservicedescription_Width = "100%";
         Imageuploaduc_Maxfilesize = "10";
         Imageuploaduc_Isreadonlymode = "false";
         Imageuploaduc_Maxnumberoffiles = "5";
         Imageuploaduc_Faileduploadmessage = "Upload Failed";
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public void Valid_Organisationid( )
      {
         A29LocationId = StringUtil.StrToGuid( dynLocationId.CurrentValue);
         GXALOCATIONID_html4P2( A11OrganisationId) ;
         dynload_actions( ) ;
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
         }
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         dynLocationId.CurrentValue = A29LocationId.ToString();
         AssignProp(sPrefix, false, dynLocationId_Internalname, "Values", dynLocationId.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV26ListGenPre","fld":"vLISTGENPRE"},{"av":"AV27ListAgbPre","fld":"vLISTAGBPRE"},{"av":"AV22ListAgb","fld":"vLISTAGB","hsh":true},{"av":"AV23ListGen","fld":"vLISTGEN","hsh":true},{"av":"A338ProductServiceGroup","fld":"PRODUCTSERVICEGROUP"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
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
         wcpOA58ProductServiceId = Guid.Empty;
         wcpOA29LocationId = Guid.Empty;
         wcpOA11OrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV34Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         A338ProductServiceGroup = "";
         AV32UploadedFiles = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV31FilesToUpdate = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         A60ProductServiceDescription = "";
         GX_FocusControl = "";
         TempTags = "";
         A59ProductServiceName = "";
         lblProductserviceimagetext_Jsonclick = "";
         ucImageuploaduc = new GXUserControl();
         A370ProductServiceClass = "";
         ClassString = "";
         StyleString = "";
         AV29SupplierLocation = "";
         lblTextblocksuppliergencompanyname_Jsonclick = "";
         lblTextblocksuppliergen_id_Jsonclick = "";
         lblTextblocksupplieragbname_Jsonclick = "";
         lblTextblocksupplieragb_id_Jsonclick = "";
         ucProductservicedescription = new GXUserControl();
         ProductServiceDescription = "";
         lblTransactiondetail_textblockdescriptionlabel_Jsonclick = "";
         lblTransactiondetail_descriptiontext_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         A266ProductServiceTileName = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         sImgUrl = "";
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
         H004P2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H004P2_A29LocationId = new Guid[] {Guid.Empty} ;
         H004P2_A31LocationName = new string[] {""} ;
         H004P3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H004P3_A29LocationId = new Guid[] {Guid.Empty} ;
         H004P3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H004P3_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H004P3_n49SupplierAgbId = new bool[] {false} ;
         H004P3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H004P3_n42SupplierGenId = new bool[] {false} ;
         H004P3_A40000ProductServiceImage_GXI = new string[] {""} ;
         H004P3_A266ProductServiceTileName = new string[] {""} ;
         H004P3_A60ProductServiceDescription = new string[] {""} ;
         H004P3_A51SupplierAgbName = new string[] {""} ;
         H004P3_A44SupplierGenCompanyName = new string[] {""} ;
         H004P3_A338ProductServiceGroup = new string[] {""} ;
         H004P3_A370ProductServiceClass = new string[] {""} ;
         H004P3_A59ProductServiceName = new string[] {""} ;
         H004P3_A61ProductServiceImage = new string[] {""} ;
         A49SupplierAgbId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         A51SupplierAgbName = "";
         A44SupplierGenCompanyName = "";
         AV25SupplierGen_Id = "";
         AV24SupplierAgb_Id = "";
         hsh = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_objcol_SdtSDT_FileUploadData1 = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         Gx_mode = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         sStyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA58ProductServiceId = "";
         sCtrlA29LocationId = "";
         sCtrlA11OrganisationId = "";
         Z29LocationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productservicegeneral__default(),
            new Object[][] {
                new Object[] {
               H004P2_A11OrganisationId, H004P2_A29LocationId, H004P2_A31LocationName
               }
               , new Object[] {
               H004P3_A58ProductServiceId, H004P3_A29LocationId, H004P3_A11OrganisationId, H004P3_A49SupplierAgbId, H004P3_n49SupplierAgbId, H004P3_A42SupplierGenId, H004P3_n42SupplierGenId, H004P3_A40000ProductServiceImage_GXI, H004P3_A266ProductServiceTileName, H004P3_A60ProductServiceDescription,
               H004P3_A51SupplierAgbName, H004P3_A44SupplierGenCompanyName, H004P3_A338ProductServiceGroup, H004P3_A370ProductServiceClass, H004P3_A59ProductServiceName, H004P3_A61ProductServiceImage
               }
            }
         );
         AV34Pgmname = "Trn_ProductServiceGeneral";
         /* GeneXus formulas. */
         AV34Pgmname = "Trn_ProductServiceGeneral";
         edtavSupplierlocation_Enabled = 0;
         chkavListgen.Enabled = 0;
         edtavSuppliergen_id_Enabled = 0;
         chkavListgenpre.Enabled = 0;
         chkavListagb.Enabled = 0;
         edtavSupplieragb_id_Enabled = 0;
         chkavListagbpre.Enabled = 0;
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
      private int edtavSupplierlocation_Enabled ;
      private int edtavSuppliergen_id_Enabled ;
      private int edtavSupplieragb_id_Enabled ;
      private int edtProductServiceName_Enabled ;
      private int edtProductServiceGroup_Visible ;
      private int edtProductServiceGroup_Enabled ;
      private int edtavSupplierlocation_Visible ;
      private int divTransactiondetail_tablegen_Visible ;
      private int divTransactiondetail_suppliergen_Visible ;
      private int divTransactiondetail_suppliergenpre_Visible ;
      private int divTransactiondetail_tableagb_Visible ;
      private int divTransactiondetail_supplieragb_Visible ;
      private int divTransactiondetail_supplieragbpre_Visible ;
      private int divTransactiondetail_productsevicetable_Visible ;
      private int edtProductServiceId_Visible ;
      private int edtOrganisationId_Visible ;
      private int edtProductServiceTileName_Visible ;
      private int imgProductServiceImage_Visible ;
      private int gxdynajaxindex ;
      private int edtSupplierGenCompanyName_Enabled ;
      private int edtSupplierAgbName_Enabled ;
      private int edtProductServiceId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtProductServiceTileName_Enabled ;
      private int imgProductServiceImage_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV34Pgmname ;
      private string edtavSupplierlocation_Internalname ;
      private string chkavListgen_Internalname ;
      private string edtavSuppliergen_id_Internalname ;
      private string chkavListgenpre_Internalname ;
      private string chkavListagb_Internalname ;
      private string edtavSupplieragb_id_Internalname ;
      private string chkavListagbpre_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Imageuploaduc_Faileduploadmessage ;
      private string Imageuploaduc_Maxnumberoffiles ;
      private string Imageuploaduc_Isreadonlymode ;
      private string Imageuploaduc_Maxfilesize ;
      private string Productservicedescription_Width ;
      private string Productservicedescription_Height ;
      private string Productservicedescription_Skin ;
      private string Productservicedescription_Toolbar ;
      private string Productservicedescription_Customtoolbar ;
      private string Productservicedescription_Customconfiguration ;
      private string Productservicedescription_Captionclass ;
      private string Productservicedescription_Captionstyle ;
      private string Productservicedescription_Captionposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divLocationid_cell_Internalname ;
      private string divLocationid_cell_Class ;
      private string dynLocationId_Internalname ;
      private string TempTags ;
      private string dynLocationId_Jsonclick ;
      private string edtProductServiceName_Internalname ;
      private string edtProductServiceName_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblProductserviceimagetext_Internalname ;
      private string lblProductserviceimagetext_Jsonclick ;
      private string divUcfilecell_Internalname ;
      private string Imageuploaduc_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string cmbProductServiceClass_Internalname ;
      private string cmbProductServiceClass_Jsonclick ;
      private string edtProductServiceGroup_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divSupplierlocation_cell_Internalname ;
      private string divSupplierlocation_cell_Class ;
      private string divUnnamedtable3_Internalname ;
      private string divTransactiondetail_tablegen_Internalname ;
      private string divTransactiondetail_suppliergen_Internalname ;
      private string divTablesplittedsuppliergencompanyname_Internalname ;
      private string lblTextblocksuppliergencompanyname_Internalname ;
      private string lblTextblocksuppliergencompanyname_Jsonclick ;
      private string divTransactiondetail_suppliergenpre_Internalname ;
      private string divTablesplittedsuppliergen_id_Internalname ;
      private string lblTextblocksuppliergen_id_Internalname ;
      private string lblTextblocksuppliergen_id_Jsonclick ;
      private string divTransactiondetail_tableagb_Internalname ;
      private string divTransactiondetail_supplieragb_Internalname ;
      private string divTablesplittedsupplieragbname_Internalname ;
      private string lblTextblocksupplieragbname_Internalname ;
      private string lblTextblocksupplieragbname_Jsonclick ;
      private string divTransactiondetail_supplieragbpre_Internalname ;
      private string divTablesplittedsupplieragb_id_Internalname ;
      private string lblTextblocksupplieragb_id_Internalname ;
      private string lblTextblocksupplieragb_id_Jsonclick ;
      private string divProductservicedescription_cell_Internalname ;
      private string divProductservicedescription_cell_Class ;
      private string Productservicedescription_Internalname ;
      private string divTransactiondetail_productsevicetable_Internalname ;
      private string lblTransactiondetail_textblockdescriptionlabel_Internalname ;
      private string lblTransactiondetail_textblockdescriptionlabel_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string lblTransactiondetail_descriptiontext_Internalname ;
      private string lblTransactiondetail_descriptiontext_Caption ;
      private string lblTransactiondetail_descriptiontext_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtProductServiceId_Internalname ;
      private string edtProductServiceId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtProductServiceTileName_Internalname ;
      private string A266ProductServiceTileName ;
      private string edtProductServiceTileName_Jsonclick ;
      private string sImgUrl ;
      private string imgProductServiceImage_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string edtSupplierGenCompanyName_Internalname ;
      private string edtSupplierAgbName_Internalname ;
      private string hsh ;
      private string cellListagb_cell_Class ;
      private string cellListagb_cell_Internalname ;
      private string cellListagbpre_cell_Class ;
      private string cellListagbpre_cell_Internalname ;
      private string cellListgen_cell_Class ;
      private string cellListgen_cell_Internalname ;
      private string cellListgenpre_cell_Class ;
      private string cellListgenpre_cell_Internalname ;
      private string edtSupplierAgbName_Class ;
      private string edtSupplierGenCompanyName_Class ;
      private string tblTablemergedsuppliergencompanyname_Class ;
      private string tblTablemergedsuppliergencompanyname_Internalname ;
      private string tblTablemergedsupplieragbname_Class ;
      private string tblTablemergedsupplieragbname_Internalname ;
      private string Gx_mode ;
      private string GXt_char2 ;
      private string edtSupplierAgbName_Link ;
      private string edtSupplierGenCompanyName_Link ;
      private string sStyleString ;
      private string tblTablemergedsupplieragb_id_Internalname ;
      private string edtavSupplieragb_id_Jsonclick ;
      private string edtSupplierAgbName_Jsonclick ;
      private string tblTablemergedsuppliergen_id_Internalname ;
      private string edtavSuppliergen_id_Jsonclick ;
      private string edtSupplierGenCompanyName_Jsonclick ;
      private string sCtrlA58ProductServiceId ;
      private string sCtrlA29LocationId ;
      private string sCtrlA11OrganisationId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV22ListAgb ;
      private bool AV23ListGen ;
      private bool Productservicedescription_Enabled ;
      private bool Productservicedescription_Toolbarcancollapse ;
      private bool Productservicedescription_Visible ;
      private bool wbLoad ;
      private bool A61ProductServiceImage_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV26ListGenPre ;
      private bool AV27ListAgbPre ;
      private bool n49SupplierAgbId ;
      private bool n42SupplierGenId ;
      private bool returnInSub ;
      private bool AV21TempBoolean ;
      private bool GXt_boolean3 ;
      private bool AV28isManager ;
      private string A60ProductServiceDescription ;
      private string ProductServiceDescription ;
      private string A338ProductServiceGroup ;
      private string A59ProductServiceName ;
      private string A370ProductServiceClass ;
      private string AV29SupplierLocation ;
      private string A40000ProductServiceImage_GXI ;
      private string A51SupplierAgbName ;
      private string A44SupplierGenCompanyName ;
      private string AV25SupplierGen_Id ;
      private string AV24SupplierAgb_Id ;
      private string A61ProductServiceImage ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid wcpOA58ProductServiceId ;
      private Guid wcpOA29LocationId ;
      private Guid wcpOA11OrganisationId ;
      private Guid A49SupplierAgbId ;
      private Guid A42SupplierGenId ;
      private Guid Z29LocationId ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucImageuploaduc ;
      private GXUserControl ucProductservicedescription ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynLocationId ;
      private GXCombobox cmbProductServiceClass ;
      private GXCheckbox chkavListgen ;
      private GXCheckbox chkavListgenpre ;
      private GXCheckbox chkavListagb ;
      private GXCheckbox chkavListagbpre ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV32UploadedFiles ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV31FilesToUpdate ;
      private IDataStoreProvider pr_default ;
      private Guid[] H004P2_A11OrganisationId ;
      private Guid[] H004P2_A29LocationId ;
      private string[] H004P2_A31LocationName ;
      private Guid[] H004P3_A58ProductServiceId ;
      private Guid[] H004P3_A29LocationId ;
      private Guid[] H004P3_A11OrganisationId ;
      private Guid[] H004P3_A49SupplierAgbId ;
      private bool[] H004P3_n49SupplierAgbId ;
      private Guid[] H004P3_A42SupplierGenId ;
      private bool[] H004P3_n42SupplierGenId ;
      private string[] H004P3_A40000ProductServiceImage_GXI ;
      private string[] H004P3_A266ProductServiceTileName ;
      private string[] H004P3_A60ProductServiceDescription ;
      private string[] H004P3_A51SupplierAgbName ;
      private string[] H004P3_A44SupplierGenCompanyName ;
      private string[] H004P3_A338ProductServiceGroup ;
      private string[] H004P3_A370ProductServiceClass ;
      private string[] H004P3_A59ProductServiceName ;
      private string[] H004P3_A61ProductServiceImage ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<SdtSDT_FileUploadData> GXt_objcol_SdtSDT_FileUploadData1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_productservicegeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004P2;
          prmH004P2 = new Object[] {
          };
          Object[] prmH004P3;
          prmH004P3 = new Object[] {
          new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004P2", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004P2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004P3", "SELECT T1.ProductServiceId, T1.LocationId, T1.OrganisationId, T1.SupplierAgbId, T1.SupplierGenId, T1.ProductServiceImage_GXI, T1.ProductServiceTileName, T1.ProductServiceDescription, T2.SupplierAgbName, T3.SupplierGenCompanyName, T1.ProductServiceGroup, T1.ProductServiceClass, T1.ProductServiceName, T1.ProductServiceImage FROM ((Trn_ProductService T1 LEFT JOIN Trn_SupplierAGB T2 ON T2.SupplierAgbId = T1.SupplierAgbId) LEFT JOIN Trn_SupplierGen T3 ON T3.SupplierGenId = T1.SupplierGenId) WHERE T1.ProductServiceId = :ProductServiceId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId ORDER BY T1.ProductServiceId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004P3,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getMultimediaUri(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 20);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((string[]) buf[14])[0] = rslt.getVarchar(13);
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(6));
                return;
       }
    }

 }

}
