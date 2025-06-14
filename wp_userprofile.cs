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
   public class wp_userprofile : GXDataArea
   {
      public wp_userprofile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_userprofile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
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
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
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
         PA9D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9D2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_AvatarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_userprofile.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILEUPLOADEDDATA", AV21FileUploadedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILEUPLOADEDDATA", AV21FileUploadedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPHONECODE_DATA", AV35PhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPHONECODE_DATA", AV35PhoneCode_Data);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISUPDATEMODE", AV6isUpdateMode);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV65WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV65WWPContext);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV11CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vBASE64STRING", AV66base64String);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_MANAGER", AV52Trn_Manager);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_MANAGER", AV52Trn_Manager);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_RECEPTIONIST", AV53Trn_Receptionist);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_RECEPTIONIST", AV53Trn_Receptionist);
         }
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Width", StringUtil.RTrim( Dvpanel_profileextendedinfo1_tablemaininfo_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Autowidth", StringUtil.BoolToStr( Dvpanel_profileextendedinfo1_tablemaininfo_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Autoheight", StringUtil.BoolToStr( Dvpanel_profileextendedinfo1_tablemaininfo_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Cls", StringUtil.RTrim( Dvpanel_profileextendedinfo1_tablemaininfo_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Title", StringUtil.RTrim( Dvpanel_profileextendedinfo1_tablemaininfo_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Collapsible", StringUtil.BoolToStr( Dvpanel_profileextendedinfo1_tablemaininfo_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Collapsed", StringUtil.BoolToStr( Dvpanel_profileextendedinfo1_tablemaininfo_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_profileextendedinfo1_tablemaininfo_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Iconposition", StringUtil.RTrim( Dvpanel_profileextendedinfo1_tablemaininfo_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Autoscroll", StringUtil.BoolToStr( Dvpanel_profileextendedinfo1_tablemaininfo_Autoscroll));
         GxWebStd.gx_hidden_field( context, "AVATARUC_Previewimagelink", StringUtil.RTrim( Avataruc_Previewimagelink));
         GxWebStd.gx_hidden_field( context, "COMBO_PHONECODE_Cls", StringUtil.RTrim( Combo_phonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_phonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_phonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_phonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_PHONECODE_Htmltemplate", StringUtil.RTrim( Combo_phonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Width", StringUtil.RTrim( Dvpanel_profileextendedinfo1_tableabout_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Autowidth", StringUtil.BoolToStr( Dvpanel_profileextendedinfo1_tableabout_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Autoheight", StringUtil.BoolToStr( Dvpanel_profileextendedinfo1_tableabout_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Cls", StringUtil.RTrim( Dvpanel_profileextendedinfo1_tableabout_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Title", StringUtil.RTrim( Dvpanel_profileextendedinfo1_tableabout_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Collapsible", StringUtil.BoolToStr( Dvpanel_profileextendedinfo1_tableabout_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Collapsed", StringUtil.BoolToStr( Dvpanel_profileextendedinfo1_tableabout_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_profileextendedinfo1_tableabout_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Iconposition", StringUtil.RTrim( Dvpanel_profileextendedinfo1_tableabout_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Autoscroll", StringUtil.BoolToStr( Dvpanel_profileextendedinfo1_tableabout_Autoscroll));
         GxWebStd.gx_hidden_field( context, "COMFIRMDELETEMODAL_Title", StringUtil.RTrim( Comfirmdeletemodal_Title));
         GxWebStd.gx_hidden_field( context, "COMFIRMDELETEMODAL_Confirmationtext", StringUtil.RTrim( Comfirmdeletemodal_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "COMFIRMDELETEMODAL_Yesbuttoncaption", StringUtil.RTrim( Comfirmdeletemodal_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "COMFIRMDELETEMODAL_Nobuttoncaption", StringUtil.RTrim( Comfirmdeletemodal_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "COMFIRMDELETEMODAL_Bodytype", StringUtil.RTrim( Comfirmdeletemodal_Bodytype));
         GxWebStd.gx_hidden_field( context, "vWWPCONTEXT_Gamuserguid", StringUtil.RTrim( AV65WWPContext.gxTpr_Gamuserguid));
         GxWebStd.gx_hidden_field( context, "vWWPCONTEXT_Receptionistid", AV65WWPContext.gxTpr_Receptionistid.ToString());
         GxWebStd.gx_hidden_field( context, "vWWPCONTEXT_Organisationid", AV65WWPContext.gxTpr_Organisationid.ToString());
         GxWebStd.gx_hidden_field( context, "vWWPCONTEXT_Locationid", AV65WWPContext.gxTpr_Locationid.ToString());
         GxWebStd.gx_hidden_field( context, "vWWPCONTEXT_Managerid", AV65WWPContext.gxTpr_Managerid.ToString());
         GxWebStd.gx_hidden_field( context, "COMBO_PHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_phonecode_Selectedvalue_get));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE9D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9D2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wp_userprofile.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_UserProfile" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Profile", "") ;
      }

      protected void WB9D0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divProfileextendedinfo1_maintable_Internalname, 1, 0, "px", 0, "px", "TableProfileCardExtendedInfo", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_profileextendedinfo1_tablemaininfo.SetProperty("Width", Dvpanel_profileextendedinfo1_tablemaininfo_Width);
            ucDvpanel_profileextendedinfo1_tablemaininfo.SetProperty("AutoWidth", Dvpanel_profileextendedinfo1_tablemaininfo_Autowidth);
            ucDvpanel_profileextendedinfo1_tablemaininfo.SetProperty("AutoHeight", Dvpanel_profileextendedinfo1_tablemaininfo_Autoheight);
            ucDvpanel_profileextendedinfo1_tablemaininfo.SetProperty("Cls", Dvpanel_profileextendedinfo1_tablemaininfo_Cls);
            ucDvpanel_profileextendedinfo1_tablemaininfo.SetProperty("Title", Dvpanel_profileextendedinfo1_tablemaininfo_Title);
            ucDvpanel_profileextendedinfo1_tablemaininfo.SetProperty("Collapsible", Dvpanel_profileextendedinfo1_tablemaininfo_Collapsible);
            ucDvpanel_profileextendedinfo1_tablemaininfo.SetProperty("Collapsed", Dvpanel_profileextendedinfo1_tablemaininfo_Collapsed);
            ucDvpanel_profileextendedinfo1_tablemaininfo.SetProperty("ShowCollapseIcon", Dvpanel_profileextendedinfo1_tablemaininfo_Showcollapseicon);
            ucDvpanel_profileextendedinfo1_tablemaininfo.SetProperty("IconPosition", Dvpanel_profileextendedinfo1_tablemaininfo_Iconposition);
            ucDvpanel_profileextendedinfo1_tablemaininfo.SetProperty("AutoScroll", Dvpanel_profileextendedinfo1_tablemaininfo_Autoscroll);
            ucDvpanel_profileextendedinfo1_tablemaininfo.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_profileextendedinfo1_tablemaininfo_Internalname, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFOContainer"+"ProfileExtendedInfo1_TableMainInfo"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divProfileextendedinfo1_tablemaininfo_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "profile Image", ""), "gx-form-item CardProfileExtendedInfoImageLabel RoundedImageLabel", 0, true, "width: 25%;");
            /* Static Bitmap Variable */
            ClassString = "CardProfileExtendedInfoImage RoundedImage" + " " + ((StringUtil.StrCmp(imgavProfileimage_gximage, "")==0) ? "" : "GX_Image_"+imgavProfileimage_gximage+"_Class");
            StyleString = "";
            AV68profileImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV68profileImage))&&String.IsNullOrEmpty(StringUtil.RTrim( AV78Profileimage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV68profileImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV68profileImage)) ? AV78Profileimage_GXI : context.PathToRelativeUrl( AV68profileImage));
            GxWebStd.gx_bitmap( context, imgavProfileimage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV68profileImage_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUser_Internalname, context.GetMessage( "user", ""), "gx-form-item CardProfileExtendedInfoTitleLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUser_Internalname, StringUtil.RTrim( AV56user), StringUtil.RTrim( context.localUtil.Format( AV56user, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUser_Jsonclick, 0, "CardProfileExtendedInfoTitle", "", "", "", "", 1, edtavUser_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginBottom20", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRole_Internalname, context.GetMessage( "role", ""), "gx-form-item CardProfileExtendedInfoSubtitleLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRole_Internalname, StringUtil.RTrim( AV46role), StringUtil.RTrim( context.localUtil.Format( AV46role, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRole_Jsonclick, 0, "CardProfileExtendedInfoSubtitle", "", "", "", "", 1, edtavRole_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdateprofile_Internalname, "", context.GetMessage( "Update Profile", ""), bttBtnupdateprofile_Jsonclick, 5, context.GetMessage( "Update Profile", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUPDATEPROFILE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_profileextendedinfo1_tableabout.SetProperty("Width", Dvpanel_profileextendedinfo1_tableabout_Width);
            ucDvpanel_profileextendedinfo1_tableabout.SetProperty("AutoWidth", Dvpanel_profileextendedinfo1_tableabout_Autowidth);
            ucDvpanel_profileextendedinfo1_tableabout.SetProperty("AutoHeight", Dvpanel_profileextendedinfo1_tableabout_Autoheight);
            ucDvpanel_profileextendedinfo1_tableabout.SetProperty("Cls", Dvpanel_profileextendedinfo1_tableabout_Cls);
            ucDvpanel_profileextendedinfo1_tableabout.SetProperty("Title", Dvpanel_profileextendedinfo1_tableabout_Title);
            ucDvpanel_profileextendedinfo1_tableabout.SetProperty("Collapsible", Dvpanel_profileextendedinfo1_tableabout_Collapsible);
            ucDvpanel_profileextendedinfo1_tableabout.SetProperty("Collapsed", Dvpanel_profileextendedinfo1_tableabout_Collapsed);
            ucDvpanel_profileextendedinfo1_tableabout.SetProperty("ShowCollapseIcon", Dvpanel_profileextendedinfo1_tableabout_Showcollapseicon);
            ucDvpanel_profileextendedinfo1_tableabout.SetProperty("IconPosition", Dvpanel_profileextendedinfo1_tableabout_Iconposition);
            ucDvpanel_profileextendedinfo1_tableabout.SetProperty("AutoScroll", Dvpanel_profileextendedinfo1_tableabout_Autoscroll);
            ucDvpanel_profileextendedinfo1_tableabout.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_profileextendedinfo1_tableabout_Internalname, "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUTContainer"+"ProfileExtendedInfo1_TableAbout"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divProfileextendedinfo1_tableabout_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginBottom15", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUpdateavatartable_Internalname, divUpdateavatartable_Visible, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFieldavatartable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAvatarlabel_Internalname, context.GetMessage( "Profile Image", ""), "", "", lblAvatarlabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucAvataruc.SetProperty("UploadedFile", AV21FileUploadedData);
            ucAvataruc.Render(context, "uc_avatar", Avataruc_Internalname, "AVATARUCContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divProfileextendedinfo1_firstinfoabout_Internalname, divProfileextendedinfo1_firstinfoabout_Visible, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavFirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstname_Internalname, context.GetMessage( "First Name", ""), "gx-form-item ReadOnlyAttributeFieldLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstname_Internalname, AV23FirstName, StringUtil.RTrim( context.localUtil.Format( AV23FirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFirstname_Jsonclick, 0, "ReadOnlyAttributeField", "", "", "", "", 1, edtavFirstname_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUpdatemodefirstnametbl_Internalname, divUpdatemodefirstnametbl_Visible, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Required", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavFirstnamevalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstnamevalue_Internalname, context.GetMessage( "First Name", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstnamevalue_Internalname, AV24FirstNameValue, StringUtil.RTrim( context.localUtil.Format( AV24FirstNameValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFirstnamevalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFirstnamevalue_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divProfileextendedinfo1_secondinfoabout_Internalname, divProfileextendedinfo1_secondinfoabout_Visible, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavLastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastname_Internalname, context.GetMessage( "Last Name", ""), "gx-form-item ReadOnlyAttributeFieldLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastname_Internalname, AV29LastName, StringUtil.RTrim( context.localUtil.Format( AV29LastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLastname_Jsonclick, 0, "ReadOnlyAttributeField", "", "", "", "", 1, edtavLastname_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUpdatemodelastnaetbl_Internalname, divUpdatemodelastnaetbl_Visible, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Required", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavLastnamevalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastnamevalue_Internalname, context.GetMessage( "Last Name", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastnamevalue_Internalname, AV30LastNameValue, StringUtil.RTrim( context.localUtil.Format( AV30LastNameValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLastnamevalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLastnamevalue_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divProfileextendedinfo1_thirdinfoabout_Internalname, divProfileextendedinfo1_thirdinfoabout_Visible, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, context.GetMessage( "Email", ""), "gx-form-item ReadOnlyAttributeFieldLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV16Email, StringUtil.RTrim( context.localUtil.Format( AV16Email, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmail_Jsonclick, 0, "ReadOnlyAttributeField", "", "", "", "", 1, edtavEmail_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUpdateemailtbl_Internalname, divUpdateemailtbl_Visible, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Required", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmailvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailvalue_Internalname, context.GetMessage( "Email", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmailvalue_Internalname, AV17EmailValue, StringUtil.RTrim( context.localUtil.Format( AV17EmailValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmailvalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmailvalue_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divProfileextendedinfo1_fourthinfoabout_Internalname, divProfileextendedinfo1_fourthinfoabout_Visible, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPhone_Internalname, context.GetMessage( "Phone", ""), "gx-form-item ReadOnlyAttributeFieldLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPhone_Internalname, AV33Phone, StringUtil.RTrim( context.localUtil.Format( AV33Phone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPhone_Jsonclick, 0, "ReadOnlyAttributeField", "", "", "", "", 1, edtavPhone_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUpdatephonetbl_Internalname, divUpdatephonetbl_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-3 UserProfilePhoneLabel", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPhonelabel_Internalname, context.GetMessage( "Phone", ""), "", "", lblPhonelabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "UserProfilePhoneTable", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_phonecode.SetProperty("Caption", Combo_phonecode_Caption);
            ucCombo_phonecode.SetProperty("Cls", Combo_phonecode_Cls);
            ucCombo_phonecode.SetProperty("EmptyItem", Combo_phonecode_Emptyitem);
            ucCombo_phonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
            ucCombo_phonecode.SetProperty("DropDownOptionsData", AV35PhoneCode_Data);
            ucCombo_phonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_phonecode_Internalname, "COMBO_PHONECODEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPhonenumber_Internalname, context.GetMessage( "Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPhonenumber_Internalname, AV38PhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV38PhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPhonenumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPhonenumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop", "start", "top", "", "flex-grow:1;align-self:flex-end;", "div");
            wb_table1_106_9D2( true) ;
         }
         else
         {
            wb_table1_106_9D2( false) ;
         }
         return  ;
      }

      protected void wb_table1_106_9D2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucComfirmdeletemodal.SetProperty("Title", Comfirmdeletemodal_Title);
            ucComfirmdeletemodal.SetProperty("ConfirmationText", Comfirmdeletemodal_Confirmationtext);
            ucComfirmdeletemodal.SetProperty("YesButtonCaption", Comfirmdeletemodal_Yesbuttoncaption);
            ucComfirmdeletemodal.SetProperty("NoButtonCaption", Comfirmdeletemodal_Nobuttoncaption);
            ucComfirmdeletemodal.SetProperty("BodyType", Comfirmdeletemodal_Bodytype);
            ucComfirmdeletemodal.Render(context, "dvelop.gxbootstrap.confirmpanel", Comfirmdeletemodal_Internalname, "COMFIRMDELETEMODALContainer");
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
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPhonecode_Internalname, AV34PhoneCode, StringUtil.RTrim( context.localUtil.Format( AV34PhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPhonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavPhonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START9D2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Profile", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9D0( ) ;
      }

      protected void WS9D2( )
      {
         START9D2( ) ;
         EVT9D2( ) ;
      }

      protected void EVT9D2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "AVATARUC.ONUPLOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Avataruc.Onupload */
                              E119D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "AVATARUC.ONFAILEDUPLOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Avataruc.Onfailedupload */
                              E129D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMFIRMDELETEMODAL.ONYES") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Comfirmdeletemodal.Onyes */
                              E139D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E149D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSAVEUPDATE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoSaveUpdate' */
                              E159D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATEPROFILE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUpdateProfile' */
                              E169D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E179D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
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

      protected void WE9D2( )
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

      protected void PA9D2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
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
               GX_FocusControl = edtavUser_Internalname;
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
         RF9D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavUser_Enabled = 0;
         AssignProp("", false, edtavUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUser_Enabled), 5, 0), true);
         edtavRole_Enabled = 0;
         AssignProp("", false, edtavRole_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRole_Enabled), 5, 0), true);
         edtavFirstname_Enabled = 0;
         AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), true);
         edtavLastname_Enabled = 0;
         AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), true);
         edtavEmail_Enabled = 0;
         AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), true);
         edtavPhone_Enabled = 0;
         AssignProp("", false, edtavPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPhone_Enabled), 5, 0), true);
      }

      protected void RF9D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E179D2 ();
            WB9D0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes9D2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavUser_Enabled = 0;
         AssignProp("", false, edtavUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUser_Enabled), 5, 0), true);
         edtavRole_Enabled = 0;
         AssignProp("", false, edtavRole_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRole_Enabled), 5, 0), true);
         edtavFirstname_Enabled = 0;
         AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), true);
         edtavLastname_Enabled = 0;
         AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), true);
         edtavEmail_Enabled = 0;
         AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), true);
         edtavPhone_Enabled = 0;
         AssignProp("", false, edtavPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPhone_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E149D2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILEUPLOADEDDATA"), AV21FileUploadedData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vPHONECODE_DATA"), AV35PhoneCode_Data);
            /* Read saved values. */
            AV6isUpdateMode = StringUtil.StrToBool( cgiGet( "vISUPDATEMODE"));
            Dvpanel_profileextendedinfo1_tablemaininfo_Width = cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Width");
            Dvpanel_profileextendedinfo1_tablemaininfo_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Autowidth"));
            Dvpanel_profileextendedinfo1_tablemaininfo_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Autoheight"));
            Dvpanel_profileextendedinfo1_tablemaininfo_Cls = cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Cls");
            Dvpanel_profileextendedinfo1_tablemaininfo_Title = cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Title");
            Dvpanel_profileextendedinfo1_tablemaininfo_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Collapsible"));
            Dvpanel_profileextendedinfo1_tablemaininfo_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Collapsed"));
            Dvpanel_profileextendedinfo1_tablemaininfo_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Showcollapseicon"));
            Dvpanel_profileextendedinfo1_tablemaininfo_Iconposition = cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Iconposition");
            Dvpanel_profileextendedinfo1_tablemaininfo_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO_Autoscroll"));
            Avataruc_Previewimagelink = cgiGet( "AVATARUC_Previewimagelink");
            Combo_phonecode_Cls = cgiGet( "COMBO_PHONECODE_Cls");
            Combo_phonecode_Selectedvalue_set = cgiGet( "COMBO_PHONECODE_Selectedvalue_set");
            Combo_phonecode_Selectedtext_set = cgiGet( "COMBO_PHONECODE_Selectedtext_set");
            Combo_phonecode_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PHONECODE_Emptyitem"));
            Combo_phonecode_Htmltemplate = cgiGet( "COMBO_PHONECODE_Htmltemplate");
            Dvpanel_profileextendedinfo1_tableabout_Width = cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Width");
            Dvpanel_profileextendedinfo1_tableabout_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Autowidth"));
            Dvpanel_profileextendedinfo1_tableabout_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Autoheight"));
            Dvpanel_profileextendedinfo1_tableabout_Cls = cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Cls");
            Dvpanel_profileextendedinfo1_tableabout_Title = cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Title");
            Dvpanel_profileextendedinfo1_tableabout_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Collapsible"));
            Dvpanel_profileextendedinfo1_tableabout_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Collapsed"));
            Dvpanel_profileextendedinfo1_tableabout_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Showcollapseicon"));
            Dvpanel_profileextendedinfo1_tableabout_Iconposition = cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Iconposition");
            Dvpanel_profileextendedinfo1_tableabout_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT_Autoscroll"));
            Comfirmdeletemodal_Title = cgiGet( "COMFIRMDELETEMODAL_Title");
            Comfirmdeletemodal_Confirmationtext = cgiGet( "COMFIRMDELETEMODAL_Confirmationtext");
            Comfirmdeletemodal_Yesbuttoncaption = cgiGet( "COMFIRMDELETEMODAL_Yesbuttoncaption");
            Comfirmdeletemodal_Nobuttoncaption = cgiGet( "COMFIRMDELETEMODAL_Nobuttoncaption");
            Comfirmdeletemodal_Bodytype = cgiGet( "COMFIRMDELETEMODAL_Bodytype");
            /* Read variables values. */
            AV68profileImage = cgiGet( imgavProfileimage_Internalname);
            AV56user = cgiGet( edtavUser_Internalname);
            AssignAttri("", false, "AV56user", AV56user);
            AV46role = cgiGet( edtavRole_Internalname);
            AssignAttri("", false, "AV46role", AV46role);
            AV23FirstName = cgiGet( edtavFirstname_Internalname);
            AssignAttri("", false, "AV23FirstName", AV23FirstName);
            AV24FirstNameValue = cgiGet( edtavFirstnamevalue_Internalname);
            AssignAttri("", false, "AV24FirstNameValue", AV24FirstNameValue);
            AV29LastName = cgiGet( edtavLastname_Internalname);
            AssignAttri("", false, "AV29LastName", AV29LastName);
            AV30LastNameValue = cgiGet( edtavLastnamevalue_Internalname);
            AssignAttri("", false, "AV30LastNameValue", AV30LastNameValue);
            AV16Email = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV16Email", AV16Email);
            AV17EmailValue = cgiGet( edtavEmailvalue_Internalname);
            AssignAttri("", false, "AV17EmailValue", AV17EmailValue);
            AV33Phone = cgiGet( edtavPhone_Internalname);
            AssignAttri("", false, "AV33Phone", AV33Phone);
            AV38PhoneNumber = cgiGet( edtavPhonenumber_Internalname);
            AssignAttri("", false, "AV38PhoneNumber", AV38PhoneNumber);
            AV34PhoneCode = cgiGet( edtavPhonecode_Internalname);
            AssignAttri("", false, "AV34PhoneCode", AV34PhoneCode);
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
         E149D2 ();
         if (returnInSub) return;
      }

      protected void E149D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV65WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavPhonecode_Visible = 0;
         AssignProp("", false, edtavPhonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPhonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_phonecode_Htmltemplate = GXt_char2;
         ucCombo_phonecode.SendProperty(context, "", false, Combo_phonecode_Internalname, "HTMLTemplate", Combo_phonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOPHONECODE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADUSERPROFILE' */
         S132 ();
         if (returnInSub) return;
         AV6isUpdateMode = false;
         AssignAttri("", false, "AV6isUpdateMode", AV6isUpdateMode);
      }

      protected void E159D2( )
      {
         /* 'DoSaveUpdate' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S142 ();
         if (returnInSub) return;
         AV5GAMUser.load( AV65WWPContext.gxTpr_Gamuserguid);
         if ( AV5GAMUser.success() && AV11CheckRequiredFieldsResult )
         {
            AV5GAMUser.gxTpr_Email = AV17EmailValue;
            AV5GAMUser.gxTpr_Name = AV17EmailValue;
            AV5GAMUser.gxTpr_Firstname = AV24FirstNameValue;
            AV5GAMUser.gxTpr_Lastname = AV30LastNameValue;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38PhoneNumber)) )
            {
               AV5GAMUser.gxTpr_Phone = AV34PhoneCode+"~"+AV38PhoneNumber;
            }
            AV5GAMUser.gxTpr_Dateupdated = DateTimeUtil.Now( context);
            AV62UserProfileImage = "";
            if ( ! ( StringUtil.StrCmp(AV66base64String, context.GetMessage( "delete-avatar", "")) == 0 ) )
            {
               AV62UserProfileImage=context.FileFromBase64( AV66base64String) ;
            }
            AV5GAMUser.save();
            if ( AV5GAMUser.success() )
            {
               AV67WWP_UserExtended.Load(AV65WWPContext.gxTpr_Gamuserguid);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62UserProfileImage)) )
               {
                  AV67WWP_UserExtended.gxTpr_Wwpuserextendedphoto = AV62UserProfileImage;
                  AV67WWP_UserExtended.gxTpr_Wwpuserextendedphoto_gxi = GXDbFile.GetUriFromFile( "", "", AV62UserProfileImage);
               }
               if ( StringUtil.StrCmp(AV66base64String, context.GetMessage( "delete-avatar", "")) == 0 )
               {
                  AV67WWP_UserExtended.gxTpr_Wwpuserextendedphoto = context.GetImagePath( "cd361e0f-97cb-4b25-a56f-891cd75b163f", "", context.GetTheme( ));
                  AV67WWP_UserExtended.gxTpr_Wwpuserextendedphoto_gxi = GXDbFile.PathToUrl( context.GetImagePath( "cd361e0f-97cb-4b25-a56f-891cd75b163f", "", context.GetTheme( )), context);
               }
               AV67WWP_UserExtended.Save();
               /* Execute user subroutine: 'UPDATETRANSACTIONTABLE' */
               S152 ();
               if (returnInSub) return;
               AV6isUpdateMode = false;
               AssignAttri("", false, "AV6isUpdateMode", AV6isUpdateMode);
               /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
               S122 ();
               if (returnInSub) return;
            }
            else
            {
               AV26GAMErrorCollection = AV5GAMUser.geterrors();
               AV75GXV1 = 1;
               while ( AV75GXV1 <= AV26GAMErrorCollection.Count )
               {
                  AV25GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV26GAMErrorCollection.Item(AV75GXV1));
                  GX_msglist.addItem(StringUtil.StringReplace( AV25GAMError.gxTpr_Message, context.GetMessage( "Username", ""), context.GetMessage( "Email/Username", "")));
                  AV75GXV1 = (int)(AV75GXV1+1);
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53Trn_Receptionist", AV53Trn_Receptionist);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV52Trn_Manager", AV52Trn_Manager);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV65WWPContext", AV65WWPContext);
      }

      protected void E169D2( )
      {
         /* 'DoUpdateProfile' Routine */
         returnInSub = false;
         AV6isUpdateMode = true;
         AssignAttri("", false, "AV6isUpdateMode", AV6isUpdateMode);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         AV24FirstNameValue = AV23FirstName;
         AssignAttri("", false, "AV24FirstNameValue", AV24FirstNameValue);
         AV30LastNameValue = AV29LastName;
         AssignAttri("", false, "AV30LastNameValue", AV30LastNameValue);
         AV17EmailValue = AV16Email;
         AssignAttri("", false, "AV17EmailValue", AV17EmailValue);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65WWPContext.gxTpr_Profileurl)) )
         {
            Avataruc_Previewimagelink = context.convertURL( (string)(context.GetImagePath( "cd132e7c-3222-4be1-9123-4cad0b17f9cf", "", context.GetTheme( ))));
            ucAvataruc.SendProperty(context, "", false, Avataruc_Internalname, "PreviewImageLink", Avataruc_Previewimagelink);
         }
         else
         {
            Avataruc_Previewimagelink = AV65WWPContext.gxTpr_Profileurl;
            ucAvataruc.SendProperty(context, "", false, Avataruc_Internalname, "PreviewImageLink", Avataruc_Previewimagelink);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33Phone)) )
         {
            AV37PhoneInputStrings = GxRegex.Split(AV65WWPContext.gxTpr_Gamuserphone,"~");
            AV34PhoneCode = AV37PhoneInputStrings.GetString(1);
            AssignAttri("", false, "AV34PhoneCode", AV34PhoneCode);
            Combo_phonecode_Selectedtext_set = AV34PhoneCode;
            ucCombo_phonecode.SendProperty(context, "", false, Combo_phonecode_Internalname, "SelectedText_set", Combo_phonecode_Selectedtext_set);
            Combo_phonecode_Selectedvalue_set = AV34PhoneCode;
            ucCombo_phonecode.SendProperty(context, "", false, Combo_phonecode_Internalname, "SelectedValue_set", Combo_phonecode_Selectedvalue_set);
            AV38PhoneNumber = AV37PhoneInputStrings.GetString(2);
            AssignAttri("", false, "AV38PhoneNumber", AV38PhoneNumber);
         }
         else
         {
            AV34PhoneCode = "+31";
            AssignAttri("", false, "AV34PhoneCode", AV34PhoneCode);
            Combo_phonecode_Selectedtext_set = AV34PhoneCode;
            ucCombo_phonecode.SendProperty(context, "", false, Combo_phonecode_Internalname, "SelectedText_set", Combo_phonecode_Selectedtext_set);
            Combo_phonecode_Selectedvalue_set = AV34PhoneCode;
            ucCombo_phonecode.SendProperty(context, "", false, Combo_phonecode_Internalname, "SelectedValue_set", Combo_phonecode_Selectedvalue_set);
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV11CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24FirstNameValue)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "First Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavFirstnamevalue_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30LastNameValue)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Last Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavLastnamevalue_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17EmailValue)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavEmailvalue_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divUpdateavatartable_Visible = (((AV6isUpdateMode)) ? 1 : 0);
         AssignProp("", false, divUpdateavatartable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUpdateavatartable_Visible), 5, 0), true);
         divProfileextendedinfo1_firstinfoabout_Visible = ((!AV6isUpdateMode) ? 1 : 0);
         AssignProp("", false, divProfileextendedinfo1_firstinfoabout_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divProfileextendedinfo1_firstinfoabout_Visible), 5, 0), true);
         divUpdatemodefirstnametbl_Visible = (((AV6isUpdateMode)) ? 1 : 0);
         AssignProp("", false, divUpdatemodefirstnametbl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUpdatemodefirstnametbl_Visible), 5, 0), true);
         divProfileextendedinfo1_secondinfoabout_Visible = ((!AV6isUpdateMode) ? 1 : 0);
         AssignProp("", false, divProfileextendedinfo1_secondinfoabout_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divProfileextendedinfo1_secondinfoabout_Visible), 5, 0), true);
         divUpdatemodelastnaetbl_Visible = (((AV6isUpdateMode)) ? 1 : 0);
         AssignProp("", false, divUpdatemodelastnaetbl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUpdatemodelastnaetbl_Visible), 5, 0), true);
         divProfileextendedinfo1_thirdinfoabout_Visible = ((!AV6isUpdateMode) ? 1 : 0);
         AssignProp("", false, divProfileextendedinfo1_thirdinfoabout_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divProfileextendedinfo1_thirdinfoabout_Visible), 5, 0), true);
         divUpdateemailtbl_Visible = (((AV6isUpdateMode)) ? 1 : 0);
         AssignProp("", false, divUpdateemailtbl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUpdateemailtbl_Visible), 5, 0), true);
         divProfileextendedinfo1_fourthinfoabout_Visible = ((!AV6isUpdateMode) ? 1 : 0);
         AssignProp("", false, divProfileextendedinfo1_fourthinfoabout_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divProfileextendedinfo1_fourthinfoabout_Visible), 5, 0), true);
         divUpdatephonetbl_Visible = (((AV6isUpdateMode)) ? 1 : 0);
         AssignProp("", false, divUpdatephonetbl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUpdatephonetbl_Visible), 5, 0), true);
         tblUpdateactionstable_Visible = (((AV6isUpdateMode)) ? 1 : 0);
         AssignProp("", false, tblUpdateactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblUpdateactionstable_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPHONECODE' Routine */
         returnInSub = false;
         AV77GXV3 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV76GXV2;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV76GXV2 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV77GXV3 <= AV76GXV2.Count )
         {
            AV36PhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV76GXV2.Item(AV77GXV3));
            AV12Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = AV36PhoneCode_DPItem.gxTpr_Countrydialcode;
            AV13ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV13ComboTitles.Add(AV36PhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV13ComboTitles.Add(AV36PhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV12Combo_DataItem.gxTpr_Title = AV13ComboTitles.ToJSonString(false);
            AV35PhoneCode_Data.Add(AV12Combo_DataItem, 0);
            AV77GXV3 = (int)(AV77GXV3+1);
         }
         AV35PhoneCode_Data.Sort("Title");
         Combo_phonecode_Selectedvalue_set = AV34PhoneCode;
         ucCombo_phonecode.SendProperty(context, "", false, Combo_phonecode_Internalname, "SelectedValue_set", Combo_phonecode_Selectedvalue_set);
      }

      protected void E119D2( )
      {
         /* Avataruc_Onupload Routine */
         returnInSub = false;
         AV62UserProfileImage = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21FileUploadedData.gxTpr_Base64image)) )
         {
            AV66base64String = GxRegex.Split(AV21FileUploadedData.gxTpr_Base64image,",").GetString(2);
            AssignAttri("", false, "AV66base64String", AV66base64String);
         }
         /*  Sending Event outputs  */
      }

      protected void E129D2( )
      {
         /* Avataruc_Onfailedupload Routine */
         returnInSub = false;
         GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Maximum file size allowed is 2MB.", ""),  "error",  "",  "true",  ""));
      }

      protected void E139D2( )
      {
         /* Comfirmdeletemodal_Onyes Routine */
         returnInSub = false;
         AV66base64String = context.GetMessage( "delete-avatar", "");
         AssignAttri("", false, "AV66base64String", AV66base64String);
         Avataruc_Previewimagelink = context.convertURL( (string)(context.GetImagePath( "cd132e7c-3222-4be1-9123-4cad0b17f9cf", "", context.GetTheme( ))));
         ucAvataruc.SendProperty(context, "", false, Avataruc_Internalname, "PreviewImageLink", Avataruc_Previewimagelink);
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'LOADUSERPROFILE' Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV65WWPContext) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65WWPContext.gxTpr_Profileurl)) )
         {
            imgavProfileimage_gximage = "UserInfo";
            AssignProp("", false, imgavProfileimage_Internalname, "gximage", imgavProfileimage_gximage, true);
            AV68profileImage = context.GetImagePath( "cd132e7c-3222-4be1-9123-4cad0b17f9cf", "", context.GetTheme( ));
            AssignProp("", false, imgavProfileimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV68profileImage)) ? AV78Profileimage_GXI : context.convertURL( context.PathToRelativeUrl( AV68profileImage))), true);
            AssignProp("", false, imgavProfileimage_Internalname, "SrcSet", context.GetImageSrcSet( AV68profileImage), true);
            AV78Profileimage_GXI = GXDbFile.PathToUrl( context.GetImagePath( "cd132e7c-3222-4be1-9123-4cad0b17f9cf", "", context.GetTheme( )), context);
            AssignProp("", false, imgavProfileimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV68profileImage)) ? AV78Profileimage_GXI : context.convertURL( context.PathToRelativeUrl( AV68profileImage))), true);
            AssignProp("", false, imgavProfileimage_Internalname, "SrcSet", context.GetImageSrcSet( AV68profileImage), true);
         }
         else
         {
            AV68profileImage = AV65WWPContext.gxTpr_Profileurl;
            AssignProp("", false, imgavProfileimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV68profileImage)) ? AV78Profileimage_GXI : context.convertURL( context.PathToRelativeUrl( AV68profileImage))), true);
            AssignProp("", false, imgavProfileimage_Internalname, "SrcSet", context.GetImageSrcSet( AV68profileImage), true);
            AV78Profileimage_GXI = GXDbFile.PathToUrl( AV65WWPContext.gxTpr_Profileurl, context);
            AssignProp("", false, imgavProfileimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV68profileImage)) ? AV78Profileimage_GXI : context.convertURL( context.PathToRelativeUrl( AV68profileImage))), true);
            AssignProp("", false, imgavProfileimage_Internalname, "SrcSet", context.GetImageSrcSet( AV68profileImage), true);
         }
         AV56user = AV65WWPContext.gxTpr_Gamuserfirstname + " " + AV65WWPContext.gxTpr_Gamuserlastname;
         AssignAttri("", false, "AV56user", AV56user);
         AV16Email = AV65WWPContext.gxTpr_Gamuseremail;
         AssignAttri("", false, "AV16Email", AV16Email);
         AV60userOrganisation = AV65WWPContext.gxTpr_Organisationname + " " + AV65WWPContext.gxTpr_Locationname;
         AV23FirstName = AV65WWPContext.gxTpr_Gamuserfirstname;
         AssignAttri("", false, "AV23FirstName", AV23FirstName);
         AV29LastName = AV65WWPContext.gxTpr_Gamuserlastname;
         AssignAttri("", false, "AV29LastName", AV29LastName);
         AV33Phone = StringUtil.StringReplace( AV65WWPContext.gxTpr_Gamuserphone, "~", " ");
         AssignAttri("", false, "AV33Phone", AV33Phone);
         if ( AV65WWPContext.gxTpr_Isreceptionist )
         {
            GXt_char2 = AV46role;
            new prc_getorganisationdefinition(context ).execute(  "Receptionist", out  GXt_char2) ;
            AV46role = GXt_char2;
            AssignAttri("", false, "AV46role", AV46role);
         }
         if ( AV65WWPContext.gxTpr_Isorganisationmanager )
         {
            AV46role = context.GetMessage( "Organisation Manager", "");
            AssignAttri("", false, "AV46role", AV46role);
         }
      }

      protected void S152( )
      {
         /* 'UPDATETRANSACTIONTABLE' Routine */
         returnInSub = false;
         AV62UserProfileImage = "";
         if ( ! ( StringUtil.StrCmp(AV66base64String, context.GetMessage( "delete-avatar", "")) == 0 ) )
         {
            AV62UserProfileImage=context.FileFromBase64( AV66base64String) ;
         }
         if ( AV65WWPContext.gxTpr_Isreceptionist )
         {
            AV53Trn_Receptionist.Load(AV65WWPContext.gxTpr_Receptionistid, AV65WWPContext.gxTpr_Organisationid, AV65WWPContext.gxTpr_Locationid);
            if ( StringUtil.StrCmp(AV66base64String, context.GetMessage( "delete-avatar", "")) == 0 )
            {
               AV53Trn_Receptionist.gxTpr_Receptionistimage = context.GetImagePath( "cd132e7c-3222-4be1-9123-4cad0b17f9cf", "", context.GetTheme( ));
               AV53Trn_Receptionist.gxTpr_Receptionistimage_gxi = GXDbFile.PathToUrl( context.GetImagePath( "cd132e7c-3222-4be1-9123-4cad0b17f9cf", "", context.GetTheme( )), context);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66base64String)) )
               {
                  AV53Trn_Receptionist.gxTpr_Receptionistimage = AV62UserProfileImage;
                  AV53Trn_Receptionist.gxTpr_Receptionistimage_gxi = GXDbFile.GetUriFromFile( "", "", AV62UserProfileImage);
               }
            }
            AV53Trn_Receptionist.gxTpr_Receptionistemail = AV17EmailValue;
            AV53Trn_Receptionist.gxTpr_Receptionistgivenname = AV24FirstNameValue;
            AV53Trn_Receptionist.gxTpr_Receptionistlastname = AV30LastNameValue;
            AV53Trn_Receptionist.gxTpr_Receptionistphonecode = AV34PhoneCode;
            AV53Trn_Receptionist.gxTpr_Receptionistphonenumber = AV38PhoneNumber;
            AV53Trn_Receptionist.gxTpr_Receptionistisactive = true;
            if ( AV53Trn_Receptionist.Update() )
            {
               context.CommitDataStores("wp_userprofile",pr_default);
            }
         }
         if ( AV65WWPContext.gxTpr_Isorganisationmanager )
         {
            AV52Trn_Manager.Load(AV65WWPContext.gxTpr_Managerid, AV65WWPContext.gxTpr_Organisationid);
            if ( StringUtil.StrCmp(AV66base64String, context.GetMessage( "delete-avatar", "")) == 0 )
            {
               AV52Trn_Manager.gxTpr_Managerimage = context.GetImagePath( "cd132e7c-3222-4be1-9123-4cad0b17f9cf", "", context.GetTheme( ));
               AV52Trn_Manager.gxTpr_Managerimage_gxi = GXDbFile.PathToUrl( context.GetImagePath( "cd132e7c-3222-4be1-9123-4cad0b17f9cf", "", context.GetTheme( )), context);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66base64String)) )
               {
                  AV52Trn_Manager.gxTpr_Managerimage = AV62UserProfileImage;
                  AV52Trn_Manager.gxTpr_Managerimage_gxi = GXDbFile.GetUriFromFile( "", "", AV62UserProfileImage);
               }
            }
            AV52Trn_Manager.gxTpr_Manageremail = AV17EmailValue;
            AV52Trn_Manager.gxTpr_Managergivenname = AV24FirstNameValue;
            AV52Trn_Manager.gxTpr_Managerlastname = AV30LastNameValue;
            AV52Trn_Manager.gxTpr_Managerphonecode = AV34PhoneCode;
            AV52Trn_Manager.gxTpr_Managerphonenumber = AV38PhoneNumber;
            AV52Trn_Manager.gxTpr_Managerisactive = true;
            if ( AV52Trn_Manager.Update() )
            {
               context.CommitDataStores("wp_userprofile",pr_default);
            }
         }
         if ( AV52Trn_Manager.Success() || AV53Trn_Receptionist.Success() )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Account Updated Successfully.", ""),  "success",  "",  "true",  ""));
            GXt_SdtWWPContext4 = AV65WWPContext;
            new prc_loadwwpcontext(context ).execute( ref  GXt_SdtWWPContext4) ;
            AV65WWPContext = GXt_SdtWWPContext4;
            /* Execute user subroutine: 'LOADUSERPROFILE' */
            S132 ();
            if (returnInSub) return;
            this.executeExternalObjectMethod("", false, "GlobalEvents", "RefreshUserProfile", new Object[] {}, true);
         }
         else
         {
            AV80GXV5 = 1;
            AV79GXV4 = AV52Trn_Manager.GetMessages();
            while ( AV80GXV5 <= AV79GXV4.Count )
            {
               AV69Message = ((GeneXus.Utils.SdtMessages_Message)AV79GXV4.Item(AV80GXV5));
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV69Message.gxTpr_Description,  "error",  "",  "true",  ""));
               AV80GXV5 = (int)(AV80GXV5+1);
            }
            AV82GXV7 = 1;
            AV81GXV6 = AV53Trn_Receptionist.GetMessages();
            while ( AV82GXV7 <= AV81GXV6.Count )
            {
               AV69Message = ((GeneXus.Utils.SdtMessages_Message)AV81GXV6.Item(AV82GXV7));
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV69Message.gxTpr_Description,  "error",  "",  "true",  ""));
               AV82GXV7 = (int)(AV82GXV7+1);
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E179D2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_106_9D2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblUpdateactionstable_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblUpdateactionstable_Internalname, tblUpdateactionstable_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellMarginTop'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            ClassString = "btn-default";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "Cancel", ""), bttBtncancel_Jsonclick, 7, context.GetMessage( "Cancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e189d1_client"+"'", TempTags, "", 2, "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsaveupdate_Internalname, "", context.GetMessage( "Update", ""), bttBtnsaveupdate_Jsonclick, 5, context.GetMessage( "Update", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOSAVEUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_UserProfile.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_106_9D2e( true) ;
         }
         else
         {
            wb_table1_106_9D2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA9D2( ) ;
         WS9D2( ) ;
         WE9D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145524075", true, true);
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
         context.AddJavascriptSource("wp_userprofile.js", "?20256145524080", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_AvatarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgavProfileimage_Internalname = "vPROFILEIMAGE";
         edtavUser_Internalname = "vUSER";
         edtavRole_Internalname = "vROLE";
         bttBtnupdateprofile_Internalname = "BTNUPDATEPROFILE";
         divProfileextendedinfo1_tablemaininfo_Internalname = "PROFILEEXTENDEDINFO1_TABLEMAININFO";
         Dvpanel_profileextendedinfo1_tablemaininfo_Internalname = "DVPANEL_PROFILEEXTENDEDINFO1_TABLEMAININFO";
         lblAvatarlabel_Internalname = "AVATARLABEL";
         Avataruc_Internalname = "AVATARUC";
         divFieldavatartable_Internalname = "FIELDAVATARTABLE";
         divUpdateavatartable_Internalname = "UPDATEAVATARTABLE";
         edtavFirstname_Internalname = "vFIRSTNAME";
         divProfileextendedinfo1_firstinfoabout_Internalname = "PROFILEEXTENDEDINFO1_FIRSTINFOABOUT";
         edtavFirstnamevalue_Internalname = "vFIRSTNAMEVALUE";
         divUpdatemodefirstnametbl_Internalname = "UPDATEMODEFIRSTNAMETBL";
         edtavLastname_Internalname = "vLASTNAME";
         divProfileextendedinfo1_secondinfoabout_Internalname = "PROFILEEXTENDEDINFO1_SECONDINFOABOUT";
         edtavLastnamevalue_Internalname = "vLASTNAMEVALUE";
         divUpdatemodelastnaetbl_Internalname = "UPDATEMODELASTNAETBL";
         edtavEmail_Internalname = "vEMAIL";
         divProfileextendedinfo1_thirdinfoabout_Internalname = "PROFILEEXTENDEDINFO1_THIRDINFOABOUT";
         edtavEmailvalue_Internalname = "vEMAILVALUE";
         divUpdateemailtbl_Internalname = "UPDATEEMAILTBL";
         edtavPhone_Internalname = "vPHONE";
         divProfileextendedinfo1_fourthinfoabout_Internalname = "PROFILEEXTENDEDINFO1_FOURTHINFOABOUT";
         lblPhonelabel_Internalname = "PHONELABEL";
         Combo_phonecode_Internalname = "COMBO_PHONECODE";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         edtavPhonenumber_Internalname = "vPHONENUMBER";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divUpdatephonetbl_Internalname = "UPDATEPHONETBL";
         bttBtncancel_Internalname = "BTNCANCEL";
         bttBtnsaveupdate_Internalname = "BTNSAVEUPDATE";
         tblUpdateactionstable_Internalname = "UPDATEACTIONSTABLE";
         divProfileextendedinfo1_tableabout_Internalname = "PROFILEEXTENDEDINFO1_TABLEABOUT";
         Dvpanel_profileextendedinfo1_tableabout_Internalname = "DVPANEL_PROFILEEXTENDEDINFO1_TABLEABOUT";
         divProfileextendedinfo1_maintable_Internalname = "PROFILEEXTENDEDINFO1_MAINTABLE";
         Comfirmdeletemodal_Internalname = "COMFIRMDELETEMODAL";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavPhonecode_Internalname = "vPHONECODE";
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
         tblUpdateactionstable_Visible = 1;
         edtavPhonecode_Jsonclick = "";
         edtavPhonecode_Visible = 1;
         edtavPhonenumber_Jsonclick = "";
         edtavPhonenumber_Enabled = 1;
         Combo_phonecode_Caption = "";
         divUpdatephonetbl_Visible = 1;
         edtavPhone_Jsonclick = "";
         edtavPhone_Enabled = 1;
         divProfileextendedinfo1_fourthinfoabout_Visible = 1;
         edtavEmailvalue_Jsonclick = "";
         edtavEmailvalue_Enabled = 1;
         divUpdateemailtbl_Visible = 1;
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         divProfileextendedinfo1_thirdinfoabout_Visible = 1;
         edtavLastnamevalue_Jsonclick = "";
         edtavLastnamevalue_Enabled = 1;
         divUpdatemodelastnaetbl_Visible = 1;
         edtavLastname_Jsonclick = "";
         edtavLastname_Enabled = 1;
         divProfileextendedinfo1_secondinfoabout_Visible = 1;
         edtavFirstnamevalue_Jsonclick = "";
         edtavFirstnamevalue_Enabled = 1;
         divUpdatemodefirstnametbl_Visible = 1;
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Enabled = 1;
         divProfileextendedinfo1_firstinfoabout_Visible = 1;
         divUpdateavatartable_Visible = 1;
         edtavRole_Jsonclick = "";
         edtavRole_Enabled = 1;
         edtavUser_Jsonclick = "";
         edtavUser_Enabled = 1;
         imgavProfileimage_gximage = "";
         Comfirmdeletemodal_Bodytype = "No";
         Comfirmdeletemodal_Nobuttoncaption = "Cancel";
         Comfirmdeletemodal_Yesbuttoncaption = "Yes";
         Comfirmdeletemodal_Confirmationtext = "Are you sure you want to delete the current avatar?";
         Comfirmdeletemodal_Title = context.GetMessage( "Comfirm Delete", "");
         Dvpanel_profileextendedinfo1_tableabout_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_profileextendedinfo1_tableabout_Iconposition = "Right";
         Dvpanel_profileextendedinfo1_tableabout_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_profileextendedinfo1_tableabout_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_profileextendedinfo1_tableabout_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_profileextendedinfo1_tableabout_Title = context.GetMessage( "About", "");
         Dvpanel_profileextendedinfo1_tableabout_Cls = "PanelCard_GrayTitle";
         Dvpanel_profileextendedinfo1_tableabout_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_profileextendedinfo1_tableabout_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_profileextendedinfo1_tableabout_Width = "100%";
         Combo_phonecode_Htmltemplate = "";
         Combo_phonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_phonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Avataruc_Previewimagelink = "";
         Dvpanel_profileextendedinfo1_tablemaininfo_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_profileextendedinfo1_tablemaininfo_Iconposition = "Right";
         Dvpanel_profileextendedinfo1_tablemaininfo_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_profileextendedinfo1_tablemaininfo_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_profileextendedinfo1_tablemaininfo_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_profileextendedinfo1_tablemaininfo_Title = context.GetMessage( "My Profile", "");
         Dvpanel_profileextendedinfo1_tablemaininfo_Cls = "PanelCard_GrayTitle ProfilePaddingBottom20";
         Dvpanel_profileextendedinfo1_tablemaininfo_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_profileextendedinfo1_tablemaininfo_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_profileextendedinfo1_tablemaininfo_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Profile", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("'DOCANCEL'","""{"handler":"E189D1","iparms":[{"av":"AV6isUpdateMode","fld":"vISUPDATEMODE"}]""");
         setEventMetadata("'DOCANCEL'",""","oparms":[{"av":"AV6isUpdateMode","fld":"vISUPDATEMODE"},{"av":"divUpdateavatartable_Visible","ctrl":"UPDATEAVATARTABLE","prop":"Visible"},{"av":"divProfileextendedinfo1_firstinfoabout_Visible","ctrl":"PROFILEEXTENDEDINFO1_FIRSTINFOABOUT","prop":"Visible"},{"av":"divUpdatemodefirstnametbl_Visible","ctrl":"UPDATEMODEFIRSTNAMETBL","prop":"Visible"},{"av":"divProfileextendedinfo1_secondinfoabout_Visible","ctrl":"PROFILEEXTENDEDINFO1_SECONDINFOABOUT","prop":"Visible"},{"av":"divUpdatemodelastnaetbl_Visible","ctrl":"UPDATEMODELASTNAETBL","prop":"Visible"},{"av":"divProfileextendedinfo1_thirdinfoabout_Visible","ctrl":"PROFILEEXTENDEDINFO1_THIRDINFOABOUT","prop":"Visible"},{"av":"divUpdateemailtbl_Visible","ctrl":"UPDATEEMAILTBL","prop":"Visible"},{"av":"divProfileextendedinfo1_fourthinfoabout_Visible","ctrl":"PROFILEEXTENDEDINFO1_FOURTHINFOABOUT","prop":"Visible"},{"av":"divUpdatephonetbl_Visible","ctrl":"UPDATEPHONETBL","prop":"Visible"},{"av":"tblUpdateactionstable_Visible","ctrl":"UPDATEACTIONSTABLE","prop":"Visible"}]}""");
         setEventMetadata("'DOSAVEUPDATE'","""{"handler":"E159D2","iparms":[{"av":"AV65WWPContext","fld":"vWWPCONTEXT"},{"av":"AV11CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV17EmailValue","fld":"vEMAILVALUE"},{"av":"AV24FirstNameValue","fld":"vFIRSTNAMEVALUE"},{"av":"AV30LastNameValue","fld":"vLASTNAMEVALUE"},{"av":"AV38PhoneNumber","fld":"vPHONENUMBER"},{"av":"AV34PhoneCode","fld":"vPHONECODE"},{"av":"AV66base64String","fld":"vBASE64STRING"},{"av":"AV52Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV53Trn_Receptionist","fld":"vTRN_RECEPTIONIST"},{"av":"AV6isUpdateMode","fld":"vISUPDATEMODE"}]""");
         setEventMetadata("'DOSAVEUPDATE'",""","oparms":[{"av":"AV6isUpdateMode","fld":"vISUPDATEMODE"},{"av":"AV11CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV53Trn_Receptionist","fld":"vTRN_RECEPTIONIST"},{"av":"AV52Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV65WWPContext","fld":"vWWPCONTEXT"},{"av":"divUpdateavatartable_Visible","ctrl":"UPDATEAVATARTABLE","prop":"Visible"},{"av":"divProfileextendedinfo1_firstinfoabout_Visible","ctrl":"PROFILEEXTENDEDINFO1_FIRSTINFOABOUT","prop":"Visible"},{"av":"divUpdatemodefirstnametbl_Visible","ctrl":"UPDATEMODEFIRSTNAMETBL","prop":"Visible"},{"av":"divProfileextendedinfo1_secondinfoabout_Visible","ctrl":"PROFILEEXTENDEDINFO1_SECONDINFOABOUT","prop":"Visible"},{"av":"divUpdatemodelastnaetbl_Visible","ctrl":"UPDATEMODELASTNAETBL","prop":"Visible"},{"av":"divProfileextendedinfo1_thirdinfoabout_Visible","ctrl":"PROFILEEXTENDEDINFO1_THIRDINFOABOUT","prop":"Visible"},{"av":"divUpdateemailtbl_Visible","ctrl":"UPDATEEMAILTBL","prop":"Visible"},{"av":"divProfileextendedinfo1_fourthinfoabout_Visible","ctrl":"PROFILEEXTENDEDINFO1_FOURTHINFOABOUT","prop":"Visible"},{"av":"divUpdatephonetbl_Visible","ctrl":"UPDATEPHONETBL","prop":"Visible"},{"av":"tblUpdateactionstable_Visible","ctrl":"UPDATEACTIONSTABLE","prop":"Visible"},{"av":"AV68profileImage","fld":"vPROFILEIMAGE"},{"av":"AV56user","fld":"vUSER"},{"av":"AV16Email","fld":"vEMAIL"},{"av":"AV23FirstName","fld":"vFIRSTNAME"},{"av":"AV29LastName","fld":"vLASTNAME"},{"av":"AV33Phone","fld":"vPHONE"},{"av":"AV46role","fld":"vROLE"}]}""");
         setEventMetadata("'DOUPDATEPROFILE'","""{"handler":"E169D2","iparms":[{"av":"AV23FirstName","fld":"vFIRSTNAME"},{"av":"AV29LastName","fld":"vLASTNAME"},{"av":"AV16Email","fld":"vEMAIL"},{"av":"AV65WWPContext","fld":"vWWPCONTEXT"},{"av":"AV33Phone","fld":"vPHONE"},{"av":"AV6isUpdateMode","fld":"vISUPDATEMODE"}]""");
         setEventMetadata("'DOUPDATEPROFILE'",""","oparms":[{"av":"AV6isUpdateMode","fld":"vISUPDATEMODE"},{"av":"AV24FirstNameValue","fld":"vFIRSTNAMEVALUE"},{"av":"AV30LastNameValue","fld":"vLASTNAMEVALUE"},{"av":"AV17EmailValue","fld":"vEMAILVALUE"},{"av":"Avataruc_Previewimagelink","ctrl":"AVATARUC","prop":"PreviewImageLink"},{"av":"AV38PhoneNumber","fld":"vPHONENUMBER"},{"av":"AV34PhoneCode","fld":"vPHONECODE"},{"av":"Combo_phonecode_Selectedtext_set","ctrl":"COMBO_PHONECODE","prop":"SelectedText_set"},{"av":"Combo_phonecode_Selectedvalue_set","ctrl":"COMBO_PHONECODE","prop":"SelectedValue_set"},{"av":"divUpdateavatartable_Visible","ctrl":"UPDATEAVATARTABLE","prop":"Visible"},{"av":"divProfileextendedinfo1_firstinfoabout_Visible","ctrl":"PROFILEEXTENDEDINFO1_FIRSTINFOABOUT","prop":"Visible"},{"av":"divUpdatemodefirstnametbl_Visible","ctrl":"UPDATEMODEFIRSTNAMETBL","prop":"Visible"},{"av":"divProfileextendedinfo1_secondinfoabout_Visible","ctrl":"PROFILEEXTENDEDINFO1_SECONDINFOABOUT","prop":"Visible"},{"av":"divUpdatemodelastnaetbl_Visible","ctrl":"UPDATEMODELASTNAETBL","prop":"Visible"},{"av":"divProfileextendedinfo1_thirdinfoabout_Visible","ctrl":"PROFILEEXTENDEDINFO1_THIRDINFOABOUT","prop":"Visible"},{"av":"divUpdateemailtbl_Visible","ctrl":"UPDATEEMAILTBL","prop":"Visible"},{"av":"divProfileextendedinfo1_fourthinfoabout_Visible","ctrl":"PROFILEEXTENDEDINFO1_FOURTHINFOABOUT","prop":"Visible"},{"av":"divUpdatephonetbl_Visible","ctrl":"UPDATEPHONETBL","prop":"Visible"},{"av":"tblUpdateactionstable_Visible","ctrl":"UPDATEACTIONSTABLE","prop":"Visible"}]}""");
         setEventMetadata("AVATARUC.ONUPLOAD","""{"handler":"E119D2","iparms":[{"av":"AV21FileUploadedData","fld":"vFILEUPLOADEDDATA"}]""");
         setEventMetadata("AVATARUC.ONUPLOAD",""","oparms":[{"av":"AV66base64String","fld":"vBASE64STRING"}]}""");
         setEventMetadata("AVATARUC.ONFAILEDUPLOAD","""{"handler":"E129D2","iparms":[]}""");
         setEventMetadata("COMFIRMDELETEMODAL.ONYES","""{"handler":"E139D2","iparms":[]""");
         setEventMetadata("COMFIRMDELETEMODAL.ONYES",""","oparms":[{"av":"AV66base64String","fld":"vBASE64STRING"},{"av":"Avataruc_Previewimagelink","ctrl":"AVATARUC","prop":"PreviewImageLink"}]}""");
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
         AV65WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         Combo_phonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV21FileUploadedData = new SdtSDT_AvatarUpload(context);
         AV14DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV35PhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV66base64String = "";
         AV52Trn_Manager = new SdtTrn_Manager(context);
         AV53Trn_Receptionist = new SdtTrn_Receptionist(context);
         Combo_phonecode_Selectedvalue_set = "";
         Combo_phonecode_Selectedtext_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_profileextendedinfo1_tablemaininfo = new GXUserControl();
         AV68profileImage = "";
         AV78Profileimage_GXI = "";
         sImgUrl = "";
         TempTags = "";
         AV56user = "";
         AV46role = "";
         bttBtnupdateprofile_Jsonclick = "";
         ucDvpanel_profileextendedinfo1_tableabout = new GXUserControl();
         lblAvatarlabel_Jsonclick = "";
         ucAvataruc = new GXUserControl();
         AV23FirstName = "";
         AV24FirstNameValue = "";
         AV29LastName = "";
         AV30LastNameValue = "";
         AV16Email = "";
         AV17EmailValue = "";
         AV33Phone = "";
         lblPhonelabel_Jsonclick = "";
         ucCombo_phonecode = new GXUserControl();
         AV38PhoneNumber = "";
         ucComfirmdeletemodal = new GXUserControl();
         AV34PhoneCode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV5GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV62UserProfileImage = "";
         AV67WWP_UserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         AV26GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV25GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV37PhoneInputStrings = new GxSimpleCollection<string>();
         AV76GXV2 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version21");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version21");
         AV36PhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV12Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV13ComboTitles = new GxSimpleCollection<string>();
         AV60userOrganisation = "";
         GXt_char2 = "";
         GXt_SdtWWPContext4 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV79GXV4 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV69Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV81GXV6 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         sStyleString = "";
         bttBtncancel_Jsonclick = "";
         bttBtnsaveupdate_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_userprofile__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_userprofile__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_userprofile__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavUser_Enabled = 0;
         edtavRole_Enabled = 0;
         edtavFirstname_Enabled = 0;
         edtavLastname_Enabled = 0;
         edtavEmail_Enabled = 0;
         edtavPhone_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavUser_Enabled ;
      private int edtavRole_Enabled ;
      private int divUpdateavatartable_Visible ;
      private int divProfileextendedinfo1_firstinfoabout_Visible ;
      private int edtavFirstname_Enabled ;
      private int divUpdatemodefirstnametbl_Visible ;
      private int edtavFirstnamevalue_Enabled ;
      private int divProfileextendedinfo1_secondinfoabout_Visible ;
      private int edtavLastname_Enabled ;
      private int divUpdatemodelastnaetbl_Visible ;
      private int edtavLastnamevalue_Enabled ;
      private int divProfileextendedinfo1_thirdinfoabout_Visible ;
      private int edtavEmail_Enabled ;
      private int divUpdateemailtbl_Visible ;
      private int edtavEmailvalue_Enabled ;
      private int divProfileextendedinfo1_fourthinfoabout_Visible ;
      private int edtavPhone_Enabled ;
      private int divUpdatephonetbl_Visible ;
      private int edtavPhonenumber_Enabled ;
      private int edtavPhonecode_Visible ;
      private int AV75GXV1 ;
      private int tblUpdateactionstable_Visible ;
      private int AV77GXV3 ;
      private int AV80GXV5 ;
      private int AV82GXV7 ;
      private int idxLst ;
      private string Combo_phonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_profileextendedinfo1_tablemaininfo_Width ;
      private string Dvpanel_profileextendedinfo1_tablemaininfo_Cls ;
      private string Dvpanel_profileextendedinfo1_tablemaininfo_Title ;
      private string Dvpanel_profileextendedinfo1_tablemaininfo_Iconposition ;
      private string Avataruc_Previewimagelink ;
      private string Combo_phonecode_Cls ;
      private string Combo_phonecode_Selectedvalue_set ;
      private string Combo_phonecode_Selectedtext_set ;
      private string Combo_phonecode_Htmltemplate ;
      private string Dvpanel_profileextendedinfo1_tableabout_Width ;
      private string Dvpanel_profileextendedinfo1_tableabout_Cls ;
      private string Dvpanel_profileextendedinfo1_tableabout_Title ;
      private string Dvpanel_profileextendedinfo1_tableabout_Iconposition ;
      private string Comfirmdeletemodal_Title ;
      private string Comfirmdeletemodal_Confirmationtext ;
      private string Comfirmdeletemodal_Yesbuttoncaption ;
      private string Comfirmdeletemodal_Nobuttoncaption ;
      private string Comfirmdeletemodal_Bodytype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divProfileextendedinfo1_maintable_Internalname ;
      private string Dvpanel_profileextendedinfo1_tablemaininfo_Internalname ;
      private string divProfileextendedinfo1_tablemaininfo_Internalname ;
      private string imgavProfileimage_gximage ;
      private string sImgUrl ;
      private string imgavProfileimage_Internalname ;
      private string edtavUser_Internalname ;
      private string TempTags ;
      private string AV56user ;
      private string edtavUser_Jsonclick ;
      private string edtavRole_Internalname ;
      private string AV46role ;
      private string edtavRole_Jsonclick ;
      private string bttBtnupdateprofile_Internalname ;
      private string bttBtnupdateprofile_Jsonclick ;
      private string Dvpanel_profileextendedinfo1_tableabout_Internalname ;
      private string divProfileextendedinfo1_tableabout_Internalname ;
      private string divUpdateavatartable_Internalname ;
      private string divFieldavatartable_Internalname ;
      private string lblAvatarlabel_Internalname ;
      private string lblAvatarlabel_Jsonclick ;
      private string Avataruc_Internalname ;
      private string divProfileextendedinfo1_firstinfoabout_Internalname ;
      private string edtavFirstname_Internalname ;
      private string edtavFirstname_Jsonclick ;
      private string divUpdatemodefirstnametbl_Internalname ;
      private string edtavFirstnamevalue_Internalname ;
      private string edtavFirstnamevalue_Jsonclick ;
      private string divProfileextendedinfo1_secondinfoabout_Internalname ;
      private string edtavLastname_Internalname ;
      private string edtavLastname_Jsonclick ;
      private string divUpdatemodelastnaetbl_Internalname ;
      private string edtavLastnamevalue_Internalname ;
      private string edtavLastnamevalue_Jsonclick ;
      private string divProfileextendedinfo1_thirdinfoabout_Internalname ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Jsonclick ;
      private string divUpdateemailtbl_Internalname ;
      private string edtavEmailvalue_Internalname ;
      private string edtavEmailvalue_Jsonclick ;
      private string divProfileextendedinfo1_fourthinfoabout_Internalname ;
      private string edtavPhone_Internalname ;
      private string edtavPhone_Jsonclick ;
      private string divUpdatephonetbl_Internalname ;
      private string lblPhonelabel_Internalname ;
      private string lblPhonelabel_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string Combo_phonecode_Caption ;
      private string Combo_phonecode_Internalname ;
      private string edtavPhonenumber_Internalname ;
      private string edtavPhonenumber_Jsonclick ;
      private string Comfirmdeletemodal_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavPhonecode_Internalname ;
      private string edtavPhonecode_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string tblUpdateactionstable_Internalname ;
      private string GXt_char2 ;
      private string sStyleString ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string bttBtnsaveupdate_Internalname ;
      private string bttBtnsaveupdate_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV6isUpdateMode ;
      private bool AV11CheckRequiredFieldsResult ;
      private bool Dvpanel_profileextendedinfo1_tablemaininfo_Autowidth ;
      private bool Dvpanel_profileextendedinfo1_tablemaininfo_Autoheight ;
      private bool Dvpanel_profileextendedinfo1_tablemaininfo_Collapsible ;
      private bool Dvpanel_profileextendedinfo1_tablemaininfo_Collapsed ;
      private bool Dvpanel_profileextendedinfo1_tablemaininfo_Showcollapseicon ;
      private bool Dvpanel_profileextendedinfo1_tablemaininfo_Autoscroll ;
      private bool Combo_phonecode_Emptyitem ;
      private bool Dvpanel_profileextendedinfo1_tableabout_Autowidth ;
      private bool Dvpanel_profileextendedinfo1_tableabout_Autoheight ;
      private bool Dvpanel_profileextendedinfo1_tableabout_Collapsible ;
      private bool Dvpanel_profileextendedinfo1_tableabout_Collapsed ;
      private bool Dvpanel_profileextendedinfo1_tableabout_Showcollapseicon ;
      private bool Dvpanel_profileextendedinfo1_tableabout_Autoscroll ;
      private bool wbLoad ;
      private bool AV68profileImage_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV66base64String ;
      private string AV78Profileimage_GXI ;
      private string AV23FirstName ;
      private string AV24FirstNameValue ;
      private string AV29LastName ;
      private string AV30LastNameValue ;
      private string AV16Email ;
      private string AV17EmailValue ;
      private string AV33Phone ;
      private string AV38PhoneNumber ;
      private string AV34PhoneCode ;
      private string AV60userOrganisation ;
      private string AV68profileImage ;
      private string AV62UserProfileImage ;
      private GXUserControl ucDvpanel_profileextendedinfo1_tablemaininfo ;
      private GXUserControl ucDvpanel_profileextendedinfo1_tableabout ;
      private GXUserControl ucAvataruc ;
      private GXUserControl ucCombo_phonecode ;
      private GXUserControl ucComfirmdeletemodal ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV65WWPContext ;
      private SdtSDT_AvatarUpload AV21FileUploadedData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV35PhoneCode_Data ;
      private SdtTrn_Manager AV52Trn_Manager ;
      private SdtTrn_Receptionist AV53Trn_Receptionist ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV5GAMUser ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV67WWP_UserExtended ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV26GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV25GAMError ;
      private GxSimpleCollection<string> AV37PhoneInputStrings ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV76GXV2 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem3 ;
      private SdtSDT_Country_SDT_CountryItem AV36PhoneCode_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private GxSimpleCollection<string> AV13ComboTitles ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext4 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV79GXV4 ;
      private GeneXus.Utils.SdtMessages_Message AV69Message ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV81GXV6 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_userprofile__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_userprofile__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_userprofile__default : DataStoreHelperBase, IDataStoreHelper
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
