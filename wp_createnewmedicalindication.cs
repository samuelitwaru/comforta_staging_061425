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
   public class wp_createnewmedicalindication : GXDataArea
   {
      public wp_createnewmedicalindication( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_createnewmedicalindication( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           Guid aP1_MedicalIndicationId ,
                           string aP2_DefaultMedicalIndicationName )
      {
         this.AV10TrnMode = aP0_TrnMode;
         this.AV14MedicalIndicationId = aP1_MedicalIndicationId;
         this.AV16DefaultMedicalIndicationName = aP2_DefaultMedicalIndicationName;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "TrnMode");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageprompt", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      public override short ExecuteStartEvent( )
      {
         PA7V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7V2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_createnewmedicalindication.aspx"+UrlEncode(StringUtil.RTrim(AV10TrnMode)) + "," + UrlEncode(AV14MedicalIndicationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV16DefaultMedicalIndicationName));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("wp_createnewmedicalindication.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV10TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vMEDICALINDICATIONID", AV14MedicalIndicationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vMEDICALINDICATIONID", GetSecureSignedToken( "", AV14MedicalIndicationId, context));
         GxWebStd.gx_hidden_field( context, "vDEFAULTMEDICALINDICATIONNAME", AV16DefaultMedicalIndicationName);
         GxWebStd.gx_hidden_field( context, "gxhash_vDEFAULTMEDICALINDICATIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16DefaultMedicalIndicationName, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Trn_medicalindication", AV7Trn_MedicalIndication);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Trn_medicalindication", AV7Trn_MedicalIndication);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV10TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV12CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV9Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV9Messages);
         }
         GxWebStd.gx_hidden_field( context, "vMEDICALINDICATIONID", AV14MedicalIndicationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vMEDICALINDICATIONID", GetSecureSignedToken( "", AV14MedicalIndicationId, context));
         GxWebStd.gx_hidden_field( context, "vDEFAULTMEDICALINDICATIONNAME", AV16DefaultMedicalIndicationName);
         GxWebStd.gx_hidden_field( context, "gxhash_vDEFAULTMEDICALINDICATIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16DefaultMedicalIndicationName, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_MEDICALINDICATION", AV7Trn_MedicalIndication);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_MEDICALINDICATION", AV7Trn_MedicalIndication);
         }
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE7V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7V2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_createnewmedicalindication.aspx"+UrlEncode(StringUtil.RTrim(AV10TrnMode)) + "," + UrlEncode(AV14MedicalIndicationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV16DefaultMedicalIndicationName));
         return formatLink("wp_createnewmedicalindication.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_CreateNewMedicalIndication" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Add New Medical Indication", "") ;
      }

      protected void WB7V0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTrn_medicalindication_medicalindicationname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTrn_medicalindication_medicalindicationname_Internalname, context.GetMessage( "Medical Indication", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_medicalindication_medicalindicationname_Internalname, AV7Trn_MedicalIndication.gxTpr_Medicalindicationname, StringUtil.RTrim( context.localUtil.Format( AV7Trn_MedicalIndication.gxTpr_Medicalindicationname, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_medicalindication_medicalindicationname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTrn_medicalindication_medicalindicationname_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateNewMedicalIndication.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateNewMedicalIndication.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateNewMedicalIndication.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTrn_medicalindication_medicalindicationid_Internalname, AV7Trn_MedicalIndication.gxTpr_Medicalindicationid.ToString(), AV7Trn_MedicalIndication.gxTpr_Medicalindicationid.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTrn_medicalindication_medicalindicationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavTrn_medicalindication_medicalindicationid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateNewMedicalIndication.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START7V2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Add New Medical Indication", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7V0( ) ;
      }

      protected void WS7V2( )
      {
         START7V2( ) ;
         EVT7V2( ) ;
      }

      protected void EVT7V2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E117V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E127V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E137V2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E147V2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
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

      protected void WE7V2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA7V2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createnewmedicalindication.aspx")), "wp_createnewmedicalindication.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createnewmedicalindication.aspx")))) ;
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
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "TrnMode");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV10TrnMode = gxfirstwebparm;
                     AssignAttri("", false, "AV10TrnMode", AV10TrnMode);
                     GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV14MedicalIndicationId = StringUtil.StrToGuid( GetPar( "MedicalIndicationId"));
                        AssignAttri("", false, "AV14MedicalIndicationId", AV14MedicalIndicationId.ToString());
                        GxWebStd.gx_hidden_field( context, "gxhash_vMEDICALINDICATIONID", GetSecureSignedToken( "", AV14MedicalIndicationId, context));
                        AV16DefaultMedicalIndicationName = GetPar( "DefaultMedicalIndicationName");
                        AssignAttri("", false, "AV16DefaultMedicalIndicationName", AV16DefaultMedicalIndicationName);
                        GxWebStd.gx_hidden_field( context, "gxhash_vDEFAULTMEDICALINDICATIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16DefaultMedicalIndicationName, "")), context));
                     }
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
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavTrn_medicalindication_medicalindicationname_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         RF7V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E127V2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E147V2 ();
            WB7V0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7V2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E117V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vTRN_MEDICALINDICATION"), AV7Trn_MedicalIndication);
            ajax_req_read_hidden_sdt(cgiGet( "Trn_medicalindication"), AV7Trn_MedicalIndication);
            /* Read saved values. */
            /* Read variables values. */
            AV7Trn_MedicalIndication.gxTpr_Medicalindicationname = cgiGet( edtavTrn_medicalindication_medicalindicationname_Internalname);
            if ( StringUtil.StrCmp(cgiGet( edtavTrn_medicalindication_medicalindicationid_Internalname), "") == 0 )
            {
               AV7Trn_MedicalIndication.gxTpr_Medicalindicationid = Guid.Empty;
            }
            else
            {
               try
               {
                  AV7Trn_MedicalIndication.gxTpr_Medicalindicationid = StringUtil.StrToGuid( cgiGet( edtavTrn_medicalindication_medicalindicationid_Internalname));
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRN_MEDICALINDICATION_MEDICALINDICATIONID");
                  GX_FocusControl = edtavTrn_medicalindication_medicalindicationid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
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
         E117V2 ();
         if (returnInSub) return;
      }

      protected void E117V2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV11LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV10TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV10TrnMode, "INS") == 0 ) ) || ( ( StringUtil.StrCmp(AV10TrnMode, "UPD") == 0 ) ) || ( ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 ) ) )
         {
            if ( StringUtil.StrCmp(AV10TrnMode, "INS") != 0 )
            {
               AV7Trn_MedicalIndication.Load(AV14MedicalIndicationId);
               AV11LoadSuccess = AV7Trn_MedicalIndication.Success();
               if ( ! AV11LoadSuccess )
               {
                  AV9Messages = AV7Trn_MedicalIndication.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV10TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 ) )
               {
                  edtavTrn_medicalindication_medicalindicationname_Enabled = 0;
                  AssignProp("", false, edtavTrn_medicalindication_medicalindicationname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrn_medicalindication_medicalindicationname_Enabled), 5, 0), true);
               }
            }
            else
            {
               AV7Trn_MedicalIndication.gxTpr_Medicalindicationname = AV16DefaultMedicalIndicationName;
            }
         }
         else
         {
            AV11LoadSuccess = false;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( AV11LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""));
            }
         }
         AV15WebSession.Remove("MEDICALINDICATIONID");
         AV15WebSession.Remove("MEDICALINDICATIONNAME");
         edtavTrn_medicalindication_medicalindicationid_Visible = 0;
         AssignProp("", false, edtavTrn_medicalindication_medicalindicationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTrn_medicalindication_medicalindicationid_Visible), 5, 0), true);
      }

      protected void E127V2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E137V2 ();
         if (returnInSub) return;
      }

      protected void E137V2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV10TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV10TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S132 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 ) || AV12CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 )
               {
                  AV7Trn_MedicalIndication.Delete();
               }
               else
               {
                  AV7Trn_MedicalIndication.Save();
                  if ( StringUtil.StrCmp(AV10TrnMode, "INS") == 0 )
                  {
                     AV15WebSession.Set("MEDICALINDICATIONID", StringUtil.Trim( AV7Trn_MedicalIndication.gxTpr_Medicalindicationid.ToString()));
                     AV15WebSession.Set("MEDICALINDICATIONNAME", AV7Trn_MedicalIndication.gxTpr_Medicalindicationname);
                  }
               }
               if ( AV7Trn_MedicalIndication.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S142 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV9Messages = AV7Trn_MedicalIndication.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Trn_MedicalIndication", AV7Trn_MedicalIndication);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9Messages", AV9Messages);
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV10TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV19GXV3 = 1;
         while ( AV19GXV3 <= AV9Messages.Count )
         {
            AV8Message = ((GeneXus.Utils.SdtMessages_Message)AV9Messages.Item(AV19GXV3));
            GX_msglist.addItem(AV8Message.gxTpr_Description);
            AV19GXV3 = (int)(AV19GXV3+1);
         }
      }

      protected void S142( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("wp_createnewmedicalindication",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV12CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
      }

      protected void nextLoad( )
      {
      }

      protected void E147V2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV10TrnMode", AV10TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
         AV14MedicalIndicationId = (Guid)getParm(obj,1);
         AssignAttri("", false, "AV14MedicalIndicationId", AV14MedicalIndicationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vMEDICALINDICATIONID", GetSecureSignedToken( "", AV14MedicalIndicationId, context));
         AV16DefaultMedicalIndicationName = (string)getParm(obj,2);
         AssignAttri("", false, "AV16DefaultMedicalIndicationName", AV16DefaultMedicalIndicationName);
         GxWebStd.gx_hidden_field( context, "gxhash_vDEFAULTMEDICALINDICATIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16DefaultMedicalIndicationName, "")), context));
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
         PA7V2( ) ;
         WS7V2( ) ;
         WE7V2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201792096", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("wp_createnewmedicalindication.js", "?20256201792096", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavTrn_medicalindication_medicalindicationname_Internalname = "TRN_MEDICALINDICATION_MEDICALINDICATIONNAME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavTrn_medicalindication_medicalindicationid_Internalname = "TRN_MEDICALINDICATION_MEDICALINDICATIONID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavTrn_medicalindication_medicalindicationname_Enabled = 1;
         edtavTrn_medicalindication_medicalindicationid_Jsonclick = "";
         edtavTrn_medicalindication_medicalindicationid_Visible = 1;
         bttBtnenter_Visible = 1;
         edtavTrn_medicalindication_medicalindicationname_Jsonclick = "";
         edtavTrn_medicalindication_medicalindicationname_Enabled = 1;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Add New Medical Indication", "");
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV14MedicalIndicationId","fld":"vMEDICALINDICATIONID","hsh":true},{"av":"AV16DefaultMedicalIndicationName","fld":"vDEFAULTMEDICALINDICATIONNAME","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E137V2","iparms":[{"av":"AV10TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV7Trn_MedicalIndication","fld":"vTRN_MEDICALINDICATION"},{"av":"AV9Messages","fld":"vMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV7Trn_MedicalIndication","fld":"vTRN_MEDICALINDICATION"},{"av":"AV9Messages","fld":"vMESSAGES"},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
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
         wcpOAV10TrnMode = "";
         wcpOAV14MedicalIndicationId = Guid.Empty;
         wcpOAV16DefaultMedicalIndicationName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV7Trn_MedicalIndication = new SdtTrn_MedicalIndication(context);
         AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV15WebSession = context.GetSession();
         AV8Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_createnewmedicalindication__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_createnewmedicalindication__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createnewmedicalindication__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavTrn_medicalindication_medicalindicationname_Enabled ;
      private int bttBtnenter_Visible ;
      private int edtavTrn_medicalindication_medicalindicationid_Visible ;
      private int AV19GXV3 ;
      private int idxLst ;
      private string AV10TrnMode ;
      private string wcpOAV10TrnMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableattributes_Internalname ;
      private string edtavTrn_medicalindication_medicalindicationname_Internalname ;
      private string TempTags ;
      private string edtavTrn_medicalindication_medicalindicationname_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavTrn_medicalindication_medicalindicationid_Internalname ;
      private string edtavTrn_medicalindication_medicalindicationid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV11LoadSuccess ;
      private string AV16DefaultMedicalIndicationName ;
      private string wcpOAV16DefaultMedicalIndicationName ;
      private Guid AV14MedicalIndicationId ;
      private Guid wcpOAV14MedicalIndicationId ;
      private IGxSession AV15WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_MedicalIndication AV7Trn_MedicalIndication ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9Messages ;
      private GeneXus.Utils.SdtMessages_Message AV8Message ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_createnewmedicalindication__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_createnewmedicalindication__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_createnewmedicalindication__default : DataStoreHelperBase, IDataStoreHelper
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
