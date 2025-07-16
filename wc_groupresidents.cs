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
   public class wc_groupresidents : GXWebComponent
   {
      public wc_groupresidents( )
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

      public wc_groupresidents( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ResidentPackageId )
      {
         this.AV28ResidentPackageId = aP0_ResidentPackageId;
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
         cmbavSdt_residents__residentsalutation = new GXCombobox();
         cmbavSdt_residents__residentgender = new GXCombobox();
         cmbavActiongroup = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ResidentPackageId");
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
                  AV28ResidentPackageId = StringUtil.StrToGuid( GetPar( "ResidentPackageId"));
                  AssignAttri(sPrefix, false, "AV28ResidentPackageId", AV28ResidentPackageId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)AV28ResidentPackageId});
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
                  gxfirstwebparm = GetFirstPar( "ResidentPackageId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ResidentPackageId");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
         sPrefix = GetPar( "sPrefix");
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
         AV21ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV16ColumnsSelector);
         AV56Pgmname = GetPar( "Pgmname");
         AV12FilterFullText = GetPar( "FilterFullText");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6WWPContext);
         AV28ResidentPackageId = StringUtil.StrToGuid( GetPar( "ResidentPackageId"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV13SDT_Residents);
         AV29ResidentDefinitionTitle = GetPar( "ResidentDefinitionTitle");
         AV32ResidentTitle = GetPar( "ResidentTitle");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV21ManageFiltersExecutionStep, AV16ColumnsSelector, AV56Pgmname, AV12FilterFullText, AV6WWPContext, AV28ResidentPackageId, AV13SDT_Residents, AV29ResidentDefinitionTitle, AV32ResidentTitle, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            PABY2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV56Pgmname = "WC_GroupResidents";
               edtavSdt_residents__residentid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residentid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentid_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__locationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__locationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__locationid_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__organisationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__organisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__organisationid_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               cmbavSdt_residents__residentsalutation.Enabled = 0;
               AssignProp(sPrefix, false, cmbavSdt_residents__residentsalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdt_residents__residentsalutation.Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residenttitle_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residenttitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residenttitle_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residentbsnnumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residentbsnnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentbsnnumber_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residentgivenname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residentgivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentgivenname_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residentlastname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residentlastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentlastname_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residentinitials_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residentinitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentinitials_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residentemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residentemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentemail_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               cmbavSdt_residents__residentgender.Enabled = 0;
               AssignProp(sPrefix, false, cmbavSdt_residents__residentgender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdt_residents__residentgender.Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residentaddress_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residentaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentaddress_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residentphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residentphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentphone_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residentbirthdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residentbirthdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentbirthdate_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residentguid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residentguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentguid_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residenttypeid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residenttypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residenttypeid_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residenttypename_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residenttypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residenttypename_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__medicalindicationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__medicalindicationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__medicalindicationid_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__medicalindicationname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__medicalindicationname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__medicalindicationname_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residentimage_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residentimage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentimage_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavSdt_residents__residentlanguage_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_residents__residentlanguage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentlanguage_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               WSBY2( ) ;
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
            context.SendWebValue( context.GetMessage( "WC_Group Residents", "")) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
            GXEncryptionTmp = "wc_groupresidents.aspx"+UrlEncode(AV28ResidentPackageId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wc_groupresidents.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV6WWPContext, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_RESIDENTS", AV13SDT_Residents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_RESIDENTS", AV13SDT_Residents);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_RESIDENTS", GetSecureSignedToken( sPrefix, AV13SDT_Residents, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTDEFINITIONTITLE", AV29ResidentDefinitionTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTDEFINITIONTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV29ResidentDefinitionTitle, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTTITLE", AV32ResidentTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32ResidentTitle, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdt_residents", AV13SDT_Residents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdt_residents", AV13SDT_Residents);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_Sdt_residents", GetSecureSignedToken( sPrefix, AV13SDT_Residents, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV19ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV19ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV26GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOLUMNSSELECTOR", AV16ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOLUMNSSELECTOR", AV16ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV28ResidentPackageId", wcpOAV28ResidentPackageId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV6WWPContext, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTPACKAGEID", AV28ResidentPackageId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV10GridState);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_RESIDENTS", AV13SDT_Residents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_RESIDENTS", AV13SDT_Residents);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_RESIDENTS", GetSecureSignedToken( sPrefix, AV13SDT_Residents, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTDEFINITIONTITLE", AV29ResidentDefinitionTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTDEFINITIONTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV29ResidentDefinitionTitle, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTTITLE", AV32ResidentTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32ResidentTitle, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Title", StringUtil.RTrim( Dvelop_confirmpanel_removeresident_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_removeresident_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_removeresident_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_removeresident_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_removeresident_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_removeresident_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_removeresident_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"INSERT_MODAL_Width", StringUtil.RTrim( Insert_modal_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"INSERT_MODAL_Title", StringUtil.RTrim( Insert_modal_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"INSERT_MODAL_Confirmtype", StringUtil.RTrim( Insert_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"INSERT_MODAL_Bodytype", StringUtil.RTrim( Insert_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_removeresident_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_removeresident_Result));
      }

      protected void RenderHtmlCloseFormBY2( )
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
         return "WC_GroupResidents" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WC_Group Residents", "") ;
      }

      protected void WBBY0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wc_groupresidents.aspx");
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
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", bttBtninsert_Caption, bttBtninsert_Jsonclick, 7, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11by1_client"+"'", TempTags, "", 2, "HLP_WC_GroupResidents.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WC_GroupResidents.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV19ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV12FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WC_GroupResidents.htm");
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV34GXV1 = nGXsfl_37_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV24GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV25GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV26GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
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
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV16ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, sPrefix+"DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table1_67_BY2( true) ;
         }
         else
         {
            wb_table1_67_BY2( false) ;
         }
         return  ;
      }

      protected void wb_table1_67_BY2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_72_BY2( true) ;
         }
         else
         {
            wb_table2_72_BY2( false) ;
         }
         return  ;
      }

      protected void wb_table2_72_BY2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0079"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0079"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_37_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0079"+"");
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
         if ( wbEnd == 37 )
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
                  AV34GXV1 = nGXsfl_37_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTBY2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WC_Group Residents", ""), 0) ;
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
               STRUPBY0( ) ;
            }
         }
      }

      protected void WSBY2( )
      {
         STARTBY2( ) ;
         EVTBY2( ) ;
      }

      protected void EVTBY2( )
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
                                 STRUPBY0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E12BY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E13BY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E14BY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                                    E15BY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_REMOVERESIDENT.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_removeresident.Close */
                                    E16BY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "INSERT_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Insert_modal.Close */
                                    E17BY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "INSERT_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Insert_modal.Onloadcomponent */
                                    E18BY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSdt_residents__residentid_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBY0( ) ;
                              }
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              AV34GXV1 = (int)(nGXsfl_37_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV13SDT_Residents.Count >= AV34GXV1 ) && ( AV34GXV1 > 0 ) )
                              {
                                 AV13SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1));
                                 cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                                 cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                                 AV27ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV27ActionGroup), 4, 0));
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
                                          GX_FocusControl = edtavSdt_residents__residentid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E19BY2 ();
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
                                          GX_FocusControl = edtavSdt_residents__residentid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E20BY2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_residents__residentid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E21BY2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_residents__residentid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E22BY2 ();
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
                                       STRUPBY0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_residents__residentid_Internalname;
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
                        if ( nCmpId == 79 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0079");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0079", "", sEvt);
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

      protected void WEBY2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormBY2( ) ;
            }
         }
      }

      protected void PABY2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wc_groupresidents.aspx")), "wc_groupresidents.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wc_groupresidents.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ResidentPackageId");
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV21ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV16ColumnsSelector ,
                                       string AV56Pgmname ,
                                       string AV12FilterFullText ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ,
                                       Guid AV28ResidentPackageId ,
                                       GXBaseCollection<SdtSDT_Resident> AV13SDT_Residents ,
                                       string AV29ResidentDefinitionTitle ,
                                       string AV32ResidentTitle ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFBY2( ) ;
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
         RFBY2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV56Pgmname = "WC_GroupResidents";
         edtavSdt_residents__residentid_Enabled = 0;
         edtavSdt_residents__locationid_Enabled = 0;
         edtavSdt_residents__organisationid_Enabled = 0;
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residenttitle_Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentinitials_Enabled = 0;
         edtavSdt_residents__residentemail_Enabled = 0;
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__residentimage_Enabled = 0;
         edtavSdt_residents__residentlanguage_Enabled = 0;
      }

      protected void RFBY2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E20BY2 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
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
            SubsflControlProps_372( ) ;
            /* Execute user event: Grid.Load */
            E21BY2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_37_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E21BY2 ();
            }
            wbEnd = 37;
            WBBY0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBY2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV6WWPContext, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_RESIDENTS", AV13SDT_Residents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_RESIDENTS", AV13SDT_Residents);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDT_RESIDENTS", GetSecureSignedToken( sPrefix, AV13SDT_Residents, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTDEFINITIONTITLE", AV29ResidentDefinitionTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTDEFINITIONTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV29ResidentDefinitionTitle, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTTITLE", AV32ResidentTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32ResidentTitle, "")), context));
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
         return AV13SDT_Residents.Count ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV21ManageFiltersExecutionStep, AV16ColumnsSelector, AV56Pgmname, AV12FilterFullText, AV6WWPContext, AV28ResidentPackageId, AV13SDT_Residents, AV29ResidentDefinitionTitle, AV32ResidentTitle, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV21ManageFiltersExecutionStep, AV16ColumnsSelector, AV56Pgmname, AV12FilterFullText, AV6WWPContext, AV28ResidentPackageId, AV13SDT_Residents, AV29ResidentDefinitionTitle, AV32ResidentTitle, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV21ManageFiltersExecutionStep, AV16ColumnsSelector, AV56Pgmname, AV12FilterFullText, AV6WWPContext, AV28ResidentPackageId, AV13SDT_Residents, AV29ResidentDefinitionTitle, AV32ResidentTitle, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV21ManageFiltersExecutionStep, AV16ColumnsSelector, AV56Pgmname, AV12FilterFullText, AV6WWPContext, AV28ResidentPackageId, AV13SDT_Residents, AV29ResidentDefinitionTitle, AV32ResidentTitle, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV21ManageFiltersExecutionStep, AV16ColumnsSelector, AV56Pgmname, AV12FilterFullText, AV6WWPContext, AV28ResidentPackageId, AV13SDT_Residents, AV29ResidentDefinitionTitle, AV32ResidentTitle, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV56Pgmname = "WC_GroupResidents";
         edtavSdt_residents__residentid_Enabled = 0;
         edtavSdt_residents__locationid_Enabled = 0;
         edtavSdt_residents__organisationid_Enabled = 0;
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residenttitle_Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentinitials_Enabled = 0;
         edtavSdt_residents__residentemail_Enabled = 0;
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__residentimage_Enabled = 0;
         edtavSdt_residents__residentlanguage_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBY0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19BY2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdt_residents"), AV13SDT_Residents);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV19ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV22DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCOLUMNSSELECTOR"), AV16ColumnsSelector);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDT_RESIDENTS"), AV13SDT_Residents);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV24GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV25GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV26GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV28ResidentPackageId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV28ResidentPackageId"));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_gridcolumnsselector_Icontype = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Dvelop_confirmpanel_removeresident_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Title");
            Dvelop_confirmpanel_removeresident_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Confirmationtext");
            Dvelop_confirmpanel_removeresident_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Yesbuttoncaption");
            Dvelop_confirmpanel_removeresident_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Nobuttoncaption");
            Dvelop_confirmpanel_removeresident_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Cancelbuttoncaption");
            Dvelop_confirmpanel_removeresident_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Yesbuttonposition");
            Dvelop_confirmpanel_removeresident_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Confirmtype");
            Insert_modal_Width = cgiGet( sPrefix+"INSERT_MODAL_Width");
            Insert_modal_Title = cgiGet( sPrefix+"INSERT_MODAL_Title");
            Insert_modal_Confirmtype = cgiGet( sPrefix+"INSERT_MODAL_Confirmtype");
            Insert_modal_Bodytype = cgiGet( sPrefix+"INSERT_MODAL_Bodytype");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_removeresident_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT_Result");
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_37_fel_idx = 0;
            while ( nGXsfl_37_fel_idx < nRC_GXsfl_37 )
            {
               nGXsfl_37_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_fel_idx+1);
               sGXsfl_37_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_372( ) ;
               AV34GXV1 = (int)(nGXsfl_37_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV13SDT_Residents.Count >= AV34GXV1 ) && ( AV34GXV1 > 0 ) )
               {
                  AV13SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1));
                  cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                  cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                  AV27ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               }
            }
            if ( nGXsfl_37_fel_idx == 0 )
            {
               nGXsfl_37_idx = 1;
               sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
               SubsflControlProps_372( ) ;
            }
            nGXsfl_37_fel_idx = 1;
            /* Read variables values. */
            AV12FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV12FilterFullText", AV12FilterFullText);
            /* Read subfile selected row values. */
            nGXsfl_37_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            AV34GXV1 = (int)(nGXsfl_37_idx+GRID_nFirstRecordOnPage);
            if ( nGXsfl_37_idx > 0 )
            {
               AV34GXV1 = (int)(nGXsfl_37_idx+GRID_nFirstRecordOnPage);
               if ( ( AV13SDT_Residents.Count >= AV34GXV1 ) && ( AV34GXV1 > 0 ) )
               {
                  AV13SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1));
                  cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                  cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                  AV27ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV27ActionGroup), 4, 0));
               }
               if ( ( AV34GXV1 > 0 ) && ( AV13SDT_Residents.Count >= AV34GXV1 ) )
               {
                  AV13SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1));
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
         E19BY2 ();
         if (returnInSub) return;
      }

      protected void E19BY2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, sPrefix, false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV22DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV22DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, sPrefix, false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         GXt_char2 = AV29ResidentDefinitionTitle;
         new prc_getorganisationdefinition(context ).execute(  "Resident", out  GXt_char2) ;
         AV29ResidentDefinitionTitle = GXt_char2;
         AssignAttri(sPrefix, false, "AV29ResidentDefinitionTitle", AV29ResidentDefinitionTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTDEFINITIONTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV29ResidentDefinitionTitle, "")), context));
         GXt_char2 = AV33ResidentsDefinitionTitle;
         new prc_getorganisationdefinition(context ).execute(  "Residents", out  GXt_char2) ;
         AV33ResidentsDefinitionTitle = GXt_char2;
         bttBtninsert_Caption = context.GetMessage( "Add ", "")+AV33ResidentsDefinitionTitle;
         AssignProp(sPrefix, false, bttBtninsert_Internalname, "Caption", bttBtninsert_Caption, true);
      }

      protected void E20BY2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV21ManageFiltersExecutionStep == 1 )
         {
            AV21ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV21ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV21ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV21ManageFiltersExecutionStep == 2 )
         {
            AV21ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV21ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV21ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV18Session.Get("WC_GroupResidentsColumnsSelector"), "") != 0 )
         {
            AV14ColumnsSelectorXML = AV18Session.Get("WC_GroupResidentsColumnsSelector");
            AV16ColumnsSelector.FromXml(AV14ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S142 ();
            if (returnInSub) return;
         }
         edtavSdt_residents__residentgivenname_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV16ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtavSdt_residents__residentgivenname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentgivenname_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavSdt_residents__residentlastname_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV16ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtavSdt_residents__residentlastname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentlastname_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavSdt_residents__residentemail_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV16ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtavSdt_residents__residentemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentemail_Visible), 5, 0), !bGXsfl_37_Refreshing);
         cmbavSdt_residents__residentgender.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV16ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, cmbavSdt_residents__residentgender_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavSdt_residents__residentgender.Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavSdt_residents__residentphone_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV16ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtavSdt_residents__residentphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdt_residents__residentphone_Visible), 5, 0), !bGXsfl_37_Refreshing);
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S152 ();
         if (returnInSub) return;
         AV24GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV24GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV24GridCurrentPage), 10, 0));
         AV25GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV25GridPageCount", StringUtil.LTrimStr( (decimal)(AV25GridPageCount), 10, 0));
         GXt_char2 = AV26GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV56Pgmname, out  GXt_char2) ;
         AV26GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV26GridAppliedFilters", AV26GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV16ColumnsSelector", AV16ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19ManageFiltersData", AV19ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDT_Residents", AV13SDT_Residents);
      }

      protected void E13BY2( )
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
            AV23PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV23PageToGo) ;
         }
      }

      protected void E14BY2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E21BY2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV34GXV1 = 1;
         while ( AV34GXV1 <= AV13SDT_Residents.Count )
         {
            AV13SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1));
            cmbavActiongroup.removeAllItems();
            cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
            cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Remove from Group", ""), "fas fa-user-xmark", "", "", "", "", "", "", ""), 0);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 37;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_372( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
            {
               DoAjaxLoad(37, GridRow);
            }
            AV34GXV1 = (int)(AV34GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27ActionGroup), 4, 0));
      }

      protected void E15BY2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV14ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV16ColumnsSelector.FromJSonString(AV14ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WC_GroupResidentsColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV14ColumnsSelectorXML)) ? "" : AV16ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV16ColumnsSelector", AV16ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19ManageFiltersData", AV19ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         if ( gx_BV37 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDT_Residents", AV13SDT_Residents);
            nGXsfl_37_bak_idx = nGXsfl_37_idx;
            gxgrGrid_refresh( subGrid_Rows, AV21ManageFiltersExecutionStep, AV16ColumnsSelector, AV56Pgmname, AV12FilterFullText, AV6WWPContext, AV28ResidentPackageId, AV13SDT_Residents, AV29ResidentDefinitionTitle, AV32ResidentTitle, sPrefix) ;
            nGXsfl_37_idx = nGXsfl_37_bak_idx;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
      }

      protected void E12BY2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S162 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S132 ();
            if (returnInSub) return;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WC_GroupResidentsFilters")) + "," + UrlEncode(StringUtil.RTrim(AV56Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV21ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV21ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV21ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WC_GroupResidentsFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV21ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV21ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV21ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV20ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WC_GroupResidentsFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV20ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if (returnInSub) return;
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV56Pgmname+"GridState",  AV20ManageFiltersXml) ;
               AV10GridState.FromXml(AV20ManageFiltersXml, null, "", "");
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV16ColumnsSelector", AV16ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19ManageFiltersData", AV19ManageFiltersData);
         if ( gx_BV37 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDT_Residents", AV13SDT_Residents);
            nGXsfl_37_bak_idx = nGXsfl_37_idx;
            gxgrGrid_refresh( subGrid_Rows, AV21ManageFiltersExecutionStep, AV16ColumnsSelector, AV56Pgmname, AV12FilterFullText, AV6WWPContext, AV28ResidentPackageId, AV13SDT_Residents, AV29ResidentDefinitionTitle, AV32ResidentTitle, sPrefix) ;
            nGXsfl_37_idx = nGXsfl_37_bak_idx;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
      }

      protected void E22BY2( )
      {
         AV34GXV1 = (int)(nGXsfl_37_idx+GRID_nFirstRecordOnPage);
         if ( ( AV34GXV1 > 0 ) && ( AV13SDT_Residents.Count >= AV34GXV1 ) )
         {
            AV13SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1));
         }
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV27ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S182 ();
            if (returnInSub) return;
         }
         else if ( AV27ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO REMOVERESIDENT' */
            S192 ();
            if (returnInSub) return;
         }
         AV27ActionGroup = 0;
         AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV27ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27ActionGroup), 4, 0));
         AssignProp(sPrefix, false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
      }

      protected void E16BY2( )
      {
         AV34GXV1 = (int)(nGXsfl_37_idx+GRID_nFirstRecordOnPage);
         if ( ( AV34GXV1 > 0 ) && ( AV13SDT_Residents.Count >= AV34GXV1 ) )
         {
            AV13SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1));
         }
         /* Dvelop_confirmpanel_removeresident_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_removeresident_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION REMOVERESIDENT' */
            S202 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV16ColumnsSelector", AV16ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19ManageFiltersData", AV19ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDT_Residents", AV13SDT_Residents);
         nGXsfl_37_bak_idx = nGXsfl_37_idx;
         gxgrGrid_refresh( subGrid_Rows, AV21ManageFiltersExecutionStep, AV16ColumnsSelector, AV56Pgmname, AV12FilterFullText, AV6WWPContext, AV28ResidentPackageId, AV13SDT_Residents, AV29ResidentDefinitionTitle, AV32ResidentTitle, sPrefix) ;
         nGXsfl_37_idx = nGXsfl_37_bak_idx;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
      }

      protected void E18BY2( )
      {
         AV34GXV1 = (int)(nGXsfl_37_idx+GRID_nFirstRecordOnPage);
         if ( ( AV34GXV1 > 0 ) && ( AV13SDT_Residents.Count >= AV34GXV1 ) )
         {
            AV13SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1));
         }
         /* Insert_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WC_SelectResidents")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wc_selectresidents", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WC_SelectResidents";
            WebComp_Wwpaux_wc_Component = "WC_SelectResidents";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0079",(string)"",(Guid)AV28ResidentPackageId,(GXBaseCollection<SdtSDT_Resident>)AV13SDT_Residents});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0079"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E17BY2( )
      {
         /* Insert_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV16ColumnsSelector", AV16ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19ManageFiltersData", AV19ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         if ( gx_BV37 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDT_Residents", AV13SDT_Residents);
            nGXsfl_37_bak_idx = nGXsfl_37_idx;
            gxgrGrid_refresh( subGrid_Rows, AV21ManageFiltersExecutionStep, AV16ColumnsSelector, AV56Pgmname, AV12FilterFullText, AV6WWPContext, AV28ResidentPackageId, AV13SDT_Residents, AV29ResidentDefinitionTitle, AV32ResidentTitle, sPrefix) ;
            nGXsfl_37_idx = nGXsfl_37_bak_idx;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
      }

      protected void S152( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
         GXt_objcol_SdtSDT_Resident3 = AV13SDT_Residents;
         new prc_getgroupresidents(context ).execute(  AV6WWPContext.gxTpr_Locationid,  AV28ResidentPackageId, ref  GXt_objcol_SdtSDT_Resident3) ;
         AV13SDT_Residents = GXt_objcol_SdtSDT_Resident3;
         gx_BV37 = true;
      }

      protected void S142( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV16ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV16ColumnsSelector,  "SDT_Residents__ResidentGivenName",  "",  "First Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV16ColumnsSelector,  "SDT_Residents__ResidentLastName",  "",  "Last Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV16ColumnsSelector,  "SDT_Residents__ResidentEmail",  "",  "Email",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV16ColumnsSelector,  "SDT_Residents__ResidentGender",  "",  "Gender",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV16ColumnsSelector,  "SDT_Residents__ResidentPhone",  "",  "Phone",  true,  "") ;
         GXt_char2 = AV15UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WC_GroupResidentsColumnsSelector", out  GXt_char2) ;
         AV15UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV15UserCustomValue)) ) )
         {
            AV17ColumnsSelectorAux.FromXml(AV15UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV17ColumnsSelectorAux, ref  AV16ColumnsSelector) ;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV19ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WC_GroupResidentsFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV19ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV12FilterFullText = "";
         AssignAttri(sPrefix, false, "AV12FilterFullText", AV12FilterFullText);
      }

      protected void S182( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_residentview.aspx"+UrlEncode(((SdtSDT_Resident)(AV13SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV13SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV13SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("trn_residentview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S192( )
      {
         /* 'DO REMOVERESIDENT' Routine */
         returnInSub = false;
         Dvelop_confirmpanel_removeresident_Confirmationtext = context.GetMessage( "Are you sure you want to remove this ", "")+AV29ResidentDefinitionTitle+context.GetMessage( " from this group", "");
         ucDvelop_confirmpanel_removeresident.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_removeresident_Internalname, "ConfirmationText", Dvelop_confirmpanel_removeresident_Confirmationtext);
         Dvelop_confirmpanel_removeresident_Title = context.GetMessage( "Confirm Action", "");
         ucDvelop_confirmpanel_removeresident.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_removeresident_Internalname, "Title", Dvelop_confirmpanel_removeresident_Title);
         this.executeUsercontrolMethod(sPrefix, false, "DVELOP_CONFIRMPANEL_REMOVERESIDENTContainer", "Confirm", "", new Object[] {});
      }

      protected void S202( )
      {
         /* 'DO ACTION REMOVERESIDENT' Routine */
         returnInSub = false;
         new prc_removeresidentfromgroup(context ).execute(  ((SdtSDT_Resident)(AV13SDT_Residents.CurrentItem)).gxTpr_Residentid,  ((SdtSDT_Resident)(AV13SDT_Residents.CurrentItem)).gxTpr_Locationid,  ((SdtSDT_Resident)(AV13SDT_Residents.CurrentItem)).gxTpr_Organisationid,  AV28ResidentPackageId, out  AV30isSuccessful) ;
         AV31ActiveLanguageName = context.GetLanguage( );
         if ( AV30isSuccessful && StringUtil.Contains( AV31ActiveLanguageName, context.GetMessage( "English", "")) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV32ResidentTitle+context.GetMessage( " removed successfully", ""),  "success",  "",  "true",  ""));
            gxgrGrid_refresh( subGrid_Rows, AV21ManageFiltersExecutionStep, AV16ColumnsSelector, AV56Pgmname, AV12FilterFullText, AV6WWPContext, AV28ResidentPackageId, AV13SDT_Residents, AV29ResidentDefinitionTitle, AV32ResidentTitle, sPrefix) ;
         }
         else
         {
            if ( AV30isSuccessful && StringUtil.Contains( AV31ActiveLanguageName, context.GetMessage( "Dutch", "")) )
            {
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV32ResidentTitle+context.GetMessage( " succesvol verwijderd", ""),  "success",  "",  "true",  ""));
               gxgrGrid_refresh( subGrid_Rows, AV21ManageFiltersExecutionStep, AV16ColumnsSelector, AV56Pgmname, AV12FilterFullText, AV6WWPContext, AV28ResidentPackageId, AV13SDT_Residents, AV29ResidentDefinitionTitle, AV32ResidentTitle, sPrefix) ;
            }
            else
            {
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Action could not be performed, please try again", ""),  "error",  "",  "true",  ""));
            }
         }
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18Session.Get(AV56Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV56Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV18Session.Get(AV56Pgmname+"GridState"), null, "", "");
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV57GXV23 = 1;
         while ( AV57GXV23 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV57GXV23));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV12FilterFullText", AV12FilterFullText);
            }
            AV57GXV23 = (int)(AV57GXV23+1);
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV18Session.Get(AV56Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV12FilterFullText)),  0,  AV12FilterFullText,  AV12FilterFullText,  false,  "",  "") ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV56Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void wb_table2_72_BY2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableinsert_modal_Internalname, tblTableinsert_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucInsert_modal.SetProperty("Width", Insert_modal_Width);
            ucInsert_modal.SetProperty("Title", Insert_modal_Title);
            ucInsert_modal.SetProperty("ConfirmType", Insert_modal_Confirmtype);
            ucInsert_modal.SetProperty("BodyType", Insert_modal_Bodytype);
            ucInsert_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Insert_modal_Internalname, sPrefix+"INSERT_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"INSERT_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_72_BY2e( true) ;
         }
         else
         {
            wb_table2_72_BY2e( false) ;
         }
      }

      protected void wb_table1_67_BY2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_removeresident_Internalname, tblTabledvelop_confirmpanel_removeresident_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_removeresident.SetProperty("Title", Dvelop_confirmpanel_removeresident_Title);
            ucDvelop_confirmpanel_removeresident.SetProperty("ConfirmationText", Dvelop_confirmpanel_removeresident_Confirmationtext);
            ucDvelop_confirmpanel_removeresident.SetProperty("YesButtonCaption", Dvelop_confirmpanel_removeresident_Yesbuttoncaption);
            ucDvelop_confirmpanel_removeresident.SetProperty("NoButtonCaption", Dvelop_confirmpanel_removeresident_Nobuttoncaption);
            ucDvelop_confirmpanel_removeresident.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_removeresident_Cancelbuttoncaption);
            ucDvelop_confirmpanel_removeresident.SetProperty("YesButtonPosition", Dvelop_confirmpanel_removeresident_Yesbuttonposition);
            ucDvelop_confirmpanel_removeresident.SetProperty("ConfirmType", Dvelop_confirmpanel_removeresident_Confirmtype);
            ucDvelop_confirmpanel_removeresident.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_removeresident_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENTContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_67_BY2e( true) ;
         }
         else
         {
            wb_table1_67_BY2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV28ResidentPackageId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV28ResidentPackageId", AV28ResidentPackageId.ToString());
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
         PABY2( ) ;
         WSBY2( ) ;
         WEBY2( ) ;
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
         sCtrlAV28ResidentPackageId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PABY2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wc_groupresidents", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PABY2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV28ResidentPackageId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV28ResidentPackageId", AV28ResidentPackageId.ToString());
         }
         wcpOAV28ResidentPackageId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV28ResidentPackageId"));
         if ( ! GetJustCreated( ) && ( ( AV28ResidentPackageId != wcpOAV28ResidentPackageId ) ) )
         {
            setjustcreated();
         }
         wcpOAV28ResidentPackageId = AV28ResidentPackageId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV28ResidentPackageId = cgiGet( sPrefix+"AV28ResidentPackageId_CTRL");
         if ( StringUtil.Len( sCtrlAV28ResidentPackageId) > 0 )
         {
            AV28ResidentPackageId = StringUtil.StrToGuid( cgiGet( sCtrlAV28ResidentPackageId));
            AssignAttri(sPrefix, false, "AV28ResidentPackageId", AV28ResidentPackageId.ToString());
         }
         else
         {
            AV28ResidentPackageId = StringUtil.StrToGuid( cgiGet( sPrefix+"AV28ResidentPackageId_PARM"));
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
         PABY2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSBY2( ) ;
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
         WSBY2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV28ResidentPackageId_PARM", AV28ResidentPackageId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV28ResidentPackageId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV28ResidentPackageId_CTRL", StringUtil.RTrim( sCtrlAV28ResidentPackageId));
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
         WEBY2( ) ;
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
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257161754590", true, true);
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
         context.AddJavascriptSource("wc_groupresidents.js", "?20257161754591", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         edtavSdt_residents__residentid_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTID_"+sGXsfl_37_idx;
         edtavSdt_residents__locationid_Internalname = sPrefix+"SDT_RESIDENTS__LOCATIONID_"+sGXsfl_37_idx;
         edtavSdt_residents__organisationid_Internalname = sPrefix+"SDT_RESIDENTS__ORGANISATIONID_"+sGXsfl_37_idx;
         cmbavSdt_residents__residentsalutation_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTSALUTATION_"+sGXsfl_37_idx;
         edtavSdt_residents__residenttitle_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTTITLE_"+sGXsfl_37_idx;
         edtavSdt_residents__residentbsnnumber_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTBSNNUMBER_"+sGXsfl_37_idx;
         edtavSdt_residents__residentgivenname_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTGIVENNAME_"+sGXsfl_37_idx;
         edtavSdt_residents__residentlastname_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTLASTNAME_"+sGXsfl_37_idx;
         edtavSdt_residents__residentinitials_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTINITIALS_"+sGXsfl_37_idx;
         edtavSdt_residents__residentemail_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTEMAIL_"+sGXsfl_37_idx;
         cmbavSdt_residents__residentgender_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTGENDER_"+sGXsfl_37_idx;
         edtavSdt_residents__residentaddress_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTADDRESS_"+sGXsfl_37_idx;
         edtavSdt_residents__residentphone_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTPHONE_"+sGXsfl_37_idx;
         edtavSdt_residents__residentbirthdate_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTBIRTHDATE_"+sGXsfl_37_idx;
         edtavSdt_residents__residentguid_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTGUID_"+sGXsfl_37_idx;
         edtavSdt_residents__residenttypeid_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTTYPEID_"+sGXsfl_37_idx;
         edtavSdt_residents__residenttypename_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTTYPENAME_"+sGXsfl_37_idx;
         edtavSdt_residents__medicalindicationid_Internalname = sPrefix+"SDT_RESIDENTS__MEDICALINDICATIONID_"+sGXsfl_37_idx;
         edtavSdt_residents__medicalindicationname_Internalname = sPrefix+"SDT_RESIDENTS__MEDICALINDICATIONNAME_"+sGXsfl_37_idx;
         edtavSdt_residents__residentimage_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTIMAGE_"+sGXsfl_37_idx;
         edtavSdt_residents__residentlanguage_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTLANGUAGE_"+sGXsfl_37_idx;
         cmbavActiongroup_Internalname = sPrefix+"vACTIONGROUP_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtavSdt_residents__residentid_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTID_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__locationid_Internalname = sPrefix+"SDT_RESIDENTS__LOCATIONID_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__organisationid_Internalname = sPrefix+"SDT_RESIDENTS__ORGANISATIONID_"+sGXsfl_37_fel_idx;
         cmbavSdt_residents__residentsalutation_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTSALUTATION_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residenttitle_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTTITLE_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residentbsnnumber_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTBSNNUMBER_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residentgivenname_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTGIVENNAME_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residentlastname_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTLASTNAME_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residentinitials_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTINITIALS_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residentemail_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTEMAIL_"+sGXsfl_37_fel_idx;
         cmbavSdt_residents__residentgender_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTGENDER_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residentaddress_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTADDRESS_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residentphone_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTPHONE_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residentbirthdate_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTBIRTHDATE_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residentguid_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTGUID_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residenttypeid_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTTYPEID_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residenttypename_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTTYPENAME_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__medicalindicationid_Internalname = sPrefix+"SDT_RESIDENTS__MEDICALINDICATIONID_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__medicalindicationname_Internalname = sPrefix+"SDT_RESIDENTS__MEDICALINDICATIONNAME_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residentimage_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTIMAGE_"+sGXsfl_37_fel_idx;
         edtavSdt_residents__residentlanguage_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTLANGUAGE_"+sGXsfl_37_fel_idx;
         cmbavActiongroup_Internalname = sPrefix+"vACTIONGROUP_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WBBY0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_37_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentid_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentid.ToString(),((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__locationid_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Locationid.ToString(),((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Locationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__locationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__locationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__organisationid_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Organisationid.ToString(),((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Organisationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__organisationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__organisationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbavSdt_residents__residentsalutation.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_RESIDENTS__RESIDENTSALUTATION_" + sGXsfl_37_idx;
               cmbavSdt_residents__residentsalutation.Name = GXCCtl;
               cmbavSdt_residents__residentsalutation.WebTags = "";
               cmbavSdt_residents__residentsalutation.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
               cmbavSdt_residents__residentsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
               cmbavSdt_residents__residentsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
               cmbavSdt_residents__residentsalutation.addItem("Ms", context.GetMessage( "Ms", ""), 0);
               cmbavSdt_residents__residentsalutation.addItem("Other", context.GetMessage( "Other", ""), 0);
               if ( cmbavSdt_residents__residentsalutation.ItemCount > 0 )
               {
                  if ( ( AV34GXV1 > 0 ) && ( AV13SDT_Residents.Count >= AV34GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentsalutation)) )
                  {
                     ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentsalutation = cmbavSdt_residents__residentsalutation.getValidValue(((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentsalutation);
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_residents__residentsalutation,(string)cmbavSdt_residents__residentsalutation_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentsalutation),(short)1,(string)cmbavSdt_residents__residentsalutation_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,cmbavSdt_residents__residentsalutation.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            cmbavSdt_residents__residentsalutation.CurrentValue = StringUtil.RTrim( ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentsalutation);
            AssignProp(sPrefix, false, cmbavSdt_residents__residentsalutation_Internalname, "Values", (string)(cmbavSdt_residents__residentsalutation.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residenttitle_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residenttitle,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residenttitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residenttitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentbsnnumber_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentbsnnumber,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentbsnnumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentbsnnumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdt_residents__residentgivenname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentgivenname_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentgivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentgivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdt_residents__residentgivenname_Visible,(int)edtavSdt_residents__residentgivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdt_residents__residentlastname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentlastname_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentlastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentlastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdt_residents__residentlastname_Visible,(int)edtavSdt_residents__residentlastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentinitials_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentinitials),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentinitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentinitials_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdt_residents__residentemail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentemail_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdt_residents__residentemail_Visible,(int)edtavSdt_residents__residentemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbavSdt_residents__residentgender.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            if ( ( cmbavSdt_residents__residentgender.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_RESIDENTS__RESIDENTGENDER_" + sGXsfl_37_idx;
               cmbavSdt_residents__residentgender.Name = GXCCtl;
               cmbavSdt_residents__residentgender.WebTags = "";
               cmbavSdt_residents__residentgender.addItem("Male", context.GetMessage( "Male", ""), 0);
               cmbavSdt_residents__residentgender.addItem("Female", context.GetMessage( "Female", ""), 0);
               cmbavSdt_residents__residentgender.addItem("Other", context.GetMessage( "Other", ""), 0);
               if ( cmbavSdt_residents__residentgender.ItemCount > 0 )
               {
                  if ( ( AV34GXV1 > 0 ) && ( AV13SDT_Residents.Count >= AV34GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentgender)) )
                  {
                     ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentgender = cmbavSdt_residents__residentgender.getValidValue(((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentgender);
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_residents__residentgender,(string)cmbavSdt_residents__residentgender_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentgender),(short)1,(string)cmbavSdt_residents__residentgender_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",cmbavSdt_residents__residentgender.Visible,cmbavSdt_residents__residentgender.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"",(bool)true,(short)0});
            cmbavSdt_residents__residentgender.CurrentValue = StringUtil.RTrim( ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentgender);
            AssignProp(sPrefix, false, cmbavSdt_residents__residentgender_Internalname, "Values", (string)(cmbavSdt_residents__residentgender.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentaddress_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentaddress,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdt_residents__residentphone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentphone_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdt_residents__residentphone_Visible,(int)edtavSdt_residents__residentphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentbirthdate_Internalname,context.localUtil.Format(((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentbirthdate, "99/99/9999"),context.localUtil.Format( ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentbirthdate, "99/99/9999"),""+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentbirthdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentbirthdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentguid_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentguid,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentguid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentguid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residenttypeid_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residenttypeid.ToString(),((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residenttypeid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residenttypeid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residenttypeid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residenttypename_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residenttypename,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residenttypename_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residenttypename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__medicalindicationid_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Medicalindicationid.ToString(),((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Medicalindicationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__medicalindicationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__medicalindicationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__medicalindicationname_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Medicalindicationname,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__medicalindicationname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__medicalindicationname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentimage_Internalname,((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentimage,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentimage_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentimage_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentlanguage_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentlanguage),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentlanguage_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentlanguage_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_37_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  if ( ( AV34GXV1 > 0 ) && ( AV13SDT_Residents.Count >= AV34GXV1 ) && (0==AV27ActionGroup) )
                  {
                     AV27ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                     AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV27ActionGroup), 4, 0));
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV27ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVACTIONGROUP.CLICK."+sGXsfl_37_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27ActionGroup), 4, 0));
            AssignProp(sPrefix, false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            send_integrity_lvl_hashesBY2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "SDT_RESIDENTS__RESIDENTSALUTATION_" + sGXsfl_37_idx;
         cmbavSdt_residents__residentsalutation.Name = GXCCtl;
         cmbavSdt_residents__residentsalutation.WebTags = "";
         cmbavSdt_residents__residentsalutation.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavSdt_residents__residentsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbavSdt_residents__residentsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbavSdt_residents__residentsalutation.addItem("Ms", context.GetMessage( "Ms", ""), 0);
         cmbavSdt_residents__residentsalutation.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavSdt_residents__residentsalutation.ItemCount > 0 )
         {
            if ( ( AV34GXV1 > 0 ) && ( AV13SDT_Residents.Count >= AV34GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentsalutation)) )
            {
            }
         }
         GXCCtl = "SDT_RESIDENTS__RESIDENTGENDER_" + sGXsfl_37_idx;
         cmbavSdt_residents__residentgender.Name = GXCCtl;
         cmbavSdt_residents__residentgender.WebTags = "";
         cmbavSdt_residents__residentgender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavSdt_residents__residentgender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavSdt_residents__residentgender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavSdt_residents__residentgender.ItemCount > 0 )
         {
            if ( ( AV34GXV1 > 0 ) && ( AV13SDT_Residents.Count >= AV34GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV13SDT_Residents.Item(AV34GXV1)).gxTpr_Residentgender)) )
            {
            }
         }
         GXCCtl = "vACTIONGROUP_" + sGXsfl_37_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            if ( ( AV34GXV1 > 0 ) && ( AV13SDT_Residents.Count >= AV34GXV1 ) && (0==AV27ActionGroup) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdt_residents__residentgivenname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "First Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdt_residents__residentlastname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdt_residents__residentemail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbavSdt_residents__residentgender.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Gender", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdt_residents__residentphone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
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
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_residents__residentsalutation.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residenttitle_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentbsnnumber_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentgivenname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentgivenname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentlastname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentlastname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentinitials_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentemail_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentemail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_residents__residentgender.Visible), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_residents__residentgender.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentaddress_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentphone_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentphone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentbirthdate_Enabled), 5, 0, ".", "")));
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
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentimage_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentlanguage_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27ActionGroup), 4, 0, ".", ""))));
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
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
         bttBtneditcolumns_Internalname = sPrefix+"BTNEDITCOLUMNS";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         edtavSdt_residents__residentid_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTID";
         edtavSdt_residents__locationid_Internalname = sPrefix+"SDT_RESIDENTS__LOCATIONID";
         edtavSdt_residents__organisationid_Internalname = sPrefix+"SDT_RESIDENTS__ORGANISATIONID";
         cmbavSdt_residents__residentsalutation_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTSALUTATION";
         edtavSdt_residents__residenttitle_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTTITLE";
         edtavSdt_residents__residentbsnnumber_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTBSNNUMBER";
         edtavSdt_residents__residentgivenname_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTGIVENNAME";
         edtavSdt_residents__residentlastname_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTLASTNAME";
         edtavSdt_residents__residentinitials_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTINITIALS";
         edtavSdt_residents__residentemail_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTEMAIL";
         cmbavSdt_residents__residentgender_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTGENDER";
         edtavSdt_residents__residentaddress_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTADDRESS";
         edtavSdt_residents__residentphone_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTPHONE";
         edtavSdt_residents__residentbirthdate_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTBIRTHDATE";
         edtavSdt_residents__residentguid_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTGUID";
         edtavSdt_residents__residenttypeid_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTTYPEID";
         edtavSdt_residents__residenttypename_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTTYPENAME";
         edtavSdt_residents__medicalindicationid_Internalname = sPrefix+"SDT_RESIDENTS__MEDICALINDICATIONID";
         edtavSdt_residents__medicalindicationname_Internalname = sPrefix+"SDT_RESIDENTS__MEDICALINDICATIONNAME";
         edtavSdt_residents__residentimage_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTIMAGE";
         edtavSdt_residents__residentlanguage_Internalname = sPrefix+"SDT_RESIDENTS__RESIDENTLANGUAGE";
         cmbavActiongroup_Internalname = sPrefix+"vACTIONGROUP";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Ddo_gridcolumnsselector_Internalname = sPrefix+"DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_removeresident_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_REMOVERESIDENT";
         tblTabledvelop_confirmpanel_removeresident_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_REMOVERESIDENT";
         Insert_modal_Internalname = sPrefix+"INSERT_MODAL";
         tblTableinsert_modal_Internalname = sPrefix+"TABLEINSERT_MODAL";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = sPrefix+"DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         subGrid_Allowcollapsing = 0;
         subGrid_Allowhovering = -1;
         subGrid_Allowselection = 1;
         subGrid_Header = "";
         cmbavActiongroup_Jsonclick = "";
         edtavSdt_residents__residentlanguage_Jsonclick = "";
         edtavSdt_residents__residentlanguage_Enabled = 0;
         edtavSdt_residents__residentimage_Jsonclick = "";
         edtavSdt_residents__residentimage_Enabled = 0;
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
         edtavSdt_residents__residentbirthdate_Jsonclick = "";
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         edtavSdt_residents__residentphone_Jsonclick = "";
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentphone_Visible = -1;
         edtavSdt_residents__residentaddress_Jsonclick = "";
         edtavSdt_residents__residentaddress_Enabled = 0;
         cmbavSdt_residents__residentgender_Jsonclick = "";
         cmbavSdt_residents__residentgender.Enabled = 0;
         cmbavSdt_residents__residentgender.Visible = -1;
         edtavSdt_residents__residentemail_Jsonclick = "";
         edtavSdt_residents__residentemail_Enabled = 0;
         edtavSdt_residents__residentemail_Visible = -1;
         edtavSdt_residents__residentinitials_Jsonclick = "";
         edtavSdt_residents__residentinitials_Enabled = 0;
         edtavSdt_residents__residentlastname_Jsonclick = "";
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentlastname_Visible = -1;
         edtavSdt_residents__residentgivenname_Jsonclick = "";
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentgivenname_Visible = -1;
         edtavSdt_residents__residentbsnnumber_Jsonclick = "";
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         edtavSdt_residents__residenttitle_Jsonclick = "";
         edtavSdt_residents__residenttitle_Enabled = 0;
         cmbavSdt_residents__residentsalutation_Jsonclick = "";
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__organisationid_Jsonclick = "";
         edtavSdt_residents__organisationid_Enabled = 0;
         edtavSdt_residents__locationid_Jsonclick = "";
         edtavSdt_residents__locationid_Enabled = 0;
         edtavSdt_residents__residentid_Jsonclick = "";
         edtavSdt_residents__residentid_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSdt_residents__residentphone_Visible = -1;
         cmbavSdt_residents__residentgender.Visible = -1;
         edtavSdt_residents__residentemail_Visible = -1;
         edtavSdt_residents__residentlastname_Visible = -1;
         edtavSdt_residents__residentgivenname_Visible = -1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Caption = context.GetMessage( "GXM_insert", "");
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Insert_modal_Bodytype = "WebComponent";
         Insert_modal_Confirmtype = "";
         Insert_modal_Title = context.GetMessage( "Select Residents", "");
         Insert_modal_Width = "1000";
         Dvelop_confirmpanel_removeresident_Confirmtype = "1";
         Dvelop_confirmpanel_removeresident_Yesbuttonposition = "left";
         Dvelop_confirmpanel_removeresident_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_removeresident_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_removeresident_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_removeresident_Confirmationtext = "";
         Dvelop_confirmpanel_removeresident_Title = "";
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
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
         edtavSdt_residents__residentlanguage_Enabled = -1;
         edtavSdt_residents__residentimage_Enabled = -1;
         edtavSdt_residents__medicalindicationname_Enabled = -1;
         edtavSdt_residents__medicalindicationid_Enabled = -1;
         edtavSdt_residents__residenttypename_Enabled = -1;
         edtavSdt_residents__residenttypeid_Enabled = -1;
         edtavSdt_residents__residentguid_Enabled = -1;
         edtavSdt_residents__residentbirthdate_Enabled = -1;
         edtavSdt_residents__residentphone_Enabled = -1;
         edtavSdt_residents__residentaddress_Enabled = -1;
         cmbavSdt_residents__residentgender.Enabled = -1;
         edtavSdt_residents__residentemail_Enabled = -1;
         edtavSdt_residents__residentinitials_Enabled = -1;
         edtavSdt_residents__residentlastname_Enabled = -1;
         edtavSdt_residents__residentgivenname_Enabled = -1;
         edtavSdt_residents__residentbsnnumber_Enabled = -1;
         edtavSdt_residents__residenttitle_Enabled = -1;
         cmbavSdt_residents__residentsalutation.Enabled = -1;
         edtavSdt_residents__organisationid_Enabled = -1;
         edtavSdt_residents__locationid_Enabled = -1;
         edtavSdt_residents__residentid_Enabled = -1;
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"sPrefix"},{"av":"AV21ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV16ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV12FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV28ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"AV29ResidentDefinitionTitle","fld":"vRESIDENTDEFINITIONTITLE","hsh":true},{"av":"AV32ResidentTitle","fld":"vRESIDENTTITLE","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV21ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV16ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RESIDENTS__RESIDENTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTEMAIL","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTGENDER","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTPHONE","prop":"Visible"},{"av":"AV24GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV25GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV19ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E13BY2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV21ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV16ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV12FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV28ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"AV29ResidentDefinitionTitle","fld":"vRESIDENTDEFINITIONTITLE","hsh":true},{"av":"AV32ResidentTitle","fld":"vRESIDENTTITLE","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E14BY2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV21ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV16ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV12FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV28ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"AV29ResidentDefinitionTitle","fld":"vRESIDENTDEFINITIONTITLE","hsh":true},{"av":"AV32ResidentTitle","fld":"vRESIDENTTITLE","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E21BY2","iparms":[]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV27ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E15BY2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV21ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV16ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV12FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV28ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"AV29ResidentDefinitionTitle","fld":"vRESIDENTDEFINITIONTITLE","hsh":true},{"av":"AV32ResidentTitle","fld":"vRESIDENTTITLE","hsh":true},{"av":"sPrefix"},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV16ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV21ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"ctrl":"SDT_RESIDENTS__RESIDENTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTEMAIL","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTGENDER","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTPHONE","prop":"Visible"},{"av":"AV24GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV25GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV19ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E12BY2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV21ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV16ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV12FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV28ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"AV29ResidentDefinitionTitle","fld":"vRESIDENTDEFINITIONTITLE","hsh":true},{"av":"AV32ResidentTitle","fld":"vRESIDENTTITLE","hsh":true},{"av":"sPrefix"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV21ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV12FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV16ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RESIDENTS__RESIDENTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTEMAIL","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTGENDER","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTPHONE","prop":"Visible"},{"av":"AV24GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV25GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV19ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E22BY2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV27ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"AV29ResidentDefinitionTitle","fld":"vRESIDENTDEFINITIONTITLE","hsh":true}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV27ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"Dvelop_confirmpanel_removeresident_Confirmationtext","ctrl":"DVELOP_CONFIRMPANEL_REMOVERESIDENT","prop":"ConfirmationText"},{"av":"Dvelop_confirmpanel_removeresident_Title","ctrl":"DVELOP_CONFIRMPANEL_REMOVERESIDENT","prop":"Title"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_REMOVERESIDENT.CLOSE","""{"handler":"E16BY2","iparms":[{"av":"Dvelop_confirmpanel_removeresident_Result","ctrl":"DVELOP_CONFIRMPANEL_REMOVERESIDENT","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV21ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV16ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV12FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV28ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"AV29ResidentDefinitionTitle","fld":"vRESIDENTDEFINITIONTITLE","hsh":true},{"av":"AV32ResidentTitle","fld":"vRESIDENTTITLE","hsh":true},{"av":"sPrefix"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_REMOVERESIDENT.CLOSE",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV21ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV16ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RESIDENTS__RESIDENTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTEMAIL","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTGENDER","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTPHONE","prop":"Visible"},{"av":"AV24GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV25GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV19ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E11BY1","iparms":[]}""");
         setEventMetadata("INSERT_MODAL.ONLOADCOMPONENT","""{"handler":"E18BY2","iparms":[{"av":"AV28ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37}]""");
         setEventMetadata("INSERT_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("INSERT_MODAL.CLOSE","""{"handler":"E17BY2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV21ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV16ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV12FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV28ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"AV29ResidentDefinitionTitle","fld":"vRESIDENTDEFINITIONTITLE","hsh":true},{"av":"AV32ResidentTitle","fld":"vRESIDENTTITLE","hsh":true},{"av":"sPrefix"}]""");
         setEventMetadata("INSERT_MODAL.CLOSE",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV21ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV16ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDT_RESIDENTS__RESIDENTGIVENNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTLASTNAME","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTEMAIL","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTGENDER","prop":"Visible"},{"ctrl":"SDT_RESIDENTS__RESIDENTPHONE","prop":"Visible"},{"av":"AV24GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV25GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV19ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV13SDT_Residents","fld":"vSDT_RESIDENTS","grid":37,"hsh":true},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37}]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
         setEventMetadata("VALIDV_GXV11","""{"handler":"Validv_Gxv11","iparms":[]}""");
         setEventMetadata("VALIDV_GXV12","""{"handler":"Validv_Gxv12","iparms":[]}""");
         setEventMetadata("VALIDV_GXV17","""{"handler":"Validv_Gxv17","iparms":[]}""");
         setEventMetadata("VALIDV_GXV19","""{"handler":"Validv_Gxv19","iparms":[]}""");
         setEventMetadata("VALIDV_GXV21","""{"handler":"Validv_Gxv21","iparms":[]}""");
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
         wcpOAV28ResidentPackageId = Guid.Empty;
         Gridpaginationbar_Selectedpage = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_removeresident_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV16ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV56Pgmname = "";
         AV12FilterFullText = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13SDT_Residents = new GXBaseCollection<SdtSDT_Resident>( context, "SDT_Resident", "Comforta_version2");
         AV29ResidentDefinitionTitle = "";
         AV32ResidentTitle = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV19ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV26GridAppliedFilters = "";
         AV22DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV10GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV33ResidentsDefinitionTitle = "";
         AV18Session = context.GetSession();
         AV14ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV20ManageFiltersXml = "";
         GXt_objcol_SdtSDT_Resident3 = new GXBaseCollection<SdtSDT_Resident>( context, "SDT_Resident", "Comforta_version2");
         AV15UserCustomValue = "";
         GXt_char2 = "";
         AV17ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         ucDvelop_confirmpanel_removeresident = new GXUserControl();
         AV31ActiveLanguageName = "";
         AV11GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         ucInsert_modal = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV28ResidentPackageId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV56Pgmname = "WC_GroupResidents";
         /* GeneXus formulas. */
         AV56Pgmname = "WC_GroupResidents";
         edtavSdt_residents__residentid_Enabled = 0;
         edtavSdt_residents__locationid_Enabled = 0;
         edtavSdt_residents__organisationid_Enabled = 0;
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residenttitle_Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentinitials_Enabled = 0;
         edtavSdt_residents__residentemail_Enabled = 0;
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__residentimage_Enabled = 0;
         edtavSdt_residents__residentlanguage_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV21ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV27ActionGroup ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int edtavSdt_residents__residentid_Enabled ;
      private int edtavSdt_residents__locationid_Enabled ;
      private int edtavSdt_residents__organisationid_Enabled ;
      private int edtavSdt_residents__residenttitle_Enabled ;
      private int edtavSdt_residents__residentbsnnumber_Enabled ;
      private int edtavSdt_residents__residentgivenname_Enabled ;
      private int edtavSdt_residents__residentlastname_Enabled ;
      private int edtavSdt_residents__residentinitials_Enabled ;
      private int edtavSdt_residents__residentemail_Enabled ;
      private int edtavSdt_residents__residentaddress_Enabled ;
      private int edtavSdt_residents__residentphone_Enabled ;
      private int edtavSdt_residents__residentbirthdate_Enabled ;
      private int edtavSdt_residents__residentguid_Enabled ;
      private int edtavSdt_residents__residenttypeid_Enabled ;
      private int edtavSdt_residents__residenttypename_Enabled ;
      private int edtavSdt_residents__medicalindicationid_Enabled ;
      private int edtavSdt_residents__medicalindicationname_Enabled ;
      private int edtavSdt_residents__residentimage_Enabled ;
      private int edtavSdt_residents__residentlanguage_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int AV34GXV1 ;
      private int subGrid_Islastpage ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_37_fel_idx=1 ;
      private int edtavSdt_residents__residentgivenname_Visible ;
      private int edtavSdt_residents__residentlastname_Visible ;
      private int edtavSdt_residents__residentemail_Visible ;
      private int edtavSdt_residents__residentphone_Visible ;
      private int AV23PageToGo ;
      private int nGXsfl_37_bak_idx=1 ;
      private int AV57GXV23 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV24GridCurrentPage ;
      private long AV25GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_removeresident_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_37_idx="0001" ;
      private string AV56Pgmname ;
      private string edtavSdt_residents__residentid_Internalname ;
      private string edtavSdt_residents__locationid_Internalname ;
      private string edtavSdt_residents__organisationid_Internalname ;
      private string cmbavSdt_residents__residentsalutation_Internalname ;
      private string edtavSdt_residents__residenttitle_Internalname ;
      private string edtavSdt_residents__residentbsnnumber_Internalname ;
      private string edtavSdt_residents__residentgivenname_Internalname ;
      private string edtavSdt_residents__residentlastname_Internalname ;
      private string edtavSdt_residents__residentinitials_Internalname ;
      private string edtavSdt_residents__residentemail_Internalname ;
      private string cmbavSdt_residents__residentgender_Internalname ;
      private string edtavSdt_residents__residentaddress_Internalname ;
      private string edtavSdt_residents__residentphone_Internalname ;
      private string edtavSdt_residents__residentbirthdate_Internalname ;
      private string edtavSdt_residents__residentguid_Internalname ;
      private string edtavSdt_residents__residenttypeid_Internalname ;
      private string edtavSdt_residents__residenttypename_Internalname ;
      private string edtavSdt_residents__medicalindicationid_Internalname ;
      private string edtavSdt_residents__medicalindicationname_Internalname ;
      private string edtavSdt_residents__residentimage_Internalname ;
      private string edtavSdt_residents__residentlanguage_Internalname ;
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
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Dvelop_confirmpanel_removeresident_Title ;
      private string Dvelop_confirmpanel_removeresident_Confirmationtext ;
      private string Dvelop_confirmpanel_removeresident_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_removeresident_Nobuttoncaption ;
      private string Dvelop_confirmpanel_removeresident_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_removeresident_Yesbuttonposition ;
      private string Dvelop_confirmpanel_removeresident_Confirmtype ;
      private string Insert_modal_Width ;
      private string Insert_modal_Title ;
      private string Insert_modal_Confirmtype ;
      private string Insert_modal_Bodytype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Caption ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavActiongroup_Internalname ;
      private string GXDecQS ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string GXt_char2 ;
      private string Dvelop_confirmpanel_removeresident_Internalname ;
      private string tblTableinsert_modal_Internalname ;
      private string Insert_modal_Internalname ;
      private string tblTabledvelop_confirmpanel_removeresident_Internalname ;
      private string sCtrlAV28ResidentPackageId ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_residents__residentid_Jsonclick ;
      private string edtavSdt_residents__locationid_Jsonclick ;
      private string edtavSdt_residents__organisationid_Jsonclick ;
      private string GXCCtl ;
      private string cmbavSdt_residents__residentsalutation_Jsonclick ;
      private string edtavSdt_residents__residenttitle_Jsonclick ;
      private string edtavSdt_residents__residentbsnnumber_Jsonclick ;
      private string edtavSdt_residents__residentgivenname_Jsonclick ;
      private string edtavSdt_residents__residentlastname_Jsonclick ;
      private string edtavSdt_residents__residentinitials_Jsonclick ;
      private string edtavSdt_residents__residentemail_Jsonclick ;
      private string cmbavSdt_residents__residentgender_Jsonclick ;
      private string edtavSdt_residents__residentaddress_Jsonclick ;
      private string edtavSdt_residents__residentphone_Jsonclick ;
      private string edtavSdt_residents__residentbirthdate_Jsonclick ;
      private string edtavSdt_residents__residentguid_Jsonclick ;
      private string edtavSdt_residents__residenttypeid_Jsonclick ;
      private string edtavSdt_residents__residenttypename_Jsonclick ;
      private string edtavSdt_residents__medicalindicationid_Jsonclick ;
      private string edtavSdt_residents__medicalindicationname_Jsonclick ;
      private string edtavSdt_residents__residentimage_Jsonclick ;
      private string edtavSdt_residents__residentlanguage_Jsonclick ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool gx_BV37 ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV30isSuccessful ;
      private string AV14ColumnsSelectorXML ;
      private string AV20ManageFiltersXml ;
      private string AV15UserCustomValue ;
      private string AV12FilterFullText ;
      private string AV29ResidentDefinitionTitle ;
      private string AV32ResidentTitle ;
      private string AV26GridAppliedFilters ;
      private string AV33ResidentsDefinitionTitle ;
      private string AV31ActiveLanguageName ;
      private Guid AV28ResidentPackageId ;
      private Guid wcpOAV28ResidentPackageId ;
      private IGxSession AV18Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_removeresident ;
      private GXUserControl ucInsert_modal ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavSdt_residents__residentsalutation ;
      private GXCombobox cmbavSdt_residents__residentgender ;
      private GXCombobox cmbavActiongroup ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV16ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<SdtSDT_Resident> AV13SDT_Residents ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV19ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV22DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV10GridState ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GXBaseCollection<SdtSDT_Resident> GXt_objcol_SdtSDT_Resident3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV17ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
