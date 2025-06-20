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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_selectimportfile : GXWebComponent
   {
      public wwp_selectimportfile( )
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

      public wwp_selectimportfile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_TransactionName ,
                           ref string aP1_ImportType ,
                           ref string aP2_ExtraParmsJson )
      {
         this.AV16TransactionName = aP0_TransactionName;
         this.AV11ImportType = aP1_ImportType;
         this.AV7ExtraParmsJson = aP2_ExtraParmsJson;
         ExecuteImpl();
         aP0_TransactionName=this.AV16TransactionName;
         aP1_ImportType=this.AV11ImportType;
         aP2_ExtraParmsJson=this.AV7ExtraParmsJson;
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
         chkavOverwriteexistingform = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "TransactionName");
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
                  AV16TransactionName = GetPar( "TransactionName");
                  AssignAttri(sPrefix, false, "AV16TransactionName", AV16TransactionName);
                  AV11ImportType = GetPar( "ImportType");
                  AssignAttri(sPrefix, false, "AV11ImportType", AV11ImportType);
                  AV7ExtraParmsJson = GetPar( "ExtraParmsJson");
                  AssignAttri(sPrefix, false, "AV7ExtraParmsJson", AV7ExtraParmsJson);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV16TransactionName,(string)AV11ImportType,(string)AV7ExtraParmsJson});
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
                  gxfirstwebparm = GetFirstPar( "TransactionName");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "TransactionName");
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
            PA1Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS1Y2( ) ;
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
            context.SendWebValue( context.GetMessage( "Select file to import", "")) ;
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
            context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.wwp_selectimportfile.aspx"+UrlEncode(StringUtil.RTrim(AV16TransactionName)) + "," + UrlEncode(StringUtil.RTrim(AV11ImportType)) + "," + UrlEncode(StringUtil.RTrim(AV7ExtraParmsJson));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("wwpbaseobjects.wwp_selectimportfile.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
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
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vERRORMSGS", AV6ErrorMsgs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vERRORMSGS", AV6ErrorMsgs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vERRORMSGS", GetSecureSignedToken( sPrefix, AV6ErrorMsgs, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV16TransactionName", wcpOAV16TransactionName);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV11ImportType", wcpOAV11ImportType);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7ExtraParmsJson", wcpOAV7ExtraParmsJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"vIMPORTTYPE", AV11ImportType);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vERRORMSGS", AV6ErrorMsgs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vERRORMSGS", AV6ErrorMsgs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vERRORMSGS", GetSecureSignedToken( sPrefix, AV6ErrorMsgs, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESULTMSG", AV14ResultMsg);
         GxWebStd.gx_hidden_field( context, sPrefix+"vEXTRAPARMSJSON", AV7ExtraParmsJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTRANSACTIONNAME", AV16TransactionName);
         GXCCtlgxBlob = "vFILTERTOUPLOAD" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtlgxBlob, AV9FilterToUpload);
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILTERTOUPLOAD_Filename", StringUtil.RTrim( edtavFiltertoupload_Filename));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILTERTOUPLOAD_Filename", StringUtil.RTrim( edtavFiltertoupload_Filename));
      }

      protected void RenderHtmlCloseForm1Y2( )
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
         return "WWPBaseObjects.WWP_SelectImportFile" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Select file to import", "") ;
      }

      protected void WB1Y0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.wwp_selectimportfile.aspx");
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransactionPopUp", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell AttributeImportFileCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFiltertoupload_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFiltertoupload_Internalname, context.GetMessage( "File", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'',0)\"";
            edtavFiltertoupload_Filetype = "tmp";
            AssignProp(sPrefix, false, edtavFiltertoupload_Internalname, "Filetype", edtavFiltertoupload_Filetype, true);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9FilterToUpload)) )
            {
               gxblobfileaux.Source = AV9FilterToUpload;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavFiltertoupload_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavFiltertoupload_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV9FilterToUpload = gxblobfileaux.GetURI();
                  AssignProp(sPrefix, false, edtavFiltertoupload_Internalname, "URL", context.PathToRelativeUrl( AV9FilterToUpload), true);
                  edtavFiltertoupload_Filetype = gxblobfileaux.GetExtension();
                  AssignProp(sPrefix, false, edtavFiltertoupload_Internalname, "Filetype", edtavFiltertoupload_Filetype, true);
               }
               AssignProp(sPrefix, false, edtavFiltertoupload_Internalname, "URL", context.PathToRelativeUrl( AV9FilterToUpload), true);
            }
            GxWebStd.gx_blob_field( context, edtavFiltertoupload_Internalname, StringUtil.RTrim( AV9FilterToUpload), context.PathToRelativeUrl( AV9FilterToUpload), (String.IsNullOrEmpty(StringUtil.RTrim( edtavFiltertoupload_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavFiltertoupload_Filetype)) ? AV9FilterToUpload : edtavFiltertoupload_Filetype)) : edtavFiltertoupload_Contenttype), false, "", edtavFiltertoupload_Parameters, 0, edtavFiltertoupload_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtavFiltertoupload_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "", "", "HLP_WWPBaseObjects/WWP_SelectImportFile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOverwriteexistingform_cell_Internalname, 1, 0, "px", 0, "px", divOverwriteexistingform_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOverwriteexistingform_Internalname, context.GetMessage( "Overwrite Existing Form", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOverwriteexistingform_Internalname, StringUtil.BoolToStr( AV5OverwriteExistingForm), "", context.GetMessage( "Overwrite Existing Form", ""), chkavOverwriteexistingform.Visible, chkavOverwriteexistingform.Enabled, "true", context.GetMessage( "Overwrite", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(21, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,21);\"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupRight", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "Import", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_SelectImportFile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnucancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtnucancel_Jsonclick, 7, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e111y1_client"+"'", TempTags, "", 2, "HLP_WWPBaseObjects/WWP_SelectImportFile.htm");
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

      protected void START1Y2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Select file to import", ""), 0) ;
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
               STRUP1Y0( ) ;
            }
         }
      }

      protected void WS1Y2( )
      {
         START1Y2( ) ;
         EVT1Y2( ) ;
      }

      protected void EVT1Y2( )
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
                                 STRUP1Y0( ) ;
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
                                 STRUP1Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E121Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1Y0( ) ;
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
                                          E131Y2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E141Y2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFiltertoupload_Internalname;
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

      protected void WE1Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm1Y2( ) ;
            }
         }
      }

      protected void PA1Y2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.wwp_selectimportfile.aspx")), "wwpbaseobjects.wwp_selectimportfile.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.wwp_selectimportfile.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "TransactionName");
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
               GX_FocusControl = edtavFiltertoupload_Internalname;
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
         AV5OverwriteExistingForm = StringUtil.StrToBool( StringUtil.BoolToStr( AV5OverwriteExistingForm));
         AssignAttri(sPrefix, false, "AV5OverwriteExistingForm", AV5OverwriteExistingForm);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF1Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E141Y2 ();
            WB1Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1Y2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vERRORMSGS", AV6ErrorMsgs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vERRORMSGS", AV6ErrorMsgs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vERRORMSGS", GetSecureSignedToken( sPrefix, AV6ErrorMsgs, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E121Y2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV16TransactionName = cgiGet( sPrefix+"wcpOAV16TransactionName");
            wcpOAV11ImportType = cgiGet( sPrefix+"wcpOAV11ImportType");
            wcpOAV7ExtraParmsJson = cgiGet( sPrefix+"wcpOAV7ExtraParmsJson");
            edtavFiltertoupload_Filename = cgiGet( sPrefix+"vFILTERTOUPLOAD_Filename");
            /* Read variables values. */
            AV9FilterToUpload = cgiGet( edtavFiltertoupload_Internalname);
            AV5OverwriteExistingForm = StringUtil.StrToBool( cgiGet( chkavOverwriteexistingform_Internalname));
            AssignAttri(sPrefix, false, "AV5OverwriteExistingForm", AV5OverwriteExistingForm);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9FilterToUpload)) )
            {
               GXCCtlgxBlob = "vFILTERTOUPLOAD" + "_gxBlob";
               AV9FilterToUpload = cgiGet( sPrefix+GXCCtlgxBlob);
            }
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
         E121Y2 ();
         if (returnInSub) return;
      }

      protected void E121Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV11ImportType, "JSON") == 0 ) ) )
         {
            chkavOverwriteexistingform.Visible = 0;
            AssignProp(sPrefix, false, chkavOverwriteexistingform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavOverwriteexistingform.Visible), 5, 0), true);
            divOverwriteexistingform_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divOverwriteexistingform_cell_Internalname, "Class", divOverwriteexistingform_cell_Class, true);
         }
         else
         {
            chkavOverwriteexistingform.Visible = 1;
            AssignProp(sPrefix, false, chkavOverwriteexistingform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavOverwriteexistingform.Visible), 5, 0), true);
            divOverwriteexistingform_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divOverwriteexistingform_cell_Internalname, "Class", divOverwriteexistingform_cell_Class, true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E131Y2 ();
         if (returnInSub) return;
      }

      protected void E131Y2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV10FilterToUploadExt = edtavFiltertoupload_Filename;
         AV10FilterToUploadExt = ((StringUtil.StringSearch( AV10FilterToUploadExt, ".", 1)>0) ? StringUtil.Substring( AV10FilterToUploadExt, StringUtil.StringSearchRev( AV10FilterToUploadExt, ".", -1)+1, StringUtil.Len( AV10FilterToUploadExt)-StringUtil.StringSearchRev( AV10FilterToUploadExt, ".", -1)) : "");
         AV17BlobId = AV9FilterToUpload;
         AV19BlobRef = StringUtil.StringReplace( AV17BlobId, "gxupload:", "");
         AV20Cache = CacheAPI.GetCache( "FL");
         AV21BlobData.FromJSonString(AV20Cache.Get(AV19BlobRef), null);
         AV22BlobPath = AV21BlobData.gxTpr_Path;
         GX_msglist.addItem("<#CLEAR#>");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9FilterToUpload)) )
         {
            if ( ( StringUtil.StrCmp(StringUtil.Upper( AV10FilterToUploadExt), "JSON") == 0 ) && ( StringUtil.StrCmp(AV11ImportType, "JSON") == 0 ) )
            {
               if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_import(context).executeUdp(  AV22BlobPath,  AV5OverwriteExistingForm, out  AV6ErrorMsgs) )
               {
                  AV12LastErrorType = 2;
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_Import_SuccessTitle", ""),  context.GetMessage( "WWP_DF_Import_Success", ""),  "success",  "",  "na",  ""));
                  this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_Close", new Object[] {(string)AV14ResultMsg}, false);
               }
               else
               {
                  /* Execute user subroutine: 'SHOWERRORS' */
                  S122 ();
                  if (returnInSub) return;
               }
            }
            else
            {
               if ( ( ( StringUtil.StrCmp(StringUtil.Upper( AV10FilterToUploadExt), "CSV") == 0 ) && ( StringUtil.StrCmp(AV11ImportType, "CSV") == 0 ) ) || ( ( StringUtil.StrCmp(StringUtil.Upper( AV10FilterToUploadExt), "XLSX") == 0 ) && ( StringUtil.StrCmp(AV11ImportType, "Excel") == 0 ) ) || ( ( StringUtil.StrCmp(StringUtil.Upper( AV10FilterToUploadExt), "JSON") == 0 ) && ( StringUtil.StrCmp(AV11ImportType, "JSON") == 0 ) ) )
               {
                  AV14ResultMsg = "";
                  AssignAttri(sPrefix, false, "AV14ResultMsg", AV14ResultMsg);
                  if ( new GeneXus.Programs.wwpbaseobjects.wwp_importdata(context).executeUdp(  AV16TransactionName,  AV11ImportType,  AV22BlobPath,  AV7ExtraParmsJson, out  AV6ErrorMsgs) )
                  {
                     AV12LastErrorType = 2;
                     AV25GXV1 = 1;
                     while ( AV25GXV1 <= AV6ErrorMsgs.Count )
                     {
                        AV13Message = ((GeneXus.Utils.SdtMessages_Message)AV6ErrorMsgs.Item(AV25GXV1));
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14ResultMsg)) )
                        {
                           AV14ResultMsg += StringUtil.NewLine( );
                           AssignAttri(sPrefix, false, "AV14ResultMsg", AV14ResultMsg);
                           if ( ( AV12LastErrorType == 0 ) && ( AV13Message.gxTpr_Type == 2 ) )
                           {
                              AV14ResultMsg += StringUtil.NewLine( );
                              AssignAttri(sPrefix, false, "AV14ResultMsg", AV14ResultMsg);
                           }
                        }
                        AV12LastErrorType = AV13Message.gxTpr_Type;
                        AV14ResultMsg += AV13Message.gxTpr_Description;
                        AssignAttri(sPrefix, false, "AV14ResultMsg", AV14ResultMsg);
                        AV25GXV1 = (int)(AV25GXV1+1);
                     }
                     GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_ImportFile_ImportSuccessTitle", ""),  AV14ResultMsg,  "success",  "",  "na",  ""));
                     this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_Close", new Object[] {(string)AV14ResultMsg}, false);
                  }
                  else
                  {
                     /* Execute user subroutine: 'SHOWERRORS' */
                     S122 ();
                     if (returnInSub) return;
                  }
               }
               else
               {
                  AV9FilterToUpload = "";
                  AssignProp(sPrefix, false, edtavFiltertoupload_Internalname, "URL", context.PathToRelativeUrl( AV9FilterToUpload), true);
                  if ( ( StringUtil.StrCmp(AV11ImportType, "JSON") == 0 ) || ( StringUtil.StrCmp(AV11ImportType, "CSV") == 0 ) )
                  {
                     AV8ExtType = StringUtil.Lower( AV11ImportType);
                  }
                  else
                  {
                     AV8ExtType = "xlsx";
                  }
                  AV14ResultMsg = StringUtil.Format( context.GetMessage( "WWP_ImportFile_ExpectedFileType", ""), AV8ExtType, "", "", "", "", "", "", "", "");
                  AssignAttri(sPrefix, false, "AV14ResultMsg", AV14ResultMsg);
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_ImportFile_ErrorImportingTitle", ""),  AV14ResultMsg,  "error",  "",  "na",  ""));
               }
            }
         }
         else
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "File", ""), "", "", "", "", "", "", "", ""));
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'SHOWERRORS' Routine */
         returnInSub = false;
         AV9FilterToUpload = "";
         AssignProp(sPrefix, false, edtavFiltertoupload_Internalname, "URL", context.PathToRelativeUrl( AV9FilterToUpload), true);
         AV26GXV2 = 1;
         while ( AV26GXV2 <= AV6ErrorMsgs.Count )
         {
            AV13Message = ((GeneXus.Utils.SdtMessages_Message)AV6ErrorMsgs.Item(AV26GXV2));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14ResultMsg)) )
            {
               AV14ResultMsg += StringUtil.NewLine( );
               AssignAttri(sPrefix, false, "AV14ResultMsg", AV14ResultMsg);
               if ( StringUtil.StrCmp(AV13Message.gxTpr_Id, "WWP_LineId") == 0 )
               {
                  AV14ResultMsg += StringUtil.NewLine( );
                  AssignAttri(sPrefix, false, "AV14ResultMsg", AV14ResultMsg);
               }
            }
            AV14ResultMsg += AV13Message.gxTpr_Description;
            AssignAttri(sPrefix, false, "AV14ResultMsg", AV14ResultMsg);
            AV26GXV2 = (int)(AV26GXV2+1);
         }
         GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_ImportFile_ErrorImportingTitle", ""),  AV14ResultMsg,  "error",  "",  "false",  ""));
      }

      protected void nextLoad( )
      {
      }

      protected void E141Y2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV16TransactionName = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV16TransactionName", AV16TransactionName);
         AV11ImportType = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV11ImportType", AV11ImportType);
         AV7ExtraParmsJson = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV7ExtraParmsJson", AV7ExtraParmsJson);
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
         PA1Y2( ) ;
         WS1Y2( ) ;
         WE1Y2( ) ;
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
         sCtrlAV16TransactionName = (string)((string)getParm(obj,0));
         sCtrlAV11ImportType = (string)((string)getParm(obj,1));
         sCtrlAV7ExtraParmsJson = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA1Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\wwp_selectimportfile", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA1Y2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV16TransactionName = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV16TransactionName", AV16TransactionName);
            AV11ImportType = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV11ImportType", AV11ImportType);
            AV7ExtraParmsJson = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV7ExtraParmsJson", AV7ExtraParmsJson);
         }
         wcpOAV16TransactionName = cgiGet( sPrefix+"wcpOAV16TransactionName");
         wcpOAV11ImportType = cgiGet( sPrefix+"wcpOAV11ImportType");
         wcpOAV7ExtraParmsJson = cgiGet( sPrefix+"wcpOAV7ExtraParmsJson");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV16TransactionName, wcpOAV16TransactionName) != 0 ) || ( StringUtil.StrCmp(AV11ImportType, wcpOAV11ImportType) != 0 ) || ( StringUtil.StrCmp(AV7ExtraParmsJson, wcpOAV7ExtraParmsJson) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV16TransactionName = AV16TransactionName;
         wcpOAV11ImportType = AV11ImportType;
         wcpOAV7ExtraParmsJson = AV7ExtraParmsJson;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV16TransactionName = cgiGet( sPrefix+"AV16TransactionName_CTRL");
         if ( StringUtil.Len( sCtrlAV16TransactionName) > 0 )
         {
            AV16TransactionName = cgiGet( sCtrlAV16TransactionName);
            AssignAttri(sPrefix, false, "AV16TransactionName", AV16TransactionName);
         }
         else
         {
            AV16TransactionName = cgiGet( sPrefix+"AV16TransactionName_PARM");
         }
         sCtrlAV11ImportType = cgiGet( sPrefix+"AV11ImportType_CTRL");
         if ( StringUtil.Len( sCtrlAV11ImportType) > 0 )
         {
            AV11ImportType = cgiGet( sCtrlAV11ImportType);
            AssignAttri(sPrefix, false, "AV11ImportType", AV11ImportType);
         }
         else
         {
            AV11ImportType = cgiGet( sPrefix+"AV11ImportType_PARM");
         }
         sCtrlAV7ExtraParmsJson = cgiGet( sPrefix+"AV7ExtraParmsJson_CTRL");
         if ( StringUtil.Len( sCtrlAV7ExtraParmsJson) > 0 )
         {
            AV7ExtraParmsJson = cgiGet( sCtrlAV7ExtraParmsJson);
            AssignAttri(sPrefix, false, "AV7ExtraParmsJson", AV7ExtraParmsJson);
         }
         else
         {
            AV7ExtraParmsJson = cgiGet( sPrefix+"AV7ExtraParmsJson_PARM");
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
         PA1Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS1Y2( ) ;
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
         WS1Y2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV16TransactionName_PARM", AV16TransactionName);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16TransactionName)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16TransactionName_CTRL", StringUtil.RTrim( sCtrlAV16TransactionName));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11ImportType_PARM", AV11ImportType);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11ImportType)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11ImportType_CTRL", StringUtil.RTrim( sCtrlAV11ImportType));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7ExtraParmsJson_PARM", AV7ExtraParmsJson);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7ExtraParmsJson)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7ExtraParmsJson_CTRL", StringUtil.RTrim( sCtrlAV7ExtraParmsJson));
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
         WE1Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562016571979", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/wwp_selectimportfile.js", "?202562016571979", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavOverwriteexistingform.Name = "vOVERWRITEEXISTINGFORM";
         chkavOverwriteexistingform.WebTags = "";
         chkavOverwriteexistingform.Caption = context.GetMessage( "Overwrite Existing Form", "");
         AssignProp(sPrefix, false, chkavOverwriteexistingform_Internalname, "TitleCaption", chkavOverwriteexistingform.Caption, true);
         chkavOverwriteexistingform.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavFiltertoupload_Internalname = sPrefix+"vFILTERTOUPLOAD";
         chkavOverwriteexistingform_Internalname = sPrefix+"vOVERWRITEEXISTINGFORM";
         divOverwriteexistingform_cell_Internalname = sPrefix+"OVERWRITEEXISTINGFORM_CELL";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         bttBtnenter_Internalname = sPrefix+"BTNENTER";
         bttBtnucancel_Internalname = sPrefix+"BTNUCANCEL";
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
         chkavOverwriteexistingform.Caption = context.GetMessage( "Overwrite Existing Form", "");
         chkavOverwriteexistingform.Enabled = 1;
         chkavOverwriteexistingform.Visible = 1;
         divOverwriteexistingform_cell_Class = "col-xs-12";
         edtavFiltertoupload_Jsonclick = "";
         edtavFiltertoupload_Parameters = "";
         edtavFiltertoupload_Contenttype = "";
         edtavFiltertoupload_Filetype = "";
         edtavFiltertoupload_Enabled = 1;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         edtavFiltertoupload_Filename = "";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV5OverwriteExistingForm","fld":"vOVERWRITEEXISTINGFORM"},{"av":"AV6ErrorMsgs","fld":"vERRORMSGS","hsh":true}]}""");
         setEventMetadata("'DOUCANCEL'","""{"handler":"E111Y1","iparms":[]}""");
         setEventMetadata("ENTER","""{"handler":"E131Y2","iparms":[{"av":"edtavFiltertoupload_Filename","ctrl":"vFILTERTOUPLOAD","prop":"Filename"},{"av":"AV9FilterToUpload","fld":"vFILTERTOUPLOAD"},{"av":"AV11ImportType","fld":"vIMPORTTYPE"},{"av":"AV6ErrorMsgs","fld":"vERRORMSGS","hsh":true},{"av":"AV5OverwriteExistingForm","fld":"vOVERWRITEEXISTINGFORM"},{"av":"AV14ResultMsg","fld":"vRESULTMSG"},{"av":"AV7ExtraParmsJson","fld":"vEXTRAPARMSJSON"},{"av":"AV16TransactionName","fld":"vTRANSACTIONNAME"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV9FilterToUpload","fld":"vFILTERTOUPLOAD"},{"av":"AV14ResultMsg","fld":"vRESULTMSG"}]}""");
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
         wcpOAV16TransactionName = "";
         wcpOAV11ImportType = "";
         wcpOAV7ExtraParmsJson = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV6ErrorMsgs = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14ResultMsg = "";
         GXCCtlgxBlob = "";
         AV9FilterToUpload = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         bttBtnenter_Jsonclick = "";
         bttBtnucancel_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV10FilterToUploadExt = "";
         AV17BlobId = "";
         AV19BlobRef = "";
         AV20Cache = new CacheAPI();
         AV21BlobData = new WorkWithPlus.workwithplus_web.SdtBlobData(context);
         AV22BlobPath = "";
         AV13Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV8ExtType = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV16TransactionName = "";
         sCtrlAV11ImportType = "";
         sCtrlAV7ExtraParmsJson = "";
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
      private short AV12LastErrorType ;
      private short nGXWrapped ;
      private int edtavFiltertoupload_Enabled ;
      private int AV25GXV1 ;
      private int AV26GXV2 ;
      private int idxLst ;
      private string edtavFiltertoupload_Filename ;
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
      private string GXCCtlgxBlob ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableattributes_Internalname ;
      private string edtavFiltertoupload_Internalname ;
      private string TempTags ;
      private string edtavFiltertoupload_Filetype ;
      private string edtavFiltertoupload_Contenttype ;
      private string edtavFiltertoupload_Parameters ;
      private string edtavFiltertoupload_Jsonclick ;
      private string divOverwriteexistingform_cell_Internalname ;
      private string divOverwriteexistingform_cell_Class ;
      private string chkavOverwriteexistingform_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtnucancel_Internalname ;
      private string bttBtnucancel_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string AV17BlobId ;
      private string AV19BlobRef ;
      private string AV22BlobPath ;
      private string sCtrlAV16TransactionName ;
      private string sCtrlAV11ImportType ;
      private string sCtrlAV7ExtraParmsJson ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool AV5OverwriteExistingForm ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV16TransactionName ;
      private string AV11ImportType ;
      private string AV7ExtraParmsJson ;
      private string wcpOAV16TransactionName ;
      private string wcpOAV11ImportType ;
      private string wcpOAV7ExtraParmsJson ;
      private string AV14ResultMsg ;
      private string AV10FilterToUploadExt ;
      private string AV8ExtType ;
      private string AV9FilterToUpload ;
      private GxFile gxblobfileaux ;
      private GXWebForm Form ;
      private CacheAPI AV20Cache ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_TransactionName ;
      private string aP1_ImportType ;
      private string aP2_ExtraParmsJson ;
      private GXCheckbox chkavOverwriteexistingform ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV6ErrorMsgs ;
      private WorkWithPlus.workwithplus_web.SdtBlobData AV21BlobData ;
      private GeneXus.Utils.SdtMessages_Message AV13Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
