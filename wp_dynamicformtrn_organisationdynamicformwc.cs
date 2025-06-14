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
   public class wp_dynamicformtrn_organisationdynamicformwc : GXWebComponent
   {
      public wp_dynamicformtrn_organisationdynamicformwc( )
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

      public wp_dynamicformtrn_organisationdynamicformwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormType ,
                           bool aP1_WWPFormIsForDynamicValidations )
      {
         this.AV10WWPFormType = aP0_WWPFormType;
         this.AV78WWPFormIsForDynamicValidations = aP1_WWPFormIsForDynamicValidations;
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
         dynavOrganisationidfilter = new GXCombobox();
         cmbavActiongroup = new GXCombobox();
         cmbWWPFormType = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WWPFormType");
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
                  AV10WWPFormType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormType"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV10WWPFormType", StringUtil.Str( (decimal)(AV10WWPFormType), 1, 0));
                  AV78WWPFormIsForDynamicValidations = StringUtil.StrToBool( GetPar( "WWPFormIsForDynamicValidations"));
                  AssignAttri(sPrefix, false, "AV78WWPFormIsForDynamicValidations", AV78WWPFormIsForDynamicValidations);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV10WWPFormType,(bool)AV78WWPFormIsForDynamicValidations});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vORGANISATIONIDFILTER") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLVvORGANISATIONIDFILTERB42( ) ;
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
                  gxfirstwebparm = GetFirstPar( "WWPFormType");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPFormType");
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
         nRC_GXsfl_43 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
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
         AV52OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV54OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV23FilterFullText = GetPar( "FilterFullText");
         AV10WWPFormType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormType"), "."), 18, MidpointRounding.ToEven));
         dynavOrganisationidfilter.FromJSonString( GetNextPar( ));
         AV55OrganisationIdFilter = StringUtil.StrToGuid( GetPar( "OrganisationIdFilter"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV75WWPContext);
         AV47ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV12ColumnsSelector);
         AV84Pgmname = GetPar( "Pgmname");
         AV67TFWWPFormTitle = GetPar( "TFWWPFormTitle");
         AV68TFWWPFormTitle_Sel = GetPar( "TFWWPFormTitle_Sel");
         AV61TFWWPFormDate = context.localUtil.ParseDTimeParm( GetPar( "TFWWPFormDate"));
         AV62TFWWPFormDate_To = context.localUtil.ParseDTimeParm( GetPar( "TFWWPFormDate_To"));
         AV69TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
         AV70TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormVersionNumber_To"), "."), 18, MidpointRounding.ToEven));
         AV63TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormLatestVersionNumber"), "."), 18, MidpointRounding.ToEven));
         AV64TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormLatestVersionNumber_To"), "."), 18, MidpointRounding.ToEven));
         AV78WWPFormIsForDynamicValidations = StringUtil.StrToBool( GetPar( "WWPFormIsForDynamicValidations"));
         AV42IsAuthorized_UserActionEdit = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionEdit"));
         AV41IsAuthorized_UserActionDisplay = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionDisplay"));
         AV39IsAuthorized_UserActionCopy = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionCopy"));
         AV40IsAuthorized_UserActionDelete = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionDelete"));
         AV43IsAuthorized_UserActionFilledForms = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionFilledForms"));
         AV44IsAuthorized_UserActionFillOutForm = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionFillOutForm"));
         AV36IsAuthorized_UCopyToLocation = StringUtil.StrToBool( GetPar( "IsAuthorized_UCopyToLocation"));
         AV37IsAuthorized_UDirectCopyToLocation = StringUtil.StrToBool( GetPar( "IsAuthorized_UDirectCopyToLocation"));
         AV5LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV52OrderedBy, AV54OrderedDsc, AV23FilterFullText, AV10WWPFormType, AV55OrganisationIdFilter, AV75WWPContext, AV47ManageFiltersExecutionStep, AV12ColumnsSelector, AV84Pgmname, AV67TFWWPFormTitle, AV68TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV69TFWWPFormVersionNumber, AV70TFWWPFormVersionNumber_To, AV63TFWWPFormLatestVersionNumber, AV64TFWWPFormLatestVersionNumber_To, AV78WWPFormIsForDynamicValidations, AV42IsAuthorized_UserActionEdit, AV41IsAuthorized_UserActionDisplay, AV39IsAuthorized_UserActionCopy, AV40IsAuthorized_UserActionDelete, AV43IsAuthorized_UserActionFilledForms, AV44IsAuthorized_UserActionFillOutForm, AV36IsAuthorized_UCopyToLocation, AV37IsAuthorized_UDirectCopyToLocation, AV5LocationId, sPrefix) ;
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
            PAB42( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV84Pgmname = "WP_DynamicFormTrn_OrganisationDynamicFormWC";
               GXVvORGANISATIONIDFILTER_htmlB42( ) ;
               WSB42( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Dynamic Form Trn_Organisation Dynamic Form WC", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
            GXEncryptionTmp = "wp_dynamicformtrn_organisationdynamicformwc.aspx"+UrlEncode(StringUtil.LTrimStr(AV10WWPFormType,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV78WWPFormIsForDynamicValidations));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_dynamicformtrn_organisationdynamicformwc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV75WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV75WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV75WWPContext, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV84Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV84Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONEDIT", AV42IsAuthorized_UserActionEdit);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONEDIT", GetSecureSignedToken( sPrefix, AV42IsAuthorized_UserActionEdit, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONDISPLAY", AV41IsAuthorized_UserActionDisplay);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDISPLAY", GetSecureSignedToken( sPrefix, AV41IsAuthorized_UserActionDisplay, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONCOPY", AV39IsAuthorized_UserActionCopy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONCOPY", GetSecureSignedToken( sPrefix, AV39IsAuthorized_UserActionCopy, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONDELETE", AV40IsAuthorized_UserActionDelete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDELETE", GetSecureSignedToken( sPrefix, AV40IsAuthorized_UserActionDelete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONFILLEDFORMS", AV43IsAuthorized_UserActionFilledForms);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLEDFORMS", GetSecureSignedToken( sPrefix, AV43IsAuthorized_UserActionFilledForms, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONFILLOUTFORM", AV44IsAuthorized_UserActionFillOutForm);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLOUTFORM", GetSecureSignedToken( sPrefix, AV44IsAuthorized_UserActionFillOutForm, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UCOPYTOLOCATION", AV36IsAuthorized_UCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV36IsAuthorized_UCopyToLocation, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UDIRECTCOPYTOLOCATION", AV37IsAuthorized_UDirectCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UDIRECTCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV37IsAuthorized_UDirectCopyToLocation, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLOCATIONID", AV5LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLOCATIONID", GetSecureSignedToken( sPrefix, AV5LocationId, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV54OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV23FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_43), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV46ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV46ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV26GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOLUMNSSELECTOR", AV12ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOLUMNSSELECTOR", AV12ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_WWPFORMDATEAUXDATE", context.localUtil.DToC( AV17DDO_WWPFormDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_WWPFORMDATEAUXDATETO", context.localUtil.DToC( AV19DDO_WWPFormDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV10WWPFormType", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV10WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV78WWPFormIsForDynamicValidations", wcpOAV78WWPFormIsForDynamicValidations);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV75WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV75WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV75WWPContext, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV84Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV84Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV54OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMTITLE", AV67TFWWPFormTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMTITLE_SEL", AV68TFWWPFormTitle_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMDATE", context.localUtil.TToC( AV61TFWWPFormDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMDATE_TO", context.localUtil.TToC( AV62TFWWPFormDate_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69TFWWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMVERSIONNUMBER_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70TFWWPFormVersionNumber_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMLATESTVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63TFWWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMLATESTVERSIONNUMBER_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV64TFWWPFormLatestVersionNumber_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vWWPFORMISFORDYNAMICVALIDATIONS", AV78WWPFormIsForDynamicValidations);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONEDIT", AV42IsAuthorized_UserActionEdit);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONEDIT", GetSecureSignedToken( sPrefix, AV42IsAuthorized_UserActionEdit, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONDISPLAY", AV41IsAuthorized_UserActionDisplay);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDISPLAY", GetSecureSignedToken( sPrefix, AV41IsAuthorized_UserActionDisplay, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONCOPY", AV39IsAuthorized_UserActionCopy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONCOPY", GetSecureSignedToken( sPrefix, AV39IsAuthorized_UserActionCopy, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONDELETE", AV40IsAuthorized_UserActionDelete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDELETE", GetSecureSignedToken( sPrefix, AV40IsAuthorized_UserActionDelete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONFILLEDFORMS", AV43IsAuthorized_UserActionFilledForms);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLEDFORMS", GetSecureSignedToken( sPrefix, AV43IsAuthorized_UserActionFilledForms, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONFILLOUTFORM", AV44IsAuthorized_UserActionFillOutForm);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLOUTFORM", GetSecureSignedToken( sPrefix, AV44IsAuthorized_UserActionFillOutForm, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UCOPYTOLOCATION", AV36IsAuthorized_UCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV36IsAuthorized_UCopyToLocation, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UDIRECTCOPYTOLOCATION", AV37IsAuthorized_UDirectCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UDIRECTCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV37IsAuthorized_UDirectCopyToLocation, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV29GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV29GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESULTMSG", AV58ResultMsg);
         GxWebStd.gx_hidden_field( context, sPrefix+"vORGANISATIONDYNAMICFORMID_SELECTED", AV82OrganisationDynamicFormId_Selected.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vORGANISATIONID_SELECTED", AV83OrganisationId_Selected.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vLOCATIONID", AV5LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLOCATIONID", GetSecureSignedToken( sPrefix, AV5LocationId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORGANISATIONID", AV6OrganisationId.ToString());
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDC_SUBSCRIPTIONS_Caption", StringUtil.RTrim( Ddc_subscriptions_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace", StringUtil.RTrim( Ddc_subscriptions_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Title", StringUtil.RTrim( Dvelop_confirmpanel_useractioncopy_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useractioncopy_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractioncopy_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractioncopy_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractioncopy_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useractioncopy_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useractioncopy_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"UCOPYTOLOCATION_MODAL_Width", StringUtil.RTrim( Ucopytolocation_modal_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"UCOPYTOLOCATION_MODAL_Title", StringUtil.RTrim( Ucopytolocation_modal_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"UCOPYTOLOCATION_MODAL_Confirmtype", StringUtil.RTrim( Ucopytolocation_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"UCOPYTOLOCATION_MODAL_Bodytype", StringUtil.RTrim( Ucopytolocation_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Title", StringUtil.RTrim( Dvelop_confirmpanel_udirectcopytolocation_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_udirectcopytolocation_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udirectcopytolocation_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udirectcopytolocation_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udirectcopytolocation_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_udirectcopytolocation_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_udirectcopytolocation_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractioncopy_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Result", StringUtil.RTrim( Dvelop_confirmpanel_udirectcopytolocation_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractioncopy_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Result", StringUtil.RTrim( Dvelop_confirmpanel_udirectcopytolocation_Result));
      }

      protected void RenderHtmlCloseFormB42( )
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
         return "WP_DynamicFormTrn_OrganisationDynamicFormWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Dynamic Form Trn_Organisation Dynamic Form WC", "") ;
      }

      protected void WBB40( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_dynamicformtrn_organisationdynamicformwc.aspx");
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
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablegridheader_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseractioninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", context.GetMessage( "Insert", ""), bttBtnuseractioninsert_Jsonclick, 5, context.GetMessage( "Insert", ""), "", StyleString, ClassString, bttBtnuseractioninsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUSERACTIONINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_DynamicFormTrn_OrganisationDynamicFormWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_DynamicFormTrn_OrganisationDynamicFormWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_DynamicFormTrn_OrganisationDynamicFormWC.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV46ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV23FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV23FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WP_DynamicFormTrn_OrganisationDynamicFormWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOrganisationidfilter_cell_Internalname, 1, 0, "px", 0, "px", divOrganisationidfilter_cell_Class, "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", dynavOrganisationidfilter.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynavOrganisationidfilter_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavOrganisationidfilter, dynavOrganisationidfilter_Internalname, AV55OrganisationIdFilter.ToString(), 1, dynavOrganisationidfilter_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "guid", "", dynavOrganisationidfilter.Visible, dynavOrganisationidfilter.Enabled, 0, 0, 20, "em", 0, "", "", "AddressAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_WP_DynamicFormTrn_OrganisationDynamicFormWC.htm");
            dynavOrganisationidfilter.CurrentValue = AV55OrganisationIdFilter.ToString();
            AssignProp(sPrefix, false, dynavOrganisationidfilter_Internalname, "Values", (string)(dynavOrganisationidfilter.ToJavascriptSource()), true);
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
            StartGridControl43( ) ;
         }
         if ( wbEnd == 43 )
         {
            wbEnd = 0;
            nRC_GXsfl_43 = (int)(nGXsfl_43_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV27GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV28GridPageCount);
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
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, sPrefix+"DDC_SUBSCRIPTIONSContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbWWPFormType, cmbWWPFormType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0)), 1, cmbWWPFormType_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbWWPFormType.Visible, 0, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_WP_DynamicFormTrn_OrganisationDynamicFormWC.htm");
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AssignProp(sPrefix, false, cmbWWPFormType_Internalname, "Values", (string)(cmbWWPFormType.ToJavascriptSource()), true);
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV12ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, sPrefix+"DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table1_63_B42( true) ;
         }
         else
         {
            wb_table1_63_B42( false) ;
         }
         return  ;
      }

      protected void wb_table1_63_B42e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_68_B42( true) ;
         }
         else
         {
            wb_table2_68_B42( false) ;
         }
         return  ;
      }

      protected void wb_table2_68_B42e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_73_B42( true) ;
         }
         else
         {
            wb_table3_73_B42( false) ;
         }
         return  ;
      }

      protected void wb_table3_73_B42e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table4_78_B42( true) ;
         }
         else
         {
            wb_table4_78_B42( false) ;
         }
         return  ;
      }

      protected void wb_table4_78_B42e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0085"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0085"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_43_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0085"+"");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_wwpformdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_wwpformdateauxdatetext_Internalname, AV18DDO_WWPFormDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV18DDO_WWPFormDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_wwpformdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_DynamicFormTrn_OrganisationDynamicFormWC.htm");
            /* User Defined Control */
            ucTfwwpformdate_rangepicker.SetProperty("Start Date", AV17DDO_WWPFormDateAuxDate);
            ucTfwwpformdate_rangepicker.SetProperty("End Date", AV19DDO_WWPFormDateAuxDateTo);
            ucTfwwpformdate_rangepicker.Render(context, "wwp.daterangepicker", Tfwwpformdate_rangepicker_Internalname, sPrefix+"TFWWPFORMDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 43 )
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

      protected void STARTB42( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Dynamic Form Trn_Organisation Dynamic Form WC", ""), 0) ;
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
               STRUPB40( ) ;
            }
         }
      }

      protected void WSB42( )
      {
         STARTB42( ) ;
         EVTB42( ) ;
      }

      protected void EVTB42( )
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
                                 STRUPB40( ) ;
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
                                 STRUPB40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11B42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12B42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13B42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                                    E14B42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E15B42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                                    E16B42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONCOPY.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_useractioncopy.Close */
                                    E17B42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_useractiondelete.Close */
                                    E18B42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "UCOPYTOLOCATION_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ucopytolocation_modal.Onloadcomponent */
                                    E19B42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_udirectcopytolocation.Close */
                                    E20B42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTIONINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUserActionInsert' */
                                    E21B42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VORGANISATIONIDFILTER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E22B42 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB40( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavActiongroup_Internalname;
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
                                 STRUPB40( ) ;
                              }
                              nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
                              SubsflControlProps_432( ) ;
                              A509OrganisationDynamicFormId = StringUtil.StrToGuid( cgiGet( edtOrganisationDynamicFormId_Internalname));
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                              A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
                              A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
                              A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname), 0);
                              A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A219WWPFormLatestVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormLatestVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                              cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                              AV11ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV11ActionGroup), 4, 0));
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
                                          GX_FocusControl = cmbavActiongroup_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E23B42 ();
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
                                          GX_FocusControl = cmbavActiongroup_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E24B42 ();
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
                                          GX_FocusControl = cmbavActiongroup_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E25B42 ();
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
                                          GX_FocusControl = cmbavActiongroup_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E26B42 ();
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
                                             /* Set Refresh If Orderedby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV52OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV54OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV23FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
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
                                       STRUPB40( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavActiongroup_Internalname;
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
                        if ( nCmpId == 85 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0085");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0085", "", sEvt);
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

      protected void WEB42( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormB42( ) ;
            }
         }
      }

      protected void PAB42( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_dynamicformtrn_organisationdynamicformwc.aspx")), "wp_dynamicformtrn_organisationdynamicformwc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_dynamicformtrn_organisationdynamicformwc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "WWPFormType");
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

      protected void GXDLVvORGANISATIONIDFILTERB42( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvORGANISATIONIDFILTER_dataB42( ) ;
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

      protected void GXVvORGANISATIONIDFILTER_htmlB42( )
      {
         Guid gxdynajaxvalue;
         GXDLVvORGANISATIONIDFILTER_dataB42( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavOrganisationidfilter.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavOrganisationidfilter.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvORGANISATIONIDFILTER_dataB42( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(Guid.Empty.ToString());
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Organisation", ""));
         /* Using cursor H00B42 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H00B42_A11OrganisationId[0].ToString());
            gxdynajaxctrldescr.Add(H00B42_A13OrganisationName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_432( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            sendrow_432( ) ;
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV52OrderedBy ,
                                       bool AV54OrderedDsc ,
                                       string AV23FilterFullText ,
                                       short AV10WWPFormType ,
                                       Guid AV55OrganisationIdFilter ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV75WWPContext ,
                                       short AV47ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV12ColumnsSelector ,
                                       string AV84Pgmname ,
                                       string AV67TFWWPFormTitle ,
                                       string AV68TFWWPFormTitle_Sel ,
                                       DateTime AV61TFWWPFormDate ,
                                       DateTime AV62TFWWPFormDate_To ,
                                       short AV69TFWWPFormVersionNumber ,
                                       short AV70TFWWPFormVersionNumber_To ,
                                       short AV63TFWWPFormLatestVersionNumber ,
                                       short AV64TFWWPFormLatestVersionNumber_To ,
                                       bool AV78WWPFormIsForDynamicValidations ,
                                       bool AV42IsAuthorized_UserActionEdit ,
                                       bool AV41IsAuthorized_UserActionDisplay ,
                                       bool AV39IsAuthorized_UserActionCopy ,
                                       bool AV40IsAuthorized_UserActionDelete ,
                                       bool AV43IsAuthorized_UserActionFilledForms ,
                                       bool AV44IsAuthorized_UserActionFillOutForm ,
                                       bool AV36IsAuthorized_UCopyToLocation ,
                                       bool AV37IsAuthorized_UDirectCopyToLocation ,
                                       Guid AV5LocationId ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFB42( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_WWPFORMID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ORGANISATIONID", GetSecureSignedToken( sPrefix, A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ORGANISATIONDYNAMICFORMID", GetSecureSignedToken( sPrefix, A509OrganisationDynamicFormId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"ORGANISATIONDYNAMICFORMID", A509OrganisationDynamicFormId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_WWPFORMVERSIONNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvORGANISATIONIDFILTER_htmlB42( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavOrganisationidfilter.ItemCount > 0 )
         {
            AV55OrganisationIdFilter = StringUtil.StrToGuid( dynavOrganisationidfilter.getValidValue(AV55OrganisationIdFilter.ToString()));
            AssignAttri(sPrefix, false, "AV55OrganisationIdFilter", AV55OrganisationIdFilter.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavOrganisationidfilter.CurrentValue = AV55OrganisationIdFilter.ToString();
            AssignProp(sPrefix, false, dynavOrganisationidfilter_Internalname, "Values", dynavOrganisationidfilter.ToJavascriptSource(), true);
         }
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AssignProp(sPrefix, false, cmbWWPFormType_Internalname, "Values", cmbWWPFormType.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFB42( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV84Pgmname = "WP_DynamicFormTrn_OrganisationDynamicFormWC";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV68TFWWPFormTitle_Sel ,
                                              AV67TFWWPFormTitle ,
                                              AV61TFWWPFormDate ,
                                              AV62TFWWPFormDate_To ,
                                              AV69TFWWPFormVersionNumber ,
                                              AV70TFWWPFormVersionNumber_To ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              A207WWPFormVersionNumber ,
                                              AV52OrderedBy ,
                                              AV54OrderedDsc ,
                                              A240WWPFormType ,
                                              AV10WWPFormType ,
                                              AV23FilterFullText ,
                                              A219WWPFormLatestVersionNumber ,
                                              AV63TFWWPFormLatestVersionNumber ,
                                              AV64TFWWPFormLatestVersionNumber_To ,
                                              A11OrganisationId ,
                                              AV6OrganisationId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV67TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV67TFWWPFormTitle), "%", "");
         /* Using cursor H00B43 */
         pr_default.execute(1, new Object[] {AV10WWPFormType, AV6OrganisationId, lV67TFWWPFormTitle, AV68TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV69TFWWPFormVersionNumber, AV70TFWWPFormVersionNumber_To});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A240WWPFormType = H00B43_A240WWPFormType[0];
            AssignAttri(sPrefix, false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            A207WWPFormVersionNumber = H00B43_A207WWPFormVersionNumber[0];
            A231WWPFormDate = H00B43_A231WWPFormDate[0];
            A208WWPFormReferenceName = H00B43_A208WWPFormReferenceName[0];
            A209WWPFormTitle = H00B43_A209WWPFormTitle[0];
            A11OrganisationId = H00B43_A11OrganisationId[0];
            A509OrganisationDynamicFormId = H00B43_A509OrganisationDynamicFormId[0];
            A206WWPFormId = H00B43_A206WWPFormId[0];
            A240WWPFormType = H00B43_A240WWPFormType[0];
            AssignAttri(sPrefix, false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            A231WWPFormDate = H00B43_A231WWPFormDate[0];
            A208WWPFormReferenceName = H00B43_A208WWPFormReferenceName[0];
            A209WWPFormTitle = H00B43_A209WWPFormTitle[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23FilterFullText)) || ( ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV23FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV23FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV23FilterFullText , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (0==AV63TFWWPFormLatestVersionNumber) || ( ( A219WWPFormLatestVersionNumber >= AV63TFWWPFormLatestVersionNumber ) ) )
               {
                  if ( (0==AV64TFWWPFormLatestVersionNumber_To) || ( ( A219WWPFormLatestVersionNumber <= AV64TFWWPFormLatestVersionNumber_To ) ) )
                  {
                     GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                  }
               }
            }
            pr_default.readNext(1);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RFB42( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 43;
         /* Execute user event: Refresh */
         E24B42 ();
         nGXsfl_43_idx = 1;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         bGXsfl_43_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
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
            SubsflControlProps_432( ) ;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV68TFWWPFormTitle_Sel ,
                                                 AV67TFWWPFormTitle ,
                                                 AV61TFWWPFormDate ,
                                                 AV62TFWWPFormDate_To ,
                                                 AV69TFWWPFormVersionNumber ,
                                                 AV70TFWWPFormVersionNumber_To ,
                                                 A209WWPFormTitle ,
                                                 A231WWPFormDate ,
                                                 A207WWPFormVersionNumber ,
                                                 AV52OrderedBy ,
                                                 AV54OrderedDsc ,
                                                 A240WWPFormType ,
                                                 AV10WWPFormType ,
                                                 AV23FilterFullText ,
                                                 A219WWPFormLatestVersionNumber ,
                                                 AV63TFWWPFormLatestVersionNumber ,
                                                 AV64TFWWPFormLatestVersionNumber_To ,
                                                 A11OrganisationId ,
                                                 AV6OrganisationId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV67TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV67TFWWPFormTitle), "%", "");
            /* Using cursor H00B44 */
            pr_default.execute(2, new Object[] {AV10WWPFormType, AV6OrganisationId, lV67TFWWPFormTitle, AV68TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV69TFWWPFormVersionNumber, AV70TFWWPFormVersionNumber_To});
            nGXsfl_43_idx = 1;
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(2) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A240WWPFormType = H00B44_A240WWPFormType[0];
               AssignAttri(sPrefix, false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
               A207WWPFormVersionNumber = H00B44_A207WWPFormVersionNumber[0];
               A231WWPFormDate = H00B44_A231WWPFormDate[0];
               A208WWPFormReferenceName = H00B44_A208WWPFormReferenceName[0];
               A209WWPFormTitle = H00B44_A209WWPFormTitle[0];
               A11OrganisationId = H00B44_A11OrganisationId[0];
               A509OrganisationDynamicFormId = H00B44_A509OrganisationDynamicFormId[0];
               A206WWPFormId = H00B44_A206WWPFormId[0];
               A240WWPFormType = H00B44_A240WWPFormType[0];
               AssignAttri(sPrefix, false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
               A231WWPFormDate = H00B44_A231WWPFormDate[0];
               A208WWPFormReferenceName = H00B44_A208WWPFormReferenceName[0];
               A209WWPFormTitle = H00B44_A209WWPFormTitle[0];
               GXt_int1 = A219WWPFormLatestVersionNumber;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
               A219WWPFormLatestVersionNumber = GXt_int1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23FilterFullText)) || ( ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV23FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV23FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV23FilterFullText , 254 , "%"),  ' ' ) ) ) )
               {
                  if ( (0==AV63TFWWPFormLatestVersionNumber) || ( ( A219WWPFormLatestVersionNumber >= AV63TFWWPFormLatestVersionNumber ) ) )
                  {
                     if ( (0==AV64TFWWPFormLatestVersionNumber_To) || ( ( A219WWPFormLatestVersionNumber <= AV64TFWWPFormLatestVersionNumber_To ) ) )
                     {
                        /* Execute user event: Grid.Load */
                        E25B42 ();
                     }
                  }
               }
               pr_default.readNext(2);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(2) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(2);
            wbEnd = 43;
            WBB40( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesB42( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV75WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV75WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV75WWPContext, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV84Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV84Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONEDIT", AV42IsAuthorized_UserActionEdit);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONEDIT", GetSecureSignedToken( sPrefix, AV42IsAuthorized_UserActionEdit, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONDISPLAY", AV41IsAuthorized_UserActionDisplay);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDISPLAY", GetSecureSignedToken( sPrefix, AV41IsAuthorized_UserActionDisplay, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONCOPY", AV39IsAuthorized_UserActionCopy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONCOPY", GetSecureSignedToken( sPrefix, AV39IsAuthorized_UserActionCopy, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONDELETE", AV40IsAuthorized_UserActionDelete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDELETE", GetSecureSignedToken( sPrefix, AV40IsAuthorized_UserActionDelete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONFILLEDFORMS", AV43IsAuthorized_UserActionFilledForms);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLEDFORMS", GetSecureSignedToken( sPrefix, AV43IsAuthorized_UserActionFilledForms, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONFILLOUTFORM", AV44IsAuthorized_UserActionFillOutForm);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLOUTFORM", GetSecureSignedToken( sPrefix, AV44IsAuthorized_UserActionFillOutForm, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UCOPYTOLOCATION", AV36IsAuthorized_UCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV36IsAuthorized_UCopyToLocation, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UDIRECTCOPYTOLOCATION", AV37IsAuthorized_UDirectCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UDIRECTCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV37IsAuthorized_UDirectCopyToLocation, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_WWPFORMID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sPrefix+sGXsfl_43_idx, context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ORGANISATIONID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sPrefix+sGXsfl_43_idx, A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ORGANISATIONDYNAMICFORMID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sPrefix+sGXsfl_43_idx, A509OrganisationDynamicFormId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_WWPFORMVERSIONNUMBER"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sPrefix+sGXsfl_43_idx, context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLOCATIONID", AV5LocationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLOCATIONID", GetSecureSignedToken( sPrefix, AV5LocationId, context));
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
         return (int)(subGridclient_rec_count_fnc()) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV52OrderedBy, AV54OrderedDsc, AV23FilterFullText, AV10WWPFormType, AV55OrganisationIdFilter, AV75WWPContext, AV47ManageFiltersExecutionStep, AV12ColumnsSelector, AV84Pgmname, AV67TFWWPFormTitle, AV68TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV69TFWWPFormVersionNumber, AV70TFWWPFormVersionNumber_To, AV63TFWWPFormLatestVersionNumber, AV64TFWWPFormLatestVersionNumber_To, AV78WWPFormIsForDynamicValidations, AV42IsAuthorized_UserActionEdit, AV41IsAuthorized_UserActionDisplay, AV39IsAuthorized_UserActionCopy, AV40IsAuthorized_UserActionDelete, AV43IsAuthorized_UserActionFilledForms, AV44IsAuthorized_UserActionFillOutForm, AV36IsAuthorized_UCopyToLocation, AV37IsAuthorized_UDirectCopyToLocation, AV5LocationId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV52OrderedBy, AV54OrderedDsc, AV23FilterFullText, AV10WWPFormType, AV55OrganisationIdFilter, AV75WWPContext, AV47ManageFiltersExecutionStep, AV12ColumnsSelector, AV84Pgmname, AV67TFWWPFormTitle, AV68TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV69TFWWPFormVersionNumber, AV70TFWWPFormVersionNumber_To, AV63TFWWPFormLatestVersionNumber, AV64TFWWPFormLatestVersionNumber_To, AV78WWPFormIsForDynamicValidations, AV42IsAuthorized_UserActionEdit, AV41IsAuthorized_UserActionDisplay, AV39IsAuthorized_UserActionCopy, AV40IsAuthorized_UserActionDelete, AV43IsAuthorized_UserActionFilledForms, AV44IsAuthorized_UserActionFillOutForm, AV36IsAuthorized_UCopyToLocation, AV37IsAuthorized_UDirectCopyToLocation, AV5LocationId, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV52OrderedBy, AV54OrderedDsc, AV23FilterFullText, AV10WWPFormType, AV55OrganisationIdFilter, AV75WWPContext, AV47ManageFiltersExecutionStep, AV12ColumnsSelector, AV84Pgmname, AV67TFWWPFormTitle, AV68TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV69TFWWPFormVersionNumber, AV70TFWWPFormVersionNumber_To, AV63TFWWPFormLatestVersionNumber, AV64TFWWPFormLatestVersionNumber_To, AV78WWPFormIsForDynamicValidations, AV42IsAuthorized_UserActionEdit, AV41IsAuthorized_UserActionDisplay, AV39IsAuthorized_UserActionCopy, AV40IsAuthorized_UserActionDelete, AV43IsAuthorized_UserActionFilledForms, AV44IsAuthorized_UserActionFillOutForm, AV36IsAuthorized_UCopyToLocation, AV37IsAuthorized_UDirectCopyToLocation, AV5LocationId, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV52OrderedBy, AV54OrderedDsc, AV23FilterFullText, AV10WWPFormType, AV55OrganisationIdFilter, AV75WWPContext, AV47ManageFiltersExecutionStep, AV12ColumnsSelector, AV84Pgmname, AV67TFWWPFormTitle, AV68TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV69TFWWPFormVersionNumber, AV70TFWWPFormVersionNumber_To, AV63TFWWPFormLatestVersionNumber, AV64TFWWPFormLatestVersionNumber_To, AV78WWPFormIsForDynamicValidations, AV42IsAuthorized_UserActionEdit, AV41IsAuthorized_UserActionDisplay, AV39IsAuthorized_UserActionCopy, AV40IsAuthorized_UserActionDelete, AV43IsAuthorized_UserActionFilledForms, AV44IsAuthorized_UserActionFillOutForm, AV36IsAuthorized_UCopyToLocation, AV37IsAuthorized_UDirectCopyToLocation, AV5LocationId, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV52OrderedBy, AV54OrderedDsc, AV23FilterFullText, AV10WWPFormType, AV55OrganisationIdFilter, AV75WWPContext, AV47ManageFiltersExecutionStep, AV12ColumnsSelector, AV84Pgmname, AV67TFWWPFormTitle, AV68TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV69TFWWPFormVersionNumber, AV70TFWWPFormVersionNumber_To, AV63TFWWPFormLatestVersionNumber, AV64TFWWPFormLatestVersionNumber_To, AV78WWPFormIsForDynamicValidations, AV42IsAuthorized_UserActionEdit, AV41IsAuthorized_UserActionDisplay, AV39IsAuthorized_UserActionCopy, AV40IsAuthorized_UserActionDelete, AV43IsAuthorized_UserActionFilledForms, AV44IsAuthorized_UserActionFillOutForm, AV36IsAuthorized_UCopyToLocation, AV37IsAuthorized_UDirectCopyToLocation, AV5LocationId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV84Pgmname = "WP_DynamicFormTrn_OrganisationDynamicFormWC";
         GXVvORGANISATIONIDFILTER_htmlB42( ) ;
         edtOrganisationDynamicFormId_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtWWPFormId_Enabled = 0;
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormDate_Enabled = 0;
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormLatestVersionNumber_Enabled = 0;
         cmbWWPFormType.Enabled = 0;
         AssignProp(sPrefix, false, cmbWWPFormType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormType.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPB40( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E23B42 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV46ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCOLUMNSSELECTOR"), AV12ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_43"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV27GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV28GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV26GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV17DDO_WWPFormDateAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_WWPFORMDATEAUXDATE"), 0);
            AV19DDO_WWPFormDateAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_WWPFORMDATEAUXDATETO"), 0);
            wcpOAV10WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV10WWPFormType"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV78WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV78WWPFormIsForDynamicValidations"));
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
            Ddc_subscriptions_Icontype = cgiGet( sPrefix+"DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( sPrefix+"DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Caption = cgiGet( sPrefix+"DDC_SUBSCRIPTIONS_Caption");
            Ddc_subscriptions_Tooltip = cgiGet( sPrefix+"DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( sPrefix+"DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Titlecontrolidtoreplace = cgiGet( sPrefix+"DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( sPrefix+"DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( sPrefix+"DDO_GRID_Format");
            Ddo_gridcolumnsselector_Icontype = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Dvelop_confirmpanel_useractioncopy_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Title");
            Dvelop_confirmpanel_useractioncopy_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Confirmationtext");
            Dvelop_confirmpanel_useractioncopy_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Yesbuttoncaption");
            Dvelop_confirmpanel_useractioncopy_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Nobuttoncaption");
            Dvelop_confirmpanel_useractioncopy_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Cancelbuttoncaption");
            Dvelop_confirmpanel_useractioncopy_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Yesbuttonposition");
            Dvelop_confirmpanel_useractioncopy_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Confirmtype");
            Dvelop_confirmpanel_useractiondelete_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Title");
            Dvelop_confirmpanel_useractiondelete_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmationtext");
            Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_useractiondelete_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Nobuttoncaption");
            Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_useractiondelete_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttonposition");
            Dvelop_confirmpanel_useractiondelete_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmtype");
            Ucopytolocation_modal_Width = cgiGet( sPrefix+"UCOPYTOLOCATION_MODAL_Width");
            Ucopytolocation_modal_Title = cgiGet( sPrefix+"UCOPYTOLOCATION_MODAL_Title");
            Ucopytolocation_modal_Confirmtype = cgiGet( sPrefix+"UCOPYTOLOCATION_MODAL_Confirmtype");
            Ucopytolocation_modal_Bodytype = cgiGet( sPrefix+"UCOPYTOLOCATION_MODAL_Bodytype");
            Dvelop_confirmpanel_udirectcopytolocation_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Title");
            Dvelop_confirmpanel_udirectcopytolocation_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Confirmationtext");
            Dvelop_confirmpanel_udirectcopytolocation_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Yesbuttoncaption");
            Dvelop_confirmpanel_udirectcopytolocation_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Nobuttoncaption");
            Dvelop_confirmpanel_udirectcopytolocation_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Cancelbuttoncaption");
            Dvelop_confirmpanel_udirectcopytolocation_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Yesbuttonposition");
            Dvelop_confirmpanel_udirectcopytolocation_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_useractioncopy_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY_Result");
            Dvelop_confirmpanel_useractiondelete_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result");
            Dvelop_confirmpanel_udirectcopytolocation_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION_Result");
            /* Read variables values. */
            AV23FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV23FilterFullText", AV23FilterFullText);
            dynavOrganisationidfilter.Name = dynavOrganisationidfilter_Internalname;
            dynavOrganisationidfilter.CurrentValue = cgiGet( dynavOrganisationidfilter_Internalname);
            AV55OrganisationIdFilter = StringUtil.StrToGuid( cgiGet( dynavOrganisationidfilter_Internalname));
            AssignAttri(sPrefix, false, "AV55OrganisationIdFilter", AV55OrganisationIdFilter.ToString());
            cmbWWPFormType.Name = cmbWWPFormType_Internalname;
            cmbWWPFormType.CurrentValue = cgiGet( cmbWWPFormType_Internalname);
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormType_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AV18DDO_WWPFormDateAuxDateText = cgiGet( edtavDdo_wwpformdateauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV18DDO_WWPFormDateAuxDateText", AV18DDO_WWPFormDateAuxDateText);
            /* Read subfile selected row values. */
            nGXsfl_43_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
            if ( nGXsfl_43_idx > 0 )
            {
               A509OrganisationDynamicFormId = StringUtil.StrToGuid( cgiGet( edtOrganisationDynamicFormId_Internalname));
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
               A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
               A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
               A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname));
               A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A219WWPFormLatestVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormLatestVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               cmbavActiongroup.Name = cmbavActiongroup_Internalname;
               cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
               AV11ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV11ActionGroup), 4, 0));
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV52OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV54OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV23FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
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
         E23B42 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E23B42( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV75WWPContext) ;
         if ( ! (Guid.Empty==AV75WWPContext.gxTpr_Organisationid) )
         {
            AV55OrganisationIdFilter = AV75WWPContext.gxTpr_Organisationid;
            AssignAttri(sPrefix, false, "AV55OrganisationIdFilter", AV55OrganisationIdFilter.ToString());
            AV6OrganisationId = AV75WWPContext.gxTpr_Organisationid;
            AssignAttri(sPrefix, false, "AV6OrganisationId", AV6OrganisationId.ToString());
         }
         this.executeUsercontrolMethod(sPrefix, false, "TFWWPFORMDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_wwpformdateauxdatetext_Internalname});
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, sPrefix, false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, sPrefix, false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         AV25GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV24GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV25GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         cmbWWPFormType.Visible = 0;
         AssignProp(sPrefix, false, cmbWWPFormType_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbWWPFormType.Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV52OrderedBy < 1 )
         {
            AV52OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV52OrderedBy", StringUtil.LTrimStr( (decimal)(AV52OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, sPrefix, false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E24B42( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         if ( (Guid.Empty==AV55OrganisationIdFilter) )
         {
            AV6OrganisationId = AV75WWPContext.gxTpr_Organisationid;
            AssignAttri(sPrefix, false, "AV6OrganisationId", AV6OrganisationId.ToString());
         }
         else
         {
            AV6OrganisationId = AV55OrganisationIdFilter;
            AssignAttri(sPrefix, false, "AV6OrganisationId", AV6OrganisationId.ToString());
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV75WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV47ManageFiltersExecutionStep == 1 )
         {
            AV47ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV47ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV47ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV47ManageFiltersExecutionStep == 2 )
         {
            AV47ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV47ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV47ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV60Session.Get("WP_DynamicFormTrn_OrganisationDynamicFormWCColumnsSelector"), "") != 0 )
         {
            AV14ColumnsSelectorXML = AV60Session.Get("WP_DynamicFormTrn_OrganisationDynamicFormWCColumnsSelector");
            AV12ColumnsSelector.FromXml(AV14ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtWWPFormTitle_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV12ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtWWPFormTitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtWWPFormDate_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV12ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtWWPFormDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormDate_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtWWPFormVersionNumber_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV12ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtWWPFormLatestVersionNumber_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV12ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtWWPFormLatestVersionNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormLatestVersionNumber_Visible), 5, 0), !bGXsfl_43_Refreshing);
         AV27GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV27GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV27GridCurrentPage), 10, 0));
         AV28GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV28GridPageCount", StringUtil.LTrimStr( (decimal)(AV28GridPageCount), 10, 0));
         GXt_char3 = AV26GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV84Pgmname, out  GXt_char3) ;
         AV26GridAppliedFilters = GXt_char3;
         AssignAttri(sPrefix, false, "AV26GridAppliedFilters", AV26GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV75WWPContext", AV75WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12ColumnsSelector", AV12ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46ManageFiltersData", AV46ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29GridState", AV29GridState);
      }

      protected void E12B42( )
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
            AV57PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV57PageToGo) ;
         }
      }

      protected void E13B42( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15B42( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV52OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV52OrderedBy", StringUtil.LTrimStr( (decimal)(AV52OrderedBy), 4, 0));
            AV54OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV54OrderedDsc", AV54OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormTitle") == 0 )
            {
               AV67TFWWPFormTitle = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV67TFWWPFormTitle", AV67TFWWPFormTitle);
               AV68TFWWPFormTitle_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV68TFWWPFormTitle_Sel", AV68TFWWPFormTitle_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormDate") == 0 )
            {
               AV61TFWWPFormDate = context.localUtil.CToT( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV61TFWWPFormDate", context.localUtil.TToC( AV61TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV62TFWWPFormDate_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV62TFWWPFormDate_To", context.localUtil.TToC( AV62TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( ! (DateTime.MinValue==AV62TFWWPFormDate_To) )
               {
                  AV62TFWWPFormDate_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV62TFWWPFormDate_To)), (short)(DateTimeUtil.Month( AV62TFWWPFormDate_To)), (short)(DateTimeUtil.Day( AV62TFWWPFormDate_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV62TFWWPFormDate_To", context.localUtil.TToC( AV62TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormVersionNumber") == 0 )
            {
               AV69TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV69TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV69TFWWPFormVersionNumber), 4, 0));
               AV70TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV70TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV70TFWWPFormVersionNumber_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormLatestVersionNumber") == 0 )
            {
               AV63TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV63TFWWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(AV63TFWWPFormLatestVersionNumber), 4, 0));
               AV64TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV64TFWWPFormLatestVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV64TFWWPFormLatestVersionNumber_To), 4, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E25B42( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavActiongroup.removeAllItems();
            cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
            if ( AV42IsAuthorized_UserActionEdit )
            {
               cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fas fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV41IsAuthorized_UserActionDisplay )
            {
               cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Display", ""), "fas fa-magnifying-glass", "", "", "", "", "", "", ""), 0);
            }
            if ( AV39IsAuthorized_UserActionCopy )
            {
               cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "Copy", ""), "fa-clone far", "", "", "", "", "", "", ""), 0);
            }
            if ( AV40IsAuthorized_UserActionDelete )
            {
               cmbavActiongroup.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "Delete", ""), "fas fa-xmark", "", "", "", "", "", "", ""), 0);
            }
            if ( AV43IsAuthorized_UserActionFilledForms )
            {
               cmbavActiongroup.addItem("5", StringUtil.Format( "%1;%2", context.GetMessage( "Filled forms", ""), "far fa-eye", "", "", "", "", "", "", ""), 0);
            }
            if ( AV44IsAuthorized_UserActionFillOutForm )
            {
               cmbavActiongroup.addItem("6", StringUtil.Format( "%1;%2", context.GetMessage( "fill out form", ""), "fas fa-file-circle-plus", "", "", "", "", "", "", ""), 0);
            }
            if ( AV36IsAuthorized_UCopyToLocation )
            {
               cmbavActiongroup.addItem("7", StringUtil.Format( "%1;%2", context.GetMessage( "Copy To Location", ""), "fa-copy far", "", "", "", "", "", "", ""), 0);
            }
            if ( AV37IsAuthorized_UDirectCopyToLocation )
            {
               cmbavActiongroup.addItem("8", StringUtil.Format( "%1;%2", context.GetMessage( "Copy To Location", ""), "fa-copy far", "", "", "", "", "", "", ""), 0);
            }
            if ( cmbavActiongroup.ItemCount == 1 )
            {
               cmbavActiongroup_Class = "Invisible";
            }
            else
            {
               cmbavActiongroup_Class = "ConvertToDDO";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 43;
            }
            sendrow_432( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_43_Refreshing )
         {
            DoAjaxLoad(43, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11ActionGroup), 4, 0));
      }

      protected void E16B42( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV14ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV12ColumnsSelector.FromJSonString(AV14ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WP_DynamicFormTrn_OrganisationDynamicFormWCColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV14ColumnsSelectorXML)) ? "" : AV12ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12ColumnsSelector", AV12ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV75WWPContext", AV75WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46ManageFiltersData", AV46ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29GridState", AV29GridState);
      }

      protected void E11B42( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WP_DynamicFormTrn_OrganisationDynamicFormWCFilters")) + "," + UrlEncode(StringUtil.RTrim(AV84Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV47ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV47ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV47ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WP_DynamicFormTrn_OrganisationDynamicFormWCFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV47ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV47ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV47ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char3 = AV48ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WP_DynamicFormTrn_OrganisationDynamicFormWCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV48ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV84Pgmname+"GridState",  AV48ManageFiltersXml) ;
               AV29GridState.FromXml(AV48ManageFiltersXml, null, "", "");
               AV52OrderedBy = AV29GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV52OrderedBy", StringUtil.LTrimStr( (decimal)(AV52OrderedBy), 4, 0));
               AV54OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV54OrderedDsc", AV54OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S152 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S202 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29GridState", AV29GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV75WWPContext", AV75WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12ColumnsSelector", AV12ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46ManageFiltersData", AV46ManageFiltersData);
      }

      protected void E26B42( )
      {
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV11ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO USERACTIONEDIT' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV11ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO USERACTIONDISPLAY' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV11ActionGroup == 3 )
         {
            /* Execute user subroutine: 'DO USERACTIONCOPY' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV11ActionGroup == 4 )
         {
            /* Execute user subroutine: 'DO USERACTIONDELETE' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV11ActionGroup == 5 )
         {
            /* Execute user subroutine: 'DO USERACTIONFILLEDFORMS' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV11ActionGroup == 6 )
         {
            /* Execute user subroutine: 'DO USERACTIONFILLOUTFORM' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV11ActionGroup == 7 )
         {
            /* Execute user subroutine: 'DO UCOPYTOLOCATION' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV11ActionGroup == 8 )
         {
            /* Execute user subroutine: 'DO UDIRECTCOPYTOLOCATION' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV11ActionGroup = 0;
         AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV11ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11ActionGroup), 4, 0));
         AssignProp(sPrefix, false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV75WWPContext", AV75WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12ColumnsSelector", AV12ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46ManageFiltersData", AV46ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29GridState", AV29GridState);
      }

      protected void E17B42( )
      {
         /* Dvelop_confirmpanel_useractioncopy_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractioncopy_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONCOPY' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV75WWPContext", AV75WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12ColumnsSelector", AV12ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46ManageFiltersData", AV46ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29GridState", AV29GridState);
      }

      protected void E18B42( )
      {
         /* Dvelop_confirmpanel_useractiondelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractiondelete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONDELETE' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV75WWPContext", AV75WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12ColumnsSelector", AV12ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46ManageFiltersData", AV46ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29GridState", AV29GridState);
      }

      protected void E19B42( )
      {
         /* Ucopytolocation_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WC_CopyGeneralDynamicFormToLocation")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wc_copygeneraldynamicformtolocation", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WC_CopyGeneralDynamicFormToLocation";
            WebComp_Wwpaux_wc_Component = "WC_CopyGeneralDynamicFormToLocation";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0085",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0085"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E20B42( )
      {
         /* Dvelop_confirmpanel_udirectcopytolocation_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_udirectcopytolocation_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION UDIRECTCOPYTOLOCATION' */
            S312 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV75WWPContext", AV75WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12ColumnsSelector", AV12ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46ManageFiltersData", AV46ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29GridState", AV29GridState);
      }

      protected void E21B42( )
      {
         /* 'DoUserActionInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(AV10WWPFormType,1,0)) + "," + UrlEncode(StringUtil.RTrim(context.GetMessage( "Organisation", ""))) + "," + UrlEncode(AV75WWPContext.gxTpr_Organisationid.ToString());
         CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14B42( )
      {
         /* Ddc_subscriptions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0085",(string)"",(string)"WWP_Form",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0085"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderedBy), 4, 0))+":"+(AV54OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S182( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV12ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV12ColumnsSelector,  "WWPFormTitle",  "",  "Title",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV12ColumnsSelector,  "WWPFormDate",  "",  "Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV12ColumnsSelector,  "WWPFormVersionNumber",  "",  "Form Version #",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV12ColumnsSelector,  "WWPFormLatestVersionNumber",  "",  "Latest Version",  true,  "") ;
         GXt_char3 = AV74UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WP_DynamicFormTrn_OrganisationDynamicFormWCColumnsSelector", out  GXt_char3) ;
         AV74UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV74UserCustomValue)) ) )
         {
            AV13ColumnsSelectorAux.FromXml(AV74UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV13ColumnsSelectorAux, ref  AV12ColumnsSelector) ;
         }
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean4 = AV42IsAuthorized_UserActionEdit;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_organisationdynamicform_edit", out  GXt_boolean4) ;
         AV42IsAuthorized_UserActionEdit = GXt_boolean4;
         AssignAttri(sPrefix, false, "AV42IsAuthorized_UserActionEdit", AV42IsAuthorized_UserActionEdit);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONEDIT", GetSecureSignedToken( sPrefix, AV42IsAuthorized_UserActionEdit, context));
         GXt_boolean4 = AV41IsAuthorized_UserActionDisplay;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_createdynamicform_Execute", out  GXt_boolean4) ;
         AV41IsAuthorized_UserActionDisplay = GXt_boolean4;
         AssignAttri(sPrefix, false, "AV41IsAuthorized_UserActionDisplay", AV41IsAuthorized_UserActionDisplay);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDISPLAY", GetSecureSignedToken( sPrefix, AV41IsAuthorized_UserActionDisplay, context));
         GXt_boolean4 = AV39IsAuthorized_UserActionCopy;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_organisationdynamicform_copy", out  GXt_boolean4) ;
         AV39IsAuthorized_UserActionCopy = GXt_boolean4;
         AssignAttri(sPrefix, false, "AV39IsAuthorized_UserActionCopy", AV39IsAuthorized_UserActionCopy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONCOPY", GetSecureSignedToken( sPrefix, AV39IsAuthorized_UserActionCopy, context));
         GXt_boolean4 = AV40IsAuthorized_UserActionDelete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_organisationdynamicform_delete", out  GXt_boolean4) ;
         AV40IsAuthorized_UserActionDelete = GXt_boolean4;
         AssignAttri(sPrefix, false, "AV40IsAuthorized_UserActionDelete", AV40IsAuthorized_UserActionDelete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDELETE", GetSecureSignedToken( sPrefix, AV40IsAuthorized_UserActionDelete, context));
         GXt_boolean4 = AV43IsAuthorized_UserActionFilledForms;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_organisationdynamicform_filledforms", out  GXt_boolean4) ;
         AV43IsAuthorized_UserActionFilledForms = GXt_boolean4;
         AssignAttri(sPrefix, false, "AV43IsAuthorized_UserActionFilledForms", AV43IsAuthorized_UserActionFilledForms);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLEDFORMS", GetSecureSignedToken( sPrefix, AV43IsAuthorized_UserActionFilledForms, context));
         GXt_boolean4 = AV44IsAuthorized_UserActionFillOutForm;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_organisationdynamicform_filloutform", out  GXt_boolean4) ;
         AV44IsAuthorized_UserActionFillOutForm = GXt_boolean4;
         AssignAttri(sPrefix, false, "AV44IsAuthorized_UserActionFillOutForm", AV44IsAuthorized_UserActionFillOutForm);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLOUTFORM", GetSecureSignedToken( sPrefix, AV44IsAuthorized_UserActionFillOutForm, context));
         GXt_boolean4 = AV36IsAuthorized_UCopyToLocation;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_organisationdynamicform_copytolocation", out  GXt_boolean4) ;
         AV36IsAuthorized_UCopyToLocation = GXt_boolean4;
         AssignAttri(sPrefix, false, "AV36IsAuthorized_UCopyToLocation", AV36IsAuthorized_UCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV36IsAuthorized_UCopyToLocation, context));
         GXt_boolean4 = AV37IsAuthorized_UDirectCopyToLocation;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_organisationdynamicform_directcopytolocation", out  GXt_boolean4) ;
         AV37IsAuthorized_UDirectCopyToLocation = GXt_boolean4;
         AssignAttri(sPrefix, false, "AV37IsAuthorized_UDirectCopyToLocation", AV37IsAuthorized_UDirectCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UDIRECTCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV37IsAuthorized_UDirectCopyToLocation, context));
         GXt_boolean4 = AV45IsAuthorized_UserActionInsert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_organisationdynamicform_insert", out  GXt_boolean4) ;
         AV45IsAuthorized_UserActionInsert = GXt_boolean4;
         if ( ! ( AV45IsAuthorized_UserActionInsert ) )
         {
            bttBtnuseractioninsert_Visible = 0;
            AssignProp(sPrefix, false, bttBtnuseractioninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuseractioninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "WWP_Form",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp(sPrefix, false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = AV46ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WP_DynamicFormTrn_OrganisationDynamicFormWCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5) ;
         AV46ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5;
      }

      protected void S192( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV23FilterFullText = "";
         AssignAttri(sPrefix, false, "AV23FilterFullText", AV23FilterFullText);
         AV67TFWWPFormTitle = "";
         AssignAttri(sPrefix, false, "AV67TFWWPFormTitle", AV67TFWWPFormTitle);
         AV68TFWWPFormTitle_Sel = "";
         AssignAttri(sPrefix, false, "AV68TFWWPFormTitle_Sel", AV68TFWWPFormTitle_Sel);
         AV61TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV61TFWWPFormDate", context.localUtil.TToC( AV61TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV62TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV62TFWWPFormDate_To", context.localUtil.TToC( AV62TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV69TFWWPFormVersionNumber = 0;
         AssignAttri(sPrefix, false, "AV69TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV69TFWWPFormVersionNumber), 4, 0));
         AV70TFWWPFormVersionNumber_To = 0;
         AssignAttri(sPrefix, false, "AV70TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV70TFWWPFormVersionNumber_To), 4, 0));
         AV63TFWWPFormLatestVersionNumber = 0;
         AssignAttri(sPrefix, false, "AV63TFWWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(AV63TFWWPFormLatestVersionNumber), 4, 0));
         AV64TFWWPFormLatestVersionNumber_To = 0;
         AssignAttri(sPrefix, false, "AV64TFWWPFormLatestVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV64TFWWPFormLatestVersionNumber_To), 4, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S212( )
      {
         /* 'DO USERACTIONEDIT' Routine */
         returnInSub = false;
         if ( AV42IsAuthorized_UserActionEdit )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(A240WWPFormType,1,0)) + "," + UrlEncode(StringUtil.RTrim(context.GetMessage( "Organisation", ""))) + "," + UrlEncode(A11OrganisationId.ToString());
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S222( )
      {
         /* 'DO USERACTIONDISPLAY' Routine */
         returnInSub = false;
         if ( AV41IsAuthorized_UserActionDisplay )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(A240WWPFormType,1,0));
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S232( )
      {
         /* 'DO USERACTIONCOPY' Routine */
         returnInSub = false;
         if ( AV39IsAuthorized_UserActionCopy )
         {
            AV82OrganisationDynamicFormId_Selected = A509OrganisationDynamicFormId;
            AssignAttri(sPrefix, false, "AV82OrganisationDynamicFormId_Selected", AV82OrganisationDynamicFormId_Selected.ToString());
            AV83OrganisationId_Selected = A11OrganisationId;
            AssignAttri(sPrefix, false, "AV83OrganisationId_Selected", AV83OrganisationId_Selected.ToString());
            this.executeUsercontrolMethod(sPrefix, false, "DVELOP_CONFIRMPANEL_USERACTIONCOPYContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S292( )
      {
         /* 'DO ACTION USERACTIONCOPY' Routine */
         returnInSub = false;
         AV76WWPForm.Load(A206WWPFormId, A207WWPFormVersionNumber);
         AV15CopyNumber = 1;
         AV9WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A208WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV15CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         while ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  0,  AV9WWPFormReferenceName) )
         {
            AV15CopyNumber = (short)(AV15CopyNumber+1);
            AV9WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A208WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV15CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         }
         AV51NewWWPForm = new SdtUForm(context);
         /* Using cursor H00B45 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A206WWPFormId = H00B45_A206WWPFormId[0];
            AV51NewWWPForm.gxTpr_Wwpformid = A206WWPFormId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV51NewWWPForm.gxTpr_Wwpformid = (short)(AV51NewWWPForm.gxTpr_Wwpformid+1);
         AV51NewWWPForm.gxTpr_Wwpformversionnumber = 1;
         AV51NewWWPForm.gxTpr_Wwpformreferencename = AV9WWPFormReferenceName;
         AV51NewWWPForm.gxTpr_Wwpformtitle = AV76WWPForm.gxTpr_Wwpformtitle;
         AV51NewWWPForm.gxTpr_Wwpformiswizard = AV76WWPForm.gxTpr_Wwpformiswizard;
         AV51NewWWPForm.gxTpr_Wwpformdate = DateTimeUtil.Now( context);
         AV51NewWWPForm.gxTpr_Wwpformvalidations = AV76WWPForm.gxTpr_Wwpformvalidations;
         AV51NewWWPForm.gxTpr_Wwpformresume = AV76WWPForm.gxTpr_Wwpformresume;
         AV51NewWWPForm.gxTpr_Wwpformresumemessage = AV76WWPForm.gxTpr_Wwpformresumemessage;
         AV86GXV1 = 1;
         while ( AV86GXV1 <= AV76WWPForm.gxTpr_Element.Count )
         {
            AV22Element = ((SdtUForm_Element)AV76WWPForm.gxTpr_Element.Item(AV86GXV1));
            if ( AV22Element.gxTpr_Wwpformelementparentid >= 0 )
            {
               AV51NewWWPForm.gxTpr_Element.Add(AV22Element, 0);
            }
            AV86GXV1 = (int)(AV86GXV1+1);
         }
         if ( AV51NewWWPForm.Insert() )
         {
            context.CommitDataStores("wp_dynamicformtrn_organisationdynamicformwc",pr_default);
            if ( ! (Guid.Empty==AV75WWPContext.gxTpr_Organisationid) )
            {
               AV8Trn_OrganisationDynamicForm = new SdtTrn_OrganisationDynamicForm(context);
               AV8Trn_OrganisationDynamicForm.gxTpr_Organisationdynamicformid = Guid.NewGuid( );
               AV8Trn_OrganisationDynamicForm.gxTpr_Organisationid = AV75WWPContext.gxTpr_Organisationid;
               AV8Trn_OrganisationDynamicForm.gxTpr_Wwpformid = AV51NewWWPForm.gxTpr_Wwpformid;
               AV8Trn_OrganisationDynamicForm.gxTpr_Wwpformversionnumber = AV51NewWWPForm.gxTpr_Wwpformversionnumber;
               if ( AV8Trn_OrganisationDynamicForm.Insert() )
               {
                  context.CommitDataStores("wp_dynamicformtrn_organisationdynamicformwc",pr_default);
               }
               else
               {
                  AV88GXV3 = 1;
                  AV87GXV2 = AV8Trn_OrganisationDynamicForm.GetMessages();
                  while ( AV88GXV3 <= AV87GXV2.Count )
                  {
                     AV49Message = ((GeneXus.Utils.SdtMessages_Message)AV87GXV2.Item(AV88GXV3));
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ResultMsg)) )
                     {
                        AV58ResultMsg += StringUtil.NewLine( );
                        AssignAttri(sPrefix, false, "AV58ResultMsg", AV58ResultMsg);
                     }
                     AV58ResultMsg += AV49Message.gxTpr_Description;
                     AssignAttri(sPrefix, false, "AV58ResultMsg", AV58ResultMsg);
                     AV88GXV3 = (int)(AV88GXV3+1);
                  }
                  context.RollbackDataStores("wp_dynamicformtrn_organisationdynamicformwc",pr_default);
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_ErrorCloning", ""),  AV58ResultMsg,  "error",  "",  "na",  ""));
               }
            }
            else
            {
               context.RollbackDataStores("wp_dynamicformtrn_organisationdynamicformwc",pr_default);
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_ErrorCloning", ""),  context.GetMessage( "Location not found", ""),  "success",  "",  "na",  ""));
            }
         }
         else
         {
            AV90GXV5 = 1;
            AV89GXV4 = AV51NewWWPForm.GetMessages();
            while ( AV90GXV5 <= AV89GXV4.Count )
            {
               AV49Message = ((GeneXus.Utils.SdtMessages_Message)AV89GXV4.Item(AV90GXV5));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ResultMsg)) )
               {
                  AV58ResultMsg += StringUtil.NewLine( );
                  AssignAttri(sPrefix, false, "AV58ResultMsg", AV58ResultMsg);
               }
               AV58ResultMsg += AV49Message.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV58ResultMsg", AV58ResultMsg);
               AV90GXV5 = (int)(AV90GXV5+1);
            }
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_ErrorCloning", ""),  AV58ResultMsg,  "error",  "",  "false",  ""));
         }
         gxgrGrid_refresh( subGrid_Rows, AV52OrderedBy, AV54OrderedDsc, AV23FilterFullText, AV10WWPFormType, AV55OrganisationIdFilter, AV75WWPContext, AV47ManageFiltersExecutionStep, AV12ColumnsSelector, AV84Pgmname, AV67TFWWPFormTitle, AV68TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV69TFWWPFormVersionNumber, AV70TFWWPFormVersionNumber_To, AV63TFWWPFormLatestVersionNumber, AV64TFWWPFormLatestVersionNumber_To, AV78WWPFormIsForDynamicValidations, AV42IsAuthorized_UserActionEdit, AV41IsAuthorized_UserActionDisplay, AV39IsAuthorized_UserActionCopy, AV40IsAuthorized_UserActionDelete, AV43IsAuthorized_UserActionFilledForms, AV44IsAuthorized_UserActionFillOutForm, AV36IsAuthorized_UCopyToLocation, AV37IsAuthorized_UDirectCopyToLocation, AV5LocationId, sPrefix) ;
      }

      protected void S242( )
      {
         /* 'DO USERACTIONDELETE' Routine */
         returnInSub = false;
         if ( AV40IsAuthorized_UserActionDelete )
         {
            AV82OrganisationDynamicFormId_Selected = A509OrganisationDynamicFormId;
            AssignAttri(sPrefix, false, "AV82OrganisationDynamicFormId_Selected", AV82OrganisationDynamicFormId_Selected.ToString());
            AV83OrganisationId_Selected = A11OrganisationId;
            AssignAttri(sPrefix, false, "AV83OrganisationId_Selected", AV83OrganisationId_Selected.ToString());
            this.executeUsercontrolMethod(sPrefix, false, "DVELOP_CONFIRMPANEL_USERACTIONDELETEContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S302( )
      {
         /* 'DO ACTION USERACTIONDELETE' Routine */
         returnInSub = false;
         new prc_deleteorganisationform(context ).execute(  AV82OrganisationDynamicFormId_Selected,  AV83OrganisationId_Selected, out  AV50Messages) ;
         if ( AV50Messages.Count > 0 )
         {
            AV91GXV6 = 1;
            while ( AV91GXV6 <= AV50Messages.Count )
            {
               AV49Message = ((GeneXus.Utils.SdtMessages_Message)AV50Messages.Item(AV91GXV6));
               GX_msglist.addItem(AV49Message.gxTpr_Description);
               AV91GXV6 = (int)(AV91GXV6+1);
            }
         }
         else
         {
            gxgrGrid_refresh( subGrid_Rows, AV52OrderedBy, AV54OrderedDsc, AV23FilterFullText, AV10WWPFormType, AV55OrganisationIdFilter, AV75WWPContext, AV47ManageFiltersExecutionStep, AV12ColumnsSelector, AV84Pgmname, AV67TFWWPFormTitle, AV68TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV69TFWWPFormVersionNumber, AV70TFWWPFormVersionNumber_To, AV63TFWWPFormLatestVersionNumber, AV64TFWWPFormLatestVersionNumber_To, AV78WWPFormIsForDynamicValidations, AV42IsAuthorized_UserActionEdit, AV41IsAuthorized_UserActionDisplay, AV39IsAuthorized_UserActionCopy, AV40IsAuthorized_UserActionDelete, AV43IsAuthorized_UserActionFilledForms, AV44IsAuthorized_UserActionFillOutForm, AV36IsAuthorized_UCopyToLocation, AV37IsAuthorized_UDirectCopyToLocation, AV5LocationId, sPrefix) ;
         }
      }

      protected void S252( )
      {
         /* 'DO USERACTIONFILLEDFORMS' Routine */
         returnInSub = false;
         if ( AV43IsAuthorized_UserActionFilledForms )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "ufilledoutforms.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim(A209WWPFormTitle));
            CallWebObject(formatLink("ufilledoutforms.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S262( )
      {
         /* 'DO USERACTIONFILLOUTFORM' Routine */
         returnInSub = false;
         if ( AV44IsAuthorized_UserActionFillOutForm )
         {
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_dynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(A208WWPFormReferenceName)),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim("INS"))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","isLinkingDiscussion"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S272( )
      {
         /* 'DO UCOPYTOLOCATION' Routine */
         returnInSub = false;
         if ( AV36IsAuthorized_UCopyToLocation )
         {
            this.executeUsercontrolMethod(sPrefix, false, "UCOPYTOLOCATION_MODALContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S282( )
      {
         /* 'DO UDIRECTCOPYTOLOCATION' Routine */
         returnInSub = false;
         if ( AV37IsAuthorized_UDirectCopyToLocation )
         {
            AV82OrganisationDynamicFormId_Selected = A509OrganisationDynamicFormId;
            AssignAttri(sPrefix, false, "AV82OrganisationDynamicFormId_Selected", AV82OrganisationDynamicFormId_Selected.ToString());
            AV83OrganisationId_Selected = A11OrganisationId;
            AssignAttri(sPrefix, false, "AV83OrganisationId_Selected", AV83OrganisationId_Selected.ToString());
            this.executeUsercontrolMethod(sPrefix, false, "DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATIONContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S312( )
      {
         /* 'DO ACTION UDIRECTCOPYTOLOCATION' Routine */
         returnInSub = false;
         AV76WWPForm.Load(A206WWPFormId, A207WWPFormVersionNumber);
         AV15CopyNumber = 1;
         AV9WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A208WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV15CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         while ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  0,  AV9WWPFormReferenceName) )
         {
            AV15CopyNumber = (short)(AV15CopyNumber+1);
            AV9WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A208WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV15CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         }
         AV51NewWWPForm = new SdtUForm(context);
         /* Using cursor H00B46 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A206WWPFormId = H00B46_A206WWPFormId[0];
            AV51NewWWPForm.gxTpr_Wwpformid = A206WWPFormId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(4);
         }
         pr_default.close(4);
         AV51NewWWPForm.gxTpr_Wwpformid = (short)(AV51NewWWPForm.gxTpr_Wwpformid+1);
         AV51NewWWPForm.gxTpr_Wwpformversionnumber = 1;
         AV51NewWWPForm.gxTpr_Wwpformreferencename = AV9WWPFormReferenceName;
         AV51NewWWPForm.gxTpr_Wwpformtitle = AV76WWPForm.gxTpr_Wwpformtitle;
         AV51NewWWPForm.gxTpr_Wwpformiswizard = AV76WWPForm.gxTpr_Wwpformiswizard;
         AV51NewWWPForm.gxTpr_Wwpformdate = DateTimeUtil.Now( context);
         AV51NewWWPForm.gxTpr_Wwpformvalidations = AV76WWPForm.gxTpr_Wwpformvalidations;
         AV51NewWWPForm.gxTpr_Wwpformresume = AV76WWPForm.gxTpr_Wwpformresume;
         AV51NewWWPForm.gxTpr_Wwpformresumemessage = AV76WWPForm.gxTpr_Wwpformresumemessage;
         AV93GXV7 = 1;
         while ( AV93GXV7 <= AV76WWPForm.gxTpr_Element.Count )
         {
            AV22Element = ((SdtUForm_Element)AV76WWPForm.gxTpr_Element.Item(AV93GXV7));
            if ( AV22Element.gxTpr_Wwpformelementparentid >= 0 )
            {
               AV51NewWWPForm.gxTpr_Element.Add(AV22Element, 0);
            }
            AV93GXV7 = (int)(AV93GXV7+1);
         }
         if ( AV51NewWWPForm.Insert() )
         {
            context.CommitDataStores("wp_dynamicformtrn_organisationdynamicformwc",pr_default);
            if ( ! (Guid.Empty==AV5LocationId) )
            {
               AV7Trn_LocationDynamicForm = new SdtTrn_LocationDynamicForm(context);
               AV7Trn_LocationDynamicForm.gxTpr_Locationdynamicformid = Guid.NewGuid( );
               AV7Trn_LocationDynamicForm.gxTpr_Locationid = AV5LocationId;
               AV7Trn_LocationDynamicForm.gxTpr_Organisationid = AV6OrganisationId;
               AV7Trn_LocationDynamicForm.gxTpr_Wwpformid = AV51NewWWPForm.gxTpr_Wwpformid;
               AV7Trn_LocationDynamicForm.gxTpr_Wwpformversionnumber = AV51NewWWPForm.gxTpr_Wwpformversionnumber;
               if ( AV7Trn_LocationDynamicForm.Insert() )
               {
                  context.CommitDataStores("wp_dynamicformtrn_organisationdynamicformwc",pr_default);
               }
               else
               {
                  AV95GXV9 = 1;
                  AV94GXV8 = AV7Trn_LocationDynamicForm.GetMessages();
                  while ( AV95GXV9 <= AV94GXV8.Count )
                  {
                     AV49Message = ((GeneXus.Utils.SdtMessages_Message)AV94GXV8.Item(AV95GXV9));
                     GX_msglist.addItem(AV49Message.gxTpr_Description);
                     AV95GXV9 = (int)(AV95GXV9+1);
                  }
               }
            }
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_Copy_SuccessTitle", ""),  context.GetMessage( "WWP_DF_Copy_Success", ""),  "success",  "",  "na",  ""));
            gxgrGrid_refresh( subGrid_Rows, AV52OrderedBy, AV54OrderedDsc, AV23FilterFullText, AV10WWPFormType, AV55OrganisationIdFilter, AV75WWPContext, AV47ManageFiltersExecutionStep, AV12ColumnsSelector, AV84Pgmname, AV67TFWWPFormTitle, AV68TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV69TFWWPFormVersionNumber, AV70TFWWPFormVersionNumber_To, AV63TFWWPFormLatestVersionNumber, AV64TFWWPFormLatestVersionNumber_To, AV78WWPFormIsForDynamicValidations, AV42IsAuthorized_UserActionEdit, AV41IsAuthorized_UserActionDisplay, AV39IsAuthorized_UserActionCopy, AV40IsAuthorized_UserActionDelete, AV43IsAuthorized_UserActionFilledForms, AV44IsAuthorized_UserActionFillOutForm, AV36IsAuthorized_UCopyToLocation, AV37IsAuthorized_UDirectCopyToLocation, AV5LocationId, sPrefix) ;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_dynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(false)) + "," + UrlEncode(StringUtil.RTrim(context.GetMessage( "LocationDynamicForm", "")));
            CallWebObject(formatLink("wp_dynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV97GXV11 = 1;
            AV96GXV10 = AV51NewWWPForm.GetMessages();
            while ( AV97GXV11 <= AV96GXV10.Count )
            {
               AV49Message = ((GeneXus.Utils.SdtMessages_Message)AV96GXV10.Item(AV97GXV11));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ResultMsg)) )
               {
                  AV58ResultMsg += StringUtil.NewLine( );
                  AssignAttri(sPrefix, false, "AV58ResultMsg", AV58ResultMsg);
               }
               AV58ResultMsg += AV49Message.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV58ResultMsg", AV58ResultMsg);
               AV97GXV11 = (int)(AV97GXV11+1);
            }
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_ErrorCloning", ""),  AV58ResultMsg,  "error",  "",  "false",  ""));
         }
      }

      protected void S142( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV60Session.Get(AV84Pgmname+"GridState"), "") == 0 )
         {
            AV29GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV84Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV60Session.Get(AV84Pgmname+"GridState"), null, "", "");
         }
         AV52OrderedBy = AV29GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV52OrderedBy", StringUtil.LTrimStr( (decimal)(AV52OrderedBy), 4, 0));
         AV54OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV54OrderedDsc", AV54OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV29GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV29GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
      }

      protected void S202( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV98GXV12 = 1;
         while ( AV98GXV12 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV98GXV12));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV23FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23FilterFullText", AV23FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV67TFWWPFormTitle = AV30GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV67TFWWPFormTitle", AV67TFWWPFormTitle);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV68TFWWPFormTitle_Sel = AV30GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV68TFWWPFormTitle_Sel", AV68TFWWPFormTitle_Sel);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFWWPFORMDATE") == 0 )
            {
               AV61TFWWPFormDate = context.localUtil.CToT( AV30GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV61TFWWPFormDate", context.localUtil.TToC( AV61TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV62TFWWPFormDate_To = context.localUtil.CToT( AV30GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV62TFWWPFormDate_To", context.localUtil.TToC( AV62TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV17DDO_WWPFormDateAuxDate = DateTimeUtil.ResetTime(AV61TFWWPFormDate);
               AssignAttri(sPrefix, false, "AV17DDO_WWPFormDateAuxDate", context.localUtil.Format(AV17DDO_WWPFormDateAuxDate, "99/99/99"));
               AV19DDO_WWPFormDateAuxDateTo = DateTimeUtil.ResetTime(AV62TFWWPFormDate_To);
               AssignAttri(sPrefix, false, "AV19DDO_WWPFormDateAuxDateTo", context.localUtil.Format(AV19DDO_WWPFormDateAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFWWPFORMVERSIONNUMBER") == 0 )
            {
               AV69TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV69TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV69TFWWPFormVersionNumber), 4, 0));
               AV70TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV70TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV70TFWWPFormVersionNumber_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFWWPFORMLATESTVERSIONNUMBER") == 0 )
            {
               AV63TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV63TFWWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(AV63TFWWPFormLatestVersionNumber), 4, 0));
               AV64TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV64TFWWPFormLatestVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV64TFWWPFormLatestVersionNumber_To), 4, 0));
            }
            AV98GXV12 = (int)(AV98GXV12+1);
         }
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFWWPFormTitle_Sel)),  AV68TFWWPFormTitle_Sel, out  GXt_char3) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFWWPFormTitle)),  AV67TFWWPFormTitle, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char3+"|"+((DateTime.MinValue==AV61TFWWPFormDate) ? "" : context.localUtil.DToC( AV17DDO_WWPFormDateAuxDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((0==AV69TFWWPFormVersionNumber) ? "" : StringUtil.Str( (decimal)(AV69TFWWPFormVersionNumber), 4, 0))+"|"+((0==AV63TFWWPFormLatestVersionNumber) ? "" : StringUtil.Str( (decimal)(AV63TFWWPFormLatestVersionNumber), 4, 0));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((DateTime.MinValue==AV62TFWWPFormDate_To) ? "" : context.localUtil.DToC( AV19DDO_WWPFormDateAuxDateTo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((0==AV70TFWWPFormVersionNumber_To) ? "" : StringUtil.Str( (decimal)(AV70TFWWPFormVersionNumber_To), 4, 0))+"|"+((0==AV64TFWWPFormLatestVersionNumber_To) ? "" : StringUtil.Str( (decimal)(AV64TFWWPFormLatestVersionNumber_To), 4, 0));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV29GridState.FromXml(AV60Session.Get(AV84Pgmname+"GridState"), null, "", "");
         AV29GridState.gxTpr_Orderedby = AV52OrderedBy;
         AV29GridState.gxTpr_Ordereddsc = AV54OrderedDsc;
         AV29GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV29GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV23FilterFullText)),  0,  AV23FilterFullText,  AV23FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV29GridState,  "TFWWPFORMTITLE",  context.GetMessage( "Title", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFWWPFormTitle)),  0,  AV67TFWWPFormTitle,  AV67TFWWPFormTitle,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFWWPFormTitle_Sel)),  AV68TFWWPFormTitle_Sel,  AV68TFWWPFormTitle_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV29GridState,  "TFWWPFORMDATE",  context.GetMessage( "Date", ""),  !((DateTime.MinValue==AV61TFWWPFormDate)&&(DateTime.MinValue==AV62TFWWPFormDate_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV61TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  ((DateTime.MinValue==AV61TFWWPFormDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV61TFWWPFormDate, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV62TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  ((DateTime.MinValue==AV62TFWWPFormDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV62TFWWPFormDate_To, "99/99/99 99:99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV29GridState,  "TFWWPFORMVERSIONNUMBER",  context.GetMessage( "Form Version #", ""),  !((0==AV69TFWWPFormVersionNumber)&&(0==AV70TFWWPFormVersionNumber_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV69TFWWPFormVersionNumber), 4, 0)),  ((0==AV69TFWWPFormVersionNumber) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV69TFWWPFormVersionNumber), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV70TFWWPFormVersionNumber_To), 4, 0)),  ((0==AV70TFWWPFormVersionNumber_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV70TFWWPFormVersionNumber_To), "ZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV29GridState,  "TFWWPFORMLATESTVERSIONNUMBER",  context.GetMessage( "Latest Version", ""),  !((0==AV63TFWWPFormLatestVersionNumber)&&(0==AV64TFWWPFormLatestVersionNumber_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV63TFWWPFormLatestVersionNumber), 4, 0)),  ((0==AV63TFWWPFormLatestVersionNumber) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV63TFWWPFormLatestVersionNumber), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV64TFWWPFormLatestVersionNumber_To), 4, 0)),  ((0==AV64TFWWPFormLatestVersionNumber_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV64TFWWPFormLatestVersionNumber_To), "ZZZ9")))) ;
         if ( ! (0==AV10WWPFormType) )
         {
            AV30GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV30GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMTYPE";
            AV30GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV10WWPFormType), 1, 0);
            AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         }
         if ( ! (false==AV78WWPFormIsForDynamicValidations) )
         {
            AV30GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV30GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMISFORDYNAMICVALIDATIONS";
            AV30GridStateFilterValue.gxTpr_Value = StringUtil.BoolToStr( AV78WWPFormIsForDynamicValidations);
            AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         }
         AV29GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV84Pgmname+"GridState",  AV29GridState.ToXml(false, true, "", "")) ;
      }

      protected void S132( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV71TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV71TrnContext.gxTpr_Callerobject = AV84Pgmname;
         AV71TrnContext.gxTpr_Callerondelete = true;
         AV71TrnContext.gxTpr_Callerurl = AV31HTTPRequest.ScriptName+"?"+AV31HTTPRequest.QueryString;
         AV71TrnContext.gxTpr_Transactionname = "Trn_OrganisationDynamicForm";
         AV72TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV72TrnContextAtt.gxTpr_Attributename = "WWPFormType";
         AV72TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV10WWPFormType), 1, 0);
         AV71TrnContext.gxTpr_Attributes.Add(AV72TrnContextAtt, 0);
         AV60Session.Set("TrnContext", AV71TrnContext.ToXml(false, true, "", ""));
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( (Guid.Empty==AV75WWPContext.gxTpr_Organisationid) ) )
         {
            dynavOrganisationidfilter.Visible = 0;
            AssignProp(sPrefix, false, dynavOrganisationidfilter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavOrganisationidfilter.Visible), 5, 0), true);
            divOrganisationidfilter_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divOrganisationidfilter_cell_Internalname, "Class", divOrganisationidfilter_cell_Class, true);
         }
         else
         {
            dynavOrganisationidfilter.Visible = 1;
            AssignProp(sPrefix, false, dynavOrganisationidfilter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavOrganisationidfilter.Visible), 5, 0), true);
            divOrganisationidfilter_cell_Class = "";
            AssignProp(sPrefix, false, divOrganisationidfilter_cell_Internalname, "Class", divOrganisationidfilter_cell_Class, true);
         }
      }

      protected void E22B42( )
      {
         /* Organisationidfilter_Controlvaluechanged Routine */
         returnInSub = false;
         AV6OrganisationId = AV55OrganisationIdFilter;
         AssignAttri(sPrefix, false, "AV6OrganisationId", AV6OrganisationId.ToString());
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV75WWPContext", AV75WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12ColumnsSelector", AV12ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46ManageFiltersData", AV46ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29GridState", AV29GridState);
      }

      protected void wb_table4_78_B42( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_udirectcopytolocation_Internalname, tblTabledvelop_confirmpanel_udirectcopytolocation_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_udirectcopytolocation.SetProperty("Title", Dvelop_confirmpanel_udirectcopytolocation_Title);
            ucDvelop_confirmpanel_udirectcopytolocation.SetProperty("ConfirmationText", Dvelop_confirmpanel_udirectcopytolocation_Confirmationtext);
            ucDvelop_confirmpanel_udirectcopytolocation.SetProperty("YesButtonCaption", Dvelop_confirmpanel_udirectcopytolocation_Yesbuttoncaption);
            ucDvelop_confirmpanel_udirectcopytolocation.SetProperty("NoButtonCaption", Dvelop_confirmpanel_udirectcopytolocation_Nobuttoncaption);
            ucDvelop_confirmpanel_udirectcopytolocation.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_udirectcopytolocation_Cancelbuttoncaption);
            ucDvelop_confirmpanel_udirectcopytolocation.SetProperty("YesButtonPosition", Dvelop_confirmpanel_udirectcopytolocation_Yesbuttonposition);
            ucDvelop_confirmpanel_udirectcopytolocation.SetProperty("ConfirmType", Dvelop_confirmpanel_udirectcopytolocation_Confirmtype);
            ucDvelop_confirmpanel_udirectcopytolocation.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_udirectcopytolocation_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATIONContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATIONContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_78_B42e( true) ;
         }
         else
         {
            wb_table4_78_B42e( false) ;
         }
      }

      protected void wb_table3_73_B42( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableucopytolocation_modal_Internalname, tblTableucopytolocation_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucUcopytolocation_modal.SetProperty("Width", Ucopytolocation_modal_Width);
            ucUcopytolocation_modal.SetProperty("Title", Ucopytolocation_modal_Title);
            ucUcopytolocation_modal.SetProperty("ConfirmType", Ucopytolocation_modal_Confirmtype);
            ucUcopytolocation_modal.SetProperty("BodyType", Ucopytolocation_modal_Bodytype);
            ucUcopytolocation_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Ucopytolocation_modal_Internalname, sPrefix+"UCOPYTOLOCATION_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"UCOPYTOLOCATION_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_73_B42e( true) ;
         }
         else
         {
            wb_table3_73_B42e( false) ;
         }
      }

      protected void wb_table2_68_B42( bool wbgen )
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
            wb_table2_68_B42e( true) ;
         }
         else
         {
            wb_table2_68_B42e( false) ;
         }
      }

      protected void wb_table1_63_B42( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_useractioncopy_Internalname, tblTabledvelop_confirmpanel_useractioncopy_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_useractioncopy.SetProperty("Title", Dvelop_confirmpanel_useractioncopy_Title);
            ucDvelop_confirmpanel_useractioncopy.SetProperty("ConfirmationText", Dvelop_confirmpanel_useractioncopy_Confirmationtext);
            ucDvelop_confirmpanel_useractioncopy.SetProperty("YesButtonCaption", Dvelop_confirmpanel_useractioncopy_Yesbuttoncaption);
            ucDvelop_confirmpanel_useractioncopy.SetProperty("NoButtonCaption", Dvelop_confirmpanel_useractioncopy_Nobuttoncaption);
            ucDvelop_confirmpanel_useractioncopy.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_useractioncopy_Cancelbuttoncaption);
            ucDvelop_confirmpanel_useractioncopy.SetProperty("YesButtonPosition", Dvelop_confirmpanel_useractioncopy_Yesbuttonposition);
            ucDvelop_confirmpanel_useractioncopy.SetProperty("ConfirmType", Dvelop_confirmpanel_useractioncopy_Confirmtype);
            ucDvelop_confirmpanel_useractioncopy.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_useractioncopy_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPYContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPYContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_63_B42e( true) ;
         }
         else
         {
            wb_table1_63_B42e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10WWPFormType = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV10WWPFormType", StringUtil.Str( (decimal)(AV10WWPFormType), 1, 0));
         AV78WWPFormIsForDynamicValidations = (bool)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV78WWPFormIsForDynamicValidations", AV78WWPFormIsForDynamicValidations);
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
         PAB42( ) ;
         WSB42( ) ;
         WEB42( ) ;
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
         sCtrlAV10WWPFormType = (string)((string)getParm(obj,0));
         sCtrlAV78WWPFormIsForDynamicValidations = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAB42( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_dynamicformtrn_organisationdynamicformwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAB42( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV10WWPFormType = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV10WWPFormType", StringUtil.Str( (decimal)(AV10WWPFormType), 1, 0));
            AV78WWPFormIsForDynamicValidations = (bool)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV78WWPFormIsForDynamicValidations", AV78WWPFormIsForDynamicValidations);
         }
         wcpOAV10WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV10WWPFormType"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV78WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV78WWPFormIsForDynamicValidations"));
         if ( ! GetJustCreated( ) && ( ( AV10WWPFormType != wcpOAV10WWPFormType ) || ( AV78WWPFormIsForDynamicValidations != wcpOAV78WWPFormIsForDynamicValidations ) ) )
         {
            setjustcreated();
         }
         wcpOAV10WWPFormType = AV10WWPFormType;
         wcpOAV78WWPFormIsForDynamicValidations = AV78WWPFormIsForDynamicValidations;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV10WWPFormType = cgiGet( sPrefix+"AV10WWPFormType_CTRL");
         if ( StringUtil.Len( sCtrlAV10WWPFormType) > 0 )
         {
            AV10WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV10WWPFormType), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV10WWPFormType", StringUtil.Str( (decimal)(AV10WWPFormType), 1, 0));
         }
         else
         {
            AV10WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV10WWPFormType_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV78WWPFormIsForDynamicValidations = cgiGet( sPrefix+"AV78WWPFormIsForDynamicValidations_CTRL");
         if ( StringUtil.Len( sCtrlAV78WWPFormIsForDynamicValidations) > 0 )
         {
            AV78WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sCtrlAV78WWPFormIsForDynamicValidations));
            AssignAttri(sPrefix, false, "AV78WWPFormIsForDynamicValidations", AV78WWPFormIsForDynamicValidations);
         }
         else
         {
            AV78WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sPrefix+"AV78WWPFormIsForDynamicValidations_PARM"));
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
         PAB42( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSB42( ) ;
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
         WSB42( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV10WWPFormType_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV10WWPFormType)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV10WWPFormType_CTRL", StringUtil.RTrim( sCtrlAV10WWPFormType));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV78WWPFormIsForDynamicValidations_PARM", StringUtil.BoolToStr( AV78WWPFormIsForDynamicValidations));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV78WWPFormIsForDynamicValidations)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV78WWPFormIsForDynamicValidations_CTRL", StringUtil.RTrim( sCtrlAV78WWPFormIsForDynamicValidations));
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
         WEB42( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145382777", true, true);
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
         context.AddJavascriptSource("wp_dynamicformtrn_organisationdynamicformwc.js", "?20256145382782", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_432( )
      {
         edtOrganisationDynamicFormId_Internalname = sPrefix+"ORGANISATIONDYNAMICFORMID_"+sGXsfl_43_idx;
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID_"+sGXsfl_43_idx;
         edtWWPFormId_Internalname = sPrefix+"WWPFORMID_"+sGXsfl_43_idx;
         edtWWPFormTitle_Internalname = sPrefix+"WWPFORMTITLE_"+sGXsfl_43_idx;
         edtWWPFormReferenceName_Internalname = sPrefix+"WWPFORMREFERENCENAME_"+sGXsfl_43_idx;
         edtWWPFormDate_Internalname = sPrefix+"WWPFORMDATE_"+sGXsfl_43_idx;
         edtWWPFormVersionNumber_Internalname = sPrefix+"WWPFORMVERSIONNUMBER_"+sGXsfl_43_idx;
         edtWWPFormLatestVersionNumber_Internalname = sPrefix+"WWPFORMLATESTVERSIONNUMBER_"+sGXsfl_43_idx;
         cmbavActiongroup_Internalname = sPrefix+"vACTIONGROUP_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_432( )
      {
         edtOrganisationDynamicFormId_Internalname = sPrefix+"ORGANISATIONDYNAMICFORMID_"+sGXsfl_43_fel_idx;
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID_"+sGXsfl_43_fel_idx;
         edtWWPFormId_Internalname = sPrefix+"WWPFORMID_"+sGXsfl_43_fel_idx;
         edtWWPFormTitle_Internalname = sPrefix+"WWPFORMTITLE_"+sGXsfl_43_fel_idx;
         edtWWPFormReferenceName_Internalname = sPrefix+"WWPFORMREFERENCENAME_"+sGXsfl_43_fel_idx;
         edtWWPFormDate_Internalname = sPrefix+"WWPFORMDATE_"+sGXsfl_43_fel_idx;
         edtWWPFormVersionNumber_Internalname = sPrefix+"WWPFORMVERSIONNUMBER_"+sGXsfl_43_fel_idx;
         edtWWPFormLatestVersionNumber_Internalname = sPrefix+"WWPFORMLATESTVERSIONNUMBER_"+sGXsfl_43_fel_idx;
         cmbavActiongroup_Internalname = sPrefix+"vACTIONGROUP_"+sGXsfl_43_fel_idx;
      }

      protected void sendrow_432( )
      {
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         WBB40( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_43_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_43_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationDynamicFormId_Internalname,A509OrganisationDynamicFormId.ToString(),A509OrganisationDynamicFormId.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationDynamicFormId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)43,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationId_Internalname,A11OrganisationId.ToString(),A11OrganisationId.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)43,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWWPFormTitle_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormTitle_Internalname,(string)A209WWPFormTitle,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormTitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPFormTitle_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormReferenceName_Internalname,(string)A208WWPFormReferenceName,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormReferenceName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWWPFormDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormDate_Internalname,context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A231WWPFormDate, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPFormDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWWPFormVersionNumber_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormVersionNumber_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormVersionNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPFormVersionNumber_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWWPFormLatestVersionNumber_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormLatestVersionNumber_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A219WWPFormLatestVersionNumber), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormLatestVersionNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPFormLatestVersionNumber_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',43)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_43_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  AV11ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV11ActionGroup), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV11ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVACTIONGROUP.CLICK."+sGXsfl_43_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavActiongroup_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11ActionGroup), 4, 0));
            AssignProp(sPrefix, false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            send_integrity_lvl_hashesB42( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         /* End function sendrow_432 */
      }

      protected void init_web_controls( )
      {
         dynavOrganisationidfilter.Name = "vORGANISATIONIDFILTER";
         dynavOrganisationidfilter.WebTags = "";
         GXCCtl = "vACTIONGROUP_" + sGXsfl_43_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
         }
         cmbWWPFormType.Name = "WWPFORMTYPE";
         cmbWWPFormType.WebTags = "";
         cmbWWPFormType.addItem("0", context.GetMessage( "WWP_DF_Type_DynamicForm", ""), 0);
         cmbWWPFormType.addItem("1", context.GetMessage( "WWP_DF_Type_DynamicSection", ""), 0);
         if ( cmbWWPFormType.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl43( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"43\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormTitle_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Title", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormDate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Date", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormVersionNumber_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Form Version #", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormLatestVersionNumber_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Latest Version", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+cmbavActiongroup_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A509OrganisationDynamicFormId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A209WWPFormTitle));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormTitle_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A208WWPFormReferenceName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormDate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormVersionNumber_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormLatestVersionNumber_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11ActionGroup), 4, 0, ".", ""))));
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
         bttBtnuseractioninsert_Internalname = sPrefix+"BTNUSERACTIONINSERT";
         bttBtneditcolumns_Internalname = sPrefix+"BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = sPrefix+"BTNSUBSCRIPTIONS";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         dynavOrganisationidfilter_Internalname = sPrefix+"vORGANISATIONIDFILTER";
         divOrganisationidfilter_cell_Internalname = sPrefix+"ORGANISATIONIDFILTER_CELL";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         edtOrganisationDynamicFormId_Internalname = sPrefix+"ORGANISATIONDYNAMICFORMID";
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID";
         edtWWPFormId_Internalname = sPrefix+"WWPFORMID";
         edtWWPFormTitle_Internalname = sPrefix+"WWPFORMTITLE";
         edtWWPFormReferenceName_Internalname = sPrefix+"WWPFORMREFERENCENAME";
         edtWWPFormDate_Internalname = sPrefix+"WWPFORMDATE";
         edtWWPFormVersionNumber_Internalname = sPrefix+"WWPFORMVERSIONNUMBER";
         edtWWPFormLatestVersionNumber_Internalname = sPrefix+"WWPFORMLATESTVERSIONNUMBER";
         cmbavActiongroup_Internalname = sPrefix+"vACTIONGROUP";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddc_subscriptions_Internalname = sPrefix+"DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         cmbWWPFormType_Internalname = sPrefix+"WWPFORMTYPE";
         Ddo_gridcolumnsselector_Internalname = sPrefix+"DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_useractioncopy_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONCOPY";
         tblTabledvelop_confirmpanel_useractioncopy_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_USERACTIONCOPY";
         Dvelop_confirmpanel_useractiondelete_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE";
         tblTabledvelop_confirmpanel_useractiondelete_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_USERACTIONDELETE";
         Ucopytolocation_modal_Internalname = sPrefix+"UCOPYTOLOCATION_MODAL";
         tblTableucopytolocation_modal_Internalname = sPrefix+"TABLEUCOPYTOLOCATION_MODAL";
         Dvelop_confirmpanel_udirectcopytolocation_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION";
         tblTabledvelop_confirmpanel_udirectcopytolocation_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = sPrefix+"DIV_WWPAUXWC";
         edtavDdo_wwpformdateauxdatetext_Internalname = sPrefix+"vDDO_WWPFORMDATEAUXDATETEXT";
         Tfwwpformdate_rangepicker_Internalname = sPrefix+"TFWWPFORMDATE_RANGEPICKER";
         divDdo_wwpformdateauxdates_Internalname = sPrefix+"DDO_WWPFORMDATEAUXDATES";
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
         cmbavActiongroup_Class = "ConvertToDDO";
         edtWWPFormLatestVersionNumber_Jsonclick = "";
         edtWWPFormVersionNumber_Jsonclick = "";
         edtWWPFormDate_Jsonclick = "";
         edtWWPFormReferenceName_Jsonclick = "";
         edtWWPFormTitle_Jsonclick = "";
         edtWWPFormId_Jsonclick = "";
         edtOrganisationId_Jsonclick = "";
         edtOrganisationDynamicFormId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtWWPFormLatestVersionNumber_Visible = -1;
         edtWWPFormVersionNumber_Visible = -1;
         edtWWPFormDate_Visible = -1;
         edtWWPFormTitle_Visible = -1;
         cmbWWPFormType.Enabled = 0;
         edtWWPFormLatestVersionNumber_Enabled = 0;
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormDate_Enabled = 0;
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormId_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtOrganisationDynamicFormId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_wwpformdateauxdatetext_Jsonclick = "";
         cmbWWPFormType_Jsonclick = "";
         cmbWWPFormType.Visible = 1;
         dynavOrganisationidfilter_Jsonclick = "";
         dynavOrganisationidfilter.Enabled = 1;
         dynavOrganisationidfilter.Visible = 1;
         divOrganisationidfilter_cell_Class = "";
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtnuseractioninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_udirectcopytolocation_Confirmtype = "1";
         Dvelop_confirmpanel_udirectcopytolocation_Yesbuttonposition = "left";
         Dvelop_confirmpanel_udirectcopytolocation_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_udirectcopytolocation_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_udirectcopytolocation_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_udirectcopytolocation_Confirmationtext = "Are you sure you want to copy the form?";
         Dvelop_confirmpanel_udirectcopytolocation_Title = context.GetMessage( "Copy form", "");
         Ucopytolocation_modal_Bodytype = "WebComponent";
         Ucopytolocation_modal_Confirmtype = "";
         Ucopytolocation_modal_Title = context.GetMessage( "Copy To Location", "");
         Ucopytolocation_modal_Width = "800";
         Dvelop_confirmpanel_useractiondelete_Confirmtype = "1";
         Dvelop_confirmpanel_useractiondelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractiondelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractiondelete_Confirmationtext = "Are you sure you want to delete form?";
         Dvelop_confirmpanel_useractiondelete_Title = context.GetMessage( "Delete form", "");
         Dvelop_confirmpanel_useractioncopy_Confirmtype = "1";
         Dvelop_confirmpanel_useractioncopy_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractioncopy_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractioncopy_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractioncopy_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractioncopy_Confirmationtext = "Are you sure you want to copy the form?";
         Dvelop_confirmpanel_useractioncopy_Title = context.GetMessage( "Copy form", "");
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Format = "||4.0|4.0";
         Ddo_grid_Datalistproc = "WP_DynamicFormTrn_OrganisationDynamicFormWCGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|||";
         Ddo_grid_Includedatalist = "T|||";
         Ddo_grid_Filterisrange = "|P|T|T";
         Ddo_grid_Filtertype = "Character|Date|Numeric|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T|T|T|";
         Ddo_grid_Columnssortvalues = "1|2|3|";
         Ddo_grid_Columnids = "3:WWPFormTitle|5:WWPFormDate|6:WWPFormVersionNumber|7:WWPFormLatestVersionNumber";
         Ddo_grid_Gridinternalname = "";
         Ddc_subscriptions_Titlecontrolidtoreplace = "";
         Ddc_subscriptions_Cls = "ColumnsSelector";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Caption = "";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"sPrefix"},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV52OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV54OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV10WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"dynavOrganisationidfilter"},{"av":"AV55OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV67TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV68TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV69TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV70TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV63TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV64TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV78WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV5LocationId","fld":"vLOCATIONID","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV6OrganisationId","fld":"vORGANISATIONID"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV27GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV28GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV46ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV29GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12B42","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV52OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV54OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV10WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"dynavOrganisationidfilter"},{"av":"AV55OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV67TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV68TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV69TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV70TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV63TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV64TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV78WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV5LocationId","fld":"vLOCATIONID","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13B42","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV52OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV54OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV10WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"dynavOrganisationidfilter"},{"av":"AV55OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV67TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV68TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV69TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV70TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV63TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV64TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV78WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV5LocationId","fld":"vLOCATIONID","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E15B42","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV52OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV54OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV10WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"dynavOrganisationidfilter"},{"av":"AV55OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV67TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV68TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV69TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV70TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV63TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV64TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV78WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV5LocationId","fld":"vLOCATIONID","hsh":true},{"av":"sPrefix"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV52OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV54OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV67TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV68TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV69TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV70TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV63TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV64TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E25B42","iparms":[{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV11ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E16B42","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV52OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV54OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV10WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"dynavOrganisationidfilter"},{"av":"AV55OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV67TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV68TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV69TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV70TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV63TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV64TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV78WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV5LocationId","fld":"vLOCATIONID","hsh":true},{"av":"sPrefix"},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV6OrganisationId","fld":"vORGANISATIONID"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV27GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV28GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV46ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV29GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11B42","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV52OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV54OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV10WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"dynavOrganisationidfilter"},{"av":"AV55OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV67TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV68TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV69TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV70TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV63TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV64TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV78WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV5LocationId","fld":"vLOCATIONID","hsh":true},{"av":"sPrefix"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV29GridState","fld":"vGRIDSTATE"},{"av":"AV17DDO_WWPFormDateAuxDate","fld":"vDDO_WWPFORMDATEAUXDATE"},{"av":"AV19DDO_WWPFormDateAuxDateTo","fld":"vDDO_WWPFORMDATEAUXDATETO"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV29GridState","fld":"vGRIDSTATE"},{"av":"AV52OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV54OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV67TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV68TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV69TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV70TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV63TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV64TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV17DDO_WWPFormDateAuxDate","fld":"vDDO_WWPFORMDATEAUXDATE"},{"av":"AV19DDO_WWPFormDateAuxDateTo","fld":"vDDO_WWPFORMDATEAUXDATETO"},{"av":"AV6OrganisationId","fld":"vORGANISATIONID"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV27GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV28GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV46ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E26B42","iparms":[{"av":"cmbavActiongroup"},{"av":"AV11ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV52OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV54OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV10WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"dynavOrganisationidfilter"},{"av":"AV55OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV67TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV68TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV69TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV70TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV63TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV64TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV78WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV5LocationId","fld":"vLOCATIONID","hsh":true},{"av":"sPrefix"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true},{"av":"A509OrganisationDynamicFormId","fld":"ORGANISATIONDYNAMICFORMID","hsh":true},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV11ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV82OrganisationDynamicFormId_Selected","fld":"vORGANISATIONDYNAMICFORMID_SELECTED"},{"av":"AV83OrganisationId_Selected","fld":"vORGANISATIONID_SELECTED"},{"av":"AV6OrganisationId","fld":"vORGANISATIONID"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV27GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV28GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV46ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV29GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONCOPY.CLOSE","""{"handler":"E17B42","iparms":[{"av":"Dvelop_confirmpanel_useractioncopy_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONCOPY","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV52OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV54OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV10WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"dynavOrganisationidfilter"},{"av":"AV55OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV67TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV68TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV69TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV70TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV63TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV64TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV78WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV5LocationId","fld":"vLOCATIONID","hsh":true},{"av":"sPrefix"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","hsh":true},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"AV58ResultMsg","fld":"vRESULTMSG"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONCOPY.CLOSE",""","oparms":[{"av":"AV58ResultMsg","fld":"vRESULTMSG"},{"av":"AV6OrganisationId","fld":"vORGANISATIONID"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV27GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV28GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV46ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV29GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE","""{"handler":"E18B42","iparms":[{"av":"Dvelop_confirmpanel_useractiondelete_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONDELETE","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV52OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV54OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV10WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"dynavOrganisationidfilter"},{"av":"AV55OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV67TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV68TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV69TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV70TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV63TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV64TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV78WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV5LocationId","fld":"vLOCATIONID","hsh":true},{"av":"sPrefix"},{"av":"AV82OrganisationDynamicFormId_Selected","fld":"vORGANISATIONDYNAMICFORMID_SELECTED"},{"av":"AV83OrganisationId_Selected","fld":"vORGANISATIONID_SELECTED"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE",""","oparms":[{"av":"AV6OrganisationId","fld":"vORGANISATIONID"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV27GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV28GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV46ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV29GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("UCOPYTOLOCATION_MODAL.ONLOADCOMPONENT","""{"handler":"E19B42","iparms":[]""");
         setEventMetadata("UCOPYTOLOCATION_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION.CLOSE","""{"handler":"E20B42","iparms":[{"av":"Dvelop_confirmpanel_udirectcopytolocation_Result","ctrl":"DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV52OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV54OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV10WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"dynavOrganisationidfilter"},{"av":"AV55OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV67TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV68TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV69TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV70TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV63TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV64TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV78WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV5LocationId","fld":"vLOCATIONID","hsh":true},{"av":"sPrefix"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","hsh":true},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"AV6OrganisationId","fld":"vORGANISATIONID"},{"av":"AV58ResultMsg","fld":"vRESULTMSG"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UDIRECTCOPYTOLOCATION.CLOSE",""","oparms":[{"av":"AV58ResultMsg","fld":"vRESULTMSG"},{"av":"AV6OrganisationId","fld":"vORGANISATIONID"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV27GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV28GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV46ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV29GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOUSERACTIONINSERT'","""{"handler":"E21B42","iparms":[{"av":"AV10WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E14B42","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VORGANISATIONIDFILTER.CONTROLVALUECHANGED","""{"handler":"E22B42","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV52OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV54OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV10WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"dynavOrganisationidfilter"},{"av":"AV55OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV84Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV67TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV68TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV69TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV70TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV63TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV64TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV78WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV5LocationId","fld":"vLOCATIONID","hsh":true},{"av":"sPrefix"}]""");
         setEventMetadata("VORGANISATIONIDFILTER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV6OrganisationId","fld":"vORGANISATIONID"},{"av":"AV75WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV47ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV27GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV28GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV42IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV41IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV39IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV40IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV43IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV44IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV36IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV37IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV46ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV29GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VALIDV_ORGANISATIONIDFILTER","""{"handler":"Validv_Organisationidfilter","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMTITLE","""{"handler":"Valid_Wwpformtitle","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMLATESTVERSIONNUMBER","""{"handler":"Valid_Wwpformlatestversionnumber","iparms":[]}""");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_useractioncopy_Result = "";
         Dvelop_confirmpanel_useractiondelete_Result = "";
         Dvelop_confirmpanel_udirectcopytolocation_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV23FilterFullText = "";
         AV55OrganisationIdFilter = Guid.Empty;
         AV75WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV84Pgmname = "";
         AV67TFWWPFormTitle = "";
         AV68TFWWPFormTitle_Sel = "";
         AV61TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AV62TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         AV5LocationId = Guid.Empty;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV46ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV26GridAppliedFilters = "";
         AV16DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV17DDO_WWPFormDateAuxDate = DateTime.MinValue;
         AV19DDO_WWPFormDateAuxDateTo = DateTime.MinValue;
         AV29GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV58ResultMsg = "";
         AV82OrganisationDynamicFormId_Selected = Guid.Empty;
         AV83OrganisationId_Selected = Guid.Empty;
         AV6OrganisationId = Guid.Empty;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnuseractioninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV18DDO_WWPFormDateAuxDateText = "";
         ucTfwwpformdate_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A509OrganisationDynamicFormId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A209WWPFormTitle = "";
         A208WWPFormReferenceName = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00B42_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00B42_A13OrganisationName = new string[] {""} ;
         lV67TFWWPFormTitle = "";
         H00B43_A240WWPFormType = new short[1] ;
         H00B43_A207WWPFormVersionNumber = new short[1] ;
         H00B43_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         H00B43_A208WWPFormReferenceName = new string[] {""} ;
         H00B43_A209WWPFormTitle = new string[] {""} ;
         H00B43_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00B43_A509OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         H00B43_A206WWPFormId = new short[1] ;
         H00B44_A240WWPFormType = new short[1] ;
         H00B44_A207WWPFormVersionNumber = new short[1] ;
         H00B44_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         H00B44_A208WWPFormReferenceName = new string[] {""} ;
         H00B44_A209WWPFormTitle = new string[] {""} ;
         H00B44_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00B44_A509OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         H00B44_A206WWPFormId = new short[1] ;
         AV25GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV24GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV60Session = context.GetSession();
         AV14ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV48ManageFiltersXml = "";
         AV74UserCustomValue = "";
         AV13ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV76WWPForm = new SdtUForm(context);
         AV9WWPFormReferenceName = "";
         AV51NewWWPForm = new SdtUForm(context);
         H00B45_A207WWPFormVersionNumber = new short[1] ;
         H00B45_A206WWPFormId = new short[1] ;
         AV22Element = new SdtUForm_Element(context);
         AV8Trn_OrganisationDynamicForm = new SdtTrn_OrganisationDynamicForm(context);
         AV87GXV2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV49Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV89GXV4 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV50Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         H00B46_A207WWPFormVersionNumber = new short[1] ;
         H00B46_A206WWPFormId = new short[1] ;
         AV7Trn_LocationDynamicForm = new SdtTrn_LocationDynamicForm(context);
         AV94GXV8 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV96GXV10 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV30GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         AV71TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV31HTTPRequest = new GxHttpRequest( context);
         AV72TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         ucDvelop_confirmpanel_udirectcopytolocation = new GXUserControl();
         ucUcopytolocation_modal = new GXUserControl();
         ucDvelop_confirmpanel_useractiondelete = new GXUserControl();
         ucDvelop_confirmpanel_useractioncopy = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV10WWPFormType = "";
         sCtrlAV78WWPFormIsForDynamicValidations = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_dynamicformtrn_organisationdynamicformwc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_dynamicformtrn_organisationdynamicformwc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_dynamicformtrn_organisationdynamicformwc__default(),
            new Object[][] {
                new Object[] {
               H00B42_A11OrganisationId, H00B42_A13OrganisationName
               }
               , new Object[] {
               H00B43_A240WWPFormType, H00B43_A207WWPFormVersionNumber, H00B43_A231WWPFormDate, H00B43_A208WWPFormReferenceName, H00B43_A209WWPFormTitle, H00B43_A11OrganisationId, H00B43_A509OrganisationDynamicFormId, H00B43_A206WWPFormId
               }
               , new Object[] {
               H00B44_A240WWPFormType, H00B44_A207WWPFormVersionNumber, H00B44_A231WWPFormDate, H00B44_A208WWPFormReferenceName, H00B44_A209WWPFormTitle, H00B44_A11OrganisationId, H00B44_A509OrganisationDynamicFormId, H00B44_A206WWPFormId
               }
               , new Object[] {
               H00B45_A207WWPFormVersionNumber, H00B45_A206WWPFormId
               }
               , new Object[] {
               H00B46_A207WWPFormVersionNumber, H00B46_A206WWPFormId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV84Pgmname = "WP_DynamicFormTrn_OrganisationDynamicFormWC";
         /* GeneXus formulas. */
         AV84Pgmname = "WP_DynamicFormTrn_OrganisationDynamicFormWC";
      }

      private short AV10WWPFormType ;
      private short wcpOAV10WWPFormType ;
      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV52OrderedBy ;
      private short AV47ManageFiltersExecutionStep ;
      private short AV69TFWWPFormVersionNumber ;
      private short AV70TFWWPFormVersionNumber_To ;
      private short AV63TFWWPFormLatestVersionNumber ;
      private short AV64TFWWPFormLatestVersionNumber_To ;
      private short wbEnd ;
      private short wbStart ;
      private short A240WWPFormType ;
      private short nDraw ;
      private short nDoneStart ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short AV11ActionGroup ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short GXt_int1 ;
      private short AV15CopyNumber ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtnuseractioninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int edtOrganisationDynamicFormId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int edtWWPFormReferenceName_Enabled ;
      private int edtWWPFormDate_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormLatestVersionNumber_Enabled ;
      private int edtWWPFormTitle_Visible ;
      private int edtWWPFormDate_Visible ;
      private int edtWWPFormVersionNumber_Visible ;
      private int edtWWPFormLatestVersionNumber_Visible ;
      private int AV57PageToGo ;
      private int AV86GXV1 ;
      private int AV88GXV3 ;
      private int AV90GXV5 ;
      private int AV91GXV6 ;
      private int AV93GXV7 ;
      private int AV95GXV9 ;
      private int AV97GXV11 ;
      private int AV98GXV12 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV27GridCurrentPage ;
      private long AV28GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_useractioncopy_Result ;
      private string Dvelop_confirmpanel_useractiondelete_Result ;
      private string Dvelop_confirmpanel_udirectcopytolocation_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_43_idx="0001" ;
      private string AV84Pgmname ;
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
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_subscriptions_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Dvelop_confirmpanel_useractioncopy_Title ;
      private string Dvelop_confirmpanel_useractioncopy_Confirmationtext ;
      private string Dvelop_confirmpanel_useractioncopy_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useractioncopy_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useractioncopy_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useractioncopy_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useractioncopy_Confirmtype ;
      private string Dvelop_confirmpanel_useractiondelete_Title ;
      private string Dvelop_confirmpanel_useractiondelete_Confirmationtext ;
      private string Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useractiondelete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useractiondelete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useractiondelete_Confirmtype ;
      private string Ucopytolocation_modal_Width ;
      private string Ucopytolocation_modal_Title ;
      private string Ucopytolocation_modal_Confirmtype ;
      private string Ucopytolocation_modal_Bodytype ;
      private string Dvelop_confirmpanel_udirectcopytolocation_Title ;
      private string Dvelop_confirmpanel_udirectcopytolocation_Confirmationtext ;
      private string Dvelop_confirmpanel_udirectcopytolocation_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_udirectcopytolocation_Nobuttoncaption ;
      private string Dvelop_confirmpanel_udirectcopytolocation_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_udirectcopytolocation_Yesbuttonposition ;
      private string Dvelop_confirmpanel_udirectcopytolocation_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablegridheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnuseractioninsert_Internalname ;
      private string bttBtnuseractioninsert_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divOrganisationidfilter_cell_Internalname ;
      private string divOrganisationidfilter_cell_Class ;
      private string dynavOrganisationidfilter_Internalname ;
      private string dynavOrganisationidfilter_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddo_grid_Internalname ;
      private string cmbWWPFormType_Internalname ;
      private string cmbWWPFormType_Jsonclick ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_wwpformdateauxdates_Internalname ;
      private string edtavDdo_wwpformdateauxdatetext_Internalname ;
      private string edtavDdo_wwpformdateauxdatetext_Jsonclick ;
      private string Tfwwpformdate_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavActiongroup_Internalname ;
      private string edtOrganisationDynamicFormId_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string edtWWPFormId_Internalname ;
      private string edtWWPFormTitle_Internalname ;
      private string edtWWPFormReferenceName_Internalname ;
      private string edtWWPFormDate_Internalname ;
      private string edtWWPFormVersionNumber_Internalname ;
      private string edtWWPFormLatestVersionNumber_Internalname ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string cmbavActiongroup_Class ;
      private string GXt_char3 ;
      private string tblTabledvelop_confirmpanel_udirectcopytolocation_Internalname ;
      private string Dvelop_confirmpanel_udirectcopytolocation_Internalname ;
      private string tblTableucopytolocation_modal_Internalname ;
      private string Ucopytolocation_modal_Internalname ;
      private string tblTabledvelop_confirmpanel_useractiondelete_Internalname ;
      private string Dvelop_confirmpanel_useractiondelete_Internalname ;
      private string tblTabledvelop_confirmpanel_useractioncopy_Internalname ;
      private string Dvelop_confirmpanel_useractioncopy_Internalname ;
      private string sCtrlAV10WWPFormType ;
      private string sCtrlAV78WWPFormIsForDynamicValidations ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtOrganisationDynamicFormId_Jsonclick ;
      private string edtOrganisationId_Jsonclick ;
      private string edtWWPFormId_Jsonclick ;
      private string edtWWPFormTitle_Jsonclick ;
      private string edtWWPFormReferenceName_Jsonclick ;
      private string edtWWPFormDate_Jsonclick ;
      private string edtWWPFormVersionNumber_Jsonclick ;
      private string edtWWPFormLatestVersionNumber_Jsonclick ;
      private string GXCCtl ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV61TFWWPFormDate ;
      private DateTime AV62TFWWPFormDate_To ;
      private DateTime A231WWPFormDate ;
      private DateTime AV17DDO_WWPFormDateAuxDate ;
      private DateTime AV19DDO_WWPFormDateAuxDateTo ;
      private bool AV78WWPFormIsForDynamicValidations ;
      private bool wcpOAV78WWPFormIsForDynamicValidations ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV54OrderedDsc ;
      private bool AV42IsAuthorized_UserActionEdit ;
      private bool AV41IsAuthorized_UserActionDisplay ;
      private bool AV39IsAuthorized_UserActionCopy ;
      private bool AV40IsAuthorized_UserActionDelete ;
      private bool AV43IsAuthorized_UserActionFilledForms ;
      private bool AV44IsAuthorized_UserActionFillOutForm ;
      private bool AV36IsAuthorized_UCopyToLocation ;
      private bool AV37IsAuthorized_UDirectCopyToLocation ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV45IsAuthorized_UserActionInsert ;
      private bool GXt_boolean4 ;
      private string AV14ColumnsSelectorXML ;
      private string AV48ManageFiltersXml ;
      private string AV74UserCustomValue ;
      private string AV23FilterFullText ;
      private string AV67TFWWPFormTitle ;
      private string AV68TFWWPFormTitle_Sel ;
      private string AV26GridAppliedFilters ;
      private string AV58ResultMsg ;
      private string AV18DDO_WWPFormDateAuxDateText ;
      private string A209WWPFormTitle ;
      private string A208WWPFormReferenceName ;
      private string lV67TFWWPFormTitle ;
      private string AV9WWPFormReferenceName ;
      private Guid AV55OrganisationIdFilter ;
      private Guid AV5LocationId ;
      private Guid AV82OrganisationDynamicFormId_Selected ;
      private Guid AV83OrganisationId_Selected ;
      private Guid AV6OrganisationId ;
      private Guid A509OrganisationDynamicFormId ;
      private Guid A11OrganisationId ;
      private IGxSession AV60Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfwwpformdate_rangepicker ;
      private GXUserControl ucDvelop_confirmpanel_udirectcopytolocation ;
      private GXUserControl ucUcopytolocation_modal ;
      private GXUserControl ucDvelop_confirmpanel_useractiondelete ;
      private GXUserControl ucDvelop_confirmpanel_useractioncopy ;
      private GXWebForm Form ;
      private GxHttpRequest AV31HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavOrganisationidfilter ;
      private GXCombobox cmbavActiongroup ;
      private GXCombobox cmbWWPFormType ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV75WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV12ColumnsSelector ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV46ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV29GridState ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00B42_A11OrganisationId ;
      private string[] H00B42_A13OrganisationName ;
      private short[] H00B43_A240WWPFormType ;
      private short[] H00B43_A207WWPFormVersionNumber ;
      private DateTime[] H00B43_A231WWPFormDate ;
      private string[] H00B43_A208WWPFormReferenceName ;
      private string[] H00B43_A209WWPFormTitle ;
      private Guid[] H00B43_A11OrganisationId ;
      private Guid[] H00B43_A509OrganisationDynamicFormId ;
      private short[] H00B43_A206WWPFormId ;
      private short[] H00B44_A240WWPFormType ;
      private short[] H00B44_A207WWPFormVersionNumber ;
      private DateTime[] H00B44_A231WWPFormDate ;
      private string[] H00B44_A208WWPFormReferenceName ;
      private string[] H00B44_A209WWPFormTitle ;
      private Guid[] H00B44_A11OrganisationId ;
      private Guid[] H00B44_A509OrganisationDynamicFormId ;
      private short[] H00B44_A206WWPFormId ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV25GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV24GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV13ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 ;
      private SdtUForm AV76WWPForm ;
      private SdtUForm AV51NewWWPForm ;
      private short[] H00B45_A207WWPFormVersionNumber ;
      private short[] H00B45_A206WWPFormId ;
      private SdtUForm_Element AV22Element ;
      private SdtTrn_OrganisationDynamicForm AV8Trn_OrganisationDynamicForm ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV87GXV2 ;
      private GeneXus.Utils.SdtMessages_Message AV49Message ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV89GXV4 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV50Messages ;
      private short[] H00B46_A207WWPFormVersionNumber ;
      private short[] H00B46_A206WWPFormId ;
      private SdtTrn_LocationDynamicForm AV7Trn_LocationDynamicForm ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV94GXV8 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV96GXV10 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV71TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV72TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_dynamicformtrn_organisationdynamicformwc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_dynamicformtrn_organisationdynamicformwc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_dynamicformtrn_organisationdynamicformwc__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_H00B43( IGxContext context ,
                                          string AV68TFWWPFormTitle_Sel ,
                                          string AV67TFWWPFormTitle ,
                                          DateTime AV61TFWWPFormDate ,
                                          DateTime AV62TFWWPFormDate_To ,
                                          short AV69TFWWPFormVersionNumber ,
                                          short AV70TFWWPFormVersionNumber_To ,
                                          string A209WWPFormTitle ,
                                          DateTime A231WWPFormDate ,
                                          short A207WWPFormVersionNumber ,
                                          short AV52OrderedBy ,
                                          bool AV54OrderedDsc ,
                                          short A240WWPFormType ,
                                          short AV10WWPFormType ,
                                          string AV23FilterFullText ,
                                          short A219WWPFormLatestVersionNumber ,
                                          short AV63TFWWPFormLatestVersionNumber ,
                                          short AV64TFWWPFormLatestVersionNumber_To ,
                                          Guid A11OrganisationId ,
                                          Guid AV6OrganisationId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int6 = new short[8];
      Object[] GXv_Object7 = new Object[2];
      scmdbuf = "SELECT T2.WWPFormType, T1.WWPFormVersionNumber, T2.WWPFormDate, T2.WWPFormReferenceName, T2.WWPFormTitle, T1.OrganisationId, T1.OrganisationDynamicFormId, T1.WWPFormId FROM (Trn_OrganisationDynamicForm T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
      AddWhere(sWhereString, "(T2.WWPFormType = :AV10WWPFormType)");
      AddWhere(sWhereString, "(T1.OrganisationId = :AV6OrganisationId)");
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFWWPFormTitle)) ) )
      {
         AddWhere(sWhereString, "(T2.WWPFormTitle like :lV67TFWWPFormTitle)");
      }
      else
      {
         GXv_int6[2] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV68TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T2.WWPFormTitle = ( :AV68TFWWPFormTitle_Sel))");
      }
      else
      {
         GXv_int6[3] = 1;
      }
      if ( StringUtil.StrCmp(AV68TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormTitle))=0))");
      }
      if ( ! (DateTime.MinValue==AV61TFWWPFormDate) )
      {
         AddWhere(sWhereString, "(T2.WWPFormDate >= :AV61TFWWPFormDate)");
      }
      else
      {
         GXv_int6[4] = 1;
      }
      if ( ! (DateTime.MinValue==AV62TFWWPFormDate_To) )
      {
         AddWhere(sWhereString, "(T2.WWPFormDate <= :AV62TFWWPFormDate_To)");
      }
      else
      {
         GXv_int6[5] = 1;
      }
      if ( ! (0==AV69TFWWPFormVersionNumber) )
      {
         AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV69TFWWPFormVersionNumber)");
      }
      else
      {
         GXv_int6[6] = 1;
      }
      if ( ! (0==AV70TFWWPFormVersionNumber_To) )
      {
         AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV70TFWWPFormVersionNumber_To)");
      }
      else
      {
         GXv_int6[7] = 1;
      }
      scmdbuf += sWhereString;
      if ( ( AV52OrderedBy == 1 ) && ! AV54OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T2.WWPFormTitle, T1.OrganisationDynamicFormId, T1.OrganisationId";
      }
      else if ( ( AV52OrderedBy == 1 ) && ( AV54OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T2.WWPFormTitle DESC, T1.OrganisationDynamicFormId, T1.OrganisationId";
      }
      else if ( ( AV52OrderedBy == 2 ) && ! AV54OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T2.WWPFormDate, T1.OrganisationDynamicFormId, T1.OrganisationId";
      }
      else if ( ( AV52OrderedBy == 2 ) && ( AV54OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T2.WWPFormDate DESC, T1.OrganisationDynamicFormId, T1.OrganisationId";
      }
      else if ( ( AV52OrderedBy == 3 ) && ! AV54OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T1.WWPFormVersionNumber, T1.OrganisationDynamicFormId, T1.OrganisationId";
      }
      else if ( ( AV52OrderedBy == 3 ) && ( AV54OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T1.WWPFormVersionNumber DESC, T1.OrganisationDynamicFormId, T1.OrganisationId";
      }
      GXv_Object7[0] = scmdbuf;
      GXv_Object7[1] = GXv_int6;
      return GXv_Object7 ;
   }

   protected Object[] conditional_H00B44( IGxContext context ,
                                          string AV68TFWWPFormTitle_Sel ,
                                          string AV67TFWWPFormTitle ,
                                          DateTime AV61TFWWPFormDate ,
                                          DateTime AV62TFWWPFormDate_To ,
                                          short AV69TFWWPFormVersionNumber ,
                                          short AV70TFWWPFormVersionNumber_To ,
                                          string A209WWPFormTitle ,
                                          DateTime A231WWPFormDate ,
                                          short A207WWPFormVersionNumber ,
                                          short AV52OrderedBy ,
                                          bool AV54OrderedDsc ,
                                          short A240WWPFormType ,
                                          short AV10WWPFormType ,
                                          string AV23FilterFullText ,
                                          short A219WWPFormLatestVersionNumber ,
                                          short AV63TFWWPFormLatestVersionNumber ,
                                          short AV64TFWWPFormLatestVersionNumber_To ,
                                          Guid A11OrganisationId ,
                                          Guid AV6OrganisationId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int8 = new short[8];
      Object[] GXv_Object9 = new Object[2];
      scmdbuf = "SELECT T2.WWPFormType, T1.WWPFormVersionNumber, T2.WWPFormDate, T2.WWPFormReferenceName, T2.WWPFormTitle, T1.OrganisationId, T1.OrganisationDynamicFormId, T1.WWPFormId FROM (Trn_OrganisationDynamicForm T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
      AddWhere(sWhereString, "(T2.WWPFormType = :AV10WWPFormType)");
      AddWhere(sWhereString, "(T1.OrganisationId = :AV6OrganisationId)");
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFWWPFormTitle)) ) )
      {
         AddWhere(sWhereString, "(T2.WWPFormTitle like :lV67TFWWPFormTitle)");
      }
      else
      {
         GXv_int8[2] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV68TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T2.WWPFormTitle = ( :AV68TFWWPFormTitle_Sel))");
      }
      else
      {
         GXv_int8[3] = 1;
      }
      if ( StringUtil.StrCmp(AV68TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormTitle))=0))");
      }
      if ( ! (DateTime.MinValue==AV61TFWWPFormDate) )
      {
         AddWhere(sWhereString, "(T2.WWPFormDate >= :AV61TFWWPFormDate)");
      }
      else
      {
         GXv_int8[4] = 1;
      }
      if ( ! (DateTime.MinValue==AV62TFWWPFormDate_To) )
      {
         AddWhere(sWhereString, "(T2.WWPFormDate <= :AV62TFWWPFormDate_To)");
      }
      else
      {
         GXv_int8[5] = 1;
      }
      if ( ! (0==AV69TFWWPFormVersionNumber) )
      {
         AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV69TFWWPFormVersionNumber)");
      }
      else
      {
         GXv_int8[6] = 1;
      }
      if ( ! (0==AV70TFWWPFormVersionNumber_To) )
      {
         AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV70TFWWPFormVersionNumber_To)");
      }
      else
      {
         GXv_int8[7] = 1;
      }
      scmdbuf += sWhereString;
      if ( ( AV52OrderedBy == 1 ) && ! AV54OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T2.WWPFormTitle, T1.OrganisationDynamicFormId, T1.OrganisationId";
      }
      else if ( ( AV52OrderedBy == 1 ) && ( AV54OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T2.WWPFormTitle DESC, T1.OrganisationDynamicFormId, T1.OrganisationId";
      }
      else if ( ( AV52OrderedBy == 2 ) && ! AV54OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T2.WWPFormDate, T1.OrganisationDynamicFormId, T1.OrganisationId";
      }
      else if ( ( AV52OrderedBy == 2 ) && ( AV54OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T2.WWPFormDate DESC, T1.OrganisationDynamicFormId, T1.OrganisationId";
      }
      else if ( ( AV52OrderedBy == 3 ) && ! AV54OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T1.WWPFormVersionNumber, T1.OrganisationDynamicFormId, T1.OrganisationId";
      }
      else if ( ( AV52OrderedBy == 3 ) && ( AV54OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T1.WWPFormVersionNumber DESC, T1.OrganisationDynamicFormId, T1.OrganisationId";
      }
      GXv_Object9[0] = scmdbuf;
      GXv_Object9[1] = GXv_int8;
      return GXv_Object9 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 1 :
                  return conditional_H00B43(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (Guid)dynConstraints[17] , (Guid)dynConstraints[18] );
            case 2 :
                  return conditional_H00B44(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (Guid)dynConstraints[17] , (Guid)dynConstraints[18] );
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
       Object[] prmH00B42;
       prmH00B42 = new Object[] {
       };
       Object[] prmH00B45;
       prmH00B45 = new Object[] {
       };
       Object[] prmH00B46;
       prmH00B46 = new Object[] {
       };
       Object[] prmH00B43;
       prmH00B43 = new Object[] {
       new ParDef("AV10WWPFormType",GXType.Int16,1,0) ,
       new ParDef("AV6OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("lV67TFWWPFormTitle",GXType.VarChar,100,0) ,
       new ParDef("AV68TFWWPFormTitle_Sel",GXType.VarChar,100,0) ,
       new ParDef("AV61TFWWPFormDate",GXType.DateTime,8,5) ,
       new ParDef("AV62TFWWPFormDate_To",GXType.DateTime,8,5) ,
       new ParDef("AV69TFWWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("AV70TFWWPFormVersionNumber_To",GXType.Int16,4,0)
       };
       Object[] prmH00B44;
       prmH00B44 = new Object[] {
       new ParDef("AV10WWPFormType",GXType.Int16,1,0) ,
       new ParDef("AV6OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("lV67TFWWPFormTitle",GXType.VarChar,100,0) ,
       new ParDef("AV68TFWWPFormTitle_Sel",GXType.VarChar,100,0) ,
       new ParDef("AV61TFWWPFormDate",GXType.DateTime,8,5) ,
       new ParDef("AV62TFWWPFormDate_To",GXType.DateTime,8,5) ,
       new ParDef("AV69TFWWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("AV70TFWWPFormVersionNumber_To",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("H00B42", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B42,0, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00B43", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B43,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00B44", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B44,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00B45", "SELECT WWPFormVersionNumber, WWPFormId FROM WWP_Form ORDER BY WWPFormId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B45,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("H00B46", "SELECT WWPFormVersionNumber, WWPFormId FROM WWP_Form ORDER BY WWPFormId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B46,1, GxCacheFrequency.OFF ,true,true )
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
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((short[]) buf[7])[0] = rslt.getShort(8);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((short[]) buf[7])[0] = rslt.getShort(8);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 4 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
    }
 }

}

}
