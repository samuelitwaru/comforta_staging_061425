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
   public class trn_locationgeneral : GXWebComponent
   {
      public trn_locationgeneral( )
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

      public trn_locationgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId )
      {
         this.A29LocationId = aP0_LocationId;
         this.A11OrganisationId = aP1_OrganisationId;
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "LocationId");
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
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A29LocationId,(Guid)A11OrganisationId});
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
                  gxfirstwebparm = GetFirstPar( "LocationId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "LocationId");
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
            PA422( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV24Pgmname = "Trn_LocationGeneral";
               edtavLocationphonecode_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationphonecode_description_Enabled), 5, 0), true);
               edtavLocationcountry_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationcountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationcountry_description_Enabled), 5, 0), true);
               WS422( ) ;
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
            context.SendWebValue( context.GetMessage( "Trn_Location General", "")) ;
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
            GXEncryptionTmp = "trn_locationgeneral.aspx"+UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_locationgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Trn_LocationGeneral");
         forbiddenHiddens.Add("LocationDescription", A36LocationDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_locationgeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV22UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV22UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILESTOUPDATE", AV21FilesToUpdate);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILESTOUPDATE", AV21FilesToUpdate);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vLOCATIONDESCRIPTIONVAR", AV20LocationDescriptionVar);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA29LocationId", wcpOA29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA11OrganisationId", wcpOA11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"IMAGEUPLOADUC_Faileduploadmessage", StringUtil.RTrim( Imageuploaduc_Faileduploadmessage));
         GxWebStd.gx_hidden_field( context, sPrefix+"IMAGEUPLOADUC_Maxnumberoffiles", StringUtil.RTrim( Imageuploaduc_Maxnumberoffiles));
         GxWebStd.gx_hidden_field( context, sPrefix+"IMAGEUPLOADUC_Isreadonlymode", StringUtil.RTrim( Imageuploaduc_Isreadonlymode));
         GxWebStd.gx_hidden_field( context, sPrefix+"IMAGEUPLOADUC_Maxfilesize", StringUtil.RTrim( Imageuploaduc_Maxfilesize));
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONDESCRIPTIONVAR_Enabled", StringUtil.BoolToStr( Locationdescriptionvar_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONDESCRIPTIONVAR_Width", StringUtil.RTrim( Locationdescriptionvar_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONDESCRIPTIONVAR_Height", StringUtil.RTrim( Locationdescriptionvar_Height));
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONDESCRIPTIONVAR_Skin", StringUtil.RTrim( Locationdescriptionvar_Skin));
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONDESCRIPTIONVAR_Toolbar", StringUtil.RTrim( Locationdescriptionvar_Toolbar));
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONDESCRIPTIONVAR_Customtoolbar", StringUtil.RTrim( Locationdescriptionvar_Customtoolbar));
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONDESCRIPTIONVAR_Customconfiguration", StringUtil.RTrim( Locationdescriptionvar_Customconfiguration));
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONDESCRIPTIONVAR_Captionclass", StringUtil.RTrim( Locationdescriptionvar_Captionclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONDESCRIPTIONVAR_Captionstyle", StringUtil.RTrim( Locationdescriptionvar_Captionstyle));
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONDESCRIPTIONVAR_Captionposition", StringUtil.RTrim( Locationdescriptionvar_Captionposition));
      }

      protected void RenderHtmlCloseForm422( )
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
         return "Trn_LocationGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Location General", "") ;
      }

      protected void WB420( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_locationgeneral.aspx");
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Location Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_LocationGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationName_Internalname, A31LocationName, StringUtil.RTrim( context.localUtil.Format( A31LocationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_LocationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationEmail_Internalname, A34LocationEmail, StringUtil.RTrim( context.localUtil.Format( A34LocationEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A34LocationEmail, "", "", "", edtLocationEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_LocationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, divUnnamedtable5_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_phone_Internalname, context.GetMessage( "Phone", ""), "", "", lblTransactiondetail_phone_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_LocationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable10_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable11_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocationphonecode_description_Internalname, context.GetMessage( "Location Phone Code_Description", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationphonecode_description_Internalname, AV14LocationPhoneCode_Description, StringUtil.RTrim( context.localUtil.Format( AV14LocationPhoneCode_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationphonecode_description_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLocationphonecode_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_LocationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationPhoneNumber_Internalname, context.GetMessage( "Location Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationPhoneNumber_Internalname, A356LocationPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A356LocationPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_LocationGeneral.htm");
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
            GxWebStd.gx_div_start( context, divLocationphone_cell_Internalname, 1, 0, "px", 0, "px", divLocationphone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtLocationPhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationPhone_Internalname, context.GetMessage( "Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A35LocationPhone);
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationPhone_Internalname, StringUtil.RTrim( A35LocationPhone), StringUtil.RTrim( context.localUtil.Format( A35LocationPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtLocationPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationPhone_Visible, edtLocationPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_LocationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblProductserviceimagetext_Internalname, context.GetMessage( "Images", ""), "", "", lblProductserviceimagetext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_LocationGeneral.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUcfilecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucImageuploaduc.SetProperty("FailedUploadMessage", Imageuploaduc_Faileduploadmessage);
            ucImageuploaduc.SetProperty("MaxNumberOfFiles", Imageuploaduc_Maxnumberoffiles);
            ucImageuploaduc.SetProperty("isReadOnlyMode", Imageuploaduc_Isreadonlymode);
            ucImageuploaduc.SetProperty("MaxFileSize", Imageuploaduc_Maxfilesize);
            ucImageuploaduc.SetProperty("UploadedFiles", AV22UploadedFiles);
            ucImageuploaduc.SetProperty("FilesToEdit", AV21FilesToUpdate);
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
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, divUnnamedtable7_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell CKEditor", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Locationdescriptionvar_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Locationdescriptionvar_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucLocationdescriptionvar.SetProperty("Width", Locationdescriptionvar_Width);
            ucLocationdescriptionvar.SetProperty("Height", Locationdescriptionvar_Height);
            ucLocationdescriptionvar.SetProperty("Attribute", AV20LocationDescriptionVar);
            ucLocationdescriptionvar.SetProperty("Skin", Locationdescriptionvar_Skin);
            ucLocationdescriptionvar.SetProperty("Toolbar", Locationdescriptionvar_Toolbar);
            ucLocationdescriptionvar.SetProperty("CustomToolbar", Locationdescriptionvar_Customtoolbar);
            ucLocationdescriptionvar.SetProperty("CustomConfiguration", Locationdescriptionvar_Customconfiguration);
            ucLocationdescriptionvar.SetProperty("CaptionClass", Locationdescriptionvar_Captionclass);
            ucLocationdescriptionvar.SetProperty("CaptionStyle", Locationdescriptionvar_Captionstyle);
            ucLocationdescriptionvar.SetProperty("CaptionPosition", Locationdescriptionvar_Captionposition);
            ucLocationdescriptionvar.Render(context, "fckeditor", Locationdescriptionvar_Internalname, sPrefix+"LOCATIONDESCRIPTIONVARContainer");
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
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, divUnnamedtable8_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_textblockdescriptionlabel_Internalname, context.GetMessage( "Description", ""), "", "", lblTransactiondetail_textblockdescriptionlabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_LocationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", 0, "px", "HTMLTextOverfow", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_descriptiontext_Internalname, lblTransactiondetail_descriptiontext_Caption, "", "", lblTransactiondetail_descriptiontext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DynamicFormHTMLEditor", 0, "", 1, 1, 0, 1, "HLP_Trn_LocationGeneral.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_LocationGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationAddressLine1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationAddressLine1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationAddressLine1_Internalname, A330LocationAddressLine1, StringUtil.RTrim( context.localUtil.Format( A330LocationAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_LocationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationAddressLine2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationAddressLine2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationAddressLine2_Internalname, A331LocationAddressLine2, StringUtil.RTrim( context.localUtil.Format( A331LocationAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_LocationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationZipCode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationZipCode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationZipCode_Internalname, A329LocationZipCode, StringUtil.RTrim( context.localUtil.Format( A329LocationZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_LocationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationCity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationCity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationCity_Internalname, A328LocationCity, StringUtil.RTrim( context.localUtil.Format( A328LocationCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_LocationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLocationcountry_description_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocationcountry_description_Internalname, context.GetMessage( "Country", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationcountry_description_Internalname, AV18LocationCountry_Description, StringUtil.RTrim( context.localUtil.Format( AV18LocationCountry_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationcountry_description_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLocationcountry_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_LocationGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_LocationGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_LocationGeneral.htm");
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A494LocationImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000LocationImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.PathToRelativeUrl( A494LocationImage));
            GxWebStd.gx_bitmap( context, imgLocationImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgLocationImage_Visible, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A494LocationImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_LocationGeneral.htm");
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtLocationDescription_Internalname, A36LocationDescription, "", "", 0, edtLocationDescription_Visible, 0, 0, 40, "chr", 3, "row", 0, StyleString, ClassString, "", "", "2097152", 1, 0, "", "", -1, true, "LongDescription", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_LocationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START422( )
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
            Form.Meta.addItem("description", context.GetMessage( "Trn_Location General", ""), 0) ;
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
               STRUP420( ) ;
            }
         }
      }

      protected void WS422( )
      {
         START422( ) ;
         EVT422( ) ;
      }

      protected void EVT422( )
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
                                 STRUP420( ) ;
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
                                 STRUP420( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11422 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP420( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12422 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP420( ) ;
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
                                 STRUP420( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavLocationphonecode_description_Internalname;
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

      protected void WE422( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm422( ) ;
            }
         }
      }

      protected void PA422( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_locationgeneral.aspx")), "trn_locationgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_locationgeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "LocationId");
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
               GX_FocusControl = edtavLocationphonecode_description_Internalname;
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
         RF422( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV24Pgmname = "Trn_LocationGeneral";
         edtavLocationphonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavLocationphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationphonecode_description_Enabled), 5, 0), true);
         edtavLocationcountry_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavLocationcountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationcountry_description_Enabled), 5, 0), true);
      }

      protected void RF422( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00422 */
            pr_default.execute(0, new Object[] {A29LocationId, A11OrganisationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A36LocationDescription = H00422_A36LocationDescription[0];
               AssignAttri(sPrefix, false, "A36LocationDescription", A36LocationDescription);
               A40000LocationImage_GXI = H00422_A40000LocationImage_GXI[0];
               n40000LocationImage_GXI = H00422_n40000LocationImage_GXI[0];
               AssignProp(sPrefix, false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A494LocationImage))), true);
               AssignProp(sPrefix, false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A494LocationImage), true);
               A328LocationCity = H00422_A328LocationCity[0];
               AssignAttri(sPrefix, false, "A328LocationCity", A328LocationCity);
               A329LocationZipCode = H00422_A329LocationZipCode[0];
               AssignAttri(sPrefix, false, "A329LocationZipCode", A329LocationZipCode);
               A331LocationAddressLine2 = H00422_A331LocationAddressLine2[0];
               AssignAttri(sPrefix, false, "A331LocationAddressLine2", A331LocationAddressLine2);
               A330LocationAddressLine1 = H00422_A330LocationAddressLine1[0];
               AssignAttri(sPrefix, false, "A330LocationAddressLine1", A330LocationAddressLine1);
               A35LocationPhone = H00422_A35LocationPhone[0];
               AssignAttri(sPrefix, false, "A35LocationPhone", A35LocationPhone);
               A356LocationPhoneNumber = H00422_A356LocationPhoneNumber[0];
               AssignAttri(sPrefix, false, "A356LocationPhoneNumber", A356LocationPhoneNumber);
               A34LocationEmail = H00422_A34LocationEmail[0];
               AssignAttri(sPrefix, false, "A34LocationEmail", A34LocationEmail);
               A31LocationName = H00422_A31LocationName[0];
               AssignAttri(sPrefix, false, "A31LocationName", A31LocationName);
               A494LocationImage = H00422_A494LocationImage[0];
               n494LocationImage = H00422_n494LocationImage[0];
               AssignAttri(sPrefix, false, "A494LocationImage", A494LocationImage);
               AssignProp(sPrefix, false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A494LocationImage))), true);
               AssignProp(sPrefix, false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A494LocationImage), true);
               /* Execute user event: Load */
               E12422 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB420( ) ;
         }
      }

      protected void send_integrity_lvl_hashes422( )
      {
      }

      protected void before_start_formulas( )
      {
         AV24Pgmname = "Trn_LocationGeneral";
         edtavLocationphonecode_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavLocationphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationphonecode_description_Enabled), 5, 0), true);
         edtavLocationcountry_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavLocationcountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationcountry_description_Enabled), 5, 0), true);
         edtLocationName_Enabled = 0;
         AssignProp(sPrefix, false, edtLocationName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationName_Enabled), 5, 0), true);
         edtLocationEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtLocationEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEmail_Enabled), 5, 0), true);
         edtLocationPhoneNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtLocationPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationPhoneNumber_Enabled), 5, 0), true);
         edtLocationPhone_Enabled = 0;
         AssignProp(sPrefix, false, edtLocationPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationPhone_Enabled), 5, 0), true);
         edtLocationAddressLine1_Enabled = 0;
         AssignProp(sPrefix, false, edtLocationAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationAddressLine1_Enabled), 5, 0), true);
         edtLocationAddressLine2_Enabled = 0;
         AssignProp(sPrefix, false, edtLocationAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationAddressLine2_Enabled), 5, 0), true);
         edtLocationZipCode_Enabled = 0;
         AssignProp(sPrefix, false, edtLocationZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationZipCode_Enabled), 5, 0), true);
         edtLocationCity_Enabled = 0;
         AssignProp(sPrefix, false, edtLocationCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationCity_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp(sPrefix, false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         imgLocationImage_Enabled = 0;
         AssignProp(sPrefix, false, imgLocationImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgLocationImage_Enabled), 5, 0), true);
         edtLocationDescription_Enabled = 0;
         AssignProp(sPrefix, false, edtLocationDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationDescription_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP420( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11422 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV22UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILESTOUPDATE"), AV21FilesToUpdate);
            /* Read saved values. */
            AV20LocationDescriptionVar = cgiGet( sPrefix+"vLOCATIONDESCRIPTIONVAR");
            wcpOA29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA29LocationId"));
            wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
            Imageuploaduc_Faileduploadmessage = cgiGet( sPrefix+"IMAGEUPLOADUC_Faileduploadmessage");
            Imageuploaduc_Maxnumberoffiles = cgiGet( sPrefix+"IMAGEUPLOADUC_Maxnumberoffiles");
            Imageuploaduc_Isreadonlymode = cgiGet( sPrefix+"IMAGEUPLOADUC_Isreadonlymode");
            Imageuploaduc_Maxfilesize = cgiGet( sPrefix+"IMAGEUPLOADUC_Maxfilesize");
            Locationdescriptionvar_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"LOCATIONDESCRIPTIONVAR_Enabled"));
            Locationdescriptionvar_Width = cgiGet( sPrefix+"LOCATIONDESCRIPTIONVAR_Width");
            Locationdescriptionvar_Height = cgiGet( sPrefix+"LOCATIONDESCRIPTIONVAR_Height");
            Locationdescriptionvar_Skin = cgiGet( sPrefix+"LOCATIONDESCRIPTIONVAR_Skin");
            Locationdescriptionvar_Toolbar = cgiGet( sPrefix+"LOCATIONDESCRIPTIONVAR_Toolbar");
            Locationdescriptionvar_Customtoolbar = cgiGet( sPrefix+"LOCATIONDESCRIPTIONVAR_Customtoolbar");
            Locationdescriptionvar_Customconfiguration = cgiGet( sPrefix+"LOCATIONDESCRIPTIONVAR_Customconfiguration");
            Locationdescriptionvar_Captionclass = cgiGet( sPrefix+"LOCATIONDESCRIPTIONVAR_Captionclass");
            Locationdescriptionvar_Captionstyle = cgiGet( sPrefix+"LOCATIONDESCRIPTIONVAR_Captionstyle");
            Locationdescriptionvar_Captionposition = cgiGet( sPrefix+"LOCATIONDESCRIPTIONVAR_Captionposition");
            /* Read variables values. */
            A31LocationName = cgiGet( edtLocationName_Internalname);
            AssignAttri(sPrefix, false, "A31LocationName", A31LocationName);
            A34LocationEmail = cgiGet( edtLocationEmail_Internalname);
            AssignAttri(sPrefix, false, "A34LocationEmail", A34LocationEmail);
            AV14LocationPhoneCode_Description = cgiGet( edtavLocationphonecode_description_Internalname);
            AssignAttri(sPrefix, false, "AV14LocationPhoneCode_Description", AV14LocationPhoneCode_Description);
            A356LocationPhoneNumber = cgiGet( edtLocationPhoneNumber_Internalname);
            AssignAttri(sPrefix, false, "A356LocationPhoneNumber", A356LocationPhoneNumber);
            A35LocationPhone = cgiGet( edtLocationPhone_Internalname);
            AssignAttri(sPrefix, false, "A35LocationPhone", A35LocationPhone);
            A330LocationAddressLine1 = cgiGet( edtLocationAddressLine1_Internalname);
            AssignAttri(sPrefix, false, "A330LocationAddressLine1", A330LocationAddressLine1);
            A331LocationAddressLine2 = cgiGet( edtLocationAddressLine2_Internalname);
            AssignAttri(sPrefix, false, "A331LocationAddressLine2", A331LocationAddressLine2);
            A329LocationZipCode = cgiGet( edtLocationZipCode_Internalname);
            AssignAttri(sPrefix, false, "A329LocationZipCode", A329LocationZipCode);
            A328LocationCity = cgiGet( edtLocationCity_Internalname);
            AssignAttri(sPrefix, false, "A328LocationCity", A328LocationCity);
            AV18LocationCountry_Description = cgiGet( edtavLocationcountry_description_Internalname);
            AssignAttri(sPrefix, false, "AV18LocationCountry_Description", AV18LocationCountry_Description);
            A494LocationImage = cgiGet( imgLocationImage_Internalname);
            n494LocationImage = false;
            AssignAttri(sPrefix, false, "A494LocationImage", A494LocationImage);
            A36LocationDescription = cgiGet( edtLocationDescription_Internalname);
            AssignAttri(sPrefix, false, "A36LocationDescription", A36LocationDescription);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Trn_LocationGeneral");
            A36LocationDescription = cgiGet( edtLocationDescription_Internalname);
            AssignAttri(sPrefix, false, "A36LocationDescription", A36LocationDescription);
            forbiddenHiddens.Add("LocationDescription", A36LocationDescription);
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("trn_locationgeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11422 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11422( )
      {
         /* Start Routine */
         returnInSub = false;
         Gx_mode = "DSP";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_objcol_SdtSDT_FileUploadData1 = AV21FilesToUpdate;
         new prc_getlocationimages(context ).execute(  A29LocationId, out  GXt_objcol_SdtSDT_FileUploadData1) ;
         AV21FilesToUpdate = GXt_objcol_SdtSDT_FileUploadData1;
      }

      protected void nextLoad( )
      {
      }

      protected void E12422( )
      {
         /* Load Routine */
         returnInSub = false;
         Gx_mode = "DSP";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         edtLocationId_Visible = 0;
         AssignProp(sPrefix, false, edtLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         imgLocationImage_Visible = 0;
         AssignProp(sPrefix, false, imgLocationImage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgLocationImage_Visible), 5, 0), true);
         edtLocationDescription_Visible = 0;
         AssignProp(sPrefix, false, edtLocationDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationDescription_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtLocationPhone_Visible = 0;
            AssignProp(sPrefix, false, edtLocationPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationPhone_Visible), 5, 0), true);
            divLocationphone_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divLocationphone_cell_Internalname, "Class", divLocationphone_cell_Class, true);
         }
         else
         {
            edtLocationPhone_Visible = 1;
            AssignProp(sPrefix, false, edtLocationPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationPhone_Visible), 5, 0), true);
            divLocationphone_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divLocationphone_cell_Internalname, "Class", divLocationphone_cell_Class, true);
         }
         divUnnamedtable5_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divUnnamedtable5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable5_Visible), 5, 0), true);
         divUnnamedtable7_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divUnnamedtable7_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable7_Visible), 5, 0), true);
         divUnnamedtable8_Visible = (((StringUtil.StrCmp(Gx_mode, "DSP")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divUnnamedtable8_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable8_Visible), 5, 0), true);
         lblTransactiondetail_descriptiontext_Caption = A36LocationDescription;
         AssignProp(sPrefix, false, lblTransactiondetail_descriptiontext_Internalname, "Caption", lblTransactiondetail_descriptiontext_Caption, true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV24Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Trn_Location";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A29LocationId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = (Guid)getParm(obj,1);
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
         PA422( ) ;
         WS422( ) ;
         WE422( ) ;
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
         sCtrlA29LocationId = (string)((string)getParm(obj,0));
         sCtrlA11OrganisationId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA422( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_locationgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA422( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A29LocationId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         wcpOA29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA29LocationId"));
         wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
         if ( ! GetJustCreated( ) && ( ( A29LocationId != wcpOA29LocationId ) || ( A11OrganisationId != wcpOA11OrganisationId ) ) )
         {
            setjustcreated();
         }
         wcpOA29LocationId = A29LocationId;
         wcpOA11OrganisationId = A11OrganisationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
         PA422( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS422( ) ;
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
         WS422( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
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
         WE422( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309333790", true, true);
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
         context.AddJavascriptSource("trn_locationgeneral.js", "?20256309333790", false, true);
         context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtLocationName_Internalname = sPrefix+"LOCATIONNAME";
         edtLocationEmail_Internalname = sPrefix+"LOCATIONEMAIL";
         lblTransactiondetail_phone_Internalname = sPrefix+"TRANSACTIONDETAIL_PHONE";
         edtavLocationphonecode_description_Internalname = sPrefix+"vLOCATIONPHONECODE_DESCRIPTION";
         divUnnamedtable11_Internalname = sPrefix+"UNNAMEDTABLE11";
         edtLocationPhoneNumber_Internalname = sPrefix+"LOCATIONPHONENUMBER";
         divUnnamedtable10_Internalname = sPrefix+"UNNAMEDTABLE10";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         edtLocationPhone_Internalname = sPrefix+"LOCATIONPHONE";
         divLocationphone_cell_Internalname = sPrefix+"LOCATIONPHONE_CELL";
         lblProductserviceimagetext_Internalname = sPrefix+"PRODUCTSERVICEIMAGETEXT";
         Imageuploaduc_Internalname = sPrefix+"IMAGEUPLOADUC";
         divUcfilecell_Internalname = sPrefix+"UCFILECELL";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         Locationdescriptionvar_Internalname = sPrefix+"LOCATIONDESCRIPTIONVAR";
         divUnnamedtable7_Internalname = sPrefix+"UNNAMEDTABLE7";
         lblTransactiondetail_textblockdescriptionlabel_Internalname = sPrefix+"TRANSACTIONDETAIL_TEXTBLOCKDESCRIPTIONLABEL";
         lblTransactiondetail_descriptiontext_Internalname = sPrefix+"TRANSACTIONDETAIL_DESCRIPTIONTEXT";
         divUnnamedtable9_Internalname = sPrefix+"UNNAMEDTABLE9";
         divUnnamedtable8_Internalname = sPrefix+"UNNAMEDTABLE8";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         edtLocationAddressLine1_Internalname = sPrefix+"LOCATIONADDRESSLINE1";
         edtLocationAddressLine2_Internalname = sPrefix+"LOCATIONADDRESSLINE2";
         edtLocationZipCode_Internalname = sPrefix+"LOCATIONZIPCODE";
         edtLocationCity_Internalname = sPrefix+"LOCATIONCITY";
         edtavLocationcountry_description_Internalname = sPrefix+"vLOCATIONCOUNTRY_DESCRIPTION";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = sPrefix+"UNNAMEDGROUP4";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTable_Internalname = sPrefix+"TABLE";
         edtLocationId_Internalname = sPrefix+"LOCATIONID";
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID";
         imgLocationImage_Internalname = sPrefix+"LOCATIONIMAGE";
         edtLocationDescription_Internalname = sPrefix+"LOCATIONDESCRIPTION";
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
         edtLocationDescription_Enabled = 0;
         imgLocationImage_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtLocationDescription_Visible = 1;
         imgLocationImage_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Visible = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Visible = 1;
         edtavLocationcountry_description_Jsonclick = "";
         edtavLocationcountry_description_Enabled = 1;
         edtLocationCity_Jsonclick = "";
         edtLocationCity_Enabled = 0;
         edtLocationZipCode_Jsonclick = "";
         edtLocationZipCode_Enabled = 0;
         edtLocationAddressLine2_Jsonclick = "";
         edtLocationAddressLine2_Enabled = 0;
         edtLocationAddressLine1_Jsonclick = "";
         edtLocationAddressLine1_Enabled = 0;
         lblTransactiondetail_descriptiontext_Caption = "";
         divUnnamedtable8_Visible = 1;
         Locationdescriptionvar_Enabled = Convert.ToBoolean( 1);
         divUnnamedtable7_Visible = 1;
         edtLocationPhone_Jsonclick = "";
         edtLocationPhone_Enabled = 0;
         edtLocationPhone_Visible = 1;
         divLocationphone_cell_Class = "col-xs-12";
         edtLocationPhoneNumber_Jsonclick = "";
         edtLocationPhoneNumber_Enabled = 0;
         edtavLocationphonecode_description_Jsonclick = "";
         edtavLocationphonecode_description_Enabled = 1;
         divUnnamedtable5_Visible = 1;
         edtLocationEmail_Jsonclick = "";
         edtLocationEmail_Enabled = 0;
         edtLocationName_Jsonclick = "";
         edtLocationName_Enabled = 0;
         Locationdescriptionvar_Captionposition = "Left";
         Locationdescriptionvar_Captionstyle = "";
         Locationdescriptionvar_Captionclass = "col-sm-4 AttributeLabel";
         Locationdescriptionvar_Customconfiguration = "myconfig.js";
         Locationdescriptionvar_Customtoolbar = "myToolbar";
         Locationdescriptionvar_Toolbar = "Custom";
         Locationdescriptionvar_Skin = "default";
         Locationdescriptionvar_Height = "250";
         Locationdescriptionvar_Width = "100%";
         Imageuploaduc_Maxfilesize = "10";
         Imageuploaduc_Isreadonlymode = "true";
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A36LocationDescription","fld":"LOCATIONDESCRIPTION"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[]}""");
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
         wcpOA29LocationId = Guid.Empty;
         wcpOA11OrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV24Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         A36LocationDescription = "";
         AV22UploadedFiles = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV21FilesToUpdate = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV20LocationDescriptionVar = "";
         GX_FocusControl = "";
         TempTags = "";
         A31LocationName = "";
         A34LocationEmail = "";
         lblTransactiondetail_phone_Jsonclick = "";
         AV14LocationPhoneCode_Description = "";
         A356LocationPhoneNumber = "";
         gxphoneLink = "";
         A35LocationPhone = "";
         lblProductserviceimagetext_Jsonclick = "";
         ucImageuploaduc = new GXUserControl();
         ucLocationdescriptionvar = new GXUserControl();
         lblTransactiondetail_textblockdescriptionlabel_Jsonclick = "";
         lblTransactiondetail_descriptiontext_Jsonclick = "";
         A330LocationAddressLine1 = "";
         A331LocationAddressLine2 = "";
         A329LocationZipCode = "";
         A328LocationCity = "";
         AV18LocationCountry_Description = "";
         ClassString = "";
         StyleString = "";
         bttBtncancel_Jsonclick = "";
         A494LocationImage = "";
         A40000LocationImage_GXI = "";
         sImgUrl = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00422_A29LocationId = new Guid[] {Guid.Empty} ;
         H00422_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00422_A36LocationDescription = new string[] {""} ;
         H00422_A40000LocationImage_GXI = new string[] {""} ;
         H00422_n40000LocationImage_GXI = new bool[] {false} ;
         H00422_A328LocationCity = new string[] {""} ;
         H00422_A329LocationZipCode = new string[] {""} ;
         H00422_A331LocationAddressLine2 = new string[] {""} ;
         H00422_A330LocationAddressLine1 = new string[] {""} ;
         H00422_A35LocationPhone = new string[] {""} ;
         H00422_A356LocationPhoneNumber = new string[] {""} ;
         H00422_A34LocationEmail = new string[] {""} ;
         H00422_A31LocationName = new string[] {""} ;
         H00422_A494LocationImage = new string[] {""} ;
         H00422_n494LocationImage = new bool[] {false} ;
         hsh = "";
         Gx_mode = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_objcol_SdtSDT_FileUploadData1 = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA29LocationId = "";
         sCtrlA11OrganisationId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_locationgeneral__default(),
            new Object[][] {
                new Object[] {
               H00422_A29LocationId, H00422_A11OrganisationId, H00422_A36LocationDescription, H00422_A40000LocationImage_GXI, H00422_n40000LocationImage_GXI, H00422_A328LocationCity, H00422_A329LocationZipCode, H00422_A331LocationAddressLine2, H00422_A330LocationAddressLine1, H00422_A35LocationPhone,
               H00422_A356LocationPhoneNumber, H00422_A34LocationEmail, H00422_A31LocationName, H00422_A494LocationImage, H00422_n494LocationImage
               }
            }
         );
         AV24Pgmname = "Trn_LocationGeneral";
         /* GeneXus formulas. */
         AV24Pgmname = "Trn_LocationGeneral";
         edtavLocationphonecode_description_Enabled = 0;
         edtavLocationcountry_description_Enabled = 0;
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
      private int edtavLocationphonecode_description_Enabled ;
      private int edtavLocationcountry_description_Enabled ;
      private int edtLocationName_Enabled ;
      private int edtLocationEmail_Enabled ;
      private int divUnnamedtable5_Visible ;
      private int edtLocationPhoneNumber_Enabled ;
      private int edtLocationPhone_Visible ;
      private int edtLocationPhone_Enabled ;
      private int divUnnamedtable7_Visible ;
      private int divUnnamedtable8_Visible ;
      private int edtLocationAddressLine1_Enabled ;
      private int edtLocationAddressLine2_Enabled ;
      private int edtLocationZipCode_Enabled ;
      private int edtLocationCity_Enabled ;
      private int edtLocationId_Visible ;
      private int edtOrganisationId_Visible ;
      private int imgLocationImage_Visible ;
      private int edtLocationDescription_Visible ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int imgLocationImage_Enabled ;
      private int edtLocationDescription_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV24Pgmname ;
      private string edtavLocationphonecode_description_Internalname ;
      private string edtavLocationcountry_description_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Imageuploaduc_Faileduploadmessage ;
      private string Imageuploaduc_Maxnumberoffiles ;
      private string Imageuploaduc_Isreadonlymode ;
      private string Imageuploaduc_Maxfilesize ;
      private string Locationdescriptionvar_Width ;
      private string Locationdescriptionvar_Height ;
      private string Locationdescriptionvar_Skin ;
      private string Locationdescriptionvar_Toolbar ;
      private string Locationdescriptionvar_Customtoolbar ;
      private string Locationdescriptionvar_Customconfiguration ;
      private string Locationdescriptionvar_Captionclass ;
      private string Locationdescriptionvar_Captionstyle ;
      private string Locationdescriptionvar_Captionposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtLocationName_Internalname ;
      private string TempTags ;
      private string edtLocationName_Jsonclick ;
      private string edtLocationEmail_Internalname ;
      private string edtLocationEmail_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblTransactiondetail_phone_Internalname ;
      private string lblTransactiondetail_phone_Jsonclick ;
      private string divUnnamedtable10_Internalname ;
      private string divUnnamedtable11_Internalname ;
      private string edtavLocationphonecode_description_Jsonclick ;
      private string edtLocationPhoneNumber_Internalname ;
      private string edtLocationPhoneNumber_Jsonclick ;
      private string divLocationphone_cell_Internalname ;
      private string divLocationphone_cell_Class ;
      private string edtLocationPhone_Internalname ;
      private string gxphoneLink ;
      private string A35LocationPhone ;
      private string edtLocationPhone_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string lblProductserviceimagetext_Internalname ;
      private string lblProductserviceimagetext_Jsonclick ;
      private string divUcfilecell_Internalname ;
      private string Imageuploaduc_Internalname ;
      private string divUnnamedtable7_Internalname ;
      private string Locationdescriptionvar_Internalname ;
      private string divUnnamedtable8_Internalname ;
      private string lblTransactiondetail_textblockdescriptionlabel_Internalname ;
      private string lblTransactiondetail_textblockdescriptionlabel_Jsonclick ;
      private string divUnnamedtable9_Internalname ;
      private string lblTransactiondetail_descriptiontext_Internalname ;
      private string lblTransactiondetail_descriptiontext_Caption ;
      private string lblTransactiondetail_descriptiontext_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtLocationAddressLine1_Internalname ;
      private string edtLocationAddressLine1_Jsonclick ;
      private string edtLocationAddressLine2_Internalname ;
      private string edtLocationAddressLine2_Jsonclick ;
      private string edtLocationZipCode_Internalname ;
      private string edtLocationZipCode_Jsonclick ;
      private string edtLocationCity_Internalname ;
      private string edtLocationCity_Jsonclick ;
      private string edtavLocationcountry_description_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string sImgUrl ;
      private string imgLocationImage_Internalname ;
      private string edtLocationDescription_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string hsh ;
      private string Gx_mode ;
      private string sCtrlA29LocationId ;
      private string sCtrlA11OrganisationId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Locationdescriptionvar_Enabled ;
      private bool wbLoad ;
      private bool A494LocationImage_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n40000LocationImage_GXI ;
      private bool n494LocationImage ;
      private bool returnInSub ;
      private string A36LocationDescription ;
      private string AV20LocationDescriptionVar ;
      private string A31LocationName ;
      private string A34LocationEmail ;
      private string AV14LocationPhoneCode_Description ;
      private string A356LocationPhoneNumber ;
      private string A330LocationAddressLine1 ;
      private string A331LocationAddressLine2 ;
      private string A329LocationZipCode ;
      private string A328LocationCity ;
      private string AV18LocationCountry_Description ;
      private string A40000LocationImage_GXI ;
      private string A494LocationImage ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid wcpOA29LocationId ;
      private Guid wcpOA11OrganisationId ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucImageuploaduc ;
      private GXUserControl ucLocationdescriptionvar ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV22UploadedFiles ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV21FilesToUpdate ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00422_A29LocationId ;
      private Guid[] H00422_A11OrganisationId ;
      private string[] H00422_A36LocationDescription ;
      private string[] H00422_A40000LocationImage_GXI ;
      private bool[] H00422_n40000LocationImage_GXI ;
      private string[] H00422_A328LocationCity ;
      private string[] H00422_A329LocationZipCode ;
      private string[] H00422_A331LocationAddressLine2 ;
      private string[] H00422_A330LocationAddressLine1 ;
      private string[] H00422_A35LocationPhone ;
      private string[] H00422_A356LocationPhoneNumber ;
      private string[] H00422_A34LocationEmail ;
      private string[] H00422_A31LocationName ;
      private string[] H00422_A494LocationImage ;
      private bool[] H00422_n494LocationImage ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<SdtSDT_FileUploadData> GXt_objcol_SdtSDT_FileUploadData1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_locationgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00422;
          prmH00422 = new Object[] {
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00422", "SELECT LocationId, OrganisationId, LocationDescription, LocationImage_GXI, LocationCity, LocationZipCode, LocationAddressLine2, LocationAddressLine1, LocationPhone, LocationPhoneNumber, LocationEmail, LocationName, LocationImage FROM Trn_Location WHERE LocationId = :LocationId and OrganisationId = :OrganisationId ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00422,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(4));
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
