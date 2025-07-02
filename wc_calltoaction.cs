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
   public class wc_calltoaction : GXWebComponent
   {
      public wc_calltoaction( )
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

      public wc_calltoaction( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId ,
                           Guid aP1_LocationId ,
                           Guid aP2_ProductServiceId )
      {
         this.AV65OrganisationId = aP0_OrganisationId;
         this.AV66LocationId = aP1_LocationId;
         this.AV67ProductServiceId = aP2_ProductServiceId;
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
         cmbavCalltoactiontype = new GXCombobox();
         cmbavSdt_calltoaction__calltoactiontype = new GXCombobox();
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
               gxfirstwebparm = GetFirstPar( "OrganisationId");
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
                  AV65OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "AV65OrganisationId", AV65OrganisationId.ToString());
                  AV66LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri(sPrefix, false, "AV66LocationId", AV66LocationId.ToString());
                  AV67ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
                  AssignAttri(sPrefix, false, "AV67ProductServiceId", AV67ProductServiceId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)AV65OrganisationId,(Guid)AV66LocationId,(Guid)AV67ProductServiceId});
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
                  gxfirstwebparm = GetFirstPar( "OrganisationId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "OrganisationId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdt_calltoactions") == 0 )
               {
                  gxnrGridsdt_calltoactions_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdt_calltoactions") == 0 )
               {
                  gxgrGridsdt_calltoactions_refresh_invoke( ) ;
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

      protected void gxnrGridsdt_calltoactions_newrow_invoke( )
      {
         nRC_GXsfl_98 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_98"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_98_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_98_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_98_idx = GetPar( "sGXsfl_98_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsdt_calltoactions_newrow( ) ;
         /* End function gxnrGridsdt_calltoactions_newrow_invoke */
      }

      protected void gxgrGridsdt_calltoactions_refresh_invoke( )
      {
         subGridsdt_calltoactions_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsdt_calltoactions_Rows"), "."), 18, MidpointRounding.ToEven));
         A58ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
         AV67ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
         A339CallToActionId = StringUtil.StrToGuid( GetPar( "CallToActionId"));
         A368CallToActionName = GetPar( "CallToActionName");
         A342CallToActionPhone = GetPar( "CallToActionPhone");
         A499CallToActionPhoneCode = GetPar( "CallToActionPhoneCode");
         A500CallToActionPhoneNumber = GetPar( "CallToActionPhoneNumber");
         A341CallToActionEmail = GetPar( "CallToActionEmail");
         A340CallToActionType = GetPar( "CallToActionType");
         A367CallToActionUrl = GetPar( "CallToActionUrl");
         A366LocationDynamicFormId = StringUtil.StrToGuid( GetPar( "LocationDynamicFormId"));
         n366LocationDynamicFormId = false;
         A208WWPFormReferenceName = GetPar( "WWPFormReferenceName");
         A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV68SDT_CallToAction);
         AV39CallToActionVariable = GetPar( "CallToActionVariable");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A339CallToActionId, A368CallToActionName, A342CallToActionPhone, A499CallToActionPhoneCode, A500CallToActionPhoneNumber, A341CallToActionEmail, A340CallToActionType, A367CallToActionUrl, A366LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, AV39CallToActionVariable, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridsdt_calltoactions_refresh_invoke */
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
            PA6G2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavSdt_calltoaction__calltoactionid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionid_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavSdt_calltoaction__organisationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__organisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__organisationid_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavSdt_calltoaction__locationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__locationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__locationid_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavSdt_calltoaction__productserviceid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__productserviceid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__productserviceid_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
               AssignProp(sPrefix, false, cmbavSdt_calltoaction__calltoactiontype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdt_calltoaction__calltoactiontype.Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavSdt_calltoaction__calltoactionname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionname_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionphone_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavSdt_calltoaction__calltoactionphonecode_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionphonecode_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavSdt_calltoaction__calltoactionphonenumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionphonenumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionphonenumber_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionurl_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionemail_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__locationdynamicformid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__locationdynamicformid_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavShortcalltoactionwithtags_Enabled = 0;
               AssignProp(sPrefix, false, edtavShortcalltoactionwithtags_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavShortcalltoactionwithtags_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavShortcalltoaction_Enabled = 0;
               AssignProp(sPrefix, false, edtavShortcalltoaction_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavShortcalltoaction_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__wwpformreferencename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__wwpformreferencename_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               edtavCalltoactionvariable_Enabled = 0;
               AssignProp(sPrefix, false, edtavCalltoactionvariable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCalltoactionvariable_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               WS6G2( ) ;
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
            context.SendWebValue( context.GetMessage( " Trn_Call To Action", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Popover/WWPPopoverRender.js", "", false, true);
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
            GXEncryptionTmp = "wc_calltoaction.aspx"+UrlEncode(AV65OrganisationId.ToString()) + "," + UrlEncode(AV66LocationId.ToString()) + "," + UrlEncode(AV67ProductServiceId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wc_calltoaction.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_CALLTOACTION", AV68SDT_CallToAction);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_CALLTOACTION", AV68SDT_CallToAction);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_CALLTOACTION", GetSecureSignedToken( sPrefix, AV68SDT_CallToAction, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdt_calltoaction", AV68SDT_CallToAction);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdt_calltoaction", AV68SDT_CallToAction);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_Sdt_calltoaction", GetSecureSignedToken( sPrefix, AV68SDT_CallToAction, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_98", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_98), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPHONECODE_DATA", AV81PhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPHONECODE_DATA", AV81PhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLOCATIONDYNAMICFORMID_DATA", AV59LocationDynamicFormId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLOCATIONDYNAMICFORMID_DATA", AV59LocationDynamicFormId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSDT_CALLTOACTIONSCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70GridSDT_CallToActionsCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSDT_CALLTOACTIONSPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71GridSDT_CallToActionsPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSDT_CALLTOACTIONSAPPLIEDFILTERS", AV72GridSDT_CallToActionsAppliedFilters);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV65OrganisationId", wcpOAV65OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV66LocationId", wcpOAV66LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV67ProductServiceId", wcpOAV67ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEID", A58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vPRODUCTSERVICEID", AV67ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONID", A339CallToActionId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONNAME", A368CallToActionName);
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONPHONE", StringUtil.RTrim( A342CallToActionPhone));
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONPHONECODE", A499CallToActionPhoneCode);
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONPHONENUMBER", A500CallToActionPhoneNumber);
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONEMAIL", A341CallToActionEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONTYPE", A340CallToActionType);
         GxWebStd.gx_hidden_field( context, sPrefix+"CALLTOACTIONURL", A367CallToActionUrl);
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONDYNAMICFORMID", A366LocationDynamicFormId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMREFERENCENAME", A208WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, sPrefix+"ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONID", A29LocationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_CALLTOACTION", AV68SDT_CallToAction);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_CALLTOACTION", AV68SDT_CallToAction);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_CALLTOACTION", GetSecureSignedToken( sPrefix, AV68SDT_CallToAction, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV77CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, sPrefix+"vORGANISATIONID", AV65OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vLOCATIONID", AV66LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vCALLTOACTIONPHONE", StringUtil.RTrim( AV57CallToActionPhone));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PHONECODE_Cls", StringUtil.RTrim( Combo_phonecode_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_phonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PHONECODE_Selectedtext_set", StringUtil.RTrim( Combo_phonecode_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_phonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PHONECODE_Htmltemplate", StringUtil.RTrim( Combo_phonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Cls", StringUtil.RTrim( Combo_locationdynamicformid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_set", StringUtil.RTrim( Combo_locationdynamicformid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedtext_set", StringUtil.RTrim( Combo_locationdynamicformid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Emptyitem", StringUtil.BoolToStr( Combo_locationdynamicformid_Emptyitem));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Class", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridsdt_calltoactionspaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridsdt_calltoactionspaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridsdt_calltoactionspaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridsdt_calltoactionspaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdt_calltoactionspaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridsdt_calltoactionspaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Previous", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Next", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Caption", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_SHORTCALLTOACTION_Gridinternalname", StringUtil.RTrim( Popover_shortcalltoaction_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_SHORTCALLTOACTION_Iteminternalname", StringUtil.RTrim( Popover_shortcalltoaction_Iteminternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_SHORTCALLTOACTION_Isgriditem", StringUtil.BoolToStr( Popover_shortcalltoaction_Isgriditem));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_SHORTCALLTOACTION_Trigger", StringUtil.RTrim( Popover_shortcalltoaction_Trigger));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_SHORTCALLTOACTION_Triggerelement", StringUtil.RTrim( Popover_shortcalltoaction_Triggerelement));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_SHORTCALLTOACTION_Popoverwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Popover_shortcalltoaction_Popoverwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_SHORTCALLTOACTION_Position", StringUtil.RTrim( Popover_shortcalltoaction_Position));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_SHORTCALLTOACTION_Keepopened", StringUtil.BoolToStr( Popover_shortcalltoaction_Keepopened));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridsdt_calltoactions_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_EMPOWERER_Popoversingrid", StringUtil.RTrim( Gridsdt_calltoactions_empowerer_Popoversingrid));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Ddointernalname", StringUtil.RTrim( Combo_locationdynamicformid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_get", StringUtil.RTrim( Combo_locationdynamicformid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_phonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsdt_calltoactionspaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Ddointernalname", StringUtil.RTrim( Combo_locationdynamicformid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_get", StringUtil.RTrim( Combo_locationdynamicformid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm6G2( )
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
            if ( ! ( WebComp_Wwpaux_wc == null ) )
            {
               WebComp_Wwpaux_wc.componentjscripts();
            }
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
         return "WC_CallToAction" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Trn_Call To Action", "") ;
      }

      protected void WB6G0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wc_calltoaction.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Popover/WWPPopoverRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseractioninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(98), 2, 0)+","+"null"+");", context.GetMessage( "Insert", ""), bttBtnuseractioninsert_Jsonclick, 7, context.GetMessage( "Insert", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e116g1_client"+"'", TempTags, "", 2, "HLP_WC_CallToAction.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableinsert_Internalname, divTableinsert_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Call to Action", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WC_CallToAction.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavCalltoactiontype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCalltoactiontype_Internalname, context.GetMessage( "Type", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCalltoactiontype, cmbavCalltoactiontype_Internalname, StringUtil.RTrim( AV52CallToActionType), 1, cmbavCalltoactiontype_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavCalltoactiontype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_WC_CallToAction.htm");
            cmbavCalltoactiontype.CurrentValue = StringUtil.RTrim( AV52CallToActionType);
            AssignProp(sPrefix, false, cmbavCalltoactiontype_Internalname, "Values", (string)(cmbavCalltoactiontype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionname_Internalname, context.GetMessage( "Label", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionname_Internalname, AV53CallToActionName, StringUtil.RTrim( context.localUtil.Format( AV53CallToActionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", edtavCalltoactionname_Invitemessage, edtavCalltoactionname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_CallToAction.htm");
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
            GxWebStd.gx_div_start( context, divTableurl_Internalname, divTableurl_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCalltoactionurl_cell_Internalname, 1, 0, "px", 0, "px", divCalltoactionurl_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionurl_Internalname, context.GetMessage( "Url", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionurl_Internalname, AV58CallToActionUrl, StringUtil.RTrim( context.localUtil.Format( AV58CallToActionUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionurl_Enabled, 0, "text", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WC_CallToAction.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablephone_Internalname, divTablephone_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPhonelabel_Internalname, context.GetMessage( "Phone", ""), "", "", lblPhonelabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WC_CallToAction.htm");
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
            ucCombo_phonecode.SetProperty("Caption", Combo_phonecode_Caption);
            ucCombo_phonecode.SetProperty("Cls", Combo_phonecode_Cls);
            ucCombo_phonecode.SetProperty("EmptyItem", Combo_phonecode_Emptyitem);
            ucCombo_phonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV32DDO_TitleSettingsIcons);
            ucCombo_phonecode.SetProperty("DropDownOptionsData", AV81PhoneCode_Data);
            ucCombo_phonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_phonecode_Internalname, sPrefix+"COMBO_PHONECODEContainer");
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
            GxWebStd.gx_div_start( context, divPhonenumber_cell_Internalname, 1, 0, "px", 0, "px", divPhonenumber_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPhonenumber_Internalname, context.GetMessage( "Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPhonenumber_Internalname, AV78PhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV78PhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPhonenumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPhonenumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_CallToAction.htm");
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
            GxWebStd.gx_div_start( context, divTableform_Internalname, divTableform_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombo_locationdynamicformid_cell_Internalname, 1, 0, "px", 0, "px", divCombo_locationdynamicformid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlocationdynamicformid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_locationdynamicformid_Internalname, context.GetMessage( "Form", ""), "", "", lblTextblockcombo_locationdynamicformid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WC_CallToAction.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_locationdynamicformid.SetProperty("Caption", Combo_locationdynamicformid_Caption);
            ucCombo_locationdynamicformid.SetProperty("Cls", Combo_locationdynamicformid_Cls);
            ucCombo_locationdynamicformid.SetProperty("EmptyItem", Combo_locationdynamicformid_Emptyitem);
            ucCombo_locationdynamicformid.SetProperty("DropDownOptionsTitleSettingsIcons", AV32DDO_TitleSettingsIcons);
            ucCombo_locationdynamicformid.SetProperty("DropDownOptionsData", AV59LocationDynamicFormId_Data);
            ucCombo_locationdynamicformid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_locationdynamicformid_Internalname, sPrefix+"COMBO_LOCATIONDYNAMICFORMIDContainer");
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
            GxWebStd.gx_div_start( context, divTableemail_Internalname, divTableemail_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCalltoactionemail_cell_Internalname, 1, 0, "px", 0, "px", divCalltoactionemail_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionemail_Internalname, AV55CallToActionEmail, StringUtil.RTrim( context.localUtil.Format( AV55CallToActionEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WC_CallToAction.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseractionadd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(98), 2, 0)+","+"null"+");", context.GetMessage( "Save", ""), bttBtnuseractionadd_Jsonclick, 5, context.GetMessage( "Save", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUSERACTIONADD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WC_CallToAction.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseractioncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(98), 2, 0)+","+"null"+");", context.GetMessage( "Cancel", ""), bttBtnuseractioncancel_Jsonclick, 7, context.GetMessage( "Cancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e126g1_client"+"'", TempTags, "", 2, "HLP_WC_CallToAction.htm");
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders GridHover HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsdt_calltoactionstablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Gridsdt_calltoactionsContainer.SetWrapped(nGXWrapped);
            StartGridControl98( ) ;
         }
         if ( wbEnd == 98 )
         {
            wbEnd = 0;
            nRC_GXsfl_98 = (int)(nGXsfl_98_idx-1);
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV86GXV1 = nGXsfl_98_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_calltoactionsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_calltoactions", Gridsdt_calltoactionsContainer, subGridsdt_calltoactions_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_calltoactionsContainerData", Gridsdt_calltoactionsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_calltoactionsContainerData"+"V", Gridsdt_calltoactionsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_calltoactionsContainerData"+"V"+"\" value='"+Gridsdt_calltoactionsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridsdt_calltoactionspaginationbar.SetProperty("Class", Gridsdt_calltoactionspaginationbar_Class);
            ucGridsdt_calltoactionspaginationbar.SetProperty("ShowFirst", Gridsdt_calltoactionspaginationbar_Showfirst);
            ucGridsdt_calltoactionspaginationbar.SetProperty("ShowPrevious", Gridsdt_calltoactionspaginationbar_Showprevious);
            ucGridsdt_calltoactionspaginationbar.SetProperty("ShowNext", Gridsdt_calltoactionspaginationbar_Shownext);
            ucGridsdt_calltoactionspaginationbar.SetProperty("ShowLast", Gridsdt_calltoactionspaginationbar_Showlast);
            ucGridsdt_calltoactionspaginationbar.SetProperty("PagesToShow", Gridsdt_calltoactionspaginationbar_Pagestoshow);
            ucGridsdt_calltoactionspaginationbar.SetProperty("PagingButtonsPosition", Gridsdt_calltoactionspaginationbar_Pagingbuttonsposition);
            ucGridsdt_calltoactionspaginationbar.SetProperty("PagingCaptionPosition", Gridsdt_calltoactionspaginationbar_Pagingcaptionposition);
            ucGridsdt_calltoactionspaginationbar.SetProperty("EmptyGridClass", Gridsdt_calltoactionspaginationbar_Emptygridclass);
            ucGridsdt_calltoactionspaginationbar.SetProperty("RowsPerPageSelector", Gridsdt_calltoactionspaginationbar_Rowsperpageselector);
            ucGridsdt_calltoactionspaginationbar.SetProperty("RowsPerPageOptions", Gridsdt_calltoactionspaginationbar_Rowsperpageoptions);
            ucGridsdt_calltoactionspaginationbar.SetProperty("Previous", Gridsdt_calltoactionspaginationbar_Previous);
            ucGridsdt_calltoactionspaginationbar.SetProperty("Next", Gridsdt_calltoactionspaginationbar_Next);
            ucGridsdt_calltoactionspaginationbar.SetProperty("Caption", Gridsdt_calltoactionspaginationbar_Caption);
            ucGridsdt_calltoactionspaginationbar.SetProperty("EmptyGridCaption", Gridsdt_calltoactionspaginationbar_Emptygridcaption);
            ucGridsdt_calltoactionspaginationbar.SetProperty("RowsPerPageCaption", Gridsdt_calltoactionspaginationbar_Rowsperpagecaption);
            ucGridsdt_calltoactionspaginationbar.SetProperty("CurrentPage", AV70GridSDT_CallToActionsCurrentPage);
            ucGridsdt_calltoactionspaginationbar.SetProperty("PageCount", AV71GridSDT_CallToActionsPageCount);
            ucGridsdt_calltoactionspaginationbar.SetProperty("AppliedFilters", AV72GridSDT_CallToActionsAppliedFilters);
            ucGridsdt_calltoactionspaginationbar.Render(context, "dvelop.dvpaginationbar", Gridsdt_calltoactionspaginationbar_Internalname, sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBARContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPhonecode_Internalname, AV79PhoneCode, StringUtil.RTrim( context.localUtil.Format( AV79PhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPhonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavPhonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_CallToAction.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationdynamicformid_Internalname, AV56LocationDynamicFormId.ToString(), AV56LocationDynamicFormId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationdynamicformid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLocationdynamicformid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WC_CallToAction.htm");
            /* User Defined Control */
            ucPopover_shortcalltoaction.SetProperty("IsGridItem", Popover_shortcalltoaction_Isgriditem);
            ucPopover_shortcalltoaction.SetProperty("Trigger", Popover_shortcalltoaction_Trigger);
            ucPopover_shortcalltoaction.SetProperty("TriggerElement", Popover_shortcalltoaction_Triggerelement);
            ucPopover_shortcalltoaction.SetProperty("PopoverWidth", Popover_shortcalltoaction_Popoverwidth);
            ucPopover_shortcalltoaction.SetProperty("Position", Popover_shortcalltoaction_Position);
            ucPopover_shortcalltoaction.SetProperty("KeepOpened", Popover_shortcalltoaction_Keepopened);
            ucPopover_shortcalltoaction.Render(context, "dvelop.wwppopover", Popover_shortcalltoaction_Internalname, sPrefix+"POPOVER_SHORTCALLTOACTIONContainer");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionid_Internalname, AV51CallToActionId.ToString(), AV51CallToActionId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCalltoactionid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WC_CallToAction.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwpformreferencename_Internalname, AV54WWPFormReferenceName, StringUtil.RTrim( context.localUtil.Format( AV54WWPFormReferenceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwpformreferencename_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwpformreferencename_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_CallToAction.htm");
            wb_table1_127_6G2( true) ;
         }
         else
         {
            wb_table1_127_6G2( false) ;
         }
         return  ;
      }

      protected void wb_table1_127_6G2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGridsdt_calltoactions_empowerer.SetProperty("PopoversInGrid", Gridsdt_calltoactions_empowerer_Popoversingrid);
            ucGridsdt_calltoactions_empowerer.Render(context, "wwp.gridempowerer", Gridsdt_calltoactions_empowerer_Internalname, sPrefix+"GRIDSDT_CALLTOACTIONS_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0134"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0134"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_98_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0134"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
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
         if ( wbEnd == 98 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV86GXV1 = nGXsfl_98_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_calltoactionsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_calltoactions", Gridsdt_calltoactionsContainer, subGridsdt_calltoactions_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_calltoactionsContainerData", Gridsdt_calltoactionsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_calltoactionsContainerData"+"V", Gridsdt_calltoactionsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_calltoactionsContainerData"+"V"+"\" value='"+Gridsdt_calltoactionsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START6G2( )
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
            Form.Meta.addItem("description", context.GetMessage( " Trn_Call To Action", ""), 0) ;
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
               STRUP6G0( ) ;
            }
         }
      }

      protected void WS6G2( )
      {
         START6G2( ) ;
         EVT6G2( ) ;
      }

      protected void EVT6G2( )
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
                                 STRUP6G0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_LOCATIONDYNAMICFORMID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_locationdynamicformid.Onoptionclicked */
                                    E136G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_CALLTOACTIONSPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdt_calltoactionspaginationbar.Changepage */
                                    E146G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_CALLTOACTIONSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdt_calltoactionspaginationbar.Changerowsperpage */
                                    E156G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_useractiondelete.Close */
                                    E166G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTIONADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUserActionAdd' */
                                    E176G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "GRIDSDT_CALLTOACTIONS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "VSHORTCALLTOACTION.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "VSHORTCALLTOACTION.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              nGXsfl_98_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
                              SubsflControlProps_982( ) ;
                              AV86GXV1 = (int)(nGXsfl_98_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
                              if ( ( AV68SDT_CallToAction.Count >= AV86GXV1 ) && ( AV86GXV1 > 0 ) )
                              {
                                 AV68SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1));
                                 AV85ShortCallToActionWithTags = cgiGet( edtavShortcalltoactionwithtags_Internalname);
                                 AssignAttri(sPrefix, false, edtavShortcalltoactionwithtags_Internalname, AV85ShortCallToActionWithTags);
                                 AV84ShortCallToAction = cgiGet( edtavShortcalltoaction_Internalname);
                                 AssignAttri(sPrefix, false, edtavShortcalltoaction_Internalname, AV84ShortCallToAction);
                                 AV39CallToActionVariable = cgiGet( edtavCalltoactionvariable_Internalname);
                                 AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCALLTOACTIONVARIABLE"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sPrefix+sGXsfl_98_idx, StringUtil.RTrim( context.localUtil.Format( AV39CallToActionVariable, "")), context));
                                 cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                                 cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                                 AV76GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV76GridActionGroup1), 4, 0));
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
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E186G2 ();
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
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E196G2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_CALLTOACTIONS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Gridsdt_calltoactions.Load */
                                          E206G2 ();
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
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E216G2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VSHORTCALLTOACTION.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E226G2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
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
                                       STRUP6G0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 134 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0134");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0134", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE6G2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6G2( ) ;
            }
         }
      }

      protected void PA6G2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wc_calltoaction.aspx")), "wc_calltoaction.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wc_calltoaction.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "OrganisationId");
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
               GX_FocusControl = cmbavCalltoactiontype_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridsdt_calltoactions_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_982( ) ;
         while ( nGXsfl_98_idx <= nRC_GXsfl_98 )
         {
            sendrow_982( ) ;
            nGXsfl_98_idx = ((subGridsdt_calltoactions_Islastpage==1)&&(nGXsfl_98_idx+1>subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : nGXsfl_98_idx+1);
            sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
            SubsflControlProps_982( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsdt_calltoactionsContainer)) ;
         /* End function gxnrGridsdt_calltoactions_newrow */
      }

      protected void gxgrGridsdt_calltoactions_refresh( int subGridsdt_calltoactions_Rows ,
                                                        Guid A58ProductServiceId ,
                                                        Guid AV67ProductServiceId ,
                                                        Guid A339CallToActionId ,
                                                        string A368CallToActionName ,
                                                        string A342CallToActionPhone ,
                                                        string A499CallToActionPhoneCode ,
                                                        string A500CallToActionPhoneNumber ,
                                                        string A341CallToActionEmail ,
                                                        string A340CallToActionType ,
                                                        string A367CallToActionUrl ,
                                                        Guid A366LocationDynamicFormId ,
                                                        string A208WWPFormReferenceName ,
                                                        Guid A11OrganisationId ,
                                                        Guid A29LocationId ,
                                                        GXBaseCollection<SdtSDT_CallToAction_SDT_CallToActionItem> AV68SDT_CallToAction ,
                                                        string AV39CallToActionVariable ,
                                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDSDT_CALLTOACTIONS_nCurrentRecord = 0;
         RF6G2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridsdt_calltoactions_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCALLTOACTIONVARIABLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV39CallToActionVariable, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCALLTOACTIONVARIABLE", AV39CallToActionVariable);
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
         if ( cmbavCalltoactiontype.ItemCount > 0 )
         {
            AV52CallToActionType = cmbavCalltoactiontype.getValidValue(AV52CallToActionType);
            AssignAttri(sPrefix, false, "AV52CallToActionType", AV52CallToActionType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCalltoactiontype.CurrentValue = StringUtil.RTrim( AV52CallToActionType);
            AssignProp(sPrefix, false, cmbavCalltoactiontype_Internalname, "Values", cmbavCalltoactiontype.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         edtavSdt_calltoaction__organisationid_Enabled = 0;
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphonecode_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphonenumber_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavShortcalltoactionwithtags_Enabled = 0;
         edtavShortcalltoaction_Enabled = 0;
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavCalltoactionvariable_Enabled = 0;
      }

      protected void RF6G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridsdt_calltoactionsContainer.ClearRows();
         }
         wbStart = 98;
         /* Execute user event: Refresh */
         E196G2 ();
         nGXsfl_98_idx = 1;
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_982( ) ;
         bGXsfl_98_Refreshing = true;
         Gridsdt_calltoactionsContainer.AddObjectProperty("GridName", "Gridsdt_calltoactions");
         Gridsdt_calltoactionsContainer.AddObjectProperty("CmpContext", sPrefix);
         Gridsdt_calltoactionsContainer.AddObjectProperty("InMasterPage", "false");
         Gridsdt_calltoactionsContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         Gridsdt_calltoactionsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsdt_calltoactionsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsdt_calltoactionsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Backcolorstyle), 1, 0, ".", "")));
         Gridsdt_calltoactionsContainer.PageSize = subGridsdt_calltoactions_fnc_Recordsperpage( );
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
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_982( ) ;
            /* Execute user event: Gridsdt_calltoactions.Load */
            E206G2 ();
            if ( ( subGridsdt_calltoactions_Islastpage == 0 ) && ( GRIDSDT_CALLTOACTIONS_nCurrentRecord > 0 ) && ( GRIDSDT_CALLTOACTIONS_nGridOutOfScope == 0 ) && ( nGXsfl_98_idx == 1 ) )
            {
               GRIDSDT_CALLTOACTIONS_nCurrentRecord = 0;
               GRIDSDT_CALLTOACTIONS_nGridOutOfScope = 1;
               subgridsdt_calltoactions_firstpage( ) ;
               /* Execute user event: Gridsdt_calltoactions.Load */
               E206G2 ();
            }
            wbEnd = 98;
            WB6G0( ) ;
         }
         bGXsfl_98_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6G2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_CALLTOACTION", AV68SDT_CallToAction);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_CALLTOACTION", AV68SDT_CallToAction);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_CALLTOACTION", GetSecureSignedToken( sPrefix, AV68SDT_CallToAction, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCALLTOACTIONVARIABLE"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sPrefix+sGXsfl_98_idx, StringUtil.RTrim( context.localUtil.Format( AV39CallToActionVariable, "")), context));
      }

      protected int subGridsdt_calltoactions_fnc_Pagecount( )
      {
         GRIDSDT_CALLTOACTIONS_nRecordCount = subGridsdt_calltoactions_fnc_Recordcount( );
         if ( ((int)((GRIDSDT_CALLTOACTIONS_nRecordCount) % (subGridsdt_calltoactions_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_CALLTOACTIONS_nRecordCount/ (decimal)(subGridsdt_calltoactions_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_CALLTOACTIONS_nRecordCount/ (decimal)(subGridsdt_calltoactions_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridsdt_calltoactions_fnc_Recordcount( )
      {
         return AV68SDT_CallToAction.Count ;
      }

      protected int subGridsdt_calltoactions_fnc_Recordsperpage( )
      {
         if ( subGridsdt_calltoactions_Rows > 0 )
         {
            return subGridsdt_calltoactions_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsdt_calltoactions_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage/ (decimal)(subGridsdt_calltoactions_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridsdt_calltoactions_firstpage( )
      {
         GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A339CallToActionId, A368CallToActionName, A342CallToActionPhone, A499CallToActionPhoneCode, A500CallToActionPhoneNumber, A341CallToActionEmail, A340CallToActionType, A367CallToActionUrl, A366LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, AV39CallToActionVariable, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_calltoactions_nextpage( )
      {
         GRIDSDT_CALLTOACTIONS_nRecordCount = subGridsdt_calltoactions_fnc_Recordcount( );
         if ( ( GRIDSDT_CALLTOACTIONS_nRecordCount >= subGridsdt_calltoactions_fnc_Recordsperpage( ) ) && ( GRIDSDT_CALLTOACTIONS_nEOF == 0 ) )
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage+subGridsdt_calltoactions_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridsdt_calltoactionsContainer.AddObjectProperty("GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A339CallToActionId, A368CallToActionName, A342CallToActionPhone, A499CallToActionPhoneCode, A500CallToActionPhoneNumber, A341CallToActionEmail, A340CallToActionType, A367CallToActionUrl, A366LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, AV39CallToActionVariable, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSDT_CALLTOACTIONS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsdt_calltoactions_previouspage( )
      {
         if ( GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage >= subGridsdt_calltoactions_fnc_Recordsperpage( ) )
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage-subGridsdt_calltoactions_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A339CallToActionId, A368CallToActionName, A342CallToActionPhone, A499CallToActionPhoneCode, A500CallToActionPhoneNumber, A341CallToActionEmail, A340CallToActionType, A367CallToActionUrl, A366LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, AV39CallToActionVariable, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_calltoactions_lastpage( )
      {
         GRIDSDT_CALLTOACTIONS_nRecordCount = subGridsdt_calltoactions_fnc_Recordcount( );
         if ( GRIDSDT_CALLTOACTIONS_nRecordCount > subGridsdt_calltoactions_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDSDT_CALLTOACTIONS_nRecordCount) % (subGridsdt_calltoactions_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nRecordCount-subGridsdt_calltoactions_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nRecordCount-((int)((GRIDSDT_CALLTOACTIONS_nRecordCount) % (subGridsdt_calltoactions_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A339CallToActionId, A368CallToActionName, A342CallToActionPhone, A499CallToActionPhoneCode, A500CallToActionPhoneNumber, A341CallToActionEmail, A340CallToActionType, A367CallToActionUrl, A366LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, AV39CallToActionVariable, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsdt_calltoactions_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(subGridsdt_calltoactions_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A339CallToActionId, A368CallToActionName, A342CallToActionPhone, A499CallToActionPhoneCode, A500CallToActionPhoneNumber, A341CallToActionEmail, A340CallToActionType, A367CallToActionUrl, A366LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, AV39CallToActionVariable, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         edtavSdt_calltoaction__organisationid_Enabled = 0;
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphonecode_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphonenumber_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavShortcalltoactionwithtags_Enabled = 0;
         edtavShortcalltoaction_Enabled = 0;
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavCalltoactionvariable_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E186G2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdt_calltoaction"), AV68SDT_CallToAction);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV32DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vPHONECODE_DATA"), AV81PhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vLOCATIONDYNAMICFORMID_DATA"), AV59LocationDynamicFormId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDT_CALLTOACTION"), AV68SDT_CallToAction);
            /* Read saved values. */
            nRC_GXsfl_98 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_98"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV70GridSDT_CallToActionsCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSDT_CALLTOACTIONSCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV71GridSDT_CallToActionsPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSDT_CALLTOACTIONSPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV72GridSDT_CallToActionsAppliedFilters = cgiGet( sPrefix+"vGRIDSDT_CALLTOACTIONSAPPLIEDFILTERS");
            wcpOAV65OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV65OrganisationId"));
            wcpOAV66LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV66LocationId"));
            wcpOAV67ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV67ProductServiceId"));
            AV57CallToActionPhone = cgiGet( sPrefix+"vCALLTOACTIONPHONE");
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDSDT_CALLTOACTIONS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridsdt_calltoactions_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
            Combo_phonecode_Cls = cgiGet( sPrefix+"COMBO_PHONECODE_Cls");
            Combo_phonecode_Selectedvalue_set = cgiGet( sPrefix+"COMBO_PHONECODE_Selectedvalue_set");
            Combo_phonecode_Selectedtext_set = cgiGet( sPrefix+"COMBO_PHONECODE_Selectedtext_set");
            Combo_phonecode_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_PHONECODE_Emptyitem"));
            Combo_phonecode_Htmltemplate = cgiGet( sPrefix+"COMBO_PHONECODE_Htmltemplate");
            Combo_locationdynamicformid_Cls = cgiGet( sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Cls");
            Combo_locationdynamicformid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_set");
            Combo_locationdynamicformid_Selectedtext_set = cgiGet( sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedtext_set");
            Combo_locationdynamicformid_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Emptyitem"));
            Gridsdt_calltoactionspaginationbar_Class = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Class");
            Gridsdt_calltoactionspaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Showfirst"));
            Gridsdt_calltoactionspaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Showprevious"));
            Gridsdt_calltoactionspaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Shownext"));
            Gridsdt_calltoactionspaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Showlast"));
            Gridsdt_calltoactionspaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridsdt_calltoactionspaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Pagingbuttonsposition");
            Gridsdt_calltoactionspaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Pagingcaptionposition");
            Gridsdt_calltoactionspaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Emptygridclass");
            Gridsdt_calltoactionspaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselector"));
            Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridsdt_calltoactionspaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageoptions");
            Gridsdt_calltoactionspaginationbar_Previous = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Previous");
            Gridsdt_calltoactionspaginationbar_Next = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Next");
            Gridsdt_calltoactionspaginationbar_Caption = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Caption");
            Gridsdt_calltoactionspaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Emptygridcaption");
            Gridsdt_calltoactionspaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpagecaption");
            Popover_shortcalltoaction_Gridinternalname = cgiGet( sPrefix+"POPOVER_SHORTCALLTOACTION_Gridinternalname");
            Popover_shortcalltoaction_Iteminternalname = cgiGet( sPrefix+"POPOVER_SHORTCALLTOACTION_Iteminternalname");
            Popover_shortcalltoaction_Isgriditem = StringUtil.StrToBool( cgiGet( sPrefix+"POPOVER_SHORTCALLTOACTION_Isgriditem"));
            Popover_shortcalltoaction_Trigger = cgiGet( sPrefix+"POPOVER_SHORTCALLTOACTION_Trigger");
            Popover_shortcalltoaction_Triggerelement = cgiGet( sPrefix+"POPOVER_SHORTCALLTOACTION_Triggerelement");
            Popover_shortcalltoaction_Popoverwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"POPOVER_SHORTCALLTOACTION_Popoverwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Popover_shortcalltoaction_Position = cgiGet( sPrefix+"POPOVER_SHORTCALLTOACTION_Position");
            Popover_shortcalltoaction_Keepopened = StringUtil.StrToBool( cgiGet( sPrefix+"POPOVER_SHORTCALLTOACTION_Keepopened"));
            Dvelop_confirmpanel_useractiondelete_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Title");
            Dvelop_confirmpanel_useractiondelete_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmationtext");
            Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_useractiondelete_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Nobuttoncaption");
            Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_useractiondelete_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttonposition");
            Dvelop_confirmpanel_useractiondelete_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmtype");
            Gridsdt_calltoactions_empowerer_Gridinternalname = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONS_EMPOWERER_Gridinternalname");
            Gridsdt_calltoactions_empowerer_Popoversingrid = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONS_EMPOWERER_Popoversingrid");
            Gridsdt_calltoactionspaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Selectedpage");
            Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvelop_confirmpanel_useractiondelete_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result");
            Combo_locationdynamicformid_Ddointernalname = cgiGet( sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Ddointernalname");
            Combo_locationdynamicformid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_get");
            nRC_GXsfl_98 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_98"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_98_fel_idx = 0;
            while ( nGXsfl_98_fel_idx < nRC_GXsfl_98 )
            {
               nGXsfl_98_fel_idx = ((subGridsdt_calltoactions_Islastpage==1)&&(nGXsfl_98_fel_idx+1>subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : nGXsfl_98_fel_idx+1);
               sGXsfl_98_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_982( ) ;
               AV86GXV1 = (int)(nGXsfl_98_fel_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
               if ( ( AV68SDT_CallToAction.Count >= AV86GXV1 ) && ( AV86GXV1 > 0 ) )
               {
                  AV68SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1));
                  AV85ShortCallToActionWithTags = cgiGet( edtavShortcalltoactionwithtags_Internalname);
                  AV84ShortCallToAction = cgiGet( edtavShortcalltoaction_Internalname);
                  AV39CallToActionVariable = cgiGet( edtavCalltoactionvariable_Internalname);
                  cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                  cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                  AV76GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
               }
            }
            if ( nGXsfl_98_fel_idx == 0 )
            {
               nGXsfl_98_idx = 1;
               sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
               SubsflControlProps_982( ) ;
            }
            nGXsfl_98_fel_idx = 1;
            /* Read variables values. */
            cmbavCalltoactiontype.Name = cmbavCalltoactiontype_Internalname;
            cmbavCalltoactiontype.CurrentValue = cgiGet( cmbavCalltoactiontype_Internalname);
            AV52CallToActionType = cgiGet( cmbavCalltoactiontype_Internalname);
            AssignAttri(sPrefix, false, "AV52CallToActionType", AV52CallToActionType);
            AV53CallToActionName = cgiGet( edtavCalltoactionname_Internalname);
            AssignAttri(sPrefix, false, "AV53CallToActionName", AV53CallToActionName);
            AV58CallToActionUrl = cgiGet( edtavCalltoactionurl_Internalname);
            AssignAttri(sPrefix, false, "AV58CallToActionUrl", AV58CallToActionUrl);
            AV78PhoneNumber = cgiGet( edtavPhonenumber_Internalname);
            AssignAttri(sPrefix, false, "AV78PhoneNumber", AV78PhoneNumber);
            AV55CallToActionEmail = cgiGet( edtavCalltoactionemail_Internalname);
            AssignAttri(sPrefix, false, "AV55CallToActionEmail", AV55CallToActionEmail);
            AV79PhoneCode = cgiGet( edtavPhonecode_Internalname);
            AssignAttri(sPrefix, false, "AV79PhoneCode", AV79PhoneCode);
            if ( StringUtil.StrCmp(cgiGet( edtavLocationdynamicformid_Internalname), "") == 0 )
            {
               AV56LocationDynamicFormId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
            }
            else
            {
               try
               {
                  AV56LocationDynamicFormId = StringUtil.StrToGuid( cgiGet( edtavLocationdynamicformid_Internalname));
                  AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vLOCATIONDYNAMICFORMID");
                  GX_FocusControl = edtavLocationdynamicformid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavCalltoactionid_Internalname), "") == 0 )
            {
               AV51CallToActionId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV51CallToActionId", AV51CallToActionId.ToString());
            }
            else
            {
               try
               {
                  AV51CallToActionId = StringUtil.StrToGuid( cgiGet( edtavCalltoactionid_Internalname));
                  AssignAttri(sPrefix, false, "AV51CallToActionId", AV51CallToActionId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vCALLTOACTIONID");
                  GX_FocusControl = edtavCalltoactionid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV54WWPFormReferenceName = cgiGet( edtavWwpformreferencename_Internalname);
            AssignAttri(sPrefix, false, "AV54WWPFormReferenceName", AV54WWPFormReferenceName);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
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
         E186G2 ();
         if (returnInSub) return;
      }

      protected void E186G2( )
      {
         /* Start Routine */
         returnInSub = false;
         divTableinsert_Visible = 0;
         AssignProp(sPrefix, false, divTableinsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableinsert_Visible), 5, 0), true);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79PhoneCode)) )
         {
            AV79PhoneCode = "+31";
            AssignAttri(sPrefix, false, "AV79PhoneCode", AV79PhoneCode);
         }
         Combo_phonecode_Selectedtext_set = AV79PhoneCode;
         ucCombo_phonecode.SendProperty(context, sPrefix, false, Combo_phonecode_Internalname, "SelectedText_set", Combo_phonecode_Selectedtext_set);
         Combo_phonecode_Selectedvalue_set = AV79PhoneCode;
         ucCombo_phonecode.SendProperty(context, sPrefix, false, Combo_phonecode_Internalname, "SelectedValue_set", Combo_phonecode_Selectedvalue_set);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52CallToActionType)) )
         {
            edtavCalltoactionname_Invitemessage = context.GetMessage( "Call Us", "");
            AssignProp(sPrefix, false, edtavCalltoactionname_Internalname, "Invitemessage", edtavCalltoactionname_Invitemessage, true);
            AV52CallToActionType = "Phone";
            AssignAttri(sPrefix, false, "AV52CallToActionType", AV52CallToActionType);
            AV53CallToActionName = AV52CallToActionType;
            AssignAttri(sPrefix, false, "AV53CallToActionName", AV53CallToActionName);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53CallToActionName)) )
         {
            AV53CallToActionName = AV52CallToActionType;
            AssignAttri(sPrefix, false, "AV53CallToActionName", AV53CallToActionName);
         }
         Popover_shortcalltoaction_Gridinternalname = subGridsdt_calltoactions_Internalname;
         ucPopover_shortcalltoaction.SendProperty(context, sPrefix, false, Popover_shortcalltoaction_Internalname, "GridInternalName", Popover_shortcalltoaction_Gridinternalname);
         Popover_shortcalltoaction_Iteminternalname = edtavShortcalltoactionwithtags_Internalname;
         ucPopover_shortcalltoaction.SendProperty(context, sPrefix, false, Popover_shortcalltoaction_Internalname, "ItemInternalName", Popover_shortcalltoaction_Iteminternalname);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV32DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV32DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavLocationdynamicformid_Visible = 0;
         AssignProp(sPrefix, false, edtavLocationdynamicformid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationdynamicformid_Visible), 5, 0), true);
         edtavPhonecode_Visible = 0;
         AssignProp(sPrefix, false, edtavPhonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPhonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_phonecode_Htmltemplate = GXt_char2;
         ucCombo_phonecode.SendProperty(context, sPrefix, false, Combo_phonecode_Internalname, "HTMLTemplate", Combo_phonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOPHONECODE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOLOCATIONDYNAMICFORMID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if (returnInSub) return;
         edtavCalltoactionid_Visible = 0;
         AssignProp(sPrefix, false, edtavCalltoactionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCalltoactionid_Visible), 5, 0), true);
         edtavWwpformreferencename_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpformreferencename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpformreferencename_Visible), 5, 0), true);
         Gridsdt_calltoactions_empowerer_Gridinternalname = subGridsdt_calltoactions_Internalname;
         ucGridsdt_calltoactions_empowerer.SendProperty(context, sPrefix, false, Gridsdt_calltoactions_empowerer_Internalname, "GridInternalName", Gridsdt_calltoactions_empowerer_Gridinternalname);
         subGridsdt_calltoactions_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
         Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue = subGridsdt_calltoactions_Rows;
         ucGridsdt_calltoactionspaginationbar.SendProperty(context, sPrefix, false, Gridsdt_calltoactionspaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue), 9, 0));
         /* Execute user subroutine: 'SET VISIBLE' */
         S142 ();
         if (returnInSub) return;
      }

      protected void E196G2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV68SDT_CallToAction.Clear();
         gx_BV98 = true;
         /* Using cursor H006G2 */
         pr_default.execute(0, new Object[] {AV67ProductServiceId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A206WWPFormId = H006G2_A206WWPFormId[0];
            A207WWPFormVersionNumber = H006G2_A207WWPFormVersionNumber[0];
            A58ProductServiceId = H006G2_A58ProductServiceId[0];
            A339CallToActionId = H006G2_A339CallToActionId[0];
            A368CallToActionName = H006G2_A368CallToActionName[0];
            A342CallToActionPhone = H006G2_A342CallToActionPhone[0];
            A499CallToActionPhoneCode = H006G2_A499CallToActionPhoneCode[0];
            A500CallToActionPhoneNumber = H006G2_A500CallToActionPhoneNumber[0];
            A341CallToActionEmail = H006G2_A341CallToActionEmail[0];
            A340CallToActionType = H006G2_A340CallToActionType[0];
            A367CallToActionUrl = H006G2_A367CallToActionUrl[0];
            A366LocationDynamicFormId = H006G2_A366LocationDynamicFormId[0];
            n366LocationDynamicFormId = H006G2_n366LocationDynamicFormId[0];
            A208WWPFormReferenceName = H006G2_A208WWPFormReferenceName[0];
            A11OrganisationId = H006G2_A11OrganisationId[0];
            A29LocationId = H006G2_A29LocationId[0];
            A206WWPFormId = H006G2_A206WWPFormId[0];
            A207WWPFormVersionNumber = H006G2_A207WWPFormVersionNumber[0];
            A208WWPFormReferenceName = H006G2_A208WWPFormReferenceName[0];
            AV74GridSDT_CallToAction = new SdtSDT_CallToAction_SDT_CallToActionItem(context);
            AV74GridSDT_CallToAction.gxTpr_Calltoactionid = A339CallToActionId;
            AV74GridSDT_CallToAction.gxTpr_Calltoactionname = A368CallToActionName;
            AV74GridSDT_CallToAction.gxTpr_Calltoactionphone = A342CallToActionPhone;
            AV74GridSDT_CallToAction.gxTpr_Calltoactionphonecode = A499CallToActionPhoneCode;
            AV74GridSDT_CallToAction.gxTpr_Calltoactionphonenumber = A500CallToActionPhoneNumber;
            AV74GridSDT_CallToAction.gxTpr_Calltoactionemail = A341CallToActionEmail;
            AV74GridSDT_CallToAction.gxTpr_Calltoactiontype = A340CallToActionType;
            AV74GridSDT_CallToAction.gxTpr_Calltoactionurl = A367CallToActionUrl;
            AV74GridSDT_CallToAction.gxTpr_Locationdynamicformid = A366LocationDynamicFormId;
            AV74GridSDT_CallToAction.gxTpr_Wwpformreferencename = A208WWPFormReferenceName;
            AV74GridSDT_CallToAction.gxTpr_Organisationid = A11OrganisationId;
            AV74GridSDT_CallToAction.gxTpr_Locationid = A29LocationId;
            AV74GridSDT_CallToAction.gxTpr_Productserviceid = A58ProductServiceId;
            AV68SDT_CallToAction.Add(AV74GridSDT_CallToAction, 0);
            gx_BV98 = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV70GridSDT_CallToActionsCurrentPage = subGridsdt_calltoactions_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV70GridSDT_CallToActionsCurrentPage", StringUtil.LTrimStr( (decimal)(AV70GridSDT_CallToActionsCurrentPage), 10, 0));
         AV71GridSDT_CallToActionsPageCount = subGridsdt_calltoactions_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV71GridSDT_CallToActionsPageCount", StringUtil.LTrimStr( (decimal)(AV71GridSDT_CallToActionsPageCount), 10, 0));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV68SDT_CallToAction", AV68SDT_CallToAction);
      }

      private void E206G2( )
      {
         /* Gridsdt_calltoactions_Load Routine */
         returnInSub = false;
         AV86GXV1 = 1;
         while ( AV86GXV1 <= AV68SDT_CallToAction.Count )
         {
            AV68SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionphone)) )
            {
               AV39CallToActionVariable = "";
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCALLTOACTIONVARIABLE"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sPrefix+sGXsfl_98_idx, StringUtil.RTrim( context.localUtil.Format( AV39CallToActionVariable, "")), context));
               AV39CallToActionVariable = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionphone;
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCALLTOACTIONVARIABLE"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sPrefix+sGXsfl_98_idx, StringUtil.RTrim( context.localUtil.Format( AV39CallToActionVariable, "")), context));
            }
            else if ( ! (Guid.Empty==((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Locationdynamicformid) )
            {
               AV39CallToActionVariable = "";
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCALLTOACTIONVARIABLE"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sPrefix+sGXsfl_98_idx, StringUtil.RTrim( context.localUtil.Format( AV39CallToActionVariable, "")), context));
               AV39CallToActionVariable = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Wwpformreferencename;
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCALLTOACTIONVARIABLE"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sPrefix+sGXsfl_98_idx, StringUtil.RTrim( context.localUtil.Format( AV39CallToActionVariable, "")), context));
            }
            else if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionurl)) )
            {
               AV39CallToActionVariable = "";
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCALLTOACTIONVARIABLE"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sPrefix+sGXsfl_98_idx, StringUtil.RTrim( context.localUtil.Format( AV39CallToActionVariable, "")), context));
               AV39CallToActionVariable = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionurl;
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCALLTOACTIONVARIABLE"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sPrefix+sGXsfl_98_idx, StringUtil.RTrim( context.localUtil.Format( AV39CallToActionVariable, "")), context));
            }
            else if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionemail)) )
            {
               AV39CallToActionVariable = "";
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCALLTOACTIONVARIABLE"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sPrefix+sGXsfl_98_idx, StringUtil.RTrim( context.localUtil.Format( AV39CallToActionVariable, "")), context));
               AV39CallToActionVariable = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionemail;
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV39CallToActionVariable);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCALLTOACTIONVARIABLE"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sPrefix+sGXsfl_98_idx, StringUtil.RTrim( context.localUtil.Format( AV39CallToActionVariable, "")), context));
            }
            if ( StringUtil.Len( AV39CallToActionVariable) > 25 )
            {
               AV84ShortCallToAction = StringUtil.Substring( AV39CallToActionVariable, 1, 25) + " ...";
               AssignAttri(sPrefix, false, edtavShortcalltoaction_Internalname, AV84ShortCallToAction);
            }
            else
            {
               AV84ShortCallToAction = AV39CallToActionVariable;
               AssignAttri(sPrefix, false, edtavShortcalltoaction_Internalname, AV84ShortCallToAction);
            }
            cmbavGridactiongroup1.removeAllItems();
            cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
            cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fas fa-pen", "", "", "", "", "", "", ""), 0);
            cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Delete", ""), "fas fa-xmark", "", "", "", "", "", "", ""), 0);
            GXt_char2 = AV85ShortCallToActionWithTags;
            new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  AV84ShortCallToAction, out  GXt_char2) ;
            AV85ShortCallToActionWithTags = GXt_char2;
            AssignAttri(sPrefix, false, edtavShortcalltoactionwithtags_Internalname, AV85ShortCallToActionWithTags);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 98;
            }
            if ( ( subGridsdt_calltoactions_Islastpage == 1 ) || ( subGridsdt_calltoactions_Rows == 0 ) || ( ( GRIDSDT_CALLTOACTIONS_nCurrentRecord >= GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage ) && ( GRIDSDT_CALLTOACTIONS_nCurrentRecord < GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage + subGridsdt_calltoactions_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_982( ) ;
            }
            GRIDSDT_CALLTOACTIONS_nEOF = (short)(((GRIDSDT_CALLTOACTIONS_nCurrentRecord<GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage+subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nEOF), 1, 0, ".", "")));
            GRIDSDT_CALLTOACTIONS_nCurrentRecord = (long)(GRIDSDT_CALLTOACTIONS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_98_Refreshing )
            {
               DoAjaxLoad(98, Gridsdt_calltoactionsRow);
            }
            AV86GXV1 = (int)(AV86GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV76GridActionGroup1), 4, 0));
      }

      protected void E146G2( )
      {
         /* Gridsdt_calltoactionspaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridsdt_calltoactionspaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgridsdt_calltoactions_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridsdt_calltoactionspaginationbar_Selectedpage, "Next") == 0 )
         {
            AV69PageToGo = subGridsdt_calltoactions_fnc_Currentpage( );
            AV69PageToGo = (int)(AV69PageToGo+1);
            subgridsdt_calltoactions_gotopage( AV69PageToGo) ;
         }
         else
         {
            AV69PageToGo = (int)(Math.Round(NumberUtil.Val( Gridsdt_calltoactionspaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgridsdt_calltoactions_gotopage( AV69PageToGo) ;
         }
      }

      protected void E156G2( )
      {
         /* Gridsdt_calltoactionspaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGridsdt_calltoactions_Rows = Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
         subgridsdt_calltoactions_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E216G2( )
      {
         AV86GXV1 = (int)(nGXsfl_98_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
         if ( ( AV86GXV1 > 0 ) && ( AV68SDT_CallToAction.Count >= AV86GXV1 ) )
         {
            AV68SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1));
         }
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV76GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO USERACTIONUPDATE' */
            S152 ();
            if (returnInSub) return;
         }
         else if ( AV76GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO USERACTIONDELETE' */
            S162 ();
            if (returnInSub) return;
         }
         AV76GridActionGroup1 = 0;
         AssignAttri(sPrefix, false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV76GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV76GridActionGroup1), 4, 0));
         AssignProp(sPrefix, false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
         cmbavCalltoactiontype.CurrentValue = StringUtil.RTrim( AV52CallToActionType);
         AssignProp(sPrefix, false, cmbavCalltoactiontype_Internalname, "Values", cmbavCalltoactiontype.ToJavascriptSource(), true);
      }

      protected void E166G2( )
      {
         AV86GXV1 = (int)(nGXsfl_98_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
         if ( ( AV86GXV1 > 0 ) && ( AV68SDT_CallToAction.Count >= AV86GXV1 ) )
         {
            AV68SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1));
         }
         /* Dvelop_confirmpanel_useractiondelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractiondelete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONDELETE' */
            S172 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV68SDT_CallToAction", AV68SDT_CallToAction);
         nGXsfl_98_bak_idx = nGXsfl_98_idx;
         gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A339CallToActionId, A368CallToActionName, A342CallToActionPhone, A499CallToActionPhoneCode, A500CallToActionPhoneNumber, A341CallToActionEmail, A340CallToActionType, A367CallToActionUrl, A366LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, AV39CallToActionVariable, sPrefix) ;
         nGXsfl_98_idx = nGXsfl_98_bak_idx;
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_982( ) ;
      }

      protected void E176G2( )
      {
         /* 'DoUserActionAdd' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S182 ();
         if (returnInSub) return;
         if ( AV77CheckRequiredFieldsResult )
         {
            AV62Trn_CallToAction = new SdtTrn_CallToAction(context);
            AV62Trn_CallToAction.gxTpr_Productserviceid = AV67ProductServiceId;
            if ( StringUtil.StrCmp(AV52CallToActionType, "Phone") != 0 )
            {
               AV62Trn_CallToAction.gxTpr_Calltoactionphone = "";
               AV62Trn_CallToAction.gxTpr_Calltoactionphonecode = "";
            }
            if ( (Guid.Empty==AV51CallToActionId) )
            {
               AV62Trn_CallToAction.gxTpr_Calltoactionid = Guid.NewGuid( );
            }
            else
            {
               AV62Trn_CallToAction.gxTpr_Calltoactionid = AV51CallToActionId;
            }
            AV62Trn_CallToAction.gxTpr_Calltoactionname = AV53CallToActionName;
            AV62Trn_CallToAction.gxTpr_Calltoactiontype = AV52CallToActionType;
            AV62Trn_CallToAction.gxTpr_Calltoactionemail = AV55CallToActionEmail;
            AV62Trn_CallToAction.gxTpr_Calltoactionphonenumber = AV78PhoneNumber;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78PhoneNumber)) )
            {
               AV62Trn_CallToAction.gxTpr_Calltoactionphonecode = AV79PhoneCode;
               GXt_char2 = "";
               new prc_concatenateintlphone(context ).execute(  AV79PhoneCode,  AV78PhoneNumber, out  GXt_char2) ;
               AV62Trn_CallToAction.gxTpr_Calltoactionphone = GXt_char2;
            }
            else
            {
               AV62Trn_CallToAction.gxTpr_Calltoactionphonecode = "";
            }
            AV62Trn_CallToAction.gxTpr_Calltoactionurl = AV58CallToActionUrl;
            AV62Trn_CallToAction.gxTpr_Organisationid = AV65OrganisationId;
            AV62Trn_CallToAction.gxTpr_Locationid = AV66LocationId;
            if ( (Guid.Empty==AV56LocationDynamicFormId) )
            {
               AV62Trn_CallToAction.gxTv_SdtTrn_CallToAction_Locationdynamicformid_SetNull();
            }
            else
            {
               AV62Trn_CallToAction.gxTpr_Locationdynamicformid = AV56LocationDynamicFormId;
            }
            new prc_logtofile(context ).execute(  AV62Trn_CallToAction.ToJSonString(true, true)) ;
            AV62Trn_CallToAction.InsertOrUpdate();
            if ( ! AV62Trn_CallToAction.Success() )
            {
               AV102GXV16 = 1;
               AV101GXV15 = AV62Trn_CallToAction.GetMessages();
               while ( AV102GXV16 <= AV101GXV15.Count )
               {
                  AV42Message = ((GeneXus.Utils.SdtMessages_Message)AV101GXV15.Item(AV102GXV16));
                  GX_msglist.addItem(AV42Message.gxTpr_Description);
                  AV102GXV16 = (int)(AV102GXV16+1);
               }
            }
            else
            {
               context.CommitDataStores("wc_calltoaction",pr_default);
               GX_msglist.addItem(context.GetMessage( "successfull", ""));
               /* Execute user subroutine: 'CLEAR FORM' */
               S192 ();
               if (returnInSub) return;
               context.DoAjaxRefreshCmp(sPrefix);
            }
         }
         /*  Sending Event outputs  */
         if ( gx_BV98 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV68SDT_CallToAction", AV68SDT_CallToAction);
            nGXsfl_98_bak_idx = nGXsfl_98_idx;
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, A58ProductServiceId, AV67ProductServiceId, A339CallToActionId, A368CallToActionName, A342CallToActionPhone, A499CallToActionPhoneCode, A500CallToActionPhoneNumber, A341CallToActionEmail, A340CallToActionType, A367CallToActionUrl, A366LocationDynamicFormId, A208WWPFormReferenceName, A11OrganisationId, A29LocationId, AV68SDT_CallToAction, AV39CallToActionVariable, sPrefix) ;
            nGXsfl_98_idx = nGXsfl_98_bak_idx;
            sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
            SubsflControlProps_982( ) ;
         }
      }

      protected void E226G2( )
      {
         /* Shortcalltoaction_Click Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WC_CallToActionDetails")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wc_calltoactiondetails", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WC_CallToActionDetails";
            WebComp_Wwpaux_wc_Component = "WC_CallToActionDetails";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0134",(string)"",(string)AV39CallToActionVariable});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)sPrefix+"vCALLTOACTIONVARIABLE_"+sGXsfl_98_idx});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0134"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E136G2( )
      {
         /* Combo_locationdynamicformid_Onoptionclicked Routine */
         returnInSub = false;
         AV56LocationDynamicFormId = StringUtil.StrToGuid( Combo_locationdynamicformid_Selectedvalue_get);
         AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'DO USERACTIONUPDATE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CLEAR FORM' */
         S192 ();
         if (returnInSub) return;
         divTableinsert_Visible = 1;
         AssignProp(sPrefix, false, divTableinsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableinsert_Visible), 5, 0), true);
         AV51CallToActionId = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionid;
         AssignAttri(sPrefix, false, "AV51CallToActionId", AV51CallToActionId.ToString());
         AV53CallToActionName = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionname;
         AssignAttri(sPrefix, false, "AV53CallToActionName", AV53CallToActionName);
         AV57CallToActionPhone = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionphone;
         AV79PhoneCode = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionphonecode;
         AssignAttri(sPrefix, false, "AV79PhoneCode", AV79PhoneCode);
         Combo_phonecode_Selectedtext_set = AV79PhoneCode;
         ucCombo_phonecode.SendProperty(context, sPrefix, false, Combo_phonecode_Internalname, "SelectedText_set", Combo_phonecode_Selectedtext_set);
         Combo_phonecode_Selectedvalue_set = AV79PhoneCode;
         ucCombo_phonecode.SendProperty(context, sPrefix, false, Combo_phonecode_Internalname, "SelectedValue_set", Combo_phonecode_Selectedvalue_set);
         AV78PhoneNumber = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionphonenumber;
         AssignAttri(sPrefix, false, "AV78PhoneNumber", AV78PhoneNumber);
         AV58CallToActionUrl = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionurl;
         AssignAttri(sPrefix, false, "AV58CallToActionUrl", AV58CallToActionUrl);
         AV56LocationDynamicFormId = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Locationdynamicformid;
         AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
         AV55CallToActionEmail = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionemail;
         AssignAttri(sPrefix, false, "AV55CallToActionEmail", AV55CallToActionEmail);
         AV52CallToActionType = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactiontype;
         AssignAttri(sPrefix, false, "AV52CallToActionType", AV52CallToActionType);
         if ( ! (Guid.Empty==AV56LocationDynamicFormId) )
         {
            Combo_locationdynamicformid_Selectedtext_set = AV54WWPFormReferenceName;
            ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedText_set", Combo_locationdynamicformid_Selectedtext_set);
            Combo_locationdynamicformid_Selectedvalue_set = AV56LocationDynamicFormId.ToString();
            ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedValue_set", Combo_locationdynamicformid_Selectedvalue_set);
         }
         else
         {
            Combo_locationdynamicformid_Selectedtext_set = "";
            ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedText_set", Combo_locationdynamicformid_Selectedtext_set);
            Combo_locationdynamicformid_Selectedvalue_set = "";
            ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedValue_set", Combo_locationdynamicformid_Selectedvalue_set);
         }
         /* Execute user subroutine: 'SET VISIBLE' */
         S142 ();
         if (returnInSub) return;
      }

      protected void S162( )
      {
         /* 'DO USERACTIONDELETE' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "DVELOP_CONFIRMPANEL_USERACTIONDELETEContainer", "Confirm", "", new Object[] {});
      }

      protected void S172( )
      {
         /* 'DO ACTION USERACTIONDELETE' Routine */
         returnInSub = false;
         new prc_deletecalltoaction(context ).execute(  ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Organisationid,  ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Locationid,  ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Productserviceid,  ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV68SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionid) ;
         GX_msglist.addItem(context.GetMessage( "delete sucessfully", ""));
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void S182( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV77CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV77CheckRequiredFieldsResult", AV77CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53CallToActionName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Label", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCalltoactionname_Internalname,  "true",  ""));
            AV77CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV77CheckRequiredFieldsResult", AV77CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV52CallToActionType, "SiteUrl") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV58CallToActionUrl)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Url", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCalltoactionurl_Internalname,  "true",  ""));
            AV77CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV77CheckRequiredFieldsResult", AV77CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV52CallToActionType, "Phone") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV78PhoneNumber)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Phone Number", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPhonenumber_Internalname,  "true",  ""));
            AV77CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV77CheckRequiredFieldsResult", AV77CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV52CallToActionType, "Form") == 0 ) ) && (Guid.Empty==AV56LocationDynamicFormId) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Form", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_locationdynamicformid_Ddointernalname,  "true",  ""));
            AV77CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV77CheckRequiredFieldsResult", AV77CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV52CallToActionType, "Email") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV55CallToActionEmail)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCalltoactionemail_Internalname,  "true",  ""));
            AV77CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV77CheckRequiredFieldsResult", AV77CheckRequiredFieldsResult);
         }
      }

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV52CallToActionType, "Email") == 0 )
         {
            divCalltoactionemail_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell";
            AssignProp(sPrefix, false, divCalltoactionemail_cell_Internalname, "Class", divCalltoactionemail_cell_Class, true);
         }
         else
         {
            divCalltoactionemail_cell_Class = "col-xs-12 col-sm-6 DataContentCell";
            AssignProp(sPrefix, false, divCalltoactionemail_cell_Internalname, "Class", divCalltoactionemail_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV52CallToActionType, "Form") == 0 )
         {
            divCombo_locationdynamicformid_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell ExtendedComboCell";
            AssignProp(sPrefix, false, divCombo_locationdynamicformid_cell_Internalname, "Class", divCombo_locationdynamicformid_cell_Class, true);
         }
         else
         {
            divCombo_locationdynamicformid_cell_Class = "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell";
            AssignProp(sPrefix, false, divCombo_locationdynamicformid_cell_Internalname, "Class", divCombo_locationdynamicformid_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV52CallToActionType, "Phone") == 0 )
         {
            divPhonenumber_cell_Class = "col-xs-12 RequiredDataContentCell";
            AssignProp(sPrefix, false, divPhonenumber_cell_Internalname, "Class", divPhonenumber_cell_Class, true);
         }
         else
         {
            divPhonenumber_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divPhonenumber_cell_Internalname, "Class", divPhonenumber_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV52CallToActionType, "SiteUrl") == 0 )
         {
            divCalltoactionurl_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell";
            AssignProp(sPrefix, false, divCalltoactionurl_cell_Internalname, "Class", divCalltoactionurl_cell_Class, true);
         }
         else
         {
            divCalltoactionurl_cell_Class = "col-xs-12 col-sm-6 DataContentCell";
            AssignProp(sPrefix, false, divCalltoactionurl_cell_Internalname, "Class", divCalltoactionurl_cell_Class, true);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOLOCATIONDYNAMICFORMID' Routine */
         returnInSub = false;
         AV104GXV18 = 1;
         GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem3 = AV103GXV17;
         new dp_locationdynamicform(context ).execute( out  GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem3) ;
         AV103GXV17 = GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem3;
         while ( AV104GXV18 <= AV103GXV17.Count )
         {
            AV61LocationDynamicFormId_DPItem = ((SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem)AV103GXV17.Item(AV104GXV18));
            AV60Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV60Combo_DataItem.gxTpr_Id = StringUtil.Trim( AV61LocationDynamicFormId_DPItem.gxTpr_Locationdynamicformid.ToString());
            AV60Combo_DataItem.gxTpr_Title = AV61LocationDynamicFormId_DPItem.gxTpr_Wwpformreferencename;
            AV59LocationDynamicFormId_Data.Add(AV60Combo_DataItem, 0);
            AV104GXV18 = (int)(AV104GXV18+1);
         }
         AV59LocationDynamicFormId_Data.Sort("Title");
         Combo_locationdynamicformid_Selectedvalue_set = ((Guid.Empty==AV56LocationDynamicFormId) ? "" : StringUtil.Trim( AV56LocationDynamicFormId.ToString()));
         ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedValue_set", Combo_locationdynamicformid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPHONECODE' Routine */
         returnInSub = false;
         AV106GXV20 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem4 = AV105GXV19;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem4) ;
         AV105GXV19 = GXt_objcol_SdtSDT_Country_SDT_CountryItem4;
         while ( AV106GXV20 <= AV105GXV19.Count )
         {
            AV82PhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV105GXV19.Item(AV106GXV20));
            AV60Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV60Combo_DataItem.gxTpr_Id = AV82PhoneCode_DPItem.gxTpr_Countrydialcode;
            AV80ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV80ComboTitles.Add(AV82PhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV80ComboTitles.Add(AV82PhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV60Combo_DataItem.gxTpr_Title = AV80ComboTitles.ToJSonString(false);
            AV81PhoneCode_Data.Add(AV60Combo_DataItem, 0);
            AV106GXV20 = (int)(AV106GXV20+1);
         }
         AV81PhoneCode_Data.Sort("Title");
         Combo_phonecode_Selectedvalue_set = AV79PhoneCode;
         ucCombo_phonecode.SendProperty(context, sPrefix, false, Combo_phonecode_Internalname, "SelectedValue_set", Combo_phonecode_Selectedvalue_set);
      }

      protected void S192( )
      {
         /* 'CLEAR FORM' Routine */
         returnInSub = false;
         AV51CallToActionId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV51CallToActionId", AV51CallToActionId.ToString());
         AV53CallToActionName = AV52CallToActionType;
         AssignAttri(sPrefix, false, "AV53CallToActionName", AV53CallToActionName);
         AV57CallToActionPhone = "";
         AV78PhoneNumber = "";
         AssignAttri(sPrefix, false, "AV78PhoneNumber", AV78PhoneNumber);
         AV58CallToActionUrl = "";
         AssignAttri(sPrefix, false, "AV58CallToActionUrl", AV58CallToActionUrl);
         AV56LocationDynamicFormId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
         Combo_locationdynamicformid_Selectedtext_set = "";
         ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedText_set", Combo_locationdynamicformid_Selectedtext_set);
         Combo_locationdynamicformid_Selectedvalue_set = "";
         ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedValue_set", Combo_locationdynamicformid_Selectedvalue_set);
         AV55CallToActionEmail = "";
         AssignAttri(sPrefix, false, "AV55CallToActionEmail", AV55CallToActionEmail);
      }

      protected void S142( )
      {
         /* 'SET VISIBLE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV52CallToActionType, "Phone") == 0 )
         {
            edtavCalltoactionname_Invitemessage = context.GetMessage( "Call us", "");
            AssignProp(sPrefix, false, edtavCalltoactionname_Internalname, "Invitemessage", edtavCalltoactionname_Invitemessage, true);
            divTableurl_Visible = 0;
            AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
            divTableemail_Visible = 0;
            AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
            divTableform_Visible = 0;
            AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
            divTablephone_Visible = 1;
            AssignProp(sPrefix, false, divTablephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablephone_Visible), 5, 0), true);
            AV58CallToActionUrl = "";
            AssignAttri(sPrefix, false, "AV58CallToActionUrl", AV58CallToActionUrl);
            AV55CallToActionEmail = "";
            AssignAttri(sPrefix, false, "AV55CallToActionEmail", AV55CallToActionEmail);
            AV56LocationDynamicFormId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
            Combo_locationdynamicformid_Selectedtext_set = "";
            ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedText_set", Combo_locationdynamicformid_Selectedtext_set);
            Combo_locationdynamicformid_Selectedvalue_set = "";
            ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedValue_set", Combo_locationdynamicformid_Selectedvalue_set);
            AV54WWPFormReferenceName = "";
            AssignAttri(sPrefix, false, "AV54WWPFormReferenceName", AV54WWPFormReferenceName);
         }
         else if ( StringUtil.StrCmp(AV52CallToActionType, "Email") == 0 )
         {
            edtavCalltoactionname_Invitemessage = context.GetMessage( "Email us", "");
            AssignProp(sPrefix, false, edtavCalltoactionname_Internalname, "Invitemessage", edtavCalltoactionname_Invitemessage, true);
            divTableurl_Visible = 0;
            AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
            divTablephone_Visible = 0;
            AssignProp(sPrefix, false, divTablephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablephone_Visible), 5, 0), true);
            divTableform_Visible = 0;
            AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
            divTableemail_Visible = 1;
            AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
            AV58CallToActionUrl = "";
            AssignAttri(sPrefix, false, "AV58CallToActionUrl", AV58CallToActionUrl);
            AV57CallToActionPhone = "";
            AV78PhoneNumber = "";
            AssignAttri(sPrefix, false, "AV78PhoneNumber", AV78PhoneNumber);
            AV56LocationDynamicFormId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
            Combo_locationdynamicformid_Selectedtext_set = "";
            ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedText_set", Combo_locationdynamicformid_Selectedtext_set);
            Combo_locationdynamicformid_Selectedvalue_set = "";
            ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedValue_set", Combo_locationdynamicformid_Selectedvalue_set);
            AV54WWPFormReferenceName = "";
            AssignAttri(sPrefix, false, "AV54WWPFormReferenceName", AV54WWPFormReferenceName);
         }
         else if ( StringUtil.StrCmp(AV52CallToActionType, "Form") == 0 )
         {
            edtavCalltoactionname_Invitemessage = context.GetMessage( "Fill Request Form", "");
            AssignProp(sPrefix, false, edtavCalltoactionname_Internalname, "Invitemessage", edtavCalltoactionname_Invitemessage, true);
            divTableurl_Visible = 0;
            AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
            divTablephone_Visible = 0;
            AssignProp(sPrefix, false, divTablephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablephone_Visible), 5, 0), true);
            divTableemail_Visible = 0;
            AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
            divTableform_Visible = 1;
            AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
            AV58CallToActionUrl = "";
            AssignAttri(sPrefix, false, "AV58CallToActionUrl", AV58CallToActionUrl);
            AV57CallToActionPhone = "";
            AV78PhoneNumber = "";
            AssignAttri(sPrefix, false, "AV78PhoneNumber", AV78PhoneNumber);
            AV55CallToActionEmail = "";
            AssignAttri(sPrefix, false, "AV55CallToActionEmail", AV55CallToActionEmail);
         }
         else if ( StringUtil.StrCmp(AV52CallToActionType, "SiteUrl") == 0 )
         {
            edtavCalltoactionname_Invitemessage = context.GetMessage( "Visit Site", "");
            AssignProp(sPrefix, false, edtavCalltoactionname_Internalname, "Invitemessage", edtavCalltoactionname_Invitemessage, true);
            divTablephone_Visible = 0;
            AssignProp(sPrefix, false, divTablephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablephone_Visible), 5, 0), true);
            divTableemail_Visible = 0;
            AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
            divTableform_Visible = 0;
            AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
            divTableurl_Visible = 1;
            AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
            AV55CallToActionEmail = "";
            AssignAttri(sPrefix, false, "AV55CallToActionEmail", AV55CallToActionEmail);
            AV57CallToActionPhone = "";
            AV78PhoneNumber = "";
            AssignAttri(sPrefix, false, "AV78PhoneNumber", AV78PhoneNumber);
            AV56LocationDynamicFormId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV56LocationDynamicFormId", AV56LocationDynamicFormId.ToString());
            Combo_locationdynamicformid_Selectedtext_set = "";
            ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedText_set", Combo_locationdynamicformid_Selectedtext_set);
            Combo_locationdynamicformid_Selectedvalue_set = "";
            ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedValue_set", Combo_locationdynamicformid_Selectedvalue_set);
            AV54WWPFormReferenceName = "";
            AssignAttri(sPrefix, false, "AV54WWPFormReferenceName", AV54WWPFormReferenceName);
         }
      }

      protected void wb_table1_127_6G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_useractiondelete_Internalname, tblTabledvelop_confirmpanel_useractiondelete_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_useractiondelete.SetProperty("Title", Dvelop_confirmpanel_useractiondelete_Title);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("ConfirmationText", Dvelop_confirmpanel_useractiondelete_Confirmationtext);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("YesButtonCaption", Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("NoButtonCaption", Dvelop_confirmpanel_useractiondelete_Nobuttoncaption);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("YesButtonPosition", Dvelop_confirmpanel_useractiondelete_Yesbuttonposition);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("ConfirmType", Dvelop_confirmpanel_useractiondelete_Confirmtype);
            ucDvelop_confirmpanel_useractiondelete.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_useractiondelete_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_127_6G2e( true) ;
         }
         else
         {
            wb_table1_127_6G2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV65OrganisationId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV65OrganisationId", AV65OrganisationId.ToString());
         AV66LocationId = (Guid)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV66LocationId", AV66LocationId.ToString());
         AV67ProductServiceId = (Guid)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV67ProductServiceId", AV67ProductServiceId.ToString());
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
         PA6G2( ) ;
         WS6G2( ) ;
         WE6G2( ) ;
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
         sCtrlAV65OrganisationId = (string)((string)getParm(obj,0));
         sCtrlAV66LocationId = (string)((string)getParm(obj,1));
         sCtrlAV67ProductServiceId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA6G2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wc_calltoaction", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6G2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV65OrganisationId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV65OrganisationId", AV65OrganisationId.ToString());
            AV66LocationId = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV66LocationId", AV66LocationId.ToString());
            AV67ProductServiceId = (Guid)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV67ProductServiceId", AV67ProductServiceId.ToString());
         }
         wcpOAV65OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV65OrganisationId"));
         wcpOAV66LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV66LocationId"));
         wcpOAV67ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV67ProductServiceId"));
         if ( ! GetJustCreated( ) && ( ( AV65OrganisationId != wcpOAV65OrganisationId ) || ( AV66LocationId != wcpOAV66LocationId ) || ( AV67ProductServiceId != wcpOAV67ProductServiceId ) ) )
         {
            setjustcreated();
         }
         wcpOAV65OrganisationId = AV65OrganisationId;
         wcpOAV66LocationId = AV66LocationId;
         wcpOAV67ProductServiceId = AV67ProductServiceId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV65OrganisationId = cgiGet( sPrefix+"AV65OrganisationId_CTRL");
         if ( StringUtil.Len( sCtrlAV65OrganisationId) > 0 )
         {
            AV65OrganisationId = StringUtil.StrToGuid( cgiGet( sCtrlAV65OrganisationId));
            AssignAttri(sPrefix, false, "AV65OrganisationId", AV65OrganisationId.ToString());
         }
         else
         {
            AV65OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV65OrganisationId_PARM"));
         }
         sCtrlAV66LocationId = cgiGet( sPrefix+"AV66LocationId_CTRL");
         if ( StringUtil.Len( sCtrlAV66LocationId) > 0 )
         {
            AV66LocationId = StringUtil.StrToGuid( cgiGet( sCtrlAV66LocationId));
            AssignAttri(sPrefix, false, "AV66LocationId", AV66LocationId.ToString());
         }
         else
         {
            AV66LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV66LocationId_PARM"));
         }
         sCtrlAV67ProductServiceId = cgiGet( sPrefix+"AV67ProductServiceId_CTRL");
         if ( StringUtil.Len( sCtrlAV67ProductServiceId) > 0 )
         {
            AV67ProductServiceId = StringUtil.StrToGuid( cgiGet( sCtrlAV67ProductServiceId));
            AssignAttri(sPrefix, false, "AV67ProductServiceId", AV67ProductServiceId.ToString());
         }
         else
         {
            AV67ProductServiceId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV67ProductServiceId_PARM"));
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
         PA6G2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6G2( ) ;
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
         WS6G2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV65OrganisationId_PARM", AV65OrganisationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV65OrganisationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV65OrganisationId_CTRL", StringUtil.RTrim( sCtrlAV65OrganisationId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV66LocationId_PARM", AV66LocationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV66LocationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV66LocationId_CTRL", StringUtil.RTrim( sCtrlAV66LocationId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV67ProductServiceId_PARM", AV67ProductServiceId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV67ProductServiceId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV67ProductServiceId_CTRL", StringUtil.RTrim( sCtrlAV67ProductServiceId));
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
         WE6G2( ) ;
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025721251275", true, true);
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
         context.AddJavascriptSource("wc_calltoaction.js", "?2025721251276", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Popover/WWPPopoverRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_982( )
      {
         edtavSdt_calltoaction__calltoactionid_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONID_"+sGXsfl_98_idx;
         edtavSdt_calltoaction__organisationid_Internalname = sPrefix+"SDT_CALLTOACTION__ORGANISATIONID_"+sGXsfl_98_idx;
         edtavSdt_calltoaction__locationid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONID_"+sGXsfl_98_idx;
         edtavSdt_calltoaction__productserviceid_Internalname = sPrefix+"SDT_CALLTOACTION__PRODUCTSERVICEID_"+sGXsfl_98_idx;
         cmbavSdt_calltoaction__calltoactiontype_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONTYPE_"+sGXsfl_98_idx;
         edtavSdt_calltoaction__calltoactionname_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONNAME_"+sGXsfl_98_idx;
         edtavSdt_calltoaction__calltoactionphone_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONE_"+sGXsfl_98_idx;
         edtavSdt_calltoaction__calltoactionphonecode_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONECODE_"+sGXsfl_98_idx;
         edtavSdt_calltoaction__calltoactionphonenumber_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONENUMBER_"+sGXsfl_98_idx;
         edtavSdt_calltoaction__calltoactionurl_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONURL_"+sGXsfl_98_idx;
         edtavSdt_calltoaction__calltoactionemail_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONEMAIL_"+sGXsfl_98_idx;
         edtavSdt_calltoaction__locationdynamicformid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONDYNAMICFORMID_"+sGXsfl_98_idx;
         edtavShortcalltoactionwithtags_Internalname = sPrefix+"vSHORTCALLTOACTIONWITHTAGS_"+sGXsfl_98_idx;
         edtavShortcalltoaction_Internalname = sPrefix+"vSHORTCALLTOACTION_"+sGXsfl_98_idx;
         edtavSdt_calltoaction__wwpformreferencename_Internalname = sPrefix+"SDT_CALLTOACTION__WWPFORMREFERENCENAME_"+sGXsfl_98_idx;
         edtavCalltoactionvariable_Internalname = sPrefix+"vCALLTOACTIONVARIABLE_"+sGXsfl_98_idx;
         cmbavGridactiongroup1_Internalname = sPrefix+"vGRIDACTIONGROUP1_"+sGXsfl_98_idx;
      }

      protected void SubsflControlProps_fel_982( )
      {
         edtavSdt_calltoaction__calltoactionid_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONID_"+sGXsfl_98_fel_idx;
         edtavSdt_calltoaction__organisationid_Internalname = sPrefix+"SDT_CALLTOACTION__ORGANISATIONID_"+sGXsfl_98_fel_idx;
         edtavSdt_calltoaction__locationid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONID_"+sGXsfl_98_fel_idx;
         edtavSdt_calltoaction__productserviceid_Internalname = sPrefix+"SDT_CALLTOACTION__PRODUCTSERVICEID_"+sGXsfl_98_fel_idx;
         cmbavSdt_calltoaction__calltoactiontype_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONTYPE_"+sGXsfl_98_fel_idx;
         edtavSdt_calltoaction__calltoactionname_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONNAME_"+sGXsfl_98_fel_idx;
         edtavSdt_calltoaction__calltoactionphone_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONE_"+sGXsfl_98_fel_idx;
         edtavSdt_calltoaction__calltoactionphonecode_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONECODE_"+sGXsfl_98_fel_idx;
         edtavSdt_calltoaction__calltoactionphonenumber_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONENUMBER_"+sGXsfl_98_fel_idx;
         edtavSdt_calltoaction__calltoactionurl_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONURL_"+sGXsfl_98_fel_idx;
         edtavSdt_calltoaction__calltoactionemail_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONEMAIL_"+sGXsfl_98_fel_idx;
         edtavSdt_calltoaction__locationdynamicformid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONDYNAMICFORMID_"+sGXsfl_98_fel_idx;
         edtavShortcalltoactionwithtags_Internalname = sPrefix+"vSHORTCALLTOACTIONWITHTAGS_"+sGXsfl_98_fel_idx;
         edtavShortcalltoaction_Internalname = sPrefix+"vSHORTCALLTOACTION_"+sGXsfl_98_fel_idx;
         edtavSdt_calltoaction__wwpformreferencename_Internalname = sPrefix+"SDT_CALLTOACTION__WWPFORMREFERENCENAME_"+sGXsfl_98_fel_idx;
         edtavCalltoactionvariable_Internalname = sPrefix+"vCALLTOACTIONVARIABLE_"+sGXsfl_98_fel_idx;
         cmbavGridactiongroup1_Internalname = sPrefix+"vGRIDACTIONGROUP1_"+sGXsfl_98_fel_idx;
      }

      protected void sendrow_982( )
      {
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_982( ) ;
         WB6G0( ) ;
         if ( ( subGridsdt_calltoactions_Rows * 1 == 0 ) || ( nGXsfl_98_idx <= subGridsdt_calltoactions_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridsdt_calltoactionsRow = GXWebRow.GetNew(context,Gridsdt_calltoactionsContainer);
            if ( subGridsdt_calltoactions_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Odd";
               }
            }
            else if ( subGridsdt_calltoactions_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 0;
               subGridsdt_calltoactions_Backcolor = subGridsdt_calltoactions_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Uniform";
               }
            }
            else if ( subGridsdt_calltoactions_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Odd";
               }
               subGridsdt_calltoactions_Backcolor = (int)(0x0);
            }
            else if ( subGridsdt_calltoactions_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 1;
               if ( ((int)((nGXsfl_98_idx) % (2))) == 0 )
               {
                  subGridsdt_calltoactions_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Even";
                  }
               }
               else
               {
                  subGridsdt_calltoactions_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Odd";
                  }
               }
            }
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_98_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactionid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactionid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)98,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__organisationid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Organisationid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Organisationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__organisationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__organisationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)98,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__locationid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Locationid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Locationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__locationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__locationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)98,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__productserviceid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Productserviceid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Productserviceid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__productserviceid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__productserviceid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)98,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',98)\"";
            if ( ( cmbavSdt_calltoaction__calltoactiontype.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_CALLTOACTION__CALLTOACTIONTYPE_" + sGXsfl_98_idx;
               cmbavSdt_calltoaction__calltoactiontype.Name = GXCCtl;
               cmbavSdt_calltoaction__calltoactiontype.WebTags = "";
               cmbavSdt_calltoaction__calltoactiontype.addItem("Phone", context.GetMessage( "Phone", ""), 0);
               cmbavSdt_calltoaction__calltoactiontype.addItem("Email", context.GetMessage( "Email", ""), 0);
               cmbavSdt_calltoaction__calltoactiontype.addItem("Form", context.GetMessage( "Form", ""), 0);
               cmbavSdt_calltoaction__calltoactiontype.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
               if ( cmbavSdt_calltoaction__calltoactiontype.ItemCount > 0 )
               {
                  if ( ( AV86GXV1 > 0 ) && ( AV68SDT_CallToAction.Count >= AV86GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactiontype)) )
                  {
                     ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactiontype = cmbavSdt_calltoaction__calltoactiontype.getValidValue(((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactiontype);
                  }
               }
            }
            /* ComboBox */
            Gridsdt_calltoactionsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_calltoaction__calltoactiontype,(string)cmbavSdt_calltoaction__calltoactiontype_Internalname,StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactiontype),(short)1,(string)cmbavSdt_calltoaction__calltoactiontype_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavSdt_calltoaction__calltoactiontype.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"",(string)"",(bool)true,(short)0});
            cmbavSdt_calltoaction__calltoactiontype.CurrentValue = StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactiontype);
            AssignProp(sPrefix, false, cmbavSdt_calltoaction__calltoactiontype_Internalname, "Values", (string)(cmbavSdt_calltoaction__calltoactiontype.ToJavascriptSource()), !bGXsfl_98_Refreshing);
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',98)\"";
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionname_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactionname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_calltoaction__calltoactionname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionphone_Internalname,StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactionphone),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionphonecode_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactionphonecode,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionphonecode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionphonecode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionphonenumber_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactionphonenumber,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionphonenumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionphonenumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionurl_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactionurl,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionurl_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionurl_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionemail_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactionemail,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__locationdynamicformid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Locationdynamicformid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Locationdynamicformid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__locationdynamicformid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__locationdynamicformid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)98,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',98)\"";
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavShortcalltoactionwithtags_Internalname,(string)AV85ShortCallToActionWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavShortcalltoactionwithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavShortcalltoactionwithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavShortcalltoaction_Internalname,(string)AV84ShortCallToAction,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVSHORTCALLTOACTION.CLICK."+sGXsfl_98_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavShortcalltoaction_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavShortcalltoaction_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__wwpformreferencename_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Wwpformreferencename,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__wwpformreferencename_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__wwpformreferencename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCalltoactionvariable_Internalname,(string)AV39CallToActionVariable,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCalltoactionvariable_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavCalltoactionvariable_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'" + sPrefix + "',false,'" + sGXsfl_98_idx + "',98)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_98_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  if ( ( AV86GXV1 > 0 ) && ( AV68SDT_CallToAction.Count >= AV86GXV1 ) && (0==AV76GridActionGroup1) )
                  {
                     AV76GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV76GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                     AssignAttri(sPrefix, false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV76GridActionGroup1), 4, 0));
                  }
               }
            }
            /* ComboBox */
            Gridsdt_calltoactionsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV76GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_98_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV76GridActionGroup1), 4, 0));
            AssignProp(sPrefix, false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_98_Refreshing);
            send_integrity_lvl_hashes6G2( ) ;
            Gridsdt_calltoactionsContainer.AddRow(Gridsdt_calltoactionsRow);
            nGXsfl_98_idx = ((subGridsdt_calltoactions_Islastpage==1)&&(nGXsfl_98_idx+1>subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : nGXsfl_98_idx+1);
            sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
            SubsflControlProps_982( ) ;
         }
         /* End function sendrow_982 */
      }

      protected void init_web_controls( )
      {
         cmbavCalltoactiontype.Name = "vCALLTOACTIONTYPE";
         cmbavCalltoactiontype.WebTags = "";
         cmbavCalltoactiontype.addItem("Phone", context.GetMessage( "Phone", ""), 0);
         cmbavCalltoactiontype.addItem("Email", context.GetMessage( "Email", ""), 0);
         cmbavCalltoactiontype.addItem("Form", context.GetMessage( "Form", ""), 0);
         cmbavCalltoactiontype.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
         if ( cmbavCalltoactiontype.ItemCount > 0 )
         {
         }
         GXCCtl = "SDT_CALLTOACTION__CALLTOACTIONTYPE_" + sGXsfl_98_idx;
         cmbavSdt_calltoaction__calltoactiontype.Name = GXCCtl;
         cmbavSdt_calltoaction__calltoactiontype.WebTags = "";
         cmbavSdt_calltoaction__calltoactiontype.addItem("Phone", context.GetMessage( "Phone", ""), 0);
         cmbavSdt_calltoaction__calltoactiontype.addItem("Email", context.GetMessage( "Email", ""), 0);
         cmbavSdt_calltoaction__calltoactiontype.addItem("Form", context.GetMessage( "Form", ""), 0);
         cmbavSdt_calltoaction__calltoactiontype.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
         if ( cmbavSdt_calltoaction__calltoactiontype.ItemCount > 0 )
         {
            if ( ( AV86GXV1 > 0 ) && ( AV68SDT_CallToAction.Count >= AV86GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV68SDT_CallToAction.Item(AV86GXV1)).gxTpr_Calltoactiontype)) )
            {
            }
         }
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_98_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            if ( ( AV86GXV1 > 0 ) && ( AV68SDT_CallToAction.Count >= AV86GXV1 ) && (0==AV76GridActionGroup1) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl98( )
      {
         if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_calltoactionsContainer"+"DivS\" data-gxgridid=\"98\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridsdt_calltoactions_Internalname, subGridsdt_calltoactions_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridsdt_calltoactions_Backcolorstyle == 0 )
            {
               subGridsdt_calltoactions_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridsdt_calltoactions_Class) > 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Title";
               }
            }
            else
            {
               subGridsdt_calltoactions_Titlebackstyle = 1;
               if ( subGridsdt_calltoactions_Backcolorstyle == 1 )
               {
                  subGridsdt_calltoactions_Titlebackcolor = subGridsdt_calltoactions_Allbackcolor;
                  if ( StringUtil.Len( subGridsdt_calltoactions_Class) > 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridsdt_calltoactions_Class) > 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Organisation Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Product Service Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Type", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Label", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action Phone Code", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action Phone Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action Url", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location Dynamic Form Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWPForm Reference Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridsdt_calltoactionsContainer.AddObjectProperty("GridName", "Gridsdt_calltoactions");
         }
         else
         {
            Gridsdt_calltoactionsContainer.AddObjectProperty("GridName", "Gridsdt_calltoactions");
            Gridsdt_calltoactionsContainer.AddObjectProperty("Header", subGridsdt_calltoactions_Header);
            Gridsdt_calltoactionsContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            Gridsdt_calltoactionsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Backcolorstyle), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("CmpContext", sPrefix);
            Gridsdt_calltoactionsContainer.AddObjectProperty("InMasterPage", "false");
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__organisationid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__locationid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__productserviceid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_calltoaction__calltoactiontype.Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionname_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionphone_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionphonecode_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionphonenumber_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionurl_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionemail_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__locationdynamicformid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV85ShortCallToActionWithTags));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavShortcalltoactionwithtags_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV84ShortCallToAction));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavShortcalltoaction_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__wwpformreferencename_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV39CallToActionVariable));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCalltoactionvariable_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV76GridActionGroup1), 4, 0, ".", ""))));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Selectedindex), 4, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Allowselection), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Selectioncolor), 9, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Allowhovering), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Hoveringcolor), 9, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Allowcollapsing), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnuseractioninsert_Internalname = sPrefix+"BTNUSERACTIONINSERT";
         cmbavCalltoactiontype_Internalname = sPrefix+"vCALLTOACTIONTYPE";
         edtavCalltoactionname_Internalname = sPrefix+"vCALLTOACTIONNAME";
         edtavCalltoactionurl_Internalname = sPrefix+"vCALLTOACTIONURL";
         divCalltoactionurl_cell_Internalname = sPrefix+"CALLTOACTIONURL_CELL";
         divTableurl_Internalname = sPrefix+"TABLEURL";
         lblPhonelabel_Internalname = sPrefix+"PHONELABEL";
         Combo_phonecode_Internalname = sPrefix+"COMBO_PHONECODE";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         edtavPhonenumber_Internalname = sPrefix+"vPHONENUMBER";
         divPhonenumber_cell_Internalname = sPrefix+"PHONENUMBER_CELL";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         divUnnamedtable4_Internalname = sPrefix+"UNNAMEDTABLE4";
         divTablephone_Internalname = sPrefix+"TABLEPHONE";
         lblTextblockcombo_locationdynamicformid_Internalname = sPrefix+"TEXTBLOCKCOMBO_LOCATIONDYNAMICFORMID";
         Combo_locationdynamicformid_Internalname = sPrefix+"COMBO_LOCATIONDYNAMICFORMID";
         divTablesplittedlocationdynamicformid_Internalname = sPrefix+"TABLESPLITTEDLOCATIONDYNAMICFORMID";
         divCombo_locationdynamicformid_cell_Internalname = sPrefix+"COMBO_LOCATIONDYNAMICFORMID_CELL";
         divTableform_Internalname = sPrefix+"TABLEFORM";
         edtavCalltoactionemail_Internalname = sPrefix+"vCALLTOACTIONEMAIL";
         divCalltoactionemail_cell_Internalname = sPrefix+"CALLTOACTIONEMAIL_CELL";
         divTableemail_Internalname = sPrefix+"TABLEEMAIL";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         bttBtnuseractionadd_Internalname = sPrefix+"BTNUSERACTIONADD";
         bttBtnuseractioncancel_Internalname = sPrefix+"BTNUSERACTIONCANCEL";
         divTableinsert_Internalname = sPrefix+"TABLEINSERT";
         edtavSdt_calltoaction__calltoactionid_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONID";
         edtavSdt_calltoaction__organisationid_Internalname = sPrefix+"SDT_CALLTOACTION__ORGANISATIONID";
         edtavSdt_calltoaction__locationid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONID";
         edtavSdt_calltoaction__productserviceid_Internalname = sPrefix+"SDT_CALLTOACTION__PRODUCTSERVICEID";
         cmbavSdt_calltoaction__calltoactiontype_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONTYPE";
         edtavSdt_calltoaction__calltoactionname_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONNAME";
         edtavSdt_calltoaction__calltoactionphone_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONE";
         edtavSdt_calltoaction__calltoactionphonecode_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONECODE";
         edtavSdt_calltoaction__calltoactionphonenumber_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONENUMBER";
         edtavSdt_calltoaction__calltoactionurl_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONURL";
         edtavSdt_calltoaction__calltoactionemail_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONEMAIL";
         edtavSdt_calltoaction__locationdynamicformid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONDYNAMICFORMID";
         edtavShortcalltoactionwithtags_Internalname = sPrefix+"vSHORTCALLTOACTIONWITHTAGS";
         edtavShortcalltoaction_Internalname = sPrefix+"vSHORTCALLTOACTION";
         edtavSdt_calltoaction__wwpformreferencename_Internalname = sPrefix+"SDT_CALLTOACTION__WWPFORMREFERENCENAME";
         edtavCalltoactionvariable_Internalname = sPrefix+"vCALLTOACTIONVARIABLE";
         cmbavGridactiongroup1_Internalname = sPrefix+"vGRIDACTIONGROUP1";
         Gridsdt_calltoactionspaginationbar_Internalname = sPrefix+"GRIDSDT_CALLTOACTIONSPAGINATIONBAR";
         divGridsdt_calltoactionstablewithpaginationbar_Internalname = sPrefix+"GRIDSDT_CALLTOACTIONSTABLEWITHPAGINATIONBAR";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavPhonecode_Internalname = sPrefix+"vPHONECODE";
         edtavLocationdynamicformid_Internalname = sPrefix+"vLOCATIONDYNAMICFORMID";
         Popover_shortcalltoaction_Internalname = sPrefix+"POPOVER_SHORTCALLTOACTION";
         edtavCalltoactionid_Internalname = sPrefix+"vCALLTOACTIONID";
         edtavWwpformreferencename_Internalname = sPrefix+"vWWPFORMREFERENCENAME";
         Dvelop_confirmpanel_useractiondelete_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE";
         tblTabledvelop_confirmpanel_useractiondelete_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_USERACTIONDELETE";
         Gridsdt_calltoactions_empowerer_Internalname = sPrefix+"GRIDSDT_CALLTOACTIONS_EMPOWERER";
         divDiv_wwpauxwc_Internalname = sPrefix+"DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridsdt_calltoactions_Internalname = sPrefix+"GRIDSDT_CALLTOACTIONS";
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
         subGridsdt_calltoactions_Allowcollapsing = 0;
         subGridsdt_calltoactions_Allowselection = 0;
         subGridsdt_calltoactions_Header = "";
         cmbavGridactiongroup1_Jsonclick = "";
         edtavCalltoactionvariable_Jsonclick = "";
         edtavCalltoactionvariable_Enabled = 1;
         edtavSdt_calltoaction__wwpformreferencename_Jsonclick = "";
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavShortcalltoaction_Jsonclick = "";
         edtavShortcalltoaction_Enabled = 1;
         edtavShortcalltoactionwithtags_Jsonclick = "";
         edtavShortcalltoactionwithtags_Enabled = 1;
         edtavSdt_calltoaction__locationdynamicformid_Jsonclick = "";
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphonenumber_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionphonenumber_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphonecode_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionphonecode_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype_Jsonclick = "";
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Jsonclick = "";
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         edtavSdt_calltoaction__locationid_Jsonclick = "";
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__organisationid_Jsonclick = "";
         edtavSdt_calltoaction__organisationid_Enabled = 0;
         edtavSdt_calltoaction__calltoactionid_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         subGridsdt_calltoactions_Class = "GridWithPaginationBar WorkWith";
         subGridsdt_calltoactions_Backcolorstyle = 0;
         edtavWwpformreferencename_Jsonclick = "";
         edtavWwpformreferencename_Visible = 1;
         edtavCalltoactionid_Jsonclick = "";
         edtavCalltoactionid_Visible = 1;
         edtavLocationdynamicformid_Jsonclick = "";
         edtavLocationdynamicformid_Visible = 1;
         edtavPhonecode_Jsonclick = "";
         edtavPhonecode_Visible = 1;
         edtavCalltoactionemail_Jsonclick = "";
         edtavCalltoactionemail_Enabled = 1;
         divCalltoactionemail_cell_Class = "col-xs-12 col-sm-6";
         divTableemail_Visible = 1;
         Combo_locationdynamicformid_Caption = "";
         divCombo_locationdynamicformid_cell_Class = "col-xs-12 col-sm-6";
         divTableform_Visible = 1;
         edtavPhonenumber_Jsonclick = "";
         edtavPhonenumber_Enabled = 1;
         divPhonenumber_cell_Class = "col-xs-12";
         Combo_phonecode_Caption = "";
         divTablephone_Visible = 1;
         edtavCalltoactionurl_Jsonclick = "";
         edtavCalltoactionurl_Enabled = 1;
         divCalltoactionurl_cell_Class = "col-xs-12 col-sm-6";
         divTableurl_Visible = 1;
         edtavCalltoactionname_Jsonclick = "";
         edtavCalltoactionname_Invitemessage = "";
         edtavCalltoactionname_Enabled = 1;
         cmbavCalltoactiontype_Jsonclick = "";
         cmbavCalltoactiontype.Enabled = 1;
         divTableinsert_Visible = 1;
         Gridsdt_calltoactions_empowerer_Popoversingrid = "Popover_ShortCallToAction";
         Dvelop_confirmpanel_useractiondelete_Confirmtype = "1";
         Dvelop_confirmpanel_useractiondelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractiondelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractiondelete_Confirmationtext = "Are you sure you want to delete?";
         Dvelop_confirmpanel_useractiondelete_Title = context.GetMessage( "Delete", "");
         Popover_shortcalltoaction_Keepopened = Convert.ToBoolean( 0);
         Popover_shortcalltoaction_Position = "Left";
         Popover_shortcalltoaction_Popoverwidth = 400;
         Popover_shortcalltoaction_Triggerelement = "Value";
         Popover_shortcalltoaction_Trigger = "Click";
         Popover_shortcalltoaction_Isgriditem = Convert.ToBoolean( -1);
         Popover_shortcalltoaction_Iteminternalname = "";
         Gridsdt_calltoactionspaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridsdt_calltoactionspaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridsdt_calltoactionspaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridsdt_calltoactionspaginationbar_Next = "WWP_PagingNextCaption";
         Gridsdt_calltoactionspaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridsdt_calltoactionspaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue = 10;
         Gridsdt_calltoactionspaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridsdt_calltoactionspaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridsdt_calltoactionspaginationbar_Pagingcaptionposition = "Left";
         Gridsdt_calltoactionspaginationbar_Pagingbuttonsposition = "Right";
         Gridsdt_calltoactionspaginationbar_Pagestoshow = 5;
         Gridsdt_calltoactionspaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridsdt_calltoactionspaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridsdt_calltoactionspaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridsdt_calltoactionspaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridsdt_calltoactionspaginationbar_Class = "PaginationBar";
         Combo_locationdynamicformid_Emptyitem = Convert.ToBoolean( 0);
         Combo_locationdynamicformid_Cls = "ExtendedCombo Attribute";
         Combo_phonecode_Htmltemplate = "";
         Combo_phonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_phonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         edtavSdt_calltoaction__wwpformreferencename_Enabled = -1;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = -1;
         edtavSdt_calltoaction__calltoactionemail_Enabled = -1;
         edtavSdt_calltoaction__calltoactionurl_Enabled = -1;
         edtavSdt_calltoaction__calltoactionphonenumber_Enabled = -1;
         edtavSdt_calltoaction__calltoactionphonecode_Enabled = -1;
         edtavSdt_calltoaction__calltoactionphone_Enabled = -1;
         edtavSdt_calltoaction__calltoactionname_Enabled = -1;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = -1;
         edtavSdt_calltoaction__productserviceid_Enabled = -1;
         edtavSdt_calltoaction__locationid_Enabled = -1;
         edtavSdt_calltoaction__organisationid_Enabled = -1;
         edtavSdt_calltoaction__calltoactionid_Enabled = -1;
         subGridsdt_calltoactions_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"AV39CallToActionVariable","fld":"vCALLTOACTIONVARIABLE","hsh":true},{"av":"sPrefix"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"AV67ProductServiceId","fld":"vPRODUCTSERVICEID"},{"av":"A339CallToActionId","fld":"CALLTOACTIONID"},{"av":"A368CallToActionName","fld":"CALLTOACTIONNAME"},{"av":"A342CallToActionPhone","fld":"CALLTOACTIONPHONE"},{"av":"A499CallToActionPhoneCode","fld":"CALLTOACTIONPHONECODE"},{"av":"A500CallToActionPhoneNumber","fld":"CALLTOACTIONPHONENUMBER"},{"av":"A341CallToActionEmail","fld":"CALLTOACTIONEMAIL"},{"av":"A340CallToActionType","fld":"CALLTOACTIONTYPE"},{"av":"A367CallToActionUrl","fld":"CALLTOACTIONURL"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":98,"hsh":true},{"av":"nGXsfl_98_idx","ctrl":"GRID","prop":"GridCurrRow","grid":98},{"av":"nRC_GXsfl_98","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":98}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":98,"hsh":true},{"av":"nGXsfl_98_idx","ctrl":"GRID","prop":"GridCurrRow","grid":98},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_98","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":98},{"av":"AV70GridSDT_CallToActionsCurrentPage","fld":"vGRIDSDT_CALLTOACTIONSCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV71GridSDT_CallToActionsPageCount","fld":"vGRIDSDT_CALLTOACTIONSPAGECOUNT","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS.LOAD","""{"handler":"E206G2","iparms":[{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":98,"hsh":true},{"av":"nGXsfl_98_idx","ctrl":"GRID","prop":"GridCurrRow","grid":98},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_98","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":98},{"av":"AV39CallToActionVariable","fld":"vCALLTOACTIONVARIABLE","hsh":true}]""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS.LOAD",""","oparms":[{"av":"AV39CallToActionVariable","fld":"vCALLTOACTIONVARIABLE","hsh":true},{"av":"AV84ShortCallToAction","fld":"vSHORTCALLTOACTION"},{"av":"cmbavGridactiongroup1"},{"av":"AV76GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"AV85ShortCallToActionWithTags","fld":"vSHORTCALLTOACTIONWITHTAGS"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONSPAGINATIONBAR.CHANGEPAGE","""{"handler":"E146G2","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"AV67ProductServiceId","fld":"vPRODUCTSERVICEID"},{"av":"A339CallToActionId","fld":"CALLTOACTIONID"},{"av":"A368CallToActionName","fld":"CALLTOACTIONNAME"},{"av":"A342CallToActionPhone","fld":"CALLTOACTIONPHONE"},{"av":"A499CallToActionPhoneCode","fld":"CALLTOACTIONPHONECODE"},{"av":"A500CallToActionPhoneNumber","fld":"CALLTOACTIONPHONENUMBER"},{"av":"A341CallToActionEmail","fld":"CALLTOACTIONEMAIL"},{"av":"A340CallToActionType","fld":"CALLTOACTIONTYPE"},{"av":"A367CallToActionUrl","fld":"CALLTOACTIONURL"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":98,"hsh":true},{"av":"nGXsfl_98_idx","ctrl":"GRID","prop":"GridCurrRow","grid":98},{"av":"nRC_GXsfl_98","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":98},{"av":"AV39CallToActionVariable","fld":"vCALLTOACTIONVARIABLE","hsh":true},{"av":"sPrefix"},{"av":"Gridsdt_calltoactionspaginationbar_Selectedpage","ctrl":"GRIDSDT_CALLTOACTIONSPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONSPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E156G2","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"AV67ProductServiceId","fld":"vPRODUCTSERVICEID"},{"av":"A339CallToActionId","fld":"CALLTOACTIONID"},{"av":"A368CallToActionName","fld":"CALLTOACTIONNAME"},{"av":"A342CallToActionPhone","fld":"CALLTOACTIONPHONE"},{"av":"A499CallToActionPhoneCode","fld":"CALLTOACTIONPHONECODE"},{"av":"A500CallToActionPhoneNumber","fld":"CALLTOACTIONPHONENUMBER"},{"av":"A341CallToActionEmail","fld":"CALLTOACTIONEMAIL"},{"av":"A340CallToActionType","fld":"CALLTOACTIONTYPE"},{"av":"A367CallToActionUrl","fld":"CALLTOACTIONURL"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":98,"hsh":true},{"av":"nGXsfl_98_idx","ctrl":"GRID","prop":"GridCurrRow","grid":98},{"av":"nRC_GXsfl_98","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":98},{"av":"AV39CallToActionVariable","fld":"vCALLTOACTIONVARIABLE","hsh":true},{"av":"sPrefix"},{"av":"Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDSDT_CALLTOACTIONSPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDSDT_CALLTOACTIONSPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"}]}""");
         setEventMetadata("'DOUSERACTIONINSERT'","""{"handler":"E116G1","iparms":[]""");
         setEventMetadata("'DOUSERACTIONINSERT'",""","oparms":[{"av":"divTableinsert_Visible","ctrl":"TABLEINSERT","prop":"Visible"}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E216G2","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV76GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":98,"hsh":true},{"av":"nGXsfl_98_idx","ctrl":"GRID","prop":"GridCurrRow","grid":98},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_98","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":98},{"av":"AV54WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME"},{"av":"cmbavCalltoactiontype"},{"av":"AV52CallToActionType","fld":"vCALLTOACTIONTYPE"}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV76GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"divTableinsert_Visible","ctrl":"TABLEINSERT","prop":"Visible"},{"av":"AV51CallToActionId","fld":"vCALLTOACTIONID"},{"av":"AV53CallToActionName","fld":"vCALLTOACTIONNAME"},{"av":"AV79PhoneCode","fld":"vPHONECODE"},{"av":"Combo_phonecode_Selectedtext_set","ctrl":"COMBO_PHONECODE","prop":"SelectedText_set"},{"av":"Combo_phonecode_Selectedvalue_set","ctrl":"COMBO_PHONECODE","prop":"SelectedValue_set"},{"av":"AV78PhoneNumber","fld":"vPHONENUMBER"},{"av":"AV58CallToActionUrl","fld":"vCALLTOACTIONURL"},{"av":"AV56LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"},{"av":"AV55CallToActionEmail","fld":"vCALLTOACTIONEMAIL"},{"av":"cmbavCalltoactiontype"},{"av":"AV52CallToActionType","fld":"vCALLTOACTIONTYPE"},{"av":"Combo_locationdynamicformid_Selectedtext_set","ctrl":"COMBO_LOCATIONDYNAMICFORMID","prop":"SelectedText_set"},{"av":"Combo_locationdynamicformid_Selectedvalue_set","ctrl":"COMBO_LOCATIONDYNAMICFORMID","prop":"SelectedValue_set"},{"av":"edtavCalltoactionname_Invitemessage","ctrl":"vCALLTOACTIONNAME","prop":"Invitemessage"},{"av":"divTableurl_Visible","ctrl":"TABLEURL","prop":"Visible"},{"av":"divTableemail_Visible","ctrl":"TABLEEMAIL","prop":"Visible"},{"av":"divTableform_Visible","ctrl":"TABLEFORM","prop":"Visible"},{"av":"divTablephone_Visible","ctrl":"TABLEPHONE","prop":"Visible"},{"av":"AV54WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE","""{"handler":"E166G2","iparms":[{"av":"Dvelop_confirmpanel_useractiondelete_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONDELETE","prop":"Result"},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"AV67ProductServiceId","fld":"vPRODUCTSERVICEID"},{"av":"A339CallToActionId","fld":"CALLTOACTIONID"},{"av":"A368CallToActionName","fld":"CALLTOACTIONNAME"},{"av":"A342CallToActionPhone","fld":"CALLTOACTIONPHONE"},{"av":"A499CallToActionPhoneCode","fld":"CALLTOACTIONPHONECODE"},{"av":"A500CallToActionPhoneNumber","fld":"CALLTOACTIONPHONENUMBER"},{"av":"A341CallToActionEmail","fld":"CALLTOACTIONEMAIL"},{"av":"A340CallToActionType","fld":"CALLTOACTIONTYPE"},{"av":"A367CallToActionUrl","fld":"CALLTOACTIONURL"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":98,"hsh":true},{"av":"nGXsfl_98_idx","ctrl":"GRID","prop":"GridCurrRow","grid":98},{"av":"nRC_GXsfl_98","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":98},{"av":"AV39CallToActionVariable","fld":"vCALLTOACTIONVARIABLE","hsh":true},{"av":"sPrefix"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE",""","oparms":[{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":98,"hsh":true},{"av":"nGXsfl_98_idx","ctrl":"GRID","prop":"GridCurrRow","grid":98},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_98","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":98},{"av":"AV70GridSDT_CallToActionsCurrentPage","fld":"vGRIDSDT_CALLTOACTIONSCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV71GridSDT_CallToActionsPageCount","fld":"vGRIDSDT_CALLTOACTIONSPAGECOUNT","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("'DOUSERACTIONADD'","""{"handler":"E176G2","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"AV67ProductServiceId","fld":"vPRODUCTSERVICEID"},{"av":"A339CallToActionId","fld":"CALLTOACTIONID"},{"av":"A368CallToActionName","fld":"CALLTOACTIONNAME"},{"av":"A342CallToActionPhone","fld":"CALLTOACTIONPHONE"},{"av":"A499CallToActionPhoneCode","fld":"CALLTOACTIONPHONECODE"},{"av":"A500CallToActionPhoneNumber","fld":"CALLTOACTIONPHONENUMBER"},{"av":"A341CallToActionEmail","fld":"CALLTOACTIONEMAIL"},{"av":"A340CallToActionType","fld":"CALLTOACTIONTYPE"},{"av":"A367CallToActionUrl","fld":"CALLTOACTIONURL"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":98,"hsh":true},{"av":"nGXsfl_98_idx","ctrl":"GRID","prop":"GridCurrRow","grid":98},{"av":"nRC_GXsfl_98","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":98},{"av":"AV39CallToActionVariable","fld":"vCALLTOACTIONVARIABLE","hsh":true},{"av":"sPrefix"},{"av":"AV77CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"cmbavCalltoactiontype"},{"av":"AV52CallToActionType","fld":"vCALLTOACTIONTYPE"},{"av":"AV51CallToActionId","fld":"vCALLTOACTIONID"},{"av":"AV53CallToActionName","fld":"vCALLTOACTIONNAME"},{"av":"AV55CallToActionEmail","fld":"vCALLTOACTIONEMAIL"},{"av":"AV78PhoneNumber","fld":"vPHONENUMBER"},{"av":"AV79PhoneCode","fld":"vPHONECODE"},{"av":"AV58CallToActionUrl","fld":"vCALLTOACTIONURL"},{"av":"AV65OrganisationId","fld":"vORGANISATIONID"},{"av":"AV66LocationId","fld":"vLOCATIONID"},{"av":"AV56LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"},{"av":"Combo_locationdynamicformid_Ddointernalname","ctrl":"COMBO_LOCATIONDYNAMICFORMID","prop":"DDOInternalName"}]""");
         setEventMetadata("'DOUSERACTIONADD'",""","oparms":[{"av":"AV77CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV51CallToActionId","fld":"vCALLTOACTIONID"},{"av":"AV53CallToActionName","fld":"vCALLTOACTIONNAME"},{"av":"AV78PhoneNumber","fld":"vPHONENUMBER"},{"av":"AV58CallToActionUrl","fld":"vCALLTOACTIONURL"},{"av":"AV56LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"},{"av":"Combo_locationdynamicformid_Selectedtext_set","ctrl":"COMBO_LOCATIONDYNAMICFORMID","prop":"SelectedText_set"},{"av":"Combo_locationdynamicformid_Selectedvalue_set","ctrl":"COMBO_LOCATIONDYNAMICFORMID","prop":"SelectedValue_set"},{"av":"AV55CallToActionEmail","fld":"vCALLTOACTIONEMAIL"},{"av":"AV68SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":98,"hsh":true},{"av":"nGXsfl_98_idx","ctrl":"GRID","prop":"GridCurrRow","grid":98},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_98","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":98},{"av":"AV70GridSDT_CallToActionsCurrentPage","fld":"vGRIDSDT_CALLTOACTIONSCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV71GridSDT_CallToActionsPageCount","fld":"vGRIDSDT_CALLTOACTIONSPAGECOUNT","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("'DOUSERACTIONCANCEL'","""{"handler":"E126G1","iparms":[{"av":"cmbavCalltoactiontype"},{"av":"AV52CallToActionType","fld":"vCALLTOACTIONTYPE"}]""");
         setEventMetadata("'DOUSERACTIONCANCEL'",""","oparms":[{"av":"divTableinsert_Visible","ctrl":"TABLEINSERT","prop":"Visible"},{"av":"AV51CallToActionId","fld":"vCALLTOACTIONID"},{"av":"AV53CallToActionName","fld":"vCALLTOACTIONNAME"},{"av":"AV78PhoneNumber","fld":"vPHONENUMBER"},{"av":"AV58CallToActionUrl","fld":"vCALLTOACTIONURL"},{"av":"AV56LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"},{"av":"Combo_locationdynamicformid_Selectedtext_set","ctrl":"COMBO_LOCATIONDYNAMICFORMID","prop":"SelectedText_set"},{"av":"Combo_locationdynamicformid_Selectedvalue_set","ctrl":"COMBO_LOCATIONDYNAMICFORMID","prop":"SelectedValue_set"},{"av":"AV55CallToActionEmail","fld":"vCALLTOACTIONEMAIL"}]}""");
         setEventMetadata("VSHORTCALLTOACTION.CLICK","""{"handler":"E226G2","iparms":[{"av":"AV39CallToActionVariable","fld":"vCALLTOACTIONVARIABLE","hsh":true}]""");
         setEventMetadata("VSHORTCALLTOACTION.CLICK",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("COMBO_LOCATIONDYNAMICFORMID.ONOPTIONCLICKED","""{"handler":"E136G2","iparms":[{"av":"Combo_locationdynamicformid_Selectedvalue_get","ctrl":"COMBO_LOCATIONDYNAMICFORMID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_LOCATIONDYNAMICFORMID.ONOPTIONCLICKED",""","oparms":[{"av":"AV56LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"}]}""");
         setEventMetadata("VALIDV_CALLTOACTIONTYPE","""{"handler":"Validv_Calltoactiontype","iparms":[]}""");
         setEventMetadata("VALIDV_CALLTOACTIONURL","""{"handler":"Validv_Calltoactionurl","iparms":[]}""");
         setEventMetadata("VALIDV_CALLTOACTIONEMAIL","""{"handler":"Validv_Calltoactionemail","iparms":[]}""");
         setEventMetadata("VALIDV_LOCATIONDYNAMICFORMID","""{"handler":"Validv_Locationdynamicformid","iparms":[]}""");
         setEventMetadata("VALIDV_CALLTOACTIONID","""{"handler":"Validv_Calltoactionid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
         setEventMetadata("VALIDV_GXV11","""{"handler":"Validv_Gxv11","iparms":[]}""");
         setEventMetadata("VALIDV_GXV12","""{"handler":"Validv_Gxv12","iparms":[]}""");
         setEventMetadata("VALIDV_GXV13","""{"handler":"Validv_Gxv13","iparms":[]}""");
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

      public override void initialize( )
      {
         wcpOAV65OrganisationId = Guid.Empty;
         wcpOAV66LocationId = Guid.Empty;
         wcpOAV67ProductServiceId = Guid.Empty;
         Gridsdt_calltoactionspaginationbar_Selectedpage = "";
         Dvelop_confirmpanel_useractiondelete_Result = "";
         Combo_locationdynamicformid_Ddointernalname = "";
         Combo_locationdynamicformid_Selectedvalue_get = "";
         Combo_phonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         A58ProductServiceId = Guid.Empty;
         A339CallToActionId = Guid.Empty;
         A368CallToActionName = "";
         A342CallToActionPhone = "";
         A499CallToActionPhoneCode = "";
         A500CallToActionPhoneNumber = "";
         A341CallToActionEmail = "";
         A340CallToActionType = "";
         A367CallToActionUrl = "";
         A366LocationDynamicFormId = Guid.Empty;
         A208WWPFormReferenceName = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV68SDT_CallToAction = new GXBaseCollection<SdtSDT_CallToAction_SDT_CallToActionItem>( context, "SDT_CallToActionItem", "Comforta_version2");
         AV39CallToActionVariable = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV32DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV81PhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV59LocationDynamicFormId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV72GridSDT_CallToActionsAppliedFilters = "";
         AV57CallToActionPhone = "";
         Combo_phonecode_Selectedvalue_set = "";
         Combo_phonecode_Selectedtext_set = "";
         Combo_locationdynamicformid_Selectedvalue_set = "";
         Combo_locationdynamicformid_Selectedtext_set = "";
         Popover_shortcalltoaction_Gridinternalname = "";
         Gridsdt_calltoactions_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnuseractioninsert_Jsonclick = "";
         AV52CallToActionType = "";
         AV53CallToActionName = "";
         AV58CallToActionUrl = "";
         lblPhonelabel_Jsonclick = "";
         ucCombo_phonecode = new GXUserControl();
         AV78PhoneNumber = "";
         lblTextblockcombo_locationdynamicformid_Jsonclick = "";
         ucCombo_locationdynamicformid = new GXUserControl();
         AV55CallToActionEmail = "";
         bttBtnuseractionadd_Jsonclick = "";
         bttBtnuseractioncancel_Jsonclick = "";
         Gridsdt_calltoactionsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridsdt_calltoactionspaginationbar = new GXUserControl();
         AV79PhoneCode = "";
         AV56LocationDynamicFormId = Guid.Empty;
         ucPopover_shortcalltoaction = new GXUserControl();
         AV51CallToActionId = Guid.Empty;
         AV54WWPFormReferenceName = "";
         ucGridsdt_calltoactions_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV85ShortCallToActionWithTags = "";
         AV84ShortCallToAction = "";
         GXDecQS = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         H006G2_A206WWPFormId = new short[1] ;
         H006G2_A207WWPFormVersionNumber = new short[1] ;
         H006G2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H006G2_A339CallToActionId = new Guid[] {Guid.Empty} ;
         H006G2_A368CallToActionName = new string[] {""} ;
         H006G2_A342CallToActionPhone = new string[] {""} ;
         H006G2_A499CallToActionPhoneCode = new string[] {""} ;
         H006G2_A500CallToActionPhoneNumber = new string[] {""} ;
         H006G2_A341CallToActionEmail = new string[] {""} ;
         H006G2_A340CallToActionType = new string[] {""} ;
         H006G2_A367CallToActionUrl = new string[] {""} ;
         H006G2_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         H006G2_n366LocationDynamicFormId = new bool[] {false} ;
         H006G2_A208WWPFormReferenceName = new string[] {""} ;
         H006G2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H006G2_A29LocationId = new Guid[] {Guid.Empty} ;
         AV74GridSDT_CallToAction = new SdtSDT_CallToAction_SDT_CallToActionItem(context);
         Gridsdt_calltoactionsRow = new GXWebRow();
         AV62Trn_CallToAction = new SdtTrn_CallToAction(context);
         GXt_char2 = "";
         AV101GXV15 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV42Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV103GXV17 = new GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem>( context, "SDT_LocationDynamicFormItem", "Comforta_version2");
         GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem3 = new GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem>( context, "SDT_LocationDynamicFormItem", "Comforta_version2");
         AV61LocationDynamicFormId_DPItem = new SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem(context);
         AV60Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV105GXV19 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem4 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV82PhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV80ComboTitles = new GxSimpleCollection<string>();
         ucDvelop_confirmpanel_useractiondelete = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV65OrganisationId = "";
         sCtrlAV66LocationId = "";
         sCtrlAV67ProductServiceId = "";
         subGridsdt_calltoactions_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         Gridsdt_calltoactionsColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wc_calltoaction__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wc_calltoaction__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wc_calltoaction__default(),
            new Object[][] {
                new Object[] {
               H006G2_A206WWPFormId, H006G2_A207WWPFormVersionNumber, H006G2_A58ProductServiceId, H006G2_A339CallToActionId, H006G2_A368CallToActionName, H006G2_A342CallToActionPhone, H006G2_A499CallToActionPhoneCode, H006G2_A500CallToActionPhoneNumber, H006G2_A341CallToActionEmail, H006G2_A340CallToActionType,
               H006G2_A367CallToActionUrl, H006G2_A366LocationDynamicFormId, H006G2_n366LocationDynamicFormId, H006G2_A208WWPFormReferenceName, H006G2_A11OrganisationId, H006G2_A29LocationId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         edtavSdt_calltoaction__organisationid_Enabled = 0;
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphonecode_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphonenumber_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavShortcalltoactionwithtags_Enabled = 0;
         edtavShortcalltoaction_Enabled = 0;
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavCalltoactionvariable_Enabled = 0;
      }

      private short GRIDSDT_CALLTOACTIONS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV76GridActionGroup1 ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGridsdt_calltoactions_Backcolorstyle ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short nGXWrapped ;
      private short subGridsdt_calltoactions_Backstyle ;
      private short subGridsdt_calltoactions_Titlebackstyle ;
      private short subGridsdt_calltoactions_Allowselection ;
      private short subGridsdt_calltoactions_Allowhovering ;
      private short subGridsdt_calltoactions_Allowcollapsing ;
      private short subGridsdt_calltoactions_Collapsed ;
      private int Gridsdt_calltoactionspaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_98 ;
      private int subGridsdt_calltoactions_Rows ;
      private int nGXsfl_98_idx=1 ;
      private int edtavSdt_calltoaction__calltoactionid_Enabled ;
      private int edtavSdt_calltoaction__organisationid_Enabled ;
      private int edtavSdt_calltoaction__locationid_Enabled ;
      private int edtavSdt_calltoaction__productserviceid_Enabled ;
      private int edtavSdt_calltoaction__calltoactionname_Enabled ;
      private int edtavSdt_calltoaction__calltoactionphone_Enabled ;
      private int edtavSdt_calltoaction__calltoactionphonecode_Enabled ;
      private int edtavSdt_calltoaction__calltoactionphonenumber_Enabled ;
      private int edtavSdt_calltoaction__calltoactionurl_Enabled ;
      private int edtavSdt_calltoaction__calltoactionemail_Enabled ;
      private int edtavSdt_calltoaction__locationdynamicformid_Enabled ;
      private int edtavShortcalltoactionwithtags_Enabled ;
      private int edtavShortcalltoaction_Enabled ;
      private int edtavSdt_calltoaction__wwpformreferencename_Enabled ;
      private int edtavCalltoactionvariable_Enabled ;
      private int Gridsdt_calltoactionspaginationbar_Pagestoshow ;
      private int Popover_shortcalltoaction_Popoverwidth ;
      private int divTableinsert_Visible ;
      private int edtavCalltoactionname_Enabled ;
      private int divTableurl_Visible ;
      private int edtavCalltoactionurl_Enabled ;
      private int divTablephone_Visible ;
      private int edtavPhonenumber_Enabled ;
      private int divTableform_Visible ;
      private int divTableemail_Visible ;
      private int edtavCalltoactionemail_Enabled ;
      private int AV86GXV1 ;
      private int edtavPhonecode_Visible ;
      private int edtavLocationdynamicformid_Visible ;
      private int edtavCalltoactionid_Visible ;
      private int edtavWwpformreferencename_Visible ;
      private int subGridsdt_calltoactions_Islastpage ;
      private int GRIDSDT_CALLTOACTIONS_nGridOutOfScope ;
      private int nGXsfl_98_fel_idx=1 ;
      private int AV69PageToGo ;
      private int nGXsfl_98_bak_idx=1 ;
      private int AV102GXV16 ;
      private int AV104GXV18 ;
      private int AV106GXV20 ;
      private int idxLst ;
      private int subGridsdt_calltoactions_Backcolor ;
      private int subGridsdt_calltoactions_Allbackcolor ;
      private int subGridsdt_calltoactions_Titlebackcolor ;
      private int subGridsdt_calltoactions_Selectedindex ;
      private int subGridsdt_calltoactions_Selectioncolor ;
      private int subGridsdt_calltoactions_Hoveringcolor ;
      private long GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage ;
      private long AV70GridSDT_CallToActionsCurrentPage ;
      private long AV71GridSDT_CallToActionsPageCount ;
      private long GRIDSDT_CALLTOACTIONS_nCurrentRecord ;
      private long GRIDSDT_CALLTOACTIONS_nRecordCount ;
      private string Gridsdt_calltoactionspaginationbar_Selectedpage ;
      private string Dvelop_confirmpanel_useractiondelete_Result ;
      private string Combo_locationdynamicformid_Ddointernalname ;
      private string Combo_locationdynamicformid_Selectedvalue_get ;
      private string Combo_phonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_98_idx="0001" ;
      private string A342CallToActionPhone ;
      private string edtavSdt_calltoaction__calltoactionid_Internalname ;
      private string edtavSdt_calltoaction__organisationid_Internalname ;
      private string edtavSdt_calltoaction__locationid_Internalname ;
      private string edtavSdt_calltoaction__productserviceid_Internalname ;
      private string cmbavSdt_calltoaction__calltoactiontype_Internalname ;
      private string edtavSdt_calltoaction__calltoactionname_Internalname ;
      private string edtavSdt_calltoaction__calltoactionphone_Internalname ;
      private string edtavSdt_calltoaction__calltoactionphonecode_Internalname ;
      private string edtavSdt_calltoaction__calltoactionphonenumber_Internalname ;
      private string edtavSdt_calltoaction__calltoactionurl_Internalname ;
      private string edtavSdt_calltoaction__calltoactionemail_Internalname ;
      private string edtavSdt_calltoaction__locationdynamicformid_Internalname ;
      private string edtavShortcalltoactionwithtags_Internalname ;
      private string edtavShortcalltoaction_Internalname ;
      private string edtavSdt_calltoaction__wwpformreferencename_Internalname ;
      private string edtavCalltoactionvariable_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV57CallToActionPhone ;
      private string Combo_phonecode_Cls ;
      private string Combo_phonecode_Selectedvalue_set ;
      private string Combo_phonecode_Selectedtext_set ;
      private string Combo_phonecode_Htmltemplate ;
      private string Combo_locationdynamicformid_Cls ;
      private string Combo_locationdynamicformid_Selectedvalue_set ;
      private string Combo_locationdynamicformid_Selectedtext_set ;
      private string Gridsdt_calltoactionspaginationbar_Class ;
      private string Gridsdt_calltoactionspaginationbar_Pagingbuttonsposition ;
      private string Gridsdt_calltoactionspaginationbar_Pagingcaptionposition ;
      private string Gridsdt_calltoactionspaginationbar_Emptygridclass ;
      private string Gridsdt_calltoactionspaginationbar_Rowsperpageoptions ;
      private string Gridsdt_calltoactionspaginationbar_Previous ;
      private string Gridsdt_calltoactionspaginationbar_Next ;
      private string Gridsdt_calltoactionspaginationbar_Caption ;
      private string Gridsdt_calltoactionspaginationbar_Emptygridcaption ;
      private string Gridsdt_calltoactionspaginationbar_Rowsperpagecaption ;
      private string Popover_shortcalltoaction_Gridinternalname ;
      private string Popover_shortcalltoaction_Iteminternalname ;
      private string Popover_shortcalltoaction_Trigger ;
      private string Popover_shortcalltoaction_Triggerelement ;
      private string Popover_shortcalltoaction_Position ;
      private string Dvelop_confirmpanel_useractiondelete_Title ;
      private string Dvelop_confirmpanel_useractiondelete_Confirmationtext ;
      private string Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useractiondelete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useractiondelete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useractiondelete_Confirmtype ;
      private string Gridsdt_calltoactions_empowerer_Gridinternalname ;
      private string Gridsdt_calltoactions_empowerer_Popoversingrid ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string TempTags ;
      private string bttBtnuseractioninsert_Internalname ;
      private string bttBtnuseractioninsert_Jsonclick ;
      private string divTableinsert_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTableattributes_Internalname ;
      private string cmbavCalltoactiontype_Internalname ;
      private string cmbavCalltoactiontype_Jsonclick ;
      private string edtavCalltoactionname_Internalname ;
      private string edtavCalltoactionname_Invitemessage ;
      private string edtavCalltoactionname_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string divTableurl_Internalname ;
      private string divCalltoactionurl_cell_Internalname ;
      private string divCalltoactionurl_cell_Class ;
      private string edtavCalltoactionurl_Internalname ;
      private string edtavCalltoactionurl_Jsonclick ;
      private string divTablephone_Internalname ;
      private string lblPhonelabel_Internalname ;
      private string lblPhonelabel_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string divUnnamedtable5_Internalname ;
      private string Combo_phonecode_Caption ;
      private string Combo_phonecode_Internalname ;
      private string divUnnamedtable6_Internalname ;
      private string divPhonenumber_cell_Internalname ;
      private string divPhonenumber_cell_Class ;
      private string edtavPhonenumber_Internalname ;
      private string edtavPhonenumber_Jsonclick ;
      private string divTableform_Internalname ;
      private string divCombo_locationdynamicformid_cell_Internalname ;
      private string divCombo_locationdynamicformid_cell_Class ;
      private string divTablesplittedlocationdynamicformid_Internalname ;
      private string lblTextblockcombo_locationdynamicformid_Internalname ;
      private string lblTextblockcombo_locationdynamicformid_Jsonclick ;
      private string Combo_locationdynamicformid_Caption ;
      private string Combo_locationdynamicformid_Internalname ;
      private string divTableemail_Internalname ;
      private string divCalltoactionemail_cell_Internalname ;
      private string divCalltoactionemail_cell_Class ;
      private string edtavCalltoactionemail_Internalname ;
      private string edtavCalltoactionemail_Jsonclick ;
      private string bttBtnuseractionadd_Internalname ;
      private string bttBtnuseractionadd_Jsonclick ;
      private string bttBtnuseractioncancel_Internalname ;
      private string bttBtnuseractioncancel_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string divGridsdt_calltoactionstablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGridsdt_calltoactions_Internalname ;
      private string Gridsdt_calltoactionspaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavPhonecode_Internalname ;
      private string edtavPhonecode_Jsonclick ;
      private string edtavLocationdynamicformid_Internalname ;
      private string edtavLocationdynamicformid_Jsonclick ;
      private string Popover_shortcalltoaction_Internalname ;
      private string edtavCalltoactionid_Internalname ;
      private string edtavCalltoactionid_Jsonclick ;
      private string edtavWwpformreferencename_Internalname ;
      private string edtavWwpformreferencename_Jsonclick ;
      private string Gridsdt_calltoactions_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactiongroup1_Internalname ;
      private string GXDecQS ;
      private string sGXsfl_98_fel_idx="0001" ;
      private string GXt_char2 ;
      private string tblTabledvelop_confirmpanel_useractiondelete_Internalname ;
      private string Dvelop_confirmpanel_useractiondelete_Internalname ;
      private string sCtrlAV65OrganisationId ;
      private string sCtrlAV66LocationId ;
      private string sCtrlAV67ProductServiceId ;
      private string subGridsdt_calltoactions_Class ;
      private string subGridsdt_calltoactions_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_calltoaction__calltoactionid_Jsonclick ;
      private string edtavSdt_calltoaction__organisationid_Jsonclick ;
      private string edtavSdt_calltoaction__locationid_Jsonclick ;
      private string edtavSdt_calltoaction__productserviceid_Jsonclick ;
      private string GXCCtl ;
      private string cmbavSdt_calltoaction__calltoactiontype_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionname_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionphone_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionphonecode_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionphonenumber_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionurl_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionemail_Jsonclick ;
      private string edtavSdt_calltoaction__locationdynamicformid_Jsonclick ;
      private string edtavShortcalltoactionwithtags_Jsonclick ;
      private string edtavShortcalltoaction_Jsonclick ;
      private string edtavSdt_calltoaction__wwpformreferencename_Jsonclick ;
      private string edtavCalltoactionvariable_Jsonclick ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string subGridsdt_calltoactions_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n366LocationDynamicFormId ;
      private bool bGXsfl_98_Refreshing=false ;
      private bool AV77CheckRequiredFieldsResult ;
      private bool Combo_phonecode_Emptyitem ;
      private bool Combo_locationdynamicformid_Emptyitem ;
      private bool Gridsdt_calltoactionspaginationbar_Showfirst ;
      private bool Gridsdt_calltoactionspaginationbar_Showprevious ;
      private bool Gridsdt_calltoactionspaginationbar_Shownext ;
      private bool Gridsdt_calltoactionspaginationbar_Showlast ;
      private bool Gridsdt_calltoactionspaginationbar_Rowsperpageselector ;
      private bool Popover_shortcalltoaction_Isgriditem ;
      private bool Popover_shortcalltoaction_Keepopened ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool gx_BV98 ;
      private bool bDynCreated_Wwpaux_wc ;
      private string A368CallToActionName ;
      private string A499CallToActionPhoneCode ;
      private string A500CallToActionPhoneNumber ;
      private string A341CallToActionEmail ;
      private string A340CallToActionType ;
      private string A367CallToActionUrl ;
      private string A208WWPFormReferenceName ;
      private string AV39CallToActionVariable ;
      private string AV72GridSDT_CallToActionsAppliedFilters ;
      private string AV52CallToActionType ;
      private string AV53CallToActionName ;
      private string AV58CallToActionUrl ;
      private string AV78PhoneNumber ;
      private string AV55CallToActionEmail ;
      private string AV79PhoneCode ;
      private string AV54WWPFormReferenceName ;
      private string AV85ShortCallToActionWithTags ;
      private string AV84ShortCallToAction ;
      private Guid AV65OrganisationId ;
      private Guid AV66LocationId ;
      private Guid AV67ProductServiceId ;
      private Guid wcpOAV65OrganisationId ;
      private Guid wcpOAV66LocationId ;
      private Guid wcpOAV67ProductServiceId ;
      private Guid A58ProductServiceId ;
      private Guid A339CallToActionId ;
      private Guid A366LocationDynamicFormId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid AV56LocationDynamicFormId ;
      private Guid AV51CallToActionId ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid Gridsdt_calltoactionsContainer ;
      private GXWebRow Gridsdt_calltoactionsRow ;
      private GXWebColumn Gridsdt_calltoactionsColumn ;
      private GXUserControl ucCombo_phonecode ;
      private GXUserControl ucCombo_locationdynamicformid ;
      private GXUserControl ucGridsdt_calltoactionspaginationbar ;
      private GXUserControl ucPopover_shortcalltoaction ;
      private GXUserControl ucGridsdt_calltoactions_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_useractiondelete ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCalltoactiontype ;
      private GXCombobox cmbavSdt_calltoaction__calltoactiontype ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXBaseCollection<SdtSDT_CallToAction_SDT_CallToActionItem> AV68SDT_CallToAction ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV32DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV81PhoneCode_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV59LocationDynamicFormId_Data ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private IDataStoreProvider pr_default ;
      private short[] H006G2_A206WWPFormId ;
      private short[] H006G2_A207WWPFormVersionNumber ;
      private Guid[] H006G2_A58ProductServiceId ;
      private Guid[] H006G2_A339CallToActionId ;
      private string[] H006G2_A368CallToActionName ;
      private string[] H006G2_A342CallToActionPhone ;
      private string[] H006G2_A499CallToActionPhoneCode ;
      private string[] H006G2_A500CallToActionPhoneNumber ;
      private string[] H006G2_A341CallToActionEmail ;
      private string[] H006G2_A340CallToActionType ;
      private string[] H006G2_A367CallToActionUrl ;
      private Guid[] H006G2_A366LocationDynamicFormId ;
      private bool[] H006G2_n366LocationDynamicFormId ;
      private string[] H006G2_A208WWPFormReferenceName ;
      private Guid[] H006G2_A11OrganisationId ;
      private Guid[] H006G2_A29LocationId ;
      private SdtSDT_CallToAction_SDT_CallToActionItem AV74GridSDT_CallToAction ;
      private SdtTrn_CallToAction AV62Trn_CallToAction ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV101GXV15 ;
      private GeneXus.Utils.SdtMessages_Message AV42Message ;
      private GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem> AV103GXV17 ;
      private GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem> GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem3 ;
      private SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem AV61LocationDynamicFormId_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV60Combo_DataItem ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV105GXV19 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem4 ;
      private SdtSDT_Country_SDT_CountryItem AV82PhoneCode_DPItem ;
      private GxSimpleCollection<string> AV80ComboTitles ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wc_calltoaction__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wc_calltoaction__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wc_calltoaction__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmH006G2;
       prmH006G2 = new Object[] {
       new ParDef("AV67ProductServiceId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("H006G2", "SELECT T2.WWPFormId, T2.WWPFormVersionNumber, T1.ProductServiceId, T1.CallToActionId, T1.CallToActionName, T1.CallToActionPhone, T1.CallToActionPhoneCode, T1.CallToActionPhoneNumber, T1.CallToActionEmail, T1.CallToActionType, T1.CallToActionUrl, T1.LocationDynamicFormId, T3.WWPFormReferenceName, T1.OrganisationId, T1.LocationId FROM ((Trn_CallToAction T1 LEFT JOIN Trn_LocationDynamicForm T2 ON T2.LocationDynamicFormId = T1.LocationDynamicFormId AND T2.OrganisationId = T1.OrganisationId AND T2.LocationId = T1.LocationId) LEFT JOIN WWP_Form T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber) WHERE T1.ProductServiceId = :AV67ProductServiceId ORDER BY T1.ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006G2,100, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((string[]) buf[13])[0] = rslt.getVarchar(13);
             ((Guid[]) buf[14])[0] = rslt.getGuid(14);
             ((Guid[]) buf[15])[0] = rslt.getGuid(15);
             return;
    }
 }

}

}
