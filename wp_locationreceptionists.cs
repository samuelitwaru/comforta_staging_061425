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
   public class wp_locationreceptionists : GXDataArea
   {
      public wp_locationreceptionists( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_locationreceptionists( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Message )
      {
         this.AV51Message = "" ;
         ExecuteImpl();
         aP0_Message=this.AV51Message;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavLocationoption = new GXCombobox();
         cmbavActiongroup = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Message");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vLOCATIONOPTION") == 0 )
            {
               ajax_req_read_hidden_sdt(GetNextPar( ), AV6WWPContext);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvLOCATIONOPTION5Z2( AV6WWPContext) ;
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
               gxfirstwebparm = GetFirstPar( "Message");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Message");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_45 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_45"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_45_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_45_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_45_idx = GetPar( "sGXsfl_45_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV19ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV40ColumnsSelector);
         AV91Pgmname = GetPar( "Pgmname");
         AV54OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV55OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV13FilterFullText = GetPar( "FilterFullText");
         A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6WWPContext);
         AV93Udparg1 = StringUtil.StrToGuid( GetPar( "Udparg1"));
         A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
         dynavLocationoption.FromJSonString( GetNextPar( ));
         AV15LocationOption = StringUtil.StrToGuid( GetPar( "LocationOption"));
         A89ReceptionistId = StringUtil.StrToGuid( GetPar( "ReceptionistId"));
         A95ReceptionistGAMGUID = GetPar( "ReceptionistGAMGUID");
         A31LocationName = GetPar( "LocationName");
         A90ReceptionistGivenName = GetPar( "ReceptionistGivenName");
         A91ReceptionistLastName = GetPar( "ReceptionistLastName");
         A93ReceptionistEmail = GetPar( "ReceptionistEmail");
         A94ReceptionistPhone = GetPar( "ReceptionistPhone");
         A369ReceptionistIsActive = StringUtil.StrToBool( GetPar( "ReceptionistIsActive"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV14SDT_Receptionists);
         AV44IsAuthorized_ReSendInvite = StringUtil.StrToBool( GetPar( "IsAuthorized_ReSendInvite"));
         AV70IsAuthorized_UserActionBlock = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionBlock"));
         AV71IsAuthorized_UserActionUnblock = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionUnblock"));
         AV43IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV30IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV31IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV47IsAuthorized_SDT_Receptionists = StringUtil.StrToBool( GetPar( "IsAuthorized_SDT_Receptionists"));
         AV78ReceptionistTitle = GetPar( "ReceptionistTitle");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wp_locationreceptionists_Execute" ;
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
         PA5Z2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5Z2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_locationreceptionists.aspx"+UrlEncode(StringUtil.RTrim(AV51Message));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_locationreceptionists.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV91Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV91Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV6WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", AV93Udparg1.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", AV93Udparg1, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RESENDINVITE", AV44IsAuthorized_ReSendInvite);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESENDINVITE", GetSecureSignedToken( "", AV44IsAuthorized_ReSendInvite, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONBLOCK", AV70IsAuthorized_UserActionBlock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONBLOCK", GetSecureSignedToken( "", AV70IsAuthorized_UserActionBlock, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONUNBLOCK", AV71IsAuthorized_UserActionUnblock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONUNBLOCK", GetSecureSignedToken( "", AV71IsAuthorized_UserActionUnblock, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV43IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV43IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV30IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV30IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV31IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV31IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SDT_RECEPTIONISTS", AV47IsAuthorized_SDT_Receptionists);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RECEPTIONISTS", GetSecureSignedToken( "", AV47IsAuthorized_SDT_Receptionists, context));
         GxWebStd.gx_hidden_field( context, "vRECEPTIONISTTITLE", AV78ReceptionistTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECEPTIONISTTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78ReceptionistTitle, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdt_receptionists", AV14SDT_Receptionists);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdt_receptionists", AV14SDT_Receptionists);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_45", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_45), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV23GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV40ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV40ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV91Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV91Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV55OrderedDsc);
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vUDPARG1", AV93Udparg1.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", AV93Udparg1, context));
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "RECEPTIONISTID", A89ReceptionistId.ToString());
         GxWebStd.gx_hidden_field( context, "RECEPTIONISTGAMGUID", A95ReceptionistGAMGUID);
         GxWebStd.gx_hidden_field( context, "LOCATIONNAME", A31LocationName);
         GxWebStd.gx_hidden_field( context, "RECEPTIONISTGIVENNAME", A90ReceptionistGivenName);
         GxWebStd.gx_hidden_field( context, "RECEPTIONISTLASTNAME", A91ReceptionistLastName);
         GxWebStd.gx_hidden_field( context, "RECEPTIONISTEMAIL", A93ReceptionistEmail);
         GxWebStd.gx_hidden_field( context, "RECEPTIONISTPHONE", StringUtil.RTrim( A94ReceptionistPhone));
         GxWebStd.gx_boolean_hidden_field( context, "RECEPTIONISTISACTIVE", A369ReceptionistIsActive);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_RECEPTIONISTS", AV14SDT_Receptionists);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_RECEPTIONISTS", AV14SDT_Receptionists);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RESENDINVITE", AV44IsAuthorized_ReSendInvite);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESENDINVITE", GetSecureSignedToken( "", AV44IsAuthorized_ReSendInvite, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONBLOCK", AV70IsAuthorized_UserActionBlock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONBLOCK", GetSecureSignedToken( "", AV70IsAuthorized_UserActionBlock, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONUNBLOCK", AV71IsAuthorized_UserActionUnblock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONUNBLOCK", GetSecureSignedToken( "", AV71IsAuthorized_UserActionUnblock, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV43IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV43IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV30IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV30IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV31IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV31IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SDT_RECEPTIONISTS", AV47IsAuthorized_SDT_Receptionists);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RECEPTIONISTS", GetSecureSignedToken( "", AV47IsAuthorized_SDT_Receptionists, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISSENT", AV36isSent);
         GxWebStd.gx_hidden_field( context, "vERRDESCRIPTION", AV67ErrDescription);
         GxWebStd.gx_hidden_field( context, "vRECEPTIONISTTITLE", AV78ReceptionistTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECEPTIONISTTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78ReceptionistTitle, "")), context));
         GxWebStd.gx_hidden_field( context, "vMESSAGE", AV51Message);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV6WWPContext, context));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Title", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Title", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Title", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Result", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Result));
         GxWebStd.gx_hidden_field( context, "vHTTPREQUEST_Baseurl", StringUtil.RTrim( AV8HTTPRequest.BaseURL));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Result));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Result", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Result));
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
            WE5Z2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5Z2( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_locationreceptionists.aspx"+UrlEncode(StringUtil.RTrim(AV51Message));
         return formatLink("wp_locationreceptionists.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_LocationReceptionists" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Location Receptionists", "") ;
      }

      protected void WB5Z0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableWithSelectableGrid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(45), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_LocationReceptionists.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(45), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_LocationReceptionists.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV17ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_45_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV13FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WP_LocationReceptionists.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablelocationoption_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_6_25", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocklocationoption_Internalname, "", "", "", lblTextblocklocationoption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_LocationReceptionists.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_93_75", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLocationoption_Internalname, context.GetMessage( "Location Option", ""), "col-sm-3 AddressAttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_45_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLocationoption, dynavLocationoption_Internalname, AV15LocationOption.ToString(), 1, dynavLocationoption_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "guid", "", dynavLocationoption.Visible, dynavLocationoption.Enabled, 0, 0, 20, "em", 0, "", "", "AddressAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_WP_LocationReceptionists.htm");
            dynavLocationoption.CurrentValue = AV15LocationOption.ToString();
            AssignProp("", false, dynavLocationoption_Internalname, "Values", (string)(dynavLocationoption.ToJavascriptSource()), true);
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders GridHover HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl45( ) ;
         }
         if ( wbEnd == 45 )
         {
            wbEnd = 0;
            nRC_GXsfl_45 = (int)(nGXsfl_45_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV80GXV1 = nGXsfl_45_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV21GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV22GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV23GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV42DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV42DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV40ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table1_66_5Z2( true) ;
         }
         else
         {
            wb_table1_66_5Z2( false) ;
         }
         return  ;
      }

      protected void wb_table1_66_5Z2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_71_5Z2( true) ;
         }
         else
         {
            wb_table2_71_5Z2( false) ;
         }
         return  ;
      }

      protected void wb_table2_71_5Z2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_76_5Z2( true) ;
         }
         else
         {
            wb_table3_76_5Z2( false) ;
         }
         return  ;
      }

      protected void wb_table3_76_5Z2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 45 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV80GXV1 = nGXsfl_45_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START5Z2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Location Receptionists", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5Z0( ) ;
      }

      protected void WS5Z2( )
      {
         START5Z2( ) ;
         EVT5Z2( ) ;
      }

      protected void EVT5Z2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E115Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E125Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E135Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E145Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E155Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_RESENDINVITE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_resendinvite.Close */
                              E165Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_useractionblock.Close */
                              E175Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_useractionunblock.Close */
                              E185Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E195Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERFULLTEXT.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E205Z2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) )
                           {
                              nGXsfl_45_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
                              SubsflControlProps_452( ) ;
                              AV80GXV1 = (int)(nGXsfl_45_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV14SDT_Receptionists.Count >= AV80GXV1 ) && ( AV80GXV1 > 0 ) )
                              {
                                 AV14SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1));
                                 AV50AccountStatus = cgiGet( edtavAccountstatus_Internalname);
                                 AssignAttri("", false, edtavAccountstatus_Internalname, AV50AccountStatus);
                                 cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                                 cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                                 AV37ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV37ActionGroup), 4, 0));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E215Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E225Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E235Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E245Z2 ();
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

      protected void WE5Z2( )
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

      protected void PA5Z2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_locationreceptionists.aspx")), "wp_locationreceptionists.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_locationreceptionists.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "Message");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV51Message = gxfirstwebparm;
                     AssignAttri("", false, "AV51Message", AV51Message);
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvLOCATIONOPTION5Z2( GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLOCATIONOPTION_data5Z2( AV6WWPContext) ;
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

      protected void GXVvLOCATIONOPTION_html5Z2( GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext )
      {
         Guid gxdynajaxvalue;
         GXDLVvLOCATIONOPTION_data5Z2( AV6WWPContext) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLocationoption.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavLocationoption.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvLOCATIONOPTION_data5Z2( GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(Guid.Empty.ToString());
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Location", ""));
         /* Using cursor H005Z2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( H005Z2_A11OrganisationId[0] == (AV6WWPContext.gxTpr_Isrootadmin ? AV6WWPContext.gxTpr_Organisationid : new prc_getuserorganisationid(context).executeUdp( )) )
            {
               gxdynajaxctrlcodr.Add(H005Z2_A29LocationId[0].ToString());
               gxdynajaxctrldescr.Add(H005Z2_A31LocationName[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_452( ) ;
         while ( nGXsfl_45_idx <= nRC_GXsfl_45 )
         {
            sendrow_452( ) ;
            nGXsfl_45_idx = ((subGrid_Islastpage==1)&&(nGXsfl_45_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_45_idx+1);
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV19ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV40ColumnsSelector ,
                                       string AV91Pgmname ,
                                       short AV54OrderedBy ,
                                       bool AV55OrderedDsc ,
                                       string AV13FilterFullText ,
                                       Guid A11OrganisationId ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ,
                                       Guid AV93Udparg1 ,
                                       Guid A29LocationId ,
                                       Guid AV15LocationOption ,
                                       Guid A89ReceptionistId ,
                                       string A95ReceptionistGAMGUID ,
                                       string A31LocationName ,
                                       string A90ReceptionistGivenName ,
                                       string A91ReceptionistLastName ,
                                       string A93ReceptionistEmail ,
                                       string A94ReceptionistPhone ,
                                       bool A369ReceptionistIsActive ,
                                       GXBaseCollection<SdtSDT_Receptionist> AV14SDT_Receptionists ,
                                       bool AV44IsAuthorized_ReSendInvite ,
                                       bool AV70IsAuthorized_UserActionBlock ,
                                       bool AV71IsAuthorized_UserActionUnblock ,
                                       bool AV43IsAuthorized_Display ,
                                       bool AV30IsAuthorized_Update ,
                                       bool AV31IsAuthorized_Delete ,
                                       bool AV47IsAuthorized_SDT_Receptionists ,
                                       string AV78ReceptionistTitle )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5Z2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
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
         if ( dynavLocationoption.ItemCount > 0 )
         {
            AV15LocationOption = StringUtil.StrToGuid( dynavLocationoption.getValidValue(AV15LocationOption.ToString()));
            AssignAttri("", false, "AV15LocationOption", AV15LocationOption.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLocationoption.CurrentValue = AV15LocationOption.ToString();
            AssignProp("", false, dynavLocationoption_Internalname, "Values", dynavLocationoption.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV91Pgmname = "WP_LocationReceptionists";
         edtavSdt_receptionists__receptionistid_Enabled = 0;
         edtavSdt_receptionists__organisationid_Enabled = 0;
         edtavSdt_receptionists__locationid_Enabled = 0;
         edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
         edtavSdt_receptionists__receptionistlastname_Enabled = 0;
         edtavSdt_receptionists__receptionistemail_Enabled = 0;
         edtavSdt_receptionists__receptionistphone_Enabled = 0;
         edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
         edtavSdt_receptionists__locationname_Enabled = 0;
         edtavSdt_receptionists_receptioniststatus_Enabled = 0;
         edtavAccountstatus_Enabled = 0;
      }

      protected void RF5Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 45;
         /* Execute user event: Refresh */
         E225Z2 ();
         nGXsfl_45_idx = 1;
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
         SubsflControlProps_452( ) ;
         bGXsfl_45_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_452( ) ;
            /* Execute user event: Grid.Load */
            E235Z2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_45_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E235Z2 ();
            }
            wbEnd = 45;
            WB5Z0( ) ;
         }
         bGXsfl_45_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5Z2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV91Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV91Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV6WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", AV93Udparg1.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", AV93Udparg1, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RESENDINVITE", AV44IsAuthorized_ReSendInvite);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESENDINVITE", GetSecureSignedToken( "", AV44IsAuthorized_ReSendInvite, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONBLOCK", AV70IsAuthorized_UserActionBlock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONBLOCK", GetSecureSignedToken( "", AV70IsAuthorized_UserActionBlock, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONUNBLOCK", AV71IsAuthorized_UserActionUnblock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONUNBLOCK", GetSecureSignedToken( "", AV71IsAuthorized_UserActionUnblock, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV43IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV43IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV30IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV30IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV31IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV31IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SDT_RECEPTIONISTS", AV47IsAuthorized_SDT_Receptionists);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RECEPTIONISTS", GetSecureSignedToken( "", AV47IsAuthorized_SDT_Receptionists, context));
         GxWebStd.gx_hidden_field( context, "vRECEPTIONISTTITLE", AV78ReceptionistTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECEPTIONISTTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78ReceptionistTitle, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return AV14SDT_Receptionists.Count ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV91Pgmname = "WP_LocationReceptionists";
         edtavSdt_receptionists__receptionistid_Enabled = 0;
         edtavSdt_receptionists__organisationid_Enabled = 0;
         edtavSdt_receptionists__locationid_Enabled = 0;
         edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
         edtavSdt_receptionists__receptionistlastname_Enabled = 0;
         edtavSdt_receptionists__receptionistemail_Enabled = 0;
         edtavSdt_receptionists__receptionistphone_Enabled = 0;
         edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
         edtavSdt_receptionists__locationname_Enabled = 0;
         edtavSdt_receptionists_receptioniststatus_Enabled = 0;
         edtavAccountstatus_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E215Z2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         GXVvLOCATIONOPTION_html5Z2( AV6WWPContext) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdt_receptionists"), AV14SDT_Receptionists);
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV42DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV40ColumnsSelector);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_RECEPTIONISTS"), AV14SDT_Receptionists);
            /* Read saved values. */
            nRC_GXsfl_45 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_45"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV21GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV22GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV23GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Dvelop_confirmpanel_resendinvite_Title = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Title");
            Dvelop_confirmpanel_resendinvite_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Confirmationtext");
            Dvelop_confirmpanel_resendinvite_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Yesbuttoncaption");
            Dvelop_confirmpanel_resendinvite_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Nobuttoncaption");
            Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Cancelbuttoncaption");
            Dvelop_confirmpanel_resendinvite_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Yesbuttonposition");
            Dvelop_confirmpanel_resendinvite_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Confirmtype");
            Dvelop_confirmpanel_useractionblock_Title = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Title");
            Dvelop_confirmpanel_useractionblock_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmationtext");
            Dvelop_confirmpanel_useractionblock_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttoncaption");
            Dvelop_confirmpanel_useractionblock_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Nobuttoncaption");
            Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Cancelbuttoncaption");
            Dvelop_confirmpanel_useractionblock_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttonposition");
            Dvelop_confirmpanel_useractionblock_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmtype");
            Dvelop_confirmpanel_useractionunblock_Title = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Title");
            Dvelop_confirmpanel_useractionunblock_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmationtext");
            Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttoncaption");
            Dvelop_confirmpanel_useractionunblock_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Nobuttoncaption");
            Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Cancelbuttoncaption");
            Dvelop_confirmpanel_useractionunblock_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttonposition");
            Dvelop_confirmpanel_useractionunblock_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_resendinvite_Result = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Result");
            Dvelop_confirmpanel_useractionblock_Result = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Result");
            Dvelop_confirmpanel_useractionunblock_Result = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Result");
            nRC_GXsfl_45 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_45"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_45_fel_idx = 0;
            while ( nGXsfl_45_fel_idx < nRC_GXsfl_45 )
            {
               nGXsfl_45_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_45_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_45_fel_idx+1);
               sGXsfl_45_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_452( ) ;
               AV80GXV1 = (int)(nGXsfl_45_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV14SDT_Receptionists.Count >= AV80GXV1 ) && ( AV80GXV1 > 0 ) )
               {
                  AV14SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1));
                  AV50AccountStatus = cgiGet( edtavAccountstatus_Internalname);
                  cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                  cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                  AV37ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               }
            }
            if ( nGXsfl_45_fel_idx == 0 )
            {
               nGXsfl_45_idx = 1;
               sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
               SubsflControlProps_452( ) ;
            }
            nGXsfl_45_fel_idx = 1;
            /* Read variables values. */
            AV13FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
            dynavLocationoption.Name = dynavLocationoption_Internalname;
            dynavLocationoption.CurrentValue = cgiGet( dynavLocationoption_Internalname);
            AV15LocationOption = StringUtil.StrToGuid( cgiGet( dynavLocationoption_Internalname));
            AssignAttri("", false, "AV15LocationOption", AV15LocationOption.ToString());
            /* Read subfile selected row values. */
            nGXsfl_45_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
            AV80GXV1 = (int)(nGXsfl_45_idx+GRID_nFirstRecordOnPage);
            if ( nGXsfl_45_idx > 0 )
            {
               AV80GXV1 = (int)(nGXsfl_45_idx+GRID_nFirstRecordOnPage);
               if ( ( AV14SDT_Receptionists.Count >= AV80GXV1 ) && ( AV80GXV1 > 0 ) )
               {
                  AV14SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1));
                  AV50AccountStatus = cgiGet( edtavAccountstatus_Internalname);
                  AssignAttri("", false, edtavAccountstatus_Internalname, AV50AccountStatus);
                  cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                  cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                  AV37ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV37ActionGroup), 4, 0));
               }
               if ( ( AV80GXV1 > 0 ) && ( AV14SDT_Receptionists.Count >= AV80GXV1 ) )
               {
                  AV14SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1));
               }
            }
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
         E215Z2 ();
         if (returnInSub) return;
      }

      protected void E215Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         GXt_boolean1 = AV47IsAuthorized_SDT_Receptionists;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionistview_Execute", out  GXt_boolean1) ;
         AV47IsAuthorized_SDT_Receptionists = GXt_boolean1;
         AssignAttri("", false, "AV47IsAuthorized_SDT_Receptionists", AV47IsAuthorized_SDT_Receptionists);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RECEPTIONISTS", GetSecureSignedToken( "", AV47IsAuthorized_SDT_Receptionists, context));
         GXt_boolean1 = AV47IsAuthorized_SDT_Receptionists;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionistview_Execute", out  GXt_boolean1) ;
         AV47IsAuthorized_SDT_Receptionists = GXt_boolean1;
         AssignAttri("", false, "AV47IsAuthorized_SDT_Receptionists", AV47IsAuthorized_SDT_Receptionists);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RECEPTIONISTS", GetSecureSignedToken( "", AV47IsAuthorized_SDT_Receptionists, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Location Receptionists", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         if ( AV54OrderedBy < 1 )
         {
            AV54OrderedBy = 1;
            AssignAttri("", false, "AV54OrderedBy", StringUtil.LTrimStr( (decimal)(AV54OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if (returnInSub) return;
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV42DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV42DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         AV53successmsg = AV52websession.Get(context.GetMessage( "NotificationMessage", ""));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53successmsg)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  AV53successmsg,  "success",  "",  "true",  ""));
            AV52websession.Remove(context.GetMessage( "NotificationMessage", ""));
         }
         GXt_SdtGAMUser3 = AV28GAMUser;
         new prc_getloggedinuser(context ).execute( out  GXt_SdtGAMUser3) ;
         AV28GAMUser = GXt_SdtGAMUser3;
         if ( AV28GAMUser.checkrole("Root Admin") )
         {
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
            if ( ! (Guid.Empty==AV6WWPContext.gxTpr_Locationid) )
            {
               AV15LocationOption = AV6WWPContext.gxTpr_Locationid;
               AssignAttri("", false, "AV15LocationOption", AV15LocationOption.ToString());
               dynavLocationoption.Visible = 0;
               AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
            }
            else
            {
               dynavLocationoption.Visible = 1;
               AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
            }
         }
         else
         {
            if ( AV28GAMUser.checkrole("Receptionist") )
            {
               GXt_guid4 = AV15LocationOption;
               new prc_getuserlocationid(context ).execute( out  GXt_guid4) ;
               AV15LocationOption = GXt_guid4;
               AssignAttri("", false, "AV15LocationOption", AV15LocationOption.ToString());
               dynavLocationoption.Visible = 0;
               AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
            }
         }
      }

      protected void E225Z2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S142 ();
         if (returnInSub) return;
         if ( AV19ManageFiltersExecutionStep == 1 )
         {
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV19ManageFiltersExecutionStep == 2 )
         {
            AV19ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S152 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV16Session.Get("WP_LocationReceptionistsColumnsSelector"), "") != 0 )
         {
            AV38ColumnsSelectorXML = AV16Session.Get("WP_LocationReceptionistsColumnsSelector");
            AV40ColumnsSelector.FromXml(AV38ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S162 ();
            if (returnInSub) return;
         }
         edtavSdt_receptionists__receptionistgivenname_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV40ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdt_receptionists__receptionistgivenname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistgivenname_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtavSdt_receptionists__receptionistlastname_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV40ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdt_receptionists__receptionistlastname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistlastname_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtavSdt_receptionists__receptionistemail_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV40ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdt_receptionists__receptionistemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistemail_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtavSdt_receptionists__receptionistphone_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV40ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdt_receptionists__receptionistphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistphone_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtavSdt_receptionists__locationname_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV40ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdt_receptionists__locationname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__locationname_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtavAccountstatus_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV40ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavAccountstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAccountstatus_Visible), 5, 0), !bGXsfl_45_Refreshing);
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S172 ();
         if (returnInSub) return;
         AV21GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV21GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV21GridCurrentPage), 10, 0));
         AV22GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV22GridPageCount", StringUtil.LTrimStr( (decimal)(AV22GridPageCount), 10, 0));
         GXt_char5 = AV23GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV91Pgmname, out  GXt_char5) ;
         AV23GridAppliedFilters = GXt_char5;
         AssignAttri("", false, "AV23GridAppliedFilters", AV23GridAppliedFilters);
         edtavAccountstatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavAccountstatus_Internalname, "Columnheaderclass", edtavAccountstatus_Columnheaderclass, !bGXsfl_45_Refreshing);
         /* Execute user subroutine: 'RELOADGRIDSDT' */
         S182 ();
         if (returnInSub) return;
         GXt_char5 = AV78ReceptionistTitle;
         new prc_getorganisationdefinition(context ).execute(  "Receptionist", out  GXt_char5) ;
         AV78ReceptionistTitle = GXt_char5;
         AssignAttri("", false, "AV78ReceptionistTitle", AV78ReceptionistTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECEPTIONISTTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV78ReceptionistTitle, "")), context));
         GXt_char5 = AV79ReceptionistsTitle;
         new prc_getorganisationdefinition(context ).execute(  "Receptionists", out  GXt_char5) ;
         AV79ReceptionistsTitle = GXt_char5;
         Form.Caption = context.GetMessage( "Location", "")+" "+AV78ReceptionistTitle;
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         dynload_actions( ) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40ColumnsSelector", AV40ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14SDT_Receptionists", AV14SDT_Receptionists);
      }

      protected void E125Z2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV20PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV20PageToGo) ;
         }
      }

      protected void E135Z2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E145Z2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV54OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV54OrderedBy", StringUtil.LTrimStr( (decimal)(AV54OrderedBy), 4, 0));
            AV55OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV55OrderedDsc", AV55OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E235Z2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV80GXV1 = 1;
         while ( AV80GXV1 <= AV14SDT_Receptionists.Count )
         {
            AV14SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1));
            GXt_boolean1 = AV45IsGAMActive;
            new prc_checkgamuseractivationstatus(context ).execute(  ((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Receptionistgamguid, out  GXt_boolean1) ;
            AV45IsGAMActive = GXt_boolean1;
            GXt_boolean1 = AV49IsGAMBlocked;
            new prc_checkgamuserblockedstatus(context ).execute(  ((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Receptionistgamguid, out  GXt_boolean1) ;
            AV49IsGAMBlocked = GXt_boolean1;
            if ( ( AV45IsGAMActive ) && ! AV49IsGAMBlocked )
            {
               AV50AccountStatus = "Active";
               AssignAttri("", false, edtavAccountstatus_Internalname, AV50AccountStatus);
            }
            else if ( ( AV45IsGAMActive ) && ( AV49IsGAMBlocked ) )
            {
               AV50AccountStatus = "Blocked";
               AssignAttri("", false, edtavAccountstatus_Internalname, AV50AccountStatus);
            }
            else if ( ! AV45IsGAMActive )
            {
               AV50AccountStatus = "Inactive";
               AssignAttri("", false, edtavAccountstatus_Internalname, AV50AccountStatus);
            }
            cmbavActiongroup.removeAllItems();
            cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
            if ( AV44IsAuthorized_ReSendInvite )
            {
               if ( ! AV45IsGAMActive )
               {
                  cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Invite", ""), "fas fa-share", "", "", "", "", "", "", ""), 0);
               }
            }
            if ( AV70IsAuthorized_UserActionBlock )
            {
               if ( ( AV45IsGAMActive ) && ! AV49IsGAMBlocked )
               {
                  cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Block", ""), "fas fa-lock", "", "", "", "", "", "", ""), 0);
               }
            }
            if ( AV71IsAuthorized_UserActionUnblock )
            {
               if ( ( AV45IsGAMActive ) && ( AV49IsGAMBlocked ) )
               {
                  cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "Unblock", ""), "fas fa-lock-open", "", "", "", "", "", "", ""), 0);
               }
            }
            if ( AV43IsAuthorized_Display )
            {
               cmbavActiongroup.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            }
            if ( AV30IsAuthorized_Update )
            {
               cmbavActiongroup.addItem("5", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV31IsAuthorized_Delete )
            {
               cmbavActiongroup.addItem("6", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            if ( cmbavActiongroup.ItemCount == 1 )
            {
               cmbavActiongroup_Class = "Invisible";
            }
            else
            {
               cmbavActiongroup_Class = "ConvertToDDO";
            }
            if ( AV47IsAuthorized_SDT_Receptionists )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "trn_receptionistview.aspx"+UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Receptionistid.ToString()) + "," + UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Organisationid.ToString()) + "," + UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Locationid.ToString());
               edtavSdt_receptionists__receptionistgivenname_Link = formatLink("trn_receptionistview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( AV47IsAuthorized_SDT_Receptionists )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "trn_receptionistview.aspx"+UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Receptionistid.ToString()) + "," + UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Organisationid.ToString()) + "," + UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Locationid.ToString());
               edtavSdt_receptionists__receptionistlastname_Link = formatLink("trn_receptionistview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( ( AV45IsGAMActive ) && ! AV49IsGAMBlocked )
            {
               edtavSdt_receptionists_receptioniststatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( ( AV45IsGAMActive ) && ( AV49IsGAMBlocked ) )
            {
               edtavSdt_receptionists_receptioniststatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else if ( ! AV45IsGAMActive )
            {
               edtavSdt_receptionists_receptioniststatus_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
            }
            else
            {
               edtavSdt_receptionists_receptioniststatus_Columnclass = "WWColumn";
            }
            if ( ( AV45IsGAMActive ) && ! AV49IsGAMBlocked )
            {
               edtavAccountstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( ( AV45IsGAMActive ) && ( AV49IsGAMBlocked ) )
            {
               edtavAccountstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else if ( ! AV45IsGAMActive )
            {
               edtavAccountstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
            }
            else
            {
               edtavAccountstatus_Columnclass = "WWColumn";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 45;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_452( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_45_Refreshing )
            {
               DoAjaxLoad(45, GridRow);
            }
            AV80GXV1 = (int)(AV80GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV37ActionGroup), 4, 0));
      }

      protected void E155Z2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV38ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV40ColumnsSelector.FromJSonString(AV38ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WP_LocationReceptionistsColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelectorXML)) ? "" : AV40ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40ColumnsSelector", AV40ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         if ( gx_BV45 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14SDT_Receptionists", AV14SDT_Receptionists);
            nGXsfl_45_bak_idx = nGXsfl_45_idx;
            gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
            nGXsfl_45_idx = nGXsfl_45_bak_idx;
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
         }
      }

      protected void E115Z2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S192 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S152 ();
            if (returnInSub) return;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WP_LocationReceptionistsFilters")) + "," + UrlEncode(StringUtil.RTrim(AV91Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WP_LocationReceptionistsFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char5 = AV18ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WP_LocationReceptionistsFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char5) ;
            AV18ManageFiltersXml = GXt_char5;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S192 ();
               if (returnInSub) return;
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV91Pgmname+"GridState",  AV18ManageFiltersXml) ;
               AV11GridState.FromXml(AV18ManageFiltersXml, null, "", "");
               AV54OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV54OrderedBy", StringUtil.LTrimStr( (decimal)(AV54OrderedBy), 4, 0));
               AV55OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV55OrderedDsc", AV55OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S132 ();
               if (returnInSub) return;
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S202 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40ColumnsSelector", AV40ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         if ( gx_BV45 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14SDT_Receptionists", AV14SDT_Receptionists);
            nGXsfl_45_bak_idx = nGXsfl_45_idx;
            gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
            nGXsfl_45_idx = nGXsfl_45_bak_idx;
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
         }
      }

      protected void E245Z2( )
      {
         AV80GXV1 = (int)(nGXsfl_45_idx+GRID_nFirstRecordOnPage);
         if ( ( AV80GXV1 > 0 ) && ( AV14SDT_Receptionists.Count >= AV80GXV1 ) )
         {
            AV14SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1));
         }
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV37ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO RESENDINVITE' */
            S212 ();
            if (returnInSub) return;
         }
         else if ( AV37ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO USERACTIONBLOCK' */
            S222 ();
            if (returnInSub) return;
         }
         else if ( AV37ActionGroup == 3 )
         {
            /* Execute user subroutine: 'DO USERACTIONUNBLOCK' */
            S232 ();
            if (returnInSub) return;
         }
         else if ( AV37ActionGroup == 4 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S242 ();
            if (returnInSub) return;
         }
         else if ( AV37ActionGroup == 5 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S252 ();
            if (returnInSub) return;
         }
         else if ( AV37ActionGroup == 6 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S262 ();
            if (returnInSub) return;
         }
         AV37ActionGroup = 0;
         AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV37ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV37ActionGroup), 4, 0));
         AssignProp("", false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40ColumnsSelector", AV40ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14SDT_Receptionists", AV14SDT_Receptionists);
         nGXsfl_45_bak_idx = nGXsfl_45_idx;
         gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
         nGXsfl_45_idx = nGXsfl_45_bak_idx;
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
         SubsflControlProps_452( ) ;
      }

      protected void E165Z2( )
      {
         AV80GXV1 = (int)(nGXsfl_45_idx+GRID_nFirstRecordOnPage);
         if ( ( AV80GXV1 > 0 ) && ( AV14SDT_Receptionists.Count >= AV80GXV1 ) )
         {
            AV14SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1));
         }
         /* Dvelop_confirmpanel_resendinvite_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_resendinvite_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION RESENDINVITE' */
            S272 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E175Z2( )
      {
         AV80GXV1 = (int)(nGXsfl_45_idx+GRID_nFirstRecordOnPage);
         if ( ( AV80GXV1 > 0 ) && ( AV14SDT_Receptionists.Count >= AV80GXV1 ) )
         {
            AV14SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1));
         }
         /* Dvelop_confirmpanel_useractionblock_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractionblock_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONBLOCK' */
            S282 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40ColumnsSelector", AV40ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14SDT_Receptionists", AV14SDT_Receptionists);
         nGXsfl_45_bak_idx = nGXsfl_45_idx;
         gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
         nGXsfl_45_idx = nGXsfl_45_bak_idx;
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
         SubsflControlProps_452( ) ;
      }

      protected void E185Z2( )
      {
         AV80GXV1 = (int)(nGXsfl_45_idx+GRID_nFirstRecordOnPage);
         if ( ( AV80GXV1 > 0 ) && ( AV14SDT_Receptionists.Count >= AV80GXV1 ) )
         {
            AV14SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1));
         }
         /* Dvelop_confirmpanel_useractionunblock_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractionunblock_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONUNBLOCK' */
            S292 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40ColumnsSelector", AV40ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14SDT_Receptionists", AV14SDT_Receptionists);
         nGXsfl_45_bak_idx = nGXsfl_45_idx;
         gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
         nGXsfl_45_idx = nGXsfl_45_bak_idx;
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
         SubsflControlProps_452( ) ;
      }

      protected void E195Z2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_receptionist.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(new prc_getuserorganisationid(context).executeUdp( ).ToString()) + "," + UrlEncode(Guid.Empty.ToString());
         CallWebObject(formatLink("trn_receptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S172( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
         AV14SDT_Receptionists.Clear();
         gx_BV45 = true;
         AV93Udparg1 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV15LocationOption ,
                                              A29LocationId ,
                                              A11OrganisationId ,
                                              AV6WWPContext.gxTpr_Isrootadmin ,
                                              AV6WWPContext.gxTpr_Organisationid ,
                                              AV93Udparg1 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H005Z3 */
         pr_default.execute(1, new Object[] {AV6WWPContext.gxTpr_Organisationid, AV6WWPContext.gxTpr_Isrootadmin, AV93Udparg1, AV15LocationOption});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = H005Z3_A29LocationId[0];
            A11OrganisationId = H005Z3_A11OrganisationId[0];
            A89ReceptionistId = H005Z3_A89ReceptionistId[0];
            A95ReceptionistGAMGUID = H005Z3_A95ReceptionistGAMGUID[0];
            A31LocationName = H005Z3_A31LocationName[0];
            A90ReceptionistGivenName = H005Z3_A90ReceptionistGivenName[0];
            A91ReceptionistLastName = H005Z3_A91ReceptionistLastName[0];
            A93ReceptionistEmail = H005Z3_A93ReceptionistEmail[0];
            A94ReceptionistPhone = H005Z3_A94ReceptionistPhone[0];
            A369ReceptionistIsActive = H005Z3_A369ReceptionistIsActive[0];
            A31LocationName = H005Z3_A31LocationName[0];
            AV27SDT_Receptionist = new SdtSDT_Receptionist(context);
            AV27SDT_Receptionist.gxTpr_Receptionistid = A89ReceptionistId;
            AV27SDT_Receptionist.gxTpr_Receptionistgamguid = A95ReceptionistGAMGUID;
            AV27SDT_Receptionist.gxTpr_Locationid = A29LocationId;
            AV27SDT_Receptionist.gxTpr_Locationname = A31LocationName;
            AV27SDT_Receptionist.gxTpr_Organisationid = A11OrganisationId;
            AV27SDT_Receptionist.gxTpr_Receptionistgivenname = A90ReceptionistGivenName;
            AV27SDT_Receptionist.gxTpr_Receptionistlastname = A91ReceptionistLastName;
            AV27SDT_Receptionist.gxTpr_Receptionistemail = A93ReceptionistEmail;
            AV27SDT_Receptionist.gxTpr_Receptionistphone = A94ReceptionistPhone;
            if ( A369ReceptionistIsActive )
            {
               AV27SDT_Receptionist.gxTpr_Receptioniststatus = "Active";
            }
            else
            {
               AV27SDT_Receptionist.gxTpr_Receptioniststatus = "Inactive";
            }
            AV14SDT_Receptionists.Add(AV27SDT_Receptionist, 0);
            gx_BV45 = true;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV54OrderedBy != 4 )
         {
            AV14SDT_Receptionists.Sort((AV55OrderedDsc ? "[" : "")+StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV54OrderedBy), 4, 0)), "ReceptionistGivenName", "ReceptionistLastName", "ReceptionistEmail", "", "", "", "", "", "")+(AV55OrderedDsc ? "]" : ""));
            gx_BV45 = true;
         }
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV54OrderedBy), 4, 0))+":"+(AV55OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S162( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV40ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "SDT_Receptionists__ReceptionistGivenName",  "",  "First Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "SDT_Receptionists__ReceptionistLastName",  "",  "Last Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "SDT_Receptionists__ReceptionistEmail",  "",  "Email",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "SDT_Receptionists__ReceptionistPhone",  "",  "Phone",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "SDT_Receptionists__LocationName",  "",  "Location",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "&AccountStatus",  "",  "Account Status",  true,  "") ;
         GXt_char5 = AV39UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WP_LocationReceptionistsColumnsSelector", out  GXt_char5) ;
         AV39UserCustomValue = GXt_char5;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39UserCustomValue)) ) )
         {
            AV41ColumnsSelectorAux.FromXml(AV39UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV41ColumnsSelectorAux, ref  AV40ColumnsSelector) ;
         }
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV44IsAuthorized_ReSendInvite;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionist_Insert", out  GXt_boolean1) ;
         AV44IsAuthorized_ReSendInvite = GXt_boolean1;
         AssignAttri("", false, "AV44IsAuthorized_ReSendInvite", AV44IsAuthorized_ReSendInvite);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESENDINVITE", GetSecureSignedToken( "", AV44IsAuthorized_ReSendInvite, context));
         GXt_boolean1 = AV70IsAuthorized_UserActionBlock;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionist_Insert", out  GXt_boolean1) ;
         AV70IsAuthorized_UserActionBlock = GXt_boolean1;
         AssignAttri("", false, "AV70IsAuthorized_UserActionBlock", AV70IsAuthorized_UserActionBlock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONBLOCK", GetSecureSignedToken( "", AV70IsAuthorized_UserActionBlock, context));
         GXt_boolean1 = AV71IsAuthorized_UserActionUnblock;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionist_Insert", out  GXt_boolean1) ;
         AV71IsAuthorized_UserActionUnblock = GXt_boolean1;
         AssignAttri("", false, "AV71IsAuthorized_UserActionUnblock", AV71IsAuthorized_UserActionUnblock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONUNBLOCK", GetSecureSignedToken( "", AV71IsAuthorized_UserActionUnblock, context));
         GXt_boolean1 = AV43IsAuthorized_Display;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionistview_Execute", out  GXt_boolean1) ;
         AV43IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV43IsAuthorized_Display", AV43IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV43IsAuthorized_Display, context));
         GXt_boolean1 = AV30IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionist_Update", out  GXt_boolean1) ;
         AV30IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV30IsAuthorized_Update", AV30IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV30IsAuthorized_Update, context));
         GXt_boolean1 = AV31IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionist_Delete", out  GXt_boolean1) ;
         AV31IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV31IsAuthorized_Delete", AV31IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV31IsAuthorized_Delete, context));
         GXt_boolean1 = AV29IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionist_Insert", out  GXt_boolean1) ;
         AV29IsAuthorized_Insert = GXt_boolean1;
         if ( ! ( AV29IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6 = AV17ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WP_LocationReceptionistsFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6;
      }

      protected void S192( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV13FilterFullText = "";
         AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
      }

      protected void S212( )
      {
         /* 'DO RESENDINVITE' Routine */
         returnInSub = false;
         if ( AV44IsAuthorized_ReSendInvite )
         {
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_RESENDINVITEContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S272( )
      {
         /* 'DO ACTION RESENDINVITE' Routine */
         returnInSub = false;
         AV35baseUrl = AV8HTTPRequest.BaseURL;
         AV34ReceptionistGuid_Selected = ((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Receptionistgamguid;
         AV28GAMUser.load( AV34ReceptionistGuid_Selected);
         AV48GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV69ActivactionKey = AV28GAMUser.getnewactivationkey(out  AV48GAMErrors);
         if ( AV48GAMErrors.Count > 0 )
         {
            AV94GXV12 = 1;
            while ( AV94GXV12 <= AV48GAMErrors.Count )
            {
               AV66GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV48GAMErrors.Item(AV94GXV12));
               GX_msglist.addItem(AV66GAMError.gxTpr_Message);
               AV94GXV12 = (int)(AV94GXV12+1);
            }
         }
         else
         {
            context.CommitDataStores("wp_locationreceptionists",pr_default);
            new prc_senduseractivationlink(context).executeSubmit(  AV34ReceptionistGuid_Selected,  AV69ActivactionKey,  AV35baseUrl, ref  AV36isSent, ref  AV67ErrDescription, ref  AV68GAMerrorCollection) ;
            GX_msglist.addItem(context.GetMessage( "Invitation sent successfully.", ""));
         }
      }

      protected void S222( )
      {
         /* 'DO USERACTIONBLOCK' Routine */
         returnInSub = false;
         if ( AV70IsAuthorized_UserActionBlock )
         {
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_USERACTIONBLOCKContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S282( )
      {
         /* 'DO ACTION USERACTIONBLOCK' Routine */
         returnInSub = false;
         AV74Trn_Receptionist.Load(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Receptionistid, ((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Organisationid, ((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Locationid);
         AV74Trn_Receptionist.gxTpr_Receptionistisactive = false;
         AV74Trn_Receptionist.Save();
         if ( AV74Trn_Receptionist.Success() )
         {
            context.CommitDataStores("wp_locationreceptionists",pr_default);
            gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  AV78ReceptionistTitle+" "+context.GetMessage( "Blocked sucessfully", ""),  "success",  "",  "true",  ""));
         }
         else
         {
            AV75Messages = AV74Trn_Receptionist.GetMessages();
            AV95GXV13 = 1;
            while ( AV95GXV13 <= AV75Messages.Count )
            {
               AV76MessageItem = ((GeneXus.Utils.SdtMessages_Message)AV75Messages.Item(AV95GXV13));
               GX_msglist.addItem(AV76MessageItem.gxTpr_Description);
               AV95GXV13 = (int)(AV95GXV13+1);
            }
         }
      }

      protected void S232( )
      {
         /* 'DO USERACTIONUNBLOCK' Routine */
         returnInSub = false;
         if ( AV71IsAuthorized_UserActionUnblock )
         {
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCKContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S292( )
      {
         /* 'DO ACTION USERACTIONUNBLOCK' Routine */
         returnInSub = false;
         AV74Trn_Receptionist.Load(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Receptionistid, ((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Organisationid, ((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Locationid);
         AV74Trn_Receptionist.gxTpr_Receptionistisactive = true;
         AV74Trn_Receptionist.Save();
         if ( AV74Trn_Receptionist.Success() )
         {
            context.CommitDataStores("wp_locationreceptionists",pr_default);
            gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  AV78ReceptionistTitle+" "+context.GetMessage( "Unblocked sucessfully", ""),  "success",  "",  "true",  ""));
         }
         else
         {
            AV75Messages = AV74Trn_Receptionist.GetMessages();
            AV96GXV14 = 1;
            while ( AV96GXV14 <= AV75Messages.Count )
            {
               AV76MessageItem = ((GeneXus.Utils.SdtMessages_Message)AV75Messages.Item(AV96GXV14));
               GX_msglist.addItem(AV76MessageItem.gxTpr_Description);
               AV96GXV14 = (int)(AV96GXV14+1);
            }
         }
      }

      protected void S242( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_receptionist.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Receptionistid.ToString()) + "," + UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Organisationid.ToString()) + "," + UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Locationid.ToString());
         CallWebObject(formatLink("trn_receptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S252( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_receptionist.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Receptionistid.ToString()) + "," + UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Organisationid.ToString()) + "," + UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Locationid.ToString());
         CallWebObject(formatLink("trn_receptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S262( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_receptionist.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Receptionistid.ToString()) + "," + UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Organisationid.ToString()) + "," + UrlEncode(((SdtSDT_Receptionist)(AV14SDT_Receptionists.CurrentItem)).gxTpr_Locationid.ToString());
         CallWebObject(formatLink("trn_receptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV91Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV91Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV91Pgmname+"GridState"), null, "", "");
         }
         AV54OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV54OrderedBy", StringUtil.LTrimStr( (decimal)(AV54OrderedBy), 4, 0));
         AV55OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV55OrderedDsc", AV55OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S202 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S202( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV97GXV15 = 1;
         while ( AV97GXV15 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV97GXV15));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
            }
            AV97GXV15 = (int)(AV97GXV15+1);
         }
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV91Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV54OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV55OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)),  0,  AV13FilterFullText,  AV13FilterFullText,  false,  "",  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV91Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void E205Z2( )
      {
         /* Filterfulltext_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'RELOADGRIDSDT' */
         S182 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV45 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14SDT_Receptionists", AV14SDT_Receptionists);
            nGXsfl_45_bak_idx = nGXsfl_45_idx;
            gxgrGrid_refresh( subGrid_Rows, AV19ManageFiltersExecutionStep, AV40ColumnsSelector, AV91Pgmname, AV54OrderedBy, AV55OrderedDsc, AV13FilterFullText, A11OrganisationId, AV6WWPContext, AV93Udparg1, A29LocationId, AV15LocationOption, A89ReceptionistId, A95ReceptionistGAMGUID, A31LocationName, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A369ReceptionistIsActive, AV14SDT_Receptionists, AV44IsAuthorized_ReSendInvite, AV70IsAuthorized_UserActionBlock, AV71IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV30IsAuthorized_Update, AV31IsAuthorized_Delete, AV47IsAuthorized_SDT_Receptionists, AV78ReceptionistTitle) ;
            nGXsfl_45_idx = nGXsfl_45_bak_idx;
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
         }
      }

      protected void S182( )
      {
         /* 'RELOADGRIDSDT' Routine */
         returnInSub = false;
         AV14SDT_Receptionists.Clear();
         gx_BV45 = true;
         AV93Udparg1 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV15LocationOption ,
                                              A29LocationId ,
                                              A11OrganisationId ,
                                              AV6WWPContext.gxTpr_Isrootadmin ,
                                              AV6WWPContext.gxTpr_Organisationid ,
                                              AV93Udparg1 ,
                                              AV13FilterFullText } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H005Z4 */
         pr_default.execute(2, new Object[] {AV6WWPContext.gxTpr_Organisationid, AV6WWPContext.gxTpr_Isrootadmin, AV93Udparg1, AV13FilterFullText, AV13FilterFullText, AV13FilterFullText, AV13FilterFullText, AV15LocationOption});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A90ReceptionistGivenName = H005Z4_A90ReceptionistGivenName[0];
            A91ReceptionistLastName = H005Z4_A91ReceptionistLastName[0];
            A93ReceptionistEmail = H005Z4_A93ReceptionistEmail[0];
            A94ReceptionistPhone = H005Z4_A94ReceptionistPhone[0];
            A29LocationId = H005Z4_A29LocationId[0];
            A11OrganisationId = H005Z4_A11OrganisationId[0];
            A89ReceptionistId = H005Z4_A89ReceptionistId[0];
            A95ReceptionistGAMGUID = H005Z4_A95ReceptionistGAMGUID[0];
            A31LocationName = H005Z4_A31LocationName[0];
            A369ReceptionistIsActive = H005Z4_A369ReceptionistIsActive[0];
            A31LocationName = H005Z4_A31LocationName[0];
            AV27SDT_Receptionist = new SdtSDT_Receptionist(context);
            AV27SDT_Receptionist.gxTpr_Receptionistid = A89ReceptionistId;
            AV27SDT_Receptionist.gxTpr_Receptionistgamguid = A95ReceptionistGAMGUID;
            AV27SDT_Receptionist.gxTpr_Locationid = A29LocationId;
            AV27SDT_Receptionist.gxTpr_Locationname = A31LocationName;
            AV27SDT_Receptionist.gxTpr_Organisationid = A11OrganisationId;
            AV27SDT_Receptionist.gxTpr_Receptionistgivenname = A90ReceptionistGivenName;
            AV27SDT_Receptionist.gxTpr_Receptionistlastname = A91ReceptionistLastName;
            AV27SDT_Receptionist.gxTpr_Receptionistemail = A93ReceptionistEmail;
            AV27SDT_Receptionist.gxTpr_Receptionistphone = A94ReceptionistPhone;
            if ( A369ReceptionistIsActive )
            {
               AV27SDT_Receptionist.gxTpr_Receptioniststatus = "Active";
            }
            else
            {
               AV27SDT_Receptionist.gxTpr_Receptioniststatus = "Inactive";
            }
            AV14SDT_Receptionists.Add(AV27SDT_Receptionist, 0);
            gx_BV45 = true;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void wb_table3_76_5Z2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_useractionunblock_Internalname, tblTabledvelop_confirmpanel_useractionunblock_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_useractionunblock.SetProperty("Title", Dvelop_confirmpanel_useractionunblock_Title);
            ucDvelop_confirmpanel_useractionunblock.SetProperty("ConfirmationText", Dvelop_confirmpanel_useractionunblock_Confirmationtext);
            ucDvelop_confirmpanel_useractionunblock.SetProperty("YesButtonCaption", Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption);
            ucDvelop_confirmpanel_useractionunblock.SetProperty("NoButtonCaption", Dvelop_confirmpanel_useractionunblock_Nobuttoncaption);
            ucDvelop_confirmpanel_useractionunblock.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption);
            ucDvelop_confirmpanel_useractionunblock.SetProperty("YesButtonPosition", Dvelop_confirmpanel_useractionunblock_Yesbuttonposition);
            ucDvelop_confirmpanel_useractionunblock.SetProperty("ConfirmType", Dvelop_confirmpanel_useractionunblock_Confirmtype);
            ucDvelop_confirmpanel_useractionunblock.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_useractionunblock_Internalname, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCKContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_USERACTIONUNBLOCKContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_76_5Z2e( true) ;
         }
         else
         {
            wb_table3_76_5Z2e( false) ;
         }
      }

      protected void wb_table2_71_5Z2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_useractionblock_Internalname, tblTabledvelop_confirmpanel_useractionblock_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_useractionblock.SetProperty("Title", Dvelop_confirmpanel_useractionblock_Title);
            ucDvelop_confirmpanel_useractionblock.SetProperty("ConfirmationText", Dvelop_confirmpanel_useractionblock_Confirmationtext);
            ucDvelop_confirmpanel_useractionblock.SetProperty("YesButtonCaption", Dvelop_confirmpanel_useractionblock_Yesbuttoncaption);
            ucDvelop_confirmpanel_useractionblock.SetProperty("NoButtonCaption", Dvelop_confirmpanel_useractionblock_Nobuttoncaption);
            ucDvelop_confirmpanel_useractionblock.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption);
            ucDvelop_confirmpanel_useractionblock.SetProperty("YesButtonPosition", Dvelop_confirmpanel_useractionblock_Yesbuttonposition);
            ucDvelop_confirmpanel_useractionblock.SetProperty("ConfirmType", Dvelop_confirmpanel_useractionblock_Confirmtype);
            ucDvelop_confirmpanel_useractionblock.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_useractionblock_Internalname, "DVELOP_CONFIRMPANEL_USERACTIONBLOCKContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_USERACTIONBLOCKContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_71_5Z2e( true) ;
         }
         else
         {
            wb_table2_71_5Z2e( false) ;
         }
      }

      protected void wb_table1_66_5Z2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_resendinvite_Internalname, tblTabledvelop_confirmpanel_resendinvite_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_resendinvite.SetProperty("Title", Dvelop_confirmpanel_resendinvite_Title);
            ucDvelop_confirmpanel_resendinvite.SetProperty("ConfirmationText", Dvelop_confirmpanel_resendinvite_Confirmationtext);
            ucDvelop_confirmpanel_resendinvite.SetProperty("YesButtonCaption", Dvelop_confirmpanel_resendinvite_Yesbuttoncaption);
            ucDvelop_confirmpanel_resendinvite.SetProperty("NoButtonCaption", Dvelop_confirmpanel_resendinvite_Nobuttoncaption);
            ucDvelop_confirmpanel_resendinvite.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption);
            ucDvelop_confirmpanel_resendinvite.SetProperty("YesButtonPosition", Dvelop_confirmpanel_resendinvite_Yesbuttonposition);
            ucDvelop_confirmpanel_resendinvite.SetProperty("ConfirmType", Dvelop_confirmpanel_resendinvite_Confirmtype);
            ucDvelop_confirmpanel_resendinvite.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_resendinvite_Internalname, "DVELOP_CONFIRMPANEL_RESENDINVITEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_RESENDINVITEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_66_5Z2e( true) ;
         }
         else
         {
            wb_table1_66_5Z2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV51Message = (string)getParm(obj,0);
         AssignAttri("", false, "AV51Message", AV51Message);
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
         PA5Z2( ) ;
         WS5Z2( ) ;
         WE5Z2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145444152", true, true);
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
         context.AddJavascriptSource("wp_locationreceptionists.js", "?20256145444158", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_452( )
      {
         edtavSdt_receptionists__receptionistid_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTID_"+sGXsfl_45_idx;
         edtavSdt_receptionists__organisationid_Internalname = "SDT_RECEPTIONISTS__ORGANISATIONID_"+sGXsfl_45_idx;
         edtavSdt_receptionists__locationid_Internalname = "SDT_RECEPTIONISTS__LOCATIONID_"+sGXsfl_45_idx;
         edtavSdt_receptionists__receptionistgivenname_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME_"+sGXsfl_45_idx;
         edtavSdt_receptionists__receptionistlastname_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME_"+sGXsfl_45_idx;
         edtavSdt_receptionists__receptionistemail_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTEMAIL_"+sGXsfl_45_idx;
         edtavSdt_receptionists__receptionistphone_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTPHONE_"+sGXsfl_45_idx;
         edtavSdt_receptionists__receptionistgamguid_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTGAMGUID_"+sGXsfl_45_idx;
         edtavSdt_receptionists__locationname_Internalname = "SDT_RECEPTIONISTS__LOCATIONNAME_"+sGXsfl_45_idx;
         edtavSdt_receptionists_receptioniststatus_Internalname = "SDT_RECEPTIONISTS_RECEPTIONISTSTATUS_"+sGXsfl_45_idx;
         edtavAccountstatus_Internalname = "vACCOUNTSTATUS_"+sGXsfl_45_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_45_idx;
      }

      protected void SubsflControlProps_fel_452( )
      {
         edtavSdt_receptionists__receptionistid_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTID_"+sGXsfl_45_fel_idx;
         edtavSdt_receptionists__organisationid_Internalname = "SDT_RECEPTIONISTS__ORGANISATIONID_"+sGXsfl_45_fel_idx;
         edtavSdt_receptionists__locationid_Internalname = "SDT_RECEPTIONISTS__LOCATIONID_"+sGXsfl_45_fel_idx;
         edtavSdt_receptionists__receptionistgivenname_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME_"+sGXsfl_45_fel_idx;
         edtavSdt_receptionists__receptionistlastname_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME_"+sGXsfl_45_fel_idx;
         edtavSdt_receptionists__receptionistemail_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTEMAIL_"+sGXsfl_45_fel_idx;
         edtavSdt_receptionists__receptionistphone_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTPHONE_"+sGXsfl_45_fel_idx;
         edtavSdt_receptionists__receptionistgamguid_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTGAMGUID_"+sGXsfl_45_fel_idx;
         edtavSdt_receptionists__locationname_Internalname = "SDT_RECEPTIONISTS__LOCATIONNAME_"+sGXsfl_45_fel_idx;
         edtavSdt_receptionists_receptioniststatus_Internalname = "SDT_RECEPTIONISTS_RECEPTIONISTSTATUS_"+sGXsfl_45_fel_idx;
         edtavAccountstatus_Internalname = "vACCOUNTSTATUS_"+sGXsfl_45_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_45_fel_idx;
      }

      protected void sendrow_452( )
      {
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
         SubsflControlProps_452( ) ;
         WB5Z0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_45_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_45_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWithSelection WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_45_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistid_Internalname,((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1)).gxTpr_Receptionistid.ToString(),((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1)).gxTpr_Receptionistid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__receptionistid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)45,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__organisationid_Internalname,((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1)).gxTpr_Organisationid.ToString(),((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1)).gxTpr_Organisationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__organisationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__organisationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)45,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__locationid_Internalname,((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1)).gxTpr_Locationid.ToString(),((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1)).gxTpr_Locationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__locationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__locationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)45,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdt_receptionists__receptionistgivenname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_45_idx + "',45)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistgivenname_Internalname,((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1)).gxTpr_Receptionistgivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavSdt_receptionists__receptionistgivenname_Link,(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistgivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdt_receptionists__receptionistgivenname_Visible,(int)edtavSdt_receptionists__receptionistgivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdt_receptionists__receptionistlastname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_45_idx + "',45)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistlastname_Internalname,((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1)).gxTpr_Receptionistlastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavSdt_receptionists__receptionistlastname_Link,(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistlastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdt_receptionists__receptionistlastname_Visible,(int)edtavSdt_receptionists__receptionistlastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdt_receptionists__receptionistemail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_45_idx + "',45)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistemail_Internalname,((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1)).gxTpr_Receptionistemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdt_receptionists__receptionistemail_Visible,(int)edtavSdt_receptionists__receptionistemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdt_receptionists__receptionistphone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_45_idx + "',45)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistphone_Internalname,StringUtil.RTrim( ((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1)).gxTpr_Receptionistphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdt_receptionists__receptionistphone_Visible,(int)edtavSdt_receptionists__receptionistphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistgamguid_Internalname,((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1)).gxTpr_Receptionistgamguid,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistgamguid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__receptionistgamguid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)45,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdt_receptionists__locationname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_45_idx + "',45)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__locationname_Internalname,((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1)).gxTpr_Locationname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__locationname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdt_receptionists__locationname_Visible,(int)edtavSdt_receptionists__locationname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists_receptioniststatus_Internalname,StringUtil.RTrim( ((SdtSDT_Receptionist)AV14SDT_Receptionists.Item(AV80GXV1)).gxTpr_Receptioniststatus),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists_receptioniststatus_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSdt_receptionists_receptioniststatus_Columnclass,(string)"",(short)0,(int)edtavSdt_receptionists_receptioniststatus_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavAccountstatus_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_45_idx + "',45)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAccountstatus_Internalname,(string)AV50AccountStatus,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAccountstatus_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavAccountstatus_Columnclass,(string)edtavAccountstatus_Columnheaderclass,(int)edtavAccountstatus_Visible,(int)edtavAccountstatus_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_45_idx + "',45)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_45_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  if ( ( AV80GXV1 > 0 ) && ( AV14SDT_Receptionists.Count >= AV80GXV1 ) && (0==AV37ActionGroup) )
                  {
                     AV37ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV37ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV37ActionGroup), 4, 0));
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV37ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_45_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavActiongroup_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV37ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_45_Refreshing);
            send_integrity_lvl_hashes5Z2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_45_idx = ((subGrid_Islastpage==1)&&(nGXsfl_45_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_45_idx+1);
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
         }
         /* End function sendrow_452 */
      }

      protected void init_web_controls( )
      {
         dynavLocationoption.Name = "vLOCATIONOPTION";
         dynavLocationoption.WebTags = "";
         GXCCtl = "vACTIONGROUP_" + sGXsfl_45_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            if ( ( AV80GXV1 > 0 ) && ( AV14SDT_Receptionists.Count >= AV80GXV1 ) && (0==AV37ActionGroup) )
            {
               AV37ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV37ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV37ActionGroup), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl45( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"45\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWithSelection WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdt_receptionists__receptionistgivenname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "First Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdt_receptionists__receptionistlastname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdt_receptionists__receptionistemail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdt_receptionists__receptionistphone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdt_receptionists__locationname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavAccountstatus_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Account Status", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+cmbavActiongroup_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__organisationid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__locationid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistgivenname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavSdt_receptionists__receptionistgivenname_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistgivenname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistlastname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavSdt_receptionists__receptionistlastname_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistlastname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistemail_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistemail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistphone_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistphone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistgamguid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__locationname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__locationname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSdt_receptionists_receptioniststatus_Columnclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists_receptioniststatus_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV50AccountStatus));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavAccountstatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavAccountstatus_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAccountstatus_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAccountstatus_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ActionGroup), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavActiongroup_Class));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         lblTextblocklocationoption_Internalname = "TEXTBLOCKLOCATIONOPTION";
         dynavLocationoption_Internalname = "vLOCATIONOPTION";
         divUnnamedtablelocationoption_Internalname = "UNNAMEDTABLELOCATIONOPTION";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavSdt_receptionists__receptionistid_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTID";
         edtavSdt_receptionists__organisationid_Internalname = "SDT_RECEPTIONISTS__ORGANISATIONID";
         edtavSdt_receptionists__locationid_Internalname = "SDT_RECEPTIONISTS__LOCATIONID";
         edtavSdt_receptionists__receptionistgivenname_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME";
         edtavSdt_receptionists__receptionistlastname_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME";
         edtavSdt_receptionists__receptionistemail_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTEMAIL";
         edtavSdt_receptionists__receptionistphone_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTPHONE";
         edtavSdt_receptionists__receptionistgamguid_Internalname = "SDT_RECEPTIONISTS__RECEPTIONISTGAMGUID";
         edtavSdt_receptionists__locationname_Internalname = "SDT_RECEPTIONISTS__LOCATIONNAME";
         edtavSdt_receptionists_receptioniststatus_Internalname = "SDT_RECEPTIONISTS_RECEPTIONISTSTATUS";
         edtavAccountstatus_Internalname = "vACCOUNTSTATUS";
         cmbavActiongroup_Internalname = "vACTIONGROUP";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_resendinvite_Internalname = "DVELOP_CONFIRMPANEL_RESENDINVITE";
         tblTabledvelop_confirmpanel_resendinvite_Internalname = "TABLEDVELOP_CONFIRMPANEL_RESENDINVITE";
         Dvelop_confirmpanel_useractionblock_Internalname = "DVELOP_CONFIRMPANEL_USERACTIONBLOCK";
         tblTabledvelop_confirmpanel_useractionblock_Internalname = "TABLEDVELOP_CONFIRMPANEL_USERACTIONBLOCK";
         Dvelop_confirmpanel_useractionunblock_Internalname = "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK";
         tblTabledvelop_confirmpanel_useractionunblock_Internalname = "TABLEDVELOP_CONFIRMPANEL_USERACTIONUNBLOCK";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowhovering = -1;
         subGrid_Allowselection = 1;
         subGrid_Header = "";
         cmbavActiongroup_Jsonclick = "";
         cmbavActiongroup_Class = "ConvertToDDO";
         edtavAccountstatus_Jsonclick = "";
         edtavAccountstatus_Columnclass = "WWColumn";
         edtavAccountstatus_Enabled = 1;
         edtavSdt_receptionists_receptioniststatus_Jsonclick = "";
         edtavSdt_receptionists_receptioniststatus_Columnclass = "WWColumn";
         edtavSdt_receptionists_receptioniststatus_Enabled = 0;
         edtavSdt_receptionists__locationname_Jsonclick = "";
         edtavSdt_receptionists__locationname_Enabled = 0;
         edtavSdt_receptionists__locationname_Visible = -1;
         edtavSdt_receptionists__receptionistgamguid_Jsonclick = "";
         edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
         edtavSdt_receptionists__receptionistphone_Jsonclick = "";
         edtavSdt_receptionists__receptionistphone_Enabled = 0;
         edtavSdt_receptionists__receptionistphone_Visible = -1;
         edtavSdt_receptionists__receptionistemail_Jsonclick = "";
         edtavSdt_receptionists__receptionistemail_Enabled = 0;
         edtavSdt_receptionists__receptionistemail_Visible = -1;
         edtavSdt_receptionists__receptionistlastname_Jsonclick = "";
         edtavSdt_receptionists__receptionistlastname_Link = "";
         edtavSdt_receptionists__receptionistlastname_Enabled = 0;
         edtavSdt_receptionists__receptionistlastname_Visible = -1;
         edtavSdt_receptionists__receptionistgivenname_Jsonclick = "";
         edtavSdt_receptionists__receptionistgivenname_Link = "";
         edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
         edtavSdt_receptionists__receptionistgivenname_Visible = -1;
         edtavSdt_receptionists__locationid_Jsonclick = "";
         edtavSdt_receptionists__locationid_Enabled = 0;
         edtavSdt_receptionists__organisationid_Jsonclick = "";
         edtavSdt_receptionists__organisationid_Enabled = 0;
         edtavSdt_receptionists__receptionistid_Jsonclick = "";
         edtavSdt_receptionists__receptionistid_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavAccountstatus_Columnheaderclass = "";
         edtavAccountstatus_Visible = -1;
         edtavSdt_receptionists__locationname_Visible = -1;
         edtavSdt_receptionists__receptionistphone_Visible = -1;
         edtavSdt_receptionists__receptionistemail_Visible = -1;
         edtavSdt_receptionists__receptionistlastname_Visible = -1;
         edtavSdt_receptionists__receptionistgivenname_Visible = -1;
         subGrid_Sortable = 0;
         edtavSdt_receptionists_receptioniststatus_Enabled = -1;
         edtavSdt_receptionists__locationname_Enabled = -1;
         edtavSdt_receptionists__receptionistgamguid_Enabled = -1;
         edtavSdt_receptionists__receptionistphone_Enabled = -1;
         edtavSdt_receptionists__receptionistemail_Enabled = -1;
         edtavSdt_receptionists__receptionistlastname_Enabled = -1;
         edtavSdt_receptionists__receptionistgivenname_Enabled = -1;
         edtavSdt_receptionists__locationid_Enabled = -1;
         edtavSdt_receptionists__organisationid_Enabled = -1;
         edtavSdt_receptionists__receptionistid_Enabled = -1;
         dynavLocationoption_Jsonclick = "";
         dynavLocationoption.Visible = 1;
         dynavLocationoption.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_useractionunblock_Confirmtype = "1";
         Dvelop_confirmpanel_useractionunblock_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractionunblock_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractionunblock_Confirmationtext = "Are you sure you want to unblock this receptionist's account?";
         Dvelop_confirmpanel_useractionunblock_Title = context.GetMessage( "Unblock Receptionist", "");
         Dvelop_confirmpanel_useractionblock_Confirmtype = "1";
         Dvelop_confirmpanel_useractionblock_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractionblock_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractionblock_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractionblock_Confirmationtext = "Are you sure you want to block this receptionist's account?";
         Dvelop_confirmpanel_useractionblock_Title = context.GetMessage( "Block Receptionist Account", "");
         Dvelop_confirmpanel_resendinvite_Confirmtype = "1";
         Dvelop_confirmpanel_resendinvite_Yesbuttonposition = "left";
         Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_resendinvite_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_resendinvite_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_resendinvite_Confirmationtext = "Are you sure you want to re-send an ivititation to this receptionist?";
         Dvelop_confirmpanel_resendinvite_Title = context.GetMessage( "Re - Send Invitation", "");
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "3:SDT_Receptionists__ReceptionistGivenName|4:SDT_Receptionists__ReceptionistLastName|5:SDT_Receptionists__ReceptionistEmail|10:AccountStatus";
         Ddo_grid_Gridinternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Location Receptionists", "");
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV93Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV15LocationOption","fld":"vLOCATIONOPTION"},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A95ReceptionistGAMGUID","fld":"RECEPTIONISTGAMGUID"},{"av":"A31LocationName","fld":"LOCATIONNAME"},{"av":"A90ReceptionistGivenName","fld":"RECEPTIONISTGIVENNAME"},{"av":"A91ReceptionistLastName","fld":"RECEPTIONISTLASTNAME"},{"av":"A93ReceptionistEmail","fld":"RECEPTIONISTEMAIL"},{"av":"A94ReceptionistPhone","fld":"RECEPTIONISTPHONE"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV47IsAuthorized_SDT_Receptionists","fld":"vISAUTHORIZED_SDT_RECEPTIONISTS","hsh":true},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTEMAIL","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTPHONE","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__LOCATIONNAME","prop":"Visible"},{"av":"edtavAccountstatus_Visible","ctrl":"vACCOUNTSTATUS","prop":"Visible"},{"av":"AV21GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV22GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV23GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"ctrl":"FORM","prop":"Caption"},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E125Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV93Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV15LocationOption","fld":"vLOCATIONOPTION"},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A95ReceptionistGAMGUID","fld":"RECEPTIONISTGAMGUID"},{"av":"A31LocationName","fld":"LOCATIONNAME"},{"av":"A90ReceptionistGivenName","fld":"RECEPTIONISTGIVENNAME"},{"av":"A91ReceptionistLastName","fld":"RECEPTIONISTLASTNAME"},{"av":"A93ReceptionistEmail","fld":"RECEPTIONISTEMAIL"},{"av":"A94ReceptionistPhone","fld":"RECEPTIONISTPHONE"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV47IsAuthorized_SDT_Receptionists","fld":"vISAUTHORIZED_SDT_RECEPTIONISTS","hsh":true},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E135Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV93Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV15LocationOption","fld":"vLOCATIONOPTION"},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A95ReceptionistGAMGUID","fld":"RECEPTIONISTGAMGUID"},{"av":"A31LocationName","fld":"LOCATIONNAME"},{"av":"A90ReceptionistGivenName","fld":"RECEPTIONISTGIVENNAME"},{"av":"A91ReceptionistLastName","fld":"RECEPTIONISTLASTNAME"},{"av":"A93ReceptionistEmail","fld":"RECEPTIONISTEMAIL"},{"av":"A94ReceptionistPhone","fld":"RECEPTIONISTPHONE"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV47IsAuthorized_SDT_Receptionists","fld":"vISAUTHORIZED_SDT_RECEPTIONISTS","hsh":true},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E145Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV93Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV15LocationOption","fld":"vLOCATIONOPTION"},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A95ReceptionistGAMGUID","fld":"RECEPTIONISTGAMGUID"},{"av":"A31LocationName","fld":"LOCATIONNAME"},{"av":"A90ReceptionistGivenName","fld":"RECEPTIONISTGIVENNAME"},{"av":"A91ReceptionistLastName","fld":"RECEPTIONISTLASTNAME"},{"av":"A93ReceptionistEmail","fld":"RECEPTIONISTEMAIL"},{"av":"A94ReceptionistPhone","fld":"RECEPTIONISTPHONE"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV47IsAuthorized_SDT_Receptionists","fld":"vISAUTHORIZED_SDT_RECEPTIONISTS","hsh":true},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E235Z2","iparms":[{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV47IsAuthorized_SDT_Receptionists","fld":"vISAUTHORIZED_SDT_RECEPTIONISTS","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV50AccountStatus","fld":"vACCOUNTSTATUS"},{"av":"cmbavActiongroup"},{"av":"AV37ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME","prop":"Link"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME","prop":"Link"},{"ctrl":"SDT_RECEPTIONISTS_RECEPTIONISTSTATUS","prop":"Columnclass"},{"av":"edtavAccountstatus_Columnclass","ctrl":"vACCOUNTSTATUS","prop":"Columnclass"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E155Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV93Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV15LocationOption","fld":"vLOCATIONOPTION"},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A95ReceptionistGAMGUID","fld":"RECEPTIONISTGAMGUID"},{"av":"A31LocationName","fld":"LOCATIONNAME"},{"av":"A90ReceptionistGivenName","fld":"RECEPTIONISTGIVENNAME"},{"av":"A91ReceptionistLastName","fld":"RECEPTIONISTLASTNAME"},{"av":"A93ReceptionistEmail","fld":"RECEPTIONISTEMAIL"},{"av":"A94ReceptionistPhone","fld":"RECEPTIONISTPHONE"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV47IsAuthorized_SDT_Receptionists","fld":"vISAUTHORIZED_SDT_RECEPTIONISTS","hsh":true},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTEMAIL","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTPHONE","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__LOCATIONNAME","prop":"Visible"},{"av":"edtavAccountstatus_Visible","ctrl":"vACCOUNTSTATUS","prop":"Visible"},{"av":"AV21GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV22GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV23GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"ctrl":"FORM","prop":"Caption"},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E115Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV93Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV15LocationOption","fld":"vLOCATIONOPTION"},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A95ReceptionistGAMGUID","fld":"RECEPTIONISTGAMGUID"},{"av":"A31LocationName","fld":"LOCATIONNAME"},{"av":"A90ReceptionistGivenName","fld":"RECEPTIONISTGIVENNAME"},{"av":"A91ReceptionistLastName","fld":"RECEPTIONISTLASTNAME"},{"av":"A93ReceptionistEmail","fld":"RECEPTIONISTEMAIL"},{"av":"A94ReceptionistPhone","fld":"RECEPTIONISTPHONE"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV47IsAuthorized_SDT_Receptionists","fld":"vISAUTHORIZED_SDT_RECEPTIONISTS","hsh":true},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTEMAIL","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTPHONE","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__LOCATIONNAME","prop":"Visible"},{"av":"edtavAccountstatus_Visible","ctrl":"vACCOUNTSTATUS","prop":"Visible"},{"av":"AV21GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV22GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV23GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"ctrl":"FORM","prop":"Caption"},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E245Z2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV37ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV93Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV15LocationOption","fld":"vLOCATIONOPTION"},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A95ReceptionistGAMGUID","fld":"RECEPTIONISTGAMGUID"},{"av":"A31LocationName","fld":"LOCATIONNAME"},{"av":"A90ReceptionistGivenName","fld":"RECEPTIONISTGIVENNAME"},{"av":"A91ReceptionistLastName","fld":"RECEPTIONISTLASTNAME"},{"av":"A93ReceptionistEmail","fld":"RECEPTIONISTEMAIL"},{"av":"A94ReceptionistPhone","fld":"RECEPTIONISTPHONE"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV47IsAuthorized_SDT_Receptionists","fld":"vISAUTHORIZED_SDT_RECEPTIONISTS","hsh":true},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV37ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTEMAIL","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTPHONE","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__LOCATIONNAME","prop":"Visible"},{"av":"edtavAccountstatus_Visible","ctrl":"vACCOUNTSTATUS","prop":"Visible"},{"av":"AV21GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV22GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV23GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"ctrl":"FORM","prop":"Caption"},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_RESENDINVITE.CLOSE","""{"handler":"E165Z2","iparms":[{"av":"Dvelop_confirmpanel_resendinvite_Result","ctrl":"DVELOP_CONFIRMPANEL_RESENDINVITE","prop":"Result"},{"av":"AV8HTTPRequest.BaseURL","ctrl":"vHTTPREQUEST","prop":"Baseurl"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"AV36isSent","fld":"vISSENT"},{"av":"AV67ErrDescription","fld":"vERRDESCRIPTION"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_RESENDINVITE.CLOSE",""","oparms":[{"av":"AV67ErrDescription","fld":"vERRDESCRIPTION"},{"av":"AV36isSent","fld":"vISSENT"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONBLOCK.CLOSE","""{"handler":"E175Z2","iparms":[{"av":"Dvelop_confirmpanel_useractionblock_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONBLOCK","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV93Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV15LocationOption","fld":"vLOCATIONOPTION"},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A95ReceptionistGAMGUID","fld":"RECEPTIONISTGAMGUID"},{"av":"A31LocationName","fld":"LOCATIONNAME"},{"av":"A90ReceptionistGivenName","fld":"RECEPTIONISTGIVENNAME"},{"av":"A91ReceptionistLastName","fld":"RECEPTIONISTLASTNAME"},{"av":"A93ReceptionistEmail","fld":"RECEPTIONISTEMAIL"},{"av":"A94ReceptionistPhone","fld":"RECEPTIONISTPHONE"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV47IsAuthorized_SDT_Receptionists","fld":"vISAUTHORIZED_SDT_RECEPTIONISTS","hsh":true},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONBLOCK.CLOSE",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTEMAIL","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTPHONE","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__LOCATIONNAME","prop":"Visible"},{"av":"edtavAccountstatus_Visible","ctrl":"vACCOUNTSTATUS","prop":"Visible"},{"av":"AV21GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV22GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV23GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"ctrl":"FORM","prop":"Caption"},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK.CLOSE","""{"handler":"E185Z2","iparms":[{"av":"Dvelop_confirmpanel_useractionunblock_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV93Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV15LocationOption","fld":"vLOCATIONOPTION"},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A95ReceptionistGAMGUID","fld":"RECEPTIONISTGAMGUID"},{"av":"A31LocationName","fld":"LOCATIONNAME"},{"av":"A90ReceptionistGivenName","fld":"RECEPTIONISTGIVENNAME"},{"av":"A91ReceptionistLastName","fld":"RECEPTIONISTLASTNAME"},{"av":"A93ReceptionistEmail","fld":"RECEPTIONISTEMAIL"},{"av":"A94ReceptionistPhone","fld":"RECEPTIONISTPHONE"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV47IsAuthorized_SDT_Receptionists","fld":"vISAUTHORIZED_SDT_RECEPTIONISTS","hsh":true},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK.CLOSE",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTEMAIL","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__RECEPTIONISTPHONE","prop":"Visible"},{"ctrl":"SDT_RECEPTIONISTS__LOCATIONNAME","prop":"Visible"},{"av":"edtavAccountstatus_Visible","ctrl":"vACCOUNTSTATUS","prop":"Visible"},{"av":"AV21GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV22GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV23GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true},{"ctrl":"FORM","prop":"Caption"},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E195Z2","iparms":[{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
         setEventMetadata("VFILTERFULLTEXT.CONTROLVALUECHANGED","""{"handler":"E205Z2","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV93Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV15LocationOption","fld":"vLOCATIONOPTION"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A95ReceptionistGAMGUID","fld":"RECEPTIONISTGAMGUID"},{"av":"A31LocationName","fld":"LOCATIONNAME"},{"av":"A90ReceptionistGivenName","fld":"RECEPTIONISTGIVENNAME"},{"av":"A91ReceptionistLastName","fld":"RECEPTIONISTLASTNAME"},{"av":"A93ReceptionistEmail","fld":"RECEPTIONISTEMAIL"},{"av":"A94ReceptionistPhone","fld":"RECEPTIONISTPHONE"},{"av":"A369ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"},{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"GRID_nEOF"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV91Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV54OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV55OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV44IsAuthorized_ReSendInvite","fld":"vISAUTHORIZED_RESENDINVITE","hsh":true},{"av":"AV70IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV71IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV31IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV47IsAuthorized_SDT_Receptionists","fld":"vISAUTHORIZED_SDT_RECEPTIONISTS","hsh":true},{"av":"AV78ReceptionistTitle","fld":"vRECEPTIONISTTITLE","hsh":true}]""");
         setEventMetadata("VFILTERFULLTEXT.CONTROLVALUECHANGED",""","oparms":[{"av":"AV14SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45}]}""");
         setEventMetadata("VALIDV_LOCATIONOPTION","""{"handler":"Validv_Locationoption","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Actiongroup","iparms":[]}""");
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
         AV51Message = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_resendinvite_Result = "";
         AV8HTTPRequest = new GxHttpRequest( context);
         Dvelop_confirmpanel_useractionblock_Result = "";
         Dvelop_confirmpanel_useractionunblock_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV91Pgmname = "";
         AV13FilterFullText = "";
         A11OrganisationId = Guid.Empty;
         AV93Udparg1 = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV15LocationOption = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         A95ReceptionistGAMGUID = "";
         A31LocationName = "";
         A90ReceptionistGivenName = "";
         A91ReceptionistLastName = "";
         A93ReceptionistEmail = "";
         A94ReceptionistPhone = "";
         AV14SDT_Receptionists = new GXBaseCollection<SdtSDT_Receptionist>( context, "SDT_Receptionist", "Comforta_version21");
         AV78ReceptionistTitle = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV17ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV23GridAppliedFilters = "";
         AV42DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV67ErrDescription = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         lblTextblocklocationoption_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV50AccountStatus = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H005Z2_A29LocationId = new Guid[] {Guid.Empty} ;
         H005Z2_A31LocationName = new string[] {""} ;
         H005Z2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV53successmsg = "";
         AV52websession = context.GetSession();
         AV28GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser3 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_guid4 = Guid.Empty;
         AV16Session = context.GetSession();
         AV38ColumnsSelectorXML = "";
         AV79ReceptionistsTitle = "";
         GridRow = new GXWebRow();
         AV18ManageFiltersXml = "";
         H005Z3_A29LocationId = new Guid[] {Guid.Empty} ;
         H005Z3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005Z3_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         H005Z3_A95ReceptionistGAMGUID = new string[] {""} ;
         H005Z3_A31LocationName = new string[] {""} ;
         H005Z3_A90ReceptionistGivenName = new string[] {""} ;
         H005Z3_A91ReceptionistLastName = new string[] {""} ;
         H005Z3_A93ReceptionistEmail = new string[] {""} ;
         H005Z3_A94ReceptionistPhone = new string[] {""} ;
         H005Z3_A369ReceptionistIsActive = new bool[] {false} ;
         AV27SDT_Receptionist = new SdtSDT_Receptionist(context);
         AV39UserCustomValue = "";
         GXt_char5 = "";
         AV41ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV35baseUrl = "";
         AV34ReceptionistGuid_Selected = "";
         AV48GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV69ActivactionKey = "";
         AV66GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV68GAMerrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV74Trn_Receptionist = new SdtTrn_Receptionist(context);
         AV75Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV76MessageItem = new GeneXus.Utils.SdtMessages_Message(context);
         AV12GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         H005Z4_A90ReceptionistGivenName = new string[] {""} ;
         H005Z4_A91ReceptionistLastName = new string[] {""} ;
         H005Z4_A93ReceptionistEmail = new string[] {""} ;
         H005Z4_A94ReceptionistPhone = new string[] {""} ;
         H005Z4_A29LocationId = new Guid[] {Guid.Empty} ;
         H005Z4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005Z4_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         H005Z4_A95ReceptionistGAMGUID = new string[] {""} ;
         H005Z4_A31LocationName = new string[] {""} ;
         H005Z4_A369ReceptionistIsActive = new bool[] {false} ;
         ucDvelop_confirmpanel_useractionunblock = new GXUserControl();
         ucDvelop_confirmpanel_useractionblock = new GXUserControl();
         ucDvelop_confirmpanel_resendinvite = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_locationreceptionists__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_locationreceptionists__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_locationreceptionists__default(),
            new Object[][] {
                new Object[] {
               H005Z2_A29LocationId, H005Z2_A31LocationName, H005Z2_A11OrganisationId
               }
               , new Object[] {
               H005Z3_A29LocationId, H005Z3_A11OrganisationId, H005Z3_A89ReceptionistId, H005Z3_A95ReceptionistGAMGUID, H005Z3_A31LocationName, H005Z3_A90ReceptionistGivenName, H005Z3_A91ReceptionistLastName, H005Z3_A93ReceptionistEmail, H005Z3_A94ReceptionistPhone, H005Z3_A369ReceptionistIsActive
               }
               , new Object[] {
               H005Z4_A90ReceptionistGivenName, H005Z4_A91ReceptionistLastName, H005Z4_A93ReceptionistEmail, H005Z4_A94ReceptionistPhone, H005Z4_A29LocationId, H005Z4_A11OrganisationId, H005Z4_A89ReceptionistId, H005Z4_A95ReceptionistGAMGUID, H005Z4_A31LocationName, H005Z4_A369ReceptionistIsActive
               }
            }
         );
         AV91Pgmname = "WP_LocationReceptionists";
         /* GeneXus formulas. */
         AV91Pgmname = "WP_LocationReceptionists";
         edtavSdt_receptionists__receptionistid_Enabled = 0;
         edtavSdt_receptionists__organisationid_Enabled = 0;
         edtavSdt_receptionists__locationid_Enabled = 0;
         edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
         edtavSdt_receptionists__receptionistlastname_Enabled = 0;
         edtavSdt_receptionists__receptionistemail_Enabled = 0;
         edtavSdt_receptionists__receptionistphone_Enabled = 0;
         edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
         edtavSdt_receptionists__locationname_Enabled = 0;
         edtavSdt_receptionists_receptioniststatus_Enabled = 0;
         edtavAccountstatus_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV19ManageFiltersExecutionStep ;
      private short AV54OrderedBy ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV37ActionGroup ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_45 ;
      private int nGXsfl_45_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int AV80GXV1 ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int edtavSdt_receptionists__receptionistid_Enabled ;
      private int edtavSdt_receptionists__organisationid_Enabled ;
      private int edtavSdt_receptionists__locationid_Enabled ;
      private int edtavSdt_receptionists__receptionistgivenname_Enabled ;
      private int edtavSdt_receptionists__receptionistlastname_Enabled ;
      private int edtavSdt_receptionists__receptionistemail_Enabled ;
      private int edtavSdt_receptionists__receptionistphone_Enabled ;
      private int edtavSdt_receptionists__receptionistgamguid_Enabled ;
      private int edtavSdt_receptionists__locationname_Enabled ;
      private int edtavSdt_receptionists_receptioniststatus_Enabled ;
      private int edtavAccountstatus_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_45_fel_idx=1 ;
      private int edtavSdt_receptionists__receptionistgivenname_Visible ;
      private int edtavSdt_receptionists__receptionistlastname_Visible ;
      private int edtavSdt_receptionists__receptionistemail_Visible ;
      private int edtavSdt_receptionists__receptionistphone_Visible ;
      private int edtavSdt_receptionists__locationname_Visible ;
      private int edtavAccountstatus_Visible ;
      private int AV20PageToGo ;
      private int nGXsfl_45_bak_idx=1 ;
      private int AV94GXV12 ;
      private int AV95GXV13 ;
      private int AV96GXV14 ;
      private int AV97GXV15 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV21GridCurrentPage ;
      private long AV22GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_resendinvite_Result ;
      private string Dvelop_confirmpanel_useractionblock_Result ;
      private string Dvelop_confirmpanel_useractionunblock_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_45_idx="0001" ;
      private string AV91Pgmname ;
      private string A94ReceptionistPhone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Dvelop_confirmpanel_resendinvite_Title ;
      private string Dvelop_confirmpanel_resendinvite_Confirmationtext ;
      private string Dvelop_confirmpanel_resendinvite_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_resendinvite_Nobuttoncaption ;
      private string Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_resendinvite_Yesbuttonposition ;
      private string Dvelop_confirmpanel_resendinvite_Confirmtype ;
      private string Dvelop_confirmpanel_useractionblock_Title ;
      private string Dvelop_confirmpanel_useractionblock_Confirmationtext ;
      private string Dvelop_confirmpanel_useractionblock_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useractionblock_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useractionblock_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useractionblock_Confirmtype ;
      private string Dvelop_confirmpanel_useractionunblock_Title ;
      private string Dvelop_confirmpanel_useractionunblock_Confirmationtext ;
      private string Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useractionunblock_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useractionunblock_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useractionunblock_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divUnnamedtablelocationoption_Internalname ;
      private string lblTextblocklocationoption_Internalname ;
      private string lblTextblocklocationoption_Jsonclick ;
      private string dynavLocationoption_Internalname ;
      private string dynavLocationoption_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavAccountstatus_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string sGXsfl_45_fel_idx="0001" ;
      private string edtavSdt_receptionists__receptionistgivenname_Internalname ;
      private string edtavSdt_receptionists__receptionistlastname_Internalname ;
      private string edtavSdt_receptionists__receptionistemail_Internalname ;
      private string edtavSdt_receptionists__receptionistphone_Internalname ;
      private string edtavSdt_receptionists__locationname_Internalname ;
      private string edtavAccountstatus_Columnheaderclass ;
      private string cmbavActiongroup_Class ;
      private string edtavSdt_receptionists__receptionistgivenname_Link ;
      private string edtavSdt_receptionists__receptionistlastname_Link ;
      private string edtavSdt_receptionists_receptioniststatus_Columnclass ;
      private string edtavAccountstatus_Columnclass ;
      private string GXt_char5 ;
      private string tblTabledvelop_confirmpanel_useractionunblock_Internalname ;
      private string Dvelop_confirmpanel_useractionunblock_Internalname ;
      private string tblTabledvelop_confirmpanel_useractionblock_Internalname ;
      private string Dvelop_confirmpanel_useractionblock_Internalname ;
      private string tblTabledvelop_confirmpanel_resendinvite_Internalname ;
      private string Dvelop_confirmpanel_resendinvite_Internalname ;
      private string edtavSdt_receptionists__receptionistid_Internalname ;
      private string edtavSdt_receptionists__organisationid_Internalname ;
      private string edtavSdt_receptionists__locationid_Internalname ;
      private string edtavSdt_receptionists__receptionistgamguid_Internalname ;
      private string edtavSdt_receptionists_receptioniststatus_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_receptionists__receptionistid_Jsonclick ;
      private string edtavSdt_receptionists__organisationid_Jsonclick ;
      private string edtavSdt_receptionists__locationid_Jsonclick ;
      private string edtavSdt_receptionists__receptionistgivenname_Jsonclick ;
      private string edtavSdt_receptionists__receptionistlastname_Jsonclick ;
      private string edtavSdt_receptionists__receptionistemail_Jsonclick ;
      private string edtavSdt_receptionists__receptionistphone_Jsonclick ;
      private string edtavSdt_receptionists__receptionistgamguid_Jsonclick ;
      private string edtavSdt_receptionists__locationname_Jsonclick ;
      private string edtavSdt_receptionists_receptioniststatus_Jsonclick ;
      private string edtavAccountstatus_Jsonclick ;
      private string GXCCtl ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV55OrderedDsc ;
      private bool A369ReceptionistIsActive ;
      private bool AV44IsAuthorized_ReSendInvite ;
      private bool AV70IsAuthorized_UserActionBlock ;
      private bool AV71IsAuthorized_UserActionUnblock ;
      private bool AV43IsAuthorized_Display ;
      private bool AV30IsAuthorized_Update ;
      private bool AV31IsAuthorized_Delete ;
      private bool AV47IsAuthorized_SDT_Receptionists ;
      private bool AV36isSent ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_45_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV45IsGAMActive ;
      private bool AV49IsGAMBlocked ;
      private bool gx_BV45 ;
      private bool AV6WWPContext_gxTpr_Isrootadmin ;
      private bool AV29IsAuthorized_Insert ;
      private bool GXt_boolean1 ;
      private string AV38ColumnsSelectorXML ;
      private string AV18ManageFiltersXml ;
      private string AV39UserCustomValue ;
      private string AV51Message ;
      private string AV13FilterFullText ;
      private string A95ReceptionistGAMGUID ;
      private string A31LocationName ;
      private string A90ReceptionistGivenName ;
      private string A91ReceptionistLastName ;
      private string A93ReceptionistEmail ;
      private string AV78ReceptionistTitle ;
      private string AV23GridAppliedFilters ;
      private string AV67ErrDescription ;
      private string AV50AccountStatus ;
      private string AV53successmsg ;
      private string AV79ReceptionistsTitle ;
      private string AV35baseUrl ;
      private string AV34ReceptionistGuid_Selected ;
      private string AV69ActivactionKey ;
      private Guid A11OrganisationId ;
      private Guid AV93Udparg1 ;
      private Guid A29LocationId ;
      private Guid AV15LocationOption ;
      private Guid A89ReceptionistId ;
      private Guid GXt_guid4 ;
      private Guid AV6WWPContext_gxTpr_Organisationid ;
      private IGxSession AV52websession ;
      private IGxSession AV16Session ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_useractionunblock ;
      private GXUserControl ucDvelop_confirmpanel_useractionblock ;
      private GXUserControl ucDvelop_confirmpanel_resendinvite ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavLocationoption ;
      private GXCombobox cmbavActiongroup ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV40ColumnsSelector ;
      private GXBaseCollection<SdtSDT_Receptionist> AV14SDT_Receptionists ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV42DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private Guid[] H005Z2_A29LocationId ;
      private string[] H005Z2_A31LocationName ;
      private Guid[] H005Z2_A11OrganisationId ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV28GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser3 ;
      private Guid[] H005Z3_A29LocationId ;
      private Guid[] H005Z3_A11OrganisationId ;
      private Guid[] H005Z3_A89ReceptionistId ;
      private string[] H005Z3_A95ReceptionistGAMGUID ;
      private string[] H005Z3_A31LocationName ;
      private string[] H005Z3_A90ReceptionistGivenName ;
      private string[] H005Z3_A91ReceptionistLastName ;
      private string[] H005Z3_A93ReceptionistEmail ;
      private string[] H005Z3_A94ReceptionistPhone ;
      private bool[] H005Z3_A369ReceptionistIsActive ;
      private SdtSDT_Receptionist AV27SDT_Receptionist ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV41ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV48GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV66GAMError ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV68GAMerrorCollection ;
      private SdtTrn_Receptionist AV74Trn_Receptionist ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV75Messages ;
      private GeneXus.Utils.SdtMessages_Message AV76MessageItem ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private string[] H005Z4_A90ReceptionistGivenName ;
      private string[] H005Z4_A91ReceptionistLastName ;
      private string[] H005Z4_A93ReceptionistEmail ;
      private string[] H005Z4_A94ReceptionistPhone ;
      private Guid[] H005Z4_A29LocationId ;
      private Guid[] H005Z4_A11OrganisationId ;
      private Guid[] H005Z4_A89ReceptionistId ;
      private string[] H005Z4_A95ReceptionistGAMGUID ;
      private string[] H005Z4_A31LocationName ;
      private bool[] H005Z4_A369ReceptionistIsActive ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP0_Message ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_locationreceptionists__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_locationreceptionists__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_locationreceptionists__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_H005Z3( IGxContext context ,
                                          Guid AV15LocationOption ,
                                          Guid A29LocationId ,
                                          Guid A11OrganisationId ,
                                          bool AV6WWPContext_gxTpr_Isrootadmin ,
                                          Guid AV6WWPContext_gxTpr_Organisationid ,
                                          Guid AV93Udparg1 )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int7 = new short[4];
      Object[] GXv_Object8 = new Object[2];
      scmdbuf = "SELECT T1.LocationId, T1.OrganisationId, T1.ReceptionistId, T1.ReceptionistGAMGUID, T2.LocationName, T1.ReceptionistGivenName, T1.ReceptionistLastName, T1.ReceptionistEmail, T1.ReceptionistPhone, T1.ReceptionistIsActive FROM (Trn_Receptionist T1 INNER JOIN Trn_Location T2 ON T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId)";
      AddWhere(sWhereString, "(T1.OrganisationId = CASE  WHEN :AV6WWPContext__Isrootadmin THEN :AV6WWPContext__Organisationid ELSE :AV93Udparg1 END)");
      if ( ! (Guid.Empty==AV15LocationOption) )
      {
         AddWhere(sWhereString, "(T1.LocationId = :AV15LocationOption)");
      }
      else
      {
         GXv_int7[3] = 1;
      }
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY T1.ReceptionistId, T1.OrganisationId, T1.LocationId";
      GXv_Object8[0] = scmdbuf;
      GXv_Object8[1] = GXv_int7;
      return GXv_Object8 ;
   }

   protected Object[] conditional_H005Z4( IGxContext context ,
                                          Guid AV15LocationOption ,
                                          Guid A29LocationId ,
                                          Guid A11OrganisationId ,
                                          bool AV6WWPContext_gxTpr_Isrootadmin ,
                                          Guid AV6WWPContext_gxTpr_Organisationid ,
                                          Guid AV93Udparg1 ,
                                          string AV13FilterFullText )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int9 = new short[8];
      Object[] GXv_Object10 = new Object[2];
      scmdbuf = "SELECT T1.ReceptionistGivenName, T1.ReceptionistLastName, T1.ReceptionistEmail, T1.ReceptionistPhone, T1.LocationId, T1.OrganisationId, T1.ReceptionistId, T1.ReceptionistGAMGUID, T2.LocationName, T1.ReceptionistIsActive FROM (Trn_Receptionist T1 INNER JOIN Trn_Location T2 ON T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId)";
      AddWhere(sWhereString, "(T1.OrganisationId = CASE  WHEN :AV6WWPContext__Isrootadmin THEN :AV6WWPContext__Organisationid ELSE :AV93Udparg1 END)");
      AddWhere(sWhereString, "(POSITION(RTRIM(LOWER(:AV13FilterFullText)) IN LOWER(T1.ReceptionistGivenName)) >= 1 or POSITION(RTRIM(LOWER(:AV13FilterFullText)) IN LOWER(T1.ReceptionistLastName)) >= 1 or POSITION(RTRIM(LOWER(:AV13FilterFullText)) IN LOWER(T1.ReceptionistEmail)) >= 1 or POSITION(RTRIM(:AV13FilterFullText) IN T1.ReceptionistPhone) >= 1)");
      if ( ! (Guid.Empty==AV15LocationOption) )
      {
         AddWhere(sWhereString, "(T1.LocationId = :AV15LocationOption)");
      }
      else
      {
         GXv_int9[7] = 1;
      }
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY T1.ReceptionistId, T1.OrganisationId, T1.LocationId";
      GXv_Object10[0] = scmdbuf;
      GXv_Object10[1] = GXv_int9;
      return GXv_Object10 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 1 :
                  return conditional_H005Z3(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (bool)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] );
            case 2 :
                  return conditional_H005Z4(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (bool)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] , (string)dynConstraints[6] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH005Z2;
       prmH005Z2 = new Object[] {
       };
       Object[] prmH005Z3;
       prmH005Z3 = new Object[] {
       new ParDef("AV6WWPContext__Organisationid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV6WWPContext__Isrootadmin",GXType.Boolean,4,0) ,
       new ParDef("AV93Udparg1",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV15LocationOption",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH005Z4;
       prmH005Z4 = new Object[] {
       new ParDef("AV6WWPContext__Organisationid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV6WWPContext__Isrootadmin",GXType.Boolean,4,0) ,
       new ParDef("AV93Udparg1",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV13FilterFullText",GXType.VarChar,100,0) ,
       new ParDef("AV13FilterFullText",GXType.VarChar,100,0) ,
       new ParDef("AV13FilterFullText",GXType.VarChar,100,0) ,
       new ParDef("AV13FilterFullText",GXType.VarChar,100,0) ,
       new ParDef("AV15LocationOption",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("H005Z2", "SELECT LocationId, LocationName, OrganisationId FROM Trn_Location ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005Z2,0, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H005Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005Z3,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("H005Z4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005Z4,100, GxCacheFrequency.OFF ,false,false )
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getString(9, 20);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             return;
    }
 }

}

}
