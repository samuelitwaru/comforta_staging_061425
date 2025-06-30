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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_subscriptionssettingswc : GXWebComponent
   {
      public wwp_subscriptionssettingswc( )
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

      public wwp_subscriptionssettingswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WWPEntityId ,
                           bool aP1_NotifShowOnlySubscribedEvents )
      {
         this.AV16WWPEntityId = aP0_WWPEntityId;
         this.AV12NotifShowOnlySubscribedEvents = aP1_NotifShowOnlySubscribedEvents;
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
         chkavIncludenotification = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WWPEntityId");
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
                  AV16WWPEntityId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPEntityId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV16WWPEntityId", StringUtil.LTrimStr( (decimal)(AV16WWPEntityId), 10, 0));
                  AV12NotifShowOnlySubscribedEvents = StringUtil.StrToBool( GetPar( "NotifShowOnlySubscribedEvents"));
                  AssignAttri(sPrefix, false, "AV12NotifShowOnlySubscribedEvents", AV12NotifShowOnlySubscribedEvents);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV16WWPEntityId,(bool)AV12NotifShowOnlySubscribedEvents});
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
                  gxfirstwebparm = GetFirstPar( "WWPEntityId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPEntityId");
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
         nRC_GXsfl_14 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_14"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_14_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_14_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_14_idx = GetPar( "sGXsfl_14_idx");
         sPrefix = GetPar( "sPrefix");
         edtavWwpnotificationdefinitionid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpnotificationdefinitionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpnotificationdefinitionid_Visible), 5, 0), !bGXsfl_14_Refreshing);
         edtavWwpsubscriptionid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_14_Refreshing);
         edtavWwpsubscriptionentityrecordid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpsubscriptionentityrecordid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionentityrecordid_Visible), 5, 0), !bGXsfl_14_Refreshing);
         edtavWwpsubscriptionentityrecorddescription_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpsubscriptionentityrecorddescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionentityrecorddescription_Visible), 5, 0), !bGXsfl_14_Refreshing);
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
         AV30Pgmname = GetPar( "Pgmname");
         edtavWwpnotificationdefinitionid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpnotificationdefinitionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpnotificationdefinitionid_Visible), 5, 0), !bGXsfl_14_Refreshing);
         edtavWwpsubscriptionid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_14_Refreshing);
         edtavWwpsubscriptionentityrecordid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpsubscriptionentityrecordid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionentityrecordid_Visible), 5, 0), !bGXsfl_14_Refreshing);
         edtavWwpsubscriptionentityrecorddescription_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpsubscriptionentityrecorddescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionentityrecorddescription_Visible), 5, 0), !bGXsfl_14_Refreshing);
         A125WWPEntityId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPEntityId"), "."), 18, MidpointRounding.ToEven));
         AV16WWPEntityId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPEntityId"), "."), 18, MidpointRounding.ToEven));
         A136WWPNotificationDefinitionAllow = StringUtil.StrToBool( GetPar( "WWPNotificationDefinitionAllow"));
         A128WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
         A134WWPNotificationDefinitionDescr = GetPar( "WWPNotificationDefinitionDescr");
         A112WWPUserExtendedId = GetPar( "WWPUserExtendedId");
         n112WWPUserExtendedId = false;
         AV29Udparg1 = GetPar( "Udparg1");
         A132WWPSubscriptionSubscribed = StringUtil.StrToBool( GetPar( "WWPSubscriptionSubscribed"));
         A124WWPSubscriptionRoleId = GetPar( "WWPSubscriptionRoleId");
         n124WWPSubscriptionRoleId = false;
         A130WWPSubscriptionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPSubscriptionId"), "."), 18, MidpointRounding.ToEven));
         A135WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionAppli"), "."), 18, MidpointRounding.ToEven));
         A131WWPSubscriptionEntityRecordId = GetPar( "WWPSubscriptionEntityRecordId");
         A133WWPSubscriptionEntityRecordDes = GetPar( "WWPSubscriptionEntityRecordDes");
         AV12NotifShowOnlySubscribedEvents = StringUtil.StrToBool( GetPar( "NotifShowOnlySubscribedEvents"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV30Pgmname, A125WWPEntityId, AV16WWPEntityId, A136WWPNotificationDefinitionAllow, A128WWPNotificationDefinitionId, A134WWPNotificationDefinitionDescr, A112WWPUserExtendedId, AV29Udparg1, A132WWPSubscriptionSubscribed, A124WWPSubscriptionRoleId, A130WWPSubscriptionId, A135WWPNotificationDefinitionAppli, A131WWPSubscriptionEntityRecordId, A133WWPSubscriptionEntityRecordDes, AV12NotifShowOnlySubscribedEvents, sPrefix) ;
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
            PA1O2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV30Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettingsWC";
               edtavWwpnotificationdescription_Enabled = 0;
               AssignProp(sPrefix, false, edtavWwpnotificationdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwpnotificationdescription_Enabled), 5, 0), !bGXsfl_14_Refreshing);
               WS1O2( ) ;
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
            context.SendWebValue( context.GetMessage( " Subscriptions Settings", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.subscriptions.wwp_subscriptionssettingswc.aspx"+UrlEncode(StringUtil.LTrimStr(AV16WWPEntityId,10,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV12NotifShowOnlySubscribedEvents));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.subscriptions.wwp_subscriptionssettingswc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV30Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV30Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG1", StringUtil.RTrim( AV29Udparg1));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV29Udparg1, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_14", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_14), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV16WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV16WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV12NotifShowOnlySubscribedEvents", wcpOAV12NotifShowOnlySubscribedEvents);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV30Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV30Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONALLOW", A136WWPNotificationDefinitionAllow);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONDESCR", A134WWPNotificationDefinitionDescr);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPUSEREXTENDEDID", StringUtil.RTrim( A112WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG1", StringUtil.RTrim( AV29Udparg1));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV29Udparg1, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONSUBSCRIBED", A132WWPSubscriptionSubscribed);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONROLEID", StringUtil.RTrim( A124WWPSubscriptionRoleId));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A130WWPSubscriptionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONAPPLI", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135WWPNotificationDefinitionAppli), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONENTITYRECORDID", A131WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONENTITYRECORDDES", A133WWPSubscriptionEntityRecordDes);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vNOTIFSHOWONLYSUBSCRIBEDEVENTS", AV12NotifShowOnlySubscribedEvents);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE1_Width", StringUtil.RTrim( Dvpanel_unnamedtable1_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE1_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE1_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE1_Cls", StringUtil.RTrim( Dvpanel_unnamedtable1_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE1_Title", StringUtil.RTrim( Dvpanel_unnamedtable1_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE1_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE1_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE1_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable1_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE1_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONDEFINITIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpnotificationdefinitionid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPSUBSCRIPTIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPSUBSCRIPTIONENTITYRECORDID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpsubscriptionentityrecordid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpsubscriptionentityrecorddescription_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm1O2( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettingsWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Subscriptions Settings", "") ;
      }

      protected void WB1O0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.subscriptions.wwp_subscriptionssettingswc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain TableSubscriptions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable1.SetProperty("Width", Dvpanel_unnamedtable1_Width);
            ucDvpanel_unnamedtable1.SetProperty("AutoWidth", Dvpanel_unnamedtable1_Autowidth);
            ucDvpanel_unnamedtable1.SetProperty("AutoHeight", Dvpanel_unnamedtable1_Autoheight);
            ucDvpanel_unnamedtable1.SetProperty("Cls", Dvpanel_unnamedtable1_Cls);
            ucDvpanel_unnamedtable1.SetProperty("Title", Dvpanel_unnamedtable1_Title);
            ucDvpanel_unnamedtable1.SetProperty("Collapsible", Dvpanel_unnamedtable1_Collapsible);
            ucDvpanel_unnamedtable1.SetProperty("Collapsed", Dvpanel_unnamedtable1_Collapsed);
            ucDvpanel_unnamedtable1.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable1_Showcollapseicon);
            ucDvpanel_unnamedtable1.SetProperty("IconPosition", Dvpanel_unnamedtable1_Iconposition);
            ucDvpanel_unnamedtable1.SetProperty("AutoScroll", Dvpanel_unnamedtable1_Autoscroll);
            ucDvpanel_unnamedtable1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable1_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE1Container"+"UnnamedTable1"+"\" style=\"display:none;\">") ;
            wb_table1_11_1O2( true) ;
         }
         else
         {
            wb_table1_11_1O2( false) ;
         }
         return  ;
      }

      protected void wb_table1_11_1O2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 14 )
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

      protected void START1O2( )
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
            Form.Meta.addItem("description", context.GetMessage( " Subscriptions Settings", ""), 0) ;
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
               STRUP1O0( ) ;
            }
         }
      }

      protected void WS1O2( )
      {
         START1O2( ) ;
         EVT1O2( ) ;
      }

      protected void EVT1O2( )
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
                                 STRUP1O0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "TABLESUBSCRIPTIONITEM.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Tablesubscriptionitem.Click */
                                    E111O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavIncludenotification_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1O0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 27), "TABLESUBSCRIPTIONITEM.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1O0( ) ;
                              }
                              nGXsfl_14_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
                              SubsflControlProps_142( ) ;
                              AV11IncludeNotification = StringUtil.StrToBool( cgiGet( chkavIncludenotification_Internalname));
                              AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV11IncludeNotification);
                              AV17WWPNotificationDescription = cgiGet( edtavWwpnotificationdescription_Internalname);
                              AssignAttri(sPrefix, false, edtavWwpnotificationdescription_Internalname, AV17WWPNotificationDescription);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpnotificationdefinitionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpnotificationdefinitionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPNOTIFICATIONDEFINITIONID");
                                 GX_FocusControl = edtavWwpnotificationdefinitionid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV5WWPNotificationDefinitionId = 0;
                                 AssignAttri(sPrefix, false, edtavWwpnotificationdefinitionid_Internalname, StringUtil.LTrimStr( (decimal)(AV5WWPNotificationDefinitionId), 10, 0));
                              }
                              else
                              {
                                 AV5WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwpnotificationdefinitionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavWwpnotificationdefinitionid_Internalname, StringUtil.LTrimStr( (decimal)(AV5WWPNotificationDefinitionId), 10, 0));
                              }
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPSUBSCRIPTIONID");
                                 GX_FocusControl = edtavWwpsubscriptionid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV7WWPSubscriptionId = 0;
                                 AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV7WWPSubscriptionId), 10, 0));
                              }
                              else
                              {
                                 AV7WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV7WWPSubscriptionId), 10, 0));
                              }
                              AV19WWPSubscriptionEntityRecordId = cgiGet( edtavWwpsubscriptionentityrecordid_Internalname);
                              AssignAttri(sPrefix, false, edtavWwpsubscriptionentityrecordid_Internalname, AV19WWPSubscriptionEntityRecordId);
                              AV6WWPSubscriptionEntityRecordDescription = cgiGet( edtavWwpsubscriptionentityrecorddescription_Internalname);
                              AssignAttri(sPrefix, false, edtavWwpsubscriptionentityrecorddescription_Internalname, AV6WWPSubscriptionEntityRecordDescription);
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
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E121O2 ();
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
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E131O2 ();
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
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E141O2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "TABLESUBSCRIPTIONITEM.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Tablesubscriptionitem.Click */
                                          E111O2 ();
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
                                       STRUP1O0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
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

      protected void WE1O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm1O2( ) ;
            }
         }
      }

      protected void PA1O2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.subscriptions.wwp_subscriptionssettingswc.aspx")), "wwpbaseobjects.subscriptions.wwp_subscriptionssettingswc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.subscriptions.wwp_subscriptionssettingswc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "WWPEntityId");
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
         SubsflControlProps_142( ) ;
         while ( nGXsfl_14_idx <= nRC_GXsfl_14 )
         {
            sendrow_142( ) ;
            nGXsfl_14_idx = ((subGrid_Islastpage==1)&&(nGXsfl_14_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_14_idx+1);
            sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
            SubsflControlProps_142( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV30Pgmname ,
                                       long A125WWPEntityId ,
                                       long AV16WWPEntityId ,
                                       bool A136WWPNotificationDefinitionAllow ,
                                       long A128WWPNotificationDefinitionId ,
                                       string A134WWPNotificationDefinitionDescr ,
                                       string A112WWPUserExtendedId ,
                                       string AV29Udparg1 ,
                                       bool A132WWPSubscriptionSubscribed ,
                                       string A124WWPSubscriptionRoleId ,
                                       long A130WWPSubscriptionId ,
                                       short A135WWPNotificationDefinitionAppli ,
                                       string A131WWPSubscriptionEntityRecordId ,
                                       string A133WWPSubscriptionEntityRecordDes ,
                                       bool AV12NotifShowOnlySubscribedEvents ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1O2( ) ;
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
         RF1O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV30Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettingsWC";
         edtavWwpnotificationdescription_Enabled = 0;
      }

      protected void RF1O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 14;
         /* Execute user event: Refresh */
         E131O2 ();
         nGXsfl_14_idx = 1;
         sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
         SubsflControlProps_142( ) ;
         bGXsfl_14_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_142( ) ;
            /* Execute user event: Grid.Load */
            E141O2 ();
            wbEnd = 14;
            WB1O0( ) ;
         }
         bGXsfl_14_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1O2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV30Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV30Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG1", StringUtil.RTrim( AV29Udparg1));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV29Udparg1, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(((subGrid_Recordcount==0) ? GRID_nFirstRecordOnPage+1 : subGrid_Recordcount)) ;
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
         return (int)(((subGrid_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGrid_fnc_Recordcount( )/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGrid_fnc_Recordcount( )) % (subGrid_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV30Pgmname, A125WWPEntityId, AV16WWPEntityId, A136WWPNotificationDefinitionAllow, A128WWPNotificationDefinitionId, A134WWPNotificationDefinitionDescr, A112WWPUserExtendedId, AV29Udparg1, A132WWPSubscriptionSubscribed, A124WWPSubscriptionRoleId, A130WWPSubscriptionId, A135WWPNotificationDefinitionAppli, A131WWPSubscriptionEntityRecordId, A133WWPSubscriptionEntityRecordDes, AV12NotifShowOnlySubscribedEvents, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV30Pgmname, A125WWPEntityId, AV16WWPEntityId, A136WWPNotificationDefinitionAllow, A128WWPNotificationDefinitionId, A134WWPNotificationDefinitionDescr, A112WWPUserExtendedId, AV29Udparg1, A132WWPSubscriptionSubscribed, A124WWPSubscriptionRoleId, A130WWPSubscriptionId, A135WWPNotificationDefinitionAppli, A131WWPSubscriptionEntityRecordId, A133WWPSubscriptionEntityRecordDes, AV12NotifShowOnlySubscribedEvents, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV30Pgmname, A125WWPEntityId, AV16WWPEntityId, A136WWPNotificationDefinitionAllow, A128WWPNotificationDefinitionId, A134WWPNotificationDefinitionDescr, A112WWPUserExtendedId, AV29Udparg1, A132WWPSubscriptionSubscribed, A124WWPSubscriptionRoleId, A130WWPSubscriptionId, A135WWPNotificationDefinitionAppli, A131WWPSubscriptionEntityRecordId, A133WWPSubscriptionEntityRecordDes, AV12NotifShowOnlySubscribedEvents, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV30Pgmname, A125WWPEntityId, AV16WWPEntityId, A136WWPNotificationDefinitionAllow, A128WWPNotificationDefinitionId, A134WWPNotificationDefinitionDescr, A112WWPUserExtendedId, AV29Udparg1, A132WWPSubscriptionSubscribed, A124WWPSubscriptionRoleId, A130WWPSubscriptionId, A135WWPNotificationDefinitionAppli, A131WWPSubscriptionEntityRecordId, A133WWPSubscriptionEntityRecordDes, AV12NotifShowOnlySubscribedEvents, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV30Pgmname, A125WWPEntityId, AV16WWPEntityId, A136WWPNotificationDefinitionAllow, A128WWPNotificationDefinitionId, A134WWPNotificationDefinitionDescr, A112WWPUserExtendedId, AV29Udparg1, A132WWPSubscriptionSubscribed, A124WWPSubscriptionRoleId, A130WWPSubscriptionId, A135WWPNotificationDefinitionAppli, A131WWPSubscriptionEntityRecordId, A133WWPSubscriptionEntityRecordDes, AV12NotifShowOnlySubscribedEvents, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV30Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettingsWC";
         edtavWwpnotificationdescription_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E121O2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_14 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_14"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV16WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV16WWPEntityId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV12NotifShowOnlySubscribedEvents = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV12NotifShowOnlySubscribedEvents"));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGrid_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvpanel_unnamedtable1_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE1_Width");
            Dvpanel_unnamedtable1_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE1_Autowidth"));
            Dvpanel_unnamedtable1_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE1_Autoheight"));
            Dvpanel_unnamedtable1_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE1_Cls");
            Dvpanel_unnamedtable1_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE1_Title");
            Dvpanel_unnamedtable1_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE1_Collapsible"));
            Dvpanel_unnamedtable1_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE1_Collapsed"));
            Dvpanel_unnamedtable1_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE1_Showcollapseicon"));
            Dvpanel_unnamedtable1_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE1_Iconposition");
            Dvpanel_unnamedtable1_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE1_Autoscroll"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
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
         E121O2 ();
         if (returnInSub) return;
      }

      protected void E121O2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavWwpnotificationdefinitionid_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpnotificationdefinitionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpnotificationdefinitionid_Visible), 5, 0), !bGXsfl_14_Refreshing);
         edtavWwpsubscriptionid_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_14_Refreshing);
         edtavWwpsubscriptionentityrecordid_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpsubscriptionentityrecordid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionentityrecordid_Visible), 5, 0), !bGXsfl_14_Refreshing);
         edtavWwpsubscriptionentityrecorddescription_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpsubscriptionentityrecorddescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionentityrecorddescription_Visible), 5, 0), !bGXsfl_14_Refreshing);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E131O2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV15WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
      }

      private void E141O2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         GXt_objcol_char1 = AV20WWPSubscriptionRoleIdCollection;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserroles(context ).execute( out  GXt_objcol_char1) ;
         AV20WWPSubscriptionRoleIdCollection = GXt_objcol_char1;
         AV9GridRecordCount = 0;
         /* Using cursor H001O2 */
         pr_default.execute(0, new Object[] {AV16WWPEntityId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A128WWPNotificationDefinitionId = H001O2_A128WWPNotificationDefinitionId[0];
            A135WWPNotificationDefinitionAppli = H001O2_A135WWPNotificationDefinitionAppli[0];
            A136WWPNotificationDefinitionAllow = H001O2_A136WWPNotificationDefinitionAllow[0];
            A125WWPEntityId = H001O2_A125WWPEntityId[0];
            A134WWPNotificationDefinitionDescr = H001O2_A134WWPNotificationDefinitionDescr[0];
            AV5WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            AssignAttri(sPrefix, false, edtavWwpnotificationdefinitionid_Internalname, StringUtil.LTrimStr( (decimal)(AV5WWPNotificationDefinitionId), 10, 0));
            AV18WWPNotificationDescriptionBase = A134WWPNotificationDefinitionDescr;
            AV17WWPNotificationDescription = AV18WWPNotificationDescriptionBase;
            AssignAttri(sPrefix, false, edtavWwpnotificationdescription_Internalname, AV17WWPNotificationDescription);
            AV11IncludeNotification = false;
            AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV11IncludeNotification);
            AV14SubscriptionLoaded = false;
            AV7WWPSubscriptionId = 0;
            AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV7WWPSubscriptionId), 10, 0));
            AV29Udparg1 = new WorkWithPlus.workwithplus_commongam.wwp_getloggeduserid(context).executeUdp( );
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A124WWPSubscriptionRoleId ,
                                                 AV20WWPSubscriptionRoleIdCollection ,
                                                 A112WWPUserExtendedId ,
                                                 AV29Udparg1 ,
                                                 A132WWPSubscriptionSubscribed ,
                                                 A128WWPNotificationDefinitionId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H001O3 */
            pr_default.execute(1, new Object[] {A128WWPNotificationDefinitionId, AV29Udparg1});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A124WWPSubscriptionRoleId = H001O3_A124WWPSubscriptionRoleId[0];
               n124WWPSubscriptionRoleId = H001O3_n124WWPSubscriptionRoleId[0];
               A132WWPSubscriptionSubscribed = H001O3_A132WWPSubscriptionSubscribed[0];
               A112WWPUserExtendedId = H001O3_A112WWPUserExtendedId[0];
               n112WWPUserExtendedId = H001O3_n112WWPUserExtendedId[0];
               A130WWPSubscriptionId = H001O3_A130WWPSubscriptionId[0];
               A131WWPSubscriptionEntityRecordId = H001O3_A131WWPSubscriptionEntityRecordId[0];
               A133WWPSubscriptionEntityRecordDes = H001O3_A133WWPSubscriptionEntityRecordDes[0];
               AV7WWPSubscriptionId = A130WWPSubscriptionId;
               AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV7WWPSubscriptionId), 10, 0));
               if ( A135WWPNotificationDefinitionAppli != 1 )
               {
                  if ( StringUtil.StrCmp(A131WWPSubscriptionEntityRecordId, "") != 0 )
                  {
                     AV6WWPSubscriptionEntityRecordDescription = A133WWPSubscriptionEntityRecordDes;
                     AssignAttri(sPrefix, false, edtavWwpsubscriptionentityrecorddescription_Internalname, AV6WWPSubscriptionEntityRecordDescription);
                     AV19WWPSubscriptionEntityRecordId = A131WWPSubscriptionEntityRecordId;
                     AssignAttri(sPrefix, false, edtavWwpsubscriptionentityrecordid_Internalname, AV19WWPSubscriptionEntityRecordId);
                     AV17WWPNotificationDescription = StringUtil.Format( "%1 (%2)", AV18WWPNotificationDescriptionBase, AV6WWPSubscriptionEntityRecordDescription, "", "", "", "", "", "", "");
                     AssignAttri(sPrefix, false, edtavWwpnotificationdescription_Internalname, AV17WWPNotificationDescription);
                     AV9GridRecordCount = (short)(AV9GridRecordCount+1);
                     AV11IncludeNotification = true;
                     AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV11IncludeNotification);
                     AV14SubscriptionLoaded = true;
                     /* Load Method */
                     if ( wbStart != -1 )
                     {
                        wbStart = 14;
                     }
                     if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
                     {
                        sendrow_142( ) ;
                     }
                     GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
                     GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
                     GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
                     subGrid_Recordcount = (int)(GRID_nCurrentRecord);
                     if ( isFullAjaxMode( ) && ! bGXsfl_14_Refreshing )
                     {
                        DoAjaxLoad(14, GridRow);
                     }
                  }
               }
               else
               {
                  AV9GridRecordCount = (short)(AV9GridRecordCount+1);
                  AV11IncludeNotification = true;
                  AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV11IncludeNotification);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A124WWPSubscriptionRoleId)) )
                  {
                     GXt_boolean2 = AV11IncludeNotification;
                     new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_checkuserisnotunsubscribed(context ).execute(  AV5WWPNotificationDefinitionId, ref  AV7WWPSubscriptionId, ref  GXt_boolean2) ;
                     AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV7WWPSubscriptionId), 10, 0));
                     AV11IncludeNotification = GXt_boolean2;
                     AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV11IncludeNotification);
                  }
                  if ( ! AV14SubscriptionLoaded )
                  {
                     /* Load Method */
                     if ( wbStart != -1 )
                     {
                        wbStart = 14;
                     }
                     if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
                     {
                        sendrow_142( ) ;
                     }
                     GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
                     GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
                     GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
                     subGrid_Recordcount = (int)(GRID_nCurrentRecord);
                     if ( isFullAjaxMode( ) && ! bGXsfl_14_Refreshing )
                     {
                        DoAjaxLoad(14, GridRow);
                     }
                  }
                  AV14SubscriptionLoaded = true;
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( ! AV14SubscriptionLoaded && ! AV11IncludeNotification && ( A135WWPNotificationDefinitionAppli != 2 ) && ! AV12NotifShowOnlySubscribedEvents )
            {
               AV9GridRecordCount = (short)(AV9GridRecordCount+1);
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 14;
               }
               if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
               {
                  sendrow_142( ) ;
               }
               GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
               subGrid_Recordcount = (int)(GRID_nCurrentRecord);
               if ( isFullAjaxMode( ) && ! bGXsfl_14_Refreshing )
               {
                  DoAjaxLoad(14, GridRow);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8GridPageCount = (short)(AV9GridRecordCount/ (decimal)(subGrid_Rows)+((((int)((AV9GridRecordCount) % (subGrid_Rows)))>0) ? 1 : 0));
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV13Session.Get(AV30Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV30Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV13Session.Get(AV30Pgmname+"GridState"), null, "", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV13Session.Get(AV30Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV30Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void E111O2( )
      {
         /* Tablesubscriptionitem_Click Routine */
         returnInSub = false;
         AV11IncludeNotification = (bool)(!AV11IncludeNotification);
         AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV11IncludeNotification);
         new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_userupdatesubscription(context ).execute(  AV11IncludeNotification, ref  AV7WWPSubscriptionId,  AV5WWPNotificationDefinitionId,  AV19WWPSubscriptionEntityRecordId,  AV6WWPSubscriptionEntityRecordDescription) ;
         AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV7WWPSubscriptionId), 10, 0));
         if ( 1 == 0 )
         {
            /* Start For Each Line */
            nRC_GXsfl_14 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_14"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_14_fel_idx = 0;
            while ( nGXsfl_14_fel_idx < nRC_GXsfl_14 )
            {
               nGXsfl_14_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_14_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_14_fel_idx+1);
               sGXsfl_14_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_142( ) ;
               AV11IncludeNotification = StringUtil.StrToBool( cgiGet( chkavIncludenotification_Internalname));
               AV17WWPNotificationDescription = cgiGet( edtavWwpnotificationdescription_Internalname);
               if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpnotificationdefinitionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpnotificationdefinitionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPNOTIFICATIONDEFINITIONID");
                  GX_FocusControl = edtavWwpnotificationdefinitionid_Internalname;
                  wbErr = true;
                  AV5WWPNotificationDefinitionId = 0;
               }
               else
               {
                  AV5WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwpnotificationdefinitionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPSUBSCRIPTIONID");
                  GX_FocusControl = edtavWwpsubscriptionid_Internalname;
                  wbErr = true;
                  AV7WWPSubscriptionId = 0;
               }
               else
               {
                  AV7WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               }
               AV19WWPSubscriptionEntityRecordId = cgiGet( edtavWwpsubscriptionentityrecordid_Internalname);
               AV6WWPSubscriptionEntityRecordDescription = cgiGet( edtavWwpsubscriptionentityrecorddescription_Internalname);
               /* End For Each Line */
            }
            if ( nGXsfl_14_fel_idx == 0 )
            {
               nGXsfl_14_idx = 1;
               sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
               SubsflControlProps_142( ) ;
            }
            nGXsfl_14_fel_idx = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table1_11_1O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtable1_Internalname, tblUnnamedtable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='SubscriptionsPanelCell'>") ;
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl14( ) ;
         }
         if ( wbEnd == 14 )
         {
            wbEnd = 0;
            nRC_GXsfl_14 = (int)(nGXsfl_14_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
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
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_11_1O2e( true) ;
         }
         else
         {
            wb_table1_11_1O2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV16WWPEntityId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV16WWPEntityId", StringUtil.LTrimStr( (decimal)(AV16WWPEntityId), 10, 0));
         AV12NotifShowOnlySubscribedEvents = (bool)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV12NotifShowOnlySubscribedEvents", AV12NotifShowOnlySubscribedEvents);
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
         PA1O2( ) ;
         WS1O2( ) ;
         WE1O2( ) ;
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
         sCtrlAV16WWPEntityId = (string)((string)getParm(obj,0));
         sCtrlAV12NotifShowOnlySubscribedEvents = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA1O2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\subscriptions\\wwp_subscriptionssettingswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA1O2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV16WWPEntityId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV16WWPEntityId", StringUtil.LTrimStr( (decimal)(AV16WWPEntityId), 10, 0));
            AV12NotifShowOnlySubscribedEvents = (bool)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV12NotifShowOnlySubscribedEvents", AV12NotifShowOnlySubscribedEvents);
         }
         wcpOAV16WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV16WWPEntityId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV12NotifShowOnlySubscribedEvents = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV12NotifShowOnlySubscribedEvents"));
         if ( ! GetJustCreated( ) && ( ( AV16WWPEntityId != wcpOAV16WWPEntityId ) || ( AV12NotifShowOnlySubscribedEvents != wcpOAV12NotifShowOnlySubscribedEvents ) ) )
         {
            setjustcreated();
         }
         wcpOAV16WWPEntityId = AV16WWPEntityId;
         wcpOAV12NotifShowOnlySubscribedEvents = AV12NotifShowOnlySubscribedEvents;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV16WWPEntityId = cgiGet( sPrefix+"AV16WWPEntityId_CTRL");
         if ( StringUtil.Len( sCtrlAV16WWPEntityId) > 0 )
         {
            AV16WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV16WWPEntityId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV16WWPEntityId", StringUtil.LTrimStr( (decimal)(AV16WWPEntityId), 10, 0));
         }
         else
         {
            AV16WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV16WWPEntityId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV12NotifShowOnlySubscribedEvents = cgiGet( sPrefix+"AV12NotifShowOnlySubscribedEvents_CTRL");
         if ( StringUtil.Len( sCtrlAV12NotifShowOnlySubscribedEvents) > 0 )
         {
            AV12NotifShowOnlySubscribedEvents = StringUtil.StrToBool( cgiGet( sCtrlAV12NotifShowOnlySubscribedEvents));
            AssignAttri(sPrefix, false, "AV12NotifShowOnlySubscribedEvents", AV12NotifShowOnlySubscribedEvents);
         }
         else
         {
            AV12NotifShowOnlySubscribedEvents = StringUtil.StrToBool( cgiGet( sPrefix+"AV12NotifShowOnlySubscribedEvents_PARM"));
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
         PA1O2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS1O2( ) ;
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
         WS1O2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV16WWPEntityId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16WWPEntityId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16WWPEntityId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16WWPEntityId_CTRL", StringUtil.RTrim( sCtrlAV16WWPEntityId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV12NotifShowOnlySubscribedEvents_PARM", StringUtil.BoolToStr( AV12NotifShowOnlySubscribedEvents));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV12NotifShowOnlySubscribedEvents)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV12NotifShowOnlySubscribedEvents_CTRL", StringUtil.RTrim( sCtrlAV12NotifShowOnlySubscribedEvents));
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
         WE1O2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309334087", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("wwpbaseobjects/subscriptions/wwp_subscriptionssettingswc.js", "?20256309334087", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_142( )
      {
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION_"+sGXsfl_14_idx;
         edtavWwpnotificationdescription_Internalname = sPrefix+"vWWPNOTIFICATIONDESCRIPTION_"+sGXsfl_14_idx;
         edtavWwpnotificationdefinitionid_Internalname = sPrefix+"vWWPNOTIFICATIONDEFINITIONID_"+sGXsfl_14_idx;
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID_"+sGXsfl_14_idx;
         edtavWwpsubscriptionentityrecordid_Internalname = sPrefix+"vWWPSUBSCRIPTIONENTITYRECORDID_"+sGXsfl_14_idx;
         edtavWwpsubscriptionentityrecorddescription_Internalname = sPrefix+"vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION_"+sGXsfl_14_idx;
      }

      protected void SubsflControlProps_fel_142( )
      {
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION_"+sGXsfl_14_fel_idx;
         edtavWwpnotificationdescription_Internalname = sPrefix+"vWWPNOTIFICATIONDESCRIPTION_"+sGXsfl_14_fel_idx;
         edtavWwpnotificationdefinitionid_Internalname = sPrefix+"vWWPNOTIFICATIONDEFINITIONID_"+sGXsfl_14_fel_idx;
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID_"+sGXsfl_14_fel_idx;
         edtavWwpsubscriptionentityrecordid_Internalname = sPrefix+"vWWPSUBSCRIPTIONENTITYRECORDID_"+sGXsfl_14_fel_idx;
         edtavWwpsubscriptionentityrecorddescription_Internalname = sPrefix+"vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION_"+sGXsfl_14_fel_idx;
      }

      protected void sendrow_142( )
      {
         sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
         SubsflControlProps_142( ) ;
         WB1O0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_14_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               subGrid_Backcolor = (int)(0xFFFFFF);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_14_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            /* Start of Columns property logic. */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subGrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_14_idx+"\">") ;
            }
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsgrid_Internalname+"_"+sGXsfl_14_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 SubscriptionItem",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablesubscriptionitem_Internalname+"_"+sGXsfl_14_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavIncludenotification_Internalname,context.GetMessage( "Include Notification", ""),(string)"gx-form-item AttributeCheckBoxLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'" + sGXsfl_14_idx + "',14)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vINCLUDENOTIFICATION_" + sGXsfl_14_idx;
            chkavIncludenotification.Name = GXCCtl;
            chkavIncludenotification.WebTags = "";
            chkavIncludenotification.Caption = context.GetMessage( "Include Notification", "");
            AssignProp(sPrefix, false, chkavIncludenotification_Internalname, "TitleCaption", chkavIncludenotification.Caption, !bGXsfl_14_Refreshing);
            chkavIncludenotification.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIncludenotification_Internalname,StringUtil.BoolToStr( AV11IncludeNotification),(string)"",context.GetMessage( "Include Notification", ""),(short)1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(21, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,21);\""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavWwpnotificationdescription_Internalname,context.GetMessage( "WWPNotification Description", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_14_idx + "',14)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpnotificationdescription_Internalname,(string)AV17WWPNotificationDescription,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"",(short)0,(short)1,(int)edtavWwpnotificationdescription_Enabled,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Table start */
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgrid_Internalname+"_"+sGXsfl_14_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavWwpnotificationdefinitionid_Internalname,context.GetMessage( "WWPNotification Definition Id", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'" + sGXsfl_14_idx + "',14)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpnotificationdefinitionid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPNotificationDefinitionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5WWPNotificationDefinitionId), "ZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,31);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwpnotificationdefinitionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavWwpnotificationdefinitionid_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)14,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavWwpsubscriptionid_Internalname,context.GetMessage( "WWPSubscription Id", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_14_idx + "',14)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpsubscriptionid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPSubscriptionId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7WWPSubscriptionId), "ZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwpsubscriptionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavWwpsubscriptionid_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)14,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavWwpsubscriptionentityrecordid_Internalname,context.GetMessage( "WWPSubscription Entity Record Id", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'" + sGXsfl_14_idx + "',14)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpsubscriptionentityrecordid_Internalname,(string)AV19WWPSubscriptionEntityRecordId,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"",(short)0,(int)edtavWwpsubscriptionentityrecordid_Visible,(short)1,(short)0,(short)80,(string)"chr",(short)10,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"2000",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavWwpsubscriptionentityrecorddescription_Internalname,context.GetMessage( "WWPSubscription Entity Record Description", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'" + sGXsfl_14_idx + "',14)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpsubscriptionentityrecorddescription_Internalname,(string)AV6WWPSubscriptionEntityRecordDescription,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(short)0,(int)edtavWwpsubscriptionentityrecorddescription_Visible,(short)1,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("row");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("table");
            }
            /* End of table */
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            send_integrity_lvl_hashes1O2( ) ;
            /* End of Columns property logic. */
            GridContainer.AddRow(GridRow);
            nGXsfl_14_idx = ((subGrid_Islastpage==1)&&(nGXsfl_14_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_14_idx+1);
            sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
            SubsflControlProps_142( ) ;
         }
         /* End function sendrow_142 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vINCLUDENOTIFICATION_" + sGXsfl_14_idx;
         chkavIncludenotification.Name = GXCCtl;
         chkavIncludenotification.WebTags = "";
         chkavIncludenotification.Caption = context.GetMessage( "Include Notification", "");
         AssignProp(sPrefix, false, chkavIncludenotification_Internalname, "TitleCaption", chkavIncludenotification.Caption, !bGXsfl_14_Refreshing);
         chkavIncludenotification.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl14( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"14\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV11IncludeNotification)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV17WWPNotificationDescription));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpnotificationdescription_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPNotificationDefinitionId), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpnotificationdefinitionid_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPSubscriptionId), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV19WWPSubscriptionEntityRecordId));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpsubscriptionentityrecordid_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV6WWPSubscriptionEntityRecordDescription));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpsubscriptionentityrecorddescription_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
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
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION";
         edtavWwpnotificationdescription_Internalname = sPrefix+"vWWPNOTIFICATIONDESCRIPTION";
         divTablesubscriptionitem_Internalname = sPrefix+"TABLESUBSCRIPTIONITEM";
         edtavWwpnotificationdefinitionid_Internalname = sPrefix+"vWWPNOTIFICATIONDEFINITIONID";
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID";
         edtavWwpsubscriptionentityrecordid_Internalname = sPrefix+"vWWPSUBSCRIPTIONENTITYRECORDID";
         edtavWwpsubscriptionentityrecorddescription_Internalname = sPrefix+"vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION";
         tblUnnamedtablecontentfsgrid_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSGRID";
         divUnnamedtablefsgrid_Internalname = sPrefix+"UNNAMEDTABLEFSGRID";
         tblUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         Dvpanel_unnamedtable1_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE1";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         edtavWwpsubscriptionid_Jsonclick = "";
         edtavWwpnotificationdefinitionid_Jsonclick = "";
         edtavWwpnotificationdescription_Enabled = 1;
         chkavIncludenotification.Caption = context.GetMessage( "Include Notification", "");
         subGrid_Class = "FreeStyleGrid";
         subGrid_Backcolorstyle = 0;
         Dvpanel_unnamedtable1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Iconposition = "Right";
         Dvpanel_unnamedtable1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Title = "";
         Dvpanel_unnamedtable1_Cls = "PanelNoHeader";
         Dvpanel_unnamedtable1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Width = "100%";
         edtavWwpsubscriptionentityrecorddescription_Visible = 1;
         edtavWwpsubscriptionentityrecordid_Visible = 1;
         edtavWwpsubscriptionid_Visible = 1;
         edtavWwpnotificationdefinitionid_Visible = 1;
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"edtavWwpnotificationdefinitionid_Visible","ctrl":"vWWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionentityrecordid_Visible","ctrl":"vWWPSUBSCRIPTIONENTITYRECORDID","prop":"Visible"},{"av":"edtavWwpsubscriptionentityrecorddescription_Visible","ctrl":"vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION","prop":"Visible"},{"av":"A125WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"AV16WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A134WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"},{"av":"A124WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"A130WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"A135WWPNotificationDefinitionAppli","fld":"WWPNOTIFICATIONDEFINITIONAPPLI","pic":"9"},{"av":"A131WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A133WWPSubscriptionEntityRecordDes","fld":"WWPSUBSCRIPTIONENTITYRECORDDES"},{"av":"AV12NotifShowOnlySubscribedEvents","fld":"vNOTIFSHOWONLYSUBSCRIBEDEVENTS"},{"av":"sPrefix"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV30Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29Udparg1","fld":"vUDPARG1","hsh":true}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E141O2","iparms":[{"av":"A125WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"AV16WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A134WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"AV29Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"},{"av":"A124WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"A130WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"A135WWPNotificationDefinitionAppli","fld":"WWPNOTIFICATIONDEFINITIONAPPLI","pic":"9"},{"av":"A131WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A133WWPSubscriptionEntityRecordDes","fld":"WWPSUBSCRIPTIONENTITYRECORDDES"},{"av":"AV12NotifShowOnlySubscribedEvents","fld":"vNOTIFSHOWONLYSUBSCRIBEDEVENTS"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV5WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"AV17WWPNotificationDescription","fld":"vWWPNOTIFICATIONDESCRIPTION"},{"av":"AV11IncludeNotification","fld":"vINCLUDENOTIFICATION"},{"av":"AV7WWPSubscriptionId","fld":"vWWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"AV6WWPSubscriptionEntityRecordDescription","fld":"vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION"},{"av":"AV19WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID"}]}""");
         setEventMetadata("TABLESUBSCRIPTIONITEM.CLICK","""{"handler":"E111O2","iparms":[{"av":"AV11IncludeNotification","fld":"vINCLUDENOTIFICATION","grid":14},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_14","ctrl":"GRID","grid":14,"prop":"GridRC","grid":14},{"av":"AV7WWPSubscriptionId","fld":"vWWPSUBSCRIPTIONID","grid":14,"pic":"ZZZZZZZZZ9"},{"av":"AV5WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","grid":14,"pic":"ZZZZZZZZZ9"},{"av":"AV19WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID","grid":14},{"av":"AV6WWPSubscriptionEntityRecordDescription","fld":"vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION","grid":14}]""");
         setEventMetadata("TABLESUBSCRIPTIONITEM.CLICK",""","oparms":[{"av":"AV11IncludeNotification","fld":"vINCLUDENOTIFICATION"},{"av":"AV7WWPSubscriptionId","fld":"vWWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"edtavWwpnotificationdefinitionid_Visible","ctrl":"vWWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionentityrecordid_Visible","ctrl":"vWWPSUBSCRIPTIONENTITYRECORDID","prop":"Visible"},{"av":"edtavWwpsubscriptionentityrecorddescription_Visible","ctrl":"vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION","prop":"Visible"},{"av":"A125WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"AV16WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A134WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"AV29Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"},{"av":"A124WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"A130WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"A135WWPNotificationDefinitionAppli","fld":"WWPNOTIFICATIONDEFINITIONAPPLI","pic":"9"},{"av":"A131WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A133WWPSubscriptionEntityRecordDes","fld":"WWPSUBSCRIPTIONENTITYRECORDDES"},{"av":"AV12NotifShowOnlySubscribedEvents","fld":"vNOTIFSHOWONLYSUBSCRIBEDEVENTS"},{"av":"sPrefix"},{"av":"AV30Pgmname","fld":"vPGMNAME","hsh":true},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"edtavWwpnotificationdefinitionid_Visible","ctrl":"vWWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionentityrecordid_Visible","ctrl":"vWWPSUBSCRIPTIONENTITYRECORDID","prop":"Visible"},{"av":"edtavWwpsubscriptionentityrecorddescription_Visible","ctrl":"vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION","prop":"Visible"},{"av":"A125WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"AV16WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A134WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"AV29Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"},{"av":"A124WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"A130WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"A135WWPNotificationDefinitionAppli","fld":"WWPNOTIFICATIONDEFINITIONAPPLI","pic":"9"},{"av":"A131WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A133WWPSubscriptionEntityRecordDes","fld":"WWPSUBSCRIPTIONENTITYRECORDDES"},{"av":"AV12NotifShowOnlySubscribedEvents","fld":"vNOTIFSHOWONLYSUBSCRIBEDEVENTS"},{"av":"sPrefix"},{"av":"AV30Pgmname","fld":"vPGMNAME","hsh":true},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"edtavWwpnotificationdefinitionid_Visible","ctrl":"vWWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionentityrecordid_Visible","ctrl":"vWWPSUBSCRIPTIONENTITYRECORDID","prop":"Visible"},{"av":"edtavWwpsubscriptionentityrecorddescription_Visible","ctrl":"vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION","prop":"Visible"},{"av":"A125WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"AV16WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A134WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"AV29Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"},{"av":"A124WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"A130WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"A135WWPNotificationDefinitionAppli","fld":"WWPNOTIFICATIONDEFINITIONAPPLI","pic":"9"},{"av":"A131WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A133WWPSubscriptionEntityRecordDes","fld":"WWPSUBSCRIPTIONENTITYRECORDDES"},{"av":"AV12NotifShowOnlySubscribedEvents","fld":"vNOTIFSHOWONLYSUBSCRIBEDEVENTS"},{"av":"sPrefix"},{"av":"AV30Pgmname","fld":"vPGMNAME","hsh":true},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"edtavWwpnotificationdefinitionid_Visible","ctrl":"vWWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionentityrecordid_Visible","ctrl":"vWWPSUBSCRIPTIONENTITYRECORDID","prop":"Visible"},{"av":"edtavWwpsubscriptionentityrecorddescription_Visible","ctrl":"vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION","prop":"Visible"},{"av":"A125WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"AV16WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A136WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A128WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A134WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A112WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"AV29Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A132WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"},{"av":"A124WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"A130WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"A135WWPNotificationDefinitionAppli","fld":"WWPNOTIFICATIONDEFINITIONAPPLI","pic":"9"},{"av":"A131WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A133WWPSubscriptionEntityRecordDes","fld":"WWPSUBSCRIPTIONENTITYRECORDDES"},{"av":"AV12NotifShowOnlySubscribedEvents","fld":"vNOTIFSHOWONLYSUBSCRIBEDEVENTS"},{"av":"sPrefix"},{"av":"AV30Pgmname","fld":"vPGMNAME","hsh":true},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"subGrid_Recordcount"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Wwpsubscriptionentityrecorddescription","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV30Pgmname = "";
         A134WWPNotificationDefinitionDescr = "";
         A112WWPUserExtendedId = "";
         AV29Udparg1 = "";
         A124WWPSubscriptionRoleId = "";
         A131WWPSubscriptionEntityRecordId = "";
         A133WWPSubscriptionEntityRecordDes = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         ucDvpanel_unnamedtable1 = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17WWPNotificationDescription = "";
         AV19WWPSubscriptionEntityRecordId = "";
         AV6WWPSubscriptionEntityRecordDescription = "";
         GXDecQS = "";
         AV15WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV20WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>();
         GXt_objcol_char1 = new GxSimpleCollection<string>();
         H001O2_A128WWPNotificationDefinitionId = new long[1] ;
         H001O2_A135WWPNotificationDefinitionAppli = new short[1] ;
         H001O2_A136WWPNotificationDefinitionAllow = new bool[] {false} ;
         H001O2_A125WWPEntityId = new long[1] ;
         H001O2_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         AV18WWPNotificationDescriptionBase = "";
         H001O3_A128WWPNotificationDefinitionId = new long[1] ;
         H001O3_A124WWPSubscriptionRoleId = new string[] {""} ;
         H001O3_n124WWPSubscriptionRoleId = new bool[] {false} ;
         H001O3_A132WWPSubscriptionSubscribed = new bool[] {false} ;
         H001O3_A112WWPUserExtendedId = new string[] {""} ;
         H001O3_n112WWPUserExtendedId = new bool[] {false} ;
         H001O3_A130WWPSubscriptionId = new long[1] ;
         H001O3_A131WWPSubscriptionEntityRecordId = new string[] {""} ;
         H001O3_A133WWPSubscriptionEntityRecordDes = new string[] {""} ;
         GridRow = new GXWebRow();
         AV13Session = context.GetSession();
         AV10GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV16WWPEntityId = "";
         sCtrlAV12NotifShowOnlySubscribedEvents = "";
         subGrid_Linesclass = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         GXCCtl = "";
         ROClassString = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscriptionssettingswc__default(),
            new Object[][] {
                new Object[] {
               H001O2_A128WWPNotificationDefinitionId, H001O2_A135WWPNotificationDefinitionAppli, H001O2_A136WWPNotificationDefinitionAllow, H001O2_A125WWPEntityId, H001O2_A134WWPNotificationDefinitionDescr
               }
               , new Object[] {
               H001O3_A128WWPNotificationDefinitionId, H001O3_A124WWPSubscriptionRoleId, H001O3_n124WWPSubscriptionRoleId, H001O3_A132WWPSubscriptionSubscribed, H001O3_A112WWPUserExtendedId, H001O3_n112WWPUserExtendedId, H001O3_A130WWPSubscriptionId, H001O3_A131WWPSubscriptionEntityRecordId, H001O3_A133WWPSubscriptionEntityRecordDes
               }
            }
         );
         AV30Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettingsWC";
         /* GeneXus formulas. */
         AV30Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettingsWC";
         edtavWwpnotificationdescription_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A135WWPNotificationDefinitionAppli ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short AV9GridRecordCount ;
      private short AV8GridPageCount ;
      private short subGrid_Backstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int edtavWwpnotificationdefinitionid_Visible ;
      private int edtavWwpsubscriptionid_Visible ;
      private int edtavWwpsubscriptionentityrecordid_Visible ;
      private int edtavWwpsubscriptionentityrecorddescription_Visible ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_14 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_14_idx=1 ;
      private int edtavWwpnotificationdescription_Enabled ;
      private int subGrid_Islastpage ;
      private int nGXsfl_14_fel_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV16WWPEntityId ;
      private long wcpOAV16WWPEntityId ;
      private long GRID_nFirstRecordOnPage ;
      private long A125WWPEntityId ;
      private long A128WWPNotificationDefinitionId ;
      private long A130WWPSubscriptionId ;
      private long AV5WWPNotificationDefinitionId ;
      private long AV7WWPSubscriptionId ;
      private long GRID_nCurrentRecord ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_14_idx="0001" ;
      private string edtavWwpnotificationdefinitionid_Internalname ;
      private string edtavWwpsubscriptionid_Internalname ;
      private string edtavWwpsubscriptionentityrecordid_Internalname ;
      private string edtavWwpsubscriptionentityrecorddescription_Internalname ;
      private string AV30Pgmname ;
      private string A112WWPUserExtendedId ;
      private string AV29Udparg1 ;
      private string A124WWPSubscriptionRoleId ;
      private string edtavWwpnotificationdescription_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_unnamedtable1_Width ;
      private string Dvpanel_unnamedtable1_Cls ;
      private string Dvpanel_unnamedtable1_Title ;
      private string Dvpanel_unnamedtable1_Iconposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_unnamedtable1_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavIncludenotification_Internalname ;
      private string GXDecQS ;
      private string sGXsfl_14_fel_idx="0001" ;
      private string tblUnnamedtable1_Internalname ;
      private string sCtrlAV16WWPEntityId ;
      private string sCtrlAV12NotifShowOnlySubscribedEvents ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string divUnnamedtablefsgrid_Internalname ;
      private string divTablesubscriptionitem_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string GXCCtl ;
      private string tblUnnamedtablecontentfsgrid_Internalname ;
      private string ROClassString ;
      private string edtavWwpnotificationdefinitionid_Jsonclick ;
      private string edtavWwpsubscriptionid_Jsonclick ;
      private string subGrid_Header ;
      private bool AV12NotifShowOnlySubscribedEvents ;
      private bool wcpOAV12NotifShowOnlySubscribedEvents ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_14_Refreshing=false ;
      private bool A136WWPNotificationDefinitionAllow ;
      private bool n112WWPUserExtendedId ;
      private bool A132WWPSubscriptionSubscribed ;
      private bool n124WWPSubscriptionRoleId ;
      private bool Dvpanel_unnamedtable1_Autowidth ;
      private bool Dvpanel_unnamedtable1_Autoheight ;
      private bool Dvpanel_unnamedtable1_Collapsible ;
      private bool Dvpanel_unnamedtable1_Collapsed ;
      private bool Dvpanel_unnamedtable1_Showcollapseicon ;
      private bool Dvpanel_unnamedtable1_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV11IncludeNotification ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV14SubscriptionLoaded ;
      private bool GXt_boolean2 ;
      private string A134WWPNotificationDefinitionDescr ;
      private string A131WWPSubscriptionEntityRecordId ;
      private string A133WWPSubscriptionEntityRecordDes ;
      private string AV17WWPNotificationDescription ;
      private string AV19WWPSubscriptionEntityRecordId ;
      private string AV6WWPSubscriptionEntityRecordDescription ;
      private string AV18WWPNotificationDescriptionBase ;
      private IGxSession AV13Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_unnamedtable1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavIncludenotification ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV15WWPContext ;
      private GxSimpleCollection<string> AV20WWPSubscriptionRoleIdCollection ;
      private GxSimpleCollection<string> GXt_objcol_char1 ;
      private IDataStoreProvider pr_default ;
      private long[] H001O2_A128WWPNotificationDefinitionId ;
      private short[] H001O2_A135WWPNotificationDefinitionAppli ;
      private bool[] H001O2_A136WWPNotificationDefinitionAllow ;
      private long[] H001O2_A125WWPEntityId ;
      private string[] H001O2_A134WWPNotificationDefinitionDescr ;
      private long[] H001O3_A128WWPNotificationDefinitionId ;
      private string[] H001O3_A124WWPSubscriptionRoleId ;
      private bool[] H001O3_n124WWPSubscriptionRoleId ;
      private bool[] H001O3_A132WWPSubscriptionSubscribed ;
      private string[] H001O3_A112WWPUserExtendedId ;
      private bool[] H001O3_n112WWPUserExtendedId ;
      private long[] H001O3_A130WWPSubscriptionId ;
      private string[] H001O3_A131WWPSubscriptionEntityRecordId ;
      private string[] H001O3_A133WWPSubscriptionEntityRecordDes ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV10GridState ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_subscriptionssettingswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001O3( IGxContext context ,
                                             string A124WWPSubscriptionRoleId ,
                                             GxSimpleCollection<string> AV20WWPSubscriptionRoleIdCollection ,
                                             string A112WWPUserExtendedId ,
                                             string AV29Udparg1 ,
                                             bool A132WWPSubscriptionSubscribed ,
                                             long A128WWPNotificationDefinitionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT WWPNotificationDefinitionId, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPUserExtendedId, WWPSubscriptionId, WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes FROM WWP_Subscription";
         AddWhere(sWhereString, "(WWPNotificationDefinitionId = :WWPNotificationDefinitionId)");
         AddWhere(sWhereString, "(( WWPUserExtendedId = ( :AV29Udparg1) and WWPSubscriptionSubscribed = TRUE) or "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV20WWPSubscriptionRoleIdCollection, "WWPSubscriptionRoleId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPNotificationDefinitionId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H001O3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (long)dynConstraints[5] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH001O2;
          prmH001O2 = new Object[] {
          new ParDef("AV16WWPEntityId",GXType.Int64,10,0)
          };
          Object[] prmH001O3;
          prmH001O3 = new Object[] {
          new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
          new ParDef("AV29Udparg1",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001O2", "SELECT WWPNotificationDefinitionId, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE (WWPEntityId = :AV16WWPEntityId) AND (WWPNotificationDefinitionAllow) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001O2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001O3,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 40);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                return;
       }
    }

 }

}
