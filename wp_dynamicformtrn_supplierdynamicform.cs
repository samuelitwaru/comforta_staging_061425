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
   public class wp_dynamicformtrn_supplierdynamicform : GXWebComponent
   {
      public wp_dynamicformtrn_supplierdynamicform( )
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

      public wp_dynamicformtrn_supplierdynamicform( IGxContext context )
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
         this.AV57WWPFormType = aP0_WWPFormType;
         this.AV56WWPFormIsForDynamicValidations = aP1_WWPFormIsForDynamicValidations;
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
         dynavSuppliergenid = new GXCombobox();
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
                  AV57WWPFormType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormType"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV57WWPFormType", StringUtil.Str( (decimal)(AV57WWPFormType), 1, 0));
                  AV56WWPFormIsForDynamicValidations = StringUtil.StrToBool( GetPar( "WWPFormIsForDynamicValidations"));
                  AssignAttri(sPrefix, false, "AV56WWPFormIsForDynamicValidations", AV56WWPFormIsForDynamicValidations);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV57WWPFormType,(bool)AV56WWPFormIsForDynamicValidations});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSUPPLIERGENID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLVvSUPPLIERGENIDBN2( ) ;
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
         AV35OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV37OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV13FilterFullText = GetPar( "FilterFullText");
         dynavSuppliergenid.FromJSonString( GetNextPar( ));
         AV58SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
         AV57WWPFormType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormType"), "."), 18, MidpointRounding.ToEven));
         AV33ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6ColumnsSelector);
         AV66Pgmname = GetPar( "Pgmname");
         AV63TFSupplierGenCompanyName = GetPar( "TFSupplierGenCompanyName");
         AV64TFSupplierGenCompanyName_Sel = GetPar( "TFSupplierGenCompanyName_Sel");
         AV47TFWWPFormTitle = GetPar( "TFWWPFormTitle");
         AV48TFWWPFormTitle_Sel = GetPar( "TFWWPFormTitle_Sel");
         AV41TFWWPFormDate = context.localUtil.ParseDTimeParm( GetPar( "TFWWPFormDate"));
         AV42TFWWPFormDate_To = context.localUtil.ParseDTimeParm( GetPar( "TFWWPFormDate_To"));
         AV49TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
         AV50TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormVersionNumber_To"), "."), 18, MidpointRounding.ToEven));
         AV43TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormLatestVersionNumber"), "."), 18, MidpointRounding.ToEven));
         AV44TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormLatestVersionNumber_To"), "."), 18, MidpointRounding.ToEven));
         AV56WWPFormIsForDynamicValidations = StringUtil.StrToBool( GetPar( "WWPFormIsForDynamicValidations"));
         AV28IsAuthorized_UserActionEdit = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionEdit"));
         AV27IsAuthorized_UserActionDisplay = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionDisplay"));
         AV25IsAuthorized_UserActionCopy = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionCopy"));
         AV26IsAuthorized_UserActionDelete = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionDelete"));
         AV29IsAuthorized_UserActionFilledForms = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionFilledForms"));
         AV30IsAuthorized_UserActionFillOutForm = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionFillOutForm"));
         AV23IsAuthorized_UCopyToLocation = StringUtil.StrToBool( GetPar( "IsAuthorized_UCopyToLocation"));
         AV24IsAuthorized_UDirectCopyToLocation = StringUtil.StrToBool( GetPar( "IsAuthorized_UDirectCopyToLocation"));
         AV65IsAuthorized_SupplierGenCompanyName = StringUtil.StrToBool( GetPar( "IsAuthorized_SupplierGenCompanyName"));
         AV31IsAuthorized_UserActionInsert = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionInsert"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV35OrderedBy, AV37OrderedDsc, AV13FilterFullText, AV58SupplierGenId, AV57WWPFormType, AV33ManageFiltersExecutionStep, AV6ColumnsSelector, AV66Pgmname, AV63TFSupplierGenCompanyName, AV64TFSupplierGenCompanyName_Sel, AV47TFWWPFormTitle, AV48TFWWPFormTitle_Sel, AV41TFWWPFormDate, AV42TFWWPFormDate_To, AV49TFWWPFormVersionNumber, AV50TFWWPFormVersionNumber_To, AV43TFWWPFormLatestVersionNumber, AV44TFWWPFormLatestVersionNumber_To, AV56WWPFormIsForDynamicValidations, AV28IsAuthorized_UserActionEdit, AV27IsAuthorized_UserActionDisplay, AV25IsAuthorized_UserActionCopy, AV26IsAuthorized_UserActionDelete, AV29IsAuthorized_UserActionFilledForms, AV30IsAuthorized_UserActionFillOutForm, AV23IsAuthorized_UCopyToLocation, AV24IsAuthorized_UDirectCopyToLocation, AV65IsAuthorized_SupplierGenCompanyName, AV31IsAuthorized_UserActionInsert, sPrefix) ;
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
            PABN2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV66Pgmname = "WP_DynamicFormTrn_SupplierDynamicForm";
               GXVvSUPPLIERGENID_htmlBN2( ) ;
               WSBN2( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Dynamic Form Trn_Supplier Dynamic Form", "")) ;
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
            GXEncryptionTmp = "wp_dynamicformtrn_supplierdynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(AV57WWPFormType,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV56WWPFormIsForDynamicValidations));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_dynamicformtrn_supplierdynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV66Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV66Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONEDIT", AV28IsAuthorized_UserActionEdit);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONEDIT", GetSecureSignedToken( sPrefix, AV28IsAuthorized_UserActionEdit, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONDISPLAY", AV27IsAuthorized_UserActionDisplay);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDISPLAY", GetSecureSignedToken( sPrefix, AV27IsAuthorized_UserActionDisplay, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONCOPY", AV25IsAuthorized_UserActionCopy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONCOPY", GetSecureSignedToken( sPrefix, AV25IsAuthorized_UserActionCopy, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONDELETE", AV26IsAuthorized_UserActionDelete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDELETE", GetSecureSignedToken( sPrefix, AV26IsAuthorized_UserActionDelete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONFILLEDFORMS", AV29IsAuthorized_UserActionFilledForms);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLEDFORMS", GetSecureSignedToken( sPrefix, AV29IsAuthorized_UserActionFilledForms, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONFILLOUTFORM", AV30IsAuthorized_UserActionFillOutForm);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLOUTFORM", GetSecureSignedToken( sPrefix, AV30IsAuthorized_UserActionFillOutForm, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UCOPYTOLOCATION", AV23IsAuthorized_UCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV23IsAuthorized_UCopyToLocation, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UDIRECTCOPYTOLOCATION", AV24IsAuthorized_UDirectCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UDIRECTCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV24IsAuthorized_UDirectCopyToLocation, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", AV65IsAuthorized_SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", GetSecureSignedToken( sPrefix, AV65IsAuthorized_SupplierGenCompanyName, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONINSERT", AV31IsAuthorized_UserActionInsert);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONINSERT", GetSecureSignedToken( sPrefix, AV31IsAuthorized_UserActionInsert, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV37OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV13FilterFullText);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSUPPLIERGENID", AV58SupplierGenId.ToString());
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_43), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV16GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV9DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV9DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOLUMNSSELECTOR", AV6ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOLUMNSSELECTOR", AV6ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_WWPFORMDATEAUXDATE", context.localUtil.DToC( AV10DDO_WWPFormDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_WWPFORMDATEAUXDATETO", context.localUtil.DToC( AV12DDO_WWPFormDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV57WWPFormType", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV57WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV56WWPFormIsForDynamicValidations", wcpOAV56WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV66Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV66Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV37OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSUPPLIERGENCOMPANYNAME", AV63TFSupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSUPPLIERGENCOMPANYNAME_SEL", AV64TFSupplierGenCompanyName_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMTITLE", AV47TFWWPFormTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMTITLE_SEL", AV48TFWWPFormTitle_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMDATE", context.localUtil.TToC( AV41TFWWPFormDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMDATE_TO", context.localUtil.TToC( AV42TFWWPFormDate_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49TFWWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMVERSIONNUMBER_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50TFWWPFormVersionNumber_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMLATESTVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43TFWWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWWPFORMLATESTVERSIONNUMBER_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TFWWPFormLatestVersionNumber_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vWWPFORMISFORDYNAMICVALIDATIONS", AV56WWPFormIsForDynamicValidations);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONEDIT", AV28IsAuthorized_UserActionEdit);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONEDIT", GetSecureSignedToken( sPrefix, AV28IsAuthorized_UserActionEdit, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONDISPLAY", AV27IsAuthorized_UserActionDisplay);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDISPLAY", GetSecureSignedToken( sPrefix, AV27IsAuthorized_UserActionDisplay, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONCOPY", AV25IsAuthorized_UserActionCopy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONCOPY", GetSecureSignedToken( sPrefix, AV25IsAuthorized_UserActionCopy, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONDELETE", AV26IsAuthorized_UserActionDelete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDELETE", GetSecureSignedToken( sPrefix, AV26IsAuthorized_UserActionDelete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONFILLEDFORMS", AV29IsAuthorized_UserActionFilledForms);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLEDFORMS", GetSecureSignedToken( sPrefix, AV29IsAuthorized_UserActionFilledForms, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONFILLOUTFORM", AV30IsAuthorized_UserActionFillOutForm);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLOUTFORM", GetSecureSignedToken( sPrefix, AV30IsAuthorized_UserActionFillOutForm, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UCOPYTOLOCATION", AV23IsAuthorized_UCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV23IsAuthorized_UCopyToLocation, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UDIRECTCOPYTOLOCATION", AV24IsAuthorized_UDirectCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UDIRECTCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV24IsAuthorized_UDirectCopyToLocation, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", AV65IsAuthorized_SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", GetSecureSignedToken( sPrefix, AV65IsAuthorized_SupplierGenCompanyName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV19GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV19GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vSUPPLIERDYNAMICFORMID_SELECTED", AV61SupplierDynamicFormId_Selected.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vSUPPLIERGENID_SELECTED", AV62SupplierGenId_Selected.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONINSERT", AV31IsAuthorized_UserActionInsert);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONINSERT", GetSecureSignedToken( sPrefix, AV31IsAuthorized_UserActionInsert, context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"USERACTIONINSERT_MODAL_Width", StringUtil.RTrim( Useractioninsert_modal_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"USERACTIONINSERT_MODAL_Title", StringUtil.RTrim( Useractioninsert_modal_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"USERACTIONINSERT_MODAL_Confirmtype", StringUtil.RTrim( Useractioninsert_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"USERACTIONINSERT_MODAL_Bodytype", StringUtil.RTrim( Useractioninsert_modal_Bodytype));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Result));
      }

      protected void RenderHtmlCloseFormBN2( )
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
         return "WP_DynamicFormTrn_SupplierDynamicForm" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Dynamic Form Trn_Supplier Dynamic Form", "") ;
      }

      protected void WBBN0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_dynamicformtrn_supplierdynamicform.aspx");
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
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseractioninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", context.GetMessage( "Insert", ""), bttBtnuseractioninsert_Jsonclick, 5, context.GetMessage( "Insert", ""), "", StyleString, ClassString, bttBtnuseractioninsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUSERACTIONINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_DynamicFormTrn_SupplierDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_DynamicFormTrn_SupplierDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_DynamicFormTrn_SupplierDynamicForm.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV32ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV13FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WP_DynamicFormTrn_SupplierDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynavSuppliergenid_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSuppliergenid, dynavSuppliergenid_Internalname, AV58SupplierGenId.ToString(), 1, dynavSuppliergenid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "guid", "", 1, dynavSuppliergenid.Enabled, 0, 0, 20, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_WP_DynamicFormTrn_SupplierDynamicForm.htm");
            dynavSuppliergenid.CurrentValue = AV58SupplierGenId.ToString();
            AssignProp(sPrefix, false, dynavSuppliergenid_Internalname, "Values", (string)(dynavSuppliergenid.ToJavascriptSource()), true);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV17GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV18GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV16GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV9DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbWWPFormType, cmbWWPFormType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0)), 1, cmbWWPFormType_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbWWPFormType.Visible, 0, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_WP_DynamicFormTrn_SupplierDynamicForm.htm");
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AssignProp(sPrefix, false, cmbWWPFormType_Internalname, "Values", (string)(cmbWWPFormType.ToJavascriptSource()), true);
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV9DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV6ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, sPrefix+"DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table1_64_BN2( true) ;
         }
         else
         {
            wb_table1_64_BN2( false) ;
         }
         return  ;
      }

      protected void wb_table1_64_BN2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_69_BN2( true) ;
         }
         else
         {
            wb_table2_69_BN2( false) ;
         }
         return  ;
      }

      protected void wb_table2_69_BN2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_74_BN2( true) ;
         }
         else
         {
            wb_table3_74_BN2( false) ;
         }
         return  ;
      }

      protected void wb_table3_74_BN2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table4_79_BN2( true) ;
         }
         else
         {
            wb_table4_79_BN2( false) ;
         }
         return  ;
      }

      protected void wb_table4_79_BN2e( bool wbgen )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"W0086"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0086"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_43_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0086"+"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_wwpformdateauxdatetext_Internalname, AV11DDO_WWPFormDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV11DDO_WWPFormDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_wwpformdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_DynamicFormTrn_SupplierDynamicForm.htm");
            /* User Defined Control */
            ucTfwwpformdate_rangepicker.SetProperty("Start Date", AV10DDO_WWPFormDateAuxDate);
            ucTfwwpformdate_rangepicker.SetProperty("End Date", AV12DDO_WWPFormDateAuxDateTo);
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

      protected void STARTBN2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Dynamic Form Trn_Supplier Dynamic Form", ""), 0) ;
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
               STRUPBN0( ) ;
            }
         }
      }

      protected void WSBN2( )
      {
         STARTBN2( ) ;
         EVTBN2( ) ;
      }

      protected void EVTBN2( )
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
                                 STRUPBN0( ) ;
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
                                 STRUPBN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11BN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12BN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13BN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                                    E14BN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E15BN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                                    E16BN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_useractiondelete.Close */
                                    E17BN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "UCOPYTOLOCATION_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ucopytolocation_modal.Onloadcomponent */
                                    E18BN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "USERACTIONINSERT_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Useractioninsert_modal.Onloadcomponent */
                                    E19BN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTIONINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUserActionInsert' */
                                    E20BN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSUPPLIERGENID.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E21BN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBN0( ) ;
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
                                 STRUPBN0( ) ;
                              }
                              nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
                              SubsflControlProps_432( ) ;
                              A44SupplierGenCompanyName = cgiGet( edtSupplierGenCompanyName_Internalname);
                              A616SupplierDynamicFormId = StringUtil.StrToGuid( cgiGet( edtSupplierDynamicFormId_Internalname));
                              A42SupplierGenId = StringUtil.StrToGuid( cgiGet( edtSupplierGenId_Internalname));
                              A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
                              A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
                              A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname), 0);
                              A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A219WWPFormLatestVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormLatestVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                              cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                              AV5ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV5ActionGroup), 4, 0));
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
                                          E22BN2 ();
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
                                          E23BN2 ();
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
                                          E24BN2 ();
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
                                          E25BN2 ();
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
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV35OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV37OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV13FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Suppliergenid Changed */
                                             if ( StringUtil.StrToGuid( cgiGet( sPrefix+"GXH_vSUPPLIERGENID")) != AV58SupplierGenId )
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
                                       STRUPBN0( ) ;
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
                        if ( nCmpId == 86 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0086");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0086", "", sEvt);
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

      protected void WEBN2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormBN2( ) ;
            }
         }
      }

      protected void PABN2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_dynamicformtrn_supplierdynamicform.aspx")), "wp_dynamicformtrn_supplierdynamicform.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_dynamicformtrn_supplierdynamicform.aspx")))) ;
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

      protected void GXDLVvSUPPLIERGENIDBN2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUPPLIERGENID_dataBN2( ) ;
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

      protected void GXVvSUPPLIERGENID_htmlBN2( )
      {
         Guid gxdynajaxvalue;
         GXDLVvSUPPLIERGENID_dataBN2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSuppliergenid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavSuppliergenid.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSUPPLIERGENID_dataBN2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(Guid.Empty.ToString());
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Supplier", ""));
         /* Using cursor H00BN2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H00BN2_A42SupplierGenId[0].ToString());
            gxdynajaxctrldescr.Add(H00BN2_A44SupplierGenCompanyName[0]);
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
                                       short AV35OrderedBy ,
                                       bool AV37OrderedDsc ,
                                       string AV13FilterFullText ,
                                       Guid AV58SupplierGenId ,
                                       short AV57WWPFormType ,
                                       short AV33ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV6ColumnsSelector ,
                                       string AV66Pgmname ,
                                       string AV63TFSupplierGenCompanyName ,
                                       string AV64TFSupplierGenCompanyName_Sel ,
                                       string AV47TFWWPFormTitle ,
                                       string AV48TFWWPFormTitle_Sel ,
                                       DateTime AV41TFWWPFormDate ,
                                       DateTime AV42TFWWPFormDate_To ,
                                       short AV49TFWWPFormVersionNumber ,
                                       short AV50TFWWPFormVersionNumber_To ,
                                       short AV43TFWWPFormLatestVersionNumber ,
                                       short AV44TFWWPFormLatestVersionNumber_To ,
                                       bool AV56WWPFormIsForDynamicValidations ,
                                       bool AV28IsAuthorized_UserActionEdit ,
                                       bool AV27IsAuthorized_UserActionDisplay ,
                                       bool AV25IsAuthorized_UserActionCopy ,
                                       bool AV26IsAuthorized_UserActionDelete ,
                                       bool AV29IsAuthorized_UserActionFilledForms ,
                                       bool AV30IsAuthorized_UserActionFillOutForm ,
                                       bool AV23IsAuthorized_UCopyToLocation ,
                                       bool AV24IsAuthorized_UDirectCopyToLocation ,
                                       bool AV65IsAuthorized_SupplierGenCompanyName ,
                                       bool AV31IsAuthorized_UserActionInsert ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFBN2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_WWPFORMID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SUPPLIERGENID", GetSecureSignedToken( sPrefix, A42SupplierGenId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERGENID", A42SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SUPPLIERDYNAMICFORMID", GetSecureSignedToken( sPrefix, A616SupplierDynamicFormId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"SUPPLIERDYNAMICFORMID", A616SupplierDynamicFormId.ToString());
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSUPPLIERGENID_htmlBN2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSuppliergenid.ItemCount > 0 )
         {
            AV58SupplierGenId = StringUtil.StrToGuid( dynavSuppliergenid.getValidValue(AV58SupplierGenId.ToString()));
            AssignAttri(sPrefix, false, "AV58SupplierGenId", AV58SupplierGenId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSuppliergenid.CurrentValue = AV58SupplierGenId.ToString();
            AssignProp(sPrefix, false, dynavSuppliergenid_Internalname, "Values", dynavSuppliergenid.ToJavascriptSource(), true);
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
         RFBN2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV66Pgmname = "WP_DynamicFormTrn_SupplierDynamicForm";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV64TFSupplierGenCompanyName_Sel ,
                                              AV63TFSupplierGenCompanyName ,
                                              AV48TFWWPFormTitle_Sel ,
                                              AV47TFWWPFormTitle ,
                                              AV41TFWWPFormDate ,
                                              AV42TFWWPFormDate_To ,
                                              AV49TFWWPFormVersionNumber ,
                                              AV50TFWWPFormVersionNumber_To ,
                                              AV58SupplierGenId ,
                                              A44SupplierGenCompanyName ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              A207WWPFormVersionNumber ,
                                              A42SupplierGenId ,
                                              AV35OrderedBy ,
                                              AV37OrderedDsc ,
                                              A240WWPFormType ,
                                              AV57WWPFormType ,
                                              AV13FilterFullText ,
                                              A219WWPFormLatestVersionNumber ,
                                              AV43TFWWPFormLatestVersionNumber ,
                                              AV44TFWWPFormLatestVersionNumber_To } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV63TFSupplierGenCompanyName = StringUtil.Concat( StringUtil.RTrim( AV63TFSupplierGenCompanyName), "%", "");
         lV47TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV47TFWWPFormTitle), "%", "");
         /* Using cursor H00BN3 */
         pr_default.execute(1, new Object[] {AV57WWPFormType, lV63TFSupplierGenCompanyName, AV64TFSupplierGenCompanyName_Sel, lV47TFWWPFormTitle, AV48TFWWPFormTitle_Sel, AV41TFWWPFormDate, AV42TFWWPFormDate_To, AV49TFWWPFormVersionNumber, AV50TFWWPFormVersionNumber_To, AV58SupplierGenId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A240WWPFormType = H00BN3_A240WWPFormType[0];
            AssignAttri(sPrefix, false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            A207WWPFormVersionNumber = H00BN3_A207WWPFormVersionNumber[0];
            A231WWPFormDate = H00BN3_A231WWPFormDate[0];
            A208WWPFormReferenceName = H00BN3_A208WWPFormReferenceName[0];
            A209WWPFormTitle = H00BN3_A209WWPFormTitle[0];
            A42SupplierGenId = H00BN3_A42SupplierGenId[0];
            A616SupplierDynamicFormId = H00BN3_A616SupplierDynamicFormId[0];
            A44SupplierGenCompanyName = H00BN3_A44SupplierGenCompanyName[0];
            A206WWPFormId = H00BN3_A206WWPFormId[0];
            A44SupplierGenCompanyName = H00BN3_A44SupplierGenCompanyName[0];
            A240WWPFormType = H00BN3_A240WWPFormType[0];
            AssignAttri(sPrefix, false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            A231WWPFormDate = H00BN3_A231WWPFormDate[0];
            A208WWPFormReferenceName = H00BN3_A208WWPFormReferenceName[0];
            A209WWPFormTitle = H00BN3_A209WWPFormTitle[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) || ( ( StringUtil.Like( StringUtil.Lower( A44SupplierGenCompanyName) , StringUtil.PadR( "%" + StringUtil.Lower( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (0==AV43TFWWPFormLatestVersionNumber) || ( ( A219WWPFormLatestVersionNumber >= AV43TFWWPFormLatestVersionNumber ) ) )
               {
                  if ( (0==AV44TFWWPFormLatestVersionNumber_To) || ( ( A219WWPFormLatestVersionNumber <= AV44TFWWPFormLatestVersionNumber_To ) ) )
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

      protected void RFBN2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 43;
         /* Execute user event: Refresh */
         E23BN2 ();
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
                                                 AV64TFSupplierGenCompanyName_Sel ,
                                                 AV63TFSupplierGenCompanyName ,
                                                 AV48TFWWPFormTitle_Sel ,
                                                 AV47TFWWPFormTitle ,
                                                 AV41TFWWPFormDate ,
                                                 AV42TFWWPFormDate_To ,
                                                 AV49TFWWPFormVersionNumber ,
                                                 AV50TFWWPFormVersionNumber_To ,
                                                 AV58SupplierGenId ,
                                                 A44SupplierGenCompanyName ,
                                                 A209WWPFormTitle ,
                                                 A231WWPFormDate ,
                                                 A207WWPFormVersionNumber ,
                                                 A42SupplierGenId ,
                                                 AV35OrderedBy ,
                                                 AV37OrderedDsc ,
                                                 A240WWPFormType ,
                                                 AV57WWPFormType ,
                                                 AV13FilterFullText ,
                                                 A219WWPFormLatestVersionNumber ,
                                                 AV43TFWWPFormLatestVersionNumber ,
                                                 AV44TFWWPFormLatestVersionNumber_To } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV63TFSupplierGenCompanyName = StringUtil.Concat( StringUtil.RTrim( AV63TFSupplierGenCompanyName), "%", "");
            lV47TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV47TFWWPFormTitle), "%", "");
            /* Using cursor H00BN4 */
            pr_default.execute(2, new Object[] {AV57WWPFormType, lV63TFSupplierGenCompanyName, AV64TFSupplierGenCompanyName_Sel, lV47TFWWPFormTitle, AV48TFWWPFormTitle_Sel, AV41TFWWPFormDate, AV42TFWWPFormDate_To, AV49TFWWPFormVersionNumber, AV50TFWWPFormVersionNumber_To, AV58SupplierGenId});
            nGXsfl_43_idx = 1;
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(2) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A240WWPFormType = H00BN4_A240WWPFormType[0];
               AssignAttri(sPrefix, false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
               A207WWPFormVersionNumber = H00BN4_A207WWPFormVersionNumber[0];
               A231WWPFormDate = H00BN4_A231WWPFormDate[0];
               A208WWPFormReferenceName = H00BN4_A208WWPFormReferenceName[0];
               A209WWPFormTitle = H00BN4_A209WWPFormTitle[0];
               A42SupplierGenId = H00BN4_A42SupplierGenId[0];
               A616SupplierDynamicFormId = H00BN4_A616SupplierDynamicFormId[0];
               A44SupplierGenCompanyName = H00BN4_A44SupplierGenCompanyName[0];
               A206WWPFormId = H00BN4_A206WWPFormId[0];
               A44SupplierGenCompanyName = H00BN4_A44SupplierGenCompanyName[0];
               A240WWPFormType = H00BN4_A240WWPFormType[0];
               AssignAttri(sPrefix, false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
               A231WWPFormDate = H00BN4_A231WWPFormDate[0];
               A208WWPFormReferenceName = H00BN4_A208WWPFormReferenceName[0];
               A209WWPFormTitle = H00BN4_A209WWPFormTitle[0];
               GXt_int1 = A219WWPFormLatestVersionNumber;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
               A219WWPFormLatestVersionNumber = GXt_int1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) || ( ( StringUtil.Like( StringUtil.Lower( A44SupplierGenCompanyName) , StringUtil.PadR( "%" + StringUtil.Lower( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV13FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV13FilterFullText , 254 , "%"),  ' ' ) ) ) )
               {
                  if ( (0==AV43TFWWPFormLatestVersionNumber) || ( ( A219WWPFormLatestVersionNumber >= AV43TFWWPFormLatestVersionNumber ) ) )
                  {
                     if ( (0==AV44TFWWPFormLatestVersionNumber_To) || ( ( A219WWPFormLatestVersionNumber <= AV44TFWWPFormLatestVersionNumber_To ) ) )
                     {
                        /* Execute user event: Grid.Load */
                        E24BN2 ();
                     }
                  }
               }
               pr_default.readNext(2);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(2) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(2);
            wbEnd = 43;
            WBBN0( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBN2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV66Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV66Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONEDIT", AV28IsAuthorized_UserActionEdit);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONEDIT", GetSecureSignedToken( sPrefix, AV28IsAuthorized_UserActionEdit, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONDISPLAY", AV27IsAuthorized_UserActionDisplay);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDISPLAY", GetSecureSignedToken( sPrefix, AV27IsAuthorized_UserActionDisplay, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONCOPY", AV25IsAuthorized_UserActionCopy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONCOPY", GetSecureSignedToken( sPrefix, AV25IsAuthorized_UserActionCopy, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONDELETE", AV26IsAuthorized_UserActionDelete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDELETE", GetSecureSignedToken( sPrefix, AV26IsAuthorized_UserActionDelete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONFILLEDFORMS", AV29IsAuthorized_UserActionFilledForms);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLEDFORMS", GetSecureSignedToken( sPrefix, AV29IsAuthorized_UserActionFilledForms, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONFILLOUTFORM", AV30IsAuthorized_UserActionFillOutForm);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLOUTFORM", GetSecureSignedToken( sPrefix, AV30IsAuthorized_UserActionFillOutForm, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UCOPYTOLOCATION", AV23IsAuthorized_UCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV23IsAuthorized_UCopyToLocation, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UDIRECTCOPYTOLOCATION", AV24IsAuthorized_UDirectCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UDIRECTCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV24IsAuthorized_UDirectCopyToLocation, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", AV65IsAuthorized_SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", GetSecureSignedToken( sPrefix, AV65IsAuthorized_SupplierGenCompanyName, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_WWPFORMID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sPrefix+sGXsfl_43_idx, context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SUPPLIERGENID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sPrefix+sGXsfl_43_idx, A42SupplierGenId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SUPPLIERDYNAMICFORMID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sPrefix+sGXsfl_43_idx, A616SupplierDynamicFormId, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_USERACTIONINSERT", AV31IsAuthorized_UserActionInsert);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONINSERT", GetSecureSignedToken( sPrefix, AV31IsAuthorized_UserActionInsert, context));
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
            gxgrGrid_refresh( subGrid_Rows, AV35OrderedBy, AV37OrderedDsc, AV13FilterFullText, AV58SupplierGenId, AV57WWPFormType, AV33ManageFiltersExecutionStep, AV6ColumnsSelector, AV66Pgmname, AV63TFSupplierGenCompanyName, AV64TFSupplierGenCompanyName_Sel, AV47TFWWPFormTitle, AV48TFWWPFormTitle_Sel, AV41TFWWPFormDate, AV42TFWWPFormDate_To, AV49TFWWPFormVersionNumber, AV50TFWWPFormVersionNumber_To, AV43TFWWPFormLatestVersionNumber, AV44TFWWPFormLatestVersionNumber_To, AV56WWPFormIsForDynamicValidations, AV28IsAuthorized_UserActionEdit, AV27IsAuthorized_UserActionDisplay, AV25IsAuthorized_UserActionCopy, AV26IsAuthorized_UserActionDelete, AV29IsAuthorized_UserActionFilledForms, AV30IsAuthorized_UserActionFillOutForm, AV23IsAuthorized_UCopyToLocation, AV24IsAuthorized_UDirectCopyToLocation, AV65IsAuthorized_SupplierGenCompanyName, AV31IsAuthorized_UserActionInsert, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV35OrderedBy, AV37OrderedDsc, AV13FilterFullText, AV58SupplierGenId, AV57WWPFormType, AV33ManageFiltersExecutionStep, AV6ColumnsSelector, AV66Pgmname, AV63TFSupplierGenCompanyName, AV64TFSupplierGenCompanyName_Sel, AV47TFWWPFormTitle, AV48TFWWPFormTitle_Sel, AV41TFWWPFormDate, AV42TFWWPFormDate_To, AV49TFWWPFormVersionNumber, AV50TFWWPFormVersionNumber_To, AV43TFWWPFormLatestVersionNumber, AV44TFWWPFormLatestVersionNumber_To, AV56WWPFormIsForDynamicValidations, AV28IsAuthorized_UserActionEdit, AV27IsAuthorized_UserActionDisplay, AV25IsAuthorized_UserActionCopy, AV26IsAuthorized_UserActionDelete, AV29IsAuthorized_UserActionFilledForms, AV30IsAuthorized_UserActionFillOutForm, AV23IsAuthorized_UCopyToLocation, AV24IsAuthorized_UDirectCopyToLocation, AV65IsAuthorized_SupplierGenCompanyName, AV31IsAuthorized_UserActionInsert, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV35OrderedBy, AV37OrderedDsc, AV13FilterFullText, AV58SupplierGenId, AV57WWPFormType, AV33ManageFiltersExecutionStep, AV6ColumnsSelector, AV66Pgmname, AV63TFSupplierGenCompanyName, AV64TFSupplierGenCompanyName_Sel, AV47TFWWPFormTitle, AV48TFWWPFormTitle_Sel, AV41TFWWPFormDate, AV42TFWWPFormDate_To, AV49TFWWPFormVersionNumber, AV50TFWWPFormVersionNumber_To, AV43TFWWPFormLatestVersionNumber, AV44TFWWPFormLatestVersionNumber_To, AV56WWPFormIsForDynamicValidations, AV28IsAuthorized_UserActionEdit, AV27IsAuthorized_UserActionDisplay, AV25IsAuthorized_UserActionCopy, AV26IsAuthorized_UserActionDelete, AV29IsAuthorized_UserActionFilledForms, AV30IsAuthorized_UserActionFillOutForm, AV23IsAuthorized_UCopyToLocation, AV24IsAuthorized_UDirectCopyToLocation, AV65IsAuthorized_SupplierGenCompanyName, AV31IsAuthorized_UserActionInsert, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV35OrderedBy, AV37OrderedDsc, AV13FilterFullText, AV58SupplierGenId, AV57WWPFormType, AV33ManageFiltersExecutionStep, AV6ColumnsSelector, AV66Pgmname, AV63TFSupplierGenCompanyName, AV64TFSupplierGenCompanyName_Sel, AV47TFWWPFormTitle, AV48TFWWPFormTitle_Sel, AV41TFWWPFormDate, AV42TFWWPFormDate_To, AV49TFWWPFormVersionNumber, AV50TFWWPFormVersionNumber_To, AV43TFWWPFormLatestVersionNumber, AV44TFWWPFormLatestVersionNumber_To, AV56WWPFormIsForDynamicValidations, AV28IsAuthorized_UserActionEdit, AV27IsAuthorized_UserActionDisplay, AV25IsAuthorized_UserActionCopy, AV26IsAuthorized_UserActionDelete, AV29IsAuthorized_UserActionFilledForms, AV30IsAuthorized_UserActionFillOutForm, AV23IsAuthorized_UCopyToLocation, AV24IsAuthorized_UDirectCopyToLocation, AV65IsAuthorized_SupplierGenCompanyName, AV31IsAuthorized_UserActionInsert, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV35OrderedBy, AV37OrderedDsc, AV13FilterFullText, AV58SupplierGenId, AV57WWPFormType, AV33ManageFiltersExecutionStep, AV6ColumnsSelector, AV66Pgmname, AV63TFSupplierGenCompanyName, AV64TFSupplierGenCompanyName_Sel, AV47TFWWPFormTitle, AV48TFWWPFormTitle_Sel, AV41TFWWPFormDate, AV42TFWWPFormDate_To, AV49TFWWPFormVersionNumber, AV50TFWWPFormVersionNumber_To, AV43TFWWPFormLatestVersionNumber, AV44TFWWPFormLatestVersionNumber_To, AV56WWPFormIsForDynamicValidations, AV28IsAuthorized_UserActionEdit, AV27IsAuthorized_UserActionDisplay, AV25IsAuthorized_UserActionCopy, AV26IsAuthorized_UserActionDelete, AV29IsAuthorized_UserActionFilledForms, AV30IsAuthorized_UserActionFillOutForm, AV23IsAuthorized_UCopyToLocation, AV24IsAuthorized_UDirectCopyToLocation, AV65IsAuthorized_SupplierGenCompanyName, AV31IsAuthorized_UserActionInsert, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV66Pgmname = "WP_DynamicFormTrn_SupplierDynamicForm";
         GXVvSUPPLIERGENID_htmlBN2( ) ;
         edtSupplierGenCompanyName_Enabled = 0;
         edtSupplierDynamicFormId_Enabled = 0;
         edtSupplierGenId_Enabled = 0;
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

      protected void STRUPBN0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E22BN2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV32ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV9DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCOLUMNSSELECTOR"), AV6ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_43"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV17GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV18GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV16GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV10DDO_WWPFormDateAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_WWPFORMDATEAUXDATE"), 0);
            AV12DDO_WWPFormDateAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_WWPFORMDATEAUXDATETO"), 0);
            wcpOAV57WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV57WWPFormType"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV56WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV56WWPFormIsForDynamicValidations"));
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
            Useractioninsert_modal_Width = cgiGet( sPrefix+"USERACTIONINSERT_MODAL_Width");
            Useractioninsert_modal_Title = cgiGet( sPrefix+"USERACTIONINSERT_MODAL_Title");
            Useractioninsert_modal_Confirmtype = cgiGet( sPrefix+"USERACTIONINSERT_MODAL_Confirmtype");
            Useractioninsert_modal_Bodytype = cgiGet( sPrefix+"USERACTIONINSERT_MODAL_Bodytype");
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
            Dvelop_confirmpanel_useractiondelete_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result");
            /* Read variables values. */
            AV13FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV13FilterFullText", AV13FilterFullText);
            dynavSuppliergenid.Name = dynavSuppliergenid_Internalname;
            dynavSuppliergenid.CurrentValue = cgiGet( dynavSuppliergenid_Internalname);
            AV58SupplierGenId = StringUtil.StrToGuid( cgiGet( dynavSuppliergenid_Internalname));
            AssignAttri(sPrefix, false, "AV58SupplierGenId", AV58SupplierGenId.ToString());
            cmbWWPFormType.Name = cmbWWPFormType_Internalname;
            cmbWWPFormType.CurrentValue = cgiGet( cmbWWPFormType_Internalname);
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormType_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AV11DDO_WWPFormDateAuxDateText = cgiGet( edtavDdo_wwpformdateauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV11DDO_WWPFormDateAuxDateText", AV11DDO_WWPFormDateAuxDateText);
            /* Read subfile selected row values. */
            nGXsfl_43_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
            if ( nGXsfl_43_idx > 0 )
            {
               A44SupplierGenCompanyName = cgiGet( edtSupplierGenCompanyName_Internalname);
               A616SupplierDynamicFormId = StringUtil.StrToGuid( cgiGet( edtSupplierDynamicFormId_Internalname));
               A42SupplierGenId = StringUtil.StrToGuid( cgiGet( edtSupplierGenId_Internalname));
               A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
               A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
               A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname));
               A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A219WWPFormLatestVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormLatestVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               cmbavActiongroup.Name = cmbavActiongroup_Internalname;
               cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
               AV5ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV5ActionGroup), 4, 0));
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV35OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV37OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV13FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToGuid( cgiGet( sPrefix+"GXH_vSUPPLIERGENID")) != AV58SupplierGenId )
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
         E22BN2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E22BN2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFWWPFORMDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_wwpformdateauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, sPrefix, false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, sPrefix, false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean2 = AV65IsAuthorized_SupplierGenCompanyName;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_suppliergenview_Execute", out  GXt_boolean2) ;
         AV65IsAuthorized_SupplierGenCompanyName = GXt_boolean2;
         AssignAttri(sPrefix, false, "AV65IsAuthorized_SupplierGenCompanyName", AV65IsAuthorized_SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", GetSecureSignedToken( sPrefix, AV65IsAuthorized_SupplierGenCompanyName, context));
         AV15GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV14GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV15GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         cmbWWPFormType.Visible = 0;
         AssignProp(sPrefix, false, cmbWWPFormType_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbWWPFormType.Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV35OrderedBy < 1 )
         {
            AV35OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV35OrderedBy", StringUtil.LTrimStr( (decimal)(AV35OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = AV9DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3) ;
         AV9DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, sPrefix, false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E23BN2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV55WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV33ManageFiltersExecutionStep == 1 )
         {
            AV33ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV33ManageFiltersExecutionStep == 2 )
         {
            AV33ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV40Session.Get("WP_DynamicFormTrn_SupplierDynamicFormColumnsSelector"), "") != 0 )
         {
            AV8ColumnsSelectorXML = AV40Session.Get("WP_DynamicFormTrn_SupplierDynamicFormColumnsSelector");
            AV6ColumnsSelector.FromXml(AV8ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtSupplierGenCompanyName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtSupplierGenCompanyName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenCompanyName_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtWWPFormTitle_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtWWPFormTitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtWWPFormDate_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtWWPFormDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormDate_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtWWPFormVersionNumber_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtWWPFormLatestVersionNumber_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtWWPFormLatestVersionNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormLatestVersionNumber_Visible), 5, 0), !bGXsfl_43_Refreshing);
         AV17GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV17GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV17GridCurrentPage), 10, 0));
         AV18GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV18GridPageCount", StringUtil.LTrimStr( (decimal)(AV18GridPageCount), 10, 0));
         GXt_char4 = AV16GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV66Pgmname, out  GXt_char4) ;
         AV16GridAppliedFilters = GXt_char4;
         AssignAttri(sPrefix, false, "AV16GridAppliedFilters", AV16GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6ColumnsSelector", AV6ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19GridState", AV19GridState);
      }

      protected void E12BN2( )
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
            AV39PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV39PageToGo) ;
         }
      }

      protected void E13BN2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15BN2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV35OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV35OrderedBy", StringUtil.LTrimStr( (decimal)(AV35OrderedBy), 4, 0));
            AV37OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV37OrderedDsc", AV37OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierGenCompanyName") == 0 )
            {
               AV63TFSupplierGenCompanyName = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV63TFSupplierGenCompanyName", AV63TFSupplierGenCompanyName);
               AV64TFSupplierGenCompanyName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV64TFSupplierGenCompanyName_Sel", AV64TFSupplierGenCompanyName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormTitle") == 0 )
            {
               AV47TFWWPFormTitle = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV47TFWWPFormTitle", AV47TFWWPFormTitle);
               AV48TFWWPFormTitle_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV48TFWWPFormTitle_Sel", AV48TFWWPFormTitle_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormDate") == 0 )
            {
               AV41TFWWPFormDate = context.localUtil.CToT( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV41TFWWPFormDate", context.localUtil.TToC( AV41TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV42TFWWPFormDate_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV42TFWWPFormDate_To", context.localUtil.TToC( AV42TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( ! (DateTime.MinValue==AV42TFWWPFormDate_To) )
               {
                  AV42TFWWPFormDate_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV42TFWWPFormDate_To)), (short)(DateTimeUtil.Month( AV42TFWWPFormDate_To)), (short)(DateTimeUtil.Day( AV42TFWWPFormDate_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV42TFWWPFormDate_To", context.localUtil.TToC( AV42TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormVersionNumber") == 0 )
            {
               AV49TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV49TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV49TFWWPFormVersionNumber), 4, 0));
               AV50TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV50TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV50TFWWPFormVersionNumber_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormLatestVersionNumber") == 0 )
            {
               AV43TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV43TFWWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(AV43TFWWPFormLatestVersionNumber), 4, 0));
               AV44TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV44TFWWPFormLatestVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV44TFWWPFormLatestVersionNumber_To), 4, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E24BN2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavActiongroup.removeAllItems();
            cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
            if ( AV28IsAuthorized_UserActionEdit )
            {
               cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fas fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV27IsAuthorized_UserActionDisplay )
            {
               cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Display", ""), "fas fa-magnifying-glass", "", "", "", "", "", "", ""), 0);
            }
            if ( AV25IsAuthorized_UserActionCopy )
            {
               cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "Copy", ""), "fa-clone far", "", "", "", "", "", "", ""), 0);
            }
            if ( AV26IsAuthorized_UserActionDelete )
            {
               cmbavActiongroup.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "Delete", ""), "fas fa-xmark", "", "", "", "", "", "", ""), 0);
            }
            if ( AV29IsAuthorized_UserActionFilledForms )
            {
               cmbavActiongroup.addItem("5", StringUtil.Format( "%1;%2", context.GetMessage( "Filled forms", ""), "far fa-eye", "", "", "", "", "", "", ""), 0);
            }
            if ( AV30IsAuthorized_UserActionFillOutForm )
            {
               cmbavActiongroup.addItem("6", StringUtil.Format( "%1;%2", context.GetMessage( "fill out form", ""), "fas fa-file-circle-plus", "", "", "", "", "", "", ""), 0);
            }
            if ( AV23IsAuthorized_UCopyToLocation )
            {
               cmbavActiongroup.addItem("7", StringUtil.Format( "%1;%2", context.GetMessage( "Copy To Location", ""), "fa-copy far", "", "", "", "", "", "", ""), 0);
            }
            if ( AV24IsAuthorized_UDirectCopyToLocation )
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
            if ( AV65IsAuthorized_SupplierGenCompanyName )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "trn_suppliergenview.aspx"+UrlEncode(A42SupplierGenId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
               edtSupplierGenCompanyName_Link = formatLink("trn_suppliergenview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5ActionGroup), 4, 0));
      }

      protected void E16BN2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV8ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV6ColumnsSelector.FromJSonString(AV8ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WP_DynamicFormTrn_SupplierDynamicFormColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV8ColumnsSelectorXML)) ? "" : AV6ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6ColumnsSelector", AV6ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19GridState", AV19GridState);
      }

      protected void E11BN2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
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
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WP_DynamicFormTrn_SupplierDynamicFormFilters")) + "," + UrlEncode(StringUtil.RTrim(AV66Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV33ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WP_DynamicFormTrn_SupplierDynamicFormFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV33ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char4 = AV34ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WP_DynamicFormTrn_SupplierDynamicFormFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char4) ;
            AV34ManageFiltersXml = GXt_char4;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV66Pgmname+"GridState",  AV34ManageFiltersXml) ;
               AV19GridState.FromXml(AV34ManageFiltersXml, null, "", "");
               AV35OrderedBy = AV19GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV35OrderedBy", StringUtil.LTrimStr( (decimal)(AV35OrderedBy), 4, 0));
               AV37OrderedDsc = AV19GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV37OrderedDsc", AV37OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19GridState", AV19GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6ColumnsSelector", AV6ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E25BN2( )
      {
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV5ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO USERACTIONEDIT' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV5ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO USERACTIONDISPLAY' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV5ActionGroup == 3 )
         {
            /* Execute user subroutine: 'DO USERACTIONCOPY' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV5ActionGroup == 4 )
         {
            /* Execute user subroutine: 'DO USERACTIONDELETE' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV5ActionGroup == 5 )
         {
            /* Execute user subroutine: 'DO USERACTIONFILLEDFORMS' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV5ActionGroup == 6 )
         {
            /* Execute user subroutine: 'DO USERACTIONFILLOUTFORM' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV5ActionGroup == 7 )
         {
            /* Execute user subroutine: 'DO UCOPYTOLOCATION' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV5ActionGroup == 8 )
         {
            /* Execute user subroutine: 'DO UDIRECTCOPYTOLOCATION' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV5ActionGroup = 0;
         AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV5ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5ActionGroup), 4, 0));
         AssignProp(sPrefix, false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6ColumnsSelector", AV6ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19GridState", AV19GridState);
      }

      protected void E17BN2( )
      {
         /* Dvelop_confirmpanel_useractiondelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractiondelete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONDELETE' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6ColumnsSelector", AV6ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19GridState", AV19GridState);
      }

      protected void E18BN2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0086",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0086"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E20BN2( )
      {
         /* 'DoUserActionInsert' Routine */
         returnInSub = false;
         if ( AV31IsAuthorized_UserActionInsert )
         {
            this.executeUsercontrolMethod(sPrefix, false, "USERACTIONINSERT_MODALContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6ColumnsSelector", AV6ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19GridState", AV19GridState);
      }

      protected void E19BN2( )
      {
         /* Useractioninsert_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WC_CreateSupplierForm")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wc_createsupplierform", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WC_CreateSupplierForm";
            WebComp_Wwpaux_wc_Component = "WC_CreateSupplierForm";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0086",(string)"",(short)A240WWPFormType});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0086"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E14BN2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0086",(string)"",(string)"WWP_Form",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0086"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV35OrderedBy), 4, 0))+":"+(AV37OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV6ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "SupplierGenCompanyName",  "",  "Supplier",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "WWPFormTitle",  "",  "Title",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "WWPFormDate",  "",  "Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "WWPFormVersionNumber",  "",  "Form Version #",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "WWPFormLatestVersionNumber",  "",  "Latest Version",  true,  "") ;
         GXt_char4 = AV54UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WP_DynamicFormTrn_SupplierDynamicFormColumnsSelector", out  GXt_char4) ;
         AV54UserCustomValue = GXt_char4;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54UserCustomValue)) ) )
         {
            AV7ColumnsSelectorAux.FromXml(AV54UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV7ColumnsSelectorAux, ref  AV6ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean2 = AV28IsAuthorized_UserActionEdit;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_supplierdynamicform_edit", out  GXt_boolean2) ;
         AV28IsAuthorized_UserActionEdit = GXt_boolean2;
         AssignAttri(sPrefix, false, "AV28IsAuthorized_UserActionEdit", AV28IsAuthorized_UserActionEdit);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONEDIT", GetSecureSignedToken( sPrefix, AV28IsAuthorized_UserActionEdit, context));
         GXt_boolean2 = AV27IsAuthorized_UserActionDisplay;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_createdynamicform_Execute", out  GXt_boolean2) ;
         AV27IsAuthorized_UserActionDisplay = GXt_boolean2;
         AssignAttri(sPrefix, false, "AV27IsAuthorized_UserActionDisplay", AV27IsAuthorized_UserActionDisplay);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDISPLAY", GetSecureSignedToken( sPrefix, AV27IsAuthorized_UserActionDisplay, context));
         GXt_boolean2 = AV25IsAuthorized_UserActionCopy;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_supplierdynamicform_copy", out  GXt_boolean2) ;
         AV25IsAuthorized_UserActionCopy = GXt_boolean2;
         AssignAttri(sPrefix, false, "AV25IsAuthorized_UserActionCopy", AV25IsAuthorized_UserActionCopy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONCOPY", GetSecureSignedToken( sPrefix, AV25IsAuthorized_UserActionCopy, context));
         GXt_boolean2 = AV26IsAuthorized_UserActionDelete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_supplierdynamicform_delete", out  GXt_boolean2) ;
         AV26IsAuthorized_UserActionDelete = GXt_boolean2;
         AssignAttri(sPrefix, false, "AV26IsAuthorized_UserActionDelete", AV26IsAuthorized_UserActionDelete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONDELETE", GetSecureSignedToken( sPrefix, AV26IsAuthorized_UserActionDelete, context));
         GXt_boolean2 = AV29IsAuthorized_UserActionFilledForms;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_supplierdynamicform_filledforms", out  GXt_boolean2) ;
         AV29IsAuthorized_UserActionFilledForms = GXt_boolean2;
         AssignAttri(sPrefix, false, "AV29IsAuthorized_UserActionFilledForms", AV29IsAuthorized_UserActionFilledForms);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLEDFORMS", GetSecureSignedToken( sPrefix, AV29IsAuthorized_UserActionFilledForms, context));
         GXt_boolean2 = AV30IsAuthorized_UserActionFillOutForm;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_supplierdynamicform_filloutform", out  GXt_boolean2) ;
         AV30IsAuthorized_UserActionFillOutForm = GXt_boolean2;
         AssignAttri(sPrefix, false, "AV30IsAuthorized_UserActionFillOutForm", AV30IsAuthorized_UserActionFillOutForm);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONFILLOUTFORM", GetSecureSignedToken( sPrefix, AV30IsAuthorized_UserActionFillOutForm, context));
         GXt_boolean2 = AV23IsAuthorized_UCopyToLocation;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_supplierdynamicform_copytolocation", out  GXt_boolean2) ;
         AV23IsAuthorized_UCopyToLocation = GXt_boolean2;
         AssignAttri(sPrefix, false, "AV23IsAuthorized_UCopyToLocation", AV23IsAuthorized_UCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV23IsAuthorized_UCopyToLocation, context));
         GXt_boolean2 = AV24IsAuthorized_UDirectCopyToLocation;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_supplierdynamicform_directcopytolocation", out  GXt_boolean2) ;
         AV24IsAuthorized_UDirectCopyToLocation = GXt_boolean2;
         AssignAttri(sPrefix, false, "AV24IsAuthorized_UDirectCopyToLocation", AV24IsAuthorized_UDirectCopyToLocation);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UDIRECTCOPYTOLOCATION", GetSecureSignedToken( sPrefix, AV24IsAuthorized_UDirectCopyToLocation, context));
         GXt_boolean2 = AV31IsAuthorized_UserActionInsert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_supplierdynamicform_insert", out  GXt_boolean2) ;
         AV31IsAuthorized_UserActionInsert = GXt_boolean2;
         AssignAttri(sPrefix, false, "AV31IsAuthorized_UserActionInsert", AV31IsAuthorized_UserActionInsert);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_USERACTIONINSERT", GetSecureSignedToken( sPrefix, AV31IsAuthorized_UserActionInsert, context));
         if ( ! ( AV31IsAuthorized_UserActionInsert ) )
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

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = AV32ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WP_DynamicFormTrn_SupplierDynamicFormFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5) ;
         AV32ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV13FilterFullText = "";
         AssignAttri(sPrefix, false, "AV13FilterFullText", AV13FilterFullText);
         AV63TFSupplierGenCompanyName = "";
         AssignAttri(sPrefix, false, "AV63TFSupplierGenCompanyName", AV63TFSupplierGenCompanyName);
         AV64TFSupplierGenCompanyName_Sel = "";
         AssignAttri(sPrefix, false, "AV64TFSupplierGenCompanyName_Sel", AV64TFSupplierGenCompanyName_Sel);
         AV47TFWWPFormTitle = "";
         AssignAttri(sPrefix, false, "AV47TFWWPFormTitle", AV47TFWWPFormTitle);
         AV48TFWWPFormTitle_Sel = "";
         AssignAttri(sPrefix, false, "AV48TFWWPFormTitle_Sel", AV48TFWWPFormTitle_Sel);
         AV41TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV41TFWWPFormDate", context.localUtil.TToC( AV41TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV42TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV42TFWWPFormDate_To", context.localUtil.TToC( AV42TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV49TFWWPFormVersionNumber = 0;
         AssignAttri(sPrefix, false, "AV49TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV49TFWWPFormVersionNumber), 4, 0));
         AV50TFWWPFormVersionNumber_To = 0;
         AssignAttri(sPrefix, false, "AV50TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV50TFWWPFormVersionNumber_To), 4, 0));
         AV43TFWWPFormLatestVersionNumber = 0;
         AssignAttri(sPrefix, false, "AV43TFWWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(AV43TFWWPFormLatestVersionNumber), 4, 0));
         AV44TFWWPFormLatestVersionNumber_To = 0;
         AssignAttri(sPrefix, false, "AV44TFWWPFormLatestVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV44TFWWPFormLatestVersionNumber_To), 4, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S202( )
      {
         /* 'DO USERACTIONEDIT' Routine */
         returnInSub = false;
         if ( AV28IsAuthorized_UserActionEdit )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(A240WWPFormType,1,0)) + "," + UrlEncode(StringUtil.RTrim(context.GetMessage( "Supplier", ""))) + "," + UrlEncode(A42SupplierGenId.ToString());
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S212( )
      {
         /* 'DO USERACTIONDISPLAY' Routine */
         returnInSub = false;
         if ( AV27IsAuthorized_UserActionDisplay )
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

      protected void S222( )
      {
         /* 'DO USERACTIONCOPY' Routine */
         returnInSub = false;
         if ( AV25IsAuthorized_UserActionCopy )
         {
            AV61SupplierDynamicFormId_Selected = A616SupplierDynamicFormId;
            AssignAttri(sPrefix, false, "AV61SupplierDynamicFormId_Selected", AV61SupplierDynamicFormId_Selected.ToString());
            AV62SupplierGenId_Selected = A42SupplierGenId;
            AssignAttri(sPrefix, false, "AV62SupplierGenId_Selected", AV62SupplierGenId_Selected.ToString());
            this.executeUsercontrolMethod(sPrefix, false, "DVELOP_CONFIRMPANEL_USERACTIONCOPYContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S282( )
      {
         /* 'DO ACTION USERACTIONCOPY' Routine */
         returnInSub = false;
      }

      protected void S232( )
      {
         /* 'DO USERACTIONDELETE' Routine */
         returnInSub = false;
         if ( AV26IsAuthorized_UserActionDelete )
         {
            AV61SupplierDynamicFormId_Selected = A616SupplierDynamicFormId;
            AssignAttri(sPrefix, false, "AV61SupplierDynamicFormId_Selected", AV61SupplierDynamicFormId_Selected.ToString());
            AV62SupplierGenId_Selected = A42SupplierGenId;
            AssignAttri(sPrefix, false, "AV62SupplierGenId_Selected", AV62SupplierGenId_Selected.ToString());
            this.executeUsercontrolMethod(sPrefix, false, "DVELOP_CONFIRMPANEL_USERACTIONDELETEContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S292( )
      {
         /* 'DO ACTION USERACTIONDELETE' Routine */
         returnInSub = false;
         new prc_deletesupplierform(context ).execute(  AV61SupplierDynamicFormId_Selected,  AV62SupplierGenId_Selected, out  AV60Messages) ;
         if ( AV60Messages.Count > 0 )
         {
            AV67GXV1 = 1;
            while ( AV67GXV1 <= AV60Messages.Count )
            {
               AV59Message = ((GeneXus.Utils.SdtMessages_Message)AV60Messages.Item(AV67GXV1));
               GX_msglist.addItem(AV59Message.gxTpr_Description);
               AV67GXV1 = (int)(AV67GXV1+1);
            }
         }
         else
         {
            gxgrGrid_refresh( subGrid_Rows, AV35OrderedBy, AV37OrderedDsc, AV13FilterFullText, AV58SupplierGenId, AV57WWPFormType, AV33ManageFiltersExecutionStep, AV6ColumnsSelector, AV66Pgmname, AV63TFSupplierGenCompanyName, AV64TFSupplierGenCompanyName_Sel, AV47TFWWPFormTitle, AV48TFWWPFormTitle_Sel, AV41TFWWPFormDate, AV42TFWWPFormDate_To, AV49TFWWPFormVersionNumber, AV50TFWWPFormVersionNumber_To, AV43TFWWPFormLatestVersionNumber, AV44TFWWPFormLatestVersionNumber_To, AV56WWPFormIsForDynamicValidations, AV28IsAuthorized_UserActionEdit, AV27IsAuthorized_UserActionDisplay, AV25IsAuthorized_UserActionCopy, AV26IsAuthorized_UserActionDelete, AV29IsAuthorized_UserActionFilledForms, AV30IsAuthorized_UserActionFillOutForm, AV23IsAuthorized_UCopyToLocation, AV24IsAuthorized_UDirectCopyToLocation, AV65IsAuthorized_SupplierGenCompanyName, AV31IsAuthorized_UserActionInsert, sPrefix) ;
         }
      }

      protected void S242( )
      {
         /* 'DO USERACTIONFILLEDFORMS' Routine */
         returnInSub = false;
         if ( AV29IsAuthorized_UserActionFilledForms )
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

      protected void S252( )
      {
         /* 'DO USERACTIONFILLOUTFORM' Routine */
         returnInSub = false;
         if ( AV30IsAuthorized_UserActionFillOutForm )
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

      protected void S262( )
      {
         /* 'DO UCOPYTOLOCATION' Routine */
         returnInSub = false;
         if ( AV23IsAuthorized_UCopyToLocation )
         {
            this.executeUsercontrolMethod(sPrefix, false, "UCOPYTOLOCATION_MODALContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void S272( )
      {
         /* 'DO UDIRECTCOPYTOLOCATION' Routine */
         returnInSub = false;
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get(AV66Pgmname+"GridState"), "") == 0 )
         {
            AV19GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV66Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV19GridState.FromXml(AV40Session.Get(AV66Pgmname+"GridState"), null, "", "");
         }
         AV35OrderedBy = AV19GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV35OrderedBy", StringUtil.LTrimStr( (decimal)(AV35OrderedBy), 4, 0));
         AV37OrderedDsc = AV19GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV37OrderedDsc", AV37OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV19GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV19GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV68GXV2 = 1;
         while ( AV68GXV2 <= AV19GridState.gxTpr_Filtervalues.Count )
         {
            AV20GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV19GridState.gxTpr_Filtervalues.Item(AV68GXV2));
            if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV20GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV13FilterFullText", AV13FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME") == 0 )
            {
               AV63TFSupplierGenCompanyName = AV20GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV63TFSupplierGenCompanyName", AV63TFSupplierGenCompanyName);
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME_SEL") == 0 )
            {
               AV64TFSupplierGenCompanyName_Sel = AV20GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV64TFSupplierGenCompanyName_Sel", AV64TFSupplierGenCompanyName_Sel);
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV47TFWWPFormTitle = AV20GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV47TFWWPFormTitle", AV47TFWWPFormTitle);
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV48TFWWPFormTitle_Sel = AV20GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV48TFWWPFormTitle_Sel", AV48TFWWPFormTitle_Sel);
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFWWPFORMDATE") == 0 )
            {
               AV41TFWWPFormDate = context.localUtil.CToT( AV20GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV41TFWWPFormDate", context.localUtil.TToC( AV41TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV42TFWWPFormDate_To = context.localUtil.CToT( AV20GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV42TFWWPFormDate_To", context.localUtil.TToC( AV42TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV10DDO_WWPFormDateAuxDate = DateTimeUtil.ResetTime(AV41TFWWPFormDate);
               AssignAttri(sPrefix, false, "AV10DDO_WWPFormDateAuxDate", context.localUtil.Format(AV10DDO_WWPFormDateAuxDate, "99/99/99"));
               AV12DDO_WWPFormDateAuxDateTo = DateTimeUtil.ResetTime(AV42TFWWPFormDate_To);
               AssignAttri(sPrefix, false, "AV12DDO_WWPFormDateAuxDateTo", context.localUtil.Format(AV12DDO_WWPFormDateAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFWWPFORMVERSIONNUMBER") == 0 )
            {
               AV49TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV20GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV49TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV49TFWWPFormVersionNumber), 4, 0));
               AV50TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV20GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV50TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV50TFWWPFormVersionNumber_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFWWPFORMLATESTVERSIONNUMBER") == 0 )
            {
               AV43TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( AV20GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV43TFWWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(AV43TFWWPFormLatestVersionNumber), 4, 0));
               AV44TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV20GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV44TFWWPFormLatestVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV44TFWWPFormLatestVersionNumber_To), 4, 0));
            }
            AV68GXV2 = (int)(AV68GXV2+1);
         }
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV64TFSupplierGenCompanyName_Sel)),  AV64TFSupplierGenCompanyName_Sel, out  GXt_char4) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFWWPFormTitle_Sel)),  AV48TFWWPFormTitle_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char4+"|"+GXt_char6+"|||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV63TFSupplierGenCompanyName)),  AV63TFSupplierGenCompanyName, out  GXt_char6) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV47TFWWPFormTitle)),  AV47TFWWPFormTitle, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char4+"|"+((DateTime.MinValue==AV41TFWWPFormDate) ? "" : context.localUtil.DToC( AV10DDO_WWPFormDateAuxDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((0==AV49TFWWPFormVersionNumber) ? "" : StringUtil.Str( (decimal)(AV49TFWWPFormVersionNumber), 4, 0))+"|"+((0==AV43TFWWPFormLatestVersionNumber) ? "" : StringUtil.Str( (decimal)(AV43TFWWPFormLatestVersionNumber), 4, 0));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV42TFWWPFormDate_To) ? "" : context.localUtil.DToC( AV12DDO_WWPFormDateAuxDateTo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((0==AV50TFWWPFormVersionNumber_To) ? "" : StringUtil.Str( (decimal)(AV50TFWWPFormVersionNumber_To), 4, 0))+"|"+((0==AV44TFWWPFormLatestVersionNumber_To) ? "" : StringUtil.Str( (decimal)(AV44TFWWPFormLatestVersionNumber_To), 4, 0));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV19GridState.FromXml(AV40Session.Get(AV66Pgmname+"GridState"), null, "", "");
         AV19GridState.gxTpr_Orderedby = AV35OrderedBy;
         AV19GridState.gxTpr_Ordereddsc = AV37OrderedDsc;
         AV19GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV19GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)),  0,  AV13FilterFullText,  AV13FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV19GridState,  "TFSUPPLIERGENCOMPANYNAME",  context.GetMessage( "Supplier", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV63TFSupplierGenCompanyName)),  0,  AV63TFSupplierGenCompanyName,  AV63TFSupplierGenCompanyName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV64TFSupplierGenCompanyName_Sel)),  AV64TFSupplierGenCompanyName_Sel,  AV64TFSupplierGenCompanyName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV19GridState,  "TFWWPFORMTITLE",  context.GetMessage( "Title", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFWWPFormTitle)),  0,  AV47TFWWPFormTitle,  AV47TFWWPFormTitle,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFWWPFormTitle_Sel)),  AV48TFWWPFormTitle_Sel,  AV48TFWWPFormTitle_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV19GridState,  "TFWWPFORMDATE",  context.GetMessage( "Date", ""),  !((DateTime.MinValue==AV41TFWWPFormDate)&&(DateTime.MinValue==AV42TFWWPFormDate_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV41TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  ((DateTime.MinValue==AV41TFWWPFormDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV41TFWWPFormDate, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV42TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  ((DateTime.MinValue==AV42TFWWPFormDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV42TFWWPFormDate_To, "99/99/99 99:99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV19GridState,  "TFWWPFORMVERSIONNUMBER",  context.GetMessage( "Form Version #", ""),  !((0==AV49TFWWPFormVersionNumber)&&(0==AV50TFWWPFormVersionNumber_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV49TFWWPFormVersionNumber), 4, 0)),  ((0==AV49TFWWPFormVersionNumber) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV49TFWWPFormVersionNumber), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV50TFWWPFormVersionNumber_To), 4, 0)),  ((0==AV50TFWWPFormVersionNumber_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV50TFWWPFormVersionNumber_To), "ZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV19GridState,  "TFWWPFORMLATESTVERSIONNUMBER",  context.GetMessage( "Latest Version", ""),  !((0==AV43TFWWPFormLatestVersionNumber)&&(0==AV44TFWWPFormLatestVersionNumber_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV43TFWWPFormLatestVersionNumber), 4, 0)),  ((0==AV43TFWWPFormLatestVersionNumber) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV43TFWWPFormLatestVersionNumber), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV44TFWWPFormLatestVersionNumber_To), 4, 0)),  ((0==AV44TFWWPFormLatestVersionNumber_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV44TFWWPFormLatestVersionNumber_To), "ZZZ9")))) ;
         if ( ! (0==AV57WWPFormType) )
         {
            AV20GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV20GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMTYPE";
            AV20GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV57WWPFormType), 1, 0);
            AV19GridState.gxTpr_Filtervalues.Add(AV20GridStateFilterValue, 0);
         }
         if ( ! (false==AV56WWPFormIsForDynamicValidations) )
         {
            AV20GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV20GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMISFORDYNAMICVALIDATIONS";
            AV20GridStateFilterValue.gxTpr_Value = StringUtil.BoolToStr( AV56WWPFormIsForDynamicValidations);
            AV19GridState.gxTpr_Filtervalues.Add(AV20GridStateFilterValue, 0);
         }
         AV19GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV66Pgmname+"GridState",  AV19GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV52TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV52TrnContext.gxTpr_Callerobject = AV66Pgmname;
         AV52TrnContext.gxTpr_Callerondelete = true;
         AV52TrnContext.gxTpr_Callerurl = AV21HTTPRequest.ScriptName+"?"+AV21HTTPRequest.QueryString;
         AV52TrnContext.gxTpr_Transactionname = "Trn_SupplierDynamicForm";
         AV53TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV53TrnContextAtt.gxTpr_Attributename = "WWPFormType";
         AV53TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV57WWPFormType), 1, 0);
         AV52TrnContext.gxTpr_Attributes.Add(AV53TrnContextAtt, 0);
         AV40Session.Set("TrnContext", AV52TrnContext.ToXml(false, true, "", ""));
      }

      protected void E21BN2( )
      {
         /* Suppliergenid_Controlvaluechanged Routine */
         returnInSub = false;
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6ColumnsSelector", AV6ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19GridState", AV19GridState);
      }

      protected void wb_table4_79_BN2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableuseractioninsert_modal_Internalname, tblTableuseractioninsert_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucUseractioninsert_modal.SetProperty("Width", Useractioninsert_modal_Width);
            ucUseractioninsert_modal.SetProperty("Title", Useractioninsert_modal_Title);
            ucUseractioninsert_modal.SetProperty("ConfirmType", Useractioninsert_modal_Confirmtype);
            ucUseractioninsert_modal.SetProperty("BodyType", Useractioninsert_modal_Bodytype);
            ucUseractioninsert_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Useractioninsert_modal_Internalname, sPrefix+"USERACTIONINSERT_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"USERACTIONINSERT_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_79_BN2e( true) ;
         }
         else
         {
            wb_table4_79_BN2e( false) ;
         }
      }

      protected void wb_table3_74_BN2( bool wbgen )
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
            wb_table3_74_BN2e( true) ;
         }
         else
         {
            wb_table3_74_BN2e( false) ;
         }
      }

      protected void wb_table2_69_BN2( bool wbgen )
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
            wb_table2_69_BN2e( true) ;
         }
         else
         {
            wb_table2_69_BN2e( false) ;
         }
      }

      protected void wb_table1_64_BN2( bool wbgen )
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
            wb_table1_64_BN2e( true) ;
         }
         else
         {
            wb_table1_64_BN2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV57WWPFormType = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV57WWPFormType", StringUtil.Str( (decimal)(AV57WWPFormType), 1, 0));
         AV56WWPFormIsForDynamicValidations = (bool)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV56WWPFormIsForDynamicValidations", AV56WWPFormIsForDynamicValidations);
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
         PABN2( ) ;
         WSBN2( ) ;
         WEBN2( ) ;
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
         sCtrlAV57WWPFormType = (string)((string)getParm(obj,0));
         sCtrlAV56WWPFormIsForDynamicValidations = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PABN2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_dynamicformtrn_supplierdynamicform", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PABN2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV57WWPFormType = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV57WWPFormType", StringUtil.Str( (decimal)(AV57WWPFormType), 1, 0));
            AV56WWPFormIsForDynamicValidations = (bool)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV56WWPFormIsForDynamicValidations", AV56WWPFormIsForDynamicValidations);
         }
         wcpOAV57WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV57WWPFormType"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV56WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV56WWPFormIsForDynamicValidations"));
         if ( ! GetJustCreated( ) && ( ( AV57WWPFormType != wcpOAV57WWPFormType ) || ( AV56WWPFormIsForDynamicValidations != wcpOAV56WWPFormIsForDynamicValidations ) ) )
         {
            setjustcreated();
         }
         wcpOAV57WWPFormType = AV57WWPFormType;
         wcpOAV56WWPFormIsForDynamicValidations = AV56WWPFormIsForDynamicValidations;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV57WWPFormType = cgiGet( sPrefix+"AV57WWPFormType_CTRL");
         if ( StringUtil.Len( sCtrlAV57WWPFormType) > 0 )
         {
            AV57WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV57WWPFormType), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV57WWPFormType", StringUtil.Str( (decimal)(AV57WWPFormType), 1, 0));
         }
         else
         {
            AV57WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV57WWPFormType_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV56WWPFormIsForDynamicValidations = cgiGet( sPrefix+"AV56WWPFormIsForDynamicValidations_CTRL");
         if ( StringUtil.Len( sCtrlAV56WWPFormIsForDynamicValidations) > 0 )
         {
            AV56WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sCtrlAV56WWPFormIsForDynamicValidations));
            AssignAttri(sPrefix, false, "AV56WWPFormIsForDynamicValidations", AV56WWPFormIsForDynamicValidations);
         }
         else
         {
            AV56WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sPrefix+"AV56WWPFormIsForDynamicValidations_PARM"));
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
         PABN2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSBN2( ) ;
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
         WSBN2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV57WWPFormType_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV57WWPFormType)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV57WWPFormType_CTRL", StringUtil.RTrim( sCtrlAV57WWPFormType));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV56WWPFormIsForDynamicValidations_PARM", StringUtil.BoolToStr( AV56WWPFormIsForDynamicValidations));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV56WWPFormIsForDynamicValidations)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV56WWPFormIsForDynamicValidations_CTRL", StringUtil.RTrim( sCtrlAV56WWPFormIsForDynamicValidations));
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
         WEBN2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256145242651", true, true);
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
         context.AddJavascriptSource("wp_dynamicformtrn_supplierdynamicform.js", "?20256145242654", false, true);
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
         edtSupplierGenCompanyName_Internalname = sPrefix+"SUPPLIERGENCOMPANYNAME_"+sGXsfl_43_idx;
         edtSupplierDynamicFormId_Internalname = sPrefix+"SUPPLIERDYNAMICFORMID_"+sGXsfl_43_idx;
         edtSupplierGenId_Internalname = sPrefix+"SUPPLIERGENID_"+sGXsfl_43_idx;
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
         edtSupplierGenCompanyName_Internalname = sPrefix+"SUPPLIERGENCOMPANYNAME_"+sGXsfl_43_fel_idx;
         edtSupplierDynamicFormId_Internalname = sPrefix+"SUPPLIERDYNAMICFORMID_"+sGXsfl_43_fel_idx;
         edtSupplierGenId_Internalname = sPrefix+"SUPPLIERGENID_"+sGXsfl_43_fel_idx;
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
         WBBN0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplierGenCompanyName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenCompanyName_Internalname,(string)A44SupplierGenCompanyName,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSupplierGenCompanyName_Link,(string)"",(string)"",(string)"",(string)edtSupplierGenCompanyName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSupplierGenCompanyName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierDynamicFormId_Internalname,A616SupplierDynamicFormId.ToString(),A616SupplierDynamicFormId.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierDynamicFormId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)43,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenId_Internalname,A42SupplierGenId.ToString(),A42SupplierGenId.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)43,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',43)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_43_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  AV5ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV5ActionGroup), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV5ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVACTIONGROUP.CLICK."+sGXsfl_43_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavActiongroup_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5ActionGroup), 4, 0));
            AssignProp(sPrefix, false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            send_integrity_lvl_hashesBN2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         /* End function sendrow_432 */
      }

      protected void init_web_controls( )
      {
         dynavSuppliergenid.Name = "vSUPPLIERGENID";
         dynavSuppliergenid.WebTags = "";
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplierGenCompanyName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Supplier", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A44SupplierGenCompanyName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSupplierGenCompanyName_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplierGenCompanyName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A616SupplierDynamicFormId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A42SupplierGenId.ToString()));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5ActionGroup), 4, 0, ".", ""))));
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
         dynavSuppliergenid_Internalname = sPrefix+"vSUPPLIERGENID";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         edtSupplierGenCompanyName_Internalname = sPrefix+"SUPPLIERGENCOMPANYNAME";
         edtSupplierDynamicFormId_Internalname = sPrefix+"SUPPLIERDYNAMICFORMID";
         edtSupplierGenId_Internalname = sPrefix+"SUPPLIERGENID";
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
         Useractioninsert_modal_Internalname = sPrefix+"USERACTIONINSERT_MODAL";
         tblTableuseractioninsert_modal_Internalname = sPrefix+"TABLEUSERACTIONINSERT_MODAL";
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
         edtSupplierGenId_Jsonclick = "";
         edtSupplierDynamicFormId_Jsonclick = "";
         edtSupplierGenCompanyName_Jsonclick = "";
         edtSupplierGenCompanyName_Link = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtWWPFormLatestVersionNumber_Visible = -1;
         edtWWPFormVersionNumber_Visible = -1;
         edtWWPFormDate_Visible = -1;
         edtWWPFormTitle_Visible = -1;
         edtSupplierGenCompanyName_Visible = -1;
         cmbWWPFormType.Enabled = 0;
         edtWWPFormLatestVersionNumber_Enabled = 0;
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormDate_Enabled = 0;
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormId_Enabled = 0;
         edtSupplierGenId_Enabled = 0;
         edtSupplierDynamicFormId_Enabled = 0;
         edtSupplierGenCompanyName_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_wwpformdateauxdatetext_Jsonclick = "";
         cmbWWPFormType_Jsonclick = "";
         cmbWWPFormType.Visible = 1;
         dynavSuppliergenid_Jsonclick = "";
         dynavSuppliergenid.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtnuseractioninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Useractioninsert_modal_Bodytype = "WebComponent";
         Useractioninsert_modal_Confirmtype = "";
         Useractioninsert_modal_Title = context.GetMessage( "Create Supplier Form", "");
         Useractioninsert_modal_Width = "800";
         Ucopytolocation_modal_Bodytype = "WebComponent";
         Ucopytolocation_modal_Confirmtype = "";
         Ucopytolocation_modal_Title = context.GetMessage( "Copy To Location", "");
         Ucopytolocation_modal_Width = "800";
         Dvelop_confirmpanel_useractiondelete_Confirmtype = "1";
         Dvelop_confirmpanel_useractiondelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractiondelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractiondelete_Confirmationtext = "Are you sure you want to delete form? All submitted responses will be deleted as well.";
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
         Ddo_grid_Format = "|||4.0|4.0";
         Ddo_grid_Datalistproc = "WP_DynamicFormTrn_SupplierDynamicFormGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|||";
         Ddo_grid_Includedatalist = "T|T|||";
         Ddo_grid_Filterisrange = "||P|T|T";
         Ddo_grid_Filtertype = "Character|Character|Date|Numeric|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|";
         Ddo_grid_Columnssortvalues = "2|1|3|4|";
         Ddo_grid_Columnids = "0:SupplierGenCompanyName|4:WWPFormTitle|6:WWPFormDate|7:WWPFormVersionNumber|8:WWPFormLatestVersionNumber";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"sPrefix"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"dynavSuppliergenid"},{"av":"AV58SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV57WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV63TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV64TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV47TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV48TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV41TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV42TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV49TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV50TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV43TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV44TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV56WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV65IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtSupplierGenCompanyName_Visible","ctrl":"SUPPLIERGENCOMPANYNAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV17GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV18GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV16GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV19GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12BN2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"dynavSuppliergenid"},{"av":"AV58SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV57WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV63TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV64TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV47TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV48TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV41TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV42TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV49TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV50TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV43TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV44TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV56WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV65IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13BN2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"dynavSuppliergenid"},{"av":"AV58SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV57WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV63TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV64TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV47TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV48TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV41TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV42TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV49TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV50TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV43TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV44TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV56WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV65IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E15BN2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"dynavSuppliergenid"},{"av":"AV58SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV57WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV63TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV64TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV47TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV48TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV41TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV42TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV49TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV50TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV43TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV44TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV56WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV65IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"av":"sPrefix"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV63TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV64TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV47TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV48TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV41TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV42TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV49TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV50TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV43TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV44TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E24BN2","iparms":[{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV65IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV5ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"edtSupplierGenCompanyName_Link","ctrl":"SUPPLIERGENCOMPANYNAME","prop":"Link"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E16BN2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"dynavSuppliergenid"},{"av":"AV58SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV57WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV63TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV64TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV47TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV48TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV41TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV42TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV49TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV50TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV43TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV44TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV56WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV65IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"av":"sPrefix"},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtSupplierGenCompanyName_Visible","ctrl":"SUPPLIERGENCOMPANYNAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV17GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV18GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV16GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV19GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11BN2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"dynavSuppliergenid"},{"av":"AV58SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV57WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV63TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV64TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV47TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV48TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV41TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV42TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV49TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV50TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV43TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV44TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV56WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV65IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"av":"sPrefix"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV19GridState","fld":"vGRIDSTATE"},{"av":"AV10DDO_WWPFormDateAuxDate","fld":"vDDO_WWPFORMDATEAUXDATE"},{"av":"AV12DDO_WWPFormDateAuxDateTo","fld":"vDDO_WWPFORMDATEAUXDATETO"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19GridState","fld":"vGRIDSTATE"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV63TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV64TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV47TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV48TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV41TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV42TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV49TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV50TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV43TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV44TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV10DDO_WWPFormDateAuxDate","fld":"vDDO_WWPFORMDATEAUXDATE"},{"av":"AV12DDO_WWPFormDateAuxDateTo","fld":"vDDO_WWPFORMDATEAUXDATETO"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtSupplierGenCompanyName_Visible","ctrl":"SUPPLIERGENCOMPANYNAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV17GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV18GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV16GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E25BN2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV5ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"dynavSuppliergenid"},{"av":"AV58SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV57WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV63TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV64TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV47TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV48TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV41TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV42TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV49TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV50TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV43TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV44TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV56WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV65IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"av":"sPrefix"},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID","hsh":true},{"av":"A616SupplierDynamicFormId","fld":"SUPPLIERDYNAMICFORMID","hsh":true},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV5ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV61SupplierDynamicFormId_Selected","fld":"vSUPPLIERDYNAMICFORMID_SELECTED"},{"av":"AV62SupplierGenId_Selected","fld":"vSUPPLIERGENID_SELECTED"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtSupplierGenCompanyName_Visible","ctrl":"SUPPLIERGENCOMPANYNAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV17GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV18GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV16GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV19GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE","""{"handler":"E17BN2","iparms":[{"av":"Dvelop_confirmpanel_useractiondelete_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONDELETE","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"dynavSuppliergenid"},{"av":"AV58SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV57WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV63TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV64TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV47TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV48TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV41TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV42TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV49TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV50TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV43TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV44TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV56WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV65IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"av":"sPrefix"},{"av":"AV61SupplierDynamicFormId_Selected","fld":"vSUPPLIERDYNAMICFORMID_SELECTED"},{"av":"AV62SupplierGenId_Selected","fld":"vSUPPLIERGENID_SELECTED"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtSupplierGenCompanyName_Visible","ctrl":"SUPPLIERGENCOMPANYNAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV17GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV18GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV16GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV19GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("UCOPYTOLOCATION_MODAL.ONLOADCOMPONENT","""{"handler":"E18BN2","iparms":[]""");
         setEventMetadata("UCOPYTOLOCATION_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("'DOUSERACTIONINSERT'","""{"handler":"E20BN2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"dynavSuppliergenid"},{"av":"AV58SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV57WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV63TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV64TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV47TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV48TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV41TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV42TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV49TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV50TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV43TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV44TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV56WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV65IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"av":"sPrefix"}]""");
         setEventMetadata("'DOUSERACTIONINSERT'",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtSupplierGenCompanyName_Visible","ctrl":"SUPPLIERGENCOMPANYNAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV17GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV18GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV16GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV19GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("USERACTIONINSERT_MODAL.ONLOADCOMPONENT","""{"handler":"E19BN2","iparms":[{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"}]""");
         setEventMetadata("USERACTIONINSERT_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E14BN2","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VSUPPLIERGENID.CONTROLVALUECHANGED","""{"handler":"E21BN2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"dynavSuppliergenid"},{"av":"AV58SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV57WWPFormType","fld":"vWWPFORMTYPE","pic":"9"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV66Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV63TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV64TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV47TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV48TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV41TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV42TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV49TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV50TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV43TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV44TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV56WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV65IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"av":"sPrefix"}]""");
         setEventMetadata("VSUPPLIERGENID.CONTROLVALUECHANGED",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtSupplierGenCompanyName_Visible","ctrl":"SUPPLIERGENCOMPANYNAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV17GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV18GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV16GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV28IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV27IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV25IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV26IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV29IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV30IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV23IsAuthorized_UCopyToLocation","fld":"vISAUTHORIZED_UCOPYTOLOCATION","hsh":true},{"av":"AV24IsAuthorized_UDirectCopyToLocation","fld":"vISAUTHORIZED_UDIRECTCOPYTOLOCATION","hsh":true},{"av":"AV31IsAuthorized_UserActionInsert","fld":"vISAUTHORIZED_USERACTIONINSERT","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV19GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VALIDV_SUPPLIERGENID","""{"handler":"Validv_Suppliergenid","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENCOMPANYNAME","""{"handler":"Valid_Suppliergencompanyname","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENID","""{"handler":"Valid_Suppliergenid","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV13FilterFullText = "";
         AV58SupplierGenId = Guid.Empty;
         AV6ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV66Pgmname = "";
         AV63TFSupplierGenCompanyName = "";
         AV64TFSupplierGenCompanyName_Sel = "";
         AV47TFWWPFormTitle = "";
         AV48TFWWPFormTitle_Sel = "";
         AV41TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AV42TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV32ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV16GridAppliedFilters = "";
         AV9DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV10DDO_WWPFormDateAuxDate = DateTime.MinValue;
         AV12DDO_WWPFormDateAuxDateTo = DateTime.MinValue;
         AV19GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV61SupplierDynamicFormId_Selected = Guid.Empty;
         AV62SupplierGenId_Selected = Guid.Empty;
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
         AV11DDO_WWPFormDateAuxDateText = "";
         ucTfwwpformdate_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A44SupplierGenCompanyName = "";
         A616SupplierDynamicFormId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         A209WWPFormTitle = "";
         A208WWPFormReferenceName = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00BN2_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H00BN2_A44SupplierGenCompanyName = new string[] {""} ;
         lV63TFSupplierGenCompanyName = "";
         lV47TFWWPFormTitle = "";
         H00BN3_A240WWPFormType = new short[1] ;
         H00BN3_A207WWPFormVersionNumber = new short[1] ;
         H00BN3_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         H00BN3_A208WWPFormReferenceName = new string[] {""} ;
         H00BN3_A209WWPFormTitle = new string[] {""} ;
         H00BN3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H00BN3_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         H00BN3_A44SupplierGenCompanyName = new string[] {""} ;
         H00BN3_A206WWPFormId = new short[1] ;
         H00BN4_A240WWPFormType = new short[1] ;
         H00BN4_A207WWPFormVersionNumber = new short[1] ;
         H00BN4_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         H00BN4_A208WWPFormReferenceName = new string[] {""} ;
         H00BN4_A209WWPFormTitle = new string[] {""} ;
         H00BN4_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H00BN4_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         H00BN4_A44SupplierGenCompanyName = new string[] {""} ;
         H00BN4_A206WWPFormId = new short[1] ;
         AV15GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV14GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV55WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV8ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV34ManageFiltersXml = "";
         AV54UserCustomValue = "";
         AV7ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV60Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV59Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV20GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char4 = "";
         AV52TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV21HTTPRequest = new GxHttpRequest( context);
         AV53TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         ucUseractioninsert_modal = new GXUserControl();
         ucUcopytolocation_modal = new GXUserControl();
         ucDvelop_confirmpanel_useractiondelete = new GXUserControl();
         ucDvelop_confirmpanel_useractioncopy = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV57WWPFormType = "";
         sCtrlAV56WWPFormIsForDynamicValidations = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_dynamicformtrn_supplierdynamicform__default(),
            new Object[][] {
                new Object[] {
               H00BN2_A42SupplierGenId, H00BN2_A44SupplierGenCompanyName
               }
               , new Object[] {
               H00BN3_A240WWPFormType, H00BN3_A207WWPFormVersionNumber, H00BN3_A231WWPFormDate, H00BN3_A208WWPFormReferenceName, H00BN3_A209WWPFormTitle, H00BN3_A42SupplierGenId, H00BN3_A616SupplierDynamicFormId, H00BN3_A44SupplierGenCompanyName, H00BN3_A206WWPFormId
               }
               , new Object[] {
               H00BN4_A240WWPFormType, H00BN4_A207WWPFormVersionNumber, H00BN4_A231WWPFormDate, H00BN4_A208WWPFormReferenceName, H00BN4_A209WWPFormTitle, H00BN4_A42SupplierGenId, H00BN4_A616SupplierDynamicFormId, H00BN4_A44SupplierGenCompanyName, H00BN4_A206WWPFormId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV66Pgmname = "WP_DynamicFormTrn_SupplierDynamicForm";
         /* GeneXus formulas. */
         AV66Pgmname = "WP_DynamicFormTrn_SupplierDynamicForm";
      }

      private short AV57WWPFormType ;
      private short wcpOAV57WWPFormType ;
      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV35OrderedBy ;
      private short AV33ManageFiltersExecutionStep ;
      private short AV49TFWWPFormVersionNumber ;
      private short AV50TFWWPFormVersionNumber_To ;
      private short AV43TFWWPFormLatestVersionNumber ;
      private short AV44TFWWPFormLatestVersionNumber_To ;
      private short wbEnd ;
      private short wbStart ;
      private short A240WWPFormType ;
      private short nDraw ;
      private short nDoneStart ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short AV5ActionGroup ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short GXt_int1 ;
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
      private int edtSupplierGenCompanyName_Enabled ;
      private int edtSupplierDynamicFormId_Enabled ;
      private int edtSupplierGenId_Enabled ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int edtWWPFormReferenceName_Enabled ;
      private int edtWWPFormDate_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormLatestVersionNumber_Enabled ;
      private int edtSupplierGenCompanyName_Visible ;
      private int edtWWPFormTitle_Visible ;
      private int edtWWPFormDate_Visible ;
      private int edtWWPFormVersionNumber_Visible ;
      private int edtWWPFormLatestVersionNumber_Visible ;
      private int AV39PageToGo ;
      private int AV67GXV1 ;
      private int AV68GXV2 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV17GridCurrentPage ;
      private long AV18GridPageCount ;
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
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_43_idx="0001" ;
      private string AV66Pgmname ;
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
      private string Useractioninsert_modal_Width ;
      private string Useractioninsert_modal_Title ;
      private string Useractioninsert_modal_Confirmtype ;
      private string Useractioninsert_modal_Bodytype ;
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
      private string dynavSuppliergenid_Internalname ;
      private string dynavSuppliergenid_Jsonclick ;
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
      private string edtSupplierGenCompanyName_Internalname ;
      private string edtSupplierDynamicFormId_Internalname ;
      private string edtSupplierGenId_Internalname ;
      private string edtWWPFormId_Internalname ;
      private string edtWWPFormTitle_Internalname ;
      private string edtWWPFormReferenceName_Internalname ;
      private string edtWWPFormDate_Internalname ;
      private string edtWWPFormVersionNumber_Internalname ;
      private string edtWWPFormLatestVersionNumber_Internalname ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string cmbavActiongroup_Class ;
      private string edtSupplierGenCompanyName_Link ;
      private string GXt_char6 ;
      private string GXt_char4 ;
      private string tblTableuseractioninsert_modal_Internalname ;
      private string Useractioninsert_modal_Internalname ;
      private string tblTableucopytolocation_modal_Internalname ;
      private string Ucopytolocation_modal_Internalname ;
      private string tblTabledvelop_confirmpanel_useractiondelete_Internalname ;
      private string Dvelop_confirmpanel_useractiondelete_Internalname ;
      private string tblTabledvelop_confirmpanel_useractioncopy_Internalname ;
      private string Dvelop_confirmpanel_useractioncopy_Internalname ;
      private string sCtrlAV57WWPFormType ;
      private string sCtrlAV56WWPFormIsForDynamicValidations ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtSupplierGenCompanyName_Jsonclick ;
      private string edtSupplierDynamicFormId_Jsonclick ;
      private string edtSupplierGenId_Jsonclick ;
      private string edtWWPFormId_Jsonclick ;
      private string edtWWPFormTitle_Jsonclick ;
      private string edtWWPFormReferenceName_Jsonclick ;
      private string edtWWPFormDate_Jsonclick ;
      private string edtWWPFormVersionNumber_Jsonclick ;
      private string edtWWPFormLatestVersionNumber_Jsonclick ;
      private string GXCCtl ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV41TFWWPFormDate ;
      private DateTime AV42TFWWPFormDate_To ;
      private DateTime A231WWPFormDate ;
      private DateTime AV10DDO_WWPFormDateAuxDate ;
      private DateTime AV12DDO_WWPFormDateAuxDateTo ;
      private bool AV56WWPFormIsForDynamicValidations ;
      private bool wcpOAV56WWPFormIsForDynamicValidations ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV37OrderedDsc ;
      private bool AV28IsAuthorized_UserActionEdit ;
      private bool AV27IsAuthorized_UserActionDisplay ;
      private bool AV25IsAuthorized_UserActionCopy ;
      private bool AV26IsAuthorized_UserActionDelete ;
      private bool AV29IsAuthorized_UserActionFilledForms ;
      private bool AV30IsAuthorized_UserActionFillOutForm ;
      private bool AV23IsAuthorized_UCopyToLocation ;
      private bool AV24IsAuthorized_UDirectCopyToLocation ;
      private bool AV65IsAuthorized_SupplierGenCompanyName ;
      private bool AV31IsAuthorized_UserActionInsert ;
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
      private bool GXt_boolean2 ;
      private string AV8ColumnsSelectorXML ;
      private string AV34ManageFiltersXml ;
      private string AV54UserCustomValue ;
      private string AV13FilterFullText ;
      private string AV63TFSupplierGenCompanyName ;
      private string AV64TFSupplierGenCompanyName_Sel ;
      private string AV47TFWWPFormTitle ;
      private string AV48TFWWPFormTitle_Sel ;
      private string AV16GridAppliedFilters ;
      private string AV11DDO_WWPFormDateAuxDateText ;
      private string A44SupplierGenCompanyName ;
      private string A209WWPFormTitle ;
      private string A208WWPFormReferenceName ;
      private string lV63TFSupplierGenCompanyName ;
      private string lV47TFWWPFormTitle ;
      private Guid AV58SupplierGenId ;
      private Guid AV61SupplierDynamicFormId_Selected ;
      private Guid AV62SupplierGenId_Selected ;
      private Guid A616SupplierDynamicFormId ;
      private Guid A42SupplierGenId ;
      private IGxSession AV40Session ;
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
      private GXUserControl ucUseractioninsert_modal ;
      private GXUserControl ucUcopytolocation_modal ;
      private GXUserControl ucDvelop_confirmpanel_useractiondelete ;
      private GXUserControl ucDvelop_confirmpanel_useractioncopy ;
      private GXWebForm Form ;
      private GxHttpRequest AV21HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSuppliergenid ;
      private GXCombobox cmbavActiongroup ;
      private GXCombobox cmbWWPFormType ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV6ColumnsSelector ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV32ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV9DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV19GridState ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00BN2_A42SupplierGenId ;
      private string[] H00BN2_A44SupplierGenCompanyName ;
      private short[] H00BN3_A240WWPFormType ;
      private short[] H00BN3_A207WWPFormVersionNumber ;
      private DateTime[] H00BN3_A231WWPFormDate ;
      private string[] H00BN3_A208WWPFormReferenceName ;
      private string[] H00BN3_A209WWPFormTitle ;
      private Guid[] H00BN3_A42SupplierGenId ;
      private Guid[] H00BN3_A616SupplierDynamicFormId ;
      private string[] H00BN3_A44SupplierGenCompanyName ;
      private short[] H00BN3_A206WWPFormId ;
      private short[] H00BN4_A240WWPFormType ;
      private short[] H00BN4_A207WWPFormVersionNumber ;
      private DateTime[] H00BN4_A231WWPFormDate ;
      private string[] H00BN4_A208WWPFormReferenceName ;
      private string[] H00BN4_A209WWPFormTitle ;
      private Guid[] H00BN4_A42SupplierGenId ;
      private Guid[] H00BN4_A616SupplierDynamicFormId ;
      private string[] H00BN4_A44SupplierGenCompanyName ;
      private short[] H00BN4_A206WWPFormId ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV15GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV14GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV55WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV7ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV60Messages ;
      private GeneXus.Utils.SdtMessages_Message AV59Message ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV20GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV52TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV53TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_dynamicformtrn_supplierdynamicform__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00BN3( IGxContext context ,
                                             string AV64TFSupplierGenCompanyName_Sel ,
                                             string AV63TFSupplierGenCompanyName ,
                                             string AV48TFWWPFormTitle_Sel ,
                                             string AV47TFWWPFormTitle ,
                                             DateTime AV41TFWWPFormDate ,
                                             DateTime AV42TFWWPFormDate_To ,
                                             short AV49TFWWPFormVersionNumber ,
                                             short AV50TFWWPFormVersionNumber_To ,
                                             Guid AV58SupplierGenId ,
                                             string A44SupplierGenCompanyName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             short A207WWPFormVersionNumber ,
                                             Guid A42SupplierGenId ,
                                             short AV35OrderedBy ,
                                             bool AV37OrderedDsc ,
                                             short A240WWPFormType ,
                                             short AV57WWPFormType ,
                                             string AV13FilterFullText ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short AV43TFWWPFormLatestVersionNumber ,
                                             short AV44TFWWPFormLatestVersionNumber_To )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[10];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T3.WWPFormType, T1.WWPFormVersionNumber, T3.WWPFormDate, T3.WWPFormReferenceName, T3.WWPFormTitle, T1.SupplierGenId, T1.SupplierDynamicFormId, T2.SupplierGenCompanyName, T1.WWPFormId FROM ((Trn_SupplierDynamicForm T1 INNER JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = T1.SupplierGenId) INNER JOIN WWP_Form T3 ON T3.WWPFormId = T1.WWPFormId AND T3.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T3.WWPFormType = :AV57WWPFormType)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFSupplierGenCompanyName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFSupplierGenCompanyName)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName like :lV63TFSupplierGenCompanyName)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFSupplierGenCompanyName_Sel)) && ! ( StringUtil.StrCmp(AV64TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName = ( :AV64TFSupplierGenCompanyName_Sel))");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( StringUtil.StrCmp(AV64TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T3.WWPFormTitle like :lV47TFWWPFormTitle)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV48TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.WWPFormTitle = ( :AV48TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( StringUtil.StrCmp(AV48TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV41TFWWPFormDate) )
         {
            AddWhere(sWhereString, "(T3.WWPFormDate >= :AV41TFWWPFormDate)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV42TFWWPFormDate_To) )
         {
            AddWhere(sWhereString, "(T3.WWPFormDate <= :AV42TFWWPFormDate_To)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (0==AV49TFWWPFormVersionNumber) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV49TFWWPFormVersionNumber)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! (0==AV50TFWWPFormVersionNumber_To) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV50TFWWPFormVersionNumber_To)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! (Guid.Empty==AV58SupplierGenId) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenId = :AV58SupplierGenId)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV35OrderedBy == 1 ) && ! AV37OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.WWPFormType, T3.WWPFormTitle, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 1 ) && ( AV37OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.WWPFormType DESC, T3.WWPFormTitle DESC, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 2 ) && ! AV37OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.WWPFormType, T2.SupplierGenCompanyName, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 2 ) && ( AV37OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.WWPFormType DESC, T2.SupplierGenCompanyName DESC, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 3 ) && ! AV37OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.WWPFormType, T3.WWPFormDate, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 3 ) && ( AV37OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.WWPFormType DESC, T3.WWPFormDate DESC, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 4 ) && ! AV37OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.WWPFormType, T1.WWPFormVersionNumber, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 4 ) && ( AV37OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.WWPFormType DESC, T1.WWPFormVersionNumber DESC, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H00BN4( IGxContext context ,
                                             string AV64TFSupplierGenCompanyName_Sel ,
                                             string AV63TFSupplierGenCompanyName ,
                                             string AV48TFWWPFormTitle_Sel ,
                                             string AV47TFWWPFormTitle ,
                                             DateTime AV41TFWWPFormDate ,
                                             DateTime AV42TFWWPFormDate_To ,
                                             short AV49TFWWPFormVersionNumber ,
                                             short AV50TFWWPFormVersionNumber_To ,
                                             Guid AV58SupplierGenId ,
                                             string A44SupplierGenCompanyName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             short A207WWPFormVersionNumber ,
                                             Guid A42SupplierGenId ,
                                             short AV35OrderedBy ,
                                             bool AV37OrderedDsc ,
                                             short A240WWPFormType ,
                                             short AV57WWPFormType ,
                                             string AV13FilterFullText ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short AV43TFWWPFormLatestVersionNumber ,
                                             short AV44TFWWPFormLatestVersionNumber_To )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[10];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T3.WWPFormType, T1.WWPFormVersionNumber, T3.WWPFormDate, T3.WWPFormReferenceName, T3.WWPFormTitle, T1.SupplierGenId, T1.SupplierDynamicFormId, T2.SupplierGenCompanyName, T1.WWPFormId FROM ((Trn_SupplierDynamicForm T1 INNER JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = T1.SupplierGenId) INNER JOIN WWP_Form T3 ON T3.WWPFormId = T1.WWPFormId AND T3.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T3.WWPFormType = :AV57WWPFormType)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFSupplierGenCompanyName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFSupplierGenCompanyName)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName like :lV63TFSupplierGenCompanyName)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFSupplierGenCompanyName_Sel)) && ! ( StringUtil.StrCmp(AV64TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName = ( :AV64TFSupplierGenCompanyName_Sel))");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( StringUtil.StrCmp(AV64TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T3.WWPFormTitle like :lV47TFWWPFormTitle)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV48TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.WWPFormTitle = ( :AV48TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( StringUtil.StrCmp(AV48TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV41TFWWPFormDate) )
         {
            AddWhere(sWhereString, "(T3.WWPFormDate >= :AV41TFWWPFormDate)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV42TFWWPFormDate_To) )
         {
            AddWhere(sWhereString, "(T3.WWPFormDate <= :AV42TFWWPFormDate_To)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! (0==AV49TFWWPFormVersionNumber) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV49TFWWPFormVersionNumber)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! (0==AV50TFWWPFormVersionNumber_To) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV50TFWWPFormVersionNumber_To)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! (Guid.Empty==AV58SupplierGenId) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenId = :AV58SupplierGenId)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV35OrderedBy == 1 ) && ! AV37OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.WWPFormType, T3.WWPFormTitle, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 1 ) && ( AV37OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.WWPFormType DESC, T3.WWPFormTitle DESC, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 2 ) && ! AV37OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.WWPFormType, T2.SupplierGenCompanyName, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 2 ) && ( AV37OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.WWPFormType DESC, T2.SupplierGenCompanyName DESC, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 3 ) && ! AV37OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.WWPFormType, T3.WWPFormDate, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 3 ) && ( AV37OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.WWPFormType DESC, T3.WWPFormDate DESC, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 4 ) && ! AV37OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.WWPFormType, T1.WWPFormVersionNumber, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
         else if ( ( AV35OrderedBy == 4 ) && ( AV37OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.WWPFormType DESC, T1.WWPFormVersionNumber DESC, T1.SupplierDynamicFormId, T1.SupplierGenId";
         }
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
                     return conditional_H00BN3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (Guid)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (short)dynConstraints[12] , (Guid)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] );
               case 2 :
                     return conditional_H00BN4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (Guid)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (short)dynConstraints[12] , (Guid)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] );
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
          Object[] prmH00BN2;
          prmH00BN2 = new Object[] {
          };
          Object[] prmH00BN3;
          prmH00BN3 = new Object[] {
          new ParDef("AV57WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV63TFSupplierGenCompanyName",GXType.VarChar,100,0) ,
          new ParDef("AV64TFSupplierGenCompanyName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV47TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV48TFWWPFormTitle_Sel",GXType.VarChar,100,0) ,
          new ParDef("AV41TFWWPFormDate",GXType.DateTime,8,5) ,
          new ParDef("AV42TFWWPFormDate_To",GXType.DateTime,8,5) ,
          new ParDef("AV49TFWWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV50TFWWPFormVersionNumber_To",GXType.Int16,4,0) ,
          new ParDef("AV58SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH00BN4;
          prmH00BN4 = new Object[] {
          new ParDef("AV57WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV63TFSupplierGenCompanyName",GXType.VarChar,100,0) ,
          new ParDef("AV64TFSupplierGenCompanyName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV47TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV48TFWWPFormTitle_Sel",GXType.VarChar,100,0) ,
          new ParDef("AV41TFWWPFormDate",GXType.DateTime,8,5) ,
          new ParDef("AV42TFWWPFormDate_To",GXType.DateTime,8,5) ,
          new ParDef("AV49TFWWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV50TFWWPFormVersionNumber_To",GXType.Int16,4,0) ,
          new ParDef("AV58SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00BN2", "SELECT SupplierGenId, SupplierGenCompanyName FROM Trn_SupplierGen ORDER BY SupplierGenCompanyName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BN2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BN3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BN3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BN4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BN4,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                return;
       }
    }

 }

}
