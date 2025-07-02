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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_addelement : GXWebComponent
   {
      public wwp_df_addelement( )
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

      public wwp_df_addelement( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPDynamicFormMode ,
                           short aP1_WWPFormElementParentId ,
                           short aP2_WWPFormElementId ,
                           short aP3_SessionId )
      {
         this.AV54WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV61WWPFormElementParentId = aP1_WWPFormElementParentId;
         this.AV60WWPFormElementId = aP2_WWPFormElementId;
         this.AV33SessionId = aP3_SessionId;
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
         radavFormtype = new GXRadio();
         cmbavWwpformelementtype = new GXCombobox();
         cmbavWwpformelementcaption = new GXCombobox();
         cmbavControl = new GXCombobox();
         radavText_format = new GXRadio();
         radavTextarea_format = new GXRadio();
         chkavDate_includetime = new GXCheckbox();
         chkavWwp_df_datemetadata_isdefaultvaluetoday = new GXCheckbox();
         chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection = new GXCheckbox();
         cmbavPredoptions_type = new GXCombobox();
         radavPredoptions_values = new GXRadio();
         chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue = new GXCheckbox();
         chkavWwp_df_containermetadata_collapsable = new GXCheckbox();
         chkavWwp_df_containermetadata_collapsedbydefault = new GXCheckbox();
         radavFile_format = new GXRadio();
         radavRadio_direction = new GXRadio();
         chkavWwp_df_booleanmetadata_defaultvalue = new GXCheckbox();
         cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype = new GXCombobox();
         cmbavWwp_df_elementsrepeatermetadata_repetitionstype = new GXCombobox();
         chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel = new GXCheckbox();
         cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid = new GXCombobox();
         cmbavWwp_df_labelmetadata_style = new GXCombobox();
         chkavWwpformelementexcludefromexport = new GXCheckbox();
         chkavIsrequired = new GXCheckbox();
         cmbavGridactiongroup1 = new GXCombobox();
         cmbavWwpform_wwpformresume = new GXCombobox();
         cmbavWwp_df_containermetadata_style = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
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
                  AV54WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV54WWPDynamicFormMode", AV54WWPDynamicFormMode);
                  AV61WWPFormElementParentId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementParentId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV61WWPFormElementParentId", StringUtil.LTrimStr( (decimal)(AV61WWPFormElementParentId), 4, 0));
                  AV60WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV60WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV60WWPFormElementId), 4, 0));
                  AV33SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV33SessionId", StringUtil.LTrimStr( (decimal)(AV33SessionId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV54WWPDynamicFormMode,(short)AV61WWPFormElementParentId,(short)AV60WWPFormElementId,(short)AV33SessionId});
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
                  gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridvalidations") == 0 )
               {
                  gxnrGridvalidations_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridvalidations") == 0 )
               {
                  gxgrGridvalidations_refresh_invoke( ) ;
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

      protected void gxnrGridvalidations_newrow_invoke( )
      {
         nRC_GXsfl_270 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_270"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_270_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_270_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_270_idx = GetPar( "sGXsfl_270_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridvalidations_newrow( ) ;
         /* End function gxnrGridvalidations_newrow_invoke */
      }

      protected void gxgrGridvalidations_refresh_invoke( )
      {
         subGridvalidations_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridvalidations_Rows"), "."), 18, MidpointRounding.ToEven));
         cmbavWwpformelementtype.FromJSonString( GetNextPar( ));
         AV64WWPFormElementType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementType"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV39Validations);
         AV18FormType = GetPar( "FormType");
         AV35Text_Format = GetPar( "Text_Format");
         AV36TextArea_Format = GetPar( "TextArea_Format");
         AV14Date_IncludeTime = StringUtil.StrToBool( GetPar( "Date_IncludeTime"));
         AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday = StringUtil.StrToBool( GetNextPar( ));
         AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection = StringUtil.StrToBool( GetNextPar( ));
         AV31PredOptions_Values = GetPar( "PredOptions_Values");
         AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue = StringUtil.StrToBool( GetNextPar( ));
         AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable = StringUtil.StrToBool( GetNextPar( ));
         AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault = StringUtil.StrToBool( GetNextPar( ));
         AV17File_Format = GetPar( "File_Format");
         AV32Radio_Direction = GetPar( "Radio_Direction");
         AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue = StringUtil.StrToBool( GetNextPar( ));
         AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel = StringUtil.StrToBool( GetNextPar( ));
         AV59WWPFormElementExcludeFromExport = StringUtil.StrToBool( GetPar( "WWPFormElementExcludeFromExport"));
         AV24IsRequired = StringUtil.StrToBool( GetPar( "IsRequired"));
         AV58WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementDataType"), "."), 18, MidpointRounding.ToEven));
         AV22IsFormSettings = StringUtil.StrToBool( GetPar( "IsFormSettings"));
         AV65WWPFormTitle = GetPar( "WWPFormTitle");
         AV28ParentIsGridMultipleData = StringUtil.StrToBool( GetPar( "ParentIsGridMultipleData"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridvalidations_refresh_invoke */
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
            PA272( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavValidations__messagewithtags_Enabled = 0;
               AssignProp(sPrefix, false, edtavValidations__messagewithtags_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValidations__messagewithtags_Enabled), 5, 0), !bGXsfl_270_Refreshing);
               edtavValidations__message_Enabled = 0;
               AssignProp(sPrefix, false, edtavValidations__message_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValidations__message_Enabled), 5, 0), !bGXsfl_270_Refreshing);
               WS272( ) ;
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
            context.SendWebValue( context.GetMessage( "Element settings", "")) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Suggest/SuggestRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_addelement.aspx"+UrlEncode(StringUtil.RTrim(AV54WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV61WWPFormElementParentId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV60WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV33SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_addelement.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV58WWPFormElementDataType), "Z9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFORMSETTINGS", AV22IsFormSettings);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFORMSETTINGS", GetSecureSignedToken( sPrefix, AV22IsFormSettings, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMTITLE", AV65WWPFormTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV65WWPFormTitle, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV28ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV28ParentIsGridMultipleData, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wwpform", AV55WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wwpform", AV55WWPForm);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wwp_df_datemetadata", AV48WWP_DF_DateMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wwp_df_datemetadata", AV48WWP_DF_DateMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wwp_df_charmetadata", AV46WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wwp_df_charmetadata", AV46WWP_DF_CharMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wwp_df_containermetadata", AV47WWP_DF_ContainerMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wwp_df_containermetadata", AV47WWP_DF_ContainerMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wwp_df_numericmetadata", AV52WWP_DF_NumericMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wwp_df_numericmetadata", AV52WWP_DF_NumericMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wwp_df_booleanmetadata", AV45WWP_DF_BooleanMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wwp_df_booleanmetadata", AV45WWP_DF_BooleanMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wwp_df_stepmetadata", AV53WWP_DF_StepMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wwp_df_stepmetadata", AV53WWP_DF_StepMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wwp_df_elementsrepeatermetadata", AV49WWP_DF_ElementsRepeaterMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wwp_df_elementsrepeatermetadata", AV49WWP_DF_ElementsRepeaterMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wwp_df_labelmetadata", AV51WWP_DF_LabelMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wwp_df_labelmetadata", AV51WWP_DF_LabelMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Validations", AV39Validations);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Validations", AV39Validations);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_270", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_270), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV54WWPDynamicFormMode", StringUtil.RTrim( wcpOAV54WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV61WWPFormElementParentId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV61WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV60WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV60WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV33SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV33SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVALIDATIONS", AV39Validations);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVALIDATIONS", AV39Validations);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV54WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTPARENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV58WWPFormElementDataType), "Z9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vVALIDATIONJSON", AV38ValidationJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCONDITIONERROR", AV9ConditionError);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vEXECUTECONDITIONTOTEST", AV16ExecuteConditionToTest);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vALLREFERENCEIDS", AV5AllReferenceIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vALLREFERENCEIDS", AV5AllReferenceIds);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVISIBLECONDITIONEXPRESSION", AV44VisibleConditionExpression);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVISIBLECONDITIONEXPRESSION", AV44VisibleConditionExpression);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTVALIDATIONINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13CurrentValidationIndex), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV7CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFORMSETTINGS", AV22IsFormSettings);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFORMSETTINGS", GetSecureSignedToken( sPrefix, AV22IsFormSettings, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMTITLE", AV65WWPFormTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV65WWPFormTitle, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV28ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV28ParentIsGridMultipleData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDVALIDATIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDVALIDATIONS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDVALIDATIONS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDVALIDATIONS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORM", AV55WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORM", AV55WWPForm);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_DATEMETADATA", AV48WWP_DF_DateMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_DATEMETADATA", AV48WWP_DF_DateMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV46WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV46WWP_DF_CharMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CONTAINERMETADATA", AV47WWP_DF_ContainerMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CONTAINERMETADATA", AV47WWP_DF_ContainerMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_NUMERICMETADATA", AV52WWP_DF_NumericMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_NUMERICMETADATA", AV52WWP_DF_NumericMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_BOOLEANMETADATA", AV45WWP_DF_BooleanMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_BOOLEANMETADATA", AV45WWP_DF_BooleanMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_STEPMETADATA", AV53WWP_DF_StepMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_STEPMETADATA", AV53WWP_DF_StepMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV49WWP_DF_ElementsRepeaterMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA", AV49WWP_DF_ElementsRepeaterMetadata);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_LABELMETADATA", AV51WWP_DF_LabelMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_LABELMETADATA", AV51WWP_DF_LabelMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDVALIDATIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"UPDATEVALIDATION_MODAL_Result", StringUtil.RTrim( Updatevalidation_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"ADDVALIDATION_MODAL_Result", StringUtil.RTrim( Addvalidation_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"UPDATEVALIDATION_MODAL_Result", StringUtil.RTrim( Updatevalidation_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"ADDVALIDATION_MODAL_Result", StringUtil.RTrim( Addvalidation_modal_Result));
      }

      protected void RenderHtmlCloseForm272( )
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
         return "WorkWithPlus.DynamicForms.WWP_DF_AddElement" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Element settings", "") ;
      }

      protected void WB270( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_addelement.aspx");
               context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
               context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Suggest/SuggestRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs1.SetProperty("PageCount", Gxuitabspanel_tabs1_Pagecount);
            ucGxuitabspanel_tabs1.SetProperty("Class", Gxuitabspanel_tabs1_Class);
            ucGxuitabspanel_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_tabs1_Historymanagement);
            ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, sPrefix+"GXUITABSPANEL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab1_title_Internalname, context.GetMessage( "WWP_DF_GeneralInformation", ""), "", "", lblTab1_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab1") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFormtype_cell_Internalname, 1, 0, "px", 0, "px", divFormtype_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", radavFormtype.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavFormtype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "WWP_DF_FormType", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavFormtype, radavFormtype_Internalname, StringUtil.RTrim( AV18FormType), "", radavFormtype.Visible, 1, 0, 0, StyleString, ClassString, "", "", 0, radavFormtype_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwpform_wwpformtitle_cell_Internalname, 1, 0, "px", 0, "px", divWwpform_wwpformtitle_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwpform_wwpformtitle_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwpform_wwpformtitle_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwpform_wwpformtitle_Internalname, context.GetMessage( "WWP_DF_Title", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwpform_wwpformtitle_Internalname, AV55WWPForm.gxTpr_Wwpformtitle, StringUtil.RTrim( context.localUtil.Format( AV55WWPForm.gxTpr_Wwpformtitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwpform_wwpformtitle_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwpform_wwpformtitle_Visible, edtavWwpform_wwpformtitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwpform_wwpformreferencename_cell_Internalname, 1, 0, "px", 0, "px", divWwpform_wwpformreferencename_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwpform_wwpformreferencename_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwpform_wwpformreferencename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwpform_wwpformreferencename_Internalname, context.GetMessage( "WWP_DF_ReferenceName", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwpform_wwpformreferencename_Internalname, AV55WWPForm.gxTpr_Wwpformreferencename, StringUtil.RTrim( context.localUtil.Format( AV55WWPForm.gxTpr_Wwpformreferencename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwpform_wwpformreferencename_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwpform_wwpformreferencename_Visible, edtavWwpform_wwpformreferencename_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwpform_wwpformresumemessage_cell_Internalname, 1, 0, "px", 0, "px", divWwpform_wwpformresumemessage_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwpform_wwpformresumemessage_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwpform_wwpformresumemessage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwpform_wwpformresumemessage_Internalname, context.GetMessage( "WWP_DF_ResumeMessage", ""), " SmallTextAreaLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "SmallTextArea";
            StyleString = "";
            ClassString = "SmallTextArea";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavWwpform_wwpformresumemessage_Internalname, AV55WWPForm.gxTpr_Wwpformresumemessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", 0, edtavWwpform_wwpformresumemessage_Visible, edtavWwpform_wwpformresumemessage_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwpformelementtype_cell_Internalname, 1, 0, "px", 0, "px", divWwpformelementtype_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavWwpformelementtype.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavWwpformelementtype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWwpformelementtype_Internalname, context.GetMessage( "WWP_DF_ElementType", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWwpformelementtype, cmbavWwpformelementtype_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV64WWPFormElementType), 1, 0)), 1, cmbavWwpformelementtype_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVWWPFORMELEMENTTYPE.CLICK."+"'", "int", "", cmbavWwpformelementtype.Visible, cmbavWwpformelementtype.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            cmbavWwpformelementtype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV64WWPFormElementType), 1, 0));
            AssignProp(sPrefix, false, cmbavWwpformelementtype_Internalname, "Values", (string)(cmbavWwpformelementtype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwpformelementcaption_cell_Internalname, 1, 0, "px", 0, "px", divWwpformelementcaption_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavWwpformelementcaption.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavWwpformelementcaption_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWwpformelementcaption_Internalname, context.GetMessage( "WWP_DF_TitleType", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWwpformelementcaption, cmbavWwpformelementcaption_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV57WWPFormElementCaption), 1, 0)), 1, cmbavWwpformelementcaption_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavWwpformelementcaption.Visible, cmbavWwpformelementcaption.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            cmbavWwpformelementcaption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57WWPFormElementCaption), 1, 0));
            AssignProp(sPrefix, false, cmbavWwpformelementcaption_Internalname, "Values", (string)(cmbavWwpformelementcaption.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwpformelementtitle_cell_Internalname, 1, 0, "px", 0, "px", divWwpformelementtitle_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwpformelementtitle_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwpformelementtitle_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwpformelementtitle_Internalname, context.GetMessage( "WWP_DF_Title", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavWwpformelementtitle_Internalname, AV63WWPFormElementTitle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", 0, edtavWwpformelementtitle_Visible, edtavWwpformelementtitle_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwpformelementreferenceidmt_cell_Internalname, 1, 0, "px", 0, "px", divWwpformelementreferenceidmt_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedwwpformelementreferenceid_Internalname, divTablesplittedwwpformelementreferenceid_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTextblockwwpformelementreferenceid_cell_Internalname, 1, 0, "px", 0, "px", divTextblockwwpformelementreferenceid_cell_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockwwpformelementreferenceid_Internalname, context.GetMessage( "WWP_DF_ReferenceId", ""), "", "", lblTextblockwwpformelementreferenceid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_60_272( true) ;
         }
         else
         {
            wb_table1_60_272( false) ;
         }
         return  ;
      }

      protected void wb_table1_60_272e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divControl_cell_Internalname, 1, 0, "px", 0, "px", divControl_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavControl.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavControl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavControl_Internalname, context.GetMessage( "WWP_DF_Control", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavControl, cmbavControl_Internalname, StringUtil.RTrim( AV10Control), 1, cmbavControl_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVCONTROL.CLICK."+"'", "svchar", "", cmbavControl.Visible, cmbavControl.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            cmbavControl.CurrentValue = StringUtil.RTrim( AV10Control);
            AssignProp(sPrefix, false, cmbavControl_Internalname, "Values", (string)(cmbavControl.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divText_format_cell_Internalname, 1, 0, "px", 0, "px", divText_format_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavText_format_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "WWP_DF_Format", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavText_format, radavText_format_Internalname, StringUtil.RTrim( AV35Text_Format), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavText_format_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTextarea_format_cell_Internalname, 1, 0, "px", 0, "px", divTextarea_format_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavTextarea_format_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "WWP_DF_Format", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavTextarea_format, radavTextarea_format_Internalname, StringUtil.RTrim( AV36TextArea_Format), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavTextarea_format_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDate_includetime_cell_Internalname, 1, 0, "px", 0, "px", divDate_includetime_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavDate_includetime.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavDate_includetime_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDate_includetime_Internalname, context.GetMessage( "WWP_DF_IncludeTime", ""), " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDate_includetime_Internalname, StringUtil.BoolToStr( AV14Date_IncludeTime), "", context.GetMessage( "WWP_DF_IncludeTime", ""), chkavDate_includetime.Visible, chkavDate_includetime.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,86);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_datemetadata_isdefaultvaluetoday_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavWwp_df_datemetadata_isdefaultvaluetoday.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavWwp_df_datemetadata_isdefaultvaluetoday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavWwp_df_datemetadata_isdefaultvaluetoday_Internalname, chkavWwp_df_datemetadata_isdefaultvaluetoday.Caption, " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavWwp_df_datemetadata_isdefaultvaluetoday_Internalname, StringUtil.BoolToStr( AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday), "", chkavWwp_df_datemetadata_isdefaultvaluetoday.Caption, chkavWwp_df_datemetadata_isdefaultvaluetoday.Visible, chkavWwp_df_datemetadata_isdefaultvaluetoday.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(91, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,91);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection_Internalname, context.GetMessage( "WWP_DF_AllowMultipleSelection", ""), " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection_Internalname, StringUtil.BoolToStr( AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection), "", context.GetMessage( "WWP_DF_AllowMultipleSelection", ""), chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.Visible, chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,96);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPredoptions_type_cell_Internalname, 1, 0, "px", 0, "px", divPredoptions_type_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavPredoptions_type.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavPredoptions_type_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPredoptions_type_Internalname, context.GetMessage( "WWP_DF_ControlType", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPredoptions_type, cmbavPredoptions_type_Internalname, StringUtil.RTrim( AV30PredOptions_Type), 1, cmbavPredoptions_type_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVPREDOPTIONS_TYPE.CLICK."+"'", "svchar", "", cmbavPredoptions_type.Visible, cmbavPredoptions_type.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "", true, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
            AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", (string)(cmbavPredoptions_type.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPredoptions_values_cell_Internalname, 1, 0, "px", 0, "px", divPredoptions_values_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavPredoptions_values_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "WWP_DF_OptionsType", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavPredoptions_values, radavPredoptions_values_Internalname, StringUtil.RTrim( AV31PredOptions_Values), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavPredoptions_values_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Internalname, context.GetMessage( "WWP_DF_ServiceURL", ""), " SmallTextAreaLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "SmallTextArea";
            StyleString = "";
            ClassString = "SmallTextArea";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Internalname, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Dynamic.gxTpr_Getoptionsservice, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", 0, edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Visible, edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", 1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPredoptions_options_cell_Internalname, 1, 0, "px", 0, "px", divPredoptions_options_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavPredoptions_options_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPredoptions_options_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPredoptions_options_Internalname, context.GetMessage( "WWP_DF_Options", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavPredoptions_options_Internalname, AV29PredOptions_Options, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", 0, edtavPredoptions_options_Visible, edtavPredoptions_options_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", context.GetMessage( "Include one option per line", ""), -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_Internalname, context.GetMessage( "WWP_DF_IncludeEmptyValue", ""), " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_Internalname, StringUtil.BoolToStr( AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue), "", context.GetMessage( "WWP_DF_IncludeEmptyValue", ""), chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Visible, chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,121);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Internalname, context.GetMessage( "WWP_DF_EmptyText", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Internalname, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Emptytext, StringUtil.RTrim( context.localUtil.Format( AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Emptytext, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Visible, edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_charmetadata_length_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_charmetadata_length_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwp_df_charmetadata_length_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwp_df_charmetadata_length_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwp_df_charmetadata_length_Internalname, context.GetMessage( "WWP_DF_Lenght", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwp_df_charmetadata_length_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46WWP_DF_CharMetadata.gxTpr_Length), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavWwp_df_charmetadata_length_Enabled!=0) ? context.localUtil.Format( (decimal)(AV46WWP_DF_CharMetadata.gxTpr_Length), "ZZZ9") : context.localUtil.Format( (decimal)(AV46WWP_DF_CharMetadata.gxTpr_Length), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,131);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwp_df_charmetadata_length_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwp_df_charmetadata_length_Visible, edtavWwp_df_charmetadata_length_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_charmetadata_defaultvalue_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_charmetadata_defaultvalue_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwp_df_charmetadata_defaultvalue_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwp_df_charmetadata_defaultvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwp_df_charmetadata_defaultvalue_Internalname, context.GetMessage( "WWP_DF_DefaultValue", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwp_df_charmetadata_defaultvalue_Internalname, AV46WWP_DF_CharMetadata.gxTpr_Defaultvalue, StringUtil.RTrim( context.localUtil.Format( AV46WWP_DF_CharMetadata.gxTpr_Defaultvalue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwp_df_charmetadata_defaultvalue_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwp_df_charmetadata_defaultvalue_Visible, edtavWwp_df_charmetadata_defaultvalue_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_containermetadata_collapsable_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_containermetadata_collapsable_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavWwp_df_containermetadata_collapsable.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavWwp_df_containermetadata_collapsable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavWwp_df_containermetadata_collapsable_Internalname, context.GetMessage( "WWP_DF_Collapsable", ""), " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavWwp_df_containermetadata_collapsable_Internalname, StringUtil.BoolToStr( AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable), "", context.GetMessage( "WWP_DF_Collapsable", ""), chkavWwp_df_containermetadata_collapsable.Visible, chkavWwp_df_containermetadata_collapsable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,141);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_containermetadata_collapsedbydefault_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_containermetadata_collapsedbydefault_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavWwp_df_containermetadata_collapsedbydefault.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavWwp_df_containermetadata_collapsedbydefault_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavWwp_df_containermetadata_collapsedbydefault_Internalname, context.GetMessage( "WWP_DF_CollapsedByDefault", ""), " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavWwp_df_containermetadata_collapsedbydefault_Internalname, StringUtil.BoolToStr( AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault), "", context.GetMessage( "WWP_DF_CollapsedByDefault", ""), chkavWwp_df_containermetadata_collapsedbydefault.Visible, chkavWwp_df_containermetadata_collapsedbydefault.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(146, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,146);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFile_format_cell_Internalname, 1, 0, "px", 0, "px", divFile_format_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavFile_format_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "WWP_DF_Format", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavFile_format, radavFile_format_Internalname, StringUtil.RTrim( AV17File_Format), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavFile_format_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_numericmetadata_length_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_numericmetadata_length_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwp_df_numericmetadata_length_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwp_df_numericmetadata_length_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwp_df_numericmetadata_length_Internalname, context.GetMessage( "WWP_DF_Lenght", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwp_df_numericmetadata_length_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52WWP_DF_NumericMetadata.gxTpr_Length), 2, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavWwp_df_numericmetadata_length_Enabled!=0) ? context.localUtil.Format( (decimal)(AV52WWP_DF_NumericMetadata.gxTpr_Length), "Z9") : context.localUtil.Format( (decimal)(AV52WWP_DF_NumericMetadata.gxTpr_Length), "Z9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,156);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwp_df_numericmetadata_length_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwp_df_numericmetadata_length_Visible, edtavWwp_df_numericmetadata_length_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_numericmetadata_decimals_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_numericmetadata_decimals_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwp_df_numericmetadata_decimals_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwp_df_numericmetadata_decimals_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwp_df_numericmetadata_decimals_Internalname, context.GetMessage( "WWP_DF_Decimals", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwp_df_numericmetadata_decimals_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52WWP_DF_NumericMetadata.gxTpr_Decimals), 1, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavWwp_df_numericmetadata_decimals_Enabled!=0) ? context.localUtil.Format( (decimal)(AV52WWP_DF_NumericMetadata.gxTpr_Decimals), "9") : context.localUtil.Format( (decimal)(AV52WWP_DF_NumericMetadata.gxTpr_Decimals), "9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,161);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwp_df_numericmetadata_decimals_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwp_df_numericmetadata_decimals_Visible, edtavWwp_df_numericmetadata_decimals_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_numericmetadata_defaultvalue_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_numericmetadata_defaultvalue_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwp_df_numericmetadata_defaultvalue_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwp_df_numericmetadata_defaultvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwp_df_numericmetadata_defaultvalue_Internalname, context.GetMessage( "WWP_DF_DefaultValue", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwp_df_numericmetadata_defaultvalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV52WWP_DF_NumericMetadata.gxTpr_Defaultvalue, 18, 5, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavWwp_df_numericmetadata_defaultvalue_Enabled!=0) ? context.localUtil.Format( AV52WWP_DF_NumericMetadata.gxTpr_Defaultvalue, "ZZZZZZZZZZZ9.99999") : context.localUtil.Format( AV52WWP_DF_NumericMetadata.gxTpr_Defaultvalue, "ZZZZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'5');"+";gx.evt.onblur(this,166);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwp_df_numericmetadata_defaultvalue_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwp_df_numericmetadata_defaultvalue_Visible, edtavWwp_df_numericmetadata_defaultvalue_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRadio_direction_cell_Internalname, 1, 0, "px", 0, "px", divRadio_direction_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavRadio_direction_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "WWP_DF_Format", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavRadio_direction, radavRadio_direction_Internalname, StringUtil.RTrim( AV32Radio_Direction), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavRadio_direction_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,171);\"", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_booleanmetadata_checkbox_controltitle_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwp_df_booleanmetadata_checkbox_controltitle_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwp_df_booleanmetadata_checkbox_controltitle_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwp_df_booleanmetadata_checkbox_controltitle_Internalname, context.GetMessage( "WWP_DF_CheckboxText", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwp_df_booleanmetadata_checkbox_controltitle_Internalname, AV45WWP_DF_BooleanMetadata.gxTpr_Checkbox.gxTpr_Controltitle, StringUtil.RTrim( context.localUtil.Format( AV45WWP_DF_BooleanMetadata.gxTpr_Checkbox.gxTpr_Controltitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,176);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwp_df_booleanmetadata_checkbox_controltitle_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwp_df_booleanmetadata_checkbox_controltitle_Visible, edtavWwp_df_booleanmetadata_checkbox_controltitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_booleanmetadata_defaultvalue_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_booleanmetadata_defaultvalue_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavWwp_df_booleanmetadata_defaultvalue.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavWwp_df_booleanmetadata_defaultvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavWwp_df_booleanmetadata_defaultvalue_Internalname, context.GetMessage( "WWP_DF_DefaultValue", ""), " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavWwp_df_booleanmetadata_defaultvalue_Internalname, StringUtil.BoolToStr( AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue), "", context.GetMessage( "WWP_DF_DefaultValue", ""), chkavWwp_df_booleanmetadata_defaultvalue.Visible, chkavWwp_df_booleanmetadata_defaultvalue.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(181, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,181);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_stepmetadata_description_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_stepmetadata_description_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwp_df_stepmetadata_description_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwp_df_stepmetadata_description_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwp_df_stepmetadata_description_Internalname, context.GetMessage( "WWP_DF_Description", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavWwp_df_stepmetadata_description_Internalname, AV53WWP_DF_StepMetadata.gxTpr_Description, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,186);\"", 0, edtavWwp_df_stepmetadata_description_Visible, edtavWwp_df_stepmetadata_description_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Internalname, context.GetMessage( "WWP_DF_DisplayType", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype, cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype), 1, 0)), 1, cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.Visible, cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,191);\"", "", true, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype), 1, 0));
            AssignProp(sPrefix, false, cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Internalname, "Values", (string)(cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavWwp_df_elementsrepeatermetadata_repetitionstype.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Internalname, context.GetMessage( "WWP_DF_RepetitionsType", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWwp_df_elementsrepeatermetadata_repetitionstype, cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype), 1, 0)), 1, cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavWwp_df_elementsrepeatermetadata_repetitionstype.Visible, cmbavWwp_df_elementsrepeatermetadata_repetitionstype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,196);\"", "", true, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            cmbavWwp_df_elementsrepeatermetadata_repetitionstype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype), 1, 0));
            AssignProp(sPrefix, false, cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Internalname, "Values", (string)(cmbavWwp_df_elementsrepeatermetadata_repetitionstype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Internalname, context.GetMessage( "WWP_DF_InsertChildCaption", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Internalname, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildcaption, StringUtil.RTrim( context.localUtil.Format( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildcaption, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,201);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Visible, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_Internalname, context.GetMessage( "WWP_DF_InsertChildButtonAlignedToLabel", ""), " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_Internalname, StringUtil.BoolToStr( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel), "", context.GetMessage( "WWP_DF_InsertChildButtonAlignedToLabel", ""), chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.Visible, chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(206, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,206);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Internalname, context.GetMessage( "WWP_DF_RemoveChildButtonTooltip", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Internalname, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Removechildtooltip, StringUtil.RTrim( context.localUtil.Format( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Removechildtooltip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,211);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Visible, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Internalname, context.GetMessage( "WWP_DF_MaxRepetitions", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Maxrepetitions), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Enabled!=0) ? context.localUtil.Format( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Maxrepetitions), "ZZZ9") : context.localUtil.Format( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Maxrepetitions), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,216);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Visible, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Internalname, context.GetMessage( "WWP_DF_RepetitionsValue", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 221,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_fixedvalue.gxTpr_Value), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_fixedvalue.gxTpr_Value), "ZZZ9") : context.localUtil.Format( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_fixedvalue.gxTpr_Value), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,221);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Visible, edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Internalname, context.GetMessage( "WWP_DF_RepetitionsCountVariable", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 226,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid, cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_variable.gxTpr_Elementid), 4, 0)), 1, cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.Visible, cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,226);\"", "", true, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_variable.gxTpr_Elementid), 4, 0));
            AssignProp(sPrefix, false, cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Internalname, "Values", (string)(cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwp_df_labelmetadata_style_cell_Internalname, 1, 0, "px", 0, "px", divWwp_df_labelmetadata_style_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavWwp_df_labelmetadata_style.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavWwp_df_labelmetadata_style_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWwp_df_labelmetadata_style_Internalname, context.GetMessage( "WWP_DF_Style", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 231,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWwp_df_labelmetadata_style, cmbavWwp_df_labelmetadata_style_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV51WWP_DF_LabelMetadata.gxTpr_Style), 2, 0)), 1, cmbavWwp_df_labelmetadata_style_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavWwp_df_labelmetadata_style.Visible, cmbavWwp_df_labelmetadata_style.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,231);\"", "", true, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            cmbavWwp_df_labelmetadata_style.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51WWP_DF_LabelMetadata.gxTpr_Style), 2, 0));
            AssignProp(sPrefix, false, cmbavWwp_df_labelmetadata_style_Internalname, "Values", (string)(cmbavWwp_df_labelmetadata_style.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab2_title_Internalname, context.GetMessage( "WWP_DF_Visibility", ""), "", "", lblTab2_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab2") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWwpformelementexcludefromexport_cell_Internalname, 1, 0, "px", 0, "px", divWwpformelementexcludefromexport_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavWwpformelementexcludefromexport.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavWwpformelementexcludefromexport_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavWwpformelementexcludefromexport_Internalname, context.GetMessage( "WWP_DF_ExcludeFromExport", ""), " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 241,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavWwpformelementexcludefromexport_Internalname, StringUtil.BoolToStr( AV59WWPFormElementExcludeFromExport), "", context.GetMessage( "WWP_DF_ExcludeFromExport", ""), chkavWwpformelementexcludefromexport.Visible, chkavWwpformelementexcludefromexport.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(241, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,241);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavVisiblecondition_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVisiblecondition_Internalname, context.GetMessage( "WWP_DF_VisibleCondition", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavVisiblecondition_Internalname, AV43VisibleCondition, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,246);\"", 0, 1, edtavVisiblecondition_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DynFormConditionHelpCell Invisible", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblVisibleconditionhelpicon_Internalname, lblVisibleconditionhelpicon_Caption, "", "", lblVisibleconditionhelpicon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            /* User Defined Control */
            ucBtntestvisiblecondition.SetProperty("TooltipText", Btntestvisiblecondition_Tooltiptext);
            ucBtntestvisiblecondition.SetProperty("BeforeIconClass", Btntestvisiblecondition_Beforeiconclass);
            ucBtntestvisiblecondition.SetProperty("Caption", Btntestvisiblecondition_Caption);
            ucBtntestvisiblecondition.SetProperty("Class", Btntestvisiblecondition_Class);
            ucBtntestvisiblecondition.Render(context, "wwp_iconbutton", Btntestvisiblecondition_Internalname, sPrefix+"BTNTESTVISIBLECONDITIONContainer");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcmentionsvisibility.SetProperty("DataListProc", Ucmentionsvisibility_Datalistproc);
            ucUcmentionsvisibility.Render(context, "wwp.suggest", Ucmentionsvisibility_Internalname, sPrefix+"UCMENTIONSVISIBILITYContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab3_title_Internalname, context.GetMessage( "Validations", ""), "", "", lblTab3_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab3") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divIsrequired_cell_Internalname, 1, 0, "px", 0, "px", divIsrequired_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavIsrequired.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavIsrequired_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsrequired_Internalname, context.GetMessage( "WWP_DF_IsRequired", ""), " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 265,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsrequired_Internalname, StringUtil.BoolToStr( AV24IsRequired), "", context.GetMessage( "WWP_DF_IsRequired", ""), chkavIsrequired.Visible, chkavIsrequired.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(265, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,265);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "end", "top", "", "", "div");
            /* User Defined Control */
            ucBtnaddvalidation.SetProperty("TooltipText", Btnaddvalidation_Tooltiptext);
            ucBtnaddvalidation.SetProperty("BeforeIconClass", Btnaddvalidation_Beforeiconclass);
            ucBtnaddvalidation.SetProperty("Caption", Btnaddvalidation_Caption);
            ucBtnaddvalidation.SetProperty("Class", Btnaddvalidation_Class);
            ucBtnaddvalidation.Render(context, "wwp_iconbutton", Btnaddvalidation_Internalname, sPrefix+"BTNADDVALIDATIONContainer");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridvalidationsContainer.SetWrapped(nGXWrapped);
            StartGridControl270( ) ;
         }
         if ( wbEnd == 270 )
         {
            wbEnd = 0;
            nRC_GXsfl_270 = (int)(nGXsfl_270_idx-1);
            if ( GridvalidationsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridvalidationsContainer.AddObjectProperty("GRIDVALIDATIONS_nEOF", GRIDVALIDATIONS_nEOF);
               GridvalidationsContainer.AddObjectProperty("GRIDVALIDATIONS_nFirstRecordOnPage", GRIDVALIDATIONS_nFirstRecordOnPage);
               AV97GXV28 = nGXsfl_270_idx;
               if ( subGridvalidations_Visible != 0 )
               {
                  sStyleString = "";
               }
               else
               {
                  sStyleString = " style=\"display:none;\"";
               }
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridvalidationsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridvalidations", GridvalidationsContainer, subGridvalidations_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridvalidationsContainerData", GridvalidationsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridvalidationsContainerData"+"V", GridvalidationsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridvalidationsContainerData"+"V"+"\" value='"+GridvalidationsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 278,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(270), 3, 0)+","+"null"+");", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 280,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuacancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(270), 3, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtnuacancel_Jsonclick, 7, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11271_client"+"'", TempTags, "", 2, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 284,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWwpform_wwpformresume, cmbavWwpform_wwpformresume_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV55WWPForm.gxTpr_Wwpformresume), 1, 0)), 1, cmbavWwpform_wwpformresume_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavWwpform_wwpformresume.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,284);\"", "", true, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            cmbavWwpform_wwpformresume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV55WWPForm.gxTpr_Wwpformresume), 1, 0));
            AssignProp(sPrefix, false, cmbavWwpform_wwpformresume_Internalname, "Values", (string)(cmbavWwpform_wwpformresume.ToJavascriptSource()), true);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 285,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWwp_df_containermetadata_style, cmbavWwp_df_containermetadata_style_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV47WWP_DF_ContainerMetadata.gxTpr_Style), 1, 0)), 1, cmbavWwp_df_containermetadata_style_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavWwp_df_containermetadata_style.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,285);\"", "", true, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            cmbavWwp_df_containermetadata_style.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47WWP_DF_ContainerMetadata.gxTpr_Style), 1, 0));
            AssignProp(sPrefix, false, cmbavWwp_df_containermetadata_style_Internalname, "Values", (string)(cmbavWwp_df_containermetadata_style.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 286,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavColumns_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Columns), 2, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8Columns), "Z9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,286);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavColumns_Jsonclick, 0, "Attribute", "", "", "", "", edtavColumns_Visible, 1, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            wb_table2_287_272( true) ;
         }
         else
         {
            wb_table2_287_272( false) ;
         }
         return  ;
      }

      protected void wb_table2_287_272e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_292_272( true) ;
         }
         else
         {
            wb_table3_292_272( false) ;
         }
         return  ;
      }

      protected void wb_table3_292_272e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGridvalidations_empowerer.Render(context, "wwp.gridempowerer", Gridvalidations_empowerer_Internalname, sPrefix+"GRIDVALIDATIONS_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0299"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0299"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_270_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0299"+"");
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
         if ( wbEnd == 270 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridvalidationsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridvalidationsContainer.AddObjectProperty("GRIDVALIDATIONS_nEOF", GRIDVALIDATIONS_nEOF);
                  GridvalidationsContainer.AddObjectProperty("GRIDVALIDATIONS_nFirstRecordOnPage", GRIDVALIDATIONS_nFirstRecordOnPage);
                  AV97GXV28 = nGXsfl_270_idx;
                  if ( subGridvalidations_Visible != 0 )
                  {
                     sStyleString = "";
                  }
                  else
                  {
                     sStyleString = " style=\"display:none;\"";
                  }
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridvalidationsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridvalidations", GridvalidationsContainer, subGridvalidations_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridvalidationsContainerData", GridvalidationsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridvalidationsContainerData"+"V", GridvalidationsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridvalidationsContainerData"+"V"+"\" value='"+GridvalidationsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START272( )
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
            Form.Meta.addItem("description", context.GetMessage( "Element settings", ""), 0) ;
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
               STRUP270( ) ;
            }
         }
      }

      protected void WS272( )
      {
         START272( ) ;
         EVT272( ) ;
      }

      protected void EVT272( )
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
                                 STRUP270( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "ADDVALIDATION_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Addvalidation_modal.Close */
                                    E12272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ADDVALIDATION_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Addvalidation_modal.Onloadcomponent */
                                    E13272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "UPDATEVALIDATION_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Updatevalidation_modal.Close */
                                    E14272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "UPDATEVALIDATION_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Updatevalidation_modal.Onloadcomponent */
                                    E15272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOTESTVISIBLECONDITION'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoTestVisibleCondition' */
                                    E16272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
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
                                          E17272 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VWWPFORMELEMENTTYPE.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E18272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCONTROL.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E19272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Wwp_df_charmetadata_multipleoptions_allowmultipleselection.Click */
                                    E20272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VPREDOPTIONS_TYPE.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E21272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VTEXT_FORMAT.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E22272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VPREDOPTIONS_VALUES.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E23272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILE_FORMAT.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E24272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "WWP_DF_CONTAINERMETADATA_COLLAPSABLE.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Wwp_df_containermetadata_collapsable.Click */
                                    E25272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Wwp_df_elementsrepeatermetadata_repetitionstype.Controlvaluechanged */
                                    E26272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Wwp_df_elementsrepeatermetadata_repetitionsdatatype.Controlvaluechanged */
                                    E27272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Wwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Click */
                                    E28272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "WWPFORM_WWPFORMRESUME.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Wwpform_wwpformresume.Controlvaluechanged */
                                    E29272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "WWP_DF_CONTAINERMETADATA_STYLE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Wwp_df_containermetadata_style.Controlvaluechanged */
                                    E30272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavGridactiongroup1_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDVALIDATIONSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDVALIDATIONSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridvalidations_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridvalidations_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridvalidations_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridvalidations_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "GRIDVALIDATIONS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              nGXsfl_270_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
                              SubsflControlProps_2702( ) ;
                              AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
                              if ( ( AV39Validations.Count >= AV97GXV28 ) && ( AV97GXV28 > 0 ) )
                              {
                                 AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
                                 cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                                 cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                                 AV19GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV19GridActionGroup1), 4, 0));
                                 AV40Validations__MessageWithTags = cgiGet( edtavValidations__messagewithtags_Internalname);
                                 AssignAttri(sPrefix, false, edtavValidations__messagewithtags_Internalname, AV40Validations__MessageWithTags);
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
                                          GX_FocusControl = cmbavGridactiongroup1_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E31272 ();
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
                                          GX_FocusControl = cmbavGridactiongroup1_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E32272 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDVALIDATIONS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactiongroup1_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Gridvalidations.Load */
                                          E33272 ();
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
                                          GX_FocusControl = cmbavGridactiongroup1_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E34272 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP270( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactiongroup1_Internalname;
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
                        if ( nCmpId == 299 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0299");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0299", "", sEvt);
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

      protected void WE272( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm272( ) ;
            }
         }
      }

      protected void PA272( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_addelement.aspx")), "workwithplus.dynamicforms.wwp_df_addelement.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_addelement.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
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
               GX_FocusControl = radavFormtype_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridvalidations_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_2702( ) ;
         while ( nGXsfl_270_idx <= nRC_GXsfl_270 )
         {
            sendrow_2702( ) ;
            nGXsfl_270_idx = ((subGridvalidations_Islastpage==1)&&(nGXsfl_270_idx+1>subGridvalidations_fnc_Recordsperpage( )) ? 1 : nGXsfl_270_idx+1);
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridvalidationsContainer)) ;
         /* End function gxnrGridvalidations_newrow */
      }

      protected void gxgrGridvalidations_refresh( int subGridvalidations_Rows ,
                                                  short AV64WWPFormElementType ,
                                                  GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV39Validations ,
                                                  string AV18FormType ,
                                                  string AV35Text_Format ,
                                                  string AV36TextArea_Format ,
                                                  bool AV14Date_IncludeTime ,
                                                  bool GXV4 ,
                                                  bool GXV5 ,
                                                  string AV31PredOptions_Values ,
                                                  bool GXV7 ,
                                                  bool GXV11 ,
                                                  bool GXV12 ,
                                                  string AV17File_Format ,
                                                  string AV32Radio_Direction ,
                                                  bool GXV17 ,
                                                  bool GXV22 ,
                                                  bool AV59WWPFormElementExcludeFromExport ,
                                                  bool AV24IsRequired ,
                                                  short AV58WWPFormElementDataType ,
                                                  bool AV22IsFormSettings ,
                                                  string AV65WWPFormTitle ,
                                                  bool AV28ParentIsGridMultipleData ,
                                                  string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDVALIDATIONS_nCurrentRecord = 0;
         RF272( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridvalidations_refresh */
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
         AssignAttri(sPrefix, false, "AV18FormType", AV18FormType);
         if ( cmbavWwpformelementtype.ItemCount > 0 )
         {
            AV64WWPFormElementType = (short)(Math.Round(NumberUtil.Val( cmbavWwpformelementtype.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV64WWPFormElementType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV64WWPFormElementType", StringUtil.Str( (decimal)(AV64WWPFormElementType), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWwpformelementtype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV64WWPFormElementType), 1, 0));
            AssignProp(sPrefix, false, cmbavWwpformelementtype_Internalname, "Values", cmbavWwpformelementtype.ToJavascriptSource(), true);
         }
         if ( cmbavWwpformelementcaption.ItemCount > 0 )
         {
            AV57WWPFormElementCaption = (short)(Math.Round(NumberUtil.Val( cmbavWwpformelementcaption.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV57WWPFormElementCaption), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV57WWPFormElementCaption", StringUtil.Str( (decimal)(AV57WWPFormElementCaption), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWwpformelementcaption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57WWPFormElementCaption), 1, 0));
            AssignProp(sPrefix, false, cmbavWwpformelementcaption_Internalname, "Values", cmbavWwpformelementcaption.ToJavascriptSource(), true);
         }
         if ( cmbavControl.ItemCount > 0 )
         {
            AV10Control = cmbavControl.getValidValue(AV10Control);
            AssignAttri(sPrefix, false, "AV10Control", AV10Control);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavControl.CurrentValue = StringUtil.RTrim( AV10Control);
            AssignProp(sPrefix, false, cmbavControl_Internalname, "Values", cmbavControl.ToJavascriptSource(), true);
         }
         AssignAttri(sPrefix, false, "AV35Text_Format", AV35Text_Format);
         AssignAttri(sPrefix, false, "AV36TextArea_Format", AV36TextArea_Format);
         AV14Date_IncludeTime = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Date_IncludeTime));
         AssignAttri(sPrefix, false, "AV14Date_IncludeTime", AV14Date_IncludeTime);
         if ( cmbavPredoptions_type.ItemCount > 0 )
         {
            AV30PredOptions_Type = cmbavPredoptions_type.getValidValue(AV30PredOptions_Type);
            AssignAttri(sPrefix, false, "AV30PredOptions_Type", AV30PredOptions_Type);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
            AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         }
         AssignAttri(sPrefix, false, "AV31PredOptions_Values", AV31PredOptions_Values);
         AssignAttri(sPrefix, false, "AV17File_Format", AV17File_Format);
         AssignAttri(sPrefix, false, "AV32Radio_Direction", AV32Radio_Direction);
         if ( cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.ItemCount > 0 )
         {
            AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype = (short)(Math.Round(NumberUtil.Val( cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype), 1, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype), 1, 0));
            AssignProp(sPrefix, false, cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Internalname, "Values", cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.ToJavascriptSource(), true);
         }
         if ( cmbavWwp_df_elementsrepeatermetadata_repetitionstype.ItemCount > 0 )
         {
            AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype = (short)(Math.Round(NumberUtil.Val( cmbavWwp_df_elementsrepeatermetadata_repetitionstype.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype), 1, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWwp_df_elementsrepeatermetadata_repetitionstype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype), 1, 0));
            AssignProp(sPrefix, false, cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Internalname, "Values", cmbavWwp_df_elementsrepeatermetadata_repetitionstype.ToJavascriptSource(), true);
         }
         if ( cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.ItemCount > 0 )
         {
            AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_variable.gxTpr_Elementid = (short)(Math.Round(NumberUtil.Val( cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_variable.gxTpr_Elementid), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_variable.gxTpr_Elementid), 4, 0));
            AssignProp(sPrefix, false, cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Internalname, "Values", cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.ToJavascriptSource(), true);
         }
         if ( cmbavWwp_df_labelmetadata_style.ItemCount > 0 )
         {
            AV51WWP_DF_LabelMetadata.gxTpr_Style = (short)(Math.Round(NumberUtil.Val( cmbavWwp_df_labelmetadata_style.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV51WWP_DF_LabelMetadata.gxTpr_Style), 2, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWwp_df_labelmetadata_style.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51WWP_DF_LabelMetadata.gxTpr_Style), 2, 0));
            AssignProp(sPrefix, false, cmbavWwp_df_labelmetadata_style_Internalname, "Values", cmbavWwp_df_labelmetadata_style.ToJavascriptSource(), true);
         }
         AV59WWPFormElementExcludeFromExport = StringUtil.StrToBool( StringUtil.BoolToStr( AV59WWPFormElementExcludeFromExport));
         AssignAttri(sPrefix, false, "AV59WWPFormElementExcludeFromExport", AV59WWPFormElementExcludeFromExport);
         AV24IsRequired = StringUtil.StrToBool( StringUtil.BoolToStr( AV24IsRequired));
         AssignAttri(sPrefix, false, "AV24IsRequired", AV24IsRequired);
         if ( cmbavWwpform_wwpformresume.ItemCount > 0 )
         {
            AV55WWPForm.gxTpr_Wwpformresume = (short)(Math.Round(NumberUtil.Val( cmbavWwpform_wwpformresume.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV55WWPForm.gxTpr_Wwpformresume), 1, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWwpform_wwpformresume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV55WWPForm.gxTpr_Wwpformresume), 1, 0));
            AssignProp(sPrefix, false, cmbavWwpform_wwpformresume_Internalname, "Values", cmbavWwpform_wwpformresume.ToJavascriptSource(), true);
         }
         if ( cmbavWwp_df_containermetadata_style.ItemCount > 0 )
         {
            AV47WWP_DF_ContainerMetadata.gxTpr_Style = (short)(Math.Round(NumberUtil.Val( cmbavWwp_df_containermetadata_style.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV47WWP_DF_ContainerMetadata.gxTpr_Style), 1, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWwp_df_containermetadata_style.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47WWP_DF_ContainerMetadata.gxTpr_Style), 1, 0));
            AssignProp(sPrefix, false, cmbavWwp_df_containermetadata_style_Internalname, "Values", cmbavWwp_df_containermetadata_style.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF272( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavValidations__messagewithtags_Enabled = 0;
         edtavValidations__message_Enabled = 0;
      }

      protected void RF272( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridvalidationsContainer.ClearRows();
         }
         wbStart = 270;
         /* Execute user event: Refresh */
         E32272 ();
         nGXsfl_270_idx = 1;
         sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
         SubsflControlProps_2702( ) ;
         bGXsfl_270_Refreshing = true;
         GridvalidationsContainer.AddObjectProperty("GridName", "Gridvalidations");
         GridvalidationsContainer.AddObjectProperty("CmpContext", sPrefix);
         GridvalidationsContainer.AddObjectProperty("InMasterPage", "false");
         GridvalidationsContainer.AddObjectProperty("Class", "WorkWith");
         GridvalidationsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridvalidationsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridvalidationsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Backcolorstyle), 1, 0, ".", "")));
         GridvalidationsContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Visible), 5, 0, ".", "")));
         GridvalidationsContainer.PageSize = subGridvalidations_fnc_Recordsperpage( );
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
            SubsflControlProps_2702( ) ;
            /* Execute user event: Gridvalidations.Load */
            E33272 ();
            if ( ( subGridvalidations_Islastpage == 0 ) && ( GRIDVALIDATIONS_nCurrentRecord > 0 ) && ( GRIDVALIDATIONS_nGridOutOfScope == 0 ) && ( nGXsfl_270_idx == 1 ) )
            {
               GRIDVALIDATIONS_nCurrentRecord = 0;
               GRIDVALIDATIONS_nGridOutOfScope = 1;
               subgridvalidations_firstpage( ) ;
               /* Execute user event: Gridvalidations.Load */
               E33272 ();
            }
            wbEnd = 270;
            WB270( ) ;
         }
         bGXsfl_270_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes272( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58WWPFormElementDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV58WWPFormElementDataType), "Z9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFORMSETTINGS", AV22IsFormSettings);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFORMSETTINGS", GetSecureSignedToken( sPrefix, AV22IsFormSettings, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMTITLE", AV65WWPFormTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV65WWPFormTitle, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV28ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV28ParentIsGridMultipleData, context));
      }

      protected int subGridvalidations_fnc_Pagecount( )
      {
         GRIDVALIDATIONS_nRecordCount = subGridvalidations_fnc_Recordcount( );
         if ( ((int)((GRIDVALIDATIONS_nRecordCount) % (subGridvalidations_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDVALIDATIONS_nRecordCount/ (decimal)(subGridvalidations_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDVALIDATIONS_nRecordCount/ (decimal)(subGridvalidations_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridvalidations_fnc_Recordcount( )
      {
         return AV39Validations.Count ;
      }

      protected int subGridvalidations_fnc_Recordsperpage( )
      {
         if ( subGridvalidations_Rows > 0 )
         {
            return subGridvalidations_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridvalidations_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDVALIDATIONS_nFirstRecordOnPage/ (decimal)(subGridvalidations_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridvalidations_firstpage( )
      {
         GRIDVALIDATIONS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDVALIDATIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDVALIDATIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridvalidations_nextpage( )
      {
         GRIDVALIDATIONS_nRecordCount = subGridvalidations_fnc_Recordcount( );
         if ( ( GRIDVALIDATIONS_nRecordCount >= subGridvalidations_fnc_Recordsperpage( ) ) && ( GRIDVALIDATIONS_nEOF == 0 ) )
         {
            GRIDVALIDATIONS_nFirstRecordOnPage = (long)(GRIDVALIDATIONS_nFirstRecordOnPage+subGridvalidations_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDVALIDATIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDVALIDATIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridvalidationsContainer.AddObjectProperty("GRIDVALIDATIONS_nFirstRecordOnPage", GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDVALIDATIONS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridvalidations_previouspage( )
      {
         if ( GRIDVALIDATIONS_nFirstRecordOnPage >= subGridvalidations_fnc_Recordsperpage( ) )
         {
            GRIDVALIDATIONS_nFirstRecordOnPage = (long)(GRIDVALIDATIONS_nFirstRecordOnPage-subGridvalidations_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDVALIDATIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDVALIDATIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridvalidations_lastpage( )
      {
         GRIDVALIDATIONS_nRecordCount = subGridvalidations_fnc_Recordcount( );
         if ( GRIDVALIDATIONS_nRecordCount > subGridvalidations_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDVALIDATIONS_nRecordCount) % (subGridvalidations_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDVALIDATIONS_nFirstRecordOnPage = (long)(GRIDVALIDATIONS_nRecordCount-subGridvalidations_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDVALIDATIONS_nFirstRecordOnPage = (long)(GRIDVALIDATIONS_nRecordCount-((int)((GRIDVALIDATIONS_nRecordCount) % (subGridvalidations_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDVALIDATIONS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDVALIDATIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDVALIDATIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridvalidations_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDVALIDATIONS_nFirstRecordOnPage = (long)(subGridvalidations_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDVALIDATIONS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDVALIDATIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDVALIDATIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavValidations__messagewithtags_Enabled = 0;
         edtavValidations__message_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP270( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E31272 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWWPFORM"), AV55WWPForm);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWWP_DF_DATEMETADATA"), AV48WWP_DF_DateMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWWP_DF_CHARMETADATA"), AV46WWP_DF_CharMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWWP_DF_CONTAINERMETADATA"), AV47WWP_DF_ContainerMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWWP_DF_NUMERICMETADATA"), AV52WWP_DF_NumericMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWWP_DF_BOOLEANMETADATA"), AV45WWP_DF_BooleanMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWWP_DF_STEPMETADATA"), AV53WWP_DF_StepMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWWP_DF_ELEMENTSREPEATERMETADATA"), AV49WWP_DF_ElementsRepeaterMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWWP_DF_LABELMETADATA"), AV51WWP_DF_LabelMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wwpform"), AV55WWPForm);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wwp_df_datemetadata"), AV48WWP_DF_DateMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wwp_df_charmetadata"), AV46WWP_DF_CharMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wwp_df_containermetadata"), AV47WWP_DF_ContainerMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wwp_df_numericmetadata"), AV52WWP_DF_NumericMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wwp_df_booleanmetadata"), AV45WWP_DF_BooleanMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wwp_df_stepmetadata"), AV53WWP_DF_StepMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wwp_df_elementsrepeatermetadata"), AV49WWP_DF_ElementsRepeaterMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wwp_df_labelmetadata"), AV51WWP_DF_LabelMetadata);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Validations"), AV39Validations);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vVALIDATIONS"), AV39Validations);
            /* Read saved values. */
            nRC_GXsfl_270 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_270"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV54WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV54WWPDynamicFormMode");
            wcpOAV61WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV61WWPFormElementParentId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV60WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV60WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV33SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV33SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDVALIDATIONS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDVALIDATIONS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDVALIDATIONS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDVALIDATIONS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridvalidations_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDVALIDATIONS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDVALIDATIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Rows), 6, 0, ".", "")));
            Updatevalidation_modal_Result = cgiGet( sPrefix+"UPDATEVALIDATION_MODAL_Result");
            Addvalidation_modal_Result = cgiGet( sPrefix+"ADDVALIDATION_MODAL_Result");
            nRC_GXsfl_270 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_270"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_270_fel_idx = 0;
            while ( nGXsfl_270_fel_idx < nRC_GXsfl_270 )
            {
               nGXsfl_270_fel_idx = ((subGridvalidations_Islastpage==1)&&(nGXsfl_270_fel_idx+1>subGridvalidations_fnc_Recordsperpage( )) ? 1 : nGXsfl_270_fel_idx+1);
               sGXsfl_270_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_2702( ) ;
               AV97GXV28 = (int)(nGXsfl_270_fel_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
               if ( ( AV39Validations.Count >= AV97GXV28 ) && ( AV97GXV28 > 0 ) )
               {
                  AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
                  cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                  cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                  AV19GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                  AV40Validations__MessageWithTags = cgiGet( edtavValidations__messagewithtags_Internalname);
               }
            }
            if ( nGXsfl_270_fel_idx == 0 )
            {
               nGXsfl_270_idx = 1;
               sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
               SubsflControlProps_2702( ) ;
            }
            nGXsfl_270_fel_idx = 1;
            /* Read variables values. */
            AV18FormType = cgiGet( radavFormtype_Internalname);
            AssignAttri(sPrefix, false, "AV18FormType", AV18FormType);
            AV55WWPForm.gxTpr_Wwpformtitle = cgiGet( edtavWwpform_wwpformtitle_Internalname);
            AV55WWPForm.gxTpr_Wwpformreferencename = cgiGet( edtavWwpform_wwpformreferencename_Internalname);
            AV55WWPForm.gxTpr_Wwpformresumemessage = cgiGet( edtavWwpform_wwpformresumemessage_Internalname);
            cmbavWwpformelementtype.Name = cmbavWwpformelementtype_Internalname;
            cmbavWwpformelementtype.CurrentValue = cgiGet( cmbavWwpformelementtype_Internalname);
            AV64WWPFormElementType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavWwpformelementtype_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV64WWPFormElementType", StringUtil.Str( (decimal)(AV64WWPFormElementType), 1, 0));
            cmbavWwpformelementcaption.Name = cmbavWwpformelementcaption_Internalname;
            cmbavWwpformelementcaption.CurrentValue = cgiGet( cmbavWwpformelementcaption_Internalname);
            AV57WWPFormElementCaption = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavWwpformelementcaption_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV57WWPFormElementCaption", StringUtil.Str( (decimal)(AV57WWPFormElementCaption), 1, 0));
            AV63WWPFormElementTitle = cgiGet( edtavWwpformelementtitle_Internalname);
            AssignAttri(sPrefix, false, "AV63WWPFormElementTitle", AV63WWPFormElementTitle);
            AV62WWPFormElementReferenceId = cgiGet( edtavWwpformelementreferenceid_Internalname);
            AssignAttri(sPrefix, false, "AV62WWPFormElementReferenceId", AV62WWPFormElementReferenceId);
            cmbavControl.Name = cmbavControl_Internalname;
            cmbavControl.CurrentValue = cgiGet( cmbavControl_Internalname);
            AV10Control = cgiGet( cmbavControl_Internalname);
            AssignAttri(sPrefix, false, "AV10Control", AV10Control);
            AV35Text_Format = cgiGet( radavText_format_Internalname);
            AssignAttri(sPrefix, false, "AV35Text_Format", AV35Text_Format);
            AV36TextArea_Format = cgiGet( radavTextarea_format_Internalname);
            AssignAttri(sPrefix, false, "AV36TextArea_Format", AV36TextArea_Format);
            AV14Date_IncludeTime = StringUtil.StrToBool( cgiGet( chkavDate_includetime_Internalname));
            AssignAttri(sPrefix, false, "AV14Date_IncludeTime", AV14Date_IncludeTime);
            AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday = StringUtil.StrToBool( cgiGet( chkavWwp_df_datemetadata_isdefaultvaluetoday_Internalname));
            AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection = StringUtil.StrToBool( cgiGet( chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection_Internalname));
            cmbavPredoptions_type.Name = cmbavPredoptions_type_Internalname;
            cmbavPredoptions_type.CurrentValue = cgiGet( cmbavPredoptions_type_Internalname);
            AV30PredOptions_Type = cgiGet( cmbavPredoptions_type_Internalname);
            AssignAttri(sPrefix, false, "AV30PredOptions_Type", AV30PredOptions_Type);
            AV31PredOptions_Values = cgiGet( radavPredoptions_values_Internalname);
            AssignAttri(sPrefix, false, "AV31PredOptions_Values", AV31PredOptions_Values);
            AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Dynamic.gxTpr_Getoptionsservice = cgiGet( edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Internalname);
            AV29PredOptions_Options = cgiGet( edtavPredoptions_options_Internalname);
            AssignAttri(sPrefix, false, "AV29PredOptions_Options", AV29PredOptions_Options);
            AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue = StringUtil.StrToBool( cgiGet( chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_Internalname));
            AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Emptytext = cgiGet( edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWwp_df_charmetadata_length_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwp_df_charmetadata_length_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWP_DF_CHARMETADATA_LENGTH");
               GX_FocusControl = edtavWwp_df_charmetadata_length_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV46WWP_DF_CharMetadata.gxTpr_Length = 0;
            }
            else
            {
               AV46WWP_DF_CharMetadata.gxTpr_Length = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwp_df_charmetadata_length_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV46WWP_DF_CharMetadata.gxTpr_Defaultvalue = cgiGet( edtavWwp_df_charmetadata_defaultvalue_Internalname);
            AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable = StringUtil.StrToBool( cgiGet( chkavWwp_df_containermetadata_collapsable_Internalname));
            AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault = StringUtil.StrToBool( cgiGet( chkavWwp_df_containermetadata_collapsedbydefault_Internalname));
            AV17File_Format = cgiGet( radavFile_format_Internalname);
            AssignAttri(sPrefix, false, "AV17File_Format", AV17File_Format);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWwp_df_numericmetadata_length_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwp_df_numericmetadata_length_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWP_DF_NUMERICMETADATA_LENGTH");
               GX_FocusControl = edtavWwp_df_numericmetadata_length_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV52WWP_DF_NumericMetadata.gxTpr_Length = 0;
            }
            else
            {
               AV52WWP_DF_NumericMetadata.gxTpr_Length = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwp_df_numericmetadata_length_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWwp_df_numericmetadata_decimals_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwp_df_numericmetadata_decimals_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWP_DF_NUMERICMETADATA_DECIMALS");
               GX_FocusControl = edtavWwp_df_numericmetadata_decimals_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV52WWP_DF_NumericMetadata.gxTpr_Decimals = 0;
            }
            else
            {
               AV52WWP_DF_NumericMetadata.gxTpr_Decimals = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwp_df_numericmetadata_decimals_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWwp_df_numericmetadata_defaultvalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwp_df_numericmetadata_defaultvalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWP_DF_NUMERICMETADATA_DEFAULTVALUE");
               GX_FocusControl = edtavWwp_df_numericmetadata_defaultvalue_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV52WWP_DF_NumericMetadata.gxTpr_Defaultvalue = 0;
            }
            else
            {
               AV52WWP_DF_NumericMetadata.gxTpr_Defaultvalue = context.localUtil.CToN( cgiGet( edtavWwp_df_numericmetadata_defaultvalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            }
            AV32Radio_Direction = cgiGet( radavRadio_direction_Internalname);
            AssignAttri(sPrefix, false, "AV32Radio_Direction", AV32Radio_Direction);
            AV45WWP_DF_BooleanMetadata.gxTpr_Checkbox.gxTpr_Controltitle = cgiGet( edtavWwp_df_booleanmetadata_checkbox_controltitle_Internalname);
            AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue = StringUtil.StrToBool( cgiGet( chkavWwp_df_booleanmetadata_defaultvalue_Internalname));
            AV53WWP_DF_StepMetadata.gxTpr_Description = cgiGet( edtavWwp_df_stepmetadata_description_Internalname);
            cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.Name = cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Internalname;
            cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.CurrentValue = cgiGet( cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Internalname);
            AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Internalname), "."), 18, MidpointRounding.ToEven));
            cmbavWwp_df_elementsrepeatermetadata_repetitionstype.Name = cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Internalname;
            cmbavWwp_df_elementsrepeatermetadata_repetitionstype.CurrentValue = cgiGet( cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Internalname);
            AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Internalname), "."), 18, MidpointRounding.ToEven));
            AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildcaption = cgiGet( edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Internalname);
            AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel = StringUtil.StrToBool( cgiGet( chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_Internalname));
            AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Removechildtooltip = cgiGet( edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS");
               GX_FocusControl = edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Maxrepetitions = 0;
            }
            else
            {
               AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Maxrepetitions = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE");
               GX_FocusControl = edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_fixedvalue.gxTpr_Value = 0;
            }
            else
            {
               AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_fixedvalue.gxTpr_Value = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.Name = cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Internalname;
            cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.CurrentValue = cgiGet( cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Internalname);
            AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_variable.gxTpr_Elementid = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Internalname), "."), 18, MidpointRounding.ToEven));
            cmbavWwp_df_labelmetadata_style.Name = cmbavWwp_df_labelmetadata_style_Internalname;
            cmbavWwp_df_labelmetadata_style.CurrentValue = cgiGet( cmbavWwp_df_labelmetadata_style_Internalname);
            AV51WWP_DF_LabelMetadata.gxTpr_Style = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavWwp_df_labelmetadata_style_Internalname), "."), 18, MidpointRounding.ToEven));
            AV59WWPFormElementExcludeFromExport = StringUtil.StrToBool( cgiGet( chkavWwpformelementexcludefromexport_Internalname));
            AssignAttri(sPrefix, false, "AV59WWPFormElementExcludeFromExport", AV59WWPFormElementExcludeFromExport);
            AV43VisibleCondition = cgiGet( edtavVisiblecondition_Internalname);
            AssignAttri(sPrefix, false, "AV43VisibleCondition", AV43VisibleCondition);
            AV24IsRequired = StringUtil.StrToBool( cgiGet( chkavIsrequired_Internalname));
            AssignAttri(sPrefix, false, "AV24IsRequired", AV24IsRequired);
            cmbavWwpform_wwpformresume.Name = cmbavWwpform_wwpformresume_Internalname;
            cmbavWwpform_wwpformresume.CurrentValue = cgiGet( cmbavWwpform_wwpformresume_Internalname);
            AV55WWPForm.gxTpr_Wwpformresume = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavWwpform_wwpformresume_Internalname), "."), 18, MidpointRounding.ToEven));
            cmbavWwp_df_containermetadata_style.Name = cmbavWwp_df_containermetadata_style_Internalname;
            cmbavWwp_df_containermetadata_style.CurrentValue = cgiGet( cmbavWwp_df_containermetadata_style_Internalname);
            AV47WWP_DF_ContainerMetadata.gxTpr_Style = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavWwp_df_containermetadata_style_Internalname), "."), 18, MidpointRounding.ToEven));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavColumns_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavColumns_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOLUMNS");
               GX_FocusControl = edtavColumns_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Columns = 0;
               AssignAttri(sPrefix, false, "AV8Columns", StringUtil.LTrimStr( (decimal)(AV8Columns), 2, 0));
            }
            else
            {
               AV8Columns = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavColumns_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV8Columns", StringUtil.LTrimStr( (decimal)(AV8Columns), 2, 0));
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
         E31272 ();
         if (returnInSub) return;
      }

      protected void E31272( )
      {
         /* Start Routine */
         returnInSub = false;
         AV22IsFormSettings = (bool)(((StringUtil.StrCmp(AV54WWPDynamicFormMode, "UPD")==0)&&(0==AV60WWPFormElementId)));
         AssignAttri(sPrefix, false, "AV22IsFormSettings", AV22IsFormSettings);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFORMSETTINGS", GetSecureSignedToken( sPrefix, AV22IsFormSettings, context));
         AV66GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV67GAMErrors);
         Ucmentionsvisibility_Gamoauthtoken = AV66GAMSession.gxTpr_Token;
         ucUcmentionsvisibility.SendProperty(context, sPrefix, false, Ucmentionsvisibility_Internalname, "GAMOAuthToken", Ucmentionsvisibility_Gamoauthtoken);
         this.executeUsercontrolMethod(sPrefix, false, "UCMENTIONSVISIBILITYContainer", "Attach", "", new Object[] {(string)"&",(string)edtavVisiblecondition_Internalname});
         Ucmentionsvisibility_Datalistprocextrapartameters = StringUtil.Format( "\"SessionId\": \"%1\",\"IncludeCurrentElement\": \"false\",\"CurrentElementId\": \"%2\",\"MaxOptions\": \"5\"", StringUtil.Trim( StringUtil.Str( (decimal)(AV33SessionId), 4, 0)), StringUtil.Trim( StringUtil.Str( (decimal)(AV60WWPFormElementId), 4, 0)), "", "", "", "", "", "", "");
         ucUcmentionsvisibility.SendProperty(context, sPrefix, false, Ucmentionsvisibility_Internalname, "DataListProcExtraPartameters", Ucmentionsvisibility_Datalistprocextrapartameters);
         AV10Control = "Text";
         AssignAttri(sPrefix, false, "AV10Control", AV10Control);
         AV35Text_Format = "Any";
         AssignAttri(sPrefix, false, "AV35Text_Format", AV35Text_Format);
         AV36TextArea_Format = "Any";
         AssignAttri(sPrefix, false, "AV36TextArea_Format", AV36TextArea_Format);
         AV31PredOptions_Values = "Fixed";
         AssignAttri(sPrefix, false, "AV31PredOptions_Values", AV31PredOptions_Values);
         AV17File_Format = "Any";
         AssignAttri(sPrefix, false, "AV17File_Format", AV17File_Format);
         AV46WWP_DF_CharMetadata.gxTpr_Length = 40;
         cmbavPredoptions_type.addItem("Combo", context.GetMessage( "Combo box", ""), 0);
         AV30PredOptions_Type = "Combo";
         AssignAttri(sPrefix, false, "AV30PredOptions_Type", AV30PredOptions_Type);
         AV32Radio_Direction = "Horizontal";
         AssignAttri(sPrefix, false, "AV32Radio_Direction", AV32Radio_Direction);
         AV52WWP_DF_NumericMetadata.gxTpr_Length = 10;
         GXt_SdtWWP_Form1 = AV55WWPForm;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV33SessionId, out  GXt_SdtWWP_Form1) ;
         AV55WWPForm = GXt_SdtWWP_Form1;
         AV65WWPFormTitle = AV55WWPForm.gxTpr_Wwpformtitle;
         AssignAttri(sPrefix, false, "AV65WWPFormTitle", AV65WWPFormTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV65WWPFormTitle, "")), context));
         if ( AV61WWPFormElementParentId > 0 )
         {
            GXt_SdtWWP_Form_Element2 = AV27ParentElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV55WWPForm,  AV61WWPFormElementParentId, out  GXt_SdtWWP_Form_Element2) ;
            AV27ParentElement = GXt_SdtWWP_Form_Element2;
            if ( AV27ParentElement.gxTpr_Wwpformelementtype == 2 )
            {
               while ( ! (0==AV27ParentElement.gxTpr_Wwpformelementparentid) && ( AV27ParentElement.gxTpr_Wwpformelementtype != 3 ) )
               {
                  GXt_SdtWWP_Form_Element2 = AV27ParentElement;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV55WWPForm,  AV27ParentElement.gxTpr_Wwpformelementparentid, out  GXt_SdtWWP_Form_Element2) ;
                  AV27ParentElement = GXt_SdtWWP_Form_Element2;
               }
            }
            if ( AV27ParentElement.gxTpr_Wwpformelementtype == 3 )
            {
               AV49WWP_DF_ElementsRepeaterMetadata.FromJSonString(AV27ParentElement.gxTpr_Wwpformelementmetadata, null);
               AV28ParentIsGridMultipleData = (bool)(((AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype==2)));
               AssignAttri(sPrefix, false, "AV28ParentIsGridMultipleData", AV28ParentIsGridMultipleData);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV28ParentIsGridMultipleData, context));
               if ( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype == 1 )
               {
                  cmbavWwpformelementtype.removeItem(StringUtil.Str( (decimal)(3), 1, 0));
               }
               AV49WWP_DF_ElementsRepeaterMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
            }
         }
         if ( StringUtil.StrCmp(AV54WWPDynamicFormMode, "INS") == 0 )
         {
            AV58WWPFormElementDataType = 2;
            AssignAttri(sPrefix, false, "AV58WWPFormElementDataType", StringUtil.LTrimStr( (decimal)(AV58WWPFormElementDataType), 2, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV58WWPFormElementDataType), "Z9"), context));
            AV47WWP_DF_ContainerMetadata.gxTpr_Style = 0;
            if ( (0==AV61WWPFormElementParentId) )
            {
               if ( AV55WWPForm.gxTpr_Wwpformiswizard )
               {
                  AV64WWPFormElementType = 5;
                  AssignAttri(sPrefix, false, "AV64WWPFormElementType", StringUtil.Str( (decimal)(AV64WWPFormElementType), 1, 0));
               }
               else
               {
                  AV64WWPFormElementType = 2;
                  AssignAttri(sPrefix, false, "AV64WWPFormElementType", StringUtil.Str( (decimal)(AV64WWPFormElementType), 1, 0));
               }
            }
         }
         else
         {
            if ( AV22IsFormSettings )
            {
               this.executeUsercontrolMethod(sPrefix, false, "GXUITABSPANEL_TABS1Container", "HideTab", "", new Object[] {(short)2});
               AV18FormType = (AV55WWPForm.gxTpr_Wwpformiswizard ? "Wizard" : "Plain");
               AssignAttri(sPrefix, false, "AV18FormType", AV18FormType);
               AV64WWPFormElementType = 2;
               AssignAttri(sPrefix, false, "AV64WWPFormElementType", StringUtil.Str( (decimal)(AV64WWPFormElementType), 1, 0));
               AV39Validations.FromJSonString(AV55WWPForm.gxTpr_Wwpformvalidations, null);
               gx_BV270 = true;
            }
            else
            {
               GXt_SdtWWP_Form_Element2 = AV11CurrentElement;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV55WWPForm,  AV60WWPFormElementId, out  GXt_SdtWWP_Form_Element2) ;
               AV11CurrentElement = GXt_SdtWWP_Form_Element2;
               AV64WWPFormElementType = AV11CurrentElement.gxTpr_Wwpformelementtype;
               AssignAttri(sPrefix, false, "AV64WWPFormElementType", StringUtil.Str( (decimal)(AV64WWPFormElementType), 1, 0));
               AV63WWPFormElementTitle = AV11CurrentElement.gxTpr_Wwpformelementtitle;
               AssignAttri(sPrefix, false, "AV63WWPFormElementTitle", AV63WWPFormElementTitle);
               AV58WWPFormElementDataType = AV11CurrentElement.gxTpr_Wwpformelementdatatype;
               AssignAttri(sPrefix, false, "AV58WWPFormElementDataType", StringUtil.LTrimStr( (decimal)(AV58WWPFormElementDataType), 2, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV58WWPFormElementDataType), "Z9"), context));
               AV57WWPFormElementCaption = (short)((AV28ParentIsGridMultipleData ? 1 : AV11CurrentElement.gxTpr_Wwpformelementcaption));
               AssignAttri(sPrefix, false, "AV57WWPFormElementCaption", StringUtil.Str( (decimal)(AV57WWPFormElementCaption), 1, 0));
               AV62WWPFormElementReferenceId = AV11CurrentElement.gxTpr_Wwpformelementreferenceid;
               AssignAttri(sPrefix, false, "AV62WWPFormElementReferenceId", AV62WWPFormElementReferenceId);
               AV59WWPFormElementExcludeFromExport = AV11CurrentElement.gxTpr_Wwpformelementexcludefromexport;
               AssignAttri(sPrefix, false, "AV59WWPFormElementExcludeFromExport", AV59WWPFormElementExcludeFromExport);
               if ( AV64WWPFormElementType == 2 )
               {
                  AV47WWP_DF_ContainerMetadata.FromJSonString(AV11CurrentElement.gxTpr_Wwpformelementmetadata, null);
                  AV8Columns = AV47WWP_DF_ContainerMetadata.gxTpr_Columns;
                  AssignAttri(sPrefix, false, "AV8Columns", StringUtil.LTrimStr( (decimal)(AV8Columns), 2, 0));
                  AV43VisibleCondition = AV47WWP_DF_ContainerMetadata.gxTpr_Visiblecondition.gxTpr_Expression;
                  AssignAttri(sPrefix, false, "AV43VisibleCondition", AV43VisibleCondition);
               }
               else if ( AV64WWPFormElementType == 5 )
               {
                  AV53WWP_DF_StepMetadata.FromJSonString(AV11CurrentElement.gxTpr_Wwpformelementmetadata, null);
                  AV8Columns = AV53WWP_DF_StepMetadata.gxTpr_Columns;
                  AssignAttri(sPrefix, false, "AV8Columns", StringUtil.LTrimStr( (decimal)(AV8Columns), 2, 0));
                  AV43VisibleCondition = AV53WWP_DF_StepMetadata.gxTpr_Visiblecondition.gxTpr_Expression;
                  AssignAttri(sPrefix, false, "AV43VisibleCondition", AV43VisibleCondition);
                  AV39Validations = AV53WWP_DF_StepMetadata.gxTpr_Validations;
                  gx_BV270 = true;
               }
               else if ( AV64WWPFormElementType == 3 )
               {
                  AV49WWP_DF_ElementsRepeaterMetadata.FromJSonString(AV11CurrentElement.gxTpr_Wwpformelementmetadata, null);
                  AV8Columns = AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Columns;
                  AssignAttri(sPrefix, false, "AV8Columns", StringUtil.LTrimStr( (decimal)(AV8Columns), 2, 0));
                  AV43VisibleCondition = AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Visiblecondition.gxTpr_Expression;
                  AssignAttri(sPrefix, false, "AV43VisibleCondition", AV43VisibleCondition);
               }
               else if ( AV64WWPFormElementType == 4 )
               {
                  AV51WWP_DF_LabelMetadata.FromJSonString(AV11CurrentElement.gxTpr_Wwpformelementmetadata, null);
                  AV43VisibleCondition = AV51WWP_DF_LabelMetadata.gxTpr_Visiblecondition.gxTpr_Expression;
                  AssignAttri(sPrefix, false, "AV43VisibleCondition", AV43VisibleCondition);
               }
               else if ( AV64WWPFormElementType == 1 )
               {
                  if ( AV58WWPFormElementDataType == 2 )
                  {
                     AV46WWP_DF_CharMetadata.FromJSonString(AV11CurrentElement.gxTpr_Wwpformelementmetadata, null);
                     AV43VisibleCondition = AV46WWP_DF_CharMetadata.gxTpr_Visiblecondition.gxTpr_Expression;
                     AssignAttri(sPrefix, false, "AV43VisibleCondition", AV43VisibleCondition);
                     AV39Validations = AV46WWP_DF_CharMetadata.gxTpr_Validations;
                     gx_BV270 = true;
                     AV24IsRequired = AV46WWP_DF_CharMetadata.gxTpr_Isrequired;
                     AssignAttri(sPrefix, false, "AV24IsRequired", AV24IsRequired);
                     if ( AV46WWP_DF_CharMetadata.gxTpr_Controltype == 4 )
                     {
                        AV10Control = "Options";
                        AssignAttri(sPrefix, false, "AV10Control", AV10Control);
                        if ( AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 1 )
                        {
                           AV30PredOptions_Type = "Combo";
                           AssignAttri(sPrefix, false, "AV30PredOptions_Type", AV30PredOptions_Type);
                        }
                        else if ( AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 4 )
                        {
                           AV30PredOptions_Type = "CheckB";
                           AssignAttri(sPrefix, false, "AV30PredOptions_Type", AV30PredOptions_Type);
                        }
                        else if ( AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 3 )
                        {
                           AV30PredOptions_Type = "Radio";
                           AssignAttri(sPrefix, false, "AV30PredOptions_Type", AV30PredOptions_Type);
                           AV32Radio_Direction = (AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Radiobutton.gxTpr_Directionvertical ? "Vertical" : "Horizontal");
                           AssignAttri(sPrefix, false, "AV32Radio_Direction", AV32Radio_Direction);
                        }
                        else if ( AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype == 2 )
                        {
                           AV30PredOptions_Type = "Suggest";
                           AssignAttri(sPrefix, false, "AV30PredOptions_Type", AV30PredOptions_Type);
                        }
                        if ( AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Hasdynamicoptions )
                        {
                           AV31PredOptions_Values = "Service";
                           AssignAttri(sPrefix, false, "AV31PredOptions_Values", AV31PredOptions_Values);
                        }
                        else
                        {
                           AV101GXV32 = 1;
                           while ( AV101GXV32 <= AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Options.Count )
                           {
                              AV41VarCharAux = ((string)AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Options.Item(AV101GXV32));
                              if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV29PredOptions_Options))) )
                              {
                                 AV29PredOptions_Options += StringUtil.NewLine( );
                                 AssignAttri(sPrefix, false, "AV29PredOptions_Options", AV29PredOptions_Options);
                              }
                              AV29PredOptions_Options += AV41VarCharAux;
                              AssignAttri(sPrefix, false, "AV29PredOptions_Options", AV29PredOptions_Options);
                              AV101GXV32 = (int)(AV101GXV32+1);
                           }
                        }
                     }
                     else if ( AV46WWP_DF_CharMetadata.gxTpr_Controltype == 3 )
                     {
                        AV10Control = "Textarea";
                        AssignAttri(sPrefix, false, "AV10Control", AV10Control);
                        AV36TextArea_Format = "Rich";
                        AssignAttri(sPrefix, false, "AV36TextArea_Format", AV36TextArea_Format);
                     }
                     else if ( AV46WWP_DF_CharMetadata.gxTpr_Controltype == 1 )
                     {
                     }
                     else if ( AV46WWP_DF_CharMetadata.gxTpr_Controltype == 2 )
                     {
                        AV10Control = "Textarea";
                        AssignAttri(sPrefix, false, "AV10Control", AV10Control);
                     }
                  }
                  else if ( AV58WWPFormElementDataType == 1 )
                  {
                     AV45WWP_DF_BooleanMetadata.FromJSonString(AV11CurrentElement.gxTpr_Wwpformelementmetadata, null);
                     AV10Control = ((AV45WWP_DF_BooleanMetadata.gxTpr_Controltype==1) ? "Checkbox" : "Switch");
                     AssignAttri(sPrefix, false, "AV10Control", AV10Control);
                     AV43VisibleCondition = AV45WWP_DF_BooleanMetadata.gxTpr_Visiblecondition.gxTpr_Expression;
                     AssignAttri(sPrefix, false, "AV43VisibleCondition", AV43VisibleCondition);
                     AV39Validations = AV45WWP_DF_BooleanMetadata.gxTpr_Validations;
                     gx_BV270 = true;
                  }
                  else if ( ( AV58WWPFormElementDataType == 4 ) || ( AV58WWPFormElementDataType == 5 ) )
                  {
                     AV10Control = "Date";
                     AssignAttri(sPrefix, false, "AV10Control", AV10Control);
                     AV14Date_IncludeTime = (bool)(((AV58WWPFormElementDataType==5)));
                     AssignAttri(sPrefix, false, "AV14Date_IncludeTime", AV14Date_IncludeTime);
                     AV48WWP_DF_DateMetadata.FromJSonString(AV11CurrentElement.gxTpr_Wwpformelementmetadata, null);
                     AV43VisibleCondition = AV48WWP_DF_DateMetadata.gxTpr_Visiblecondition.gxTpr_Expression;
                     AssignAttri(sPrefix, false, "AV43VisibleCondition", AV43VisibleCondition);
                     AV39Validations = AV48WWP_DF_DateMetadata.gxTpr_Validations;
                     gx_BV270 = true;
                     AV24IsRequired = AV48WWP_DF_DateMetadata.gxTpr_Isrequired;
                     AssignAttri(sPrefix, false, "AV24IsRequired", AV24IsRequired);
                  }
                  else if ( AV58WWPFormElementDataType == 7 )
                  {
                     AV35Text_Format = "Email";
                     AssignAttri(sPrefix, false, "AV35Text_Format", AV35Text_Format);
                     AV46WWP_DF_CharMetadata.FromJSonString(AV11CurrentElement.gxTpr_Wwpformelementmetadata, null);
                     AV43VisibleCondition = AV46WWP_DF_CharMetadata.gxTpr_Visiblecondition.gxTpr_Expression;
                     AssignAttri(sPrefix, false, "AV43VisibleCondition", AV43VisibleCondition);
                     AV39Validations = AV46WWP_DF_CharMetadata.gxTpr_Validations;
                     gx_BV270 = true;
                     AV24IsRequired = AV46WWP_DF_CharMetadata.gxTpr_Isrequired;
                     AssignAttri(sPrefix, false, "AV24IsRequired", AV24IsRequired);
                  }
                  else if ( AV58WWPFormElementDataType == 9 )
                  {
                     AV10Control = "File";
                     AssignAttri(sPrefix, false, "AV10Control", AV10Control);
                  }
                  else if ( AV58WWPFormElementDataType == 10 )
                  {
                     AV10Control = "File";
                     AssignAttri(sPrefix, false, "AV10Control", AV10Control);
                     AV17File_Format = "Image";
                     AssignAttri(sPrefix, false, "AV17File_Format", AV17File_Format);
                     AV50WWP_DF_ImageMetadata.FromJSonString(AV11CurrentElement.gxTpr_Wwpformelementmetadata, null);
                     AV43VisibleCondition = AV50WWP_DF_ImageMetadata.gxTpr_Visiblecondition.gxTpr_Expression;
                     AssignAttri(sPrefix, false, "AV43VisibleCondition", AV43VisibleCondition);
                     AV39Validations = AV50WWP_DF_ImageMetadata.gxTpr_Validations;
                     gx_BV270 = true;
                     AV24IsRequired = AV50WWP_DF_ImageMetadata.gxTpr_Isrequired;
                     AssignAttri(sPrefix, false, "AV24IsRequired", AV24IsRequired);
                  }
                  else if ( AV58WWPFormElementDataType == 3 )
                  {
                     AV10Control = "Number";
                     AssignAttri(sPrefix, false, "AV10Control", AV10Control);
                     AV52WWP_DF_NumericMetadata.FromJSonString(AV11CurrentElement.gxTpr_Wwpformelementmetadata, null);
                     AV43VisibleCondition = AV52WWP_DF_NumericMetadata.gxTpr_Visiblecondition.gxTpr_Expression;
                     AssignAttri(sPrefix, false, "AV43VisibleCondition", AV43VisibleCondition);
                     AV39Validations = AV52WWP_DF_NumericMetadata.gxTpr_Validations;
                     gx_BV270 = true;
                     AV24IsRequired = AV52WWP_DF_NumericMetadata.gxTpr_Isrequired;
                     AssignAttri(sPrefix, false, "AV24IsRequired", AV24IsRequired);
                  }
                  else if ( AV58WWPFormElementDataType == 6 )
                  {
                     AV10Control = "Password";
                     AssignAttri(sPrefix, false, "AV10Control", AV10Control);
                     AV52WWP_DF_NumericMetadata.FromJSonString(AV11CurrentElement.gxTpr_Wwpformelementmetadata, null);
                     AV43VisibleCondition = AV52WWP_DF_NumericMetadata.gxTpr_Visiblecondition.gxTpr_Expression;
                     AssignAttri(sPrefix, false, "AV43VisibleCondition", AV43VisibleCondition);
                     AV39Validations = AV52WWP_DF_NumericMetadata.gxTpr_Validations;
                     gx_BV270 = true;
                     AV24IsRequired = AV52WWP_DF_NumericMetadata.gxTpr_Isrequired;
                     AssignAttri(sPrefix, false, "AV24IsRequired", AV24IsRequired);
                  }
                  else if ( AV58WWPFormElementDataType == 8 )
                  {
                     AV10Control = "Text";
                     AssignAttri(sPrefix, false, "AV10Control", AV10Control);
                     AV35Text_Format = "Url";
                     AssignAttri(sPrefix, false, "AV35Text_Format", AV35Text_Format);
                     AV46WWP_DF_CharMetadata.FromJSonString(AV11CurrentElement.gxTpr_Wwpformelementmetadata, null);
                     AV43VisibleCondition = AV46WWP_DF_CharMetadata.gxTpr_Visiblecondition.gxTpr_Expression;
                     AssignAttri(sPrefix, false, "AV43VisibleCondition", AV43VisibleCondition);
                     AV39Validations = AV46WWP_DF_CharMetadata.gxTpr_Validations;
                     gx_BV270 = true;
                     AV24IsRequired = AV46WWP_DF_CharMetadata.gxTpr_Isrequired;
                     AssignAttri(sPrefix, false, "AV24IsRequired", AV24IsRequired);
                  }
               }
            }
         }
         if ( AV39Validations.Count == 0 )
         {
            subGridvalidations_Visible = 0;
            AssignProp(sPrefix, false, sPrefix+"GridvalidationsContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridvalidations_Visible), 5, 0), true);
         }
         if ( ( AV64WWPFormElementType == 5 ) || ( StringUtil.StrCmp(AV54WWPDynamicFormMode, "INS") != 0 ) || AV28ParentIsGridMultipleData || ( AV61WWPFormElementParentId == 0 ) )
         {
            cmbavWwpformelementtype.Enabled = 0;
            AssignProp(sPrefix, false, cmbavWwpformelementtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavWwpformelementtype.Enabled), 5, 0), true);
         }
         else
         {
            cmbavWwpformelementtype.removeItem(StringUtil.Str( (decimal)(5), 1, 0));
            if ( ( StringUtil.StrCmp(AV54WWPDynamicFormMode, "INS") != 0 ) && ( ( AV64WWPFormElementType == 2 ) || ( AV64WWPFormElementType == 3 ) ) )
            {
               cmbavWwpformelementtype.removeItem(StringUtil.Str( (decimal)(1), 1, 0));
               cmbavWwpformelementtype.removeItem(StringUtil.Str( (decimal)(4), 1, 0));
            }
         }
         if ( ! AV22IsFormSettings && ( ( StringUtil.StrCmp(AV54WWPDynamicFormMode, "INS") == 0 ) || ( AV64WWPFormElementType == 3 ) ) )
         {
            cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.addItem(StringUtil.Str( (decimal)(0), 1, 0), "", 0);
            AV102GXV33 = 1;
            while ( AV102GXV33 <= AV55WWPForm.gxTpr_Element.Count )
            {
               AV15ElementAux = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV55WWPForm.gxTpr_Element.Item(AV102GXV33));
               if ( ( AV15ElementAux.gxTpr_Wwpformelementparentid >= 0 ) && ( AV15ElementAux.gxTpr_Wwpformelementtype == 1 ) && ( AV15ElementAux.gxTpr_Wwpformelementdatatype == 3 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV15ElementAux.gxTpr_Wwpformelementreferenceid))) )
               {
                  cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.addItem(StringUtil.LTrimStr( (decimal)(AV15ElementAux.gxTpr_Wwpformelementid), 4, 0), AV15ElementAux.gxTpr_Wwpformelementreferenceid, 0);
               }
               AV102GXV33 = (int)(AV102GXV33+1);
            }
         }
         lblVisibleconditionhelpicon_Caption = StringUtil.StringReplace( lblVisibleconditionhelpicon_Caption, "VisibleConditionHelpText", context.GetMessage( "WWP_DF_VisibleConditionTooltip", ""));
         AssignProp(sPrefix, false, lblVisibleconditionhelpicon_Internalname, "Caption", lblVisibleconditionhelpicon_Caption, true);
         if ( (0==AV8Columns) )
         {
            AV8Columns = 1;
            AssignAttri(sPrefix, false, "AV8Columns", StringUtil.LTrimStr( (decimal)(AV8Columns), 2, 0));
         }
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         lblVisibleconditionhelpicon_Caption = StringUtil.Format( "<i class='BootstrapTooltipLeft fas fa-circle-info' title='%1'></i>", context.GetMessage( "VisibleConditionHelpText", ""), "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblVisibleconditionhelpicon_Internalname, "Caption", lblVisibleconditionhelpicon_Caption, true);
         lblReferencieidhelpicon_Caption = StringUtil.Format( "<i class='BootstrapTooltipLeft fas fa-circle-info' title='%1'></i>", context.GetMessage( "I18N_REFERENCEIDHELPICON", ""), "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblReferencieidhelpicon_Internalname, "Caption", lblReferencieidhelpicon_Caption, true);
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "Mask_Apply", new Object[] {(string)edtavWwpformelementreferenceid_Internalname,(string)"AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",(bool)false,(bool)false}, false);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         cmbavWwpform_wwpformresume.Visible = 0;
         AssignProp(sPrefix, false, cmbavWwpform_wwpformresume_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwpform_wwpformresume.Visible), 5, 0), true);
         cmbavWwp_df_containermetadata_style.Visible = 0;
         AssignProp(sPrefix, false, cmbavWwp_df_containermetadata_style_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwp_df_containermetadata_style.Visible), 5, 0), true);
         edtavColumns_Visible = 0;
         AssignProp(sPrefix, false, edtavColumns_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavColumns_Visible), 5, 0), true);
         Gridvalidations_empowerer_Gridinternalname = subGridvalidations_Internalname;
         ucGridvalidations_empowerer.SendProperty(context, sPrefix, false, Gridvalidations_empowerer_Internalname, "GridInternalName", Gridvalidations_empowerer_Gridinternalname);
         subGridvalidations_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDVALIDATIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Rows), 6, 0, ".", "")));
      }

      protected void E32272( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      private void E33272( )
      {
         /* Gridvalidations_Load Routine */
         returnInSub = false;
         AV97GXV28 = 1;
         while ( AV97GXV28 <= AV39Validations.Count )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
            AV21IsFirstValidation = (bool)(((AV39Validations.IndexOf(((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV39Validations.CurrentItem)))==1)));
            AV23IsLastValidation = (bool)(((AV39Validations.IndexOf(((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV39Validations.CurrentItem)))==AV39Validations.Count)));
            cmbavGridactiongroup1.removeAllItems();
            cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
            cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fas fa-pencil", "", "", "", "", "", "", ""), 0);
            cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "far fa-trash-can", "", "", "", "", "", "", ""), 0);
            if ( ! AV21IsFirstValidation )
            {
               cmbavGridactiongroup1.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "WWP_DF_MoveUp", ""), "fas fa-arrow-up", "", "", "", "", "", "", ""), 0);
            }
            if ( ! AV23IsLastValidation )
            {
               cmbavGridactiongroup1.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "WWP_DF_MoveDown", ""), "fas fa-arrow-down", "", "", "", "", "", "", ""), 0);
            }
            GXt_char3 = AV40Validations__MessageWithTags;
            new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV39Validations.CurrentItem)).gxTpr_Message, out  GXt_char3) ;
            AV40Validations__MessageWithTags = GXt_char3;
            AssignAttri(sPrefix, false, edtavValidations__messagewithtags_Internalname, AV40Validations__MessageWithTags);
            if ( 1 == 1 )
            {
               AV40Validations__MessageWithTags = StringUtil.Format( "<i class='fa fa-check-circle FontColorIconSuccess	 TagBeforeText BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "ValidationTooltip", ""), "", "", "", "", "", "", "", "") + AV40Validations__MessageWithTags;
               AssignAttri(sPrefix, false, edtavValidations__messagewithtags_Internalname, AV40Validations__MessageWithTags);
            }
            AV34Text = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV39Validations.CurrentItem)).gxTpr_Condition.gxTpr_Expression;
            AV40Validations__MessageWithTags = StringUtil.StringReplace( AV40Validations__MessageWithTags, "ValidationTooltip", StringUtil.StringReplace( AV34Text, "'", "\""));
            AssignAttri(sPrefix, false, edtavValidations__messagewithtags_Internalname, AV40Validations__MessageWithTags);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 270;
            }
            if ( ( subGridvalidations_Islastpage == 1 ) || ( subGridvalidations_Rows == 0 ) || ( ( GRIDVALIDATIONS_nCurrentRecord >= GRIDVALIDATIONS_nFirstRecordOnPage ) && ( GRIDVALIDATIONS_nCurrentRecord < GRIDVALIDATIONS_nFirstRecordOnPage + subGridvalidations_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_2702( ) ;
            }
            GRIDVALIDATIONS_nEOF = (short)(((GRIDVALIDATIONS_nCurrentRecord<GRIDVALIDATIONS_nFirstRecordOnPage+subGridvalidations_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDVALIDATIONS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDVALIDATIONS_nEOF), 1, 0, ".", "")));
            GRIDVALIDATIONS_nCurrentRecord = (long)(GRIDVALIDATIONS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_270_Refreshing )
            {
               DoAjaxLoad(270, GridvalidationsRow);
            }
            AV97GXV28 = (int)(AV97GXV28+1);
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridActionGroup1), 4, 0));
      }

      protected void E13272( )
      {
         /* Addvalidation_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_EditValidation")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_editvalidation", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_EditValidation";
            WebComp_Wwpaux_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_EditValidation";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0299",(string)"",(string)AV54WWPDynamicFormMode,(short)AV61WWPFormElementParentId,(short)AV60WWPFormElementId,(string)AV62WWPFormElementReferenceId,(short)AV58WWPFormElementDataType,(short)AV33SessionId,(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)sPrefix+"vWWPFORMELEMENTREFERENCEID",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0299"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E34272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV19GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO UPDATEVALIDATION' */
            S132 ();
            if (returnInSub) return;
         }
         else if ( AV19GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO DELETEVALIDATION' */
            S142 ();
            if (returnInSub) return;
         }
         else if ( AV19GridActionGroup1 == 3 )
         {
            /* Execute user subroutine: 'DO MOVEUP' */
            S152 ();
            if (returnInSub) return;
         }
         else if ( AV19GridActionGroup1 == 4 )
         {
            /* Execute user subroutine: 'DO MOVEDOWN' */
            S162 ();
            if (returnInSub) return;
         }
         AV19GridActionGroup1 = 0;
         AssignAttri(sPrefix, false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV19GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridActionGroup1), 4, 0));
         AssignProp(sPrefix, false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
         nGXsfl_270_bak_idx = nGXsfl_270_idx;
         gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
         nGXsfl_270_idx = nGXsfl_270_bak_idx;
         sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
         SubsflControlProps_2702( ) ;
      }

      protected void E15272( )
      {
         /* Updatevalidation_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_EditValidation")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_editvalidation", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_EditValidation";
            WebComp_Wwpaux_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_EditValidation";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0299",(string)"",(string)AV54WWPDynamicFormMode,(short)AV61WWPFormElementParentId,(short)AV60WWPFormElementId,(string)AV62WWPFormElementReferenceId,(short)AV58WWPFormElementDataType,(short)AV33SessionId,(string)AV38ValidationJson});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)sPrefix+"vWWPFORMELEMENTREFERENCEID",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0299"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E16272( )
      {
         /* 'DoTestVisibleCondition' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV43VisibleCondition))) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "WWP_DF_EnterConditionToValidate", ""),  "error",  edtavVisiblecondition_Internalname,  "true",  ""));
         }
         else
         {
            AV16ExecuteConditionToTest = true;
            AssignAttri(sPrefix, false, "AV16ExecuteConditionToTest", AV16ExecuteConditionToTest);
            GXt_char3 = AV41VarCharAux;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getavailablevariables(context ).execute(  AV33SessionId,  false,  AV60WWPFormElementId,  9999,  "", out  GXt_char3) ;
            AV41VarCharAux = GXt_char3;
            AV5AllReferenceIds.FromJSonString(StringUtil.Lower( AV41VarCharAux), null);
            /* Execute user subroutine: 'VALIDATE VISIBILITY CONDITION' */
            S172 ();
            if (returnInSub) return;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9ConditionError)) )
            {
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "WWP_DF_ConditionExecSuccessfully", ""),  "success",  "",  "true",  ""));
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5AllReferenceIds", AV5AllReferenceIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV44VisibleConditionExpression", AV44VisibleConditionExpression);
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( AV64WWPFormElementType != 3 ) ) )
         {
            Btnaddvalidation_Visible = false;
            ucBtnaddvalidation.SendProperty(context, sPrefix, false, Btnaddvalidation_Internalname, "Visible", StringUtil.BoolToStr( Btnaddvalidation_Visible));
         }
      }

      protected void S132( )
      {
         /* 'DO UPDATEVALIDATION' Routine */
         returnInSub = false;
         AV13CurrentValidationIndex = (short)(AV39Validations.IndexOf(((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV39Validations.CurrentItem))));
         AssignAttri(sPrefix, false, "AV13CurrentValidationIndex", StringUtil.LTrimStr( (decimal)(AV13CurrentValidationIndex), 4, 0));
         AV38ValidationJson = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV39Validations.CurrentItem)).ToJSonString(false, true);
         AssignAttri(sPrefix, false, "AV38ValidationJson", AV38ValidationJson);
         this.executeUsercontrolMethod(sPrefix, false, "UPDATEVALIDATION_MODALContainer", "Confirm", "", new Object[] {});
      }

      protected void S142( )
      {
         /* 'DO DELETEVALIDATION' Routine */
         returnInSub = false;
         AV39Validations.RemoveItem(AV39Validations.IndexOf(((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV39Validations.CurrentItem))));
         gx_BV270 = true;
         if ( AV39Validations.Count == 0 )
         {
            subGridvalidations_Visible = 0;
            AssignProp(sPrefix, false, sPrefix+"GridvalidationsContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridvalidations_Visible), 5, 0), true);
         }
      }

      protected void S152( )
      {
         /* 'DO MOVEUP' Routine */
         returnInSub = false;
         AV12CurrentValidation = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV39Validations.CurrentItem));
         AV20Index = (short)(AV39Validations.IndexOf(((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV39Validations.CurrentItem))));
         AV39Validations.RemoveItem(AV20Index);
         gx_BV270 = true;
         AV39Validations.Add(AV12CurrentValidation, AV20Index-1);
         gx_BV270 = true;
      }

      protected void S162( )
      {
         /* 'DO MOVEDOWN' Routine */
         returnInSub = false;
         AV12CurrentValidation = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV39Validations.CurrentItem));
         AV20Index = (short)(AV39Validations.IndexOf(((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV39Validations.CurrentItem))));
         AV39Validations.RemoveItem(AV20Index);
         gx_BV270 = true;
         AV39Validations.Add(AV12CurrentValidation, AV20Index+1);
         gx_BV270 = true;
      }

      protected void S182( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV7CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         if ( ( AV22IsFormSettings ) && String.IsNullOrEmpty(StringUtil.RTrim( AV55WWPForm.gxTpr_Wwpformtitle)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_DF_Title", ""), "", "", "", "", "", "", "", ""),  "error",  edtavWwpform_wwpformtitle_Internalname,  "true",  ""));
            AV7CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         }
         if ( ( AV22IsFormSettings ) && String.IsNullOrEmpty(StringUtil.RTrim( AV55WWPForm.gxTpr_Wwpformreferencename)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_DF_ReferenceName", ""), "", "", "", "", "", "", "", ""),  "error",  edtavWwpform_wwpformreferencename_Internalname,  "true",  ""));
            AV7CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         }
         if ( ( AV22IsFormSettings && ( AV55WWPForm.gxTpr_Wwpformresume == 1 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV55WWPForm.gxTpr_Wwpformresumemessage)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_DF_ResumeMessage", ""), "", "", "", "", "", "", "", ""),  "error",  edtavWwpform_wwpformresumemessage_Internalname,  "true",  ""));
            AV7CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         }
         if ( ( ! AV22IsFormSettings && ( AV64WWPFormElementType != 3 ) && ( ( AV64WWPFormElementType != 2 ) || ( AV47WWP_DF_ContainerMetadata.gxTpr_Style == 2 ) ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV63WWPFormElementTitle)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_DF_Title", ""), "", "", "", "", "", "", "", ""),  "error",  edtavWwpformelementtitle_Internalname,  "true",  ""));
            AV7CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         }
         if ( ( ( ( AV64WWPFormElementType == 1 ) || ( AV64WWPFormElementType == 3 ) ) && ( AV55WWPForm.gxTpr_Wwpformtype == 1 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV62WWPFormElementReferenceId)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_DF_ReferenceId", ""), "", "", "", "", "", "", "", ""),  "error",  edtavWwpformelementreferenceid_Internalname,  "true",  ""));
            AV7CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         }
         if ( ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Options") == 0 ) && ( StringUtil.StrCmp(AV31PredOptions_Values, "Service") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Dynamic.gxTpr_Getoptionsservice)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_DF_ServiceURL", ""), "", "", "", "", "", "", "", ""),  "error",  edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Internalname,  "true",  ""));
            AV7CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         }
         if ( ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Options") == 0 ) && ( StringUtil.StrCmp(AV31PredOptions_Values, "Fixed") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV29PredOptions_Options)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_DF_Options", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPredoptions_options_Internalname,  "true",  ""));
            AV7CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         }
         if ( ( ( AV64WWPFormElementType == 3 ) && ( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildcaption)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_DF_InsertChildCaption", ""), "", "", "", "", "", "", "", ""),  "error",  edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Internalname,  "true",  ""));
            AV7CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         }
         if ( ( ( AV64WWPFormElementType == 3 ) && ( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) ) && (0==AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Maxrepetitions) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_DF_MaxRepetitions", ""), "", "", "", "", "", "", "", ""),  "error",  edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Internalname,  "true",  ""));
            AV7CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         }
         if ( ( ( AV64WWPFormElementType == 3 ) && ( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 2 ) ) && (0==AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_fixedvalue.gxTpr_Value) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_DF_RepetitionsValue", ""), "", "", "", "", "", "", "", ""),  "error",  edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Internalname,  "true",  ""));
            AV7CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         }
         if ( ( ( AV64WWPFormElementType == 3 ) && ( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 3 ) ) && (0==AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_variable.gxTpr_Elementid) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_DF_RepetitionsCountVariable", ""), "", "", "", "", "", "", "", ""),  "error",  cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Internalname,  "true",  ""));
            AV7CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(AV30PredOptions_Type, "Combo") != 0 ) && ( StringUtil.StrCmp(AV30PredOptions_Type, "Suggest") != 0 ) && ( StringUtil.StrCmp(AV31PredOptions_Values, "Fixed") != 0 ) )
         {
            AV31PredOptions_Values = "Fixed";
            AssignAttri(sPrefix, false, "AV31PredOptions_Values", AV31PredOptions_Values);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( AV58WWPFormElementDataType != 1 ) ) )
         {
            chkavIsrequired.Visible = 0;
            AssignProp(sPrefix, false, chkavIsrequired_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsrequired.Visible), 5, 0), true);
            divIsrequired_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divIsrequired_cell_Internalname, "Class", divIsrequired_cell_Class, true);
         }
         else
         {
            chkavIsrequired.Visible = 1;
            AssignProp(sPrefix, false, chkavIsrequired_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsrequired.Visible), 5, 0), true);
            divIsrequired_cell_Class = "col-xs-12 col-sm-9 DataContentCell DscTop";
            AssignProp(sPrefix, false, divIsrequired_cell_Internalname, "Class", divIsrequired_cell_Class, true);
         }
         if ( ! ( ! ( ( AV64WWPFormElementType == 1 ) && ( ( StringUtil.StrCmp(AV10Control, "File") == 0 ) && ( StringUtil.StrCmp(AV17File_Format, "Any") == 0 ) || ( StringUtil.StrCmp(AV10Control, "Password") == 0 ) || ( ( StringUtil.StrCmp(AV10Control, "Text") == 0 ) && ( StringUtil.StrCmp(AV36TextArea_Format, "Rich") == 0 ) ) ) ) ) )
         {
            chkavWwpformelementexcludefromexport.Visible = 0;
            AssignProp(sPrefix, false, chkavWwpformelementexcludefromexport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwpformelementexcludefromexport.Visible), 5, 0), true);
            divWwpformelementexcludefromexport_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwpformelementexcludefromexport_cell_Internalname, "Class", divWwpformelementexcludefromexport_cell_Class, true);
         }
         else
         {
            chkavWwpformelementexcludefromexport.Visible = 1;
            AssignProp(sPrefix, false, chkavWwpformelementexcludefromexport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwpformelementexcludefromexport.Visible), 5, 0), true);
            divWwpformelementexcludefromexport_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwpformelementexcludefromexport_cell_Internalname, "Class", divWwpformelementexcludefromexport_cell_Class, true);
         }
         if ( ! ( AV22IsFormSettings ) )
         {
            radavFormtype.Visible = 0;
            AssignProp(sPrefix, false, radavFormtype_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(radavFormtype.Visible), 5, 0), true);
            divFormtype_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divFormtype_cell_Internalname, "Class", divFormtype_cell_Class, true);
         }
         else
         {
            radavFormtype.Visible = 1;
            AssignProp(sPrefix, false, radavFormtype_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(radavFormtype.Visible), 5, 0), true);
            divFormtype_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divFormtype_cell_Internalname, "Class", divFormtype_cell_Class, true);
         }
         if ( ! ( AV22IsFormSettings ) )
         {
            edtavWwpform_wwpformtitle_Visible = 0;
            AssignProp(sPrefix, false, edtavWwpform_wwpformtitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpform_wwpformtitle_Visible), 5, 0), true);
            divWwpform_wwpformtitle_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwpform_wwpformtitle_cell_Internalname, "Class", divWwpform_wwpformtitle_cell_Class, true);
         }
         else
         {
            edtavWwpform_wwpformtitle_Visible = 1;
            AssignProp(sPrefix, false, edtavWwpform_wwpformtitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpform_wwpformtitle_Visible), 5, 0), true);
            divWwpform_wwpformtitle_cell_Class = "col-xs-12 RequiredDataContentCell DscTop";
            AssignProp(sPrefix, false, divWwpform_wwpformtitle_cell_Internalname, "Class", divWwpform_wwpformtitle_cell_Class, true);
         }
         if ( ! ( AV22IsFormSettings ) )
         {
            edtavWwpform_wwpformreferencename_Visible = 0;
            AssignProp(sPrefix, false, edtavWwpform_wwpformreferencename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpform_wwpformreferencename_Visible), 5, 0), true);
            divWwpform_wwpformreferencename_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwpform_wwpformreferencename_cell_Internalname, "Class", divWwpform_wwpformreferencename_cell_Class, true);
         }
         else
         {
            edtavWwpform_wwpformreferencename_Visible = 1;
            AssignProp(sPrefix, false, edtavWwpform_wwpformreferencename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpform_wwpformreferencename_Visible), 5, 0), true);
            divWwpform_wwpformreferencename_cell_Class = "col-xs-12 RequiredDataContentCell DscTop";
            AssignProp(sPrefix, false, divWwpform_wwpformreferencename_cell_Internalname, "Class", divWwpform_wwpformreferencename_cell_Class, true);
         }
         if ( ! ( AV22IsFormSettings && ( AV55WWPForm.gxTpr_Wwpformresume == 1 ) ) )
         {
            edtavWwpform_wwpformresumemessage_Visible = 0;
            AssignProp(sPrefix, false, edtavWwpform_wwpformresumemessage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpform_wwpformresumemessage_Visible), 5, 0), true);
            divWwpform_wwpformresumemessage_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwpform_wwpformresumemessage_cell_Internalname, "Class", divWwpform_wwpformresumemessage_cell_Class, true);
         }
         else
         {
            edtavWwpform_wwpformresumemessage_Visible = 1;
            AssignProp(sPrefix, false, edtavWwpform_wwpformresumemessage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpform_wwpformresumemessage_Visible), 5, 0), true);
            divWwpform_wwpformresumemessage_cell_Class = "col-xs-12 RequiredDataContentCell DscTop";
            AssignProp(sPrefix, false, divWwpform_wwpformresumemessage_cell_Internalname, "Class", divWwpform_wwpformresumemessage_cell_Class, true);
         }
         if ( ! ( ! AV22IsFormSettings ) )
         {
            cmbavWwpformelementtype.Visible = 0;
            AssignProp(sPrefix, false, cmbavWwpformelementtype_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwpformelementtype.Visible), 5, 0), true);
            divWwpformelementtype_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwpformelementtype_cell_Internalname, "Class", divWwpformelementtype_cell_Class, true);
         }
         else
         {
            cmbavWwpformelementtype.Visible = 1;
            AssignProp(sPrefix, false, cmbavWwpformelementtype_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwpformelementtype.Visible), 5, 0), true);
            divWwpformelementtype_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwpformelementtype_cell_Internalname, "Class", divWwpformelementtype_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ! AV28ParentIsGridMultipleData ) )
         {
            cmbavWwpformelementcaption.Visible = 0;
            AssignProp(sPrefix, false, cmbavWwpformelementcaption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwpformelementcaption.Visible), 5, 0), true);
            divWwpformelementcaption_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwpformelementcaption_cell_Internalname, "Class", divWwpformelementcaption_cell_Class, true);
         }
         else
         {
            cmbavWwpformelementcaption.Visible = 1;
            AssignProp(sPrefix, false, cmbavWwpformelementcaption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwpformelementcaption.Visible), 5, 0), true);
            divWwpformelementcaption_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwpformelementcaption_cell_Internalname, "Class", divWwpformelementcaption_cell_Class, true);
         }
         if ( ! ( ! AV22IsFormSettings && ( AV64WWPFormElementType != 3 ) && ( ( AV64WWPFormElementType != 2 ) || ( AV47WWP_DF_ContainerMetadata.gxTpr_Style == 2 ) ) ) )
         {
            edtavWwpformelementtitle_Visible = 0;
            AssignProp(sPrefix, false, edtavWwpformelementtitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpformelementtitle_Visible), 5, 0), true);
            divWwpformelementtitle_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwpformelementtitle_cell_Internalname, "Class", divWwpformelementtitle_cell_Class, true);
         }
         else
         {
            edtavWwpformelementtitle_Visible = 1;
            AssignProp(sPrefix, false, edtavWwpformelementtitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpformelementtitle_Visible), 5, 0), true);
            if ( ! AV22IsFormSettings && ( AV64WWPFormElementType != 3 ) && ( ( AV64WWPFormElementType != 2 ) || ( AV47WWP_DF_ContainerMetadata.gxTpr_Style == 2 ) ) )
            {
               divWwpformelementtitle_cell_Class = "col-xs-12 RequiredDataContentCell DscTop";
               AssignProp(sPrefix, false, divWwpformelementtitle_cell_Internalname, "Class", divWwpformelementtitle_cell_Class, true);
            }
            else
            {
               divWwpformelementtitle_cell_Class = "col-xs-12 DataContentCell DscTop";
               AssignProp(sPrefix, false, divWwpformelementtitle_cell_Internalname, "Class", divWwpformelementtitle_cell_Class, true);
            }
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) || ( AV64WWPFormElementType == 3 ) ) )
         {
            edtavWwpformelementreferenceid_Visible = 0;
            AssignProp(sPrefix, false, edtavWwpformelementreferenceid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpformelementreferenceid_Visible), 5, 0), true);
            cellWwpformelementreferenceid_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellWwpformelementreferenceid_cell_Internalname, "Class", cellWwpformelementreferenceid_cell_Class, true);
            divTextblockwwpformelementreferenceid_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divTextblockwwpformelementreferenceid_cell_Internalname, "Class", divTextblockwwpformelementreferenceid_cell_Class, true);
         }
         else
         {
            edtavWwpformelementreferenceid_Visible = 1;
            AssignProp(sPrefix, false, edtavWwpformelementreferenceid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpformelementreferenceid_Visible), 5, 0), true);
            divTextblockwwpformelementreferenceid_cell_Class = "col-sm-12 MergeLabelCell";
            AssignProp(sPrefix, false, divTextblockwwpformelementreferenceid_cell_Internalname, "Class", divTextblockwwpformelementreferenceid_cell_Class, true);
            if ( ( ( AV64WWPFormElementType == 1 ) || ( AV64WWPFormElementType == 3 ) ) && ( AV55WWPForm.gxTpr_Wwpformtype == 1 ) )
            {
               divWwpformelementreferenceidmt_cell_Class = "col-xs-12 RequiredDataContentCell DscTop";
               AssignProp(sPrefix, false, divWwpformelementreferenceidmt_cell_Internalname, "Class", divWwpformelementreferenceidmt_cell_Class, true);
            }
            else
            {
               divWwpformelementreferenceidmt_cell_Class = "col-xs-12 DataContentCell DscTop";
               AssignProp(sPrefix, false, divWwpformelementreferenceidmt_cell_Internalname, "Class", divWwpformelementreferenceidmt_cell_Class, true);
            }
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) ) )
         {
            cmbavControl.Visible = 0;
            AssignProp(sPrefix, false, cmbavControl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavControl.Visible), 5, 0), true);
            divControl_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divControl_cell_Internalname, "Class", divControl_cell_Class, true);
         }
         else
         {
            cmbavControl.Visible = 1;
            AssignProp(sPrefix, false, cmbavControl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavControl.Visible), 5, 0), true);
            divControl_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divControl_cell_Internalname, "Class", divControl_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Date") == 0 ) ) )
         {
            chkavDate_includetime.Visible = 0;
            AssignProp(sPrefix, false, chkavDate_includetime_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavDate_includetime.Visible), 5, 0), true);
            divDate_includetime_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divDate_includetime_cell_Internalname, "Class", divDate_includetime_cell_Class, true);
         }
         else
         {
            chkavDate_includetime.Visible = 1;
            AssignProp(sPrefix, false, chkavDate_includetime_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavDate_includetime.Visible), 5, 0), true);
            divDate_includetime_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divDate_includetime_cell_Internalname, "Class", divDate_includetime_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Date") == 0 ) ) )
         {
            chkavWwp_df_datemetadata_isdefaultvaluetoday.Visible = 0;
            AssignProp(sPrefix, false, chkavWwp_df_datemetadata_isdefaultvaluetoday_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_datemetadata_isdefaultvaluetoday.Visible), 5, 0), true);
            divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_datemetadata_isdefaultvaluetoday_cell_Internalname, "Class", divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class, true);
         }
         else
         {
            chkavWwp_df_datemetadata_isdefaultvaluetoday.Visible = 1;
            AssignProp(sPrefix, false, chkavWwp_df_datemetadata_isdefaultvaluetoday_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_datemetadata_isdefaultvaluetoday.Visible), 5, 0), true);
            divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_datemetadata_isdefaultvaluetoday_cell_Internalname, "Class", divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Options") == 0 ) ) )
         {
            chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.Visible = 0;
            AssignProp(sPrefix, false, chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.Visible), 5, 0), true);
            divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Internalname, "Class", divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class, true);
         }
         else
         {
            chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.Visible = 1;
            AssignProp(sPrefix, false, chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.Visible), 5, 0), true);
            divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Internalname, "Class", divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Options") == 0 ) ) )
         {
            cmbavPredoptions_type.Visible = 0;
            AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavPredoptions_type.Visible), 5, 0), true);
            divPredoptions_type_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divPredoptions_type_cell_Internalname, "Class", divPredoptions_type_cell_Class, true);
         }
         else
         {
            cmbavPredoptions_type.Visible = 1;
            AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavPredoptions_type.Visible), 5, 0), true);
            divPredoptions_type_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divPredoptions_type_cell_Internalname, "Class", divPredoptions_type_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Options") == 0 ) && ( StringUtil.StrCmp(AV31PredOptions_Values, "Service") == 0 ) ) )
         {
            edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Visible = 0;
            AssignProp(sPrefix, false, edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Visible), 5, 0), true);
            divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Internalname, "Class", divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class, true);
         }
         else
         {
            edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Visible = 1;
            AssignProp(sPrefix, false, edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Visible), 5, 0), true);
            divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class = "col-xs-12 RequiredDataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Internalname, "Class", divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Options") == 0 ) && ( StringUtil.StrCmp(AV31PredOptions_Values, "Fixed") == 0 ) ) )
         {
            edtavPredoptions_options_Visible = 0;
            AssignProp(sPrefix, false, edtavPredoptions_options_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPredoptions_options_Visible), 5, 0), true);
            divPredoptions_options_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divPredoptions_options_cell_Internalname, "Class", divPredoptions_options_cell_Class, true);
         }
         else
         {
            edtavPredoptions_options_Visible = 1;
            AssignProp(sPrefix, false, edtavPredoptions_options_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPredoptions_options_Visible), 5, 0), true);
            divPredoptions_options_cell_Class = "col-xs-12 RequiredDataContentCell DscTop";
            AssignProp(sPrefix, false, divPredoptions_options_cell_Internalname, "Class", divPredoptions_options_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Options") == 0 ) && ( StringUtil.StrCmp(AV30PredOptions_Type, "Combo") == 0 ) && ! AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection ) )
         {
            chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Visible = 0;
            AssignProp(sPrefix, false, chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Visible), 5, 0), true);
            divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Internalname, "Class", divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class, true);
         }
         else
         {
            chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Visible = 1;
            AssignProp(sPrefix, false, chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Visible), 5, 0), true);
            divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Internalname, "Class", divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Options") == 0 ) && ( StringUtil.StrCmp(AV30PredOptions_Type, "Combo") == 0 ) && ! AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection && AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue ) )
         {
            edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Visible = 0;
            AssignProp(sPrefix, false, edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Visible), 5, 0), true);
            divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Internalname, "Class", divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class, true);
         }
         else
         {
            edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Visible = 1;
            AssignProp(sPrefix, false, edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Visible), 5, 0), true);
            divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Internalname, "Class", divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( ( StringUtil.StrCmp(AV10Control, "Text") == 0 ) && ( StringUtil.StrCmp(AV35Text_Format, "Any") == 0 ) || ( StringUtil.StrCmp(AV10Control, "Password") == 0 ) ) ) )
         {
            edtavWwp_df_charmetadata_length_Visible = 0;
            AssignProp(sPrefix, false, edtavWwp_df_charmetadata_length_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_charmetadata_length_Visible), 5, 0), true);
            divWwp_df_charmetadata_length_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_charmetadata_length_cell_Internalname, "Class", divWwp_df_charmetadata_length_cell_Class, true);
         }
         else
         {
            edtavWwp_df_charmetadata_length_Visible = 1;
            AssignProp(sPrefix, false, edtavWwp_df_charmetadata_length_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_charmetadata_length_Visible), 5, 0), true);
            divWwp_df_charmetadata_length_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_charmetadata_length_cell_Internalname, "Class", divWwp_df_charmetadata_length_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( ( StringUtil.StrCmp(AV10Control, "Text") == 0 ) && ( StringUtil.StrCmp(AV35Text_Format, "Any") == 0 ) || ( StringUtil.StrCmp(AV10Control, "Options") == 0 ) && ! AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection ) ) )
         {
            edtavWwp_df_charmetadata_defaultvalue_Visible = 0;
            AssignProp(sPrefix, false, edtavWwp_df_charmetadata_defaultvalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_charmetadata_defaultvalue_Visible), 5, 0), true);
            divWwp_df_charmetadata_defaultvalue_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_charmetadata_defaultvalue_cell_Internalname, "Class", divWwp_df_charmetadata_defaultvalue_cell_Class, true);
         }
         else
         {
            edtavWwp_df_charmetadata_defaultvalue_Visible = 1;
            AssignProp(sPrefix, false, edtavWwp_df_charmetadata_defaultvalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_charmetadata_defaultvalue_Visible), 5, 0), true);
            divWwp_df_charmetadata_defaultvalue_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_charmetadata_defaultvalue_cell_Internalname, "Class", divWwp_df_charmetadata_defaultvalue_cell_Class, true);
         }
         if ( ! ( ! AV22IsFormSettings && ( AV64WWPFormElementType == 2 ) && ( AV47WWP_DF_ContainerMetadata.gxTpr_Style == 2 ) ) )
         {
            chkavWwp_df_containermetadata_collapsable.Visible = 0;
            AssignProp(sPrefix, false, chkavWwp_df_containermetadata_collapsable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_containermetadata_collapsable.Visible), 5, 0), true);
            divWwp_df_containermetadata_collapsable_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_containermetadata_collapsable_cell_Internalname, "Class", divWwp_df_containermetadata_collapsable_cell_Class, true);
         }
         else
         {
            chkavWwp_df_containermetadata_collapsable.Visible = 1;
            AssignProp(sPrefix, false, chkavWwp_df_containermetadata_collapsable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_containermetadata_collapsable.Visible), 5, 0), true);
            divWwp_df_containermetadata_collapsable_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_containermetadata_collapsable_cell_Internalname, "Class", divWwp_df_containermetadata_collapsable_cell_Class, true);
         }
         if ( ! ( ! AV22IsFormSettings && ( AV64WWPFormElementType == 2 ) && AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable && ( AV47WWP_DF_ContainerMetadata.gxTpr_Style == 2 ) ) )
         {
            chkavWwp_df_containermetadata_collapsedbydefault.Visible = 0;
            AssignProp(sPrefix, false, chkavWwp_df_containermetadata_collapsedbydefault_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_containermetadata_collapsedbydefault.Visible), 5, 0), true);
            divWwp_df_containermetadata_collapsedbydefault_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_containermetadata_collapsedbydefault_cell_Internalname, "Class", divWwp_df_containermetadata_collapsedbydefault_cell_Class, true);
         }
         else
         {
            chkavWwp_df_containermetadata_collapsedbydefault.Visible = 1;
            AssignProp(sPrefix, false, chkavWwp_df_containermetadata_collapsedbydefault_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_containermetadata_collapsedbydefault.Visible), 5, 0), true);
            divWwp_df_containermetadata_collapsedbydefault_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_containermetadata_collapsedbydefault_cell_Internalname, "Class", divWwp_df_containermetadata_collapsedbydefault_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Number") == 0 ) ) )
         {
            edtavWwp_df_numericmetadata_length_Visible = 0;
            AssignProp(sPrefix, false, edtavWwp_df_numericmetadata_length_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_numericmetadata_length_Visible), 5, 0), true);
            divWwp_df_numericmetadata_length_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_numericmetadata_length_cell_Internalname, "Class", divWwp_df_numericmetadata_length_cell_Class, true);
         }
         else
         {
            edtavWwp_df_numericmetadata_length_Visible = 1;
            AssignProp(sPrefix, false, edtavWwp_df_numericmetadata_length_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_numericmetadata_length_Visible), 5, 0), true);
            divWwp_df_numericmetadata_length_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_numericmetadata_length_cell_Internalname, "Class", divWwp_df_numericmetadata_length_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Number") == 0 ) ) )
         {
            edtavWwp_df_numericmetadata_decimals_Visible = 0;
            AssignProp(sPrefix, false, edtavWwp_df_numericmetadata_decimals_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_numericmetadata_decimals_Visible), 5, 0), true);
            divWwp_df_numericmetadata_decimals_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_numericmetadata_decimals_cell_Internalname, "Class", divWwp_df_numericmetadata_decimals_cell_Class, true);
         }
         else
         {
            edtavWwp_df_numericmetadata_decimals_Visible = 1;
            AssignProp(sPrefix, false, edtavWwp_df_numericmetadata_decimals_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_numericmetadata_decimals_Visible), 5, 0), true);
            divWwp_df_numericmetadata_decimals_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_numericmetadata_decimals_cell_Internalname, "Class", divWwp_df_numericmetadata_decimals_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Numeric") == 0 ) ) )
         {
            edtavWwp_df_numericmetadata_defaultvalue_Visible = 0;
            AssignProp(sPrefix, false, edtavWwp_df_numericmetadata_defaultvalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_numericmetadata_defaultvalue_Visible), 5, 0), true);
            divWwp_df_numericmetadata_defaultvalue_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_numericmetadata_defaultvalue_cell_Internalname, "Class", divWwp_df_numericmetadata_defaultvalue_cell_Class, true);
         }
         else
         {
            edtavWwp_df_numericmetadata_defaultvalue_Visible = 1;
            AssignProp(sPrefix, false, edtavWwp_df_numericmetadata_defaultvalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_numericmetadata_defaultvalue_Visible), 5, 0), true);
            divWwp_df_numericmetadata_defaultvalue_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_numericmetadata_defaultvalue_cell_Internalname, "Class", divWwp_df_numericmetadata_defaultvalue_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Checkbox") == 0 ) ) )
         {
            edtavWwp_df_booleanmetadata_checkbox_controltitle_Visible = 0;
            AssignProp(sPrefix, false, edtavWwp_df_booleanmetadata_checkbox_controltitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_booleanmetadata_checkbox_controltitle_Visible), 5, 0), true);
            divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_booleanmetadata_checkbox_controltitle_cell_Internalname, "Class", divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class, true);
         }
         else
         {
            edtavWwp_df_booleanmetadata_checkbox_controltitle_Visible = 1;
            AssignProp(sPrefix, false, edtavWwp_df_booleanmetadata_checkbox_controltitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_booleanmetadata_checkbox_controltitle_Visible), 5, 0), true);
            divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_booleanmetadata_checkbox_controltitle_cell_Internalname, "Class", divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( ( StringUtil.StrCmp(AV10Control, "Checkbox") == 0 ) || ( StringUtil.StrCmp(AV10Control, "Switch") == 0 ) ) ) )
         {
            chkavWwp_df_booleanmetadata_defaultvalue.Visible = 0;
            AssignProp(sPrefix, false, chkavWwp_df_booleanmetadata_defaultvalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_booleanmetadata_defaultvalue.Visible), 5, 0), true);
            divWwp_df_booleanmetadata_defaultvalue_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_booleanmetadata_defaultvalue_cell_Internalname, "Class", divWwp_df_booleanmetadata_defaultvalue_cell_Class, true);
         }
         else
         {
            chkavWwp_df_booleanmetadata_defaultvalue.Visible = 1;
            AssignProp(sPrefix, false, chkavWwp_df_booleanmetadata_defaultvalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_booleanmetadata_defaultvalue.Visible), 5, 0), true);
            divWwp_df_booleanmetadata_defaultvalue_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_booleanmetadata_defaultvalue_cell_Internalname, "Class", divWwp_df_booleanmetadata_defaultvalue_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 5 ) ) )
         {
            edtavWwp_df_stepmetadata_description_Visible = 0;
            AssignProp(sPrefix, false, edtavWwp_df_stepmetadata_description_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_stepmetadata_description_Visible), 5, 0), true);
            divWwp_df_stepmetadata_description_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_stepmetadata_description_cell_Internalname, "Class", divWwp_df_stepmetadata_description_cell_Class, true);
         }
         else
         {
            edtavWwp_df_stepmetadata_description_Visible = 1;
            AssignProp(sPrefix, false, edtavWwp_df_stepmetadata_description_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_stepmetadata_description_Visible), 5, 0), true);
            divWwp_df_stepmetadata_description_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_stepmetadata_description_cell_Internalname, "Class", divWwp_df_stepmetadata_description_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 3 ) ) )
         {
            cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.Visible = 0;
            AssignProp(sPrefix, false, cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class, true);
         }
         else
         {
            cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.Visible = 1;
            AssignProp(sPrefix, false, cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 3 ) ) )
         {
            cmbavWwp_df_elementsrepeatermetadata_repetitionstype.Visible = 0;
            AssignProp(sPrefix, false, cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwp_df_elementsrepeatermetadata_repetitionstype.Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class, true);
         }
         else
         {
            cmbavWwp_df_elementsrepeatermetadata_repetitionstype.Visible = 1;
            AssignProp(sPrefix, false, cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwp_df_elementsrepeatermetadata_repetitionstype.Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 3 ) && ( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) ) )
         {
            edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Visible = 0;
            AssignProp(sPrefix, false, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class, true);
         }
         else
         {
            edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Visible = 1;
            AssignProp(sPrefix, false, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class = "col-xs-12 RequiredDataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 3 ) && ( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) && ( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype == 1 ) ) )
         {
            chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.Visible = 0;
            AssignProp(sPrefix, false, chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class, true);
         }
         else
         {
            chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.Visible = 1;
            AssignProp(sPrefix, false, chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 3 ) && ( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) ) )
         {
            edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Visible = 0;
            AssignProp(sPrefix, false, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class, true);
         }
         else
         {
            edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Visible = 1;
            AssignProp(sPrefix, false, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 3 ) && ( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 1 ) ) )
         {
            edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Visible = 0;
            AssignProp(sPrefix, false, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class, true);
         }
         else
         {
            edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Visible = 1;
            AssignProp(sPrefix, false, edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class = "col-xs-12 RequiredDataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 3 ) && ( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 2 ) ) )
         {
            edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Visible = 0;
            AssignProp(sPrefix, false, edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class, true);
         }
         else
         {
            edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Visible = 1;
            AssignProp(sPrefix, false, edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class = "col-xs-12 RequiredDataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 3 ) && ( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionstype == 3 ) ) )
         {
            cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.Visible = 0;
            AssignProp(sPrefix, false, cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class, true);
         }
         else
         {
            cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.Visible = 1;
            AssignProp(sPrefix, false, cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.Visible), 5, 0), true);
            divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class = "col-xs-12 RequiredDataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Internalname, "Class", divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class, true);
         }
         if ( ! ( ! AV22IsFormSettings && ( AV64WWPFormElementType == 4 ) ) )
         {
            cmbavWwp_df_labelmetadata_style.Visible = 0;
            AssignProp(sPrefix, false, cmbavWwp_df_labelmetadata_style_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwp_df_labelmetadata_style.Visible), 5, 0), true);
            divWwp_df_labelmetadata_style_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwp_df_labelmetadata_style_cell_Internalname, "Class", divWwp_df_labelmetadata_style_cell_Class, true);
         }
         else
         {
            cmbavWwp_df_labelmetadata_style.Visible = 1;
            AssignProp(sPrefix, false, cmbavWwp_df_labelmetadata_style_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWwp_df_labelmetadata_style.Visible), 5, 0), true);
            divWwp_df_labelmetadata_style_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divWwp_df_labelmetadata_style_cell_Internalname, "Class", divWwp_df_labelmetadata_style_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Text") == 0 ) ) )
         {
            divText_format_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divText_format_cell_Internalname, "Class", divText_format_cell_Class, true);
         }
         else
         {
            divText_format_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divText_format_cell_Internalname, "Class", divText_format_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Textarea") == 0 ) ) )
         {
            divTextarea_format_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divTextarea_format_cell_Internalname, "Class", divTextarea_format_cell_Class, true);
         }
         else
         {
            divTextarea_format_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divTextarea_format_cell_Internalname, "Class", divTextarea_format_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "File") == 0 ) ) )
         {
            divFile_format_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divFile_format_cell_Internalname, "Class", divFile_format_cell_Class, true);
         }
         else
         {
            divFile_format_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divFile_format_cell_Internalname, "Class", divFile_format_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Options") == 0 ) && ( ( StringUtil.StrCmp(AV30PredOptions_Type, "Combo") == 0 ) || ( StringUtil.StrCmp(AV30PredOptions_Type, "Suggest") == 0 ) ) ) )
         {
            AV31PredOptions_Values = "Fixed";
            AssignAttri(sPrefix, false, "AV31PredOptions_Values", AV31PredOptions_Values);
            divPredoptions_values_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divPredoptions_values_cell_Internalname, "Class", divPredoptions_values_cell_Class, true);
         }
         else
         {
            divPredoptions_values_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divPredoptions_values_cell_Internalname, "Class", divPredoptions_values_cell_Class, true);
         }
         if ( ! ( ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Options") == 0 ) && ( StringUtil.StrCmp(AV30PredOptions_Type, "Radio") == 0 ) ) )
         {
            divRadio_direction_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divRadio_direction_cell_Internalname, "Class", divRadio_direction_cell_Class, true);
         }
         else
         {
            divRadio_direction_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp(sPrefix, false, divRadio_direction_cell_Internalname, "Class", divRadio_direction_cell_Class, true);
         }
         chkavWwp_df_datemetadata_isdefaultvaluetoday.Caption = (AV14Date_IncludeTime ? context.GetMessage( "WWP_DF_SetNowAsDefaultValue", "") : context.GetMessage( "WWP_DF_SetTodayAsDefaultValue", ""));
         AssignProp(sPrefix, false, chkavWwp_df_datemetadata_isdefaultvaluetoday_Internalname, "TitleCaption", chkavWwp_df_datemetadata_isdefaultvaluetoday.Caption, true);
         if ( StringUtil.StrCmp(AV10Control, "Options") == 0 )
         {
            cmbavPredoptions_type.removeAllItems();
            cmbavPredoptions_type.addItem("Combo", context.GetMessage( "WWP_DF_Combo", ""), 0);
            if ( AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection )
            {
               cmbavPredoptions_type.addItem("CheckB", context.GetMessage( "WWP_DF_Checkboxes", ""), 0);
            }
            else
            {
               cmbavPredoptions_type.addItem("Radio", context.GetMessage( "WWP_DF_RadioButtons", ""), 0);
               cmbavPredoptions_type.addItem("Suggest", context.GetMessage( "WWP_DF_TextWithSuggestions", ""), 0);
            }
         }
         divTablesplittedwwpformelementreferenceid_Visible = edtavWwpformelementreferenceid_Visible;
         AssignProp(sPrefix, false, divTablesplittedwwpformelementreferenceid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedwwpformelementreferenceid_Visible), 5, 0), true);
         if ( AV22IsFormSettings || ( AV64WWPFormElementType == 1 ) || ( AV64WWPFormElementType == 5 ) )
         {
            this.executeUsercontrolMethod(sPrefix, false, "GXUITABSPANEL_TABS1Container", "ShowTab", "", new Object[] {(short)3});
         }
         else
         {
            AV39Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version2");
            gx_BV270 = true;
            this.executeUsercontrolMethod(sPrefix, false, "GXUITABSPANEL_TABS1Container", "HideTab", "", new Object[] {(short)3});
         }
         if ( AV22IsFormSettings )
         {
            edtavWwpform_wwpformreferencename_Visible = 0;
            AssignProp(sPrefix, false, edtavWwpform_wwpformreferencename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpform_wwpformreferencename_Visible), 5, 0), true);
            divWwpform_wwpformreferencename_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divWwpform_wwpformreferencename_cell_Internalname, "Class", divWwpform_wwpformreferencename_cell_Class, true);
            AV55WWPForm.gxTpr_Wwpformreferencename = Guid.NewGuid( ).ToString();
         }
      }

      protected void E14272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Updatevalidation_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Updatevalidation_modal_Result, "CANCEL") != 0 )
         {
            AV37Validation = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation(context);
            AV37Validation.FromJSonString(Updatevalidation_modal_Result, null);
            AV39Validations.RemoveItem(AV13CurrentValidationIndex);
            gx_BV270 = true;
            AV39Validations.Add(AV37Validation, AV13CurrentValidationIndex);
            gx_BV270 = true;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
         nGXsfl_270_bak_idx = nGXsfl_270_idx;
         gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
         nGXsfl_270_idx = nGXsfl_270_bak_idx;
         sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
         SubsflControlProps_2702( ) ;
      }

      protected void E12272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Addvalidation_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Addvalidation_modal_Result, "CANCEL") != 0 )
         {
            AV37Validation = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation(context);
            AV37Validation.FromJSonString(Addvalidation_modal_Result, null);
            AV39Validations.Add(AV37Validation, 0);
            gx_BV270 = true;
            subGridvalidations_Visible = 1;
            AssignProp(sPrefix, false, sPrefix+"GridvalidationsContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridvalidations_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
         nGXsfl_270_bak_idx = nGXsfl_270_idx;
         gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
         nGXsfl_270_idx = nGXsfl_270_bak_idx;
         sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
         SubsflControlProps_2702( ) ;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E17272 ();
         if (returnInSub) return;
      }

      protected void E17272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S182 ();
         if (returnInSub) return;
         if ( AV7CheckRequiredFieldsResult )
         {
            /* Execute user subroutine: 'VALIDATE' */
            S192 ();
            if (returnInSub) return;
         }
         if ( AV7CheckRequiredFieldsResult && ( ( StringUtil.StrCmp(AV54WWPDynamicFormMode, "INS") == 0 ) || ( StringUtil.StrCmp(AV54WWPDynamicFormMode, "UPD") == 0 ) ) )
         {
            if ( AV22IsFormSettings )
            {
               AV55WWPForm.gxTpr_Wwpformvalidations = AV39Validations.ToJSonString(false);
               AV25NeedToRefreshForm = (bool)(((StringUtil.StrCmp(AV55WWPForm.gxTpr_Wwpformtitle, AV65WWPFormTitle)!=0)));
               if ( AV55WWPForm.gxTpr_Wwpformiswizard != ( ( StringUtil.StrCmp(AV18FormType, "Wizard") == 0 ) ) )
               {
                  AV25NeedToRefreshForm = true;
                  AV103GXV34 = 1;
                  while ( AV103GXV34 <= AV55WWPForm.gxTpr_Element.Count )
                  {
                     AV56WWPFormElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV55WWPForm.gxTpr_Element.Item(AV103GXV34));
                     if ( AV55WWPForm.gxTpr_Wwpformiswizard )
                     {
                        if ( AV56WWPFormElement.gxTpr_Wwpformelementtype == 5 )
                        {
                           AV56WWPFormElement.gxTpr_Wwpformelementtype = 2;
                           AV53WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
                           AV53WWP_DF_StepMetadata.FromJSonString(AV56WWPFormElement.gxTpr_Wwpformelementmetadata, null);
                           AV104GXV35 = 1;
                           while ( AV104GXV35 <= AV53WWP_DF_StepMetadata.gxTpr_Validations.Count )
                           {
                              AV37Validation = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV53WWP_DF_StepMetadata.gxTpr_Validations.Item(AV104GXV35));
                              AV39Validations.Add((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)(AV37Validation.Clone()), 0);
                              gx_BV270 = true;
                              AV104GXV35 = (int)(AV104GXV35+1);
                           }
                           AV47WWP_DF_ContainerMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
                           AV47WWP_DF_ContainerMetadata.gxTpr_Visiblecondition = AV53WWP_DF_StepMetadata.gxTpr_Visiblecondition;
                           AV47WWP_DF_ContainerMetadata.gxTpr_Style = 2;
                           AV47WWP_DF_ContainerMetadata.gxTpr_Columns = AV53WWP_DF_StepMetadata.gxTpr_Columns;
                           AV56WWPFormElement.gxTpr_Wwpformelementmetadata = AV47WWP_DF_ContainerMetadata.ToJSonString(false, true);
                        }
                     }
                     else
                     {
                        if ( (0==AV56WWPFormElement.gxTpr_Wwpformelementparentid) )
                        {
                           if ( AV56WWPFormElement.gxTpr_Wwpformelementtype == 2 )
                           {
                              AV56WWPFormElement.gxTpr_Wwpformelementtype = 5;
                              AV47WWP_DF_ContainerMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
                              AV47WWP_DF_ContainerMetadata.FromJSonString(AV56WWPFormElement.gxTpr_Wwpformelementmetadata, null);
                              AV53WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
                              AV53WWP_DF_StepMetadata.gxTpr_Visiblecondition = AV47WWP_DF_ContainerMetadata.gxTpr_Visiblecondition;
                              AV53WWP_DF_StepMetadata.gxTpr_Columns = AV47WWP_DF_ContainerMetadata.gxTpr_Columns;
                              AV56WWPFormElement.gxTpr_Wwpformelementmetadata = AV53WWP_DF_StepMetadata.ToJSonString(false, true);
                           }
                           else
                           {
                              AV7CheckRequiredFieldsResult = false;
                              AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
                              GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "WWP_DF_ChangeFormTypeWizardRequirement", ""),  "error",  radavFormtype_Internalname,  "true",  ""));
                              if (true) break;
                           }
                        }
                     }
                     AV103GXV34 = (int)(AV103GXV34+1);
                  }
               }
               AV105Referencecount = 0;
               while ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  AV55WWPForm.gxTpr_Wwpformid,  AV55WWPForm.gxTpr_Wwpformreferencename) && ( AV105Referencecount < 1000 ) )
               {
                  AV55WWPForm.gxTpr_Wwpformreferencename = Guid.NewGuid( ).ToString();
                  AV105Referencecount = (short)(AV105Referencecount+1);
               }
               if ( AV7CheckRequiredFieldsResult )
               {
                  AV55WWPForm.gxTpr_Wwpformiswizard = (bool)(((StringUtil.StrCmp(AV18FormType, "Wizard")==0)));
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveformdefinition(context ).execute(  AV33SessionId,  AV55WWPForm) ;
                  this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_Close", new Object[] {(string)(AV25NeedToRefreshForm ? "OK_AND_REFRESH" : "OK")}, false);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(AV54WWPDynamicFormMode, "INS") == 0 )
               {
                  AV56WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
                  AV56WWPFormElement.gxTpr_Wwpformelementid = (short)(AV55WWPForm.gxTpr_Element.Count+1);
                  AV106GXV36 = 1;
                  while ( AV106GXV36 <= AV55WWPForm.gxTpr_Element.Count )
                  {
                     AV15ElementAux = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV55WWPForm.gxTpr_Element.Item(AV106GXV36));
                     if ( AV15ElementAux.gxTpr_Wwpformelementid >= AV56WWPFormElement.gxTpr_Wwpformelementid )
                     {
                        AV56WWPFormElement.gxTpr_Wwpformelementid = (short)(AV15ElementAux.gxTpr_Wwpformelementid+1);
                     }
                     AV106GXV36 = (int)(AV106GXV36+1);
                  }
                  AV56WWPFormElement.gxTpr_Wwpformelementparentid = AV61WWPFormElementParentId;
                  AV56WWPFormElement.gxTpr_Wwpformelementorderindex = (short)(((AV55WWPForm.gxTpr_Element.Count==0) ? 0 : ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV55WWPForm.gxTpr_Element.Item(AV55WWPForm.gxTpr_Element.Count)).gxTpr_Wwpformelementorderindex));
                  AV56WWPFormElement.gxTpr_Wwpformelementorderindex = (short)(AV56WWPFormElement.gxTpr_Wwpformelementorderindex+1);
                  AV55WWPForm.gxTpr_Element.Add(AV56WWPFormElement, 0);
               }
               else
               {
                  GXt_SdtWWP_Form_Element2 = AV56WWPFormElement;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV55WWPForm,  AV60WWPFormElementId, out  GXt_SdtWWP_Form_Element2) ;
                  AV56WWPFormElement = GXt_SdtWWP_Form_Element2;
               }
               AV56WWPFormElement.gxTpr_Wwpformelementtitle = AV63WWPFormElementTitle;
               AV56WWPFormElement.gxTpr_Wwpformelementtype = AV64WWPFormElementType;
               AV56WWPFormElement.gxTpr_Wwpformelementcaption = (short)((AV28ParentIsGridMultipleData ? 3 : AV57WWPFormElementCaption));
               AV56WWPFormElement.gxTpr_Wwpformelementreferenceid = StringUtil.Trim( AV62WWPFormElementReferenceId);
               AV56WWPFormElement.gxTpr_Wwpformelementexcludefromexport = AV59WWPFormElementExcludeFromExport;
               AV56WWPFormElement.gxTpr_Wwpformelementdatatype = 2;
               if ( AV64WWPFormElementType == 2 )
               {
                  AV47WWP_DF_ContainerMetadata.gxTpr_Columns = AV8Columns;
                  AV47WWP_DF_ContainerMetadata.gxTpr_Visiblecondition = AV44VisibleConditionExpression;
                  AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault = (bool)(AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault&&AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable);
                  AV56WWPFormElement.gxTpr_Wwpformelementmetadata = AV47WWP_DF_ContainerMetadata.ToJSonString(false, true);
               }
               else if ( AV64WWPFormElementType == 5 )
               {
                  AV53WWP_DF_StepMetadata.gxTpr_Columns = AV8Columns;
                  AV53WWP_DF_StepMetadata.gxTpr_Validations = AV39Validations;
                  AV53WWP_DF_StepMetadata.gxTpr_Visiblecondition = AV44VisibleConditionExpression;
                  AV56WWPFormElement.gxTpr_Wwpformelementmetadata = AV53WWP_DF_StepMetadata.ToJSonString(false, true);
               }
               else if ( AV64WWPFormElementType == 3 )
               {
                  AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Columns = AV8Columns;
                  AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Visiblecondition = AV44VisibleConditionExpression;
                  AV56WWPFormElement.gxTpr_Wwpformelementmetadata = AV49WWP_DF_ElementsRepeaterMetadata.ToJSonString(false, true);
               }
               else if ( AV64WWPFormElementType == 4 )
               {
                  AV51WWP_DF_LabelMetadata.gxTpr_Visiblecondition = AV44VisibleConditionExpression;
                  AV56WWPFormElement.gxTpr_Wwpformelementmetadata = AV51WWP_DF_LabelMetadata.ToJSonString(false, true);
               }
               else if ( AV64WWPFormElementType == 1 )
               {
                  if ( StringUtil.StrCmp(AV10Control, "Text") == 0 )
                  {
                     AV46WWP_DF_CharMetadata.gxTpr_Isrequired = AV24IsRequired;
                     AV46WWP_DF_CharMetadata.gxTpr_Validations = AV39Validations;
                     AV46WWP_DF_CharMetadata.gxTpr_Visiblecondition = AV44VisibleConditionExpression;
                     AV46WWP_DF_CharMetadata.gxTpr_Controltype = 1;
                     if ( StringUtil.StrCmp(AV35Text_Format, "Any") == 0 )
                     {
                        AV56WWPFormElement.gxTpr_Wwpformelementdatatype = 2;
                     }
                     else if ( StringUtil.StrCmp(AV35Text_Format, "Email") == 0 )
                     {
                        AV56WWPFormElement.gxTpr_Wwpformelementdatatype = 7;
                     }
                     else if ( StringUtil.StrCmp(AV35Text_Format, "Url") == 0 )
                     {
                        AV56WWPFormElement.gxTpr_Wwpformelementdatatype = 8;
                     }
                     AV56WWPFormElement.gxTpr_Wwpformelementmetadata = AV46WWP_DF_CharMetadata.ToJSonString(false, true);
                  }
                  else if ( StringUtil.StrCmp(AV10Control, "Password") == 0 )
                  {
                     AV56WWPFormElement.gxTpr_Wwpformelementdatatype = 6;
                     AV46WWP_DF_CharMetadata.gxTpr_Isrequired = AV24IsRequired;
                     AV46WWP_DF_CharMetadata.gxTpr_Validations = AV39Validations;
                     AV46WWP_DF_CharMetadata.gxTpr_Visiblecondition = AV44VisibleConditionExpression;
                     AV56WWPFormElement.gxTpr_Wwpformelementmetadata = AV46WWP_DF_CharMetadata.ToJSonString(false, true);
                  }
                  else if ( StringUtil.StrCmp(AV10Control, "Textarea") == 0 )
                  {
                     AV46WWP_DF_CharMetadata.gxTpr_Isrequired = AV24IsRequired;
                     AV46WWP_DF_CharMetadata.gxTpr_Validations = AV39Validations;
                     AV46WWP_DF_CharMetadata.gxTpr_Visiblecondition = AV44VisibleConditionExpression;
                     AV56WWPFormElement.gxTpr_Wwpformelementdatatype = 2;
                     AV46WWP_DF_CharMetadata.gxTpr_Controltype = (short)(((StringUtil.StrCmp(AV36TextArea_Format, "Any")==0) ? 2 : 3));
                     AV56WWPFormElement.gxTpr_Wwpformelementmetadata = AV46WWP_DF_CharMetadata.ToJSonString(false, true);
                  }
                  else if ( StringUtil.StrCmp(AV10Control, "Number") == 0 )
                  {
                     AV56WWPFormElement.gxTpr_Wwpformelementdatatype = 3;
                     AV52WWP_DF_NumericMetadata.gxTpr_Isrequired = AV24IsRequired;
                     AV52WWP_DF_NumericMetadata.gxTpr_Validations = AV39Validations;
                     AV52WWP_DF_NumericMetadata.gxTpr_Visiblecondition = AV44VisibleConditionExpression;
                     AV56WWPFormElement.gxTpr_Wwpformelementmetadata = AV52WWP_DF_NumericMetadata.ToJSonString(false, true);
                  }
                  else if ( StringUtil.StrCmp(AV10Control, "Date") == 0 )
                  {
                     AV56WWPFormElement.gxTpr_Wwpformelementdatatype = (short)((AV14Date_IncludeTime ? 5 : 4));
                     AV48WWP_DF_DateMetadata.gxTpr_Isrequired = AV24IsRequired;
                     AV48WWP_DF_DateMetadata.gxTpr_Validations = AV39Validations;
                     AV48WWP_DF_DateMetadata.gxTpr_Visiblecondition = AV44VisibleConditionExpression;
                     AV56WWPFormElement.gxTpr_Wwpformelementmetadata = AV48WWP_DF_DateMetadata.ToJSonString(false, true);
                  }
                  else if ( ( StringUtil.StrCmp(AV10Control, "Checkbox") == 0 ) || ( StringUtil.StrCmp(AV10Control, "Switch") == 0 ) )
                  {
                     AV56WWPFormElement.gxTpr_Wwpformelementdatatype = 1;
                     AV45WWP_DF_BooleanMetadata.gxTpr_Validations = AV39Validations;
                     AV45WWP_DF_BooleanMetadata.gxTpr_Visiblecondition = AV44VisibleConditionExpression;
                     AV45WWP_DF_BooleanMetadata.gxTpr_Controltype = (short)(((StringUtil.StrCmp(AV10Control, "Checkbox")==0) ? 1 : 2));
                     AV56WWPFormElement.gxTpr_Wwpformelementmetadata = AV45WWP_DF_BooleanMetadata.ToJSonString(false, true);
                  }
                  else if ( StringUtil.StrCmp(AV10Control, "File") == 0 )
                  {
                     AV56WWPFormElement.gxTpr_Wwpformelementdatatype = (short)(((StringUtil.StrCmp(AV17File_Format, "Any")==0) ? 9 : 10));
                  }
                  else if ( StringUtil.StrCmp(AV10Control, "Options") == 0 )
                  {
                     AV56WWPFormElement.gxTpr_Wwpformelementdatatype = 2;
                     AV46WWP_DF_CharMetadata.gxTpr_Isrequired = AV24IsRequired;
                     AV46WWP_DF_CharMetadata.gxTpr_Visiblecondition = AV44VisibleConditionExpression;
                     AV46WWP_DF_CharMetadata.gxTpr_Validations = AV39Validations;
                     AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Options.Clear();
                     if ( StringUtil.StrCmp(AV31PredOptions_Values, "Fixed") == 0 )
                     {
                        AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Hasdynamicoptions = false;
                        AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Dynamic.gxTpr_Getoptionsservice = "";
                        AV108GXV38 = 1;
                        AV107GXV37 = GxRegex.Split(AV29PredOptions_Options,StringUtil.Chr( 10));
                        while ( AV108GXV38 <= AV107GXV37.Count )
                        {
                           AV41VarCharAux = AV107GXV37.GetString(AV108GXV38);
                           if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV41VarCharAux))) )
                           {
                              AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Options.Add(StringUtil.Trim( AV41VarCharAux), 0);
                           }
                           AV108GXV38 = (int)(AV108GXV38+1);
                        }
                     }
                     else
                     {
                        AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Hasdynamicoptions = true;
                     }
                     AV46WWP_DF_CharMetadata.gxTpr_Controltype = 4;
                     if ( StringUtil.StrCmp(AV30PredOptions_Type, "Combo") == 0 )
                     {
                        AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype = 1;
                        if ( AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection )
                        {
                           AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue = false;
                        }
                     }
                     else if ( StringUtil.StrCmp(AV30PredOptions_Type, "Radio") == 0 )
                     {
                        AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype = 3;
                        AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Radiobutton.gxTpr_Directionvertical = (bool)(((StringUtil.StrCmp(AV32Radio_Direction, "Vertical")==0)));
                     }
                     else if ( StringUtil.StrCmp(AV30PredOptions_Type, "CheckB") == 0 )
                     {
                        AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype = 4;
                     }
                     else if ( StringUtil.StrCmp(AV30PredOptions_Type, "Suggest") == 0 )
                     {
                        AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype = 2;
                     }
                     AV56WWPFormElement.gxTpr_Wwpformelementmetadata = AV46WWP_DF_CharMetadata.ToJSonString(false, true);
                  }
               }
               if ( AV7CheckRequiredFieldsResult )
               {
                  AV55WWPForm.Check();
                  AV109GXV39 = 1;
                  while ( AV109GXV39 <= AV55WWPForm.gxTpr_Element.Count )
                  {
                     AV15ElementAux = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV55WWPForm.gxTpr_Element.Item(AV109GXV39));
                     if ( StringUtil.Contains( AV15ElementAux.ToJSonString(true, true), "\"Mode\":\"DLT\"") )
                     {
                        AV15ElementAux.gxTpr_Wwpformelementparentid = (short)(AV15ElementAux.gxTpr_Wwpformelementid*-1);
                     }
                     AV109GXV39 = (int)(AV109GXV39+1);
                  }
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveformdefinition(context ).execute(  AV33SessionId,  AV55WWPForm) ;
                  this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_Close", new Object[] {(string)"OK"}, false);
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV53WWP_DF_StepMetadata", AV53WWP_DF_StepMetadata);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
         nGXsfl_270_bak_idx = nGXsfl_270_idx;
         gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
         nGXsfl_270_idx = nGXsfl_270_bak_idx;
         sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
         SubsflControlProps_2702( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47WWP_DF_ContainerMetadata", AV47WWP_DF_ContainerMetadata);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49WWP_DF_ElementsRepeaterMetadata", AV49WWP_DF_ElementsRepeaterMetadata);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV51WWP_DF_LabelMetadata", AV51WWP_DF_LabelMetadata);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46WWP_DF_CharMetadata", AV46WWP_DF_CharMetadata);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV45WWP_DF_BooleanMetadata", AV45WWP_DF_BooleanMetadata);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48WWP_DF_DateMetadata", AV48WWP_DF_DateMetadata);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV52WWP_DF_NumericMetadata", AV52WWP_DF_NumericMetadata);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5AllReferenceIds", AV5AllReferenceIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV44VisibleConditionExpression", AV44VisibleConditionExpression);
      }

      protected void E18272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Wwpformelementtype_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         if ( ! ( ( AV64WWPFormElementType == 1 ) ) )
         {
            AV62WWPFormElementReferenceId = "";
            AssignAttri(sPrefix, false, "AV62WWPFormElementReferenceId", AV62WWPFormElementReferenceId);
         }
         /*  Sending Event outputs  */
         radavPredoptions_values.CurrentValue = StringUtil.RTrim( AV31PredOptions_Values);
         AssignProp(sPrefix, false, radavPredoptions_values_Internalname, "Values", radavPredoptions_values.ToJavascriptSource(), true);
         cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
         AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         if ( gx_BV270 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
            nGXsfl_270_bak_idx = nGXsfl_270_idx;
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
            nGXsfl_270_idx = nGXsfl_270_bak_idx;
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
      }

      protected void E19272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Control_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavPredoptions_values.CurrentValue = StringUtil.RTrim( AV31PredOptions_Values);
         AssignProp(sPrefix, false, radavPredoptions_values_Internalname, "Values", radavPredoptions_values.ToJavascriptSource(), true);
         cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
         AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         if ( gx_BV270 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
            nGXsfl_270_bak_idx = nGXsfl_270_idx;
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
            nGXsfl_270_idx = nGXsfl_270_bak_idx;
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
      }

      protected void E20272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Wwp_df_charmetadata_multipleoptions_allowmultipleselection_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavPredoptions_values.CurrentValue = StringUtil.RTrim( AV31PredOptions_Values);
         AssignProp(sPrefix, false, radavPredoptions_values_Internalname, "Values", radavPredoptions_values.ToJavascriptSource(), true);
         cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
         AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         if ( gx_BV270 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
            nGXsfl_270_bak_idx = nGXsfl_270_idx;
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
            nGXsfl_270_idx = nGXsfl_270_bak_idx;
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
      }

      protected void E21272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Predoptions_type_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavPredoptions_values.CurrentValue = StringUtil.RTrim( AV31PredOptions_Values);
         AssignProp(sPrefix, false, radavPredoptions_values_Internalname, "Values", radavPredoptions_values.ToJavascriptSource(), true);
         cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
         AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         if ( gx_BV270 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
            nGXsfl_270_bak_idx = nGXsfl_270_idx;
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
            nGXsfl_270_idx = nGXsfl_270_bak_idx;
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
      }

      protected void E22272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Text_format_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavPredoptions_values.CurrentValue = StringUtil.RTrim( AV31PredOptions_Values);
         AssignProp(sPrefix, false, radavPredoptions_values_Internalname, "Values", radavPredoptions_values.ToJavascriptSource(), true);
         cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
         AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         if ( gx_BV270 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
            nGXsfl_270_bak_idx = nGXsfl_270_idx;
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
            nGXsfl_270_idx = nGXsfl_270_bak_idx;
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
      }

      protected void E23272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Predoptions_values_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavPredoptions_values.CurrentValue = StringUtil.RTrim( AV31PredOptions_Values);
         AssignProp(sPrefix, false, radavPredoptions_values_Internalname, "Values", radavPredoptions_values.ToJavascriptSource(), true);
         cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
         AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         if ( gx_BV270 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
            nGXsfl_270_bak_idx = nGXsfl_270_idx;
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
            nGXsfl_270_idx = nGXsfl_270_bak_idx;
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
      }

      protected void E24272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* File_format_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavPredoptions_values.CurrentValue = StringUtil.RTrim( AV31PredOptions_Values);
         AssignProp(sPrefix, false, radavPredoptions_values_Internalname, "Values", radavPredoptions_values.ToJavascriptSource(), true);
         cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
         AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         if ( gx_BV270 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
            nGXsfl_270_bak_idx = nGXsfl_270_idx;
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
            nGXsfl_270_idx = nGXsfl_270_bak_idx;
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
      }

      protected void E25272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Wwp_df_containermetadata_collapsable_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavPredoptions_values.CurrentValue = StringUtil.RTrim( AV31PredOptions_Values);
         AssignProp(sPrefix, false, radavPredoptions_values_Internalname, "Values", radavPredoptions_values.ToJavascriptSource(), true);
         cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
         AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         if ( gx_BV270 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
            nGXsfl_270_bak_idx = nGXsfl_270_idx;
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
            nGXsfl_270_idx = nGXsfl_270_bak_idx;
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
      }

      protected void E26272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Wwp_df_elementsrepeatermetadata_repetitionstype_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavPredoptions_values.CurrentValue = StringUtil.RTrim( AV31PredOptions_Values);
         AssignProp(sPrefix, false, radavPredoptions_values_Internalname, "Values", radavPredoptions_values.ToJavascriptSource(), true);
         cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
         AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         if ( gx_BV270 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
            nGXsfl_270_bak_idx = nGXsfl_270_idx;
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
            nGXsfl_270_idx = nGXsfl_270_bak_idx;
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
      }

      protected void E27272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Wwp_df_elementsrepeatermetadata_repetitionsdatatype_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavPredoptions_values.CurrentValue = StringUtil.RTrim( AV31PredOptions_Values);
         AssignProp(sPrefix, false, radavPredoptions_values_Internalname, "Values", radavPredoptions_values.ToJavascriptSource(), true);
         cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
         AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         if ( gx_BV270 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
            nGXsfl_270_bak_idx = nGXsfl_270_idx;
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
            nGXsfl_270_idx = nGXsfl_270_bak_idx;
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
      }

      protected void E28272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Wwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavPredoptions_values.CurrentValue = StringUtil.RTrim( AV31PredOptions_Values);
         AssignProp(sPrefix, false, radavPredoptions_values_Internalname, "Values", radavPredoptions_values.ToJavascriptSource(), true);
         cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
         AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         if ( gx_BV270 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
            nGXsfl_270_bak_idx = nGXsfl_270_idx;
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
            nGXsfl_270_idx = nGXsfl_270_bak_idx;
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
      }

      protected void E29272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Wwpform_wwpformresume_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavPredoptions_values.CurrentValue = StringUtil.RTrim( AV31PredOptions_Values);
         AssignProp(sPrefix, false, radavPredoptions_values_Internalname, "Values", radavPredoptions_values.ToJavascriptSource(), true);
         cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
         AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         if ( gx_BV270 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
            nGXsfl_270_bak_idx = nGXsfl_270_idx;
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
            nGXsfl_270_idx = nGXsfl_270_bak_idx;
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
      }

      protected void E30272( )
      {
         AV97GXV28 = (int)(nGXsfl_270_idx+GRIDVALIDATIONS_nFirstRecordOnPage);
         if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) )
         {
            AV39Validations.CurrentItem = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28));
         }
         /* Wwp_df_containermetadata_style_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavPredoptions_values.CurrentValue = StringUtil.RTrim( AV31PredOptions_Values);
         AssignProp(sPrefix, false, radavPredoptions_values_Internalname, "Values", radavPredoptions_values.ToJavascriptSource(), true);
         cmbavPredoptions_type.CurrentValue = StringUtil.RTrim( AV30PredOptions_Type);
         AssignProp(sPrefix, false, cmbavPredoptions_type_Internalname, "Values", cmbavPredoptions_type.ToJavascriptSource(), true);
         if ( gx_BV270 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39Validations", AV39Validations);
            nGXsfl_270_bak_idx = nGXsfl_270_idx;
            gxgrGridvalidations_refresh( subGridvalidations_Rows, AV64WWPFormElementType, AV39Validations, AV18FormType, AV35Text_Format, AV36TextArea_Format, AV14Date_IncludeTime, AV48WWP_DF_DateMetadata.gxTpr_Isdefaultvaluetoday, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection, AV31PredOptions_Values, AV46WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsable, AV47WWP_DF_ContainerMetadata.gxTpr_Collapsedbydefault, AV17File_Format, AV32Radio_Direction, AV45WWP_DF_BooleanMetadata.gxTpr_Defaultvalue, AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitions_useradded.gxTpr_Insertchildbutton_isalignedtolabel, AV59WWPFormElementExcludeFromExport, AV24IsRequired, AV58WWPFormElementDataType, AV22IsFormSettings, AV65WWPFormTitle, AV28ParentIsGridMultipleData, sPrefix) ;
            nGXsfl_270_idx = nGXsfl_270_bak_idx;
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WWPForm", AV55WWPForm);
      }

      protected void S192( )
      {
         /* 'VALIDATE' Routine */
         returnInSub = false;
         GXt_char3 = AV41VarCharAux;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getavailablevariables(context ).execute(  AV33SessionId,  false,  AV60WWPFormElementId,  9999,  "", out  GXt_char3) ;
         AV41VarCharAux = GXt_char3;
         AV5AllReferenceIds.FromJSonString(StringUtil.Lower( AV41VarCharAux), null);
         AV16ExecuteConditionToTest = false;
         AssignAttri(sPrefix, false, "AV16ExecuteConditionToTest", AV16ExecuteConditionToTest);
         /* Execute user subroutine: 'VALIDATE VISIBILITY CONDITION' */
         S172 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV62WWPFormElementReferenceId))) )
         {
            if ( StringUtil.StrCmp(StringUtil.Lower( StringUtil.Trim( AV62WWPFormElementReferenceId)), "value") == 0 )
            {
               this.executeUsercontrolMethod(sPrefix, false, "GXUITABSPANEL_TABS1Container", "SelectTab", "", new Object[] {(short)1});
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_DF_InvalidReferenceId", ""), AV62WWPFormElementReferenceId, "", "", "", "", "", "", "", ""),  "error",  edtavWwpformelementreferenceid_Internalname,  "true",  ""));
               AV7CheckRequiredFieldsResult = false;
               AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
            }
            else
            {
               AV110GXV40 = 1;
               while ( AV110GXV40 <= AV55WWPForm.gxTpr_Element.Count )
               {
                  AV15ElementAux = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV55WWPForm.gxTpr_Element.Item(AV110GXV40));
                  if ( ( ( StringUtil.StrCmp(AV54WWPDynamicFormMode, "INS") == 0 ) || ( AV15ElementAux.gxTpr_Wwpformelementid != AV60WWPFormElementId ) ) && ( StringUtil.StrCmp(StringUtil.Lower( StringUtil.Trim( AV15ElementAux.gxTpr_Wwpformelementreferenceid)), StringUtil.Lower( StringUtil.Trim( AV62WWPFormElementReferenceId))) == 0 ) )
                  {
                     this.executeUsercontrolMethod(sPrefix, false, "GXUITABSPANEL_TABS1Container", "SelectTab", "", new Object[] {(short)1});
                     GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_DF_DuplicatedReferenceId", ""), AV62WWPFormElementReferenceId, "", "", "", "", "", "", "", ""),  "error",  edtavWwpformelementreferenceid_Internalname,  "true",  ""));
                     AV7CheckRequiredFieldsResult = false;
                     AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
                  }
                  AV110GXV40 = (int)(AV110GXV40+1);
               }
            }
         }
         if ( AV7CheckRequiredFieldsResult && ( AV64WWPFormElementType == 1 ) && ( StringUtil.StrCmp(AV10Control, "Number") == 0 ) && ( AV52WWP_DF_NumericMetadata.gxTpr_Decimals > 5 ) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "WWP_DF_DecimalsGreater5", ""),  "error",  edtavWwp_df_numericmetadata_decimals_Internalname,  "true",  ""));
            AV7CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         }
         if ( AV7CheckRequiredFieldsResult && ( AV39Validations.Count > 0 ) )
         {
            AV111GXV41 = 1;
            while ( AV111GXV41 <= AV39Validations.Count )
            {
               AV37Validation = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV111GXV41));
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getconditionmentionsandvalidate(context ).execute(  AV55WWPForm,  AV37Validation.gxTpr_Condition.gxTpr_Expression,  true,  false,  AV62WWPFormElementReferenceId,  AV58WWPFormElementDataType, ref  AV5AllReferenceIds, out  AV42VarCharList, out  AV9ConditionError) ;
               AssignAttri(sPrefix, false, "AV9ConditionError", AV9ConditionError);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9ConditionError)) )
               {
                  this.executeUsercontrolMethod(sPrefix, false, "GXUITABSPANEL_TABS1Container", "SelectTab", "", new Object[] {(short)3});
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV9ConditionError,  "error",  "",  "true",  ""));
                  AV7CheckRequiredFieldsResult = false;
                  AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
                  if (true) break;
               }
               AV111GXV41 = (int)(AV111GXV41+1);
            }
         }
         if ( AV7CheckRequiredFieldsResult && ( StringUtil.StrCmp(AV54WWPDynamicFormMode, "UPD") == 0 ) && ( AV64WWPFormElementType == 3 ) )
         {
            GXt_SdtWWP_Form_Element2 = AV26OriginalElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV55WWPForm,  AV60WWPFormElementId, out  GXt_SdtWWP_Form_Element2) ;
            AV26OriginalElement = GXt_SdtWWP_Form_Element2;
            AV6AuxWWP_DF_ElementsRepeaterMetadata.FromJSonString(AV26OriginalElement.gxTpr_Wwpformelementmetadata, null);
            if ( AV6AuxWWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype != AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype )
            {
               AV112GXV42 = 1;
               while ( AV112GXV42 <= AV55WWPForm.gxTpr_Element.Count )
               {
                  AV15ElementAux = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV55WWPForm.gxTpr_Element.Item(AV112GXV42));
                  if ( AV15ElementAux.gxTpr_Wwpformelementparentid == AV60WWPFormElementId )
                  {
                     if ( AV49WWP_DF_ElementsRepeaterMetadata.gxTpr_Repetitionsdatatype == 2 )
                     {
                        if ( AV15ElementAux.gxTpr_Wwpformelementtype != 1 )
                        {
                           AV7CheckRequiredFieldsResult = false;
                           AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
                           GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "WWP_DF_ChangeDisplayTypeRequirement", ""),  "error",  "",  "true",  ""));
                           if (true) break;
                        }
                        else
                        {
                           AV15ElementAux.gxTpr_Wwpformelementcaption = 3;
                        }
                     }
                     else
                     {
                        AV15ElementAux.gxTpr_Wwpformelementcaption = 1;
                     }
                  }
                  AV112GXV42 = (int)(AV112GXV42+1);
               }
            }
         }
      }

      protected void S172( )
      {
         /* 'VALIDATE VISIBILITY CONDITION' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getconditionmentionsandvalidate(context ).execute(  AV55WWPForm,  AV43VisibleCondition,  false,  AV16ExecuteConditionToTest,  AV62WWPFormElementReferenceId,  AV58WWPFormElementDataType, ref  AV5AllReferenceIds, out  AV42VarCharList, out  AV9ConditionError) ;
         AssignAttri(sPrefix, false, "AV9ConditionError", AV9ConditionError);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9ConditionError)) )
         {
            AV44VisibleConditionExpression.gxTpr_Expression = AV43VisibleCondition;
            AV44VisibleConditionExpression.gxTpr_Mentionedfields = AV42VarCharList;
         }
         else
         {
            this.executeUsercontrolMethod(sPrefix, false, "GXUITABSPANEL_TABS1Container", "SelectTab", "", new Object[] {(short)2});
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV9ConditionError,  "error",  edtavVisiblecondition_Internalname,  "true",  ""));
            AV7CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV7CheckRequiredFieldsResult", AV7CheckRequiredFieldsResult);
         }
      }

      protected void wb_table3_292_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableupdatevalidation_modal_Internalname, tblTableupdatevalidation_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucUpdatevalidation_modal.SetProperty("Width", Updatevalidation_modal_Width);
            ucUpdatevalidation_modal.SetProperty("Title", Updatevalidation_modal_Title);
            ucUpdatevalidation_modal.SetProperty("ConfirmType", Updatevalidation_modal_Confirmtype);
            ucUpdatevalidation_modal.SetProperty("BodyType", Updatevalidation_modal_Bodytype);
            ucUpdatevalidation_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Updatevalidation_modal_Internalname, sPrefix+"UPDATEVALIDATION_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"UPDATEVALIDATION_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_292_272e( true) ;
         }
         else
         {
            wb_table3_292_272e( false) ;
         }
      }

      protected void wb_table2_287_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableaddvalidation_modal_Internalname, tblTableaddvalidation_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucAddvalidation_modal.SetProperty("Width", Addvalidation_modal_Width);
            ucAddvalidation_modal.SetProperty("Title", Addvalidation_modal_Title);
            ucAddvalidation_modal.SetProperty("ConfirmType", Addvalidation_modal_Confirmtype);
            ucAddvalidation_modal.SetProperty("BodyType", Addvalidation_modal_Bodytype);
            ucAddvalidation_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Addvalidation_modal_Internalname, sPrefix+"ADDVALIDATION_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"ADDVALIDATION_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_287_272e( true) ;
         }
         else
         {
            wb_table2_287_272e( false) ;
         }
      }

      protected void wb_table1_60_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedwwpformelementreferenceid_Internalname, tblTablemergedwwpformelementreferenceid_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellWwpformelementreferenceid_cell_Internalname+"\"  class='"+cellWwpformelementreferenceid_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwpformelementreferenceid_Internalname, context.GetMessage( "WWPForm Element Reference Id", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwpformelementreferenceid_Internalname, AV62WWPFormElementReferenceId, StringUtil.RTrim( context.localUtil.Format( AV62WWPFormElementReferenceId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwpformelementreferenceid_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwpformelementreferenceid_Visible, edtavWwpformelementreferenceid_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DynFormConditionHelpCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblReferencieidhelpicon_Internalname, lblReferencieidhelpicon_Caption, "", "", lblReferencieidhelpicon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WorkWithPlus/DynamicForms/WWP_DF_AddElement.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_60_272e( true) ;
         }
         else
         {
            wb_table1_60_272e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV54WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV54WWPDynamicFormMode", AV54WWPDynamicFormMode);
         AV61WWPFormElementParentId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV61WWPFormElementParentId", StringUtil.LTrimStr( (decimal)(AV61WWPFormElementParentId), 4, 0));
         AV60WWPFormElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV60WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV60WWPFormElementId), 4, 0));
         AV33SessionId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV33SessionId", StringUtil.LTrimStr( (decimal)(AV33SessionId), 4, 0));
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
         PA272( ) ;
         WS272( ) ;
         WE272( ) ;
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
         sCtrlAV54WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV61WWPFormElementParentId = (string)((string)getParm(obj,1));
         sCtrlAV60WWPFormElementId = (string)((string)getParm(obj,2));
         sCtrlAV33SessionId = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA272( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_addelement", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA272( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV54WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV54WWPDynamicFormMode", AV54WWPDynamicFormMode);
            AV61WWPFormElementParentId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV61WWPFormElementParentId", StringUtil.LTrimStr( (decimal)(AV61WWPFormElementParentId), 4, 0));
            AV60WWPFormElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV60WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV60WWPFormElementId), 4, 0));
            AV33SessionId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV33SessionId", StringUtil.LTrimStr( (decimal)(AV33SessionId), 4, 0));
         }
         wcpOAV54WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV54WWPDynamicFormMode");
         wcpOAV61WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV61WWPFormElementParentId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV60WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV60WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV33SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV33SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV54WWPDynamicFormMode, wcpOAV54WWPDynamicFormMode) != 0 ) || ( AV61WWPFormElementParentId != wcpOAV61WWPFormElementParentId ) || ( AV60WWPFormElementId != wcpOAV60WWPFormElementId ) || ( AV33SessionId != wcpOAV33SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV54WWPDynamicFormMode = AV54WWPDynamicFormMode;
         wcpOAV61WWPFormElementParentId = AV61WWPFormElementParentId;
         wcpOAV60WWPFormElementId = AV60WWPFormElementId;
         wcpOAV33SessionId = AV33SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV54WWPDynamicFormMode = cgiGet( sPrefix+"AV54WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV54WWPDynamicFormMode) > 0 )
         {
            AV54WWPDynamicFormMode = cgiGet( sCtrlAV54WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV54WWPDynamicFormMode", AV54WWPDynamicFormMode);
         }
         else
         {
            AV54WWPDynamicFormMode = cgiGet( sPrefix+"AV54WWPDynamicFormMode_PARM");
         }
         sCtrlAV61WWPFormElementParentId = cgiGet( sPrefix+"AV61WWPFormElementParentId_CTRL");
         if ( StringUtil.Len( sCtrlAV61WWPFormElementParentId) > 0 )
         {
            AV61WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV61WWPFormElementParentId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV61WWPFormElementParentId", StringUtil.LTrimStr( (decimal)(AV61WWPFormElementParentId), 4, 0));
         }
         else
         {
            AV61WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV61WWPFormElementParentId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV60WWPFormElementId = cgiGet( sPrefix+"AV60WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV60WWPFormElementId) > 0 )
         {
            AV60WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV60WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV60WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV60WWPFormElementId), 4, 0));
         }
         else
         {
            AV60WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV60WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV33SessionId = cgiGet( sPrefix+"AV33SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV33SessionId) > 0 )
         {
            AV33SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV33SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV33SessionId", StringUtil.LTrimStr( (decimal)(AV33SessionId), 4, 0));
         }
         else
         {
            AV33SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV33SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA272( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS272( ) ;
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
         WS272( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV54WWPDynamicFormMode_PARM", StringUtil.RTrim( AV54WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV54WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV54WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV54WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV61WWPFormElementParentId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61WWPFormElementParentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV61WWPFormElementParentId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV61WWPFormElementParentId_CTRL", StringUtil.RTrim( sCtrlAV61WWPFormElementParentId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV60WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV60WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV60WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV60WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV33SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV33SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV33SessionId_CTRL", StringUtil.RTrim( sCtrlAV33SessionId));
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
         WE272( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212452869", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_addelement.js", "?20257212452874", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Suggest/SuggestRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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

      protected void SubsflControlProps_2702( )
      {
         cmbavGridactiongroup1_Internalname = sPrefix+"vGRIDACTIONGROUP1_"+sGXsfl_270_idx;
         edtavValidations__messagewithtags_Internalname = sPrefix+"vVALIDATIONS__MESSAGEWITHTAGS_"+sGXsfl_270_idx;
         edtavValidations__message_Internalname = sPrefix+"VALIDATIONS__MESSAGE_"+sGXsfl_270_idx;
      }

      protected void SubsflControlProps_fel_2702( )
      {
         cmbavGridactiongroup1_Internalname = sPrefix+"vGRIDACTIONGROUP1_"+sGXsfl_270_fel_idx;
         edtavValidations__messagewithtags_Internalname = sPrefix+"vVALIDATIONS__MESSAGEWITHTAGS_"+sGXsfl_270_fel_idx;
         edtavValidations__message_Internalname = sPrefix+"VALIDATIONS__MESSAGE_"+sGXsfl_270_fel_idx;
      }

      protected void sendrow_2702( )
      {
         sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
         SubsflControlProps_2702( ) ;
         WB270( ) ;
         if ( ( subGridvalidations_Rows * 1 == 0 ) || ( nGXsfl_270_idx <= subGridvalidations_fnc_Recordsperpage( ) * 1 ) )
         {
            GridvalidationsRow = GXWebRow.GetNew(context,GridvalidationsContainer);
            if ( subGridvalidations_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridvalidations_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridvalidations_Class, "") != 0 )
               {
                  subGridvalidations_Linesclass = subGridvalidations_Class+"Odd";
               }
            }
            else if ( subGridvalidations_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridvalidations_Backstyle = 0;
               subGridvalidations_Backcolor = subGridvalidations_Allbackcolor;
               if ( StringUtil.StrCmp(subGridvalidations_Class, "") != 0 )
               {
                  subGridvalidations_Linesclass = subGridvalidations_Class+"Uniform";
               }
            }
            else if ( subGridvalidations_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridvalidations_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridvalidations_Class, "") != 0 )
               {
                  subGridvalidations_Linesclass = subGridvalidations_Class+"Odd";
               }
               subGridvalidations_Backcolor = (int)(0x0);
            }
            else if ( subGridvalidations_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridvalidations_Backstyle = 1;
               if ( ((int)((nGXsfl_270_idx) % (2))) == 0 )
               {
                  subGridvalidations_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridvalidations_Class, "") != 0 )
                  {
                     subGridvalidations_Linesclass = subGridvalidations_Class+"Even";
                  }
               }
               else
               {
                  subGridvalidations_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridvalidations_Class, "") != 0 )
                  {
                     subGridvalidations_Linesclass = subGridvalidations_Class+"Odd";
                  }
               }
            }
            if ( GridvalidationsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_270_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridvalidationsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 271,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',270)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_270_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) && (0==AV19GridActionGroup1) )
                  {
                     AV19GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                     AssignAttri(sPrefix, false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV19GridActionGroup1), 4, 0));
                  }
               }
            }
            /* ComboBox */
            GridvalidationsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_270_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,271);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19GridActionGroup1), 4, 0));
            AssignProp(sPrefix, false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_270_Refreshing);
            /* Subfile cell */
            if ( GridvalidationsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 272,'" + sPrefix + "',false,'" + sGXsfl_270_idx + "',270)\"";
            ROClassString = "Attribute";
            GridvalidationsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavValidations__messagewithtags_Internalname,(string)AV40Validations__MessageWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,272);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavValidations__messagewithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavValidations__messagewithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)270,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridvalidationsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridvalidationsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavValidations__message_Internalname,((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV39Validations.Item(AV97GXV28)).gxTpr_Message,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavValidations__message_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavValidations__message_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)270,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes272( ) ;
            GridvalidationsContainer.AddRow(GridvalidationsRow);
            nGXsfl_270_idx = ((subGridvalidations_Islastpage==1)&&(nGXsfl_270_idx+1>subGridvalidations_fnc_Recordsperpage( )) ? 1 : nGXsfl_270_idx+1);
            sGXsfl_270_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_270_idx), 4, 0), 4, "0");
            SubsflControlProps_2702( ) ;
         }
         /* End function sendrow_2702 */
      }

      protected void init_web_controls( )
      {
         radavFormtype.Name = "vFORMTYPE";
         radavFormtype.WebTags = "";
         radavFormtype.addItem("Plain", context.GetMessage( "Plain", ""), 0);
         radavFormtype.addItem("Wizard", context.GetMessage( "Wizard", ""), 0);
         cmbavWwpformelementtype.Name = "vWWPFORMELEMENTTYPE";
         cmbavWwpformelementtype.WebTags = "";
         cmbavWwpformelementtype.addItem("1", context.GetMessage( "WWP_DF_ElementType_Simple", ""), 0);
         cmbavWwpformelementtype.addItem("2", context.GetMessage( "WWP_DF_ElementType_Container", ""), 0);
         cmbavWwpformelementtype.addItem("3", context.GetMessage( "WWP_DF_ElementType_ElementsRepeater", ""), 0);
         cmbavWwpformelementtype.addItem("4", context.GetMessage( "WWP_DF_ElementType_Label", ""), 0);
         cmbavWwpformelementtype.addItem("5", context.GetMessage( "WWP_DF_ElementType_Step", ""), 0);
         if ( cmbavWwpformelementtype.ItemCount > 0 )
         {
         }
         cmbavWwpformelementcaption.Name = "vWWPFORMELEMENTCAPTION";
         cmbavWwpformelementcaption.WebTags = "";
         cmbavWwpformelementcaption.addItem("1", context.GetMessage( "WWP_DF_ElementCaptionType_Label", ""), 0);
         cmbavWwpformelementcaption.addItem("2", context.GetMessage( "WWP_DF_ElementCaptionType_Title", ""), 0);
         cmbavWwpformelementcaption.addItem("3", context.GetMessage( "WWP_DF_ElementCaptionType_None", ""), 0);
         if ( cmbavWwpformelementcaption.ItemCount > 0 )
         {
         }
         cmbavControl.Name = "vCONTROL";
         cmbavControl.WebTags = "";
         cmbavControl.addItem("Text", context.GetMessage( "Text", ""), 0);
         cmbavControl.addItem("Textarea", context.GetMessage( "Textarea", ""), 0);
         cmbavControl.addItem("Number", context.GetMessage( "Number", ""), 0);
         cmbavControl.addItem("Date", context.GetMessage( "Date picker", ""), 0);
         cmbavControl.addItem("Checkbox", context.GetMessage( "Checkbox", ""), 0);
         cmbavControl.addItem("Switch", context.GetMessage( "Switch (on/off)", ""), 0);
         cmbavControl.addItem("Password", context.GetMessage( "Password", ""), 0);
         cmbavControl.addItem("Options", context.GetMessage( "Predefined options", ""), 0);
         cmbavControl.addItem("File", context.GetMessage( "File upload", ""), 0);
         if ( cmbavControl.ItemCount > 0 )
         {
         }
         radavText_format.Name = "vTEXT_FORMAT";
         radavText_format.WebTags = "";
         radavText_format.addItem("Any", context.GetMessage( "Any", ""), 0);
         radavText_format.addItem("Email", context.GetMessage( "Email", ""), 0);
         radavText_format.addItem("Url", context.GetMessage( "Url", ""), 0);
         radavTextarea_format.Name = "vTEXTAREA_FORMAT";
         radavTextarea_format.WebTags = "";
         radavTextarea_format.addItem("Any", context.GetMessage( "Any", ""), 0);
         radavTextarea_format.addItem("Rich", context.GetMessage( "Formatted text/html", ""), 0);
         chkavDate_includetime.Name = "vDATE_INCLUDETIME";
         chkavDate_includetime.WebTags = "";
         chkavDate_includetime.Caption = context.GetMessage( "WWP_DF_IncludeTime", "");
         AssignProp(sPrefix, false, chkavDate_includetime_Internalname, "TitleCaption", chkavDate_includetime.Caption, true);
         chkavDate_includetime.CheckedValue = "false";
         chkavWwp_df_datemetadata_isdefaultvaluetoday.Name = "WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY";
         chkavWwp_df_datemetadata_isdefaultvaluetoday.WebTags = "";
         chkavWwp_df_datemetadata_isdefaultvaluetoday.Caption = context.GetMessage( "WWP_DF_SetTodayAsDefaultValue", "");
         AssignProp(sPrefix, false, chkavWwp_df_datemetadata_isdefaultvaluetoday_Internalname, "TitleCaption", chkavWwp_df_datemetadata_isdefaultvaluetoday.Caption, true);
         chkavWwp_df_datemetadata_isdefaultvaluetoday.CheckedValue = "false";
         chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.Name = "WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION";
         chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.WebTags = "";
         chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.Caption = context.GetMessage( "WWP_DF_AllowMultipleSelection", "");
         AssignProp(sPrefix, false, chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection_Internalname, "TitleCaption", chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.Caption, true);
         chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.CheckedValue = "false";
         cmbavPredoptions_type.Name = "vPREDOPTIONS_TYPE";
         cmbavPredoptions_type.WebTags = "";
         if ( cmbavPredoptions_type.ItemCount > 0 )
         {
         }
         radavPredoptions_values.Name = "vPREDOPTIONS_VALUES";
         radavPredoptions_values.WebTags = "";
         radavPredoptions_values.addItem("Fixed", context.GetMessage( "Fixed values", ""), 0);
         radavPredoptions_values.addItem("Service", context.GetMessage( "Web service", ""), 0);
         chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Name = "WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE";
         chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.WebTags = "";
         chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Caption = context.GetMessage( "WWP_DF_IncludeEmptyValue", "");
         AssignProp(sPrefix, false, chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_Internalname, "TitleCaption", chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Caption, true);
         chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.CheckedValue = "false";
         chkavWwp_df_containermetadata_collapsable.Name = "WWP_DF_CONTAINERMETADATA_COLLAPSABLE";
         chkavWwp_df_containermetadata_collapsable.WebTags = "";
         chkavWwp_df_containermetadata_collapsable.Caption = context.GetMessage( "WWP_DF_Collapsable", "");
         AssignProp(sPrefix, false, chkavWwp_df_containermetadata_collapsable_Internalname, "TitleCaption", chkavWwp_df_containermetadata_collapsable.Caption, true);
         chkavWwp_df_containermetadata_collapsable.CheckedValue = "false";
         chkavWwp_df_containermetadata_collapsedbydefault.Name = "WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT";
         chkavWwp_df_containermetadata_collapsedbydefault.WebTags = "";
         chkavWwp_df_containermetadata_collapsedbydefault.Caption = context.GetMessage( "WWP_DF_CollapsedByDefault", "");
         AssignProp(sPrefix, false, chkavWwp_df_containermetadata_collapsedbydefault_Internalname, "TitleCaption", chkavWwp_df_containermetadata_collapsedbydefault.Caption, true);
         chkavWwp_df_containermetadata_collapsedbydefault.CheckedValue = "false";
         radavFile_format.Name = "vFILE_FORMAT";
         radavFile_format.WebTags = "";
         radavFile_format.addItem("Any", context.GetMessage( "Any", ""), 0);
         radavFile_format.addItem("Image", context.GetMessage( "Image", ""), 0);
         radavRadio_direction.Name = "vRADIO_DIRECTION";
         radavRadio_direction.WebTags = "";
         radavRadio_direction.addItem("Horizontal", context.GetMessage( "Horizontal", ""), 0);
         radavRadio_direction.addItem("Vertical", context.GetMessage( "Vertical", ""), 0);
         chkavWwp_df_booleanmetadata_defaultvalue.Name = "WWP_DF_BOOLEANMETADATA_DEFAULTVALUE";
         chkavWwp_df_booleanmetadata_defaultvalue.WebTags = "";
         chkavWwp_df_booleanmetadata_defaultvalue.Caption = context.GetMessage( "WWP_DF_DefaultValue", "");
         AssignProp(sPrefix, false, chkavWwp_df_booleanmetadata_defaultvalue_Internalname, "TitleCaption", chkavWwp_df_booleanmetadata_defaultvalue.Caption, true);
         chkavWwp_df_booleanmetadata_defaultvalue.CheckedValue = "false";
         cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.Name = "WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE";
         cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.WebTags = "";
         cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.addItem("1", context.GetMessage( "WWP_DF_ElementRepeater_Type_Plain", ""), 0);
         cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.addItem("2", context.GetMessage( "WWP_DF_ElementRepeater_Type_Grid", ""), 0);
         if ( cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.ItemCount > 0 )
         {
         }
         cmbavWwp_df_elementsrepeatermetadata_repetitionstype.Name = "WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE";
         cmbavWwp_df_elementsrepeatermetadata_repetitionstype.WebTags = "";
         cmbavWwp_df_elementsrepeatermetadata_repetitionstype.addItem("1", context.GetMessage( "WWP_DF_ElementRepeater_Repetitions_AddedByUser", ""), 0);
         cmbavWwp_df_elementsrepeatermetadata_repetitionstype.addItem("2", context.GetMessage( "WWP_DF_ElementRepeater_Repetitions_FixedValue", ""), 0);
         cmbavWwp_df_elementsrepeatermetadata_repetitionstype.addItem("3", context.GetMessage( "WWP_DF_ElementRepeater_Repetitions_Variable", ""), 0);
         if ( cmbavWwp_df_elementsrepeatermetadata_repetitionstype.ItemCount > 0 )
         {
         }
         chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.Name = "WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL";
         chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.WebTags = "";
         chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.Caption = context.GetMessage( "WWP_DF_InsertChildButtonAlignedToLabel", "");
         AssignProp(sPrefix, false, chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_Internalname, "TitleCaption", chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.Caption, true);
         chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.CheckedValue = "false";
         cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.Name = "WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID";
         cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.WebTags = "";
         if ( cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.ItemCount > 0 )
         {
         }
         cmbavWwp_df_labelmetadata_style.Name = "WWP_DF_LABELMETADATA_STYLE";
         cmbavWwp_df_labelmetadata_style.WebTags = "";
         cmbavWwp_df_labelmetadata_style.addItem("0", context.GetMessage( "WWP_DF_LabelMetadata_Style_Text", ""), 0);
         cmbavWwp_df_labelmetadata_style.addItem("1", context.GetMessage( "WWP_DF_LabelMetadata_Style_Title", ""), 0);
         if ( cmbavWwp_df_labelmetadata_style.ItemCount > 0 )
         {
         }
         chkavWwpformelementexcludefromexport.Name = "vWWPFORMELEMENTEXCLUDEFROMEXPORT";
         chkavWwpformelementexcludefromexport.WebTags = "";
         chkavWwpformelementexcludefromexport.Caption = context.GetMessage( "WWP_DF_ExcludeFromExport", "");
         AssignProp(sPrefix, false, chkavWwpformelementexcludefromexport_Internalname, "TitleCaption", chkavWwpformelementexcludefromexport.Caption, true);
         chkavWwpformelementexcludefromexport.CheckedValue = "false";
         chkavIsrequired.Name = "vISREQUIRED";
         chkavIsrequired.WebTags = "";
         chkavIsrequired.Caption = context.GetMessage( "WWP_DF_IsRequired", "");
         AssignProp(sPrefix, false, chkavIsrequired_Internalname, "TitleCaption", chkavIsrequired.Caption, true);
         chkavIsrequired.CheckedValue = "false";
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_270_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            if ( ( AV97GXV28 > 0 ) && ( AV39Validations.Count >= AV97GXV28 ) && (0==AV19GridActionGroup1) )
            {
            }
         }
         cmbavWwpform_wwpformresume.Name = "WWPFORM_WWPFORMRESUME";
         cmbavWwpform_wwpformresume.WebTags = "";
         cmbavWwpform_wwpformresume.addItem("0", context.GetMessage( "WWP_DF_Resume_Never", ""), 0);
         cmbavWwpform_wwpformresume.addItem("1", context.GetMessage( "WWP_DF_Resume_AskUser", ""), 0);
         cmbavWwpform_wwpformresume.addItem("2", context.GetMessage( "WWP_DF_Resume_Always", ""), 0);
         if ( cmbavWwpform_wwpformresume.ItemCount > 0 )
         {
         }
         cmbavWwp_df_containermetadata_style.Name = "WWP_DF_CONTAINERMETADATA_STYLE";
         cmbavWwp_df_containermetadata_style.WebTags = "";
         cmbavWwp_df_containermetadata_style.addItem("0", context.GetMessage( "WWP_DF_ContainerMetadata_Style_None", ""), 0);
         cmbavWwp_df_containermetadata_style.addItem("1", context.GetMessage( "WWP_DF_ContainerMetadata_Style_Panel", ""), 0);
         cmbavWwp_df_containermetadata_style.addItem("2", context.GetMessage( "WWP_DF_ContainerMetadata_Style_PanelWithTitle", ""), 0);
         if ( cmbavWwp_df_containermetadata_style.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl270( )
      {
         if ( GridvalidationsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridvalidationsContainer"+"DivS\" data-gxgridid=\"270\">") ;
            sStyleString = "";
            if ( subGridvalidations_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, subGridvalidations_Internalname, subGridvalidations_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridvalidations_Backcolorstyle == 0 )
            {
               subGridvalidations_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridvalidations_Class) > 0 )
               {
                  subGridvalidations_Linesclass = subGridvalidations_Class+"Title";
               }
            }
            else
            {
               subGridvalidations_Titlebackstyle = 1;
               if ( subGridvalidations_Backcolorstyle == 1 )
               {
                  subGridvalidations_Titlebackcolor = subGridvalidations_Allbackcolor;
                  if ( StringUtil.Len( subGridvalidations_Class) > 0 )
                  {
                     subGridvalidations_Linesclass = subGridvalidations_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridvalidations_Class) > 0 )
                  {
                     subGridvalidations_Linesclass = subGridvalidations_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_Validations", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_Validations", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridvalidationsContainer.AddObjectProperty("GridName", "Gridvalidations");
         }
         else
         {
            GridvalidationsContainer.AddObjectProperty("GridName", "Gridvalidations");
            GridvalidationsContainer.AddObjectProperty("Header", subGridvalidations_Header);
            GridvalidationsContainer.AddObjectProperty("Class", "WorkWith");
            GridvalidationsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridvalidationsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridvalidationsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Backcolorstyle), 1, 0, ".", "")));
            GridvalidationsContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Visible), 5, 0, ".", "")));
            GridvalidationsContainer.AddObjectProperty("CmpContext", sPrefix);
            GridvalidationsContainer.AddObjectProperty("InMasterPage", "false");
            GridvalidationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridvalidationsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19GridActionGroup1), 4, 0, ".", ""))));
            GridvalidationsContainer.AddColumnProperties(GridvalidationsColumn);
            GridvalidationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridvalidationsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV40Validations__MessageWithTags));
            GridvalidationsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavValidations__messagewithtags_Enabled), 5, 0, ".", "")));
            GridvalidationsContainer.AddColumnProperties(GridvalidationsColumn);
            GridvalidationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridvalidationsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavValidations__message_Enabled), 5, 0, ".", "")));
            GridvalidationsContainer.AddColumnProperties(GridvalidationsColumn);
            GridvalidationsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Selectedindex), 4, 0, ".", "")));
            GridvalidationsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Allowselection), 1, 0, ".", "")));
            GridvalidationsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Selectioncolor), 9, 0, ".", "")));
            GridvalidationsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Allowhovering), 1, 0, ".", "")));
            GridvalidationsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Hoveringcolor), 9, 0, ".", "")));
            GridvalidationsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Allowcollapsing), 1, 0, ".", "")));
            GridvalidationsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridvalidations_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTab1_title_Internalname = sPrefix+"TAB1_TITLE";
         radavFormtype_Internalname = sPrefix+"vFORMTYPE";
         divFormtype_cell_Internalname = sPrefix+"FORMTYPE_CELL";
         edtavWwpform_wwpformtitle_Internalname = sPrefix+"WWPFORM_WWPFORMTITLE";
         divWwpform_wwpformtitle_cell_Internalname = sPrefix+"WWPFORM_WWPFORMTITLE_CELL";
         edtavWwpform_wwpformreferencename_Internalname = sPrefix+"WWPFORM_WWPFORMREFERENCENAME";
         divWwpform_wwpformreferencename_cell_Internalname = sPrefix+"WWPFORM_WWPFORMREFERENCENAME_CELL";
         edtavWwpform_wwpformresumemessage_Internalname = sPrefix+"WWPFORM_WWPFORMRESUMEMESSAGE";
         divWwpform_wwpformresumemessage_cell_Internalname = sPrefix+"WWPFORM_WWPFORMRESUMEMESSAGE_CELL";
         cmbavWwpformelementtype_Internalname = sPrefix+"vWWPFORMELEMENTTYPE";
         divWwpformelementtype_cell_Internalname = sPrefix+"WWPFORMELEMENTTYPE_CELL";
         cmbavWwpformelementcaption_Internalname = sPrefix+"vWWPFORMELEMENTCAPTION";
         divWwpformelementcaption_cell_Internalname = sPrefix+"WWPFORMELEMENTCAPTION_CELL";
         edtavWwpformelementtitle_Internalname = sPrefix+"vWWPFORMELEMENTTITLE";
         divWwpformelementtitle_cell_Internalname = sPrefix+"WWPFORMELEMENTTITLE_CELL";
         lblTextblockwwpformelementreferenceid_Internalname = sPrefix+"TEXTBLOCKWWPFORMELEMENTREFERENCEID";
         divTextblockwwpformelementreferenceid_cell_Internalname = sPrefix+"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL";
         edtavWwpformelementreferenceid_Internalname = sPrefix+"vWWPFORMELEMENTREFERENCEID";
         cellWwpformelementreferenceid_cell_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEID_CELL";
         lblReferencieidhelpicon_Internalname = sPrefix+"REFERENCIEIDHELPICON";
         tblTablemergedwwpformelementreferenceid_Internalname = sPrefix+"TABLEMERGEDWWPFORMELEMENTREFERENCEID";
         divTablesplittedwwpformelementreferenceid_Internalname = sPrefix+"TABLESPLITTEDWWPFORMELEMENTREFERENCEID";
         divWwpformelementreferenceidmt_cell_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEIDMT_CELL";
         cmbavControl_Internalname = sPrefix+"vCONTROL";
         divControl_cell_Internalname = sPrefix+"CONTROL_CELL";
         radavText_format_Internalname = sPrefix+"vTEXT_FORMAT";
         divText_format_cell_Internalname = sPrefix+"TEXT_FORMAT_CELL";
         radavTextarea_format_Internalname = sPrefix+"vTEXTAREA_FORMAT";
         divTextarea_format_cell_Internalname = sPrefix+"TEXTAREA_FORMAT_CELL";
         chkavDate_includetime_Internalname = sPrefix+"vDATE_INCLUDETIME";
         divDate_includetime_cell_Internalname = sPrefix+"DATE_INCLUDETIME_CELL";
         chkavWwp_df_datemetadata_isdefaultvaluetoday_Internalname = sPrefix+"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY";
         divWwp_df_datemetadata_isdefaultvaluetoday_cell_Internalname = sPrefix+"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL";
         chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection_Internalname = sPrefix+"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION";
         divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Internalname = sPrefix+"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL";
         cmbavPredoptions_type_Internalname = sPrefix+"vPREDOPTIONS_TYPE";
         divPredoptions_type_cell_Internalname = sPrefix+"PREDOPTIONS_TYPE_CELL";
         radavPredoptions_values_Internalname = sPrefix+"vPREDOPTIONS_VALUES";
         divPredoptions_values_cell_Internalname = sPrefix+"PREDOPTIONS_VALUES_CELL";
         edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Internalname = sPrefix+"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE";
         divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Internalname = sPrefix+"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL";
         edtavPredoptions_options_Internalname = sPrefix+"vPREDOPTIONS_OPTIONS";
         divPredoptions_options_cell_Internalname = sPrefix+"PREDOPTIONS_OPTIONS_CELL";
         chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_Internalname = sPrefix+"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE";
         divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Internalname = sPrefix+"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL";
         edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Internalname = sPrefix+"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT";
         divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Internalname = sPrefix+"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL";
         edtavWwp_df_charmetadata_length_Internalname = sPrefix+"WWP_DF_CHARMETADATA_LENGTH";
         divWwp_df_charmetadata_length_cell_Internalname = sPrefix+"WWP_DF_CHARMETADATA_LENGTH_CELL";
         edtavWwp_df_charmetadata_defaultvalue_Internalname = sPrefix+"WWP_DF_CHARMETADATA_DEFAULTVALUE";
         divWwp_df_charmetadata_defaultvalue_cell_Internalname = sPrefix+"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL";
         chkavWwp_df_containermetadata_collapsable_Internalname = sPrefix+"WWP_DF_CONTAINERMETADATA_COLLAPSABLE";
         divWwp_df_containermetadata_collapsable_cell_Internalname = sPrefix+"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL";
         chkavWwp_df_containermetadata_collapsedbydefault_Internalname = sPrefix+"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT";
         divWwp_df_containermetadata_collapsedbydefault_cell_Internalname = sPrefix+"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL";
         radavFile_format_Internalname = sPrefix+"vFILE_FORMAT";
         divFile_format_cell_Internalname = sPrefix+"FILE_FORMAT_CELL";
         edtavWwp_df_numericmetadata_length_Internalname = sPrefix+"WWP_DF_NUMERICMETADATA_LENGTH";
         divWwp_df_numericmetadata_length_cell_Internalname = sPrefix+"WWP_DF_NUMERICMETADATA_LENGTH_CELL";
         edtavWwp_df_numericmetadata_decimals_Internalname = sPrefix+"WWP_DF_NUMERICMETADATA_DECIMALS";
         divWwp_df_numericmetadata_decimals_cell_Internalname = sPrefix+"WWP_DF_NUMERICMETADATA_DECIMALS_CELL";
         edtavWwp_df_numericmetadata_defaultvalue_Internalname = sPrefix+"WWP_DF_NUMERICMETADATA_DEFAULTVALUE";
         divWwp_df_numericmetadata_defaultvalue_cell_Internalname = sPrefix+"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL";
         radavRadio_direction_Internalname = sPrefix+"vRADIO_DIRECTION";
         divRadio_direction_cell_Internalname = sPrefix+"RADIO_DIRECTION_CELL";
         edtavWwp_df_booleanmetadata_checkbox_controltitle_Internalname = sPrefix+"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE";
         divWwp_df_booleanmetadata_checkbox_controltitle_cell_Internalname = sPrefix+"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL";
         chkavWwp_df_booleanmetadata_defaultvalue_Internalname = sPrefix+"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE";
         divWwp_df_booleanmetadata_defaultvalue_cell_Internalname = sPrefix+"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL";
         edtavWwp_df_stepmetadata_description_Internalname = sPrefix+"WWP_DF_STEPMETADATA_DESCRIPTION";
         divWwp_df_stepmetadata_description_cell_Internalname = sPrefix+"WWP_DF_STEPMETADATA_DESCRIPTION_CELL";
         cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE";
         divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL";
         cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE";
         divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL";
         edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION";
         divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL";
         chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL";
         divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL";
         edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP";
         divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL";
         edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS";
         divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL";
         edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE";
         divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL";
         cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID";
         divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Internalname = sPrefix+"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL";
         cmbavWwp_df_labelmetadata_style_Internalname = sPrefix+"WWP_DF_LABELMETADATA_STYLE";
         divWwp_df_labelmetadata_style_cell_Internalname = sPrefix+"WWP_DF_LABELMETADATA_STYLE_CELL";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         lblTab2_title_Internalname = sPrefix+"TAB2_TITLE";
         chkavWwpformelementexcludefromexport_Internalname = sPrefix+"vWWPFORMELEMENTEXCLUDEFROMEXPORT";
         divWwpformelementexcludefromexport_cell_Internalname = sPrefix+"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL";
         edtavVisiblecondition_Internalname = sPrefix+"vVISIBLECONDITION";
         lblVisibleconditionhelpicon_Internalname = sPrefix+"VISIBLECONDITIONHELPICON";
         Btntestvisiblecondition_Internalname = sPrefix+"BTNTESTVISIBLECONDITION";
         Ucmentionsvisibility_Internalname = sPrefix+"UCMENTIONSVISIBILITY";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         lblTab3_title_Internalname = sPrefix+"TAB3_TITLE";
         chkavIsrequired_Internalname = sPrefix+"vISREQUIRED";
         divIsrequired_cell_Internalname = sPrefix+"ISREQUIRED_CELL";
         Btnaddvalidation_Internalname = sPrefix+"BTNADDVALIDATION";
         cmbavGridactiongroup1_Internalname = sPrefix+"vGRIDACTIONGROUP1";
         edtavValidations__messagewithtags_Internalname = sPrefix+"vVALIDATIONS__MESSAGEWITHTAGS";
         edtavValidations__message_Internalname = sPrefix+"VALIDATIONS__MESSAGE";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = sPrefix+"GXUITABSPANEL_TABS1";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         bttBtnenter_Internalname = sPrefix+"BTNENTER";
         bttBtnuacancel_Internalname = sPrefix+"BTNUACANCEL";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         cmbavWwpform_wwpformresume_Internalname = sPrefix+"WWPFORM_WWPFORMRESUME";
         cmbavWwp_df_containermetadata_style_Internalname = sPrefix+"WWP_DF_CONTAINERMETADATA_STYLE";
         edtavColumns_Internalname = sPrefix+"vCOLUMNS";
         Addvalidation_modal_Internalname = sPrefix+"ADDVALIDATION_MODAL";
         tblTableaddvalidation_modal_Internalname = sPrefix+"TABLEADDVALIDATION_MODAL";
         Updatevalidation_modal_Internalname = sPrefix+"UPDATEVALIDATION_MODAL";
         tblTableupdatevalidation_modal_Internalname = sPrefix+"TABLEUPDATEVALIDATION_MODAL";
         Gridvalidations_empowerer_Internalname = sPrefix+"GRIDVALIDATIONS_EMPOWERER";
         divDiv_wwpauxwc_Internalname = sPrefix+"DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridvalidations_Internalname = sPrefix+"GRIDVALIDATIONS";
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
         subGridvalidations_Allowcollapsing = 0;
         subGridvalidations_Allowselection = 0;
         subGridvalidations_Header = "";
         chkavIsrequired.Caption = context.GetMessage( "WWP_DF_IsRequired", "");
         chkavWwpformelementexcludefromexport.Caption = context.GetMessage( "WWP_DF_ExcludeFromExport", "");
         chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.Caption = context.GetMessage( "WWP_DF_InsertChildButtonAlignedToLabel", "");
         chkavWwp_df_booleanmetadata_defaultvalue.Caption = context.GetMessage( "WWP_DF_DefaultValue", "");
         chkavWwp_df_containermetadata_collapsedbydefault.Caption = context.GetMessage( "WWP_DF_CollapsedByDefault", "");
         chkavWwp_df_containermetadata_collapsable.Caption = context.GetMessage( "WWP_DF_Collapsable", "");
         chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Caption = context.GetMessage( "WWP_DF_IncludeEmptyValue", "");
         chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.Caption = context.GetMessage( "WWP_DF_AllowMultipleSelection", "");
         chkavDate_includetime.Caption = context.GetMessage( "WWP_DF_IncludeTime", "");
         edtavValidations__message_Jsonclick = "";
         edtavValidations__message_Enabled = 0;
         edtavValidations__messagewithtags_Jsonclick = "";
         edtavValidations__messagewithtags_Enabled = 1;
         cmbavGridactiongroup1_Jsonclick = "";
         subGridvalidations_Class = "WorkWith";
         subGridvalidations_Backcolorstyle = 0;
         edtavWwpformelementreferenceid_Jsonclick = "";
         edtavWwpformelementreferenceid_Enabled = 1;
         cellWwpformelementreferenceid_cell_Class = "";
         Addvalidation_modal_Bodytype = "WebComponent";
         Addvalidation_modal_Confirmtype = "";
         Addvalidation_modal_Title = context.GetMessage( "Validation", "");
         Addvalidation_modal_Width = "800";
         Updatevalidation_modal_Bodytype = "WebComponent";
         Updatevalidation_modal_Confirmtype = "";
         Updatevalidation_modal_Title = context.GetMessage( "Validation", "");
         Updatevalidation_modal_Width = "800";
         chkavWwp_df_datemetadata_isdefaultvaluetoday.Caption = context.GetMessage( "WWP_DF_SetTodayAsDefaultValue", "");
         edtavWwpformelementreferenceid_Visible = 1;
         Btnaddvalidation_Visible = Convert.ToBoolean( -1);
         lblReferencieidhelpicon_Caption = context.GetMessage( "<i class='BootstrapTooltipLeft fas fa-circle-info' title='The \"Reference id\" is used to reference this field in the visible conditions or validation of other fields of the form. If this field will not be referenced, it is recommended to leave it blank.'></i>", "");
         Ucmentionsvisibility_Datalistprocextrapartameters = "";
         edtavColumns_Jsonclick = "";
         edtavColumns_Visible = 1;
         cmbavWwp_df_containermetadata_style_Jsonclick = "";
         cmbavWwp_df_containermetadata_style.Visible = 1;
         cmbavWwpform_wwpformresume_Jsonclick = "";
         cmbavWwpform_wwpformresume.Visible = 1;
         subGridvalidations_Visible = 1;
         Btnaddvalidation_Class = "ButtonGray";
         Btnaddvalidation_Caption = context.GetMessage( "WWP_DF_AddValidation", "");
         Btnaddvalidation_Beforeiconclass = "fas fa-circle-plus";
         Btnaddvalidation_Tooltiptext = "";
         chkavIsrequired.Enabled = 1;
         chkavIsrequired.Visible = 1;
         divIsrequired_cell_Class = "col-xs-12 col-sm-9";
         Ucmentionsvisibility_Datalistproc = "WorkWithPlus.DynamicForms.WWP_DF_GetAvailableVariables";
         Btntestvisiblecondition_Class = "ButtonGray";
         Btntestvisiblecondition_Caption = context.GetMessage( "WWP_DF_TestCondition", "");
         Btntestvisiblecondition_Beforeiconclass = "fas fa-circle-play";
         Btntestvisiblecondition_Tooltiptext = "";
         lblVisibleconditionhelpicon_Caption = context.GetMessage( "<i class='BootstrapTooltipLeft fas fa-circle-info' title='VisibleConditionHelpText'></i>", "");
         edtavVisiblecondition_Enabled = 1;
         chkavWwpformelementexcludefromexport.Enabled = 1;
         chkavWwpformelementexcludefromexport.Visible = 1;
         divWwpformelementexcludefromexport_cell_Class = "col-xs-12";
         cmbavWwp_df_labelmetadata_style_Jsonclick = "";
         cmbavWwp_df_labelmetadata_style.Enabled = 1;
         cmbavWwp_df_labelmetadata_style.Visible = 1;
         divWwp_df_labelmetadata_style_cell_Class = "col-xs-12";
         cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Jsonclick = "";
         cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.Enabled = 1;
         cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid.Visible = 1;
         divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class = "col-xs-12";
         edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Jsonclick = "";
         edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Enabled = 1;
         edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Visible = 1;
         divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class = "col-xs-12";
         edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Jsonclick = "";
         edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Enabled = 1;
         edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Visible = 1;
         divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class = "col-xs-12";
         edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Jsonclick = "";
         edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Enabled = 1;
         edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Visible = 1;
         divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class = "col-xs-12";
         chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.Enabled = 1;
         chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel.Visible = 1;
         divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class = "col-xs-12";
         edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Jsonclick = "";
         edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Enabled = 1;
         edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Visible = 1;
         divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class = "col-xs-12";
         cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Jsonclick = "";
         cmbavWwp_df_elementsrepeatermetadata_repetitionstype.Enabled = 1;
         cmbavWwp_df_elementsrepeatermetadata_repetitionstype.Visible = 1;
         divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class = "col-xs-12";
         cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Jsonclick = "";
         cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.Enabled = 1;
         cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype.Visible = 1;
         divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class = "col-xs-12";
         edtavWwp_df_stepmetadata_description_Enabled = 1;
         edtavWwp_df_stepmetadata_description_Visible = 1;
         divWwp_df_stepmetadata_description_cell_Class = "col-xs-12";
         chkavWwp_df_booleanmetadata_defaultvalue.Enabled = 1;
         chkavWwp_df_booleanmetadata_defaultvalue.Visible = 1;
         divWwp_df_booleanmetadata_defaultvalue_cell_Class = "col-xs-12";
         edtavWwp_df_booleanmetadata_checkbox_controltitle_Jsonclick = "";
         edtavWwp_df_booleanmetadata_checkbox_controltitle_Enabled = 1;
         edtavWwp_df_booleanmetadata_checkbox_controltitle_Visible = 1;
         divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class = "col-xs-12";
         radavRadio_direction_Jsonclick = "";
         divRadio_direction_cell_Class = "col-xs-12 DataContentCell DscTop";
         edtavWwp_df_numericmetadata_defaultvalue_Jsonclick = "";
         edtavWwp_df_numericmetadata_defaultvalue_Enabled = 1;
         edtavWwp_df_numericmetadata_defaultvalue_Visible = 1;
         divWwp_df_numericmetadata_defaultvalue_cell_Class = "col-xs-12";
         edtavWwp_df_numericmetadata_decimals_Jsonclick = "";
         edtavWwp_df_numericmetadata_decimals_Enabled = 1;
         edtavWwp_df_numericmetadata_decimals_Visible = 1;
         divWwp_df_numericmetadata_decimals_cell_Class = "col-xs-12";
         edtavWwp_df_numericmetadata_length_Jsonclick = "";
         edtavWwp_df_numericmetadata_length_Enabled = 1;
         edtavWwp_df_numericmetadata_length_Visible = 1;
         divWwp_df_numericmetadata_length_cell_Class = "col-xs-12";
         radavFile_format_Jsonclick = "";
         divFile_format_cell_Class = "col-xs-12 DataContentCell DscTop";
         chkavWwp_df_containermetadata_collapsedbydefault.Enabled = 1;
         chkavWwp_df_containermetadata_collapsedbydefault.Visible = 1;
         divWwp_df_containermetadata_collapsedbydefault_cell_Class = "col-xs-12";
         chkavWwp_df_containermetadata_collapsable.Enabled = 1;
         chkavWwp_df_containermetadata_collapsable.Visible = 1;
         divWwp_df_containermetadata_collapsable_cell_Class = "col-xs-12";
         edtavWwp_df_charmetadata_defaultvalue_Jsonclick = "";
         edtavWwp_df_charmetadata_defaultvalue_Enabled = 1;
         edtavWwp_df_charmetadata_defaultvalue_Visible = 1;
         divWwp_df_charmetadata_defaultvalue_cell_Class = "col-xs-12";
         edtavWwp_df_charmetadata_length_Jsonclick = "";
         edtavWwp_df_charmetadata_length_Enabled = 1;
         edtavWwp_df_charmetadata_length_Visible = 1;
         divWwp_df_charmetadata_length_cell_Class = "col-xs-12";
         edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Jsonclick = "";
         edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Enabled = 1;
         edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Visible = 1;
         divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class = "col-xs-12";
         chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Enabled = 1;
         chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue.Visible = 1;
         divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class = "col-xs-12";
         edtavPredoptions_options_Enabled = 1;
         edtavPredoptions_options_Visible = 1;
         divPredoptions_options_cell_Class = "col-xs-12";
         edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Enabled = 1;
         edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Visible = 1;
         divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class = "col-xs-12";
         radavPredoptions_values_Jsonclick = "";
         divPredoptions_values_cell_Class = "col-xs-12 DataContentCell DscTop";
         cmbavPredoptions_type_Jsonclick = "";
         cmbavPredoptions_type.Enabled = 1;
         cmbavPredoptions_type.Visible = 1;
         divPredoptions_type_cell_Class = "col-xs-12";
         chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.Enabled = 1;
         chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection.Visible = 1;
         divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class = "col-xs-12";
         chkavWwp_df_datemetadata_isdefaultvaluetoday.Enabled = 1;
         chkavWwp_df_datemetadata_isdefaultvaluetoday.Caption = context.GetMessage( "WWP_DF_SetTodayAsDefaultValue", "");
         chkavWwp_df_datemetadata_isdefaultvaluetoday.Visible = 1;
         divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class = "col-xs-12";
         chkavDate_includetime.Enabled = 1;
         chkavDate_includetime.Visible = 1;
         divDate_includetime_cell_Class = "col-xs-12";
         radavTextarea_format_Jsonclick = "";
         divTextarea_format_cell_Class = "col-xs-12 DataContentCell DscTop";
         radavText_format_Jsonclick = "";
         divText_format_cell_Class = "col-xs-12 DataContentCell DscTop";
         cmbavControl_Jsonclick = "";
         cmbavControl.Enabled = 1;
         cmbavControl.Visible = 1;
         divControl_cell_Class = "col-xs-12";
         divTextblockwwpformelementreferenceid_cell_Class = "col-xs-12";
         divTablesplittedwwpformelementreferenceid_Visible = 1;
         divWwpformelementreferenceidmt_cell_Class = "col-xs-12";
         edtavWwpformelementtitle_Enabled = 1;
         edtavWwpformelementtitle_Visible = 1;
         divWwpformelementtitle_cell_Class = "col-xs-12";
         cmbavWwpformelementcaption_Jsonclick = "";
         cmbavWwpformelementcaption.Enabled = 1;
         cmbavWwpformelementcaption.Visible = 1;
         divWwpformelementcaption_cell_Class = "col-xs-12";
         cmbavWwpformelementtype_Jsonclick = "";
         cmbavWwpformelementtype.Enabled = 1;
         cmbavWwpformelementtype.Visible = 1;
         divWwpformelementtype_cell_Class = "col-xs-12";
         edtavWwpform_wwpformresumemessage_Enabled = 1;
         edtavWwpform_wwpformresumemessage_Visible = 1;
         divWwpform_wwpformresumemessage_cell_Class = "col-xs-12";
         edtavWwpform_wwpformreferencename_Jsonclick = "";
         edtavWwpform_wwpformreferencename_Enabled = 1;
         edtavWwpform_wwpformreferencename_Visible = 1;
         divWwpform_wwpformreferencename_cell_Class = "col-xs-12";
         edtavWwpform_wwpformtitle_Jsonclick = "";
         edtavWwpform_wwpformtitle_Enabled = 1;
         edtavWwpform_wwpformtitle_Visible = 1;
         divWwpform_wwpformtitle_cell_Class = "col-xs-12";
         radavFormtype_Jsonclick = "";
         radavFormtype.Visible = 1;
         divFormtype_cell_Class = "col-xs-12";
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 3;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         edtavValidations__message_Enabled = -1;
         subGridvalidations_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"sPrefix"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnaddvalidation_Visible","ctrl":"BTNADDVALIDATION","prop":"Visible"}]}""");
         setEventMetadata("GRIDVALIDATIONS.LOAD","""{"handler":"E33272","iparms":[{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270}]""");
         setEventMetadata("GRIDVALIDATIONS.LOAD",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV19GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"AV40Validations__MessageWithTags","fld":"vVALIDATIONS__MESSAGEWITHTAGS"}]}""");
         setEventMetadata("'DOUACANCEL'","""{"handler":"E11271","iparms":[]}""");
         setEventMetadata("ADDVALIDATION_MODAL.ONLOADCOMPONENT","""{"handler":"E13272","iparms":[{"av":"AV54WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV61WWPFormElementParentId","fld":"vWWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"AV60WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV62WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV33SessionId","fld":"vSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("ADDVALIDATION_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E34272","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV19GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV19GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"AV13CurrentValidationIndex","fld":"vCURRENTVALIDATIONINDEX","pic":"ZZZ9"},{"av":"AV38ValidationJson","fld":"vVALIDATIONJSON"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"subGridvalidations_Visible","ctrl":"GRIDVALIDATIONS","prop":"Visible"}]}""");
         setEventMetadata("UPDATEVALIDATION_MODAL.ONLOADCOMPONENT","""{"handler":"E15272","iparms":[{"av":"AV54WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV61WWPFormElementParentId","fld":"vWWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"AV60WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV62WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV33SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV38ValidationJson","fld":"vVALIDATIONJSON"}]""");
         setEventMetadata("UPDATEVALIDATION_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("'DOTESTVISIBLECONDITION'","""{"handler":"E16272","iparms":[{"av":"AV43VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"AV33SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV60WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV9ConditionError","fld":"vCONDITIONERROR"},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV16ExecuteConditionToTest","fld":"vEXECUTECONDITIONTOTEST"},{"av":"AV62WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV5AllReferenceIds","fld":"vALLREFERENCEIDS"},{"av":"AV44VisibleConditionExpression","fld":"vVISIBLECONDITIONEXPRESSION"}]""");
         setEventMetadata("'DOTESTVISIBLECONDITION'",""","oparms":[{"av":"AV16ExecuteConditionToTest","fld":"vEXECUTECONDITIONTOTEST"},{"av":"AV5AllReferenceIds","fld":"vALLREFERENCEIDS"},{"av":"AV9ConditionError","fld":"vCONDITIONERROR"},{"av":"AV44VisibleConditionExpression","fld":"vVISIBLECONDITIONEXPRESSION"},{"av":"AV7CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("UPDATEVALIDATION_MODAL.CLOSE","""{"handler":"E14272","iparms":[{"av":"Updatevalidation_modal_Result","ctrl":"UPDATEVALIDATION_MODAL","prop":"Result"},{"av":"AV13CurrentValidationIndex","fld":"vCURRENTVALIDATIONINDEX","pic":"ZZZ9"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true}]""");
         setEventMetadata("UPDATEVALIDATION_MODAL.CLOSE",""","oparms":[{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270}]}""");
         setEventMetadata("ADDVALIDATION_MODAL.CLOSE","""{"handler":"E12272","iparms":[{"av":"Addvalidation_modal_Result","ctrl":"ADDVALIDATION_MODAL","prop":"Result"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true}]""");
         setEventMetadata("ADDVALIDATION_MODAL.CLOSE",""","oparms":[{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"subGridvalidations_Visible","ctrl":"GRIDVALIDATIONS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E17272","iparms":[{"av":"AV7CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV54WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"AV33SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV61WWPFormElementParentId","fld":"vWWPFORMELEMENTPARENTID","pic":"ZZZ9"},{"av":"AV60WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV63WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"cmbavWwpformelementcaption"},{"av":"AV57WWPFormElementCaption","fld":"vWWPFORMELEMENTCAPTION","pic":"9"},{"av":"AV62WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV8Columns","fld":"vCOLUMNS","pic":"Z9"},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV44VisibleConditionExpression","fld":"vVISIBLECONDITIONEXPRESSION"},{"av":"AV53WWP_DF_StepMetadata","fld":"vWWP_DF_STEPMETADATA"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV51WWP_DF_LabelMetadata","fld":"vWWP_DF_LABELMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV52WWP_DF_NumericMetadata","fld":"vWWP_DF_NUMERICMETADATA"},{"av":"AV48WWP_DF_DateMetadata","fld":"vWWP_DF_DATEMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV45WWP_DF_BooleanMetadata","fld":"vWWP_DF_BOOLEANMETADATA"},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"AV29PredOptions_Options","fld":"vPREDOPTIONS_OPTIONS"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV43VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"AV16ExecuteConditionToTest","fld":"vEXECUTECONDITIONTOTEST"},{"av":"AV5AllReferenceIds","fld":"vALLREFERENCEIDS"},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV53WWP_DF_StepMetadata","fld":"vWWP_DF_STEPMETADATA"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV7CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV51WWP_DF_LabelMetadata","fld":"vWWP_DF_LABELMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"AV45WWP_DF_BooleanMetadata","fld":"vWWP_DF_BOOLEANMETADATA"},{"av":"AV48WWP_DF_DateMetadata","fld":"vWWP_DF_DATEMETADATA"},{"av":"AV52WWP_DF_NumericMetadata","fld":"vWWP_DF_NUMERICMETADATA"},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV5AllReferenceIds","fld":"vALLREFERENCEIDS"},{"av":"AV16ExecuteConditionToTest","fld":"vEXECUTECONDITIONTOTEST"},{"av":"AV9ConditionError","fld":"vCONDITIONERROR"},{"av":"AV44VisibleConditionExpression","fld":"vVISIBLECONDITIONEXPRESSION"}]}""");
         setEventMetadata("VWWPFORMELEMENTTYPE.CLICK","""{"handler":"E18272","iparms":[{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true}]""");
         setEventMetadata("VWWPFORMELEMENTTYPE.CLICK",""","oparms":[{"av":"AV62WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"chkavIsrequired.Visible","ctrl":"vISREQUIRED","prop":"Visible"},{"av":"divIsrequired_cell_Class","ctrl":"ISREQUIRED_CELL","prop":"Class"},{"av":"chkavWwpformelementexcludefromexport.Visible","ctrl":"vWWPFORMELEMENTEXCLUDEFROMEXPORT","prop":"Visible"},{"av":"divWwpformelementexcludefromexport_cell_Class","ctrl":"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL","prop":"Class"},{"av":"radavFormtype"},{"av":"divFormtype_cell_Class","ctrl":"FORMTYPE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMTITLE","prop":"Visible"},{"av":"divWwpform_wwpformtitle_cell_Class","ctrl":"WWPFORM_WWPFORMTITLE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMREFERENCENAME","prop":"Visible"},{"av":"divWwpform_wwpformreferencename_cell_Class","ctrl":"WWPFORM_WWPFORMREFERENCENAME_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE","prop":"Visible"},{"av":"divWwpform_wwpformresumemessage_cell_Class","ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE_CELL","prop":"Class"},{"av":"cmbavWwpformelementtype"},{"av":"divWwpformelementtype_cell_Class","ctrl":"WWPFORMELEMENTTYPE_CELL","prop":"Class"},{"av":"cmbavWwpformelementcaption"},{"av":"divWwpformelementcaption_cell_Class","ctrl":"WWPFORMELEMENTCAPTION_CELL","prop":"Class"},{"av":"edtavWwpformelementtitle_Visible","ctrl":"vWWPFORMELEMENTTITLE","prop":"Visible"},{"av":"divWwpformelementtitle_cell_Class","ctrl":"WWPFORMELEMENTTITLE_CELL","prop":"Class"},{"av":"cellWwpformelementreferenceid_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"divWwpformelementreferenceidmt_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEIDMT_CELL","prop":"Class"},{"av":"edtavWwpformelementreferenceid_Visible","ctrl":"vWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"divTextblockwwpformelementreferenceid_cell_Class","ctrl":"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"cmbavControl"},{"av":"divControl_cell_Class","ctrl":"CONTROL_CELL","prop":"Class"},{"av":"chkavDate_includetime.Visible","ctrl":"vDATE_INCLUDETIME","prop":"Visible"},{"av":"divDate_includetime_cell_Class","ctrl":"DATE_INCLUDETIME_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Visible"},{"av":"divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class","ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL","prop":"Class"},{"av":"cmbavPredoptions_type"},{"av":"divPredoptions_type_cell_Class","ctrl":"PREDOPTIONS_TYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL","prop":"Class"},{"av":"edtavPredoptions_options_Visible","ctrl":"vPREDOPTIONS_OPTIONS","prop":"Visible"},{"av":"divPredoptions_options_cell_Class","ctrl":"PREDOPTIONS_OPTIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_charmetadata_length_cell_Class","ctrl":"WWP_DF_CHARMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsable_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsedbydefault_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_numericmetadata_length_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS","prop":"Visible"},{"av":"divWwp_df_numericmetadata_decimals_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_numericmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION","prop":"Visible"},{"av":"divWwp_df_stepmetadata_description_cell_Class","ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL","prop":"Class"},{"ctrl":"WWP_DF_LABELMETADATA_STYLE","prop":"Visible"},{"av":"divWwp_df_labelmetadata_style_cell_Class","ctrl":"WWP_DF_LABELMETADATA_STYLE_CELL","prop":"Class"},{"av":"divText_format_cell_Class","ctrl":"TEXT_FORMAT_CELL","prop":"Class"},{"av":"divTextarea_format_cell_Class","ctrl":"TEXTAREA_FORMAT_CELL","prop":"Class"},{"av":"divFile_format_cell_Class","ctrl":"FILE_FORMAT_CELL","prop":"Class"},{"av":"divPredoptions_values_cell_Class","ctrl":"PREDOPTIONS_VALUES_CELL","prop":"Class"},{"av":"divRadio_direction_cell_Class","ctrl":"RADIO_DIRECTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Caption"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"divTablesplittedwwpformelementreferenceid_Visible","ctrl":"TABLESPLITTEDWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("VCONTROL.CLICK","""{"handler":"E19272","iparms":[{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true}]""");
         setEventMetadata("VCONTROL.CLICK",""","oparms":[{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"chkavIsrequired.Visible","ctrl":"vISREQUIRED","prop":"Visible"},{"av":"divIsrequired_cell_Class","ctrl":"ISREQUIRED_CELL","prop":"Class"},{"av":"chkavWwpformelementexcludefromexport.Visible","ctrl":"vWWPFORMELEMENTEXCLUDEFROMEXPORT","prop":"Visible"},{"av":"divWwpformelementexcludefromexport_cell_Class","ctrl":"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL","prop":"Class"},{"av":"radavFormtype"},{"av":"divFormtype_cell_Class","ctrl":"FORMTYPE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMTITLE","prop":"Visible"},{"av":"divWwpform_wwpformtitle_cell_Class","ctrl":"WWPFORM_WWPFORMTITLE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMREFERENCENAME","prop":"Visible"},{"av":"divWwpform_wwpformreferencename_cell_Class","ctrl":"WWPFORM_WWPFORMREFERENCENAME_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE","prop":"Visible"},{"av":"divWwpform_wwpformresumemessage_cell_Class","ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE_CELL","prop":"Class"},{"av":"cmbavWwpformelementtype"},{"av":"divWwpformelementtype_cell_Class","ctrl":"WWPFORMELEMENTTYPE_CELL","prop":"Class"},{"av":"cmbavWwpformelementcaption"},{"av":"divWwpformelementcaption_cell_Class","ctrl":"WWPFORMELEMENTCAPTION_CELL","prop":"Class"},{"av":"edtavWwpformelementtitle_Visible","ctrl":"vWWPFORMELEMENTTITLE","prop":"Visible"},{"av":"divWwpformelementtitle_cell_Class","ctrl":"WWPFORMELEMENTTITLE_CELL","prop":"Class"},{"av":"cellWwpformelementreferenceid_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"divWwpformelementreferenceidmt_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEIDMT_CELL","prop":"Class"},{"av":"edtavWwpformelementreferenceid_Visible","ctrl":"vWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"divTextblockwwpformelementreferenceid_cell_Class","ctrl":"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"cmbavControl"},{"av":"divControl_cell_Class","ctrl":"CONTROL_CELL","prop":"Class"},{"av":"chkavDate_includetime.Visible","ctrl":"vDATE_INCLUDETIME","prop":"Visible"},{"av":"divDate_includetime_cell_Class","ctrl":"DATE_INCLUDETIME_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Visible"},{"av":"divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class","ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL","prop":"Class"},{"av":"cmbavPredoptions_type"},{"av":"divPredoptions_type_cell_Class","ctrl":"PREDOPTIONS_TYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL","prop":"Class"},{"av":"edtavPredoptions_options_Visible","ctrl":"vPREDOPTIONS_OPTIONS","prop":"Visible"},{"av":"divPredoptions_options_cell_Class","ctrl":"PREDOPTIONS_OPTIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_charmetadata_length_cell_Class","ctrl":"WWP_DF_CHARMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsable_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsedbydefault_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_numericmetadata_length_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS","prop":"Visible"},{"av":"divWwp_df_numericmetadata_decimals_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_numericmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION","prop":"Visible"},{"av":"divWwp_df_stepmetadata_description_cell_Class","ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL","prop":"Class"},{"ctrl":"WWP_DF_LABELMETADATA_STYLE","prop":"Visible"},{"av":"divWwp_df_labelmetadata_style_cell_Class","ctrl":"WWP_DF_LABELMETADATA_STYLE_CELL","prop":"Class"},{"av":"divText_format_cell_Class","ctrl":"TEXT_FORMAT_CELL","prop":"Class"},{"av":"divTextarea_format_cell_Class","ctrl":"TEXTAREA_FORMAT_CELL","prop":"Class"},{"av":"divFile_format_cell_Class","ctrl":"FILE_FORMAT_CELL","prop":"Class"},{"av":"divPredoptions_values_cell_Class","ctrl":"PREDOPTIONS_VALUES_CELL","prop":"Class"},{"av":"divRadio_direction_cell_Class","ctrl":"RADIO_DIRECTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Caption"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"divTablesplittedwwpformelementreferenceid_Visible","ctrl":"TABLESPLITTEDWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION.CLICK","""{"handler":"E20272","iparms":[{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true}]""");
         setEventMetadata("WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION.CLICK",""","oparms":[{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"chkavIsrequired.Visible","ctrl":"vISREQUIRED","prop":"Visible"},{"av":"divIsrequired_cell_Class","ctrl":"ISREQUIRED_CELL","prop":"Class"},{"av":"chkavWwpformelementexcludefromexport.Visible","ctrl":"vWWPFORMELEMENTEXCLUDEFROMEXPORT","prop":"Visible"},{"av":"divWwpformelementexcludefromexport_cell_Class","ctrl":"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL","prop":"Class"},{"av":"radavFormtype"},{"av":"divFormtype_cell_Class","ctrl":"FORMTYPE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMTITLE","prop":"Visible"},{"av":"divWwpform_wwpformtitle_cell_Class","ctrl":"WWPFORM_WWPFORMTITLE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMREFERENCENAME","prop":"Visible"},{"av":"divWwpform_wwpformreferencename_cell_Class","ctrl":"WWPFORM_WWPFORMREFERENCENAME_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE","prop":"Visible"},{"av":"divWwpform_wwpformresumemessage_cell_Class","ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE_CELL","prop":"Class"},{"av":"cmbavWwpformelementtype"},{"av":"divWwpformelementtype_cell_Class","ctrl":"WWPFORMELEMENTTYPE_CELL","prop":"Class"},{"av":"cmbavWwpformelementcaption"},{"av":"divWwpformelementcaption_cell_Class","ctrl":"WWPFORMELEMENTCAPTION_CELL","prop":"Class"},{"av":"edtavWwpformelementtitle_Visible","ctrl":"vWWPFORMELEMENTTITLE","prop":"Visible"},{"av":"divWwpformelementtitle_cell_Class","ctrl":"WWPFORMELEMENTTITLE_CELL","prop":"Class"},{"av":"cellWwpformelementreferenceid_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"divWwpformelementreferenceidmt_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEIDMT_CELL","prop":"Class"},{"av":"edtavWwpformelementreferenceid_Visible","ctrl":"vWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"divTextblockwwpformelementreferenceid_cell_Class","ctrl":"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"cmbavControl"},{"av":"divControl_cell_Class","ctrl":"CONTROL_CELL","prop":"Class"},{"av":"chkavDate_includetime.Visible","ctrl":"vDATE_INCLUDETIME","prop":"Visible"},{"av":"divDate_includetime_cell_Class","ctrl":"DATE_INCLUDETIME_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Visible"},{"av":"divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class","ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL","prop":"Class"},{"av":"cmbavPredoptions_type"},{"av":"divPredoptions_type_cell_Class","ctrl":"PREDOPTIONS_TYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL","prop":"Class"},{"av":"edtavPredoptions_options_Visible","ctrl":"vPREDOPTIONS_OPTIONS","prop":"Visible"},{"av":"divPredoptions_options_cell_Class","ctrl":"PREDOPTIONS_OPTIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_charmetadata_length_cell_Class","ctrl":"WWP_DF_CHARMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsable_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsedbydefault_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_numericmetadata_length_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS","prop":"Visible"},{"av":"divWwp_df_numericmetadata_decimals_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_numericmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION","prop":"Visible"},{"av":"divWwp_df_stepmetadata_description_cell_Class","ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL","prop":"Class"},{"ctrl":"WWP_DF_LABELMETADATA_STYLE","prop":"Visible"},{"av":"divWwp_df_labelmetadata_style_cell_Class","ctrl":"WWP_DF_LABELMETADATA_STYLE_CELL","prop":"Class"},{"av":"divText_format_cell_Class","ctrl":"TEXT_FORMAT_CELL","prop":"Class"},{"av":"divTextarea_format_cell_Class","ctrl":"TEXTAREA_FORMAT_CELL","prop":"Class"},{"av":"divFile_format_cell_Class","ctrl":"FILE_FORMAT_CELL","prop":"Class"},{"av":"divPredoptions_values_cell_Class","ctrl":"PREDOPTIONS_VALUES_CELL","prop":"Class"},{"av":"divRadio_direction_cell_Class","ctrl":"RADIO_DIRECTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Caption"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"divTablesplittedwwpformelementreferenceid_Visible","ctrl":"TABLESPLITTEDWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("VPREDOPTIONS_TYPE.CLICK","""{"handler":"E21272","iparms":[{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true}]""");
         setEventMetadata("VPREDOPTIONS_TYPE.CLICK",""","oparms":[{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"chkavIsrequired.Visible","ctrl":"vISREQUIRED","prop":"Visible"},{"av":"divIsrequired_cell_Class","ctrl":"ISREQUIRED_CELL","prop":"Class"},{"av":"chkavWwpformelementexcludefromexport.Visible","ctrl":"vWWPFORMELEMENTEXCLUDEFROMEXPORT","prop":"Visible"},{"av":"divWwpformelementexcludefromexport_cell_Class","ctrl":"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL","prop":"Class"},{"av":"radavFormtype"},{"av":"divFormtype_cell_Class","ctrl":"FORMTYPE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMTITLE","prop":"Visible"},{"av":"divWwpform_wwpformtitle_cell_Class","ctrl":"WWPFORM_WWPFORMTITLE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMREFERENCENAME","prop":"Visible"},{"av":"divWwpform_wwpformreferencename_cell_Class","ctrl":"WWPFORM_WWPFORMREFERENCENAME_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE","prop":"Visible"},{"av":"divWwpform_wwpformresumemessage_cell_Class","ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE_CELL","prop":"Class"},{"av":"cmbavWwpformelementtype"},{"av":"divWwpformelementtype_cell_Class","ctrl":"WWPFORMELEMENTTYPE_CELL","prop":"Class"},{"av":"cmbavWwpformelementcaption"},{"av":"divWwpformelementcaption_cell_Class","ctrl":"WWPFORMELEMENTCAPTION_CELL","prop":"Class"},{"av":"edtavWwpformelementtitle_Visible","ctrl":"vWWPFORMELEMENTTITLE","prop":"Visible"},{"av":"divWwpformelementtitle_cell_Class","ctrl":"WWPFORMELEMENTTITLE_CELL","prop":"Class"},{"av":"cellWwpformelementreferenceid_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"divWwpformelementreferenceidmt_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEIDMT_CELL","prop":"Class"},{"av":"edtavWwpformelementreferenceid_Visible","ctrl":"vWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"divTextblockwwpformelementreferenceid_cell_Class","ctrl":"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"cmbavControl"},{"av":"divControl_cell_Class","ctrl":"CONTROL_CELL","prop":"Class"},{"av":"chkavDate_includetime.Visible","ctrl":"vDATE_INCLUDETIME","prop":"Visible"},{"av":"divDate_includetime_cell_Class","ctrl":"DATE_INCLUDETIME_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Visible"},{"av":"divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class","ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL","prop":"Class"},{"av":"cmbavPredoptions_type"},{"av":"divPredoptions_type_cell_Class","ctrl":"PREDOPTIONS_TYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL","prop":"Class"},{"av":"edtavPredoptions_options_Visible","ctrl":"vPREDOPTIONS_OPTIONS","prop":"Visible"},{"av":"divPredoptions_options_cell_Class","ctrl":"PREDOPTIONS_OPTIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_charmetadata_length_cell_Class","ctrl":"WWP_DF_CHARMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsable_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsedbydefault_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_numericmetadata_length_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS","prop":"Visible"},{"av":"divWwp_df_numericmetadata_decimals_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_numericmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION","prop":"Visible"},{"av":"divWwp_df_stepmetadata_description_cell_Class","ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL","prop":"Class"},{"ctrl":"WWP_DF_LABELMETADATA_STYLE","prop":"Visible"},{"av":"divWwp_df_labelmetadata_style_cell_Class","ctrl":"WWP_DF_LABELMETADATA_STYLE_CELL","prop":"Class"},{"av":"divText_format_cell_Class","ctrl":"TEXT_FORMAT_CELL","prop":"Class"},{"av":"divTextarea_format_cell_Class","ctrl":"TEXTAREA_FORMAT_CELL","prop":"Class"},{"av":"divFile_format_cell_Class","ctrl":"FILE_FORMAT_CELL","prop":"Class"},{"av":"divPredoptions_values_cell_Class","ctrl":"PREDOPTIONS_VALUES_CELL","prop":"Class"},{"av":"divRadio_direction_cell_Class","ctrl":"RADIO_DIRECTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Caption"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"divTablesplittedwwpformelementreferenceid_Visible","ctrl":"TABLESPLITTEDWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("VTEXT_FORMAT.CONTROLVALUECHANGED","""{"handler":"E22272","iparms":[{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true}]""");
         setEventMetadata("VTEXT_FORMAT.CONTROLVALUECHANGED",""","oparms":[{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"chkavIsrequired.Visible","ctrl":"vISREQUIRED","prop":"Visible"},{"av":"divIsrequired_cell_Class","ctrl":"ISREQUIRED_CELL","prop":"Class"},{"av":"chkavWwpformelementexcludefromexport.Visible","ctrl":"vWWPFORMELEMENTEXCLUDEFROMEXPORT","prop":"Visible"},{"av":"divWwpformelementexcludefromexport_cell_Class","ctrl":"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL","prop":"Class"},{"av":"radavFormtype"},{"av":"divFormtype_cell_Class","ctrl":"FORMTYPE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMTITLE","prop":"Visible"},{"av":"divWwpform_wwpformtitle_cell_Class","ctrl":"WWPFORM_WWPFORMTITLE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMREFERENCENAME","prop":"Visible"},{"av":"divWwpform_wwpformreferencename_cell_Class","ctrl":"WWPFORM_WWPFORMREFERENCENAME_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE","prop":"Visible"},{"av":"divWwpform_wwpformresumemessage_cell_Class","ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE_CELL","prop":"Class"},{"av":"cmbavWwpformelementtype"},{"av":"divWwpformelementtype_cell_Class","ctrl":"WWPFORMELEMENTTYPE_CELL","prop":"Class"},{"av":"cmbavWwpformelementcaption"},{"av":"divWwpformelementcaption_cell_Class","ctrl":"WWPFORMELEMENTCAPTION_CELL","prop":"Class"},{"av":"edtavWwpformelementtitle_Visible","ctrl":"vWWPFORMELEMENTTITLE","prop":"Visible"},{"av":"divWwpformelementtitle_cell_Class","ctrl":"WWPFORMELEMENTTITLE_CELL","prop":"Class"},{"av":"cellWwpformelementreferenceid_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"divWwpformelementreferenceidmt_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEIDMT_CELL","prop":"Class"},{"av":"edtavWwpformelementreferenceid_Visible","ctrl":"vWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"divTextblockwwpformelementreferenceid_cell_Class","ctrl":"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"cmbavControl"},{"av":"divControl_cell_Class","ctrl":"CONTROL_CELL","prop":"Class"},{"av":"chkavDate_includetime.Visible","ctrl":"vDATE_INCLUDETIME","prop":"Visible"},{"av":"divDate_includetime_cell_Class","ctrl":"DATE_INCLUDETIME_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Visible"},{"av":"divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class","ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL","prop":"Class"},{"av":"cmbavPredoptions_type"},{"av":"divPredoptions_type_cell_Class","ctrl":"PREDOPTIONS_TYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL","prop":"Class"},{"av":"edtavPredoptions_options_Visible","ctrl":"vPREDOPTIONS_OPTIONS","prop":"Visible"},{"av":"divPredoptions_options_cell_Class","ctrl":"PREDOPTIONS_OPTIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_charmetadata_length_cell_Class","ctrl":"WWP_DF_CHARMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsable_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsedbydefault_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_numericmetadata_length_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS","prop":"Visible"},{"av":"divWwp_df_numericmetadata_decimals_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_numericmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION","prop":"Visible"},{"av":"divWwp_df_stepmetadata_description_cell_Class","ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL","prop":"Class"},{"ctrl":"WWP_DF_LABELMETADATA_STYLE","prop":"Visible"},{"av":"divWwp_df_labelmetadata_style_cell_Class","ctrl":"WWP_DF_LABELMETADATA_STYLE_CELL","prop":"Class"},{"av":"divText_format_cell_Class","ctrl":"TEXT_FORMAT_CELL","prop":"Class"},{"av":"divTextarea_format_cell_Class","ctrl":"TEXTAREA_FORMAT_CELL","prop":"Class"},{"av":"divFile_format_cell_Class","ctrl":"FILE_FORMAT_CELL","prop":"Class"},{"av":"divPredoptions_values_cell_Class","ctrl":"PREDOPTIONS_VALUES_CELL","prop":"Class"},{"av":"divRadio_direction_cell_Class","ctrl":"RADIO_DIRECTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Caption"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"divTablesplittedwwpformelementreferenceid_Visible","ctrl":"TABLESPLITTEDWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("VPREDOPTIONS_VALUES.CONTROLVALUECHANGED","""{"handler":"E23272","iparms":[{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true}]""");
         setEventMetadata("VPREDOPTIONS_VALUES.CONTROLVALUECHANGED",""","oparms":[{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"chkavIsrequired.Visible","ctrl":"vISREQUIRED","prop":"Visible"},{"av":"divIsrequired_cell_Class","ctrl":"ISREQUIRED_CELL","prop":"Class"},{"av":"chkavWwpformelementexcludefromexport.Visible","ctrl":"vWWPFORMELEMENTEXCLUDEFROMEXPORT","prop":"Visible"},{"av":"divWwpformelementexcludefromexport_cell_Class","ctrl":"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL","prop":"Class"},{"av":"radavFormtype"},{"av":"divFormtype_cell_Class","ctrl":"FORMTYPE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMTITLE","prop":"Visible"},{"av":"divWwpform_wwpformtitle_cell_Class","ctrl":"WWPFORM_WWPFORMTITLE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMREFERENCENAME","prop":"Visible"},{"av":"divWwpform_wwpformreferencename_cell_Class","ctrl":"WWPFORM_WWPFORMREFERENCENAME_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE","prop":"Visible"},{"av":"divWwpform_wwpformresumemessage_cell_Class","ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE_CELL","prop":"Class"},{"av":"cmbavWwpformelementtype"},{"av":"divWwpformelementtype_cell_Class","ctrl":"WWPFORMELEMENTTYPE_CELL","prop":"Class"},{"av":"cmbavWwpformelementcaption"},{"av":"divWwpformelementcaption_cell_Class","ctrl":"WWPFORMELEMENTCAPTION_CELL","prop":"Class"},{"av":"edtavWwpformelementtitle_Visible","ctrl":"vWWPFORMELEMENTTITLE","prop":"Visible"},{"av":"divWwpformelementtitle_cell_Class","ctrl":"WWPFORMELEMENTTITLE_CELL","prop":"Class"},{"av":"cellWwpformelementreferenceid_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"divWwpformelementreferenceidmt_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEIDMT_CELL","prop":"Class"},{"av":"edtavWwpformelementreferenceid_Visible","ctrl":"vWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"divTextblockwwpformelementreferenceid_cell_Class","ctrl":"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"cmbavControl"},{"av":"divControl_cell_Class","ctrl":"CONTROL_CELL","prop":"Class"},{"av":"chkavDate_includetime.Visible","ctrl":"vDATE_INCLUDETIME","prop":"Visible"},{"av":"divDate_includetime_cell_Class","ctrl":"DATE_INCLUDETIME_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Visible"},{"av":"divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class","ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL","prop":"Class"},{"av":"cmbavPredoptions_type"},{"av":"divPredoptions_type_cell_Class","ctrl":"PREDOPTIONS_TYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL","prop":"Class"},{"av":"edtavPredoptions_options_Visible","ctrl":"vPREDOPTIONS_OPTIONS","prop":"Visible"},{"av":"divPredoptions_options_cell_Class","ctrl":"PREDOPTIONS_OPTIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_charmetadata_length_cell_Class","ctrl":"WWP_DF_CHARMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsable_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsedbydefault_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_numericmetadata_length_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS","prop":"Visible"},{"av":"divWwp_df_numericmetadata_decimals_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_numericmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION","prop":"Visible"},{"av":"divWwp_df_stepmetadata_description_cell_Class","ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL","prop":"Class"},{"ctrl":"WWP_DF_LABELMETADATA_STYLE","prop":"Visible"},{"av":"divWwp_df_labelmetadata_style_cell_Class","ctrl":"WWP_DF_LABELMETADATA_STYLE_CELL","prop":"Class"},{"av":"divText_format_cell_Class","ctrl":"TEXT_FORMAT_CELL","prop":"Class"},{"av":"divTextarea_format_cell_Class","ctrl":"TEXTAREA_FORMAT_CELL","prop":"Class"},{"av":"divFile_format_cell_Class","ctrl":"FILE_FORMAT_CELL","prop":"Class"},{"av":"divPredoptions_values_cell_Class","ctrl":"PREDOPTIONS_VALUES_CELL","prop":"Class"},{"av":"divRadio_direction_cell_Class","ctrl":"RADIO_DIRECTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Caption"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"divTablesplittedwwpformelementreferenceid_Visible","ctrl":"TABLESPLITTEDWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("VFILE_FORMAT.CONTROLVALUECHANGED","""{"handler":"E24272","iparms":[{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true}]""");
         setEventMetadata("VFILE_FORMAT.CONTROLVALUECHANGED",""","oparms":[{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"chkavIsrequired.Visible","ctrl":"vISREQUIRED","prop":"Visible"},{"av":"divIsrequired_cell_Class","ctrl":"ISREQUIRED_CELL","prop":"Class"},{"av":"chkavWwpformelementexcludefromexport.Visible","ctrl":"vWWPFORMELEMENTEXCLUDEFROMEXPORT","prop":"Visible"},{"av":"divWwpformelementexcludefromexport_cell_Class","ctrl":"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL","prop":"Class"},{"av":"radavFormtype"},{"av":"divFormtype_cell_Class","ctrl":"FORMTYPE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMTITLE","prop":"Visible"},{"av":"divWwpform_wwpformtitle_cell_Class","ctrl":"WWPFORM_WWPFORMTITLE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMREFERENCENAME","prop":"Visible"},{"av":"divWwpform_wwpformreferencename_cell_Class","ctrl":"WWPFORM_WWPFORMREFERENCENAME_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE","prop":"Visible"},{"av":"divWwpform_wwpformresumemessage_cell_Class","ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE_CELL","prop":"Class"},{"av":"cmbavWwpformelementtype"},{"av":"divWwpformelementtype_cell_Class","ctrl":"WWPFORMELEMENTTYPE_CELL","prop":"Class"},{"av":"cmbavWwpformelementcaption"},{"av":"divWwpformelementcaption_cell_Class","ctrl":"WWPFORMELEMENTCAPTION_CELL","prop":"Class"},{"av":"edtavWwpformelementtitle_Visible","ctrl":"vWWPFORMELEMENTTITLE","prop":"Visible"},{"av":"divWwpformelementtitle_cell_Class","ctrl":"WWPFORMELEMENTTITLE_CELL","prop":"Class"},{"av":"cellWwpformelementreferenceid_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"divWwpformelementreferenceidmt_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEIDMT_CELL","prop":"Class"},{"av":"edtavWwpformelementreferenceid_Visible","ctrl":"vWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"divTextblockwwpformelementreferenceid_cell_Class","ctrl":"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"cmbavControl"},{"av":"divControl_cell_Class","ctrl":"CONTROL_CELL","prop":"Class"},{"av":"chkavDate_includetime.Visible","ctrl":"vDATE_INCLUDETIME","prop":"Visible"},{"av":"divDate_includetime_cell_Class","ctrl":"DATE_INCLUDETIME_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Visible"},{"av":"divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class","ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL","prop":"Class"},{"av":"cmbavPredoptions_type"},{"av":"divPredoptions_type_cell_Class","ctrl":"PREDOPTIONS_TYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL","prop":"Class"},{"av":"edtavPredoptions_options_Visible","ctrl":"vPREDOPTIONS_OPTIONS","prop":"Visible"},{"av":"divPredoptions_options_cell_Class","ctrl":"PREDOPTIONS_OPTIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_charmetadata_length_cell_Class","ctrl":"WWP_DF_CHARMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsable_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsedbydefault_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_numericmetadata_length_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS","prop":"Visible"},{"av":"divWwp_df_numericmetadata_decimals_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_numericmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION","prop":"Visible"},{"av":"divWwp_df_stepmetadata_description_cell_Class","ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL","prop":"Class"},{"ctrl":"WWP_DF_LABELMETADATA_STYLE","prop":"Visible"},{"av":"divWwp_df_labelmetadata_style_cell_Class","ctrl":"WWP_DF_LABELMETADATA_STYLE_CELL","prop":"Class"},{"av":"divText_format_cell_Class","ctrl":"TEXT_FORMAT_CELL","prop":"Class"},{"av":"divTextarea_format_cell_Class","ctrl":"TEXTAREA_FORMAT_CELL","prop":"Class"},{"av":"divFile_format_cell_Class","ctrl":"FILE_FORMAT_CELL","prop":"Class"},{"av":"divPredoptions_values_cell_Class","ctrl":"PREDOPTIONS_VALUES_CELL","prop":"Class"},{"av":"divRadio_direction_cell_Class","ctrl":"RADIO_DIRECTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Caption"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"divTablesplittedwwpformelementreferenceid_Visible","ctrl":"TABLESPLITTEDWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("WWP_DF_CONTAINERMETADATA_COLLAPSABLE.CLICK","""{"handler":"E25272","iparms":[{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true}]""");
         setEventMetadata("WWP_DF_CONTAINERMETADATA_COLLAPSABLE.CLICK",""","oparms":[{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"chkavIsrequired.Visible","ctrl":"vISREQUIRED","prop":"Visible"},{"av":"divIsrequired_cell_Class","ctrl":"ISREQUIRED_CELL","prop":"Class"},{"av":"chkavWwpformelementexcludefromexport.Visible","ctrl":"vWWPFORMELEMENTEXCLUDEFROMEXPORT","prop":"Visible"},{"av":"divWwpformelementexcludefromexport_cell_Class","ctrl":"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL","prop":"Class"},{"av":"radavFormtype"},{"av":"divFormtype_cell_Class","ctrl":"FORMTYPE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMTITLE","prop":"Visible"},{"av":"divWwpform_wwpformtitle_cell_Class","ctrl":"WWPFORM_WWPFORMTITLE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMREFERENCENAME","prop":"Visible"},{"av":"divWwpform_wwpformreferencename_cell_Class","ctrl":"WWPFORM_WWPFORMREFERENCENAME_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE","prop":"Visible"},{"av":"divWwpform_wwpformresumemessage_cell_Class","ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE_CELL","prop":"Class"},{"av":"cmbavWwpformelementtype"},{"av":"divWwpformelementtype_cell_Class","ctrl":"WWPFORMELEMENTTYPE_CELL","prop":"Class"},{"av":"cmbavWwpformelementcaption"},{"av":"divWwpformelementcaption_cell_Class","ctrl":"WWPFORMELEMENTCAPTION_CELL","prop":"Class"},{"av":"edtavWwpformelementtitle_Visible","ctrl":"vWWPFORMELEMENTTITLE","prop":"Visible"},{"av":"divWwpformelementtitle_cell_Class","ctrl":"WWPFORMELEMENTTITLE_CELL","prop":"Class"},{"av":"cellWwpformelementreferenceid_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"divWwpformelementreferenceidmt_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEIDMT_CELL","prop":"Class"},{"av":"edtavWwpformelementreferenceid_Visible","ctrl":"vWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"divTextblockwwpformelementreferenceid_cell_Class","ctrl":"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"cmbavControl"},{"av":"divControl_cell_Class","ctrl":"CONTROL_CELL","prop":"Class"},{"av":"chkavDate_includetime.Visible","ctrl":"vDATE_INCLUDETIME","prop":"Visible"},{"av":"divDate_includetime_cell_Class","ctrl":"DATE_INCLUDETIME_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Visible"},{"av":"divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class","ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL","prop":"Class"},{"av":"cmbavPredoptions_type"},{"av":"divPredoptions_type_cell_Class","ctrl":"PREDOPTIONS_TYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL","prop":"Class"},{"av":"edtavPredoptions_options_Visible","ctrl":"vPREDOPTIONS_OPTIONS","prop":"Visible"},{"av":"divPredoptions_options_cell_Class","ctrl":"PREDOPTIONS_OPTIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_charmetadata_length_cell_Class","ctrl":"WWP_DF_CHARMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsable_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsedbydefault_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_numericmetadata_length_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS","prop":"Visible"},{"av":"divWwp_df_numericmetadata_decimals_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_numericmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION","prop":"Visible"},{"av":"divWwp_df_stepmetadata_description_cell_Class","ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL","prop":"Class"},{"ctrl":"WWP_DF_LABELMETADATA_STYLE","prop":"Visible"},{"av":"divWwp_df_labelmetadata_style_cell_Class","ctrl":"WWP_DF_LABELMETADATA_STYLE_CELL","prop":"Class"},{"av":"divText_format_cell_Class","ctrl":"TEXT_FORMAT_CELL","prop":"Class"},{"av":"divTextarea_format_cell_Class","ctrl":"TEXTAREA_FORMAT_CELL","prop":"Class"},{"av":"divFile_format_cell_Class","ctrl":"FILE_FORMAT_CELL","prop":"Class"},{"av":"divPredoptions_values_cell_Class","ctrl":"PREDOPTIONS_VALUES_CELL","prop":"Class"},{"av":"divRadio_direction_cell_Class","ctrl":"RADIO_DIRECTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Caption"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"divTablesplittedwwpformelementreferenceid_Visible","ctrl":"TABLESPLITTEDWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE.CONTROLVALUECHANGED","""{"handler":"E26272","iparms":[{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true}]""");
         setEventMetadata("WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE.CONTROLVALUECHANGED",""","oparms":[{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"chkavIsrequired.Visible","ctrl":"vISREQUIRED","prop":"Visible"},{"av":"divIsrequired_cell_Class","ctrl":"ISREQUIRED_CELL","prop":"Class"},{"av":"chkavWwpformelementexcludefromexport.Visible","ctrl":"vWWPFORMELEMENTEXCLUDEFROMEXPORT","prop":"Visible"},{"av":"divWwpformelementexcludefromexport_cell_Class","ctrl":"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL","prop":"Class"},{"av":"radavFormtype"},{"av":"divFormtype_cell_Class","ctrl":"FORMTYPE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMTITLE","prop":"Visible"},{"av":"divWwpform_wwpformtitle_cell_Class","ctrl":"WWPFORM_WWPFORMTITLE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMREFERENCENAME","prop":"Visible"},{"av":"divWwpform_wwpformreferencename_cell_Class","ctrl":"WWPFORM_WWPFORMREFERENCENAME_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE","prop":"Visible"},{"av":"divWwpform_wwpformresumemessage_cell_Class","ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE_CELL","prop":"Class"},{"av":"cmbavWwpformelementtype"},{"av":"divWwpformelementtype_cell_Class","ctrl":"WWPFORMELEMENTTYPE_CELL","prop":"Class"},{"av":"cmbavWwpformelementcaption"},{"av":"divWwpformelementcaption_cell_Class","ctrl":"WWPFORMELEMENTCAPTION_CELL","prop":"Class"},{"av":"edtavWwpformelementtitle_Visible","ctrl":"vWWPFORMELEMENTTITLE","prop":"Visible"},{"av":"divWwpformelementtitle_cell_Class","ctrl":"WWPFORMELEMENTTITLE_CELL","prop":"Class"},{"av":"cellWwpformelementreferenceid_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"divWwpformelementreferenceidmt_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEIDMT_CELL","prop":"Class"},{"av":"edtavWwpformelementreferenceid_Visible","ctrl":"vWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"divTextblockwwpformelementreferenceid_cell_Class","ctrl":"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"cmbavControl"},{"av":"divControl_cell_Class","ctrl":"CONTROL_CELL","prop":"Class"},{"av":"chkavDate_includetime.Visible","ctrl":"vDATE_INCLUDETIME","prop":"Visible"},{"av":"divDate_includetime_cell_Class","ctrl":"DATE_INCLUDETIME_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Visible"},{"av":"divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class","ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL","prop":"Class"},{"av":"cmbavPredoptions_type"},{"av":"divPredoptions_type_cell_Class","ctrl":"PREDOPTIONS_TYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL","prop":"Class"},{"av":"edtavPredoptions_options_Visible","ctrl":"vPREDOPTIONS_OPTIONS","prop":"Visible"},{"av":"divPredoptions_options_cell_Class","ctrl":"PREDOPTIONS_OPTIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_charmetadata_length_cell_Class","ctrl":"WWP_DF_CHARMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsable_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsedbydefault_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_numericmetadata_length_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS","prop":"Visible"},{"av":"divWwp_df_numericmetadata_decimals_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_numericmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION","prop":"Visible"},{"av":"divWwp_df_stepmetadata_description_cell_Class","ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL","prop":"Class"},{"ctrl":"WWP_DF_LABELMETADATA_STYLE","prop":"Visible"},{"av":"divWwp_df_labelmetadata_style_cell_Class","ctrl":"WWP_DF_LABELMETADATA_STYLE_CELL","prop":"Class"},{"av":"divText_format_cell_Class","ctrl":"TEXT_FORMAT_CELL","prop":"Class"},{"av":"divTextarea_format_cell_Class","ctrl":"TEXTAREA_FORMAT_CELL","prop":"Class"},{"av":"divFile_format_cell_Class","ctrl":"FILE_FORMAT_CELL","prop":"Class"},{"av":"divPredoptions_values_cell_Class","ctrl":"PREDOPTIONS_VALUES_CELL","prop":"Class"},{"av":"divRadio_direction_cell_Class","ctrl":"RADIO_DIRECTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Caption"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"divTablesplittedwwpformelementreferenceid_Visible","ctrl":"TABLESPLITTEDWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE.CONTROLVALUECHANGED","""{"handler":"E27272","iparms":[{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true}]""");
         setEventMetadata("WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE.CONTROLVALUECHANGED",""","oparms":[{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"chkavIsrequired.Visible","ctrl":"vISREQUIRED","prop":"Visible"},{"av":"divIsrequired_cell_Class","ctrl":"ISREQUIRED_CELL","prop":"Class"},{"av":"chkavWwpformelementexcludefromexport.Visible","ctrl":"vWWPFORMELEMENTEXCLUDEFROMEXPORT","prop":"Visible"},{"av":"divWwpformelementexcludefromexport_cell_Class","ctrl":"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL","prop":"Class"},{"av":"radavFormtype"},{"av":"divFormtype_cell_Class","ctrl":"FORMTYPE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMTITLE","prop":"Visible"},{"av":"divWwpform_wwpformtitle_cell_Class","ctrl":"WWPFORM_WWPFORMTITLE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMREFERENCENAME","prop":"Visible"},{"av":"divWwpform_wwpformreferencename_cell_Class","ctrl":"WWPFORM_WWPFORMREFERENCENAME_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE","prop":"Visible"},{"av":"divWwpform_wwpformresumemessage_cell_Class","ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE_CELL","prop":"Class"},{"av":"cmbavWwpformelementtype"},{"av":"divWwpformelementtype_cell_Class","ctrl":"WWPFORMELEMENTTYPE_CELL","prop":"Class"},{"av":"cmbavWwpformelementcaption"},{"av":"divWwpformelementcaption_cell_Class","ctrl":"WWPFORMELEMENTCAPTION_CELL","prop":"Class"},{"av":"edtavWwpformelementtitle_Visible","ctrl":"vWWPFORMELEMENTTITLE","prop":"Visible"},{"av":"divWwpformelementtitle_cell_Class","ctrl":"WWPFORMELEMENTTITLE_CELL","prop":"Class"},{"av":"cellWwpformelementreferenceid_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"divWwpformelementreferenceidmt_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEIDMT_CELL","prop":"Class"},{"av":"edtavWwpformelementreferenceid_Visible","ctrl":"vWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"divTextblockwwpformelementreferenceid_cell_Class","ctrl":"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"cmbavControl"},{"av":"divControl_cell_Class","ctrl":"CONTROL_CELL","prop":"Class"},{"av":"chkavDate_includetime.Visible","ctrl":"vDATE_INCLUDETIME","prop":"Visible"},{"av":"divDate_includetime_cell_Class","ctrl":"DATE_INCLUDETIME_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Visible"},{"av":"divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class","ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL","prop":"Class"},{"av":"cmbavPredoptions_type"},{"av":"divPredoptions_type_cell_Class","ctrl":"PREDOPTIONS_TYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL","prop":"Class"},{"av":"edtavPredoptions_options_Visible","ctrl":"vPREDOPTIONS_OPTIONS","prop":"Visible"},{"av":"divPredoptions_options_cell_Class","ctrl":"PREDOPTIONS_OPTIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_charmetadata_length_cell_Class","ctrl":"WWP_DF_CHARMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsable_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsedbydefault_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_numericmetadata_length_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS","prop":"Visible"},{"av":"divWwp_df_numericmetadata_decimals_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_numericmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION","prop":"Visible"},{"av":"divWwp_df_stepmetadata_description_cell_Class","ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL","prop":"Class"},{"ctrl":"WWP_DF_LABELMETADATA_STYLE","prop":"Visible"},{"av":"divWwp_df_labelmetadata_style_cell_Class","ctrl":"WWP_DF_LABELMETADATA_STYLE_CELL","prop":"Class"},{"av":"divText_format_cell_Class","ctrl":"TEXT_FORMAT_CELL","prop":"Class"},{"av":"divTextarea_format_cell_Class","ctrl":"TEXTAREA_FORMAT_CELL","prop":"Class"},{"av":"divFile_format_cell_Class","ctrl":"FILE_FORMAT_CELL","prop":"Class"},{"av":"divPredoptions_values_cell_Class","ctrl":"PREDOPTIONS_VALUES_CELL","prop":"Class"},{"av":"divRadio_direction_cell_Class","ctrl":"RADIO_DIRECTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Caption"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"divTablesplittedwwpformelementreferenceid_Visible","ctrl":"TABLESPLITTEDWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE.CLICK","""{"handler":"E28272","iparms":[{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true}]""");
         setEventMetadata("WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE.CLICK",""","oparms":[{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"chkavIsrequired.Visible","ctrl":"vISREQUIRED","prop":"Visible"},{"av":"divIsrequired_cell_Class","ctrl":"ISREQUIRED_CELL","prop":"Class"},{"av":"chkavWwpformelementexcludefromexport.Visible","ctrl":"vWWPFORMELEMENTEXCLUDEFROMEXPORT","prop":"Visible"},{"av":"divWwpformelementexcludefromexport_cell_Class","ctrl":"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL","prop":"Class"},{"av":"radavFormtype"},{"av":"divFormtype_cell_Class","ctrl":"FORMTYPE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMTITLE","prop":"Visible"},{"av":"divWwpform_wwpformtitle_cell_Class","ctrl":"WWPFORM_WWPFORMTITLE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMREFERENCENAME","prop":"Visible"},{"av":"divWwpform_wwpformreferencename_cell_Class","ctrl":"WWPFORM_WWPFORMREFERENCENAME_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE","prop":"Visible"},{"av":"divWwpform_wwpformresumemessage_cell_Class","ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE_CELL","prop":"Class"},{"av":"cmbavWwpformelementtype"},{"av":"divWwpformelementtype_cell_Class","ctrl":"WWPFORMELEMENTTYPE_CELL","prop":"Class"},{"av":"cmbavWwpformelementcaption"},{"av":"divWwpformelementcaption_cell_Class","ctrl":"WWPFORMELEMENTCAPTION_CELL","prop":"Class"},{"av":"edtavWwpformelementtitle_Visible","ctrl":"vWWPFORMELEMENTTITLE","prop":"Visible"},{"av":"divWwpformelementtitle_cell_Class","ctrl":"WWPFORMELEMENTTITLE_CELL","prop":"Class"},{"av":"cellWwpformelementreferenceid_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"divWwpformelementreferenceidmt_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEIDMT_CELL","prop":"Class"},{"av":"edtavWwpformelementreferenceid_Visible","ctrl":"vWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"divTextblockwwpformelementreferenceid_cell_Class","ctrl":"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"cmbavControl"},{"av":"divControl_cell_Class","ctrl":"CONTROL_CELL","prop":"Class"},{"av":"chkavDate_includetime.Visible","ctrl":"vDATE_INCLUDETIME","prop":"Visible"},{"av":"divDate_includetime_cell_Class","ctrl":"DATE_INCLUDETIME_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Visible"},{"av":"divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class","ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL","prop":"Class"},{"av":"cmbavPredoptions_type"},{"av":"divPredoptions_type_cell_Class","ctrl":"PREDOPTIONS_TYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL","prop":"Class"},{"av":"edtavPredoptions_options_Visible","ctrl":"vPREDOPTIONS_OPTIONS","prop":"Visible"},{"av":"divPredoptions_options_cell_Class","ctrl":"PREDOPTIONS_OPTIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_charmetadata_length_cell_Class","ctrl":"WWP_DF_CHARMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsable_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsedbydefault_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_numericmetadata_length_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS","prop":"Visible"},{"av":"divWwp_df_numericmetadata_decimals_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_numericmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION","prop":"Visible"},{"av":"divWwp_df_stepmetadata_description_cell_Class","ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL","prop":"Class"},{"ctrl":"WWP_DF_LABELMETADATA_STYLE","prop":"Visible"},{"av":"divWwp_df_labelmetadata_style_cell_Class","ctrl":"WWP_DF_LABELMETADATA_STYLE_CELL","prop":"Class"},{"av":"divText_format_cell_Class","ctrl":"TEXT_FORMAT_CELL","prop":"Class"},{"av":"divTextarea_format_cell_Class","ctrl":"TEXTAREA_FORMAT_CELL","prop":"Class"},{"av":"divFile_format_cell_Class","ctrl":"FILE_FORMAT_CELL","prop":"Class"},{"av":"divPredoptions_values_cell_Class","ctrl":"PREDOPTIONS_VALUES_CELL","prop":"Class"},{"av":"divRadio_direction_cell_Class","ctrl":"RADIO_DIRECTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Caption"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"divTablesplittedwwpformelementreferenceid_Visible","ctrl":"TABLESPLITTEDWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("WWPFORM_WWPFORMRESUME.CONTROLVALUECHANGED","""{"handler":"E29272","iparms":[{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true}]""");
         setEventMetadata("WWPFORM_WWPFORMRESUME.CONTROLVALUECHANGED",""","oparms":[{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"chkavIsrequired.Visible","ctrl":"vISREQUIRED","prop":"Visible"},{"av":"divIsrequired_cell_Class","ctrl":"ISREQUIRED_CELL","prop":"Class"},{"av":"chkavWwpformelementexcludefromexport.Visible","ctrl":"vWWPFORMELEMENTEXCLUDEFROMEXPORT","prop":"Visible"},{"av":"divWwpformelementexcludefromexport_cell_Class","ctrl":"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL","prop":"Class"},{"av":"radavFormtype"},{"av":"divFormtype_cell_Class","ctrl":"FORMTYPE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMTITLE","prop":"Visible"},{"av":"divWwpform_wwpformtitle_cell_Class","ctrl":"WWPFORM_WWPFORMTITLE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMREFERENCENAME","prop":"Visible"},{"av":"divWwpform_wwpformreferencename_cell_Class","ctrl":"WWPFORM_WWPFORMREFERENCENAME_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE","prop":"Visible"},{"av":"divWwpform_wwpformresumemessage_cell_Class","ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE_CELL","prop":"Class"},{"av":"cmbavWwpformelementtype"},{"av":"divWwpformelementtype_cell_Class","ctrl":"WWPFORMELEMENTTYPE_CELL","prop":"Class"},{"av":"cmbavWwpformelementcaption"},{"av":"divWwpformelementcaption_cell_Class","ctrl":"WWPFORMELEMENTCAPTION_CELL","prop":"Class"},{"av":"edtavWwpformelementtitle_Visible","ctrl":"vWWPFORMELEMENTTITLE","prop":"Visible"},{"av":"divWwpformelementtitle_cell_Class","ctrl":"WWPFORMELEMENTTITLE_CELL","prop":"Class"},{"av":"cellWwpformelementreferenceid_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"divWwpformelementreferenceidmt_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEIDMT_CELL","prop":"Class"},{"av":"edtavWwpformelementreferenceid_Visible","ctrl":"vWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"divTextblockwwpformelementreferenceid_cell_Class","ctrl":"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"cmbavControl"},{"av":"divControl_cell_Class","ctrl":"CONTROL_CELL","prop":"Class"},{"av":"chkavDate_includetime.Visible","ctrl":"vDATE_INCLUDETIME","prop":"Visible"},{"av":"divDate_includetime_cell_Class","ctrl":"DATE_INCLUDETIME_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Visible"},{"av":"divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class","ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL","prop":"Class"},{"av":"cmbavPredoptions_type"},{"av":"divPredoptions_type_cell_Class","ctrl":"PREDOPTIONS_TYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL","prop":"Class"},{"av":"edtavPredoptions_options_Visible","ctrl":"vPREDOPTIONS_OPTIONS","prop":"Visible"},{"av":"divPredoptions_options_cell_Class","ctrl":"PREDOPTIONS_OPTIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_charmetadata_length_cell_Class","ctrl":"WWP_DF_CHARMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsable_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsedbydefault_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_numericmetadata_length_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS","prop":"Visible"},{"av":"divWwp_df_numericmetadata_decimals_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_numericmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION","prop":"Visible"},{"av":"divWwp_df_stepmetadata_description_cell_Class","ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL","prop":"Class"},{"ctrl":"WWP_DF_LABELMETADATA_STYLE","prop":"Visible"},{"av":"divWwp_df_labelmetadata_style_cell_Class","ctrl":"WWP_DF_LABELMETADATA_STYLE_CELL","prop":"Class"},{"av":"divText_format_cell_Class","ctrl":"TEXT_FORMAT_CELL","prop":"Class"},{"av":"divTextarea_format_cell_Class","ctrl":"TEXTAREA_FORMAT_CELL","prop":"Class"},{"av":"divFile_format_cell_Class","ctrl":"FILE_FORMAT_CELL","prop":"Class"},{"av":"divPredoptions_values_cell_Class","ctrl":"PREDOPTIONS_VALUES_CELL","prop":"Class"},{"av":"divRadio_direction_cell_Class","ctrl":"RADIO_DIRECTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Caption"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"divTablesplittedwwpformelementreferenceid_Visible","ctrl":"TABLESPLITTEDWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("WWP_DF_CONTAINERMETADATA_STYLE.CONTROLVALUECHANGED","""{"handler":"E30272","iparms":[{"av":"cmbavPredoptions_type"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"cmbavControl"},{"av":"AV10Control","fld":"vCONTROL"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV55WWPForm","fld":"vWWPFORM"},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV47WWP_DF_ContainerMetadata","fld":"vWWP_DF_CONTAINERMETADATA"},{"av":"AV46WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"AV49WWP_DF_ElementsRepeaterMetadata","fld":"vWWP_DF_ELEMENTSREPEATERMETADATA"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true}]""");
         setEventMetadata("WWP_DF_CONTAINERMETADATA_STYLE.CONTROLVALUECHANGED",""","oparms":[{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"chkavIsrequired.Visible","ctrl":"vISREQUIRED","prop":"Visible"},{"av":"divIsrequired_cell_Class","ctrl":"ISREQUIRED_CELL","prop":"Class"},{"av":"chkavWwpformelementexcludefromexport.Visible","ctrl":"vWWPFORMELEMENTEXCLUDEFROMEXPORT","prop":"Visible"},{"av":"divWwpformelementexcludefromexport_cell_Class","ctrl":"WWPFORMELEMENTEXCLUDEFROMEXPORT_CELL","prop":"Class"},{"av":"radavFormtype"},{"av":"divFormtype_cell_Class","ctrl":"FORMTYPE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMTITLE","prop":"Visible"},{"av":"divWwpform_wwpformtitle_cell_Class","ctrl":"WWPFORM_WWPFORMTITLE_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMREFERENCENAME","prop":"Visible"},{"av":"divWwpform_wwpformreferencename_cell_Class","ctrl":"WWPFORM_WWPFORMREFERENCENAME_CELL","prop":"Class"},{"ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE","prop":"Visible"},{"av":"divWwpform_wwpformresumemessage_cell_Class","ctrl":"WWPFORM_WWPFORMRESUMEMESSAGE_CELL","prop":"Class"},{"av":"cmbavWwpformelementtype"},{"av":"divWwpformelementtype_cell_Class","ctrl":"WWPFORMELEMENTTYPE_CELL","prop":"Class"},{"av":"cmbavWwpformelementcaption"},{"av":"divWwpformelementcaption_cell_Class","ctrl":"WWPFORMELEMENTCAPTION_CELL","prop":"Class"},{"av":"edtavWwpformelementtitle_Visible","ctrl":"vWWPFORMELEMENTTITLE","prop":"Visible"},{"av":"divWwpformelementtitle_cell_Class","ctrl":"WWPFORMELEMENTTITLE_CELL","prop":"Class"},{"av":"cellWwpformelementreferenceid_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"divWwpformelementreferenceidmt_cell_Class","ctrl":"WWPFORMELEMENTREFERENCEIDMT_CELL","prop":"Class"},{"av":"edtavWwpformelementreferenceid_Visible","ctrl":"vWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"divTextblockwwpformelementreferenceid_cell_Class","ctrl":"TEXTBLOCKWWPFORMELEMENTREFERENCEID_CELL","prop":"Class"},{"av":"cmbavControl"},{"av":"divControl_cell_Class","ctrl":"CONTROL_CELL","prop":"Class"},{"av":"chkavDate_includetime.Visible","ctrl":"vDATE_INCLUDETIME","prop":"Visible"},{"av":"divDate_includetime_cell_Class","ctrl":"DATE_INCLUDETIME_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Visible"},{"av":"divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class","ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION_CELL","prop":"Class"},{"av":"cmbavPredoptions_type"},{"av":"divPredoptions_type_cell_Class","ctrl":"PREDOPTIONS_TYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_DYNAMIC_GETOPTIONSSERVICE_CELL","prop":"Class"},{"av":"edtavPredoptions_options_Visible","ctrl":"vPREDOPTIONS_OPTIONS","prop":"Visible"},{"av":"divPredoptions_options_cell_Class","ctrl":"PREDOPTIONS_OPTIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT","prop":"Visible"},{"av":"divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class","ctrl":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_EMPTYTEXT_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_charmetadata_length_cell_Class","ctrl":"WWP_DF_CHARMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_charmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_CHARMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsable_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT","prop":"Visible"},{"av":"divWwp_df_containermetadata_collapsedbydefault_cell_Class","ctrl":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_LENGTH","prop":"Visible"},{"av":"divWwp_df_numericmetadata_length_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_LENGTH_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS","prop":"Visible"},{"av":"divWwp_df_numericmetadata_decimals_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DECIMALS_CELL","prop":"Class"},{"ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_numericmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_NUMERICMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_CHECKBOX_CONTROLTITLE_CELL","prop":"Class"},{"ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE","prop":"Visible"},{"av":"divWwp_df_booleanmetadata_defaultvalue_cell_Class","ctrl":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION","prop":"Visible"},{"av":"divWwp_df_stepmetadata_description_cell_Class","ctrl":"WWP_DF_STEPMETADATA_DESCRIPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSDATATYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONSTYPE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDCAPTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_REMOVECHILDTOOLTIP_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_MAXREPETITIONS_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_FIXEDVALUE_VALUE_CELL","prop":"Class"},{"ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID","prop":"Visible"},{"av":"divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class","ctrl":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_VARIABLE_ELEMENTID_CELL","prop":"Class"},{"ctrl":"WWP_DF_LABELMETADATA_STYLE","prop":"Visible"},{"av":"divWwp_df_labelmetadata_style_cell_Class","ctrl":"WWP_DF_LABELMETADATA_STYLE_CELL","prop":"Class"},{"av":"divText_format_cell_Class","ctrl":"TEXT_FORMAT_CELL","prop":"Class"},{"av":"divTextarea_format_cell_Class","ctrl":"TEXTAREA_FORMAT_CELL","prop":"Class"},{"av":"divFile_format_cell_Class","ctrl":"FILE_FORMAT_CELL","prop":"Class"},{"av":"divPredoptions_values_cell_Class","ctrl":"PREDOPTIONS_VALUES_CELL","prop":"Class"},{"av":"divRadio_direction_cell_Class","ctrl":"RADIO_DIRECTION_CELL","prop":"Class"},{"ctrl":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY","prop":"Caption"},{"av":"AV30PredOptions_Type","fld":"vPREDOPTIONS_TYPE"},{"av":"divTablesplittedwwpformelementreferenceid_Visible","ctrl":"TABLESPLITTEDWWPFORMELEMENTREFERENCEID","prop":"Visible"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV55WWPForm","fld":"vWWPFORM"}]}""");
         setEventMetadata("GRIDVALIDATIONS_FIRSTPAGE","""{"handler":"subgridvalidations_firstpage","iparms":[{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"sPrefix"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"}]""");
         setEventMetadata("GRIDVALIDATIONS_FIRSTPAGE",""","oparms":[{"av":"Btnaddvalidation_Visible","ctrl":"BTNADDVALIDATION","prop":"Visible"}]}""");
         setEventMetadata("GRIDVALIDATIONS_PREVPAGE","""{"handler":"subgridvalidations_previouspage","iparms":[{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"sPrefix"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"}]""");
         setEventMetadata("GRIDVALIDATIONS_PREVPAGE",""","oparms":[{"av":"Btnaddvalidation_Visible","ctrl":"BTNADDVALIDATION","prop":"Visible"}]}""");
         setEventMetadata("GRIDVALIDATIONS_NEXTPAGE","""{"handler":"subgridvalidations_nextpage","iparms":[{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"sPrefix"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"}]""");
         setEventMetadata("GRIDVALIDATIONS_NEXTPAGE",""","oparms":[{"av":"Btnaddvalidation_Visible","ctrl":"BTNADDVALIDATION","prop":"Visible"}]}""");
         setEventMetadata("GRIDVALIDATIONS_LASTPAGE","""{"handler":"subgridvalidations_lastpage","iparms":[{"av":"GRIDVALIDATIONS_nFirstRecordOnPage"},{"av":"GRIDVALIDATIONS_nEOF"},{"av":"subGridvalidations_Rows","ctrl":"GRIDVALIDATIONS","prop":"Rows"},{"av":"AV39Validations","fld":"vVALIDATIONS","grid":270},{"av":"nGXsfl_270_idx","ctrl":"GRID","prop":"GridCurrRow","grid":270},{"av":"nRC_GXsfl_270","ctrl":"GRIDVALIDATIONS","prop":"GridRC","grid":270},{"av":"AV58WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","hsh":true},{"av":"AV22IsFormSettings","fld":"vISFORMSETTINGS","hsh":true},{"av":"AV65WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"AV28ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"sPrefix"},{"av":"cmbavWwpformelementtype"},{"av":"AV64WWPFormElementType","fld":"vWWPFORMELEMENTTYPE","pic":"9"},{"av":"radavFormtype"},{"av":"AV18FormType","fld":"vFORMTYPE"},{"av":"radavText_format"},{"av":"AV35Text_Format","fld":"vTEXT_FORMAT"},{"av":"radavTextarea_format"},{"av":"AV36TextArea_Format","fld":"vTEXTAREA_FORMAT"},{"av":"AV14Date_IncludeTime","fld":"vDATE_INCLUDETIME"},{"av":"GXV4","fld":"WWP_DF_DATEMETADATA_ISDEFAULTVALUETODAY"},{"av":"GXV5","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_ALLOWMULTIPLESELECTION"},{"av":"radavPredoptions_values"},{"av":"AV31PredOptions_Values","fld":"vPREDOPTIONS_VALUES"},{"av":"GXV7","fld":"WWP_DF_CHARMETADATA_MULTIPLEOPTIONS_COMBOBOX_INCLUDEEMPTYVALUE"},{"av":"GXV11","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSABLE"},{"av":"GXV12","fld":"WWP_DF_CONTAINERMETADATA_COLLAPSEDBYDEFAULT"},{"av":"radavFile_format"},{"av":"AV17File_Format","fld":"vFILE_FORMAT"},{"av":"radavRadio_direction"},{"av":"AV32Radio_Direction","fld":"vRADIO_DIRECTION"},{"av":"GXV17","fld":"WWP_DF_BOOLEANMETADATA_DEFAULTVALUE"},{"av":"GXV22","fld":"WWP_DF_ELEMENTSREPEATERMETADATA_REPETITIONS_USERADDED_INSERTCHILDBUTTON_ISALIGNEDTOLABEL"},{"av":"AV59WWPFormElementExcludeFromExport","fld":"vWWPFORMELEMENTEXCLUDEFROMEXPORT"},{"av":"AV24IsRequired","fld":"vISREQUIRED"}]""");
         setEventMetadata("GRIDVALIDATIONS_LASTPAGE",""","oparms":[{"av":"Btnaddvalidation_Visible","ctrl":"BTNADDVALIDATION","prop":"Visible"}]}""");
         setEventMetadata("VALIDV_WWPFORMELEMENTTYPE","""{"handler":"Validv_Wwpformelementtype","iparms":[]}""");
         setEventMetadata("VALIDV_WWPFORMELEMENTCAPTION","""{"handler":"Validv_Wwpformelementcaption","iparms":[]}""");
         setEventMetadata("VALIDV_GXV19","""{"handler":"Validv_Gxv19","iparms":[]}""");
         setEventMetadata("VALIDV_GXV20","""{"handler":"Validv_Gxv20","iparms":[]}""");
         setEventMetadata("VALIDV_GXV27","""{"handler":"Validv_Gxv27","iparms":[]}""");
         setEventMetadata("VALIDV_GXV30","""{"handler":"Validv_Gxv30","iparms":[]}""");
         setEventMetadata("VALIDV_GXV31","""{"handler":"Validv_Gxv31","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv29","iparms":[]}""");
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
         wcpOAV54WWPDynamicFormMode = "";
         Updatevalidation_modal_Result = "";
         Addvalidation_modal_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV39Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version2");
         AV18FormType = "";
         AV35Text_Format = "";
         AV36TextArea_Format = "";
         AV48WWP_DF_DateMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata(context);
         AV46WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV31PredOptions_Values = "";
         AV47WWP_DF_ContainerMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
         AV17File_Format = "";
         AV32Radio_Direction = "";
         AV45WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
         AV49WWP_DF_ElementsRepeaterMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
         AV65WWPFormTitle = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV55WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV52WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
         AV53WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
         AV51WWP_DF_LabelMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata(context);
         AV38ValidationJson = "";
         AV9ConditionError = "";
         AV5AllReferenceIds = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "Comforta_version2");
         AV44VisibleConditionExpression = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         GX_FocusControl = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblTab1_title_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV63WWPFormElementTitle = "";
         lblTextblockwwpformelementreferenceid_Jsonclick = "";
         AV10Control = "";
         AV30PredOptions_Type = "";
         AV29PredOptions_Options = "";
         lblTab2_title_Jsonclick = "";
         AV43VisibleCondition = "";
         lblVisibleconditionhelpicon_Jsonclick = "";
         ucBtntestvisiblecondition = new GXUserControl();
         ucUcmentionsvisibility = new GXUserControl();
         lblTab3_title_Jsonclick = "";
         ucBtnaddvalidation = new GXUserControl();
         GridvalidationsContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtnenter_Jsonclick = "";
         bttBtnuacancel_Jsonclick = "";
         ucGridvalidations_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV40Validations__MessageWithTags = "";
         GXDecQS = "";
         AV62WWPFormElementReferenceId = "";
         AV66GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV67GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         Ucmentionsvisibility_Gamoauthtoken = "";
         GXt_SdtWWP_Form1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV27ParentElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV11CurrentElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV41VarCharAux = "";
         AV50WWP_DF_ImageMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata(context);
         AV15ElementAux = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         Gridvalidations_empowerer_Gridinternalname = "";
         AV34Text = "";
         GridvalidationsRow = new GXWebRow();
         AV12CurrentValidation = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation(context);
         AV37Validation = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation(context);
         AV56WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV107GXV37 = new GxSimpleCollection<string>();
         GXt_char3 = "";
         AV42VarCharList = new GxSimpleCollection<string>();
         AV26OriginalElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         GXt_SdtWWP_Form_Element2 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV6AuxWWP_DF_ElementsRepeaterMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
         ucUpdatevalidation_modal = new GXUserControl();
         ucAddvalidation_modal = new GXUserControl();
         lblReferencieidhelpicon_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV54WWPDynamicFormMode = "";
         sCtrlAV61WWPFormElementParentId = "";
         sCtrlAV60WWPFormElementId = "";
         sCtrlAV33SessionId = "";
         subGridvalidations_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridvalidationsColumn = new GXWebColumn();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavValidations__messagewithtags_Enabled = 0;
         edtavValidations__message_Enabled = 0;
      }

      private short AV61WWPFormElementParentId ;
      private short AV60WWPFormElementId ;
      private short AV33SessionId ;
      private short wcpOAV61WWPFormElementParentId ;
      private short wcpOAV60WWPFormElementId ;
      private short wcpOAV33SessionId ;
      private short GRIDVALIDATIONS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV64WWPFormElementType ;
      private short AV58WWPFormElementDataType ;
      private short AV13CurrentValidationIndex ;
      private short wbEnd ;
      private short wbStart ;
      private short AV57WWPFormElementCaption ;
      private short AV8Columns ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV19GridActionGroup1 ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGridvalidations_Backcolorstyle ;
      private short AV20Index ;
      private short AV105Referencecount ;
      private short nGXWrapped ;
      private short subGridvalidations_Backstyle ;
      private short subGridvalidations_Titlebackstyle ;
      private short subGridvalidations_Allowselection ;
      private short subGridvalidations_Allowhovering ;
      private short subGridvalidations_Allowcollapsing ;
      private short subGridvalidations_Collapsed ;
      private int nRC_GXsfl_270 ;
      private int subGridvalidations_Rows ;
      private int nGXsfl_270_idx=1 ;
      private int edtavValidations__messagewithtags_Enabled ;
      private int edtavValidations__message_Enabled ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int edtavWwpform_wwpformtitle_Visible ;
      private int edtavWwpform_wwpformtitle_Enabled ;
      private int edtavWwpform_wwpformreferencename_Visible ;
      private int edtavWwpform_wwpformreferencename_Enabled ;
      private int edtavWwpform_wwpformresumemessage_Visible ;
      private int edtavWwpform_wwpformresumemessage_Enabled ;
      private int edtavWwpformelementtitle_Visible ;
      private int edtavWwpformelementtitle_Enabled ;
      private int divTablesplittedwwpformelementreferenceid_Visible ;
      private int edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Visible ;
      private int edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Enabled ;
      private int edtavPredoptions_options_Visible ;
      private int edtavPredoptions_options_Enabled ;
      private int edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Visible ;
      private int edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Enabled ;
      private int edtavWwp_df_charmetadata_length_Visible ;
      private int edtavWwp_df_charmetadata_length_Enabled ;
      private int edtavWwp_df_charmetadata_defaultvalue_Visible ;
      private int edtavWwp_df_charmetadata_defaultvalue_Enabled ;
      private int edtavWwp_df_numericmetadata_length_Visible ;
      private int edtavWwp_df_numericmetadata_length_Enabled ;
      private int edtavWwp_df_numericmetadata_decimals_Visible ;
      private int edtavWwp_df_numericmetadata_decimals_Enabled ;
      private int edtavWwp_df_numericmetadata_defaultvalue_Visible ;
      private int edtavWwp_df_numericmetadata_defaultvalue_Enabled ;
      private int edtavWwp_df_booleanmetadata_checkbox_controltitle_Visible ;
      private int edtavWwp_df_booleanmetadata_checkbox_controltitle_Enabled ;
      private int edtavWwp_df_stepmetadata_description_Visible ;
      private int edtavWwp_df_stepmetadata_description_Enabled ;
      private int edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Visible ;
      private int edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Enabled ;
      private int edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Visible ;
      private int edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Enabled ;
      private int edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Visible ;
      private int edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Enabled ;
      private int edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Visible ;
      private int edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Enabled ;
      private int edtavVisiblecondition_Enabled ;
      private int AV97GXV28 ;
      private int subGridvalidations_Visible ;
      private int edtavColumns_Visible ;
      private int subGridvalidations_Islastpage ;
      private int GRIDVALIDATIONS_nGridOutOfScope ;
      private int nGXsfl_270_fel_idx=1 ;
      private int AV101GXV32 ;
      private int AV102GXV33 ;
      private int nGXsfl_270_bak_idx=1 ;
      private int edtavWwpformelementreferenceid_Visible ;
      private int AV103GXV34 ;
      private int AV104GXV35 ;
      private int AV106GXV36 ;
      private int AV108GXV38 ;
      private int AV109GXV39 ;
      private int AV110GXV40 ;
      private int AV111GXV41 ;
      private int AV112GXV42 ;
      private int edtavWwpformelementreferenceid_Enabled ;
      private int idxLst ;
      private int subGridvalidations_Backcolor ;
      private int subGridvalidations_Allbackcolor ;
      private int subGridvalidations_Titlebackcolor ;
      private int subGridvalidations_Selectedindex ;
      private int subGridvalidations_Selectioncolor ;
      private int subGridvalidations_Hoveringcolor ;
      private long GRIDVALIDATIONS_nFirstRecordOnPage ;
      private long GRIDVALIDATIONS_nCurrentRecord ;
      private long GRIDVALIDATIONS_nRecordCount ;
      private string AV54WWPDynamicFormMode ;
      private string wcpOAV54WWPDynamicFormMode ;
      private string Updatevalidation_modal_Result ;
      private string Addvalidation_modal_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_270_idx="0001" ;
      private string edtavValidations__messagewithtags_Internalname ;
      private string edtavValidations__message_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTableattributes_Internalname ;
      private string Gxuitabspanel_tabs1_Class ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblTab1_title_Internalname ;
      private string lblTab1_title_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string divFormtype_cell_Internalname ;
      private string divFormtype_cell_Class ;
      private string radavFormtype_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string TempTags ;
      private string radavFormtype_Jsonclick ;
      private string divWwpform_wwpformtitle_cell_Internalname ;
      private string divWwpform_wwpformtitle_cell_Class ;
      private string edtavWwpform_wwpformtitle_Internalname ;
      private string edtavWwpform_wwpformtitle_Jsonclick ;
      private string divWwpform_wwpformreferencename_cell_Internalname ;
      private string divWwpform_wwpformreferencename_cell_Class ;
      private string edtavWwpform_wwpformreferencename_Internalname ;
      private string edtavWwpform_wwpformreferencename_Jsonclick ;
      private string divWwpform_wwpformresumemessage_cell_Internalname ;
      private string divWwpform_wwpformresumemessage_cell_Class ;
      private string edtavWwpform_wwpformresumemessage_Internalname ;
      private string divWwpformelementtype_cell_Internalname ;
      private string divWwpformelementtype_cell_Class ;
      private string cmbavWwpformelementtype_Internalname ;
      private string cmbavWwpformelementtype_Jsonclick ;
      private string divWwpformelementcaption_cell_Internalname ;
      private string divWwpformelementcaption_cell_Class ;
      private string cmbavWwpformelementcaption_Internalname ;
      private string cmbavWwpformelementcaption_Jsonclick ;
      private string divWwpformelementtitle_cell_Internalname ;
      private string divWwpformelementtitle_cell_Class ;
      private string edtavWwpformelementtitle_Internalname ;
      private string divWwpformelementreferenceidmt_cell_Internalname ;
      private string divWwpformelementreferenceidmt_cell_Class ;
      private string divTablesplittedwwpformelementreferenceid_Internalname ;
      private string divTextblockwwpformelementreferenceid_cell_Internalname ;
      private string divTextblockwwpformelementreferenceid_cell_Class ;
      private string lblTextblockwwpformelementreferenceid_Internalname ;
      private string lblTextblockwwpformelementreferenceid_Jsonclick ;
      private string divControl_cell_Internalname ;
      private string divControl_cell_Class ;
      private string cmbavControl_Internalname ;
      private string cmbavControl_Jsonclick ;
      private string divText_format_cell_Internalname ;
      private string divText_format_cell_Class ;
      private string radavText_format_Internalname ;
      private string radavText_format_Jsonclick ;
      private string divTextarea_format_cell_Internalname ;
      private string divTextarea_format_cell_Class ;
      private string radavTextarea_format_Internalname ;
      private string radavTextarea_format_Jsonclick ;
      private string divDate_includetime_cell_Internalname ;
      private string divDate_includetime_cell_Class ;
      private string chkavDate_includetime_Internalname ;
      private string divWwp_df_datemetadata_isdefaultvaluetoday_cell_Internalname ;
      private string divWwp_df_datemetadata_isdefaultvaluetoday_cell_Class ;
      private string chkavWwp_df_datemetadata_isdefaultvaluetoday_Internalname ;
      private string divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Internalname ;
      private string divWwp_df_charmetadata_multipleoptions_allowmultipleselection_cell_Class ;
      private string chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection_Internalname ;
      private string divPredoptions_type_cell_Internalname ;
      private string divPredoptions_type_cell_Class ;
      private string cmbavPredoptions_type_Internalname ;
      private string cmbavPredoptions_type_Jsonclick ;
      private string divPredoptions_values_cell_Internalname ;
      private string divPredoptions_values_cell_Class ;
      private string radavPredoptions_values_Internalname ;
      private string radavPredoptions_values_Jsonclick ;
      private string divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Internalname ;
      private string divWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_cell_Class ;
      private string edtavWwp_df_charmetadata_multipleoptions_dynamic_getoptionsservice_Internalname ;
      private string divPredoptions_options_cell_Internalname ;
      private string divPredoptions_options_cell_Class ;
      private string edtavPredoptions_options_Internalname ;
      private string divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Internalname ;
      private string divWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_cell_Class ;
      private string chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue_Internalname ;
      private string divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Internalname ;
      private string divWwp_df_charmetadata_multipleoptions_combobox_emptytext_cell_Class ;
      private string edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Internalname ;
      private string edtavWwp_df_charmetadata_multipleoptions_combobox_emptytext_Jsonclick ;
      private string divWwp_df_charmetadata_length_cell_Internalname ;
      private string divWwp_df_charmetadata_length_cell_Class ;
      private string edtavWwp_df_charmetadata_length_Internalname ;
      private string edtavWwp_df_charmetadata_length_Jsonclick ;
      private string divWwp_df_charmetadata_defaultvalue_cell_Internalname ;
      private string divWwp_df_charmetadata_defaultvalue_cell_Class ;
      private string edtavWwp_df_charmetadata_defaultvalue_Internalname ;
      private string edtavWwp_df_charmetadata_defaultvalue_Jsonclick ;
      private string divWwp_df_containermetadata_collapsable_cell_Internalname ;
      private string divWwp_df_containermetadata_collapsable_cell_Class ;
      private string chkavWwp_df_containermetadata_collapsable_Internalname ;
      private string divWwp_df_containermetadata_collapsedbydefault_cell_Internalname ;
      private string divWwp_df_containermetadata_collapsedbydefault_cell_Class ;
      private string chkavWwp_df_containermetadata_collapsedbydefault_Internalname ;
      private string divFile_format_cell_Internalname ;
      private string divFile_format_cell_Class ;
      private string radavFile_format_Internalname ;
      private string radavFile_format_Jsonclick ;
      private string divWwp_df_numericmetadata_length_cell_Internalname ;
      private string divWwp_df_numericmetadata_length_cell_Class ;
      private string edtavWwp_df_numericmetadata_length_Internalname ;
      private string edtavWwp_df_numericmetadata_length_Jsonclick ;
      private string divWwp_df_numericmetadata_decimals_cell_Internalname ;
      private string divWwp_df_numericmetadata_decimals_cell_Class ;
      private string edtavWwp_df_numericmetadata_decimals_Internalname ;
      private string edtavWwp_df_numericmetadata_decimals_Jsonclick ;
      private string divWwp_df_numericmetadata_defaultvalue_cell_Internalname ;
      private string divWwp_df_numericmetadata_defaultvalue_cell_Class ;
      private string edtavWwp_df_numericmetadata_defaultvalue_Internalname ;
      private string edtavWwp_df_numericmetadata_defaultvalue_Jsonclick ;
      private string divRadio_direction_cell_Internalname ;
      private string divRadio_direction_cell_Class ;
      private string radavRadio_direction_Internalname ;
      private string radavRadio_direction_Jsonclick ;
      private string divWwp_df_booleanmetadata_checkbox_controltitle_cell_Internalname ;
      private string divWwp_df_booleanmetadata_checkbox_controltitle_cell_Class ;
      private string edtavWwp_df_booleanmetadata_checkbox_controltitle_Internalname ;
      private string edtavWwp_df_booleanmetadata_checkbox_controltitle_Jsonclick ;
      private string divWwp_df_booleanmetadata_defaultvalue_cell_Internalname ;
      private string divWwp_df_booleanmetadata_defaultvalue_cell_Class ;
      private string chkavWwp_df_booleanmetadata_defaultvalue_Internalname ;
      private string divWwp_df_stepmetadata_description_cell_Internalname ;
      private string divWwp_df_stepmetadata_description_cell_Class ;
      private string edtavWwp_df_stepmetadata_description_Internalname ;
      private string divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Internalname ;
      private string divWwp_df_elementsrepeatermetadata_repetitionsdatatype_cell_Class ;
      private string cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Internalname ;
      private string cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype_Jsonclick ;
      private string divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Internalname ;
      private string divWwp_df_elementsrepeatermetadata_repetitionstype_cell_Class ;
      private string cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Internalname ;
      private string cmbavWwp_df_elementsrepeatermetadata_repetitionstype_Jsonclick ;
      private string divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Internalname ;
      private string divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_cell_Class ;
      private string edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Internalname ;
      private string edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildcaption_Jsonclick ;
      private string divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Internalname ;
      private string divWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_cell_Class ;
      private string chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel_Internalname ;
      private string divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Internalname ;
      private string divWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_cell_Class ;
      private string edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Internalname ;
      private string edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_removechildtooltip_Jsonclick ;
      private string divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Internalname ;
      private string divWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_cell_Class ;
      private string edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Internalname ;
      private string edtavWwp_df_elementsrepeatermetadata_repetitions_useradded_maxrepetitions_Jsonclick ;
      private string divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Internalname ;
      private string divWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_cell_Class ;
      private string edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Internalname ;
      private string edtavWwp_df_elementsrepeatermetadata_repetitions_fixedvalue_value_Jsonclick ;
      private string divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Internalname ;
      private string divWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_cell_Class ;
      private string cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Internalname ;
      private string cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid_Jsonclick ;
      private string divWwp_df_labelmetadata_style_cell_Internalname ;
      private string divWwp_df_labelmetadata_style_cell_Class ;
      private string cmbavWwp_df_labelmetadata_style_Internalname ;
      private string cmbavWwp_df_labelmetadata_style_Jsonclick ;
      private string lblTab2_title_Internalname ;
      private string lblTab2_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string divWwpformelementexcludefromexport_cell_Internalname ;
      private string divWwpformelementexcludefromexport_cell_Class ;
      private string chkavWwpformelementexcludefromexport_Internalname ;
      private string edtavVisiblecondition_Internalname ;
      private string lblVisibleconditionhelpicon_Internalname ;
      private string lblVisibleconditionhelpicon_Caption ;
      private string lblVisibleconditionhelpicon_Jsonclick ;
      private string Btntestvisiblecondition_Tooltiptext ;
      private string Btntestvisiblecondition_Beforeiconclass ;
      private string Btntestvisiblecondition_Caption ;
      private string Btntestvisiblecondition_Class ;
      private string Btntestvisiblecondition_Internalname ;
      private string Ucmentionsvisibility_Datalistproc ;
      private string Ucmentionsvisibility_Internalname ;
      private string lblTab3_title_Internalname ;
      private string lblTab3_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string divIsrequired_cell_Internalname ;
      private string divIsrequired_cell_Class ;
      private string chkavIsrequired_Internalname ;
      private string Btnaddvalidation_Tooltiptext ;
      private string Btnaddvalidation_Beforeiconclass ;
      private string Btnaddvalidation_Caption ;
      private string Btnaddvalidation_Class ;
      private string Btnaddvalidation_Internalname ;
      private string sStyleString ;
      private string subGridvalidations_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtnuacancel_Internalname ;
      private string bttBtnuacancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string cmbavWwpform_wwpformresume_Internalname ;
      private string cmbavWwpform_wwpformresume_Jsonclick ;
      private string cmbavWwp_df_containermetadata_style_Internalname ;
      private string cmbavWwp_df_containermetadata_style_Jsonclick ;
      private string edtavColumns_Internalname ;
      private string edtavColumns_Jsonclick ;
      private string Gridvalidations_empowerer_Internalname ;
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
      private string sGXsfl_270_fel_idx="0001" ;
      private string edtavWwpformelementreferenceid_Internalname ;
      private string Ucmentionsvisibility_Gamoauthtoken ;
      private string Ucmentionsvisibility_Datalistprocextrapartameters ;
      private string lblReferencieidhelpicon_Caption ;
      private string lblReferencieidhelpicon_Internalname ;
      private string Gridvalidations_empowerer_Gridinternalname ;
      private string cellWwpformelementreferenceid_cell_Class ;
      private string cellWwpformelementreferenceid_cell_Internalname ;
      private string GXt_char3 ;
      private string tblTableupdatevalidation_modal_Internalname ;
      private string Updatevalidation_modal_Width ;
      private string Updatevalidation_modal_Title ;
      private string Updatevalidation_modal_Confirmtype ;
      private string Updatevalidation_modal_Bodytype ;
      private string Updatevalidation_modal_Internalname ;
      private string tblTableaddvalidation_modal_Internalname ;
      private string Addvalidation_modal_Width ;
      private string Addvalidation_modal_Title ;
      private string Addvalidation_modal_Confirmtype ;
      private string Addvalidation_modal_Bodytype ;
      private string Addvalidation_modal_Internalname ;
      private string tblTablemergedwwpformelementreferenceid_Internalname ;
      private string edtavWwpformelementreferenceid_Jsonclick ;
      private string lblReferencieidhelpicon_Jsonclick ;
      private string sCtrlAV54WWPDynamicFormMode ;
      private string sCtrlAV61WWPFormElementParentId ;
      private string sCtrlAV60WWPFormElementId ;
      private string sCtrlAV33SessionId ;
      private string subGridvalidations_Class ;
      private string subGridvalidations_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string ROClassString ;
      private string edtavValidations__messagewithtags_Jsonclick ;
      private string edtavValidations__message_Jsonclick ;
      private string subGridvalidations_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14Date_IncludeTime ;
      private bool AV59WWPFormElementExcludeFromExport ;
      private bool AV24IsRequired ;
      private bool AV22IsFormSettings ;
      private bool AV28ParentIsGridMultipleData ;
      private bool bGXsfl_270_Refreshing=false ;
      private bool AV16ExecuteConditionToTest ;
      private bool AV7CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV270 ;
      private bool gx_refresh_fired ;
      private bool AV21IsFirstValidation ;
      private bool AV23IsLastValidation ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool Btnaddvalidation_Visible ;
      private bool AV25NeedToRefreshForm ;
      private string AV63WWPFormElementTitle ;
      private string AV29PredOptions_Options ;
      private string AV43VisibleCondition ;
      private string AV18FormType ;
      private string AV35Text_Format ;
      private string AV36TextArea_Format ;
      private string AV31PredOptions_Values ;
      private string AV17File_Format ;
      private string AV32Radio_Direction ;
      private string AV65WWPFormTitle ;
      private string AV38ValidationJson ;
      private string AV9ConditionError ;
      private string AV10Control ;
      private string AV30PredOptions_Type ;
      private string AV40Validations__MessageWithTags ;
      private string AV62WWPFormElementReferenceId ;
      private string AV41VarCharAux ;
      private string AV34Text ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridvalidationsContainer ;
      private GXWebRow GridvalidationsRow ;
      private GXWebColumn GridvalidationsColumn ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucBtntestvisiblecondition ;
      private GXUserControl ucUcmentionsvisibility ;
      private GXUserControl ucBtnaddvalidation ;
      private GXUserControl ucGridvalidations_empowerer ;
      private GXUserControl ucUpdatevalidation_modal ;
      private GXUserControl ucAddvalidation_modal ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXRadio radavFormtype ;
      private GXCombobox cmbavWwpformelementtype ;
      private GXCombobox cmbavWwpformelementcaption ;
      private GXCombobox cmbavControl ;
      private GXRadio radavText_format ;
      private GXRadio radavTextarea_format ;
      private GXCheckbox chkavDate_includetime ;
      private GXCheckbox chkavWwp_df_datemetadata_isdefaultvaluetoday ;
      private GXCheckbox chkavWwp_df_charmetadata_multipleoptions_allowmultipleselection ;
      private GXCombobox cmbavPredoptions_type ;
      private GXRadio radavPredoptions_values ;
      private GXCheckbox chkavWwp_df_charmetadata_multipleoptions_combobox_includeemptyvalue ;
      private GXCheckbox chkavWwp_df_containermetadata_collapsable ;
      private GXCheckbox chkavWwp_df_containermetadata_collapsedbydefault ;
      private GXRadio radavFile_format ;
      private GXRadio radavRadio_direction ;
      private GXCheckbox chkavWwp_df_booleanmetadata_defaultvalue ;
      private GXCombobox cmbavWwp_df_elementsrepeatermetadata_repetitionsdatatype ;
      private GXCombobox cmbavWwp_df_elementsrepeatermetadata_repetitionstype ;
      private GXCheckbox chkavWwp_df_elementsrepeatermetadata_repetitions_useradded_insertchildbutton_isalignedtolabel ;
      private GXCombobox cmbavWwp_df_elementsrepeatermetadata_repetitions_variable_elementid ;
      private GXCombobox cmbavWwp_df_labelmetadata_style ;
      private GXCheckbox chkavWwpformelementexcludefromexport ;
      private GXCheckbox chkavIsrequired ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXCombobox cmbavWwpform_wwpformresume ;
      private GXCombobox cmbavWwp_df_containermetadata_style ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV39Validations ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata AV48WWP_DF_DateMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV46WWP_DF_CharMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata AV47WWP_DF_ContainerMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata AV45WWP_DF_BooleanMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV49WWP_DF_ElementsRepeaterMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV55WWPForm ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata AV52WWP_DF_NumericMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata AV53WWP_DF_StepMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata AV51WWP_DF_LabelMetadata ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWPSuggestDataItem> AV5AllReferenceIds ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV44VisibleConditionExpression ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV66GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV67GAMErrors ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form1 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV27ParentElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV11CurrentElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata AV50WWP_DF_ImageMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV15ElementAux ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation AV12CurrentValidation ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation AV37Validation ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV56WWPFormElement ;
      private GxSimpleCollection<string> AV107GXV37 ;
      private GxSimpleCollection<string> AV42VarCharList ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV26OriginalElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element GXt_SdtWWP_Form_Element2 ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV6AuxWWP_DF_ElementsRepeaterMetadata ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
