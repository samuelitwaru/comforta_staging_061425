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
   public class wp_provisionedappdashboard : GXDataArea
   {
      public wp_provisionedappdashboard( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_provisionedappdashboard( IGxContext context )
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
         cmbavSdt_residents__residentsalutation = new GXCombobox();
         cmbavSdt_residents__residentgender = new GXCombobox();
         cmbavActiongroup = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Freestylegrid1") == 0 )
            {
               gxnrFreestylegrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Freestylegrid1") == 0 )
            {
               gxgrFreestylegrid1_refresh_invoke( ) ;
               return  ;
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

      protected void gxnrFreestylegrid1_newrow_invoke( )
      {
         nRC_GXsfl_31 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_31"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_31_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_31_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_31_idx = GetPar( "sGXsfl_31_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFreestylegrid1_newrow( ) ;
         /* End function gxnrFreestylegrid1_newrow_invoke */
      }

      protected void gxgrFreestylegrid1_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV36ResidentPackageId = StringUtil.StrToGuid( GetPar( "ResidentPackageId"));
         A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV53WWPContext);
         AV95Udparg2 = StringUtil.StrToGuid( GetPar( "Udparg2"));
         A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
         AV96Udparg3 = StringUtil.StrToGuid( GetPar( "Udparg3"));
         A62ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
         A72ResidentSalutation = GetPar( "ResidentSalutation");
         A63ResidentBsnNumber = GetPar( "ResidentBsnNumber");
         A64ResidentGivenName = GetPar( "ResidentGivenName");
         A65ResidentLastName = GetPar( "ResidentLastName");
         A66ResidentInitials = GetPar( "ResidentInitials");
         A67ResidentEmail = GetPar( "ResidentEmail");
         A68ResidentGender = GetPar( "ResidentGender");
         A312ResidentCountry = GetPar( "ResidentCountry");
         A313ResidentCity = GetPar( "ResidentCity");
         A314ResidentZipCode = GetPar( "ResidentZipCode");
         A315ResidentAddressLine1 = GetPar( "ResidentAddressLine1");
         A316ResidentAddressLine2 = GetPar( "ResidentAddressLine2");
         A70ResidentPhone = GetPar( "ResidentPhone");
         A97ResidentTypeName = GetPar( "ResidentTypeName");
         A98MedicalIndicationId = StringUtil.StrToGuid( GetPar( "MedicalIndicationId"));
         n98MedicalIndicationId = false;
         A99MedicalIndicationName = GetPar( "MedicalIndicationName");
         A73ResidentBirthDate = context.localUtil.ParseDateParm( GetPar( "ResidentBirthDate"));
         A96ResidentTypeId = StringUtil.StrToGuid( GetPar( "ResidentTypeId"));
         n96ResidentTypeId = false;
         A71ResidentGUID = GetPar( "ResidentGUID");
         AV98Udparg4 = StringUtil.StrToGuid( GetPar( "Udparg4"));
         A527ResidentPackageId = StringUtil.StrToGuid( GetPar( "ResidentPackageId"));
         n527ResidentPackageId = false;
         A528SG_LocationId = StringUtil.StrToGuid( GetPar( "SG_LocationId"));
         AV88Udparg1 = StringUtil.StrToGuid( GetPar( "Udparg1"));
         A531ResidentPackageName = GetPar( "ResidentPackageName");
         AV42IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV40IsAuthorized_SDT_Residents = StringUtil.StrToBool( GetPar( "IsAuthorized_SDT_Residents"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreestylegrid1_refresh( subGrid_Rows, AV36ResidentPackageId, A11OrganisationId, AV53WWPContext, AV95Udparg2, A29LocationId, AV96Udparg3, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV98Udparg4, A527ResidentPackageId, A528SG_LocationId, AV88Udparg1, A531ResidentPackageName, AV42IsAuthorized_Delete, AV40IsAuthorized_SDT_Residents) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFreestylegrid1_refresh_invoke */
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_82 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_82"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_82_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_82_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_82_idx = GetPar( "sGXsfl_82_idx");
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
         AV36ResidentPackageId = StringUtil.StrToGuid( GetPar( "ResidentPackageId"));
         A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV53WWPContext);
         AV95Udparg2 = StringUtil.StrToGuid( GetPar( "Udparg2"));
         A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
         AV96Udparg3 = StringUtil.StrToGuid( GetPar( "Udparg3"));
         A62ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
         A72ResidentSalutation = GetPar( "ResidentSalutation");
         A63ResidentBsnNumber = GetPar( "ResidentBsnNumber");
         A64ResidentGivenName = GetPar( "ResidentGivenName");
         A65ResidentLastName = GetPar( "ResidentLastName");
         A66ResidentInitials = GetPar( "ResidentInitials");
         A67ResidentEmail = GetPar( "ResidentEmail");
         A68ResidentGender = GetPar( "ResidentGender");
         A312ResidentCountry = GetPar( "ResidentCountry");
         A313ResidentCity = GetPar( "ResidentCity");
         A314ResidentZipCode = GetPar( "ResidentZipCode");
         A315ResidentAddressLine1 = GetPar( "ResidentAddressLine1");
         A316ResidentAddressLine2 = GetPar( "ResidentAddressLine2");
         A70ResidentPhone = GetPar( "ResidentPhone");
         A97ResidentTypeName = GetPar( "ResidentTypeName");
         A98MedicalIndicationId = StringUtil.StrToGuid( GetPar( "MedicalIndicationId"));
         n98MedicalIndicationId = false;
         A99MedicalIndicationName = GetPar( "MedicalIndicationName");
         A73ResidentBirthDate = context.localUtil.ParseDateParm( GetPar( "ResidentBirthDate"));
         A96ResidentTypeId = StringUtil.StrToGuid( GetPar( "ResidentTypeId"));
         n96ResidentTypeId = false;
         A71ResidentGUID = GetPar( "ResidentGUID");
         AV98Udparg4 = StringUtil.StrToGuid( GetPar( "Udparg4"));
         A527ResidentPackageId = StringUtil.StrToGuid( GetPar( "ResidentPackageId"));
         n527ResidentPackageId = false;
         ajax_req_read_hidden_sdt(GetNextPar( ), AV37SDT_Residents);
         AV42IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV40IsAuthorized_SDT_Residents = StringUtil.StrToBool( GetPar( "IsAuthorized_SDT_Residents"));
         AV88Udparg1 = StringUtil.StrToGuid( GetPar( "Udparg1"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV36ResidentPackageId, A11OrganisationId, AV53WWPContext, AV95Udparg2, A29LocationId, AV96Udparg3, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV98Udparg4, A527ResidentPackageId, AV37SDT_Residents, AV42IsAuthorized_Delete, AV40IsAuthorized_SDT_Residents, AV88Udparg1) ;
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
            return "wp_provisionedappdashboard_Execute" ;
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
         PABH2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTBH2( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_provisionedappdashboard.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV53WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV53WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV53WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG2", AV95Udparg2.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG2", GetSecureSignedToken( "", AV95Udparg2, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG3", AV96Udparg3.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG3", GetSecureSignedToken( "", AV96Udparg3, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG4", AV98Udparg4.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG4", GetSecureSignedToken( "", AV98Udparg4, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", AV88Udparg1.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", AV88Udparg1, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV42IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV42IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SDT_RESIDENTS", AV40IsAuthorized_SDT_Residents);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RESIDENTS", GetSecureSignedToken( "", AV40IsAuthorized_SDT_Residents, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdt_residents", AV37SDT_Residents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdt_residents", AV37SDT_Residents);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_31", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_31), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_82", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_82), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTPACKAGEID_DATA", AV44ResidentPackageId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTPACKAGEID_DATA", AV44ResidentPackageId_Data);
         }
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV53WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV53WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV53WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG2", AV95Udparg2.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG2", GetSecureSignedToken( "", AV95Udparg2, context));
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "vUDPARG3", AV96Udparg3.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG3", GetSecureSignedToken( "", AV96Udparg3, context));
         GxWebStd.gx_hidden_field( context, "RESIDENTID", A62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "RESIDENTSALUTATION", StringUtil.RTrim( A72ResidentSalutation));
         GxWebStd.gx_hidden_field( context, "RESIDENTBSNNUMBER", A63ResidentBsnNumber);
         GxWebStd.gx_hidden_field( context, "RESIDENTGIVENNAME", A64ResidentGivenName);
         GxWebStd.gx_hidden_field( context, "RESIDENTLASTNAME", A65ResidentLastName);
         GxWebStd.gx_hidden_field( context, "RESIDENTINITIALS", StringUtil.RTrim( A66ResidentInitials));
         GxWebStd.gx_hidden_field( context, "RESIDENTEMAIL", A67ResidentEmail);
         GxWebStd.gx_hidden_field( context, "RESIDENTGENDER", A68ResidentGender);
         GxWebStd.gx_hidden_field( context, "RESIDENTCOUNTRY", A312ResidentCountry);
         GxWebStd.gx_hidden_field( context, "RESIDENTCITY", A313ResidentCity);
         GxWebStd.gx_hidden_field( context, "RESIDENTZIPCODE", A314ResidentZipCode);
         GxWebStd.gx_hidden_field( context, "RESIDENTADDRESSLINE1", A315ResidentAddressLine1);
         GxWebStd.gx_hidden_field( context, "RESIDENTADDRESSLINE2", A316ResidentAddressLine2);
         GxWebStd.gx_hidden_field( context, "RESIDENTPHONE", StringUtil.RTrim( A70ResidentPhone));
         GxWebStd.gx_hidden_field( context, "RESIDENTTYPENAME", A97ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "MEDICALINDICATIONID", A98MedicalIndicationId.ToString());
         GxWebStd.gx_hidden_field( context, "MEDICALINDICATIONNAME", A99MedicalIndicationName);
         GxWebStd.gx_hidden_field( context, "RESIDENTBIRTHDATE", context.localUtil.DToC( A73ResidentBirthDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "RESIDENTTYPEID", A96ResidentTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "RESIDENTGUID", A71ResidentGUID);
         GxWebStd.gx_hidden_field( context, "vUDPARG4", AV98Udparg4.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG4", GetSecureSignedToken( "", AV98Udparg4, context));
         GxWebStd.gx_hidden_field( context, "RESIDENTPACKAGEID", A527ResidentPackageId.ToString());
         GxWebStd.gx_hidden_field( context, "SG_LOCATIONID", A528SG_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "vUDPARG1", AV88Udparg1.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", AV88Udparg1, context));
         GxWebStd.gx_hidden_field( context, "RESIDENTPACKAGENAME", A531ResidentPackageName);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_RESIDENTS", AV37SDT_Residents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_RESIDENTS", AV37SDT_Residents);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV42IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV42IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SDT_RESIDENTS", AV40IsAuthorized_SDT_Residents);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RESIDENTS", GetSecureSignedToken( "", AV40IsAuthorized_SDT_Residents, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISSENT", AV63isSent);
         GxWebStd.gx_hidden_field( context, "vERRDESCROPTION", StringUtil.RTrim( AV64ErrDescroption));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "subFreestylegrid1_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Width", StringUtil.RTrim( Dvpanel_cardlefticon1_maintable_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Autowidth", StringUtil.BoolToStr( Dvpanel_cardlefticon1_maintable_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Autoheight", StringUtil.BoolToStr( Dvpanel_cardlefticon1_maintable_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Cls", StringUtil.RTrim( Dvpanel_cardlefticon1_maintable_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Title", StringUtil.RTrim( Dvpanel_cardlefticon1_maintable_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Collapsible", StringUtil.BoolToStr( Dvpanel_cardlefticon1_maintable_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Collapsed", StringUtil.BoolToStr( Dvpanel_cardlefticon1_maintable_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_cardlefticon1_maintable_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Iconposition", StringUtil.RTrim( Dvpanel_cardlefticon1_maintable_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Autoscroll", StringUtil.BoolToStr( Dvpanel_cardlefticon1_maintable_Autoscroll));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Cls", StringUtil.RTrim( Combo_residentpackageid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Selectedvalue_set", StringUtil.RTrim( Combo_residentpackageid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Visible", StringUtil.BoolToStr( Combo_residentpackageid_Visible));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Emptyitemtext", StringUtil.RTrim( Combo_residentpackageid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Title", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Title", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Title", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Result", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Result));
         GxWebStd.gx_hidden_field( context, "vHTTPREQUEST_Baseurl", StringUtil.RTrim( AV46HTTPRequest.BaseURL));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Result));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Selectedvalue_get", StringUtil.RTrim( Combo_residentpackageid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Result", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Result));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPACKAGEID_Selectedvalue_get", StringUtil.RTrim( Combo_residentpackageid_Selectedvalue_get));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WEBH2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTBH2( ) ;
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
         return formatLink("wp_provisionedappdashboard.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_ProvisionedAppDashboard" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Provisioned App Dashboard", "") ;
      }

      protected void WBBH0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-md-3 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_cardlefticon1_maintable.SetProperty("Width", Dvpanel_cardlefticon1_maintable_Width);
            ucDvpanel_cardlefticon1_maintable.SetProperty("AutoWidth", Dvpanel_cardlefticon1_maintable_Autowidth);
            ucDvpanel_cardlefticon1_maintable.SetProperty("AutoHeight", Dvpanel_cardlefticon1_maintable_Autoheight);
            ucDvpanel_cardlefticon1_maintable.SetProperty("Cls", Dvpanel_cardlefticon1_maintable_Cls);
            ucDvpanel_cardlefticon1_maintable.SetProperty("Title", Dvpanel_cardlefticon1_maintable_Title);
            ucDvpanel_cardlefticon1_maintable.SetProperty("Collapsible", Dvpanel_cardlefticon1_maintable_Collapsible);
            ucDvpanel_cardlefticon1_maintable.SetProperty("Collapsed", Dvpanel_cardlefticon1_maintable_Collapsed);
            ucDvpanel_cardlefticon1_maintable.SetProperty("ShowCollapseIcon", Dvpanel_cardlefticon1_maintable_Showcollapseicon);
            ucDvpanel_cardlefticon1_maintable.SetProperty("IconPosition", Dvpanel_cardlefticon1_maintable_Iconposition);
            ucDvpanel_cardlefticon1_maintable.SetProperty("AutoScroll", Dvpanel_cardlefticon1_maintable_Autoscroll);
            ucDvpanel_cardlefticon1_maintable.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_cardlefticon1_maintable_Internalname, "DVPANEL_CARDLEFTICON1_MAINTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CARDLEFTICON1_MAINTABLEContainer"+"CardLeftIcon1_MainTable"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardlefticon1_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 SimpleCardIconPadding", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardlefticon1_icon_Internalname, context.GetMessage( "<i class='ProgressCardIconBaseColor fas fa-mobile-alt' style='font-size: 50px'></i>", ""), "", "", lblCardlefticon1_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_ProvisionedAppDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardlefticon1_tableinfo_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;align-items:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardlefticon1_description_Internalname, context.GetMessage( "Provisioned App version", ""), "", "", lblCardlefticon1_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WP_ProvisionedAppDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:flex-start;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardlefticon1_value_Internalname, context.GetMessage( "Card Left Icon1_Value", ""), "gx-form-item TextBlockDashboardDescriptionCardLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_31_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardlefticon1_value_Internalname, AV35CardLeftIcon1_Value, StringUtil.RTrim( context.localUtil.Format( AV35CardLeftIcon1_Value, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardlefticon1_value_Jsonclick, 0, "TextBlockDashboardDescriptionCard", "", "", "", "", 1, edtavCardlefticon1_value_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProvisionedAppDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MoreInfoCardCell", "start", "top", "", "", "div");
            wb_table1_24_BH2( true) ;
         }
         else
         {
            wb_table1_24_BH2( false) ;
         }
         return  ;
      }

      protected void wb_table1_24_BH2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9", "start", "top", "", "", "div");
            /*  Grid Control  */
            Freestylegrid1Container.SetIsFreestyle(true);
            Freestylegrid1Container.SetWrapped(nGXWrapped);
            StartGridControl31( ) ;
         }
         if ( wbEnd == 31 )
         {
            wbEnd = 0;
            nRC_GXsfl_31 = (int)(nGXsfl_31_idx-1);
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableresident_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, divUnnamedtable1_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombo_residentpackageid_cell_Internalname, 1, 0, "px", 0, "px", divCombo_residentpackageid_cell_Class, "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_residentpackageid.SetProperty("Caption", Combo_residentpackageid_Caption);
            ucCombo_residentpackageid.SetProperty("Cls", Combo_residentpackageid_Cls);
            ucCombo_residentpackageid.SetProperty("EmptyItemText", Combo_residentpackageid_Emptyitemtext);
            ucCombo_residentpackageid.SetProperty("DropDownOptionsData", AV44ResidentPackageId_Data);
            ucCombo_residentpackageid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residentpackageid_Internalname, "COMBO_RESIDENTPACKAGEIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedfilterscontainer_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:flex-end;", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell CellMarginTop HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl82( ) ;
         }
         if ( wbEnd == 82 )
         {
            wbEnd = 0;
            nRC_GXsfl_82 = (int)(nGXsfl_82_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               AV68GXV1 = nGXsfl_82_idx;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_31_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentpackageid_Internalname, AV36ResidentPackageId.ToString(), AV36ResidentPackageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentpackageid_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentpackageid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_ProvisionedAppDashboard.htm");
            wb_table2_107_BH2( true) ;
         }
         else
         {
            wb_table2_107_BH2( false) ;
         }
         return  ;
      }

      protected void wb_table2_107_BH2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_112_BH2( true) ;
         }
         else
         {
            wb_table3_112_BH2( false) ;
         }
         return  ;
      }

      protected void wb_table3_112_BH2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table4_117_BH2( true) ;
         }
         else
         {
            wb_table4_117_BH2( false) ;
         }
         return  ;
      }

      protected void wb_table4_117_BH2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table5_122_BH2( true) ;
         }
         else
         {
            wb_table5_122_BH2( false) ;
         }
         return  ;
      }

      protected void wb_table5_122_BH2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 31 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Freestylegrid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 82 )
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
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  AV68GXV1 = nGXsfl_82_idx;
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

      protected void STARTBH2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WP_Provisioned App Dashboard", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPBH0( ) ;
      }

      protected void WSBH2( )
      {
         STARTBH2( ) ;
         EVTBH2( ) ;
      }

      protected void EVTBH2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_RESIDENTPACKAGEID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_residentpackageid.Onoptionclicked */
                              E11BH2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_RESENDINVITE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_resendinvite.Close */
                              E12BH2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_useractionunblock.Close */
                              E13BH2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_useractionblock.Close */
                              E14BH2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_31_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
                              SubsflControlProps_312( ) ;
                              GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Width_" + sGXsfl_31_idx;
                              Dvpanel_cardcomponent1_maintable_Width = cgiGet( GXCCtl);
                              ucDvpanel_cardcomponent1_maintable.SendProperty(context, "", false, Dvpanel_cardcomponent1_maintable_Internalname, "Width", Dvpanel_cardcomponent1_maintable_Width);
                              GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Autowidth_" + sGXsfl_31_idx;
                              Dvpanel_cardcomponent1_maintable_Autowidth = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucDvpanel_cardcomponent1_maintable.SendProperty(context, "", false, Dvpanel_cardcomponent1_maintable_Internalname, "AutoWidth", StringUtil.BoolToStr( Dvpanel_cardcomponent1_maintable_Autowidth));
                              GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Autoheight_" + sGXsfl_31_idx;
                              Dvpanel_cardcomponent1_maintable_Autoheight = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucDvpanel_cardcomponent1_maintable.SendProperty(context, "", false, Dvpanel_cardcomponent1_maintable_Internalname, "AutoHeight", StringUtil.BoolToStr( Dvpanel_cardcomponent1_maintable_Autoheight));
                              GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Cls_" + sGXsfl_31_idx;
                              Dvpanel_cardcomponent1_maintable_Cls = cgiGet( GXCCtl);
                              ucDvpanel_cardcomponent1_maintable.SendProperty(context, "", false, Dvpanel_cardcomponent1_maintable_Internalname, "Cls", Dvpanel_cardcomponent1_maintable_Cls);
                              GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Title_" + sGXsfl_31_idx;
                              Dvpanel_cardcomponent1_maintable_Title = cgiGet( GXCCtl);
                              ucDvpanel_cardcomponent1_maintable.SendProperty(context, "", false, Dvpanel_cardcomponent1_maintable_Internalname, "Title", Dvpanel_cardcomponent1_maintable_Title);
                              GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Collapsible_" + sGXsfl_31_idx;
                              Dvpanel_cardcomponent1_maintable_Collapsible = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucDvpanel_cardcomponent1_maintable.SendProperty(context, "", false, Dvpanel_cardcomponent1_maintable_Internalname, "Collapsible", StringUtil.BoolToStr( Dvpanel_cardcomponent1_maintable_Collapsible));
                              GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Collapsed_" + sGXsfl_31_idx;
                              Dvpanel_cardcomponent1_maintable_Collapsed = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucDvpanel_cardcomponent1_maintable.SendProperty(context, "", false, Dvpanel_cardcomponent1_maintable_Internalname, "Collapsed", StringUtil.BoolToStr( Dvpanel_cardcomponent1_maintable_Collapsed));
                              GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Showcollapseicon_" + sGXsfl_31_idx;
                              Dvpanel_cardcomponent1_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucDvpanel_cardcomponent1_maintable.SendProperty(context, "", false, Dvpanel_cardcomponent1_maintable_Internalname, "ShowCollapseIcon", StringUtil.BoolToStr( Dvpanel_cardcomponent1_maintable_Showcollapseicon));
                              GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Iconposition_" + sGXsfl_31_idx;
                              Dvpanel_cardcomponent1_maintable_Iconposition = cgiGet( GXCCtl);
                              ucDvpanel_cardcomponent1_maintable.SendProperty(context, "", false, Dvpanel_cardcomponent1_maintable_Internalname, "IconPosition", Dvpanel_cardcomponent1_maintable_Iconposition);
                              GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Autoscroll_" + sGXsfl_31_idx;
                              Dvpanel_cardcomponent1_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucDvpanel_cardcomponent1_maintable.SendProperty(context, "", false, Dvpanel_cardcomponent1_maintable_Internalname, "AutoScroll", StringUtil.BoolToStr( Dvpanel_cardcomponent1_maintable_Autoscroll));
                              AV32Cardcomponent1_Value = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardcomponent1_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, edtavCardcomponent1_value_Internalname, StringUtil.LTrimStr( (decimal)(AV32Cardcomponent1_Value), 12, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E15BH2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E16BH2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freestylegrid1.Load */
                                    E17BH2 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) )
                           {
                              nGXsfl_82_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
                              SubsflControlProps_825( ) ;
                              AV68GXV1 = (int)(nGXsfl_82_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV37SDT_Residents.Count >= AV68GXV1 ) && ( AV68GXV1 > 0 ) )
                              {
                                 AV37SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1));
                                 AV38AccountStatus = cgiGet( edtavAccountstatus_Internalname);
                                 AssignAttri("", false, edtavAccountstatus_Internalname, AV38AccountStatus);
                                 cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                                 cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                                 AV41ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV41ActionGroup), 4, 0));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E18BH5 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E19BH2 ();
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

      protected void WEBH2( )
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

      protected void PABH2( )
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
               GX_FocusControl = edtavCardlefticon1_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrFreestylegrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_312( ) ;
         while ( nGXsfl_31_idx <= nRC_GXsfl_31 )
         {
            sendrow_312( ) ;
            nGXsfl_31_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_31_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_idx+1);
            sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
            SubsflControlProps_312( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Freestylegrid1Container)) ;
         /* End function gxnrFreestylegrid1_newrow */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_825( ) ;
         while ( nGXsfl_82_idx <= nRC_GXsfl_82 )
         {
            sendrow_825( ) ;
            nGXsfl_82_idx = ((subGrid_Islastpage==1)&&(nGXsfl_82_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_82_idx+1);
            sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
            SubsflControlProps_825( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrFreestylegrid1_refresh( int subGrid_Rows ,
                                                 Guid AV36ResidentPackageId ,
                                                 Guid A11OrganisationId ,
                                                 GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV53WWPContext ,
                                                 Guid AV95Udparg2 ,
                                                 Guid A29LocationId ,
                                                 Guid AV96Udparg3 ,
                                                 Guid A62ResidentId ,
                                                 string A72ResidentSalutation ,
                                                 string A63ResidentBsnNumber ,
                                                 string A64ResidentGivenName ,
                                                 string A65ResidentLastName ,
                                                 string A66ResidentInitials ,
                                                 string A67ResidentEmail ,
                                                 string A68ResidentGender ,
                                                 string A312ResidentCountry ,
                                                 string A313ResidentCity ,
                                                 string A314ResidentZipCode ,
                                                 string A315ResidentAddressLine1 ,
                                                 string A316ResidentAddressLine2 ,
                                                 string A70ResidentPhone ,
                                                 string A97ResidentTypeName ,
                                                 Guid A98MedicalIndicationId ,
                                                 string A99MedicalIndicationName ,
                                                 DateTime A73ResidentBirthDate ,
                                                 Guid A96ResidentTypeId ,
                                                 string A71ResidentGUID ,
                                                 Guid AV98Udparg4 ,
                                                 Guid A527ResidentPackageId ,
                                                 Guid A528SG_LocationId ,
                                                 Guid AV88Udparg1 ,
                                                 string A531ResidentPackageName ,
                                                 bool AV42IsAuthorized_Delete ,
                                                 bool AV40IsAuthorized_SDT_Residents )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREESTYLEGRID1_nCurrentRecord = 0;
         RFBH2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrFreestylegrid1_refresh */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       Guid AV36ResidentPackageId ,
                                       Guid A11OrganisationId ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV53WWPContext ,
                                       Guid AV95Udparg2 ,
                                       Guid A29LocationId ,
                                       Guid AV96Udparg3 ,
                                       Guid A62ResidentId ,
                                       string A72ResidentSalutation ,
                                       string A63ResidentBsnNumber ,
                                       string A64ResidentGivenName ,
                                       string A65ResidentLastName ,
                                       string A66ResidentInitials ,
                                       string A67ResidentEmail ,
                                       string A68ResidentGender ,
                                       string A312ResidentCountry ,
                                       string A313ResidentCity ,
                                       string A314ResidentZipCode ,
                                       string A315ResidentAddressLine1 ,
                                       string A316ResidentAddressLine2 ,
                                       string A70ResidentPhone ,
                                       string A97ResidentTypeName ,
                                       Guid A98MedicalIndicationId ,
                                       string A99MedicalIndicationName ,
                                       DateTime A73ResidentBirthDate ,
                                       Guid A96ResidentTypeId ,
                                       string A71ResidentGUID ,
                                       Guid AV98Udparg4 ,
                                       Guid A527ResidentPackageId ,
                                       GXBaseCollection<SdtSDT_Resident> AV37SDT_Residents ,
                                       bool AV42IsAuthorized_Delete ,
                                       bool AV40IsAuthorized_SDT_Residents ,
                                       Guid AV88Udparg1 )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFBH5( ) ;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFBH2( ) ;
         RFBH5( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavCardlefticon1_value_Enabled = 0;
         AssignProp("", false, edtavCardlefticon1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardlefticon1_value_Enabled), 5, 0), true);
         edtavCardcomponent1_value_Enabled = 0;
         edtavSdt_residents__residentid_Enabled = 0;
         edtavSdt_residents__locationid_Enabled = 0;
         edtavSdt_residents__organisationid_Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentinitials_Enabled = 0;
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         edtavSdt_residents__residentemail_Enabled = 0;
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavAccountstatus_Enabled = 0;
      }

      protected void RFBH2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Freestylegrid1Container.ClearRows();
         }
         wbStart = 31;
         /* Execute user event: Refresh */
         E16BH2 ();
         nGXsfl_31_idx = 1;
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
         bGXsfl_31_Refreshing = true;
         Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         Freestylegrid1Container.AddObjectProperty("CmpContext", "");
         Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
         Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Freestylegrid1Container.AddObjectProperty("Class", "FreeStyleGrid");
         Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
         Freestylegrid1Container.PageSize = subFreestylegrid1_fnc_Recordsperpage( );
         if ( subFreestylegrid1_Islastpage != 0 )
         {
            FREESTYLEGRID1_nFirstRecordOnPage = (long)(subFreestylegrid1_fnc_Recordcount( )-subFreestylegrid1_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("FREESTYLEGRID1_nFirstRecordOnPage", FREESTYLEGRID1_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_312( ) ;
            /* Execute user event: Freestylegrid1.Load */
            E17BH2 ();
            wbEnd = 31;
            WBBH0( ) ;
         }
         bGXsfl_31_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBH2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV53WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV53WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV53WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG2", AV95Udparg2.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG2", GetSecureSignedToken( "", AV95Udparg2, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG3", AV96Udparg3.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG3", GetSecureSignedToken( "", AV96Udparg3, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG4", AV98Udparg4.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG4", GetSecureSignedToken( "", AV98Udparg4, context));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", AV88Udparg1.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", AV88Udparg1, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV42IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV42IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SDT_RESIDENTS", AV40IsAuthorized_SDT_Residents);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RESIDENTS", GetSecureSignedToken( "", AV40IsAuthorized_SDT_Residents, context));
      }

      protected void RFBH5( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 82;
         /* Execute user event: Refresh */
         E16BH2 ();
         nGXsfl_82_idx = 1;
         sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
         SubsflControlProps_825( ) ;
         bGXsfl_82_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_825( ) ;
            /* Execute user event: Grid.Load */
            E18BH5 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_82_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E18BH5 ();
            }
            wbEnd = 82;
            WBBH0( ) ;
         }
         bGXsfl_82_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBH5( )
      {
      }

      protected int subFreestylegrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
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
         return AV37SDT_Residents.Count ;
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
            gxgrGrid_refresh( subGrid_Rows, AV36ResidentPackageId, A11OrganisationId, AV53WWPContext, AV95Udparg2, A29LocationId, AV96Udparg3, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV98Udparg4, A527ResidentPackageId, AV37SDT_Residents, AV42IsAuthorized_Delete, AV40IsAuthorized_SDT_Residents, AV88Udparg1) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV36ResidentPackageId, A11OrganisationId, AV53WWPContext, AV95Udparg2, A29LocationId, AV96Udparg3, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV98Udparg4, A527ResidentPackageId, AV37SDT_Residents, AV42IsAuthorized_Delete, AV40IsAuthorized_SDT_Residents, AV88Udparg1) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV36ResidentPackageId, A11OrganisationId, AV53WWPContext, AV95Udparg2, A29LocationId, AV96Udparg3, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV98Udparg4, A527ResidentPackageId, AV37SDT_Residents, AV42IsAuthorized_Delete, AV40IsAuthorized_SDT_Residents, AV88Udparg1) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV36ResidentPackageId, A11OrganisationId, AV53WWPContext, AV95Udparg2, A29LocationId, AV96Udparg3, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV98Udparg4, A527ResidentPackageId, AV37SDT_Residents, AV42IsAuthorized_Delete, AV40IsAuthorized_SDT_Residents, AV88Udparg1) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV36ResidentPackageId, A11OrganisationId, AV53WWPContext, AV95Udparg2, A29LocationId, AV96Udparg3, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV98Udparg4, A527ResidentPackageId, AV37SDT_Residents, AV42IsAuthorized_Delete, AV40IsAuthorized_SDT_Residents, AV88Udparg1) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavCardlefticon1_value_Enabled = 0;
         AssignProp("", false, edtavCardlefticon1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardlefticon1_value_Enabled), 5, 0), true);
         edtavCardcomponent1_value_Enabled = 0;
         edtavSdt_residents__residentid_Enabled = 0;
         edtavSdt_residents__locationid_Enabled = 0;
         edtavSdt_residents__organisationid_Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentinitials_Enabled = 0;
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         edtavSdt_residents__residentemail_Enabled = 0;
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavAccountstatus_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBH0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15BH2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdt_residents"), AV37SDT_Residents);
            ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTPACKAGEID_DATA"), AV44ResidentPackageId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_RESIDENTS"), AV37SDT_Residents);
            /* Read saved values. */
            nRC_GXsfl_31 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_31"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_82 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_82"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subFreestylegrid1_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subFreestylegrid1_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvpanel_cardlefticon1_maintable_Width = cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Width");
            Dvpanel_cardlefticon1_maintable_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Autowidth"));
            Dvpanel_cardlefticon1_maintable_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Autoheight"));
            Dvpanel_cardlefticon1_maintable_Cls = cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Cls");
            Dvpanel_cardlefticon1_maintable_Title = cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Title");
            Dvpanel_cardlefticon1_maintable_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Collapsible"));
            Dvpanel_cardlefticon1_maintable_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Collapsed"));
            Dvpanel_cardlefticon1_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Showcollapseicon"));
            Dvpanel_cardlefticon1_maintable_Iconposition = cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Iconposition");
            Dvpanel_cardlefticon1_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Autoscroll"));
            Combo_residentpackageid_Cls = cgiGet( "COMBO_RESIDENTPACKAGEID_Cls");
            Combo_residentpackageid_Selectedvalue_set = cgiGet( "COMBO_RESIDENTPACKAGEID_Selectedvalue_set");
            Combo_residentpackageid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTPACKAGEID_Visible"));
            Combo_residentpackageid_Emptyitemtext = cgiGet( "COMBO_RESIDENTPACKAGEID_Emptyitemtext");
            Dvelop_confirmpanel_resendinvite_Title = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Title");
            Dvelop_confirmpanel_resendinvite_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Confirmationtext");
            Dvelop_confirmpanel_resendinvite_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Yesbuttoncaption");
            Dvelop_confirmpanel_resendinvite_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Nobuttoncaption");
            Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Cancelbuttoncaption");
            Dvelop_confirmpanel_resendinvite_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Yesbuttonposition");
            Dvelop_confirmpanel_resendinvite_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Confirmtype");
            Dvelop_confirmpanel_useractionunblock_Title = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Title");
            Dvelop_confirmpanel_useractionunblock_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmationtext");
            Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttoncaption");
            Dvelop_confirmpanel_useractionunblock_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Nobuttoncaption");
            Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Cancelbuttoncaption");
            Dvelop_confirmpanel_useractionunblock_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttonposition");
            Dvelop_confirmpanel_useractionunblock_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmtype");
            Dvelop_confirmpanel_useractionblock_Title = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Title");
            Dvelop_confirmpanel_useractionblock_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmationtext");
            Dvelop_confirmpanel_useractionblock_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttoncaption");
            Dvelop_confirmpanel_useractionblock_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Nobuttoncaption");
            Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Cancelbuttoncaption");
            Dvelop_confirmpanel_useractionblock_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttonposition");
            Dvelop_confirmpanel_useractionblock_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmtype");
            Dvelop_confirmpanel_udelete_Title = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Title");
            Dvelop_confirmpanel_udelete_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Confirmationtext");
            Dvelop_confirmpanel_udelete_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_udelete_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Nobuttoncaption");
            Dvelop_confirmpanel_udelete_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_udelete_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttonposition");
            Dvelop_confirmpanel_udelete_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Dvelop_confirmpanel_resendinvite_Result = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Result");
            Dvelop_confirmpanel_useractionunblock_Result = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Result");
            Dvelop_confirmpanel_useractionblock_Result = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Result");
            Combo_residentpackageid_Selectedvalue_get = cgiGet( "COMBO_RESIDENTPACKAGEID_Selectedvalue_get");
            nRC_GXsfl_82 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_82"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_82_fel_idx = 0;
            while ( nGXsfl_82_fel_idx < nRC_GXsfl_82 )
            {
               nGXsfl_82_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_82_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_82_fel_idx+1);
               sGXsfl_82_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_825( ) ;
               AV68GXV1 = (int)(nGXsfl_82_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV37SDT_Residents.Count >= AV68GXV1 ) && ( AV68GXV1 > 0 ) )
               {
                  AV37SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1));
                  AV38AccountStatus = cgiGet( edtavAccountstatus_Internalname);
                  cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                  cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                  AV41ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               }
            }
            if ( nGXsfl_82_fel_idx == 0 )
            {
               nGXsfl_82_idx = 1;
               sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
               SubsflControlProps_825( ) ;
            }
            nGXsfl_82_fel_idx = 1;
            /* Read variables values. */
            AV35CardLeftIcon1_Value = cgiGet( edtavCardlefticon1_value_Internalname);
            AssignAttri("", false, "AV35CardLeftIcon1_Value", AV35CardLeftIcon1_Value);
            if ( StringUtil.StrCmp(cgiGet( edtavResidentpackageid_Internalname), "") == 0 )
            {
               AV36ResidentPackageId = Guid.Empty;
               AssignAttri("", false, "AV36ResidentPackageId", AV36ResidentPackageId.ToString());
            }
            else
            {
               try
               {
                  AV36ResidentPackageId = StringUtil.StrToGuid( cgiGet( edtavResidentpackageid_Internalname));
                  AssignAttri("", false, "AV36ResidentPackageId", AV36ResidentPackageId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vRESIDENTPACKAGEID");
                  GX_FocusControl = edtavResidentpackageid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
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
         E15BH2 ();
         if (returnInSub) return;
      }

      protected void E15BH2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_guid1 = AV33LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV33LocationId = GXt_guid1;
         AssignAttri("", false, "AV33LocationId", AV33LocationId.ToString());
         GXt_char2 = AV35CardLeftIcon1_Value;
         new prc_getactiveversion(context ).execute( out  GXt_char2) ;
         AV35CardLeftIcon1_Value = GXt_char2;
         AssignAttri("", false, "AV35CardLeftIcon1_Value", AV35CardLeftIcon1_Value);
         edtavResidentpackageid_Visible = 0;
         AssignProp("", false, edtavResidentpackageid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentpackageid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBORESIDENTPACKAGEID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         subGrid_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GXt_boolean3 = AV40IsAuthorized_SDT_Residents;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_residentview_Execute", out  GXt_boolean3) ;
         AV40IsAuthorized_SDT_Residents = GXt_boolean3;
         AssignAttri("", false, "AV40IsAuthorized_SDT_Residents", AV40IsAuthorized_SDT_Residents);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RESIDENTS", GetSecureSignedToken( "", AV40IsAuthorized_SDT_Residents, context));
         GXt_boolean3 = AV40IsAuthorized_SDT_Residents;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_residentview_Execute", out  GXt_boolean3) ;
         AV40IsAuthorized_SDT_Residents = GXt_boolean3;
         AssignAttri("", false, "AV40IsAuthorized_SDT_Residents", AV40IsAuthorized_SDT_Residents);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SDT_RESIDENTS", GetSecureSignedToken( "", AV40IsAuthorized_SDT_Residents, context));
      }

      protected void E16BH2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S142 ();
         if (returnInSub) return;
         edtavAccountstatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavAccountstatus_Internalname, "Columnheaderclass", edtavAccountstatus_Columnheaderclass, !bGXsfl_82_Refreshing);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37SDT_Residents", AV37SDT_Residents);
      }

      private void E17BH2( )
      {
         /* Freestylegrid1_Load Routine */
         returnInSub = false;
         AV88Udparg1 = new prc_getuserlocationid(context).executeUdp( );
         /* Using cursor H00BH2 */
         pr_default.execute(0, new Object[] {AV88Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A527ResidentPackageId = H00BH2_A527ResidentPackageId[0];
            n527ResidentPackageId = H00BH2_n527ResidentPackageId[0];
            A528SG_LocationId = H00BH2_A528SG_LocationId[0];
            A531ResidentPackageName = H00BH2_A531ResidentPackageName[0];
            AV32Cardcomponent1_Value = 0;
            AssignAttri("", false, edtavCardcomponent1_value_Internalname, StringUtil.LTrimStr( (decimal)(AV32Cardcomponent1_Value), 12, 0));
            /* Using cursor H00BH3 */
            pr_default.execute(1, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               AV32Cardcomponent1_Value = (long)(AV32Cardcomponent1_Value+1);
               AssignAttri("", false, edtavCardcomponent1_value_Internalname, StringUtil.LTrimStr( (decimal)(AV32Cardcomponent1_Value), 12, 0));
               lblCardcomponent1_icon_Fontname = context.GetMessage( "fas fa-file", "");
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV34ResidentPackageName = A531ResidentPackageName;
            lblCardcomponent1_description_Caption = AV34ResidentPackageName;
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 31;
            }
            sendrow_312( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_31_Refreshing )
            {
               DoAjaxLoad(31, Freestylegrid1Row);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /*  Sending Event outputs  */
      }

      protected void E19BH2( )
      {
         AV68GXV1 = (int)(nGXsfl_82_idx+GRID_nFirstRecordOnPage);
         if ( ( AV68GXV1 > 0 ) && ( AV37SDT_Residents.Count >= AV68GXV1 ) )
         {
            AV37SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1));
         }
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV41ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO RESENDINVITE' */
            S152 ();
            if (returnInSub) return;
         }
         else if ( AV41ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO USERACTIONUNBLOCK' */
            S162 ();
            if (returnInSub) return;
         }
         else if ( AV41ActionGroup == 3 )
         {
            /* Execute user subroutine: 'DO USERACTIONBLOCK' */
            S172 ();
            if (returnInSub) return;
         }
         else if ( AV41ActionGroup == 4 )
         {
            /* Execute user subroutine: 'DO VIEWQRCODE' */
            S182 ();
            if (returnInSub) return;
         }
         else if ( AV41ActionGroup == 5 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S192 ();
            if (returnInSub) return;
         }
         else if ( AV41ActionGroup == 6 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S202 ();
            if (returnInSub) return;
         }
         else if ( AV41ActionGroup == 7 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S212 ();
            if (returnInSub) return;
         }
         else if ( AV41ActionGroup == 8 )
         {
            /* Execute user subroutine: 'DO UDELETE' */
            S222 ();
            if (returnInSub) return;
         }
         AV41ActionGroup = 0;
         AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV41ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41ActionGroup), 4, 0));
         AssignProp("", false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
      }

      protected void E12BH2( )
      {
         AV68GXV1 = (int)(nGXsfl_82_idx+GRID_nFirstRecordOnPage);
         if ( ( AV68GXV1 > 0 ) && ( AV37SDT_Residents.Count >= AV68GXV1 ) )
         {
            AV37SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1));
         }
         /* Dvelop_confirmpanel_resendinvite_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_resendinvite_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION RESENDINVITE' */
            S232 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E13BH2( )
      {
         AV68GXV1 = (int)(nGXsfl_82_idx+GRID_nFirstRecordOnPage);
         if ( ( AV68GXV1 > 0 ) && ( AV37SDT_Residents.Count >= AV68GXV1 ) )
         {
            AV37SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1));
         }
         /* Dvelop_confirmpanel_useractionunblock_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractionunblock_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONUNBLOCK' */
            S242 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37SDT_Residents", AV37SDT_Residents);
         nGXsfl_82_bak_idx = nGXsfl_82_idx;
         gxgrGrid_refresh( subGrid_Rows, AV36ResidentPackageId, A11OrganisationId, AV53WWPContext, AV95Udparg2, A29LocationId, AV96Udparg3, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV98Udparg4, A527ResidentPackageId, AV37SDT_Residents, AV42IsAuthorized_Delete, AV40IsAuthorized_SDT_Residents, AV88Udparg1) ;
         nGXsfl_82_idx = nGXsfl_82_bak_idx;
         sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
         SubsflControlProps_825( ) ;
      }

      protected void E14BH2( )
      {
         AV68GXV1 = (int)(nGXsfl_82_idx+GRID_nFirstRecordOnPage);
         if ( ( AV68GXV1 > 0 ) && ( AV37SDT_Residents.Count >= AV68GXV1 ) )
         {
            AV37SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1));
         }
         /* Dvelop_confirmpanel_useractionblock_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractionblock_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONBLOCK' */
            S252 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37SDT_Residents", AV37SDT_Residents);
         nGXsfl_82_bak_idx = nGXsfl_82_idx;
         gxgrGrid_refresh( subGrid_Rows, AV36ResidentPackageId, A11OrganisationId, AV53WWPContext, AV95Udparg2, A29LocationId, AV96Udparg3, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV98Udparg4, A527ResidentPackageId, AV37SDT_Residents, AV42IsAuthorized_Delete, AV40IsAuthorized_SDT_Residents, AV88Udparg1) ;
         nGXsfl_82_idx = nGXsfl_82_bak_idx;
         sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
         SubsflControlProps_825( ) ;
      }

      protected void E11BH2( )
      {
         /* Combo_residentpackageid_Onoptionclicked Routine */
         returnInSub = false;
         AV36ResidentPackageId = StringUtil.StrToGuid( Combo_residentpackageid_Selectedvalue_get);
         AssignAttri("", false, "AV36ResidentPackageId", AV36ResidentPackageId.ToString());
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV82 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37SDT_Residents", AV37SDT_Residents);
            nGXsfl_82_bak_idx = nGXsfl_82_idx;
            gxgrGrid_refresh( subGrid_Rows, AV36ResidentPackageId, A11OrganisationId, AV53WWPContext, AV95Udparg2, A29LocationId, AV96Udparg3, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV98Udparg4, A527ResidentPackageId, AV37SDT_Residents, AV42IsAuthorized_Delete, AV40IsAuthorized_SDT_Residents, AV88Udparg1) ;
            nGXsfl_82_idx = nGXsfl_82_bak_idx;
            sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
            SubsflControlProps_825( ) ;
         }
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV42IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_resident_Delete", out  GXt_boolean3) ;
         AV42IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV42IsAuthorized_Delete", AV42IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV42IsAuthorized_Delete, context));
      }

      protected void S152( )
      {
         /* 'DO RESENDINVITE' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_RESENDINVITEContainer", "Confirm", "", new Object[] {});
      }

      protected void S232( )
      {
         /* 'DO ACTION RESENDINVITE' Routine */
         returnInSub = false;
         AV57baseUrl = AV46HTTPRequest.BaseURL;
         AV58ResidentGuid_Selected = ((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Residentguid;
         AV59GAMUser_Resident.load( AV58ResidentGuid_Selected);
         AV60GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV61ActivactionKey = AV59GAMUser_Resident.getnewactivationkey(out  AV60GAMErrors);
         if ( AV60GAMErrors.Count > 0 )
         {
            AV90GXV20 = 1;
            while ( AV90GXV20 <= AV60GAMErrors.Count )
            {
               AV62GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV60GAMErrors.Item(AV90GXV20));
               GX_msglist.addItem(AV62GAMError.gxTpr_Message);
               AV90GXV20 = (int)(AV90GXV20+1);
            }
         }
         else
         {
            context.CommitDataStores("wp_provisionedappdashboard",pr_default);
            new prc_senduseractivationlink(context).executeSubmit(  AV58ResidentGuid_Selected,  AV61ActivactionKey,  AV57baseUrl, ref  AV63isSent, ref  AV64ErrDescroption, ref  AV65GamErrorCollection) ;
            GX_msglist.addItem(context.GetMessage( "Invitation sent successfully.", ""));
         }
      }

      protected void S162( )
      {
         /* 'DO USERACTIONUNBLOCK' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCKContainer", "Confirm", "", new Object[] {});
      }

      protected void S242( )
      {
         /* 'DO ACTION USERACTIONUNBLOCK' Routine */
         returnInSub = false;
         AV60GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         new prc_unblockuser(context ).execute(  ((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Residentguid, out  AV66IsUnblocked, out  AV60GAMErrors) ;
         if ( AV66IsUnblocked )
         {
            gxgrGrid_refresh( subGrid_Rows, AV36ResidentPackageId, A11OrganisationId, AV53WWPContext, AV95Udparg2, A29LocationId, AV96Udparg3, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV98Udparg4, A527ResidentPackageId, AV37SDT_Residents, AV42IsAuthorized_Delete, AV40IsAuthorized_SDT_Residents, AV88Udparg1) ;
            GX_msglist.addItem(context.GetMessage( "Resident Unblocked sucessfully", ""));
         }
         if ( AV60GAMErrors.Count > 0 )
         {
            AV91GXV21 = 1;
            while ( AV91GXV21 <= AV60GAMErrors.Count )
            {
               AV62GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV60GAMErrors.Item(AV91GXV21));
               GX_msglist.addItem(AV62GAMError.gxTpr_Message);
               AV91GXV21 = (int)(AV91GXV21+1);
            }
         }
      }

      protected void S172( )
      {
         /* 'DO USERACTIONBLOCK' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_USERACTIONBLOCKContainer", "Confirm", "", new Object[] {});
      }

      protected void S252( )
      {
         /* 'DO ACTION USERACTIONBLOCK' Routine */
         returnInSub = false;
         AV60GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         new prc_blockuser(context ).execute(  ((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Residentguid, out  AV67IsBlocked, out  AV60GAMErrors) ;
         if ( AV67IsBlocked )
         {
            gxgrGrid_refresh( subGrid_Rows, AV36ResidentPackageId, A11OrganisationId, AV53WWPContext, AV95Udparg2, A29LocationId, AV96Udparg3, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A314ResidentZipCode, A315ResidentAddressLine1, A316ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV98Udparg4, A527ResidentPackageId, AV37SDT_Residents, AV42IsAuthorized_Delete, AV40IsAuthorized_SDT_Residents, AV88Udparg1) ;
            GX_msglist.addItem(context.GetMessage( "Resident Blocked sucessfully", ""));
         }
         if ( AV60GAMErrors.Count > 0 )
         {
            AV92GXV22 = 1;
            while ( AV92GXV22 <= AV60GAMErrors.Count )
            {
               AV62GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV60GAMErrors.Item(AV92GXV22));
               GX_msglist.addItem(AV62GAMError.gxTpr_Message);
               AV92GXV22 = (int)(AV92GXV22+1);
            }
         }
      }

      protected void S182( )
      {
         /* 'DO VIEWQRCODE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_residentqrcode.aspx"+UrlEncode(StringUtil.RTrim(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Residentguid)) + "," + UrlEncode(StringUtil.RTrim(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Residentemail));
         context.PopUp(formatLink("wp_residentqrcode.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
      }

      protected void S192( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_residentview.aspx"+UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("trn_residentview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S202( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_resident.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString());
         CallWebObject(formatLink("trn_resident.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S212( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_resident.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString());
         CallWebObject(formatLink("trn_resident.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO UDELETE' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_UDELETEContainer", "Confirm", "", new Object[] {});
      }

      protected void S262( )
      {
         /* 'DO ACTION UDELETE' Routine */
         returnInSub = false;
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ! (Guid.Empty==AV33LocationId) ) )
         {
            Combo_residentpackageid_Visible = false;
            ucCombo_residentpackageid.SendProperty(context, "", false, Combo_residentpackageid_Internalname, "Visible", StringUtil.BoolToStr( Combo_residentpackageid_Visible));
            divCombo_residentpackageid_cell_Class = "Invisible";
            AssignProp("", false, divCombo_residentpackageid_cell_Internalname, "Class", divCombo_residentpackageid_cell_Class, true);
         }
         else
         {
            Combo_residentpackageid_Visible = true;
            ucCombo_residentpackageid.SendProperty(context, "", false, Combo_residentpackageid_Internalname, "Visible", StringUtil.BoolToStr( Combo_residentpackageid_Visible));
            divCombo_residentpackageid_cell_Class = "col-xs-12 ExtendedComboCell";
            AssignProp("", false, divCombo_residentpackageid_cell_Internalname, "Class", divCombo_residentpackageid_cell_Class, true);
         }
         if ( ! Combo_residentpackageid_Visible )
         {
            divUnnamedtable1_Visible = 0;
            AssignProp("", false, divUnnamedtable1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable1_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBORESIDENTPACKAGEID' Routine */
         returnInSub = false;
         /* Using cursor H00BH4 */
         pr_default.execute(2, new Object[] {AV33LocationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A528SG_LocationId = H00BH4_A528SG_LocationId[0];
            A527ResidentPackageId = H00BH4_A527ResidentPackageId[0];
            n527ResidentPackageId = H00BH4_n527ResidentPackageId[0];
            A531ResidentPackageName = H00BH4_A531ResidentPackageName[0];
            AV45Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV45Combo_DataItem.gxTpr_Id = StringUtil.Trim( A527ResidentPackageId.ToString());
            AV45Combo_DataItem.gxTpr_Title = A531ResidentPackageName;
            AV44ResidentPackageId_Data.Add(AV45Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_residentpackageid_Selectedvalue_set = ((Guid.Empty==AV36ResidentPackageId) ? "" : StringUtil.Trim( AV36ResidentPackageId.ToString()));
         ucCombo_residentpackageid.SendProperty(context, "", false, Combo_residentpackageid_Internalname, "SelectedValue_set", Combo_residentpackageid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
         if ( (Guid.Empty==AV36ResidentPackageId) )
         {
            AV37SDT_Residents.Clear();
            gx_BV82 = true;
            AV95Udparg2 = new prc_getuserorganisationid(context).executeUdp( );
            AV96Udparg3 = new prc_getuserlocationid(context).executeUdp( );
            /* Using cursor H00BH5 */
            pr_default.execute(3, new Object[] {AV96Udparg3, AV53WWPContext.gxTpr_Organisationid, AV53WWPContext.gxTpr_Isrootadmin, AV95Udparg2});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A29LocationId = H00BH5_A29LocationId[0];
               A11OrganisationId = H00BH5_A11OrganisationId[0];
               A62ResidentId = H00BH5_A62ResidentId[0];
               A72ResidentSalutation = H00BH5_A72ResidentSalutation[0];
               A63ResidentBsnNumber = H00BH5_A63ResidentBsnNumber[0];
               A64ResidentGivenName = H00BH5_A64ResidentGivenName[0];
               A65ResidentLastName = H00BH5_A65ResidentLastName[0];
               A66ResidentInitials = H00BH5_A66ResidentInitials[0];
               A67ResidentEmail = H00BH5_A67ResidentEmail[0];
               A68ResidentGender = H00BH5_A68ResidentGender[0];
               A312ResidentCountry = H00BH5_A312ResidentCountry[0];
               A313ResidentCity = H00BH5_A313ResidentCity[0];
               A314ResidentZipCode = H00BH5_A314ResidentZipCode[0];
               A315ResidentAddressLine1 = H00BH5_A315ResidentAddressLine1[0];
               A316ResidentAddressLine2 = H00BH5_A316ResidentAddressLine2[0];
               A70ResidentPhone = H00BH5_A70ResidentPhone[0];
               A97ResidentTypeName = H00BH5_A97ResidentTypeName[0];
               A98MedicalIndicationId = H00BH5_A98MedicalIndicationId[0];
               n98MedicalIndicationId = H00BH5_n98MedicalIndicationId[0];
               A99MedicalIndicationName = H00BH5_A99MedicalIndicationName[0];
               A73ResidentBirthDate = H00BH5_A73ResidentBirthDate[0];
               A96ResidentTypeId = H00BH5_A96ResidentTypeId[0];
               n96ResidentTypeId = H00BH5_n96ResidentTypeId[0];
               A71ResidentGUID = H00BH5_A71ResidentGUID[0];
               A99MedicalIndicationName = H00BH5_A99MedicalIndicationName[0];
               A97ResidentTypeName = H00BH5_A97ResidentTypeName[0];
               AV54SDT_Resident = new SdtSDT_Resident(context);
               AV54SDT_Resident.gxTpr_Residentid = A62ResidentId;
               AV54SDT_Resident.gxTpr_Locationid = A29LocationId;
               AV54SDT_Resident.gxTpr_Organisationid = A11OrganisationId;
               AV54SDT_Resident.gxTpr_Residentsalutation = A72ResidentSalutation;
               AV54SDT_Resident.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
               AV54SDT_Resident.gxTpr_Residentgivenname = A64ResidentGivenName;
               AV54SDT_Resident.gxTpr_Residentlastname = A65ResidentLastName;
               AV54SDT_Resident.gxTpr_Residentinitials = A66ResidentInitials;
               AV54SDT_Resident.gxTpr_Residentemail = A67ResidentEmail;
               AV54SDT_Resident.gxTpr_Residentgender = A68ResidentGender;
               GXt_char2 = "";
               new prc_concatenateaddress(context ).execute(  A312ResidentCountry,  A313ResidentCity,  A314ResidentZipCode,  A315ResidentAddressLine1,  A316ResidentAddressLine2, out  GXt_char2) ;
               AV54SDT_Resident.gxTpr_Residentaddress = GXt_char2;
               AV54SDT_Resident.gxTpr_Residentphone = A70ResidentPhone;
               AV54SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
               AV54SDT_Resident.gxTpr_Medicalindicationid = A98MedicalIndicationId;
               AV54SDT_Resident.gxTpr_Medicalindicationname = A99MedicalIndicationName;
               AV54SDT_Resident.gxTpr_Residentbirthdate = A73ResidentBirthDate;
               AV54SDT_Resident.gxTpr_Residenttypeid = A96ResidentTypeId;
               AV54SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
               AV54SDT_Resident.gxTpr_Residentguid = A71ResidentGUID;
               AV37SDT_Residents.Add(AV54SDT_Resident, 0);
               gx_BV82 = true;
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
         else
         {
            if ( ! (Guid.Empty==AV36ResidentPackageId) )
            {
               AV37SDT_Residents.Clear();
               gx_BV82 = true;
               AV98Udparg4 = new prc_getuserlocationid(context).executeUdp( );
               pr_default.dynParam(4, new Object[]{ new Object[]{
                                                    AV36ResidentPackageId ,
                                                    A527ResidentPackageId ,
                                                    AV98Udparg4 ,
                                                    A29LocationId } ,
                                                    new int[]{
                                                    TypeConstants.BOOLEAN
                                                    }
               });
               /* Using cursor H00BH6 */
               pr_default.execute(4, new Object[] {AV98Udparg4, AV36ResidentPackageId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A527ResidentPackageId = H00BH6_A527ResidentPackageId[0];
                  n527ResidentPackageId = H00BH6_n527ResidentPackageId[0];
                  A29LocationId = H00BH6_A29LocationId[0];
                  A62ResidentId = H00BH6_A62ResidentId[0];
                  A11OrganisationId = H00BH6_A11OrganisationId[0];
                  A72ResidentSalutation = H00BH6_A72ResidentSalutation[0];
                  A63ResidentBsnNumber = H00BH6_A63ResidentBsnNumber[0];
                  A64ResidentGivenName = H00BH6_A64ResidentGivenName[0];
                  A65ResidentLastName = H00BH6_A65ResidentLastName[0];
                  A66ResidentInitials = H00BH6_A66ResidentInitials[0];
                  A67ResidentEmail = H00BH6_A67ResidentEmail[0];
                  A68ResidentGender = H00BH6_A68ResidentGender[0];
                  A312ResidentCountry = H00BH6_A312ResidentCountry[0];
                  A313ResidentCity = H00BH6_A313ResidentCity[0];
                  A314ResidentZipCode = H00BH6_A314ResidentZipCode[0];
                  A315ResidentAddressLine1 = H00BH6_A315ResidentAddressLine1[0];
                  A316ResidentAddressLine2 = H00BH6_A316ResidentAddressLine2[0];
                  A70ResidentPhone = H00BH6_A70ResidentPhone[0];
                  A97ResidentTypeName = H00BH6_A97ResidentTypeName[0];
                  A98MedicalIndicationId = H00BH6_A98MedicalIndicationId[0];
                  n98MedicalIndicationId = H00BH6_n98MedicalIndicationId[0];
                  A99MedicalIndicationName = H00BH6_A99MedicalIndicationName[0];
                  A73ResidentBirthDate = H00BH6_A73ResidentBirthDate[0];
                  A96ResidentTypeId = H00BH6_A96ResidentTypeId[0];
                  n96ResidentTypeId = H00BH6_n96ResidentTypeId[0];
                  A71ResidentGUID = H00BH6_A71ResidentGUID[0];
                  A99MedicalIndicationName = H00BH6_A99MedicalIndicationName[0];
                  A97ResidentTypeName = H00BH6_A97ResidentTypeName[0];
                  AV54SDT_Resident = new SdtSDT_Resident(context);
                  AV54SDT_Resident.gxTpr_Residentid = A62ResidentId;
                  AV54SDT_Resident.gxTpr_Locationid = A29LocationId;
                  AV54SDT_Resident.gxTpr_Organisationid = A11OrganisationId;
                  AV54SDT_Resident.gxTpr_Residentsalutation = A72ResidentSalutation;
                  AV54SDT_Resident.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
                  AV54SDT_Resident.gxTpr_Residentgivenname = A64ResidentGivenName;
                  AV54SDT_Resident.gxTpr_Residentlastname = A65ResidentLastName;
                  AV54SDT_Resident.gxTpr_Residentinitials = A66ResidentInitials;
                  AV54SDT_Resident.gxTpr_Residentemail = A67ResidentEmail;
                  AV54SDT_Resident.gxTpr_Residentgender = A68ResidentGender;
                  GXt_char2 = "";
                  new prc_concatenateaddress(context ).execute(  A312ResidentCountry,  A313ResidentCity,  A314ResidentZipCode,  A315ResidentAddressLine1,  A316ResidentAddressLine2, out  GXt_char2) ;
                  AV54SDT_Resident.gxTpr_Residentaddress = GXt_char2;
                  AV54SDT_Resident.gxTpr_Residentphone = A70ResidentPhone;
                  AV54SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
                  AV54SDT_Resident.gxTpr_Medicalindicationid = A98MedicalIndicationId;
                  AV54SDT_Resident.gxTpr_Medicalindicationname = A99MedicalIndicationName;
                  AV54SDT_Resident.gxTpr_Residentbirthdate = A73ResidentBirthDate;
                  AV54SDT_Resident.gxTpr_Residenttypeid = A96ResidentTypeId;
                  AV54SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
                  AV54SDT_Resident.gxTpr_Residentguid = A71ResidentGUID;
                  AV37SDT_Residents.Add(AV54SDT_Resident, 0);
                  gx_BV82 = true;
                  pr_default.readNext(4);
               }
               pr_default.close(4);
            }
         }
      }

      private void E18BH5( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV68GXV1 = 1;
         while ( AV68GXV1 <= AV37SDT_Residents.Count )
         {
            AV37SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1));
            GXt_boolean3 = AV51IsGAMActive;
            new prc_checkgamuseractivationstatus(context ).execute(  ((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Residentguid, out  GXt_boolean3) ;
            AV51IsGAMActive = GXt_boolean3;
            GXt_boolean3 = AV52IsGAMBlocked;
            new prc_checkgamuserblockedstatus(context ).execute(  ((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Residentguid, out  GXt_boolean3) ;
            AV52IsGAMBlocked = GXt_boolean3;
            if ( ( AV51IsGAMActive ) && ! AV52IsGAMBlocked )
            {
               AV38AccountStatus = "Active";
               AssignAttri("", false, edtavAccountstatus_Internalname, AV38AccountStatus);
            }
            else if ( ( AV51IsGAMActive ) && ( AV52IsGAMBlocked ) )
            {
               AV38AccountStatus = "Blocked";
               AssignAttri("", false, edtavAccountstatus_Internalname, AV38AccountStatus);
            }
            else if ( ! AV51IsGAMActive )
            {
               AV38AccountStatus = "Inactive";
               AssignAttri("", false, edtavAccountstatus_Internalname, AV38AccountStatus);
            }
            cmbavActiongroup.removeAllItems();
            cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
            if ( ! AV51IsGAMActive )
            {
               cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Invite", ""), "fas fa-share", "", "", "", "", "", "", ""), 0);
            }
            if ( ( AV51IsGAMActive ) && ( AV52IsGAMBlocked ) )
            {
               cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Unblock", ""), "fas fa-lock-open", "", "", "", "", "", "", ""), 0);
            }
            if ( ( AV51IsGAMActive ) && ! AV52IsGAMBlocked )
            {
               cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "Block", ""), "fas fa-lock", "", "", "", "", "", "", ""), 0);
            }
            if ( 1 == 0 )
            {
               cmbavActiongroup.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "QR code", ""), "fas fa-qrcode", "", "", "", "", "", "", ""), 0);
            }
            cmbavActiongroup.addItem("5", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            cmbavActiongroup.addItem("6", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            if ( AV42IsAuthorized_Delete )
            {
               if ( false )
               {
                  cmbavActiongroup.addItem("7", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
               }
            }
            cmbavActiongroup.addItem("8", StringUtil.Format( "%1;%2", context.GetMessage( "Delete", ""), "fas fa-x", "", "", "", "", "", "", ""), 0);
            if ( AV40IsAuthorized_SDT_Residents )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "trn_residentview.aspx"+UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString());
               edtavSdt_residents__residentgivenname_Link = formatLink("trn_residentview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( AV40IsAuthorized_SDT_Residents )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "trn_residentview.aspx"+UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV37SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString());
               edtavSdt_residents__residentlastname_Link = formatLink("trn_residentview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( ( AV51IsGAMActive ) && ! AV52IsGAMBlocked )
            {
               edtavAccountstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( ( AV51IsGAMActive ) && ( AV52IsGAMBlocked ) )
            {
               edtavAccountstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else if ( ! AV51IsGAMActive )
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
               wbStart = 82;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_825( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_82_Refreshing )
            {
               DoAjaxLoad(82, GridRow);
            }
            AV68GXV1 = (int)(AV68GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41ActionGroup), 4, 0));
      }

      protected void wb_table5_122_BH2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_udelete_Internalname, tblTabledvelop_confirmpanel_udelete_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_udelete.SetProperty("Title", Dvelop_confirmpanel_udelete_Title);
            ucDvelop_confirmpanel_udelete.SetProperty("ConfirmationText", Dvelop_confirmpanel_udelete_Confirmationtext);
            ucDvelop_confirmpanel_udelete.SetProperty("YesButtonCaption", Dvelop_confirmpanel_udelete_Yesbuttoncaption);
            ucDvelop_confirmpanel_udelete.SetProperty("NoButtonCaption", Dvelop_confirmpanel_udelete_Nobuttoncaption);
            ucDvelop_confirmpanel_udelete.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_udelete_Cancelbuttoncaption);
            ucDvelop_confirmpanel_udelete.SetProperty("YesButtonPosition", Dvelop_confirmpanel_udelete_Yesbuttonposition);
            ucDvelop_confirmpanel_udelete.SetProperty("ConfirmType", Dvelop_confirmpanel_udelete_Confirmtype);
            ucDvelop_confirmpanel_udelete.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_udelete_Internalname, "DVELOP_CONFIRMPANEL_UDELETEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_UDELETEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_122_BH2e( true) ;
         }
         else
         {
            wb_table5_122_BH2e( false) ;
         }
      }

      protected void wb_table4_117_BH2( bool wbgen )
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
            wb_table4_117_BH2e( true) ;
         }
         else
         {
            wb_table4_117_BH2e( false) ;
         }
      }

      protected void wb_table3_112_BH2( bool wbgen )
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
            wb_table3_112_BH2e( true) ;
         }
         else
         {
            wb_table3_112_BH2e( false) ;
         }
      }

      protected void wb_table2_107_BH2( bool wbgen )
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
            wb_table2_107_BH2e( true) ;
         }
         else
         {
            wb_table2_107_BH2e( false) ;
         }
      }

      protected void wb_table1_24_BH2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCardlefticon1_moreinfo_Internalname, tblCardlefticon1_moreinfo_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardlefticon1_moreinfoicon_Internalname, context.GetMessage( "<i class='CardMaterialMoreInfoIcon far fa-clock' style='font-size: 16px'></i>", ""), "", "", lblCardlefticon1_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_ProvisionedAppDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardlefticon1_moreinfocaption_Internalname, context.GetMessage( "Just Updated", ""), "", "", lblCardlefticon1_moreinfocaption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_ProvisionedAppDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_24_BH2e( true) ;
         }
         else
         {
            wb_table1_24_BH2e( false) ;
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
         PABH2( ) ;
         WSBH2( ) ;
         WEBH2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562017155916", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wp_provisionedappdashboard.js", "?202562017155919", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_312( )
      {
         lblCardcomponent1_icon_Internalname = "CARDCOMPONENT1_ICON_"+sGXsfl_31_idx;
         lblCardcomponent1_description_Internalname = "CARDCOMPONENT1_DESCRIPTION_"+sGXsfl_31_idx;
         edtavCardcomponent1_value_Internalname = "vCARDCOMPONENT1_VALUE_"+sGXsfl_31_idx;
         lblCardcomponent1_moreinfoicon_Internalname = "CARDCOMPONENT1_MOREINFOICON_"+sGXsfl_31_idx;
         lblCardcomponent1_moreinfocaption_Internalname = "CARDCOMPONENT1_MOREINFOCAPTION_"+sGXsfl_31_idx;
         Dvpanel_cardcomponent1_maintable_Internalname = "DVPANEL_CARDCOMPONENT1_MAINTABLE_"+sGXsfl_31_idx;
      }

      protected void SubsflControlProps_fel_312( )
      {
         lblCardcomponent1_icon_Internalname = "CARDCOMPONENT1_ICON_"+sGXsfl_31_fel_idx;
         lblCardcomponent1_description_Internalname = "CARDCOMPONENT1_DESCRIPTION_"+sGXsfl_31_fel_idx;
         edtavCardcomponent1_value_Internalname = "vCARDCOMPONENT1_VALUE_"+sGXsfl_31_fel_idx;
         lblCardcomponent1_moreinfoicon_Internalname = "CARDCOMPONENT1_MOREINFOICON_"+sGXsfl_31_fel_idx;
         lblCardcomponent1_moreinfocaption_Internalname = "CARDCOMPONENT1_MOREINFOCAPTION_"+sGXsfl_31_fel_idx;
         Dvpanel_cardcomponent1_maintable_Internalname = "DVPANEL_CARDCOMPONENT1_MAINTABLE_"+sGXsfl_31_fel_idx;
      }

      protected void sendrow_312( )
      {
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
         WBBH0( ) ;
         Freestylegrid1Row = GXWebRow.GetNew(context,Freestylegrid1Container);
         if ( subFreestylegrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFreestylegrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
            }
         }
         else if ( subFreestylegrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFreestylegrid1_Backstyle = 0;
            subFreestylegrid1_Backcolor = subFreestylegrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Uniform";
            }
         }
         else if ( subFreestylegrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFreestylegrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
            }
            subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFreestylegrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFreestylegrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_31_idx) % (2))) == 0 )
            {
               subFreestylegrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Even";
               }
            }
            else
            {
               subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFreestylegrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_31_idx+"\">") ;
         }
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFreestylegrid1layouttable_Internalname+"_"+sGXsfl_31_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 CellMarginTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* User Defined Control */
         Freestylegrid1Row.AddColumnProperties("usercontrol", -1, isAjaxCallMode( ), new Object[] {(string)"DVPANEL_CARDCOMPONENT1_MAINTABLEContainer"+"_"+sGXsfl_31_idx,(short)-1});
         Freestylegrid1Row.AddColumnProperties("usercontrolcontainer", -1, isAjaxCallMode( ), new Object[] {(string)"DVPANEL_CARDCOMPONENT1_MAINTABLEContainer",(string)"Cardcomponent1_MainTable"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divCardcomponent1_maintable_Internalname+"_"+sGXsfl_31_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-6 SimpleCardIconPadding",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblCardcomponent1_icon_Internalname,context.GetMessage( "<i class='ProgressCardIconBaseColor far fa-gem' style='font-size: 50px'></i>", ""),(string)"",(string)"",(string)lblCardcomponent1_icon_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"font-family:'"+lblCardcomponent1_icon_Fontname+"';",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-6",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divCardcomponent1_tableinfo_Internalname+"_"+sGXsfl_31_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"flex-direction:column;align-items:flex-end;",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblCardcomponent1_description_Internalname,(string)lblCardcomponent1_description_Caption,(string)"",(string)"",(string)lblCardcomponent1_description_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlockDashboardDescriptionCard",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCardcomponent1_value_Internalname,context.GetMessage( "Cardcomponent1_Value", ""),(string)"gx-form-item DashboardNumberCardLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_31_idx + "',31)\"";
         ROClassString = "DashboardNumberCard";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCardcomponent1_value_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32Cardcomponent1_Value), 15, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavCardcomponent1_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV32Cardcomponent1_Value), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV32Cardcomponent1_Value), "ZZZ,ZZZ,ZZZ,ZZ9"))),TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,47);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCardcomponent1_value_Jsonclick,(short)0,(string)"DashboardNumberCard",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCardcomponent1_value_Enabled,(short)0,(string)"text",(string)"",(short)15,(string)"chr",(short)1,(string)"row",(short)15,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"WorkWithPlus_Web\\KPINumericValue",(string)"end",(bool)false,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 MoreInfoCardCell",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Freestylegrid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblCardcomponent1_moreinfo_Internalname+"_"+sGXsfl_31_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblCardcomponent1_moreinfoicon_Internalname,context.GetMessage( "<i class='CardMaterialMoreInfoIcon far fa-clock' style='font-size: 16px'></i>", ""),(string)"",(string)"",(string)lblCardcomponent1_moreinfoicon_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblCardcomponent1_moreinfocaption_Internalname,context.GetMessage( "Just Updated", ""),(string)"",(string)"",(string)lblCardcomponent1_moreinfocaption_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlockMoreInfoCard",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("row");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("table");
         }
         /* End of table */
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashesBH2( ) ;
         GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Width_" + sGXsfl_31_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Dvpanel_cardcomponent1_maintable_Width));
         GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Autowidth_" + sGXsfl_31_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Dvpanel_cardcomponent1_maintable_Autowidth));
         GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Autoheight_" + sGXsfl_31_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Dvpanel_cardcomponent1_maintable_Autoheight));
         GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Cls_" + sGXsfl_31_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Dvpanel_cardcomponent1_maintable_Cls));
         GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Title_" + sGXsfl_31_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Dvpanel_cardcomponent1_maintable_Title));
         GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Collapsible_" + sGXsfl_31_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Dvpanel_cardcomponent1_maintable_Collapsible));
         GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Collapsed_" + sGXsfl_31_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Dvpanel_cardcomponent1_maintable_Collapsed));
         GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Showcollapseicon_" + sGXsfl_31_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Dvpanel_cardcomponent1_maintable_Showcollapseicon));
         GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Iconposition_" + sGXsfl_31_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Dvpanel_cardcomponent1_maintable_Iconposition));
         GXCCtl = "DVPANEL_CARDCOMPONENT1_MAINTABLE_Autoscroll_" + sGXsfl_31_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Dvpanel_cardcomponent1_maintable_Autoscroll));
         /* End of Columns property logic. */
         Freestylegrid1Container.AddRow(Freestylegrid1Row);
         nGXsfl_31_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_31_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_idx+1);
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
         /* End function sendrow_312 */
      }

      protected void SubsflControlProps_825( )
      {
         edtavSdt_residents__residentid_Internalname = "SDT_RESIDENTS__RESIDENTID_"+sGXsfl_82_idx;
         edtavSdt_residents__locationid_Internalname = "SDT_RESIDENTS__LOCATIONID_"+sGXsfl_82_idx;
         edtavSdt_residents__organisationid_Internalname = "SDT_RESIDENTS__ORGANISATIONID_"+sGXsfl_82_idx;
         edtavSdt_residents__residentbsnnumber_Internalname = "SDT_RESIDENTS__RESIDENTBSNNUMBER_"+sGXsfl_82_idx;
         cmbavSdt_residents__residentsalutation_Internalname = "SDT_RESIDENTS__RESIDENTSALUTATION_"+sGXsfl_82_idx;
         edtavSdt_residents__residentgivenname_Internalname = "SDT_RESIDENTS__RESIDENTGIVENNAME_"+sGXsfl_82_idx;
         edtavSdt_residents__residentlastname_Internalname = "SDT_RESIDENTS__RESIDENTLASTNAME_"+sGXsfl_82_idx;
         edtavSdt_residents__residentinitials_Internalname = "SDT_RESIDENTS__RESIDENTINITIALS_"+sGXsfl_82_idx;
         cmbavSdt_residents__residentgender_Internalname = "SDT_RESIDENTS__RESIDENTGENDER_"+sGXsfl_82_idx;
         edtavSdt_residents__residentbirthdate_Internalname = "SDT_RESIDENTS__RESIDENTBIRTHDATE_"+sGXsfl_82_idx;
         edtavSdt_residents__residentemail_Internalname = "SDT_RESIDENTS__RESIDENTEMAIL_"+sGXsfl_82_idx;
         edtavSdt_residents__residentphone_Internalname = "SDT_RESIDENTS__RESIDENTPHONE_"+sGXsfl_82_idx;
         edtavSdt_residents__residentguid_Internalname = "SDT_RESIDENTS__RESIDENTGUID_"+sGXsfl_82_idx;
         edtavSdt_residents__residenttypeid_Internalname = "SDT_RESIDENTS__RESIDENTTYPEID_"+sGXsfl_82_idx;
         edtavSdt_residents__residenttypename_Internalname = "SDT_RESIDENTS__RESIDENTTYPENAME_"+sGXsfl_82_idx;
         edtavSdt_residents__medicalindicationid_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONID_"+sGXsfl_82_idx;
         edtavSdt_residents__medicalindicationname_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONNAME_"+sGXsfl_82_idx;
         edtavSdt_residents__residentaddress_Internalname = "SDT_RESIDENTS__RESIDENTADDRESS_"+sGXsfl_82_idx;
         edtavAccountstatus_Internalname = "vACCOUNTSTATUS_"+sGXsfl_82_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_82_idx;
      }

      protected void SubsflControlProps_fel_825( )
      {
         edtavSdt_residents__residentid_Internalname = "SDT_RESIDENTS__RESIDENTID_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__locationid_Internalname = "SDT_RESIDENTS__LOCATIONID_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__organisationid_Internalname = "SDT_RESIDENTS__ORGANISATIONID_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__residentbsnnumber_Internalname = "SDT_RESIDENTS__RESIDENTBSNNUMBER_"+sGXsfl_82_fel_idx;
         cmbavSdt_residents__residentsalutation_Internalname = "SDT_RESIDENTS__RESIDENTSALUTATION_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__residentgivenname_Internalname = "SDT_RESIDENTS__RESIDENTGIVENNAME_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__residentlastname_Internalname = "SDT_RESIDENTS__RESIDENTLASTNAME_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__residentinitials_Internalname = "SDT_RESIDENTS__RESIDENTINITIALS_"+sGXsfl_82_fel_idx;
         cmbavSdt_residents__residentgender_Internalname = "SDT_RESIDENTS__RESIDENTGENDER_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__residentbirthdate_Internalname = "SDT_RESIDENTS__RESIDENTBIRTHDATE_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__residentemail_Internalname = "SDT_RESIDENTS__RESIDENTEMAIL_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__residentphone_Internalname = "SDT_RESIDENTS__RESIDENTPHONE_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__residentguid_Internalname = "SDT_RESIDENTS__RESIDENTGUID_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__residenttypeid_Internalname = "SDT_RESIDENTS__RESIDENTTYPEID_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__residenttypename_Internalname = "SDT_RESIDENTS__RESIDENTTYPENAME_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__medicalindicationid_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONID_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__medicalindicationname_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONNAME_"+sGXsfl_82_fel_idx;
         edtavSdt_residents__residentaddress_Internalname = "SDT_RESIDENTS__RESIDENTADDRESS_"+sGXsfl_82_fel_idx;
         edtavAccountstatus_Internalname = "vACCOUNTSTATUS_"+sGXsfl_82_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_82_fel_idx;
      }

      protected void sendrow_825( )
      {
         sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
         SubsflControlProps_825( ) ;
         WBBH0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_82_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_82_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_82_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentid_Internalname,((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentid.ToString(),((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)82,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__locationid_Internalname,((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Locationid.ToString(),((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Locationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__locationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__locationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)82,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__organisationid_Internalname,((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Organisationid.ToString(),((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Organisationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__organisationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__organisationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)82,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentbsnnumber_Internalname,((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentbsnnumber,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentbsnnumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentbsnnumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbavSdt_residents__residentsalutation.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_RESIDENTS__RESIDENTSALUTATION_" + sGXsfl_82_idx;
               cmbavSdt_residents__residentsalutation.Name = GXCCtl;
               cmbavSdt_residents__residentsalutation.WebTags = "";
               cmbavSdt_residents__residentsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
               cmbavSdt_residents__residentsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
               cmbavSdt_residents__residentsalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
               cmbavSdt_residents__residentsalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
               if ( cmbavSdt_residents__residentsalutation.ItemCount > 0 )
               {
                  if ( ( AV68GXV1 > 0 ) && ( AV37SDT_Residents.Count >= AV68GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentsalutation)) )
                  {
                     ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentsalutation = cmbavSdt_residents__residentsalutation.getValidValue(((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentsalutation);
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_residents__residentsalutation,(string)cmbavSdt_residents__residentsalutation_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentsalutation),(short)1,(string)cmbavSdt_residents__residentsalutation_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,cmbavSdt_residents__residentsalutation.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            cmbavSdt_residents__residentsalutation.CurrentValue = StringUtil.RTrim( ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentsalutation);
            AssignProp("", false, cmbavSdt_residents__residentsalutation_Internalname, "Values", (string)(cmbavSdt_residents__residentsalutation.ToJavascriptSource()), !bGXsfl_82_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_82_idx + "',82)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentgivenname_Internalname,((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentgivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavSdt_residents__residentgivenname_Link,(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentgivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_residents__residentgivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_82_idx + "',82)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentlastname_Internalname,((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentlastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavSdt_residents__residentlastname_Link,(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentlastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_residents__residentlastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentinitials_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentinitials),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentinitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentinitials_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_82_idx + "',82)\"";
            if ( ( cmbavSdt_residents__residentgender.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_RESIDENTS__RESIDENTGENDER_" + sGXsfl_82_idx;
               cmbavSdt_residents__residentgender.Name = GXCCtl;
               cmbavSdt_residents__residentgender.WebTags = "";
               cmbavSdt_residents__residentgender.addItem("Male", context.GetMessage( "Male", ""), 0);
               cmbavSdt_residents__residentgender.addItem("Female", context.GetMessage( "Female", ""), 0);
               cmbavSdt_residents__residentgender.addItem("Other", context.GetMessage( "Other", ""), 0);
               if ( cmbavSdt_residents__residentgender.ItemCount > 0 )
               {
                  if ( ( AV68GXV1 > 0 ) && ( AV37SDT_Residents.Count >= AV68GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentgender)) )
                  {
                     ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentgender = cmbavSdt_residents__residentgender.getValidValue(((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentgender);
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_residents__residentgender,(string)cmbavSdt_residents__residentgender_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentgender),(short)1,(string)cmbavSdt_residents__residentgender_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavSdt_residents__residentgender.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"",(string)"",(bool)true,(short)0});
            cmbavSdt_residents__residentgender.CurrentValue = StringUtil.RTrim( ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentgender);
            AssignProp("", false, cmbavSdt_residents__residentgender_Internalname, "Values", (string)(cmbavSdt_residents__residentgender.ToJavascriptSource()), !bGXsfl_82_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentbirthdate_Internalname,context.localUtil.Format(((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentbirthdate, "99/99/9999"),context.localUtil.Format( ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentbirthdate, "99/99/9999"),""+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentbirthdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentbirthdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_82_idx + "',82)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentemail_Internalname,((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_residents__residentemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_82_idx + "',82)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentphone_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_residents__residentphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentguid_Internalname,((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentguid,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentguid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentguid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)82,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residenttypeid_Internalname,((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residenttypeid.ToString(),((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residenttypeid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residenttypeid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residenttypeid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)82,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residenttypename_Internalname,((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residenttypename,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residenttypename_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residenttypename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__medicalindicationid_Internalname,((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Medicalindicationid.ToString(),((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Medicalindicationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__medicalindicationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__medicalindicationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)82,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__medicalindicationname_Internalname,((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Medicalindicationname,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__medicalindicationname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__medicalindicationname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentaddress_Internalname,((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentaddress,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_82_idx + "',82)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAccountstatus_Internalname,(string)AV38AccountStatus,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAccountstatus_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavAccountstatus_Columnclass,(string)edtavAccountstatus_Columnheaderclass,(short)-1,(int)edtavAccountstatus_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_82_idx + "',82)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_82_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  if ( ( AV68GXV1 > 0 ) && ( AV37SDT_Residents.Count >= AV68GXV1 ) && (0==AV41ActionGroup) )
                  {
                     AV41ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV41ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV41ActionGroup), 4, 0));
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV41ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_82_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_82_Refreshing);
            send_integrity_lvl_hashesBH5( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_82_idx = ((subGrid_Islastpage==1)&&(nGXsfl_82_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_82_idx+1);
            sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
            SubsflControlProps_825( ) ;
         }
         /* End function sendrow_825 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "SDT_RESIDENTS__RESIDENTSALUTATION_" + sGXsfl_82_idx;
         cmbavSdt_residents__residentsalutation.Name = GXCCtl;
         cmbavSdt_residents__residentsalutation.WebTags = "";
         cmbavSdt_residents__residentsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbavSdt_residents__residentsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbavSdt_residents__residentsalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
         cmbavSdt_residents__residentsalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
         if ( cmbavSdt_residents__residentsalutation.ItemCount > 0 )
         {
            if ( ( AV68GXV1 > 0 ) && ( AV37SDT_Residents.Count >= AV68GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentsalutation)) )
            {
               ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentsalutation = cmbavSdt_residents__residentsalutation.getValidValue(((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentsalutation);
            }
         }
         GXCCtl = "SDT_RESIDENTS__RESIDENTGENDER_" + sGXsfl_82_idx;
         cmbavSdt_residents__residentgender.Name = GXCCtl;
         cmbavSdt_residents__residentgender.WebTags = "";
         cmbavSdt_residents__residentgender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavSdt_residents__residentgender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavSdt_residents__residentgender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavSdt_residents__residentgender.ItemCount > 0 )
         {
            if ( ( AV68GXV1 > 0 ) && ( AV37SDT_Residents.Count >= AV68GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentgender)) )
            {
               ((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentgender = cmbavSdt_residents__residentgender.getValidValue(((SdtSDT_Resident)AV37SDT_Residents.Item(AV68GXV1)).gxTpr_Residentgender);
            }
         }
         GXCCtl = "vACTIONGROUP_" + sGXsfl_82_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            if ( ( AV68GXV1 > 0 ) && ( AV37SDT_Residents.Count >= AV68GXV1 ) && (0==AV41ActionGroup) )
            {
               AV41ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV41ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV41ActionGroup), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl31( )
      {
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"DivS\" data-gxgridid=\"31\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFreestylegrid1_Internalname, subFreestylegrid1_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         }
         else
         {
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
            Freestylegrid1Container.AddObjectProperty("Header", subFreestylegrid1_Header);
            Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Freestylegrid1Container.AddObjectProperty("Class", "FreeStyleGrid");
            Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("CmpContext", "");
            Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectedindex), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowselection), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectioncolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowhovering), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Hoveringcolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowcollapsing), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl82( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"82\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.SendWebValue( context.GetMessage( "Resident Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Organisation Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "BSN Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Salutation", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "First Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Initials", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Gender", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Date Of Birth", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident GUID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Type Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Type", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Medical Indication Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Medical Indication", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Address", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Account Status", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__locationid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__organisationid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentbsnnumber_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_residents__residentsalutation.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentgivenname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavSdt_residents__residentgivenname_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentlastname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavSdt_residents__residentlastname_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentinitials_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_residents__residentgender.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentbirthdate_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentemail_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentphone_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentguid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residenttypeid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residenttypename_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__medicalindicationid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__medicalindicationname_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentaddress_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV38AccountStatus));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavAccountstatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavAccountstatus_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAccountstatus_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41ActionGroup), 4, 0, ".", ""))));
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
         lblCardlefticon1_icon_Internalname = "CARDLEFTICON1_ICON";
         lblCardlefticon1_description_Internalname = "CARDLEFTICON1_DESCRIPTION";
         edtavCardlefticon1_value_Internalname = "vCARDLEFTICON1_VALUE";
         divCardlefticon1_tableinfo_Internalname = "CARDLEFTICON1_TABLEINFO";
         lblCardlefticon1_moreinfoicon_Internalname = "CARDLEFTICON1_MOREINFOICON";
         lblCardlefticon1_moreinfocaption_Internalname = "CARDLEFTICON1_MOREINFOCAPTION";
         tblCardlefticon1_moreinfo_Internalname = "CARDLEFTICON1_MOREINFO";
         divCardlefticon1_maintable_Internalname = "CARDLEFTICON1_MAINTABLE";
         Dvpanel_cardlefticon1_maintable_Internalname = "DVPANEL_CARDLEFTICON1_MAINTABLE";
         lblCardcomponent1_icon_Internalname = "CARDCOMPONENT1_ICON";
         lblCardcomponent1_description_Internalname = "CARDCOMPONENT1_DESCRIPTION";
         edtavCardcomponent1_value_Internalname = "vCARDCOMPONENT1_VALUE";
         divCardcomponent1_tableinfo_Internalname = "CARDCOMPONENT1_TABLEINFO";
         lblCardcomponent1_moreinfoicon_Internalname = "CARDCOMPONENT1_MOREINFOICON";
         lblCardcomponent1_moreinfocaption_Internalname = "CARDCOMPONENT1_MOREINFOCAPTION";
         tblCardcomponent1_moreinfo_Internalname = "CARDCOMPONENT1_MOREINFO";
         divCardcomponent1_maintable_Internalname = "CARDCOMPONENT1_MAINTABLE";
         Dvpanel_cardcomponent1_maintable_Internalname = "DVPANEL_CARDCOMPONENT1_MAINTABLE";
         divFreestylegrid1layouttable_Internalname = "FREESTYLEGRID1LAYOUTTABLE";
         Combo_residentpackageid_Internalname = "COMBO_RESIDENTPACKAGEID";
         divCombo_residentpackageid_cell_Internalname = "COMBO_RESIDENTPACKAGEID_CELL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTableactions_Internalname = "TABLEACTIONS";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         edtavSdt_residents__residentid_Internalname = "SDT_RESIDENTS__RESIDENTID";
         edtavSdt_residents__locationid_Internalname = "SDT_RESIDENTS__LOCATIONID";
         edtavSdt_residents__organisationid_Internalname = "SDT_RESIDENTS__ORGANISATIONID";
         edtavSdt_residents__residentbsnnumber_Internalname = "SDT_RESIDENTS__RESIDENTBSNNUMBER";
         cmbavSdt_residents__residentsalutation_Internalname = "SDT_RESIDENTS__RESIDENTSALUTATION";
         edtavSdt_residents__residentgivenname_Internalname = "SDT_RESIDENTS__RESIDENTGIVENNAME";
         edtavSdt_residents__residentlastname_Internalname = "SDT_RESIDENTS__RESIDENTLASTNAME";
         edtavSdt_residents__residentinitials_Internalname = "SDT_RESIDENTS__RESIDENTINITIALS";
         cmbavSdt_residents__residentgender_Internalname = "SDT_RESIDENTS__RESIDENTGENDER";
         edtavSdt_residents__residentbirthdate_Internalname = "SDT_RESIDENTS__RESIDENTBIRTHDATE";
         edtavSdt_residents__residentemail_Internalname = "SDT_RESIDENTS__RESIDENTEMAIL";
         edtavSdt_residents__residentphone_Internalname = "SDT_RESIDENTS__RESIDENTPHONE";
         edtavSdt_residents__residentguid_Internalname = "SDT_RESIDENTS__RESIDENTGUID";
         edtavSdt_residents__residenttypeid_Internalname = "SDT_RESIDENTS__RESIDENTTYPEID";
         edtavSdt_residents__residenttypename_Internalname = "SDT_RESIDENTS__RESIDENTTYPENAME";
         edtavSdt_residents__medicalindicationid_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONID";
         edtavSdt_residents__medicalindicationname_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONNAME";
         edtavSdt_residents__residentaddress_Internalname = "SDT_RESIDENTS__RESIDENTADDRESS";
         edtavAccountstatus_Internalname = "vACCOUNTSTATUS";
         cmbavActiongroup_Internalname = "vACTIONGROUP";
         divTableresident_Internalname = "TABLERESIDENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavResidentpackageid_Internalname = "vRESIDENTPACKAGEID";
         Dvelop_confirmpanel_resendinvite_Internalname = "DVELOP_CONFIRMPANEL_RESENDINVITE";
         tblTabledvelop_confirmpanel_resendinvite_Internalname = "TABLEDVELOP_CONFIRMPANEL_RESENDINVITE";
         Dvelop_confirmpanel_useractionunblock_Internalname = "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK";
         tblTabledvelop_confirmpanel_useractionunblock_Internalname = "TABLEDVELOP_CONFIRMPANEL_USERACTIONUNBLOCK";
         Dvelop_confirmpanel_useractionblock_Internalname = "DVELOP_CONFIRMPANEL_USERACTIONBLOCK";
         tblTabledvelop_confirmpanel_useractionblock_Internalname = "TABLEDVELOP_CONFIRMPANEL_USERACTIONBLOCK";
         Dvelop_confirmpanel_udelete_Internalname = "DVELOP_CONFIRMPANEL_UDELETE";
         tblTabledvelop_confirmpanel_udelete_Internalname = "TABLEDVELOP_CONFIRMPANEL_UDELETE";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subFreestylegrid1_Internalname = "FREESTYLEGRID1";
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
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         subFreestylegrid1_Allowcollapsing = 0;
         cmbavActiongroup_Jsonclick = "";
         edtavAccountstatus_Jsonclick = "";
         edtavAccountstatus_Columnclass = "WWColumn";
         edtavAccountstatus_Enabled = 1;
         edtavSdt_residents__residentaddress_Jsonclick = "";
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Jsonclick = "";
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Jsonclick = "";
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__residenttypename_Jsonclick = "";
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__residenttypeid_Jsonclick = "";
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residentguid_Jsonclick = "";
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residentphone_Jsonclick = "";
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentemail_Jsonclick = "";
         edtavSdt_residents__residentemail_Enabled = 0;
         edtavSdt_residents__residentbirthdate_Jsonclick = "";
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         cmbavSdt_residents__residentgender_Jsonclick = "";
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentinitials_Jsonclick = "";
         edtavSdt_residents__residentinitials_Enabled = 0;
         edtavSdt_residents__residentlastname_Jsonclick = "";
         edtavSdt_residents__residentlastname_Link = "";
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentgivenname_Jsonclick = "";
         edtavSdt_residents__residentgivenname_Link = "";
         edtavSdt_residents__residentgivenname_Enabled = 0;
         cmbavSdt_residents__residentsalutation_Jsonclick = "";
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Jsonclick = "";
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         edtavSdt_residents__organisationid_Jsonclick = "";
         edtavSdt_residents__organisationid_Enabled = 0;
         edtavSdt_residents__locationid_Jsonclick = "";
         edtavSdt_residents__locationid_Enabled = 0;
         edtavSdt_residents__residentid_Jsonclick = "";
         edtavSdt_residents__residentid_Enabled = 0;
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavCardcomponent1_value_Jsonclick = "";
         edtavCardcomponent1_value_Enabled = 0;
         lblCardcomponent1_description_Caption = context.GetMessage( "Sales", "");
         lblCardcomponent1_icon_Fontname = "";
         subFreestylegrid1_Class = "FreeStyleGrid";
         edtavAccountstatus_Columnheaderclass = "";
         subFreestylegrid1_Backcolorstyle = 0;
         edtavSdt_residents__residentaddress_Enabled = -1;
         edtavSdt_residents__medicalindicationname_Enabled = -1;
         edtavSdt_residents__medicalindicationid_Enabled = -1;
         edtavSdt_residents__residenttypename_Enabled = -1;
         edtavSdt_residents__residenttypeid_Enabled = -1;
         edtavSdt_residents__residentguid_Enabled = -1;
         edtavSdt_residents__residentphone_Enabled = -1;
         edtavSdt_residents__residentemail_Enabled = -1;
         edtavSdt_residents__residentbirthdate_Enabled = -1;
         cmbavSdt_residents__residentgender.Enabled = -1;
         edtavSdt_residents__residentinitials_Enabled = -1;
         edtavSdt_residents__residentlastname_Enabled = -1;
         edtavSdt_residents__residentgivenname_Enabled = -1;
         cmbavSdt_residents__residentsalutation.Enabled = -1;
         edtavSdt_residents__residentbsnnumber_Enabled = -1;
         edtavSdt_residents__organisationid_Enabled = -1;
         edtavSdt_residents__locationid_Enabled = -1;
         edtavSdt_residents__residentid_Enabled = -1;
         Dvpanel_cardcomponent1_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_cardcomponent1_maintable_Iconposition = "Right";
         Dvpanel_cardcomponent1_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_cardcomponent1_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_cardcomponent1_maintable_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_cardcomponent1_maintable_Title = "";
         Dvpanel_cardcomponent1_maintable_Cls = "PanelNoHeader";
         Dvpanel_cardcomponent1_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_cardcomponent1_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_cardcomponent1_maintable_Width = "100%";
         edtavResidentpackageid_Jsonclick = "";
         edtavResidentpackageid_Visible = 1;
         divCombo_residentpackageid_cell_Class = "col-xs-12";
         divUnnamedtable1_Visible = 1;
         edtavCardlefticon1_value_Jsonclick = "";
         edtavCardlefticon1_value_Enabled = 1;
         Dvelop_confirmpanel_udelete_Confirmtype = "1";
         Dvelop_confirmpanel_udelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_udelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_udelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_udelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_udelete_Confirmationtext = "The following data associated with the resident will be deleted: Memos";
         Dvelop_confirmpanel_udelete_Title = context.GetMessage( "Confirm delete action", "");
         Dvelop_confirmpanel_useractionblock_Confirmtype = "1";
         Dvelop_confirmpanel_useractionblock_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractionblock_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractionblock_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractionblock_Confirmationtext = "Are you sure you want to block resident?";
         Dvelop_confirmpanel_useractionblock_Title = context.GetMessage( "Block Resident", "");
         Dvelop_confirmpanel_useractionunblock_Confirmtype = "1";
         Dvelop_confirmpanel_useractionunblock_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractionunblock_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractionunblock_Confirmationtext = "Are you sure you want to unblock Resident?";
         Dvelop_confirmpanel_useractionunblock_Title = context.GetMessage( "Unblock user", "");
         Dvelop_confirmpanel_resendinvite_Confirmtype = "1";
         Dvelop_confirmpanel_resendinvite_Yesbuttonposition = "left";
         Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_resendinvite_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_resendinvite_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_resendinvite_Confirmationtext = "Are you sure you want to re-send an invititation to this resident?";
         Dvelop_confirmpanel_resendinvite_Title = context.GetMessage( "Re - Send Invitation", "");
         Combo_residentpackageid_Emptyitemtext = "Select Access";
         Combo_residentpackageid_Visible = Convert.ToBoolean( -1);
         Combo_residentpackageid_Cls = "ExtendedCombo btn-default";
         Dvpanel_cardlefticon1_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_cardlefticon1_maintable_Iconposition = "Right";
         Dvpanel_cardlefticon1_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_cardlefticon1_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_cardlefticon1_maintable_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_cardlefticon1_maintable_Title = "";
         Dvpanel_cardlefticon1_maintable_Cls = "PanelNoHeader";
         Dvpanel_cardlefticon1_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_cardlefticon1_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_cardlefticon1_maintable_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WP_Provisioned App Dashboard", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"FREESTYLEGRID1_nEOF"},{"av":"A528SG_LocationId","fld":"SG_LOCATIONID"},{"av":"A531ResidentPackageName","fld":"RESIDENTPACKAGENAME"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV36ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV53WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV95Udparg2","fld":"vUDPARG2","hsh":true},{"av":"AV96Udparg3","fld":"vUDPARG3","hsh":true},{"av":"AV98Udparg4","fld":"vUDPARG4","hsh":true},{"av":"AV88Udparg1","fld":"vUDPARG1","hsh":true},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV40IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]}""");
         setEventMetadata("FREESTYLEGRID1.LOAD","""{"handler":"E17BH2","iparms":[{"av":"A528SG_LocationId","fld":"SG_LOCATIONID"},{"av":"AV88Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A531ResidentPackageName","fld":"RESIDENTPACKAGENAME"}]""");
         setEventMetadata("FREESTYLEGRID1.LOAD",""","oparms":[{"av":"AV32Cardcomponent1_Value","fld":"vCARDCOMPONENT1_VALUE","pic":"ZZZ,ZZZ,ZZZ,ZZ9"},{"av":"lblCardcomponent1_icon_Fontname","ctrl":"CARDCOMPONENT1_ICON","prop":"Fontname"},{"av":"lblCardcomponent1_description_Caption","ctrl":"CARDCOMPONENT1_DESCRIPTION","prop":"Caption"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E18BH5","iparms":[{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV40IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV38AccountStatus","fld":"vACCOUNTSTATUS"},{"av":"cmbavActiongroup"},{"av":"AV41ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"ctrl":"SDT_RESIDENTS__RESIDENTGIVENNAME","prop":"Link"},{"ctrl":"SDT_RESIDENTS__RESIDENTLASTNAME","prop":"Link"},{"av":"edtavAccountstatus_Columnclass","ctrl":"vACCOUNTSTATUS","prop":"Columnclass"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E19BH2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV41ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV41ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_RESENDINVITE.CLOSE","""{"handler":"E12BH2","iparms":[{"av":"Dvelop_confirmpanel_resendinvite_Result","ctrl":"DVELOP_CONFIRMPANEL_RESENDINVITE","prop":"Result"},{"av":"AV46HTTPRequest.BaseURL","ctrl":"vHTTPREQUEST","prop":"Baseurl"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV63isSent","fld":"vISSENT"},{"av":"AV64ErrDescroption","fld":"vERRDESCROPTION"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_RESENDINVITE.CLOSE",""","oparms":[{"av":"AV64ErrDescroption","fld":"vERRDESCROPTION"},{"av":"AV63isSent","fld":"vISSENT"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK.CLOSE","""{"handler":"E13BH2","iparms":[{"av":"Dvelop_confirmpanel_useractionunblock_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV36ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV53WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV95Udparg2","fld":"vUDPARG2","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV96Udparg3","fld":"vUDPARG3","hsh":true},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"AV98Udparg4","fld":"vUDPARG4","hsh":true},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV40IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV88Udparg1","fld":"vUDPARG1","hsh":true},{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"FREESTYLEGRID1_nEOF"},{"av":"A528SG_LocationId","fld":"SG_LOCATIONID"},{"av":"A531ResidentPackageName","fld":"RESIDENTPACKAGENAME"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK.CLOSE",""","oparms":[{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONBLOCK.CLOSE","""{"handler":"E14BH2","iparms":[{"av":"Dvelop_confirmpanel_useractionblock_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONBLOCK","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV36ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV53WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV95Udparg2","fld":"vUDPARG2","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV96Udparg3","fld":"vUDPARG3","hsh":true},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"AV98Udparg4","fld":"vUDPARG4","hsh":true},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV40IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV88Udparg1","fld":"vUDPARG1","hsh":true},{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"FREESTYLEGRID1_nEOF"},{"av":"A528SG_LocationId","fld":"SG_LOCATIONID"},{"av":"A531ResidentPackageName","fld":"RESIDENTPACKAGENAME"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONBLOCK.CLOSE",""","oparms":[{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]}""");
         setEventMetadata("COMBO_RESIDENTPACKAGEID.ONOPTIONCLICKED","""{"handler":"E11BH2","iparms":[{"av":"Combo_residentpackageid_Selectedvalue_get","ctrl":"COMBO_RESIDENTPACKAGEID","prop":"SelectedValue_get"},{"av":"AV36ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV53WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV95Udparg2","fld":"vUDPARG2","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV96Udparg3","fld":"vUDPARG3","hsh":true},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"AV98Udparg4","fld":"vUDPARG4","hsh":true},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"FREESTYLEGRID1_nEOF"},{"av":"A528SG_LocationId","fld":"SG_LOCATIONID"},{"av":"A531ResidentPackageName","fld":"RESIDENTPACKAGENAME"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV88Udparg1","fld":"vUDPARG1","hsh":true},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV40IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true}]""");
         setEventMetadata("COMBO_RESIDENTPACKAGEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV36ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV40IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV88Udparg1","fld":"vUDPARG1","hsh":true},{"av":"AV36ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV53WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV95Udparg2","fld":"vUDPARG2","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV96Udparg3","fld":"vUDPARG3","hsh":true},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"AV98Udparg4","fld":"vUDPARG4","hsh":true},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV40IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV88Udparg1","fld":"vUDPARG1","hsh":true},{"av":"AV36ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV53WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV95Udparg2","fld":"vUDPARG2","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV96Udparg3","fld":"vUDPARG3","hsh":true},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"AV98Udparg4","fld":"vUDPARG4","hsh":true},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV40IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV88Udparg1","fld":"vUDPARG1","hsh":true},{"av":"AV36ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV53WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV95Udparg2","fld":"vUDPARG2","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV96Udparg3","fld":"vUDPARG3","hsh":true},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"AV98Udparg4","fld":"vUDPARG4","hsh":true},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV40IsAuthorized_SDT_Residents","fld":"vISAUTHORIZED_SDT_RESIDENTS","hsh":true},{"av":"AV88Udparg1","fld":"vUDPARG1","hsh":true},{"av":"AV36ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV53WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV95Udparg2","fld":"vUDPARG2","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV96Udparg3","fld":"vUDPARG3","hsh":true},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A312ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A313ResidentCity","fld":"RESIDENTCITY"},{"av":"A314ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A315ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A316ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"AV98Udparg4","fld":"vUDPARG4","hsh":true},{"av":"A527ResidentPackageId","fld":"RESIDENTPACKAGEID"}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"av":"edtavAccountstatus_Columnheaderclass","ctrl":"vACCOUNTSTATUS","prop":"Columnheaderclass"},{"av":"AV37SDT_Residents","fld":"vSDT_RESIDENTS","grid":82},{"av":"nGXsfl_82_idx","ctrl":"GRID","prop":"GridCurrRow","grid":82},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_82","ctrl":"GRID","prop":"GridRC","grid":82},{"av":"AV42IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]}""");
         setEventMetadata("VALIDV_RESIDENTPACKAGEID","""{"handler":"Validv_Residentpackageid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Cardcomponent1_value","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
         setEventMetadata("VALIDV_GXV10","""{"handler":"Validv_Gxv10","iparms":[]}""");
         setEventMetadata("VALIDV_GXV12","""{"handler":"Validv_Gxv12","iparms":[]}""");
         setEventMetadata("VALIDV_GXV15","""{"handler":"Validv_Gxv15","iparms":[]}""");
         setEventMetadata("VALIDV_GXV17","""{"handler":"Validv_Gxv17","iparms":[]}""");
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
         Dvelop_confirmpanel_resendinvite_Result = "";
         AV46HTTPRequest = new GxHttpRequest( context);
         Dvelop_confirmpanel_useractionunblock_Result = "";
         Dvelop_confirmpanel_useractionblock_Result = "";
         Dvelop_confirmpanel_udelete_Result = "";
         Combo_residentpackageid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV36ResidentPackageId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV53WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV95Udparg2 = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV96Udparg3 = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A72ResidentSalutation = "";
         A63ResidentBsnNumber = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A66ResidentInitials = "";
         A67ResidentEmail = "";
         A68ResidentGender = "";
         A312ResidentCountry = "";
         A313ResidentCity = "";
         A314ResidentZipCode = "";
         A315ResidentAddressLine1 = "";
         A316ResidentAddressLine2 = "";
         A70ResidentPhone = "";
         A97ResidentTypeName = "";
         A98MedicalIndicationId = Guid.Empty;
         A99MedicalIndicationName = "";
         A73ResidentBirthDate = DateTime.MinValue;
         A96ResidentTypeId = Guid.Empty;
         A71ResidentGUID = "";
         AV98Udparg4 = Guid.Empty;
         A527ResidentPackageId = Guid.Empty;
         A528SG_LocationId = Guid.Empty;
         AV88Udparg1 = Guid.Empty;
         A531ResidentPackageName = "";
         AV37SDT_Residents = new GXBaseCollection<SdtSDT_Resident>( context, "SDT_Resident", "Comforta_version2");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV44ResidentPackageId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV64ErrDescroption = "";
         Combo_residentpackageid_Selectedvalue_set = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_cardlefticon1_maintable = new GXUserControl();
         lblCardlefticon1_icon_Jsonclick = "";
         lblCardlefticon1_description_Jsonclick = "";
         TempTags = "";
         AV35CardLeftIcon1_Value = "";
         Freestylegrid1Container = new GXWebGrid( context);
         sStyleString = "";
         ucCombo_residentpackageid = new GXUserControl();
         Combo_residentpackageid_Caption = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         ucDvpanel_cardcomponent1_maintable = new GXUserControl();
         AV38AccountStatus = "";
         AV33LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         H00BH2_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         H00BH2_n527ResidentPackageId = new bool[] {false} ;
         H00BH2_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         H00BH2_A531ResidentPackageName = new string[] {""} ;
         H00BH3_A62ResidentId = new Guid[] {Guid.Empty} ;
         H00BH3_A29LocationId = new Guid[] {Guid.Empty} ;
         H00BH3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00BH3_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         H00BH3_n527ResidentPackageId = new bool[] {false} ;
         AV34ResidentPackageName = "";
         Freestylegrid1Row = new GXWebRow();
         AV57baseUrl = "";
         AV58ResidentGuid_Selected = "";
         AV59GAMUser_Resident = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV60GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV61ActivactionKey = "";
         AV62GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV65GamErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXEncryptionTmp = "";
         H00BH4_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         H00BH4_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         H00BH4_n527ResidentPackageId = new bool[] {false} ;
         H00BH4_A531ResidentPackageName = new string[] {""} ;
         AV45Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         H00BH5_A29LocationId = new Guid[] {Guid.Empty} ;
         H00BH5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00BH5_A62ResidentId = new Guid[] {Guid.Empty} ;
         H00BH5_A72ResidentSalutation = new string[] {""} ;
         H00BH5_A63ResidentBsnNumber = new string[] {""} ;
         H00BH5_A64ResidentGivenName = new string[] {""} ;
         H00BH5_A65ResidentLastName = new string[] {""} ;
         H00BH5_A66ResidentInitials = new string[] {""} ;
         H00BH5_A67ResidentEmail = new string[] {""} ;
         H00BH5_A68ResidentGender = new string[] {""} ;
         H00BH5_A312ResidentCountry = new string[] {""} ;
         H00BH5_A313ResidentCity = new string[] {""} ;
         H00BH5_A314ResidentZipCode = new string[] {""} ;
         H00BH5_A315ResidentAddressLine1 = new string[] {""} ;
         H00BH5_A316ResidentAddressLine2 = new string[] {""} ;
         H00BH5_A70ResidentPhone = new string[] {""} ;
         H00BH5_A97ResidentTypeName = new string[] {""} ;
         H00BH5_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H00BH5_n98MedicalIndicationId = new bool[] {false} ;
         H00BH5_A99MedicalIndicationName = new string[] {""} ;
         H00BH5_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         H00BH5_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H00BH5_n96ResidentTypeId = new bool[] {false} ;
         H00BH5_A71ResidentGUID = new string[] {""} ;
         AV54SDT_Resident = new SdtSDT_Resident(context);
         H00BH6_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         H00BH6_n527ResidentPackageId = new bool[] {false} ;
         H00BH6_A29LocationId = new Guid[] {Guid.Empty} ;
         H00BH6_A62ResidentId = new Guid[] {Guid.Empty} ;
         H00BH6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00BH6_A72ResidentSalutation = new string[] {""} ;
         H00BH6_A63ResidentBsnNumber = new string[] {""} ;
         H00BH6_A64ResidentGivenName = new string[] {""} ;
         H00BH6_A65ResidentLastName = new string[] {""} ;
         H00BH6_A66ResidentInitials = new string[] {""} ;
         H00BH6_A67ResidentEmail = new string[] {""} ;
         H00BH6_A68ResidentGender = new string[] {""} ;
         H00BH6_A312ResidentCountry = new string[] {""} ;
         H00BH6_A313ResidentCity = new string[] {""} ;
         H00BH6_A314ResidentZipCode = new string[] {""} ;
         H00BH6_A315ResidentAddressLine1 = new string[] {""} ;
         H00BH6_A316ResidentAddressLine2 = new string[] {""} ;
         H00BH6_A70ResidentPhone = new string[] {""} ;
         H00BH6_A97ResidentTypeName = new string[] {""} ;
         H00BH6_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H00BH6_n98MedicalIndicationId = new bool[] {false} ;
         H00BH6_A99MedicalIndicationName = new string[] {""} ;
         H00BH6_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         H00BH6_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H00BH6_n96ResidentTypeId = new bool[] {false} ;
         H00BH6_A71ResidentGUID = new string[] {""} ;
         GXt_char2 = "";
         GridRow = new GXWebRow();
         ucDvelop_confirmpanel_udelete = new GXUserControl();
         ucDvelop_confirmpanel_useractionblock = new GXUserControl();
         ucDvelop_confirmpanel_useractionunblock = new GXUserControl();
         ucDvelop_confirmpanel_resendinvite = new GXUserControl();
         lblCardlefticon1_moreinfoicon_Jsonclick = "";
         lblCardlefticon1_moreinfocaption_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subFreestylegrid1_Linesclass = "";
         lblCardcomponent1_icon_Jsonclick = "";
         lblCardcomponent1_description_Jsonclick = "";
         ROClassString = "";
         lblCardcomponent1_moreinfoicon_Jsonclick = "";
         lblCardcomponent1_moreinfocaption_Jsonclick = "";
         subGrid_Linesclass = "";
         subFreestylegrid1_Header = "";
         Freestylegrid1Column = new GXWebColumn();
         GridColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_provisionedappdashboard__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_provisionedappdashboard__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_provisionedappdashboard__default(),
            new Object[][] {
                new Object[] {
               H00BH2_A527ResidentPackageId, H00BH2_A528SG_LocationId, H00BH2_A531ResidentPackageName
               }
               , new Object[] {
               H00BH3_A62ResidentId, H00BH3_A29LocationId, H00BH3_A11OrganisationId, H00BH3_A527ResidentPackageId, H00BH3_n527ResidentPackageId
               }
               , new Object[] {
               H00BH4_A528SG_LocationId, H00BH4_A527ResidentPackageId, H00BH4_A531ResidentPackageName
               }
               , new Object[] {
               H00BH5_A29LocationId, H00BH5_A11OrganisationId, H00BH5_A62ResidentId, H00BH5_A72ResidentSalutation, H00BH5_A63ResidentBsnNumber, H00BH5_A64ResidentGivenName, H00BH5_A65ResidentLastName, H00BH5_A66ResidentInitials, H00BH5_A67ResidentEmail, H00BH5_A68ResidentGender,
               H00BH5_A312ResidentCountry, H00BH5_A313ResidentCity, H00BH5_A314ResidentZipCode, H00BH5_A315ResidentAddressLine1, H00BH5_A316ResidentAddressLine2, H00BH5_A70ResidentPhone, H00BH5_A97ResidentTypeName, H00BH5_A98MedicalIndicationId, H00BH5_n98MedicalIndicationId, H00BH5_A99MedicalIndicationName,
               H00BH5_A73ResidentBirthDate, H00BH5_A96ResidentTypeId, H00BH5_n96ResidentTypeId, H00BH5_A71ResidentGUID
               }
               , new Object[] {
               H00BH6_A527ResidentPackageId, H00BH6_n527ResidentPackageId, H00BH6_A29LocationId, H00BH6_A62ResidentId, H00BH6_A11OrganisationId, H00BH6_A72ResidentSalutation, H00BH6_A63ResidentBsnNumber, H00BH6_A64ResidentGivenName, H00BH6_A65ResidentLastName, H00BH6_A66ResidentInitials,
               H00BH6_A67ResidentEmail, H00BH6_A68ResidentGender, H00BH6_A312ResidentCountry, H00BH6_A313ResidentCity, H00BH6_A314ResidentZipCode, H00BH6_A315ResidentAddressLine1, H00BH6_A316ResidentAddressLine2, H00BH6_A70ResidentPhone, H00BH6_A97ResidentTypeName, H00BH6_A98MedicalIndicationId,
               H00BH6_n98MedicalIndicationId, H00BH6_A99MedicalIndicationName, H00BH6_A73ResidentBirthDate, H00BH6_A96ResidentTypeId, H00BH6_n96ResidentTypeId, H00BH6_A71ResidentGUID
               }
            }
         );
         /* GeneXus formulas. */
         edtavCardlefticon1_value_Enabled = 0;
         edtavCardcomponent1_value_Enabled = 0;
         edtavSdt_residents__residentid_Enabled = 0;
         edtavSdt_residents__locationid_Enabled = 0;
         edtavSdt_residents__organisationid_Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentinitials_Enabled = 0;
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         edtavSdt_residents__residentemail_Enabled = 0;
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavAccountstatus_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short AV41ActionGroup ;
      private short nDonePA ;
      private short subFreestylegrid1_Backcolorstyle ;
      private short subGrid_Backcolorstyle ;
      private short FREESTYLEGRID1_nEOF ;
      private short subFreestylegrid1_Backstyle ;
      private short subGrid_Backstyle ;
      private short subFreestylegrid1_Allowselection ;
      private short subFreestylegrid1_Allowhovering ;
      private short subFreestylegrid1_Allowcollapsing ;
      private short subFreestylegrid1_Collapsed ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_31 ;
      private int nRC_GXsfl_82 ;
      private int subFreestylegrid1_Recordcount ;
      private int subGrid_Rows ;
      private int nGXsfl_31_idx=1 ;
      private int nGXsfl_82_idx=1 ;
      private int edtavCardlefticon1_value_Enabled ;
      private int divUnnamedtable1_Visible ;
      private int AV68GXV1 ;
      private int edtavResidentpackageid_Visible ;
      private int subFreestylegrid1_Islastpage ;
      private int subGrid_Islastpage ;
      private int edtavCardcomponent1_value_Enabled ;
      private int edtavSdt_residents__residentid_Enabled ;
      private int edtavSdt_residents__locationid_Enabled ;
      private int edtavSdt_residents__organisationid_Enabled ;
      private int edtavSdt_residents__residentbsnnumber_Enabled ;
      private int edtavSdt_residents__residentgivenname_Enabled ;
      private int edtavSdt_residents__residentlastname_Enabled ;
      private int edtavSdt_residents__residentinitials_Enabled ;
      private int edtavSdt_residents__residentbirthdate_Enabled ;
      private int edtavSdt_residents__residentemail_Enabled ;
      private int edtavSdt_residents__residentphone_Enabled ;
      private int edtavSdt_residents__residentguid_Enabled ;
      private int edtavSdt_residents__residenttypeid_Enabled ;
      private int edtavSdt_residents__residenttypename_Enabled ;
      private int edtavSdt_residents__medicalindicationid_Enabled ;
      private int edtavSdt_residents__medicalindicationname_Enabled ;
      private int edtavSdt_residents__residentaddress_Enabled ;
      private int edtavAccountstatus_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_82_fel_idx=1 ;
      private int nGXsfl_82_bak_idx=1 ;
      private int AV90GXV20 ;
      private int AV91GXV21 ;
      private int AV92GXV22 ;
      private int idxLst ;
      private int subFreestylegrid1_Backcolor ;
      private int subFreestylegrid1_Allbackcolor ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subFreestylegrid1_Selectedindex ;
      private int subFreestylegrid1_Selectioncolor ;
      private int subFreestylegrid1_Hoveringcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV32Cardcomponent1_Value ;
      private long FREESTYLEGRID1_nCurrentRecord ;
      private long GRID_nCurrentRecord ;
      private long FREESTYLEGRID1_nFirstRecordOnPage ;
      private long GRID_nRecordCount ;
      private string Dvelop_confirmpanel_resendinvite_Result ;
      private string Dvelop_confirmpanel_useractionunblock_Result ;
      private string Dvelop_confirmpanel_useractionblock_Result ;
      private string Dvelop_confirmpanel_udelete_Result ;
      private string Combo_residentpackageid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_31_idx="0001" ;
      private string A72ResidentSalutation ;
      private string A66ResidentInitials ;
      private string A70ResidentPhone ;
      private string sGXsfl_82_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV64ErrDescroption ;
      private string Dvpanel_cardlefticon1_maintable_Width ;
      private string Dvpanel_cardlefticon1_maintable_Cls ;
      private string Dvpanel_cardlefticon1_maintable_Title ;
      private string Dvpanel_cardlefticon1_maintable_Iconposition ;
      private string Combo_residentpackageid_Cls ;
      private string Combo_residentpackageid_Selectedvalue_set ;
      private string Combo_residentpackageid_Emptyitemtext ;
      private string Dvelop_confirmpanel_resendinvite_Title ;
      private string Dvelop_confirmpanel_resendinvite_Confirmationtext ;
      private string Dvelop_confirmpanel_resendinvite_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_resendinvite_Nobuttoncaption ;
      private string Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_resendinvite_Yesbuttonposition ;
      private string Dvelop_confirmpanel_resendinvite_Confirmtype ;
      private string Dvelop_confirmpanel_useractionunblock_Title ;
      private string Dvelop_confirmpanel_useractionunblock_Confirmationtext ;
      private string Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useractionunblock_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useractionunblock_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useractionunblock_Confirmtype ;
      private string Dvelop_confirmpanel_useractionblock_Title ;
      private string Dvelop_confirmpanel_useractionblock_Confirmationtext ;
      private string Dvelop_confirmpanel_useractionblock_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useractionblock_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useractionblock_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useractionblock_Confirmtype ;
      private string Dvelop_confirmpanel_udelete_Title ;
      private string Dvelop_confirmpanel_udelete_Confirmationtext ;
      private string Dvelop_confirmpanel_udelete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_udelete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_udelete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_udelete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_udelete_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_cardlefticon1_maintable_Internalname ;
      private string divCardlefticon1_maintable_Internalname ;
      private string lblCardlefticon1_icon_Internalname ;
      private string lblCardlefticon1_icon_Jsonclick ;
      private string divCardlefticon1_tableinfo_Internalname ;
      private string lblCardlefticon1_description_Internalname ;
      private string lblCardlefticon1_description_Jsonclick ;
      private string edtavCardlefticon1_value_Internalname ;
      private string TempTags ;
      private string edtavCardlefticon1_value_Jsonclick ;
      private string sStyleString ;
      private string subFreestylegrid1_Internalname ;
      private string divTableresident_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divCombo_residentpackageid_cell_Internalname ;
      private string divCombo_residentpackageid_cell_Class ;
      private string Combo_residentpackageid_Caption ;
      private string Combo_residentpackageid_Internalname ;
      private string divTablerightheader_Internalname ;
      private string divTablefilters_Internalname ;
      private string divAdvancedfilterscontainer_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavResidentpackageid_Internalname ;
      private string edtavResidentpackageid_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXCCtl ;
      private string Dvpanel_cardcomponent1_maintable_Width ;
      private string Dvpanel_cardcomponent1_maintable_Internalname ;
      private string Dvpanel_cardcomponent1_maintable_Cls ;
      private string Dvpanel_cardcomponent1_maintable_Title ;
      private string Dvpanel_cardcomponent1_maintable_Iconposition ;
      private string edtavCardcomponent1_value_Internalname ;
      private string edtavAccountstatus_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string sGXsfl_82_fel_idx="0001" ;
      private string edtavAccountstatus_Columnheaderclass ;
      private string lblCardcomponent1_icon_Fontname ;
      private string lblCardcomponent1_description_Caption ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string edtavSdt_residents__residentgivenname_Link ;
      private string edtavSdt_residents__residentlastname_Link ;
      private string edtavAccountstatus_Columnclass ;
      private string tblTabledvelop_confirmpanel_udelete_Internalname ;
      private string Dvelop_confirmpanel_udelete_Internalname ;
      private string tblTabledvelop_confirmpanel_useractionblock_Internalname ;
      private string Dvelop_confirmpanel_useractionblock_Internalname ;
      private string tblTabledvelop_confirmpanel_useractionunblock_Internalname ;
      private string Dvelop_confirmpanel_useractionunblock_Internalname ;
      private string tblTabledvelop_confirmpanel_resendinvite_Internalname ;
      private string Dvelop_confirmpanel_resendinvite_Internalname ;
      private string tblCardlefticon1_moreinfo_Internalname ;
      private string lblCardlefticon1_moreinfoicon_Internalname ;
      private string lblCardlefticon1_moreinfoicon_Jsonclick ;
      private string lblCardlefticon1_moreinfocaption_Internalname ;
      private string lblCardlefticon1_moreinfocaption_Jsonclick ;
      private string lblCardcomponent1_icon_Internalname ;
      private string lblCardcomponent1_description_Internalname ;
      private string lblCardcomponent1_moreinfoicon_Internalname ;
      private string lblCardcomponent1_moreinfocaption_Internalname ;
      private string sGXsfl_31_fel_idx="0001" ;
      private string subFreestylegrid1_Class ;
      private string subFreestylegrid1_Linesclass ;
      private string divFreestylegrid1layouttable_Internalname ;
      private string divCardcomponent1_maintable_Internalname ;
      private string lblCardcomponent1_icon_Jsonclick ;
      private string divCardcomponent1_tableinfo_Internalname ;
      private string lblCardcomponent1_description_Jsonclick ;
      private string ROClassString ;
      private string edtavCardcomponent1_value_Jsonclick ;
      private string tblCardcomponent1_moreinfo_Internalname ;
      private string lblCardcomponent1_moreinfoicon_Jsonclick ;
      private string lblCardcomponent1_moreinfocaption_Jsonclick ;
      private string edtavSdt_residents__residentid_Internalname ;
      private string edtavSdt_residents__locationid_Internalname ;
      private string edtavSdt_residents__organisationid_Internalname ;
      private string edtavSdt_residents__residentbsnnumber_Internalname ;
      private string cmbavSdt_residents__residentsalutation_Internalname ;
      private string edtavSdt_residents__residentgivenname_Internalname ;
      private string edtavSdt_residents__residentlastname_Internalname ;
      private string edtavSdt_residents__residentinitials_Internalname ;
      private string cmbavSdt_residents__residentgender_Internalname ;
      private string edtavSdt_residents__residentbirthdate_Internalname ;
      private string edtavSdt_residents__residentemail_Internalname ;
      private string edtavSdt_residents__residentphone_Internalname ;
      private string edtavSdt_residents__residentguid_Internalname ;
      private string edtavSdt_residents__residenttypeid_Internalname ;
      private string edtavSdt_residents__residenttypename_Internalname ;
      private string edtavSdt_residents__medicalindicationid_Internalname ;
      private string edtavSdt_residents__medicalindicationname_Internalname ;
      private string edtavSdt_residents__residentaddress_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string edtavSdt_residents__residentid_Jsonclick ;
      private string edtavSdt_residents__locationid_Jsonclick ;
      private string edtavSdt_residents__organisationid_Jsonclick ;
      private string edtavSdt_residents__residentbsnnumber_Jsonclick ;
      private string cmbavSdt_residents__residentsalutation_Jsonclick ;
      private string edtavSdt_residents__residentgivenname_Jsonclick ;
      private string edtavSdt_residents__residentlastname_Jsonclick ;
      private string edtavSdt_residents__residentinitials_Jsonclick ;
      private string cmbavSdt_residents__residentgender_Jsonclick ;
      private string edtavSdt_residents__residentbirthdate_Jsonclick ;
      private string edtavSdt_residents__residentemail_Jsonclick ;
      private string edtavSdt_residents__residentphone_Jsonclick ;
      private string edtavSdt_residents__residentguid_Jsonclick ;
      private string edtavSdt_residents__residenttypeid_Jsonclick ;
      private string edtavSdt_residents__residenttypename_Jsonclick ;
      private string edtavSdt_residents__medicalindicationid_Jsonclick ;
      private string edtavSdt_residents__medicalindicationname_Jsonclick ;
      private string edtavSdt_residents__residentaddress_Jsonclick ;
      private string edtavAccountstatus_Jsonclick ;
      private string cmbavActiongroup_Jsonclick ;
      private string subFreestylegrid1_Header ;
      private string subGrid_Header ;
      private DateTime A73ResidentBirthDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n98MedicalIndicationId ;
      private bool n96ResidentTypeId ;
      private bool n527ResidentPackageId ;
      private bool AV42IsAuthorized_Delete ;
      private bool AV40IsAuthorized_SDT_Residents ;
      private bool AV63isSent ;
      private bool Dvpanel_cardlefticon1_maintable_Autowidth ;
      private bool Dvpanel_cardlefticon1_maintable_Autoheight ;
      private bool Dvpanel_cardlefticon1_maintable_Collapsible ;
      private bool Dvpanel_cardlefticon1_maintable_Collapsed ;
      private bool Dvpanel_cardlefticon1_maintable_Showcollapseicon ;
      private bool Dvpanel_cardlefticon1_maintable_Autoscroll ;
      private bool Combo_residentpackageid_Visible ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool Dvpanel_cardcomponent1_maintable_Autowidth ;
      private bool Dvpanel_cardcomponent1_maintable_Autoheight ;
      private bool Dvpanel_cardcomponent1_maintable_Collapsible ;
      private bool Dvpanel_cardcomponent1_maintable_Collapsed ;
      private bool Dvpanel_cardcomponent1_maintable_Showcollapseicon ;
      private bool Dvpanel_cardcomponent1_maintable_Autoscroll ;
      private bool bGXsfl_31_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_82_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool gx_BV82 ;
      private bool AV66IsUnblocked ;
      private bool AV67IsBlocked ;
      private bool AV51IsGAMActive ;
      private bool AV52IsGAMBlocked ;
      private bool GXt_boolean3 ;
      private string A63ResidentBsnNumber ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A67ResidentEmail ;
      private string A68ResidentGender ;
      private string A312ResidentCountry ;
      private string A313ResidentCity ;
      private string A314ResidentZipCode ;
      private string A315ResidentAddressLine1 ;
      private string A316ResidentAddressLine2 ;
      private string A97ResidentTypeName ;
      private string A99MedicalIndicationName ;
      private string A71ResidentGUID ;
      private string A531ResidentPackageName ;
      private string AV35CardLeftIcon1_Value ;
      private string AV38AccountStatus ;
      private string AV34ResidentPackageName ;
      private string AV57baseUrl ;
      private string AV58ResidentGuid_Selected ;
      private string AV61ActivactionKey ;
      private Guid AV36ResidentPackageId ;
      private Guid A11OrganisationId ;
      private Guid AV95Udparg2 ;
      private Guid A29LocationId ;
      private Guid AV96Udparg3 ;
      private Guid A62ResidentId ;
      private Guid A98MedicalIndicationId ;
      private Guid A96ResidentTypeId ;
      private Guid AV98Udparg4 ;
      private Guid A527ResidentPackageId ;
      private Guid A528SG_LocationId ;
      private Guid AV88Udparg1 ;
      private Guid AV33LocationId ;
      private Guid GXt_guid1 ;
      private GXWebGrid Freestylegrid1Container ;
      private GXWebGrid GridContainer ;
      private GXWebRow Freestylegrid1Row ;
      private GXWebRow GridRow ;
      private GXWebColumn Freestylegrid1Column ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_cardlefticon1_maintable ;
      private GXUserControl ucCombo_residentpackageid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDvpanel_cardcomponent1_maintable ;
      private GXUserControl ucDvelop_confirmpanel_udelete ;
      private GXUserControl ucDvelop_confirmpanel_useractionblock ;
      private GXUserControl ucDvelop_confirmpanel_useractionunblock ;
      private GXUserControl ucDvelop_confirmpanel_resendinvite ;
      private GxHttpRequest AV46HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavSdt_residents__residentsalutation ;
      private GXCombobox cmbavSdt_residents__residentgender ;
      private GXCombobox cmbavActiongroup ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV53WWPContext ;
      private GXBaseCollection<SdtSDT_Resident> AV37SDT_Residents ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV44ResidentPackageId_Data ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00BH2_A527ResidentPackageId ;
      private bool[] H00BH2_n527ResidentPackageId ;
      private Guid[] H00BH2_A528SG_LocationId ;
      private string[] H00BH2_A531ResidentPackageName ;
      private Guid[] H00BH3_A62ResidentId ;
      private Guid[] H00BH3_A29LocationId ;
      private Guid[] H00BH3_A11OrganisationId ;
      private Guid[] H00BH3_A527ResidentPackageId ;
      private bool[] H00BH3_n527ResidentPackageId ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV59GAMUser_Resident ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV60GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV62GAMError ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV65GamErrorCollection ;
      private Guid[] H00BH4_A528SG_LocationId ;
      private Guid[] H00BH4_A527ResidentPackageId ;
      private bool[] H00BH4_n527ResidentPackageId ;
      private string[] H00BH4_A531ResidentPackageName ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV45Combo_DataItem ;
      private Guid[] H00BH5_A29LocationId ;
      private Guid[] H00BH5_A11OrganisationId ;
      private Guid[] H00BH5_A62ResidentId ;
      private string[] H00BH5_A72ResidentSalutation ;
      private string[] H00BH5_A63ResidentBsnNumber ;
      private string[] H00BH5_A64ResidentGivenName ;
      private string[] H00BH5_A65ResidentLastName ;
      private string[] H00BH5_A66ResidentInitials ;
      private string[] H00BH5_A67ResidentEmail ;
      private string[] H00BH5_A68ResidentGender ;
      private string[] H00BH5_A312ResidentCountry ;
      private string[] H00BH5_A313ResidentCity ;
      private string[] H00BH5_A314ResidentZipCode ;
      private string[] H00BH5_A315ResidentAddressLine1 ;
      private string[] H00BH5_A316ResidentAddressLine2 ;
      private string[] H00BH5_A70ResidentPhone ;
      private string[] H00BH5_A97ResidentTypeName ;
      private Guid[] H00BH5_A98MedicalIndicationId ;
      private bool[] H00BH5_n98MedicalIndicationId ;
      private string[] H00BH5_A99MedicalIndicationName ;
      private DateTime[] H00BH5_A73ResidentBirthDate ;
      private Guid[] H00BH5_A96ResidentTypeId ;
      private bool[] H00BH5_n96ResidentTypeId ;
      private string[] H00BH5_A71ResidentGUID ;
      private SdtSDT_Resident AV54SDT_Resident ;
      private Guid[] H00BH6_A527ResidentPackageId ;
      private bool[] H00BH6_n527ResidentPackageId ;
      private Guid[] H00BH6_A29LocationId ;
      private Guid[] H00BH6_A62ResidentId ;
      private Guid[] H00BH6_A11OrganisationId ;
      private string[] H00BH6_A72ResidentSalutation ;
      private string[] H00BH6_A63ResidentBsnNumber ;
      private string[] H00BH6_A64ResidentGivenName ;
      private string[] H00BH6_A65ResidentLastName ;
      private string[] H00BH6_A66ResidentInitials ;
      private string[] H00BH6_A67ResidentEmail ;
      private string[] H00BH6_A68ResidentGender ;
      private string[] H00BH6_A312ResidentCountry ;
      private string[] H00BH6_A313ResidentCity ;
      private string[] H00BH6_A314ResidentZipCode ;
      private string[] H00BH6_A315ResidentAddressLine1 ;
      private string[] H00BH6_A316ResidentAddressLine2 ;
      private string[] H00BH6_A70ResidentPhone ;
      private string[] H00BH6_A97ResidentTypeName ;
      private Guid[] H00BH6_A98MedicalIndicationId ;
      private bool[] H00BH6_n98MedicalIndicationId ;
      private string[] H00BH6_A99MedicalIndicationName ;
      private DateTime[] H00BH6_A73ResidentBirthDate ;
      private Guid[] H00BH6_A96ResidentTypeId ;
      private bool[] H00BH6_n96ResidentTypeId ;
      private string[] H00BH6_A71ResidentGUID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_provisionedappdashboard__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_provisionedappdashboard__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_provisionedappdashboard__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_H00BH6( IGxContext context ,
                                          Guid AV36ResidentPackageId ,
                                          Guid A527ResidentPackageId ,
                                          Guid AV98Udparg4 ,
                                          Guid A29LocationId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int4 = new short[2];
      Object[] GXv_Object5 = new Object[2];
      scmdbuf = "SELECT T1.ResidentPackageId, T1.LocationId, T1.ResidentId, T1.OrganisationId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentInitials, T1.ResidentEmail, T1.ResidentGender, T1.ResidentCountry, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine1, T1.ResidentAddressLine2, T1.ResidentPhone, T3.ResidentTypeName, T1.MedicalIndicationId, T2.MedicalIndicationName, T1.ResidentBirthDate, T1.ResidentTypeId, T1.ResidentGUID FROM ((Trn_Resident T1 LEFT JOIN Trn_MedicalIndication T2 ON T2.MedicalIndicationId = T1.MedicalIndicationId) LEFT JOIN Trn_ResidentType T3 ON T3.ResidentTypeId = T1.ResidentTypeId)";
      AddWhere(sWhereString, "(T1.LocationId = :AV98Udparg4)");
      if ( ! (Guid.Empty==AV36ResidentPackageId) )
      {
         AddWhere(sWhereString, "(T1.ResidentPackageId = :AV36ResidentPackageId)");
      }
      else
      {
         GXv_int4[1] = 1;
      }
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY T1.LocationId";
      GXv_Object5[0] = scmdbuf;
      GXv_Object5[1] = GXv_int4;
      return GXv_Object5 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 4 :
                  return conditional_H00BH6(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
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
      ,new ForEachCursor(def[3])
      ,new ForEachCursor(def[4])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH00BH2;
       prmH00BH2 = new Object[] {
       new ParDef("AV88Udparg1",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH00BH3;
       prmH00BH3 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmH00BH4;
       prmH00BH4 = new Object[] {
       new ParDef("AV33LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH00BH5;
       prmH00BH5 = new Object[] {
       new ParDef("AV96Udparg3",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV53WWPC_1Organisationid",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV53WWPContext__Isrootadmin",GXType.Boolean,4,0) ,
       new ParDef("AV95Udparg2",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH00BH6;
       prmH00BH6 = new Object[] {
       new ParDef("AV98Udparg4",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV36ResidentPackageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("H00BH2", "SELECT ResidentPackageId, SG_LocationId, ResidentPackageName FROM Trn_ResidentPackage WHERE SG_LocationId = :AV88Udparg1 ORDER BY SG_LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BH2,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00BH3", "SELECT ResidentId, LocationId, OrganisationId, ResidentPackageId FROM Trn_Resident WHERE ResidentPackageId = :ResidentPackageId ORDER BY ResidentPackageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BH3,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("H00BH4", "SELECT SG_LocationId, ResidentPackageId, ResidentPackageName FROM Trn_ResidentPackage WHERE SG_LocationId = :AV33LocationId ORDER BY ResidentPackageName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BH4,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("H00BH5", "SELECT T1.LocationId, T1.OrganisationId, T1.ResidentId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentInitials, T1.ResidentEmail, T1.ResidentGender, T1.ResidentCountry, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine1, T1.ResidentAddressLine2, T1.ResidentPhone, T3.ResidentTypeName, T1.MedicalIndicationId, T2.MedicalIndicationName, T1.ResidentBirthDate, T1.ResidentTypeId, T1.ResidentGUID FROM ((Trn_Resident T1 LEFT JOIN Trn_MedicalIndication T2 ON T2.MedicalIndicationId = T1.MedicalIndicationId) LEFT JOIN Trn_ResidentType T3 ON T3.ResidentTypeId = T1.ResidentTypeId) WHERE (T1.LocationId = :AV96Udparg3) AND (T1.OrganisationId = CASE  WHEN :AV53WWPContext__Isrootadmin THEN :AV53WWPC_1Organisationid ELSE :AV95Udparg2 END) ORDER BY T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BH5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00BH6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BH6,100, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 20);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getString(16, 20);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((Guid[]) buf[17])[0] = rslt.getGuid(18);
             ((bool[]) buf[18])[0] = rslt.wasNull(18);
             ((string[]) buf[19])[0] = rslt.getVarchar(19);
             ((DateTime[]) buf[20])[0] = rslt.getGXDate(20);
             ((Guid[]) buf[21])[0] = rslt.getGuid(21);
             ((bool[]) buf[22])[0] = rslt.wasNull(21);
             ((string[]) buf[23])[0] = rslt.getVarchar(22);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((bool[]) buf[1])[0] = rslt.wasNull(1);
             ((Guid[]) buf[2])[0] = rslt.getGuid(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((Guid[]) buf[4])[0] = rslt.getGuid(4);
             ((string[]) buf[5])[0] = rslt.getString(5, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((string[]) buf[9])[0] = rslt.getString(9, 20);
             ((string[]) buf[10])[0] = rslt.getVarchar(10);
             ((string[]) buf[11])[0] = rslt.getVarchar(11);
             ((string[]) buf[12])[0] = rslt.getVarchar(12);
             ((string[]) buf[13])[0] = rslt.getVarchar(13);
             ((string[]) buf[14])[0] = rslt.getVarchar(14);
             ((string[]) buf[15])[0] = rslt.getVarchar(15);
             ((string[]) buf[16])[0] = rslt.getVarchar(16);
             ((string[]) buf[17])[0] = rslt.getString(17, 20);
             ((string[]) buf[18])[0] = rslt.getVarchar(18);
             ((Guid[]) buf[19])[0] = rslt.getGuid(19);
             ((bool[]) buf[20])[0] = rslt.wasNull(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((DateTime[]) buf[22])[0] = rslt.getGXDate(21);
             ((Guid[]) buf[23])[0] = rslt.getGuid(22);
             ((bool[]) buf[24])[0] = rslt.wasNull(22);
             ((string[]) buf[25])[0] = rslt.getVarchar(23);
             return;
    }
 }

}

}
