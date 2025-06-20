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
namespace GeneXus.Programs.wwpbaseobjects {
   public class workwithplustoolboxmasterpage : GXMasterPage
   {
      public workwithplustoolboxmasterpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public workwithplustoolboxmasterpage( IGxContext context )
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
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            PA7O2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS7O2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE7O2( ) ;
               }
            }
         }
         cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            GXWebForm.AddResponsiveMetaHeaders((getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta);
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vDVELOP_MENU_MPAGE", AV22DVelop_Menu);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDVELOP_MENU_MPAGE", AV22DVelop_Menu);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vDVELOP_MENU_USERDATA_MPAGE", AV10DVelop_Menu_UserData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDVELOP_MENU_USERDATA_MPAGE", AV10DVelop_Menu_UserData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vNOTIFICATIONINFO_MPAGE", AV11NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO_MPAGE", AV11NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDID_MPAGE", StringUtil.RTrim( A112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "vUDPARG1_MPAGE", StringUtil.RTrim( AV44Udparg1));
         GxWebStd.gx_boolean_hidden_field( context, "WWPNOTIFICATIONISREAD_MPAGE", A187WWPNotificationIsRead);
         GxWebStd.gx_hidden_field( context, "DDC_CHANGELANGUAGE_MPAGE_Caption", StringUtil.RTrim( Ddc_changelanguage_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_CHANGELANGUAGE_MPAGE_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_changelanguage_Componentwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icontype", StringUtil.RTrim( Ddc_notificationswc_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icon", StringUtil.RTrim( Ddc_notificationswc_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Caption", StringUtil.RTrim( Ddc_notificationswc_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Cls", StringUtil.RTrim( Ddc_notificationswc_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Icon", StringUtil.RTrim( Ddc_adminag_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Cls", StringUtil.RTrim( Ddc_adminag_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_adminag_Componentwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Sidebarmainclass", StringUtil.RTrim( Ucmenu_Sidebarmainclass));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Scrollwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucmenu_Scrollwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Scrollalwaysvisible", StringUtil.BoolToStr( Ucmenu_Scrollalwaysvisible));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Hidescrollincompactmenu", StringUtil.BoolToStr( Ucmenu_Hidescrollincompactmenu));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONINFO_MPAGE_Message", AV11NotificationInfo.gxTpr_Message);
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icon", StringUtil.RTrim( Ddc_notificationswc_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icon", StringUtil.RTrim( Ddc_notificationswc_Icon));
      }

      protected void RenderHtmlCloseForm7O2( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((string)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/slimscroll/jquery.slimscroll.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/SidebarMenu/BootstrapSidebarMenuRender.js", "", false, true);
         context.AddJavascriptSource("wwpbaseobjects/workwithplustoolboxmasterpage.js", "?20256201794010", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.WorkWithPlusToolBoxMasterPage" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Work With Plus Tool Box Master Page", "") ;
      }

      protected void WB7O0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MasterHeaderCell navbar-fixed-top", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "TableHeader", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Header Image", ""), "gx-form-item LogoImageLabel", 0, true, "width: 25%;");
            /* Static Bitmap Variable */
            ClassString = "LogoImage" + " " + ((StringUtil.StrCmp(imgavHeaderimage_gximage, "")==0) ? "" : "GX_Image_"+imgavHeaderimage_gximage+"_Class");
            StyleString = "";
            AV33HeaderImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV33HeaderImage))&&String.IsNullOrEmpty(StringUtil.RTrim( AV41Headerimage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV33HeaderImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV33HeaderImage)) ? AV41Headerimage_GXI : context.PathToRelativeUrl( AV33HeaderImage));
            GxWebStd.gx_bitmap( context, imgavHeaderimage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV33HeaderImage_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects/WorkWithPlusToolBoxMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblShowmenu_Internalname, context.GetMessage( "<i class=\"fa fa-bars ImageMenuIcon\"></i>", ""), "", "", lblShowmenu_Jsonclick, "'"+""+"'"+",true,"+"'"+"e117o1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/WorkWithPlusToolBoxMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableuserrole_Internalname, 1, 0, "px", 0, "px", "CellHeaderBar hidden-xs", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdc_changelanguage.SetProperty("Caption", Ddc_changelanguage_Caption);
            ucDdc_changelanguage.SetProperty("ComponentWidth", Ddc_changelanguage_Componentwidth);
            ucDdc_changelanguage.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_changelanguage_Internalname, "DDC_CHANGELANGUAGE_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_notificationswc.SetProperty("IconType", Ddc_notificationswc_Icontype);
            ucDdc_notificationswc.SetProperty("Icon", Ddc_notificationswc_Icon);
            ucDdc_notificationswc.SetProperty("Caption", Ddc_notificationswc_Caption);
            ucDdc_notificationswc.SetProperty("Cls", Ddc_notificationswc_Cls);
            ucDdc_notificationswc.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_notificationswc_Internalname, "DDC_NOTIFICATIONSWC_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "MasterTopIconsCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_adminag.SetProperty("Caption", Ddc_adminag_Caption);
            ucDdc_adminag.SetProperty("Cls", Ddc_adminag_Cls);
            ucDdc_adminag.SetProperty("ComponentWidth", Ddc_adminag_Componentwidth);
            ucDdc_adminag.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_adminag_Internalname, "DDC_ADMINAG_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellTableContentMaster", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "page-content MaterialStyle", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
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
            ucUcmenu.SetProperty("SidebarMainClass", Ucmenu_Sidebarmainclass);
            ucUcmenu.SetProperty("ScrollWidth", Ucmenu_Scrollwidth);
            ucUcmenu.SetProperty("ScrollAlwaysVisible", Ucmenu_Scrollalwaysvisible);
            ucUcmenu.SetProperty("HideScrollInCompactMenu", Ucmenu_Hidescrollincompactmenu);
            ucUcmenu.SetProperty("SidebarMenuOptionsData", AV22DVelop_Menu);
            ucUcmenu.SetProperty("SidebarMenuUserData", AV10DVelop_Menu_UserData);
            ucUcmenu.Render(context, "dvelop.gxbootstrap.sidebarmenu", Ucmenu_Internalname, "UCMENU_MPAGEContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',true,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavPickerdummyvariable_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavPickerdummyvariable_Internalname, context.localUtil.Format(AV31PickerDummyVariable, "99/99/99"), context.localUtil.Format( AV31PickerDummyVariable, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "", "", "", edtavPickerdummyvariable_Jsonclick, 0, "Invisible", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/WorkWithPlusToolBoxMasterPage.htm");
            GxWebStd.gx_bitmap( context, edtavPickerdummyvariable_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/WorkWithPlusToolBoxMasterPage.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "MPW0039"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0039"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0039"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START7O2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7O0( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WS7O2( )
      {
         START7O2( ) ;
         EVT7O2( ) ;
      }

      protected void EVT7O2( )
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
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDC_CHANGELANGUAGE_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddc_changelanguage.Onloadcomponent */
                           E127O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddc_notificationswc.Onloadcomponent */
                           E137O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddc_adminag.Onloadcomponent */
                           E147O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E157O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Onmessage_gx1 */
                           E167O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E177O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
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
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Onmessage_gx1 */
                           E167O2 ();
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  else if ( StringUtil.StrCmp(sEvtType, "M") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-2));
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-6));
                     nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                     if ( nCmpId == 39 )
                     {
                        OldWwpaux_wc = cgiGet( "MPW0039");
                        if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                        {
                           WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                           WebComp_Wwpaux_wc.ComponentInit();
                           WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                        if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                        {
                           WebComp_Wwpaux_wc.componentprocess("MPW0039", "", sEvt);
                        }
                        WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                     }
                  }
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE7O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm7O2( ) ;
            }
         }
      }

      protected void PA7O2( )
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
               GX_FocusControl = edtavPickerdummyvariable_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
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
         RF7O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( 1 != 0 )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     WebComp_Wwpaux_wc.componentstart();
                  }
               }
            }
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E177O2 ();
            WB7O0( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes7O2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E157O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDVELOP_MENU_MPAGE"), AV22DVelop_Menu);
            ajax_req_read_hidden_sdt(cgiGet( "vDVELOP_MENU_USERDATA_MPAGE"), AV10DVelop_Menu_UserData);
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO_MPAGE"), AV11NotificationInfo);
            /* Read saved values. */
            Ddc_changelanguage_Caption = cgiGet( "DDC_CHANGELANGUAGE_MPAGE_Caption");
            Ddc_changelanguage_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_CHANGELANGUAGE_MPAGE_Componentwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddc_notificationswc_Icontype = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Icontype");
            Ddc_notificationswc_Icon = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Icon");
            Ddc_notificationswc_Caption = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Caption");
            Ddc_notificationswc_Cls = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Cls");
            Ddc_adminag_Icon = cgiGet( "DDC_ADMINAG_MPAGE_Icon");
            Ddc_adminag_Cls = cgiGet( "DDC_ADMINAG_MPAGE_Cls");
            Ddc_adminag_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_ADMINAG_MPAGE_Componentwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ucmenu_Sidebarmainclass = cgiGet( "UCMENU_MPAGE_Sidebarmainclass");
            Ucmenu_Scrollwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCMENU_MPAGE_Scrollwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ucmenu_Scrollalwaysvisible = StringUtil.StrToBool( cgiGet( "UCMENU_MPAGE_Scrollalwaysvisible"));
            Ucmenu_Hidescrollincompactmenu = StringUtil.StrToBool( cgiGet( "UCMENU_MPAGE_Hidescrollincompactmenu"));
            Ddc_notificationswc_Icon = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Icon");
            /* Read variables values. */
            AV33HeaderImage = cgiGet( imgavHeaderimage_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavPickerdummyvariable_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Picker Dummy Variable", "")}), 1, "vPICKERDUMMYVARIABLE_MPAGE");
               GX_FocusControl = edtavPickerdummyvariable_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31PickerDummyVariable = DateTime.MinValue;
               AssignAttri("", true, "AV31PickerDummyVariable", context.localUtil.Format(AV31PickerDummyVariable, "99/99/99"));
            }
            else
            {
               AV31PickerDummyVariable = context.localUtil.CToD( cgiGet( edtavPickerdummyvariable_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", true, "AV31PickerDummyVariable", context.localUtil.Format(AV31PickerDummyVariable, "99/99/99"));
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
         E157O2 ();
         if (returnInSub) return;
      }

      protected void E157O2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDT_OrganisationSetting1 = AV34SDT_OrganisationSetting;
         new prc_organisationsetting(context ).execute( out  GXt_SdtSDT_OrganisationSetting1) ;
         AV34SDT_OrganisationSetting = GXt_SdtSDT_OrganisationSetting1;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34SDT_OrganisationSetting.gxTpr_Organisationsettingfavicon)) )
         {
            (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\""+context.convertURL( (string)(context.GetImagePath( "cceab8ff-208f-4395-99fd-7fe799e0d69c", "", context.GetTheme( ))))+"\">";
         }
         else
         {
            (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\""+AV34SDT_OrganisationSetting.gxTpr_Organisationsettingfavicon_gxi+"\">";
         }
         divLayoutmaintable_Class = "MainContainerWithFooter";
         AssignProp("", true, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         GXt_objcol_SdtDVelop_Menu_Item2 = AV22DVelop_Menu;
         new umenuoptionsdata(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
         AV22DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
         new WorkWithPlus.workwithplus_webgam.getmenuauthorizedoptions(context ).execute( ref  AV22DVelop_Menu) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34SDT_OrganisationSetting.gxTpr_Organisationsettinglogo)) )
         {
            imgImagelogo_gximage = "LogoLogin";
            AssignProp("", true, imgImagelogo_Internalname, "gximage", imgImagelogo_gximage, true);
            AV35ImageLogo = context.GetImagePath( "e9edf59f-db45-4e16-b6a6-2c2b6611a4a3", "", context.GetTheme( ));
            AV40Imagelogo_GXI = GXDbFile.PathToUrl( context.GetImagePath( "e9edf59f-db45-4e16-b6a6-2c2b6611a4a3", "", context.GetTheme( )), context);
            AV33HeaderImage = AV35ImageLogo;
            AssignProp("", true, imgavHeaderimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV33HeaderImage)) ? AV41Headerimage_GXI : context.convertURL( context.PathToRelativeUrl( AV33HeaderImage))), true);
            AssignProp("", true, imgavHeaderimage_Internalname, "SrcSet", context.GetImageSrcSet( AV33HeaderImage), true);
            AV41Headerimage_GXI = AV40Imagelogo_GXI;
            AssignProp("", true, imgavHeaderimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV33HeaderImage)) ? AV41Headerimage_GXI : context.convertURL( context.PathToRelativeUrl( AV33HeaderImage))), true);
            AssignProp("", true, imgavHeaderimage_Internalname, "SrcSet", context.GetImageSrcSet( AV33HeaderImage), true);
         }
         else
         {
            AV33HeaderImage = AV34SDT_OrganisationSetting.gxTpr_Organisationsettinglogo;
            AssignProp("", true, imgavHeaderimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV33HeaderImage)) ? AV41Headerimage_GXI : context.convertURL( context.PathToRelativeUrl( AV33HeaderImage))), true);
            AssignProp("", true, imgavHeaderimage_Internalname, "SrcSet", context.GetImageSrcSet( AV33HeaderImage), true);
            AV41Headerimage_GXI = AV34SDT_OrganisationSetting.gxTpr_Organisationsettinglogo_gxi;
            AssignProp("", true, imgavHeaderimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV33HeaderImage)) ? AV41Headerimage_GXI : context.convertURL( context.PathToRelativeUrl( AV33HeaderImage))), true);
            AssignProp("", true, imgavHeaderimage_Internalname, "SrcSet", context.GetImageSrcSet( AV33HeaderImage), true);
         }
         Ddc_adminag_Icon = context.convertURL( (string)(context.GetImagePath( "cd132e7c-3222-4be1-9123-4cad0b17f9cf", "", context.GetTheme( ))));
         ucDdc_adminag.SendProperty(context, "", true, Ddc_adminag_Internalname, "Icon", Ddc_adminag_Icon);
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
         AV23UserName = (String.IsNullOrEmpty(StringUtil.RTrim( AV9GAMUser.gxTpr_Firstname)) ? AV9GAMUser.gxTpr_Name : StringUtil.Trim( AV9GAMUser.gxTpr_Firstname)+" "+StringUtil.Trim( AV9GAMUser.gxTpr_Lastname));
         AV5GAMRoleCollection = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).getroles(out  AV7GAMErrorCollection);
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV5GAMRoleCollection.Count )
         {
            AV6GAMRole = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV5GAMRoleCollection.Item(AV42GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24RolesDescriptions)) )
            {
               AV24RolesDescriptions += ", ";
               AssignAttri("", true, "AV24RolesDescriptions", AV24RolesDescriptions);
            }
            AV24RolesDescriptions += (String.IsNullOrEmpty(StringUtil.RTrim( AV6GAMRole.gxTpr_Description)) ? AV6GAMRole.gxTpr_Name : AV6GAMRole.gxTpr_Description);
            AssignAttri("", true, "AV24RolesDescriptions", AV24RolesDescriptions);
            AV42GXV1 = (int)(AV42GXV1+1);
         }
         if ( StringUtil.StrCmp(AV25WebSession.Get(context.GetMessage( "ClientInformationSaved", "")), context.GetMessage( "Y", "")) != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_registerwebclient(context ).execute(  new GeneXus.Core.genexus.client.SdtClientInformation(context).gxTpr_Id,  (short)(context.GetBrowserType( )),  context.GetBrowserVersion( ),  new WorkWithPlus.workwithplus_commongam.wwp_getloggeduserid(context).executeUdp( )) ;
            AV25WebSession.Set(context.GetMessage( "ClientInformationSaved", ""), context.GetMessage( "Y", ""));
         }
         /* Execute user subroutine: 'LOADNOTIFICATIONS' */
         S112 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV28Httprequest.Method, "GET") == 0 )
         {
            GXt_SdtWWP_DesignSystemSettings3 = AV15WWP_DesignSystemSettings;
            new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings3) ;
            AV15WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings3;
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"base-color",AV34SDT_OrganisationSetting.gxTpr_Organisationsettingbasecolor}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"background-color",AV15WWP_DesignSystemSettings.gxTpr_Backgroundstyle}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"menu-color",AV15WWP_DesignSystemSettings.gxTpr_Menucolor}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"font-size",AV34SDT_OrganisationSetting.gxTpr_Organisationsettingfontsize}, false);
            this.executeExternalObjectMethod("", true, "WWPActions", "EmpoweredGrids_Refresh", new Object[] {}, false);
         }
         Ddc_changelanguage_Caption = context.GetLanguage( );
         ucDdc_changelanguage.SendProperty(context, "", true, Ddc_changelanguage_Internalname, "Caption", Ddc_changelanguage_Caption);
      }

      protected void E127O2( )
      {
         /* Ddc_changelanguage_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WC_ChangeLanguage")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wc_changelanguage", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WC_ChangeLanguage";
            WebComp_Wwpaux_wc_Component = "WC_ChangeLanguage";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0039",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0039"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E137O2( )
      {
         /* Ddc_notificationswc_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.notifications.common.wwp_masterpagenotificationswc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0039",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0039"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E147O2( )
      {
         /* Ddc_adminag_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.WWP_MasterPageTopActionsWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wwp_masterpagetopactionswc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.WWP_MasterPageTopActionsWC";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.WWP_MasterPageTopActionsWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0039",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0039"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E167O2( )
      {
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         if ( StringUtil.StartsWith( AV11NotificationInfo.gxTpr_Id, "WebNotification#") )
         {
            AV13WWP_WebNotification.FromJSonString(AV11NotificationInfo.gxTpr_Message, null);
            if ( ! new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_isreceivedwebnotification(context).executeUdp(  AV13WWP_WebNotification.gxTpr_Wwpwebnotificationid) )
            {
               new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_setwebnotificationreceived(context ).execute(  AV13WWP_WebNotification.gxTpr_Wwpwebnotificationid) ;
               AV14WWP_UserExtended.Load(new WorkWithPlus.workwithplus_commongam.wwp_getloggeduserid(context).executeUdp( ));
               if ( AV14WWP_UserExtended.gxTpr_Wwpuserextendeddesktopnotif )
               {
                  GXKey = Crypto.GetSiteKey( );
                  GXEncryptionTmp = "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx"+UrlEncode(StringUtil.LTrimStr(AV13WWP_WebNotification.gxTpr_Wwpnotificationid,10,0));
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetdesktopnotificationmsg(context).executeUdp(  AV13WWP_WebNotification.gxTpr_Wwpwebnotificationtitle,  AV13WWP_WebNotification.gxTpr_Wwpwebnotificationtext,  AV13WWP_WebNotification.gxTpr_Wwpwebnotificationicon,  formatLink("wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)));
               }
            }
         }
         /* Execute user subroutine: 'LOADNOTIFICATIONS' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'LOADNOTIFICATIONS' Routine */
         returnInSub = false;
         AV12NotificationsCount = 0;
         AV44Udparg1 = new WorkWithPlus.workwithplus_commongam.wwp_getloggeduserid(context).executeUdp( );
         /* Optimized group. */
         /* Using cursor H007O2 */
         pr_default.execute(0, new Object[] {AV44Udparg1});
         cV12NotificationsCount = H007O2_AV12NotificationsCount[0];
         pr_default.close(0);
         AV12NotificationsCount = (short)(AV12NotificationsCount+cV12NotificationsCount*1);
         /* End optimized group. */
         this.executeUsercontrolMethod("", true, "DDC_NOTIFICATIONSWC_MPAGEContainer", "Update", "", new Object[] {((AV12NotificationsCount>0) ? StringUtil.Trim( StringUtil.Str( (decimal)(AV12NotificationsCount), 4, 0)) : ""),(string)Ddc_notificationswc_Icon});
      }

      protected void nextLoad( )
      {
      }

      protected void E177O2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA7O2( ) ;
         WS7O2( ) ;
         WE7O2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?20256201794826", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/workwithplustoolboxmasterpage.js", "?20256201794830", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/slimscroll/jquery.slimscroll.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/SidebarMenu/BootstrapSidebarMenuRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgavHeaderimage_Internalname = "vHEADERIMAGE_MPAGE";
         lblShowmenu_Internalname = "SHOWMENU_MPAGE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1_MPAGE";
         Ddc_changelanguage_Internalname = "DDC_CHANGELANGUAGE_MPAGE";
         Ddc_notificationswc_Internalname = "DDC_NOTIFICATIONSWC_MPAGE";
         Ddc_adminag_Internalname = "DDC_ADMINAG_MPAGE";
         divTableuserrole_Internalname = "TABLEUSERROLE_MPAGE";
         divTableheader_Internalname = "TABLEHEADER_MPAGE";
         divTablecontent_Internalname = "TABLECONTENT_MPAGE";
         Ucmenu_Internalname = "UCMENU_MPAGE";
         divTablemain_Internalname = "TABLEMAIN_MPAGE";
         edtavPickerdummyvariable_Internalname = "vPICKERDUMMYVARIABLE_MPAGE";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC_MPAGE";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS_MPAGE";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavPickerdummyvariable_Jsonclick = "";
         Ddc_adminag_Caption = "";
         imgavHeaderimage_gximage = "";
         divLayoutmaintable_Class = "Table";
         Ucmenu_Hidescrollincompactmenu = Convert.ToBoolean( 0);
         Ucmenu_Scrollalwaysvisible = Convert.ToBoolean( -1);
         Ucmenu_Scrollwidth = 5;
         Ucmenu_Sidebarmainclass = "page-sidebar sidebar-fixed MaterialStyle";
         Ddc_adminag_Componentwidth = 260;
         Ddc_adminag_Cls = "ActionGroupHeader ActionGroupHeaderSquare";
         Ddc_adminag_Icon = "";
         Ddc_notificationswc_Cls = "DropDownNotification";
         Ddc_notificationswc_Caption = "999";
         Ddc_notificationswc_Icon = "far fa-bell";
         Ddc_notificationswc_Icontype = "FontIcon";
         Ddc_changelanguage_Componentwidth = 160;
         Ddc_changelanguage_Caption = context.GetMessage( "Change Language", "");
         Contentholder.setDataArea(getDataAreaObject());
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
         setEventMetadata("REFRESH_MPAGE","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("DDC_CHANGELANGUAGE_MPAGE.ONLOADCOMPONENT_MPAGE","""{"handler":"E127O2","iparms":[]""");
         setEventMetadata("DDC_CHANGELANGUAGE_MPAGE.ONLOADCOMPONENT_MPAGE",""","oparms":[{"ctrl":"WWPAUX_WC_MPAGE"}]}""");
         setEventMetadata("DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE","""{"handler":"E137O2","iparms":[]""");
         setEventMetadata("DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE",""","oparms":[{"ctrl":"WWPAUX_WC_MPAGE"}]}""");
         setEventMetadata("DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE","""{"handler":"E147O2","iparms":[]""");
         setEventMetadata("DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE",""","oparms":[{"ctrl":"WWPAUX_WC_MPAGE"}]}""");
         setEventMetadata("DOSHOWMENU_MPAGE","""{"handler":"E117O1","iparms":[]}""");
         setEventMetadata("ONMESSAGE_GX1_MPAGE","""{"handler":"E167O2","iparms":[{"av":"AV11NotificationInfo","fld":"vNOTIFICATIONINFO_MPAGE"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID_MPAGE"},{"av":"AV44Udparg1","fld":"vUDPARG1_MPAGE"},{"av":"A187WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD_MPAGE"},{"av":"Ddc_notificationswc_Icon","ctrl":"DDC_NOTIFICATIONSWC_MPAGE","prop":"Icon"}]}""");
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
         Contentholder = new GXDataAreaControl();
         AV11NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         GXKey = "";
         AV22DVelop_Menu = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item>( context, "Item", "Comforta_version2");
         AV10DVelop_Menu_UserData = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_UserData(context);
         A112WWPUserExtendedId = "";
         AV44Udparg1 = "";
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         AV33HeaderImage = "";
         AV41Headerimage_GXI = "";
         sImgUrl = "";
         lblShowmenu_Jsonclick = "";
         ucDdc_changelanguage = new GXUserControl();
         ucDdc_notificationswc = new GXUserControl();
         ucDdc_adminag = new GXUserControl();
         ucUcmenu = new GXUserControl();
         TempTags = "";
         AV31PickerDummyVariable = DateTime.MinValue;
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GX_FocusControl = "";
         AV34SDT_OrganisationSetting = new SdtSDT_OrganisationSetting(context);
         GXt_SdtSDT_OrganisationSetting1 = new SdtSDT_OrganisationSetting(context);
         GXt_objcol_SdtDVelop_Menu_Item2 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item>( context, "Item", "Comforta_version2");
         AV35ImageLogo = "";
         imgImagelogo_gximage = "";
         imgImagelogo_Internalname = "";
         AV40Imagelogo_GXI = "";
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV23UserName = "";
         AV5GAMRoleCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV7GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV6GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV24RolesDescriptions = "";
         AV25WebSession = context.GetSession();
         AV28Httprequest = new GxHttpRequest( context);
         AV15WWP_DesignSystemSettings = new WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings(context);
         GXt_SdtWWP_DesignSystemSettings3 = new WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings(context);
         AV13WWP_WebNotification = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
         AV14WWP_UserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         GXEncryptionTmp = "";
         H007O2_AV12NotificationsCount = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.workwithplustoolboxmasterpage__default(),
            new Object[][] {
                new Object[] {
               H007O2_AV12NotificationsCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV12NotificationsCount ;
      private short cV12NotificationsCount ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int Ddc_changelanguage_Componentwidth ;
      private int Ddc_adminag_Componentwidth ;
      private int Ucmenu_Scrollwidth ;
      private int AV42GXV1 ;
      private int idxLst ;
      private string Ddc_notificationswc_Icon ;
      private string GXKey ;
      private string A112WWPUserExtendedId ;
      private string AV44Udparg1 ;
      private string Ddc_changelanguage_Caption ;
      private string Ddc_notificationswc_Icontype ;
      private string Ddc_notificationswc_Caption ;
      private string Ddc_notificationswc_Cls ;
      private string Ddc_adminag_Icon ;
      private string Ddc_adminag_Cls ;
      private string Ucmenu_Sidebarmainclass ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string ClassString ;
      private string imgavHeaderimage_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgavHeaderimage_Internalname ;
      private string lblShowmenu_Internalname ;
      private string lblShowmenu_Jsonclick ;
      private string divTableuserrole_Internalname ;
      private string Ddc_changelanguage_Internalname ;
      private string Ddc_notificationswc_Internalname ;
      private string Ddc_adminag_Caption ;
      private string Ddc_adminag_Internalname ;
      private string divTablecontent_Internalname ;
      private string Ucmenu_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string TempTags ;
      private string edtavPickerdummyvariable_Internalname ;
      private string edtavPickerdummyvariable_Jsonclick ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GX_FocusControl ;
      private string imgImagelogo_gximage ;
      private string imgImagelogo_Internalname ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private DateTime AV31PickerDummyVariable ;
      private bool A187WWPNotificationIsRead ;
      private bool Ucmenu_Scrollalwaysvisible ;
      private bool Ucmenu_Hidescrollincompactmenu ;
      private bool wbLoad ;
      private bool AV33HeaderImage_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wwpaux_wc ;
      private string AV41Headerimage_GXI ;
      private string AV40Imagelogo_GXI ;
      private string AV23UserName ;
      private string AV24RolesDescriptions ;
      private string AV33HeaderImage ;
      private string AV35ImageLogo ;
      private IGxSession AV25WebSession ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucDdc_changelanguage ;
      private GXUserControl ucDdc_notificationswc ;
      private GXUserControl ucDdc_adminag ;
      private GXUserControl ucUcmenu ;
      private GxHttpRequest AV28Httprequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contentholder ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV11NotificationInfo ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> AV22DVelop_Menu ;
      private WorkWithPlus.workwithplus_web.SdtDVelop_Menu_UserData AV10DVelop_Menu_UserData ;
      private SdtSDT_OrganisationSetting AV34SDT_OrganisationSetting ;
      private SdtSDT_OrganisationSetting GXt_SdtSDT_OrganisationSetting1 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV5GAMRoleCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV7GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV6GAMRole ;
      private WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings AV15WWP_DesignSystemSettings ;
      private WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings GXt_SdtWWP_DesignSystemSettings3 ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification AV13WWP_WebNotification ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV14WWP_UserExtended ;
      private IDataStoreProvider pr_default ;
      private short[] H007O2_AV12NotificationsCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class workwithplustoolboxmasterpage__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH007O2;
          prmH007O2 = new Object[] {
          new ParDef("AV44Udparg1",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007O2", "SELECT COUNT(*) FROM WWP_Notification WHERE (WWPUserExtendedId = ( :AV44Udparg1)) AND (Not WWPNotificationIsRead) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O2,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
