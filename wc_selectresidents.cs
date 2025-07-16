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
   public class wc_selectresidents : GXWebComponent
   {
      public wc_selectresidents( )
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

      public wc_selectresidents( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ResidentPackageId ,
                           GXBaseCollection<SdtSDT_Resident> aP1_SDT_ResidentsOfGroup )
      {
         this.AV28ResidentPackageId = aP0_ResidentPackageId;
         this.AV42SDT_ResidentsOfGroup = aP1_SDT_ResidentsOfGroup;
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
         chkavSelectall = new GXCheckbox();
         chkavSdt_selectresidents__isselected = new GXCheckbox();
         cmbavSdt_selectresidents__residentsalutation = new GXCombobox();
         cmbavSdt_selectresidents__residentgender = new GXCombobox();
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
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV42SDT_ResidentsOfGroup);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)AV28ResidentPackageId,(GXBaseCollection<SdtSDT_Resident>)AV42SDT_ResidentsOfGroup});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grids") == 0 )
               {
                  gxnrGrids_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grids") == 0 )
               {
                  gxgrGrids_refresh_invoke( ) ;
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

      protected void gxnrGrids_newrow_invoke( )
      {
         nRC_GXsfl_38 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_38"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_38_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_38_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_38_idx = GetPar( "sGXsfl_38_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrids_newrow( ) ;
         /* End function gxnrGrids_newrow_invoke */
      }

      protected void gxgrGrids_refresh_invoke( )
      {
         subGrids_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrids_Rows"), "."), 18, MidpointRounding.ToEven));
         A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6WWPContext);
         AV12FilterFullText = GetPar( "FilterFullText");
         A62ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
         A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         A72ResidentSalutation = GetPar( "ResidentSalutation");
         n72ResidentSalutation = false;
         A63ResidentBsnNumber = GetPar( "ResidentBsnNumber");
         A64ResidentGivenName = GetPar( "ResidentGivenName");
         A65ResidentLastName = GetPar( "ResidentLastName");
         A66ResidentInitials = GetPar( "ResidentInitials");
         A67ResidentEmail = GetPar( "ResidentEmail");
         A68ResidentGender = GetPar( "ResidentGender");
         A70ResidentPhone = GetPar( "ResidentPhone");
         A97ResidentTypeName = GetPar( "ResidentTypeName");
         A98MedicalIndicationId = StringUtil.StrToGuid( GetPar( "MedicalIndicationId"));
         n98MedicalIndicationId = false;
         A99MedicalIndicationName = GetPar( "MedicalIndicationName");
         A73ResidentBirthDate = context.localUtil.ParseDateParm( GetPar( "ResidentBirthDate"));
         A96ResidentTypeId = StringUtil.StrToGuid( GetPar( "ResidentTypeId"));
         n96ResidentTypeId = false;
         A71ResidentGUID = GetPar( "ResidentGUID");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV34SelectedResidentIdCollection);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV37SDT_SelectResidents);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV43ExistingResidentIdCollection);
         AV45SelectAll = StringUtil.StrToBool( GetPar( "SelectAll"));
         AV41PopupTitle = GetPar( "PopupTitle");
         AV32ResidentsDefinitionTitle = GetPar( "ResidentsDefinitionTitle");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrids_refresh( subGrids_Rows, A29LocationId, AV6WWPContext, AV12FilterFullText, A62ResidentId, A11OrganisationId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV34SelectedResidentIdCollection, AV37SDT_SelectResidents, AV43ExistingResidentIdCollection, AV45SelectAll, AV41PopupTitle, AV32ResidentsDefinitionTitle, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrids_refresh_invoke */
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
            PABZ2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavSdt_selectresidents__residentid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residentid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residentid_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__locationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__locationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__locationid_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__organisationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__organisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__organisationid_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               cmbavSdt_selectresidents__residentsalutation.Enabled = 0;
               AssignProp(sPrefix, false, cmbavSdt_selectresidents__residentsalutation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdt_selectresidents__residentsalutation.Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residenttitle_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residenttitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residenttitle_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residentbsnnumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residentbsnnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residentbsnnumber_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residentgivenname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residentgivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residentgivenname_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residentlastname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residentlastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residentlastname_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residentinitials_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residentinitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residentinitials_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residentemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residentemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residentemail_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               cmbavSdt_selectresidents__residentgender.Enabled = 0;
               AssignProp(sPrefix, false, cmbavSdt_selectresidents__residentgender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdt_selectresidents__residentgender.Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residentaddress_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residentaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residentaddress_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residentphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residentphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residentphone_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residentbirthdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residentbirthdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residentbirthdate_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residentguid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residentguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residentguid_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residenttypeid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residenttypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residenttypeid_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residenttypename_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residenttypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residenttypename_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__medicalindicationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__medicalindicationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__medicalindicationid_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__medicalindicationname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__medicalindicationname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__medicalindicationname_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residentimage_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residentimage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residentimage_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtavSdt_selectresidents__residentlanguage_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_selectresidents__residentlanguage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_selectresidents__residentlanguage_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               WSBZ2( ) ;
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wc_selectresidents.aspx"+UrlEncode(AV28ResidentPackageId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wc_selectresidents.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV6WWPContext, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEXISTINGRESIDENTIDCOLLECTION", AV43ExistingResidentIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEXISTINGRESIDENTIDCOLLECTION", AV43ExistingResidentIdCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEXISTINGRESIDENTIDCOLLECTION", GetSecureSignedToken( sPrefix, AV43ExistingResidentIdCollection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPOPUPTITLE", AV41PopupTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPOPUPTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41PopupTitle, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTSDEFINITIONTITLE", AV32ResidentsDefinitionTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTSDEFINITIONTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32ResidentsDefinitionTitle, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdt_selectresidents", AV37SDT_SelectResidents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdt_selectresidents", AV37SDT_SelectResidents);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_38", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_38), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38GridsCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GridsPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSAPPLIEDFILTERS", AV40GridsAppliedFilters);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV28ResidentPackageId", wcpOAV28ResidentPackageId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"LOCATIONID", A29LocationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV6WWPContext, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTID", A62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTSALUTATION", StringUtil.RTrim( A72ResidentSalutation));
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTBSNNUMBER", A63ResidentBsnNumber);
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTGIVENNAME", A64ResidentGivenName);
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTLASTNAME", A65ResidentLastName);
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTINITIALS", StringUtil.RTrim( A66ResidentInitials));
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTEMAIL", A67ResidentEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTGENDER", A68ResidentGender);
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTPHONE", StringUtil.RTrim( A70ResidentPhone));
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTTYPENAME", A97ResidentTypeName);
         GxWebStd.gx_hidden_field( context, sPrefix+"MEDICALINDICATIONID", A98MedicalIndicationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"MEDICALINDICATIONNAME", A99MedicalIndicationName);
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTBIRTHDATE", context.localUtil.DToC( A73ResidentBirthDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTTYPEID", A96ResidentTypeId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"RESIDENTGUID", A71ResidentGUID);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSELECTEDRESIDENTIDCOLLECTION", AV34SelectedResidentIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSELECTEDRESIDENTIDCOLLECTION", AV34SelectedResidentIdCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_SELECTRESIDENTS", AV37SDT_SelectResidents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_SELECTRESIDENTS", AV37SDT_SelectResidents);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEXISTINGRESIDENTIDCOLLECTION", AV43ExistingResidentIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEXISTINGRESIDENTIDCOLLECTION", AV43ExistingResidentIdCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEXISTINGRESIDENTIDCOLLECTION", GetSecureSignedToken( sPrefix, AV43ExistingResidentIdCollection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPOPUPTITLE", AV41PopupTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPOPUPTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41PopupTitle, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTPACKAGEID", AV28ResidentPackageId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTSDEFINITIONTITLE", AV32ResidentsDefinitionTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTSDEFINITIONTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32ResidentsDefinitionTitle, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_RESIDENTSOFGROUP", AV42SDT_ResidentsOfGroup);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_RESIDENTSOFGROUP", AV42SDT_ResidentsOfGroup);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Class", StringUtil.RTrim( Gridspaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridspaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridspaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridspaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridspaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridspaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridspaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridspaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridspaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridspaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridspaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Previous", StringUtil.RTrim( Gridspaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Next", StringUtil.RTrim( Gridspaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Caption", StringUtil.RTrim( Gridspaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridspaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridspaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grids_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridspaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridspaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
      }

      protected void RenderHtmlCloseFormBZ2( )
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
         return "WC_SelectResidents" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Select Residents", "") ;
      }

      protected void WBBZ0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wc_selectresidents.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divLayoutmaintable1_Internalname, 1, 0, "px", 0, "px", "Table TableWithSelectableGrid", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "align-items:baseline;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSelectall_Internalname, context.GetMessage( "Select All", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'" + sGXsfl_38_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSelectall_Internalname, StringUtil.BoolToStr( AV45SelectAll), "", context.GetMessage( "Select All", ""), 1, chkavSelectall.Enabled, "true", context.GetMessage( " Select All", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(19, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,19);\"");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'" + sGXsfl_38_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV12FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WC_SelectResidents.htm");
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
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridstablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridsContainer.SetWrapped(nGXWrapped);
            StartGridControl38( ) ;
         }
         if ( wbEnd == 38 )
         {
            wbEnd = 0;
            nRC_GXsfl_38 = (int)(nGXsfl_38_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV46GXV1 = nGXsfl_38_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grids", GridsContainer, subGrids_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData", GridsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData"+"V", GridsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridspaginationbar.SetProperty("Class", Gridspaginationbar_Class);
            ucGridspaginationbar.SetProperty("ShowFirst", Gridspaginationbar_Showfirst);
            ucGridspaginationbar.SetProperty("ShowPrevious", Gridspaginationbar_Showprevious);
            ucGridspaginationbar.SetProperty("ShowNext", Gridspaginationbar_Shownext);
            ucGridspaginationbar.SetProperty("ShowLast", Gridspaginationbar_Showlast);
            ucGridspaginationbar.SetProperty("PagesToShow", Gridspaginationbar_Pagestoshow);
            ucGridspaginationbar.SetProperty("PagingButtonsPosition", Gridspaginationbar_Pagingbuttonsposition);
            ucGridspaginationbar.SetProperty("PagingCaptionPosition", Gridspaginationbar_Pagingcaptionposition);
            ucGridspaginationbar.SetProperty("EmptyGridClass", Gridspaginationbar_Emptygridclass);
            ucGridspaginationbar.SetProperty("RowsPerPageSelector", Gridspaginationbar_Rowsperpageselector);
            ucGridspaginationbar.SetProperty("RowsPerPageOptions", Gridspaginationbar_Rowsperpageoptions);
            ucGridspaginationbar.SetProperty("Previous", Gridspaginationbar_Previous);
            ucGridspaginationbar.SetProperty("Next", Gridspaginationbar_Next);
            ucGridspaginationbar.SetProperty("Caption", Gridspaginationbar_Caption);
            ucGridspaginationbar.SetProperty("EmptyGridCaption", Gridspaginationbar_Emptygridcaption);
            ucGridspaginationbar.SetProperty("RowsPerPageCaption", Gridspaginationbar_Rowsperpagecaption);
            ucGridspaginationbar.SetProperty("CurrentPage", AV38GridsCurrentPage);
            ucGridspaginationbar.SetProperty("PageCount", AV39GridsPageCount);
            ucGridspaginationbar.SetProperty("AppliedFilters", AV40GridsAppliedFilters);
            ucGridspaginationbar.Render(context, "dvelop.dvpaginationbar", Gridspaginationbar_Internalname, sPrefix+"GRIDSPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop10", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancelaction_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(38), 2, 0)+","+"null"+");", context.GetMessage( "Cancel", ""), bttBtncancelaction_Jsonclick, 7, context.GetMessage( "Cancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11bz1_client"+"'", TempTags, "", 2, "HLP_WC_SelectResidents.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(38), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WC_SelectResidents.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
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
            ucGrids_empowerer.Render(context, "wwp.gridempowerer", Grids_empowerer_Internalname, sPrefix+"GRIDS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 38 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV46GXV1 = nGXsfl_38_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grids", GridsContainer, subGrids_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData", GridsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData"+"V", GridsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTBZ2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Select Residents", ""), 0) ;
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
               STRUPBZ0( ) ;
            }
         }
      }

      protected void WSBZ2( )
      {
         STARTBZ2( ) ;
         EVTBZ2( ) ;
      }

      protected void EVTBZ2( )
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
                                 STRUPBZ0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBZ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridspaginationbar.Changepage */
                                    E12BZ2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBZ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridspaginationbar.Changerowsperpage */
                                    E13BZ2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBZ0( ) ;
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
                                          E14BZ2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERFULLTEXT.CONTROLVALUECHANGING") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBZ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E15BZ2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSELECTALL.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBZ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E16BZ2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBZ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavSelectall_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRIDS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBZ0( ) ;
                              }
                              nGXsfl_38_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
                              SubsflControlProps_382( ) ;
                              AV46GXV1 = (int)(nGXsfl_38_idx+GRIDS_nFirstRecordOnPage);
                              if ( ( AV37SDT_SelectResidents.Count >= AV46GXV1 ) && ( AV46GXV1 > 0 ) )
                              {
                                 AV37SDT_SelectResidents.CurrentItem = ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1));
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
                                          GX_FocusControl = chkavSelectall_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E17BZ2 ();
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
                                          GX_FocusControl = chkavSelectall_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E18BZ2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavSelectall_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grids.Load */
                                          E19BZ2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUPBZ0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavSelectall_Internalname;
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEBZ2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormBZ2( ) ;
            }
         }
      }

      protected void PABZ2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wc_selectresidents.aspx")), "wc_selectresidents.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wc_selectresidents.aspx")))) ;
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
               GX_FocusControl = chkavSelectall_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrids_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_382( ) ;
         while ( nGXsfl_38_idx <= nRC_GXsfl_38 )
         {
            sendrow_382( ) ;
            nGXsfl_38_idx = ((subGrids_Islastpage==1)&&(nGXsfl_38_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_382( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsContainer)) ;
         /* End function gxnrGrids_newrow */
      }

      protected void gxgrGrids_refresh( int subGrids_Rows ,
                                        Guid A29LocationId ,
                                        GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ,
                                        string AV12FilterFullText ,
                                        Guid A62ResidentId ,
                                        Guid A11OrganisationId ,
                                        string A72ResidentSalutation ,
                                        string A63ResidentBsnNumber ,
                                        string A64ResidentGivenName ,
                                        string A65ResidentLastName ,
                                        string A66ResidentInitials ,
                                        string A67ResidentEmail ,
                                        string A68ResidentGender ,
                                        string A70ResidentPhone ,
                                        string A97ResidentTypeName ,
                                        Guid A98MedicalIndicationId ,
                                        string A99MedicalIndicationName ,
                                        DateTime A73ResidentBirthDate ,
                                        Guid A96ResidentTypeId ,
                                        string A71ResidentGUID ,
                                        GxSimpleCollection<Guid> AV34SelectedResidentIdCollection ,
                                        GXBaseCollection<SdtSDT_SelectResident> AV37SDT_SelectResidents ,
                                        GxSimpleCollection<Guid> AV43ExistingResidentIdCollection ,
                                        bool AV45SelectAll ,
                                        string AV41PopupTitle ,
                                        string AV32ResidentsDefinitionTitle ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDS_nCurrentRecord = 0;
         RFBZ2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrids_refresh */
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
         AV45SelectAll = StringUtil.StrToBool( StringUtil.BoolToStr( AV45SelectAll));
         AssignAttri(sPrefix, false, "AV45SelectAll", AV45SelectAll);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFBZ2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdt_selectresidents__residentid_Enabled = 0;
         edtavSdt_selectresidents__locationid_Enabled = 0;
         edtavSdt_selectresidents__organisationid_Enabled = 0;
         cmbavSdt_selectresidents__residentsalutation.Enabled = 0;
         edtavSdt_selectresidents__residenttitle_Enabled = 0;
         edtavSdt_selectresidents__residentbsnnumber_Enabled = 0;
         edtavSdt_selectresidents__residentgivenname_Enabled = 0;
         edtavSdt_selectresidents__residentlastname_Enabled = 0;
         edtavSdt_selectresidents__residentinitials_Enabled = 0;
         edtavSdt_selectresidents__residentemail_Enabled = 0;
         cmbavSdt_selectresidents__residentgender.Enabled = 0;
         edtavSdt_selectresidents__residentaddress_Enabled = 0;
         edtavSdt_selectresidents__residentphone_Enabled = 0;
         edtavSdt_selectresidents__residentbirthdate_Enabled = 0;
         edtavSdt_selectresidents__residentguid_Enabled = 0;
         edtavSdt_selectresidents__residenttypeid_Enabled = 0;
         edtavSdt_selectresidents__residenttypename_Enabled = 0;
         edtavSdt_selectresidents__medicalindicationid_Enabled = 0;
         edtavSdt_selectresidents__medicalindicationname_Enabled = 0;
         edtavSdt_selectresidents__residentimage_Enabled = 0;
         edtavSdt_selectresidents__residentlanguage_Enabled = 0;
      }

      protected void RFBZ2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 38;
         /* Execute user event: Refresh */
         E18BZ2 ();
         nGXsfl_38_idx = 1;
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_382( ) ;
         bGXsfl_38_Refreshing = true;
         GridsContainer.AddObjectProperty("GridName", "Grids");
         GridsContainer.AddObjectProperty("CmpContext", sPrefix);
         GridsContainer.AddObjectProperty("InMasterPage", "false");
         GridsContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
         GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
         GridsContainer.PageSize = subGrids_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_382( ) ;
            /* Execute user event: Grids.Load */
            E19BZ2 ();
            if ( ( subGrids_Islastpage == 0 ) && ( GRIDS_nCurrentRecord > 0 ) && ( GRIDS_nGridOutOfScope == 0 ) && ( nGXsfl_38_idx == 1 ) )
            {
               GRIDS_nCurrentRecord = 0;
               GRIDS_nGridOutOfScope = 1;
               subgrids_firstpage( ) ;
               /* Execute user event: Grids.Load */
               E19BZ2 ();
            }
            wbEnd = 38;
            WBBZ0( ) ;
         }
         bGXsfl_38_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBZ2( )
      {
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEXISTINGRESIDENTIDCOLLECTION", AV43ExistingResidentIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEXISTINGRESIDENTIDCOLLECTION", AV43ExistingResidentIdCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEXISTINGRESIDENTIDCOLLECTION", GetSecureSignedToken( sPrefix, AV43ExistingResidentIdCollection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPOPUPTITLE", AV41PopupTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPOPUPTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41PopupTitle, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESIDENTSDEFINITIONTITLE", AV32ResidentsDefinitionTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTSDEFINITIONTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32ResidentsDefinitionTitle, "")), context));
      }

      protected int subGrids_fnc_Pagecount( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( ((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nRecordCount/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nRecordCount/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrids_fnc_Recordcount( )
      {
         return AV37SDT_SelectResidents.Count ;
      }

      protected int subGrids_fnc_Recordsperpage( )
      {
         if ( subGrids_Rows > 0 )
         {
            return subGrids_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrids_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nFirstRecordOnPage/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrids_firstpage( )
      {
         GRIDS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, A29LocationId, AV6WWPContext, AV12FilterFullText, A62ResidentId, A11OrganisationId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV34SelectedResidentIdCollection, AV37SDT_SelectResidents, AV43ExistingResidentIdCollection, AV45SelectAll, AV41PopupTitle, AV32ResidentsDefinitionTitle, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrids_nextpage( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( ( GRIDS_nRecordCount >= subGrids_fnc_Recordsperpage( ) ) && ( GRIDS_nEOF == 0 ) )
         {
            GRIDS_nFirstRecordOnPage = (long)(GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, A29LocationId, AV6WWPContext, AV12FilterFullText, A62ResidentId, A11OrganisationId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV34SelectedResidentIdCollection, AV37SDT_SelectResidents, AV43ExistingResidentIdCollection, AV45SelectAll, AV41PopupTitle, AV32ResidentsDefinitionTitle, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrids_previouspage( )
      {
         if ( GRIDS_nFirstRecordOnPage >= subGrids_fnc_Recordsperpage( ) )
         {
            GRIDS_nFirstRecordOnPage = (long)(GRIDS_nFirstRecordOnPage-subGrids_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, A29LocationId, AV6WWPContext, AV12FilterFullText, A62ResidentId, A11OrganisationId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV34SelectedResidentIdCollection, AV37SDT_SelectResidents, AV43ExistingResidentIdCollection, AV45SelectAll, AV41PopupTitle, AV32ResidentsDefinitionTitle, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrids_lastpage( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( GRIDS_nRecordCount > subGrids_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDS_nFirstRecordOnPage = (long)(GRIDS_nRecordCount-subGrids_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDS_nFirstRecordOnPage = (long)(GRIDS_nRecordCount-((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, A29LocationId, AV6WWPContext, AV12FilterFullText, A62ResidentId, A11OrganisationId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV34SelectedResidentIdCollection, AV37SDT_SelectResidents, AV43ExistingResidentIdCollection, AV45SelectAll, AV41PopupTitle, AV32ResidentsDefinitionTitle, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrids_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDS_nFirstRecordOnPage = (long)(subGrids_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, A29LocationId, AV6WWPContext, AV12FilterFullText, A62ResidentId, A11OrganisationId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV34SelectedResidentIdCollection, AV37SDT_SelectResidents, AV43ExistingResidentIdCollection, AV45SelectAll, AV41PopupTitle, AV32ResidentsDefinitionTitle, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavSdt_selectresidents__residentid_Enabled = 0;
         edtavSdt_selectresidents__locationid_Enabled = 0;
         edtavSdt_selectresidents__organisationid_Enabled = 0;
         cmbavSdt_selectresidents__residentsalutation.Enabled = 0;
         edtavSdt_selectresidents__residenttitle_Enabled = 0;
         edtavSdt_selectresidents__residentbsnnumber_Enabled = 0;
         edtavSdt_selectresidents__residentgivenname_Enabled = 0;
         edtavSdt_selectresidents__residentlastname_Enabled = 0;
         edtavSdt_selectresidents__residentinitials_Enabled = 0;
         edtavSdt_selectresidents__residentemail_Enabled = 0;
         cmbavSdt_selectresidents__residentgender.Enabled = 0;
         edtavSdt_selectresidents__residentaddress_Enabled = 0;
         edtavSdt_selectresidents__residentphone_Enabled = 0;
         edtavSdt_selectresidents__residentbirthdate_Enabled = 0;
         edtavSdt_selectresidents__residentguid_Enabled = 0;
         edtavSdt_selectresidents__residenttypeid_Enabled = 0;
         edtavSdt_selectresidents__residenttypename_Enabled = 0;
         edtavSdt_selectresidents__medicalindicationid_Enabled = 0;
         edtavSdt_selectresidents__medicalindicationname_Enabled = 0;
         edtavSdt_selectresidents__residentimage_Enabled = 0;
         edtavSdt_selectresidents__residentlanguage_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBZ0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17BZ2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdt_selectresidents"), AV37SDT_SelectResidents);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDT_SELECTRESIDENTS"), AV37SDT_SelectResidents);
            /* Read saved values. */
            nRC_GXsfl_38 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_38"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV38GridsCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV39GridsPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV40GridsAppliedFilters = cgiGet( sPrefix+"vGRIDSAPPLIEDFILTERS");
            wcpOAV28ResidentPackageId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV28ResidentPackageId"));
            AV41PopupTitle = cgiGet( sPrefix+"vPOPUPTITLE");
            GRIDS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrids_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
            Gridspaginationbar_Class = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Class");
            Gridspaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Showfirst"));
            Gridspaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Showprevious"));
            Gridspaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Shownext"));
            Gridspaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Showlast"));
            Gridspaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridspaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Pagingbuttonsposition");
            Gridspaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Pagingcaptionposition");
            Gridspaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Emptygridclass");
            Gridspaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselector"));
            Gridspaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridspaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageoptions");
            Gridspaginationbar_Previous = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Previous");
            Gridspaginationbar_Next = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Next");
            Gridspaginationbar_Caption = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Caption");
            Gridspaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Emptygridcaption");
            Gridspaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpagecaption");
            Grids_empowerer_Gridinternalname = cgiGet( sPrefix+"GRIDS_EMPOWERER_Gridinternalname");
            Gridspaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Selectedpage");
            Gridspaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_38 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_38"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_38_fel_idx = 0;
            while ( nGXsfl_38_fel_idx < nRC_GXsfl_38 )
            {
               nGXsfl_38_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_38_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_38_fel_idx+1);
               sGXsfl_38_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_382( ) ;
               AV46GXV1 = (int)(nGXsfl_38_fel_idx+GRIDS_nFirstRecordOnPage);
               if ( ( AV37SDT_SelectResidents.Count >= AV46GXV1 ) && ( AV46GXV1 > 0 ) )
               {
                  AV37SDT_SelectResidents.CurrentItem = ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1));
               }
            }
            if ( nGXsfl_38_fel_idx == 0 )
            {
               nGXsfl_38_idx = 1;
               sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
               SubsflControlProps_382( ) ;
            }
            nGXsfl_38_fel_idx = 1;
            /* Read variables values. */
            AV45SelectAll = StringUtil.StrToBool( cgiGet( chkavSelectall_Internalname));
            AssignAttri(sPrefix, false, "AV45SelectAll", AV45SelectAll);
            AV12FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV12FilterFullText", AV12FilterFullText);
            /* Read subfile selected row values. */
            nGXsfl_38_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrids_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_382( ) ;
            AV46GXV1 = (int)(nGXsfl_38_idx+GRIDS_nFirstRecordOnPage);
            if ( nGXsfl_38_idx > 0 )
            {
               AV46GXV1 = (int)(nGXsfl_38_idx+GRIDS_nFirstRecordOnPage);
               if ( ( AV37SDT_SelectResidents.Count >= AV46GXV1 ) && ( AV46GXV1 > 0 ) )
               {
                  AV37SDT_SelectResidents.CurrentItem = ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1));
               }
               if ( ( AV46GXV1 > 0 ) && ( AV37SDT_SelectResidents.Count >= AV46GXV1 ) )
               {
                  AV37SDT_SelectResidents.CurrentItem = ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1));
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
         E17BZ2 ();
         if (returnInSub) return;
      }

      protected void E17BZ2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S112 ();
         if (returnInSub) return;
         Grids_empowerer_Gridinternalname = subGrids_Internalname;
         ucGrids_empowerer.SendProperty(context, sPrefix, false, Grids_empowerer_Internalname, "GridInternalName", Grids_empowerer_Gridinternalname);
         subGrids_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         Gridspaginationbar_Rowsperpageselectedvalue = subGrids_Rows;
         ucGridspaginationbar.SendProperty(context, sPrefix, false, Gridspaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridspaginationbar_Rowsperpageselectedvalue), 9, 0));
         GXt_char1 = AV32ResidentsDefinitionTitle;
         new prc_getorganisationdefinition(context ).execute(  "Residents", out  GXt_char1) ;
         AV32ResidentsDefinitionTitle = GXt_char1;
         AssignAttri(sPrefix, false, "AV32ResidentsDefinitionTitle", AV32ResidentsDefinitionTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTSDEFINITIONTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32ResidentsDefinitionTitle, "")), context));
         AV41PopupTitle = context.GetMessage( "Select ", "") + AV32ResidentsDefinitionTitle;
         AssignAttri(sPrefix, false, "AV41PopupTitle", AV41PopupTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPOPUPTITLE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41PopupTitle, "")), context));
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_UpdateTitle", new Object[] {(string)AV41PopupTitle}, false);
         Form.Caption = AV41PopupTitle;
         AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
         AV34SelectedResidentIdCollection = (GxSimpleCollection<Guid>)(new GxSimpleCollection<Guid>());
         /* Execute user subroutine: 'GETALREADYEXISITINGRESIDENTSOFGROUP' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E18BZ2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S112 ();
         if (returnInSub) return;
         AV38GridsCurrentPage = subGrids_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV38GridsCurrentPage", StringUtil.LTrimStr( (decimal)(AV38GridsCurrentPage), 10, 0));
         AV39GridsPageCount = subGrids_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV39GridsPageCount", StringUtil.LTrimStr( (decimal)(AV39GridsPageCount), 10, 0));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV37SDT_SelectResidents", AV37SDT_SelectResidents);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34SelectedResidentIdCollection", AV34SelectedResidentIdCollection);
      }

      private void E19BZ2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV37SDT_SelectResidents.Count )
         {
            AV37SDT_SelectResidents.CurrentItem = ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1));
            if ( (AV43ExistingResidentIdCollection.IndexOf(((SdtSDT_SelectResident)(AV37SDT_SelectResidents.CurrentItem)).gxTpr_Residentid)>0) )
            {
               chkavSdt_selectresidents__isselected.Enabled = 0;
               chkavSdt_selectresidents__isselected_Class = "ActionDisabledCursor";
            }
            else
            {
               chkavSdt_selectresidents__isselected.Enabled = 1;
               chkavSdt_selectresidents__isselected_Class = "";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 38;
            }
            if ( ( subGrids_Islastpage == 1 ) || ( subGrids_Rows == 0 ) || ( ( GRIDS_nCurrentRecord >= GRIDS_nFirstRecordOnPage ) && ( GRIDS_nCurrentRecord < GRIDS_nFirstRecordOnPage + subGrids_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_382( ) ;
            }
            GRIDS_nEOF = (short)(((GRIDS_nCurrentRecord<GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
            GRIDS_nCurrentRecord = (long)(GRIDS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_38_Refreshing )
            {
               DoAjaxLoad(38, GridsRow);
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E12BZ2( )
      {
         /* Gridspaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridspaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrids_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridspaginationbar_Selectedpage, "Next") == 0 )
         {
            AV23PageToGo = subGrids_fnc_Currentpage( );
            AV23PageToGo = (int)(AV23PageToGo+1);
            subgrids_gotopage( AV23PageToGo) ;
         }
         else
         {
            AV23PageToGo = (int)(Math.Round(NumberUtil.Val( Gridspaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrids_gotopage( AV23PageToGo) ;
         }
      }

      protected void E13BZ2( )
      {
         /* Gridspaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrids_Rows = Gridspaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         subgrids_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E14BZ2 ();
         if (returnInSub) return;
      }

      protected void E14BZ2( )
      {
         AV46GXV1 = (int)(nGXsfl_38_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV46GXV1 > 0 ) && ( AV37SDT_SelectResidents.Count >= AV46GXV1 ) )
         {
            AV37SDT_SelectResidents.CurrentItem = ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETSELECTEDRESIDENTS' */
         S132 ();
         if (returnInSub) return;
         if ( AV34SelectedResidentIdCollection.Count > 0 )
         {
            new prc_addresidentstopackagegroup(context ).execute(  AV28ResidentPackageId,  AV34SelectedResidentIdCollection) ;
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV32ResidentsDefinitionTitle+context.GetMessage( " added successfully", ""),  "success",  "",  "true",  ""));
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_Close", new Object[] {(string)AV41PopupTitle}, false);
         }
         else
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "No ", "")+AV32ResidentsDefinitionTitle+context.GetMessage( " have been selected", ""),  "error",  "",  "true",  ""));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34SelectedResidentIdCollection", AV34SelectedResidentIdCollection);
      }

      protected void E15BZ2( )
      {
         AV46GXV1 = (int)(nGXsfl_38_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV46GXV1 > 0 ) && ( AV37SDT_SelectResidents.Count >= AV46GXV1 ) )
         {
            AV37SDT_SelectResidents.CurrentItem = ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1));
         }
         /* Filterfulltext_Controlvaluechanging Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETSELECTEDRESIDENTS' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34SelectedResidentIdCollection", AV34SelectedResidentIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV37SDT_SelectResidents", AV37SDT_SelectResidents);
         nGXsfl_38_bak_idx = nGXsfl_38_idx;
         gxgrGrids_refresh( subGrids_Rows, A29LocationId, AV6WWPContext, AV12FilterFullText, A62ResidentId, A11OrganisationId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV34SelectedResidentIdCollection, AV37SDT_SelectResidents, AV43ExistingResidentIdCollection, AV45SelectAll, AV41PopupTitle, AV32ResidentsDefinitionTitle, sPrefix) ;
         nGXsfl_38_idx = nGXsfl_38_bak_idx;
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_382( ) ;
      }

      protected void E16BZ2( )
      {
         AV46GXV1 = (int)(nGXsfl_38_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV46GXV1 > 0 ) && ( AV37SDT_SelectResidents.Count >= AV46GXV1 ) )
         {
            AV37SDT_SelectResidents.CurrentItem = ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1));
         }
         /* Selectall_Controlvaluechanged Routine */
         returnInSub = false;
         AV34SelectedResidentIdCollection.Clear();
         if ( AV45SelectAll )
         {
            AV69GXV24 = 1;
            while ( AV69GXV24 <= AV37SDT_SelectResidents.Count )
            {
               AV35SDT_Resident = ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV69GXV24));
               if ( ! (AV43ExistingResidentIdCollection.IndexOf(AV35SDT_Resident.gxTpr_Residentid)>0) )
               {
                  AV34SelectedResidentIdCollection.Add(AV35SDT_Resident.gxTpr_Residentid, 0);
               }
               AV69GXV24 = (int)(AV69GXV24+1);
            }
         }
         else
         {
            AV34SelectedResidentIdCollection.Clear();
         }
         gxgrGrids_refresh( subGrids_Rows, A29LocationId, AV6WWPContext, AV12FilterFullText, A62ResidentId, A11OrganisationId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV34SelectedResidentIdCollection, AV37SDT_SelectResidents, AV43ExistingResidentIdCollection, AV45SelectAll, AV41PopupTitle, AV32ResidentsDefinitionTitle, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34SelectedResidentIdCollection", AV34SelectedResidentIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV37SDT_SelectResidents", AV37SDT_SelectResidents);
         nGXsfl_38_bak_idx = nGXsfl_38_idx;
         gxgrGrids_refresh( subGrids_Rows, A29LocationId, AV6WWPContext, AV12FilterFullText, A62ResidentId, A11OrganisationId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID, AV34SelectedResidentIdCollection, AV37SDT_SelectResidents, AV43ExistingResidentIdCollection, AV45SelectAll, AV41PopupTitle, AV32ResidentsDefinitionTitle, sPrefix) ;
         nGXsfl_38_idx = nGXsfl_38_bak_idx;
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_382( ) ;
      }

      protected void S112( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
         AV37SDT_SelectResidents = new GXBaseCollection<SdtSDT_SelectResident>( context, "SDT_SelectResident", "Comforta_version2");
         gx_BV38 = true;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV12FilterFullText ,
                                              AV6WWPContext.gxTpr_Locationid ,
                                              A29LocationId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor H00BZ2 */
         pr_default.execute(0, new Object[] {AV6WWPContext.gxTpr_Locationid, AV12FilterFullText, AV12FilterFullText});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A64ResidentGivenName = H00BZ2_A64ResidentGivenName[0];
            A65ResidentLastName = H00BZ2_A65ResidentLastName[0];
            A29LocationId = H00BZ2_A29LocationId[0];
            A62ResidentId = H00BZ2_A62ResidentId[0];
            A11OrganisationId = H00BZ2_A11OrganisationId[0];
            A72ResidentSalutation = H00BZ2_A72ResidentSalutation[0];
            n72ResidentSalutation = H00BZ2_n72ResidentSalutation[0];
            A63ResidentBsnNumber = H00BZ2_A63ResidentBsnNumber[0];
            A66ResidentInitials = H00BZ2_A66ResidentInitials[0];
            A67ResidentEmail = H00BZ2_A67ResidentEmail[0];
            A68ResidentGender = H00BZ2_A68ResidentGender[0];
            A70ResidentPhone = H00BZ2_A70ResidentPhone[0];
            A97ResidentTypeName = H00BZ2_A97ResidentTypeName[0];
            A98MedicalIndicationId = H00BZ2_A98MedicalIndicationId[0];
            n98MedicalIndicationId = H00BZ2_n98MedicalIndicationId[0];
            A99MedicalIndicationName = H00BZ2_A99MedicalIndicationName[0];
            A73ResidentBirthDate = H00BZ2_A73ResidentBirthDate[0];
            A96ResidentTypeId = H00BZ2_A96ResidentTypeId[0];
            n96ResidentTypeId = H00BZ2_n96ResidentTypeId[0];
            A71ResidentGUID = H00BZ2_A71ResidentGUID[0];
            A99MedicalIndicationName = H00BZ2_A99MedicalIndicationName[0];
            A97ResidentTypeName = H00BZ2_A97ResidentTypeName[0];
            AV35SDT_Resident = new SdtSDT_SelectResident(context);
            AV35SDT_Resident.gxTpr_Residentid = A62ResidentId;
            AV35SDT_Resident.gxTpr_Locationid = A29LocationId;
            AV35SDT_Resident.gxTpr_Organisationid = A11OrganisationId;
            AV35SDT_Resident.gxTpr_Residentsalutation = A72ResidentSalutation;
            AV35SDT_Resident.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
            AV35SDT_Resident.gxTpr_Residentgivenname = A64ResidentGivenName;
            AV35SDT_Resident.gxTpr_Residentlastname = A65ResidentLastName;
            AV35SDT_Resident.gxTpr_Residentinitials = A66ResidentInitials;
            AV35SDT_Resident.gxTpr_Residentemail = A67ResidentEmail;
            AV35SDT_Resident.gxTpr_Residentgender = A68ResidentGender;
            AV35SDT_Resident.gxTpr_Residentphone = A70ResidentPhone;
            AV35SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
            AV35SDT_Resident.gxTpr_Medicalindicationid = A98MedicalIndicationId;
            AV35SDT_Resident.gxTpr_Medicalindicationname = A99MedicalIndicationName;
            AV35SDT_Resident.gxTpr_Residentbirthdate = A73ResidentBirthDate;
            AV35SDT_Resident.gxTpr_Residenttypeid = A96ResidentTypeId;
            AV35SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
            AV35SDT_Resident.gxTpr_Residentguid = A71ResidentGUID;
            if ( (AV34SelectedResidentIdCollection.IndexOf(A62ResidentId)>0) )
            {
               AV35SDT_Resident.gxTpr_Isselected = true;
            }
            else
            {
               AV35SDT_Resident.gxTpr_Isselected = false;
            }
            AV37SDT_SelectResidents.Add(AV35SDT_Resident, 0);
            gx_BV38 = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV34SelectedResidentIdCollection.Clear();
      }

      protected void S132( )
      {
         /* 'GETSELECTEDRESIDENTS' Routine */
         returnInSub = false;
         AV71GXV25 = 1;
         while ( AV71GXV25 <= AV37SDT_SelectResidents.Count )
         {
            AV35SDT_Resident = ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV71GXV25));
            if ( AV35SDT_Resident.gxTpr_Isselected )
            {
               AV34SelectedResidentIdCollection.Add(AV35SDT_Resident.gxTpr_Residentid, 0);
            }
            AV71GXV25 = (int)(AV71GXV25+1);
         }
      }

      protected void S122( )
      {
         /* 'GETALREADYEXISITINGRESIDENTSOFGROUP' Routine */
         returnInSub = false;
         AV72GXV26 = 1;
         while ( AV72GXV26 <= AV42SDT_ResidentsOfGroup.Count )
         {
            AV44SDT_ResidentOfGroup = ((SdtSDT_Resident)AV42SDT_ResidentsOfGroup.Item(AV72GXV26));
            AV43ExistingResidentIdCollection.Add(AV44SDT_ResidentOfGroup.gxTpr_Residentid, 0);
            AV72GXV26 = (int)(AV72GXV26+1);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV28ResidentPackageId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV28ResidentPackageId", AV28ResidentPackageId.ToString());
         AV42SDT_ResidentsOfGroup = (GXBaseCollection<SdtSDT_Resident>)getParm(obj,1);
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
         PABZ2( ) ;
         WSBZ2( ) ;
         WEBZ2( ) ;
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
         sCtrlAV42SDT_ResidentsOfGroup = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PABZ2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wc_selectresidents", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PABZ2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV28ResidentPackageId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV28ResidentPackageId", AV28ResidentPackageId.ToString());
            AV42SDT_ResidentsOfGroup = (GXBaseCollection<SdtSDT_Resident>)getParm(obj,3);
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
         sCtrlAV42SDT_ResidentsOfGroup = cgiGet( sPrefix+"AV42SDT_ResidentsOfGroup_CTRL");
         if ( StringUtil.Len( sCtrlAV42SDT_ResidentsOfGroup) > 0 )
         {
            AV42SDT_ResidentsOfGroup = new GXBaseCollection<SdtSDT_Resident>();
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV42SDT_ResidentsOfGroup_PARM"), AV42SDT_ResidentsOfGroup);
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
         PABZ2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSBZ2( ) ;
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
         WSBZ2( ) ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV42SDT_ResidentsOfGroup_PARM", AV42SDT_ResidentsOfGroup);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV42SDT_ResidentsOfGroup_PARM", AV42SDT_ResidentsOfGroup);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV42SDT_ResidentsOfGroup)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV42SDT_ResidentsOfGroup_CTRL", StringUtil.RTrim( sCtrlAV42SDT_ResidentsOfGroup));
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
         WEBZ2( ) ;
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
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202571617542158", true, true);
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
         context.AddJavascriptSource("wc_selectresidents.js", "?202571617542159", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_382( )
      {
         chkavSdt_selectresidents__isselected_Internalname = sPrefix+"SDT_SELECTRESIDENTS__ISSELECTED_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residentid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTID_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__locationid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__LOCATIONID_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__organisationid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__ORGANISATIONID_"+sGXsfl_38_idx;
         cmbavSdt_selectresidents__residentsalutation_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTSALUTATION_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residenttitle_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTTITLE_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residentbsnnumber_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTBSNNUMBER_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residentgivenname_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTGIVENNAME_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residentlastname_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTLASTNAME_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residentinitials_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTINITIALS_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residentemail_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTEMAIL_"+sGXsfl_38_idx;
         cmbavSdt_selectresidents__residentgender_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTGENDER_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residentaddress_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTADDRESS_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residentphone_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTPHONE_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residentbirthdate_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTBIRTHDATE_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residentguid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTGUID_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residenttypeid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTTYPEID_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residenttypename_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTTYPENAME_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__medicalindicationid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__MEDICALINDICATIONID_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__medicalindicationname_Internalname = sPrefix+"SDT_SELECTRESIDENTS__MEDICALINDICATIONNAME_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residentimage_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTIMAGE_"+sGXsfl_38_idx;
         edtavSdt_selectresidents__residentlanguage_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTLANGUAGE_"+sGXsfl_38_idx;
      }

      protected void SubsflControlProps_fel_382( )
      {
         chkavSdt_selectresidents__isselected_Internalname = sPrefix+"SDT_SELECTRESIDENTS__ISSELECTED_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residentid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTID_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__locationid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__LOCATIONID_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__organisationid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__ORGANISATIONID_"+sGXsfl_38_fel_idx;
         cmbavSdt_selectresidents__residentsalutation_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTSALUTATION_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residenttitle_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTTITLE_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residentbsnnumber_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTBSNNUMBER_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residentgivenname_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTGIVENNAME_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residentlastname_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTLASTNAME_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residentinitials_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTINITIALS_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residentemail_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTEMAIL_"+sGXsfl_38_fel_idx;
         cmbavSdt_selectresidents__residentgender_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTGENDER_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residentaddress_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTADDRESS_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residentphone_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTPHONE_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residentbirthdate_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTBIRTHDATE_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residentguid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTGUID_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residenttypeid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTTYPEID_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residenttypename_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTTYPENAME_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__medicalindicationid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__MEDICALINDICATIONID_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__medicalindicationname_Internalname = sPrefix+"SDT_SELECTRESIDENTS__MEDICALINDICATIONNAME_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residentimage_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTIMAGE_"+sGXsfl_38_fel_idx;
         edtavSdt_selectresidents__residentlanguage_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTLANGUAGE_"+sGXsfl_38_fel_idx;
      }

      protected void sendrow_382( )
      {
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_382( ) ;
         WBBZ0( ) ;
         if ( ( subGrids_Rows * 1 == 0 ) || ( nGXsfl_38_idx <= subGrids_fnc_Recordsperpage( ) * 1 ) )
         {
            GridsRow = GXWebRow.GetNew(context,GridsContainer);
            if ( subGrids_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrids_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Odd";
               }
            }
            else if ( subGrids_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrids_Backstyle = 0;
               subGrids_Backcolor = subGrids_Allbackcolor;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Uniform";
               }
            }
            else if ( subGrids_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrids_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Odd";
               }
               subGrids_Backcolor = (int)(0x0);
            }
            else if ( subGrids_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrids_Backstyle = 1;
               if ( ((int)((nGXsfl_38_idx) % (2))) == 0 )
               {
                  subGrids_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Even";
                  }
               }
               else
               {
                  subGrids_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Odd";
                  }
               }
            }
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWithSelection WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_38_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_38_idx + "',38)\"";
            ClassString = chkavSdt_selectresidents__isselected_Class;
            StyleString = "";
            GXCCtl = "SDT_SELECTRESIDENTS__ISSELECTED_" + sGXsfl_38_idx;
            chkavSdt_selectresidents__isselected.Name = GXCCtl;
            chkavSdt_selectresidents__isselected.WebTags = "";
            chkavSdt_selectresidents__isselected.Caption = "";
            AssignProp(sPrefix, false, chkavSdt_selectresidents__isselected_Internalname, "TitleCaption", chkavSdt_selectresidents__isselected.Caption, !bGXsfl_38_Refreshing);
            chkavSdt_selectresidents__isselected.CheckedValue = "false";
            GridsRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavSdt_selectresidents__isselected_Internalname,StringUtil.BoolToStr( ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Isselected),(string)"",(string)"",(short)-1,chkavSdt_selectresidents__isselected.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(39, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,39);\""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residentid_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentid.ToString(),((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residentid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__residentid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)38,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__locationid_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Locationid.ToString(),((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Locationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__locationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__locationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)38,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__organisationid_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Organisationid.ToString(),((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Organisationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__organisationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__organisationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)38,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbavSdt_selectresidents__residentsalutation.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_SELECTRESIDENTS__RESIDENTSALUTATION_" + sGXsfl_38_idx;
               cmbavSdt_selectresidents__residentsalutation.Name = GXCCtl;
               cmbavSdt_selectresidents__residentsalutation.WebTags = "";
               cmbavSdt_selectresidents__residentsalutation.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
               cmbavSdt_selectresidents__residentsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
               cmbavSdt_selectresidents__residentsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
               cmbavSdt_selectresidents__residentsalutation.addItem("Ms", context.GetMessage( "Ms", ""), 0);
               cmbavSdt_selectresidents__residentsalutation.addItem("Other", context.GetMessage( "Other", ""), 0);
               if ( cmbavSdt_selectresidents__residentsalutation.ItemCount > 0 )
               {
                  if ( ( AV46GXV1 > 0 ) && ( AV37SDT_SelectResidents.Count >= AV46GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentsalutation)) )
                  {
                     ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentsalutation = cmbavSdt_selectresidents__residentsalutation.getValidValue(((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentsalutation);
                  }
               }
            }
            /* ComboBox */
            GridsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_selectresidents__residentsalutation,(string)cmbavSdt_selectresidents__residentsalutation_Internalname,StringUtil.RTrim( ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentsalutation),(short)1,(string)cmbavSdt_selectresidents__residentsalutation_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,cmbavSdt_selectresidents__residentsalutation.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            cmbavSdt_selectresidents__residentsalutation.CurrentValue = StringUtil.RTrim( ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentsalutation);
            AssignProp(sPrefix, false, cmbavSdt_selectresidents__residentsalutation_Internalname, "Values", (string)(cmbavSdt_selectresidents__residentsalutation.ToJavascriptSource()), !bGXsfl_38_Refreshing);
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residenttitle_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residenttitle,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residenttitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__residenttitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residentbsnnumber_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentbsnnumber,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residentbsnnumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__residentbsnnumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residentgivenname_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentgivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residentgivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_selectresidents__residentgivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residentlastname_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentlastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residentlastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_selectresidents__residentlastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residentinitials_Internalname,StringUtil.RTrim( ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentinitials),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residentinitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__residentinitials_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residentemail_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residentemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_selectresidents__residentemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'" + sGXsfl_38_idx + "',38)\"";
            if ( ( cmbavSdt_selectresidents__residentgender.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_SELECTRESIDENTS__RESIDENTGENDER_" + sGXsfl_38_idx;
               cmbavSdt_selectresidents__residentgender.Name = GXCCtl;
               cmbavSdt_selectresidents__residentgender.WebTags = "";
               cmbavSdt_selectresidents__residentgender.addItem("Male", context.GetMessage( "Male", ""), 0);
               cmbavSdt_selectresidents__residentgender.addItem("Female", context.GetMessage( "Female", ""), 0);
               cmbavSdt_selectresidents__residentgender.addItem("Other", context.GetMessage( "Other", ""), 0);
               if ( cmbavSdt_selectresidents__residentgender.ItemCount > 0 )
               {
                  if ( ( AV46GXV1 > 0 ) && ( AV37SDT_SelectResidents.Count >= AV46GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentgender)) )
                  {
                     ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentgender = cmbavSdt_selectresidents__residentgender.getValidValue(((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentgender);
                  }
               }
            }
            /* ComboBox */
            GridsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_selectresidents__residentgender,(string)cmbavSdt_selectresidents__residentgender_Internalname,StringUtil.RTrim( ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentgender),(short)1,(string)cmbavSdt_selectresidents__residentgender_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavSdt_selectresidents__residentgender.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"",(bool)true,(short)0});
            cmbavSdt_selectresidents__residentgender.CurrentValue = StringUtil.RTrim( ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentgender);
            AssignProp(sPrefix, false, cmbavSdt_selectresidents__residentgender_Internalname, "Values", (string)(cmbavSdt_selectresidents__residentgender.ToJavascriptSource()), !bGXsfl_38_Refreshing);
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residentaddress_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentaddress,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residentaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__residentaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residentphone_Internalname,StringUtil.RTrim( ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentphone),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residentphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__residentphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residentbirthdate_Internalname,context.localUtil.Format(((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentbirthdate, "99/99/9999"),context.localUtil.Format( ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentbirthdate, "99/99/9999"),""+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residentbirthdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__residentbirthdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residentguid_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentguid,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residentguid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__residentguid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)38,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residenttypeid_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residenttypeid.ToString(),((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residenttypeid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residenttypeid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__residenttypeid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)38,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residenttypename_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residenttypename,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residenttypename_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__residenttypename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__medicalindicationid_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Medicalindicationid.ToString(),((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Medicalindicationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__medicalindicationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__medicalindicationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)38,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__medicalindicationname_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Medicalindicationname,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__medicalindicationname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__medicalindicationname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residentimage_Internalname,((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentimage,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residentimage_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__residentimage_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_selectresidents__residentlanguage_Internalname,StringUtil.RTrim( ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentlanguage),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_selectresidents__residentlanguage_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_selectresidents__residentlanguage_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesBZ2( ) ;
            GridsContainer.AddRow(GridsRow);
            nGXsfl_38_idx = ((subGrids_Islastpage==1)&&(nGXsfl_38_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_382( ) ;
         }
         /* End function sendrow_382 */
      }

      protected void init_web_controls( )
      {
         chkavSelectall.Name = "vSELECTALL";
         chkavSelectall.WebTags = "";
         chkavSelectall.Caption = context.GetMessage( "Select All", "");
         AssignProp(sPrefix, false, chkavSelectall_Internalname, "TitleCaption", chkavSelectall.Caption, true);
         chkavSelectall.CheckedValue = "false";
         GXCCtl = "SDT_SELECTRESIDENTS__ISSELECTED_" + sGXsfl_38_idx;
         chkavSdt_selectresidents__isselected.Name = GXCCtl;
         chkavSdt_selectresidents__isselected.WebTags = "";
         chkavSdt_selectresidents__isselected.Caption = "";
         AssignProp(sPrefix, false, chkavSdt_selectresidents__isselected_Internalname, "TitleCaption", chkavSdt_selectresidents__isselected.Caption, !bGXsfl_38_Refreshing);
         chkavSdt_selectresidents__isselected.CheckedValue = "false";
         GXCCtl = "SDT_SELECTRESIDENTS__RESIDENTSALUTATION_" + sGXsfl_38_idx;
         cmbavSdt_selectresidents__residentsalutation.Name = GXCCtl;
         cmbavSdt_selectresidents__residentsalutation.WebTags = "";
         cmbavSdt_selectresidents__residentsalutation.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavSdt_selectresidents__residentsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbavSdt_selectresidents__residentsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbavSdt_selectresidents__residentsalutation.addItem("Ms", context.GetMessage( "Ms", ""), 0);
         cmbavSdt_selectresidents__residentsalutation.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavSdt_selectresidents__residentsalutation.ItemCount > 0 )
         {
            if ( ( AV46GXV1 > 0 ) && ( AV37SDT_SelectResidents.Count >= AV46GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentsalutation)) )
            {
            }
         }
         GXCCtl = "SDT_SELECTRESIDENTS__RESIDENTGENDER_" + sGXsfl_38_idx;
         cmbavSdt_selectresidents__residentgender.Name = GXCCtl;
         cmbavSdt_selectresidents__residentgender.WebTags = "";
         cmbavSdt_selectresidents__residentgender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavSdt_selectresidents__residentgender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavSdt_selectresidents__residentgender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavSdt_selectresidents__residentgender.ItemCount > 0 )
         {
            if ( ( AV46GXV1 > 0 ) && ( AV37SDT_SelectResidents.Count >= AV46GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_SelectResident)AV37SDT_SelectResidents.Item(AV46GXV1)).gxTpr_Residentgender)) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl38( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"DivS\" data-gxgridid=\"38\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrids_Internalname, subGrids_Internalname, "", "GridWithPaginationBar WorkWithSelection WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrids_Backcolorstyle == 0 )
            {
               subGrids_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrids_Class) > 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Title";
               }
            }
            else
            {
               subGrids_Titlebackstyle = 1;
               if ( subGrids_Backcolorstyle == 1 )
               {
                  subGrids_Titlebackcolor = subGrids_Allbackcolor;
                  if ( StringUtil.Len( subGrids_Class) > 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrids_Class) > 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+chkavSdt_selectresidents__isselected_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
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
            context.SendWebValue( context.GetMessage( "Resident Salutation", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Title", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Bsn Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "First Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Initials", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Gender", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Address", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Birth Date", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident GUID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Type Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Type Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Medical Indication Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Medical Indication Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Image", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Language", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridsContainer.AddObjectProperty("GridName", "Grids");
         }
         else
         {
            GridsContainer.AddObjectProperty("GridName", "Grids");
            GridsContainer.AddObjectProperty("Header", subGrids_Header);
            GridsContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
            GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("CmpContext", sPrefix);
            GridsContainer.AddObjectProperty("InMasterPage", "false");
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Class", StringUtil.RTrim( chkavSdt_selectresidents__isselected_Class));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavSdt_selectresidents__isselected.Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residentid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__locationid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__organisationid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_selectresidents__residentsalutation.Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residenttitle_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residentbsnnumber_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residentgivenname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residentlastname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residentinitials_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residentemail_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_selectresidents__residentgender.Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residentaddress_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residentphone_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residentbirthdate_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residentguid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residenttypeid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residenttypename_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__medicalindicationid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__medicalindicationname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residentimage_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_selectresidents__residentlanguage_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Selectedindex), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowselection), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Selectioncolor), 9, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowhovering), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Hoveringcolor), 9, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowcollapsing), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         chkavSelectall_Internalname = sPrefix+"vSELECTALL";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         chkavSdt_selectresidents__isselected_Internalname = sPrefix+"SDT_SELECTRESIDENTS__ISSELECTED";
         edtavSdt_selectresidents__residentid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTID";
         edtavSdt_selectresidents__locationid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__LOCATIONID";
         edtavSdt_selectresidents__organisationid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__ORGANISATIONID";
         cmbavSdt_selectresidents__residentsalutation_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTSALUTATION";
         edtavSdt_selectresidents__residenttitle_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTTITLE";
         edtavSdt_selectresidents__residentbsnnumber_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTBSNNUMBER";
         edtavSdt_selectresidents__residentgivenname_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTGIVENNAME";
         edtavSdt_selectresidents__residentlastname_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTLASTNAME";
         edtavSdt_selectresidents__residentinitials_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTINITIALS";
         edtavSdt_selectresidents__residentemail_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTEMAIL";
         cmbavSdt_selectresidents__residentgender_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTGENDER";
         edtavSdt_selectresidents__residentaddress_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTADDRESS";
         edtavSdt_selectresidents__residentphone_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTPHONE";
         edtavSdt_selectresidents__residentbirthdate_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTBIRTHDATE";
         edtavSdt_selectresidents__residentguid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTGUID";
         edtavSdt_selectresidents__residenttypeid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTTYPEID";
         edtavSdt_selectresidents__residenttypename_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTTYPENAME";
         edtavSdt_selectresidents__medicalindicationid_Internalname = sPrefix+"SDT_SELECTRESIDENTS__MEDICALINDICATIONID";
         edtavSdt_selectresidents__medicalindicationname_Internalname = sPrefix+"SDT_SELECTRESIDENTS__MEDICALINDICATIONNAME";
         edtavSdt_selectresidents__residentimage_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTIMAGE";
         edtavSdt_selectresidents__residentlanguage_Internalname = sPrefix+"SDT_SELECTRESIDENTS__RESIDENTLANGUAGE";
         Gridspaginationbar_Internalname = sPrefix+"GRIDSPAGINATIONBAR";
         divGridstablewithpaginationbar_Internalname = sPrefix+"GRIDSTABLEWITHPAGINATIONBAR";
         divGridtablewithpaginationbar1_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR1";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         bttBtncancelaction_Internalname = sPrefix+"BTNCANCELACTION";
         bttBtnenter_Internalname = sPrefix+"BTNENTER";
         divLayoutmaintable1_Internalname = sPrefix+"LAYOUTMAINTABLE1";
         Grids_empowerer_Internalname = sPrefix+"GRIDS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrids_Internalname = sPrefix+"GRIDS";
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
         subGrids_Allowcollapsing = 0;
         subGrids_Allowhovering = -1;
         subGrids_Allowselection = 1;
         subGrids_Header = "";
         chkavSelectall.Caption = context.GetMessage( "Select All", "");
         edtavSdt_selectresidents__residentlanguage_Jsonclick = "";
         edtavSdt_selectresidents__residentlanguage_Enabled = 0;
         edtavSdt_selectresidents__residentimage_Jsonclick = "";
         edtavSdt_selectresidents__residentimage_Enabled = 0;
         edtavSdt_selectresidents__medicalindicationname_Jsonclick = "";
         edtavSdt_selectresidents__medicalindicationname_Enabled = 0;
         edtavSdt_selectresidents__medicalindicationid_Jsonclick = "";
         edtavSdt_selectresidents__medicalindicationid_Enabled = 0;
         edtavSdt_selectresidents__residenttypename_Jsonclick = "";
         edtavSdt_selectresidents__residenttypename_Enabled = 0;
         edtavSdt_selectresidents__residenttypeid_Jsonclick = "";
         edtavSdt_selectresidents__residenttypeid_Enabled = 0;
         edtavSdt_selectresidents__residentguid_Jsonclick = "";
         edtavSdt_selectresidents__residentguid_Enabled = 0;
         edtavSdt_selectresidents__residentbirthdate_Jsonclick = "";
         edtavSdt_selectresidents__residentbirthdate_Enabled = 0;
         edtavSdt_selectresidents__residentphone_Jsonclick = "";
         edtavSdt_selectresidents__residentphone_Enabled = 0;
         edtavSdt_selectresidents__residentaddress_Jsonclick = "";
         edtavSdt_selectresidents__residentaddress_Enabled = 0;
         cmbavSdt_selectresidents__residentgender_Jsonclick = "";
         cmbavSdt_selectresidents__residentgender.Enabled = 0;
         edtavSdt_selectresidents__residentemail_Jsonclick = "";
         edtavSdt_selectresidents__residentemail_Enabled = 0;
         edtavSdt_selectresidents__residentinitials_Jsonclick = "";
         edtavSdt_selectresidents__residentinitials_Enabled = 0;
         edtavSdt_selectresidents__residentlastname_Jsonclick = "";
         edtavSdt_selectresidents__residentlastname_Enabled = 0;
         edtavSdt_selectresidents__residentgivenname_Jsonclick = "";
         edtavSdt_selectresidents__residentgivenname_Enabled = 0;
         edtavSdt_selectresidents__residentbsnnumber_Jsonclick = "";
         edtavSdt_selectresidents__residentbsnnumber_Enabled = 0;
         edtavSdt_selectresidents__residenttitle_Jsonclick = "";
         edtavSdt_selectresidents__residenttitle_Enabled = 0;
         cmbavSdt_selectresidents__residentsalutation_Jsonclick = "";
         cmbavSdt_selectresidents__residentsalutation.Enabled = 0;
         edtavSdt_selectresidents__organisationid_Jsonclick = "";
         edtavSdt_selectresidents__organisationid_Enabled = 0;
         edtavSdt_selectresidents__locationid_Jsonclick = "";
         edtavSdt_selectresidents__locationid_Enabled = 0;
         edtavSdt_selectresidents__residentid_Jsonclick = "";
         edtavSdt_selectresidents__residentid_Enabled = 0;
         chkavSdt_selectresidents__isselected.Caption = "";
         chkavSdt_selectresidents__isselected_Class = "AttributeCheckBox";
         chkavSdt_selectresidents__isselected.Enabled = 1;
         subGrids_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrids_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         chkavSelectall.Enabled = 1;
         Gridspaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridspaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridspaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridspaginationbar_Next = "WWP_PagingNextCaption";
         Gridspaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridspaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridspaginationbar_Rowsperpageselectedvalue = 10;
         Gridspaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridspaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridspaginationbar_Pagingcaptionposition = "Left";
         Gridspaginationbar_Pagingbuttonsposition = "Right";
         Gridspaginationbar_Pagestoshow = 5;
         Gridspaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridspaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridspaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridspaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridspaginationbar_Class = "PaginationBar";
         Form.Caption = context.GetMessage( "Select Residents", "");
         edtavSdt_selectresidents__residentlanguage_Enabled = -1;
         edtavSdt_selectresidents__residentimage_Enabled = -1;
         edtavSdt_selectresidents__medicalindicationname_Enabled = -1;
         edtavSdt_selectresidents__medicalindicationid_Enabled = -1;
         edtavSdt_selectresidents__residenttypename_Enabled = -1;
         edtavSdt_selectresidents__residenttypeid_Enabled = -1;
         edtavSdt_selectresidents__residentguid_Enabled = -1;
         edtavSdt_selectresidents__residentbirthdate_Enabled = -1;
         edtavSdt_selectresidents__residentphone_Enabled = -1;
         edtavSdt_selectresidents__residentaddress_Enabled = -1;
         cmbavSdt_selectresidents__residentgender.Enabled = -1;
         edtavSdt_selectresidents__residentemail_Enabled = -1;
         edtavSdt_selectresidents__residentinitials_Enabled = -1;
         edtavSdt_selectresidents__residentlastname_Enabled = -1;
         edtavSdt_selectresidents__residentgivenname_Enabled = -1;
         edtavSdt_selectresidents__residentbsnnumber_Enabled = -1;
         edtavSdt_selectresidents__residenttitle_Enabled = -1;
         cmbavSdt_selectresidents__residentsalutation.Enabled = -1;
         edtavSdt_selectresidents__organisationid_Enabled = -1;
         edtavSdt_selectresidents__locationid_Enabled = -1;
         edtavSdt_selectresidents__residentid_Enabled = -1;
         subGrids_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV37SDT_SelectResidents","fld":"vSDT_SELECTRESIDENTS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"nRC_GXsfl_38","ctrl":"GRIDS","prop":"GridRC","grid":38},{"av":"sPrefix"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV12FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"AV34SelectedResidentIdCollection","fld":"vSELECTEDRESIDENTIDCOLLECTION"},{"av":"AV43ExistingResidentIdCollection","fld":"vEXISTINGRESIDENTIDCOLLECTION","hsh":true},{"av":"AV45SelectAll","fld":"vSELECTALL"},{"av":"AV41PopupTitle","fld":"vPOPUPTITLE","hsh":true},{"av":"AV32ResidentsDefinitionTitle","fld":"vRESIDENTSDEFINITIONTITLE","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV38GridsCurrentPage","fld":"vGRIDSCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridsPageCount","fld":"vGRIDSPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV37SDT_SelectResidents","fld":"vSDT_SELECTRESIDENTS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_38","ctrl":"GRIDS","prop":"GridRC","grid":38},{"av":"AV34SelectedResidentIdCollection","fld":"vSELECTEDRESIDENTIDCOLLECTION"}]}""");
         setEventMetadata("GRIDS.LOAD","""{"handler":"E19BZ2","iparms":[{"av":"AV37SDT_SelectResidents","fld":"vSDT_SELECTRESIDENTS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_38","ctrl":"GRIDS","prop":"GridRC","grid":38},{"av":"AV43ExistingResidentIdCollection","fld":"vEXISTINGRESIDENTIDCOLLECTION","hsh":true}]""");
         setEventMetadata("GRIDS.LOAD",""","oparms":[{"ctrl":"SDT_SELECTRESIDENTS__ISSELECTED","prop":"Enabled"},{"ctrl":"SDT_SELECTRESIDENTS__ISSELECTED","prop":"Class"}]}""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12BZ2","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV12FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"AV34SelectedResidentIdCollection","fld":"vSELECTEDRESIDENTIDCOLLECTION"},{"av":"AV37SDT_SelectResidents","fld":"vSDT_SELECTRESIDENTS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"nRC_GXsfl_38","ctrl":"GRIDS","prop":"GridRC","grid":38},{"av":"AV43ExistingResidentIdCollection","fld":"vEXISTINGRESIDENTIDCOLLECTION","hsh":true},{"av":"AV45SelectAll","fld":"vSELECTALL"},{"av":"AV41PopupTitle","fld":"vPOPUPTITLE","hsh":true},{"av":"AV32ResidentsDefinitionTitle","fld":"vRESIDENTSDEFINITIONTITLE","hsh":true},{"av":"sPrefix"},{"av":"Gridspaginationbar_Selectedpage","ctrl":"GRIDSPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13BZ2","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV12FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"AV34SelectedResidentIdCollection","fld":"vSELECTEDRESIDENTIDCOLLECTION"},{"av":"AV37SDT_SelectResidents","fld":"vSDT_SELECTRESIDENTS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"nRC_GXsfl_38","ctrl":"GRIDS","prop":"GridRC","grid":38},{"av":"AV43ExistingResidentIdCollection","fld":"vEXISTINGRESIDENTIDCOLLECTION","hsh":true},{"av":"AV45SelectAll","fld":"vSELECTALL"},{"av":"AV41PopupTitle","fld":"vPOPUPTITLE","hsh":true},{"av":"AV32ResidentsDefinitionTitle","fld":"vRESIDENTSDEFINITIONTITLE","hsh":true},{"av":"sPrefix"},{"av":"Gridspaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDSPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"}]}""");
         setEventMetadata("'DOCANCELACTION'","""{"handler":"E11BZ1","iparms":[{"av":"AV41PopupTitle","fld":"vPOPUPTITLE","hsh":true}]}""");
         setEventMetadata("ENTER","""{"handler":"E14BZ2","iparms":[{"av":"AV34SelectedResidentIdCollection","fld":"vSELECTEDRESIDENTIDCOLLECTION"},{"av":"AV28ResidentPackageId","fld":"vRESIDENTPACKAGEID"},{"av":"AV32ResidentsDefinitionTitle","fld":"vRESIDENTSDEFINITIONTITLE","hsh":true},{"av":"AV41PopupTitle","fld":"vPOPUPTITLE","hsh":true},{"av":"AV37SDT_SelectResidents","fld":"vSDT_SELECTRESIDENTS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_38","ctrl":"GRIDS","prop":"GridRC","grid":38}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV34SelectedResidentIdCollection","fld":"vSELECTEDRESIDENTIDCOLLECTION"}]}""");
         setEventMetadata("VFILTERFULLTEXT.CONTROLVALUECHANGING","""{"handler":"E15BZ2","iparms":[{"av":"AV12FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV37SDT_SelectResidents","fld":"vSDT_SELECTRESIDENTS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_38","ctrl":"GRIDS","prop":"GridRC","grid":38},{"av":"AV34SelectedResidentIdCollection","fld":"vSELECTEDRESIDENTIDCOLLECTION"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV43ExistingResidentIdCollection","fld":"vEXISTINGRESIDENTIDCOLLECTION","hsh":true},{"av":"AV45SelectAll","fld":"vSELECTALL"},{"av":"AV41PopupTitle","fld":"vPOPUPTITLE","hsh":true},{"av":"AV32ResidentsDefinitionTitle","fld":"vRESIDENTSDEFINITIONTITLE","hsh":true}]""");
         setEventMetadata("VFILTERFULLTEXT.CONTROLVALUECHANGING",""","oparms":[{"av":"AV34SelectedResidentIdCollection","fld":"vSELECTEDRESIDENTIDCOLLECTION"},{"av":"AV37SDT_SelectResidents","fld":"vSDT_SELECTRESIDENTS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_38","ctrl":"GRIDS","prop":"GridRC","grid":38}]}""");
         setEventMetadata("VSELECTALL.CONTROLVALUECHANGED","""{"handler":"E16BZ2","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV12FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"AV34SelectedResidentIdCollection","fld":"vSELECTEDRESIDENTIDCOLLECTION"},{"av":"AV37SDT_SelectResidents","fld":"vSDT_SELECTRESIDENTS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"nRC_GXsfl_38","ctrl":"GRIDS","prop":"GridRC","grid":38},{"av":"AV43ExistingResidentIdCollection","fld":"vEXISTINGRESIDENTIDCOLLECTION","hsh":true},{"av":"AV45SelectAll","fld":"vSELECTALL"},{"av":"AV41PopupTitle","fld":"vPOPUPTITLE","hsh":true},{"av":"AV32ResidentsDefinitionTitle","fld":"vRESIDENTSDEFINITIONTITLE","hsh":true},{"av":"sPrefix"}]""");
         setEventMetadata("VSELECTALL.CONTROLVALUECHANGED",""","oparms":[{"av":"AV34SelectedResidentIdCollection","fld":"vSELECTEDRESIDENTIDCOLLECTION"},{"av":"AV38GridsCurrentPage","fld":"vGRIDSCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridsPageCount","fld":"vGRIDSPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV37SDT_SelectResidents","fld":"vSDT_SELECTRESIDENTS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_38","ctrl":"GRIDS","prop":"GridRC","grid":38}]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
         setEventMetadata("VALIDV_GXV12","""{"handler":"Validv_Gxv12","iparms":[]}""");
         setEventMetadata("VALIDV_GXV13","""{"handler":"Validv_Gxv13","iparms":[]}""");
         setEventMetadata("VALIDV_GXV18","""{"handler":"Validv_Gxv18","iparms":[]}""");
         setEventMetadata("VALIDV_GXV20","""{"handler":"Validv_Gxv20","iparms":[]}""");
         setEventMetadata("VALIDV_GXV22","""{"handler":"Validv_Gxv22","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv23","iparms":[]}""");
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
         AV42SDT_ResidentsOfGroup = new GXBaseCollection<SdtSDT_Resident>( context, "SDT_Resident", "Comforta_version2");
         wcpOAV28ResidentPackageId = Guid.Empty;
         Gridspaginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         A29LocationId = Guid.Empty;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12FilterFullText = "";
         A62ResidentId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A72ResidentSalutation = "";
         A63ResidentBsnNumber = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A66ResidentInitials = "";
         A67ResidentEmail = "";
         A68ResidentGender = "";
         A70ResidentPhone = "";
         A97ResidentTypeName = "";
         A98MedicalIndicationId = Guid.Empty;
         A99MedicalIndicationName = "";
         A73ResidentBirthDate = DateTime.MinValue;
         A96ResidentTypeId = Guid.Empty;
         A71ResidentGUID = "";
         AV34SelectedResidentIdCollection = new GxSimpleCollection<Guid>();
         AV37SDT_SelectResidents = new GXBaseCollection<SdtSDT_SelectResident>( context, "SDT_SelectResident", "Comforta_version2");
         AV43ExistingResidentIdCollection = new GxSimpleCollection<Guid>();
         AV41PopupTitle = "";
         AV32ResidentsDefinitionTitle = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV40GridsAppliedFilters = "";
         Grids_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         GridsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridspaginationbar = new GXUserControl();
         bttBtncancelaction_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         ucGrids_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         GXt_char1 = "";
         GridsRow = new GXWebRow();
         AV35SDT_Resident = new SdtSDT_SelectResident(context);
         H00BZ2_A64ResidentGivenName = new string[] {""} ;
         H00BZ2_A65ResidentLastName = new string[] {""} ;
         H00BZ2_A29LocationId = new Guid[] {Guid.Empty} ;
         H00BZ2_A62ResidentId = new Guid[] {Guid.Empty} ;
         H00BZ2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00BZ2_A72ResidentSalutation = new string[] {""} ;
         H00BZ2_n72ResidentSalutation = new bool[] {false} ;
         H00BZ2_A63ResidentBsnNumber = new string[] {""} ;
         H00BZ2_A66ResidentInitials = new string[] {""} ;
         H00BZ2_A67ResidentEmail = new string[] {""} ;
         H00BZ2_A68ResidentGender = new string[] {""} ;
         H00BZ2_A70ResidentPhone = new string[] {""} ;
         H00BZ2_A97ResidentTypeName = new string[] {""} ;
         H00BZ2_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H00BZ2_n98MedicalIndicationId = new bool[] {false} ;
         H00BZ2_A99MedicalIndicationName = new string[] {""} ;
         H00BZ2_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         H00BZ2_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H00BZ2_n96ResidentTypeId = new bool[] {false} ;
         H00BZ2_A71ResidentGUID = new string[] {""} ;
         AV44SDT_ResidentOfGroup = new SdtSDT_Resident(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV28ResidentPackageId = "";
         sCtrlAV42SDT_ResidentsOfGroup = "";
         subGrids_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridsColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wc_selectresidents__default(),
            new Object[][] {
                new Object[] {
               H00BZ2_A64ResidentGivenName, H00BZ2_A65ResidentLastName, H00BZ2_A29LocationId, H00BZ2_A62ResidentId, H00BZ2_A11OrganisationId, H00BZ2_A72ResidentSalutation, H00BZ2_n72ResidentSalutation, H00BZ2_A63ResidentBsnNumber, H00BZ2_A66ResidentInitials, H00BZ2_A67ResidentEmail,
               H00BZ2_A68ResidentGender, H00BZ2_A70ResidentPhone, H00BZ2_A97ResidentTypeName, H00BZ2_A98MedicalIndicationId, H00BZ2_n98MedicalIndicationId, H00BZ2_A99MedicalIndicationName, H00BZ2_A73ResidentBirthDate, H00BZ2_A96ResidentTypeId, H00BZ2_n96ResidentTypeId, H00BZ2_A71ResidentGUID
               }
            }
         );
         /* GeneXus formulas. */
         edtavSdt_selectresidents__residentid_Enabled = 0;
         edtavSdt_selectresidents__locationid_Enabled = 0;
         edtavSdt_selectresidents__organisationid_Enabled = 0;
         cmbavSdt_selectresidents__residentsalutation.Enabled = 0;
         edtavSdt_selectresidents__residenttitle_Enabled = 0;
         edtavSdt_selectresidents__residentbsnnumber_Enabled = 0;
         edtavSdt_selectresidents__residentgivenname_Enabled = 0;
         edtavSdt_selectresidents__residentlastname_Enabled = 0;
         edtavSdt_selectresidents__residentinitials_Enabled = 0;
         edtavSdt_selectresidents__residentemail_Enabled = 0;
         cmbavSdt_selectresidents__residentgender.Enabled = 0;
         edtavSdt_selectresidents__residentaddress_Enabled = 0;
         edtavSdt_selectresidents__residentphone_Enabled = 0;
         edtavSdt_selectresidents__residentbirthdate_Enabled = 0;
         edtavSdt_selectresidents__residentguid_Enabled = 0;
         edtavSdt_selectresidents__residenttypeid_Enabled = 0;
         edtavSdt_selectresidents__residenttypename_Enabled = 0;
         edtavSdt_selectresidents__medicalindicationid_Enabled = 0;
         edtavSdt_selectresidents__medicalindicationname_Enabled = 0;
         edtavSdt_selectresidents__residentimage_Enabled = 0;
         edtavSdt_selectresidents__residentlanguage_Enabled = 0;
      }

      private short GRIDS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrids_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrids_Backstyle ;
      private short subGrids_Titlebackstyle ;
      private short subGrids_Allowselection ;
      private short subGrids_Allowhovering ;
      private short subGrids_Allowcollapsing ;
      private short subGrids_Collapsed ;
      private int Gridspaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_38 ;
      private int subGrids_Rows ;
      private int nGXsfl_38_idx=1 ;
      private int edtavSdt_selectresidents__residentid_Enabled ;
      private int edtavSdt_selectresidents__locationid_Enabled ;
      private int edtavSdt_selectresidents__organisationid_Enabled ;
      private int edtavSdt_selectresidents__residenttitle_Enabled ;
      private int edtavSdt_selectresidents__residentbsnnumber_Enabled ;
      private int edtavSdt_selectresidents__residentgivenname_Enabled ;
      private int edtavSdt_selectresidents__residentlastname_Enabled ;
      private int edtavSdt_selectresidents__residentinitials_Enabled ;
      private int edtavSdt_selectresidents__residentemail_Enabled ;
      private int edtavSdt_selectresidents__residentaddress_Enabled ;
      private int edtavSdt_selectresidents__residentphone_Enabled ;
      private int edtavSdt_selectresidents__residentbirthdate_Enabled ;
      private int edtavSdt_selectresidents__residentguid_Enabled ;
      private int edtavSdt_selectresidents__residenttypeid_Enabled ;
      private int edtavSdt_selectresidents__residenttypename_Enabled ;
      private int edtavSdt_selectresidents__medicalindicationid_Enabled ;
      private int edtavSdt_selectresidents__medicalindicationname_Enabled ;
      private int edtavSdt_selectresidents__residentimage_Enabled ;
      private int edtavSdt_selectresidents__residentlanguage_Enabled ;
      private int Gridspaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int AV46GXV1 ;
      private int subGrids_Islastpage ;
      private int GRIDS_nGridOutOfScope ;
      private int nGXsfl_38_fel_idx=1 ;
      private int AV23PageToGo ;
      private int nGXsfl_38_bak_idx=1 ;
      private int AV69GXV24 ;
      private int AV71GXV25 ;
      private int AV72GXV26 ;
      private int idxLst ;
      private int subGrids_Backcolor ;
      private int subGrids_Allbackcolor ;
      private int subGrids_Titlebackcolor ;
      private int subGrids_Selectedindex ;
      private int subGrids_Selectioncolor ;
      private int subGrids_Hoveringcolor ;
      private long GRIDS_nFirstRecordOnPage ;
      private long AV38GridsCurrentPage ;
      private long AV39GridsPageCount ;
      private long GRIDS_nCurrentRecord ;
      private long GRIDS_nRecordCount ;
      private string Gridspaginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_38_idx="0001" ;
      private string A72ResidentSalutation ;
      private string A66ResidentInitials ;
      private string A70ResidentPhone ;
      private string edtavSdt_selectresidents__residentid_Internalname ;
      private string edtavSdt_selectresidents__locationid_Internalname ;
      private string edtavSdt_selectresidents__organisationid_Internalname ;
      private string cmbavSdt_selectresidents__residentsalutation_Internalname ;
      private string edtavSdt_selectresidents__residenttitle_Internalname ;
      private string edtavSdt_selectresidents__residentbsnnumber_Internalname ;
      private string edtavSdt_selectresidents__residentgivenname_Internalname ;
      private string edtavSdt_selectresidents__residentlastname_Internalname ;
      private string edtavSdt_selectresidents__residentinitials_Internalname ;
      private string edtavSdt_selectresidents__residentemail_Internalname ;
      private string cmbavSdt_selectresidents__residentgender_Internalname ;
      private string edtavSdt_selectresidents__residentaddress_Internalname ;
      private string edtavSdt_selectresidents__residentphone_Internalname ;
      private string edtavSdt_selectresidents__residentbirthdate_Internalname ;
      private string edtavSdt_selectresidents__residentguid_Internalname ;
      private string edtavSdt_selectresidents__residenttypeid_Internalname ;
      private string edtavSdt_selectresidents__residenttypename_Internalname ;
      private string edtavSdt_selectresidents__medicalindicationid_Internalname ;
      private string edtavSdt_selectresidents__medicalindicationname_Internalname ;
      private string edtavSdt_selectresidents__residentimage_Internalname ;
      private string edtavSdt_selectresidents__residentlanguage_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Gridspaginationbar_Class ;
      private string Gridspaginationbar_Pagingbuttonsposition ;
      private string Gridspaginationbar_Pagingcaptionposition ;
      private string Gridspaginationbar_Emptygridclass ;
      private string Gridspaginationbar_Rowsperpageoptions ;
      private string Gridspaginationbar_Previous ;
      private string Gridspaginationbar_Next ;
      private string Gridspaginationbar_Caption ;
      private string Gridspaginationbar_Emptygridcaption ;
      private string Gridspaginationbar_Rowsperpagecaption ;
      private string Grids_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable1_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string chkavSelectall_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string divTablerightheader_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divGridtablewithpaginationbar1_Internalname ;
      private string divGridstablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrids_Internalname ;
      private string Gridspaginationbar_Internalname ;
      private string bttBtncancelaction_Internalname ;
      private string bttBtncancelaction_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grids_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sGXsfl_38_fel_idx="0001" ;
      private string GXt_char1 ;
      private string chkavSdt_selectresidents__isselected_Class ;
      private string sCtrlAV28ResidentPackageId ;
      private string sCtrlAV42SDT_ResidentsOfGroup ;
      private string chkavSdt_selectresidents__isselected_Internalname ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtavSdt_selectresidents__residentid_Jsonclick ;
      private string edtavSdt_selectresidents__locationid_Jsonclick ;
      private string edtavSdt_selectresidents__organisationid_Jsonclick ;
      private string cmbavSdt_selectresidents__residentsalutation_Jsonclick ;
      private string edtavSdt_selectresidents__residenttitle_Jsonclick ;
      private string edtavSdt_selectresidents__residentbsnnumber_Jsonclick ;
      private string edtavSdt_selectresidents__residentgivenname_Jsonclick ;
      private string edtavSdt_selectresidents__residentlastname_Jsonclick ;
      private string edtavSdt_selectresidents__residentinitials_Jsonclick ;
      private string edtavSdt_selectresidents__residentemail_Jsonclick ;
      private string cmbavSdt_selectresidents__residentgender_Jsonclick ;
      private string edtavSdt_selectresidents__residentaddress_Jsonclick ;
      private string edtavSdt_selectresidents__residentphone_Jsonclick ;
      private string edtavSdt_selectresidents__residentbirthdate_Jsonclick ;
      private string edtavSdt_selectresidents__residentguid_Jsonclick ;
      private string edtavSdt_selectresidents__residenttypeid_Jsonclick ;
      private string edtavSdt_selectresidents__residenttypename_Jsonclick ;
      private string edtavSdt_selectresidents__medicalindicationid_Jsonclick ;
      private string edtavSdt_selectresidents__medicalindicationname_Jsonclick ;
      private string edtavSdt_selectresidents__residentimage_Jsonclick ;
      private string edtavSdt_selectresidents__residentlanguage_Jsonclick ;
      private string subGrids_Header ;
      private DateTime A73ResidentBirthDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n72ResidentSalutation ;
      private bool n98MedicalIndicationId ;
      private bool n96ResidentTypeId ;
      private bool AV45SelectAll ;
      private bool bGXsfl_38_Refreshing=false ;
      private bool Gridspaginationbar_Showfirst ;
      private bool Gridspaginationbar_Showprevious ;
      private bool Gridspaginationbar_Shownext ;
      private bool Gridspaginationbar_Showlast ;
      private bool Gridspaginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool gx_BV38 ;
      private string AV12FilterFullText ;
      private string A63ResidentBsnNumber ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A67ResidentEmail ;
      private string A68ResidentGender ;
      private string A97ResidentTypeName ;
      private string A99MedicalIndicationName ;
      private string A71ResidentGUID ;
      private string AV41PopupTitle ;
      private string AV32ResidentsDefinitionTitle ;
      private string AV40GridsAppliedFilters ;
      private Guid AV28ResidentPackageId ;
      private Guid wcpOAV28ResidentPackageId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid A11OrganisationId ;
      private Guid A98MedicalIndicationId ;
      private Guid A96ResidentTypeId ;
      private Guid AV6WWPContext_gxTpr_Locationid ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXUserControl ucGridspaginationbar ;
      private GXUserControl ucGrids_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_Resident> AV42SDT_ResidentsOfGroup ;
      private GXCheckbox chkavSelectall ;
      private GXCheckbox chkavSdt_selectresidents__isselected ;
      private GXCombobox cmbavSdt_selectresidents__residentsalutation ;
      private GXCombobox cmbavSdt_selectresidents__residentgender ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GxSimpleCollection<Guid> AV34SelectedResidentIdCollection ;
      private GXBaseCollection<SdtSDT_SelectResident> AV37SDT_SelectResidents ;
      private GxSimpleCollection<Guid> AV43ExistingResidentIdCollection ;
      private SdtSDT_SelectResident AV35SDT_Resident ;
      private IDataStoreProvider pr_default ;
      private string[] H00BZ2_A64ResidentGivenName ;
      private string[] H00BZ2_A65ResidentLastName ;
      private Guid[] H00BZ2_A29LocationId ;
      private Guid[] H00BZ2_A62ResidentId ;
      private Guid[] H00BZ2_A11OrganisationId ;
      private string[] H00BZ2_A72ResidentSalutation ;
      private bool[] H00BZ2_n72ResidentSalutation ;
      private string[] H00BZ2_A63ResidentBsnNumber ;
      private string[] H00BZ2_A66ResidentInitials ;
      private string[] H00BZ2_A67ResidentEmail ;
      private string[] H00BZ2_A68ResidentGender ;
      private string[] H00BZ2_A70ResidentPhone ;
      private string[] H00BZ2_A97ResidentTypeName ;
      private Guid[] H00BZ2_A98MedicalIndicationId ;
      private bool[] H00BZ2_n98MedicalIndicationId ;
      private string[] H00BZ2_A99MedicalIndicationName ;
      private DateTime[] H00BZ2_A73ResidentBirthDate ;
      private Guid[] H00BZ2_A96ResidentTypeId ;
      private bool[] H00BZ2_n96ResidentTypeId ;
      private string[] H00BZ2_A71ResidentGUID ;
      private SdtSDT_Resident AV44SDT_ResidentOfGroup ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wc_selectresidents__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00BZ2( IGxContext context ,
                                             string AV12FilterFullText ,
                                             Guid AV6WWPContext_gxTpr_Locationid ,
                                             Guid A29LocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[3];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.ResidentGivenName, T1.ResidentLastName, T1.LocationId, T1.ResidentId, T1.OrganisationId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentInitials, T1.ResidentEmail, T1.ResidentGender, T1.ResidentPhone, T3.ResidentTypeName, T1.MedicalIndicationId, T2.MedicalIndicationName, T1.ResidentBirthDate, T1.ResidentTypeId, T1.ResidentGUID FROM ((Trn_Resident T1 LEFT JOIN Trn_MedicalIndication T2 ON T2.MedicalIndicationId = T1.MedicalIndicationId) LEFT JOIN Trn_ResidentType T3 ON T3.ResidentTypeId = T1.ResidentTypeId)";
         AddWhere(sWhereString, "(T1.LocationId = :AV6WWPContext__Locationid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12FilterFullText)) )
         {
            AddWhere(sWhereString, "(POSITION(RTRIM(:AV12FilterFullText) IN LOWER(T1.ResidentGivenName)) >= 1 or POSITION(RTRIM(:AV12FilterFullText) IN LOWER(T1.ResidentLastName)) >= 1)");
         }
         else
         {
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LocationId";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00BZ2(context, (string)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH00BZ2;
          prmH00BZ2 = new Object[] {
          new ParDef("AV6WWPContext__Locationid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV12FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("AV12FilterFullText",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00BZ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BZ2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((Guid[]) buf[13])[0] = rslt.getGuid(13);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                ((string[]) buf[15])[0] = rslt.getVarchar(14);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(15);
                ((Guid[]) buf[17])[0] = rslt.getGuid(16);
                ((bool[]) buf[18])[0] = rslt.wasNull(16);
                ((string[]) buf[19])[0] = rslt.getVarchar(17);
                return;
       }
    }

 }

}
